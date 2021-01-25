var allMedications;
var nameList = [];

$(document).ready(function () {
    $.ajax({
        method: "GET",
        url: "../api/medication",
        contentType: "application/json",
        success: function (data) {
            allMedications = data;
            for (let inp of document.getElementsByName('medicineName'))
                autocomplete(inp, allMedications.map(x => x.name));
        },
        error: function (e) {
            pageInfo("An error has occured while trying to get hospital medications!");
        }
    });

    $("#btnUrgent").click(function (e) {
        e.preventDefault();
        $("#urgProcurementInput").show();
    });

    $(".close").click(function () {
        $(".modalCustom").hide(200);
    });

	$(".add_field_button").click(function (e) {
		e.preventDefault();
		if ($(".input_fields_wrap").children().length < 10) {
            $(".input_fields_wrap").append('<div><div class="autocomplete">' +
                '<input type = "text" name = "medicineName" placeholder = "Enter medicine name" class= "ac" autocomplete="off"/> ' +
                '</div>' +
				'<input placeholder="Enter amount" type="number" name="quantity"/> ' +
				'<button class="btn btn-outline-danger remove_field">&times;</button>' +
                '</div>');
            for (let inp of document.getElementsByName('medicineName'))
                autocomplete(inp, allMedications.map(x => x.name));
		}
	});

	$(".input_fields_wrap").on('click', '.remove_field', function (e) {
		e.preventDefault();
		$(this).parent('div').remove();
    });

    $("#purchase").click(function () {
        let pharmacyName = $("#phName").val();
        let medicationOrder = [];

        $('span[name="medicine"]').each(function (i, el) {
            let item = {
                "medicineName": $(el).text(),
                "amount": Number(document.getElementsByName('amountToBuy')[i].value)
            }
            medicationOrder.push(item);
        });

        $.ajax({
            method: "POST",
            url: "../api/medication/orderMedicines?phName=" + pharmacyName,
            contentType: "application/json",
            data: JSON.stringify(medicationOrder),
            success: function (data) {
                if (data != null) {
                    let message = 'New medication stock: ';
                    for (let d of data) {
                        message += d.amount + 'x' + d.name + ', ';
                    }
                    message = message.slice(0, -2);
                    message += '. Expect your package soon!';
                    $("#message").text(message);
                    $("#pageInfoModal").modal('toggle');
                    $("#pageInfo").show();
                }
            },
            error: function (e) {
                alert("ERROR: " + e.status);
            }
        });
    });
});

function findMedicines() {
    $("#responseLoad").show();
    var n = $(".input_fields_wrap").children().length;
    let medicinesToBuy = [];
    $("input[name='medicineName']").each(function (i, el) {
        let med = {
            "name": $(el).val(),
            "amount": Number(document.getElementsByName('quantity')[i].value)
        }
        medicinesToBuy.push(med); 
    });

    $.ajax({
        method: "POST",
        url: "../api/medication/findMedsPh",
        contentType: "application/json",
        data: JSON.stringify(medicinesToBuy),
        success: function (data) {
            $("#responseLoad").hide();
            if (data.length > 0) {
                showUrgTable(data, n);
                $("#urgProcurementInput").hide();
            }
        },
        error: function (e) {
            pageInfo("Cannot find pharmacy! Maybe you lost connection!");
        }
    });
        
}

function showUrgTable(pharmacies, n) {
    nameList = [];
    $("#medTableData").find('tbody').empty();
    for (let ph of pharmacies) {
        let content = '<tr>';
        content += '<td>' + ph.medicine.name + '</td>';
        content += '<td>' + ph.medicine.amount + '</td>';
        content += '<td>' + ph.price + '</td>';
        content += '<td>' + ph.phName + '</td>';
        content += '</tr>';

        $("#medTableData").find('tbody').append(content);

        if (n > 0) {
            $('#divAmount').append('<span name="medicine">' + ph.medicine.name + '</span>: ');
            $('#divAmount').append('<input type="number" name="amountToBuy" min="1" id="' + ph.medicine.name + '" style="width:150px" />');
            $('#divAmount').append('<span id="price"></span><br/>');
            n--;
        }
        
        if (nameList.includes(ph.phName))
            continue;
        nameList.push(ph.phName);
        $("#phName").append('<option value="' + ph.phName + '">' + ph.phName + '</option>');
    }
    $("#urgProcurementResponse").removeAttr("hidden");
}

function orderMedicines() {
    
}

function pageInfo(text) {
    $("#message").text(text);
    $("#pageInfoModal").modal('toggle');
    $("#pageInfo").show();
}