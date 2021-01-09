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

    $("#mc-embedded-subscribe").click(function () {
        let email = $("#mce-EMAIL").val();

        var jsonEmail = JSON.stringify({
            Email: email,
        });

        $.ajax({
            method: "POST",
            url: "../api/pharmacyemails/add",
            contentType: "application/json",
            data: jsonEmail,
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

    $("#btnAddTender").click(function () {
        let medicationName = $("#btnMed").text();
        let startDate = $("#dateStart").val();
        let endDate = $("#dateEnd").val();

        if (startDate == "" || endDate == "") {
            alert("Start date and end date can't be empty!")
            return;
        }
        if (startDate > endDate) {
            alert("Start date can't be greater than end date!")
            return;
        }

        var jsonTender = JSON.stringify({
            Medications: [{"name": medicationName}],
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
    var now = Date.now();

    for (let ten of tenders) {
        var content = '<div';
        var date = new Date(ten.endDate).getTime();
        var expired = false;

        if (date < now) {
            content += ' class= "card text-white bg-secondary mb-3" style="width:350px; display:inline-block;">';
            expired = true;
        } else {
            content += ' class="card" style="width:350px; display:inline-block;">';
        }
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
        if (expired == true) {
            content += '<button type="button" class="btn btn-danger btn-lg" onclick="deleteOffer(\'' + ten.id + '\')" data-toggle="modal" data-target="#sendModal">';
            content += 'Delete tender</button >&nbsp;&nbsp;';
        } else {
            content += '<button type="button" class="btn btn-primary btn-lg" onclick="makeOffer(\'' + ten.id + '\')" id="' + ten.id + '" data-toggle="modal" data-target="#sendModal">';
            content += 'Make offer</button >&nbsp;&nbsp;';
        }
        content += '<button type="button" class="btn btn-secondary btn-lg" onclick="viewOffers(\'' + ten.id + '\')" > ';
        content += 'View offers</button >';
        content += '</div></div></div>';
        $("#viewTender").append(content);
    }

}

function viewOffers(tender) {
    window.location.assign(window.location.origin += "/viewTenderOffers.html?" + tender);
}

function makeOffer(tender) {
    $("#viewNeeds").empty();

    $("#modalTender").slideDown("fast");
    $(".close").click(function () {
        $(".modalCustom").hide(200);
    })

    $.ajax({
        method: "GET",
        url: "../api/tender/" + tender,
        contentType: "application/json",
        success: function (data) {
            console.log(data);
            var content = '<tr><h4><td style="color: gray">ID tender: ' + data.id + '</td></h4></tr>';
            for (let ten of data.medications) {
                content += '<tr><td>' + ten.name + '</td><br>';
                content += '<td> <input type="number" id="' + ten.name + '" min="0" value="0"/></td></tr>';
            }
            content += '<tr><td>Price:&nbsp;</td><td><input type="number" id="txtPrice" min="1" max="6"><td></tr>';
            $("#viewNeeds").append(content);
            $("#idTender").val(data.id);

            $("#btnAddOffer").click(function () {
                let name = $("#txtName").val();
                let price = $("#txtPrice").val();
                let message = $("#txtNote").val();
                let meds = [];

                for (let ten of data.medications) {
                    var elemN = ten.name;
                    var elemA = $("#" + ten.name + "").val();
                    let med = {
                        "name": elemN,
                        "amount": Number(elemA)
                    };
                    
                    meds.push(med);
                }
                console.log(meds);
                

                var jsonApi = JSON.stringify({
                    PharmacyName: name,
                    Price: Number(price),
                    Medications: meds,
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
        },
    });

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