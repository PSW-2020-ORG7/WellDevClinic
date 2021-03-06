﻿var allMeds = [];
var br = 0;
var delList = [];
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
        error: function (e) {
            $("#message").empty();
            $('#message').text('Error occured while loading tenders!');
            $("#pageInfo").show();
        }
    });

    $(".add_field_button").click(function (e) {
        e.preventDefault();
        skip = false;
        if (br > 1) {
            br -= 2;
            if ($("#" + br).val() == "") {
                skip = true;
            } 
            br += 2;
        }
        if ($(".input_fields_wrap").children().length < 10 && skip == false) {
            let contentField = '<div>';
            contentField += '<div class="autocomplete">';
            contentField += '<input id= "' + br + '" type="text" name="medicineName" placeholder="Enter medicine name" autocomplete="off" value =""/> ';
            contentField += "</div>";
            br += 1;
            contentField += '<input id="' + br + '" type="number" name="quantity" placeholder="Enter amount"/> ';
            //contentField += '<button class="btn btn-outline-danger remove_field">&times;</button>';
            contentField += '</div>';
            $(".input_fields_wrap").append(contentField);
            br += 1;
            for (let inp of document.getElementsByName('medicineName'))
                autocomplete(inp, allMeds.map(x => x.name));
        }
    });

    /*$(".input_fields_wrap").on('click', '.remove_field', function (e) {
        e.preventDefault();
        br -= 1;
        $(this).parent('div').remove();
    });*/

    $(".close").click(function () {
        $(".modalCustom").hide(200);
    });

    $("#btnTenderModal").click(function () {
        $("#modalAddTender").slideDown("fast");
    });
})

function getMedicationStock() {
    $("#viewMedication").empty();
    $("#viewMedication").append('<a class="dropdown-item" href="#" onClick="setName(\'All medications\')">All medications</a>');
    $.ajax({
        method: "GET",
        url: "../api/medication/",
        contentType: "application/json",
        success: function (allMedications) {
            allMeds = allMedications;
            for (let med of allMedications) {
                let content = '<a class="dropdown-item" href="#" onClick="setName(\'' + med.name + '\')">';
                content += med.name;
                content += '</a>';

                $("#viewMedication").append(content);
            }
            for (let inp of document.getElementsByName('medicineName'))
                autocomplete(inp, allMeds.map(x => x.name));
        },
        error: function (e) {
            $('#write').text(e.responseText);
            $("#stockAction").show();
            $("#btnOk").click(function () {
                $("#txtResponse").val(e.status + " " + e.statusText);
            });
        },
    });
}

function setName(name) {
    $("#btnMed").text(name);
}


function viewAllTenders(tenders) {
    $("#viewTender").empty();
    var now = Date.now();

    for (let ten of tenders) {
        if (ten.isDeleted == false) {
            var content = '<div';
            var date = new Date(ten.period.endDate).getTime();
            var expired = false;

            if (date < now) {
                content += ' class= "card text-white bg-dark mb-3" style="width:350px; display:inline-block;">';
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
                    content += '<tr style="background: transparent;"><td float="right">';
                    content += med.name + '</td><td>  x' + med.amount + '</td></tr>';
                }
            }
            content += '</table></h5><hr color="#FFFF33"> <table>';
            content += '<tr style="color: gray;background: transparent;"><td float="right" >Start date:</td><td>';
            content += ISOtoShort(new Date(ten.period.startDate));
            content += '</td></tr>';
            content += '<tr style="color: gray; background: transparent;"><td float="right">End date:</td><td>';
            content += ISOtoShort(new Date(ten.period.endDate));
            content += '</td></tr>';
            content += '</table><br>';
            if (expired == true) {
                content += '<button type="button" class="btn btn-danger btn-lg" onclick="deleteTender(\'' + ten.id + '\')" data-toggle="modal" data-target="#sendModal">';
                content += 'Delete tender</button >&nbsp;&nbsp;';
            } else {
                content += '<button type="button" class="btn btn-info btn-lg" onclick="makeOffer(\'' + ten.id + '\')" id="' + ten.id + '" data-toggle="modal" data-target="#sendModal">';
                content += 'Make offer</button >&nbsp;&nbsp;';
            }
            content += '<button type="button" class="btn btn-secondary btn-lg" onclick="viewOffers(\'' + ten.id + '\')" > ';
            content += 'View offers</button >';
            content += '</div></div></div>';
            $("#viewTender").append(content);
        }
        
    }

}

function viewOffers(tender) {
    window.location.assign(window.location.origin += "/viewTenderOffers.html?" + tender);
}

