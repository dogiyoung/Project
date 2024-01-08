#ifndef PARSER_H
#define PARSER_H

#include <QString>
#include <QDebug>

class parser
{
public:
    parser();

    void receivedMessage(const QString &Message, QString &messageType, QString &senderName, QString &parsedMessage);
    void crateAccount(const QString &Message, QString &ID, QString &PW, QString &Birth, QString &Name);
    void login(const QString &Message, QString &userID, QString &userPW);
    void findPassword(const QString &Message, QString &userID, QString &userBirth);
};

#endif // PARSER_H
