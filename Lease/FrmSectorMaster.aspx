<%@ Page Title="" Language="C#" MasterPageFile="~/Lease/MainMaster.master" AutoEventWireup="true" CodeFile="FrmSectorMaster.aspx.cs" Inherits="FrmSectorMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" language="javascript">
        function Validate() {
            $(document).ready(function () {

                $('#<%=btnSave.ClientID%>').click(function () {
                    if ($('#<%=DDlWardNo.ClientID%>').val() == 0 && $('#<%=DDlSchemeName.ClientID%>').val() != '' && $('#<%=DDlSchemeName.ClientID%>').val() == 0 && $('#<%=txtSector.ClientID%>').val() == '') {
                        $('#<%=DDlWardNo.ClientID%>').css('border-color', 'Red');
                 $('#<%=DDlSchemeName.ClientID%>').css('border-color', 'Red');
                 $('#<%=txtSector.ClientID%>').css('border-color', 'Red');
                 alert('Insert Mandetory Feilds')

                 return false;
             }
             else if ($('#<%=DDlWardNo.ClientID%>').val() == 0) {
                 $('#<%=DDlWardNo.ClientID%>').css('border-color', 'Red');

            alert('Select WardNo')
            return false;

        }
        else if ($('#<%=DDlSchemeName.ClientID%>').val() != '' && $('#<%=DDlSchemeName.ClientID%>').val() == 0) {
            $('#<%=DDlSchemeName.ClientID%>').css('border-color', 'Red');

    alert('Select Scheme')
    return false;

}
else if ($('#<%=txtSector.ClientID%>').val() == '') {
    $('#<%=txtSector.ClientID%>').css('border-color', 'Red');

    alert('Insert Sector')
    return false;

}
else {

    return true;
}

                })
            });
};
function mouseover() {
    $(document).ready(function () {

        $('#<%=DDlWardNo.ClientID%>').focus(function () {
            $('#<%=DDlWardNo.ClientID%>').css('border-color', '');

        });
    });


    $(document).ready(function () {

        $('#<%=DDlSchemeName.ClientID%>').focus(function () {
            $('#<%=DDlSchemeName.ClientID%>').css('border-color', '');

        });
    });


    $(document).ready(function () {

        $('#<%=txtSector.ClientID%>').focus(function () {
            $('#<%=txtSector.ClientID%>').css('border-color', '');

        });
    });


};

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="scr" runat="server"></asp:ScriptManager>

     
    <div class="container-fluid">
        <asp:UpdatePanel ID="upd" runat="server">
            <ContentTemplate>
                 <script type="text/javascript" lang="javascript">
                     Sys.Application.add_load(Validate);
                     Sys.Application.add_load(mouseover);

                </script>
              
                <div class="row">
                    <h3 class="heading">
                        <asp:Label ID="Label78" runat="server" Text="Sector Master"></asp:Label>
                    </h3>
                    <div class="col-xs-12">
                        <div class="panel panel-primary">
                            <div class="panel-heading">
                                <h3 class="panel-title">Sector Master</h3>
                            </div>
                            <div class="panel-body form-horizontal scheme-form-group">
                                <div class="form-group">
                                    <div class="row">
                                        <div class="col-xs-12 col-sm-4">
                                            <label class="control-label col-xs-12 col-sm-5 required">Ward No.</label>
                                            <div class="col-xs-12 col-sm-7 width-660-sm">
                                                <asp:DropDownList ID="DDlWardNo" runat="server" CssClass="textbig form-control" AutoPostBack="True" OnSelectedIndexChanged="DDlWardNo_SelectedIndexChanged"></asp:DropDownList>

                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <div class="row">
                                        <div class="col-xs-12 col-sm-4">
                                            <label class="control-label col-xs-12 col-sm-5 required">Scheme</label>
                                            <div class="col-xs-12 col-sm-7 width-660-sm">
                                                <asp:DropDownList ID="DDlSchemeName" runat="server" AutoPostBack="true" CssClass="textbig form-control"></asp:DropDownList>
                                             
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="row">
                                        <div class="col-xs-12 col-sm-4">
                                            <label class="control-label col-xs-12 col-sm-5 required">Sector</label>
                                            <div class="col-xs-12 col-sm-7 width-660-sm">
                                                <asp:TextBox ID="txtSector" runat="server" CssClass="textbig form-control" MaxLength="8" Width="175px"></asp:TextBox>
                                                <asp:RequiredFieldValidator SetFocusOnError="true" CssClass="errorMsg" ID="rq6" runat="server" ControlToValidate="txtSector" ErrorMessage="Enter Sector" ForeColor="Red" ValidationGroup="a"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="panel-footer">

                                <asp:Button ID="btnSave" runat="server" BackColor="#2282BE" Font-Bold="True" ForeColor="White" Text="Save" Width="60px" ValidationGroup="a" OnClick="btnSave_Click" />
                                <asp:Button ID="btnclear" runat="server" BackColor="#2282BE" Font-Bold="True" ForeColor="White" Text="Clear" Width="60px" OnClick="btnclear_Click" />
                                <asp:Button ID="btnExit" runat="server" BackColor="#2282BE" Font-Bold="True" ForeColor="White" Text="Exit" Width="60px" OnClick="btnExit_Click" />
                                <asp:Label ID="LblMsg" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                            </div>
                        </div>
                    </div>

                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>


</asp:Content>


