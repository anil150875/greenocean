<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="GreenOcean.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script type="text/javascript">
         function CalculateTotal()
         {
             var gv = document.getElementById("<%= GridView1.ClientID%>");
             var tb = gv.getElementsByTagName("input");
             var lb = gv.getElementsByTagName("span");
             var sub=0;
             var total=0;
          
             var indexp = 0;
             var indexq = 1;
             var price = 0;
             var qty = 0;
             var totalqty = 0;
             var tbcount = tb.length / 2;
             for (var i = 0; i < tbcount; i++)
             {
                 if(tb[i].type="text")
                 {
                     sub = parseFloat(tb[i + indexp].value) * parseFloat(tb[i + indexq].value);
                     if(isNaN(sub))
                     {
                         lb[i].innerHTML = "0.0";
                         sub = 0;
                     }
                     else
                     {
                         lb[i].innerHTML = sub;
                     }
                     if(isNaN(tb[i+indexp].value) || tb[i+indexq].value=="")
                     {
                         qty=0;
                     }
                     else
                     {
                         qty=tb[i+indexq].value;

                     }
                     totalqty=totalqty+parseInt(qty);
                     total=total+parseFloat(sub);
                 }
                 indexp++;
                 indexq++;

             }
             lb[tbcount].innerHTML = "Total Quantity "+totalqty;
             lb[tbcount+1].innerHTML = "Grand Total "+total;


         }
         </script>

</head>
<body>
    <form id="form1" runat="server">
        <div>

        </div>
        <asp:GridView ID="GridView1" runat="server">
            <Columns>
                <asp:BoundField />
                <asp:BoundField />
                <asp:TemplateField></asp:TemplateField>
                <asp:TemplateField></asp:TemplateField>
                <asp:BoundField />
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
