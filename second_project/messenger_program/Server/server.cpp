#include "server.h"

Server::Server(QObject* parent) : QObject(parent)
{
    server = new QTcpServer(this);
    connect(server, &QTcpServer::newConnection, this, &Server::newConnection);
}

bool Server::startServer()                          // 서버 시작
{
    if (server->listen(QHostAddress::Any, 8080))    // any를 통해 모든 ip연결 가능
    {
        return true;
    }
    else
    {
        return false;
    }
}


void Server::newConnection()
{
    while (server->hasPendingConnections()) {                       //클라이언트 대기중
        QTcpSocket* Client = server->nextPendingConnection();       //클라이언트와 통신
        connect(Client, &QTcpSocket::readyRead, this, &Server::readData);
        connect(Client, &QTcpSocket::disconnected, this, &Server::disConnection);
    }
}

void Server::crateAccount(const QString &ID,const QString &PW,const QString &Birth,const QString &Name){    // 회원가입
    QTcpSocket* clientSocket = static_cast<QTcpSocket*>(sender());
    QSqlDatabase db = QSqlDatabase::addDatabase("QSQLITE");
    db.setDatabaseName("database.db"); // SQLite 데이터베이스 파일명

    if (!db.open()) {
        qWarning() << "Error: Cannot open database";
        return;
    }
    QSqlQuery checkQuery;
    checkQuery.prepare("SELECT ID, PW, Birth, Name FROM userData WHERE ID = :ID OR PW = :PW OR Birth = :Birth OR Name = :Name");
    checkQuery.bindValue(":ID", ID);
    checkQuery.bindValue(":PW", PW);
    checkQuery.bindValue(":Birth", Birth);
    checkQuery.bindValue(":Name", Name);

    if (checkQuery.exec()) {
        bool idExists = false;
        bool nameExists = false;

        while (checkQuery.next()) {
            userID = checkQuery.value(0).toString();
            userPW = checkQuery.value(1).toString();
            userBirth = checkQuery.value(2).toString();
            userName = checkQuery.value(3).toString();

            if (userID == ID) {
                idExists = true;
            }

            if (userName == Name) {
                nameExists = true;
            }
        }
        if (!idExists && !nameExists) {                 // id, name 중복 체크
            QSqlQuery insertQuery;
            insertQuery.prepare("INSERT INTO userData (ID, PW, Birth, Name) VALUES (:ID, :PW, :Birth, :Name)");
            insertQuery.bindValue(":ID", ID);
            insertQuery.bindValue(":PW", PW);
            insertQuery.bindValue(":Birth", Birth);
            insertQuery.bindValue(":Name", Name);

            if (insertQuery.exec()) {
                QString message = "TYPE:crateAccount_success|SENDER:|MESSAGE:회원가입이 완료되었습니다.|";
                usersID[clientSocket] = userID;


                clientSocket->write(message.toUtf8());
            } else {
                qDebug() << "회원가입에 실패하였습니다.";
            }
        }
        else if(idExists){       // id 중복일 경우
            QString message = "TYPE:crateAccount_idExists|SENDER:|MESSAGE:이미 사용중인 아이디입니다.|";
            clientSocket->write(message.toUtf8());
        }
        else if(nameExists){    // name 중복일 경우
            QString message = "TYPE:crateAccount_nameExists|SENDER:|MESSAGE:이미 사용중인 이름입니다.|";
            clientSocket->write(message.toUtf8());
        }
    }

    else {
        qDebug() << "Error: Cannot execute query";
    }
    db.close();
}

