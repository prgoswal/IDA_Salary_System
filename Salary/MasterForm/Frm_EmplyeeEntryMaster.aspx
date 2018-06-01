<%@ Page Title="" Language="C#" MasterPageFile="~/Salary/SalaryMaster.master" AutoEventWireup="true" CodeFile="~/Salary/MasterForm/Frm_EmplyeeEntryMaster.aspx.cs" Inherits="MasterForm_Frm_EmplyeeEntryMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script type="text/javascript">
        function LoadAllScript() {
            LoadBasic();
            onLoad();
           // FunJoiningDate();
            BasicChange();
        }
    </script>
    <script type="text/javascript" src="https://www.google.com/jsapi"></script>

    <script>
        // Load the Google Transliterate API
        google.load("elements", "1", {
            packages: "transliteration"
        });

        function onLoad() {
            var options = {
                sourceLanguage:
                google.elements.transliteration.LanguageCode.ENGLISH,
                destinationLanguage:
                [google.elements.transliteration.LanguageCode.HINDI],
                shortcutKey: 'ctrl+g',
                transliterationEnabled: true
            };
            var control =
            new google.elements.transliteration.TransliterationControl(options);

            if (document.getElementById('ContentPlaceHolder1_txtFirstNameH') != null) { control.makeTransliteratable(['<%= txtFirstNameH.ClientID %>']); }
            if (document.getElementById('ContentPlaceHolder1_txtLastNameH') != null) { control.makeTransliteratable(['<%= txtLastNameH.ClientID %>']); }
            if (document.getElementById('ContentPlaceHolder1_txtFnameH') != null) { control.makeTransliteratable(['<%= txtFnameH.ClientID %>']); }

        }
        google.setOnLoadCallback(onLoad);

    </script>



    <script type="text/javascript">

        function CompareDate(DateValue) {

            if (document.getElementById(DateValue.id).value != '') {
                var InputDate = DateValue.value;

                var EnteredDate = InputDate;
                var date = EnteredDate.substring(0, 2);
                var month = EnteredDate.substring(3, 5);
                var year = EnteredDate.substring(6, 10);
                var myDate = new Date(year, month - 1, date);
                var today = new Date();

                if (myDate > today) {
                    alert("Select date is not greater than today date");
                    document.getElementById(DateValue.id).value = '';
                    $('#ContentPlaceHolder1_lblMsg').addClass('alertMsg failed');
                    $('#ContentPlaceHolder1_lblMsg').html('Select date is not greater than today date');
                    $('#ContentPlaceHolder1_lblMsg').show();
                    document.getElementById(DateValue.id).style.borderColor = "red";
                    return false;
                }
                else {
                    document.getElementById(DateValue.id).style.borderColor = "lightgray";
                    $('#ContentPlaceHolder1_lblMsg').hide();
                }
            }
        }

        $(document).ready(function () {
           // FunJoiningDate();
            BasicChange();
            //  CompareDate(DateValue);

            $('.panel-collapse').each(function () {
                if ($(this).hasClass('in')) {
                    $(this).parent('.panel').find('.panel-heading').removeClass('collapsed');
                }
            })
        });

        function Validationgrid() {
            if ($('#ContentPlaceHolder1_txtName_Nom').val() == '') {
                $('#ContentPlaceHolder1_lblMsg').addClass('alertMsg failed');
                $('#ContentPlaceHolder1_lblMsg').html('Please Enter Nominee Name ');
                $('#ContentPlaceHolder1_lblMsg').show();
                $('#ContentPlaceHolder1_txtName_Nom').css('border-color', 'red');
                $('#ContentPlaceHolder1_txtName_Nom').focus();
                return false;
            }

            else {
                $('#ContentPlaceHolder1_txtName_Nom').css('border-color', 'lightgray');
            }

            if ($('#ContentPlaceHolder1_ddlRelation_Nom').val() == '0') {
                $('#ContentPlaceHolder1_lblMsg').addClass('alertMsg failed');
                $('#ContentPlaceHolder1_lblMsg').html(' Please Select Nominee Relation ');
                $('#ContentPlaceHolder1_lblMsg').show();
                $('#ContentPlaceHolder1_ddlRelation_Nom').css('border-color', 'red');
                $('#ContentPlaceHolder1_ddlRelation_Nom').focus();
                return false;
            }

            else {
                $('#ContentPlaceHolder1_ddlRelation_Nom').css('border-color', 'lightgray');
            }
            if ($('#ContentPlaceHolder1_txtPercentage_Nom').val() == '') {
                $('#ContentPlaceHolder1_lblMsg').addClass('alertMsg failed');
                $('#ContentPlaceHolder1_lblMsg').html('Please Select Nominee Percentage');
                $('#ContentPlaceHolder1_lblMsg').show();
                $('#ContentPlaceHolder1_txtPercentage_Nom').css('border-color', 'red');
                $('#ContentPlaceHolder1_txtPercentage_Nom').focus();
                return false;
            }

            else {
                $('#ContentPlaceHolder1_txtPercentage_Nom').css('border-color', 'lightgray');
            }
        }
        function Validation() {


            if ($('#ContentPlaceHolder1_ddlEmpType').val() == '0') {
                $('#ContentPlaceHolder1_lblMsg').addClass('alertMsg failed');
                $('#ContentPlaceHolder1_lblMsg').html(' Please Select Employee Type ');
                $('#ContentPlaceHolder1_lblMsg').show();
                $('#ContentPlaceHolder1_ddlEmpType').css('border-color', 'red');
                $('#ContentPlaceHolder1_ddlEmpType').focus();
                return false;
            }

            else {
                $('#ContentPlaceHolder1_ddlEmpType').css('border-color', 'lightgray');
            }

            if ($('#ContentPlaceHolder1_ddlEmpCtg').val() == '0') {
                $('#ContentPlaceHolder1_lblMsg').addClass('alertMsg failed');
                $('#ContentPlaceHolder1_lblMsg').html(' Please Select Employee Category ');
                $('#ContentPlaceHolder1_lblMsg').show();
                $('#ContentPlaceHolder1_ddlEmpCtg').css('border-color', 'red');
                $('#ContentPlaceHolder1_ddlEmpCtg').focus();
                return false;
            }

            else {
                $('#ContentPlaceHolder1_ddlEmpCtg').css('border-color', 'lightgray');
            }


            if ($('#ContentPlaceHolder1_ddlSubSection').val() == '0') {
                $('#ContentPlaceHolder1_lblMsg').addClass('alertMsg failed');
                $('#ContentPlaceHolder1_lblMsg').html(' Please Select Employee Sub Section ');
                $('#ContentPlaceHolder1_lblMsg').show();
                $('#ContentPlaceHolder1_ddlSubSection').css('border-color', 'red');
                $('#ContentPlaceHolder1_ddlSubSection').focus();
                return false;
            }

            else {
                $('#ContentPlaceHolder1_ddlSubSection').css('border-color', 'lightgray');
            }




            if ($('#ContentPlaceHolder1_ddlDeputation').val() == '0') {
                $('#ContentPlaceHolder1_lblMsg').addClass('alertMsg failed');
                $('#ContentPlaceHolder1_lblMsg').html(' Please Select Deputation ');
                $('#ContentPlaceHolder1_lblMsg').show();
                $('#ContentPlaceHolder1_ddlDeputation').css('border-color', 'red');
                $('#ContentPlaceHolder1_ddlDeputation').focus();
                return false;
            }

            else {
                $('#ContentPlaceHolder1_ddlDeputation').css('border-color', 'lightgray');
            }


            if ($('#ContentPlaceHolder1_ddlDeputation').val() == '1') {
                if ($('#ContentPlaceHolder1_txtDepuDate').val() == '') {
                    $('#ContentPlaceHolder1_lblMsg').addClass('alertMsg failed');
                    $('#ContentPlaceHolder1_lblMsg').html(' Please Select Deputation Date');
                    $('#ContentPlaceHolder1_lblMsg').show();
                    $('#ContentPlaceHolder1_txtDepuDate').css('border-color', 'red');
                    $('#ContentPlaceHolder1_txtDepuDate').focus();
                    return false;
                }
                else {
                    $('#ContentPlaceHolder1_txtDepuDate').css('border-color', 'lightgray');
                }
                if ($('#ContentPlaceHolder1_txtDepuPlace').val() == '') {
                    $('#ContentPlaceHolder1_lblMsg').addClass('alertMsg failed');
                    $('#ContentPlaceHolder1_lblMsg').html(' Please Select Deputation Place ');
                    $('#ContentPlaceHolder1_lblMsg').show();
                    $('#ContentPlaceHolder1_txtDepuPlace').css('border-color', 'red');
                    $('#ContentPlaceHolder1_txtDepuPlace').focus();
                    return false;
                }
                else {
                    $('#ContentPlaceHolder1_txtDepuPlace').css('border-color', 'lightgray');
                }
            }

            if ($('#ContentPlaceHolder1_ddlDesignation').val() == '0') {
                $('#ContentPlaceHolder1_lblMsg').html(' Please Select Designation ');
                $('#ContentPlaceHolder1_lblMsg').addClass('alertMsg failed');
                $('#ContentPlaceHolder1_lblMsg').show();
                $('#ContentPlaceHolder1_ddlDesignation').css('border-color', 'red');
                $('#ContentPlaceHolder1_ddlDesignation').focus();
                return false;
            }

            else {
                $('#ContentPlaceHolder1_ddlDesignation').css('border-color', 'lightgray');
            }

            if ($('#ContentPlaceHolder1_ddlTitalE').val() == '0') {
                $('#ContentPlaceHolder1_lblMsg').html(' Please Select Tital');
                $('#ContentPlaceHolder1_lblMsg').addClass('alertMsg failed');
                $('#ContentPlaceHolder1_lblMsg').show();
                $('#ContentPlaceHolder1_ddlTitalE').css('border-color', 'red');
                $('#ContentPlaceHolder1_ddlTitalE').focus();
                return false;
            }
            else {
                $('#ContentPlaceHolder1_ddlTitalE').css('border-color', 'lightgray');
            }

            if ($('#ContentPlaceHolder1_txtFirstName').val() == '') {
                $('#ContentPlaceHolder1_lblMsg').html(' Please Enter First Name ');
                $('#ContentPlaceHolder1_lblMsg').addClass('alertMsg failed');
                $('#ContentPlaceHolder1_lblMsg').show();
                $('#ContentPlaceHolder1_txtFirstName').css('border-color', 'red');
                $('#ContentPlaceHolder1_txtFirstName').focus();
                return false;
            }
            else {
                $('#ContentPlaceHolder1_txtFirstName').css('border-color', 'lightgray');
            }

            //if ($('#ContentPlaceHolder1_txtLastName').val() == '') {
            //    $('#ContentPlaceHolder1_lblMsg').html(' Please Enter Last Name ');
            //    $('#ContentPlaceHolder1_lblMsg').show();
            //    $('#ContentPlaceHolder1_txtLastName').css('border-color', 'red');
            //    $('#ContentPlaceHolder1_txtLastName').focus();
            //    return false;
            //}
            //else {
            //    $('#ContentPlaceHolder1_txtLastName').css('border-color', 'lightgray');
            //}

            if ($('#ContentPlaceHolder1_txtFname').val() == '') {
                $('#ContentPlaceHolder1_lblMsg').html(' Please Enter Father Name ');
                $('#ContentPlaceHolder1_lblMsg').addClass('alertMsg failed');
                $('#ContentPlaceHolder1_lblMsg').show();
                $('#ContentPlaceHolder1_txtFname').css('border-color', 'red');
                $('#ContentPlaceHolder1_txtFname').focus();
                return false;
            }
            else {
                $('#ContentPlaceHolder1_txtFname').css('border-color', 'lightgray');
            }


            if ($('#ContentPlaceHolder1_ddlGender').val() == '0') {
                $('#ContentPlaceHolder1_lblMsg').html(' Please Select Gender ');
                $('#ContentPlaceHolder1_lblMsg').addClass('alertMsg failed');
                $('#ContentPlaceHolder1_lblMsg').show();
                $('#ContentPlaceHolder1_ddlGender').css('border-color', 'red');
                $('#ContentPlaceHolder1_ddlGender').focus();
                return false;
            }
            else {
                $('#ContentPlaceHolder1_ddlGender').css('border-color', 'lightgray');
            }

            if ($('#ContentPlaceHolder1_ddlCastCtg').val() == '0') {
                $('#ContentPlaceHolder1_lblMsg').html(' Please Select Category');
                $('#ContentPlaceHolder1_lblMsg').addClass('alertMsg failed');
                $('#ContentPlaceHolder1_lblMsg').show();
                $('#ContentPlaceHolder1_ddlCastCtg').css('border-color', 'red');
                $('#ContentPlaceHolder1_ddlCastCtg').focus();
                return false;
            }
            else {
                $('#ContentPlaceHolder1_ddlCastCtg').css('border-color', 'lightgray');
            }

            //if ($('#ContentPlaceHolder1_ddlQualification').val() == '0') {
            //    $('#ContentPlaceHolder1_lblMsg').html(' Please Select Qualification ');
            //    $('#ContentPlaceHolder1_lblMsg').addClass('alertMsg failed');
            //    $('#ContentPlaceHolder1_lblMsg').show();
            //    $('#ContentPlaceHolder1_ddlQualification').css('border-color', 'red');
            //    $('#ContentPlaceHolder1_ddlQualification').focus();
            //    return false;
            //}
            //else {
            //    $('#ContentPlaceHolder1_ddlQualification').css('border-color', 'lightgray');
            //}

            //if ($('#ContentPlaceHolder1_ddlBloodGroup').val() == '0') {
            //    $('#ContentPlaceHolder1_lblMsg').html(' Please Select Blood Group ');
            //    $('#ContentPlaceHolder1_lblMsg').addClass('alertMsg failed');
            //    $('#ContentPlaceHolder1_lblMsg').show();
            //    $('#ContentPlaceHolder1_ddlBloodGroup').css('border-color', 'red');
            //    $('#ContentPlaceHolder1_ddlBloodGroup').focus();
            //    return false;
            //}
            //else {
            //    $('#ContentPlaceHolder1_ddlBloodGroup').css('border-color', 'lightgray');
            //}

            if ($('#ContentPlaceHolder1_ddlMaritalStatus').val() == '1') {
                if ($('#ContentPlaceHolder1_ddlFamilyPlaning').val() == '0') {
                    $('#ContentPlaceHolder1_lblMsg').html(' Please Select Family Planing If Select Yes ');
                    $('#ContentPlaceHolder1_lblMsg').addClass('alertMsg failed');
                    $('#ContentPlaceHolder1_lblMsg').show();
                    $('#ContentPlaceHolder1_ddlFamilyPlaning').css('border-color', 'red');
                    $('#ContentPlaceHolder1_ddlFamilyPlaning').focus();
                    return false;
                }
                else {
                    $('#ContentPlaceHolder1_ddlFamilyPlaning').css('border-color', 'lightgray');
                }
            }


            if ($('#ContentPlaceHolder1_ddlHandicapped').val() == '000') {
                $('#ContentPlaceHolder1_lblMsg').html(' Please Select Handicapped Yes/No ');
                $('#ContentPlaceHolder1_lblMsg').addClass('alertMsg failed');
                $('#ContentPlaceHolder1_lblMsg').show();
                $('#ContentPlaceHolder1_ddlHandicapped').css('border-color', 'red');
                $('#ContentPlaceHolder1_ddlHandicapped').focus();
                return false;
            }
            else {
                $('#ContentPlaceHolder1_ddlHandicapped').css('border-color', 'lightgray');
            }

            if ($('#ContentPlaceHolder1_ddlHandicapped').val() == '1') {
                if ($('#ContentPlaceHolder1_txtHandPercentage').val() == '') {
                    $('#ContentPlaceHolder1_lblMsg').html(' Please Select Percentage ');
                    $('#ContentPlaceHolder1_lblMsg').addClass('alertMsg failed');
                    $('#ContentPlaceHolder1_lblMsg').show();
                    $('#ContentPlaceHolder1_txtHandPercentage').css('border-color', 'red');
                    $('#ContentPlaceHolder1_txtHandPercentage').focus();
                    return false;
                }
            }
            else {
                $('#ContentPlaceHolder1_txtHandPercentage').css('border-color', 'lightgray');
            }


            if ($('#ContentPlaceHolder1_ddlGrade').val() == '000') {
                $('#ContentPlaceHolder1_lblMsg').html(' Please Select Grade ');
                $('#ContentPlaceHolder1_other_info').addClass('panel-collapse collapse in');
                $('#ContentPlaceHolder1_other_infoHead').removeClass('collapsed');
                $('#ContentPlaceHolder1_lblMsg').addClass('alertMsg failed');
                $('#ContentPlaceHolder1_lblMsg').show();
                $('#ContentPlaceHolder1_ddlGrade').css('border-color', 'red');
                $('#ContentPlaceHolder1_ddlGrade').focus();
                return false;
            }
            else {
                $('#ContentPlaceHolder1_ddlGrade').css('border-color', 'lightgray');
            }

            if ($('#ContentPlaceHolder1_txtBasic').val() == '') {
                $('#ContentPlaceHolder1_lblMsg').html(' Please Enter Basic ');
                $('#ContentPlaceHolder1_other_info').addClass('panel-collapse collapse in');
                $('#ContentPlaceHolder1_other_infoHead').removeClass('collapsed');
                $('#ContentPlaceHolder1_lblMsg').addClass('alertMsg failed');
                $('#ContentPlaceHolder1_lblMsg').show();
                $('#ContentPlaceHolder1_txtBasic').css('border-color', 'red');
                $('#ContentPlaceHolder1_txtBasic').focus();
                return false;
            }
            else {
                $('#ContentPlaceHolder1_txtBasic').css('border-color', 'lightgray');
            }

            if ($('#ContentPlaceHolder1_txtBirthDate').val() == '') {
                $('#ContentPlaceHolder1_lblMsg').html(' Please Enter Date Of Birth ');
                $('#ContentPlaceHolder1_other_info').addClass('panel-collapse collapse in');
                $('#ContentPlaceHolder1_other_infoHead').removeClass('collapsed');
                $('#ContentPlaceHolder1_lblMsg').addClass('alertMsg failed');
                $('#ContentPlaceHolder1_lblMsg').show();
                $('#ContentPlaceHolder1_txtBirthDate').css('border-color', 'red');
                $('#ContentPlaceHolder1_txtBirthDate').focus();
                return false;
            }
            else {
                $('#ContentPlaceHolder1_txtBirthDate').css('border-color', 'lightgray');
            }

            if ($('#ContentPlaceHolder1_txtJoiningDate').val() == '') {
                $('#ContentPlaceHolder1_lblMsg').html(' Please Enter Joining Date ');
                $('#ContentPlaceHolder1_other_info').addClass('panel-collapse collapse in');
                $('#ContentPlaceHolder1_other_infoHead').removeClass('collapsed');
                $('#ContentPlaceHolder1_lblMsg').addClass('alertMsg failed');
                $('#ContentPlaceHolder1_lblMsg').show();
                $('#ContentPlaceHolder1_txtJoiningDate').css('border-color', 'red');
                $('#ContentPlaceHolder1_txtJoiningDate').focus();
                return false;
            }
            else {
                $('#ContentPlaceHolder1_txtJoiningDate').css('border-color', 'lightgray');
            }
        }

        //function FunJoiningDate() {

        //   
        //    if ($('#ContentPlaceHolder1_txtJoiningDate').val() != "") {
        //        var InputDate = $('#ContentPlaceHolder1_txtJoiningDate').val();

        //        var EnteredDate = InputDate;
        //        var date = EnteredDate.substring(0, 2);
        //        var month = EnteredDate.substring(3, 5);
        //        var year = EnteredDate.substring(6, 10);
        //        var myDate = new Date(year, month - 1, date);
        //        var today = new Date();

        //        if (myDate > today) {
        //            $('#ContentPlaceHolder1_lblMsg').html('Select date is not greater than today date ');
        //            $('#ContentPlaceHolder1_other_info').addClass('panel-collapse collapse in');
        //            $('#ContentPlaceHolder1_other_infoHead').removeClass('collapsed');
        //            $('#ContentPlaceHolder1_lblMsg').addClass('alertMsg failed');
        //            $('#ContentPlaceHolder1_lblMsg').show();
        //            $('#ContentPlaceHolder1_txtJoiningDate').css('border-color', 'red');
        //            $('#ContentPlaceHolder1_txtJoiningDate').focus();
        //            return false;
        //        }
        //        else {
        //            $('#ContentPlaceHolder1_txtJoiningDate').css('border-color', 'lightgray');
        //        }
        //    }

        //    if (($('#ContentPlaceHolder1_txtJoiningDate').val() != "") && ($('#ContentPlaceHolder1_txtBirthDate').val() != "")) {
        //        var BirthDate1 = $('#ContentPlaceHolder1_txtBirthDate').val();
        //        var JoiningDate1 = $('#ContentPlaceHolder1_txtJoiningDate').val();

        //        date1 = new Date(BirthDate1);
        //        date2 = new Date(JoiningDate1);

        //        var BirthYear = BirthDate1.substring(6, 10);
        //        var JoininYear = JoiningDate1.substring(6, 10);

        //        if (date2 < date1) {
        //            alert('Joining Date sholud not be less than birthdate');
        //            $('#ContentPlaceHolder1_lblMsg').html(' Joining Date sholud not be less than birthdate ');
        //            $('#ContentPlaceHolder1_lblMsg').addClass('alertMsg failed');
        //            $('#ContentPlaceHolder1_lblMsg').show();
        //            $('#ContentPlaceHolder1_txtJoiningDate').val('');
        //            $('#ContentPlaceHolder1_txtJoiningDate').focus();
        //            $('#ContentPlaceHolder1_txtJoiningDate').css('border-color', 'red');
        //            return false;
        //        }
        //        else if (JoininYear - BirthYear < 18) {

        //            alert('You are not eligible your age should have above 18 year');
        //            $('#ContentPlaceHolder1_lblMsg').html(' You are not eligible your age should have above 18 year ');
        //            $('#ContentPlaceHolder1_lblMsg').addClass('alertMsg failed');
        //            $('#ContentPlaceHolder1_lblMsg').show();

        //            $('#ContentPlaceHolder1_txtJoiningDate').val('');
        //            $('#ContentPlaceHolder1_txtJoiningDate').focus();
        //            $('#ContentPlaceHolder1_txtJoiningDate').css('border-color', 'red');
        //            return false;
        //        }
        //        else {
        //            $('#ContentPlaceHolder1_txtJoiningDate').css('border-color', 'lightgray');
        //            $('#ContentPlaceHolder1_txtJoiningDate').focus();
        //        }
        //    }
        //    return true;

        //    //if (($('#ContentPlaceHolder1_txtJoiningDate').val() != "") && ($('#ContentPlaceHolder1_lblClassDesc').html() != "") && ($('#ContentPlaceHolder1_txtBirthDate').val() != "")) {
        //    //    var JoiningDate = $('#ContentPlaceHolder1_txtBirthDate').val();
        //    //    var RetirmentYear = JoiningDate.substring(6, 10);

        //    //    var a = $('#ContentPlaceHolder1_txtJoiningDate').val();
        //    //    var RetirmentDateMonth = a.substring(0, 6);


        //    //    var RetirmentYearClass = $('#ContentPlaceHolder1_hfRetirmentYear').val();
        //    //    var TotalRetirmentYear = parseInt(RetirmentYear) + parseInt(RetirmentYearClass);

        //    //    $('#ContentPlaceHolder1_lblRetirmentDate').val(RetirmentDateMonth + TotalRetirmentYear);
        //    //}
        //    //else {
        //    //    $('#ContentPlaceHolder1_lblRetirmentDate').val('')
        //    //}
        //}

        function BasicChange() {
            if ($('#ContentPlaceHolder1_ddlEmpCtg').val() == "5") {

                if ($('#ContentPlaceHolder1_ddlGrade').val() == "") {
                    $('#ContentPlaceHolder1_lblMsg').hide();
                }
                else {
                    $('#ContentPlaceHolder1_lblMsg').show();
                }
                $('#ContentPlaceHolder1_ddlGrade').css('border-color', 'lightgray');

                if ($('#ContentPlaceHolder1_ddlGrade').val() != "000") {
                    var txtBasicValue = $('#ContentPlaceHolder1_txtBasic').val();
                    var ddlGradeValue = $('#ContentPlaceHolder1_ddlGrade').find('option:selected').text();

                    var MaxSalry = ddlGradeValue.split('-')[1].split('-')[0];
                    var MinSalry = ddlGradeValue.split('-')[0].split('-')[0];

                    if ((parseInt(txtBasicValue) > parseInt(MaxSalry))) {
                        //alert('Basic salary can not Exceed grade limit')
                        $('#ContentPlaceHolder1_lblMsg').html('Basic salary can not Exceed grade limit');
                        $('#ContentPlaceHolder1_lblMsg').addClass('alertMsg failed');
                        $('#ContentPlaceHolder1_lblMsg').show();

                        $('#ContentPlaceHolder1_txtBasic').css('border-color', 'red');

                        $('#ContentPlaceHolder1_txtBasic').val('');
                        $('#ContentPlaceHolder1_txtBasic').focus();
                        return false;
                    }
                    else if ((parseInt(txtBasicValue) < parseInt(MinSalry))) {
                        // alert('Basic salary can not be lesss than minimum limit of grade')
                        $('#ContentPlaceHolder1_lblMsg').html(' Basic salary can not be lesss than minimum limit of grade ');
                        $('#ContentPlaceHolder1_lblMsg').addClass('alertMsg failed');
                        $('#ContentPlaceHolder1_lblMsg').show();

                        $('#ContentPlaceHolder1_txtBasic').css('border-color', 'red');
                        $('#ContentPlaceHolder1_txtBasic').val('');
                        $('#ContentPlaceHolder1_txtBasic').focus();
                        return false;
                    }
                    else {
                        $('#ContentPlaceHolder1_txtBasic').css('border-color', 'lightgray');
                    }
                }
            }
        }

    </script>

    <style>
        .name-title-picker {
            border-top-right-radius: 0px;
            border-bottom-right-radius: 0px;
            width: 20%;
            float: left;
            padding: 0;
            font-size: 11px;
        }

        .name-textbox {
            margin-left: -1px;
            border-top-left-radius: 0px;
            border-bottom-left-radius: 0px;
            width: 80%;
            float: left;
        }

        .chk_inpt input {
            margin-right: 5px;
        }

        .chk_inpt label {
            margin-left: 5px;
        }

        hr {
            margin: 10px 0px 10px 0px;
        }

        .second_heading {
            font-size: 30px;
            font-weight: normal !important;
        }

        .brdr_box {
            border: 1px solid #888787;
            padding: 10px;
            position: relative;
            margin-bottom: 20px;
        }

        .fix2brdr_box {
            top: -31px;
            background: #fff;
            position: absolute;
            padding: 0px 5px 0px 5px;
        }

        .Star {
            color: red;
        }

        .mrgntp10 {
            margin-top: 20px;
        }

        .panel-heading {
            text-align: center;
            font-weight: bold;
            font-size: 14px;
            color: #fff !important;
        }

        .panel-body {
            padding: 8px;
        }

        .popover {
            position: absolute;
        }

        .hdclr {
            color: #fff;
        }

        .acrdn_pnl .form-group {
            margin-bottom: 5px !important;
        }

        .acrdn_pnl .label {
            margin-bottom: 0px !important;
        }

        .acrdn_pnl .panel-default {
            border: none !important;
        }

        .acrdn_pnl .panel-heading {
            text-align: left;
            background-color: #3c8dbc;
            height: 25px;
            line-height: 5px;
            margin-bottom: 5px;
        }


            .acrdn_pnl .panel-heading a:focus, a:hover {
                color: #fafafa;
                text-decoration: none;
            }

        .ar {
            margin-right: 15px;
        }

        .panel-group .panel + .panel {
            margin-top: 4px;
        }

        .fa {
            font-size: 12px;
        }

        .panel {
            font-size: 12px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="updatepnl">
        <ProgressTemplate>
            <div class="loading active"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>

    <asp:UpdatePanel ID="updatepnl" runat="server">
        <ContentTemplate>
            <script>
                Sys.Application.add_load(LoadAllScript);
            </script>
            <div class="col-xs-12 mrgntp10">
                <div class="panel panel-primary form-horizontal">
                    <div class="panel-heading">Employee Master</div>
                    <div class="panel-body">

                        <div class="panel-group acrdn_pnl" id="accordion">
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <a class="panel-title hdclr">General Information</a>
                                </div>
                                <div id="generalinfo">
                                    <div class="row">
                                        <div class="col-sm-3 col-xs-12">
                                            <div class="form-group">
                                                <label class="col-sm-12 col-xs-12">Employee Type</label>
                                                <div class="col-sm-12">
                                                    <asp:DropDownList runat="server" CssClass="form-control form-control-xs" ID="ddlEmpType"></asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-sm-3 col-xs-12">
                                            <div class="form-group">
                                                <label class="col-sm-12 col-xs-12">Employee Category</label>
                                                <div class="col-sm-12">
                                                    <asp:DropDownList runat="server" CssClass="form-control form-control-xs" ID="ddlEmpCtg" OnSelectedIndexChanged="ddlEmpCtg_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-3 col-xs-12">
                                            <div class="form-group">
                                                <label class="col-sm-12 col-xs-12">Sub Section</label>
                                                <div class="col-sm-12">
                                                    <asp:DropDownList runat="server" CssClass="form-control form-control-xs" ID="ddlSubSection" OnSelectedIndexChanged="ddlSubSection_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-sm-3 col-xs-12">
                                            <div class="form-group">
                                                <label class="col-sm-12 col-xs-12">Section</label>
                                                <div class="col-sm-12">
                                                    <asp:Label runat="server" CssClass="form-control form-control-xs" BackColor="#eeeeee" ID="lblSection" />
                                                    <asp:HiddenField ID="hfSectionId" runat="server" />
                                                </div>
                                            </div>
                                        </div>

                                    </div>

                                    <div class="row">

                                        <div class="col-sm-3 col-xs-12">
                                            <style>
                                                .d3466 .form-control:first-child {
                                                    width: 34%;
                                                }

                                                .d3466 .form-control:last-child {
                                                    width: 66% !important;
                                                    padding-left: 5px;
                                                }

                                                .width66 {
                                                    width: 66% !important;
                                                    padding-left: 5px;
                                                }

                                                .d3466 label:first-child {
                                                    width: 34%;
                                                }

                                                .d3466 label:last-child {
                                                    width: 66%;
                                                    padding-left: 5px;
                                                }

                                                .fix2brdr_box {
                                                    color: #3c8dbc;
                                                }
                                            </style>
                                            <div class="form-group  two-form-control d3466">
                                                <label class="col-xs-6">Deputation<i class="Star">*</i></label>
                                                <label class="col-xs-6">Date</label>
                                                <div class="col-sm-12">
                                                    <asp:DropDownList runat="server" CssClass="form-control form-control-xs" ID="ddlDeputation" OnTextChanged="ddlDeputation_TextChanged" AutoPostBack="true">
                                                        <asp:ListItem Value="0" Text="Select" />
                                                        <asp:ListItem Value="1" Text="Yes" />
                                                        <asp:ListItem Value="2" Text="No" />
                                                    </asp:DropDownList>
                                                    <asp:TextBox runat="server" CssClass="datepicker form-control form-control-xs width66" MaxLength="10" placeholder="DD/MM/YYYY" Enabled="false" ID="txtDepuDate" onchange="return CompareDate(this);" />
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-sm-3 col-xs-12">
                                            <div class="form-group">
                                                <label class="col-sm-12 col-xs-12">Deputation Place</label>
                                                <div class="col-sm-12">
                                                    <asp:TextBox runat="server" CssClass="form-control form-control-xs" MaxLength="100" Enabled="false" placeholder="Enter Deputation Place" ID="txtDepuPlace" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-3 col-xs-12">
                                            <div class="form-group">
                                                <label class="col-sm-12 col-xs-12">Designation<i class="Star"> *</i></label>
                                                <div class="col-sm-12">
                                                    <asp:DropDownList runat="server" CssClass="form-control form-control-xs" ID="ddlDesignation" OnSelectedIndexChanged="ddlDesignation_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-3 col-xs-12">
                                            <div class="row">
                                                <div class="col-sm-6">
                                                    <div class="form-group">
                                                        <label class="col-sm-12 col-xs-12">Class Desc</label>
                                                        <div class="col-sm-12">
                                                            <asp:Label Text="" CssClass="form-control" BackColor="#eeeeee" runat="server" ID="lblClassDesc" />
                                                            <asp:HiddenField ID="hflblClassId" runat="server" />
                                                            <asp:HiddenField ID="hfRetirmentYear" runat="server" />
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-sm-6">
                                                    <div class="form-group">
                                                        <label class="col-sm-12 col-xs-12">Fix Payee</label>
                                                        <div class="col-sm-12">
                                                            <asp:RadioButtonList runat="server" RepeatDirection="Horizontal" ID="rbFixPayee" OnSelectedIndexChanged="rbFixPayee_SelectedIndexChanged" AutoPostBack="true">
                                                                <asp:ListItem Value="0" Text="No" Selected="True" />
                                                                <asp:ListItem Value="1" Text="Yes" />
                                                            </asp:RadioButtonList>

                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>

                                    </div>
                                </div>
                            </div>

                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <a class="panel-title hdclr">Personal Information</a>
                                </div>
                                <div id="persnolinfo">
                                    <div class="row">
                                        <div class="col-sm-3 col-xs-12">
                                            <div class="form-group">
                                                <label class="col-sm-12 col-xs-12">First Name<i class="Star"> *</i></label>
                                                <div class="col-sm-12">

                                                    <asp:DropDownList runat="server" CssClass="form-control form-control-xs name-title-picker" ID="ddlTitalE" OnSelectedIndexChanged="ddlTitalE_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                                    <asp:TextBox runat="server" placeholder="Enter First Name" MaxLength="50" CssClass="form-control form-control-xs name-textbox text-uppercase" ID="txtFirstName" />
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-sm-3 col-xs-12">
                                            <div class="form-group">
                                                <label class="col-sm-12 col-xs-12">First Name In Hindi<i class="Star"> </i></label>
                                                <div class="col-sm-12">
                                                    <asp:DropDownList runat="server" CssClass="form-control form-control-xs name-title-picker" ID="ddlTitalH" OnSelectedIndexChanged="ddlTitalH_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                                    <asp:TextBox runat="server" placeholder="Enter First Name In Hindi" MaxLength="500" CssClass="form-control form-control-xs name-textbox" ID="txtFirstNameH" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-3 col-xs-12">
                                            <div class="form-group">
                                                <label class="col-sm-12 col-xs-12">Last Name<i class="Star"> *</i></label>
                                                <div class="col-sm-12">
                                                    <asp:TextBox runat="server" placeholder="Enter Last Name" MaxLength="35" CssClass="form-control form-control-xs text-uppercase" ID="txtLastName" />
                                                </div>
                                            </div>
                                        </div>


                                        <div class="col-sm-3 col-xs-12">
                                            <div class="form-group">
                                                <label class="col-sm-12 col-xs-12">Last Name In Hindi<i class="Star"> </i></label>
                                                <div class="col-sm-12">
                                                    <asp:TextBox runat="server" placeholder="Enter Last Name In Hindi" MaxLength="500" CssClass="form-control form-control-xs" ID="txtLastNameH" />
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-sm-3 col-xs-12">
                                            <div class="form-group">
                                                <label class="col-sm-12 col-xs-12">Fathers Name<i class="Star"> *</i></label>
                                                <div class="col-sm-12">
                                                    <asp:TextBox runat="server" placeholder="Enter Father Name" MaxLength="50" CssClass="form-control form-control-xs text-uppercase" ID="txtFname" />
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-sm-3 col-xs-12">
                                            <div class="form-group">
                                                <label class="col-sm-12 col-xs-12">Fathers Name In Hindi<i class="Star"> </i></label>
                                                <div class="col-sm-12">
                                                    <asp:TextBox runat="server" placeholder="Enter Father Name  In Hindi" MaxLength="500" CssClass="form-control form-control-xs" ID="txtFnameH" />
                                                </div>
                                            </div>
                                        </div>


                                        <div class="col-sm-3 col-xs-12">


                                            <div class="row">
                                                <div class="col-sm-6">
                                                    <div class="form-group">
                                                        <label class="col-sm-12 col-xs-12">Gender<i class="Star"> *</i></label>
                                                        <div class="col-sm-12 col-xs-12">
                                                            <asp:DropDownList runat="server" CssClass="form-control form-control-xs" ID="ddlGender">
                                                                <asp:ListItem Value="0" Text="-- Select --" />
                                                                <asp:ListItem Value="1" Text="Male" />
                                                                <asp:ListItem Value="2" Text="Female" />
                                                            </asp:DropDownList>
                                                        </div>

                                                    </div>
                                                </div>
                                                <div class="col-sm-6">
                                                    <div class="form-group">
                                                        <label class="col-sm-12 col-xs-12">Category<i class="Star"> *</i></label>
                                                        <div class="col-sm-12">
                                                            <asp:DropDownList runat="server" CssClass="form-control form-control-xs" ID="ddlCastCtg"></asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>





                                        </div>
                                        <div class="col-sm-3 col-xs-12">

                                            <div class="row">
                                                <div class="col-sm-7">
                                                    <div class="form-group">
                                                        <label class="col-sm-12 col-xs-12">Qualification<i class="Star"> </i></label>
                                                        <div class="col-sm-12">
                                                            <asp:DropDownList runat="server" CssClass="form-control form-control-xs" ID="ddlQualification"></asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-sm-5">
                                                    <div class="form-group">
                                                        <label class="col-sm-12 col-xs-12">Blood Group<i class="Star"> </i></label>
                                                        <div class="col-sm-12">
                                                            <asp:DropDownList runat="server" CssClass="form-control form-control-xs" ID="ddlBloodGroup">
                                                                <asp:ListItem Value="--Select--">--Select--</asp:ListItem>
                                                                <asp:ListItem Value="A+">A+</asp:ListItem>
                                                                <asp:ListItem Value="A-">A-</asp:ListItem>
                                                                <asp:ListItem Value="B+">B+</asp:ListItem>
                                                                <asp:ListItem Value="B-">B-</asp:ListItem>
                                                                <asp:ListItem Value="O+">O+</asp:ListItem>
                                                                <asp:ListItem Value="O-">O-</asp:ListItem>
                                                                <asp:ListItem Value="AB+">AB+</asp:ListItem>
                                                                <asp:ListItem Value="AB-">AB-</asp:ListItem>
                                                                <asp:ListItem Value="OTHER">OTHER</asp:ListItem>

                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-sm-3 col-xs-12">

                                            <div class="row">
                                                <div class="col-sm-6">
                                                    <div class="form-group">
                                                        <label class="col-sm-12 col-xs-12">Aadhaar No.</label>
                                                        <div class="col-sm-12 col-xs-12">
                                                            <asp:TextBox runat="server" placeholder="Enter Aadhaar No." MaxLength="12" CssClass="form-control form-control-xs numberonly" ID="txtAadhaarNo" />
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-sm-6">
                                                    <div class="form-group">
                                                        <label class="col-sm-12 col-xs-12">Voter ID No.</label>
                                                        <div class="col-sm-12 col-xs-12">
                                                            <asp:TextBox runat="server" placeholder="Enter Voter ID" MaxLength="20" CssClass="form-control form-control-xs alphanum text-uppercase" ID="txtVoterId" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>


                                        </div>


                                        <div class="col-sm-3 col-xs-12">
                                            <div class="row">
                                                <div class="col-sm-6">
                                                    <div class="form-group">
                                                        <label class="col-sm-12 col-xs-12">
                                                            Marital Status
                                                        </label>
                                                        <div class="col-sm-12">
                                                            <asp:DropDownList runat="server" CssClass="form-control form-control-xs" ID="ddlMaritalStatus" OnTextChanged="ddlMaritalStatus_TextChanged" AutoPostBack="true">
                                                                <asp:ListItem Value="000" Text="Select" />
                                                                <asp:ListItem Value="1" Text="Yes" />
                                                                <asp:ListItem Value="0" Text="No" />
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-sm-6">
                                                    <div class="form-group">
                                                        <label class="col-sm-12 col-xs-12">Family Planing</label>
                                                        <div class="col-sm-12">
                                                            <asp:DropDownList runat="server" CssClass="form-control form-control-xs" ID="ddlFamilyPlaning" Enabled="false">
                                                                <asp:ListItem Value="0" Text="Select" />
                                                                <asp:ListItem Value="1" Text="Yes" />
                                                                <asp:ListItem Value="2" Text="No" />
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>


                                        </div>


                                        <div class="col-sm-3 col-xs-12">
                                            <div class="row">
                                                <div class="col-sm-6">
                                                    <div class="form-group">
                                                        <label class="col-sm-12 col-xs-12">Handicapped<i class="Star"> *</i></label>
                                                        <div class="col-sm-12 col-xs-12">
                                                            <asp:DropDownList runat="server" CssClass="form-control form-control-xs" ID="ddlHandicapped" OnTextChanged="ddlHandicapped_TextChanged" AutoPostBack="true">
                                                                <asp:ListItem Value="000" Text="Select" />
                                                                <asp:ListItem Value="1" Text="Yes" />
                                                                <asp:ListItem Value="0" Text="No" />
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-sm-6">
                                                    <div class="form-group">
                                                        <label class="col-sm-12 col-xs-12">Percentage</label>
                                                        <div class="col-sm-12">
                                                            <asp:TextBox runat="server" MaxLength="3" CssClass="form-control form-control-xs numberonly" ID="txtHandPercentage" placeholder="Enter Percentage" Enabled="false" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>


                                        </div>

                                    </div>


                                </div>

                            </div>


                            <div class="panel panel-default">
                                <div id="AddressinfoHead" runat="server" class="panel-heading entryMst-collapse collapsed" data-toggle="collapse" data-parent="#accordion" data-target="#ContentPlaceHolder1_Addressinfo">
                                    <a class="panel-title hdclr"><i class="fa" aria-hidden="true"></i>Address</a>
                                </div>

                                <div id="Addressinfo" runat="server" class="panel-collapse collapse p10">

                                    <div class="row">
                                        <div class="col-sm-3 col-xs-12">
                                            <div class="form-group">
                                                <label class="col-sm-12 col-xs-12">Permanent Address<i class="Star"> </i></label>
                                                <div class="col-sm-12 col-xs-12">
                                                    <asp:TextBox runat="server" MaxLength="500" placeholder="Enter Permanent Address" CssClass="form-control form-control-xs text-uppercase" ID="txtPermanentAdd" />
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-sm-3 col-xs-12">
                                            <div class="form-group">
                                                <label class="col-sm-12 col-xs-12">Place<i class="Star"> </i></label>
                                                <div class="col-sm-12">
                                                    <asp:TextBox runat="server" MaxLength="100" placeholder="Enter Permanent Place" CssClass="form-control form-control-xs text-uppercase" ID="txtPermanentPlace" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-3 col-xs-12">
                                            <div class="form-group">
                                                <label class="col-sm-12 col-xs-12">Mobile Number</label>
                                                <div class="col-sm-12">
                                                    <asp:TextBox runat="server" MaxLength="10" placeholder="Enter Permanent Mobile Number" CssClass="form-control form-control-xs numberonly" ID="txtPermanentMobileNo" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-sm-6 col-xs-12">
                                            <div class="form-group">
                                                <div class="col-sm-12 col-xs-12">
                                                    <asp:CheckBox Text="Please Check (if Permanent Address And Prasent Address Are Same) " OnCheckedChanged="chkPermanentSame_CheckedChanged" AutoPostBack="true" runat="server" ID="chkPermanentSame" />
                                                </div>
                                            </div>
                                        </div>

                                    </div>

                                    <div class="row">
                                        <div class="col-sm-3 col-xs-12">
                                            <div class="form-group">
                                                <label class="col-sm-12 col-xs-12">Present Address<i class="Star"> </i></label>
                                                <div class="col-sm-12 col-xs-12">
                                                    <asp:TextBox runat="server" MaxLength="500" placeholder="Enter Prasent Address" CssClass="form-control form-control-xs text-uppercase" ID="txtPrsentAdd" />
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-sm-3 col-xs-12">
                                            <div class="form-group">
                                                <label class="col-sm-12 col-xs-12">Place<i class="Star"> </i></label>
                                                <div class="col-sm-12">
                                                    <asp:TextBox runat="server" MaxLength="100" placeholder="Enter Prasent Place" CssClass="form-control form-control-xs text-uppercase" ID="txtPrsentPlace" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-3 col-xs-12">
                                            <div class="form-group">
                                                <label class="col-sm-12 col-xs-12">Phone /Mobile Number</label>
                                                <div class="col-sm-12">
                                                    <asp:TextBox runat="server" MaxLength="12" placeholder="Enter Prasent Phone/Mobile No." CssClass="form-control form-control-xs numberonly" ID="txtPrsentMobileNo" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                </div>

                            </div>



                            <div class="panel panel-default">
                                <div id="Bank_infoHead" runat="server" class="panel-heading entryMst-collapse collapsed" data-toggle="collapse" data-parent="#accordion" data-target="#ContentPlaceHolder1_Bank_info">
                                    <a class="panel-title hdclr"><i class="fa" aria-hidden="true"></i>Bank Details (If Any)</a>
                                </div>
                                <div id="Bank_info" runat="server" class="panel-collapse collapse p10">

                                    <div class="row">
                                        <div class="col-sm-3 col-xs-12">
                                            <div class="form-group">
                                                <label class="col-sm-12 col-xs-12">Bank Name</label>
                                                <div class="col-sm-12 col-xs-12">
                                                    <asp:DropDownList runat="server" CssClass="form-control form-control-xs" ID="ddlBank" OnSelectedIndexChanged="ddlBank_SelectedIndexChanged" AutoPostBack="true">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-sm-3 col-xs-12">
                                            <div class="form-group">
                                                <label class="col-sm-12 col-xs-12">Branch</label>
                                                <div class="col-sm-12">
                                                    <asp:DropDownList runat="server" CssClass="form-control form-control-xs" OnSelectedIndexChanged="ddlBranch_SelectedIndexChanged" AutoPostBack="true" ID="ddlBranch" Enabled="false">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-3 col-xs-12">
                                            <div class="form-group">
                                                <label class="col-sm-12 col-xs-12">Bank A/C No.</label>
                                                <div class="col-sm-12">
                                                    <asp:TextBox runat="server" MaxLength="20" placeholder="Enter Bank A/c No." Enabled="false" ID="txtBankAcNo" CssClass="form-control form-control-xs numberonly" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-3 col-xs-12">
                                            <div class="form-group">
                                                <label class="col-sm-12 col-xs-12">IFSC Code</label>
                                                <div class="col-sm-12 col-xs-12">
                                                    <asp:TextBox runat="server" ID="txtIFSCCode" placeholder="Enter IFSC Code" Enabled="false" MaxLength="11" CssClass="form-control form-control-xs text-uppercase" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-sm-3 col-xs-12">
                                            <div class="form-group">
                                                <label class="col-sm-12 col-xs-12">GPF A/C No.</label>
                                                <div class="col-sm-12">
                                                    <asp:TextBox runat="server" placeholder="Enter GPF A/C No." ID="txtGPFAco" MaxLength="20" CssClass="form-control form-control-xs text-uppercase" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-3 col-xs-12">
                                            <div class="form-group">
                                                <label class="col-sm-12 col-xs-12">PAN No.</label>
                                                <div class="col-sm-12">
                                                    <asp:TextBox runat="server" ID="txtPanNo" placeholder="Enter PAN No." MaxLength="10" CssClass="form-control form-control-xs text-uppercase PanNo" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-3 col-xs-12">
                                            <div class="form-group">
                                                <label class="col-sm-12 col-xs-12">ESIC A/C No.</label>
                                                <div class="col-sm-12">
                                                    <asp:TextBox runat="server" placeholder="Enter ESIC A/C No." MaxLength="20" ID="txtESICACNo" CssClass="form-control form-control-xs text-uppercase" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-3 col-xs-12">
                                            <div class="form-group">
                                                <label class="col-sm-12 col-xs-12">UAN No.</label>
                                                <div class="col-sm-12 col-xs-12">
                                                    <asp:TextBox runat="server" placeholder="Enter UAN No." MaxLength="30" ID="txtUANNo" CssClass="form-control form-control-xs text-uppercase" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                </div>
                            </div>

                            <div class="panel panel-default">

                                <div id="other_infoHead" runat="server" class="panel-heading entryMst-collapse collapsed" data-toggle="collapse" data-parent="#accordion" data-target="#ContentPlaceHolder1_other_info">
                                    <a class="panel-title hdclr"><i class="fa" aria-hidden="true"></i>Office Information</a>
                                </div>

                                <div id="other_info" runat="server" class="panel-collapse collapse p10">

                                    <div class="row">
                                        <div class="col-sm-3 col-xs-12">
                                            <div class="form-group">
                                                <label class="col-sm-12 col-xs-12">Grade<i class="Star"> *</i></label>
                                                <div class="col-sm-12 col-xs-12">
                                                    <asp:DropDownList runat="server" CssClass="form-control form-control-xs" ID="ddlGrade">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-sm-3 col-xs-12">
                                            <div class="form-group">
                                                <label class="col-sm-12 col-xs-12">Basic<i class="Star"> *</i></label>
                                                <div class="col-sm-12">
                                                    <asp:TextBox runat="server" ID="txtBasic" onchange="return BasicChange()" MaxLength="10" placeholder="Enter Basic Amount" CssClass="form-control form-control-xs Amount" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-3 col-xs-12">
                                            <div class="form-group">
                                                <label class="col-sm-12 col-xs-12">Birth Date<i class="Star"> *</i></label>
                                                <div class="col-sm-12">
                                                    <asp:TextBox runat="server" ID="txtBirthDate" MaxLength="10" placeholder="DD/MM/YYYY" CssClass="form-control form-control-xs BirthDate" OnTextChanged="txtBirthDate_TextChanged" AutoPostBack="true" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-3 col-xs-12">
                                            <div class="row">
                                                <div class="col-sm-6">
                                                    <div class="form-group">
                                                        <label class="col-sm-12 col-xs-12">Joining Date<i class="Star"> *</i></label>
                                                        <div class="col-sm-12 col-xs-12">
                                                            <asp:TextBox runat="server" ID="txtJoiningDate" placeholder="DD/MM/YYYY"  OnTextChanged="txtJoiningDate_TextChanged" AutoPostBack="true" MaxLength="10" CssClass="form-control form-control-xs datepicker" />

                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-sm-6">
                                                    <label class="col-sm-12 col-xs-12">Retirement&nbsp;Date</label>
                                                    <div class="col-sm-12 col-xs-12">
                                                        <asp:TextBox ID="lblRetirmentDate" runat="server" Enabled="false" CssClass="form-control" />
                                                    </div>
                                                </div>
                                            </div>

                                        </div>


                                    </div>
                                    <div class="row">
                                        <div class="col-sm-3 col-xs-12">
                                            <div class="form-group">
                                                <label class="col-sm-12 col-xs-12">Confirm Date</label>
                                                <div class="col-sm-12 col-xs-12">
                                                    <asp:TextBox runat="server" ID="txtConfiromDate" onchange="return CompareDate(this);" placeholder="DD/MM/YYYY" MaxLength="10" CssClass="form-control form-control-xs datepicker" />
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-sm-3 col-xs-12">
                                            <div class="form-group">
                                                <label class="col-sm-12 col-xs-12">Basic Incr. Date</label>
                                                <div class="col-sm-12">
                                                    <asp:TextBox runat="server" ID="txtBasicIncDate" onchange="return CompareDate(this);" placeholder="DD/MM/YYYY" MaxLength="10" CssClass="form-control form-control-xs datepicker" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-3 col-xs-12" style="display: none">
                                            <div class="form-group">
                                                <label class="col-sm-12 col-xs-12">Total Privilege Leave</label>
                                                <div class="col-sm-12">
                                                    <asp:TextBox runat="server" ID="txtTotalPvlLeave" placeholder="Enter Total Privilege Leave" CssClass="form-control form-control-xs" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-3 col-xs-12" style="display: none">
                                            <div class="form-group">
                                                <label class="col-sm-12 col-xs-12">Total Half Pay Leave</label>
                                                <div class="col-sm-12 col-xs-12">
                                                    <asp:TextBox runat="server" ID="txtTotalHalfPayLeve" placeholder="Enter Total Half Pay Leave" CssClass="form-control form-control-xs" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <%--   <div class="row">
                                        <div class="col-sm-3 col-xs-12">
                                            <div class="form-group">
                                                <div class="col-sm-12 col-xs-12 chk_inpt">
                                                    <asp:CheckBox Text="Earning Deduction Info" runat="server" />
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-sm-3 col-xs-12">
                                            <div class="form-group">
                                                <div class="col-sm-12 chk_inpt">
                                                    <asp:CheckBox Text="Family Details" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-3 col-xs-12">
                                            <div class="form-group">
                                                <div class="col-sm-12 chk_inpt">
                                                    <asp:CheckBox Text="Nominee Information" runat="server" ID="chkNomineeInformation" onchange="return NommneePanelFun();" />
                                                </div>
                                            </div>
                                        </div>

                                    </div>--%>
                                </div>
                            </div>

                            <div class="panel panel-default">
                                <div id="NomineeHead" runat="server" class="panel-heading entryMst-collapse collapsed" data-toggle="collapse" data-parent="#accordion" data-target="#ContentPlaceHolder1_Nominee">
                                    <a class="panel-title hdclr"><i class="fa" aria-hidden="true"></i>Nominee Information</a>

                                </div>
                                <div id="Nominee" class="panel-collapse collapse p10" runat="server">
                                    <div class="row">
                                        <%--<div class="col-sm-3 col-xs-12">
                                            <div class="form-group">
                                                <label class="col-sm-12 col-xs-12">Nominee Type</label>
                                                <div class="col-sm-12 col-xs-12">
                                                    <asp:DropDownList ID="ddlNomineeType_Nom" runat="server" CssClass="form-control form-control-xs">
                                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                        <asp:ListItem Value="1">Gratuity</asp:ListItem>
                                                        <asp:ListItem Value="2">GPF</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>--%>

                                        <div class="col-sm-3 col-xs-12">
                                            <div class="form-group">
                                                <label class="col-sm-12 col-xs-12">Name</label>
                                                <div class="col-sm-12">
                                                    <asp:TextBox runat="server" ID="txtName_Nom" MaxLength="10" placeholder="Enter Nominee Name" CssClass="form-control form-control-xs" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-3 col-xs-12">
                                            <div class="form-group">
                                                <label class="col-sm-12 col-xs-12">Relation</label>
                                                <div class="col-sm-12">
                                                    <asp:DropDownList runat="server" CssClass="form-control form-control-xs" ID="ddlRelation_Nom">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-3 col-xs-12">
                                            <div class="row">
                                                <div class="col-sm-8">
                                                    <div class="form-group">
                                                        <label class="col-sm-12 col-xs-12">Percentage</label>
                                                        <div class="col-sm-12 col-xs-12">
                                                            <asp:TextBox runat="server" ID="txtPercentage_Nom" placeholder="Enetr Percentage " MaxLength="10" CssClass="form-control form-control-xs numberonly" />
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-sm-4 text-right">
                                                    <label class="col-sm-12 col-xs-12">&nbsp;</label>
                                                    <div class="col-sm-12 col-xs-12">
                                                        <asp:LinkButton CssClass="btn btn-primary" runat="server" ID="btnAddNomeenee" OnClick="btnAddNomeenee_Click" OnClientClick="return Validationgrid()">Add</asp:LinkButton>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-xs-12">
                                            <div class="table-responsive">
                                                <style>
                                                    .table_head {
                                                        background: #3c8dbc;
                                                        color: #fff;
                                                    }
                                                </style>

                                                <asp:GridView ID="gvNomnee" CssClass="table table-bordered" OnRowCommand="gvNomnee_RowCommand" AutoGenerateColumns="false" ShowHeader="true" runat="server">
                                                    <HeaderStyle CssClass="table_head" />
                                                    <Columns>
                                                        <%--<asp:TemplateField HeaderText="Nominee Type">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblNomneeTypeId" Text='<%#Eval("NomneeTypeId") %>' runat="server" Visible="false"></asp:Label>
                                                                <asp:Label ID="lblNomneeTypeDesc" Text='<%#Eval("NomneeTypeDesc") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>--%>
                                                        <asp:TemplateField HeaderText="Nominee Name">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblNomneeName" Text='<%#Eval("NomneeName") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Relation">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblNomneeRelationId" Text='<%#Eval("NomneeRelationId") %>' Visible="false" runat="server"></asp:Label>
                                                                <asp:Label ID="lblNomneeRelationDesc" Text='<%#Eval("NomneeRelationDesc") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Percentage">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblNomneeParsentage" Text='<%#Eval("NomneeParsentage") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Action" ItemStyle-Width="10%">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="btnEdit" CommandName="Select1" CommandArgument='<%#Container.DataItemIndex %>' Text="Edit" CssClass="btn btn-primary btn-xs" OnClick="btnEdit_Click" runat="server"></asp:LinkButton>
                                                                <asp:LinkButton ID="btnDelete" Text="Del" CommandName="DeleteRow" CommandArgument='<%#Container.DataItemIndex %>' CssClass="btn btn-xs btn-danger add_btn" runat="server"></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                                    <RowStyle ForeColor="#000066" />
                                                    <SelectedRowStyle BackColor="LightGray" Font-Bold="True" ForeColor="White" />
                                                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                                                </asp:GridView>
                                                <asp:HiddenField ID="hfStaticVar" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                        </div>


                        <asp:Label Text="" ID="hfFocus" Visible="false" runat="server" />
                    </div>
                    <div class="panel-footer" style="margin-top: -20px;">
                        <div class="row">
                            <div class="col-xs-12 col-sm-12 text-right">
                                <asp:Label ID="lblMsg" runat="server" Style="display: none" />
                                <asp:LinkButton CssClass="btn btn-success" runat="server" ID="btnSave" OnClick="btnSave_Click" OnClientClick="return Validation()"><i class="fa r fa-save"></i> Save</asp:LinkButton>
                                <asp:LinkButton CssClass="btn btn-warning" runat="server" ID="btnClear" OnClick="btnClear_Click"><i class="fa r fa-refresh"></i> Clear</asp:LinkButton>
                                <asp:LinkButton CssClass="btn btn-danger" PostBackUrl="~/Salary/Dashboard.aspx" runat="server"><i class="fa r fa-close"></i> Exit</asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

