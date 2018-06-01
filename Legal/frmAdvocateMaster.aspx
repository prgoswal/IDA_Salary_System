<%@ Page Title="" Language="C#" MasterPageFile="~/Legal/LegalMaster.master" AutoEventWireup="true" CodeFile="frmAdvocateMaster.aspx.cs" Inherits="frmAdvocateMaster" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
   
     <script type="text/javascript" src="https://www.google.com/jsapi">
    </script>
    <script>
        function LoadC() {
            
            $(function () {
                $(".datepicker").datepicker({ dateFormat: 'dd/mm/yy' });
            });
            
        }
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

            control.makeTransliteratable(['<%=txt_AdvonmH.ClientID%>']); 
            control.makeTransliteratable(['<%=txt_AdvoAddress.ClientID%>']); 
        }
        google.setOnLoadCallback(onLoad);

    </script>

    <script type="text/javascript">
     
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:ScriptManager ID="scr1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="up1" runat="server">
        <ContentTemplate>
            <script type="text/javascript" lang="javascript">
                Sys.Application.add_load(onLoad);
                Sys.Application.add_load(LoadC);
            </script>
            <div>
                <div class="" style="margin: 0 auto; max-width: 1255px;">
                    <div class="panel panel-primary mt10" style="margin-top: 10px">
                        <div class="panel-heading">
                            <h3 class="panel-title">Advocate Master</h3>
                            <!-- /.box-tools -->
                        </div>
                        <!-- /.box-header -->
                        <div class="panel-body form-horizontal">
                            <div class="row">

                                <div class="col-xs-12 col-sm-6">
                                    <div class="form-group">
                                        <label class="control-label col-xs-12 col-sm-4 required">
                                            Advocate Name English
                                        </label>
                                        <div class="col-xs-12 col-sm-8">
                                            <asp:TextBox ID="txt_AdvonmE" runat="server" CssClass="form-control" MaxLength="60" placeholder="Advocate Name In English"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfv1" runat="server" ControlToValidate="txt_AdvonmE" CssClass="errorMsg" Display="Dynamic" ValidationGroup="a" ForeColor="Red" SetFocusOnError="true" ErrorMessage="Enter Advocate Name In English"></asp:RequiredFieldValidator>

                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txt_AdvonmE" FilterType="Custom,LowercaseLetters, UppercaseLetters" ValidChars=" " />
                                        </div>
                                    </div>
                                </div>


                                <div class="col-xs-12  col-sm-6">
                                    <div class="form-group">
                                        <label class="control-label col-xs-12 col-sm-4 required">
                                            Advocate Name Hindi
                                        </label>
                                        <div class="col-xs-12 col-sm-8">
                                            <asp:TextBox ID="txt_AdvonmH" runat="server" CssClass="form-control" placeholder="Advocate Name In Hindi" MaxLength="60"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfv2" runat="server" ControlToValidate="txt_AdvonmH" CssClass="errorMsg" ValidationGroup="a" ForeColor="Red" Display="Dynamic" SetFocusOnError="true" ErrorMessage="Enter Advocate Name In Hindi"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                                </div>   <div class="row">


                                  <div class="col-xs-12 col-sm-6">
                                    <div class="form-group">
                                        <label class="control-label col-xs-12 col-sm-4 required">
                                            Court Type
                                        </label>
                                        <div class="col-xs-12 col-sm-8">
                                         <asp:DropDownList ID="ddl_Courttype" runat="server" CssClass="form-control"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfv_Advtype" ValidationGroup="a" runat="server" CssClass="errorMsg" ControlToValidate="ddl_Courttype" InitialValue="0" ErrorMessage="Select Court Type" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                      
                                        </div>
                                    </div>
                                </div>
                                <div class="col-xs-12  col-sm-6">
                                    <div class="form-group">
                                        <label class="control-label col-xs-12 col-sm-4 required">
                                            Advocate Address
                                        </label>
                                        <div class="col-xs-12 col-sm-8">
                                            <asp:TextBox ID="txt_AdvoAddress" runat="server" CssClass="form-control" TextMode="MultiLine" placeholder="Advocate Address" MaxLength="180" Height="50px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_AdvonmH" CssClass="errorMsg" ValidationGroup="a" ForeColor="Red" Display="Dynamic" SetFocusOnError="true" ErrorMessage="Enter Advocate Address"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                            </div>


                            <div class="row">
                                

                                <div class="col-xs-12 col-sm-6 ">
                                    <div class="form-group">
                                        <label class="control-label col-xs-12 col-sm-4 required">
                                            Advocate&nbsp;Qualification
                                        </label>
                                        <div class="col-xs-12 col-sm-8">
                                            <asp:TextBox ID="txt_AddvoQualif" runat="server" CssClass="form-control" placeholder="Advocate Qualification" MaxLength="60"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_AddvoQualif" CssClass="errorMsg" ValidationGroup="a" ForeColor="Red" Display="Dynamic" SetFocusOnError="true" ErrorMessage="Enter Advocate Qualification"></asp:RequiredFieldValidator>
                                              <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txt_AddvoQualif" FilterType="Custom,LowercaseLetters, UppercaseLetters" ValidChars=" " />
                                        </div>
                                    </div>

                                </div>
                                <div class="col-xs-12  col-sm-6">
                                    <div class="form-group">
                                        <label class="control-label col-xs-12 col-sm-4 required">
                                            Advocate Panel
                                        </label>
                                        <div class="col-xs-12 col-sm-8">
                                            <asp:TextBox ID="txt_Advopanel" runat="server" CssClass="form-control" placeholder="Advocate Panel" MaxLength="60"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_Advopanel" CssClass="errorMsg" ValidationGroup="a" ForeColor="Red" Display="Dynamic" SetFocusOnError="true" ErrorMessage="Enter Advocate Panel"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>

                            </div>

                            <div class="row">


                                <div class="col-xs-12  col-sm-6">
                                    <div class="form-group">
                                        <label class="control-label col-xs-12 col-sm-4 required">
                                            Telephone No
                                        </label>
                                        <div class="col-xs-12 col-sm-8">
                                            <asp:TextBox ID="txt_telephone" runat="server" CssClass="form-control" placeholder="Telephone Number" MaxLength="10"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_telephone" CssClass="errorMsg" ValidationGroup="a" ForeColor="Red" Display="Dynamic" SetFocusOnError="true" ErrorMessage="Enter Telephonr Number"></asp:RequiredFieldValidator>
                                             <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txt_telephone" FilterType="Numbers" ValidChars=" " />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-xs-12  col-sm-6">
                                    <div class="form-group">


                                        <div class="row">
                                            <div class="col-xs-12 col-sm-10">
                                                  <div class="row">
                                                <label class="control-label col-xs-12 col-sm-5 required"  style="max-width:220px;padding-left:30px">
                                                    Appointment Date
                                                </label>
                                                <div class="col-xs-12 col-sm-7">
                                                    <asp:TextBox ID="txt_Appointmentdate" runat="server" CssClass="form-control datepicker" ></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txt_Appointmentdate" CssClass="errorMsg" ValidationGroup="a" ForeColor="Red" Display="Dynamic" SetFocusOnError="true" ErrorMessage="Enter Appointment Date"></asp:RequiredFieldValidator>
                                                </div>
                                                      </div>
                                            </div>
                                            <div class="col-xs-12 col-sm-2">
                                                <style>
                                                    .radio-advocate {
                                                        padding-top:8px
                                                    }
                                                    .radio-advocate input,.radio-advocate label {
                                                        display:block;
                                                        float:left;
                                                        user-select:none;
                                                        cursor:pointer
                                                    }
                                                    .radio-advocate label {
                                                        margin-top:1px;
                                                        margin-left:2px
                                                    }
                                                   .radio-advocate input:checked + label {
                                                        text-shadow:0px 0px 1px  rgba(0,0,0,0.5)
                                                    }
                                                </style>
                                                <div class="required radio-advocate" style="max-width:63px">
                                                    <asp:CheckBox ID="chk_Active" runat="server" Text="Active" />

                                                </div>
                                            </div>
                                        </div>

                                    </div>
                                </div>
                            </div>

                        </div>
                        <div class="panel-footer">
                            <asp:Button ID="btnupdate" Text="Update" runat="server" ValidationGroup="a" OnClick="btnupdate_Click" CssClass="btn btn-success btnSave" />
                            <asp:Button ID="btnSave" Text="Save" runat="server" ValidationGroup="a" OnClick="btnSave_Click" CssClass="btn btn-success btnSave" />
                            <asp:Button ID="btnClear" Text="Clear" runat="server" OnClick="btnClear_Click" CssClass="btn btn-warning btnClear" />
                            <asp:Button ID="btnExit" runat="server" PostBackUrl="Dashboard.aspx" CssClass="btn btn-danger" Text="Exit" />
                            <div class="alertMsg success" runat="server" id="pnlSuccess"></div>
                            <div class="alertMsg failed" runat="server" id="pnlfailed"></div>
                        </div>

                        <div class="panel-body table table-responsive table-bordered" style="overflow-y: auto; height: 200px; padding: 0">
                            <asp:GridView ID="gv_Advocatemaster" runat="server" AutoGenerateColumns="False" OnRowCommand="gv_Advocatemaster_RowCommand" DataKeyNames="AdvocateCode,AdvocateTypeId" CssClass="table table-responsive table-bordered table-hover" HeaderStyle-BackColor="#006699" HeaderStyle-ForeColor="white">
                                <Columns>

                                    <asp:TemplateField HeaderText="Sr No">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>


                                    <asp:BoundField DataField="AdvocateCode" Visible="false" HeaderText="AdvocateCode" />
                                    <asp:BoundField DataField="AdvocateTypeId" Visible="false" HeaderText="AdvocateTypeId" />

                                    <asp:TemplateField HeaderText="Advocate Name English">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAdvocateNameE" runat="server" Text=' <%# Eval("AdvocateNmE") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Advocate Name Hindi">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAdvocateNameH" runat="server" Text=' <%# Eval("AdvocateNmH") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>


                                    <asp:TemplateField HeaderText="Advocate Address">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAdvocateAddress" runat="server" Text=' <%# Eval("AdvoAddress") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Qualification">
                                        <ItemTemplate>
                                            <asp:Label ID="lblQualification" runat="server" Text=' <%# Eval("AdvoQualification") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Advocate Panel">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAdvopanel" runat="server" Text=' <%# Eval("AdvoPanel") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Telephone No">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTelephoneno" runat="server" Text=' <%# Eval("TelNo") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    

                                    <asp:TemplateField HeaderText="Appointment Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAppointmentDt" runat="server" Text=' <%# Eval("AppointmentDt") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>


                                     <asp:TemplateField HeaderText="Court Type">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCourtTypeNameE" runat="server" Text=' <%# Eval("CourtTypeNameH") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>


                                    <asp:TemplateField HeaderText="Select">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnk1" runat="server" CommandArgument='<%#(Container.DataItemIndex)%>' CommandName="Select">Edit</asp:LinkButton>
                                        </ItemTemplate>

                                    </asp:TemplateField>
                                </Columns>

                            </asp:GridView>

                        </div>

                    </div>
                </div>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

