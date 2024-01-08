#include "parser.h"

parser::parser()
{

}

void parser::receivedMessage(const QString &Message, QString &messageType, QString &senderName, QString &parsedMessage){
    QString data = Message;
    if(data.contains("/nick")){
        data.remove("/nick").remove(QRegExp("^\\s+"));;
    }
    QStringList fields = data.split('|', QString::SkipEmptyParts);
    QString key;
    QString value;

    for (const QString &field : fields) {
        QStringList keyValue = field.split(':', QString::SkipEmptyParts);
        if (keyValue.size() == 2) {
            key = keyValue[0].trimmed();
            value = keyValue[1].trimmed();

            if(key == "TYPE"){
                messageType = value;
            }

            if(key == "SENDER"){
                senderName = value;
            }
            if(key == "MESSAGE"){
                parsedMessage = value;
            }

        }

    }
}
void parser::crateAccount(const QString &Message, QString &userID, QString &userPW, QString &userBirth, QString &userName){
    QStringList lines = Message.split("\n",Qt::SkipEmptyParts);
    foreach (const QString& line, lines) {
        QString data = line;
        if(data.startsWith("db_id")){
            data.remove("db_id");
            userID =data;
        }
        else if(data.startsWith("db_pw")){
            data.remove("db_pw");
            userPW =data;
        }
        else if(data.startsWith("db_birth")){
            data.remove("db_birth");
            userBirth =data;
        }
        else if(data.startsWith("db_name")){
            data.remove("db_name");
            userName =data;
        }
    }
}

void parser::login(const QString &Message, QString &userID, QString &userPW){

    QStringList lines = Message.split("\n",Qt::SkipEmptyParts);
    foreach (const QString& line, lines) {
        QString data = line;

        if(data.startsWith("login_id")){
            data.remove("login_id");
            userID =data;
        }
        else if(data.startsWith("login_pw")){
            data.remove("login_pw");
            userPW =data;
        }
    }
}

void parser::findPassword(const QString &Message, QString &userID, QString &userBirth){
    QStringList lines = Message.split("\n",Qt::SkipEmptyParts);
    foreach (const QString& line, lines) {
        QString data = line;
        if(data.startsWith("find_id")){
            data.remove("find_id");
            userID =data;
        }
        else if(data.startsWith("find_birth")){
            data.remove("find_birth");
            userBirth =data;
        }
    }
}

//void parser::addToFriends(const QString &Message, QString &userID){      이후 친구추가
//    QStringList lines = Message.split("\n",Qt::SkipEmptyParts);
//    foreach (const QString& line, lines) {
//        QString data = line;
//        if(data.startsWith("find_id")){
//            data.remove("find_id");
//            userID =data;
//        }
//        else if(data.startsWith("find_birth")){
//            data.remove("find_birth");
//            userBirth =data;
//        }
//    }
//}









