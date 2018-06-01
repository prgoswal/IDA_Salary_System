<%@ Page Title="" EnableEventValidation="false" Language="C#" MasterPageFile="~/Estate/MainMaster.master" AutoEventWireup="true" CodeFile="frmPropertyMatser.aspx.cs" Inherits="frmPropertyMatser" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=14.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <script>
        function OpenEditModal() {
            $('#propertyEditModal').modal('show');
        }
    </script>
      <script>
          function OpenLedgerModal() {
              $('#LedgerModal').modal('show');
          }
    </script>
    <style>
        @font-face {
            font-family: kruti dev;
            src: url("<%= ResolveUrl("~/Content/fonts/Kruti_Dev_010.TTF")%>") format("truetype");
        }

        .hindi {
            font-family: kruti dev;
            font-size: 18px;
        }
    </style>
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

        .tbl_hd {
            background-color: #3c8dbc;
            color: #fff;
        }

        .td-padding-0 tr th {
            padding: 5px !important;
        }

        .td-padding-0 tr td {
            padding: 0px !important;
        }

            .td-padding-0 tr td .btn {
                padding: 1px 4px !important;
            }

            .td-padding-0 tr td input, .td-padding-0 tr td select {
                border: 0 !important;
                border-radius: 0;
                padding: 3px 2px;
                height: 30px;
            }

                .td-padding-0 tr td input:focus, .td-padding-0 tr td select:focus {
                    outline: 1px solid #ddd !important;
                    box-shadow: none;
                }

        .brk-all {
            word-break: break-all;
        }

        .modal-header-theme {
            background: #3c8dbc;
            color: #fff;
            border-top-left-radius: 4px;
            border-top-right-radius: 4px;
        }

        .propertyEditModal {
            padding-right: 0 !Important;
        }

            .propertyEditModal .modal-dialog {
                width: 85%;
                margin-top: 50px;                
            }
             .LedgerModal {
            padding-right: 0 !Important;
        }

            .LedgerModal .modal-dialog {
                width: 85%;
                margin-top: 50px;                
            }

        .form-horizontal-label-left .control-label {
            text-align: left;
        }
    </style>
    <div class="col-sm-12 col-sm-offset-0">
        <div class="panel panel-primary mt10">
            <div class="panel-heading">
                <h3 class="panel-title">Property Master</h3>
            </div>
            <div class="panel-body form-horizontal scheme-form-group">
                
                    <div class="row">
                        <div class="col-xs-12 col-sm-4">                         
                            <label class="col-xs-12 col-sm-4 required control-label" style="white-space:nowrap">Scheme&nbsp;Name</label>
                            <div class="col-xs-12 col-sm-8">
                                <asp:DropDownList runat="server" ID="ddlSchName" OnSelectedIndexChanged="ddlSchName_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control chzn-select"></asp:DropDownList>
                                <%--<asp:CompareValidator CssClass="errorMsg" ForeColor="Red" SetFocusOnError="true" ErrorMessage="Select Scheme Name" runat="server" ID="comparevalidator1" ValidationGroup="save" ControlToValidate="ddlSchName" ValueToCompare="0" Operator="NotEqual"></asp:CompareValidator>--%>
                           <asp:Label runat="server" ID="lblTplot"><b>Total Plot :  </b></asp:Label><asp:Label runat="server" ID="lblSchName"></asp:Label>
                                  </div>
                                </div>
                         <div class="col-xs-12 col-sm-3">                         
                            <label class="col-xs-12 col-sm-4 required control-label">IDA RefNo.</label>
                            <div class="col-xs-12 col-sm-8">
                               <asp:TextBox runat="server" ID="txtIDARefNumber" CssClass="form-control" MaxLength="10"></asp:TextBox>
                                 <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server" TargetControlID="txtIDARefNumber" FilterMode="ValidChars" FilterType="Numbers" />
                            </div>
                                </div>                                     
                        <div class="col-xs-12 col-sm-3">
                             <div class="form-group">
                            <label class="col-xs-12 col-sm-4  required control-label">Validity</label>
                            <div class="col-xs-12 col-sm-8">
                                <asp:DropDownList runat="server" ID="ddlValidity" OnSelectedIndexChanged="ddlValidity_SelectedIndexChanged"  AutoPostBack="true" CssClass="form-control"></asp:DropDownList>                             
                            </div>
                                 </div>
                        </div>       
                               
                         <div class="col-xs-12 col-sm-2 text-right">                            
                            <asp:LinkButton runat="server" Text="Search" ID="btnSearch" OnClick="btnSearch_Click" CssClass="btn btn-primary"></asp:LinkButton>
                                <asp:LinkButton runat="server" Text="Clear" ID="btnCancel" OnClick="btnCancel_Click" CssClass="btn btn-danger"></asp:LinkButton>
                            
                        </div>             
                    </div>
              
                <div class="col-xs-12">
                    <div style="padding-right: 17px">
                        <table class="table table-bordered td-padding-0 brk-all" style="margin-bottom: 0px!important;">
                            <tr class="tbl_hd">                               
                                <th style="width: 15%;">
                                    IDA RefNo.<br />
                                    Service No.<br />
                                    Plot No. + Sector Name<br />
                                    Plot Use +  Plot Category
                                </th>
                              <%--  <th style="width: 08%;">Plot Use
                                    <br />
                                    Plot Category</th>--%>
                                <th style="width: 25%;">Name - Gender<br />
                                  Address
                                    <br />
                                  <%--  CAddress2 + CAddress3<br />--%>
                                    Email | Aadhaar No. | GSTNo. | Mobile No. </th>                                
                                    <%--Address Hindi 2 + Address Hindi 3</th>--%>
                                <th style="width: 15%">Plot Size(Sq. Mtr)
                                    <br />
                                    Plot Rate(Sq. Mtr)
                                    <br />
                                    Plot Cost
                                    <br />
                                    Poss. Date</th>
                                <th style="width: 12%">Delete Flag
                                    <br />
                                    Comm Date
                                    <br />
                                    Yearly Lease
                                </th>
                                <th style="width: 12%">Inst Amt.
                                    <br />paid / Total Inst
                                    <br />Inst Start Date
                                    <br />Inst Loan Amt.
                                </th>
                                     <th style="width: 13%;"></th>
                            </tr>

                        </table>

                    </div>

                </div>

                <div class="col-xs-12">
                    <div style="max-height: 500px; overflow-y: scroll;">
                        <asp:GridView ID="GvProMaster" CssClass="table table-bordered mb0 brk-all" OnRowDataBound="GvProMaster_RowDataBound" AutoGenerateColumns="false" DataKeyNames="FinalInd" ShowHeader="false" runat="server">
                            <Columns>                               
                                <asp:TemplateField ItemStyle-CssClass="clsSector" ItemStyle-Width="15%">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblIDARefNo" Text='<%#Eval("IdaRefNo") %>'></asp:Label>
                                        <br />
                                        <asp:Label runat="server" ID="lblServiceNo" Text='<%#Eval("ServiceNo") %>'></asp:Label>
                                        <br />
                                        <asp:Label runat="server" ID="lblPlotNo" Text='<%#Eval("PNoSecName") %>'></asp:Label>
                                        <br />
                                         <asp:Label runat="server" ID="lblPlotCat" Text='<%#Eval("PlotUseCat") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                               <%-- <asp:TemplateField ItemStyle-CssClass="clsSector" ItemStyle-Width="08%">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblPlotUse" Text='<%#Eval("UseDescE") %>'></asp:Label>
                                        <br />
                                        <asp:Label runat="server" ID="lblPlotCat" Text='<%#Eval("ReservCateDescE") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                                <asp:TemplateField ItemStyle-CssClass="clsSector" ItemStyle-Width="25%">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblNameGender" Text='<%#Eval("NameGender") %>'></asp:Label>
                                        <br />
                                        <asp:Label runat="server" ID="lblCAddress1" Text='<%#Eval("Address") %>'></asp:Label>
                                      <%--  <br />
                                        <asp:Label runat="server" ID="lblCAddr23" Text='<%#Eval("Add12") %>'></asp:Label>--%>
                                        <br />
                                        <asp:Label runat="server" ID="lblEAGM" Text='<%#Eval("EAGM") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%--<asp:TemplateField ItemStyle-CssClass="clsSector" ItemStyle-Width="20%">
                                    <ItemTemplate>
                                        <asp:Label runat="server" CssClass="hindi" ID="lblNameH" Text='<%#Eval("PlotHolderNameH") %>'></asp:Label>
                                        <br />
                                        <asp:Label runat="server" CssClass="hindi" ID="lblCAddre1H" Text='<%#Eval("AddressHindi") %>'></asp:Label>
                               --%>         <%--<br />
                                        <asp:Label runat="server" CssClass="hindi" ID="lblCAddrH23" Text='<%#Eval("AddHindi12") %>'></asp:Label>--%>
                                   <%-- </ItemTemplate>
                                </asp:TemplateField>--%>
                                <asp:TemplateField ItemStyle-CssClass="clsSector" ItemStyle-Width="15%">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblPlotSize" Text='<%#Eval("PossArea") %>'></asp:Label>
                                        <br />
                                        <asp:Label runat="server" ID="lblPLotRate" Text='<%#Eval("RateSqMeter") %>'></asp:Label>
                                        <br />
                                        <asp:Label runat="server" ID="lblPlotCost" Text='<%#Eval("PropCost") %>'></asp:Label>
                                        <br />
                                        <asp:Label runat="server" ID="lblPlotDate" Text='<%#Eval("PossDate") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-CssClass="clsSector" ItemStyle-Width="12%">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lbldelflag" Text='<%#Eval("IDADeleteFlag") %>'></asp:Label>
                                        <br />
                                        <asp:Label runat="server" ID="lblCommDate" Text='<%#Eval("CommDate") %>'></asp:Label>
                                        <br />
                                          <asp:Label runat="server" ID="lblRegLease" Text='<%#Eval("RegLeaseAmt") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-CssClass="clsSector" ItemStyle-Width="12%">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblInstAmount" Text='<%#Eval("InstAmount") %>'></asp:Label>
                                        <br />
                                        <asp:Label runat="server" ID="lblTotNoOfPaidInst" Text='<%#Eval("TotNoOfPaidInst") %>'></asp:Label> 
                                        /  <asp:Label runat="server" ID="lblTotNoOfInst" Text='<%#Eval("TotNoOfInst") %>'></asp:Label> 
                                        <br />
                                        <asp:Label runat="server" ID="lblInstStartDate" Text='<%#Eval("InstStartDate") %>'></asp:Label>
                                        <br />
                                        <asp:Label runat="server" ID="lblInstLoanBalAmt" Text='<%#Eval("InstLoanBalAmt") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                   <asp:TemplateField ItemStyle-CssClass="clsSector" ItemStyle-Width="13%">
                                    <ItemTemplate>
                                        <asp:LinkButton runat="server" Text="Edit" ID="btnEdit" OnClick="btnEdit_Click"></asp:LinkButton>
                                        <br />
                                        <asp:LinkButton runat="server" Text="Lease Ledger" ID="btnLedger" OnClick="btnLedger_Click"></asp:LinkButton>
                                        <br />
                                        <asp:LinkButton runat="server" ID="btnIns" Visible="false" Text="Installment Sheet" OnClick="btnIns_Click"></asp:LinkButton>
                                        <br />
                                        <asp:LinkButton runat="server" ID="btnInstLedger" Visible="false" OnClick="btnInstLedger_Click" Text="Installment Ledger"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="FinalInd" Visible="false" />

                            </Columns>
                            <FooterStyle BackColor="White" ForeColor="#000066" />
                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                            <RowStyle ForeColor="#000066" />
                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="#007DBB" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#00547E" />
                        </asp:GridView>
                    </div>
                </div>

            </div>
            <div class="panel-footer">
                <div class="alertMsg success" runat="server" id="pnlSuccess"></div>
                <div class="alertMsg failed" runat="server" id="pnlfailed"></div>
            </div>
        </div>
    </div>




    <!-- Modal -->
    <div id="propertyEditModal" class="modal propertyEditModal" role="dialog">
        <div class="modal-dialog">

            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header modal-header-theme">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Property Master</h4>
                </div>
                <div class="modal-body form-horizontal form-horizontal-label-left">


                    <div class="row">
                        <div class="col-sm-3">
                            <div class="form-group">
                                <label class="control-label col-xs-12">
                                    IDA RefNo.
                                </label>
                                <div class="col-xs-12">
                                    <asp:TextBox runat="server" ID="txtIDARefNo" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-3">
                            <div class="form-group">
                                <label class="control-label col-xs-12">
                                    Service No.
                                </label>
                                <div class="col-xs-12">
                                    <asp:TextBox runat="server" ID="txtServiceNo" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-3">
                            <div class="form-group">
                                <label class="control-label col-xs-12">
                                    Plot No.
                                </label>
                                <div class="col-xs-12">
                                    <asp:TextBox runat="server" ID="txtPlotNo" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                         <div class="col-sm-3">
                            <div class="form-group">
                                <label class="control-label col-xs-12">
                                    Sector Name
                                </label>
                                <div class="col-xs-12">
                                    <asp:TextBox runat="server" ID="txtSecName" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                   

                    <div class="row">
                        <div class="col-sm-3">
                            <div class="form-group">
                                <label class="control-label col-xs-12">
                                    Plot Use
                                </label>
                                <div class="col-xs-12">
                                    <asp:TextBox runat="server" ID="txtPlotUse" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-3">
                            <div class="form-group">
                                <label class="control-label col-xs-12">
                                    Plot Category
                                </label>
                                <div class="col-xs-12">
                                    <asp:TextBox runat="server" ID="txtPlotCate" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-3">
                            <div class="form-group">
                                <label class="control-label col-xs-12">
                                    Name
                                </label>
                                <div class="col-xs-12">
                                    <asp:TextBox runat="server" ID="txtName" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                         <div class="col-sm-3">
                            <div class="form-group">
                                <label class="control-label col-xs-12">
                                    Gender
                                </label>
                                <div class="col-xs-12">
                                    <asp:TextBox runat="server" ID="txtGender" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                       
                        <div class="col-sm-3">
                            <div class="form-group">
                                <label class="control-label col-xs-12">
                                    CAddress1 
                                </label>
                                <div class="col-xs-12">
                                    <asp:TextBox runat="server" ID="txtCAddress1" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-3">
                            <div class="form-group">
                                <label class="control-label col-xs-12">
                                    CAddress2 
                                </label>
                                <div class="col-xs-12">
                                    <asp:TextBox runat="server" ID="txtCAddress2" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                         <div class="col-sm-3">
                            <div class="form-group">
                                <label class="control-label col-xs-12">
                                    CAddress3
                                </label>
                                <div class="col-xs-12">
                                    <asp:TextBox runat="server" ID="txtCAddress3" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-3">
                            <div class="form-group">
                                <label class="control-label col-xs-12">
                                    Email
                                </label>
                                <div class="col-xs-12">
                                    <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                       
                        <div class="col-sm-3">
                            <div class="form-group">
                                <label class="control-label col-xs-12">
                                    Aadhaar No.
                                </label>
                                <div class="col-xs-12">
                                    <asp:TextBox runat="server" ID="txtAadhaaNo" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                          <div class="col-sm-3">
                            <div class="form-group">
                                <label class="control-label col-xs-12">
                                    GSTNo.
                                </label>
                                <div class="col-xs-12">
                                    <asp:TextBox runat="server" ID="txtGSTNo" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-3">
                            <div class="form-group">
                                <label class="control-label col-xs-12">
                                    Mobile No.
                                </label>
                                <div class="col-xs-12">
                                    <asp:TextBox runat="server" ID="txtMobileNo" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                          <div class="col-sm-3">
                            <div class="form-group">
                                <label class="control-label col-xs-12">
                                    Plot Size (Sq. Mtr) 
                                </label>
                                <div class="col-xs-12">
                                    <asp:TextBox runat="server" ID="txtPlotSize" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                       <%-- <div class="col-sm-3">
                            <div class="form-group">
                                <label class="control-label col-xs-12">
                                    Name Hindi 
                                </label>
                                <div class="col-xs-12">
                                    <asp:TextBox runat="server" ID="txtNameH" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>--%>
                    </div>

                  <%-- 
                    <div class="row">
                        <div class="col-sm-3">
                            <div class="form-group">
                                <label class="control-label col-xs-12">
                                    Address Hindi 1
                                </label>
                                <div class="col-xs-12">
                                    <asp:TextBox runat="server" ID="txtAddH1" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-3">
                            <div class="form-group">
                                <label class="control-label col-xs-12">
                                    Address Hindi 2 
                                </label>
                                <div class="col-xs-12">
                                    <asp:TextBox runat="server" ID="txtAddH2" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-3">
                            <div class="form-group">
                                <label class="control-label col-xs-12">
                                    Address Hindi 3
                                </label>
                                <div class="col-xs-12">
                                    <asp:TextBox runat="server" ID="txtAddH3" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                         <div class="col-sm-3">
                            <div class="form-group">
                                <label class="control-label col-xs-12">
                                    Plot Size (Sq. Mtr) 
                                </label>
                                <div class="col-xs-12">
                                    <asp:TextBox runat="server" ID="txtPlotSize" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>--%>

                    <div class="row">                       
                        <div class="col-sm-3">
                            <div class="form-group">
                                <label class="control-label col-xs-12">
                                    Plot Rate (Sq. Mtr)
                                </label>
                                <div class="col-xs-12">
                                    <asp:TextBox runat="server" ID="txtPlotRate" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-3">
                            <div class="form-group">
                                <label class="control-label col-xs-12">
                                    Plot Cost
                                </label>
                                <div class="col-xs-12">
                                    <asp:TextBox runat="server" ID="txtPlotCost" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                         <div class="col-sm-3">
                            <div class="form-group">
                                <label class="control-label col-xs-12">
                                    Poss. Date
                                </label>
                                <div class="col-xs-12">
                                    <asp:TextBox runat="server" ID="txtPlossDate" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-3">
                            <div class="form-group">
                                <label class="control-label col-xs-12">
                                    Delete Flag
                                </label>
                                <div class="col-xs-12">
                                    <asp:TextBox runat="server" ID="txtDelflag" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                       
                        <div class="col-sm-3">
                            <div class="form-group">
                                <label class="control-label col-xs-12">
                                    Comm Date
                                </label>
                                <div class="col-xs-12">
                                    <asp:TextBox runat="server" ID="txtCommDate" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                         <div class="col-sm-3">
                            <div class="form-group">
                                <label class="control-label col-xs-12">
                                  Yearly Lease  <%--Reg Lease Amt.--%>
                                </label>
                                <div class="col-xs-12">
                                    <asp:TextBox runat="server" ID="txtRegLeaseAmt" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-3">
                            <div class="form-group">
                                <label class="control-label col-xs-12">
                                    Inst Amt. 
                                </label>
                                <div class="col-xs-12">
                                    <asp:TextBox runat="server" ID="txtInstAmt" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-3">
                            <div class="form-group">
                                <label class="control-label col-xs-12">
                                     paid / Total Inst  
                                </label>
                                <div class="col-xs-12">
                                    <asp:TextBox runat="server" ID="txtPaidInst" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-3">
                            <div class="form-group">
                                <label class="control-label col-xs-12">
                                   inst Start Date 
                                </label>
                                <div class="col-xs-12">
                                    <asp:TextBox runat="server" ID="txtInstSdate" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                         <div class="col-sm-3">
                            <div class="form-group">
                                <label class="control-label col-xs-12">
                                   Inst Loan Amt.
                                </label>
                                <div class="col-xs-12">
                                    <asp:TextBox runat="server" ID="txtLoanAmt" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>


                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-success" data-dismiss="modal">Update</button>
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Cancel</button>
                </div>
            </div>

        </div>
    </div>


    <div id="LedgerModal" class="modal LedgerModal" role="dialog">
        <div class="modal-dialog">

            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header modal-header-theme">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title"><asp:Label runat="server" ID="lblHeader"></asp:Label></h4>
                </div>
                <div class="modal-body form-horizontal form-horizontal-label-left">

                    <rsweb:ReportViewer ShowParameterPrompts="false" Height="500px" Width="100%" ID="ReportViewer1" runat="server"></rsweb:ReportViewer>

                </div>
                <div class="modal-footer">                   
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Cancel</button>
                </div>
            </div>

        </div>
    </div>
     <script type="text/javascript">
         $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
         $('.chzn-search input[type="text"]').addClass('form-control');
         $('.chzn-single').addClass('form-control');
    </script>
</asp:Content>

