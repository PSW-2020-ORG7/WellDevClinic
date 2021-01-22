var userType = "";
var token = "";
var userId = "";
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
function parseJwt(token) {
	var base64Url = token.split('.')[1];
	var base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
	var jsonPayload = decodeURIComponent(atob(base64).split('').map(function (c) {
		return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
	}).join(''));

	return JSON.parse(jsonPayload);
};


$(document).ready(function () {
    $.get({
        url: window.location.protocol + "//" + window.location.host + '/api/examination/referral/' + userId,
        headers: { "Authorization": token },
        success: function (referral) {
            let startDate = referral.period.startDate;
            let start = startDate.split('T');
            let endDate = referral.period.endDate;
            let end = endDate.split('T');
            $('label[id="period"]').text('from ' + start[0] + ' to ' + end[0]);
            $('label[id="doctor"]').text(referral.doctor.person.fullName);
            $('label[id="speciality"]').text(referral.doctor.speciality.name);
            $('label[id="text"]').text(referral.text);
        }
    });

});
