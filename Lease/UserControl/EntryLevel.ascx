<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EntryLevel.ascx.cs" Inherits="UserControl_EntryLevel" %>
  <div class="sidebar">
                    <div class="sidebar-inner">
                       
                        <ul class="sidenav">
                           <%-- <li>
                                <a href="FrmSchemeMaster.aspx">
                                    <i class="fa fa-dashboard fa-sidenav"></i>
                                    <span class="text-sidenav">Scheme Master</span>
                                </a>
                            </li>--%>
                            <li>
                                <a href="#">
                                    <i class="fa fa-dashboard fa-sidenav"></i>
                                    <span class="text-sidenav">Menu1</span>
                                </a>
                            </li>
                            <li>
                                <a href="#" data-toggle="collapse" data-target="#ine" class="collapsed">
                                    <i class="fa fa-gears fa-sidenav"></i>
                                    <span class="text-sidenav">Master</span>
                                </a>
                                <ul class="sidenav collapse" id="ine">                                   
                                     <li>
                                        <a href="<%= ResolveUrl("~/Lease/FrmScanningFileEntry.aspx")%>"> 
                                            <span class="text-sidenav">Scan File Entry</span>
                                        </a>
                                    </li>
                                 
                                    <li>
                                        <a href="<%= ResolveUrl("~/Lease/frmImgCrop.aspx") %>">
                                            <span class="text-sidenav">Document Image Croping</span>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="<%= ResolveUrl("~/Lease/frmDocumentDisplay.aspx") %>">
                                            <span class="text-sidenav">Document Image Display</span>
                                        </a>
                                    </li>
                                    <li>
                                         <a href="<%= ResolveUrl("~/Lease/frmFileTrackNoRpt.aspx") %>">
                                            <span class="text-sidenav">Scanning Sticker Print </span>
                                        </a>
                                    </li>
                                </ul>
                            </li>

                        </ul>
                    </div>
                </div>