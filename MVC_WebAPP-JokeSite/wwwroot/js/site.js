// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

        $("#selectjoketype").change(function () {
            if (this.value == "single") {
                $("#oneliner").css("display", "block");
                $("#twopartsetup").css("display", "none");
                $("#twopartdelivery").css("display", "none");
                $("#twopartsetupinput").val("");
                $("#twopartdeliveryinput").val("");
            }
            else {
                $("#oneliner").css("display", "none");
                $("#twopartsetup").css("display", "block");
                $("#twopartdelivery").css("display", "block");
                $("#onelinerinput").val("");
            }
        });
