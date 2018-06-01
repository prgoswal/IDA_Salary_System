<%@ Page Title="" Language="C#" MasterPageFile="~/Legal/LegalMaster.master" AutoEventWireup="true" CodeFile="frmCaseDetail.aspx.cs" Inherits="frmCaseDetail" %>

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

            control.makeTransliteratable(['<%=txtCaseTitle.ClientID%>']);
            control.makeTransliteratable(['<%=txtSuitName.ClientID%>']);
            control.makeTransliteratable(['<%=txtPartyName.ClientID%>']);
            control.makeTransliteratable(['<%=txtPartyAddress.ClientID%>']);
            control.makeTransliteratable(['<%=txtcaseDetails.ClientID%>']);
            control.makeTransliteratable(['<%=txtOICAddress.ClientID%>']);
            control.makeTransliteratable(['<%=txtAdvoAddress.ClientID%>']);
            control.makeTransliteratable(['<%=txtOrderDesc.ClientID%>']);
            control.makeTransliteratable(['<%=txtlastDecision.ClientID%>']);
            control.makeTransliteratable(['<%=txtRemark.ClientID%>']);
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
            margin-bottom: 15px !important;
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

        .pointer {
            cursor: pointer;
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
    <script type="text/javascript" lang="javascript">
        Sys.Application.add_load(onLoad);
    </script>
    <asp:ScriptManager ID="scr1" runat="server"></asp:ScriptManager>
    <div class="col-xs-12 mrgntp10">
        <div class="panel panel-primary form-horizontal">
            <div class="panel-heading">Case Master</div>
            <div class="panel-body">

                <div class="panel-group acrdn_pnl" id="accordion">

                    <div class="row">
                        <div class="col-sm-12">

                            <div class="row">
                                <div class="col-sm-3 col-xs-12">
                                    <div class="form-group">
                                        <label class="col-sm-12 col-xs-12">नोटिस प्राप्ति क्रमांक/दिनांक<i class="Star"> </i></label>
                                        <div class="col-sm-12 col-xs-12">
                                            <asp:TextBox ID="txtNoticeNo" runat="server" MaxLength="6" placeholder="प्राप्ति क्रमांक" CssClass="form-control form-control-xs text-uppercase grpint1" />
                                            <asp:RequiredFieldValidator ID="rfv1" runat="server" ControlToValidate="txtNoticeNo" CssClass="errorMsg" Display="Dynamic" ValidationGroup="a" ForeColor="Red" SetFocusOnError="true" ErrorMessage="नोटिस प्राप्ति क्रमांक दर्ज करे"></asp:RequiredFieldValidator>
                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtNoticeNo" FilterType="Numbers" ValidChars=" " />
                                            <asp:TextBox ID="txtNoticeDate" runat="server" MaxLength="10" placeholder="दिनांक" CssClass="form-control form-control-xs text-uppercase grpint2 datepickermaxtoday" />
                                             <asp:RegularExpressionValidator ID="reg" runat="server" ForeColor="Red" SetFocusOnError="true" CssClass="errorMsg-r" ControlToValidate="txtNoticeDate" ValidationExpression="^(((((0[1-9])|(1\d)|(2[0-8]))[/]((0[1-9])|(1[0-2])))|((31[/]((0[13578])|(1[02])))|((29|30)[/]((0[1,3-9])|(1[0-2])))))[/]((20[0-9][0-9]))|(29[/]02[/]20(([02468][048])|([13579][26]))))$" ErrorMessage="Invalid date format." ValidationGroup="a" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNoticeDate" CssClass="errorMsg-r erromrgn" Display="Dynamic" ValidationGroup="a" ForeColor="Red" SetFocusOnError="true" ErrorMessage="नोटिस प्राप्ति दिनांक  दर्ज करे"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-3 col-xs-12">
                                    <div class="form-group">
                                        <label class="col-sm-12 col-xs-12">दावा रजिस्टर क्रमांक/दिनांक<i class="Star"> </i></label>
                                        <div class="col-sm-12">
                                            <asp:TextBox ID="txtSuitRegNo" runat="server" MaxLength="6" placeholder="प्राप्ति क्रमांक" CssClass="form-control form-control-xs text-uppercase grpint1" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtSuitRegNo" CssClass="errorMsg" Display="Dynamic" ValidationGroup="a" ForeColor="Red" SetFocusOnError="true" ErrorMessage="दावा रजिस्टर क्रमांक दर्ज करे"></asp:RequiredFieldValidator>
                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtSuitRegNo" FilterType="Numbers" ValidChars=" " />
                                            <asp:TextBox ID="txtSuitRegDate" runat="server" MaxLength="10" placeholder="दिनांक" CssClass="form-control form-control-xs text-uppercase grpint2 datepickermaxtoday" />
                                             <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ForeColor="Red" SetFocusOnError="true" CssClass="errorMsg-r" ControlToValidate="txtSuitRegDate" ValidationExpression="^(((((0[1-9])|(1\d)|(2[0-8]))[/]((0[1-9])|(1[0-2])))|((31[/]((0[13578])|(1[02])))|((29|30)[/]((0[1,3-9])|(1[0-2])))))[/]((20[0-9][0-9]))|(29[/]02[/]20(([02468][048])|([13579][26]))))$" ErrorMessage="Invalid date format." ValidationGroup="a" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtSuitRegDate" CssClass="errorMsg-r" Display="Dynamic" ValidationGroup="a" ForeColor="Red" SetFocusOnError="true" ErrorMessage="दावा रजिस्टर दिनांक  दर्ज करे"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>

                                <asp:UpdatePanel ID="updCourt" runat="server">
                                    <ContentTemplate >
                                <div class="col-sm-3 col-xs-12">
                                    <div class="form-group">
                                        <label class="col-sm-12 col-xs-12">न्यायालय </label>
                                        <div class="col-sm-12">
                                            <asp:DropDownList runat="server" CssClass="form-control form-control-xs" AutoPostBack="true" OnSelectedIndexChanged="ddlCourtPlace_SelectedIndexChanged" ID="ddlCourtPlace"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rf1" runat="server" ControlToValidate="ddlCourtPlace" ValidationGroup="a" InitialValue="0" Display="Dynamic" ForeColor="Red" ErrorMessage="न्यायालय / स्थान का नाम चुने "></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-3 col-xs-12">
                                    <div class="form-group">
                                        <label class="col-sm-12 col-xs-12">स्थान का नाम</label>
                                        <div class="col-sm-12 col-xs-12">
                                            <asp:TextBox runat="server" MaxLength="60" placeholder="" CssClass="form-control form-control-xs text-uppercase " ID="txtCourtplace" ReadOnly="true" />
                                        </div>
                                    </div>
                                </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>

                            <div class="row">
                                <div class="col-sm-3 col-xs-12">
                                    <div class="form-group">
                                        <label class="col-sm-12 col-xs-12">प्रकरण क्रमांक<i class="Star"> </i></label>
                                        <div class="col-sm-12 col-xs-12">
                                            <asp:TextBox ID="txtCaseNumber" runat="server" MaxLength="6" placeholder="प्रकरण क्रमांक" CssClass="form-control form-control-xs text-uppercase" />
                                            <asp:RequiredFieldValidator ID="rfvcaseNo" runat="server" ValidationGroup="a" ControlToValidate="txtCaseNumber" ErrorMessage="प्रकरण क्रमांक दर्ज करे " Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txtCaseNumber" FilterType="Numbers" ValidChars=" " />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-3 col-xs-12">
                                    <div class="form-group">
                                        <label class="col-sm-12 col-xs-12">पुराने दावा रजिस्टर क्रमांक<i class="Star"> </i></label>
                                        <div class="col-sm-12">
                                            <asp:TextBox ID="txtOldSuitRegNo" runat="server" MaxLength="6" placeholder="पुराने दावा रजिस्टर क्रमांक" CssClass="form-control form-control-xs text-uppercase" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="a" runat="server" ControlToValidate="txtOldSuitRegNo" ErrorMessage="पुराने दावा रजिस्टर क्रमांक दर्ज करे " Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" TargetControlID="txtOldSuitRegNo" FilterType="Numbers" ValidChars=" " />

                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-3 col-xs-12">
                                    <div class="form-group">
                                        <label class="col-sm-12 col-xs-12">पुराने केस का नंबर</label>
                                        <div class="col-sm-12">
                                            <asp:TextBox ID="txtOldCaseNo" runat="server" MaxLength="12" placeholder="केस का नंबर" CssClass="form-control form-control-xs numberonly" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ValidationGroup="a" runat="server" ControlToValidate="txtOldSuitRegNo" ErrorMessage="पुराने केस का नंबर दर्ज करे " Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" TargetControlID="txtOldCaseNo" FilterType="Numbers" ValidChars=" " />
                                        </div>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>


                    <div class="panel panel-default">
                        <div id="case_hd" runat="server" class="panel-heading entryMst-collapse collapsed pointer" data-toggle="collapse" data-parent="#accordion" data-target="#ContentPlaceHolder1_case">
                            <a class="panel-title hdclr"><i class="fa" aria-hidden="true"></i>केस का उनवान
                            </a>
                        </div>

                        <div id="case" runat="server" class="panel-collapse collapse  p10">
                          <%--  <asp:ScriptManager ID="scr1" runat="server"></asp:ScriptManager>--%>
                            <asp:UpdatePanel ID="upd1" runat="server">
                                <ContentTemplate>
                                    <div class="row">

                                        <div class="col-sm-4 col-xs-12">
                                            <div class="form-group">
                                                <label class="col-sm-12 col-xs-12">केस का उनवान<i class="Star"> </i></label>
                                                <div class="col-sm-12 col-xs-12">
                                                    <asp:TextBox ID="txtCaseTitle" runat="server" MaxLength="150" TextMode="MultiLine" Style="width: 100%; height: 115px;" CssClass="form-control form-control-xs"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ValidationGroup="a" ControlToValidate="txtCaseTitle" Display="Dynamic" ForeColor="Red" ErrorMessage="केस का उनवान दर्ज करे"></asp:RequiredFieldValidator>

                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-2 col-xs-12">
                                            <div class="form-group">
                                                <label class="col-sm-12 col-xs-12">केस का प्रकार</label>
                                                <div class="col-sm-12">
                                                    <asp:DropDownList ID="ddlCaseType" runat="server" CssClass="form-control form-control-xs">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ValidationGroup="a" InitialValue="0" ControlToValidate="ddlCaseType" Display="Dynamic" ForeColor="Red" ErrorMessage="केस का प्रकार चुने "></asp:RequiredFieldValidator>

                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-4 col-xs-12">
                                            <div class="form-group">
                                                <label class="col-sm-12 col-xs-12">वादी याची का नाम</label>
                                                <div class="col-sm-12">
                                                    <asp:TextBox ID="txtSuitName" runat="server" MaxLength="60" placeholder="वादी याची का नाम" CssClass="form-control form-control-xs text-uppercase " />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ValidationGroup="b" ControlToValidate="txtSuitName" Display="Dynamic" ForeColor="Red" ErrorMessage="वादी याची का नाम दर्ज करे "></asp:RequiredFieldValidator>

                                                </div>
                                            </div>
                                        </div>


                                        <div class="col-sm-2 col-xs-12">
                                            <div class="form-group">
                                                <label class="col-sm-12 col-xs-12">&nbsp</label>
                                                <div class="col-sm-12">
                                                    <asp:Button ID="BtnAddSuitName" Text="Press Enter To Add" OnClick="BtnAddSuitName_Click" ValidationGroup="b" runat="server" CssClass="btn btn-primary" />
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-sm-6" style="float: left; height: 100px; overflow: auto">

                                            <style>
                                                .hdr {
                                                    background-color: #3c8dbc;
                                                    color: #fff;
                                                }
                                            </style>
                                            <asp:GridView ID="gridSuitName" ShowHeader="true" OnRowCommand="gridSuitName_RowCommand" CssClass="table table-bordered" runat="server" AutoGenerateColumns="false">
                                                <Columns>

                                                    <asp:TemplateField HeaderStyle-CssClass="hdr" HeaderText="क्रमांक">
                                                        <ItemTemplate>
                                                            <%#(Container.DataItemIndex+1) %>
                                                        </ItemTemplate>

                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="SuitName" HeaderStyle-CssClass="hdr" HeaderText="वादी याचिका का नाम" />
                                                    <asp:TemplateField HeaderText="मिटाये" HeaderStyle-CssClass="hdr">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="del" runat="server" ForeColor="red" CommandName="RecordDelete" Text="Delete" CommandArgument=' <%#(Container.DataItemIndex) %>'></asp:LinkButton>
                                                        </ItemTemplate>

                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                            <%-- </td>
                                        </tr>
                                    </tbody>
                                </table>--%>
                                        </div>

                                    </div>
                                    <hr />
                                    <div class="row">
                                        <div class="col-sm-4 col-xs-12">
                                            <div class="form-group">
                                                <label class="col-sm-12 col-xs-12">विपक्षी का नाम <i class="Star"></i></label>
                                                <div class="col-sm-12 col-xs-12">
                                                    <asp:TextBox ID="txtPartyName" runat="server" MaxLength="60" placeholder="विपक्षी का नाम" CssClass="form-control form-control-xs text-uppercase" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtPartyName" ValidationGroup="partyGroup" Display="Dynamic" ForeColor="Red" ErrorMessage="विपक्षी का नाम दर्ज करे"></asp:RequiredFieldValidator>


                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-sm-4 col-xs-12">
                                            <div class="form-group">
                                                <label class="col-sm-12 col-xs-12">विपक्षी का पता<i class="Star"> </i></label>
                                                <div class="col-sm-12">
                                                    <asp:TextBox ID="txtPartyAddress" runat="server" MaxLength="150" placeholder="विपक्षी का पता" CssClass="form-control form-control-xs text-uppercase" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtPartyAddress" Display="Dynamic" ValidationGroup="partyGroup" ForeColor="Red" ErrorMessage="विपक्षी का पता दर्ज करे"></asp:RequiredFieldValidator>

                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-2 col-xs-12">
                                            <div class="form-group">
                                                <label class="col-sm-12 col-xs-12">मोबाइल नंबर</label>
                                                <div class="col-sm-12">
                                                    <asp:TextBox ID="txtPartyMobNo" runat="server" MaxLength="10" MinLength="10" placeholder="मोबाइल नंबर" CssClass="form-control form-control-xs text-uppercase" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtPartyMobNo" Display="Dynamic" ValidationGroup="partyGroup" ForeColor="Red" ErrorMessage="मोबाइल नंबर दर्ज करे"></asp:RequiredFieldValidator>
                                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender11" runat="server" TargetControlID="txtPartyMobNo" FilterType="Numbers" ValidChars=" " />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-2 col-xs-12">
                                            <div class="form-group">
                                                <label class="col-sm-12 col-xs-12">आधार नंबर</label>
                                                <div class="col-sm-12">
                                                    <asp:TextBox ID="txtAadharNo" runat="server" MaxLength="12" MinLength="12" placeholder="आधार नंबर" CssClass="form-control form-control-xs text-uppercase" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtAadharNo" Display="Dynamic" ValidationGroup="partyGroup" ForeColor="Red" ErrorMessage="आधार नंबर दर्ज करे"></asp:RequiredFieldValidator>
                                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender12" runat="server" TargetControlID="txtAadharNo" FilterType="Numbers" ValidChars=" " />
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-sm-4 col-xs-12">
                                            <div class="form-group">
                                                <label class="col-sm-12 col-xs-12">योजना का नाम</label>
                                                <div class="col-sm-12 col-xs-12">
                                                    <asp:DropDownList ID="ddlSchemeName" runat="server" CssClass="form-control form-control-xs">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" InitialValue="0" ControlToValidate="ddlSchemeName" Display="Dynamic" ValidationGroup="partyGroup" ForeColor="Red" ErrorMessage="योजना का नाम दर्ज करे"></asp:RequiredFieldValidator>

                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-2 col-xs-12">
                                            <div class="form-group">
                                                <label class="col-sm-12 col-xs-12">भूखंड नंबर</label>
                                                <div class="col-sm-12 col-xs-12">
                                                    <asp:TextBox ID="txtPlotNo" runat="server" MaxLength="12" placeholder="भूखंड नंबर" CssClass="form-control form-control-xs text-uppercase" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtPlotNo" Display="Dynamic" ValidationGroup="partyGroup" ForeColor="Red" ErrorMessage="भूखंड नंबर दर्ज करे"></asp:RequiredFieldValidator>
                                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender13" runat="server" TargetControlID="txtPlotNo" FilterType="Numbers" ValidChars=" " />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-2 col-xs-12">
                                            <div class="form-group">
                                                <label class="col-sm-12 col-xs-12">संदर्भ नंबर</label>
                                                <div class="col-sm-12 col-xs-12">
                                                    <asp:TextBox ID="txtRefNo" runat="server" MaxLength="6" placeholder="संदर्भ नंबर" CssClass="form-control form-control-xs text-uppercase" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txtRefNo" Display="Dynamic" ValidationGroup="partyGroup" ForeColor="Red" ErrorMessage="संदर्भ नंबर दर्ज करे"></asp:RequiredFieldValidator>
                                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender14" runat="server" TargetControlID="txtRefNo" FilterType="Numbers" ValidChars=" " />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-2 col-xs-12">
                                            <div class="form-group">
                                                <label class="col-sm-12 col-xs-12">&nbsp;</label>
                                                <div class="col-sm-12 col-xs-12">
                                                    <asp:Button ID="BtnPartyAdd" Text="Add" runat="server" ValidationGroup="partyGroup" OnClick="BtnPartyAdd_Click" CssClass="btn btn-primary" />
                                                </div>
                                            </div>
                                        </div>


                                        <div class="">
                                            <div class="col-sm-12 ">

                                                <asp:GridView ID="GridParty" runat="server" CssClass="table table-bordered tblhieght " OnRowCommand="GridParty_RowCommand" AutoGenerateColumns="false">
                                                    <Columns>
                                                        <asp:TemplateField Visible="false" HeaderText="Sno.">
                                                            <ItemTemplate>
                                                                <%#(Container.DataItemIndex+1) %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderStyle-CssClass="tblhd" HeaderText="विपक्षी का नाम">
                                                            <ItemTemplate>
                                                                <%# Eval("PartyName") %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-CssClass="tblhd" HeaderText="विपक्षी का पता">
                                                            <ItemTemplate>
                                                                <%# Eval("PartyAddress") %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-CssClass="tblhd" HeaderText="मोबाईल नंबर">
                                                            <ItemTemplate>
                                                                <%# Eval("PartyMobNo") %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-CssClass="tblhd" HeaderText="आधार नंबर">
                                                            <ItemTemplate>
                                                                <%# Eval("PartyAadharNo") %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-CssClass="tblhd" HeaderText="योजना का नाम">
                                                            <ItemTemplate>
                                                                <%# Eval("PartyPlanName") %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-CssClass="tblhd" HeaderText="प्लाट नंबर">
                                                            <ItemTemplate>
                                                                <%# Eval("PartyPlotNo") %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-CssClass="tblhd" HeaderText="संदर्भ नंबर">
                                                            <ItemTemplate>
                                                                <%# Eval("PartyRef") %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="PartyPlanId" Visible="false" HeaderText="Plan Id" />

                                                        <asp:TemplateField HeaderText="मिटाये" HeaderStyle-CssClass="tblhd">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="partyDel" runat="server" ForeColor="red" CommandName="RecordDel" CommandArgument='<%#(Container.DataItemIndex) %>' Text="Delete"></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>

                                            </div>

                                        </div>

                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>


                    </div>

                    <div class="panel panel-default">
                        <div id="vivranhdr" runat="server" class="panel-heading entryMst-collapse collapsed pointer" data-toggle="collapse" data-parent="#accordion" data-target="#ContentPlaceHolder1_vivran">
                            <a class="panel-title hdclr"><i class="fa" aria-hidden="true"></i>विवरण</a>
                        </div>

                        <div id="vivran" runat="server" class="panel-collapse collapse p10">


                            <div class="row">


                                <div class="col-sm-6 col-xs-12">
                                    <div class="form-group">
                                        <label class="col-sm-12 col-xs-12">प्रकरण का विवरण<i class="Star"> </i></label>
                                        <div class="col-sm-12 col-xs-12">
                                            <asp:TextBox ID="txtcaseDetails" runat="server" MaxLength="60" Style="width: 100%; height: 80px;" class="form-control form-control-xs"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvcaseDetail" runat="server" ControlToValidate="txtcaseDetails" ValidationGroup="a" ForeColor="Red" Display="Dynamic" ErrorMessage="प्रकरण का विवरण दर्ज करे "></asp:RequiredFieldValidator>

                                        </div>
                                    </div>
                                </div>

                                <div class="col-sm-2 col-xs-12">
                                    <div class="form-group">
                                        <label class="col-sm-12 col-xs-12">प्राथम पेशी दिनांक</label>
                                        <div class="col-sm-12">
                                            <asp:TextBox ID="txtfirsthdate" runat="server" placeholder="DD/MM/YY" MaxLength="10" CssClass="form-control form-control-xs datepickermaxtoday" />
                                             <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ForeColor="Red" SetFocusOnError="true" CssClass="errorMsg-r" ControlToValidate="txtfirsthdate" ValidationExpression="^(((((0[1-9])|(1\d)|(2[0-8]))[/]((0[1-9])|(1[0-2])))|((31[/]((0[13578])|(1[02])))|((29|30)[/]((0[1,3-9])|(1[0-2])))))[/]((20[0-9][0-9]))|(29[/]02[/]20(([02468][048])|([13579][26]))))$" ErrorMessage="Invalid date format." ValidationGroup="a" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="txtfirsthdate" ValidationGroup="a" ForeColor="Red" Display="Dynamic" ErrorMessage="प्राथम पेशी दिनांक दर्ज करे "></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>

                            </div>
                            <div class="row">

                                <div class="col-sm-6">

                                    <asp:UpdatePanel ID="upd2" runat="server">
                                        <ContentTemplate>


                                            <div class="col-xs-12">



                                                <div class="row" style="color: #3c8dbc;">
                                                    <h5><strong>प्रभारी अभिव्यक्ति की नियुक्ति(OIC)</strong></h5>
                                                    <hr />
                                                </div>
                                            </div>
                                            <hr />

                                            <div class="row">

                                                <div class="col-sm-6 col-xs-12">
                                                    <div class="form-group">
                                                        <label class="col-sm-12 col-xs-12">पत्र क्रमांक/दिनांक<i class="Star"> </i></label>
                                                        <div class="col-sm-12 col-xs-12">
                                                            <asp:TextBox ID="txtOICLetterNo" runat="server" MaxLength="6" placeholder="पत्र क्रमांक" CssClass="form-control form-control-xs text-uppercase grpint1"></asp:TextBox>

                                                            <asp:TextBox ID="txtOICLetterDate" runat="server" MaxLength="10" placeholder="दिनांक" CssClass="form-control form-control-xs text-uppercase grpint2 datepickermaxtoday"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ForeColor="Red" SetFocusOnError="true" CssClass="errorMsg-r" ControlToValidate="txtOICLetterDate" ValidationExpression="^(((((0[1-9])|(1\d)|(2[0-8]))[/]((0[1-9])|(1[0-2])))|((31[/]((0[13578])|(1[02])))|((29|30)[/]((0[1,3-9])|(1[0-2])))))[/]((20[0-9][0-9]))|(29[/]02[/]20(([02468][048])|([13579][26]))))$" ErrorMessage="Invalid date format." ValidationGroup="AddOIC" />
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="txtOICLetterDate" ValidationGroup="AddOIC" ForeColor="Red" Display="Dynamic" ErrorMessage="पत्र क्रमांक/दिनांक दर्ज करे " CssClass="errorMsg"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="col-sm-6 col-xs-12">
                                                    <div class="form-group">
                                                        <label class="col-sm-12 col-xs-12">नाम</label>
                                                        <div class="col-sm-12">


                                                            <asp:DropDownList ID="ddlOICName" runat="server" CssClass="form-control form-control-xs">
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator18" InitialValue="0" runat="server" ControlToValidate="ddlOICName" ValidationGroup="AddOIC" ForeColor="Red" Display="Dynamic" ErrorMessage="नाम चुने "></asp:RequiredFieldValidator>

                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-sm-9 col-xs-12">
                                                    <div class="form-group">
                                                        <label class="col-sm-12 col-xs-12">पता<i class="Star"> </i></label>
                                                        <div class="col-sm-12 col-xs-12">
                                                            <%--<textarea style="width: 100%; height:35px;" class="form-control form-control-xs"></textarea>--%>
                                                            <asp:TextBox ID="txtOICAddress" runat="server" TextMode="MultiLine" MaxLength="150" CssClass="form-control form-control-xs" Style="width: 100%; height: 35px;"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="txtOICAddress" ValidationGroup="AddOIC" ForeColor="Red" Display="Dynamic" ErrorMessage="पता दर्ज करे"></asp:RequiredFieldValidator>

                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-sm-3 col-xs-12">
                                                    <div class="form-group">
                                                        <label class="col-sm-12 col-xs-12">&nbsp;</label>
                                                        <div class="col-sm-12 col-xs-12">
                                                            <asp:Button ID="btnOICAdd" Text="Add OIC" runat="server" ValidationGroup="AddOIC" OnClick="btnOICAdd_Click" CssClass="btn btn-primary" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>


                                            <div class="row">
                                                <div class="col-sm-12 ">



                                                    <asp:GridView ID="GridOIC" runat="server" CssClass="table table-bordered tblhieght " OnRowCommand="GridOIC_RowCommand" AutoGenerateColumns="false">
                                                        <Columns>
                                                            <asp:TemplateField Visible="false" HeaderText="Sno.">
                                                                <ItemTemplate>
                                                                    <%#(Container.DataItemIndex+1) %>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderStyle-CssClass="tblhd" HeaderText="पत्र क्रमांक">
                                                                <ItemTemplate>
                                                                    <%# Eval("OICLetterNo") %>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-CssClass="tblhd" HeaderText="दिनांक">
                                                                <ItemTemplate>
                                                                    <%# Eval("OICLetterDate") %>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-CssClass="tblhd" HeaderText="नाम">
                                                                <ItemTemplate>
                                                                    <%# Eval("OICName") %>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-CssClass="tblhd" HeaderText="पता">
                                                                <ItemTemplate>
                                                                    <%# Eval("OICAddress") %>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="मिटाये" HeaderStyle-CssClass="tblhd">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="OICDel" runat="server" ForeColor="red" CommandName="RecordDel" CommandArgument='<%#(Container.DataItemIndex) %>' Text="Delete"></asp:LinkButton>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>


                                                </div>

                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>

                                </div>




                                <div class="col-sm-6">

                                    <asp:UpdatePanel ID="upd3" runat="server">
                                        <ContentTemplate>
                                            <div class="col-xs-12" style="padding-top: 11px">
                                                <div class="row" style="color: #3c8dbc;">
                                                    <h5><strong>अभिभाषक की नियुक्ति(Advocate)</strong></h5>
                                                    <hr />
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-sm-6 col-xs-12">
                                                    <div class="form-group">
                                                        <label class="col-sm-12 col-xs-12">पत्र क्रमांक<i class="Star"> </i></label>
                                                        <div class="col-sm-12 col-xs-12">
                                                            <asp:TextBox ID="txtAdvoLetterNo" runat="server" MaxLength="6" placeholder="पत्र क्रमांक" CssClass="form-control form-control-xs text-uppercase grpint1" />
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="txtAdvoLetterNo" ValidationGroup="AddAdvocate" ForeColor="Red" Display="Dynamic" ErrorMessage="पत्र क्रमांक दर्ज करे" CssClass="errorMsg"></asp:RequiredFieldValidator>

                                                            <asp:TextBox ID="txtAdvoLetterDate" runat="server" MaxLength="10" placeholder="दिनांक" CssClass="form-control form-control-xs text-uppercase grpint2 datepickermaxtoday" />
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ForeColor="Red" SetFocusOnError="true" CssClass="errorMsg-r" ControlToValidate="txtAdvoLetterDate" ValidationExpression="^(((((0[1-9])|(1\d)|(2[0-8]))[/]((0[1-9])|(1[0-2])))|((31[/]((0[13578])|(1[02])))|((29|30)[/]((0[1,3-9])|(1[0-2])))))[/]((20[0-9][0-9]))|(29[/]02[/]20(([02468][048])|([13579][26]))))$" ErrorMessage="Invalid date format." ValidationGroup="AddAdvocate" />
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="txtAdvoLetterDate" ValidationGroup="AddAdvocate" ForeColor="Red" Display="Dynamic" ErrorMessage="दिनाक दर्ज करे" CssClass="errorMsg-r"></asp:RequiredFieldValidator>

                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="col-sm-6 col-xs-12">
                                                    <div class="form-group">
                                                        <label class="col-sm-12 col-xs-12">नाम<i class="Star"> </i></label>
                                                        <div class="col-sm-12 col-xs-12">

                                                            <asp:DropDownList ID="ddlAdvoName" runat="server" CssClass="form-control form-control-xs">
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="ddlAdvoName" ValidationGroup="AddAdvocate" ForeColor="Red" InitialValue="0" Display="Dynamic" ErrorMessage="नाम चुने "></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-sm-9 col-xs-12">
                                                    <div class="form-group">
                                                        <label class="col-sm-12 col-xs-12">पता<i class="Star"> </i></label>
                                                        <div class="col-sm-12 col-xs-12">
                                                            <%--<textarea style="width: 100%;height:35px;" class="form-control" ></textarea>--%>
                                                            <asp:TextBox ID="txtAdvoAddress" runat="server" Style="width: 100%; height: 35px;" MaxLength="150" TextMode="MultiLine" class="form-control"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="txtAdvoAddress" ValidationGroup="AddAdvocate" ForeColor="Red" Display="Dynamic" ErrorMessage=" पता दर्ज करे "></asp:RequiredFieldValidator>

                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-sm-2 col-xs-12 text-center">
                                                    <div class="form-group">
                                                        <label class="col-sm-12 col-xs-12">&nbsp;</label>
                                                        <div class="col-sm-12 col-xs-12">
                                                            <asp:Button ID="btnAdvocateAdd" Text="Add Advocate" ValidationGroup="AddAdvocate" runat="server" OnClick="btnAdvocateAdd_Click" CssClass="btn btn-primary" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="row">

                                                <div class="col-sm-12 ">


                                                    <asp:GridView ID="GridAdvo" runat="server" CssClass="table table-bordered tblhieght " OnRowCommand="GridAdvo_RowCommand" AutoGenerateColumns="false">
                                                        <Columns>
                                                            <asp:TemplateField Visible="false" HeaderText="Sno.">
                                                                <ItemTemplate>
                                                                    <%#(Container.DataItemIndex+1) %>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderStyle-CssClass="tblhd" HeaderText="पत्र क्रमांक">
                                                                <ItemTemplate>
                                                                    <%# Eval("AdvoLetterNo") %>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-CssClass="tblhd" HeaderText="दिनांक">
                                                                <ItemTemplate>
                                                                    <%# Eval("AdvoLetterDate") %>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-CssClass="tblhd" HeaderText="नाम">
                                                                <ItemTemplate>
                                                                    <%# Eval("AdvoName") %>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-CssClass="tblhd" HeaderText="पता">
                                                                <ItemTemplate>
                                                                    <%# Eval("AdvoAddress") %>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="मिटाये" HeaderStyle-CssClass="tblhd">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="AdvoDel" runat="server" ForeColor="red" CommandName="RecordDel" CommandArgument='<%#(Container.DataItemIndex) %>' Text="Delete"></asp:LinkButton>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>


                                                </div>

                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>

                                </div>

                            </div>
                        </div>

                    </div>



                    <div class="panel panel-default">
                        <div id="sthittihdr" runat="server" class="panel-heading entryMst-collapse collapsed pointer" data-toggle="collapse" data-parent="#accordion" data-target="#ContentPlaceHolder1_sthitti">
                            <a class="panel-title hdclr"><i class="fa" aria-hidden="true"></i>स्थिति</a>
                        </div>
                        <asp:UpdatePanel ID="upd" runat="server">
                            <ContentTemplate>
                                 <div id="sthitti" runat="server" class="panel-collapse collapse  p10">
                            <div class="row">


                                <div class="col-sm-2 col-xs-12">
                                    <div class="form-group">
                                        <label class="col-sm-12 col-xs-12">वित्तीय भार (रू)<i class="Star"> </i></label>
                                        <div class="col-sm-12 col-xs-12">
                                            <asp:TextBox runat="server" MaxLength="8" placeholder="वित्तीय भार दर्ज" CssClass="form-control form-control-xs text-uppercase" ID="txtfinancialburden" />
                                              <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server" TargetControlID="txtfinancialburden" FilterType="Numbers" ValidChars=" " />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ControlToValidate="txtfinancialburden" ValidationGroup="a" ForeColor="Red" Display="Dynamic" ErrorMessage=" वित्तीय भार दर्ज करे "></asp:RequiredFieldValidator>

                                        </div>
                                    </div>
                                </div>

                                <div class="col-sm-2 col-xs-12">
                                    <div class="form-group">
                                        <label class="col-sm-12 col-xs-12">जवाब का प्रकार<i class="Star"> </i></label>
                                        <div class="col-sm-12 col-xs-12">
                                            <asp:DropDownList ID="ddlReplyType" runat="server" CssClass="form-control form-control-xs">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" ControlToValidate="ddlReplyType" ValidationGroup="a" ForeColor="Red" Display="Dynamic" InitialValue="0" ErrorMessage=" जवाब का प्रकार चुने  "></asp:RequiredFieldValidator>

                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-2 col-xs-12">
                                    <div class="form-group">
                                        <label class="col-sm-12 col-xs-12">जवाब प्रस्तुत करने की दिनांक<i class="Star"> </i></label>
                                        <div class="col-sm-12 col-xs-12">
                                            <asp:TextBox runat="server" MaxLength="10" placeholder="DD/MM/YY" CssClass="form-control form-control-xs text-uppercase datepickermintoday" ID="txtreplydate" />
                                              <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ForeColor="Red" SetFocusOnError="true" CssClass="errorMsg-r" ControlToValidate="txtreplydate" ValidationExpression="^(((((0[1-9])|(1\d)|(2[0-8]))[/]((0[1-9])|(1[0-2])))|((31[/]((0[13578])|(1[02])))|((29|30)[/]((0[1,3-9])|(1[0-2])))))[/]((20[0-9][0-9]))|(29[/]02[/]20(([02468][048])|([13579][26]))))$" ErrorMessage="Invalid date format." ValidationGroup="a" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator26" runat="server" ControlToValidate="txtreplydate" ValidationGroup="a"
                                                ForeColor="Red" Display="Dynamic" ErrorMessage=" जवाब का प्रकार दर्ज करे  "></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                               <%-- <div class="col-sm-2 col-xs-12" >
                                    <div class="form-group">
                                        <label class="col-sm-12 col-xs-12">आगामी पेशी दिनांक</label>
                                        <div class="col-sm-12 col-xs-12">
                                            <asp:TextBox runat="server" MaxLength="10" placeholder="DD/MM/YY" CssClass="form-control form-control-xs text-uppercase datepickermintoday" ID="txtnexthdate" />
                                             <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ForeColor="Red" SetFocusOnError="true" CssClass="errorMsg-r" ControlToValidate="txtnexthdate" ValidationExpression="^(((((0[1-9])|(1\d)|(2[0-8]))[/]((0[1-9])|(1[0-2])))|((31[/]((0[13578])|(1[02])))|((29|30)[/]((0[1,3-9])|(1[0-2])))))[/]((20[0-9][0-9]))|(29[/]02[/]20(([02468][048])|([13579][26]))))$" ErrorMessage="Invalid date format." ValidationGroup="a" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator27" runat="server"  ControlToValidate="txtnexthdate" ValidationGroup="a" ForeColor="Red" Display="Dynamic" ErrorMessage=" आगामी पेशी दिनांक दर्ज करे  "></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>--%>

                                <div class="col-sm-2 col-xs-12">
                                    <div class="form-group">
                                        <label class="col-sm-12 col-xs-12">प्रकरण की स्थिति</label>
                                        <div class="col-sm-12 col-xs-12">
                                            <asp:DropDownList ID="ddlCaseStage" runat="server" CssClass="form-control form-control-xs">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator28" runat="server" ControlToValidate="ddlCaseStage" ValidationGroup="a" ForeColor="Red" Display="Dynamic" InitialValue="0" ErrorMessage="प्रकरण की स्थिति चुने "></asp:RequiredFieldValidator>
                                        </div> 
                                    </div>
                                </div>

                                <div class="col-sm-2 col-xs-12">
                                    <div class="form-group">
                                        <label class="col-sm-12 col-xs-12">जवाब प्रस्तुत हुआ या नहीं</label>
                                        <div class="col-sm-12 col-xs-12 rdo">
                                           <%-- <asp:RadioButton Text="हां" ID="rdbyes" runat="server"  GroupName="rd" Checked="true" />
                                            <asp:RadioButton Text="नहीं" ID="rdbNo" runat="server"  GroupName="rd" />--%>

                                            <asp:RadioButtonList ID="rdblist" runat="server" RepeatDirection="Horizontal">
                                                <asp:ListItem Value="हां" Selected="True">हां</asp:ListItem>
                                                <asp:ListItem Value="नहीं">नहीं</asp:ListItem>
                                            </asp:RadioButtonList>

                                        </div>
                                    </div>
                                </div>


                                 <div class="col-sm-2 col-xs-12">
                                    <div class="form-group">
                                        <label class="col-sm-12 col-xs-12">लास्ट दिनाँक</label>
                                        <div class="col-sm-12 col-xs-12">
                                             <asp:TextBox  ID="txtlastdate" runat="server" MaxLength="10" placeholder="DD/MM/YY" CssClass="form-control form-control-xs text-uppercase datepicker" />

                                        </div>
                                    </div>
                                </div>





                            </div>

                            <div class="row">


                                <div class="col-sm-2 col-xs-12">
                                    <div class="form-group">
                                        <label class="col-sm-12 col-xs-12">आदेश का प्रकार<i class="Star"> </i></label>
                                        <div class="col-sm-12 col-xs-12">
                                            <asp:DropDownList runat="server" ID="ddlOrderType" CssClass="form-control form-control-xs">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator29" runat="server" ControlToValidate="ddlOrderType" ValidationGroup="a" ForeColor="Red" Display="Dynamic" InitialValue="0" ErrorMessage="आदेश का प्रकार चुने "></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-4 col-xs-12">
                                    <div class="form-group">
                                        <label class="col-sm-12 col-xs-12">आदेश का विवरण <i class="Star"></i></label>
                                        <div class="col-sm-12 col-xs-12">
                                            <asp:TextBox runat="server" MaxLength="160" placeholder="आदेश का विवरण " CssClass="form-control form-control-xs text-uppercase" ID="txtOrderDesc" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator30" runat="server" ControlToValidate="txtOrderDesc" ValidationGroup="a" ForeColor="Red" Display="Dynamic" ErrorMessage="आदेश का विवरण  दर्ज करे"></asp:RequiredFieldValidator>

                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-2 col-xs-12">
                                    <div class="form-group">
                                        <label class="col-sm-12 col-xs-12">आदेश दिनांक<i class="Star"> </i></label>
                                        <div class="col-sm-12 col-xs-12">
                                            <asp:TextBox runat="server" MaxLength="10" placeholder="दिनांक" CssClass="form-control form-control-xs text-uppercase datepickermintoday" ID="txtorderdate" />
                                             <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ForeColor="Red" SetFocusOnError="true" CssClass="errorMsg-r" ControlToValidate="txtorderdate" ValidationExpression="^(((((0[1-9])|(1\d)|(2[0-8]))[/]((0[1-9])|(1[0-2])))|((31[/]((0[13578])|(1[02])))|((29|30)[/]((0[1,3-9])|(1[0-2])))))[/]((20[0-9][0-9]))|(29[/]02[/]20(([02468][048])|([13579][26]))))$" ErrorMessage="Invalid date format." ValidationGroup="a" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator31" runat="server" ControlToValidate="txtorderdate" ValidationGroup="a" ForeColor="Red" Display="Dynamic" ErrorMessage="आदेश दिनांक दर्ज करे"></asp:RequiredFieldValidator>

                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-2 col-xs-12">
                                    <div class="form-group">
                                        <label class="col-sm-12 col-xs-12">अंतिम निर्णय विवरण<i class="Star"> </i></label>
                                        <div class="col-sm-12 col-xs-12">
                                            <asp:TextBox ID="txtlastDecision" runat="server" MaxLength="60" Style="width: 100%; height: 35px;" class="form-control"></asp:TextBox>

                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator32" runat="server" ControlToValidate="txtlastDecision" ValidationGroup="a" ForeColor="Red" Display="Dynamic" ErrorMessage="अंतिम निर्णय विवरण दर्ज करे"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-2 col-xs-12">
                                    <div class="form-group">
                                        <label class="col-sm-12 col-xs-12">अन्य कोई विशेष</label>
                                        <div class="col-sm-12 col-xs-12">
                                            <asp:TextBox ID="txtRemark" runat="server" MaxLength="150" Style="width: 100%; height: 35px;" CssClass="form-control"></asp:TextBox>

                                        </div>
                                    </div>
                                </div>

                            </div>



                        </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                       

                    </div>

                </div>
            </div>


            <div class="panel-footer">
                <asp:Button ID="btnSave" Text="Save" runat="server" ValidationGroup="a" OnClick="btnSave_Click" CssClass="btn btn-success btnSave" />
                <asp:Button ID="btnClear" Text="Clear" OnClick="btnClear_Click" runat="server" CssClass="btn btn-warning btnClear" />
                <asp:Button ID="btnExit" runat="server" OnClick="btnExit_Click" CssClass="btn btn-danger" Text="Exit" />
                <div class="alertMsg success" runat="server" id="pnlSuccess"></div>
                <div class="alertMsg failed" runat="server" id="pnlfailed"></div>

            </div>
        </div>
    </div>

</asp:Content>

