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

        document.getElementById("username").style.borderColor = "black";         
        document.getElementById("password").style.borderColor = "black";

        let username = $("#username"); 
        let password = $("#password");
        var usernameBool = false;
        var passwordBool = false;

        if(!username.val() || 0 === username.val().length){
            document.getElementById("username").style.borderColor = "red";
            document.getElementById("username").placeholder="Enter username...";
        }
        else
            usernameBool = true;

        if(!password.val() || 0 === password.val().length){
            document.getElementById("password").style.borderColor = "red";
            document.getElementById("password").placeholder="Enter password...";
        }
        else
            passwordBool = true;

        if(usernameBool && passwordBool){

            var data2 = {
                Username: username.val(), Password: password.val()
            }
            console.log(data2)
    
            $.ajax({
                url: window.location.protocol + "//" + window.location.host + "/api/user",
                type: 'POST',
                data: JSON.stringify(data2),
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    console.log(data)
                    sessionStorage.setItem("token", data);
                    let payload = parseJwt(data);
                    let userType = payload["type"];
                    console.log(userType);
                    if (userType == "Patient") {
                        window.location.replace(window.location.protocol + "//" + window.location.host + "/html/homePage.html");
                    } else {
                        window.location.replace(window.location.protocol + "//" + window.location.host + "/html/viewFeedbackAdmin.html");
                    }
                    //window.location.replace(window.location.protocol + "//" + window.location.host + "/html/feedback.html");
                    console.log(payload)
                },
                error: function(){
                    Swal.fire({
                        position: 'top-end',
                        icon: 'error',
                        title: 'Username or password incorrect',
                        showConfirmButton: false,
                        timer: 1500
                    })
                }
            })
        }


    })
});