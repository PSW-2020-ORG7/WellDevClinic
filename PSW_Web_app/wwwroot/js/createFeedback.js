
function parseJwt (token) {
    var base64Url = token.split('.')[1];
    var base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
    var jsonPayload = decodeURIComponent(atob(base64).split('').map(function(c) {
        return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
    }).join(''));

    return JSON.parse(jsonPayload);
};

function authorize() {
    token = sessionStorage.getItem("token");
    let payload = parseJwt(token);
    userType = payload["type"];
    if (userType != "Patient") {
        alert("You are not authorized for this page!!!");
        window.location.replace(window.location.protocol + "//" + window.location.host + "/html/viewFeedbackAdmin.html");
    }
}

var userType = "";
var token = "";
$(document).ready(function () {
    console.log(window.location.protocol + "//" + window.location.host);
    let form = $("#feedbackForm");
    form.submit(function (event) {

        event.preventDefault();
        let comment = $("#comment");
        let anonymous = document.getElementById('anonymous');
        let private = document.getElementById('private');
        let patient = "Jack Smith";

        if (jQuery.trim(comment.val()) != '') {
            let anonymousBool = false;
            if (anonymous.checked) {
                anonymousBool = true;
            }

            let privateBool = false;
            if (private.checked) {
                privateBool = true;
            }

            let data = sessionStorage.getItem("token");
            let payload = parseJwt(data);
            let id = payload["Id"];

            $.get({
                url: window.location.protocol + "//" + window.location.host + "/api/patient/lazy/" + id,
                success: function (data) {
                    console.log(data);
                    $.post({
                        url: window.location.protocol + "//" + window.location.host + "/api/feedback",
                        data: JSON.stringify({ content: comment.val(), isAnonymous: anonymousBool, isPrivate: privateBool, patient: data }),
                        headers: { "Authorization": token },
                        success: function () {
                            alert("Uspesno ste poslali komentar")
                        },
                        contentType: "application/json; charset=utf-8"
                    })
                }
            })

        }
        else {
            alert("Unesite komentar u odgovarajuce polje")
            comment.css("border-width", "5px")
            comment.css("borderColor", "red")
        }

    })
});