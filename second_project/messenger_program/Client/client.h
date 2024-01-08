#ifndef CLIENT_H
#define CLIENT_H

#include <QObject>
#include <QtSql>
#include <QTcpSocket>
#include <QDebug>
#include <QSqlQuery>
#include <QSqlDatabase>
#include <QSqlError>
#include "parser.h"

class Client : public QObject
{
    Q_OBJECT

public:
    explicit Client(QObject* parent = nullptr);
    void readData();
    void closeClient();
    void parsingMessage(const QString &receivedMessage);
    Q_INVOKABLE QString sendData(const QString &data);
    Q_INVOKABLE void crateAccount(const QString &id,const QString &password,const QString &birth,const QString &name);
    Q_INVOKABLE void login(const QString &ID,const QString &PW);
    Q_INVOKABLE void findPassword(const QString &ID,const QString &Name);


signals:        // qml에서 사용하는 신호
    void serverMessage(const QString &serverMessage);
    void clientMessage(const QString &clientMessage);
    void duplicateName(const QString &duplicateName);
    void changeName(const QString &changeName);
    void whisperMessage_read(const QString &whisperMessage_read);
    void whisperMessage_send(const QString &whisperMessage_send);
    void whoCommand(const QString &whoCommand);
    void connectMessage(const QString &connectMessage);
    void sendMessage(const QString &sendMessage);
    void crateMessage(const QString &crateMessage);
    void login_successMessage(const QString &login_successMessage);
    void login_failMessage(const QString &login_failMessage);
    void passwordMessage(const QString &passwordMessage);
    void printMessage(const QString &printMessage);


public slots:
    Q_INVOKABLE bool connectToServer(); // 서버연결

private:
    QTcpSocket* socket;
    QMap<QTcpSocket*,QString> users;

};

#endif
