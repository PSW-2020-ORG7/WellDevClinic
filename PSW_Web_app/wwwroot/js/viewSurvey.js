﻿function addSurvey(survey) {
    let tr_medical = $('<tr></tr>');
    let tr_doctor = $('<tr></tr>');
    let tr_hospital = $('<tr></tr>');
    let tdMedical1;
    let tdMedical2;
    let tdMedical3;
    let tdMedical4;
    let tdDoctor1;
    let tdDoctor2;
    let tdDoctor3;
    let tdDoctor4;
    let tdHospital1;
    let tdHospital2;
    let tdHospital3;
    let tdHospital4;
    for (let grade of survey.grades) {

        if (grade.question == "medical1")
            tdMedical1 = $('<td>' + grade.grade + '</td>');
        else if (grade.question == "medical2")
            tdMedical2 = $('<td>' + grade.grade + '</td>');
        else if (grade.question == "medical3")
            tdMedical3 = $('<td>' + grade.grade + '</td>');
        else if (grade.question == "medical4")
            tdMedical4 = $('<td>' + grade.grade + '</td>');
        else if (grade.question == "doctor1")
            tdDoctor1 = $('<td>' + grade.grade + '</td>');
        else if (grade.question == "doctor2")
            tdDoctor2 = $('<td>' + grade.grade + '</td>');
        else if (grade.question == "doctor3")
            tdDoctor3 = $('<td>' + grade.grade + '</td>');
        else if (grade.question == "doctor4")
            tdDoctor4 = $('<td>' + grade.grade + '</td>');
        else if (grade.question == "hospital1")
            tdHospital1 = $('<td>' + grade.grade + '</td>');
        else if (grade.question == "hospital2")
            tdHospital2 = $('<td>' + grade.grade + '</td>');
        else if (grade.question == "hospital3")
            tdHospital3 = $('<td>' + grade.grade + '</td>');
        else if (grade.question == "hospital4")
            tdHospital4 = $('<td>' + grade.grade + '</td>');
    }
    let tdMedical;
    let tdDoctor;
    let tdHospital;
    for (let grade of survey.averageGrades) {

        if (grade.question == "medical")
            tdMedical = $('<td>' + grade.grade + '</td>');
        else if (grade.question == "doctor")
            tdDoctor = $('<td>' + grade.grade + '</td>');
        else if (grade.question == "hospital")
            tdHospital = $('<td>' + grade.grade + '</td>');
    }
    let tdDoctorName = $('<td>' + survey.doctor +'</td>');

    tr_medical.append($('<td>' + survey.id + '</td>')).append(tdMedical1).append(tdMedical2).append(tdMedical3).append(tdMedical4).append(tdMedical)
    tr_doctor.append($('<td>' + survey.id + '</td>')).append(tdDoctorName).append(tdDoctor1).append(tdDoctor2).append(tdDoctor3).append(tdDoctor4).append(tdDoctor)
    tr_hospital.append($('<td>' + survey.id + '</td>')).append(tdHospital1).append(tdHospital2).append(tdHospital3).append(tdHospital4).append(tdHospital)

    $('#table_doctor tbody').append(tr_doctor);
    $('#table_medical tbody').append(tr_medical);
    $('#table_hospital tbody').append(tr_hospital);
}



$(document).ready(function () {

    $.get({
        url: 'http://localhost:49153/api/survey',
        success: function (surveys) {
            for (let survey of surveys) {
                addSurvey(survey);
            }
        }
    });

    $('#button_doctor').click(function (event) {
        var origin = window.location.origin;
        window.location.href = origin + "/html/viewSurveyDoctor.html"
    });

    $('#quit').click(function (event) {
        var origin = window.location.origin;
        window.location.href = origin + "/html/feedback.html"
    });

});