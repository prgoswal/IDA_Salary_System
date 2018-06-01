using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class test : System.Web.UI.Page
{
    HttpClient HClient = new HttpClient(); 
    protected void Page_Load(object sender, EventArgs e)
    {
        List<Cat> moreCats = new List<Cat> { };

       moreCats = new List<Cat>
        {
            new Cat(){ Name = "Furrytail", Age=5 },
            new Cat(){ Name = "Peaches", Age=4 },
            
        };

        foreach (Cat c in moreCats)
        {
            int a = c.Age;
        }
        if (!this.IsPostBack)
        {
            string url = ConfigurationManager.AppSettings["ImageUrl"].ToString();
            //DataTable dt = new DataTable();
            //dt.Columns.AddRange(new DataColumn[3] { new DataColumn("Id"), new DataColumn("Name"), new DataColumn("Country") });
            //dt.Rows.Add(1, "John Hammond", "United States");
            //dt.Rows.Add(2, "Mudassar Khan", "India");
            //dt.Rows.Add(3, "Suzanne Mathews", "France");
            //dt.Rows.Add(4, "Robert Schidner", "Russia");
            //GridView1.DataSource = dt;
            //GridView1.DataBind();

            //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "a();", true);
        }
         //// Load the Google Transliterate API
         //google.load("elements", "1", {
         //    packages: "transliteration"
         //});

         //function onLoad() {
         //    var options = {
         //        sourceLanguage:
         //        google.elements.transliteration.LanguageCode.ENGLISH,
         //        destinationLanguage:
         //        [google.elements.transliteration.LanguageCode.HINDI],
         //        transliterationEnabled: true
         //    };

         //    // Create an instance on TransliterationControl with the required
         //    // options.
         //    var control =
         //    new google.elements.transliteration.TransliterationControl(options);

         //    // Enable transliteration in the textbox with id
         //    // 'transliterateTextarea'.
         //    control.makeTransliteratable(['<%=transliterateTextarea.ClientID%>']);
         //}
         //google.setOnLoadCallback(onLoad);
    }



   //    <%--  <script type="text/javascript" src="https://www.google.com/jsapi">
   // </script>--%>
   //<%-- <script src="http://code.jquery.com/jquery-latest.js"></script>
   // <script type="text/javascript" src="http://api.jquery.com/scripts/events.js"></script>
   // <script type="text/javascript" src="http://www.google.com/jsapi"></script>
   // <script type="text/javascript">
   //     google.load("language", "1");
   // </script>--%>
   // <%--<script type="text/javascript">

   //     $("#<%=target.ClientID%>").keyup(function (event) {

   //         var str = $("#<%=target.ClientID%>").val().toString();
   //         var a = str.split(' ');

   //         google.language.transliterate(a, "en", "hi", function (result) {
   //             var container = document.getElementById("<%=transliterateTextarea.ClientID%>");

   //             var data = "";
   //             for (var i = 0; i < result.transliterations.length; i++) {
   //                 data = data + " " + result.transliterations[i].transliteratedWords[0];
   //             }
   //             container.innerText = data;;
   //         });

   //     });
   // </script>--%>
   // <%--<script>
   //     // var s = document.createElement('script'); s.setAttribute('src', 'http://developer.quillpad.in/static/js/quill.js?lang=Hindi&key=30539a066ed34ea27fe9f2e9a488613a');
   //     // s.setAttribute('id', 'qpd_script');
   //     //// s.setAttribute('id', 'txt1');
   //     // document.head.appendChild(s);

   //     var s = document.createElement('script'); s.setAttribute('src', 'http://developer.quillpad.in/static/js/quill.js?lang=Hindi&key=30539a066ed34ea27fe9f2e9a488613a');
   //     s.setAttribute('id', 'qpd_script');
   //     // s.setAttribute('id', 'txt1');
   //     document.head.appendChild(s);
   //     //document.getElementById("txt3").appendChild(s);

   // </script>--%>

   // <%--<script>
   //     // Load the Google Transliterate API
   //     google.load("elements", "1", {
   //         packages: "transliteration"
   //     });

   //     function onLoad() {
   //         var options = {
   //             sourceLanguage:
   //             google.elements.transliteration.LanguageCode.ENGLISH,
   //             destinationLanguage:
   //             [google.elements.transliteration.LanguageCode.HINDI],
   //             shortcutKey: 'ctrl+g',
   //             transliterationEnabled: true
   //         };

   //         // Create an instance on TransliterationControl with the required
   //         // options.
   //         var control =
   //         new google.elements.transliteration.TransliterationControl(options);

   //         // Enable transliteration in the textbox with id
   //         // 'transliterateTextarea'.
   //         control.makeTransliteratable(['<%=transliterateTextarea.ClientID%>']);
   //   }
   //   google.setOnLoadCallback(onLoad);

   // </script>--%>


    //<textarea id="transliterateTextarea" runat="server" width="600px" ></textarea>--%>
    //<asp:TextBox ID="target" runat="server"></asp:TextBox>
    //<asp:TextBox ID="transliterateTextarea" runat="server" TextMode="MultiLine" Width="600px"></asp:TextBox>
    //<%-- <asp:TextBox ID="txt1" runat="server"></asp:TextBox>--%>

    //<%--'#<%=transliterateTextarea.ClientID%>'


  




}

class Cat
{
    // Auto-implemented properties.
    public int Age { get; set; }
    public string Name { get; set; }
}