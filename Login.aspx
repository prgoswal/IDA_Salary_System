<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>IDA : Indore Development Authority</title>
    <!-- Styles -->
    <link rel="icon" href="favicon.ico" />
      
    <link href="<%= ResolveUrl("~/Content/css/bootstrap.css")%>" rel="stylesheet" />
    <link href="<%= ResolveUrl("~/Content/css/fa.css")%>" rel="stylesheet" />
    <link href="<%= ResolveUrl("~/Content/css/SystemCss/style.css")%>" rel="stylesheet" />
    <style>
        @media (min-width:768px) {
            body {
                overflow:hidden
            }
        }
    </style>
    <!-- Styles -->
    <!-- Scripts Start -->
     <script src="<%= ResolveUrl("~/Content/js/jquery.js") %>" type="text/javascript"></script>
    <script src="<%= ResolveUrl("~/Content/js/bootstrap.js") %>" type="text/javascript"></script>
    <script src="<%= ResolveUrl("~/Content/js/app.js") %>" type="text/javascript"></script>
    <script>
        $(document).ready(function () {
            var wh = parseInt($(window).height() - 170);
            $('.login-page').css('min-height',wh)
        });
        $(window).resize(function () {
            var wh = parseInt($(window).height() - 170);
            $('.login-page').css('min-height', wh)
        });
    </script>
    <!-- Scripts End -->
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="scr" runat="server"></asp:ScriptManager>
        <div>
            <div class="container-fluid top-row"></div>
            <div class="container-fluid logo-navbar">
                <div class="row">
                    <div class="container">
                        <div class="logo-img">
                            <img src="Content/img/logo.png" />
                        </div>
                        <div class="logo-img-right">
                            <img src="Content/img/dindayal.png" />
                        </div>
                        <div class="logo-text">
                            <span class="logo-text-heading">Indore Development Authority
                            </span>
                            <span class="logo-tag-line">Where construction is a never ending process...
                            </span>
                        </div>

                    </div>
                </div>
            </div>
              
            <nav class="navbar navbar-default navbar-ida">
                <div class="navbar-header">
                    <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#navbar" aria-expanded="false" aria-controls="navbar">
                        <i class="fa"></i>
                    </button>
                   
                </div>
                <div class="container">
                    <div class="row">
                        <div id="navbar" class="navbar-collapse collapse">
                            <%--<ul class="nav navbar-nav ">
                                  <li><a class="webHome hidden" href="frmHomePage.aspx">Home</a></li>                              
                                 <li><a class="visible-after-login" href="frmSystem.aspx">Home</a></li>
                            </ul>--%>
                              <ul class="nav navbar-nav navbar-right ">
                                 
                            </ul>
                        </div>
                    </div>
                </div>
            </nav>
        </div>
        <div class="container-fluid">
            <div class="row">
            <div class="wrapper login-page" style="">
                <div class="content">
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col-xs-12 ">
                                <div class="home-text">
                                    Welcome to
                                    <br />
                                    Indore Development Authority.
                                </div>
                                <div class="login-card">
                                    <div class="login-img">
                                        <img src="Content/img/ida.png" />
                                    </div>
                                    <div class="login-title">Indore Development Authority</div>
                                    <div class="form-group">
                                        <asp:TextBox ID="txtUserName" Placeholder="Username" runat="server" class="form-control" MaxLength="30"></asp:TextBox>
                                        <i class="fa fa-user"></i>
                                    </div>
                                    <div class="form-group">
                                        <asp:TextBox ID="txtPassword" Placeholder="Password" runat="server" class="form-control" TextMode="Password" MaxLength="30"></asp:TextBox>
                                        <i class="fa fa-lock"></i>
                                    </div>
                                    <div class="form-group">
                                        <%-- <a href="frmSystem.aspx" class="btn btn-block btn-theme">Login</a>--%>
                                        <asp:Button ID="btnLogin" runat="server" class="btn btn-block btn-theme" Text="Login" OnClick="btnLogin_Click"  />
                                        <asp:Label ID="lblmsg" runat="server" CssClass="errorMsg" ForeColor="Red" Visible="false"></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            </div>
        </div>
        <footer>
            <div class="container-fluid part2">
                <div class="row">
                    &copy; 2017, All Rights Reserved.
                </div>
            </div>
        </footer>
    </form>
</body>
</html>
