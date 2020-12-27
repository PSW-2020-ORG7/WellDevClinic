function parseJwt (token) {
    var base64Url = token.split('.')[1];
    var base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
    var jsonPayload = decodeURIComponent(atob(base64).split('').map(function(c) {
        return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
    }).join(''));

    return JSON.parse(jsonPayload);
};


$(document).ready(function () {

    let form = $("#login-form");
    form.submit(function (event) {

        event.preventDefault();

        let username = $("#username"); 
        let password = $("#password");

        var data2 = {
            Username: username.val(), Password: password.val()
        }

        $.ajax({
            url: window.location.protocol + "//" + window.location.host + "/api/user",
            type: 'POST',
            data: JSON.stringify(data2),
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                sessionStorage.setItem("token", data);
                let payload = parseJwt(data);
                let userType = payload["type"];
                console.log(userType);
                //window.location.replace(window.location.protocol + "//" + window.location.host + "/html/feedback.html");
                console.log(payload)


            }
        })
    })
});