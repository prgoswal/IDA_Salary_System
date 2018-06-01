<%@ Page Title="" Language="C#" MasterPageFile="~/FrontOffice/MainMaster.master" AutoEventWireup="true" CodeFile="test.aspx.cs" Inherits="test" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="../js/jquery-1.6.4.min.js"></script>
    <script src="../js/jquery.signalR-2.2.0.js"></script>
    <script type="text/javascript" src="http://localhost:9090/signalr/hubs"></script>   
     
    


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    
 <%--  <asp:Button ID="btnscan" Text="Scan" runat="server" CssClass="btn btn-warning  btn-xs" OnClientClick="return ShowSendingProgress();"  />--%>
    
  <input type="button" onclick="getScanner()" value="Scan" />
    <img height="300" width="300" id="imgscan" />
    

    <script type="text/javascript">      

        function getScanner() {
            debugger;
            $('.loading').addClass('actives');
            
            alert("fi");           
            
        }

        function getScannerImg() {

            ShowSendingProgress();

            //Set the hubs URL for the connection
            $.connection.hub.url = "http://localhost:9090/signalr";
            // Declare a proxy to reference the hub.
            var chat = $.connection.myHub;

            // Create a function that the hub can call to broadcast messages.
             chat.client.addMessage = function (name, message) {
                debugger;
                console.log(message);

                $('#imgscan').attr('src', 'data:image/png;base64,' + message);
                StopProgress();
            };

            var myVar;
            $.connection.hub.start().done(function () {
                var imgdata = chat.server.send(720, 400);
                console.log(imgdata);

                // $('#message').val('').focus();
            });

           
            return false;

        }
    </script>

</asp:Content>

