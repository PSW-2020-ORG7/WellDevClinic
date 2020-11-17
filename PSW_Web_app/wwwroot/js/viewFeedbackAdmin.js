﻿
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
	url = "http://localhost:49153/html/viewFeedbackAdmin.html?id=" + code_str;
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
		url: 'http://localhost:49153/api/feedback/' + code1,
		success: function (feedback) {

			if (code1 == "") {
				for (let f of feedback) {
					addFeedback(f);
				}

			}
			else {
				$.ajax({
					url: 'http://localhost:49153/api/feedback/',
					type: 'PUT',
					data: JSON.stringify({ id: feedback.id, patient: feedback.patient, content: feedback.content, isPrivate: feedback.isPrivate, isAnonymous: feedback.isAnonymous, publish: true }),
					contentType: "application/json; charset=utf-8",
					success: function (data) {
						window.location.href = "http://localhost:49153/html/viewFeedbackAdmin.html";
					},
				});
			}

		}
	});


	$("#filter").on('change', function () {
		deleteTable();
		var filter = $("#filter").val();
		$.get({
			url: 'http://localhost:49153/api/feedback',
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
