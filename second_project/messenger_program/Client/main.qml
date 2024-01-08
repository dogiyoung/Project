import QtQuick 2.14
import QtQuick.Window 2.14
import Client 1.0
import QtQuick.Controls 2.14
import QtQuick.Layouts 1.2


Window {
    id: clientWindow
    visible: true
    width: 500
    height: 600
    title: qsTr("client")

    Client { id: client}
    property var readText: ""
    property var crateText: ""
    property var passwordText: ""

    Component.onCompleted: {        // 실행시 서버에 바로 연결
        client.connectToServer()
    }

    Connections {                   // cpp에서 내보낸 신호처리
        target: client
        onPrintMessage:{
             readText+= printMessage+"\n"
        }

        onCrateMessage: {
            crateText+= crateMessage+"\n"
        }
        onLogin_successMessage:{
            stackView.push(secondPage)
        }
        onLogin_failMessage:{
            loginDialog.open()
        }
        onPasswordMessage:{
            passwordText = passwordMessage+"\n"
        }
    }

    Dialog {                // 로그인 실패시
        id: loginDialog
        title: "안내"
        standardButtons: Dialog.Ok
        anchors.centerIn: parent
        Text{
            text: "입력한 아이디를 찾을 수 없습니다.\n 아이디, 비밀번호를 확인하고 다시 시도하세요 "
            font.bold: true
            font.pixelSize: 18
            anchors.centerIn: parent
        }
        onAccepted: {
            loginDialog.close()
        }
    }

    StackView {         // 여러가지 페이지 설정
        id: stackView
        anchors.fill: parent
        initialItem: firstPage // 초기 페이지 설정

        Component {
            id: firstPage      // 메인 화면
            Rectangle {
                width: stackView.width
                height: stackView.height
                color: "#fae100"
                Image {
                    anchors.top:parent.top
                    anchors.topMargin:parent.height/8
                    anchors.horizontalCenter: parent.horizontalCenter
                   // source: "/../../../../../media/sf_vm_share/사본 -사본 -카톡로고.png"
                }
                Column{     // 로그인 필드
                    anchors.centerIn: parent
                    TextField{
                        id:id
                        placeholderText: "아이디를 입력하세요"
                    }
                    TextField{
                        id:password
                        placeholderText: "비밀번호를 입력하세요"
                    }

                    Button {        //로그인 버튼
                        id: login
                        text: "로그인"
                        font.bold: true
                        font.pixelSize: 20
                        onClicked: {
                            var ID = id.text
                            var PW = password.text
                            client.login(ID,PW)
                        }
                    }

                    Row{        // 회원가입, 비밀번호 찾기 버튼
                        Button {
                            id:register
                            text: "회원가입"
                            background: Rectangle{
                                color: "#fae100"
                            }
                            onClicked: {
                                stackView.push(registerPage)        // 회원가입 페이지로 이동
                            }
                        }
                        Button {
                            id:findPassword
                            text: "비밀번호 찾기"
                            background: Rectangle{
                                color: "#fae100"
                            }
                            onClicked: {
                                stackView.push(findPasswordPage)    //비밀번호 찾기 페이지로 이동
                            }
                        }
                    }
                }
            }
        }
        Component {
            id: secondPage  // 채팅 페이지
            Rectangle {
                width: stackView.width
                height: stackView.height

                color: "aqua"

                Flickable {
                    id:flick
                    width: parent.width
                    height: parent.height-50
                    ScrollBar.vertical: ScrollBar { id: scrollBar }
                    Keys.onUpPressed: scrollBar.decrease()
                    Keys.onDownPressed: scrollBar.increase()
                    contentHeight: Math.max(chatReadArea.height)

                    TextArea {
                        id: chatReadArea    // 받은 메시지
                        readOnly: true
                        text: readText
                        font.bold: true
                        width:  flick.width
                        wrapMode: Text.Wrap
                    }

                    onContentHeightChanged: {   // 메시지가 일정높이(height: parent.height-50)를 벗어 날 시 자동 스크롤
                        if (contentHeight > height) {
                            contentY = contentHeight - height;
                        }
                    }
                }
                Button{             // 채팅방 퇴장 버튼
                    text: "exit "
                    anchors.bottom: parent.bottom
                    onClicked: {
                        readText=""
                        stackView.push(firstPage)
                        client.sendData("/exit")
                    }
                }

                RowLayout {                             // 메시지 입력창
                    anchors.bottom:parent.bottom
                    anchors.right: parent.right
                    TextField {
                        id: messageInput
                        placeholderText: "Message 입력"
                        Keys.onPressed: {               // 엔터키 입력시
                            if (event.key === Qt.Key_Return) {
                                var message = messageInput.text
                                var sendMessage =  client.sendData(message)
                                if(sendMessage){
                                    messageInput.text = ""
                                }
                                else{
                                    messageInput.text = ""
                                }

                                if (sendMessage === "/exit") {
                                    readText=""
                                    stackView.push(firstPage)   // 메인 화면으로 이동
                                }
                            }
                        }
                    }

                    Button {                                   // 메시지 전송 버튼 클릭시
                        text: "Send Message"
                        onClicked: {
                            var message = messageInput.text
                            var sendMessage =  client.sendData(message)
                            if(sendMessage){
                                messageInput.text = ""
                            }
                            else{
                                messageInput.text = ""
                            }
                            if (sendMessage === "/exit") {
                                readText=""
                                stackView.push(firstPage)    // 메인 화면으로 이동
                            }
                        }
                    }
                }
            }
        }
        Component {
            id: registerPage    // 회원가입 페이지 구성
            Rectangle {
                width: stackView.width
                height: stackView.height
                Column{
                    spacing: 30
                    anchors.centerIn: parent
                    Text {
                        text: "Register With Us"
                        font.bold: true
                        font.pixelSize: 30
                    }
                    TextField{
                        id:id
                        placeholderText: "아이디를 입력하세요"
                    }
                    TextField{
                        id:password
                        placeholderText: "비밀번호를 입력하세요"
                    }
                    TextField{
                        id:birth
                        placeholderText: "생년월일을 입력하세요"
                    }
                    TextField{
                        id:name
                        placeholderText: "이름을 입력하세요"
                    }

                    Button {
                        text: "가입하기"
                        width: name.width
                        onClicked: {
                            client.crateAccount(id.text,password.text,birth.text,name.text)
                            crateText=""
                        }
                    }

                    Text{
                        text: crateText
                        color: "red"
                    }
                }
                Button {
                    anchors.bottom: parent.bottom
                    text: "뒤로가기"
                    onClicked: {
                        stackView.push(firstPage)   // 메인 화면으로 이동
                        crateText=""
                    }
                }
            }
        }
        Component {
            id: findPasswordPage        // 비밀번호 찾기 페이지 구성
            Rectangle {
                width: stackView.width
                height: stackView.height
                Column{
                    spacing: 30
                    anchors.top: parent.top
                    anchors.horizontalCenter: parent.horizontalCenter
                    anchors.centerIn: parent
                    Text {
                        text: "비밀번호 찾기"
                        font.bold: true
                        font.pixelSize: 30
                    }
                    Text {
                        text: "비밀번호를 찾기 위한 ID와 생년월일을 입력하세요"
                        font.pixelSize: 20
                    }
                    TextField{
                        id:id
                        placeholderText: "아이디를 입력하세요"

                    }
                    TextField{
                        id:birth
                        placeholderText: "생년월일을 입력하세요"
                    }
                    Button {
                        text: "비밀번호 찾기"
                        width: birth.width
                        onClicked: {
                            client.findPassword(id.text,birth.text)
                        }
                    }
                    Text{
                        text: passwordText
                        color: "red"
                    }
                }
                Button {
                    anchors.bottom: parent.bottom
                    text: "뒤로가기"
                    onClicked: {
                        stackView.push(firstPage)   // 메인 화면으로 이동
                        passwordText="";
                    }
                }
            }
        }
    }
}
