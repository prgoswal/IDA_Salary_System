
function LoadBasic() {

    

    $(document).ready(function () {
        $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
    });

    $(document).ready(function () {
        $('.chzn-search input[type="text"]').addClass('form-control');
        $('.chzn-single').addClass('form-control');
    });

    ///// Plus Minus Collapse In and Out
    $('.panel-collapse').each(function () {
        if ($(this).hasClass('in')) {
            $(this).parent('.panel').find('.panel-heading').removeClass('collapsed');
        }
    })

    ////////////////////////////////////Load Basic Employee Master Fix Payee Checked Change Update Panel/////////////////////////////////////////////

    //$('#ContentPlaceHolder1_lblMsg').hide();
    //$('#ContentPlaceHolder1_ddlDeputation').css('border-color', 'lightgray');
    //    if ($('#ContentPlaceHolder1_ddlDeputation').val() == '1') {
    //    $('#ContentPlaceHolder1_txtDepuDate').removeAttr('disabled');
    //    $('#ContentPlaceHolder1_txtDepuPlace').removeAttr('disabled');
    //    $('#ContentPlaceHolder1_txtDepuDate').focus();
    //}
    //else {
    //    $('#ContentPlaceHolder1_txtDepuDate').attr('disabled', 'disabed');
    //    $('#ContentPlaceHolder1_txtDepuPlace').attr('disabled', 'disabed');
    //    $('#ContentPlaceHolder1_txtDepuDate').val('');
    //    $('#ContentPlaceHolder1_txtDepuPlace').val('');
    //}


    $('[id=ContentPlaceHolder1_rbFixPayee] input').unbind().click(function (e) {
        var val = $('[id=ContentPlaceHolder1_rbFixPayee]').find('input:checked').val();
        if (val == 0) {
            $('#ContentPlaceHolder1_ddlGrade').removeAttr('disabled');
            $('#ContentPlaceHolder1_ddlGrade').val('000');
        }
        else {

            $('#ContentPlaceHolder1_ddlGrade').attr('disabled', 'disabed');
            $('#ContentPlaceHolder1_ddlGrade').val('0');

        }
    });
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    //$(document).ready(function () {
    //    $('.search_client_by').change(function () {
    //        var searchtype = $('.search_client_by').val();
    //        var options = $('#clients');
    //        if (searchtype == 'client_name') {
    //            options.html('<option value="Ankit Consultancy Pvt Ltd Indore"><option value="Jay Dev Civilcon India Private Limited Bhopal"><option value="Sushma Multitrade Pvt Ltd Mumbai"><option value="Evergreen Colours India Private Limited Indore"><option value="Kartikey Colonisers Pvt Ltd Ujjain"><option value="Krini Infratech Private Limited Dhar"><option value="Sarvottam Cropscience India Pvt Ltd Sagar">')
    //        }
    //        if (searchtype == 'client_gstin') {
    //            options.html('<option value="23AAAPO5542D1K5">')
    //        }
    //        if (searchtype == 'client_pan') {
    //            options.html('<option value="AAAPO5542D">')
    //        }
    //    })
    //});

    //$(document).ready(function () {
    //    $('.show_records_table').click(function () {
    //        $('.records_table').removeClass('hidden');
    //    });
    //    $('.hide_records_table').click(function () {
    //        $('.records_table').addClass('hidden');
    //    })
    //});

    //$(document).ready(function () {
    //    container = document.getElementById('radio_a_container');
    //    links = container.getElementsByTagName('a');
    //    for (i = 0; i < links.length; i++) {
    //        links[i].addEventListener("click", function (e) {
    //            e.preventDefault();
    //            this.childNodes[1].checked = true;
    //        });
    //    }
    //});

    $(document).ready(function () {
        $("div.bhoechie-tab-menu>div.list-group>a").click(function (e) {
            e.preventDefault();
            $(this).siblings('a.active').removeClass("active");
            $(this).addClass("active");
            var index = $(this).index();
            $("div.bhoechie-tab>div.bhoechie-tab-content").removeClass("active");
            $("div.bhoechie-tab>div.bhoechie-tab-content").eq(index).addClass("active");
        });
    });

    $(document).ready(function () {

        var current_url = $(location).attr('pathname').split('/').slice(-1)[0];
        var pagename = current_url;
        $('aside a').each(function () {
            var href = $(this).attr('href');
            if (href == pagename) {
                $(this).parent('li').addClass("active");
                $(this).parents('ul').addClass("in");
                //console.log(href + pagename);

            }
        });

        

    });

    //////////////////////////////////////////////////////////////////////////

    function PopOverError(id, plac, msg) {
        try {
            $(id).popover({
                title: 'Error!',
                trigger: 'manual',
                placement: plac,
                content: function () {
                    var message = msg; //"Allow Numbers Only!";
                    return message;
                }
            });
            $(id).popover("show");
        } catch (e) { }
    }

    //// For Numeri Value Only \\\\\\


    $(document).ready(function () {
        $('.numberonly').keypress(function (event) {
            try {
                var chCode = (event.charCode === undefined) ? event.keyCode : event.charCode;
                var id = ('#' + this.id);
                if (chCode > 31 && (chCode < 48 || chCode > 57)) {
                    PopOverError(id, 'top', 'Allow Numbers Only!');
                    return false;
                }
                else {
                    $(id).popover('destroy');
                    return true;
                }
            } catch (e) {

            }
        });
        $('.numberonly').blur(function (e) {
            try {
                var id = ('#' + this.id);
                $(id).popover('destroy');
            } catch (e) { }
        });


        $('.Amount').keypress(function (event) {
            try {
                var chCode = (event.charCode === undefined) ? event.keyCode : event.charCode;
                var id = ('#' + this.id);
                if (chCode > 31 && (chCode < 48 || chCode > 57)) {
                    PopOverError(id, 'top', 'Allow Numeric Value Only!');
                    return false;
                }
                else {
                    $(id).popover('destroy');
                    return true;
                }
            } catch (e) {

            }
        });
        $('.Amount').blur(function (e) {
            try {
                var id = ('#' + this.id);
                $(id).popover('destroy');
            } catch (e) { }
        });

        //// For Valid Date Allow \\\\\\
        $('.datepicker').datepicker({ dateFormat: 'dd/mm/yy', maxDate: '0', changeYear: true, changeMonth: true });
        $('.datepicker').blur(function (e) {
            try {

                var id = ('#' + this.id);
                var date = $(id).val();
                $(id).popover('destroy');
                var valid = true;
                if (date.length <= 0 || date == '' || date == undefined) {
                    return false;
                }
                //if (date.match(/^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[1,3-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$/)) {
                if (date.match(/^([0-9]{2})\/([0-9]{2})\/([0-9]{4})$/)) {
                    valid = true;
                } else {
                    valid = false;
                }

                if (valid) {
                    $(id).popover('destroy');
                } else {
                    PopOverError(id, 'top', 'Invalid Date.');
                    $(id).focus();
                }
            } catch (e) { }
        });
        $('.datepicker').keypress(function (e) {
            try {
                $(id).popover('destroy');
                var chCode = (e.charCode === undefined) ? e.keyCode : e.charCode;
                var id = ('#' + this.id);
                if (chCode > 31 && (chCode < 48 || chCode > 57)) {
                    PopOverError(id, 'top', 'Enter Valid Key For Date.');
                    return false; //Non Numeric Value Return Directly;
                }
                else {
                    if ($(id).val() === undefined) {
                        event.preventDefault();
                        return;
                    }
                    if (e.key == "/") {
                        PopOverError(id, 'top', 'This Key Is Invalid!');
                        event.preventDefault();
                        return false;
                    }
                    if (e.keyCode != 8) {

                        var DateVal = $(id).val();
                        if (e.keyCode == 191) {
                            var corr = DateVal.slice(0, DateVal.lastIndexOf("/"));
                            PopOverError(id, 'top', 'Enter Valid Date!');
                            $(id).val(corr);
                            event.preventDefault();
                            return false;
                        }

                        if ($(id).val().length == 2) {
                            if ($(id).val() < 1 || $(id).val() > 31) {
                                $(id).val("")
                                PopOverError(id, 'top', 'Enter Valid Day!');
                                event.preventDefault();
                                return false;
                            }
                            $(id).val($(id).val() + "/");
                        } else if ($(id).val().length == 5) {
                            var month = $(id).val().substring(3, 6);
                            if (month < 1 || month > 12) {
                                var corr = $(id).val().replace("/" + month, "");
                                $(id).val(corr);
                                PopOverError(id, 'top', 'Enter Valid Month!');
                                event.preventDefault();
                                return false;
                            }
                            $(id).val($(id).val() + "/");
                        } else if ($(id).val().length == 10) {
                            var Inputyear = $(id).val().substring(6, 11);
                            var NowYear = new Date().getUTCFullYear();
                            if (Inputyear < 1900 || Inputyear > NowYear) {
                                var corr = $(id).val().replace(Inputyear, "");
                                $(id).val(corr);
                                PopOverError(id, 'top', 'Enter Valid Year!');
                                event.preventDefault();
                                return false;
                            }
                        }
                        else { $(id).popover('destroy'); }
                    }
                }
            } catch (e) { }
        });


        //////////Birth Date ////////////////
        $('.BirthDate').datepicker({ dateFormat: 'dd/mm/yy', maxDate: '0', yearRange: '1900:+0', changeYear: true, changeMonth: true });
        $('.BirthDate').blur(function (e) {
            try {

                var id = ('#' + this.id);
                var date = $(id).val();
                $(id).popover('destroy');
                var valid = true;
                if (date.length <= 0 || date == '' || date == undefined) {
                    return false;
                }
                //if (date.match(/^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[1,3-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$/)) {
                if (date.match(/^([0-9]{2})\/([0-9]{2})\/([0-9]{4})$/)) {
                    valid = true;
                } else {
                    valid = false;
                }

                if (valid) {
                    $(id).popover('destroy');
                } else {
                    PopOverError(id, 'top', 'Invalid Date.');
                    $(id).focus();
                }
            } catch (e) { }
        });
        $('.BirthDate').keypress(function (e) {
            try {
                $(id).popover('destroy');
                var chCode = (e.charCode === undefined) ? e.keyCode : e.charCode;
                var id = ('#' + this.id);
                if (chCode > 31 && (chCode < 48 || chCode > 57)) {
                    PopOverError(id, 'top', 'Enter Valid Key For Date.');
                    return false; //Non Numeric Value Return Directly;
                }
                else {
                    if ($(id).val() === undefined) {
                        event.preventDefault();
                        return;
                    }
                    if (e.key == "/") {
                        PopOverError(id, 'top', 'This Key Is Invalid!');
                        event.preventDefault();
                        return false;
                    }
                    if (e.keyCode != 8) {

                        var DateVal = $(id).val();
                        if (e.keyCode == 191) {
                            var corr = DateVal.slice(0, DateVal.lastIndexOf("/"));
                            PopOverError(id, 'top', 'Enter Valid Date!');
                            $(id).val(corr);
                            event.preventDefault();
                            return false;
                        }

                        if ($(id).val().length == 2) {
                            if ($(id).val() < 1 || $(id).val() > 31) {
                                $(id).val("")
                                PopOverError(id, 'top', 'Enter Valid Day!');
                                event.preventDefault();
                                return false;
                            }
                            $(id).val($(id).val() + "/");
                        } else if ($(id).val().length == 5) {
                            var month = $(id).val().substring(3, 6);
                            if (month < 1 || month > 12) {
                                var corr = $(id).val().replace("/" + month, "");
                                $(id).val(corr);
                                PopOverError(id, 'top', 'Enter Valid Month!');
                                event.preventDefault();
                                return false;
                            }
                            $(id).val($(id).val() + "/");
                        } else if ($(id).val().length == 10) {
                            var Inputyear = $(id).val().substring(6, 11);
                            var NowYear = new Date().getUTCFullYear();
                            if (Inputyear < 1900 || Inputyear > NowYear) {
                                var corr = $(id).val().replace(Inputyear, "");
                                $(id).val(corr);
                                PopOverError(id, 'top', 'Enter Valid Year!');
                                event.preventDefault();
                                return false;
                            }
                        }
                        else { $(id).popover('destroy'); }
                    }
                }
            } catch (e) { }
        });

        ////////////////////////////////////


        $('.datepickerForExpiryDate').datepicker({ dateFormat: 'dd/mm/yy', minDate: '0', changeYear: true, changeMonth: true });
        $('.datepickerForExpiryDate').blur(function (e) {
            try {

                var id = ('#' + this.id);
                var date = $(id).val();
                $(id).popover('destroy');
                var valid = true;
                if (date.length <= 0 || date == '' || date == undefined) {
                    return false;
                }
                //if (date.match(/^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[1,3-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$/)) {
                if (date.match(/^([0-9]{2})\/([0-9]{2})\/([0-9]{4})$/)) {
                    valid = true;
                } else {
                    valid = false;
                }

                if (valid) {
                    $(id).popover('destroy');
                } else {
                    PopOverError(id, 'top', 'Invalid Date.');
                    $(id).focus();
                }
            } catch (e) { }
        });
        $('.datepickerForExpiryDate').keypress(function (e) {
            try {
                $(id).popover('destroy');
                var chCode = (e.charCode === undefined) ? e.keyCode : e.charCode;
                var id = ('#' + this.id);
                if (chCode > 31 && (chCode < 48 || chCode > 57)) {
                    PopOverError(id, 'top', 'Enter Valid Key For Date.');
                    return false; //Non Numeric Value Return Directly;
                }
                else {
                    if ($(id).val() === undefined) {
                        event.preventDefault();
                        return;
                    }
                    if (e.key == "/") {
                        PopOverError(id, 'top', 'This Key Is Invalid!');
                        event.preventDefault();
                        return false;
                    }
                    if (e.keyCode != 8) {

                        var DateVal = $(id).val();
                        if (e.keyCode == 191) {
                            var corr = DateVal.slice(0, DateVal.lastIndexOf("/"));
                            PopOverError(id, 'top', 'Enter Valid Date!');
                            $(id).val(corr);
                            event.preventDefault();
                            return false;
                        }

                        if ($(id).val().length == 2) {
                            if ($(id).val() < 1 || $(id).val() > 31) {
                                $(id).val("")
                                PopOverError(id, 'top', 'Enter Valid Day!');
                                event.preventDefault();
                                return false;
                            }
                            $(id).val($(id).val() + "/");
                        } else if ($(id).val().length == 5) {
                            var month = $(id).val().substring(3, 6);
                            if (month < 1 || month > 12) {
                                var corr = $(id).val().replace("/" + month, "");
                                $(id).val(corr);
                                PopOverError(id, 'top', 'Enter Valid Month!');
                                event.preventDefault();
                                return false;
                            }
                            $(id).val($(id).val() + "/");
                        } else if ($(id).val().length == 10) {
                            var Inputyear = $(id).val().substring(6, 11);
                            var NowYear = new Date().getUTCFullYear();
                            if (Inputyear < 1900 || Inputyear > NowYear) {
                                var corr = $(id).val().replace(Inputyear, "");
                                $(id).val(corr);
                                PopOverError(id, 'top', 'Enter Valid Year!');
                                event.preventDefault();
                                return false;
                            }
                        }
                        else { $(id).popover('destroy'); }
                    }
                }
            } catch (e) { }
        });

        $('.Money').blur(function (e) {
            try {
                var id = ('#' + this.id);
                $(id).popover('destroy');
            } catch (e) { }
        });
        $('.Money').keypress(function (e) {
            try {
                var id = ('#' + this.id);
                var val = $(id).val();
                var chCode = (e.charCode === undefined) ? e.keyCode : e.charCode;
                var id = ('#' + this.id);
                $(id).popover('destroy');

                if (chCode != 46) {
                    if (chCode > 31 && (chCode < 48 || chCode > 57)) {
                        PopOverError(id, 'top', 'Enter Valid Amount');
                        return false; //Non Numeric Value Return Directly;
                    }
                }

                if (val.indexOf(".") != -1 && val.indexOf(".") + 3 == val.length && event.keyCode != 8 && event.keyCode != 17 && event.keyCode != 37 && event.keyCode != 39 && event.keyCode != 46 && event.keyCode != 9) {
                    PopOverError(id, 'top', 'This Allow Only Amount Ex-1000.20');
                    event.preventDefault();
                    return false;
                }
                if (event.keyCode == 46 && val == "") {
                    PopOverError(id, 'top', 'This Allow Only Amount Ex-1000.20');
                    event.preventDefault();
                    return false;
                }
                if (val.split(".").length > 1 && event.keyCode == 46) {
                    PopOverError(id, 'top', 'This Allow Only Amount Ex-1000.20');
                    event.preventDefault();
                    return false;
                }
            } catch (e) {

            }
        });

        $('.Qty').keypress(function (e) {
            try {
                var id = ('#' + this.id);
                var val = $(id).val();
                var chCode = (e.charCode === undefined) ? e.keyCode : e.charCode;
                var id = ('#' + this.id);
                $(id).popover('destroy');

                if (chCode != 46) {
                    if (chCode > 31 && (chCode < 48 || chCode > 57)) {
                        PopOverError(id, 'top', 'Enter Valid Qty.');
                        return false; //Non Numeric Value Return Directly;
                    }
                }

                if (val.indexOf(".") != -1 && val.indexOf(".") + 3 == val.length && event.keyCode != 8 && event.keyCode != 17 && event.keyCode != 37 && event.keyCode != 39 && event.keyCode != 46 && event.keyCode != 9) {
                    PopOverError(id, 'top', 'This Allow Only Amount Ex-1000.20');
                    event.preventDefault();
                    return false;
                }
                if (event.keyCode == 46 && val == "") {
                    PopOverError(id, 'top', 'This Allow Only Amount Ex-1000.20');
                    event.preventDefault();
                    return false;
                }
                if (val.split(".").length > 1 && event.keyCode == 46) {
                    PopOverError(id, 'top', 'This Allow Only Amount Ex-1000.20');
                    event.preventDefault();
                    return false;
                }
            } catch (e) {

            }
        });

        $('.Alphaonly').keypress(function (e) {
            try {
                var chCode = (event.charCode === undefined) ? event.keyCode : event.charCode;
                var id = ('#' + this.id);
                if ((chCode > 64 && chCode < 91) || (chCode > 96 && chCode < 123) || chCode == 32) {
                    $(id).popover('destroy');
                    return true;
                } else {
                    PopOverError(id, 'top', 'Allow Characters Only!');
                    return false;
                }
            } catch (e) {

            }
        });
        $('.Alphaonly').blur(function (e) {
            var id = ('#' + this.id);
            $(id).popover('destroy');
        });

        $('.Mobile').blur(function (e) {
            try {
                var id = ('#' + this.id);
                var mobile = $(id).val();
                $(id).popover('destroy');
                var valid = true;
                if (mobile == undefined || mobile == '') {
                    return false;
                }


                if (mobile.length == 10) {
                    valid = true;
                } else {
                    valid = false;
                }

                if (valid) {
                    $(id).popover('destroy');

                } else {
                    $(id).focus();
                    PopOverError(id, 'top', 'Enter 10 Digit Mobile No.');
                    e.preventDefault();
                    //return false;
                }
            } catch (e) { }
        });

        $('.PinCode').blur(function (e) {
            try {
                var id = ('#' + this.id);
                var pinCode = $(id).val();
                $(id).popover('destroy');
                var valid = true;
                if (pinCode == undefined || pinCode == '') {
                    return false;
                }
                if (pinCode.length == 6) {
                    valid = true;
                } else {
                    valid = false;
                }

                if (valid) {
                    $(id).popover('destroy');

                } else {
                    PopOverError(id, 'top', 'Enter 6 Digit PinCode.');
                    $(id).focus();
                    event.preventDefault();
                    return false;
                }
            } catch (e) { }
        });

        $('.PanNo').blur(function (e) {
            var id = ('#' + this.id);
            var val = $(id).val();
            if (val.length >= 1) {
                if (val.length < 10) {
                    PopOverError(id, 'top', 'Invalid Pan No.');
                    event.preventDefault();
                    $(id).focus();
                    return false;
                } else {
                    $(id).popover('destroy');
                    return true;
                }
            }
        });
        $('.PanNo').keypress(function (e) {
            try {
                var chCode = (event.charCode === undefined) ? event.keyCode : event.charCode;
                var id = ('#' + this.id);
                $(id).popover('destroy');

                if ($(id).val().length < 5) {

                    if ((chCode > 64 && chCode < 91) || (chCode > 96 && chCode < 123)) {
                        $(id).popover('destroy');
                    } else {
                        PopOverError(id, 'top', 'Allow Characters Only!');
                        return false;
                    }
                }
                else if ($(id).val().length < 9) {

                    if (chCode > 31 && (chCode < 48 || chCode > 57)) {
                        PopOverError(id, 'top', 'Allow Numbers Only!');
                        return false;
                    }
                }
                else if ($(id).val().length < 10) {

                    if ((chCode > 64 && chCode < 91) || (chCode > 96 && chCode < 123) || chCode == 32) {
                        $(id).popover('destroy');
                    } else {
                        PopOverError(id, 'top', 'Allow Characters Only!');
                        return false;
                    }
                }

                if ($(id).val().length == 10) {
                    PopOverError(id, 'top', 'Allow 10 Characters Only!');
                    return false;
                }
                else {
                }

            } catch (e) {

            }
        });


        $('.NoOfDays').keypress(function (e) {
            try {
                var id = ('#' + this.id);
                var val = $(id).val();
                var chCode = (e.charCode === undefined) ? e.keyCode : e.charCode;
                var id = ('#' + this.id);
                $(id).popover('destroy');

                if (chCode != 46) {
                    if (chCode > 31 && (chCode < 48 || chCode > 57)) {
                        PopOverError(id, 'top', 'Enter Valid Qty.');
                        return false; //Non Numeric Value Return Directly;
                    }
                }

                if (val.indexOf(".") != -1 && val.indexOf(".") + 3 == val.length && event.keyCode != 8 && event.keyCode != 17 && event.keyCode != 37 && event.keyCode != 39 && event.keyCode != 46 && event.keyCode != 9) {
                    PopOverError(id, 'top', 'This Allow No Of Days Ex-1000.20');
                    event.preventDefault();
                    return false;
                }
                if (event.keyCode == 46 && val == "") {
                    PopOverError(id, 'top', 'This Allow Only No Of Days Ex-1000.20');
                    event.preventDefault();
                    return false;
                }
                if (val.split(".").length > 1 && event.keyCode == 46) {
                    PopOverError(id, 'top', 'This Allow Only No Of Days Ex-1000.20');
                    event.preventDefault();
                    return false;
                }
            } catch (e) {

            }
        });

        $('.NoOfDays').blur(function (e) {
            var id = ('#' + this.id);
            $(id).popover('destroy');
        });


        $('.AlphaNum').keypress(function (event) {

            try {
                var chCode = (event.charCode === undefined) ? event.keyCode : event.charCode;
                var id = ('#' + this.id);
                if ((chCode > 64 && chCode < 91) || (chCode > 96 && chCode < 123) || chCode == 32 || (chCode > 47 && chCode < 58)) {
                    $(id).popover('destroy');
                    return true;
                } else {
                    PopOverError(id, 'top', 'Allow Aplha And Number Only!');
                    return false;
                }
            } catch (e) {

            }
        });
        $('.AlphaNum').blur(function (e) {
            var id = ('#' + this.id);
            $(id).popover('destroy');
        });

        $('.Decimal4').blur(function (e) {
            try {
                var id = ('#' + this.id);
                $(id).popover('destroy');
            } catch (e) { }
        });
        $('.Decimal4').keypress(function (e) {
            try {
                var id = ('#' + this.id);
                var val = $(id).val();
                var chCode = (e.charCode === undefined) ? e.keyCode : e.charCode;
                var id = ('#' + this.id);
                $(id).popover('destroy');

                if (chCode != 46) {
                    if (chCode > 31 && (chCode < 48 || chCode > 57)) {
                        PopOverError(id, 'top', 'Enter Valid Number');
                        return false; //Non Numeric Value Return Directly;
                    }
                }

                if (val.indexOf(".") != -1 && val.indexOf(".") + 5 == val.length && event.keyCode != 8 && event.keyCode != 17 && event.keyCode != 37 && event.keyCode != 39 && event.keyCode != 46 && event.keyCode != 9) {
                    PopOverError(id, 'top', 'This Allow Only 4 Decimal Place');
                    event.preventDefault();
                    return false;
                }
                if (event.keyCode == 46 && val == "") {
                    PopOverError(id, 'top', 'This Allow Only 4 Decimal Place');
                    event.preventDefault();
                    return false;
                }
                if (val.split(".").length > 3 && event.keyCode == 46) {
                    PopOverError(id, 'top', 'This Allow Only 4 Decimal Place');
                    event.preventDefault();
                    return false;
                }
            } catch (e) {

            }
        });

        //function Loading() {
        //    try {
        //        $('#ModalLoader').modal();
        //    } catch (e) { }
        //}
        function openModal(errMsg, type, href) {
            try {
                if (type == "True") {
                    $('#header').addClass("bg-info");
                    $('#title').html("Success!")
                    $('#txtMsg').html(errMsg);
                    $('#header').removeClass("bg-danger");
                    $('#btnYes').attr('href', "#ModalInfo");
                }
                else {
                    $('#header').addClass("bg-danger");
                    $('#title').html("Error!")
                    $('#txtMsg').html(errMsg);
                    $('#header').removeClass("bg-info");
                    $('#btnYes').attr('href', href);
                }
                $('#ModalInfo').modal();
                $("#btnModelClose").blur();
                $("#btnModelClose").focus();
            } catch (e) { }
        }
        //function LoadActive() {
        //    $('.loading').addClass('active');
        //}
    });


}


