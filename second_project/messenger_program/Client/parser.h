#ifndef PARSER_H
#define PARSER_H

#include <QString>
#include <QDebug>

class parser
{
public:
    parser();

    void receivedMessage(const QString &Message, QString &messageType, QString &senderName, QString &parsedMessage);
    void whoCommand(const QString &Message,  QString &messageType_who ,QString &parsedMessage_who,QString &parsedMessage_who_my,QString &parsedMessage_who_others);


};

#endif // PARSER_H
