#ifndef MYSERVER_H
#define MYSERVER_H

#include <QTcpServer>
#include <QTcpSocket>
#include <QtSql/QSqlQuery>
#include <QtSql/QSqlDatabase>
#include <QtSql/QSqlError>
#include "parser.h"

class Server : public QObject
{
    Q_OBJECT

public:
    explicit Server(QObject* parent = nullptr);
    Q_INVOKABLE bool startServer();
    Q_INVOKABLE void sendData(const QString &data);
    void parsingMessage(const QString &receivedMessage);
    void crateAccount(const QString &ID,const QString &PW,const QString &Birth,const QString &Name);
    void login(const QString &ID,const QString &PW);
    void updateUserName(const QString &ID, const QString &newName);
    void findPassword(const QString &ID,const QString &Birth);
    void addToFriends(const QString &ID);
    void sendData_notMe(const QString &data,QTcpSocket* sender);
    void sendData_nickCommand(const QString &data,QTcpSocket* sender);
    void sendData_whoCommand(QTcpSocket* sender);
    void sendData_whisperCommand(QString &data,QString &Name,QMap<QTcpSocket*,QString>,QTcpSocket* sender);
    void exitCommand();

signals:        // qml에서 사용하는 신호
    void sendMessage(const QString &sendMessage);
    void printMessage(const QString &printMessage);


public slots:
    void newConnection();   // 새로운 클라이언트 연결 처리
    void readData();        // 데이터 수신
    void disConnection();   // 클라이언트 연결 해제

private:
    QTcpServer* server;
    QSet<QTcpSocket*> clients;
    QMap<QTcpSocket*,QString> users;
    QMap<QTcpSocket*,QString> usersID;
    QStringList userList;
    QString userID;
    QString userPW;
    QString userBirth;
    QString userName;
};

#endif
