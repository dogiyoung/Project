#include "randommodel.h"
#include <iostream>
#include <vector>
#include <algorithm>  // <- std:: shuffle 쓰기위해
#include <random>
#include <QDebug>


RandomModel::RandomModel(QObject *parent)
    : QAbstractListModel(parent)
{
}

int RandomModel::rowCount(const QModelIndex &parent) const
{
    if (parent.isValid())
        return 0;

    return ModelList6.count();
}

QVariant RandomModel::data(const QModelIndex &index, int role) const
{
    if (!index.isValid())
        return QVariant();

    if (role == Qt::DisplayRole || role == Qt::EditRole){
        return ModelList6.at(index.row());
    }

    return QVariant();
}

void RandomModel::shuffleMode4()
{
    copyrandommodel = ModelList6;
    ModelList6 = ModelList4;

    emit layoutChanged();

}


void RandomModel::shuffleMode6()
{

    ModelList6 = copyrandommodel;

    emit layoutChanged();

}
void RandomModel::shuffle()
{
    std::random_device rd;
    std::mt19937 gen(rd());
    std::shuffle(ModelList6.begin(), ModelList6.end(),gen);
       // qDebug() << "randommodel[i]";
    for(int i= 0; i < ModelList6.size(); ++i) //인덱스 탐색
    {
         ModelList6[i];
    }


    emit layoutChanged();


}