//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



//$(document).ready(function () {
//    $('.search_client_by').change(function () {
//        var searchtype = $('.search_client_by').val();
//        var options = $('#clients');
//        if (searchtype == 'client_name') {
//            options.html('<option value="Ankit Consultancy Pvt Ltd Indore"><option value="Jay Dev Civilcon India Private Limited Bhopal"><option value="Sushma Multitrade Pvt Ltd Mumbai"><option value="Evergreen Colours India Private Limited Indore"><option value="Kartikey Colonisers Pvt Ltd Ujjain"><option value="Krini Infratech Private Limited Dhar"><option value="Sarvottam Cropscience India Pvt Ltd Sagar">')
//        }
//        if (searchtype == 'client_gstin') {
//            options.html('<option value="23AAAPO5542D1K5">')
//        }
//        if (searchtype == 'client_pan') {
//            options.html('<option value="AAAPO5542D">')
//        }
//    })
//});



//$(document).ready(function () {
//    $('.show_records_table').click(function () {
//        $('.records_table').removeClass('hidden');
//    });
//    $('.hide_records_table').click(function () {
//        $('.records_table').addClass('hidden');
//    })
//});

//$(document).ready(function () {
//    container = document.getElementById('radio_a_container');
//    links = container.getElementsByTagName('a');
//    for (i = 0; i < links.length; i++) {
//        links[i].addEventListener("click", function (e) {
//            e.preventDefault();
//            this.childNodes[1].checked = true;
//        });
//    }
//});


