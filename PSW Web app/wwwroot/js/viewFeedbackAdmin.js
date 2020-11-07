
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

	tr.append(tdId).append(tdText).append(tdPatient).append(tdPrivate);
	$('#table tbody').append(tr);

}

$(document).ready(function () {

	$.get({
		url: 'http://localhost:49153/api/feedback',
		success: function (feedback) {

			for (let f of feedback)
				addFeedback(f);
		}
	});

});

