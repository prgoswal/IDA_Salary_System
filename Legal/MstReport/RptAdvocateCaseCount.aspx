<%@ Page Title="" Language="C#" MasterPageFile="~/Legal/LegalMaster.master" AutoEventWireup="true" CodeFile="RptAdvocateCaseCount.aspx.cs" Inherits="Legal_MstReport_RptAdvocateCaseCount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript" src="https://www.google.com/jsapi">
    </script>
    <script>
        // Load the Google Transliterate API
        google.load("elements", "1", {
            packages: "transliteration"
        });

        function onLoad() {

            var date = new Date();
            $('.datepickermaxtoday').datepicker({ dateFormat: 'dd/mm/yy', maxDate: date });
            $('.datepickermintoday').datepicker({ dateFormat: 'dd/mm/yy', minDate: date });
            $('.datepicker').datepicker({ dateFormat: 'dd/mm/yy' });
            $('.datepicker').each(function () {
                $(this).attr('placeholder', 'DD/MM/YYYY');
            });
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
        }
        google.setOnLoadCallback(onLoad);

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

        .grpint1 {
            width: 50%;
            margin: 0px;
            padding: 0px;
            padding-left: 5px;
            float: left;
            border-bottom-right-radius: 0px;
            border-top-right-radius: 0px;
        }

        .grpint2 {
            width: 50%;
            margin: 0px;
            padding: 0px;
            padding-left: 5px;
            float: left;
            border-bottom-left-radius: 0px;
            border-top-left-radius: 0px;
        }

        .tblhd {
            background-color: #3c8dbc;
            color: #fff;
        }

        .rdo label {
            margin-left: 5px;
            margin-right: 5px;
        }

        .tblhieght {
            height: 100px;
            overflow-y: scroll;
        }
       .suitdateto {
           width:50%;
           float:left;
           margin-right:5px;
       } 
       .suitdatefrom {
           width:48%;
           float:right
       }
    </style>


    <%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=14.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="col-xs-12 col-sm-8 mrgntp10 col-sm-offset-2">
                <div class="panel panel-primary form-horizontal">
                    <div class="panel-heading">Advocate Case Count Report</div>
                    <div class="panel-body">
                        <div class="panel-group acrdn_pnl">

                            <div class="row">
                                <div class="col-xs-12 col-sm-9">
                                    <div class="form-group">
                                        <label class="col-sm-3 col-xs-12 control-label required">From Date<i class="Star"> </i></label>
                                        <div class="col-sm-9 col-xs-12">
                                            <asp:TextBox ID="txtfromdate" runat="server" CssClass="form-control form-control-xs datepicker"></asp:TextBox>
                                           
                                        </div>
                                    </div>


                                     <div class="form-group">
                                        <label class="col-sm-3 col-xs-12 control-label required">To Date<i class="Star"> </i></label>
                                        <div class="col-sm-9 col-xs-12">
                                            <asp:TextBox ID="txttodate" runat="server" CssClass="form-control form-control-xs datepicker"></asp:TextBox>
                                            
                                        </div>
                                    </div>



                                </div>
                                <div class="col-xs-12 col-sm-3">
                                    <asp:Button ID="btnsearch" Text="Search" ValidationGroup="a" runat="server" OnClick="btnsearch_Click" CssClass="btn btn-success btnSave" />
                                    <asp:Button ID="btnclear" Text="Clear" runat="server" OnClick="btnclear_Click" CssClass="btn btn-warning btnClear" />
                                    <asp:Button ID="btnExit" runat="server" PostBackUrl="~/Legal/Dashboard.aspx" Text="Exit" CssClass="btn btn-danger" />

                                </div>
                            </div>

                            

                         
                        </div>

                         

                    </div>

                    <div class="panel-footer">
                        <div class="alertMsg success" runat="server" id="pnlSuccess"></div>
                        <div class="alertMsg failed" runat="server" id="pnlfailed"></div>
                    </div>

                </div>
            </div>
</asp:Content>

