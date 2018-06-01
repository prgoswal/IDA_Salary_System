<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EntryLevel.ascx.cs" Inherits="UserControl_EntryLevel" %>
 <div class="sidebar">
                    <div class="sidebar-inner">
                        
                        <ul class="sidenav" id="myGroup">
                            <li>
                                <a href="<%= ResolveUrl("~/Estate/Dashboard.aspx")%>">
                                    <i class="fa fa-dashboard fa-sidenav"></i>
                                    <span class="text-sidenav">Dashboard</span>
                                </a>
                            </li>
                           
                            <li>
                                <a href="#" data-toggle="collapse" data-target="#ine" class="collapsed">
                                    <i class="fa fa-gears fa-sidenav"></i>
                                    <span class="text-sidenav">Scheme Master</span>
                                </a>
                                <ul class="sidenav collapse first-level" id="ine">      
                                     <li>
                                       <a href="<%= ResolveUrl("~/Estate/frmSchMaster.aspx")%>">
                                            <span class="text-sidenav">Scheme Master</span>
                                        </a>
                                    </li>  
                                     <li>
                                       <a href="<%= ResolveUrl("~/Estate/frmSchSector.aspx")%>">
                                            <span class="text-sidenav">Sector Master</span>
                                        </a>
                                    </li>   
                                    <li>
                                       <a href="<%= ResolveUrl("~/Estate/frmSchPlotTypeAssign.aspx")%>">
                                            <span class="text-sidenav">Scheme Wise Plot Category</span>
                                        </a>
                                    </li>  
                                    <li>
                                       <a href="<%= ResolveUrl("~/Estate/frmSchAreaDetail.aspx")%>">
                                            <span class="text-sidenav">Scheme Wise Size Wise Facility Area</span>
                                        </a>
                                    </li>
                                    <li>
                                       <a href="<%= ResolveUrl("~/Estate/frmSchPlotingDetail.aspx")%>">
                                            <span class="text-sidenav">Scheme Wise Size Wise Ploting</span>
                                        </a>
                                    </li>  
                                      <li>
                                       <a href="<%= ResolveUrl("~/Estate/frmPlotNoAllotment.aspx")%>">
                                            <span class="text-sidenav">Scheme Wise Ploting</span>
                                        </a>
                                    </li>       
                                       <li>
                                       <a href="<%= ResolveUrl("~/Estate/frmPropertyMatser.aspx")%>">
                                            <span class="text-sidenav">Property Master</span>
                                        </a>
                                    </li>                                                                                                                                                     
                                </ul>
                            </li>
                            <li>
                                <a href="#" data-toggle="collapse" data-target="#ine1" class="collapsed toggle">
                                    <i class="fa fa-gears fa-sidenav"></i>
                                    <span class="text-sidenav">Other Master</span>
                                </a>
                                <ul class="sidenav collapse first-level" id="ine1">                                    
                                    <li>
                                       <a href="<%= ResolveUrl("~/Estate/FrmDevCategory.aspx")%>">
                                            <span class="text-sidenav">Developer Category</span>
                                        </a>
                                    </li>
                                    <li>
                                       <a href="<%= ResolveUrl("~/Estate/FrmDeveloper.aspx")%>">
                                            <span class="text-sidenav">Developer Master</span>
                                        </a>
                                    </li>
                                    <li>
                                     <a href="<%= ResolveUrl("~/Estate/FrmWard.aspx")%>">
                                            <span class="text-sidenav">Ward Master</span>
                                        </a>
                                    </li>
                                    <li>
                                         <a href="<%= ResolveUrl("~/Estate/FrmZone.aspx")%>">
                                            <span class="text-sidenav">Zone Master</span>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="<%= ResolveUrl("~/Estate/FrmUseMaster.aspx")%>">
                                            <span class="text-sidenav">Use Type Master</span>
                                        </a>
                                    </li>
                                      <li>
                                       <a href="<%= ResolveUrl("~/Estate/frmPlotTypeMaster.aspx")%>">
                                            <span class="text-sidenav">Plot Type Master</span>
                                        </a>
                                    </li>
                                    <li>
                                       <a href="<%= ResolveUrl("~/Estate/FrmSchOtherFacility.aspx")%>">
                                            <span class="text-sidenav">Scheme Other Facility Area Master</span>
                                        </a>
                                    </li>                                                                                                                                                                                                                                                             
                                     <li>
                                       <a href="<%= ResolveUrl("~/Estate/frmPlotSituation.aspx")%>">
                                            <span class="text-sidenav">Plot Situation Type Master</span>
                                        </a>
                                    </li>
                                     
                                </ul>
                            </li>
                             <li>
                                <a href="#" data-toggle="collapse" data-target="#ine3" class="collapsed toggle">
                                    <i class="fa fa-gears fa-sidenav"></i>
                                    <span class="text-sidenav">Updation</span>
                                </a>
                                <ul class="sidenav collapse first-level" id="ine3">                                    
                                     <li>
                                       <a href="<%= ResolveUrl("~/Estate/frmMasterUpdate.aspx")%>">
                                            <span class="text-sidenav">Master Record Update</span>
                                        </a>
                                    </li>                                                                      
                                </ul>
                            </li>
                             <li>
                                <a href="#" data-toggle="collapse" data-target="#ine2" class="collapsed">
                                    <i class="fa fa-gears fa-sidenav"></i>
                                    <span class="text-sidenav">Report</span>
                                </a>
                                <ul class="sidenav collapse first-level" id="ine2">                                    
                                    <li>
                                       <a href="<%= ResolveUrl("~/Estate/Report/Rpt_LeaseLedger.aspx")%>">
                                            <span class="text-sidenav">Scheme Wise Ledger</span>
                                        </a>
                                    </li>                                   
                                </ul>
                            </li>

                        </ul>
                    </div>
                </div>
