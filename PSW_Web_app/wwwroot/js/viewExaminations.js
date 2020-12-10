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
    let time = $('<td>' + examination.startTime + ' - '+ examination.endTime + '</td>');
   
    let buttonCancel =  $('<button class="button">Cancel examination</button>');

	tr.append(row).append(doctor).append(date).append(time).append(buttonCancel);
	$('#tableU tbody').append(tr);
}
$(document).ready(function () {
    $.get({
		url: window.location.protocol + "//" + window.location.host + '/api/examination/1',
		success: function (list) {
			i = 1;
			for (let examination of list) {
				addPrviousExamination(examination, i)
				i++;
			}	
		}
	});

    $.get({
		url: window.location.protocol + "//" + window.location.host + '/api/examination/upcoming/1',
		success: function (list) {
			i = 1;
			for (let examination of list) {
				addUpcomingExamination(examination, i)
				i++;
			}	
		}
	});

});