void Server::login(const QString &ID,const QString &PW){    // 로그인
    QTcpSocket* clientSocket = static_cast<QTcpSocket*>(sender());
    QSqlDatabase db = QSqlDatabase::addDatabase("QSQLITE");
    db.setDatabaseName("database.db"); // SQLite 데이터베이스 파일명


    if (!db.open()) {
        qWarning() << "Error: Cannot open database";
        return;
    }
    QSqlQuery checkQuery;
    checkQuery.prepare("SELECT ID, PW, Name FROM userData WHERE ID = :ID OR PW = :PW OR Name = :userName" );
    checkQuery.bindValue(":ID", ID);
    checkQuery.bindValue(":PW", PW);
    checkQuery.bindValue(":userName", userName);

    QString db_id, db_pw;
    if (checkQuery.exec()) {
        bool loginSuccessful = false;
        while (checkQuery.next()) {
            db_id = checkQuery.value(0).toString();
            db_pw = checkQuery.value(1).toString();

            if (db_id==ID && db_pw==PW) {                       // id,password 체크
                userID =checkQuery.value(0).toString();
                userPW = checkQuery.value(1).toString();
                userName= checkQuery.value(2).toString();
                usersID[clientSocket] = userID;         // userID 저장
                loginSuccessful = true;
                break;
            }
        }
        if(loginSuccessful){
            QString loginSuccessful = "TYPE:loginSuccessful|SENDER:|MESSAGE:닉네임 "+userName+"님으로 대화방에 입장하였습니다.\n도움말이 필요하면 /h 를 입력하세요.|";

            clientSocket->write(loginSuccessful.toUtf8());
            clients.insert(clientSocket);
            users[clientSocket] =userName;
            userList.clear();
            foreach(QString user, users.values()){         // QMap에 있는 이름을 uesrList로 전달
                userList << user;

                emit printMessage(userName+" 님이 입장했습니다.");
                emit printMessage("현재 접속 : "+userList.join(","));
                emit printMessage("현재 접속자 수는 "+QString::number(clients.size())+"명 입니다.");
                qDebug() <<"로그인에 성공했습니다.";
                qDebug() <<loginSuccessful;
            }
        }
        else{
            QString message = "TYPE:loginFail|SENDER:|MESSAGE:로그인에 실패했습니다.|";
            clientSocket->write(message.toUtf8());
            qDebug()<<message;
        }
    }
    else {
        qDebug() << "Error: Cannot execute query";
    }
    db.close();
}


void Server::updateUserName(const QString &ID, const QString &Name) {    // 이름 변경
    QTcpSocket* clientSocket = static_cast<QTcpSocket*>(sender());
    QSqlDatabase db = QSqlDatabase::addDatabase("QSQLITE");
    db.setDatabaseName("database.db");

    if (!db.open()) {
        qWarning() << "Error: Cannot open database";
        return;
    }

    QSqlQuery checkQuery;
    checkQuery.prepare("SELECT Name FROM userData WHERE Name = :Name");
    checkQuery.bindValue(":Name", Name);

    if (checkQuery.exec()) {
        bool nameExists = false;

        while (checkQuery.next()) {
            QString db_name = checkQuery.value(0).toString();
            if (db_name == Name) {
                nameExists = true;
                break;
            }
        }
        if (!nameExists) {
            QSqlQuery updateQuery;
            updateQuery.prepare("UPDATE userData SET Name = :Name WHERE ID = :ID");
            updateQuery.bindValue(":Name", Name);
            updateQuery.bindValue(":ID", ID);

            if (updateQuery.exec()) {
                qDebug() <<"이름변경 완료";
                userName = Name;
                QString message = "TYPE:updateUserName|SENDER:|MESSAGE:"+users[clientSocket]+" 님이 "+Name+"으로 이름을 변경했습니다.|";
                QString emitMessage = users[clientSocket]+" 님이 "+Name+"으로 이름을 변경했습니다.";
                users[clientSocket] = Name;
                emit printMessage(emitMessage);
                foreach (QTcpSocket* Client, clients)
                {
                    if (Client != clientSocket) {
                        Client->write(message.toUtf8());
                    }
                }
            }
        }
        else if(nameExists){
            QString message = "TYPE:updateUserName_nameExists|SENDER:|MESSAGE:중복된 이름입니다. 다시 입력해주세요|";
            qDebug() <<message;
            clientSocket->write(message.toUtf8());
        }
    }

    else {
        qDebug() << "Error: Cannot execute query";
    }
    db.close();

}


