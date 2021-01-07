$(document).ready(function () {
    getMedicationStock();
    $.ajax({
        method: "GET",
        url: "../api/tender",
        contentType: "application/json",
        success: function (data) {
            viewAllTenders(data);
            console.log(data);
        },
    });

    $("#btnAddTender").click(function () {
        //let medicationName = $("#btnMed").text();
        let startDate = $("#dateStart").val();
        let endDate = $("#dateEnd").val();
        let list = {"Id":1, "Name":"Brufen"};

        if (startDate == "" || endDate == "") {
            alert("Start date and end date can't be empty!")
            return;
        }
        if (startDate > endDate) {
            alert("Start date can't be greater than end date!")
            return;
        }

        var jsonTender = JSON.stringify({
            Medications: [],
            StartDate: startDate,
            EndDate: endDate
        });

        $.ajax({
            method: "POST",
            url: "../api/tender/add",
            contentType: "application/json",
            data: jsonTender,
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

    $(".close").click(function () {
        $(".modalCustom").hide(200);
    })

    $("#btnAddTen").click(function () {
        $("#modalAddTender").slideDown("fast");
    })
   


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
    var $form = $('#mc-embedded-subscribe-form')
    if ($form.length > 0) {
        $('form input[type="submit"]').bind('click', function (event) {
            if (event) event.preventDefault()
            subscribe($form)
        })
    }
})

function getMedicationStock() {
    $("#viewMedication").empty();
    $("#viewMedication").append('<a class="dropdown-item" href="#" onClick="setName(\'All medications\')">All medications</a>');
    $.ajax({
        method: "GET",
        url: "../api/medication/",
        contentType: "application/json",
        success: function (allMeds) {
            for (let med of allMeds) {
                let content = '<a class="dropdown-item" href="#" onClick="setName(\'' + med.name + '\')">';
                content += med.name;
                content += '</a>';

                $("#viewMedication").append(content);
            }
        },
        error: function (e) {
            $('#write').html(e.responseText);
            $("#stockAction").show();
            $("#btnOk").click(function () {
                $("#txtResponse").val(e.status + " " + e.statusText);
            });
        },
    });
}


function viewAllTenders(tenders) {
    $("#viewTender").empty();
    var neededMedications = {};

    for (let ten of tenders) {
        var content = '<div class="card" style="width:350px; display:inline-block">';
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
        content += '</div></div></div>';
        $("#viewTender").append(content);
    }
}



function makeOffer(tender) {
    $("#modalTender").slideDown("fast");
    $(".close").click(function () {
        $(".modalCustom").hide(200);
    })

    $("#idTender").val(tender);


    $("#btnAddOffer").click(function () {
        let name = $("#txtName").val();
        let price = $("#txtPrice").val();
        let message = $("#txtNote").val();

        let valid = true;

        var jsonApi = JSON.stringify({
            PharmacyName: name,
            Price: Number(price),
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

function subscribe($form) {
    $('#mc-embedded-subscribe').val('Sending...');
    $.ajax({
        contentType: 'application/json',
        error: function (err) { alert('Could not connect to the email server. Please try again later.') },
        success: function (data) {
            $('#mc-embedded-subscribe').val('subscribe')
            if (data) {
                $('#mce-EMAIL').css('borderColor', '#ffffff')
                $('#subscribe-result').css('color', 'rgb(53, 114, 210)')
                $('#subscribe-result').html('<p>Thank you for subscribing. We will inform you when new tender is opened.</p>')
                $('#mce-EMAIL').val('')
            } else {
                $('#mce-EMAIL').css('borderColor', '#ff8282')
                $('#subscribe-result').css('color', '#ff8282')
            }
        }
    })
}

function setName(name) {
    $("#btnMed").html(name);
}