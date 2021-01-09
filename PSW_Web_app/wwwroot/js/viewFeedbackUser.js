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
		success: function (allFeedback) {

			for (let feedback of allFeedback) {
				if (feedback.publish) {
					addFeedback(feedback);
				}
			}
		}
	});
});