void Server::findPassword(const QString &ID,const QString &Birth){
    QTcpSocket* clientSocket = static_cast<QTcpSocket*>(sender());
    QSqlDatabase db = QSqlDatabase::addDatabase("QSQLITE");
    db.setDatabaseName("database.db");

    if (!db.open()) {
        qWarning() << "Error: Cannot open database";
        return;
    }
    QSqlQuery checkQuery;
    checkQuery.prepare("SELECT ID, Birth, PW FROM userData WHERE ID = :ID  OR Birth = :Birth OR PW = :userPW" );
    checkQuery.bindValue(":ID", ID);
    checkQuery.bindValue(":Birth", Birth);
    checkQuery.bindValue(":userPW", userPW);

    if (checkQuery.exec()) {
        bool idExists = false;
        while (checkQuery.next()) {
            QString db_id = checkQuery.value(0).toString();
            QString db_birth = checkQuery.value(1).toString();
            if (db_id == ID && db_birth == Birth) {         // 입력한 id, password가 db에 있나 체크
                userPW=checkQuery.value(2).toString();
                idExists = true;
            }
        }
        if(!idExists){
            QString message = "TYPE:findPassword_!idExists|SENDER:|MESSAGE:아이디와 생년월일을 다시 확인해주세요|";
            clientSocket->write(message.toUtf8());
        }
        else{
            QString message = "TYPE:findPassword_idExists|SENDER:|MESSAGE:Client 님의 비밀번호는 "+userPW+"입니다.|";
            clientSocket->write(message.toUtf8());
            qDebug() <<message;
        }
    }
    else {
        qDebug() << "Error: Cannot execute query";
    }
    db.close();
}

void Server::addToFriends(const QString &ID){
    QTcpSocket* clientSocket = static_cast<QTcpSocket*>(sender());
    QSqlDatabase db = QSqlDatabase::addDatabase("QSQLITE");
    db.setDatabaseName("database.db");

    if (!db.open()) {
        qWarning() << "Error: Cannot open database";
        return;
    }
    QSqlQuery checkQuery;
    checkQuery.prepare("SELECT ID FROM userData WHERE ID = :ID");
    checkQuery.bindValue(":ID", ID);

    QString db_id;
    if (checkQuery.exec()) {
        bool idExists = false;
        while (checkQuery.next()) {
            db_id = checkQuery.value(0).toString();

            if (db_id == ID) {
                idExists = true;
            }
        }
        if(idExists){
            QString message = "TYPE:addToFriends_idExists|SENDER:|MESSAGE:친구추가에 성공했습니다.\n"+ID+"|";
            clientSocket->write(message.toUtf8());
            qDebug()<<message;
        }
        else{
            QString message = "TYPE:addToFriends_!idExists|SENDER:|MESSAGE:존재하지 않는 아이디입니다.|";
            clientSocket->write(message.toUtf8());
            qDebug()<<message;
        }
    }
    else {
        qDebug() << "Error: Cannot execute query";
    }
    db.close();
}

void Server::readData()                                                  // 클라이언트에서 받은 message 수신
{
    QTcpSocket* clientSocket = static_cast<QTcpSocket*>(sender());
    if(clientSocket){
        QString data = clientSocket->readAll();
        parsingMessage(data);
    }
}

void Server::parsingMessage(const QString &receivedMessage){
    QTcpSocket* clientSocket = static_cast<QTcpSocket*>(sender());
    QString messageType, senderName, parsedMessage;
    parser pInstance;
    pInstance.receivedMessage(receivedMessage,messageType,senderName,parsedMessage);
    // parser에서 messageType, senderName, parsedMessage; 정의

    if(messageType == "NICK"){
        updateUserName(usersID[clientSocket],senderName);
    }
    else if (messageType =="WHO"){
        sendData_whoCommand(clientSocket);
    }
    else if (messageType =="WHISPER"){
        sendData_whisperCommand(parsedMessage,senderName,users,clientSocket);
    }
    else if(messageType == "EXIT"){
        exitCommand();
    }

    else if(messageType == "crateAccount"){     // 회원 가입
        pInstance.crateAccount(receivedMessage,userID,userPW,userBirth,userName);
        crateAccount(userID,userPW,userBirth,userName);
    }

    else if(messageType =="login"){     // 로그인
        pInstance.login(receivedMessage,userID,userPW);
        login(userID,userPW);
    }
    else if(messageType =="findPassword"){     // 비밀번호 찾기
        pInstance.findPassword(receivedMessage,userID,userBirth);
        findPassword(userID,userBirth);
    }
    else if(messageType =="clientMessage"){
        sendData_notMe(parsedMessage,clientSocket);     // 해당 클라이언트 제외 클라이언트에  message 전송
    }
    //  else if(data.startsWith("friend_id")){  // 친구 추가
    //      data.remove("friend_id");
    //      qDebug()<<data;
    //      addToFriends(data);
    //  }

}

