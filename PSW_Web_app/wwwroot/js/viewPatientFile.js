function authorize() {
    token = sessionStorage.getItem("token");
    let payload = parseJwt(token);
    userType = payload["type"];
    if (userType != "Patient") {
        alert("You are not authorized for this page!!!");
        window.location.replace(window.location.protocol + "//" + window.location.host + "/html/viewFeedbackAdmin.html");
    }
}
var token = "";
var userType = "";
function parseJwt(token) {
    var base64Url = token.split('.')[1];
    var base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
    var jsonPayload = decodeURIComponent(atob(base64).split('').map(function (c) {
        return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
    }).join(''));

    return JSON.parse(jsonPayload);
};

function addAllergy(allergy) {
    list = $('#allergies');
    element = $('<li>' + allergy + '</li>');
    list.append(element);
}
$(document).ready(function () {
    $.get({
        url: window.location.protocol + "//" + window.location.host + '/api/patient/patientFile/1',
        headers: { "Authorization": token },
        success: function (user) {
            $('label[id="username"]').text(user.username);
            $('label[id="fullName"]').text(user.fullName);
            $('label[id="middleName"]').text(user.middleName);
            $('label[id="date"]').text(user.date);
            $('label[id="address"]').text(user.address);
            $('label[id="phone"]').text(user.phone);
            $('label[id="email"]').text(user.email);
            $('label[id="gender"]').text(user.gender);
            $('label[id="bloodType"]').text(user.bloodType);
            $('#image').attr('src'," http://localhost:51393"+user.image);
            for (let allergy of user.allergies) {
                addAllergy(allergy);
            }

        }
    });

});