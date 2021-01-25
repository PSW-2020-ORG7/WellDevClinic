$(document).ready(function () {
    $("#btnLogin").click(function (e) {
        e.preventDefault();
        $("#responseLoad").show();
        let userInput = $("#txtUsername").val();
        let passwordInput = $("#txtPassword").val();

        let valid = true;

        if (!userInput) {
            valid = false;
            $("#txtUsername").css("border-color", "red");
            $("#invalidUsername").css("display", "block");
        } else {
            $("#txtUsername").css("border-color", "#ccc");
            $("#invalidUsername").css("display", "none");
        }
        if (!passwordInput) {
            valid = false;
            $("#txtPassword").css("border-color", "red");
            $("#invalidPassword").css("display", "block");
        } else {
            $("#txtPassword").css("border-color", "#ccc");
            $("#invalidPassword").css("display", "none");
        }

        if (!valid)
            return;

        $.ajax({
            method: "POST",
            url: "../api/user/login",
            contentType: "application/json",
            data: JSON.stringify({
                username: $("#txtUsername").val(),
                password: $("#txtPassword").val()
            }),
            success: function (data) {
                $("#responseLoad").hide();
                if (data)
                    window.location.assign(window.location.origin += "/index.html");
                else
                    pageInfo("Password or username is incorrect.");
            },
            error: function () {
                $("#responseLoad").hide();
                pageInfo("An error has occurred while trying to connect with hospital server. Try again later!")
            }
        });
    });
});

function pageInfo(text) {
    $("#message").text(text);
    $("#pageInfoModal").modal('toggle');
    $("#pageInfo").show();
}