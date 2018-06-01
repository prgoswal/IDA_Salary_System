<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Administrator.ascx.cs" Inherits="UserControl_Administrator" %>
<div runat="server" id="logo" class="sidebar">
    <div class="sidebar-inner">
       
        <ul class="sidenav">
            <li>
                <a href="<%# ResolveUrl("~/FrontOffice/Dashboard.aspx")%>">
                    <i class="fa fa-dashboard fa-sidenav"></i>
                    <span class="text-sidenav">Dashboard</span>
                </a>
            </li>
            <li>
                <a href="#" data-toggle="collapse" data-target="#ine" class="collapsed">
                    <i class="fa fa-gears fa-sidenav"></i>
                    <span class="text-sidenav">Masters</span>
                </a>
                <ul class="sidenav collapse" id="ine">
                    
                    <li>
                        <a href="<%# ResolveUrl("~/FrontOffice/Administrator/frm_InwardCategory.aspx")%>">

                            <span class="text-sidenav">Inward Category</span>
                        </a>
                    </li>
                    <li>
                        <a href="<%# ResolveUrl("~/FrontOffice/Administrator/frm_DepartmentService.aspx")%>">

                            <span class="text-sidenav">Department Services </span>
                        </a>
                    </li>

                    <li>
                        <a href="<%# ResolveUrl("~/FrontOffice/Administrator/frm_DepartmentServiceMatter.aspx")%>">

                            <span class="text-sidenav">Department Services Matter </span>
                        </a>
                    </li>
                    <li>
                        <a href="<%# ResolveUrl("~/FrontOffice/Administrator/frm_DepartmentServicematterDoc.aspx")%>">

                            <span class="text-sidenav">Department Services Matter Document </span>
                        </a>
                    </li>
                    <%--<li>
                                          <a href="<%# ResolveUrl("~/FrontOffice/Administrator/frm_DepartmentEmployee.aspx")%>">

                                            <span class="text-sidenav">Department Employee </span>
                                        </a>
                                    </li>--%>
                  <%--  <li>
                        <a href="<%# ResolveUrl("~/FrontOffice/Administrator/frm_RegisterComplain.aspx")%>">

                            <span class="text-sidenav">Register Complain</span>
                        </a>
                    </li>--%>
                    <li>
                        <a href="<%# ResolveUrl("~/FrontOffice/Administrator/frm_EmpServicesAssign.aspx")%>">

                            <span class="text-sidenav">Department Wise Employee Services</span>
                        </a>
                    </li>
                </ul>
            </li>
            <li>
                <a href="#" data-toggle="collapse" data-target="#ine1" class="collapsed">
                    <i class="fa fa-gears fa-sidenav"></i>
                    <span class="text-sidenav">Services</span>
                </a>
                <ul class="sidenav collapse" id="ine1">   
                    <li>
                        <a href="<%# ResolveUrl("~/FrontOffice/Administrator/frm_InwardApplication.aspx")%>">

                            <span class="text-sidenav">Appilcation</span>
                        </a>
                    </li>
                    <li>
                        <a href="#">
                            <span class="text-sidenav">Enquiry</span>
                        </a>
                    </li>
                    
                </ul>
            </li>

        </ul>
    </div>
</div>
