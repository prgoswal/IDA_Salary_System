<%@ Page Title="" Language="C#" MasterPageFile="~/FrontOffice/MainMaster.master" AutoEventWireup="true" CodeFile="frm_EmpServicesAssign.aspx.cs" Inherits="Administrator_frm_EmpServicesAssign" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:UpdatePanel ID="upd1" runat="server">
        <ContentTemplate>
            <div>
                <div class="col-xs-12 col-sm-6 col-sm-offset-3">
                    <div class="panel panel-primary mt50">
                        <div class="panel-heading">
                            <h3 class="panel-title">Department Wise Employee Services</h3>
                            <!-- /.box-tools -->
                        </div>
                        <!-- /.box-header -->
                        <div class="panel-body form-horizontal scheme-form-group">
                            <div class="form-group">
                                <div class="col-xs-12">
                                    <label class="control-label col-xs-12 col-sm-4 required">
                                        Department Name
                                    </label>
                                    <div class="col-xs-12 col-sm-8">
                                        <asp:DropDownList ID="ddl_DeptName" runat="server" OnSelectedIndexChanged="ddl_DeptName_SelectedIndexChanged" AutoPostBack="true" class="service_txt browser-default select form-control inputs">
                                           
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator CssClass="errorMsg" ID="rfv5" runat="server" ErrorMessage="Please select Department" ControlToValidate="ddl_DeptName" ValidationGroup="a" ForeColor="Red" InitialValue="0"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-xs-12 ">
                                    <label class="control-label col-xs-12 col-sm-4 required">
                                        Employee Name 
                                    </label>
                                    <div class="col-xs-12 col-sm-8">

                                        <asp:DropDownList ID="ddl_EmpName" runat="server" class="service_txt browser-default select form-control inputs">
                                            <asp:ListItem Value="0">--Select Employee Name - Designation--</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator CssClass="errorMsg" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Select Employee Name" 
                                            ControlToValidate="ddl_EmpName"
                                            ValidationGroup="a" ForeColor="Red" InitialValue="0"></asp:RequiredFieldValidator>

                                    </div>
                                </div>
                            </div>


                          



                           


                           


                            

                        </div>
                        <div class="panel-footer">
                            <asp:Button ID="btnSave" Text="Save" runat="server" ValidationGroup="a"  CssClass="btn btn-success btnSave" />
                            <asp:Button ID="btnClear" Text="Clear" runat="server"  CssClass="btn btn-default btnClear" />
                            <asp:Button ID="btnExit" runat="server" PostBackUrl="~/FrontOffice/Dashboard.aspx" CssClass="btn btn-danger" Text="Exit" />
                            <div class="alertMsg success" runat="server" id="pnlSuccess" Visible="false"></div>
                            <div class="alertMsg failed" runat="server" id="pnlfailed" Visible="false"></div>


                        </div>
                    </div>


                </div>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

