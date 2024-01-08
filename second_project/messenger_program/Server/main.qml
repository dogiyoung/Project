import QtQuick 2.14
import QtQuick.Window 2.14
import Server 1.0
import QtQuick.Controls 2.14
import QtQuick.Layouts 1.2


Window {
    visible: true
    width: 640
    height: 480
    title: qsTr("Server")

    Server { id: server}
    property var sendText: ""
    property var readText: ""

    Component.onCompleted: {                    // 서버 시작
        server.startServer()
    }

    Connections {
        target: server
        onPrintMessage: {
            readText+= printMessage+"\n"
        }
        onSendMessage: {
            sendText+= "공지사항: "+sendMessage+"\n"
        }
    }

    Flickable {
        id:flick
        width: parent.width/2+200
        height: parent.height-100
        anchors.top:parent.top
        anchors.left: parent.left
        anchors.leftMargin: 50
        Keys.onUpPressed: scrollBar.decrease()
        Keys.onDownPressed: scrollBar.increase()
        ScrollBar.vertical: ScrollBar { id: scrollBar }
        contentHeight: Math.max(chatReadArea.height,chatSendArea.height)
        Row{
            spacing: 10
            TextArea {
                id: chatSendArea
                readOnly: true
                text: sendText
                color: "navy"
                font.bold: true
                width:  flick.width / 2
                wrapMode: Text.Wrap
            }
            TextArea {
                id: chatReadArea
                readOnly: true
                text: readText
                color: "green"
                font.bold: true
                width:  flick.width / 2
                wrapMode: Text.Wrap
            }

        }
        onContentHeightChanged: {
            if (contentHeight > height) {
                contentY = contentHeight - height;
            }
        }
    }
    RowLayout {                                 // 메시지 입력창
        anchors.bottom:parent.bottom
        anchors.right: parent.right
        TextField {
            id: messageInput
            placeholderText: "Message 입력"
            Keys.onPressed: {                           // 엔터키 입력시
                if (event.key === Qt.Key_Return) {
                    var message = messageInput.text;
                    var sendMessage =  server.sendData(message)
                    messageInput.text = ""
                }
            }
        }

        Button {
            // 메시지 전송 버튼 클릭시

            text: "Send Message"
            onClicked: {
                var message = messageInput.text;
                var sendMessage =  server.sendData(messageInput.text)
                messageInput.text = ""
            }
        }
    }
}
