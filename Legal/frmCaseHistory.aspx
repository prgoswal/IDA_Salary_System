<%@ Page Title="" Language="C#" MasterPageFile="~/Legal/LegalMaster.master" AutoEventWireup="true" CodeFile="frmCaseHistory.aspx.cs" Inherits="frmCaseHistory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script>

        function onLoad() {

            var date = new Date();
            $('.datepickermaxtoday').datepicker({ dateFormat: 'dd/mm/yy', maxDate: date });
            $('.datepickermintoday').datepicker({ dateFormat: 'dd/mm/yy', minDate: date });
            $('.datepicker').datepicker({ dateFormat: 'dd/mm/yy' });
            $('.datepicker').each(function () {
                $(this).attr('placeholder', 'DD/MM/YYYY');
            });

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
        .radio-inline-casehistory {
            padding-top:8px
        }
        .radio-inline-casehistory input, .radio-inline-casehistory label {
            display:block;
            float:left;
            font-weight:normal;
            cursor:pointer;
            user-select:none
        }
         .radio-inline-casehistory input{
            margin:0;
            margin-right:1px
        } 
         .radio-inline-casehistory input:checked + label {
           font-weight:bold
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:ScriptManager ID="scr1" runat="server"></asp:ScriptManager>
    <script type="text/javascript" lang="javascript">
        Sys.Application.add_load(onLoad);
    </script>
    <asp:UpdatePanel ID="upd1" runat="server">
        <ContentTemplate>
            <div class="mrgntp10" style="margin-left: auto;margin-right: auto;max-width: 920px;">
                <div class="panel panel-primary form-horizontal">
                    <div class="panel-heading">Case History</div>
                    <div class="panel-body">
                        <div class="panel-group acrdn_pnl">
                           
                            <div class="row">
                                <div class="col-xs-12 col-sm-2 radio-inline-casehistory">
                                    <asp:RadioButton ID="rdb_SuitNoAndDatewise" runat="server" Checked="true" OnCheckedChanged="rdb_SuitNoAndDatewise_CheckedChanged" AutoPostBack="true" Text="Suitno and datewise" GroupName="g1" />
                                </div>
                                <div class="col-xs-12 col-sm-5">
                                    <div class="form-group">
                                        <label class="col-sm-3 col-xs-12 control-label">Suit No<i class="Star"> </i></label>
                                       
                                        <div class="col-sm-9 col-xs-12">
                                            <asp:TextBox ID="txt_Suitno" runat="server" MaxLength="12" class="form-control form-control-xs"></asp:TextBox>

                                        </div>
                                    </div>
                                </div>
                                <div class="col-xs-12 col-sm-5">
                                    <div class="form-group">
                                        <label class="col-sm-3 col-xs-12 control-label">Suit Date<i class="Star"> </i></label>
                                        
                                        <div class="col-sm-9 col-xs-12">
                                            <asp:TextBox ID="txt_Suitdate" runat="server" class="form-control form-control-xs datepicker"></asp:TextBox>

                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ForeColor="Red" SetFocusOnError="true" CssClass="errorMsg-r" ControlToValidate="txt_Suitdate" ValidationExpression="^(((((0[1-9])|(1\d)|(2[0-8]))[/]((0[1-9])|(1[0-2])))|((31[/]((0[13578])|(1[02])))|((29|30)[/]((0[1,3-9])|(1[0-2])))))[/]((20[0-9][0-9]))|(29[/]02[/]20(([02468][048])|([13579][26]))))$" ErrorMessage="Invalid date format." ValidationGroup="s" />

                                        </div>
                                               
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-xs-12 col-sm-2 radio-inline-casehistory">
                                    <asp:RadioButton ID="rdb_casehearingdate" runat="server" OnCheckedChanged="rdb_casehearingdate_CheckedChanged" AutoPostBack="true" Text="Case Hearing Date" GroupName="g1" />
                                </div>
                                <div class="col-xs-12 col-sm-5">
                                    <div class="form-group">
                                        <label class="col-sm-3 col-xs-12 control-label">From<i class="Star"> </i></label>
                                        <div class="col-sm-9 col-xs-12">
                                            <asp:TextBox ID="txt_from" runat="server" class="form-control form-control-xs datepicker"></asp:TextBox></div>

                                          <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ForeColor="Red" SetFocusOnError="true" CssClass="errorMsg-r" ControlToValidate="txt_from" ValidationExpression="^(((((0[1-9])|(1\d)|(2[0-8]))[/]((0[1-9])|(1[0-2])))|((31[/]((0[13578])|(1[02])))|((29|30)[/]((0[1,3-9])|(1[0-2])))))[/]((20[0-9][0-9]))|(29[/]02[/]20(([02468][048])|([13579][26]))))$" ErrorMessage="Invalid date format." ValidationGroup="s" />
                                       
                                    </div>
                                </div>
                                <div class="col-xs-12 col-sm-5">
                                    <div class="form-group">
                                        <label class="col-sm-3 col-xs-12 control-label">To<i class="Star"> </i></label>
                                        <div class="col-sm-9 col-xs-12">
                                            <asp:TextBox ID="txt_To" runat="server" class="form-control form-control-xs datepicker"></asp:TextBox></div>

                                         <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ForeColor="Red" SetFocusOnError="true" CssClass="errorMsg-r" ControlToValidate="txt_To" ValidationExpression="^(((((0[1-9])|(1\d)|(2[0-8]))[/]((0[1-9])|(1[0-2])))|((31[/]((0[13578])|(1[02])))|((29|30)[/]((0[1,3-9])|(1[0-2])))))[/]((20[0-9][0-9]))|(29[/]02[/]20(([02468][048])|([13579][26]))))$" ErrorMessage="Invalid date format." ValidationGroup="s" />
                                       
                                    </div>
                                </div>
                            </div>

                            <asp:GridView ID="dgv_caseHistroy" runat="server" AutoGenerateColumns="false" CssClass="table table-responsive table-bordered table-hover" HeaderStyle-BackColor="#006699" HeaderStyle-ForeColor="white">

                                <Columns>
                                    <asp:TemplateField HeaderText="Sr.No " >
                                      <ItemTemplate >
                                       <%#Container.DataItemIndex+1 %>
                                      </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:BoundField DataField="SuitRegNo" HeaderText="Suit No  " />
                                    <asp:BoundField DataField="CaseNo" HeaderText="Case No " />
                                    <asp:BoundField DataField="SuitRegDate" HeaderText="Suit Date " />

                                    <asp:BoundField DataField="NextHDate" HeaderText="Hearing Date " />
                                    <asp:BoundField DataField="CaseStageDescH" HeaderText="Case Stage" />
                                    <asp:BoundField DataField="AdvoName" HeaderText="Advocate Name  " />
                               
                                </Columns>
                            </asp:GridView>

                        </div>
                    </div>

                    <div class="panel-footer">
                         <asp:Button ID="btnSearch" runat="server" ValidationGroup="s" Text="Search" CssClass="btn btn-success btnSearch" OnClick="btnSearch_Click" />
                        <asp:Button ID="btnclear" runat="server" Text="Clear" CssClass="btn btn-warning btnclear" OnClick="btnclear_Click" />
                        <asp:Button ID="btnExit" runat="server" PostBackUrl="~/Legal/Dashboard.aspx" Text="Exit" CssClass="btn btn-danger" />

                        <div class="alertMsg success" runat="server" id="pnlSuccess"></div>
                        <div class="alertMsg failed" runat="server" id="pnlfailed"></div>
                    </div>

                </div>
            </div>
            </ContentTemplate>
        </asp:UpdatePanel>
      
</asp:Content>

