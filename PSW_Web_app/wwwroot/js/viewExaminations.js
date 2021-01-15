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

function addPrviousExamination(examination, i) {
	tr = $('<tr id="tr"></tr>');
	let row = $('<th scope="row">' + i + '</th>');
	let doctor = $('<td>' + examination.doctor.person.fullName + '</td>');
	let fullDateStart = examination.prescription.period.startDate;
	let splittedStart = fullDateStart.split('T');
	let fullDateEnd = examination.prescription.period.endDate;
	let splittedEnd = fullDateEnd.split('T');
	let date = $('<td>' + splittedStart[0] + '</td>');
	let time = $('<td>' + splittedStart[1] + ' - ' + splittedEnd[1] + '</td>');
    let diagnosis = $('<td>' + examination.diagnosis.name + '</td>');
    let therapy = $('<td>' + examination.therapy.note + '</td>');
	
	if(!examination.filledSurvey){
		let buttonSurvey =  $('<button class="button">Fill out survey</button>');
		buttonSurvey.click(function (event) {
			var origin = window.location.origin;
			window.location.href = origin + '/html/survey.html'+'?doctor=' + examination.doctor+'&id='+examination.id;
		});
		tr.append(row).append(doctor).append(date).append(time).append(diagnosis).append(therapy).append(buttonSurvey);

	}
	else{
		let message = $('<td>Survey is filled out.</td>');
		tr.append(row).append(doctor).append(date).append(time).append(diagnosis).append(therapy).append(message);
	}
	$('#tableP tbody').append(tr);
}

function addUpcomingExamination(examination, i) {
	tr = $('<tr id="tr"></tr>');
	let row = $('<th scope="row">' + i + '</th>');
	let doctor = $('<td>' + examination.doctor +'</td>');
	let date = $('<td>' + examination.date +'</td>');
	let time = $('<td>' + examination.startTime + ' - ' + examination.endTime + '</td>');

	if (examination.canBeCanceled) {
		let buttonCancel = $('<button class="buttonCancel">Cancel examination</button>');
		buttonCancel.attr("id", examination.id);
		tr.append(row).append(doctor).append(date).append(time).append(buttonCancel);
	}
	else {
		tr.append(row).append(doctor).append(date).append(time);
	}

	$('#tableU tbody').append(tr);
}
$(document).ready(function () {

	$.get({
		url: window.location.protocol + "//" + window.location.host + '/api/patient/lazy/' + userId,
		headers: { "Authorization": token },
		success: function (data) {
			$.post({
				url: window.location.protocol + "//" + window.location.host + '/api/examination/',
				data: JSON.stringify(data),
				contentType: "application/json; charset=utf-8",
				headers: { "Authorization": token },
				success: function (list) {
					i = 1;
					for (let examination of list) {
						addPrviousExamination(examination, i)
						i++;
					}
				}
			});
		}
	});


    $.get({
		url: window.location.protocol + "//" + window.location.host + '/api/examination/upcoming/1',
		headers: { "Authorization": token },
		success: function (list) {
			i = 1;
			for (let examination of list) {
				if (!(examination.canceled)) {
					addUpcomingExamination(examination, i)
					i++;
				}
			}	
		}
	});

	$("#tableU tbody").on("click", ".buttonCancel", function () {
		var id = $(this).attr('id');
		$.ajax({
			url: window.location.protocol + "//" + window.location.host + "/api/examination/canceled/" + id,
			type: 'PUT',
			headers: { "Authorization": token },
			success: function () {
				alert("Appointment canceled successfully");
				window.location.reload();
			},
		});
	});

});