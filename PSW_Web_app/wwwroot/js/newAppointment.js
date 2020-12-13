
//jQuery time
var current_fs, next_fs, previous_fs; //fieldsets
var left, opacity, scale; //fieldset properties which we will animate
var animating; //flag to prevent quick multi-click glitches

var date = $("#calendar");
var speciality = $("#specialization");
var doctors = $("#doctors");
var fieldSetCounter = 0;

$(".next").click(function () {
	if (!date.val() || 0 === date.val().length) {

	}
	else {
		if (animating) return false;
		animating = true;

		current_fs = $(this).parent();
		next_fs = $(this).parent().next();

		//activate next step on progressbar using the index of next_fs
		$("#progressbar li").eq($("fieldset").index(next_fs)).addClass("active");

		console.log(fieldSetCounter);
		console.log(doctors.val());
		var app = document.getElementById("appointments");
		if (fieldSetCounter == 2) {
			$.ajax({
				url: "http://localhost:49153/api/doctor/" + date.val() + '/' + doctors.val(),
				type: 'GET',
				success: function (data) {
					console.log(data);
					console.log("TERMINI");
					for (var i = 0; i < data.length; i++) {
						var opt = document.createElement('option');
						var startDate = data[i].startDate;
						console.log(data[i].startDate);
						console.log(data[i].endDate);
						var endDate = data[i].endDate;
						var startSplit = startDate.split("T");
						var endSplit = endDate.split("T");
						var start = startSplit[1].split(":");
						var end = endSplit[1].split(":");
						var startTime = start[0] + ":" + start[1];
						var endTime = end[0] + ":" + end[1];
						opt.setAttribute('value', data[i].startDate + "S" + data[i].endDate);
						opt.text = startTime + "-" + endTime;
						app.appendChild(opt);
					}
				}
			});
		}
		//show the next fieldset
		var selDoc = document.getElementById("doctors");
		console.log(fieldSetCounter);
		if (fieldSetCounter == 1) {
			$.ajax({
				url: "http://localhost:49153/api/doctor/" + speciality.val(),
				type: 'GET',
				success: function (data) {
					console.log(data);
					for (var i = 0; i < data.length; i++) {
						//var opt = "<option" + "value=" + data[i].name + ">" + data[i].name + "</option>";
						var opt = document.createElement('option');
						opt.setAttribute('value', data[i].id);
						opt.text = "Dr " + data[i].name + ' ' + data[i].surname;
						selDoc.appendChild(opt);
					}
				}
			});
		}
		fieldSetCounter += 1;
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

$(document).ready(function () {
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
		url: "http://localhost:49153/api/speciality",
		type: 'GET',
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
	if (animating) return false;
	animating = true;

	current_fs = $(this).parent();
	previous_fs = $(this).parent().prev();

	//de-activate current step on progressbar
	$("#progressbar li").eq($("fieldset").index(current_fs)).removeClass("active");

	//show the previous fieldset
	previous_fs.show();
	fieldSetCounter -= 1;
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
	var data2 = { doctorId: parseInt(doctors.val(),10), period: appointments.val() }
	$.ajax({
		url: "http://localhost:49153/api/examination/newExamination",
		type: 'POST',
		data: JSON.stringify(data2),
		contentType: "application/json; charset=utf-8",
		success: function (data) {
			console.log(data);
		}
	})
});

