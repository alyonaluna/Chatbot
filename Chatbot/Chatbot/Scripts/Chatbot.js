var needUserAnswer = false;
var noAnswerLine = "У меня нет ответа на это. Что я должен ответить?";
var gotUserAnswerLine = "Спасибо! Я запомню это.";

var model = {
    userLine: ko.observable(""),
    dialog: ko.observableArray(),
    dialogToShow: ko.observable("")
};

function sendAjaxRequest(httpMethod, url, callback, data) {
    $.ajax("/api/web" + (url ? "/" + url : ""),
        {
            type: httpMethod,
            success: callback,
            data: data
        });
}

function send() {
    if (model.userLine().trim() !== "") {
        if (needUserAnswer) {
            sendAjaxRequest("POST",
                "CreateFact",
                function() {
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
                function(answer) {
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
    $(".user-input").focus();
}

function updateDialog() {
    model.userLine("");
    var result = "";
    for (var i = 0; i < model.dialog().length; i++) {
        result += "- " + model.dialog()[i] + "\n";
    }
    model.dialogToShow(result);
}

$(function () {
    ko.applyBindings(model);

    $(".user-input").keyup(function(e) {
        if (e.keyCode == 13) {
            $(".btn-primary").click();
        }
    });
});