void Server::exitCommand(){                     // 채팅방 퇴장
    QTcpSocket* clientSocket = static_cast<QTcpSocket*>(sender());

    if (clientSocket) {
        emit printMessage(users[clientSocket]+" 님이 퇴장했습니다.");
        userList.removeAll(users[clientSocket]);
        clients.remove(clientSocket);
        users.remove(clientSocket);
        usersID.remove(clientSocket);
        emit printMessage("현재 접속자 수는 "+QString::number(clients.size())+"명 입니다.");
    }
}

void Server::disConnection(){                 // 클라이언트 종료
    QTcpSocket* clientSocket = static_cast<QTcpSocket*>(sender());
    if (clientSocket) {
        emit printMessage(users[clientSocket]+" 님이 퇴장했습니다.");
        userList.removeAll(users[clientSocket]);
        clients.remove(clientSocket);
        users.remove(clientSocket);
        usersID.remove(clientSocket);
        clientSocket->deleteLater();         // 클라이언트 소켓 정리
        emit printMessage("현재 접속자 수는 "+QString::number(clients.size())+"명 입니다.");
    }
}

void Server::sendData(const QString &data)  // 모든 클라이언트에게 message 전송
{
    QString message = "TYPE:Server|SENDER:|MESSAGE:"+data+"|";
    emit sendMessage(data);
    foreach (QTcpSocket* Client, clients)
    {
        Client->write(message.toUtf8());
    }
}

void Server::sendData_notMe(const QString &data,QTcpSocket* sender)       // 해당 클라이언트 제외 클라이언트에  message 전송
{
    QString message = "TYPE:message_Client|SENDER:|MESSAGE:"+users[sender]+">>"+ data+"|";
    foreach (QTcpSocket* Client, clients)
    {
        if (Client != sender) {
            Client->write(message.toUtf8());
        }
    }
}

void Server::sendData_whoCommand(QTcpSocket* sender)                      // who 커맨드 사용시 전송
{
    QString member,data;
    if (sender) {
        QString message = "TYPE:whoCommand|MESSAGE:대화방에 총 " +QString::number(clients.size())+ "명이 있습니다.|\n";
        sender->write(message.toUtf8());
        foreach(QString user, users){
            QHostAddress clientIp = sender->peerAddress();
            QString ClientIp = clientIp.toString();
            if (ClientIp.startsWith("::ffff:")) {
                ClientIp.remove(0, 7); // "::ffff:" 문자열의 길이인 7개의 문자를 제거
            }
            member = user + "("+ClientIp+")";

            if(member.contains(users[sender])){
                data = "TYPE:who_myCommand|MESSAGE:"+member+"-나|\n";
            }
            else {
                data = "TYPE:who_othersCommand|MESSAGE:"+member+"|\n";
            }
            sender->write(data.toUtf8());
        }
    }
}


void Server::sendData_whisperCommand(QString &data,QString &Name,QMap<QTcpSocket*,QString>users,QTcpSocket* sender)   // w 커맨드 사용시 전송
{
    foreach (QTcpSocket* Client, clients){
        if (users[Client] == Name) {
            QString message = "TYPE:whisperCommand|SENDER:|MESSAGE:"+users[sender]+" 님의 귓속말>> "+data+"|";
            Client->write(message.toUtf8());
        }
    }
}
