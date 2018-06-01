<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WebUserControl.ascx.cs" Inherits="UserControl_WebUserControl" %>
 <div class="sidebar">
                    <div class="sidebar-inner">
                        <div class="userinfo">
                            <div class="userinfo-img-container">
                                <div class="userinfo-pic">
                                    <img src="img/user.png" />
                                </div>
                            </div>
                            <div class="userinfo-txt-container">
                                <div class="userinfo-name">Durgesh Sir</div>
                                <div class="userinfo-level">Admin</div>
                            </div>
                        </div>
                        <ul class="sidenav">
                            <li>
                                <a href="FrmSchemeMaster.aspx">
                                    <i class="fa fa-dashboard fa-sidenav"></i>
                                    <span class="text-sidenav">Scheme Master</span>
                                </a>
                            </li>
                            <li>
                                <a href="FrmSectorMaster.aspx">
                                    <i class="fa fa-dashboard fa-sidenav"></i>
                                    <span class="text-sidenav">Sector Master</span>
                                </a>
                            </li>
                            <li>
                                <a href="#" data-toggle="collapse" data-target="#ine" class="collapsed">
                                    <i class="fa fa-gears fa-sidenav"></i>
                                    <span class="text-sidenav">Dashboard</span>
                                </a>
                                <ul class="sidenav collapse" id="ine">
                                    <li>
                                        <a href="#">
                                            <span class="text-sidenav">in 1</span>
                                        </a>
                                    </li>
                                </ul>
                            </li>

                        </ul>
                    </div>
                </div>