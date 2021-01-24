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
var userType = "";
var token = "";
var userId = "";

function parseJwt(token) {
	var base64Url = token.split('.')[1];
	var base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
	var jsonPayload = decodeURIComponent(atob(base64).split('').map(function (c) {
		return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
	}).join(''));

	return JSON.parse(jsonPayload);
};
//jQuery time
var current_fs, next_fs, previous_fs; //fieldsets
var left, opacity, scale; //fieldset properties which we will animate
var animating; //flag to prevent quick multi-click glitches

var date = $("#calendar");
var speciality = $("#specialization");
var doctors = $("#doctors");
var fieldSetCounter = 0;

//var timer1, timer2 = 0;
//var start = [];
function SendEvent(type,max) {
	$.ajax({
		url: window.location.protocol + "//" + window.location.host + "/api/event/save",
		type: 'POST',
		data: JSON.stringify({ patientId: parseInt(userId, 10), stepId: parseInt(counter, 10), stepType: type, scheduleId : max }),
		//data: JSON.stringify({ patientId: parseInt(userId, 10)}),
		contentType: "application/json; charset=utf-8",
		headers: { "Authorization": token },
		success: function (data) {
			console.log(data);
		}
	});
}

$(".next").click(function () {
	//console.log(fieldSetCounter);
	console.log("Brojac pre sendEvent");
	SendEvent(0,max);
	counter += 1;
	if (!date.val() || 0 === date.val().length) {

	}
	else {
		if (animating) return false;
		animating = true;

		current_fs = $(this).parent();
		next_fs = $(this).parent().next();

		//activate next step on progressbar using the index of next_fs
		$("#progressbar li").eq($("fieldset").index(next_fs)).addClass("active");

		//console.log(fieldSetCounter);
		console.log(doctors.val());
		var app = document.getElementById("appointments");
		if (fieldSetCounter == 2) {
			$.ajax({
				url: window.location.protocol + "//" + window.location.host + "/api/doctor/" + date.val() + '/' + doctors.val(),
				type: 'GET',
				headers: { "Authorization": token },
				success: function (data) {
					console.log(data);
					console.log("TERMINI");
					for (var i = 0; i < data.length; i++) {
						var opt = document.createElement('option');
						var startDate = data[i].period.startDate;
						//console.log(data[i].startDate);
						//console.log(data[i].endDate);
						var endDate = data[i].period.endDate;
						var startSplit = startDate.split("T");
						var endSplit = endDate.split("T");
						var start = startSplit[1].split(":");
						var end = endSplit[1].split(":");
						var startTime = start[0] + ":" + start[1];
						var endTime = end[0] + ":" + end[1];
						opt.setAttribute('value', data[i].period.startDate + "S" + data[i].period.endDate);
						console.log(data[i].period.startDate + "S" + data[i].period.endDate);
						opt.text = startTime + "-" + endTime;
						app.appendChild(opt);
					}
				}
			});
		}
		//show the next fieldset
		var selDoc = document.getElementById("doctors");
		//console.log(fieldSetCounter);
		if (fieldSetCounter == 1) {
			$.ajax({
				url: window.location.protocol + "//" + window.location.host + "/api/doctor/" + speciality.val(),
				type: 'GET',
				headers: { "Authorization": token },
				success: function (data) {
					console.log(data);
					for (var i = 0; i < data.length; i++) {
						//var opt = "<option" + "value=" + data[i].name + ">" + data[i].name + "</option>";
						var opt = document.createElement('option');
						opt.setAttribute('value', data[i].id);
						opt.text = "Dr " + data[i].person.firstName + ' ' + data[i].person.lastName;
						selDoc.appendChild(opt);
					}
				}
			});
		}
		fieldSetCounter += 1;
		//counter += 1;
		next_fs.show();
		//hide the current fieldset with style
		current_fs.animate({ opacity: 0 }, {
			step: function (now, mx) {
				//as the opacity of current_fs reduces to 0 - stored in "now"
				//1. scale current_fs down to 80%
				scale = 1 - (1 - now) * 0.2;
				//2. bring next_fs from the right(50%)
				left = (now * 50) + "%";
				//3. increase opacity of next_fs to 1 as it moves in
				opacity = 1 - now;
				current_fs.css({
					'transform': 'scale(' + scale + ')',
					'position': 'absolute'
				});
				next_fs.css({ 'left': left, 'opacity': opacity });
			},
			duration: 800,
			complete: function () {
				current_fs.hide();
				animating = false;
			},
			//this comes from the custom easing plugin
			easing: 'easeInOutBack'
		});
	}
});
var max = 0;
var counter = 0;
$(document).ready(function () {
	$.ajax({
		url: window.location.protocol + "//" + window.location.host + "/api/event/max",
		type: 'GET',
		headers: { "Authorization": token },
		success: function (data) {
			console.log(data);
			console.log("MAX");
			max = data;

			SendEvent(0,max);
			counter += 1;
		}
	});


	//var today = new Date().toISOString().split('T')[0];
	//document.getElementsByName("calendar")[0].setAttribute('min', today);
	var dtToday = new Date();

	var month = dtToday.getMonth() + 1;
	var day = dtToday.getDate();
	var year = dtToday.getFullYear();
	if (month < 10)
		month = '0' + month.toString();
	if (day < 10)
		day = '0' + day.toString();

	var maxDate = year + '-' + month + '-' + day;
	$('#calendar').attr('min', maxDate);

	var sel = document.getElementById("specialization");

	$.ajax({
		url: window.location.protocol + "//" + window.location.host + "/api/speciality",
		type: 'GET',
		headers: { "Authorization": token },
		success: function (data) {
			console.log(data);
			for (var i = 0; i < data.length; i++) {
				//var opt = "<option" + "value=" + data[i].name + ">" + data[i].name + "</option>";
				var opt = document.createElement('option');
				opt.setAttribute('value', data[i].name);
				opt.text = data[i].name;
				sel.appendChild(opt);
			}
		}
	});
});


