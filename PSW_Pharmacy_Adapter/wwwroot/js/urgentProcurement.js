$(document).ready(function () {
	$("#btnUrgent").click(function (event) {
		event.preventDefault();
		$("#modalUrgProcurement").slideDown("fast");
	});

	$(".add_field_button").click(function (e) {
		e.preventDefault();
		if ($(".input_fields_wrap").children().length < 5) {
            $(".input_fields_wrap").append('<div><div class="autocomplete">' +
                '<input type = "text" name = "medicineName" placeholder = "Enter medicine name" class= "ac" /> ' +
                '</div>' +
				'<input placeholder="Enter amount" type="number" name="quantity[]"/> ' +
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
});

function autocomplete(inp, arr) {
    var currentFocus;
    inp.addEventListener("input", function (e) {
        var a, b, i, val = this.value;
        closeAllLists();
        if (!val)
            return false;
        currentFocus = -1;
        a = document.createElement("DIV");
        a.setAttribute("id", this.id + "autocomplete-list");
        a.setAttribute("class", "autocomplete-items");

        this.parentNode.appendChild(a);
        for (i = 0; i < arr.length; i++) {
            if (arr[i].substr(0, val.length).toUpperCase() == val.toUpperCase()) {
                b = document.createElement("DIV");
                b.innerHTML = "<strong>" + arr[i].substr(0, val.length) + "</strong>";
                b.innerHTML += arr[i].substr(val.length);
                b.innerHTML += "<input type='hidden' value='" + arr[i] + "'>";
                b.addEventListener("click", function (e) {
                    inp.value = this.getElementsByTagName("input")[0].value;
                    closeAllLists();
                });
                a.appendChild(b);
            }
        }
    });

    /*Keyboard button press*/
    inp.addEventListener("keydown", function (e) {
        var x = document.getElementById(this.id + "autocomplete-list");
        if (x) x = x.getElementsByTagName("div");
        if (e.keyCode == 40) {  //On arrow DOWN click
            currentFocus++;
            addActive(x);
        } else if (e.keyCode == 38) { //On arrow UP click
            currentFocus--;
            addActive(x);
        } else if (e.keyCode == 13) { // On Enter click
            e.preventDefault();
            if (currentFocus > -1)
                if (x)
                    x[currentFocus].click();
        }
    });

    function addActive(x) {
        if (!x) 
            return false;

        removeActive(x);
        if (currentFocus >= x.length) currentFocus = 0;
        if (currentFocus < 0) currentFocus = (x.length - 1);
        x[currentFocus].classList.add("autocomplete-active");
    }

    function removeActive(x) {
        for (var i = 0; i < x.length; i++)
            x[i].classList.remove("autocomplete-active");
    }

    function closeAllLists(elmnt) {
        var x = document.getElementsByClassName("autocomplete-items");
        for (var i = 0; i < x.length; i++)
            if (elmnt != x[i] && elmnt != inp)
                x[i].parentNode.removeChild(x[i]);
    }

    document.addEventListener("click", function (e) {
        closeAllLists(e.target);
    });
}