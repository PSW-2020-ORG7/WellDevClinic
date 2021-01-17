function authorize() {
	token = sessionStorage.getItem("token");
	let payload = parseJwt(token);
	userType = payload["type"];
	if (userType != "Secretary") {
		alert("You are not authorized for this page!!!");
		window.location.replace(window.location.protocol + "//" + window.location.host + "/html/homePage.html");
	}
}
var userType = "";
var token = "";
function parseJwt(token) {
	var base64Url = token.split('.')[1];
	var base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
	var jsonPayload = decodeURIComponent(atob(base64).split('').map(function (c) {
		return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
	}).join(''));

	return JSON.parse(jsonPayload);
};

function addPatient(patient) {
	let tr = $('<tr></tr>');
	let tdId = $('<td>' + patient.id + '</td>');
	let tdName = $('<td>' + patient.person.firstName + '</td>');
	let tdBlock = $('<td></td>');
	if (!patient.blocked) {
		let button = $('<button type="button"> Block user </button>');
		button.attr('class', 'block');
		tdBlock.append(button);
		tr.append(tdId).append(tdName).append(tdBlock);
		$('#table_for_blocking tbody').append(tr);
	}
	else {
		tr.append(tdId).append(tdName);
		$('#table_blocked tbody').append(tr);
	}
}

$(document).ready(function () {

	$.get({
		url: window.location.protocol + "//" + window.location.host + '/api/patient/patients_for_blocking',
		headers: { "Authorization": token },
		success: function (patients) {
			for (let patient of patients) {
				for (let patient of patients) {
					$.get({
						url: window.location.protocol + "//" + window.location.host + '/api/patient/lazy/' + patient.id,
						success: function (patient) {
							addPatient(patient);
						}
					});
				}
			}
		}
	});

	$.get({
		url: window.location.protocol + "//" + window.location.host + '/api/patient/blocked_patients',
		headers: { "Authorization": token },
		success: function (patients) {
			for (let patient of patients) {
				addPatient(patient);
			}
		}
	});

	$("#table_for_blocking tbody").on("click", ".block", function () {

		let Tr = $(this).closest('tr');
		let dataId = Tr.find("td:eq(0)").html();

		$.ajax({
			url: window.location.protocol + "//" + window.location.host + "/api/patient/" + dataId,
			type: 'PUT',
			headers: { "Authorization": token },
			success: function () {
				alert("Uspesno blokiran pacijent")
				location.reload();
			},
			contentType: "application/json; charset=utf-8"
		})

	});

	$('#quit').click(function (event) {
		var origin = window.location.origin;
		window.location.href = origin + "/html/viewFeedbackAdmin.html"
	});
});