$(".previous").click(function () {
	console.log(fieldSetCounter);
	console.log("Brojac pre sendEvent");
	SendEvent(1,max);
	if (animating) return false;
	animating = true;

	current_fs = $(this).parent();
	previous_fs = $(this).parent().prev();

	//de-activate current step on progressbar
	$("#progressbar li").eq($("fieldset").index(current_fs)).removeClass("active");

	//show the previous fieldset
	previous_fs.show();
	fieldSetCounter -= 1;
	counter -= 1;
	//hide the current fieldset with style
	current_fs.animate({ opacity: 0 }, {
		step: function (now, mx) {
			//as the opacity of current_fs reduces to 0 - stored in "now"
			//1. scale previous_fs from 80% to 100%
			scale = 0.8 + (1 - now) * 0.2;
			//2. take current_fs to the right(50%) - from 0%
			left = ((1 - now) * 50) + "%";
			//3. increase opacity of previous_fs to 1 as it moves in
			opacity = 1 - now;
			current_fs.css({ 'left': left });
			previous_fs.css({ 'transform': 'scale(' + scale + ')', 'opacity': opacity });
		},
		duration: 800,
		complete: function () {
			current_fs.hide();
			animating = false;
		},
		//this comes from the custom easing plugin
		easing: 'easeInOutBack'
	});
});

let form = $("#msform");
form.submit(function (event) {
	event.preventDefault();

	var appointments = $("#appointments");
	//var doctor = { id : doctors.val() }
	console.log(appointments.val())
	var startEnd = appointments.val().split("S");
	var start = new Date(startEnd[0])
	var end = new Date(startEnd[1])
	console.log(start,end)
	console.log(doctors.val(),userId)
	var data2 = { Start: start, End : end, PatientId : parseInt(userId,10), DoctorId : parseInt(doctors.val(),10) }
	$.ajax({
		url: window.location.protocol + "//" + window.location.host + "/api/examination/newExamination",
		type: 'POST',
		data: JSON.stringify(data2),
		contentType: "application/json; charset=utf-8",
		headers: { "Authorization": token },
		success: function (data) {
			console.log(data);
			counter += 1;
			SendEvent(0,max);
			location.href = window.location.protocol + "//" + window.location.host + "/html/homePage.html"
			
		}
	})
});


