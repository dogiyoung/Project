//#include "randomlist.h"
//#include <iostream>
//#include <vector>
//#include <algorithm>  // <- std:: shuffle 쓰기위해
//#include <random>
//#include <QDebug>
//#include <QUrl>

//RandomList::RandomList(QObject *parent) : QObject(parent)
//{

//}

//void RandomList::shuffle()
//{
//    std::vector<QString> imagePaths {
//            "file:///C:/Users/user/Desktop/practice/cardGame/img/1.png",
//            "file:///C:/Users/user/Desktop/practice/cardGame/img/2.png",
//            "file:///C:/Users/user/Desktop/practice/cardGame/img/3.png",
//            "file:///C:/Users/user/Desktop/practice/cardGame/img/4.png",
//            "file:///C:/Users/user/Desktop/practice/cardGame/img/5.png",
//            "file:///C:/Users/user/Desktop/practice/cardGame/img/6.png",
//            "file:///C:/Users/user/Desktop/practice/cardGame/img/7.png",
//            "file:///C:/Users/user/Desktop/practice/cardGame/img/8.png"
//        };

//        // 난수 생성기 초기화
//        std::vector<int> numbers{1,2,3,4,5,6,7,8};
//        std::random_device rd;
//        std::mt19937 gen(rd());

//        // 벡터를 섞음
//        std::shuffle(numbers.begin(), numbers.end(), gen);

//        // 랜덤으로 생성된 숫자
//        for(const auto& number : numbers) {
//            //qDebug()<<number<< " ";

//        // 랜덤 숫자와 이미지 경로의 숫자를 비교하여 일치하는 이미지를 출력
//           if (number >= 1 && number <= 8) {
//            QString imagePath = imagePaths[number - 1];
//            //std::cout << imagePath.toStdString() << std::endl;
//             QUrl imageUrl(imagePath);
//             qDebug() << imageUrl;



//            // imagePath를 사용하여 이미지를 불러와서 처리하는 코드를 추가할 수 있습니다.
//        } else {
//            std::cout << "Invalid random number." << std::endl;
//        }
//        }

//        std::vector<int> numbers1{1,2,3,4,5,6,7,8};
//        std::random_device rd1;
//        std::mt19937 gen1(rd1());

//        // 벡터를 섞음
//        std::shuffle(numbers1.begin(), numbers1.end(), gen);

//        // 랜덤으로 생성된 숫자
//        for(const auto& number1 : numbers1) {
//           // qDebug()<<number1<< " ";

//        // 랜덤 숫자와 이미지 경로의 숫자를 비교하여 일치하는 이미지를 출력
//           if (number1 >= 1 && number1 <= 8) {
//            QString imagePath = imagePaths[number1 - 1];
//            std::cout << imagePath.toStdString() << std::endl;
//            // imagePath를 사용하여 이미지를 불러와서 처리하는 코드를 추가할 수 있습니다.
//        } else {
//            std::cout << "Invalid random number." << std::endl;
//        }
//        }

//}
