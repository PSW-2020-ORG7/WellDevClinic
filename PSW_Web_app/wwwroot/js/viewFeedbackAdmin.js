function authorize() {
	let token = sessionStorage.getItem("token");
	let payload = parseJwt(token);
	userType = payload["type"];
	if (userType != "Secretary") {
		alert("You are not authorized for this page!!!");
		window.location.replace(window.location.protocol + "//" + window.location.host + "/html/homePage.html");
	}
}

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
	let tr = $('<tr></tr>');
	let tdId = $('<td>' + feedback.id + '</td>');
	let tdText = $('<td>' + feedback.content + '</td>');
	let tdPatient;
	if (feedback.isAnonymous == true) {
		tdPatient = $('<td>Anonymous</td>');
	}
	else
		tdPatient = $('<td>' + feedback.patient + '</td>');

	let tdPrivate;
	if (feedback.isPrivate == true) {

		tdPrivate = $('<td><input type = checkbox checked disabled/></td>');
	}
	else
		tdPrivate = $('<td><input type = checkbox disabled/></td>');

	let tdPublished;
	if (feedback.publish == true) {

		tdPublished = $('<td><input type = checkbox checked disabled/></td>');
	}
	else
		tdPublished = $('<td><input type = checkbox disabled/></td>');

	let tdPublish;
	if (feedback.publish == false && feedback.isPrivate == false) {
		tdPublish = $('<td><button type="button" enabled onclick="buttonFunction(this)" >Publish</button></td>');
	}
	else
		tdPublish = $('<td><button type="button" disabled>Publish</button></td>');


	tr.append(tdId).append(tdText).append(tdPatient).append(tdPrivate).append(tdPublished).append(tdPublish);
	$('#table tbody').append(tr);

}

function buttonFunction(item) {
	var row = $(item).closest("tr");
	var tds = row.find("td");
	var code_str = tds[0].innerHTML;
	url = window.location.protocol + "//" + window.location.host + "/html/viewFeedbackAdmin.html?id=" + code_str;
	location.href = url;
}

function deleteTable() {
	$('#table tbody').empty();
}

$(document).ready(function () {
	var code1 = ""
	var queryString = window.location.search;
	if (queryString.includes("?")) {
		queryString = queryString.split('?');
		var query = queryString[1];
		query = query.split('=');
		code1 = query[1];
		console.log(code1);
	}

	$.get({
		url: window.location.protocol + "//" + window.location.host + '/api/feedback/' + code1,
		headers: { "Authorization": userType },
		success: function (feedback) {

			if (code1 == "") {
				for (let f of feedback) {
					addFeedback(f);
				}

			}
			else {
				$.ajax({
					url: window.location.protocol + "//" + window.location.host + '/api/feedback/',
					headers: { "Authorization": userType },
					type: 'PUT',
					data: JSON.stringify({ id: feedback.id, patient: feedback.patient, content: feedback.content, isPrivate: feedback.isPrivate, isAnonymous: feedback.isAnonymous, publish: true }),
					contentType: "application/json; charset=utf-8",
					success: function (data) {
						window.location.href = window.location.protocol + "//" + window.location.host + "/html/viewFeedbackAdmin.html";
					},
				});
			}

		}
	});


	$("#filter").on('change', function () {
		deleteTable();
		var filter = $("#filter").val();
		$.get({
			url: window.location.protocol + "//" + window.location.host + '/api/feedback',
			headers: { "Authorization": userType },
			success: function (feedback) {
				for (let f of feedback) {
					if (filter == "all") {
						addFeedback(f);
					}
					else if (filter == "private") {
						if (f.isPrivate) {
							addFeedback(f);
						}
					}
					else if (filter == "pending") {
						if (!f.publish && !f.isPrivate) {
							addFeedback(f);
						}
					}
					else {
						if (f.publish) {
							addFeedback(f);
						}
					}
				}
			}
		});

	});

});

