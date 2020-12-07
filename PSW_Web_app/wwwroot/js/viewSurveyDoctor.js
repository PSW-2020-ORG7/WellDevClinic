function addSurvey(survey) {
    let tr_doctor = $('<tr></tr>');
    let tdDoctor1;
    let tdDoctor2;
    let tdDoctor3;
    let tdDoctor4;
    for (let grade of survey.grades) {

        if (grade.question == "doctor1")
            tdDoctor1 = $('<td>' + grade.grade + '</td>');
        else if (grade.question == "doctor2")
            tdDoctor2 = $('<td>' + grade.grade + '</td>');
        else if (grade.question == "doctor3")
            tdDoctor3 = $('<td>' + grade.grade + '</td>');
        else if (grade.question == "doctor4")
            tdDoctor4 = $('<td>' + grade.grade + '</td>');
    }
    let tdDoctor;
    for (let grade of survey.averageGrades) {
        if (grade.question == "doctor")
            tdDoctor = $('<td>' + grade.grade + '</td>');
    }

    tr_doctor.append($('<td>' + survey.id + '</td>')).append(tdDoctor1).append(tdDoctor2).append(tdDoctor3).append(tdDoctor4).append(tdDoctor);
    $('#table_doctor tbody').append(tr_doctor);
}

function addAverage(grades) {

    let tr_doctor = $('<tr></tr>');
    let tdDoctor1;
    let tdDoctor2;
    let tdDoctor3;
    let tdDoctor4;
    let tdAverage;

    for (let grade of grades) {

        if (grade.question == "question1")
            tdDoctor1 = $('<td>' + grade.grade + '</td>');
        else if (grade.question == "question2")
            tdDoctor2 = $('<td>' + grade.grade + '</td>');
        else if (grade.question == "question3")
            tdDoctor3 = $('<td>' + grade.grade + '</td>');
        else if (grade.question == "question4")
            tdDoctor4 = $('<td>' + grade.grade + '</td>');
        else
            tdAverage = $('<td>' + grade.grade + '</td>');
    }

    tr_doctor.append(tdDoctor1).append(tdDoctor2).append(tdDoctor3).append(tdDoctor4).append(tdAverage);
    $('#table_average tbody').append(tr_doctor);
}

function deleteTable() {
    $('#table_average tbody').empty();
    $('#table_doctor tbody').empty();
}


$(document).ready(function () {

    $("#doctor").on('change', function () {
        deleteTable();
        let doctor = $("#doctor").val();
            $.get({
                url: "http://localhost:49153/api/survey/"+ doctor,
                success: function (surveys) {
                    for (let survey of surveys)
                        addSurvey(survey);
                    if (surveys.length > 0) {
                        $.post({
                            url: "http://localhost:49153/api/survey/doctor_average",
                            data: JSON.stringify(surveys),
                            success: function (grades) {
                                addAverage(grades);
                            },
                            contentType: "application/json; charset=utf-8"
                        })
                    }

                },
            })

    });
    
});