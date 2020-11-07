function addFeedback(feedback) {
	let tr = $('<tr></tr>');
	
	let tdContent = $('<td>' + feedback.content + '</td>');
	let tdPatient;

	if (feedback.isAnonymous) {
		 tdPatient = $('<td>Anonymous</td>');
	}
	else {
		 tdPatient = $('<td>' + feedback.patient + '</td>');
	}
	
	tr.append(tdPatient).append(tdContent);
	$('#table tbody').append(tr);

}

$(document).ready(function () {

	$.get({
		url: 'http://localhost:49153/api/feedback',
		success: function (allFeedback) {

			for (let feedback of allFeedback)
				if (feedback.publish) {
					addFeedback(feedback);
				}
		}
	});
});