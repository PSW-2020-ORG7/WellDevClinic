function addAllergy(allergy) {
    list = $('#allergies');
    element = $('<li>' + allergy + '</li>');
    list.append(element);
}
$(document).ready(function () {
    $.get({
        url: window.location.protocol + "//" + window.location.host + '/api/patient/patientFile/1',
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