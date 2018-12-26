var needUserAnswer = false;
var noAnswerLine = "У меня нет ответа на это. Что я должен ответить?";
var gotUserAnswerLine = "Спасибо! Я запомню это.";

var model = {
    userLine: ko.observable(""),
    dialog: ko.observableArray(),
    dialogToShow: ko.observable("")
};

function sendAjaxRequest(httpMethod, url, callback, data = null) {
    $.ajax("/api/web" + (url ? "/" + url : ""),
        {
            type: httpMethod,
            success: callback,
            data: data
        });
}

function send() {
    if (needUserAnswer) {
        sendAjaxRequest("POST",
            "CreateFact",
            function () {
                model.dialog.push(model.userLine());
                needUserAnswer = false;
                model.dialog.push(gotUserAnswerLine);
                updateDialog();
            },
            {
                Question: model.dialog()[model.dialog().length - 2],
                Answer: model.userLine
            });
    } else {
        sendAjaxRequest("GET",
            "GetAnswer",
            function (answer) {
                model.dialog.push(model.userLine());
                if (answer == "") {
                    needUserAnswer = true;
                    model.dialog.push(noAnswerLine);
                } else {
                    model.dialog.push(answer);
                }
                updateDialog();
            },
            { question: model.userLine });
    }
}

function updateDialog() {
    model.userLine("");
    var result = "";
    for (var i = 0; i < model.dialog().length; i++) {
        result += "-" + model.dialog()[i] + "\n";
    }
    model.dialogToShow(result);
}

$(function () {
    ko.applyBindings(model);
});