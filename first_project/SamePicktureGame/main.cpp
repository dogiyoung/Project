#include <QGuiApplication>
#include <QQmlApplicationEngine>
#include "randomlist.h"
#include <QQmlContext>
#include "randommodel.h"



int main(int argc, char *argv[])
{
    qputenv("QT_IM_MODULE", QByteArray("qtvirtualkeyboard"));

#if QT_VERSION < QT_VERSION_CHECK(6, 0, 0)
    QCoreApplication::setAttribute(Qt::AA_EnableHighDpiScaling);
#endif
    QGuiApplication app(argc, argv);

    QQmlApplicationEngine engine;

    qmlRegisterType<RandomModel>("RandomModel", 1, 0, "RandomModel");   // cpp 클래스 연결

//    RandomModel rl;

//    engine.rootContext()->setContextProperty("randomlist", &rl);


       engine.load(QUrl(QStringLiteral("qrc:/main.qml")));
       if (engine.rootObjects().isEmpty())
           return -1;
    return app.exec();
}

void quitApplication() {
    QGuiApplication::quit();
}
