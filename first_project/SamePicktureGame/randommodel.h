#ifndef RANDOMMODEL_H
#define RANDOMMODEL_H

#include <QAbstractListModel>

class RandomModel : public QAbstractListModel
{
    Q_OBJECT

public:
    explicit RandomModel( QObject *parent = nullptr);
    int rowCount(const QModelIndex &parent = QModelIndex()) const override;

    QVariant data(const QModelIndex &index, int role = Qt::DisplayRole) const override;

    Q_INVOKABLE void shuffleMode4();
    Q_INVOKABLE void shuffleMode6();
    Q_INVOKABLE void shuffle();


private:
    QVector<QString> copyrandommodel{};
    QVector<QString> ModelList4{

        "img/1.png",
        "img/2.png",
        "img/3.png",
        "img/4.png",
        "img/5.png",
        "img/6.png",
        "img/7.png",
        "img/8.png",
        "img/1.png",
        "img/2.png",
        "img/3.png",
        "img/4.png",
        "img/5.png",
        "img/6.png",
        "img/7.png",
        "img/8.png",
    };
    QVector<QString> ModelList6{
        "img/1.png",
        "img/2.png",
        "img/3.png",
        "img/4.png",
        "img/5.png",
        "img/6.png",
        "img/7.png",
        "img/8.png",
        "img/1.png",
        "img/2.png",
        "img/3.png",
        "img/4.png",
        "img/5.png",
        "img/6.png",
        "img/7.png",
        "img/8.png",
        "img/9.png",
        "img/10.png",
        "img/11.png",
        "img/12.png",
        "img/13.png",
        "img/14.png",
        "img/15.png",
        "img/16.png",
        "img/17.png",
        "img/18.png",
        "img/9.png",
        "img/10.png",
        "img/11.png",
        "img/12.png",
        "img/13.png",
        "img/14.png",
        "img/15.png",
        "img/16.png",
        "img/17.png",
        "img/18.png"
    };

};

#endif // RANDOMMODEL_H
