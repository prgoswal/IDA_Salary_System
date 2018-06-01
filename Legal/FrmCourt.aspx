<%@ Page Title="" Language="C#" MasterPageFile="~/Legal/LegalMaster.master" AutoEventWireup="true" CodeFile="FrmCourt.aspx.cs" Inherits="FrmCourt" %>

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
            var options = {
                sourceLanguage:
                google.elements.transliteration.LanguageCode.ENGLISH,
                destinationLanguage:
                [google.elements.transliteration.LanguageCode.HINDI],
                shortcutKey: 'ctrl+g',
                transliterationEnabled: true            };

            var control =
            new google.elements.transliteration.TransliterationControl(options);

            control.makeTransliteratable(['<%=txt_CourtNmH.ClientID%>']);
            control.makeTransliteratable(['<%=txt_CourtPlace.ClientID%>']);
            control.makeTransliteratable(['<%=txt_CourtJudgeNm.ClientID%>']);
            
            
        }
        google.setOnLoadCallback(onLoad);

    </script>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="scr1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="up1" runat="server">
        <ContentTemplate>
            <script type="text/javascript" lang="javascript">
                Sys.Application.add_load(onLoad);
            </script>
            <div>
                <div class="col-xs-12 col-sm-8 col-sm-offset-2">
                    <div class="panel panel-primary mt10">
                        <div class="panel-heading">
                            <h3 class="panel-title"> Court Master</h3>
                            <!-- /.box-tools -->
                        </div>
                        <!-- /.box-header -->
                        <div class="panel-body form-horizontal">
                            <div class="form-group">
                                
                                
                                <div class="col-xs-12">
                                    <label class="control-label col-xs-12 col-sm-3 col-sm-offset-1 required">
                                       Court Name English
                                    </label>
                                    <div class="col-xs-12 col-sm-7">
                                        <asp:TextBox ID="txt_CourtNmE" runat="server" CssClass="form-control" MaxLength="50" placeholder="Enter Court Name In English"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfv1" runat="server" ControlToValidate="txt_CourtNmE" CssClass="errorMsg" Display="Dynamic" ValidationGroup="a" ForeColor="Red" SetFocusOnError="true" ErrorMessage="Enter Court Name English"></asp:RequiredFieldValidator>

                                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txt_CourtNmE" FilterType="Custom,LowercaseLetters, UppercaseLetters" ValidChars=" " />
                                    </div>

                                </div>

                            </div>
                            <div class="form-group">

                                <div class="col-xs-12 ">
                                    <label class="control-label col-xs-12 col-sm-3 col-sm-offset-1 required">
                                       Court Name Hindi
                                    </label>
                                    <div class="col-xs-12 col-sm-7">

                                        <asp:TextBox ID="txt_CourtNmH" runat="server" CssClass="form-control" placeholder="Enter Case Stage in Hindi" MaxLength="100"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfv2" runat="server" ControlToValidate="txt_CourtNmH" CssClass="errorMsg" ValidationGroup="a" ForeColor="Red" Display="Dynamic" SetFocusOnError="true" ErrorMessage="Enter Court Name Hindi"></asp:RequiredFieldValidator>

                                    </div>
                                </div>

                            </div>

                             <div class="form-group">


                                <div class="col-xs-12">
                                    <label class="control-label col-xs-12 col-sm-3 col-sm-offset-1 required">
                                       Court Place
                                    </label>
                                    <div class="col-xs-12 col-sm-7">
                                        <asp:TextBox ID="txt_CourtPlace" runat="server" CssClass="form-control" MaxLength="50" placeholder="Enter Court Place"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_CourtPlace" CssClass="errorMsg" Display="Dynamic" ValidationGroup="a" ForeColor="Red" SetFocusOnError="true" ErrorMessage="Enter Court Place"></asp:RequiredFieldValidator>

                                    </div>

                                </div>

                            </div>

                             <div class="form-group">


                                <div class="col-xs-12">
                                    <label class="control-label col-xs-12 col-sm-3 col-sm-offset-1 required">
                                       Court Judge Name
                                    </label>
                                    <div class="col-xs-12 col-sm-7">
                                        <asp:TextBox ID="txt_CourtJudgeNm" runat="server" CssClass="form-control" MaxLength="50" placeholder="Enter Court Judge Name"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_CourtJudgeNm" CssClass="errorMsg" Display="Dynamic" ValidationGroup="a" ForeColor="Red" SetFocusOnError="true" ErrorMessage="Enter Court Judge Name"></asp:RequiredFieldValidator>

                                    </div>

                                </div>

                            </div>

                             <div class="form-group">

                                <div class="col-xs-12">
                                    <label class="control-label col-xs-12 col-sm-3 col-sm-offset-1 required">
                                       Select Court Type
                                    </label>
                                    <div class="col-xs-12 col-sm-7">
                                        <asp:DropDownList ID="ddlCourtType" runat="server" CssClass="form-control"></asp:DropDownList>                               
                                  <asp:CompareValidator CssClass="errorMsg" ForeColor="Red" SetFocusOnError="true" ErrorMessage="Select Court Type" runat="server" ID="comparevalidator1" ValidationGroup="a" ControlToValidate="ddlCourtType" ValueToCompare="कोर्ट के प्रकार चुने " Operator="NotEqual"></asp:CompareValidator>
                                    </div>

                                </div>

                            </div>

                        </div>
                        <div class="panel-footer">
                            <asp:Button ID="btnSave" Text="Save" runat="server" ValidationGroup="a" OnClick="btnSave_Click" CssClass="btn btn-success btnSave" />
                            <asp:Button ID="btnClear" Text="Clear" runat="server" OnClick="btnClear_Click" CssClass="btn btn-warning btnClear" />
                            <asp:Button ID="btnExit" runat="server" PostBackUrl="Dashboard.aspx" CssClass="btn btn-danger" Text="Exit" />
                            <div class="alertMsg success" runat="server" id="pnlSuccess"></div>
                            <div class="alertMsg failed" runat="server" id="pnlfailed"></div>
                        </div>


                        <div class="panel-body table table-responsive table-bordered" style="overflow-y: auto; height: 200px">
                            <asp:GridView ID="GridCourt" runat="server" AutoGenerateColumns="False" DataKeyNames="CourtCode,CourtTypeCode" OnRowCommand="GridCourt_RowCommand" CssClass="table table-responsive table-bordered table-hover" HeaderStyle-BackColor="#006699" HeaderStyle-ForeColor="white">
                                <Columns>
                                    <asp:TemplateField HeaderText="Sno.">
                                        <ItemTemplate>
                                            <%#(Container.DataItemIndex+1) %>
                                        </ItemTemplate>
                                        
                                    </asp:TemplateField>
                                 
                                    <asp:BoundField Visible="false" DataField="CourtCode" HeaderText="CourtCode" />
                                    <asp:BoundField Visible="false" DataField="CourtTypeCode" HeaderText="CourtTypeCode" />
                                 
                                    <asp:TemplateField HeaderText="Court Name English">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCourtNmE" runat="server" Text=' <%# Eval("CourtNmE") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Court Name Hindi">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCourtNmH" runat="server" Text=' <%# Eval("CourtNmH") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Court Place">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCourtPlace" runat="server" Text=' <%# Eval("CourtPlace") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Court Judge Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCourtJudgeNm" runat="server" Text=' <%# Eval("CourtJudgeNm") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Court Type">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCourtTypeNameE" runat="server" Text=' <%# Eval("CourtTypeNameH") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                   
                                    <asp:TemplateField Visible="false" HeaderText="Select">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton1" CommandArgument='<%# Eval("CourtCode") %>' CommandName="DelRecord" runat="server">Delete</asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Select">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkBtnEdit" CommandArgument='<%#(Container.DataItemIndex)%>' CommandName="EditRecord" runat="server">Edit</asp:LinkButton>
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


