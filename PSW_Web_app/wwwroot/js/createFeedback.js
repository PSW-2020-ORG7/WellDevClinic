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
    validDate();
    $.get({
        url: window.location.protocol + "//" + window.location.host + "/api/doctor/",
        headers: { "Authorization": token },
        success: function (doctors) {
            for (let i = 0; i < doctors.length; i++) {
                addDoctor(doctors[i])
            }
        }
    });

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

            $.post({
                url: window.location.protocol + "//" + window.location.host + "/api/feedback",
                data: JSON.stringify({ content: comment.val(), isAnonymous: anonymousBool, isPrivate: privateBool, patient: patient }),
                headers: { "Authorization": token },
                success: function () {
                    alert("Uspesno ste poslali komentar")
                },
                contentType: "application/json; charset=utf-8"
            })
        }
        else {
            alert("Unesite komentar u odgovarajuce polje")
            comment.css("border-width","5px")
            comment.css("borderColor", "red")
        }

    })
})