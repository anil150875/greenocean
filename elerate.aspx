<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="elerate.aspx.cs" Inherits="GreenOcean.elerate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <div class="col-md-12 shadow p-4 mb-4 bg-white" >
         
         <table  style="width:100%; ">
             <tr class="success">
                 <td>
                     PC :<asp:Label ID="lblProfile" runat="server" Text="Label"></asp:Label>
                 </td>
                 <td>
                     MTC :<asp:Label ID="lblMTC" runat="server" Text="Label"></asp:Label>
                 </td>
                 <td>
                    PES : <asp:Label ID="lblRegion" runat="server" Text="Label"></asp:Label>
                 </td>
            
                 <td>
                    Duration : <asp:Label ID="lblDuration" runat="server" Text="Label"></asp:Label>
                 </td>
                 <td>
                    EAC :  <asp:Label ID="lblEac" runat="server" Text="Label"></asp:Label>
                 </td>
                 <td>
                    Business type <asp:Label ID="lblBusinessType" runat="server" Text="Label"></asp:Label>
                 </td>
            
                 <td>
                   Current Supplier :  <asp:Label ID="lblCurrentSupplier" runat="server" Text="Current Supplier"></asp:Label>
                 </td>

                   <td>
                   start  date :  <asp:Label ID="lblStartdate" runat="server" Text="start date"></asp:Label>
                 </td>
                 
             </tr>
            
             <tr class="success">
                 <td>
                     <asp:Label ID="lblBGEMetertype" runat="server" Text="lblBGEMetertype"></asp:Label>
                 </td>
                 <td>
                     <asp:Label ID="lblBGLMetertype" runat="server" Text="lblBGLMetertype" Visible="False"></asp:Label>
                 </td>
                 <td>
                     <asp:Label ID="lblDEMetertype" runat="server" Text="lblDEMetertype"></asp:Label>
                 </td>
            
                 <td>
                     <asp:Label ID="lblEDFMetertype" runat="server" Text="lblDEMetertype" Visible="False"></asp:Label>
                 </td>
                 <td>
                     <asp:Label ID="lblNpwer" runat="server" Text="lblNpwer"></asp:Label>
                 </td>
                 <td>
                     <asp:TextBox ID="txtUplift" runat="server" Visible="False"></asp:TextBox>
                 </td>
            
                 <td>
                     <asp:Label ID="lblELEPayment" runat="server" Text="lblDEMetertype" Visible="False"></asp:Label>
                 </td>
                 
             </tr>
            
             <tr class="success">
                 <td>
                     <asp:Label ID="lblGZMetertype" runat="server" Text="lblGZMetertype"></asp:Label>
                 </td>
                 <td>
                     <asp:Label ID="lblPEMetertype" runat="server" Text="lblPEMetertype"></asp:Label>
                 </td>
                 <td>
                     <asp:Label ID="lblSPAMetertype" runat="server" Text="lblSPAPEMetertype" Visible="False"></asp:Label>
                 </td>
            
                 <td>
                     <asp:Label ID="lblSSEPEMetertype" runat="server" Text="lblSSEPEMetertype" Visible="False"></asp:Label>
                 </td>
                 <td>
                     <asp:Label ID="lblEONEMetertype" runat="server" Text="lblEONEMetertype"></asp:Label>
                 </td>
                 <td>
                     &nbsp;</td>
            
                 <td>
                     &nbsp;</td>
                 
             </tr>
            
         </table>
         <asp:Panel ID="Panel1" runat="server" Visible ="false">
        
         <table style="width: 100%;">
             <tr>
                 <td style="height: 20px">Supplier</td>
                 <td style="height: 20px">Contract Length</td>
                 <td style="height: 20px">Payment  Type</td>
             </tr>
             <tr>
                 <td>
                     <asp:CheckBoxList ID="chkSupplier" runat="server" Width="100%" RepeatDirection="Horizontal">
                         <asp:ListItem>British Gas</asp:ListItem>
                         <asp:ListItem>British Gas LE</asp:ListItem>
                         <asp:ListItem>EDF</asp:ListItem>
                         <asp:ListItem>EDF</asp:ListItem>
                         <asp:ListItem>OPAS</asp:ListItem>
                         <asp:ListItem Value="NPower">N Power</asp:ListItem>
                         <asp:ListItem>Scotish Power</asp:ListItem>
                         <asp:ListItem>Pozitive energy</asp:ListItem>
                     </asp:CheckBoxList>
                     <br />
                 <td>
                     <asp:CheckBoxList ID="chkContract" runat="server" RepeatDirection="Horizontal" Width="100%">
                         <asp:ListItem>12</asp:ListItem>
                         <asp:ListItem>24</asp:ListItem>
                         <asp:ListItem>36</asp:ListItem>
                         <asp:ListItem>48</asp:ListItem>
                         <asp:ListItem>60</asp:ListItem>
                     </asp:CheckBoxList>

                 </td>
                 <td>
                     <asp:CheckBoxList ID="chkPayment" runat="server" RepeatDirection="Horizontal">
                         <asp:ListItem>CC</asp:ListItem>
                         <asp:ListItem>DD</asp:ListItem>
                     </asp:CheckBoxList>

                 </td>
             </tr>
             
         </table>
             </asp:Panel>
     </div>


    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>


       
    <div class="col-md-12">
        <h2>
            British Gas New Connection 
        </h2>
        <p>
            <asp:GridView ID="gvBGE" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" OnRowDataBound="gvBGE_RowDataBound" ShowFooter="True" Width="100%" AutoGenerateColumns="False">
                 <Columns>
                 <asp:BoundField DataField="WindowOpen" HeaderText="Start Date" />
                     <asp:BoundField DataField="StandingCharge" HeaderText="StandingCharge" />
                 <asp:BoundField DataField="PriceLineDescription" HeaderText="PriceLineDescription" />
                 <asp:BoundField DataField="PaymentMethod" HeaderText="PaymentMethod" />
                 <asp:BoundField DataField="ContractDuration" HeaderText="Term" />
                 <asp:BoundField DataField="UnitType" HeaderText="UnitType" />
                 <asp:BoundField DataField="ConsumptionRange" HeaderText="ConsumptionRange" />
                 <asp:BoundField DataField="UnitCharge" HeaderText="Price " />
                 <asp:TemplateField HeaderText="Uplift" Visible="False">
                     <FooterTemplate>
                         Project Amount :&nbsp;
                         <asp:Label ID="lblTotal" runat="server" Text="0"></asp:Label>
                     </FooterTemplate>
                     <ItemTemplate>
                         <asp:TextBox ID="txtUplift"  runat="server" Text ="0"   ></asp:TextBox>
                        
                     </ItemTemplate>
                 </asp:TemplateField>
                  <asp:TemplateField HeaderText="Total Cost" Visible="False">
                     <ItemTemplate>
                         <asp:TextBox ID="txtTotalCost" runat="server"></asp:TextBox>
                        
                     </ItemTemplate>
                 </asp:TemplateField>
             </Columns>
                <FooterStyle BackColor="White" ForeColor="#000066" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                <RowStyle ForeColor="#000066" />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#00547E" />
            </asp:GridView>
            <p>
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>

                        <table style="width: 100%;">
                            <tr>
                                <td>Day Price</td>
                                <td>Night Price</td>
                                <td>Weekend </td>
                                <td>Standing Charge</td>
                                <td>Uplift</td>
                                <td>Final Price</td>
                                
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtbgaPrice" runat="server" TextMode="Number"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txtbgaNightPrice" runat="server" TextMode="Number"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtbgaWeekend" runat="server" TextMode="Number"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtbgasccharge" runat="server"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txtbgauplift" runat="server" AutoPostBack="true" OnTextChanged="txtbgauplift_TextChanged" TextMode="Number" min ="0.0" max= "3.0" step="0.1">0.0</asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txtbgafinalvalue" runat="server" TextMode="Number"></asp:TextBox></td>
                            </tr>
                            

                            <tr>
                                <td>
                                    <asp:Label ID="lblbgaday" runat="server" Text="0"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblbganight" runat="server" Text="0"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblbgaweekend" runat="server" Text="0"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblbgasc" runat="server" Text="0"></asp:Label>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            

                        </table>

                    </ContentTemplate>
                </asp:UpdatePanel>




                <p>
                </p>




            </p>
            
          
            </div>

            <div class="col-md-12">

            </div>

         </ContentTemplate>
    </asp:UpdatePanel>
 

            <div class="col-md-12">
            <h2>British Gas Renewal</h2>
            <p>
            
            <asp:GridView ID="gvBGR" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" ShowFooter="True"  OnRowDataBound="gvBGR_RowDataBound" Width="100%" AutoGenerateColumns="False">
                  
                 <Columns>
                 <asp:BoundField DataField="WindowOpen" HeaderText="Start Date" />
                     <asp:BoundField DataField="StandingCharge" HeaderText="StandingCharge" />
                 <asp:BoundField DataField="PriceLineDescription" HeaderText="PriceLineDescription" />
                 <asp:BoundField DataField="PaymentMethod" HeaderText="PaymentMethod" />
                 <asp:BoundField DataField="ContractDuration" HeaderText="Term" />
                 <asp:BoundField DataField="UnitType" HeaderText="UnitType" />
                 <asp:BoundField DataField="ConsumptionRange" HeaderText="ConsumptionRange" />
                 <asp:BoundField DataField="UnitCharge" HeaderText="Price " />
                 <asp:TemplateField HeaderText="Uplift" Visible="False">
                     <FooterTemplate>
                        
                         <asp:Label ID="lblTotal" runat="server" Text="0" Visible="false"></asp:Label>
                     </FooterTemplate>
                     <ItemTemplate>
                         <asp:TextBox ID="txtUplift"  runat="server" Text ="0"   ></asp:TextBox>
                        
                     </ItemTemplate>
                 </asp:TemplateField>
                  <asp:TemplateField HeaderText="Total Cost" Visible="False">
                     <ItemTemplate>
                         <asp:TextBox ID="txtTotalCost" runat="server"></asp:TextBox>
                        
                     </ItemTemplate>
                 </asp:TemplateField>
             </Columns>
                    
                <FooterStyle BackColor="White" ForeColor="#000066" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                <RowStyle ForeColor="#000066" />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#00547E" />
            </asp:GridView>
                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>
                <p>
                <table style="width: 100%;">
                    <tr>
                        <td>Price</td>
                        <td>Night Price</td>
                        <td>Weekend </td>
                        <td>Standing Charge</td>
                        <td>Uplift</td>
                        <td>Final Price</td>
                    </tr>
                    <tr>
                        <td><asp:TextBox ID="txtbgrprice" runat="server" TextMode="Number"></asp:TextBox></td>
                         <td>
                                    <asp:TextBox ID="txtbgrnight" runat="server" TextMode="Number"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtbgrweekend" runat="server" TextMode="Number"></asp:TextBox>
                                </td>
                        <td><asp:TextBox ID="txtbgrsccharge" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtbgruplift" runat="server" AutoPostBack="true"   TextMode="Number" min ="0.0" max= "3.0" step="0.1" OnTextChanged="txtbgruplift_TextChanged">0.0</asp:TextBox></td>
                        <td><asp:TextBox ID="txtbgrfinalvalue" runat="server"  Text="0.0" TextMode="Number"></asp:TextBox></td>
                    </tr>
                    
                    <tr>
                        <td>
                            <asp:Label ID="lblbgrday" runat="server" Text="0"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblbgrnight" runat="server" Text="0"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblbgrweekend" runat="server" Text="0"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblbgrsc" runat="server" Text="0"></asp:Label>
                        </td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    
                </table>
                    </ContentTemplate>
           </asp:UpdatePanel>

        </div>

                   <div class="col-md-12">
            <h2>British Gas LE (Acquisition)</h2>
                        <asp:GridView ID="gvBGL" runat="server" BackColor="White" BorderColor="#CCCCCC" ShowFooter="True" BorderStyle="None" BorderWidth="1px" CellPadding="3" Width="100%" OnRowDataBound="gvBGL_RowDataBound" AutoGenerateColumns="False">

                              
                    <Columns>
                 <asp:BoundField DataField="WindowOpen" HeaderText="Start Date" />
                        <asp:BoundField DataField="StandingCharge" HeaderText="StandingCharge" />
                 <asp:BoundField DataField="PriceLineDescription" HeaderText="PriceLineDescription" />
                 <asp:BoundField DataField="PaymentMethod" HeaderText="PaymentMethod" />
                 <asp:BoundField DataField="ContractDuration" HeaderText="Term" />
                 <asp:BoundField DataField="UnitType" HeaderText="UnitType" />
                 <asp:BoundField DataField="ConsumptionRange" HeaderText="ConsumptionRange" />
                 <asp:BoundField DataField="UnitCharge" HeaderText="Price " />
                 <asp:TemplateField HeaderText="Uplift" Visible="False">
                     <FooterTemplate>
                        
                         <asp:Label ID="lblTotal" runat="server" Text="0" Visible="false"></asp:Label>
                     </FooterTemplate>
                     <ItemTemplate>
                         <asp:TextBox ID="txtUplift"  runat="server" Text ="0"   ></asp:TextBox>
                        
                     </ItemTemplate>
                 </asp:TemplateField>
                  <asp:TemplateField HeaderText="Total Cost" Visible="False">
                     <ItemTemplate>
                         <asp:TextBox ID="txtTotalCost" runat="server"></asp:TextBox>
                        
                     </ItemTemplate>
                 </asp:TemplateField>
             </Columns>
                <FooterStyle BackColor="White" ForeColor="#000066" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                <RowStyle ForeColor="#000066" />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#00547E" />
            </asp:GridView>
                       <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                           <ContentTemplate>
                               <p>
                                   <table style="width: 100%;">
                                       <tr>
                                           <td>Price</td>
                                           <td>Night Price</td>
                                           <td>Weekend </td>
                                           <td>Standing Charge</td>
                                           <td>Uplift</td>
                                           <td>Final Price</td>
                                       </tr>
                                       <tr>
                                           <td>
                                               <asp:TextBox ID="txtbglaprice" runat="server" TextMode="Number"></asp:TextBox></td>
                                           <td>
                                               <asp:TextBox ID="txtbglanight" runat="server" TextMode="Number"></asp:TextBox>
                                           </td>
                                           <td>
                                               <asp:TextBox ID="txtbglaweekend" runat="server" TextMode="Number"></asp:TextBox>
                                           </td>
                                           <td>
                                               <asp:TextBox ID="txtbglasccharge" runat="server"></asp:TextBox></td>
                                           <td>
                                               <asp:TextBox ID="txtbglauplift" runat="server" AutoPostBack="true" TextMode="Number" min ="0.0" max= "3.0" step="0.1" OnTextChanged="txtbglauplift_TextChanged" >0.0</asp:TextBox></td>
                                           <td>
                                               <asp:TextBox ID="txtbglafinalvalue" runat="server" TextMode="Number">0.0</asp:TextBox></td>
                                       </tr>

                                       <tr>
                                           <td>
                                               <asp:Label ID="lblbgladay" runat="server" Text="0"></asp:Label>
                                           </td>
                                           <td>
                                               <asp:Label ID="lblbglanight" runat="server" Text="0"></asp:Label>
                                           </td>
                                           <td>
                                               <asp:Label ID="lblbglaweekend" runat="server" Text="0"></asp:Label>
                                           </td>
                                           <td>
                                               <asp:Label ID="lblbglasccharge" runat="server" Text="0"></asp:Label>
                                           </td>
                                           <td>&nbsp;</td>
                                           <td>&nbsp;</td>
                                       </tr>

                                   </table>
                          
                       </div>
   
     </ContentTemplate>
                       </asp:UpdatePanel>
                   <div class="col-md-12">
            <h2>British Gas LE (Renew)</h2>
                        <asp:GridView ID="gvBGlRenew" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" ShowFooter="True" BorderWidth="1px" CellPadding="3" Width="100%" OnRowDataBound="gvBGlRenew_RowDataBound" AutoGenerateColumns="False">

                              
                     <Columns>
                 <asp:BoundField DataField="WindowOpen" HeaderText="Start Date" />
                         <asp:BoundField DataField="StandingCharge" HeaderText="StandingCharge" />
                 <asp:BoundField DataField="PriceLineDescription" HeaderText="PriceLineDescription" />
                 <asp:BoundField DataField="PaymentMethod" HeaderText="PaymentMethod" />
                 <asp:BoundField DataField="ContractDuration" HeaderText="Term" />
                 <asp:BoundField DataField="UnitType" HeaderText="UnitType" />
                 <asp:BoundField DataField="ConsumptionRange" HeaderText="ConsumptionRange" />
                 <asp:BoundField DataField="UnitCharge" HeaderText="Price " />
                 <asp:TemplateField HeaderText="Uplift" Visible="False">
                     <FooterTemplate>
                         Project Amount :&nbsp;
                         <asp:Label ID="lblTotal" runat="server" Text="0"></asp:Label>
                     </FooterTemplate>
                     <ItemTemplate>
                         <asp:TextBox ID="txtUplift"  runat="server" Text ="0"   ></asp:TextBox>
                        
                     </ItemTemplate>
                 </asp:TemplateField>
                  <asp:TemplateField HeaderText="Total Cost" Visible="False">
                     <ItemTemplate>
                         <asp:TextBox ID="txtTotalCost" runat="server"></asp:TextBox>
                        
                     </ItemTemplate>
                 </asp:TemplateField>
             </Columns>
                <FooterStyle BackColor="White" ForeColor="#000066" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                <RowStyle ForeColor="#000066" />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#00547E" />
            </asp:GridView>
                      <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                           <ContentTemplate>
                               <p>
                                   <table style="width: 100%;">
                                       <tr>
                                           <td>Price</td>
                                           <td>Night Price</td>
                                           <td>Weekend </td>
                                           <td>Standing Charge</td>
                                           <td>Uplift</td>
                                           <td>Final Price</td>
                                       </tr>
                                       <tr>
                                           <td>
                                               <asp:TextBox ID="txtbgleprice" runat="server" TextMode="Number"></asp:TextBox></td>
                                           <td>
                                               <asp:TextBox ID="txtbglenight" runat="server" TextMode="Number"></asp:TextBox>
                                           </td>
                                           <td>
                                               <asp:TextBox ID="txtbgleweekend" runat="server" TextMode="Number"></asp:TextBox>
                                           </td>
                                           <td>
                                               <asp:TextBox ID="txtbglesccharge" runat="server"></asp:TextBox></td>
                                           <td>
                                               <asp:TextBox ID="txtbgleuplift" runat="server" AutoPostBack="true" TextMode="Number" min ="0.0" max= "3.0" step="0.1"   OnTextChanged="txtbgleuplift_TextChanged">0.0</asp:TextBox></td>
                                           <td>
                                               <asp:TextBox ID="txtbglefinalvalue" runat="server" TextMode="Number">0.0</asp:TextBox></td>
                                       </tr>

                                       <tr>
                                           <td>
                                               <asp:Label ID="lblbgleday" runat="server" Text="0"></asp:Label>
                                           </td>
                                           <td>
                                               <asp:Label ID="lblbglenight" runat="server" Text="0"></asp:Label>
                                           </td>
                                           <td>
                                               <asp:Label ID="lblbgleweekend" runat="server" Text="0"></asp:Label>
                                           </td>
                                           <td>
                                               <asp:Label ID="lblbglesccharge" runat="server" Text="0"></asp:Label>
                                           </td>
                                           <td>&nbsp;</td>
                                           <td>&nbsp;</td>
                                       </tr>

                                   </table>
                           </ContentTemplate>
                       </asp:UpdatePanel>


                       </div>
                       <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                           <ContentTemplate>

                          
                   <div class="col-md-12">
            <h2>Duel Energy</h2>
                        <asp:GridView ID="gvDE" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Width="100%" OnSelectedIndexChanged="gvDE_SelectedIndexChanged" AutoGenerateColumns="False" OnRowDataBound="gvDE_RowDataBound">
                           <Columns>
                               <asp:BoundField DataField="EffectiveFromDate" HeaderText="Start Date" />
                               <asp:BoundField DataField="Product" HeaderText="Product" />
                               <asp:BoundField DataField="StandingCharge" HeaderText="StandingCharge" />
                               <asp:BoundField HeaderText="day" DataField="DayAllSTODOtherDayUnits" />
                               <asp:BoundField DataField="NightUnitPrice" HeaderText="Night" />
                               <asp:BoundField DataField="EveWkendControlSTODWinterPeak" HeaderText="WeekEnd" />

                                <asp:TemplateField HeaderText="Uplift" Visible="False">
                     <ItemTemplate>
                         <asp:TextBox ID="txtUplift"  runat="server" Text ="0"   ></asp:TextBox>
                        
                     </ItemTemplate>
                 </asp:TemplateField>
                  <asp:TemplateField HeaderText="Total Cost" Visible="False">
                     <ItemTemplate>
                         <asp:TextBox ID="txtTotalCost" runat="server"></asp:TextBox>
                        
                     </ItemTemplate>
                 </asp:TemplateField>
                    </Columns>
                <FooterStyle BackColor="White" ForeColor="#000066" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                <RowStyle ForeColor="#000066" />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#00547E" />
            </asp:GridView>
                       <table style="width: 100%;">
                           <tr>
                               <td>Day Price</td>
                               <td>Night Price</td>
                               <td>Weekend&nbsp; Price</td>
                               <td>Standing Charge</td>
                               <td>Uplift</td>
                               <td>Final Price</td>
                           </tr>
                           <tr>
                               <td>
                                   <asp:TextBox ID="txtdeDay" runat="server" TextMode="Number">0.0</asp:TextBox>
                               </td>
                               <td>
                                   <asp:TextBox ID="txtdenight" runat="server" TextMode="Number">0.0</asp:TextBox>
                               </td>
                               <td>
                                   <asp:TextBox ID="txtdeweekend" runat="server" TextMode="Number">0.0</asp:TextBox>
                               </td>
                               <td>
                                   <asp:TextBox ID="txtdesc" runat="server" TextMode="Number">0.0</asp:TextBox>
                               </td>
                               <td>
                                   <asp:TextBox ID="txtdeuplift" runat="server" TextMode="Number" min ="0.0" max= "3.0" step="0.1" OnTextChanged="txtdeuplift_TextChanged" AutoPostBack="True">0.0</asp:TextBox>
                               </td>
                               <td>
                                   <asp:TextBox ID="txtdefinal" runat="server" TextMode="Number">0.0</asp:TextBox>
                               </td>
                           </tr>
                           <tr>
                               <td>
                                   <asp:Label ID="lblDeDay" runat="server" Text="0"></asp:Label>
                               </td>
                               <td>
                                   <asp:Label ID="lblDeNight" runat="server" Text="0"></asp:Label>
                               </td>
                               <td>
                                   <asp:Label ID="lblDeWeekend" runat="server" Text="0"></asp:Label>
                               </td>
                               <td>
                                   <asp:Label ID="lblDeSc" runat="server" Text="0"></asp:Label>
                               </td>
                               <td>&nbsp;</td>
                               <td>&nbsp;</td>
                           </tr>
                       </table>


                       </div>
                              
                                </ContentTemplate>
                       </asp:UpdatePanel>
     
                       <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                           <ContentTemplate>


                          
                   <div class="col-md-12">


            <h2>EDF ELectricity </h2>
                     
                        <asp:GridView ID="gvEDF" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Width="100%" AutoGenerateColumns="False" OnRowDataBound="gvEDF_RowDataBound">
                             <Columns>
                                 <asp:BoundField DataField="Contract" HeaderText="Contract" />
                                 <asp:BoundField DataField="Meter" HeaderText="Meter" />
                                 <asp:BoundField DataField="StandingCharge" HeaderText="StandingCharge" />
                                 <asp:BoundField DataField="Day" HeaderText="Day" />
                                 <asp:BoundField DataField="Night" HeaderText="Night" />
                                 <asp:BoundField HeaderText="EveningWeekend" DataField="EveningWeekend" />
                                 <asp:TemplateField HeaderText="Uplift" Visible="False">
                     <ItemTemplate>
                         <asp:TextBox ID="txtUplift"  runat="server" Text ="0"   ></asp:TextBox>
                        
                     </ItemTemplate>
                 </asp:TemplateField>
                  <asp:TemplateField HeaderText="Total Cost" Visible="False">
                     <ItemTemplate>
                         <asp:TextBox ID="txtTotalCost" runat="server"></asp:TextBox>
                        
                     </ItemTemplate>
                 </asp:TemplateField>
                    </Columns>
                <FooterStyle BackColor="White" ForeColor="#000066" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                <RowStyle ForeColor="#000066" />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#00547E" />
            </asp:GridView>
                     
                       <table style="width: 100%;">
                           <tr>
                               <td>Day Price</td>
                               <td>Night Price</td>
                               <td>Weekend&nbsp; Price</td>
                               <td>Standing Charge</td>
                               <td>Uplift</td>
                               <td>Final Price</td>
                           </tr>
                           <tr>
                               <td>
                                   <asp:TextBox ID="txtedfday" runat="server" TextMode="Number">0</asp:TextBox></td>
                               <td><asp:TextBox ID="txtedfnight" runat="server" TextMode="Number">0</asp:TextBox></td></td>
                               <td><asp:TextBox ID="txtedfweekend" runat="server" TextMode="Number">0</asp:TextBox></td></td>
                               <td>
                                   <asp:TextBox ID="txtedfsc" runat="server" TextMode="Number">0</asp:TextBox>
                               </td>
                               <td>
                                   <asp:TextBox ID="txtedfuplift" runat="server" TextMode="Number" min ="0.0" max= "3.0" step="0.1" AutoPostBack ="true" OnTextChanged="txtedfuplift_TextChanged" >0</asp:TextBox>
                               </td>
                               <td>
                                   <asp:TextBox ID="txtedffinalvalue" runat="server" TextMode="Number">0</asp:TextBox>
                               </td>
                           </tr>
                           <tr>
                               <td>
                                   <asp:Label ID="lblEdfDay" runat="server" Text="0"></asp:Label>
                               </td>
                               <td>
                                   <asp:Label ID="lblEdfNight" runat="server" Text="0"></asp:Label>
                               </td>
                               <td>
                                   <asp:Label ID="lblEDFWeekend" runat="server" Text="0"></asp:Label>
                               </td>
                               <td>
                                   <asp:Label ID="lblEdfSC" runat="server" Text="0"></asp:Label>
                               </td>
                               <td>&nbsp;</td>
                               <td>&nbsp;</td>
                           </tr>
                       </table>

                       </div>

                                </ContentTemplate>

                       </asp:UpdatePanel> 
   
                       <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                           <ContentTemplate>

                               <div class="col-md-12">
                                   <h2>NPOWER  Renewal  </h2>
                                   <asp:GridView ID="gvNpowerA" runat="server" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" Width="100%" AutoGenerateColumns="False" OnRowDataBound="gvNpowerA_RowDataBound">

                                       <Columns>
                                           <asp:BoundField DataField="book" HeaderText="Price Book" />
                                           <asp:BoundField DataField="Duration" HeaderText="Duration" />
                                           <asp:BoundField DataField="Volume_min" HeaderText="Volume" />
                                           <asp:BoundField DataField="rate_type" HeaderText="rate_type" />
                                           <asp:BoundField DataField="Standing_Charge" HeaderText="Standing_Charge" />
                                           <asp:BoundField DataField="Day_Units" HeaderText="Day_Units" />
                                           <asp:BoundField DataField="All_Units" HeaderText="All_Units" />
                                           <asp:BoundField DataField="Night_Units" HeaderText="Night_Units" />
                                           <asp:BoundField DataField="Weekday_Units" HeaderText="Weekday_Units" />
                                           <asp:BoundField DataField="Other_Units" HeaderText="Other_Units" />

                                       </Columns>
                                       <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                       <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                                       <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                                       <RowStyle BackColor="White" ForeColor="#003399" />
                                       <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                       <SortedAscendingCellStyle BackColor="#EDF6F6" />
                                       <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                                       <SortedDescendingCellStyle BackColor="#D6DFDF" />
                                       <SortedDescendingHeaderStyle BackColor="#002876" />
                                   </asp:GridView>
                                   <table style="width: 100%;">
                                       <tr>
                                           <td>Day Price</td>
                                           <td>All Unit Price</td>
                                           <td>Night Price</td>
                                           <td>Weekend&nbsp; Price</td>
                                           <td>Other Units</td>
                                           <td>Standing Charge</td>
                                           <td>Uplift</td>
                                           <td>Final Price</td>
                                       </tr>
                                       <tr>
                                           <td>
                                               <asp:TextBox ID="txtnprday" runat="server" TextMode="Number">0</asp:TextBox></td>
                                           <td>
                                               <asp:TextBox ID="txtnprall" runat="server" TextMode="Number">0</asp:TextBox></td>
                                           <td>
                                               <asp:TextBox ID="txtnprnight" runat="server" TextMode="Number">0</asp:TextBox></td>
                                           <td>
                                               <asp:TextBox ID="txtnprweekend" runat="server" TextMode="Number">0</asp:TextBox></td>
                                           <td>
                                               <asp:TextBox ID="txtnprother" runat="server" TextMode="Number">0</asp:TextBox>
                                           </td>
                                           <td>
                                               <asp:TextBox ID="txtnprsc" runat="server" TextMode="Number">0</asp:TextBox>
                                           </td>
                                           <td>
                                               <asp:TextBox ID="txtnpruplift" runat="server" TextMode="Number" min="0.0" max="3.0" step="0.1" AutoPostBack="true" OnTextChanged="txtnpruplift_TextChanged">0</asp:TextBox>
                                           </td>
                                           <td>
                                               <asp:TextBox ID="txtnprfinalvalue" runat="server" TextMode="Number">0</asp:TextBox>
                                           </td>
                                       </tr>
                                       <tr>
                                           <td>
                                               <asp:Label ID="lblnprday" runat="server" Text="0"></asp:Label>
                                           </td>
                                           <td>
                                               <asp:Label ID="lblnprall" runat="server" Text="0"></asp:Label>
                                           </td>
                                           <td>
                                               <asp:Label ID="lblnprnight" runat="server" Text="0"></asp:Label>
                                           </td>
                                           <td>
                                               <asp:Label ID="lblnprweekend" runat="server" Text="0"></asp:Label>
                                           </td>
                                           <td>
                                               <asp:Label ID="lblnprother" runat="server" Text="0"></asp:Label>
                                           </td>
                                           <td>
                                               <asp:Label ID="lblnprsc" runat="server" Text="0"></asp:Label>
                                           </td>
                                           <td>&nbsp;</td>
                                           <td>&nbsp;</td>
                                       </tr>
                                   </table>

                               </div>

                           </ContentTemplate>

                       </asp:UpdatePanel>

     <div class="col-md-12">
         <h2>NPOWER  npowere  </h2>
          <asp:GridView ID="gvnpowere" runat="server" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" Width="100%" AutoGenerateColumns="False" OnRowDataBound="gvnpowere_RowDataBound" >
               
               <Columns>
                   <asp:BoundField DataField="book" HeaderText="Price Book" />
                   <asp:BoundField DataField="Duration" HeaderText="Duration" />
                   <asp:BoundField DataField="Volume_min" HeaderText="Volume" />
                   <asp:BoundField DataField="rate_type" HeaderText="rate_type" />
                   <asp:BoundField DataField="Standing_Charge" HeaderText="Standing_Charge" />
                   <asp:BoundField DataField="Day_Units" HeaderText="Day_Units" />
                   <asp:BoundField DataField="All_Units" HeaderText="All_Units" />
                   <asp:BoundField DataField="Night_Units" HeaderText="Night_Units" />
                   <asp:BoundField DataField="Weekday_Units" HeaderText="Weekday_Units" />
                   <asp:BoundField DataField="Other_Units" HeaderText="Other_Units" />

                
               </Columns>
               <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
               <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
               <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
               <RowStyle BackColor="White" ForeColor="#003399" />
               <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
               <SortedAscendingCellStyle BackColor="#EDF6F6" />
               <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
               <SortedDescendingCellStyle BackColor="#D6DFDF" />
               <SortedDescendingHeaderStyle BackColor="#002876" />
           </asp:GridView>
         <table style="width: 100%;">
             <tr>
                 <td>Day Price</td>
                 <td>All Unit Price</td>
                 <td>Night Price</td>
                 <td>Weekend&nbsp; Price</td>
                 <td>Other Units</td>
                 <td>Standing Charge</td>
                 <td>Uplift</td>
                 <td>Final Price</td>
             </tr>
             <tr>
                 <td>
                     <asp:TextBox ID="txtnprrday" runat="server" TextMode="Number">0</asp:TextBox></td>
                 <td>
                     <asp:TextBox ID="txtnprrall" runat="server" TextMode="Number">0</asp:TextBox></td>
                 <td>
                     <asp:TextBox ID="txtnprrnight" runat="server" TextMode="Number">0</asp:TextBox></td>
                 <td>
                     <asp:TextBox ID="txtnprrweekend" runat="server" TextMode="Number">0</asp:TextBox></td>
                 <td>
                     <asp:TextBox ID="txtnprrothrt" runat="server" TextMode="Number">0</asp:TextBox></td>
                 <td>
                     <asp:TextBox ID="txtnprrsc" runat="server" TextMode="Number">0</asp:TextBox>
                 </td>
                 <td>
                     <asp:TextBox ID="txtnprruplift" runat="server" TextMode="Number" min="0.0" max="3.0" step="0.1" AutoPostBack="true" OnTextChanged="txtnprruplift_TextChanged">0</asp:TextBox>
                 </td>
                 <td>
                     <asp:TextBox ID="txtnprrfinalprice" runat="server" TextMode="Number">0</asp:TextBox>
                 </td>
             </tr>
             <tr>
                 <td>
                     <asp:Label ID="lblnprrday" runat="server" Text="0"></asp:Label>
                 </td>
                 <td>
                     <asp:Label ID="lblnprrall" runat="server" Text="0"></asp:Label>
                 </td>
                 <td>
                     <asp:Label ID="lblnprrnight" runat="server" Text="0"></asp:Label>
                 </td>
                 <td>
                     <asp:Label ID="lblnprrweekend" runat="server" Text="0"></asp:Label>
                 </td>
                 <td>
                     <asp:Label ID="lblnprrother" runat="server" Text="0"></asp:Label>
                 </td>
                 <td>
                     <asp:Label ID="lblnprrsc" runat="server" Text="0"></asp:Label>
                 </td>
                 <td>&nbsp;</td>
                 <td>&nbsp;</td>
             </tr>
         </table>
         

         </div>
    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
        <ContentTemplate>


     <div class="col-md-12">
         <h2>npoweral  </h2>
         
          <asp:GridView ID="gvnpoweral" runat="server" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" Width="100%" AutoGenerateColumns="False" OnRowDataBound="gvnpoweral_RowDataBound">
              
               <Columns>
                   <asp:BoundField DataField="book" HeaderText="Price Book" />
                   <asp:BoundField DataField="Duration" HeaderText="Duration" />
                   <asp:BoundField DataField="Volume_min" HeaderText="Volume" />
                   <asp:BoundField DataField="rate_type" HeaderText="rate_type" />
                   <asp:BoundField DataField="Standing_Charge" HeaderText="Standing_Charge" />
                   <asp:BoundField DataField="Day_Units" HeaderText="Day_Units" />
                   <asp:BoundField DataField="All_Units" HeaderText="All_Units" />
                   <asp:BoundField DataField="Night_Units" HeaderText="Night_Units" />
                   <asp:BoundField DataField="Weekday_Units" HeaderText="Weekday_Units" />
                   <asp:BoundField DataField="Other_Units" HeaderText="Other_Units" />

               
               </Columns>
               <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
               <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
               <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
               <RowStyle BackColor="White" ForeColor="#003399" />
               <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
               <SortedAscendingCellStyle BackColor="#EDF6F6" />
               <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
               <SortedDescendingCellStyle BackColor="#D6DFDF" />
               <SortedDescendingHeaderStyle BackColor="#002876" />
           </asp:GridView>
         <table style="width: 100%;">
             <tr>
                 <td>Day Price</td>
                 <td>All Unit Price</td>
                 <td>Night Price</td>
                 <td>Weekend&nbsp; Price</td>
                 <td>Other Units</td>
                 <td>Standing Charge</td>
                 <td>Uplift</td>
                 <td>Final Price</td>
             </tr>
             <tr>
                 <td>
                     <asp:TextBox ID="txtnpreday" runat="server" TextMode="Number">0</asp:TextBox></td>
                 <td>
                     <asp:TextBox ID="txtnpreall" runat="server" TextMode="Number">0</asp:TextBox></td>
                 <td>
                     <asp:TextBox ID="txtnprenight" runat="server" TextMode="Number">0</asp:TextBox></td>
                 <td>
                     <asp:TextBox ID="txtnpreweekend" runat="server" TextMode="Number">0</asp:TextBox></td>
                 <td>
                     <asp:TextBox ID="txtnpreother" runat="server" TextMode="Number">0</asp:TextBox>
                 </td>
                 <td>
                     <asp:TextBox ID="txtnpresc" runat="server" TextMode="Number">0</asp:TextBox>
                 </td>
                 <td>
                     <asp:TextBox ID="txtnpreuplift" runat="server" TextMode="Number" min="0.0" max="3.0" step="0.1" AutoPostBack="true" OnTextChanged="txtnpreuplift_TextChanged">0</asp:TextBox>
                 </td>
                 <td>
                     <asp:TextBox ID="txtnprefinalvalue" runat="server" TextMode="Number">0</asp:TextBox>
                 </td>
             </tr>
             <tr>
                 <td>
                     <asp:Label ID="lblnpreda" runat="server" Text="0"></asp:Label>
                 </td>
                 <td>
                     <asp:Label ID="lblnpreall" runat="server" Text="0"></asp:Label>
                 </td>
                 <td>
                     <asp:Label ID="lblnprenight" runat="server" Text="0"></asp:Label>
                 </td>
                 <td>
                     <asp:Label ID="lblnpreweekend" runat="server" Text="0"></asp:Label>
                 </td>
                 <td>
                     <asp:Label ID="lblnpreother" runat="server" Text="0"></asp:Label>
                 </td>
                 <td>
                     <asp:Label ID="lblnpresc" runat="server" Text="0"></asp:Label>
                 </td>
                 <td>&nbsp;</td>
                 <td>&nbsp;</td>
             </tr>
         </table>


          
        
         </div>
          
        </ContentTemplate>
    </asp:UpdatePanel>
   
                       <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                           <ContentTemplate>

                           
    <div class="col-md-12">
         <h2>gazprom-energy</h2>  
            <asp:GridView ID="gvgaz" runat="server" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" Width="100%" AutoGenerateColumns="False" OnRowDataBound="gvgaz_RowDataBound">
                <Columns>
                    <asp:BoundField DataField="ContractDuration" HeaderText="ContractDuration" />
                    <asp:BoundField DataField="GDate" HeaderText="GDate" />
                    <asp:BoundField DataField="StandingCharge" HeaderText="StandingCharge" />
                    <asp:BoundField DataField="UnitRate" HeaderText="UnitRate" />
                    <asp:BoundField DataField="Day" HeaderText="Day" />
                    <asp:BoundField DataField="Day" HeaderText="Night" />
                    <asp:BoundField DataField="EveningWeekend" HeaderText="EveningWeekend" />
                   
                 
                </Columns>
              


                <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                <RowStyle BackColor="White" ForeColor="#003399" />
                <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                <SortedAscendingCellStyle BackColor="#EDF6F6" />
                <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                <SortedDescendingCellStyle BackColor="#D6DFDF" />
                <SortedDescendingHeaderStyle BackColor="#002876" />
              


            </asp:GridView>

        <table style="width: 100%;">
                           <tr>
                               <td>Day Price</td>
                               <td>Unit Rate</td>
                               <td>Night Price</td>
                               <td>Weekend&nbsp; Price</td>
                               <td>Standing Charge</td>
                               <td>Uplift</td>
                               <td>Final Price</td>
                           </tr>
                           <tr>
                               <td>
                                   <asp:TextBox ID="txtgazday" runat="server" TextMode="Number">0</asp:TextBox></td>
                               <td>
                                   <asp:TextBox ID="txtgazunitrate" runat="server" TextMode="Number">0</asp:TextBox></td>
                               <td><asp:TextBox ID="txtgaznight" runat="server" TextMode="Number">0</asp:TextBox></td>
                               <td><asp:TextBox ID="txtgazweekend" runat="server" TextMode="Number">0</asp:TextBox></td>
                               <td>
                                   <asp:TextBox ID="txtgazsc" runat="server" TextMode="Number">0</asp:TextBox>
                               </td>
                               <td>
                                   <asp:TextBox ID="txtgazuplift" runat="server" TextMode="Number" min ="0.0" max= "3.0" step="0.1" AutoPostBack ="true" OnTextChanged="txtgazuplift_TextChanged"  >0</asp:TextBox>
                               </td>
                               <td>
                                   <asp:TextBox ID="txtgazfinal" runat="server" TextMode="Number">0</asp:TextBox>
                               </td>
                           </tr>
                           <tr>
                               <td>
                                   <asp:Label ID="lblgazday" runat="server" Text="0"></asp:Label>
                               </td>
                               <td>
                                   <asp:Label ID="lblgazunitrate" runat="server" Text="0"></asp:Label>
                               </td>
                               <td>
                                   <asp:Label ID="lblgaznight" runat="server" Text="0"></asp:Label>
                               </td>
                               <td>
                                   <asp:Label ID="lblgazweekend" runat="server" Text="0"></asp:Label>
                               </td>
                               <td>
                                   <asp:Label ID="lblgazsc" runat="server" Text="0"></asp:Label>
                               </td>
                               <td>&nbsp;</td>
                               <td>&nbsp;</td>
                           </tr>
                       </table>
     </div>    
                               </ContentTemplate>
                       </asp:UpdatePanel>
    
                       <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                           <ContentTemplate>

     <div class="col-md-12" style="left: 0px; top: 0px">
         <h2>Positive -energy</h2>
         
             <asp:GridView ID="gvpe" runat="server" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" Width="100%" AutoGenerateColumns="False" OnRowDataBound="gvpe_RowDataBound">
                 <Columns>
                     <asp:BoundField DataField="Tariffname" HeaderText="Tariffname" />
                     <asp:BoundField DataField="Term12" HeaderText="Term" />
                     <asp:BoundField DataField="Fixedcharge12" HeaderText="Fixedcharge" />
                     <asp:BoundField DataField="Day12" HeaderText="Day charge" />
                     <asp:BoundField DataField="Night12" HeaderText="Night" />
                     <asp:BoundField DataField="RHT12" HeaderText="RHT" />
                     <asp:BoundField DataField="EveWK12" HeaderText="EveWK" />
                    
                    
                 </Columns>
                 <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                 <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                 <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                 <RowStyle BackColor="White" ForeColor="#003399" />
                 <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                 <SortedAscendingCellStyle BackColor="#EDF6F6" />
                 <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                 <SortedDescendingCellStyle BackColor="#D6DFDF" />
                 <SortedDescendingHeaderStyle BackColor="#002876" />


             </asp:GridView>

             <asp:GridView ID="gvpe24" runat="server" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" Width="100%" AutoGenerateColumns="False" OnRowDataBound="gvpe24_RowDataBound">
                 <Columns>
                     <asp:BoundField DataField="Tariffname" HeaderText="Tariffname" />
                     <asp:BoundField DataField="Term24" HeaderText="Term" />
                     <asp:BoundField DataField="Fixedcharge12" HeaderText="Fixedcharge" />
                     <asp:BoundField DataField="Day24" HeaderText="Day charge" />
                     <asp:BoundField DataField="Night24" HeaderText="Night" />
                     <asp:BoundField DataField="RHT24" HeaderText="RHT" />
                     <asp:BoundField DataField="EveWK24" HeaderText="EveWK" />
                   
                 </Columns>
                 <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                 <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                 <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                 <RowStyle BackColor="White" ForeColor="#003399" />
                 <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                 <SortedAscendingCellStyle BackColor="#EDF6F6" />
                 <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                 <SortedDescendingCellStyle BackColor="#D6DFDF" />
                 <SortedDescendingHeaderStyle BackColor="#002876" />
             </asp:GridView>

             <asp:GridView ID="gvpe36" runat="server" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" Width="100%" AutoGenerateColumns="False" OnRowDataBound="gvpe36_RowDataBound">
                 <Columns>
                     <asp:BoundField DataField="Tariffname" HeaderText="Tariffname" />
                     <asp:BoundField DataField="Term36" HeaderText="Term" />
                     <asp:BoundField DataField="Fixedcharge36" HeaderText="Fixedcharge" />
                     <asp:BoundField DataField="Day36" HeaderText="Day charge" />
                     <asp:BoundField DataField="Night36" HeaderText="Night" />
                     <asp:BoundField DataField="RHT36" HeaderText="RHT" />
                     <asp:BoundField DataField="EveWK36" HeaderText="EveWK" />
                    
                   
                 </Columns>
                 <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                 <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                 <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                 <RowStyle BackColor="White" ForeColor="#003399" />
                 <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                 <SortedAscendingCellStyle BackColor="#EDF6F6" />
                 <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                 <SortedDescendingCellStyle BackColor="#D6DFDF" />
                 <SortedDescendingHeaderStyle BackColor="#002876" />
             </asp:GridView>

              <table style="width: 100%;">
                           <tr>
                               <td>Day Price</td>
                               <td>Night Price</td>
                               <td>Weekend&nbsp; Price</td>
                               <td>Standing Charge</td>
                               <td>Uplift</td>
                               <td>Final Price</td>
                           </tr>
                           <tr>
                               <td>
                                   <asp:TextBox ID="txtpeday" runat="server" TextMode="Number">0</asp:TextBox></td>
                               <td><asp:TextBox ID="txtpenight" runat="server" TextMode="Number">0</asp:TextBox></td>
                               <td><asp:TextBox ID="txtpeweekend" runat="server" TextMode="Number">0</asp:TextBox></td>
                               <td>
                                   <asp:TextBox ID="txtpesc" runat="server" TextMode="Number">0</asp:TextBox>
                               </td>
                               <td>
                                   <asp:TextBox ID="txtpeuplft" runat="server" TextMode="Number" min ="0.0" max= "3.0" step="0.1" AutoPostBack ="true" OnTextChanged="txtpeuplft_TextChanged"  >0</asp:TextBox>
                               </td>
                               <td>
                                   <asp:TextBox ID="txtpefinal" runat="server" TextMode="Number">0</asp:TextBox>
                               </td>
                           </tr>
                           <tr>
                               <td>
                                   <asp:Label ID="lblpeday" runat="server" Text="0"></asp:Label>
                               </td>
                               <td>
                                   <asp:Label ID="lblpenight" runat="server" Text="0"></asp:Label>
                               </td>
                               <td>
                                   <asp:Label ID="lblpeweekend" runat="server" Text="0"></asp:Label>
                               </td>
                               <td>
                                   <asp:Label ID="lblpesc" runat="server" Text="0"></asp:Label>
                               </td>
                               <td>&nbsp;</td>
                               <td>&nbsp;</td>
                           </tr>
                       </table>

         </div>

        
                           </ContentTemplate>
                       </asp:UpdatePanel>
         
                       <asp:UpdatePanel ID="UpdatePanel15" runat="server">
                           <ContentTemplate>


         <div class="col-md-12" style="left: 0px; top: 0px">
         <h2>Scotish  -Power (Acq)</h2>
             <asp:GridView ID="gvspaa" runat="server" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" Width="100%" AutoGenerateColumns="False">
                 <Columns>
                     <asp:BoundField DataField="ProductName" HeaderText="ProductName" />
                     <asp:BoundField DataField="DailyStandingCharge" HeaderText="DailyStandingCharge" />
                      <asp:BoundField DataField="PriceType" HeaderText="Price Type" />
                     <asp:BoundField HeaderText="All" DataField="All" />
                     <asp:BoundField DataField="Day" HeaderText="Day" />
                     <asp:BoundField DataField="Night" HeaderText="Night" />
                     <asp:BoundField DataField="EW" HeaderText="Evening Weekend" />
                     <asp:BoundField HeaderText="OffPeak" />
                  
                 </Columns>
                 <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                 <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                 <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                 <RowStyle BackColor="White" ForeColor="#003399" />
                 <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                 <SortedAscendingCellStyle BackColor="#EDF6F6" />
                 <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                 <SortedDescendingCellStyle BackColor="#D6DFDF" />
                 <SortedDescendingHeaderStyle BackColor="#002876" />
             </asp:GridView>

             </div>
                               
                           </ContentTemplate>
                       </asp:UpdatePanel>

                       <asp:UpdatePanel ID="UpdatePanel16" runat="server">
                           <ContentTemplate>

                         

          <div class="col-md-12" style="left: 0px; top: 0px">
         <h2>Scotish  -Power (Renew)</h2>
             <asp:GridView ID="gvspae" runat="server" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" Width="100%" AutoGenerateColumns="False">
                 <Columns>
                     <asp:BoundField DataField="ProductName" HeaderText="ProductName" />
                     <asp:BoundField DataField="DailyStandingCharge" HeaderText="DailyStandingCharge" />
                      <asp:BoundField DataField="PriceType" HeaderText="Price Type" />
                     <asp:BoundField HeaderText="All" DataField ="All" />
                     <asp:BoundField DataField="Day" HeaderText="Day" />
                     <asp:BoundField DataField="Night" HeaderText="Night" />
                     <asp:BoundField DataField="EW" HeaderText="Evening Weekend" />
                     <asp:BoundField HeaderText="OffPeak" />
                  
                 </Columns>
                 <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                 <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                 <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                 <RowStyle BackColor="White" ForeColor="#003399" />
                 <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                 <SortedAscendingCellStyle BackColor="#EDF6F6" />
                 <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                 <SortedDescendingCellStyle BackColor="#D6DFDF" />
                 <SortedDescendingHeaderStyle BackColor="#002876" />
             </asp:GridView>

             </div>

                                 </ContentTemplate>
                       </asp:UpdatePanel>
                       <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                           <ContentTemplate>


                        
         <div class="col-md-12" style="left: 0px; top: 0px">
         <h2>SSE</h2>

             <asp:GridView ID="gvsse" runat="server" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" Width="100%" AutoGenerateColumns="False" OnRowDataBound="gvsse_RowDataBound">
                 <Columns>
                     <asp:BoundField DataField="SSERef" HeaderText="ProductName" />

                     <asp:BoundField DataField="Period" HeaderText="Period" />
                     <asp:BoundField DataField="AMRQuarterlyCharge" HeaderText="AMRQuarterlyCharge" />
                     <asp:BoundField DataField="NonAMRQuarterlyCharge" HeaderText="NonAMRQuarterlyCharge" />
                     <asp:BoundField DataField="AllUnits" HeaderText="AllUnits" />
                     <asp:BoundField DataField="DayUnits" HeaderText="DayUnits" />
                     <asp:BoundField DataField="NightUnits" HeaderText="NightUnits" />
                     <asp:BoundField DataField="WeekDayUnits" HeaderText="WeekDayUnits" />
                     <asp:BoundField DataField="EveningandWeekendUnits" HeaderText="EveningandWeekendUnits" />
                     <asp:BoundField DataField="OffPeakUnits" HeaderText="OffPeakUnits" />
                     <asp:BoundField DataField="NonWeekDayUnits" HeaderText="NonWeekDayUnits" />
                     <asp:BoundField DataField="FiTs" HeaderText="FiTs" />
                     

                     </Columns>

                 <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                 <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                 <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                 <RowStyle BackColor="White" ForeColor="#003399" />
                 <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                 <SortedAscendingCellStyle BackColor="#EDF6F6" />
                 <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                 <SortedDescendingCellStyle BackColor="#D6DFDF" />
                 <SortedDescendingHeaderStyle BackColor="#002876" />

                 </asp:GridView>

              <table style="width: 100%;">
                           <tr>
                               <td>Day Price</td>
                               <td>All units</td>
                               <td>Night Price</td>
                               <td>Weekend&nbsp; Price</td>
                               <td>Standing Charge</td>
                               <td>Uplift</td>
                               <td>Final Price</td>
                           </tr>
                           <tr>
                               <td>
                                   <asp:TextBox ID="txtsseDay" runat="server" TextMode="Number">0</asp:TextBox></td>
                               <td>
                                   <asp:TextBox ID="txtsseallunits" runat="server" TextMode="Number">0</asp:TextBox></td>
                               <td><asp:TextBox ID="txtssenight" runat="server" TextMode="Number">0</asp:TextBox></td>
                               <td><asp:TextBox ID="txtsseweekend" runat="server" TextMode="Number">0</asp:TextBox></td>
                               <td>
                                   <asp:TextBox ID="txtssesc" runat="server" TextMode="Number">0</asp:TextBox>
                               </td>
                               <td>
                                   <asp:TextBox ID="txtsseuplift" runat="server" TextMode="Number" min ="0.0" max= "3.0" step="0.1" AutoPostBack ="true"  >0</asp:TextBox>
                               </td>
                               <td>
                                   <asp:TextBox ID="txtssefinalvalue" runat="server" TextMode="Number">0</asp:TextBox>
                               </td>
                           </tr>
                           <tr>
                               <td>
                                   <asp:Label ID="lblsseday" runat="server" Text="0"></asp:Label>
                               </td>
                               <td>
                                   <asp:Label ID="lblsseallunit" runat="server" Text="0"></asp:Label>
                               </td>
                               <td>
                                   <asp:Label ID="lblssenight" runat="server" Text="0"></asp:Label>
                               </td>
                               <td>
                                   <asp:Label ID="lblsseweekend" runat="server" Text="0"></asp:Label>
                               </td>
                               <td>
                                   <asp:Label ID="lblssesc" runat="server" Text="0"></asp:Label>
                               </td>
                               <td>&nbsp;</td>
                               <td>&nbsp;</td>
                           </tr>
                       </table>


             </div>

                                  </ContentTemplate>
                       </asp:UpdatePanel>

                       <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                           <ContentTemplate>

                          
          <div class="col-md-12" style="left: 0px; top: 0px">
         <h2>TGP</h2>

             <asp:GridView ID="gvTGP" runat="server"  BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" Width="100%" AutoGenerateColumns="False" OnRowDataBound="gvTGP_RowDataBound">
                 <Columns>
                     <asp:BoundField DataField="ProductName" HeaderText="ProductName" />

                     <asp:BoundField DataField="ContractLength" HeaderText="Period" />
                     <asp:BoundField DataField="FixedChargepday" HeaderText="FixedChargepday" />
                     <asp:BoundField DataField="UnitspkWh" HeaderText="UnitspkWh" />
                     <asp:BoundField DataField="DayUnitspkWh" HeaderText="DayUnitspkWh" />
                     <asp:BoundField DataField="NightUnitspkWh" HeaderText="NightUnitspkWh" />
                     <asp:BoundField DataField="EveWeUnitspkWh" HeaderText="EveWeUnitspkWh" />
                     <asp:BoundField DataField="WeekdayUnitspkWh" HeaderText="WeekdayUnitspkWh" />
                     <asp:BoundField DataField="WinterEveUnitspkWh" HeaderText="WinterEveUnitspkWh" />
                    
                    

                     </Columns>

                 <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                 <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                 <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                 <RowStyle BackColor="White" ForeColor="#003399" />
                 <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                 <SortedAscendingCellStyle BackColor="#EDF6F6" />
                 <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                 <SortedDescendingCellStyle BackColor="#D6DFDF" />
                 <SortedDescendingHeaderStyle BackColor="#002876" />

                 </asp:GridView>

              <table style="width: 100%;">
                           <tr>
                               <td>Day Price</td>
                               <td>Unit Rate</td>
                               <td>Night Price</td>
                               <td>Weekend&nbsp; Price</td>
                               <td>Standing Charge</td>
                               <td>Uplift</td>
                               <td>Final Price</td>
                           </tr>
                           <tr>
                               <td>
                                   <asp:TextBox ID="txttgpday" runat="server" TextMode="Number">0</asp:TextBox></td>
                               <td>
                                   <asp:TextBox ID="txttgpunitrate" runat="server" TextMode="Number">0</asp:TextBox></td>
                               <td><asp:TextBox ID="txttgpnight" runat="server" TextMode="Number">0</asp:TextBox></td>
                               <td><asp:TextBox ID="txttgpweekend" runat="server" TextMode="Number">0</asp:TextBox></td>
                               <td>
                                   <asp:TextBox ID="txttgpsc" runat="server" TextMode="Number">0</asp:TextBox>
                               </td>
                               <td>
                                   <asp:TextBox ID="txttgpuplift" runat="server" TextMode="Number" min ="0.0" max= "3.0" step="0.1" AutoPostBack ="true" OnTextChanged="txtedfuplift_TextChanged" >0</asp:TextBox>
                               </td>
                               <td>
                                   <asp:TextBox ID="txttgpfinalvalue" runat="server" TextMode="Number">0</asp:TextBox>
                               </td>
                           </tr>
                           <tr>
                               <td>
                                   <asp:Label ID="lbltgpday" runat="server" Text="0"></asp:Label>
                               </td>
                               <td>
                                   <asp:Label ID="lbltgpunitrate" runat="server" Text="0"></asp:Label>
                               </td>
                               <td>
                                   <asp:Label ID="lbltgpnight" runat="server" Text="0"></asp:Label>
                               </td>
                               <td>
                                   <asp:Label ID="lbltgpweekend" runat="server" Text="0"></asp:Label>
                               </td>
                               <td>
                                   <asp:Label ID="lbltgpsc" runat="server" Text="0"></asp:Label>
                               </td>
                               <td>&nbsp;</td>
                               <td>&nbsp;</td>
                           </tr>
                       </table>


             </div>

                        </ContentTemplate>
                       </asp:UpdatePanel>
                       <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                           <ContentTemplate>

                           

          <div class="col-md-12" style="left: 0px; top: 0px">
         <h2>EON Energy</h2>

             <asp:GridView ID="gvEonDD" runat="server" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" Width="100%" AutoGenerateColumns="False" OnRowDataBound="gvEonDD_RowDataBound">
                 <Columns>
                     <asp:BoundField DataField="Product" HeaderText="ProductName" />

                     <asp:BoundField DataField="ContractLength" HeaderText="Period" />
                
                     <asp:BoundField DataField="DDStandingCharge" HeaderText="DDStandingCharge" />
                     <asp:BoundField DataField="DDDayAllSTODOtherDayUnits" HeaderText="DDDayAllSTODOtherDayUnits" />
                
                     <asp:BoundField DataField="DDStandingCharge" HeaderText="UnitspkWh" />
                     <asp:BoundField DataField="DDNightUnitPrice" HeaderText="DDNightUnitPrice" />
                     <asp:BoundField DataField="DDEveWkendControlSTODWinterPeak" HeaderText="DDEveWkendControlSTODWinterPeak" />
                     <asp:BoundField DataField="DDMinAQ" HeaderText="DDMinAQ" />
                     <asp:BoundField DataField="DDMaxAQ" HeaderText="DDMaxAQ" />
                    
                     </Columns>

                 <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                 <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                 <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                 <RowStyle BackColor="White" ForeColor="#003399" />
                 <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                 <SortedAscendingCellStyle BackColor="#EDF6F6" />
                 <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                 <SortedDescendingCellStyle BackColor="#D6DFDF" />
                 <SortedDescendingHeaderStyle BackColor="#002876" />

                 </asp:GridView>
              <table style="width: 100%;">
                           <tr>
                               <td>Day Price</td>
                               <td>Unit Rate</td>
                               <td>Night Price</td>
                               <td>Weekend&nbsp; Price</td>
                               <td>Standing Charge</td>
                               <td>Uplift</td>
                               <td>Final Price</td>
                           </tr>
                           <tr>
                               <td>
                                   <asp:TextBox ID="txteonday" runat="server" TextMode="Number">0</asp:TextBox></td>
                               <td>
                                   <asp:TextBox ID="txteonUnitrate" runat="server" TextMode="Number">0</asp:TextBox></td>
                               <td><asp:TextBox ID="txteonnight" runat="server" TextMode="Number">0</asp:TextBox></td>
                               <td><asp:TextBox ID="txteonweekend" runat="server" TextMode="Number">0</asp:TextBox></td>
                               <td>
                                   <asp:TextBox ID="txteonsc" runat="server" TextMode="Number">0</asp:TextBox>
                               </td>
                               <td>
                                   <asp:TextBox ID="txteonuplift" runat="server" TextMode="Number" min ="0.0" max= "3.0" step="0.1" AutoPostBack ="true" OnTextChanged="txteonuplift_TextChanged"  >0</asp:TextBox>
                               </td>
                               <td>
                                   <asp:TextBox ID="txteonfinalvalue" runat="server" TextMode="Number">0</asp:TextBox>
                               </td>
                           </tr>
                           <tr>
                               <td>
                                   <asp:Label ID="lbleonday" runat="server" Text="0"></asp:Label>
                               </td>
                               <td>
                                   <asp:Label ID="lbleonunitrate" runat="server" Text="0"></asp:Label>
                               </td>
                               <td>
                                   <asp:Label ID="lbleonnight" runat="server" Text="0"></asp:Label>
                               </td>
                               <td>
                                   <asp:Label ID="lbleonweekend" runat="server" Text="0"></asp:Label>
                               </td>
                               <td>
                                   <asp:Label ID="lbleonsc" runat="server" Text="0"></asp:Label>
                               </td>
                               <td>&nbsp;</td>
                               <td>&nbsp;</td>
                           </tr>
                       </table>


             </div>

</ContentTemplate>
                       </asp:UpdatePanel>


         </div>
    

      





              

   



</asp:Content>