function makeOffer(tender) {
    $("#viewNeeds").empty();
    $("#modalTender").slideDown("fast");

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
            content += '<tr><td>Price:&nbsp;</td><td><input type="number" id="txtPrice" min="1" max="6">€<td></tr>';
            $("#viewNeeds").append(content);
            $("#idTender").val(data.id);

            $("#btnAddOffer").click(function () {
                let name = $("#txtName").val();
                let price = $("#txtPrice").val();
                let message = $("#txtNote").val();
                let email = $("#txtEmail").val();
                let meds = [];

                var patternNum = /^\d+$/;
                var patternEmail = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;

                if (name == "" || price == "" || email == "") {
                    $('#message').html('Please fill out requested fields.');
                    $("#pageInfo").show();
                } else if (patternNum.test(Number(price)) == false) {
                    $('#message').html('Ups! Price must be a positive number.');
                    $("#pageInfo").show();
                } else if (patternEmail.test(email) == false) {
                    $('#message').html('Ups! Invalid email format. Format is example@mail.com');
                    $("#pageInfo").show();
                } else {
                    for (let ten of data.medications) {
                        var elemN = ten.name;
                        var elemA = $("#" + ten.name).val();
                        if (elemA == '') {
                            elemA == '0';
                        }
                        let med = {
                            "name": elemN,
                            "amount": Number(elemA)
                        };

                        meds.push(med);
                    }
                    console.log(meds);

                    $.ajax({
                        method: "POST",
                        url: "../api/tenderoffer/add",
                        contentType: "application/json",
                        data: JSON.stringify({
                            PharmacyName: name,
                            Price: Number(price),
                            Medications: meds,
                            Message: message,
                            TenderId: Number(tender),
                            Mail: { Mail: email }
                        }),
                        success: function (data) {
                            if (data) {
                                $('#message').html('Succesfully added to database.');
                                $("#pageInfo").show();
                            }
                        },
                        error: function (e) {
                            $("#message").empty();
                            $('#message').html('Already exists.');
                            $("#pageInfo").show();
                        }
                    })
                }
            })
        },
    });

}

function addTender() {
    let meds = [];
    var patternNum = /^\d+$/;
    console.log(meds);
    let startDate = $("#dateStart").val();
    let endDate = $("#dateEnd").val();


    for (let i = 0; i < br; i++) {
        medName = $("#" + i + "").val();
        i += 1;
        medAmount = $("#" + i + "").val();
        if (medName == "" || medAmount == "") {
            $('#message').html('Please fill out requested fields.');
            $("#pageInfo").show();
            continue;
        } else {
            if (patternNum.test(Number(medAmount)) == false) {
                $('#message').html('Ups! Price must be a positive number.');
                $("#pageInfo").show();
                return;
            } else {
                var item = {
                    "name": medName,
                    "amount": Number(medAmount)
                };
                meds.push(item);

                if (startDate == "" || endDate == "") {
                    $('#message').text('Start date and end date can not be empty!');
                    $("#pageInfo").show();
                } else if (startDate >= endDate) {
                    $('#message').text('Start date can not be same or greater than end date!');
                    $("#pageInfo").show();
                } else {
                    $.ajax({
                        method: "POST",
                        url: "../api/tender/add",
                        contentType: "application/json",
                        data: JSON.stringify({
                            Medications: meds,
                            Period: {
                                StartDate: startDate,
                                EndDate: endDate
                            },
                            IsDeleted: false
                        }),
                        success: function (data) {
                            if (data) {
                                $('#message').text('Succesfully added to database.');
                                $("#pageInfo").show();
                                $("#btnOk").click(function () {
                                    window.location.reload();
                                })
                            }
                        },
                        error: function (e) {
                            $("#message").empty();
                            $('#message').text('Already exists.');
                            $("#pageInfo").show();
                        }
                    });
                }
            }
        }
    } 

    if (br == 0) {
        $('#message').html('Please add desired medications. You can not make tender without at least one medication.');
        $("#pageInfo").show();
    }
}

function deleteTender(tender) {
    $.ajax({
        method: "PUT",
        url: "../api/tender/delete/" + tender,
        contentType: "application/json",
        success: function (tender) {
            console.log(tender);
            window.location.reload();
        },

        error: function (e) {
            $("#message").empty();
            $('#message').text('Error occured while deleting tender!');
            $("#pageInfo").show();
        }
    });
}

function subscribe(e) {
    e.preventDefault();
    let mail = $("#inpEmail").val();
    if (!mail || !mail.includes('@'))
        return;

    $.ajax({
        method: "POST",
        url: "../api/pharmacyemails/add",
        contentType: "application/json",
        data: JSON.stringify({
            Mail: { Mail: $('#inpEmail').val()}
        }),
        success: function (data) {
            if (data) {
                $('#message').text('Succesfully added to database.');
                $('#inpEmail').css('borderColor', '#ffffff')
                $('#subscribe-result').css('color', '#17a2b8')
                $('#subscribe-result').html('<p>Thank you for subscribing. We will inform you when new tender is opened.</p>')
                $('#inpEmail').val('')
                $("#pageInfo").show();
            }
        },
        error: function (e) {
            $("#message").empty();
            $('#message').text('Already exists.');
            $("#pageInfo").show();
        }
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