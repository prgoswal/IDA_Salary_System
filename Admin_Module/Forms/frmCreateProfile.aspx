<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_Module/AdminMaster.master" AutoEventWireup="true" CodeFile="frmCreateProfile.aspx.cs" Inherits="Admin_Module_Forms_frmCreateProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="col-xs-12">
       
    <div class="panel panel-primary"  style="margin:0 auto;width:100%;max-width:500px">
        <div class="panel-heading">
            <div class="pannel-title text-center"><b>Create Profile</b></div>
        </div>
        <div class="panel-body">
            <div class="form-horizontal">
                <div class="form-group">
                    <label class="control-label col-xs-12 col-sm-4">Profile / Level Name </label>
                    <div class="col-xs-12 col-sm-8">
                        <asp:TextBox ID="txtProfileName" runat="server" CssClass="form-control"/>
                    </div>
                </div>
            </div>
        </div>
        <div class="panel-footer text-right">
            <span class="alertMsg" runat="server" visible="false" id="ErrorMsg"></span>
            <asp:Button ID="btnSave" Text="Save" CssClass="btn btn-success" runat="server" OnClick="btnSave_Click" />
            <asp:Button ID="btnClear" Text="Clear" CssClass="btn btn-warning" runat="server" OnClick="btnClear_Click" />
            <asp:Button ID="btnExit" Text="Exit" CssClass="btn btn-danger" runat="server" OnClick="btnExit_Click" />
        </div>
    </div></div>
</asp:Content>

