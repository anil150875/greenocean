<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GreenOcean._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
       
      
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
            <asp:Panel ID="Panel1" runat="server">
                <table style="width:100%;">
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="Search  Basis"></asp:Label>
                        </td>
                        <td style="width: 935px">
                            &nbsp;</td>
                        <td>&nbsp;</td>
                        <td>
                            <asp:TextBox ID="txtMPAN" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Electricity</td>
                        <td style="width: 935px">
                            &nbsp;</td>
                        <td>&nbsp;</td>
                        <td>Gas</td>
                    </tr>
                    <tr>
                        <td style="height: 22px">
                            <asp:DropDownList ID="ddProfile" runat="server" Width="71px">
                                <asp:ListItem>00</asp:ListItem>
                                <asp:ListItem>01</asp:ListItem>
                                <asp:ListItem>02</asp:ListItem>
                                <asp:ListItem Selected="True">03</asp:ListItem>
                                <asp:ListItem>04</asp:ListItem>
                                <asp:ListItem>05</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td style="height: 22px; width: 935px">
                            <asp:TextBox ID="txtRegion" runat="server">801</asp:TextBox>
                            <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                        </td>
                        <td style="height: 22px">&nbsp;</td>
                        <td style="height: 22px"></td>
                    </tr>
                    <tr>
                        <td style="height: 22px">
                            <asp:DropDownList ID="DropDownList2" runat="server" Width="71px">
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
                                <asp:ListItem>18</asp:ListItem>
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
                        </td>
                        <td style="height: 22px; width: 935px">
                            <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                        </td>
                        <td style="height: 22px">&nbsp;</td>
                        <td style="height: 22px">&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="height: 20px">
                            <asp:Label ID="lblProfile" runat="server" Text="Profile"></asp:Label>
                        </td>
                        <td style="height: 20px; width: 935px;">
                            <asp:Label ID="lblRegion" runat="server" Text="Area"></asp:Label>
                        </td>
                        <td style="height: 20px">&nbsp;</td>
                        <td style="height: 20px">
                            <asp:Label ID="lblMTCR" runat="server" Text="MTCR"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 20px">
                            <asp:Label ID="lblBGEMetertype" runat="server" Text="BG Existing"></asp:Label>
                        </td>
                        <td style="height: 20px; width: 935px;">
                            <asp:Label ID="lblDEMetertype" runat="server" Text="Duel Energy"></asp:Label>
                        </td>
                        <td style="height: 20px">&nbsp;</td>
                        <td style="height: 20px">
                            <asp:Label ID="lblEDFMetertype" runat="server" Text="Duel Energy"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblBGNewMetertye" runat="server" Text="BG New"></asp:Label>
                        </td>
                        <td style="width: 935px">
                            <asp:Label ID="lblBGLMetertype" runat="server" Text="BG Lite Energy"></asp:Label>
                        </td>
                        <td>&nbsp;</td>
                        <td>
                            <asp:Button ID="btinMpan" runat="server" BackColor="White" BorderStyle="None" Height="34px" OnClick="btinMpan_Click" Text="Go" Width="113px" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </asp:View>
        <asp:View ID="View2" runat="server">
           
            <table style="width:100%;">
                <tr>
                    <td style="height: 20px"></td>
                    <td style="height: 20px"></td>
                    <td style="height: 20px"></td>
                    <td style="height: 20px"></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Consumption"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtConsumption" runat="server">4999</asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Contract Time Frame"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtContract" runat="server">12</asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        <asp:TextBox ID="txtUplift" runat="server">0</asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Payment Method</td>
                    <td>
                        <asp:TextBox ID="txtPaymentMethod" runat="server">DD</asp:TextBox>
                    </td>
                    <td>Uplift</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Start date</td>
                    <td>
                        <asp:Calendar ID="cdStartDate" runat="server"   SelectedDate="<%# DateTime.Today %>"   OnSelectionChanged="cdStartDate_SelectionChanged"></asp:Calendar>
                    </td>
                    <td>End Date</td>
                    <td>
                        <asp:Calendar ID="cdEndDate" runat="server"  SelectedDate="<%# DateTime.Now.AddYears(1) %>"  OnSelectionChanged="cdEndDate_SelectionChanged"></asp:Calendar>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Label ID="lblStartdate" runat="server" Text="Start date"></asp:Label>
                    </td>
                    <td>
                        <asp:Button ID="btnShowProposal" runat="server" BackColor="White" BorderStyle="None" Height="34px" OnClick="btnShowProposal_Click" Text="Show Proposal" Width="113px" />
                    </td>
                    <td>
                        <asp:Label ID="lblEnddate" runat="server" Text="EndDate"></asp:Label>
                    </td>
                </tr>
            </table>
           
        </asp:View>
        <asp:View ID="View3" runat="server">
              <div class="row">
        <div class="col-md-12">
            <h2>British Gas (Acquisition)</h2>
            <p>
              
                <asp:GridView ID="gvBGE" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Width="100%" OnRowDataBound="gvBGE_RowDataBound" ShowFooter="True">
                    
                    <Columns>
                        <asp:TemplateField HeaderText="Total Cost">
                            
                            <FooterTemplate>
                                Projected Payable amount
                            </FooterTemplate>
                            
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Uplift">
                            
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Final amount Cost">
                            
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server"></asp:Label>
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
              
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301948">Generate Quote&raquo;</a>
            </p>
        </div>
        <div class="col-md-12">
            <h2>British Gas Renewal</h2>
            <p>
            
            <asp:GridView ID="gvBGR" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" OnRowDataBound="gvBGR_RowDataBound" Width="100%">
                  
                    <Columns>
                        <asp:TemplateField HeaderText="Total Cost">
                            
                            <FooterTemplate>
                                Projected Payable amount
                            </FooterTemplate>
                            
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Uplift">
                            
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Final amount Cost">
                            
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server"></asp:Label>
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
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301949">Generate Quote &raquo;</a>
            </p>
        </div>
                  <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                      <ContentTemplate>


                    

                   <div class="col-md-12">
                       
            <h2>British Gas LE (Acquisition)</h2>
                        <asp:GridView ID="gvBGL" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Width="100%" OnRowDataBound="gvBGL_RowDataBound">

                              
                    <Columns>
                        <asp:TemplateField HeaderText="Total Cost">
                            
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Uplift">
                            
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Final amount Cost">
                            
                            <FooterTemplate>
                                Projected Payable amount
                            </FooterTemplate>
                            
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server"></asp:Label>
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
                       </div>
                    </ContentTemplate>
                  </asp:UpdatePanel>



                   <div class="col-md-12">
            <h2>British Gas LE (Renew)</h2>
                        <asp:GridView ID="gvBGlRenew" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Width="100%" OnRowDataBound="gvBGlRenew_RowDataBound">

                              
                    <Columns>
                        <asp:TemplateField HeaderText="Total Cost">
                            
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Uplift">
                            
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Final amount Cost">
                            
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server"></asp:Label>
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
                       </div>

                   <div class="col-md-12">
            <h2>Duel Energy</h2>
                        <asp:GridView ID="gvDE" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Width="100%" OnSelectedIndexChanged="gvDE_SelectedIndexChanged">
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
                       </div>

                  <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                      <ContentTemplate>

                          
                   <div class="col-md-12">
            <h2>EDF ELectricity </h2>
                        <asp:GridView ID="gvEDF" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Width="100%">
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
                       </div>

                           </ContentTemplate>

                  </asp:UpdatePanel> 


        
    </div>
        </asp:View>
        <asp:View ID ="View4" runat ="server"  >

            <table style="width:100%;">
                <tr>
                    <td>
                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" Visible="False">
                            <asp:ListItem>Electricity</asp:ListItem>
                            <asp:ListItem>Gas</asp:ListItem>
                            <asp:ListItem>Both</asp:ListItem>
                        </asp:RadioButtonList>
                        &nbsp;</td>
                    <td>&nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>Create&nbsp; Business</td>
                    <td>
                        <asp:TextBox ID="txtBusiness" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Matrix Quote" Width="139px" />
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:DropDownList ID="ddCurrentElectricity" runat="server" Visible="False">
                            <asp:ListItem>British Gas</asp:ListItem>
                            <asp:ListItem>British Gas LE</asp:ListItem>
                            <asp:ListItem>Duel Energy</asp:ListItem>
                            <asp:ListItem>EDF</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddCurrentGas" runat="server" Visible="False">
                            <asp:ListItem>British Gas</asp:ListItem>
                            <asp:ListItem>British Gas LE</asp:ListItem>
                            <asp:ListItem>Duel Energy</asp:ListItem>
                            <asp:ListItem>EDF</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>

        </asp:View>

        <asp:View ID ="View5" runat ="server"  >

          
            <table style="width:100%;">
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label5" runat="server" Text="MPRN"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                    <td>
                        <asp:TextBox ID="TextBox2" runat="server" OnTextChanged="TextBox2_TextChanged"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="Label6" runat="server" Text="Create Business"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox3" runat="server" OnTextChanged="TextBox2_TextChanged"></asp:TextBox>
                    </td>
                </tr>
            </table>

          
        </asp:View>

  

        </asp:MultiView>
    </div>
    
</asp:Content>
