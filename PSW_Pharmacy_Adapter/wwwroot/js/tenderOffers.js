$(document).ready(function () {

    $.ajax({
        method: "GET",
        url: "../api/tender",
        contentType: "application/json",
        success: function (data) {
            viewAllTenders(data);
        },
    });


    /*$("#btnAddOffer").click(function () {
        let name = $("#txtPharmacy").val();
        let price = $("#txtPrice").val();
        let id = $("#txtId").val();


        let valid = true;

        if (!name) {
            valid = false;
            $("#txtPharmacy").css("border-width", "1");
            $("#invalidName").css("display", "block");
        } else {
            $("#txtPharmacy").css("border-width", "0");
            $("#invalidName").css("display", "none");
        }
        if (!price) {
            valid = false;
            $("#txtPrice").css("border-width", "1");
            $("#invalidPrice").css("display", "block");
        } else {
            $("#txtPrice").css("border-width", "0");
            $("#invalidPrice").css("display", "none");
        }

        if (valid) {
            var jsonApi = JSON.stringify({
                PharmacyName : name,
                Price : Number(price),
                Id : Number(id),
                Medications : [],
                Message : ""
            });
        }


        $.ajax({
            method: "POST",
            url: "../api/tenderoffer/add",
            contentType: "application/json",
            data: jsonApi,
            success: function (data) {
                if (data) {
                    $('#message').html('Succesfully added to database.');
                }
            },
            error: function (e) {
                $("#message").empty();
                $('#message').html('Error.');
                $("#regAction").show();
            }
        })
    })*/
})


function viewAllTenders(tenders) {
    $("#viewTender").empty();
    for (let ten of tenders) {
        var content = '<div class="card" id="' + ten.id + '">';
        content += '<div class="card-body">';
        content += '<div class="data">';
        content += '<table style="margin:10px">';
        content += '<tr><td float="right">Id:</td><td>';
        content += ten.id;
        content += '</td></tr>';
        if (ten.medication != null) {
            content += '<tr><td float="right">Hospital need:</td>';
            content += '<td>';
            for (let med of ten.medication)
                content += med.name + ', <br/>';
            content += '</td>';
        }
        content += '</tr>';
        content += '<tr><td float="right">Start date:</td><td>';
        content += ISOtoShort(new Date(ten.startDate));
        content += '</td></tr>';
        content += '<tr><td float="right">End date:</td><td>';
        content += ISOtoShort(new Date(ten.endDate));
        content += '</td></tr>';
        content += '<tr><td colspan="2">'
        content += '<button type="button" class="btn btn-info" onclick="makeOffer(\'' + ten.id + '\')" id="' + ten.id + '" data-toggle="modal" data-target="#sendModal">';
        content += 'Make offer</button > ';
        content += '</td>';
        content += '</tr> ';
        content += '</table>';
        content += '</div></div></div>';
        $("#viewTender").append(content);
    }
}


function ISOtoShort(date) {
    let day = date.getDate();
    let month = (date.getMonth() + 1);
    let year = date.getFullYear();

    if (day < 10)
        day = '0' + day;
    if (month < 10)
        month = '0' + month;

    return String(day + '-' + month + '-' + year);
}