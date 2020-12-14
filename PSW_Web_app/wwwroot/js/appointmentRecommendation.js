$(document).ready(function () {
    validDate();
    $.get({
        url: window.location.protocol + "//" + window.location.host + "/api/doctor/",
        success: function (doctors) {
            for (let i = 0; i < doctors.length; i++) {
                addDoctor(doctors[i])
            }
        }
    });

    $('form#form').submit(function (event) {
        event.preventDefault();
        let doctor = $('select[name="doctor"]').val();
        let date = $('input[name="date"]').val();
        let date2 = $('input[name="date2"]').val();
        let radio_value = $('input[name=priority]:checked').val();
        console.log(doctor);
        console.log(date);
        console.log(date2);
        console.log(radio_value);

        $.post({
            url: window.location.protocol + "//" + window.location.host + '/api/businessDay/',
            data: JSON.stringify({ doctorid: doctor, date: date, date2: date2 }),
            contentType: 'application/json',
            success: function (list) {
                deleteTable();
                i = 1;
                for (let recommendation of list) {
                    addRecommendation(recommendation, i);
                    i++;
                }
            }
        });
    })
});

function addDoctor(doctor) {
    let select = document.getElementById("doctor_select");
    var option = document.createElement('option');
    option.setAttribute('value', doctor.id);
    option.text = doctor.fullName;
    select.appendChild(option);
}

function validDate() {
    var today = new Date().toISOString().split('T')[0];
    document.getElementsByName("date")[0].setAttribute('min', today);
    document.getElementsByName("date2")[0].setAttribute('min', today);
}

function addRecommendation(recommendation, i) {
    for (let term of recommendation.terms) {
        tr = $('<tr id="tr"></tr>');
        let row = $('<th scope="row">' + i + '</th>');
        let doctor = $('<td>' + recommendation.doctor + '</td>');
        let doctorId = $('<td>' + recommendation.doctorId + '</td>');
        let room = $('<td>' + recommendation.room + '</td>');
        let button = $('<td><input type="button" value="Schedule" onclick="myFunction(this)"></td>');
        let time = $('<td>' + term + '</td>');
        tr.append(doctorId).append(doctor).append(room).append(time).append(button);
        $('#tbody').append(tr);
    }
}
function deleteTable() {
    $('#tbody').empty();
}

function myFunction(item) {
    var row = $(item).closest("tr");
    var tds = row.find("td");
    var doctorId = tds[0].innerHTML;
    var date = tds[3].innerHTML;
    let radio_value = $('input[name=priority]:checked').val();
    console.log(radio_value);
    var priority = true;
    if (radio_value == "doctor") {
        priority = false;
    }
    console.log(date);
    $.ajax({
        url: window.location.protocol + "//" + window.location.host + '/api/examination/create/',
        type: 'POST',
        data: JSON.stringify({ doctorId: doctorId, date: date, priority: priority }),
        success: function (data) {
            console.log("usao u success!");
            console.log(data);
            if (data != null) {
                alert('Success!');
                location.reload();
            }
        },
        contentType: "application/json; charset=utf-8"
    });

}