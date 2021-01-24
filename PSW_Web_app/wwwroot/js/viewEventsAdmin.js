function authorize()
{
	token = sessionStorage.getItem("token");
	let payload = parseJwt(token);
	userType = payload["type"];
	if (userType != "Secretary")
	{
		alert("You are not authorized for this page!!!");
		window.location.replace(window.location.protocol + "//" + window.location.host + "/html/homePage.html");
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

function addEvent(Event)
{
	let tr = $('<tr></tr>');
	let tdPatient = $('<td>' + Event.patientId + '</td>');
	let tdStep = $('<td>' + Event.stepName + '</td>');
	let tdTime = $('<td>' + Event.timeSpent + '</td>');

	tr.append(tdPatient).append(tdStep).append(tdTime);
	$('#table tbody').append(tr);
}

function addStepTimes(data) {
	let tr = $('<tr></tr>');
	let tdFirst = $('<td>' + data.firstStep + "s" + '</td>');
	let tdSecond = $('<td>' + data.secondStep + "s" + '</td>');
	let tdThird = $('<td>' + data.thirdStep + "s" + '</td>');
	let tdFourth = $('<td>' + data.fourthStep + "s" + '</td>');
	let tdSuccess = $('<td>' + data.fifthStep + '</td>');
	let tdUnsuccess = $('<td>' + data.unsuccessful + '</td>');
	let tdNext = $('<td>' + data.next + '</td>');
	let tdPrevious = $('<td>' + data.prev + '</td>');

	tr.append(tdFirst).append(tdSecond).append(tdThird).append(tdFourth).append(tdSuccess).append(tdUnsuccess).append(tdNext).append(tdPrevious);
	let table =  document.getElementById("tbody2");
	$('#table tbody').append(tr);
}

$(document).ready(function() {
	$.get({
		url: window.location.protocol + "//" + window.location.host + '/api/event/stepTime',
		headers: { "Authorization": token },
		success: function (data) {
			addStepTimes(data);
		}
	})

	/*$.get({
	url: window.location.protocol + "//" + window.location.host + '/api/event/getAll',
        headers: { "Authorization": token },
		success: function(Events){
			for (let Event of Events)
            {
				addEvent(Event);
            }
        }
	})*/


});

