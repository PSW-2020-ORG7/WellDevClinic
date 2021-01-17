function authorize() {
    token = sessionStorage.getItem("token");
    let payload = parseJwt(token);
    userType = payload["type"];
    userId = payload["Id"];
    if (userType != "Patient") {
        alert("You are not authorized for this page!!!");
        window.location.replace(window.location.protocol + "//" + window.location.host + "/html/viewFeedbackAdmin.html");
    }
}
var token = "";
var userType = "";
var userId = "";
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
    element = $('<li>' + allergy.name + '</li>');
    list.append(element);
}

$(document).ready(function () {
    $.get({
        url: window.location.protocol + "//" + window.location.host + '/api/patient/patientDetails/' + userId,
        headers: { "Authorization": token },
        success: function (user) {
           /* $('label[id="username"]').text(user.username);*/
            $('label[id="fullName"]').text(user.person.fullName);
            $('label[id="middleName"]').text(user.userDetails.middleName);
            let fullDate = user.userDetails.dateOfBirth;
            let date = fullDate.split('T');
            $('label[id="date"]').text(date[0]);
            $('label[id="address"]').text(user.userDetails.address.street + user.userDetails.address.number);
            $('label[id="phone"]').text(user.userDetails.phone);
            $('label[id="email"]').text(user.userDetails.email);
            $('label[id="gender"]').text(user.userDetails.gender);
            $('label[id="bloodType"]').text(user.userDetails.bloodType);
            $('#image').attr('src', " http://localhost:51393" + user.image);

            $.get({
                url: window.location.protocol + "//" + window.location.host + '/api/patient/patientFile/' + userId,
                headers: { "Authorization": token },
                success: function (file) {
                    for (let allergy of file.allergy) {
                        addAllergy(allergy);
                    }
                }
            });
        }
    });

});