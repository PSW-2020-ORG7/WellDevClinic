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

function addFeedback(feedback) {
	let tr = $('<tr id="tr"></tr>');
	let td = $('<td></td>');
	let form = $('<form id="form" class="form-horizontal"></form>');

	let patient;

	if (feedback.isAnonymous) {
		patient = "Anonymous";
	}
	else {
		patient = feedback.patient.fullName;
	}

	let user = $('<div class="form-group row"><div class="col-sm-12"><input id="patient" readonly class="form-control-plaintext" value="'+ patient +'"></div></div>');
	let content = $('<div  class="form-group row"><div class="col-sm-12"><textarea id="content" readonly   >'+feedback.content+'</textarea></div></div>');

	form.append(user).append(content);
	td.append(form);
	tr.append(td);
	$('#table tbody').append(tr);

}

$(document).ready(function () {

	$.get({
		url: window.location.protocol + "//" + window.location.host + '/api/feedback',
		headers: { "Authorization": token },
		success: function (allFeedback) {

			for (let feedback of allFeedback) {
				if (feedback.publish) {
					addFeedback(feedback);
				}
			}
		}
	});
});