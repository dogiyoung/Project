import QtQuick 2.12
import QtQuick.Window 2.12
import QtQuick.VirtualKeyboard 2.4
import QtQuick.Layouts 1.2
import QtQml 2.0
import QtQuick.Controls 1.4
import RandomModel 1.0
import QtMultimedia 5.12
import QtQuick.Dialogs 1.3

Window {
    id: idWindow
    visible: true
    width: 600
    height: 600
    title: qsTr("SamePicktureGame")

    // 변수 선언
    RandomModel { id: randomList}
    property int selectcount: 0
    property var clickedImages: []
    property int premodel: 1
    property int count: 0
    property int score: 0
    property var isMatch: []
    property bool isClick: false
    property int countDown: 60
    property var checkModel: []

    Text{
        text: "Score : "+score + "점"
        font.bold: true
        font.pixelSize: 24
        anchors.top:parent.top
        anchors.right: parent.right
        anchors.rightMargin:10
        anchors.topMargin:10
    }
    Text{
        text: "Time : "+countDown +"초"
        font.bold: true
        color: "blue"
        font.pixelSize: 20
        anchors.top:parent.top
        anchors.right: parent.right
        anchors.rightMargin:10
        anchors.topMargin:50

    }
    Dialog {
        id: scoreDialog
        title: "메시지 창"
        standardButtons: Dialog.Ok
        Text{
            text: "Game Over!"
            font.bold: true
            font.pixelSize: 18
            anchors.centerIn: parent
        }
        onAccepted: {               // 확인 버튼을 클릭시 닫힘
            scoreDialog.close()
        }
    }
    Dialog {
        id: countDowndialog
        title: "메시지 창"
        standardButtons: Dialog.Ok
        Text{
            text: "시간초과! "
            font.bold: true
            font.pixelSize: 18
            anchors.centerIn: parent
        }
        onAccepted: {
            countDowndialog.close()
        }
    }
    Dialog {
        id: allclearDialog
        title: "메시지 창"
        standardButtons: Dialog.Ok
        Text{
            text: "모든 그림을 맞췄습니다! "
            font.bold: true
            font.pixelSize: 18
            anchors.centerIn: parent
        }
        onAccepted: {
            allclearDialog.close()
        }
    }
    Timer {                             // 시작시 countDown시작
        id: messageTimer
        interval: 1000
        running: true
        repeat: true
        onTriggered: {
            countDown--;
            if (countDown < 0) {
                countDown = 0
                isClick = false
                countDowndialog.open()
                messageTimer.stop()
            }
            if(score <0){
                scoreDialog.open()
                messageTimer.stop()
                score=0
                isClick = false
            }
            if(grid.columns === 4){         //4x4 모드 클리어 시
                if(isMatch.length == 16){
                    isMatch =[]
                    score =0;
                    isClick = false
                    allclearDialog.open()
                    messageTimer.stop()
                }
            }
            if(grid.columns === 6){         //6x6모드 클리어 시
                if(isMatch.length == 36){
                    isMatch =[]
                    score =0;
                    isClick = false
                    allclearDialog.open()
                    messageTimer.stop()
                }
            }
        }
    }


    ColumnLayout{                               // shuffle, mode 변경 버튼
        Button {
            id:shuffle
             text : " shuffle "
            BorderImage {
                anchors.fill: parent
            }
            onClicked: {
                if(grid.columns === 4){
                    randomList.shuffle()
                    isMatch =[]
                    score = 0;
                    countDown=60
                    messageTimer.start()
                }
                if(grid.columns === 6){
                    randomList.shuffle()
                    isMatch =[]
                    score = 300;
                    countDown=180
                    messageTimer.start()
                }
            }
        }
        Button {
            id: mode4
            text : "4x4 모드"
            onClicked: {
                grid.columns =  4
                randomList.shuffleMode4();
                isMatch =[]
                score = 0;
                countDown=60
            }
        }

        Button {
            id:mode6
            text : "6x6 모드"
            onClicked: {
                grid.columns =  6
                randomList.shuffleMode6();
                isMatch =[]
                score = 300;
                countDown=180
            }

        }

        Button {
            id: stop
            text : "일시정지"
            onClicked: {
               messageTimer.stop()
            }
        }
        Button {
            id: start
            text : "  재시작 "
            onClicked: {
               messageTimer.start()
            }
        }

    }
    SoundEffect{                        // 배경음악 설정
        id: correctSound
        source: "music/correct.wav"

    }
    SoundEffect{
        id: incorrectSound
        source: "music/incorrect.wav"

    }
    SoundEffect {
        id: playSound
        source: "music/backmusic.wav"
        loops: SoundEffect.Infinite
    }

    GridLayout{                         // 그림 타일 설정
        id : grid
        columns : 6
        rows :6
        columnSpacing: 10
        rowSpacing: 10
        anchors.centerIn: parent;

        Repeater {
            id: myRepeater
            model: randomList

            Rectangle{
                width: 50
                height: 50

                color: "lightblue"
                border.width: 1
                border.color: "black"
                Flipable{
                    id: flipAble
                    width: 50
                    height: 50

                    property bool flipped: false    // false: 기본상태 true: 180도 회전

                    transform: Rotation {
                        id: rotation
                        origin.x: flipAble.width/2
                        origin.y: flipAble.height/2
                        axis.x: 0; axis.y: 1; axis.z: 0
                        angle: 0
                    }

                    states: State {
                        name: "back"
                        PropertyChanges { target: rotation; angle: 360 }
                        when: flipAble.flipped
                    }

                    transitions: Transition {
                        NumberAnimation { target: rotation; property: "angle"; duration: flipAble.smooth ? 1000 :1000 }
                    }

                    Image {
                        id: image
                        source:  "img/question.png"
                        anchors.fill: parent

                        Timer {                     //5초 후 게임 시작
                            id: timer
                            interval: 5000
                            onTriggered: {
                                image.source = "img/question.png"
                                isClick = true;
                                timer.stop()
                            }
                        }
                        Component.onCompleted: {
                            image.source = model.display
                            timer.start()
                             playSound.play()
                            if( grid.columns ==  6)
                            {
                                score = 300
                                countDown=180
                            }
                        }
                    }

                    Timer {
                        id: restoreTimer
                        interval: 500
                        onTriggered:  image.source = "img/question.png"
                    }

                    MouseArea{
                        anchors.fill: parent
                        onClicked: {
                            if(isClick){
                                flipAble.flipped = !flipAble.flipped
                                if (selectcount < 2) {
                                    image.source = model.display;
                                    clickedImages.push({ image: image, model: model });     // 클릭시 model 이미지 저장
                                    selectcount++;

                                    if (selectcount === 2) {
                                        if (clickedImages[0].model.index !== clickedImages[1].model.index) {
                                            if (clickedImages[0].model.display === clickedImages[1].model.display) { // 정답
                                                isMatch.push(clickedImages[0].model.index)      // index 값 저장
                                                isMatch.push(clickedImages[1].model.index)

                                                // 현재 인덱스와 첫 번째 등장 위치의 인덱스가 동일한 경우에만 해당 인덱스 유지
                                                const newIsMatch = isMatch.filter((element, index) => isMatch.indexOf(element) === index);

                                                console.log(newIsMatch);
                                                console.log(isMatch);

                                                if(isMatch.length === newIsMatch.length){   // 정답인 그림을 다시 클릭시 정답으로 처리하는 오류 방지를 위해
                                                    console.log("두 이미지는 같습니다!");
                                                    correctSound.play()
                                                    count++;
                                                    score += 50;
                                                    console.log(score + "점");
                                                    console.log(newIsMatch);
                                                    console.log(isMatch);
                                                }
                                                else{
                                                    console.log("다른 이미지를 클릭하세요!");
                                                    incorrectSound.play()
                                                    isMatch.pop(clickedImages[0].model.index)
                                                    isMatch.pop(clickedImages[1].model.index)
                                                }
                                            }
                                            else{                                                                   //오답
                                                if(isMatch.includes(clickedImages[1].model.index) === true){        // 이미 정답인 이미지를 이후에 클릭시
                                                    clickedImages[0].image.source = "img/question.png";
                                                    console.log("이미 정답인 이미지를 선택했습니다!");
                                                    incorrectSound.play()
                                                    score -= 50;
                                                    console.log(score + "점");
                                                }
                                                else if(isMatch.includes(clickedImages[0].model.index) === true){   // 이미 정답인 이미지를 먼저 클릭시
                                                    clickedImages[1].model.display
                                                    restoreTimer.restart();
                                                    console.log("이미 정답인 이미지를 선택했습니다!");
                                                    incorrectSound.play()
                                                    score -= 50;
                                                    console.log(score + "점");
                                                }
                                                else{
                                                    console.log("두 이미지는 다릅니다!");                                // 두 이미지가 다를시
                                                    incorrectSound.play()
                                                    clickedImages[0].image.source = "img/question.png";
                                                    restoreTimer.restart();
                                                    score -= 50;
                                                    console.log(score + "점");
                                                }
                                            }

                                        }
                                        else {                                                                          // 같은 그림을 클릭
                                            if(isMatch.includes(clickedImages[1].model.index) === true){               // 이미 정답인 이미지 클릭
                                                console.log("같은 그림을 두 번 선택했습니다!");
                                                incorrectSound.play()
                                                score -= 50;
                                                console.log(score + "점");
                                            }
                                            else{
                                                image.source = "img/question.png";
                                                console.log("같은 그림을 두 번 선택했습니다!");
                                                incorrectSound.play()
                                                score -= 50;
                                                console.log(score + "점");
                                            }
                                        }
                                        clickedImages = [];
                                        selectcount = 0;
                                    }
                                }
                            }
                        }
                    }   // MouseArea
                }
            }
        } // Repeater
    } // GridLayout
}

