<%@ Page Title="" Language="C#" MasterPageFile="~/Estate/MainMaster.master" AutoEventWireup="true" CodeFile="frmSchMaster.aspx.cs" Inherits="Master_frmSchMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <script type="text/javascript" src="https://www.google.com/jsapi">
    </script>
    <script type="text/javascript" src="https://www.google.com/jsapi">
    </script>
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

            control.makeTransliteratable(['<%=txtSchNameH.ClientID%>']);
        }
        google.setOnLoadCallback(onLoad);

    </script>

    <div class="col-sm-10 col-sm-offset-1">
        <div class="panel panel-primary mt10">
            <div class="panel-heading">
                <h3 class="panel-title">Scheme Master</h3>
            </div>
            <div class="panel-body form-horizontal scheme-form-group">
                <div class="form-group">
                    <div class="row">
                        <div class="col-xs-12 col-sm-6">
                            <label class="col-xs-12 col-sm-5 required">Scheme Name English</label>
                            <div class="col-xs-12 col-sm-7">
                                <asp:TextBox runat="server" ID="txtSchNameE" MaxLength="70" placeholder="Scheme Name English" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator SetFocusOnError="true" CssClass="errorMsg" ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtSchNameE" ErrorMessage="Enter Scheme Name English" ForeColor="Red" ValidationGroup="a"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-xs-12 col-sm-6">
                            <style>
                                .ui-datepicker {
                                    z-index:99 !important;
                                }
                            </style>
                            <label class="col-xs-12 col-sm-5 required control-label">Scheme Name Hindi</label>
                            <div class="col-xs-12 col-sm-7">
                                <asp:TextBox runat="server" ID="txtSchNameH" MaxLength="200" placeholder="Scheme Name Hindi" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator SetFocusOnError="true" CssClass="errorMsg" ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtSchNameH" ErrorMessage="Enter Scheme Name Hindi" ForeColor="Red" ValidationGroup="a"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                </div>
                <style>
                    .sm_20 .sm_80 {
                        float: left;
                    }

                    .sm_20 {
                        width: 20%;
                    }

                    .sm_80 {
                        width: 80%;
                    }
                </style>
                <div class="form-group">
                    <div class="row">
                        <div class="col-xs-12 col-sm-12">
                            <label class="col-xs-12 col-sm-5 sm_20">Scheme Location</label>
                            <div class="col-xs-12 col-sm-7 sm_80">
                                <asp:TextBox runat="server" ID="txtSchLoc" CssClass="form-control" MaxLength="50" placeholder="Scheme Location"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <div class="row">
                        <div class="col-xs-12 col-sm-6">
                            <label class="col-xs-12 col-sm-5 required">Scheme Use Type</label>
                            <div class="col-xs-12 col-sm-7">
                                <asp:DropDownList ID="ddlSchUseType" runat="server" CssClass="form-control">
                                </asp:DropDownList>
                                <asp:CompareValidator CssClass="errorMsg" ForeColor="Red" SetFocusOnError="true" ErrorMessage="Select Scheme Use Type" runat="server" ID="comparevalidator3" ValidationGroup="a" ControlToValidate="ddlSchUseType" ValueToCompare="0" Operator="NotEqual"></asp:CompareValidator>
                                <%-- <asp:RequiredFieldValidator SetFocusOnError="true" CssClass="errorMsg" ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlSchUseType" ErrorMessage="Select Scheme Use Type" ForeColor="Red" ValidationGroup="a"></asp:RequiredFieldValidator>             --%>
                            </div>
                        </div>
                        <div class="col-xs-12 col-sm-6">
                            <label class="control-label col-xs-12 col-sm-5 required">Scheme No</label>
                            <div class="col-xs-12 col-sm-7">
                                <asp:TextBox ID="txtSchNo" runat="server" CssClass="form-control" placeholder="Scheme No" MaxLength="20"></asp:TextBox>
                                <asp:RequiredFieldValidator SetFocusOnError="true" CssClass="errorMsg" ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtSchNo" ErrorMessage="Enter Scheme No" ForeColor="Red" ValidationGroup="a"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="form-group">
                    <div class="row">
                        <div class="col-xs-12 col-sm-6">
                            <label class="col-xs-12 col-sm-5">Scheme&nbsp;Develope&nbsp;Category</label>
                            <div class="col-xs-12 col-sm-7">
                                <asp:DropDownList ID="ddlSchDevCat" runat="server" CssClass="form-control">
                                </asp:DropDownList>
                                <%--    <asp:CompareValidator CssClass="errorMsg" ForeColor="Red" SetFocusOnError="true" ErrorMessage="Select Scheme Develop Category" runat="server" ID="comparevalidator1" ValidationGroup="a" ControlToValidate="ddlSchDevCat" ValueToCompare="0" Operator="NotEqual"></asp:CompareValidator>--%>
                            </div>
                        </div>
                        <div class="col-xs-12 col-sm-6">
                            <label class="control-label col-xs-12 col-sm-5">Scheme Develop</label>
                            <div class="col-xs-12 col-sm-7">
                                <asp:DropDownList ID="ddlSchDev" runat="server" CssClass="form-control">
                                </asp:DropDownList>
                             <%--     <asp:CompareValidator CssClass="errorMsg" ForeColor="Red" SetFocusOnError="true" ErrorMessage="Select Scheme Develop" runat="server" ID="comparevalidator2" ValidationGroup="a" ControlToValidate="ddlSchDev" ValueToCompare="0" Operator="NotEqual"></asp:CompareValidator>--%>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="form-group">
                    <div class="row">
                        <div class="col-xs-12 col-sm-6">
                            <label class="col-xs-12 col-sm-5">Approval No</label>
                            <div class="col-xs-12 col-sm-7">
                                <asp:TextBox ID="txtAppno" runat="server" placeholder="Approval No" MaxLength="20" CssClass="form-control"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server" TargetControlID="txtAppno" FilterMode="ValidChars" FilterType="Numbers" />
                            </div>
                        </div>
                        <div class="col-xs-12 col-sm-6">
                            <label class="control-label col-xs-12 col-sm-5">Approval Date</label>
                            <div class="col-xs-12 col-sm-7">
                                <asp:TextBox runat="server" data-date-format="dd/mm/yyyy" CssClass="form-control datepicker" ID="txtAppDate" placeholder="DD/MM/YYYY" />
                                <asp:RegularExpressionValidator ForeColor="Red" CssClass="text-danger errorMsg validation_error" ValidationGroup="validate" ID="RegularExpressionValidator4" runat="server" SetFocusOnError="true" ControlToValidate="txtAppDate" ErrorMessage="Enter Correct Approval Date" ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[-/.](0[1-9]|1[012])[-/.](19|20)\d\d$"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="form-group">
                    <div class="row">
                        <div class="col-xs-12 col-sm-6">
                            <label class="col-xs-12 col-sm-5">Approval By</label>
                            <div class="col-xs-12 col-sm-7">
                                <asp:TextBox ID="txtAppby" runat="server" MaxLength="70" placeholder="Approval By" CssClass="form-control"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txtAppby" FilterMode="ValidChars" FilterType="UppercaseLetters,LowercaseLetters,Custom" ValidChars=" " />
                            </div>
                        </div>
                         <div class="col-xs-12 col-sm-6">
                            <label class="col-xs-12 col-sm-5 required control-label">IDASchNo</label>
                            <div class="col-xs-12 col-sm-7">
                                <asp:TextBox ID="txtIDASchNo" runat="server" MaxLength="4" placeholder="IDA SchNo" CssClass="form-control"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" TargetControlID="txtIDASchNo" FilterMode="ValidChars" FilterType="Numbers" ValidChars=" " />
                            <asp:RequiredFieldValidator SetFocusOnError="true" CssClass="errorMsg" ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtIDASchNo" ErrorMessage="Enter IDA SchNo" ForeColor="Red" ValidationGroup="a"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="form-group">
                    <div class="row">
                        <div class="col-xs-12 col-sm-6">
                            <label class="col-xs-12 col-sm-5">Total Scheme Area</label>
                            <div class="col-xs-12 col-sm-7">
                                <div class="input-group">
                                    <asp:TextBox ID="txtTotalSchArea" runat="server" MaxLength="10" placeholder="Total Scheme Area" CssClass="form-control"></asp:TextBox>
                                    <span class="input-group-addon">Sq. Yard</span>
                                </div>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtTotalSchArea" FilterMode="ValidChars" FilterType="Numbers" ValidChars=" " />
                            </div>

                        </div>
                        <div class="col-xs-12 col-sm-6">
                            <label class="col-xs-12 col-sm-5 control-label">Total Ploting Area</label>
                            <div class="col-xs-12 col-sm-7">
                                <div class="input-group">
                                    <asp:TextBox ID="txtTotalPlotArea" runat="server" MaxLength="10" placeholder="Total Ploting Area" CssClass="form-control"></asp:TextBox>
                                    <span class="input-group-addon">Sq. Yard</span>
                                </div>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtTotalPlotArea" FilterMode="ValidChars" FilterType="Numbers" ValidChars=" " />
                            </div>
                        </div>
                    </div>
                </div>

                <style>
                    .rdo label{
                        margin-right:10px;
                    }
                </style>

                  <div class="form-group">
                    <div class="row">
                        <div class="col-xs-12 col-sm-6">
                            <label class="col-xs-12 col-sm-5">Sector Available</label>
                            <div class="col-xs-12 col-sm-7 rdo">
                              <asp:RadioButtonList runat="server" RepeatDirection="Horizontal" ID="rdbSectorAval">
                                  <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                                  <asp:ListItem Text="No" Value ="0" Selected="True"></asp:ListItem>
                              </asp:RadioButtonList>
                            </div>
                        </div>
                        <div class="col-xs-12 col-sm-6">
                            <label class="control-label col-xs-12 col-sm-5">Plot Category Type Available</label>
                            <div class="col-xs-12 col-sm-7 rdo">
                              <asp:RadioButtonList runat="server" RepeatDirection="Horizontal"  ID="rdbPlotAval">
                                  <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                                  <asp:ListItem Text="No" Value="0" Selected="True"></asp:ListItem>
                              </asp:RadioButtonList>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="panel-footer">
                <asp:Button ID="Button1" Text="Save" runat="server" ValidationGroup="a" OnClick="btnSave_Click" CssClass="btn btn-success btnSave" />
                <asp:Button ID="Button2" Text="Clear" runat="server" OnClick="btnclear_Click" CssClass="btn btn-default btnClear" />
                <asp:Button ID="Button3" runat="server" PostBackUrl="Dashboard.aspx" CssClass="btn btn-danger" Text="Exit" />
                <div class="alertMsg success" runat="server" id="pnlSuccess"></div>
                <div class="alertMsg failed" runat="server" id="pnlfailed"></div>
            </div>
        </div>
    </div>


</asp:Content>

