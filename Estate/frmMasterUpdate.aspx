<%@ Page Title="" Language="C#" MasterPageFile="~/Estate/MainMaster.master" AutoEventWireup="true" CodeFile="frmMasterUpdate.aspx.cs" Inherits="Estate_frmMasterUpdate" %>
<%--<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 <style>
              .ui-datepicker {
              z-index:99 !important;
                   }
              .form-control{
                  height:30px;
              }
   </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <div class="col-sm-10 col-sm-offset-1">
        <div class="panel panel-primary mt10">
            <div class="panel-heading">
                <h3 class="panel-title">Master Update</h3>
            </div>
            <div class="panel-body form-horizontal scheme-form-group">

                 <div class="form-group">
                    <div class="row">
                        <div class="col-xs-12 col-sm-6">                         
                            <label class="col-xs-12 col-sm-5 required" style="white-space:nowrap">Ref No.</label>
                            <div class="col-xs-12 col-sm-5">
                             <asp:TextBox runat="server" ID="txtRefNo" placeholder="Ref No." CssClass="form-control" MaxLength="10"></asp:TextBox> 
                                   <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtRefNo" FilterMode="ValidChars" FilterType="Numbers" ValidChars=" " />
                                  </div>
                             <div class="col-xs-12 col-sm-2">                            
                            <asp:LinkButton runat="server" Text="Search" Height="30px" ID="btnSearch" OnClick="btnSearch_Click"  CssClass="btn btn-primary"></asp:LinkButton>                                                          
                        </div>  
                                </div>                             
                               
                                   
                           <div class="col-xs-12 col-sm-6">                         
                            <label class="col-xs-12 col-sm-5" style="white-space:nowrap;">Service No.</label>
                            <div class="col-xs-12 col-sm-7">
                               <asp:TextBox runat="server" ID="txtServiceNo" placeholder="Service NO."  CssClass="form-control"></asp:TextBox>
                                  </div>
                                </div>    
                    </div>
                </div>

                <hr />
             
                     <div class="panel panel-primary" style="background-color:#efefef;">
          
            <div class="panel-body form-horizontal scheme-form-group">
                <div class="form-group">
                    <div class="row ">
                       <div class="col-xs-12 col-sm-6">
                            <label class="col-xs-12 col-sm-5"> Plot Holder Name</label>
                            <div class="col-xs-12 col-sm-7">
                                   <asp:TextBox runat="server" ID="txtPlotHolderName" Enabled="false" placeholder="Plot Holder Name" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>     
                       <div class="col-xs-12 col-sm-6">
                            <label class="col-xs-12 col-sm-5">  Property NO.</label>
                            <div class="col-xs-12 col-sm-7">
                                    <asp:TextBox runat="server" ID="txtPropertyNo" Enabled="false" placeholder=" Property NO." CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>                                                                                  
                    </div>
                </div>

                <div class="form-group">
                 <div class="row">
                        <div class="col-xs-12 col-sm-6">
                            <label class="col-xs-12 col-sm-5" > Total No. Of Installment</label>
                            <div class="col-xs-12 col-sm-7">
                                    <asp:TextBox runat="server" ID="txtTotNoInst" Enabled="false" placeholder="Total No. Of Installment" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>     
                       <div class="col-xs-12 col-sm-6">
                            <label class="col-xs-12 col-sm-5 ">  Total No. Of Paid Inst.</label>
                            <div class="col-xs-12 col-sm-7">
                                   <asp:TextBox runat="server" ID="txtTotPaidInst" Enabled="false" placeholder="Total No. Of Paid Inst." CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>                                                                 
                    </div>
                    </div>
                </div></div>

                <div class="form-group">
                    <div class="row">
                        <div class="col-xs-12 col-sm-4">
                            <label class="col-xs-12 col-sm-5" >Property Cost</label>
                            <div class="col-xs-12 col-sm-7">
                                    <asp:TextBox runat="server" ID="txtPropCost" placeholder="Property Cost" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>     
                       <div class="col-xs-12 col-sm-4">
                            <label class="col-xs-12 col-sm-5">Down Pay Per.</label>
                            <div class="col-xs-12 col-sm-7">
                                   <asp:TextBox runat="server" ID="txtDownPer" placeholder="Down Pay Per." CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>   
                        <div class="col-xs-12 col-sm-4">
                            <label class="col-xs-12 col-sm-5"> Down Pay Amt.</label>
                            <div class="col-xs-12 col-sm-7">
                                    <asp:TextBox runat="server" ID="txtDownAmt" placeholder="Down Pay Amt." CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>                                                                 
                    </div>
                    </div>

                <div  class="form-group">
                     <div class="row">
                        <div class="col-xs-12 col-sm-4">
                            <label class="col-xs-12 col-sm-5">Loan Amt.</label>
                            <div class="col-xs-12 col-sm-7">
                                    <asp:TextBox runat="server" ID="txtLoanAmt" placeholder="Loan Amt." CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>     
                       <div class="col-xs-12 col-sm-4">
                            <label class="col-xs-12 col-sm-5">EMD Amt.</label>
                            <div class="col-xs-12 col-sm-7">
                                    <asp:TextBox runat="server" ID="txtEmdAmt" placeholder="EMD Amt." CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>  
                       <div class="col-xs-12 col-sm-4">
                            <label class="col-xs-12 col-sm-5">Interest Rate</label>
                            <div class="col-xs-12 col-sm-7">
                                   <asp:TextBox runat="server" ID="txtIntRate" placeholder="Interest Rate" CssClass="form-control"></asp:TextBox>
                                  <%--<cc1:maskededitextender ID="MaskedEditExtender2" runat="server" AutoComplete="false"
                                                    AutoCompleteValue="10" CultureName="en-US" Mask="9999999999%" MaskType="Number" TargetControlID="txtIntRate"
                                                    UserDateFormat="None">
                                                </cc1:maskededitextender>--%>
                            </div>                                                                                                         
                    </div>                   
                </div>                                                                                                                       
                    </div>   

                 <div  class="form-group">                     
                  <div class="row">
                        <div class="col-xs-12 col-sm-4">
                            <label class="col-xs-12 col-sm-5">Inst Start Date</label>
                            <div class="col-xs-12 col-sm-7">
                                    <asp:TextBox runat="server" data-date-format="dd/mm/yyyy" placeholder="DD/MM/YYYY"  ID="txtStartDate" CssClass="form-control datepicker"></asp:TextBox>
                            </div>
                        </div>     
                      <%-- <div class="col-xs-12 col-sm-4">
                            <label class="col-xs-12 col-sm-5 required">EMD Amt.</label>
                            <div class="col-xs-12 col-sm-7">
                                    <asp:TextBox runat="server" ID="TextBox2" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>  
                       <div class="col-xs-12 col-sm-4">
                            <label class="col-xs-12 col-sm-5 required">Interest Rate</label>
                            <div class="col-xs-12 col-sm-7">
                                   <asp:TextBox runat="server" ID="TextBox5" CssClass="form-control"></asp:TextBox>
                            </div>  --%>                                                                                                       
                    </div>            
                 
                 </div>
                                
                </div>
                

               
                            <div class="panel-footer">                                        
                            <asp:Button ID="btnUpdate" Text="Update" runat="server" OnClick="btnUpdate_Click" CssClass="btn btn-success btnSave" />
                            <asp:Button ID="btnClear" Text="Clear" runat="server" OnClick="btnClear_Click"   CssClass="btn btn-default btnClear" />
                            <asp:Button ID="btnExit" runat="server" PostBackUrl="Dashboard.aspx" CssClass="btn btn-danger" Text="Exit" />
                            <div class="alertMsg success" runat="server"  id="pnlSuccess"></div>
                            <div class="alertMsg failed" runat="server" id="pnlfailed"></div>
                            </div>
         </div></div>
</asp:Content>

