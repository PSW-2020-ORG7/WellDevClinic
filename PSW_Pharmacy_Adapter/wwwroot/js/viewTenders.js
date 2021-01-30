var allMeds = [];
var br = 0;

$(document).ready(function () {
    getAllMedications();
    $.ajax({
        method: "GET",
        url: "../api/tender",
        contentType: "application/json",
        success: function (data) {
            if (data.length <= 0)
                $("#noContent").removeAttr("hidden");
            else
                viewAllTenders(data);
            $("#pageLoader").hide();
        },
        error: function (e) {
            pageInfo('Error has occurred while trying to load tenders!');
            $("#noContent").removeAttr("hidden");
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

function getAllMedications() {
    $.ajax({
        method: "GET",
        url: "../api/medication/",
        contentType: "application/json",
        success: function (allMedications) {
            allMeds = allMedications;
            
            for (let inp of document.getElementsByName('medicineName'))
                autocomplete(inp, allMeds.map(x => x.name));
        },
        error: function (e) {
            pageInfo("An error has occured while trying to connect with hospital server. Try again later!");
        },
    });
}

function viewAllTenders(tenders) {
    $("#viewTender").empty();
    var now = Date.now();

    for (let ten of tenders) {
        if (ten.isDeleted == true) continue;

        let endDate = new Date(ten.period.endDate).getTime();
        let startDate = new Date(ten.period.startDate).getTime();
        let expired = false;

        let content = '<div style="width:350px; display:inline-block;" class= "card';
        if (endDate < now) {
            content += ' text-white bg-dark mb-3';
            expired = true;
        }
        content += '"><div class="card-body">';
        content += '<div class="data"> <h4 class="card-subtitle mb-2 text-muted">ID: '
        content += ten.id;
        content += '</h4>';
        content += '<h5><table style="margin:10px">';
        if (ten.medications != null) {
            content += '<h4>Requirements:<h4>';

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
        if (expired) {
            content += '<button type="button" class="btn btn-danger btn-lg" onclick="deleteTender(\'' + ten.id + '\')">';
            content += 'Delete tender</button >&nbsp;&nbsp;';
            content += '<button type="button" class="btn btn-secondary btn-lg" onclick="viewOffers(\'' + ten.id + '\')" ';
            content += '>View offers</button >';
        } else {
            content += '<button type="button" class="btn btn-info btn-lg" onclick="offerForm(\'' + ten.id + '\')" ';
            if (startDate > now)
                content += "disabled ";
            content += '>Make offer</button >&nbsp;&nbsp;';
            content += '<button type="button" class="btn btn-secondary btn-lg" onclick="viewOffers(\'' + ten.id + '\')" ';
            if (startDate > now)
                content += "disabled ";
            content += '>View offers</button >';
        }       
        
        content += '</div></div></div>';
        $("#viewTender").append(content);      
    }
}

function viewOffers(tender) {
    window.location.assign(window.location.origin += "/viewTenderOffers.html?" + tender);
}

function offerForm(currTenderId) {
    $("#viewNeeds").empty();
    $("#txtName").val('');
    $("#txtEmail").val('');
    $("#txtNote").val('');

    $.ajax({
        method: "GET",
        url: "../api/tender/" + currTenderId,
        contentType: "application/json",
        success: function (tender) {
            let content = '<h4 class="text-muted">ID tender: ' + tender.id + '</h4>';
            content += '<table>';
            for (let med of tender.medications) {
                content += '<tr><td>' + med.name + '</td>';
                content += '<td><input type="number" min=' + med.amount + ' id="' + med.name + '" /></td></tr>';
            }
            content += '<tr><td>Price:&nbsp;</td><td><input type="number" id="txtPrice" min="1"> €<td></tr>';
            content += '</table>'
            $("#viewNeeds").append(content);
            $("#idTender").val(tender.id);
            $("#modalTender").slideDown("fast"); 

            $("#btnAddOffer").click(function () {
                let name = $("#txtName").val();
                let price = $("#txtPrice").val();
                let message = $("#txtNote").val();
                let email = $("#txtEmail").val();
                let meds = [];

                var patternNum = /^\d+$/;
                var patternEmail = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;

                if (name == "" || price == "" || email == "") {
                    pageInfo('Please fill out requested fields.');
                    return;
                } else if (patternNum.test(Number(price)) == false) {
                    pageInfo('Oops! Price must be a positive number.');
                    return;
                } else if (patternEmail.test(email) == false) {
                    pageInfo('Oops! Invalid email format. Format is example@mail.com');
                    return;
                }

                for (let med of tender.medications) {
                    let inpAmount = Number($("#" + med.name).val());
                    let minAmount = Number($("#" + med.name).attr('min'));
                    if (isNaN(inpAmount) || inpAmount < minAmount) {
                        pageInfo('Minimum amount for ' + med.name + ' is ' + minAmount);
                        return;
                    }

                    let item = {
                        "name": med.name,
                        "amount": inpAmount
                    };
                    meds.push(item);
                }

                $.ajax({
                    method: "POST",
                    url: "../api/tenderoffer/add",
                    contentType: "application/json",
                    data: JSON.stringify({
                        PharmacyName: name,
                        Price: Number(price),
                        Medications: meds,
                        Message: message,
                        TenderId: Number(tender.id),
                        Mail: { Mail: email }
                    }),
                    success: function (data) {
                        if (data)
                            pageInfo('Offer made succesfuly');
                    },
                    error: function (e) {
                        pageInfo('Offer with the same id already exists!');
                    }
                });
            });
        },
        error: function (e) {
            pageInfo('An unknown error has occurred.');
        },
    });

}

function addTender() {
    let meds = [];
    var patternNum = /^\d+$/;
    let startDate = $("#dateStart").val();
    let endDate = $("#dateEnd").val();

    if (startDate == "" || endDate == "") {
        pageInfo('Start date and end date must be specified!');
        return;
    } else if (startDate >= endDate) {
        pageInfo('End date must be greater than start date!');
        return;
    } else if (br == 0) {
        pageInfo('Please add desired medications. You can not make tender without at least one medication.');
        return;
    }

    for (let i = 0; i < br; i++) {
        medName = $("#" + i + "").val();
        i += 1;
        medAmount = $("#" + i + "").val();
        if (medName == "" || medAmount == "") {
            pageInfo('Please fill out requested fields.');
            return;
        }
        if (patternNum.test(Number(medAmount)) == false) {
            pageInfo('Oops! Price must be a positive number.');
            return;
        } else {
            let item = {
                "name": medName,
                "amount": Number(medAmount)
            };
            meds.push(item);
        }
    }

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
                pageInfo('Succesfully added to database.');
                $("#btnOk").click(function () {
                    window.location.reload();
                });
            }
        },
        error: function (e) {
            pageInfo('Tender with same id already exists!');
        }
    });
}

function deleteTender(tender) {
    $.ajax({
        method: "PUT",
        url: "../api/tender/delete/" + tender,
        contentType: "application/json",
        success: function (tender) {
            window.location.reload();
        },
        error: function (e) {
            pageInfo('Error occured while deleting tender!');
        }
    });
}

function subscribe(e) { 
    let mail = $("#inpEmail").val();
    if (!mail || !mail.includes('@'))
        return;
    e.preventDefault();

    $.ajax({
        method: "POST",
        url: "../api/pharmacyemails/add",
        contentType: "application/json",
        data: JSON.stringify({
            Mail: { Mail: $('#inpEmail').val()}
        }),
        success: function (data) {
            if (data) {
                $('#subscribe-result').removeAttr('hidden');
                $('#inpEmail').val('');
                pageInfo('You have subscribed for tenders successfuly!');
            }
        },
        error: function (e) {
            if(e.status == 400)
                pageInfo('You have already subscribed.');
            else
                pageInfo('An unknown error has occurred.');
        }
    });
}

function pageInfo(text) {
    $("#message").text(text);
    $("#pageInfoModal").modal('toggle');
    $("#pageInfo").show();
}