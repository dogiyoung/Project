#include "client.h"

Client::Client(QObject* parent) : QObject(parent)
{
    socket = new QTcpSocket(this);
}

bool Client::connectToServer()                // 서버 연결
{
    socket->connectToHost("127.0.0.1", 8080); // 서버 IP 주소 및 포트 번호
    if (socket->waitForConnected(3000))
    {
        connect(socket, &QTcpSocket::readyRead, this, &Client::readData);
        return true;
    }
    else
    {
        return false;
    }
}


void Client::crateAccount(const QString &ID,const QString &PW,const QString &Birth,const QString &Name){    // 회원가입
    QString message = "TYPE:crateAccount|SENDER:""|MESSAGE:\ndb_id"+ID+"\n"+"db_pw"+PW+"\n"+"db_birth"+Birth+"\n"+"db_name"+Name;
    socket->write(message.toUtf8());

}

void Client:: login(const QString &ID,const QString &PW){   // 로그인
    QString message = "TYPE:login|SENDER:""|MESSAGE:\nlogin_id"+ID+"\n"+"login_pw"+PW;
    socket->write(message.toUtf8());

}

void Client::findPassword(const QString &ID,const QString &Birth){  //비밀번호 찾기
    QString message = "TYPE:findPassword|SENDER:""|MESSAGE:\nfind_id"+ID+"\n"+"find_birth"+Birth;
    socket->write(message.toUtf8());

}

QString Client::sendData(const QString &data)   // 서버에 message 송신
{
    QString whisperMessage = data;
    if(whisperMessage.startsWith("/w")&&!whisperMessage.startsWith("/who")){
        whisperMessage.remove("/w");
        QStringList fields = whisperMessage.split(" ", QString::SkipEmptyParts);
        QString name;
        QString sendData;
        if (fields.size() == 2) {
            name = fields[0].trimmed();
            sendData = fields[1].trimmed();
        }

        emit printMessage("귓속말>> "+sendData);
        QString message = "TYPE:WHISPER|SENDER:"+name+"|MESSAGE:"+sendData+"|";
        socket->write(message.toUtf8());
    }
    else if(data.startsWith("/exit")){
        QString message = "TYPE:EXIT|SENDER:""|MESSAGE:|";
        socket->write(message.toUtf8());
        return "/exit";
    }
    else if(data.startsWith("/nick")){
        QString message = "TYPE:NICK|SENDER:"+data+"|MESSAGE:|";
        socket->write(message.toUtf8());
    }
    else if(data.startsWith("/who")){
        QString message = "TYPE:WHO|SENDER:|MESSAGE:|";
        socket->write(message.toUtf8());
    }
    else{
        QString clientMessage = "보낸 메시지>> "+data;
        emit printMessage(clientMessage);
        clientMessage.remove("보낸 메시지>> ");
        QString message = "TYPE:clientMessage|SENDER:|MESSAGE:"+clientMessage+"|";
        socket->write(message.toUtf8());

    }

    return "true";
}

void Client::readData()                     // 서버에서 받은 message 수신
{
    if(sender()==socket){
        QString data = socket->readAll();
        parsingMessage(data);
    }
}

void Client::parsingMessage(const QString &receivedMessage){
    QString messageType, messageType_who, senderName, parsedMessage;
    QString parsedMessage_who, parsedMessage_who_my, parsedMessage_who_others;
    parser pInstance;

    pInstance.receivedMessage(receivedMessage,messageType,senderName,parsedMessage);
    QStringList lines = receivedMessage.split("\n",Qt::SkipEmptyParts);
    for (const QString &line : lines) {
        QString data = line;
        pInstance.whoCommand(data,messageType_who,parsedMessage_who,parsedMessage_who_my,parsedMessage_who_others);
        if(messageType_who =="whoCommand"){            // who 커맨드
            emit printMessage(parsedMessage_who);
        }
        else if(messageType_who =="who_myCommand"){         // who 커맨드(-나 표시)
            emit printMessage(parsedMessage_who_my);
        }
        else if(messageType_who =="who_othersCommand"){     // who 커맨드(다른 접속자)
            emit printMessage(parsedMessage_who_others);
        }
    }

    if(messageType == "Server"){                    // server에서 받은 메시지
        emit printMessage("공지사항>> " + parsedMessage);
    }
    else if(messageType == "message_Client"){       // client에서 받은 메시지
        emit printMessage(parsedMessage);
    }
    else if(messageType =="whisperCommand"){        // whisper 커맨드
        emit printMessage(parsedMessage);
    }
    else if(messageType =="crateAccount_success"){  // 회원가입 성공
        emit crateMessage(parsedMessage);
    }
    else if(messageType =="crateAccount_idExists"||messageType =="crateAccount_nameExists"){
        emit crateMessage(parsedMessage);           // 회원가입 실패(id,name 중복)
    }
    else if(messageType =="loginSuccessful"){       // 로그인 성공
        emit login_successMessage(parsedMessage);
        QStringList lines = parsedMessage.split("\n",Qt::SkipEmptyParts);
        QString enter=lines[0].trimmed();
        QString help=lines[1].trimmed();
        emit printMessage(enter);       // 대화방에 입장
        emit printMessage(help);        // 도움말
    }
    else if(messageType =="loginFail"){             // 로그인 실패
        emit login_failMessage(parsedMessage);
    }
    else if(messageType =="updateUserName"){        // 이름 변경
        emit printMessage(parsedMessage);
    }
    else if(messageType =="updateUserName_nameExists"){      // 이름 변경 실패(name 중복)
        emit printMessage(parsedMessage);
    }
    else if(messageType =="findPassword_!idExists"){        // 비밀번호 찾기 실패
        emit passwordMessage(parsedMessage);
    }
    else if(messageType =="findPassword_idExists"){         // 비밀번호 찾기 성공
        emit passwordMessage(parsedMessage);
    }
}

void Client::closeClient(){     // 서버와 연결 종료
    socket->close();
    users.remove(socket);
}