$(document).ready(function () {
    $("div.bhoechie-tab-menu>div.list-group>a").click(function (e) {
        e.preventDefault();
        $(this).siblings('a.active').removeClass("active");
        $(this).addClass("active");
        var index = $(this).index();
        $("div.bhoechie-tab>div.bhoechie-tab-content").removeClass("active");
        $("div.bhoechie-tab>div.bhoechie-tab-content").eq(index).addClass("active");
    });
});

$(document).ready(function () {
    var current_url = $(location).attr('pathname').split('/').slice(-1)[0];
    var pagename = current_url;
    $('aside a').each(function () {
        var href = $(this).attr('href');
        if (href == pagename) {
            $(this).parent('li').addClass("active");
            $(this).parents('ul').addClass("in");
            //console.log(href + pagename);
        }
    });
});

function PopOverError(id, plac, msg) {
    try {
        $(id).popover({
            title: 'Error!',
            trigger: 'manual',
            placement: plac,
            content: function () {
                var message = msg; //"Allow Numbers Only!";
                return message;
            }
        });
        $(id).popover("show");
    } catch (e) { }
}

//// For Numeri Value Only \\\\\\

$(document).ready(function () {
    $('.numberonly').keypress(function (event) {

        try {
            var chCode = (event.charCode === undefined) ? event.keyCode : event.charCode;
            var id = ('#' + this.id);
            if (chCode > 31 && (chCode < 48 || chCode > 57)) {
                PopOverError(id, 'top', 'Allow Numbers Only!');
                return false;
            }
            else {
                $(id).popover('destroy');
                return true;
            }
        } catch (e) {

        }
    });
    $('.numberonly').blur(function (e) {
        try {
            var id = ('#' + this.id);
            $(id).popover('destroy');
        } catch (e) { }
    });

    $('.NotAllowSpace').keypress(function (event) {
        try {
            var chCode = (event.charCode === undefined) ? event.keyCode : event.charCode;
            var id = ('#' + this.id);
            if (chCode == 32) {
                PopOverError(id, 'top', 'Not Allow Space...!');
                return false;
            }
            else {
                $(id).popover('destroy');
                return true;
            }
        } catch (e) {

        }
    });
    $('.NotAllowSpace').blur(function (e) {
        try {
            var id = ('#' + this.id);
            $(id).popover('destroy');
        } catch (e) { }
    });


    $('.Amount').keypress(function (event) {
        try {
            var chCode = (event.charCode === undefined) ? event.keyCode : event.charCode;
            var id = ('#' + this.id);
            if (chCode > 31 && (chCode < 48 || chCode > 57)) {
                PopOverError(id, 'top', 'Allow Numeric Value Only!');
                return false;
            }
            else {
                $(id).popover('destroy');
                return true;
            }
        } catch (e) {

        }
    });
    $('.Amount').blur(function (e) {
        try {
            var id = ('#' + this.id);
            $(id).popover('destroy');
        } catch (e) { }
    });


    //// For Valid Date Allow \\\\\\
    $('.datepicker').datepicker({ dateFormat: 'dd/mm/yy', maxDate: '0', changeYear: true, changeMonth: true });
    $('.datepicker').blur(function (e) {
        try {

            var id = ('#' + this.id);
            var date = $(id).val();
            $(id).popover('destroy');
            var valid = true;
            if (date.length <= 0 || date == '' || date == undefined) {
                return false;
            }
            //if (date.match(/^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[1,3-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$/)) {
            if (date.match(/^([0-9]{2})\/([0-9]{2})\/([0-9]{4})$/)) {
                valid = true;
            } else {
                valid = false;
            }

            if (valid) {
                $(id).popover('destroy');
            } else {
                PopOverError(id, 'top', 'Invalid Date.');
                $(id).focus();
            }
        } catch (e) { }
    });
    $('.datepicker').keypress(function (e) {
        try {
            $(id).popover('destroy');
            var chCode = (e.charCode === undefined) ? e.keyCode : e.charCode;
            var id = ('#' + this.id);
            if (chCode > 31 && (chCode < 48 || chCode > 57)) {
                PopOverError(id, 'top', 'Enter Valid Key For Date.');
                return false; //Non Numeric Value Return Directly;
            }
            else {
                if ($(id).val() === undefined) {
                    event.preventDefault();
                    return;
                }
                if (e.key == "/") {
                    PopOverError(id, 'top', 'This Key Is Invalid!');
                    event.preventDefault();
                    return false;
                }
                if (e.keyCode != 8) {

                    var DateVal = $(id).val();
                    if (e.keyCode == 191) {
                        var corr = DateVal.slice(0, DateVal.lastIndexOf("/"));
                        PopOverError(id, 'top', 'Enter Valid Date!');
                        $(id).val(corr);
                        event.preventDefault();
                        return false;
                    }

                    if ($(id).val().length == 2) {
                        if ($(id).val() < 1 || $(id).val() > 31) {
                            $(id).val("")
                            PopOverError(id, 'top', 'Enter Valid Day!');
                            event.preventDefault();
                            return false;
                        }
                        $(id).val($(id).val() + "/");
                    } else if ($(id).val().length == 5) {
                        var month = $(id).val().substring(3, 6);
                        if (month < 1 || month > 12) {
                            var corr = $(id).val().replace("/" + month, "");
                            $(id).val(corr);
                            PopOverError(id, 'top', 'Enter Valid Month!');
                            event.preventDefault();
                            return false;
                        }
                        $(id).val($(id).val() + "/");
                    } else if ($(id).val().length == 10) {
                        var Inputyear = $(id).val().substring(6, 11);
                        var NowYear = new Date().getUTCFullYear();
                        if (Inputyear < 1900 || Inputyear > NowYear) {
                            var corr = $(id).val().replace(Inputyear, "");
                            $(id).val(corr);
                            PopOverError(id, 'top', 'Enter Valid Year!');
                            event.preventDefault();
                            return false;
                        }
                    }
                    else { $(id).popover('destroy'); }
                }
            }
        } catch (e) { }
    });

    //////////Birth Date ////////////////
    $('.BirthDate').datepicker({ dateFormat: 'dd/mm/yy', maxDate: '0', yearRange: '1900:+0', changeYear: true, changeMonth: true });
    $('.BirthDate').blur(function (e) {
        try {

            var id = ('#' + this.id);
            var date = $(id).val();
            $(id).popover('destroy');
            var valid = true;
            if (date.length <= 0 || date == '' || date == undefined) {
                return false;
            }
            //if (date.match(/^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[1,3-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$/)) {
            if (date.match(/^([0-9]{2})\/([0-9]{2})\/([0-9]{4})$/)) {
                valid = true;
            } else {
                valid = false;
            }

            if (valid) {
                $(id).popover('destroy');
            } else {
                PopOverError(id, 'top', 'Invalid Date.');
                $(id).focus();
            }
        } catch (e) { }
    });
    $('.BirthDate').keypress(function (e) {
        try {
            $(id).popover('destroy');
            var chCode = (e.charCode === undefined) ? e.keyCode : e.charCode;
            var id = ('#' + this.id);
            if (chCode > 31 && (chCode < 48 || chCode > 57)) {
                PopOverError(id, 'top', 'Enter Valid Key For Date.');
                return false; //Non Numeric Value Return Directly;
            }
            else {
                if ($(id).val() === undefined) {
                    event.preventDefault();
                    return;
                }
                if (e.key == "/") {
                    PopOverError(id, 'top', 'This Key Is Invalid!');
                    event.preventDefault();
                    return false;
                }
                if (e.keyCode != 8) {

                    var DateVal = $(id).val();
                    if (e.keyCode == 191) {
                        var corr = DateVal.slice(0, DateVal.lastIndexOf("/"));
                        PopOverError(id, 'top', 'Enter Valid Date!');
                        $(id).val(corr);
                        event.preventDefault();
                        return false;
                    }

                    if ($(id).val().length == 2) {
                        if ($(id).val() < 1 || $(id).val() > 31) {
                            $(id).val("")
                            PopOverError(id, 'top', 'Enter Valid Day!');
                            event.preventDefault();
                            return false;
                        }
                        $(id).val($(id).val() + "/");
                    } else if ($(id).val().length == 5) {
                        var month = $(id).val().substring(3, 6);
                        if (month < 1 || month > 12) {
                            var corr = $(id).val().replace("/" + month, "");
                            $(id).val(corr);
                            PopOverError(id, 'top', 'Enter Valid Month!');
                            event.preventDefault();
                            return false;
                        }
                        $(id).val($(id).val() + "/");
                    } else if ($(id).val().length == 10) {
                        var Inputyear = $(id).val().substring(6, 11);
                        var NowYear = new Date().getUTCFullYear();
                        if (Inputyear < 1900 || Inputyear > NowYear) {
                            var corr = $(id).val().replace(Inputyear, "");
                            $(id).val(corr);
                            PopOverError(id, 'top', 'Enter Valid Year!');
                            event.preventDefault();
                            return false;
                        }
                    }
                    else { $(id).popover('destroy'); }
                }
            }
        } catch (e) { }
    });

    ////////////////////////////////////

    $('.datepickerForExpiryDate').datepicker({ dateFormat: 'dd/mm/yy', minDate: '0', changeYear: true, changeMonth: true });
    $('.datepickerForExpiryDate').blur(function (e) {
        try {

            var id = ('#' + this.id);
            var date = $(id).val();
            $(id).popover('destroy');
            var valid = true;
            if (date.length <= 0 || date == '' || date == undefined) {
                return false;
            }
            //if (date.match(/^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[1,3-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$/)) {
            if (date.match(/^([0-9]{2})\/([0-9]{2})\/([0-9]{4})$/)) {
                valid = true;
            } else {
                valid = false;
            }

            if (valid) {
                $(id).popover('destroy');
            } else {
                PopOverError(id, 'top', 'Invalid Date.');
                $(id).focus();
            }
        } catch (e) { }
    });
    $('.datepickerForExpiryDate').keypress(function (e) {
        try {
            $(id).popover('destroy');
            var chCode = (e.charCode === undefined) ? e.keyCode : e.charCode;
            var id = ('#' + this.id);
            if (chCode > 31 && (chCode < 48 || chCode > 57)) {
                PopOverError(id, 'top', 'Enter Valid Key For Date.');
                return false; //Non Numeric Value Return Directly;
            }
            else {
                if ($(id).val() === undefined) {
                    event.preventDefault();
                    return;
                }
                if (e.key == "/") {
                    PopOverError(id, 'top', 'This Key Is Invalid!');
                    event.preventDefault();
                    return false;
                }
                if (e.keyCode != 8) {

                    var DateVal = $(id).val();
                    if (e.keyCode == 191) {
                        var corr = DateVal.slice(0, DateVal.lastIndexOf("/"));
                        PopOverError(id, 'top', 'Enter Valid Date!');
                        $(id).val(corr);
                        event.preventDefault();
                        return false;
                    }

                    if ($(id).val().length == 2) {
                        if ($(id).val() < 1 || $(id).val() > 31) {
                            $(id).val("")
                            PopOverError(id, 'top', 'Enter Valid Day!');
                            event.preventDefault();
                            return false;
                        }
                        $(id).val($(id).val() + "/");
                    } else if ($(id).val().length == 5) {
                        var month = $(id).val().substring(3, 6);
                        if (month < 1 || month > 12) {
                            var corr = $(id).val().replace("/" + month, "");
                            $(id).val(corr);
                            PopOverError(id, 'top', 'Enter Valid Month!');
                            event.preventDefault();
                            return false;
                        }
                        $(id).val($(id).val() + "/");
                    } else if ($(id).val().length == 10) {
                        var Inputyear = $(id).val().substring(6, 11);
                        var NowYear = new Date().getUTCFullYear();
                        if (Inputyear < 1900 || Inputyear > NowYear) {
                            var corr = $(id).val().replace(Inputyear, "");
                            $(id).val(corr);
                            PopOverError(id, 'top', 'Enter Valid Year!');
                            event.preventDefault();
                            return false;
                        }
                    }
                    else { $(id).popover('destroy'); }
                }
            }
        } catch (e) { }
    });

    $('.Money').blur(function (e) {
        try {
            var id = ('#' + this.id);
            $(id).popover('destroy');
        } catch (e) { }
    });
    $('.Money').keypress(function (e) {
        try {
            var id = ('#' + this.id);
            var val = $(id).val();
            var chCode = (e.charCode === undefined) ? e.keyCode : e.charCode;
            var id = ('#' + this.id);
            $(id).popover('destroy');

            if (chCode != 46) {
                if (chCode > 31 && (chCode < 48 || chCode > 57)) {
                    PopOverError(id, 'top', 'Enter Valid Amount');
                    return false; //Non Numeric Value Return Directly;
                }
            }

            if (val.indexOf(".") != -1 && val.indexOf(".") + 3 == val.length && event.keyCode != 8 && event.keyCode != 17 && event.keyCode != 37 && event.keyCode != 39 && event.keyCode != 46 && event.keyCode != 9) {
                PopOverError(id, 'top', 'This Allow Only Amount Ex-1000.20');
                event.preventDefault();
                return false;
            }
            if (event.keyCode == 46 && val == "") {
                PopOverError(id, 'top', 'This Allow Only Amount Ex-1000.20');
                event.preventDefault();
                return false;
            }
            if (val.split(".").length > 1 && event.keyCode == 46) {
                PopOverError(id, 'top', 'This Allow Only Amount Ex-1000.20');
                event.preventDefault();
                return false;
            }
        } catch (e) {

        }
    });

    $('.Qty').keypress(function (e) {
        try {
            var id = ('#' + this.id);
            var val = $(id).val();
            var chCode = (e.charCode === undefined) ? e.keyCode : e.charCode;
            var id = ('#' + this.id);
            $(id).popover('destroy');

            if (chCode != 46) {
                if (chCode > 31 && (chCode < 48 || chCode > 57)) {
                    PopOverError(id, 'top', 'Enter Valid Qty.');
                    return false; //Non Numeric Value Return Directly;
                }
            }

            if (val.indexOf(".") != -1 && val.indexOf(".") + 3 == val.length && event.keyCode != 8 && event.keyCode != 17 && event.keyCode != 37 && event.keyCode != 39 && event.keyCode != 46 && event.keyCode != 9) {
                PopOverError(id, 'top', 'This Allow Only Amount Ex-1000.20');
                event.preventDefault();
                return false;
            }
            if (event.keyCode == 46 && val == "") {
                PopOverError(id, 'top', 'This Allow Only Amount Ex-1000.20');
                event.preventDefault();
                return false;
            }
            if (val.split(".").length > 1 && event.keyCode == 46) {
                PopOverError(id, 'top', 'This Allow Only Amount Ex-1000.20');
                event.preventDefault();
                return false;
            }
        } catch (e) {

        }
    });

    $('.Alphaonly').keypress(function (e) {
        try {
            var chCode = (event.charCode === undefined) ? event.keyCode : event.charCode;
            var id = ('#' + this.id);
            if ((chCode > 64 && chCode < 91) || (chCode > 96 && chCode < 123) || chCode == 32) {
                $(id).popover('destroy');
                return true;
            } else {
                PopOverError(id, 'top', 'Allow Characters Only!');
                return false;
            }
        } catch (e) {

        }
    });
    $('.Alphaonly').blur(function (e) {
        var id = ('#' + this.id);
        $(id).popover('destroy');
    });

    $('.Mobile').blur(function (e) {
        try {
            var id = ('#' + this.id);
            var mobile = $(id).val();
            $(id).popover('destroy');
            var valid = true;
            if (mobile == undefined || mobile == '') {
                return false;
            }


            if (mobile.length == 10) {
                valid = true;
            } else {
                valid = false;
            }

            if (valid) {
                $(id).popover('destroy');

            } else {
                $(id).focus();
                PopOverError(id, 'top', 'Enter 10 Digit Mobile No.');
                e.preventDefault();
                //return false;
            }
        } catch (e) { }
    });

    $('.PinCode').blur(function (e) {
        try {
            var id = ('#' + this.id);
            var pinCode = $(id).val();
            $(id).popover('destroy');
            var valid = true;
            if (pinCode == undefined || pinCode == '') {
                return false;
            }
            if (pinCode.length == 6) {
                valid = true;
            } else {
                valid = false;
            }

            if (valid) {
                $(id).popover('destroy');

            } else {
                PopOverError(id, 'top', 'Enter 6 Digit PinCode.');
                $(id).focus();
                event.preventDefault();
                return false;
            }
        } catch (e) { }
    });

    $('.PanNo').blur(function (e) {
        var id = ('#' + this.id);
        var val = $(id).val();
        if (val.length >= 1) {
            if (val.length < 10) {
                PopOverError(id, 'top', 'Invalid Pan No.');
                event.preventDefault();
                $(id).focus();
                return false;
            } else {
                $(id).popover('destroy');
                return true;
            }
        }
    });
    $('.PanNo').keypress(function (e) {
        try {
            var chCode = (event.charCode === undefined) ? event.keyCode : event.charCode;
            var id = ('#' + this.id);
            $(id).popover('destroy');

            if ($(id).val().length < 5) {

                if ((chCode > 64 && chCode < 91) || (chCode > 96 && chCode < 123)) {
                    $(id).popover('destroy');
                } else {
                    PopOverError(id, 'top', 'Allow Characters Only!');
                    return false;
                }
            }
            else if ($(id).val().length < 9) {

                if (chCode > 31 && (chCode < 48 || chCode > 57)) {
                    PopOverError(id, 'top', 'Allow Numbers Only!');
                    return false;
                }
            }
            else if ($(id).val().length < 10) {

                if ((chCode > 64 && chCode < 91) || (chCode > 96 && chCode < 123) || chCode == 32) {
                    $(id).popover('destroy');
                } else {
                    PopOverError(id, 'top', 'Allow Characters Only!');
                    return false;
                }
            }

            if ($(id).val().length == 10) {
                PopOverError(id, 'top', 'Allow 10 Characters Only!');
                return false;
            }
            else {
            }

        } catch (e) {

        }
    });

    $('.AlphaNum').keypress(function (event) {

        try {
            var chCode = (event.charCode === undefined) ? event.keyCode : event.charCode;
            var id = ('#' + this.id);
            if ((chCode > 64 && chCode < 91) || (chCode > 96 && chCode < 123) || chCode == 32 || (chCode > 47 && chCode < 58)) {
                $(id).popover('destroy');
                return true;
            } else {
                PopOverError(id, 'top', 'Allow Aplha And Number Only!');
                return false;
            }
        } catch (e) {

        }
    });
    $('.AlphaNum').blur(function (e) {
        var id = ('#' + this.id);
        $(id).popover('destroy');
    });


    $('.NoOfDays').keypress(function (e) {
        try {
            var id = ('#' + this.id);
            var val = $(id).val();
            var chCode = (e.charCode === undefined) ? e.keyCode : e.charCode;
            var id = ('#' + this.id);
            $(id).popover('destroy');

            if (chCode != 46) {
                if (chCode > 31 && (chCode < 48 || chCode > 57)) {
                    PopOverError(id, 'top', 'Enter Valid Qty.');
                    return false; //Non Numeric Value Return Directly;
                }
            }

            if (val.indexOf(".") != -1 && val.indexOf(".") + 3 == val.length && event.keyCode != 8 && event.keyCode != 17 && event.keyCode != 37 && event.keyCode != 39 && event.keyCode != 46 && event.keyCode != 9) {
                PopOverError(id, 'top', 'This Allow No Of Days Ex-1000.20');
                event.preventDefault();
                return false;
            }
            if (event.keyCode == 46 && val == "") {
                PopOverError(id, 'top', 'This Allow Only No Of Days Ex-1000.20');
                event.preventDefault();
                return false;
            }
            if (val.split(".").length > 1 && event.keyCode == 46) {
                PopOverError(id, 'top', 'This Allow Only No Of Days Ex-1000.20');
                event.preventDefault();
                return false;
            }
        } catch (e) {

        }
    });

    $('.NoOfDays').blur(function (e) {
        var id = ('#' + this.id);
        $(id).popover('destroy');
    });

    $('.Decimal4').blur(function (e) {
        try {
            var id = ('#' + this.id);
            $(id).popover('destroy');
        } catch (e) { }
    });
    $('.Decimal4').keypress(function (e) {
        try {
            var id = ('#' + this.id);
            var val = $(id).val();
            var chCode = (e.charCode === undefined) ? e.keyCode : e.charCode;
            var id = ('#' + this.id);
            $(id).popover('destroy');

            if (chCode != 46) {
                if (chCode > 31 && (chCode < 48 || chCode > 57)) {
                    PopOverError(id, 'top', 'Enter Valid Number');
                    return false; //Non Numeric Value Return Directly;
                }
            }

            if (val.indexOf(".") != -1 && val.indexOf(".") + 5 == val.length && event.keyCode != 8 && event.keyCode != 17 && event.keyCode != 37 && event.keyCode != 39 && event.keyCode != 46 && event.keyCode != 9) {
                PopOverError(id, 'top', 'This Allow Only 4 Decimal Place');
                event.preventDefault();
                return false;
            }
            if (event.keyCode == 46 && val == "") {
                PopOverError(id, 'top', 'This Allow Only 4 Decimal Place');
                event.preventDefault();
                return false;
            }
            if (val.split(".").length > 3 && event.keyCode == 46) {
                PopOverError(id, 'top', 'This Allow Only 4 Decimal Place');
                event.preventDefault();
                return false;
            }
        } catch (e) {

        }
    });

    function Loading() {
        try {
            $('#ModalLoader').modal();
        } catch (e) { }
    }
    function openModal(errMsg, type, href) {
        try {
            if (type == "True") {
                $('#header').addClass("bg-info");
                $('#title').html("Success!")
                $('#txtMsg').html(errMsg);
                $('#header').removeClass("bg-danger");
                $('#btnYes').attr('href', "#ModalInfo");
            }
            else {
                $('#header').addClass("bg-danger");
                $('#title').html("Error!")
                $('#txtMsg').html(errMsg);
                $('#header').removeClass("bg-info");
                $('#btnYes').attr('href', href);
            }
            $('#ModalInfo').modal();
            $("#btnModelClose").blur();
            $("#btnModelClose").focus();
        } catch (e) { }
    }
    function LoadActive() {
        $('.loading').addClass('active');
    }

});

$(document).ready(function () {
    $('.ham-nav2').click(function () {
        $('.nav-list.collapse').collapse('hide');
    });
})

$(document).ready(function () {
    $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
});

$(document).ready(function () {
    $('.chzn-search input[type="text"]').addClass('form-control');
    $('.chzn-single').addClass('form-control');
});

//for Profile creation
var openDrop = false;
document.onmouseup = function (e) { /// Close Checkbox DropDown On Outside Click.
    try {
        var cb = document.getElementById('divdrop');
        if (openDrop == true) {
            openDrop = false;
            return false;
        }
        if (cb.classList.item(2) == 'in') {
            cb.hidden = true;
            cb.classList.remove('in');
        }
    } catch (e) {

    }
}
function Opendrop() { //// Open Checbox DropDown.
    try {
        document.getElementById('divdrop').classList.add('in');
    } catch (e) {

    }
}

function Closedrop(e) { //
    try {
        if (e != 1) {
            document.getElementById('divdrop').classList.add('in');
        }
    } catch (e) {

    }
}