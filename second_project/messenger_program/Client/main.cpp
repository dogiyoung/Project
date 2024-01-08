#include <QCoreApplication>
#include <QGuiApplication>
#include <QQmlApplicationEngine>
#include "client.h"

int main(int argc, char *argv[])
{


    QGuiApplication app(argc, argv);
    QQmlApplicationEngine engine;

    qmlRegisterType<Client>("Client", 1, 0, "Client");

    engine.load(QUrl(QStringLiteral("qrc:/main.qml")));
    if (engine.rootObjects().isEmpty()) {
        return -1;
    }


    return app.exec();
}
