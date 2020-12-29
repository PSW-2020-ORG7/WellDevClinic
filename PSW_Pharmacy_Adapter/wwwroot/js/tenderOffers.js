$(document).ready(function () {

    $.ajax({
        method: "GET",
        url: "../api/tender",
        contentType: "application/json",
        success: function (data) {
            viewAllTenders(data);
            console.log(data);
        },
    });


    /*$("#btnAddOffer").click(function () {
        let name = $("#txtPharmacy").val();
        let price = $("#txtPrice").val();
        let id = $("#txtId").val();
        let message = $("#txtMessage").val();

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
                Medications: [],
                Message: message
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
                    $("#regAction").show();
                }
                //alert("Uspeo sam");
                //console.log(data);
            },
            error: function (e) {
                $("#message").empty();
                $('#message').html('Already exists.');
                $("#regAction").show();
            }
        })
    })*/
})


function viewAllTenders(tenders) {
    $("#viewTender").empty();
    for (let ten of tenders) {
        var content = '<div class="card" style="width:350px">';
        content += '<div class="card-body">';
        content += '<div class="data"> <h4 class="card-subtitle mb-2 text-muted">ID: '
        content += ten.id;
        content += '</h4>';
        content += '<h5><table style="margin:10px">';
        if (ten.medications != null) {
            content += '<h4>Hospital need:<h4>';
            
            for (let med of ten.medications) {
                content += '<tr><td float="right">';
                content += med.name + '</td><td>, &nbsp; amount: ' + med.amount + ';</td></tr>';
            }
        }
        content += '</table></h5><hr color="#FFFF33"> <table>';
        content += '<tr style="color: gray"><td float="right" >Start date:</td><td>';
        content += ISOtoShort(new Date(ten.startDate));
        content += '</td></tr>';
        content += '<tr style="color: gray"><td float="right">End date:</td><td>';
        content += ISOtoShort(new Date(ten.endDate));
        content += '</td></tr>';
        content += '</table><br>';
        content += '<button type="button" class="btn btn-primary btn-lg" onclick="makeOffer(\'' + ten.id + '\')" id="' + ten.id + '" data-toggle="modal" data-target="#sendModal">';
        content += 'Make offer</button >';
        /*content += '<tr><td colspan="2">'
        content += '<button type="button" class="btn btn-primary btn-lg" onclick="makeOffer(\'' + ten.id + '\')" id="' + ten.id + '" data-toggle="modal" data-target="#sendModal">';
        content += 'Send offer</button >';
        content += '</td>';
        content += '</tr> ';
        content += '</table>';*/
        content += '</div></div></div>';
        $("#viewTender").append(content);
    }
}



function makeOffer(tenderId) {
    $("#modalTender").slideDown("fast");
    $(".close").click(function () {
        $(".modalCustom").hide(200);
    })

        $("#btnAddOffer").click(function () {
        let name = $("#txtName").val();
        let price = $("#txtPrice").val();
        let id = $("#txtId").val();
        let message = $("#txtNote").val();

        let valid = true;

        var jsonApi = JSON.stringify({
            PharmacyName: name,
            Price: Number(price),
            Id: Number(id),
            Medications: [],
            Message: message,
            TenderId: Number(tender)
        });

        $.ajax({
            method: "POST",
            url: "../api/tenderoffer/add",
            contentType: "application/json",
            data: jsonApi,
            success: function (data) {
                if (data) {
                    $('#message').html('Succesfully added to database.');
                    $("#regAction").show();
                }
            },
            error: function (e) {
                $("#message").empty();
                $('#message').html('Already exists.');
                $("#regAction").show();
            }
        })
    })
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