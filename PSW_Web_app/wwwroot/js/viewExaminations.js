function addPrviousExamination(examination, i) {
	tr = $('<tr id="tr"></tr>');
	let row = $('<th scope="row">' + i + '</th>');
	let doctor = $('<td>' + examination.doctor+'</td>');
	let date = $('<td>' + examination.date+'</td>');
    let time = $('<td>' + examination.startTime + ' - '+ examination.endTime + '</td>');
    let diagnosis = $('<td>' + examination.diagnosis + '</td>');
    let therapy = $('<td>' + examination.therapy + '</td>');
	
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
		url: window.location.protocol + "//" + window.location.host + '/api/examination/1',
		success: function (list) {
			i = 1;
			for (let examination of list) {
				if (!(examination.canceled)) {
					addPrviousExamination(examination, i)
					i++;
				}
			}	
		}
	});

    $.get({
		url: window.location.protocol + "//" + window.location.host + '/api/examination/upcoming/1',
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
			success: function () {
				alert("Appointment canceled successfully");
				window.location.reload();
			},
		});
	});

});