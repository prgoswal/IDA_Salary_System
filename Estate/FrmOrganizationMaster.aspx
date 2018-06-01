<%@ Page Title="" Language="C#" MasterPageFile="~/Estate/MainMaster.master" AutoEventWireup="true" CodeFile="FrmOrganizationMaster.aspx.cs" Inherits="FrmOrganizationMaster" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

      <script type="text/javascript" src="https://www.google.com/jsapi">
    </script>
    <script>
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

            control.makeTransliteratable(['<%=txt_OrganizationnameH.ClientID%>']);
       }
       google.setOnLoadCallback(onLoad);

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="scr1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="upd1" runat="server">
        <ContentTemplate>
             <script type="text/javascript" lang="javascript">
                 Sys.Application.add_load(onLoad);
            </script>

    <div class="col-sm-10 col-sm-offset-1">
                        <div class="panel panel-primary mt10">
                            <div class="panel-heading">
                                <h3 class="panel-title">Organization Master</h3>
                            </div>
                            <div class="panel-body form-horizontal scheme-form-group">
                                <div class="form-group">
                                    <div class="row">
                                        <div class="col-xs-12 col-sm-6">
                                            <label class="col-xs-12 col-sm-5 required control-label">Organization Name English</label>
                                            <div class="col-xs-12 col-sm-7">
                                             <asp:TextBox runat="server" ID="txt_OrganizationnameE" MaxLength="50" placeholder="Organization Name English" CssClass="form-control"></asp:TextBox>  
                                                  <asp:RequiredFieldValidator SetFocusOnError="true" CssClass="errorMsg" ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_OrganizationnameE" ErrorMessage="Enter Organization Name English" ForeColor="Red" ValidationGroup="a"></asp:RequiredFieldValidator> 
                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txt_OrganizationnameE" FilterType="Custom,LowercaseLetters, UppercaseLetters" ValidChars=" " />                                      
                                                   </div>
                                        </div>
                                         <div class="col-xs-12 col-sm-6">
                                            <label class="col-xs-12 col-sm-5 required control-label">Organization Name Hindi</label>
                                            <div class="col-xs-12 col-sm-7">
                                             <asp:TextBox runat="server" ID="txt_OrganizationnameH" MaxLength="100" placeholder="Organization Name Hindi" CssClass="form-control"></asp:TextBox>      
                                                  <asp:RequiredFieldValidator SetFocusOnError="true" CssClass="errorMsg" ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_OrganizationnameH" ErrorMessage="Enter Organization Name Hindi" ForeColor="Red" ValidationGroup="a"></asp:RequiredFieldValidator>  
                                                                      
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <style>
                                    .sm_20 .sm_80{
                                        float:left;
                                    }
                                    .sm_20{
                                       width:20%;
                                    }
                                    .sm_80{
                                        width:80%;
                                    }
                                </style>
                                <div class="form-group">
                                    <div class="row">
                                        <div class="col-xs-12 col-sm-12">
                                            <label class="col-xs-12 col-sm-5 sm_20 required control-label">Organization Address</label>
                                           <div class="col-xs-12 col-sm-7 sm_80" >                                           
                                    <asp:TextBox runat="server" ID="txt_OrganizationAddress" CssClass="form-control" MaxLength="80" placeholder="Organization Address" TextMode="MultiLine" ></asp:TextBox>
                                               <asp:RequiredFieldValidator SetFocusOnError="true" CssClass="errorMsg" ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_OrganizationAddress" ErrorMessage="Enter Organization Address" ForeColor="Red" ValidationGroup="a"></asp:RequiredFieldValidator> 
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="row">
                                        <div class="col-xs-12 col-sm-6">
                                            <label class="col-xs-12 col-sm-5 required control-label">Contact Person1 Name</label>
                                            <div class="col-xs-12 col-sm-7">                                           
                                                     
                                                <asp:TextBox ID="txt_ContactPer1name" runat="server" CssClass="form-control" MaxLength="30" placeholder="Contact Person1 Name"></asp:TextBox> 
                                                
                                                 <asp:RequiredFieldValidator SetFocusOnError="true" CssClass="errorMsg" ID="RequiredFieldValidator5" runat="server" ControlToValidate="txt_ContactPer1name" ErrorMessage="Enter Contact Person1 Name" ForeColor="Red" ValidationGroup="a"></asp:RequiredFieldValidator> 
                                                 <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txt_ContactPer1name" FilterType="Custom,LowercaseLetters, UppercaseLetters" ValidChars=" " /> 
                                                                                                        
                                            </div>
                                        </div>
                                        <div class="col-xs-12 col-sm-6">
                                            <label class="control-label col-xs-12 col-sm-5 required control-label">Contact Person1 Mobile</label>
                                            <div class="col-xs-12 col-sm-7">
                                                <asp:TextBox ID="txt_ContactPer1Mob" runat="server" CssClass="form-control" placeholder="Contact Person1 Mobile" MaxLength="10"></asp:TextBox>  
                                                   <asp:RequiredFieldValidator SetFocusOnError="true" CssClass="errorMsg" ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_ContactPer1Mob" ErrorMessage="Enter Contact Person1 Mobile" ForeColor="Red" ValidationGroup="a"></asp:RequiredFieldValidator>   
                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" TargetControlID="txt_ContactPer1Mob" FilterType="Numbers" ValidChars="" />                                                                                  
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                    <div class="form-group">
                                    <div class="row">
                                        <div class="col-xs-12 col-sm-6">
                                            <label class="col-xs-12 col-sm-5 required control-label">Contact Person1 Email</label>
                                            <div class="col-xs-12 col-sm-7">                                      
                                                  <asp:TextBox ID="txt_Contactper1Email" runat="server" CssClass="form-control" MaxLength="20" placeholder="Contact Person1 Email"></asp:TextBox>   
                                                
                                                 <asp:RequiredFieldValidator SetFocusOnError="true" CssClass="errorMsg" ID="RequiredFieldValidator6" runat="server" ControlToValidate="txt_Contactper1Email" ErrorMessage="Enter Contact Person1 Email" ForeColor="Red" ValidationGroup="a"></asp:RequiredFieldValidator>
                                                 <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage=" Enter Valid Email" ValidationGroup="a" ControlToValidate="txt_Contactper1Email" CssClass="errorMsg" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                      
                                                           
                                            </div>
                                        </div>
                                        <div class="col-xs-12 col-sm-6">
                                            <label class="control-label col-xs-12 col-sm-5 control-label">Contact Person1 Designation</label>
                                            <div class="col-xs-12 col-sm-7">
                                               <asp:TextBox ID="txt_Contactper1Desg" runat="server" CssClass="form-control" MaxLength="20" placeholder="Enter Contact Person1 Designation"></asp:TextBox>
                                                  <asp:RequiredFieldValidator SetFocusOnError="true" CssClass="errorMsg" ID="RequiredFieldValidator7" runat="server" ControlToValidate="txt_Contactper1Desg" ErrorMessage="Enter Contact Person1 Designation" ForeColor="Red" ValidationGroup="a"></asp:RequiredFieldValidator>

                                            </div>
                                        </div>
                                    </div>
                                </div>

                                 <div class="form-group">
                                    <div class="row">
                                        <div class="col-xs-12 col-sm-6">
                                            <label class="col-xs-12 col-sm-5 required control-label">Contact Person2 Name</label>
                                            <div class="col-xs-12 col-sm-7">
                                                  <asp:TextBox ID="txt_ContactPer2name" runat="server" CssClass="form-control" MaxLength="30" placeholder="Contact Person2 Name"></asp:TextBox>  
                                                
                                                 <asp:RequiredFieldValidator SetFocusOnError="true" CssClass="errorMsg" ID="RequiredFieldValidator8" runat="server" ControlToValidate="txt_ContactPer2name" ErrorMessage="Enter Contact Person2 Name" ForeColor="Red" ValidationGroup="a"></asp:RequiredFieldValidator>  
                                                 <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" TargetControlID="txt_ContactPer2name" FilterType="Custom,LowercaseLetters, UppercaseLetters" ValidChars=" " />                                
                                           
                                                 </div>
                                        </div>
                                        <div class="col-xs-12 col-sm-6">
                                            <label class="control-label col-xs-12 col-sm-5 required control-label">Contact Person2 Mobile</label>
                                            <div class="col-xs-12 col-sm-7">
                                          <asp:TextBox ID="txt_ContactPer2Mob" runat="server" CssClass="form-control" placeholder="Contact Person2 Mobile" MaxLength="10" ></asp:TextBox>  
                                                 
                                                 <asp:RequiredFieldValidator SetFocusOnError="true" CssClass="errorMsg" ID="RequiredFieldValidator9" runat="server" ControlToValidate="txt_ContactPer2Mob" ErrorMessage="Enter Contact Person2 MobileNo" ForeColor="Red" ValidationGroup="a"></asp:RequiredFieldValidator> 
                                                 <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server" TargetControlID="txt_ContactPer2Mob" FilterType="Numbers" ValidChars=" " /> 
                                                                                                                                              
                                                 </div>
                                            </div>
                                        </div>
                                    </div>
                              
                                    <div class="form-group">
                                    <div class="row">
                                        <div class="col-xs-12 col-sm-6">
                                            <label class="col-xs-12 col-sm-5 required control-label">Contact Person2 Email</label>
                                            <div class="col-xs-12 col-sm-7">
                                              <asp:TextBox ID="txt_Contactper2Emai" runat="server" CssClass="form-control" MaxLength="20" placeholder="Contact Person2 Email"></asp:TextBox>  
                                                
                                                <asp:RequiredFieldValidator SetFocusOnError="true" CssClass="errorMsg" ID="RequiredFieldValidator10" runat="server" ControlToValidate="txt_Contactper2Emai" ErrorMessage="Enter Contact Person2 Email" ForeColor="Red" ValidationGroup="a"></asp:RequiredFieldValidator>   
                                                
                                                 <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage=" Enter Valid Email" ValidationGroup="a" ControlToValidate="txt_Contactper2Emai" CssClass="errorMsg" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>                                                                
                                                 </div>
                                        </div>  
                                        
                                        
                                         <div class="col-xs-12 col-sm-6">
                                            <label class="col-xs-12 col-sm-5 control-label">  Contact Person2 Designation</label>
                                            <div class="col-xs-12 col-sm-7">
                                               <asp:TextBox ID="txt_Contactper2Desg" runat="server" CssClass="form-control" MaxLength="20" placeholder="Enter Contact Person2 Designation"></asp:TextBox>  
                                                
                                                  <asp:RequiredFieldValidator SetFocusOnError="true" CssClass="errorMsg" ID="RequiredFieldValidator11" runat="server" ControlToValidate="txt_Contactper2Desg" ErrorMessage="Enter Contact Person2 Designation" ForeColor="Red" ValidationGroup="a"></asp:RequiredFieldValidator> 
                                                 </div>
                                        </div> 
                                                                             
                                        </div>
                                    </div>                        

                                </div>
                            
                            <div class="panel-footer">                                        
                                <asp:Button ID="btnsave" Text="Save" runat="server" ValidationGroup="a" OnClick="btnsave_Click"   CssClass="btn btn-success btnSave" />
                            <asp:Button ID="btnclear" Text="Clear" runat="server" OnClick="btnclear_Click" CssClass="btn btn-default btnClear" />
                            <asp:Button ID="btnexit" runat="server" PostBackUrl="Dashboard.aspx" CssClass="btn btn-danger" Text="Exit" />
                            <div class="alertMsg success" runat="server"  id="pnlSuccess"></div>
                            <div class="alertMsg failed" runat="server" id="pnlfailed"></div>
                            </div>
                             </div>    
                        </div>
            </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

