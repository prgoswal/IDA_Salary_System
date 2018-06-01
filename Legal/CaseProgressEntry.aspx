<%@ Page Title="" Language="C#" MasterPageFile="~/Legal/LegalMaster.master" AutoEventWireup="true" CodeFile="CaseProgressEntry.aspx.cs" Inherits="CaseProgressEntry" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

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

          control.makeTransliteratable(['<%=txtCaseTital.ClientID%>']);
              control.makeTransliteratable(['<%=txtHDesc.ClientID%>']);
           
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
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="scr" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="upd1" runat="server">
        <ContentTemplate>
              <script type="text/javascript" lang="javascript">
                  Sys.Application.add_load(onLoad);
                  Sys.Application.add_load(LoadC);
            </script>

    <div class="col-xs-12 mrgntp10">
        <div class="panel panel-primary form-horizontal">
            <div class="panel-heading">Case Progress Enrty</div>
            <div class="panel-body">
                <div class="panel-group acrdn_pnl" >

                    <div class="row">
                        <div class="col-sm-12">

                            <div class="row">
                                <div class="col-sm-2 col-xs-12">
                                    <div class="form-group">
                                        <label class="col-sm-12 col-xs-12">सदस्यता क्रमांक<i class="Star"> </i></label>
                                        <div class="col-sm-12 col-xs-12">
                                            <%--<asp:DropDownList  ID="ddlMemberNo" runat="server" CssClass="form-control form-control-xs"></asp:DropDownList>--%>
                                             <asp:TextBox ID="txtSuitNo" runat="server" MaxLength="12" placeholder="सदस्यता क्रमांक" CssClass="form-control " />
                                        </div>
                                    </div>
                                </div>

                                <div class="col-sm-2 col-xs-12">
                                    <div class="form-group">
                                        <label class="col-sm-12 col-xs-12">दावा दिनांक<i class="Star"> </i></label>
                                        <div class="col-sm-12">
                                             <asp:TextBox ID="txtSuitRegDate" runat="server" MaxLength="500" placeholder="DD/MM/YY" CssClass="form-control form-control-xs text-uppercase datepicker"  />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="s" ControlToValidate="txtSuitRegDate" ErrorMessage="दावा दिनांक दर्ज करे " Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ForeColor="Red" SetFocusOnError="true" CssClass="errorMsg-r" ControlToValidate="txtSuitRegDate" ValidationExpression="^(((((0[1-9])|(1\d)|(2[0-8]))[/]((0[1-9])|(1[0-2])))|((31[/]((0[13578])|(1[02])))|((29|30)[/]((0[1,3-9])|(1[0-2])))))[/]((20[0-9][0-9]))|(29[/]02[/]20(([02468][048])|([13579][26]))))$" ErrorMessage="Invalid date format." ValidationGroup="s" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-2 col-xs-12">
                                    <div class="form-group">
                                        <label class="col-sm-12 col-xs-12">केस का क्रमांक</label>
                                        <div class="col-sm-12">
                                            <%--<asp:DropDownList ID="ddlCaseNumber" runat="server" CssClass="form-control form-control-xs" ></asp:DropDownList>--%>
                                             <asp:TextBox ID="txtCaseNo" runat="server" MaxLength="12" placeholder="केस का क्रमांक" CssClass="form-control " />
                                             <asp:RequiredFieldValidator ID="rfvcaseNo" runat="server" ValidationGroup="s" ControlToValidate="txtCaseNo" ErrorMessage="केस का क्रमांक दर्ज करे " Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txtCaseNo" FilterType="Numbers" ValidChars=" " />
                                            
                                        </div>
                                    </div>
                                </div>
                                
                                 <div class="col-sm-2 col-xs-12">
                                    <div class="form-group">
                                        <label class="col-sm-12 col-xs-12">&nbsp </label>
                                        <div class="col-sm-12 col-xs-12">
                                          <asp:Button ID="BtnSearch" runat="server" Text="Search" OnClick="BtnSearch_Click" ValidationGroup="s"  CssClass="btn btn-success"/>
                                           
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-2 col-xs-12">
                                    <div class="form-group">
                                        <label class="col-sm-12 col-xs-12">न्यायालय का नाम </label>
                                        <div class="col-sm-12 col-xs-12">
                                          <%-- <asp:DropDownList runat="server" CssClass="form-control form-control-xs" ID="ddlCourtName"></asp:DropDownList>--%>
                                             <asp:TextBox ID="txtCourtPlace" Enabled="false" runat="server" MaxLength="150" style="width: 100%;" CssClass="form-control  " />
                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="a" ControlToValidate="txtCourtPlace" ErrorMessage="न्यायालय का नाम दर्ज करे " Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                           
                                        </div>
                                    </div>
                                </div>
                                 <div class="col-sm-4 col-xs-12">
                                    <div class="form-group">
                                        <label class="col-sm-12 col-xs-12">केस का उनवान<i class="Star"> </i></label>
                                        <div class="col-sm-12 col-xs-12">
                                            <asp:TextBox ID="txtCaseTital" Enabled="false" runat="server" class="form-control form-control-xs" style="width: 100%;height:50px;"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>


                    <div class="panel panel-default">
                        <div class="panel-heading" >
                            <a class="panel-title hdclr"><i class="fa" aria-hidden="true"></i>केस अभिभाषक
                            </a>
                        </div>

                        <div class="panel-body p10">
                            <div class="row">

                                <div class="col-sm-4 col-xs-12">
                                    <div class="form-group">
                                        <label class="col-sm-12 col-xs-12">अभिभाषक का नाम<i class="Star"> </i></label>
                                        <div class="col-sm-12 col-xs-12">
                                             <asp:DropDownList ID="ddlAdvoName" runat="server" CssClass="form-control form-control-xs">                                               
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfv1" runat="server" ValidationGroup="a" ControlToValidate="ddlAdvoName" InitialValue="अभिभाषक का नाम चुने" ErrorMessage="अभिभाषक का नाम चुने" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-2 col-xs-12">
                                    <div class="form-group">
                                        <label class="col-sm-12 col-xs-12">नियुक्ति दिनांक</label>
                                        <div class="col-sm-12">
                                           <asp:TextBox ID="txtAppointDate" runat="server" MaxLength="10" placeholder="DD/MM/YY" CssClass="form-control form-control-xs text-uppercase datepicker "  />
                                            <asp:RequiredFieldValidator ID="rfv2" runat="server" ValidationGroup="a" ControlToValidate="txtAppointDate" Display="Dynamic" ForeColor="Red" ErrorMessage="नियुक्ति दिनांक दर्ज करे " InitialValue="0"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>                              
                            </div>
                        </div>

                    </div>

                    <div class="panel panel-default">
                        <div  class="panel-heading">
                            <a class="panel-title hdclr"><i class="fa" aria-hidden="true"></i>केस दिनांक
                            </a>
                        </div>

                        <div class="panel-body p10">
                          

                             <div class="col-sm-4 col-xs-12">
                                    <div class="form-group">
                                        <label class="col-sm-12 col-xs-12">स्थिति <i class="Star"> </i></label>
                                        <div class="col-sm-12 col-xs-12">
                                             <asp:DropDownList ID="ddlCaseStage" runat="server" CssClass="form-control form-control-xs">
                                                
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfv3" runat="server" ValidationGroup="a" ControlToValidate="ddlCaseStage" ErrorMessage="स्थिति चुने " Display="Dynamic" ForeColor="Red" InitialValue="चुने"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div> 

                                <div class="col-sm-2 col-xs-12">
                                    <div class="form-group">
                                        <label class="col-sm-12 col-xs-12">आगामी पेशी की दिनांक</label>
                                        <div class="col-sm-12">
                                           <asp:TextBox ID="txtNextHdate" runat="server" MaxLength="10" placeholder="DD/MM/YY" CssClass="form-control form-control-xs text-uppercase datepicker "  />
                                            <asp:RequiredFieldValidator ID="rfv4" runat="server" ValidationGroup="a" ControlToValidate="txtNextHdate" ErrorMessage="आगामी पेशी की दिनांक दर्ज करे" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-2 col-xs-12">
                                    <div class="form-group">
                                        <label class="col-sm-12 col-xs-12">अंतिम हियरिंग दिनांक</label>
                                        <div class="col-sm-12">
                                           <asp:TextBox ID="txtLastNHDate" runat="server" MaxLength="10" placeholder="DD/MM/YY" CssClass="form-control form-control-xs text-uppercase datepicker "  />
                                            <asp:RequiredFieldValidator ID="rfv5" runat="server" ValidationGroup="a" ControlToValidate="txtLastDate" ErrorMessage="अंतिम दिनांक दर्ज करे" ForeColor="Red" Display="Dynamic" InitialValue="0"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                               </div>
                        </div>
                   

                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <a class="panel-title hdclr"><i class="fa" aria-hidden="true"></i>केस प्रभारी अधिकारी
                            </a>
                        </div>

                        <div class="panel-body p10">
                            <div class="row">

                                 <div class="col-sm-4 col-xs-12">
                                    <div class="form-group">
                                        <label class="col-sm-12 col-xs-12">प्रभारी अधिकारी<i class="Star"> </i></label>
                                        <div class="col-sm-12 col-xs-12">
                                             <asp:DropDownList ID="ddlOICOfficer" runat="server" CssClass="form-control form-control-xs">                                               
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfv6" runat="server" ValidationGroup="a" ControlToValidate="ddlOICOfficer" ErrorMessage="प्रभारी अधिकारी चुने " Display="Dynamic" ForeColor="Red" InitialValue="चुने"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-2 col-xs-12">
                                    <div class="form-group">
                                        <label class="col-sm-12 col-xs-12">नियुक्ति क्रमांक</label>
                                        <div class="col-sm-12">
                                           <asp:TextBox  ID="txtChargeAppointNo" runat="server" MaxLength="10" placeholder="नियुक्ति क्रमांक" CssClass="form-control form-control-xs text-uppercase " />
                                            <asp:RequiredFieldValidator ID="rfv7" runat="server" ValidationGroup="a" ControlToValidate="txtChargeAppointNo" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-2 col-xs-12">
                                    <div class="form-group">
                                        <label class="col-sm-12 col-xs-12">नियुक्ति दिनांक</label>
                                        <div class="col-sm-12">
                                           <asp:TextBox ID="txtChargeAppointDate" runat="server" MaxLength="10" placeholder="DD/MM/YY" CssClass="form-control form-control-xs text-uppercase datepicker "  />
                                            <asp:RequiredFieldValidator ID="rfv8" runat="server" ControlToValidate="txtChargeAppointDate" Display="Dynamic" ForeColor="Red" ErrorMessage="नियुक्ति दिनांक दर्ज करे" ValidationGroup="a" InitialValue="0"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>   
                            </div>
                        </div>

                    </div>

                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <a class="panel-title hdclr"><i class="fa" aria-hidden="true"></i>पेशी विवरण
                            </a>
                        </div>

                        <div class="panel-body p10">
                            <div class="row">

                               <%-- <div class="col-sm-2 col-xs-12">
                                    <div class="form-group">
                                        <label class="col-sm-12 col-xs-12">पेशी दिनांक</label>
                                        <div class="col-sm-12">
                                           <asp:TextBox ID="txtFirstHDate" runat="server" MaxLength="10" placeholder="DD/MM/YY" CssClass="form-control form-control-xs text-uppercase datepicker "  />
                                        </div>
                                    </div>
                                </div>--%>
                               
                                <div class="col-sm-4 col-xs-12">
                                    <div class="form-group">
                                        <label class="col-sm-12 col-xs-12">विवरण<i class="Star"> </i></label>
                                        <div class="col-sm-12 col-xs-12">
                                            <asp:TextBox ID="txtHDesc" MaxLength="150" runat="server" class="form-control form-control-xs" style="width: 100%;height:50px;"></asp:TextBox>                                          
                                        </div>
                                    </div>
                                </div>


                                 <div class="col-sm-2 col-xs-12">
                                    <div class="form-group">
                                        <label class="col-sm-12 col-xs-12">अंतिम दिनांक</label>
                                        <div class="col-sm-12">
                                           <asp:TextBox ID="txtlastdate" runat="server" MaxLength="10" placeholder="DD/MM/YYYY" CssClass="form-control form-control-xs text-uppercase datepicker "  />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtChargeAppointDate" Display="Dynamic" ForeColor="Red" ErrorMessage="नियुक्ति दिनांक दर्ज करे" ValidationGroup="a" InitialValue="0"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div> 
                                 
                            </div>
                        </div>

                    </div>
                </div>
            </div>

             <div class="panel-footer">
                           <%-- <asp:Button ID="btnSave" Text="Save" OnClick="btnSave_Click" runat="server"   CssClass="btn btn-success btnSave" />--%>
                 <asp:Button ID="btnupdate" runat="server" Text="Update" ValidationGroup="a" OnClick="btnupdate_Click" CssClass="btn btn-success btnSave" />
                            <asp:Button ID="btnClear" Text="Clear" OnClick="btnClear_Click" runat="server"  CssClass="btn btn-warning btnClear" />
                            <asp:Button ID="btnExit" runat="server"  CssClass="btn btn-danger" Text="Exit" />
                           <div class="alertMsg success" runat="server" id="pnlSuccess"></div>
                           <div class="alertMsg failed" runat="server" id="pnlfailed"></div>                           
                        </div>

        </div>
    </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

