function authorize() {
	token = sessionStorage.getItem("token");
	let payload = parseJwt(token);
	userType = payload["type"];
	if (userType != "Patient") {
		alert("You are not authorized for this page!!!");
		window.location.replace(window.location.protocol + "//" + window.location.host + "/html/viewFeedbackAdmin.html");
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

var doctor1_dto = new Object();
var doctor2_dto = new Object();
var doctor3_dto = new Object();
var doctor4_dto = new Object();
var medical1_dto = new Object();
var medical2_dto = new Object();
var medical3_dto = new Object();
var medical4_dto = new Object();
var hospital1_dto = new Object();
var hospital2_dto = new Object();
var hospital3_dto = new Object();
var hospital4_dto = new Object();
var doctor = []
$(document).ready(function () {
	$('#submit').click(function (event) {

		let doctor1 = $("input:radio[name ='doctor1']:checked").val();
		let doctor2 = $("input:radio[name ='doctor2']:checked").val();
		let doctor3 = $("input:radio[name ='doctor3']:checked").val();
		let doctor_grade = $("input:radio[name ='doctor_grade']:checked").val();
		doctor1_dto.grade = parseInt(doctor1);
		doctor1_dto.question = 'doctor1';
		doctor2_dto.grade = parseInt(doctor2);
		doctor2_dto.question = 'doctor2';
		doctor3_dto.grade = parseInt(doctor3);
		doctor3_dto.question = 'doctor3';
		doctor4_dto.grade = parseInt(doctor_grade);
		doctor4_dto.question = 'doctor4';
		doctor.push(doctor1_dto)
		doctor.push(doctor2_dto)
		doctor.push(doctor3_dto)
		doctor.push(doctor4_dto)

		let medical1 = $("input:radio[name ='medical1']:checked").val();
		let medical2 = $("input:radio[name ='medical2']:checked").val();
		let medical3 = $("input:radio[name ='medical3']:checked").val();
		let medical_grade = $("input:radio[name ='medical_grade']:checked").val();
		medical1_dto.grade = parseInt(medical1);
		medical1_dto.question = 'medical1';
		medical2_dto.grade = parseInt(medical2);
		medical2_dto.question = 'medical2';
		medical3_dto.grade = parseInt(medical3);
		medical3_dto.question = 'medical3';
		medical4_dto.grade = parseInt(medical_grade);
		medical4_dto.question = 'medical4';
		doctor.push(medical1_dto)
		doctor.push(medical2_dto)
		doctor.push(medical3_dto)
		doctor.push(medical4_dto)

		let hospital1 = $("input:radio[name ='hospital1']:checked").val();
		let hospital2 = $("input:radio[name ='hospital2']:checked").val();
		let hospital3 = $("input:radio[name ='hospital3']:checked").val();
		let hospital_grade = $("input:radio[name ='hospital_grade']:checked").val();
		hospital1_dto.grade = parseInt(hospital1);
		hospital1_dto.question = 'hospital1';
		hospital2_dto.grade = parseInt(hospital2);
		hospital2_dto.question = 'hospital2';
		hospital3_dto.grade = parseInt(hospital3);
		hospital3_dto.question = 'hospital3';
		hospital4_dto.grade = parseInt(hospital_grade);
		hospital4_dto.question = 'hospital4';
		doctor.push(hospital1_dto)
		doctor.push(hospital2_dto)
		doctor.push(hospital3_dto)
		doctor.push(hospital4_dto)


		let searchParams = new URLSearchParams(window.location.search);
		let doctor_name = searchParams.get('doctor');
		let examination_id =  searchParams.get('id');
				
		$.post({
			url: window.location.protocol + "//" + window.location.host + "/api/survey",
			data: JSON.stringify({ grades: doctor, doctor: doctor_name }),
			headers: { "Authorization": token },
			success: function () {
				alert("You have completed the survey");
				$.ajax({
					url: window.location.protocol + "//" + window.location.host + '/api/examination/'+examination_id,
					type: 'PUT',
					headers: { "Authorization": token },
					success: function (data) {
						var origin = window.location.origin;
						window.location.href = origin + "/html/viewExaminations.html"
						
					},
				});
			},
			contentType: "application/json; charset=utf-8"
		})
	});

	$('#quit').click(function (event) {
		var origin = window.location.origin;
		window.location.href = origin + "/html/viewExaminations.html"
	});
});