<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EntryLevel.ascx.cs" Inherits="UserControl_EntryLevel" %>
<div class="sidebar">
    <div class="sidebar-inner">

        <ul class="sidenav" id="myGroup">
            <li>
                <a href="<%= ResolveUrl("~/Demand/Dashboard.aspx")%>">
                    <i class="fa fa-dashboard fa-sidenav"></i>
                    <span class="text-sidenav">Dashboard</span>
                </a>
            </li>

            <li>
                <a href="#" data-toggle="collapse" data-target="#ine1" class="collapsed">
                    <i class="fa fa-gears fa-sidenav"></i>
                    <span class="text-sidenav">Master</span>
                </a>
                <ul class="sidenav collapse first-level" id="ine1">
                   
                </ul>
            </li>
            <li>
                <a href="#" data-toggle="collapse" data-target="#ine" class="collapsed">
                    <i class="fa fa-gears fa-sidenav"></i>
                    <span class="text-sidenav">Demand</span>
                </a>
                <ul class="sidenav collapse first-level" id="ine">
                    <li>
                        <a href="<%= ResolveUrl("~/Demand/FrmGenerateDemand.aspx")%>">
                            <span class="text-sidenav">Generate Demand</span>
                        </a>
                    </li>
                </ul>
            </li>
        </ul>
    </div>
</div>
