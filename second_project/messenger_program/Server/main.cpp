#include <QCoreApplication>
#include <QGuiApplication>
#include <QQmlApplicationEngine>
#include "server.h"


int main(int argc, char *argv[])
{
    QGuiApplication app(argc, argv);
    QQmlApplicationEngine engine;

    qmlRegisterType<Server>("Server", 1, 0, "Server");

    engine.load(QUrl(QStringLiteral("qrc:/main.qml")));
    if (engine.rootObjects().isEmpty()) {
        return -1;
    }


    return app.exec();
}
