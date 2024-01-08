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
    QString key,value;

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

void parser::whoCommand(const QString &Message, QString &messageType_who, QString &parsedMessage_who,QString &parsedMessage_who_my,QString &parsedMessage_who_others){
    QString data;
    QString parsedMessage;
    QStringList lines = Message.split("\n",Qt::SkipEmptyParts);
    for (const QString &line : lines) {
        data = line;
        qDebug()<<"data";
        qDebug()<<data;
        QStringList fields = data.split('|', QString::SkipEmptyParts);
        QString key;
        QString value;

        for (const QString &field : fields) {
            QStringList keyValue = field.split(':', QString::SkipEmptyParts);
            if (keyValue.size() == 2) {
                key = keyValue[0].trimmed();
                value = keyValue[1].trimmed();

                if(key == "TYPE"){
                    messageType_who = value;
                }
                if(key == "MESSAGE"){
                    parsedMessage = value;
                }
            }
        }
        if(messageType_who == "whoCommand"){
            parsedMessage_who = parsedMessage;

        }
        else if(messageType_who == "who_myCommand"){
            parsedMessage_who_my=parsedMessage;

        }
        else if(messageType_who == "who_othersCommand"){
            parsedMessage_who_others=parsedMessage;

        }
    }
}





































