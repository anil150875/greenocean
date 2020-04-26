<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="quote.aspx.cs" Inherits="GreenOcean.quote" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div class="col-md-12">
         <h1> Business Name :  <asp:Label ID="lblBusiness" runat="server" Text="Business"></asp:Label></h1>
         <hr />
     </div>
   
    <div class="col-md-6" style="left: 0px; top: 0px">
        <h3>Electricity</h3>

         <table style="width: 100%;">
        <tr>
            <td>&nbsp;Search with MPAN</td>
           
              
            <td>
               
        </tr>
        <tr>
            <td>
                <asp:DropDownList ID="ddProfile" runat="server" Width="71px">
                    <asp:ListItem>00</asp:ListItem>
                    <asp:ListItem>01</asp:ListItem>
                    <asp:ListItem>02</asp:ListItem>
                    <asp:ListItem Selected="True">03</asp:ListItem>
                    <asp:ListItem>04</asp:ListItem>
                    <asp:ListItem>05</asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox ID="txtELEMTC" runat="server">801</asp:TextBox>
                <asp:TextBox ID="TextBox5" runat="server" MaxLength="3"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:DropDownList ID="ddEleRegion" runat="server" Width="71px">
                    <asp:ListItem>00</asp:ListItem>
                    <asp:ListItem>01</asp:ListItem>
                    <asp:ListItem>02</asp:ListItem>
                    <asp:ListItem>03</asp:ListItem>
                    <asp:ListItem>04</asp:ListItem>
                    <asp:ListItem>05</asp:ListItem>
                    <asp:ListItem>06</asp:ListItem>
                    <asp:ListItem>07</asp:ListItem>
                    <asp:ListItem>08</asp:ListItem>
                    <asp:ListItem>09</asp:ListItem>
                    <asp:ListItem>10</asp:ListItem>
                    <asp:ListItem>11</asp:ListItem>
                    <asp:ListItem>12</asp:ListItem>
                    <asp:ListItem>14</asp:ListItem>
                    <asp:ListItem>15</asp:ListItem>
                    <asp:ListItem>16</asp:ListItem>
                    <asp:ListItem>17</asp:ListItem>
                    <asp:ListItem Selected="True">18</asp:ListItem>
                    <asp:ListItem>19</asp:ListItem>
                    <asp:ListItem>20</asp:ListItem>
                    <asp:ListItem>21</asp:ListItem>
                    <asp:ListItem>22</asp:ListItem>
                    <asp:ListItem>23</asp:ListItem>
                    <asp:ListItem>24</asp:ListItem>
                    <asp:ListItem>25</asp:ListItem>
                    <asp:ListItem>26</asp:ListItem>
                    <asp:ListItem>27</asp:ListItem>
                    <asp:ListItem>28</asp:ListItem>
                    <asp:ListItem>29</asp:ListItem>
                    <asp:ListItem>30</asp:ListItem>
                    <asp:ListItem>31</asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox ID="TextBox6" runat="server" MaxLength="11"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
        <table style="width: 100%;">
            <tr>
                <td>Current Supplier</td>
                <td>
                    <asp:DropDownList ID="DDELESupplier" runat="server">
                        <asp:ListItem Value="bg" Selected="True">British Gas</asp:ListItem>
                        <asp:ListItem Value="bgl">British Gase LE</asp:ListItem>
                        <asp:ListItem Value="de">Duel Energy</asp:ListItem>
                        <asp:ListItem Value="edf">EDF</asp:ListItem>
                    </asp:DropDownList>
                </td>
                
            </tr>
            <tr>
                <td>Business Type</td>
                <td>
                    <asp:DropDownList ID="DDELEBusinesstype" runat="server">
                        <asp:ListItem>Others</asp:ListItem>
                    </asp:DropDownList>
                </td>
                
            </tr>
             <tr>
                <td>EAC</td>
                <td>
                    <asp:TextBox ID="txtELEEAC" runat="server">4999</asp:TextBox>
                 </td>
                
            </tr>
            <tr>
                <td>Start Date</td>
                <td>
                    <asp:Calendar ID="CalEleStartDate"  SelectedDate="<%# DateTime.Today %>"  runat="server"></asp:Calendar>
                </td>
                
            </tr>


            
            <tr>
                <td>Duration</td>
                <td>
                    <asp:TextBox ID="txtELEDuration" runat="server">12</asp:TextBox>
                </td>
                
            </tr>


            
            <tr>
                <td>Payment mode</td>
                <td>
                    <asp:TextBox ID="txtElepaymentMode" runat="server">DD</asp:TextBox>
                </td>
                
            </tr>


            
            <tr>
                <td>
                    <asp:Button ID="btnEleTerrif"   SelectedDate="<%# DateTime.Today %>"  runat="server" OnClick="btnEleTerrif_Click" Text="Find Terriffs" Width="119px" />
                </td>
                <td>&nbsp;</td>
                
            </tr>


            
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                
            </tr>


            
        </table>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>

     </div>

    <div class="col-md-6">
        <h3>Gas</h3>
         <table style="width: 100%;">
        <tr>
            <td>&nbsp;Search with MPR</td>
           
              
            <td>
               
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        </table>
        <table style="width: 100%;">
            <tr>
                <td>Current Supplier</td>
                <td>
                    <asp:DropDownList ID="DDGASSupplier0" runat="server">
                        <asp:ListItem Value="bg" Selected="True">British Gas</asp:ListItem>
                        <asp:ListItem Value="bgl">British Gase LE</asp:ListItem>
                        <asp:ListItem Value="de">Duel Energy</asp:ListItem>
                        <asp:ListItem Value="edf">EDF</asp:ListItem>
                    </asp:DropDownList>
                </td>
                
            </tr>
            <tr>
                <td>Business Type</td>
                <td>
                    <asp:DropDownList ID="DdGASusinesstype" runat="server">
                        <asp:ListItem>Others</asp:ListItem>
                    </asp:DropDownList>
                </td>
                
            </tr>
             <tr>
                <td>EAC</td>
                <td>
                    <asp:TextBox ID="txtgasEAC" runat="server"></asp:TextBox>
                 </td>
                
            </tr>
            <tr>
                <td>Start Date</td>
                <td>
                    <asp:Calendar ID="CalEleStartDate0" runat="server"></asp:Calendar>
                </td>
                
            </tr>


            
            <tr>
                <td>Duration</td>
                <td>
                    <asp:TextBox ID="txtGASDuration" runat="server">12</asp:TextBox>
                </td>
                
            </tr>


            
            <tr>
                <td>
                    <asp:Button ID="btnGasTerrif" runat="server" Text="Find Terriffs" Width="119px" />
                </td>
                <td>&nbsp;</td>
                
            </tr>


            
        </table>
     </div>




   
</asp:Content>

