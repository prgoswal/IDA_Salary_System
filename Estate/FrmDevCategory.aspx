﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Estate/MainMaster.master" AutoEventWireup="true" CodeFile="FrmDevCategory.aspx.cs" Inherits="frm_DevCategory" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
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
         
           control.makeTransliteratable(['<%=txt_DevCatNameH.ClientID%>']);
       }
       google.setOnLoadCallback(onLoad);

      </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
                    <h3 class="panel-title">Developer Category Master</h3>
                    <!-- /.box-tools -->
                </div>
                <!-- /.box-header -->
                <div class="panel-body form-horizontal">
                    <div class="form-group">

                       
                        <div class="col-xs-12">
                            <label class="control-label col-xs-12 col-sm-4 required">
                                Developer Category Name E
                            </label>
                            <div class="col-xs-12 col-sm-8">
                                <asp:TextBox ID="txt_DevelopercatnameE" runat="server" CssClass="form-control" MaxLength="50" placeholder="Enter Developer Category Name In English"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfv1" runat="server" ControlToValidate="txt_DevelopercatnameE" CssClass="errorMsg" Display="Dynamic" ValidationGroup="a" ForeColor="Red" SetFocusOnError="true" ErrorMessage="Enter Developer Category Name English"></asp:RequiredFieldValidator>

                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txt_DevelopercatnameE" FilterType="Custom,LowercaseLetters, UppercaseLetters" ValidChars=" " />
                            </div>
                              
                        </div>

                    </div>
                    <div class="form-group">
                       
                        <div class="col-xs-12 ">
                            <label class="control-label col-xs-12 col-sm-4 required">
                               Developer Category Name H
                            </label>
                            <div class="col-xs-12 col-sm-8">

                                <asp:TextBox ID="txt_DevCatNameH" runat="server" CssClass="form-control" placeholder="Enter Developer Category Name in Hindi" MaxLength="100"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfv2" runat="server" ControlToValidate="txt_DevCatNameH" CssClass="errorMsg" ValidationGroup="a" ForeColor="Red" Display="Dynamic" SetFocusOnError="true" ErrorMessage="Enter Developer Category Name Hindi"></asp:RequiredFieldValidator>

                            </div>
                        </div
                        
                    </div>
                </div>
                <div class="panel-footer">
                            <asp:Button ID="btnSave" Text="Save" runat="server" ValidationGroup="a" OnClick="btnSave_Click"  CssClass="btn btn-success btnSave" />
                            <asp:Button ID="btnClear" Text="Clear" runat="server" OnClick="btnClear_Click" CssClass="btn btn-warning btnClear" />
                            <asp:Button ID="btnExit" runat="server" PostBackUrl="Dashboard.aspx" CssClass="btn btn-danger" Text="Exit" />
                            <div class="alertMsg success" runat="server"  id="pnlSuccess"></div>
                            <div class="alertMsg failed" runat="server" id="pnlfailed"></div>
                </div>

                    <div class="panel-body">
                        <div class="col-xs-12">
                  <div style="max-height: 200px;overflow-y:scroll;">
                  <%--<div class="panel-footer table table-responsive table-bordered" style="overflow-y:auto;height:200px" >--%>
              <asp:GridView ID="dgv_Devcat" runat="server" AutoGenerateColumns="False" DataKeyNames="DevCateCode" CssClass="table table-responsive table-bordered table-hover" OnRowCommand="dgv_Devcat_RowCommand" HeaderStyle-BackColor="#006699" HeaderStyle-ForeColor="white">
                <Columns>
                    <asp:BoundField DataField="DevCateCode" HeaderText="Developer category Code" />
                    <asp:BoundField DataField="CityCode" HeaderText="City Code" />
                    <asp:BoundField DataField="DevCateDescE" HeaderText="Category Desc English" />
                    <asp:BoundField DataField="DevCateDescH" HeaderText="Category Desc Hindi" />
                     <asp:TemplateField HeaderText="Select">
                      <ItemTemplate>
                       <asp:LinkButton ID="LinkButton1"  CommandArgument='<%# Eval("DevCateCode") %>' CommandName="DelRecord" runat="server">Delete</asp:LinkButton>
                     </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                   
            </asp:GridView>
                </div>
</div></div>

            </div>
        </div>
    </div>
            </ContentTemplate>
        </asp:UpdatePanel>
</asp:Content>

