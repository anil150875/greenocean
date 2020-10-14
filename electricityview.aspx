<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="electricityview.aspx.cs" Inherits="GreenOcean.electricityview" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm(" Are you sure? You want to send the email")) {
                confirm_value.value = "Yes";
            }
            else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }
    </script>
    <table class="nav-justified">
        <tr class="success">
            <td>PC :<asp:Label ID="lblProfile" runat="server" Text="Label"></asp:Label>
            </td>
            <td>MTC :<asp:Label ID="lblMTC" runat="server" Text="Label"></asp:Label>
            </td>
            <td>PES :
                <asp:Label ID="lblRegion" runat="server" Text="Label"></asp:Label>
            </td>

            <td>Duration :
                <asp:Label ID="lblDuration" runat="server" Text="Label"></asp:Label>
            </td>
            <td>EAC : 
                <asp:Label ID="lblEac" runat="server" Text="Label"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtEac" runat="server" TextMode="Number" Width="75px"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="btnEac" runat="server" Text="Update EAC" OnCommand="btnEac_Command" CssClass="btn-primary" />
            </td>

            <td>
                <asp:Label ID="lblBusinessType" runat="server" Text="lblBusinesstype" Visible="False"></asp:Label>
            </td>

            <td>
                <asp:Label ID="lblCurrentSupplier" runat="server" Text="Current Supplier" Visible="false"></asp:Label>
            </td>

            <td>
                <asp:Label ID="lblStartdate" runat="server" Text="start date" Visible="False"></asp:Label>
            </td>

        </tr>


        <tr class="success">
            <td>
                <asp:Label ID="lblBGEMetertype" runat="server" Text="lblBGEMetertype" Visible="False"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblBGLMetertype" runat="server" Text="lblBGLMetertype" Visible="False"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblDEMetertype" runat="server" Text="lblDEMetertype" Visible="False"></asp:Label>
            </td>

            <td>
                <asp:Label ID="lblEDFMetertype" runat="server" Text="lblDEMetertype" Visible="False"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblNpwer" runat="server" Text="lblNpwer" Visible="False"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblOpusMeterType" runat="server" Text="lblOpusMeterType" Visible="False"></asp:Label>
                <asp:Label ID="lblOpusMeterType1" runat="server" Text="lblOpusMeterType" Visible="False"></asp:Label>
                <asp:Label ID="lblOpusMeterType2" runat="server" Text="lblOpusMeterType" Visible="False"></asp:Label>
                <asp:Label ID="lblOpusMeterType3" runat="server" Text="lblOpusMeterType" Visible="False"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtUplift" runat="server"></asp:TextBox>



            </td>

            <td>
                <asp:Label ID="lblELEPayment" runat="server" Text="lblDEMetertype" Visible="False"></asp:Label>
            </td>

        </tr>


        <tr class="success">
            <td>
                <asp:Label ID="lblGZMetertype" runat="server" Text="lblGZMetertype" Visible="False"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblPEMetertype" runat="server" Text="lblPEMetertype" Visible="False"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblSPAMetertype" runat="server" Text="lblSPAPEMetertype" Visible="False"></asp:Label>
            </td>

            <td>
                <asp:Label ID="lblSSEPEMetertype" runat="server" Text="lblSSEPEMetertype" Visible="False"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblEONEMetertype" runat="server" Text="lblEONEMetertype" Visible="False"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblHevsMeterType" runat="server" Text="lblHevs"></asp:Label>
                 <asp:Label ID="lblGulfMetertype" runat="server" Text="lblgulf"></asp:Label>
                 <asp:Label ID="lblyuMetertype" runat="server" Text="lblyu"></asp:Label>
                 <asp:Label ID="lblUtilitaMetertype" runat="server" Text="lblutillita"></asp:Label>
            </td>
            <td>&nbsp;</td>

            <td>&nbsp;</td>

        </tr>
    </table>
    <table class="nav-justified">
        <tr class="success">
            <td>Business Name<asp:TextBox ID="txtBusiness" runat="server" Width="100px"></asp:TextBox>
            </td>
            <td>Business Address : 
                <asp:TextBox ID="txtBusinessAddress" runat="server" Width="100px"></asp:TextBox></td>
            <td>ZIP :
                <asp:TextBox ID="txtBusinessZip" runat="server" Width="75px"></asp:TextBox>


            </td>
            <td>Name :<asp:TextBox ID="txtName" runat="server" Width="75px"></asp:TextBox>
            </td>
            <td>Email :<asp:TextBox ID="txtEmail" runat="server" TextMode="Email"></asp:TextBox>
                <asp:DropDownList ID="ddProvider" runat="server">
                    <asp:ListItem Selected="True">Select</asp:ListItem>
                    <asp:ListItem>Energy Savers</asp:ListItem>
                    <asp:ListItem>Utility Savers</asp:ListItem>
                    <asp:ListItem>Energy Advisors</asp:ListItem>
                    <asp:ListItem>Utility Now</asp:ListItem>
                </asp:DropDownList>
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
            </td>


            <td>
                <asp:Button ID="btnSendEmail" runat="server" Text="Send Email " OnClick="SendEmail_Click" CssClass="btn-primary" OnClientClick="Confirm()" />

            </td>
            <td>
                <asp:Button ID="btnResult" runat="server" OnClick="btnResult_Click" Text="Show Result" CssClass="btn-primary" /></td>



            <tr class="success">
                <td colspan="8"></td>
            </tr>


    </table>
    <%-- <td>
                                <asp:TextBox ID="txtbga12wd" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>

                            <td>
                                <asp:TextBox ID="txtbga12unit" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>--%>













    <asp:Menu ID="Menu1" runat="server" Font-Size="Small" Orientation="Horizontal" StaticSubMenuIndent="10px" Font-Bold="True" Font-Italic="False" BackColor="#B5C7DE" CssClass="alert-info" DynamicHorizontalOffset="2" Font-Names="Verdana" ForeColor="#284E98" OnMenuItemClick="Menu1_MenuItemClick" Width="100%">
        <DynamicHoverStyle BackColor="#284E98" ForeColor="White" />
        <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
        <DynamicMenuStyle BackColor="#B5C7DE" />
        <DynamicSelectedStyle BackColor="#507CD1" />
        <Items>
            <asp:MenuItem Text="12 Months" Value="0"></asp:MenuItem>
            <asp:MenuItem Text="24 Months" Value="1"></asp:MenuItem>
            <asp:MenuItem Text="36 Months" Value="2"></asp:MenuItem>
            <asp:MenuItem Text="48 Months" Value="3"></asp:MenuItem>
            <asp:MenuItem Text="60 Months" Value="4"></asp:MenuItem>
            <asp:MenuItem Text="All Terms" Value="5"></asp:MenuItem>
        </Items>

        <StaticHoverStyle BackColor="#284E98" ForeColor="White" />
        <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
        <StaticSelectedStyle BackColor="#507CD1" />

    </asp:Menu>



    <asp:MultiView runat="server" ID="Multiview1">
        <asp:View ID="View12" runat="server">
            <br />
            <table class="table table-bordered table-dark">
                <tr>
                    <td>Supplier Name</td>
                    <td>Program Name</td>
                    <td>Standing&nbsp; charge</td>
                    <td>Day Unit Charge</td>
                    <td>Night Unit
                        <br />
                        Charge</td>
                    <td>EVENING<br />
                        WEEKEND UNIT CHARGE</td>
                    <%-- <td>WEEKDAY
                        <br />
                        DAY UNIT<br />
                        CHARGE</td>

                    <td>UNIT Charge</td>--%>
                    <td>OFF PEAK UNIT CHARGE</td>
                    <td>Other Charges </td>
                    <td>Uplift</td>
                    <td>Yearly Charge</td>

                    <td>Mail</td>
                    <td>Show </td>
                    <td>Save</td>





                </tr>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>



                        <tr>



                            <td>
                                <asp:ImageButton ID="bga12supplier" runat="server" Height="39px" ImageUrl="~/britishgas.jpg" Width="175px" />
                            </td>
                            <td>
                                <asp:Label ID="lblBga12program" runat="server" Text="British Gas new"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbga12sc" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txtbga12day" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbga12night" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>

                            <td>
                                <asp:TextBox ID="txtbga12ew" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <%-- <td>
                                <asp:TextBox ID="txtbga12wd" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>

                            <td>
                                <asp:TextBox ID="txtbga12unit" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>--%>
                            <td>
                                <asp:TextBox ID="txtbga12offpeak" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbga12other" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbga12uplift" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="2.0" step="0.1" AutoPostBack="true" OnTextChanged="txtbga12uplift_TextChanged"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbga12rate" runat="server" Text="0" Width="75px"></asp:TextBox>

                            </td>
                            <td>
                                <asp:CheckBox ID="chkbga12" runat="server" />
                            </td>
                            <td>
                                <asp:Button ID="btnbga12Show" runat="server" Text="Show" OnClick="btnbga12Show_Click" />
                            </td>
                            <td>
                                <asp:Button ID="btnBga12Save" runat="server" Text="Save" /></td>




                        </tr>

                    </ContentTemplate>
                </asp:UpdatePanel>

                <tr>

                    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                        <ContentTemplate>







                            <td>
                                <asp:ImageButton ID="bge12supplier" runat="server" Height="39px" ImageUrl="~/britishgas.jpg" Width="175px" />
                            </td>
                            <td>
                                <asp:Label ID="lblBge12program" runat="server" Text="British Gas Re new "></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbge12sc" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txtbge12day" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbge12night" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbge12ew" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <%-- <td>
                                <asp:TextBox ID="txtbge12wd" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>

                            <td>
                                <asp:TextBox ID="txtbge12unit" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>--%>
                            <td>
                                <asp:TextBox ID="txtbge12offpeak" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbge12other" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbge12uplift" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="2.0" step="0.1" AutoPostBack="true" OnTextChanged="txtbge12uplift_TextChanged"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbge12rate" runat="server" Text="0" Width="75px"></asp:TextBox>

                            </td>
                            <td>
                                <asp:CheckBox ID="chkbge12" runat="server" />
                            </td>
                            </td>
                            <td>
                                <asp:Button ID="btnbge12show" runat="server" Text="Show" OnClick="btnbge12show_Click" />
                            </td>
                            <td>
                                <asp:Button ID="btnbgesave" runat="server" Text="Save" /></td>



                            </tr>

                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <tr>
                        <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                            <ContentTemplate>







                                <td>
                                    <asp:ImageButton ID="bgl12supplier" runat="server" Height="39px" ImageUrl="~/images/bgl.png" Width="175px" />
                                </td>
                                <td>
                                    <asp:Label ID="lblbgla12program" runat="server" Text="British Gas Lite new"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtbgla12sc" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txtbgla12day" runat="server" Text="0" Width="75px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtbgla12night" runat="server" Text="0" Width="75px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtbgla12ew" runat="server" Text="0" Width="75px"></asp:TextBox>
                                </td>
                                <%-- <td>
                                    <asp:TextBox ID="txtbgla12wd" runat="server" Text="0" Width="75px"></asp:TextBox>
                                </td>

                                <td>
                                    <asp:TextBox ID="txtbgla12unit" runat="server" Text="0" Width="75px"></asp:TextBox>
                                </td>--%>
                                <td>
                                    <asp:TextBox ID="txtbgla12offpeak" runat="server" Text="0" Width="75px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtbgla12other" runat="server" Text="0" Width="75px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtbgla12uplift" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="1.5" step="0.1" AutoPostBack="true" OnTextChanged="txtbgla12uplift_TextChanged"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtbgla12rate" runat="server" Text="0" Width="75px"></asp:TextBox>

                                </td>

                                <td>
                                    <asp:CheckBox ID="chkbgla12" runat="server" />
                                </td>
                                </td>
                                <td>
                                    <asp:Button ID="btnbgla12" runat="server" Text="Show" OnClick="btnbgla12_Click" />
                                </td>
                                <td>
                                    <asp:Button ID="Button2" runat="server" Text="Save" /></td>




                                </tr>

                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <tr>
                            <asp:UpdatePanel ID="UpdatePanel16" runat="server">
                                <ContentTemplate>







                                    <td>
                                        <asp:ImageButton ID="bgle12supplier" runat="server" Height="39px" ImageUrl="~/images/bgl.png" Width="175px" />
                                    </td>
                                    <td>
                                        <asp:Label ID="lblbgle12program" runat="server" Text="British Gas Lite new"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtbgle12sc" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                                    <td>
                                        <asp:TextBox ID="txtbgle12day" runat="server" Text="0" Width="75px"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtbgle12night" runat="server" Text="0" Width="75px"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtbgle12ew" runat="server" Text="0" Width="75px"></asp:TextBox>
                                    </td>
                                    <%-- <td>
                                        <asp:TextBox ID="txtbgle12wd" runat="server" Text="0" Width="75px"></asp:TextBox>
                                    </td>

                                    <td>
                                        <asp:TextBox ID="txtbgle12unit" runat="server" Text="0" Width="75px"></asp:TextBox>
                                    </td>--%>
                                    <td>
                                        <asp:TextBox ID="txtbgle12offpeak" runat="server" Text="0" Width="75px"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtbgle12other" runat="server" Text="0" Width="75px"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtbgle12uplift" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="1.5" step="0.1" AutoPostBack="true" OnTextChanged="txtbgle12uplift_TextChanged"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtbgle12rate" runat="server" Text="0" Width="75px"></asp:TextBox>

                                    </td>

                                    <td>
                                        <asp:CheckBox ID="chkbgle12" runat="server" />
                                    </td>
                                    </td>
                                    <td>
                                        <asp:Button ID="btnBgle" runat="server" Text="Show" OnClick="btnBgle_Click" />
                                    </td>
                                    <td>
                                        <asp:Button ID="Button4" runat="server" Text="Save" /></td>





                                    </tr>

                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <tr>

                                <asp:UpdatePanel ID="UpdatePanel21" runat="server">
                                    <ContentTemplate>







                                        <td>
                                            <asp:ImageButton ID="edfa12supplier" runat="server" Height="39px" ImageUrl="~/images/edf.jpg" Width="175px" />
                                        </td>
                                        <td>
                                            <asp:Label ID="lbledfa12program" runat="server" Text="British Gas Lite new"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtedfa12sc" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="txtedfa12day" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtedfa12night" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtedfa12ew" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <%-- <td>
                                            <asp:TextBox ID="txtedfa12wd" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>

                                        <td>
                                            <asp:TextBox ID="txtedfa12unit" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>--%>
                                        <td>
                                            <asp:TextBox ID="txtedfa12offpeak" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtedfa12other" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtedfa12uplift" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="1.5" step="0.1" AutoPostBack="true" OnTextChanged="txtedfa12uplift_TextChanged"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtEdf12Rate" runat="server" Text="0" Width="75px"></asp:TextBox>

                                        </td>

                                        <td>
                                            <asp:CheckBox ID="chkedf12" runat="server" />
                                        </td>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnedf12" runat="server" Text="Show" OnClick="btnedf12_Click" />
                                        </td>
                                        <td>
                                            <asp:Button ID="Button12" runat="server" Text="Save" /></td>



                                        </tr>

                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <tr>
                                    <asp:UpdatePanel ID="UpdatePanel26" runat="server">
                                        <ContentTemplate>







                                            <td>
                                                <asp:ImageButton ID="dea12supplier" runat="server" Height="39px" ImageUrl="~/images/de.jpg" Width="175px" />
                                            </td>
                                            <td>
                                                <asp:Label ID="lbldea12program" runat="server" Text="British Gas Lite new"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtdea12sc" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox ID="txtdea12day" runat="server" Text="0" Width="75px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtdea12night" runat="server" Text="0" Width="75px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtdea12ew" runat="server" Text="0" Width="75px"></asp:TextBox>
                                            </td>
                                            <%-- <td>
                                                <asp:TextBox ID="txtdea12wd" runat="server" Text="0" Width="75px"></asp:TextBox>
                                            </td>

                                            <td>
                                                <asp:TextBox ID="txtdea12unit" runat="server" Text="0" Width="75px"></asp:TextBox>
                                            </td>--%>
                                            <td>
                                                <asp:TextBox ID="txtdea12offpeak" runat="server" Text="0" Width="75px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtdea12other" runat="server" Text="0" Width="75px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtdea12uplift" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="2.0" step="0.1" AutoPostBack="true" OnTextChanged="txtdea12uplift_TextChanged"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtde12rate" runat="server" Text="0" Width="75px"></asp:TextBox>

                                            </td>

                                            <td>
                                                <asp:CheckBox ID="chkde12" runat="server" />
                                            </td>
                                            </td>
                                            <td>
                                                <asp:Button ID="btnde12" runat="server" Text="Show" OnClick="btnde12_Click" />
                                            </td>
                                            <td>
                                                <asp:Button ID="Button14" runat="server" Text="Save" /></td>



                                            </tr>

                                        </ContentTemplate>
                                    </asp:UpdatePanel>

                                    <asp:UpdatePanel ID="UpdatePanel140" runat="server">
                                        <ContentTemplate>







                                            <td>
                                                <asp:ImageButton ID="deawc12supplier" runat="server" Height="39px" ImageUrl="~/images/de.jpg" Width="175px" />
                                            </td>
                                            <td>
                                                <asp:Label ID="lbldeawc12program" runat="server" Text="Dual Energy WC 12 Months"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtdeawc12sc" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox ID="txtdeawc12day" runat="server" Text="0" Width="75px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtdeawc12night" runat="server" Text="0" Width="75px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtdeawc12ew" runat="server" Text="0" Width="75px"></asp:TextBox>
                                            </td>
                                            <%-- <td>
                                                <asp:TextBox ID="txtdeawc12wd" runat="server" Text="0" Width="75px"></asp:TextBox>
                                            </td>

                                            <td>
                                                <asp:TextBox ID="txtdeawc12unit" runat="server" Text="0" Width="75px"></asp:TextBox>
                                            </td>--%>
                                            <td>
                                                <asp:TextBox ID="txtdeawc12offpeak" runat="server" Text="0" Width="75px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtdeawc12other" runat="server" Text="0" Width="75px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtdeawc12uplift" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="2.0" step="0.1" AutoPostBack="true"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtdeawc12rate" runat="server" Text="0" Width="75px"></asp:TextBox>

                                            </td>

                                            <td>
                                                <asp:CheckBox ID="chkdeawc12" runat="server" />
                                            </td>
                                            </td>
                                            <td>
                                                <asp:Button ID="btndeawc12show" runat="server" Text="Show" />
                                            </td>
                                            <td>
                                                <asp:Button ID="btndeawc12save" runat="server" Text="Save" /></td>



                                            </tr>

                                        </ContentTemplate>
                                    </asp:UpdatePanel>






                                    <tr>
                                        <asp:UpdatePanel ID="UpdatePanel31" runat="server">
                                            <ContentTemplate>







                                                <td>
                                                    <asp:ImageButton ID="pe12supplier" runat="server" Height="39px" ImageUrl="~/images/positive.jpg" Width="175px" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblpe12program" runat="server" Text="Positive Energy"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtpe12sc" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                                                <td>
                                                    <asp:TextBox ID="txtpe12day" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtpe12night" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtpe12ew" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                </td>
                                                <%--  <td>
                                                    <asp:TextBox ID="txtpe12wd" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                </td>

                                                <td>
                                                    <asp:TextBox ID="txtpe12unit" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                </td--%>>
                                                <td>
                                                    <asp:TextBox ID="txtpe12offpeak" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtpe12other" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtpe12uplift" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="3.0" step="0.1" AutoPostBack="true" OnTextChanged="txtpe12uplift_TextChanged"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtpe12rate" runat="server" Text="0" Width="75px"></asp:TextBox>

                                                </td>

                                                <td>
                                                    <asp:CheckBox ID="chkpe12" runat="server" />
                                                </td>
                                                </td>
                                                <td>
                                                    <asp:Button ID="btnPE12" runat="server" Text="Show" OnClick="btnPE12_Click" />
                                                </td>
                                                <td>
                                                    <asp:Button ID="Button15" runat="server" Text="Save" /></td>




                                                </tr>

                                            </ContentTemplate>
                                        </asp:UpdatePanel>

                                        <asp:UpdatePanel ID="UpdatePanel34" runat="server">
                                            <ContentTemplate>

                                                <tr>





                                                    <td>
                                                        <asp:ImageButton ID="gaz12supplier" runat="server" Height="39px" ImageUrl="~/images/gaz.png" AlternateText="Gaz Prom " Width="175px" />
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblgaz12program" runat="server" Text="Gaz Prom "></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtgaz12sc" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox ID="txtgaz12day" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtgaz12night" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtgaz12ew" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                    </td>
                                                    <%-- <td>
                                                        <asp:TextBox ID="txtgaz12wd" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                    </td>

                                                    <td>
                                                        <asp:TextBox ID="txtgaz12unit" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                    </td>--%>
                                                    <td>
                                                        <asp:TextBox ID="txtgaz12offpeak" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtgaz12other" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtgaz12uplift" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="2.0" step="0.1" AutoPostBack="true" OnTextChanged="txtgaz12uplift_TextChanged"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtgaz12rate" runat="server" Text="0" Width="75px"></asp:TextBox>

                                                    </td>

                                                    <td>
                                                        <asp:CheckBox ID="chkgaz12" runat="server" />
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="btnGaz12" runat="server" Text="Show" OnClick="btnGaz12_Click" />
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="Button16" runat="server" Text="Save" /></td>




                                                </tr>

                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <tr>
                                            <asp:UpdatePanel ID="UpdatePanel37" runat="server">
                                                <ContentTemplate>







                                                    <td>
                                                        <asp:ImageButton ID="sse12supplier" runat="server" Height="39px" ImageUrl="~/images/sse.jpg" AlternateText="sse energy" Width="175px" />
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblsse12program" runat="server" Text="sse  Energy"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtsse12scamr" runat="server" Width="75px" Text="0"></asp:TextBox>
                                                        <asp:TextBox ID="txtsse12scnonamr" runat="server" Width="75px" Text="0"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtsse12day" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtsse12night" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtsse12ew" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                    </td>
                                                    <%-- <td>
                                                        <asp:TextBox ID="txtsse12wd" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                    </td>

                                                    <td>
                                                        <asp:TextBox ID="txtsse12unit" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                    </td>--%>
                                                    <td>
                                                        <asp:TextBox ID="txtsse12offpeak" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtsse12other" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtsse12uplift" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="2.0" step="0.1" AutoPostBack="true" OnTextChanged="txtsse12uplift_TextChanged"></asp:TextBox>
                                                        <asp:TextBox ID="txtsse12upliftnonamr" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="2.0" step="0.1" AutoPostBack="true" OnTextChanged="txtsse12upliftnonamr_TextChanged"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtsse12rate" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                        <asp:TextBox ID="txtsse12ratenonamr" runat="server" Text="0" Width="75px"></asp:TextBox>

                                                    </td>

                                                    <td>
                                                        <asp:CheckBox ID="chksse12amr" runat="server" /><br />
                                                        <asp:CheckBox ID="chksse12nonamr" runat="server" />
                                                    </td>
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="btnsse12amr" runat="server" Text="Show" OnClick="btnsse12amr_Click" />
                                                        <asp:Button ID="btnsse12nonamr" runat="server" Text="Show" OnClick="btnsse12nonamr_Click" />
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="Button17" runat="server" Text="Save" />
                                                        <asp:Button ID="Button1" runat="server" Text="Save" />
                                                    </td>



                                                    </tr>

                                                </ContentTemplate>
                                            </asp:UpdatePanel>

                                            <tr>
                                                <asp:UpdatePanel ID="UpdatePanel38" runat="server">
                                                    <ContentTemplate>







                                                        <td>
                                                            <asp:ImageButton ID="npra12supplier" runat="server" Height="39px" ImageUrl="~/images/npower.jpg" AlternateText="N Power energy" Width="175px" />
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblnpra12program" runat="server" Text="npra  Energy"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtnpra12sc" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                                                        <td>
                                                            <asp:TextBox ID="txtnpra12day" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtnpra12night" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtnpra12ew" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                        </td>
                                                        <%-- <td>
                                                            <asp:TextBox ID="txtnpra12wd" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                        </td>

                                                        <td>
                                                            <asp:TextBox ID="txtnpra12unit" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                        </td>--%>
                                                        <td>
                                                            <asp:TextBox ID="txtnpra12offpeak" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtnpra12other" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtnpra12uplift" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="3.0" step="0.1" AutoPostBack="true" OnTextChanged="txtnpra12uplift_TextChanged"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtnpra12rate" runat="server" Text="0" Width="75px"></asp:TextBox>

                                                        </td>

                                                        <td>
                                                            <asp:CheckBox ID="chknpr12" runat="server" />
                                                        </td>
                                                        </td>
                                                        <td>
                                                            <asp:Button ID="btnNpr12" runat="server" Text="Show" OnClick="btnNpr12_Click" />
                                                        </td>
                                                        <td>
                                                            <asp:Button ID="Button18" runat="server" Text="Save" /></td>



                                                        </tr>

                                                    </ContentTemplate>
                                                </asp:UpdatePanel>


                                                <asp:UpdatePanel ID="UpdatePanel41" runat="server">
                                                    <ContentTemplate>



                                                        <tr>



                                                            <td>
                                                                <asp:ImageButton ID="spe12supplier" runat="server" Height="39px" ImageUrl="~/images/sp_logo.jpg" AlternateText="N Power energy" Width="175px" />
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblspe12program" runat="server" Text="spe  Energy"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtspe12sc" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                                                            <td>
                                                                <asp:TextBox ID="txtspe12day" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtspe12night" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtspe12ew" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                            </td>
                                                            <%-- <td>
                                                                <asp:TextBox ID="txtspe12wd" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                            </td>

                                                            <td>
                                                                <asp:TextBox ID="txtspe12unit" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                            </td>--%>
                                                            <td>
                                                                <asp:TextBox ID="txtspe12offpeak" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtspe12other" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtspe12uplift" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="2.0" step="0.1" AutoPostBack="true" OnTextChanged="txtspe12uplift_TextChanged"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtspe12rate" runat="server" Text="0" Width="75px"></asp:TextBox>

                                                            </td>
                                                            <td>
                                                                <asp:CheckBox ID="chkspe12" runat="server" />
                                                            </td>
                                                            </td>
                                                            <td>
                                                                <asp:Button ID="btnSpe12" runat="server" Text="Show" OnClick="btnSpe12_Click" />
                                                            </td>
                                                            <td>
                                                                <asp:Button ID="Button19" runat="server" Text="Save" /></td>



                                                        </tr>

                                                    </ContentTemplate>
                                                </asp:UpdatePanel>

                                                <asp:UpdatePanel ID="UpdatePanel45" runat="server">
                                                    <ContentTemplate>



                                                        <tr>



                                                            <td>
                                                                <asp:ImageButton ID="tgp12supplier" runat="server" Height="39px" ImageUrl="~/images/tglogo.png" Width="175px" />
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lbltgp12program" runat="server" Text="Total Energy"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txttgp12sc" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                                                            <td>
                                                                <asp:TextBox ID="txttgp12day" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txttgp12night" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txttgp12ew" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                            </td>
                                                            <%-- <td>
                                                                <asp:TextBox ID="txttgp12wd" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                            </td>

                                                            <td>
                                                                <asp:TextBox ID="txttgp12unit" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                            </td>--%>
                                                            <td>
                                                                <asp:TextBox ID="txttgp12offpeak" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txttgp12other" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txttgp12uplift" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="3.0" step="0.1" AutoPostBack="true" OnTextChanged="txttgp12uplift_TextChanged"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txttgp12rate" runat="server" Text="0" Width="75px"></asp:TextBox>

                                                            </td>
                                                            <td>
                                                                <asp:CheckBox ID="chktgp12" runat="server" />
                                                            </td>
                                                            </td>
                                                            <td>
                                                                <asp:Button ID="btnTgp12" runat="server" Text="Show" OnClick="btnTgp12_Click" />
                                                            </td>
                                                            <td>
                                                                <asp:Button ID="Button21" runat="server" Text="Save" /></td>





                                                        </tr>

                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                                <asp:UpdatePanel ID="UpdatePanel130" runat="server">
                                                    <ContentTemplate>







                                                        <td>
                                                            <asp:ImageButton ID="tgpw12supplier" runat="server" Height="39px" ImageUrl="~/images/tglogo.png" Width="175px" />
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lbltgpw12program" runat="server" Text="Total Energy"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txttgpw12sc" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                                                        <td>
                                                            <asp:TextBox ID="txttgpw12day" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txttgpw12night" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txttgpw12ew" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                        </td>
                                                        <%-- <td>
                                                        <asp:TextBox ID="txttgpw12wd" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                    </td>

                                                    <td>
                                                        <asp:TextBox ID="txttgpw12unit" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                    </td>--%>
                                                        <td>
                                                            <asp:TextBox ID="txttgpw12offpeak" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txttgpw12other" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txttgpw12uplift" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="3.0" step="0.1" AutoPostBack="true"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txttgpw12rate" runat="server" Text="0" Width="75px"></asp:TextBox>

                                                        </td>
                                                        <td>
                                                            <asp:CheckBox ID="chktgpw12" runat="server" />
                                                        </td>
                                                        </td>
                             <td>
                                 <asp:Button ID="btntgpw12show" runat="server" Text="Show" />
                             </td>
                                                        <td>
                                                            <asp:Button ID="Button26" runat="server" Text="Save" /></td>





                                                        </tr>

                                                    </ContentTemplate>

                                                </asp:UpdatePanel>


                                                <asp:UpdatePanel ID="UpdatePanel101" runat="server">
                                                    <ContentTemplate>



                                                        <tr>



                                                            <td>
                                                                <asp:ImageButton ID="opus12supplier" runat="server" Height="39px" ImageUrl="~/images/opus.png" Width="175px" />
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblopus12program" runat="server" Text="Opus Energy"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtopus12sc" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                                                            <td>
                                                                <asp:TextBox ID="txtopus12day" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtopus12night" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                            </td>

                                                            <td>
                                                                <asp:TextBox ID="txtopus12ew" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                            </td>
                                                            <%-- <td>
                                                                <asp:TextBox ID="txtopus12wd" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                            </td>

                                                            <td>
                                                                <asp:TextBox ID="txtopus12unit" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                            </td>--%>
                                                            <td>
                                                                <asp:TextBox ID="txtopus12offpeak" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtopus12other" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtopus12uplift" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="1.0" step="0.1" AutoPostBack="true" OnTextChanged="txtopus12uplift_TextChanged"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtopus12rate" runat="server" Text="0" Width="75px"></asp:TextBox>

                                                            </td>
                                                            <td>
                                                                <asp:CheckBox ID="chkopus12" runat="server" />
                                                            </td>
                                                            <td>
                                                                <asp:Button ID="btnopus12Show" runat="server" Text="Show" />
                                                            </td>
                                                            <td>
                                                                <asp:Button ID="btnopus12Save" runat="server" Text="Save" /></td>




                                                        </tr>

                                                    </ContentTemplate>
                                                </asp:UpdatePanel>

                                                <asp:UpdatePanel ID="UpdatePanel105" runat="server">
                                                    <ContentTemplate>



                                                        <tr>



                                                            <td>
                                                                <asp:ImageButton ID="eon12supplier" runat="server" Height="39px" ImageUrl="~/images/eon.jpg" Width="175px" />
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lbleon12program" runat="server" Text="EON Energy"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txteon12sc" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                                                            <td>
                                                                <asp:TextBox ID="txteon12day" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txteon12night" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                            </td>

                                                            <td>
                                                                <asp:TextBox ID="txteon12ew" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                            </td>
                                                            <%-- <td>
                                                                <asp:TextBox ID="txteon12wd" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                            </td>

                                                            <td>
                                                                <asp:TextBox ID="txteon12unit" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                            </td>--%>
                                                            <td>
                                                                <asp:TextBox ID="txteon12offpeak" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txteon12other" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <%-- <asp:TextBox ID="txteon12uplift" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="3.0" step="0.1" AutoPostBack="true"></asp:TextBox>--%>
                                                                <asp:DropDownList ID="ddEon12Uplift" runat="server" Width="75px" AutoPostBack="true" OnSelectedIndexChanged="ddEon12Uplift_SelectedIndexChanged">
                                                                    <asp:ListItem>0.0</asp:ListItem>
                                                                    <asp:ListItem>0.1</asp:ListItem>
                                                                    <asp:ListItem>0.2</asp:ListItem>
                                                                    <asp:ListItem>0.3</asp:ListItem>
                                                                    <asp:ListItem>0.4</asp:ListItem>
                                                                    <asp:ListItem>0.5</asp:ListItem>
                                                                    <asp:ListItem>0.6</asp:ListItem>
                                                                    <asp:ListItem>0.7</asp:ListItem>
                                                                    <asp:ListItem>0.8</asp:ListItem>
                                                                    <asp:ListItem>0.9</asp:ListItem>
                                                                    <asp:ListItem>1.0</asp:ListItem>
                                                                    <asp:ListItem>1.2</asp:ListItem>
                                                                    <asp:ListItem>1.5</asp:ListItem>



                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txteon12rate" runat="server" Text="0" Width="75px"></asp:TextBox>

                                                            </td>
                                                            <td>
                                                                <asp:CheckBox ID="chkeon12" runat="server" />
                                                            </td>
                                                            <td>
                                                                <asp:Button ID="btneon12Show" runat="server" Text="Show" />
                                                            </td>
                                                            <td>
                                                                <asp:Button ID="btneon12Save" runat="server" Text="Save" /></td>




                                                        </tr>

                                                    </ContentTemplate>
                                                </asp:UpdatePanel>

                                                <asp:UpdatePanel ID="UpdatePanel117" runat="server">
                                                    <ContentTemplate>



                                                        <tr>



                                                            <td>
                                                                <asp:ImageButton ID="hev12supplier" runat="server" Height="39px" ImageUrl="~/images/hev.png" Width="175px" />
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblhev12program" runat="server" Text="Heven  Energy"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txthev12sc" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                                                            <td>
                                                                <asp:TextBox ID="txthev12day" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txthev12night" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                            </td>

                                                            <td>
                                                                <asp:TextBox ID="txthev12ew" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                            </td>
                                                            <%-- <td>
                                                                <asp:TextBox ID="txthev12wd" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                            </td>

                                                            <td>
                                                                <asp:TextBox ID="txthev12unit" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                            </td>--%>
                                                            <td>
                                                                <asp:TextBox ID="txthev12offpeak" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txthev12other" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txthev12uplift" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="1.0" step="0.1" AutoPostBack="true"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txthev12rate" runat="server" Text="0" Width="75px"></asp:TextBox>

                                                            </td>
                                                            <td>
                                                                <asp:CheckBox ID="chkhev12" runat="server" />
                                                            </td>
                                                            <td>
                                                                <asp:Button ID="btnhev12Show" runat="server" Text="Show" />
                                                            </td>
                                                            <td>
                                                                <asp:Button ID="btnhev12Save" runat="server" Text="Save" /></td>




                                                        </tr>

                                                    </ContentTemplate>
                                                </asp:UpdatePanel>

                                                <asp:UpdatePanel ID="UpdatePanel135" runat="server">
                                                    <ContentTemplate>



                                                        <tr>



                                                            <td>
                                                                <asp:ImageButton ID="hevc12supplier" runat="server" Height="39px" ImageUrl="~/images/hev.png" Width="175px" />
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblhevc12program" runat="server" Text="heven  Energy Complete"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txthevc12sc" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                                                            <td>
                                                                <asp:TextBox ID="txthevc12day" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txthevc12night" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                            </td>

                                                            <td>
                                                                <asp:TextBox ID="txthevc12ew" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                            </td>
                                                            <%-- <td>
                                                                <asp:TextBox ID="txthevc12wd" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                            </td>

                                                            <td>
                                                                <asp:TextBox ID="txthevc12unit" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                            </td>--%>
                                                            <td>
                                                                <asp:TextBox ID="txthevc12offpeak" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txthevc12other" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txthevc12uplift" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="1.0" step="0.1" AutoPostBack="true"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txthevc12rate" runat="server" Text="0" Width="75px"></asp:TextBox>

                                                            </td>
                                                            <td>
                                                                <asp:CheckBox ID="chkhevc12" runat="server" />
                                                            </td>
                                                            <td>
                                                                <asp:Button ID="btnhevc12Show" runat="server" Text="Show" />
                                                            </td>
                                                            <td>
                                                                <asp:Button ID="btnhevc12Save" runat="server" Text="Save" /></td>




                                                        </tr>

                                                    </ContentTemplate>
                                                </asp:UpdatePanel>


                                <asp:UpdatePanel ID="UpdatePanel150" runat="server">
                                    <ContentTemplate>







                                        <td>
                                            <asp:ImageButton ID="utila12supplier" runat="server" Height="39px" ImageUrl="~/images/utilita.png" Width="175px" />
                                        </td>
                                        <td>
                                            <asp:Label ID="lblutila12program" runat="server" Text="Utilita Energy new"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtutila12sc" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="txtutila12day" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtutila12night" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtutila12ew" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <%-- <td>
                                            <asp:TextBox ID="txtutila12wd" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>

                                        <td>
                                            <asp:TextBox ID="txtutila12unit" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>--%>
                                        <td>
                                            <asp:TextBox ID="txtutila12offpeak" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtutila12other" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtutila12uplift" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="1.5" step="0.1" AutoPostBack="true" ></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtutil12Rate" runat="server" Text="0" Width="75px"></asp:TextBox>

                                        </td>

                                        <td>
                                            <asp:CheckBox ID="chkutil12" runat="server" />
                                        </td>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnutil12" runat="server" Text="Show" OnClick="btnutil12Show_Click" />
                                        </td>
                                        <td>
                                            <asp:Button ID="Button42" runat="server" Text="Save" /></td>



                                        </tr>

                                    </ContentTemplate>
                                </asp:UpdatePanel>
								
								
								 <asp:UpdatePanel ID="UpdatePanel151" runat="server">
                                    <ContentTemplate>







                                        <td>
                                            <asp:ImageButton ID="gulfa12supplier" runat="server" Height="39px" ImageUrl="~/images/gulf.png" Width="175px" />
                                        </td>
                                        <td>
                                            <asp:Label ID="lblgulfa12program" runat="server" Text="Gulf  Energy"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtgulfa12sc" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="txtgulfa12day" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtgulfa12night" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtgulfa12ew" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <%-- <td>
                                            <asp:TextBox ID="txtgulfa12wd" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>

                                        <td>
                                            <asp:TextBox ID="txtgulfa12unit" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>--%>
                                        <td>
                                            <asp:TextBox ID="txtgulfa12offpeak" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtgulfa12other" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtgulfa12uplift" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="1.5" step="0.1" AutoPostBack="true"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtgulf12Rate" runat="server" Text="0" Width="75px"></asp:TextBox>

                                        </td>

                                        <td>
                                            <asp:CheckBox ID="chkgulf12" runat="server" />
                                        </td>
                                        </td>
                                        <td>
                                            <asp:Button ID="btngulf12" runat="server" Text="Show" OnClick="btngulf12Show_Click" />
                                        </td>
                                        <td>
                                            <asp:Button ID="Button44" runat="server" Text="Save" /></td>



                                        </tr>

                                    </ContentTemplate>
                                </asp:UpdatePanel>
								
								  <asp:UpdatePanel ID="UpdatePanel152" runat="server">
                                    <ContentTemplate>







                                        <td>
                                            <asp:ImageButton ID="yuea12supplier" runat="server" Height="39px"  ImageUrl="~/images/yue.jpg" Width="175px" />
                                        </td>
                                        <td>
                                            <asp:Label ID="lblyuea12program" runat="server" Text="YU Energy"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtyuea12sc" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="txtyuea12day" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtyuea12night" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtyuea12ew" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <%-- <td>
                                            <asp:TextBox ID="txtyuea12wd" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>

                                        <td>
                                            <asp:TextBox ID="txtyuea12unit" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>--%>
                                        <td>
                                            <asp:TextBox ID="txtyuea12offpeak" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtyuea12other" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtyuea12uplift" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="1.5" step="0.1" AutoPostBack="true" ></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtyue12Rate" runat="server" Text="0" Width="75px"></asp:TextBox>

                                        </td>

                                        <td>
                                            <asp:CheckBox ID="chkyue12" runat="server" />
                                        </td>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnyue12" runat="server" Text="Show" OnClick="btnyue12Show_Click" />
                                            <%--<asp:Button ID="btnyue12" runat="server" Text="Show" />--%>
                                        </td>
                                        <td>
                                            <asp:Button ID="Button46" runat="server" Text="Save" /></td>



                                        </tr>

                                    </ContentTemplate>
                                </asp:UpdatePanel>









            </table>



        </asp:View>
        <asp:View ID="View24" runat="server">
            <table class="table table-bordered table-dark">
                <tr>
                    <td>Supplier Name</td>
                    <td>Program Name</td>
                    <td>Standing&nbsp; charge</td>
                    <td>Day Unit Charge</td>
                    <td>Night Unit Charge</td>
                    <td>EVENING WEEKEND UNIT CHARGE</td>
                    <%--<td>WEEKDAY DAY UNIT CHARGE</td>

                    <td>UNIT Charge</td>--%>
                    <td>OFF PEAK UNIT CHARGE</td>
                    <td>Other Charges </td>
                    <td>Uplift</td>
                    <td>Yearly Charge</td>





                    <td>Mail</td>
                    <td>Show </td>
                    <td>Save</td>





                </tr>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>



                        <tr>



                            <td>
                                <asp:ImageButton ID="bga24supplier" runat="server" Height="39px" ImageUrl="~/britishgas.jpg" Width="175px" />
                            </td>
                            <td>
                                <asp:Label ID="lblBga24program" runat="server" Text="British Gas new"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbga24sc" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txtbga24day" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbga24night" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbga24ew" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <%-- <td>
                                <asp:TextBox ID="txtbga24wd" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>

                            <td>
                                <asp:TextBox ID="txtbga24unit" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>--%>
                            <td>
                                <asp:TextBox ID="txtbga24offpeak" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbga24other" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbga24uplift" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="2.0" step="0.1" AutoPostBack="true" OnTextChanged="txtbga24uplift_TextChanged"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbga24rate" runat="server" Text="0" Width="75px"></asp:TextBox>

                            </td>
                            <td>
                                <asp:CheckBox ID="chkbga24" runat="server" />
                            </td>
                            <td>
                                <asp:Button ID="btnBga24" runat="server" Text="Show" OnClick="btnBga24_Click" />
                            </td>
                            <td>
                                <asp:Button ID="Button23" runat="server" Text="Save" /></td>





                        </tr>

                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                    <ContentTemplate>



                        <tr>



                            <td>
                                <asp:ImageButton ID="bge24supplier" runat="server" Height="39px" ImageUrl="~/britishgas.jpg" Width="175px" />
                            </td>
                            <td>
                                <asp:Label ID="lblBge24program" runat="server" Text="British Gas Re new "></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbge24sc" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txtbge24day" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbge24night" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbge24ew" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <%-- <td>
                                <asp:TextBox ID="txtbge24wd" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>

                            <td>
                                <asp:TextBox ID="txtbge24unit" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>--%>
                            <td>
                                <asp:TextBox ID="txtbge24offpeak" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbge24other" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbge24uplift" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="2.0" step="0.1" AutoPostBack="true" OnTextChanged="txtbge24uplift_TextChanged"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbfge24rate" runat="server" Text="0" Width="75px"></asp:TextBox>

                            </td>
                            <td>
                                <asp:CheckBox ID="chkbge24" runat="server" />
                            </td>
                            <td>
                                <asp:Button ID="btnBge24" runat="server" Text="Show" OnClick="btnBge24_Click" />
                            </td>
                            <td>
                                <asp:Button ID="Button25" runat="server" Text="Save" /></td>





                        </tr>

                    </ContentTemplate>
                </asp:UpdatePanel>

                <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                    <ContentTemplate>



                        <tr>



                            <td>
                                <asp:ImageButton ID="bgl24supplier" runat="server" Height="39px" ImageUrl="~/images/bgl.png" Width="175px" />
                            </td>
                            <td>
                                <asp:Label ID="lblbgla24program" runat="server" Text="British Gas Lite new"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbgla24sc" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txtbgla24day" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbgla24night" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbgla24ew" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <%-- <td>
                                <asp:TextBox ID="txtbgla24wd" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>

                            <td>
                                <asp:TextBox ID="txtbgla24unit" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>--%>
                            <td>
                                <asp:TextBox ID="txtbgla24offpeak" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbgla24other" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbgla24uplift" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="1.5" step="0.1" AutoPostBack="true" OnTextChanged="txtbgla24uplift_TextChanged"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbfgla24rate" runat="server" Text="0" Width="75px"></asp:TextBox>

                            </td>

                            <td>
                                <asp:CheckBox ID="chkbgla24" runat="server" />
                            </td>
                            <td>
                                <asp:Button ID="btnbgla24" runat="server" Text="Show" OnClick="btnbgla24_Click" />
                            </td>
                            <td>
                                <asp:Button ID="Button27" runat="server" Text="Save" /></td>

                        </tr>

                    </ContentTemplate>
                </asp:UpdatePanel>

                <asp:UpdatePanel ID="UpdatePanel17" runat="server">
                    <ContentTemplate>



                        <tr>



                            <td>
                                <asp:ImageButton ID="bgle24supplier" runat="server" Height="39px" ImageUrl="~/images/bgl.png" Width="175px" />
                            </td>
                            <td>
                                <asp:Label ID="lblbgle24program" runat="server" Text="British Gas Lite new"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbgle24sc" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txtbgle24day" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbgle24night" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbgle24ew" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <%-- <td>
                                <asp:TextBox ID="txtbgle24wd" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>

                            <td>
                                <asp:TextBox ID="txtbgle24unit" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>--%>
                            <td>
                                <asp:TextBox ID="txtbgle24offpeak" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbgle24other" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbgle24uplift" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="1.5" step="0.1" AutoPostBack="true" OnTextChanged="txtbgle24uplift_TextChanged"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbgle24rate" runat="server" Text="0" Width="75px"></asp:TextBox>

                            </td>
                            <td>
                                <asp:CheckBox ID="chkbgle24" runat="server" />
                            </td>
                            <td>
                                <asp:Button ID="btnbgle24" runat="server" Text="Show" OnClick="btnbgle24_Click" />
                            </td>
                            <td>
                                <asp:Button ID="Button29" runat="server" Text="Save" /></td>





                        </tr>

                    </ContentTemplate>
                </asp:UpdatePanel>

                <asp:UpdatePanel ID="UpdatePanel22" runat="server">
                    <ContentTemplate>



                        <tr>



                            <td>
                                <asp:ImageButton ID="edfa24supplier" runat="server" Height="39px" ImageUrl="~/images/edf.jpg" Width="175px" />
                            </td>
                            <td>
                                <asp:Label ID="lbledfa24program" runat="server" Text="British Gas Lite new"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtedfa24sc" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txtedfa24day" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtedfa24night" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtedfa24ew" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <%-- <td>
                                <asp:TextBox ID="txtedfa24wd" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>

                            <td>
                                <asp:TextBox ID="txtedfa24unit" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>--%>
                            <td>
                                <asp:TextBox ID="txtedfa24offpeak" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtedfa24other" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtedfa24uplift" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="1.5" step="0.1" AutoPostBack="true" OnTextChanged="txtedfa24uplift_TextChanged"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtEdf24Rate" runat="server" Text="0" Width="75px"></asp:TextBox>

                            </td>

                            <td>
                                <asp:CheckBox ID="chkedf24" runat="server" />
                            </td>
                            <td>
                                <asp:Button ID="btnEDF24" runat="server" Text="Show" OnClick="btnEDF24_Click" />
                            </td>
                            <td>
                                <asp:Button ID="Button31" runat="server" Text="Save" /></td>





                        </tr>

                    </ContentTemplate>
                </asp:UpdatePanel>

                <asp:UpdatePanel ID="UpdatePanel27" runat="server">
                    <ContentTemplate>



                        <tr>



                            <td>
                                <asp:ImageButton ID="dea24supplier" runat="server" Height="39px" ImageUrl="~/images/de.jpg" Width="175px" />
                            </td>
                            <td>
                                <asp:Label ID="lbldea24program" runat="server" Text="British Gas Lite new"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtdea24sc" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txtdea24day" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtdea24night" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtdea24ew" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <%-- <td>
                                <asp:TextBox ID="txtdea24wd" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>

                            <td>
                                <asp:TextBox ID="txtdea24unit" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>--%>
                            <td>
                                <asp:TextBox ID="txtdea24offpeak" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtdea24other" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtdea24uplift" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="2.0" step="0.1" AutoPostBack="true" OnTextChanged="txtdea24uplift_TextChanged"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtde24rate" runat="server" Text="0" Width="75px"></asp:TextBox>

                            </td>

                            <td>
                                <asp:CheckBox ID="chkde24" runat="server" />
                            </td>
                            <td>
                                <asp:Button ID="btnDe24" runat="server" Text="Show" OnClick="btnDe24_Click" />
                            </td>
                            <td>
                                <asp:Button ID="Button33" runat="server" Text="Save" /></td>





                        </tr>

                    </ContentTemplate>


                </asp:UpdatePanel>

                <asp:UpdatePanel ID="UpdatePanel141" runat="server">
                    <ContentTemplate>







                        <td>
                            <asp:ImageButton ID="deawc24supplier" runat="server" Height="39px" ImageUrl="~/images/de.jpg" Width="175px" />
                        </td>
                        <td>
                            <asp:Label ID="lbldeawc24program" runat="server" Text="Dual Energy WC 24 Months"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtdeawc24sc" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="txtdeawc24day" runat="server" Text="0" Width="75px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtdeawc24night" runat="server" Text="0" Width="75px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtdeawc24ew" runat="server" Text="0" Width="75px"></asp:TextBox>
                        </td>

                        <td>
                            <asp:TextBox ID="txtdeawc24offpeak" runat="server" Text="0" Width="75px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtdeawc24other" runat="server" Text="0" Width="75px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtdeawc24uplift" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="2.0" step="0.1" AutoPostBack="true"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtdeawc24rate" runat="server" Text="0" Width="75px"></asp:TextBox>

                        </td>

                        <td>
                            <asp:CheckBox ID="chkdeawc24" runat="server" />
                        </td>
                        </td>
                                            <td>
                                                <asp:Button ID="btndeawc24show" runat="server" Text="Show" />
                                            </td>
                        <td>
                            <asp:Button ID="btndeawc24save" runat="server" Text="Save" /></td>



                        </tr>

                    </ContentTemplate>
                </asp:UpdatePanel>


                <asp:UpdatePanel ID="UpdatePanel32" runat="server">
                    <ContentTemplate>



                        <tr>



                            <td>
                                <asp:ImageButton ID="pe24supplier" runat="server" Height="39px" ImageUrl="~/images/positive.jpg" Width="175px" />
                            </td>
                            <td>
                                <asp:Label ID="lblpe24program" runat="server" Text="British Gas Lite new"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtpe24sc" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txtpe24day" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtpe24night" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtpe24ew" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <%-- <td>
                                <asp:TextBox ID="txtpe24wd" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>

                            <td>
                                <asp:TextBox ID="txtpe24unit" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>--%>
                            <td>
                                <asp:TextBox ID="txtpe24offpeak" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtpe24other" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtpe24uplift" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="3.0" step="0.1" AutoPostBack="true" OnTextChanged="txtpe24uplift_TextChanged"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtpe24rate" runat="server" Text="0" Width="75px"></asp:TextBox>

                            </td>

                            <td>
                                <asp:CheckBox ID="chkpe24" runat="server" />
                            </td>
                            <td>
                                <asp:Button ID="btnPE24" runat="server" Text="Show" OnClick="btnPE24_Click" />
                            </td>
                            <td>
                                <asp:Button ID="Button35" runat="server" Text="Save" /></td>





                        </tr>

                    </ContentTemplate>
                </asp:UpdatePanel>

                <asp:UpdatePanel ID="UpdatePanel35" runat="server">
                    <ContentTemplate>



                        <tr>



                            <td>
                                <asp:ImageButton ID="gaz24supplier" runat="server" Height="39px" ImageUrl="~/images/gaz.png" AlternateText="Gaz Prom " Width="175px" />
                            </td>
                            <td>
                                <asp:Label ID="lblgaz24program" runat="server" Text="Gaz  Energy"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtgaz24sc" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txtgaz24day" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtgaz24night" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtgaz24ew" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <%-- <td>
                                <asp:TextBox ID="txtgaz24wd" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>

                            <td>
                                <asp:TextBox ID="txtgaz24unit" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>--%>
                            <td>
                                <asp:TextBox ID="txtgaz24offpeak" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtgaz24other" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtgaz24uplift" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="2.0" step="0.1" AutoPostBack="true" OnTextChanged="txtgaz24uplift_TextChanged"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtgaz24rate" runat="server" Text="0" Width="75px"></asp:TextBox>

                            </td>

                            <td>
                                <asp:CheckBox ID="chkgaz24" runat="server" />
                            </td>
                            <td>
                                <asp:Button ID="btnGaz24" runat="server" Text="Show" OnClick="btnGaz24_Click" />
                            </td>
                            <td>
                                <asp:Button ID="Button37" runat="server" Text="Save" /></td>





                        </tr>

                    </ContentTemplate>
                </asp:UpdatePanel>


                <asp:UpdatePanel ID="UpdatePanel43" runat="server">


                    <ContentTemplate>

                        <tr>






                            <td>
                                <asp:ImageButton ID="sse24supplier" runat="server" Height="39px" ImageUrl="~/images/sse.jpg" AlternateText="sse energy" Width="175px" />
                            </td>
                            <td>
                                <asp:Label ID="lblsse24program" runat="server" Text="sse  Energy"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtsse24scamr" runat="server" Width="75px" Text="0"></asp:TextBox>
                                <asp:TextBox ID="txtsse24scnonamr" runat="server" Width="75px" Text="0"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtsse24day" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtsse24night" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtsse24ew" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <%-- <td>
                                                        <asp:TextBox ID="txtsse24wd" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                    </td>

                                                    <td>
                                                        <asp:TextBox ID="txtsse24unit" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                    </td>--%>
                            <td>
                                <asp:TextBox ID="txtsse24offpeak" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtsse24other" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtsse24uplift" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="2.0" step="0.1" AutoPostBack="true" OnTextChanged="txtsse24uplift_TextChanged"></asp:TextBox>
                                <asp:TextBox ID="txtsse24upliftnonamr" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="2.0" step="0.1" AutoPostBack="true" OnTextChanged="txtsse24upliftnonamr_TextChanged"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtsse24rate" runat="server" Text="0" Width="75px"></asp:TextBox>
                                <asp:TextBox ID="txtsse24ratenonamr" runat="server" Text="0" Width="75px"></asp:TextBox>

                            </td>

                            <td>
                                <asp:CheckBox ID="chksse24amr" runat="server" /><br />
                                <asp:CheckBox ID="chksse24nonamr" runat="server" />
                            </td>
                            </td>
                                                    <td>
                                                        <asp:Button ID="btnsse24amr" runat="server" Text="Show" />
                                                        <asp:Button ID="btnsse24nonamr" runat="server" Text="Show" />
                                                    </td>
                            <td>
                                <asp:Button ID="Button3" runat="server" Text="Save" />
                                <asp:Button ID="Button5" runat="server" Text="Save" />
                            </td>



                        </tr>

                    </ContentTemplate>
                </asp:UpdatePanel>




                <asp:UpdatePanel ID="UpdatePanel39" runat="server">
                    <ContentTemplate>



                        <tr>



                            <td>
                                <asp:ImageButton ID="npra24supplier" runat="server" Height="39px" ImageUrl="~/images/npower.jpg" AlternateText="N Power energy" Width="175px" />
                            </td>
                            <td>
                                <asp:Label ID="lblnpra24program" runat="server" Text="npra  Energy"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtnpra24sc" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txtnpra24day" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtnpra24night" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtnpra24ew" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <%-- <td>
                                <asp:TextBox ID="txtnpra24wd" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>

                            <td>
                                <asp:TextBox ID="txtnpra24unit" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>--%>
                            <td>
                                <asp:TextBox ID="txtnpra24offpeak" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtnpra24other" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtnpra24uplift" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="3.0" step="0.1" AutoPostBack="true" OnTextChanged="txtnpra24uplift_TextChanged"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtnpra24rate" runat="server" Text="0" Width="75px"></asp:TextBox>

                            </td>

                            <td>
                                <asp:CheckBox ID="chknpr24" runat="server" />
                            </td>
                            <td>
                                <asp:Button ID="btnnpr24" runat="server" Text="Show" OnClick="btnnpr24_Click" />
                            </td>
                            <td>
                                <asp:Button ID="Button39" runat="server" Text="Save" /></td>





                        </tr>

                    </ContentTemplate>
                </asp:UpdatePanel>

                <asp:UpdatePanel ID="UpdatePanel42" runat="server">
                    <ContentTemplate>



                        <tr>



                            <td>
                                <asp:ImageButton ID="spe24supplier" runat="server" Height="39px" ImageUrl="~/images/sp_logo.jpg" AlternateText="N Power energy" Width="175px" />
                            </td>
                            <td>
                                <asp:Label ID="lblspe24program" runat="server" Text="spe  Energy"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtspe24sc" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txtspe24day" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtspe24night" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtspe24ew" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <%-- <td>
                                <asp:TextBox ID="txtspe24wd" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>

                            <td>
                                <asp:TextBox ID="txtspe24unit" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>--%>
                            <td>
                                <asp:TextBox ID="txtspe24offpeak" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtspe24other" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtspe24uplift" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="2.0" step="0.1" AutoPostBack="true" OnTextChanged="txtspe24uplift_TextChanged"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtspe24rate" runat="server" Text="0" Width="75px"></asp:TextBox>

                            </td>

                            <td>
                                <asp:CheckBox ID="chkspe24" runat="server" />
                            </td>
                            <td>
                                <asp:Button ID="btnSpe24" runat="server" Text="Show" OnClick="btnSpe24_Click" />
                            </td>
                            <td>
                                <asp:Button ID="Button41" runat="server" Text="Save" /></td>




                        </tr>

                    </ContentTemplate>
                </asp:UpdatePanel>

                <asp:UpdatePanel ID="UpdatePanel46" runat="server">
                    <ContentTemplate>



                        <tr>



                            <td>
                                <asp:ImageButton ID="tgp24supplier" runat="server" Height="39px" ImageUrl="~/images/tglogo.png" Width="175px" />
                            </td>
                            <td>
                                <asp:Label ID="lbltgp24program" runat="server" Text="Total Energy"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txttgp24sc" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txttgp24day" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txttgp24night" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txttgp24ew" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <%--  <td>
                                <asp:TextBox ID="txttgp24wd" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>

                            <td>
                                <asp:TextBox ID="txttgp24unit" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>--%>
                            <td>
                                <asp:TextBox ID="txttgp24offpeak" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txttgp24other" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txttgp24uplift" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="3.0" step="0.1" AutoPostBack="true" OnTextChanged="txttgp24uplift_TextChanged"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txttgp24rate" runat="server" Text="0" Width="75px"></asp:TextBox>

                            </td>

                            <td>
                                <asp:CheckBox ID="chktgp24" runat="server" />
                            </td>
                            <td>
                                <asp:Button ID="btntgp24" runat="server" Text="Show" OnClick="btntgp24_Click" />
                            </td>
                            <td>
                                <asp:Button ID="Button43" runat="server" Text="Save" /></td>



                        </tr>

                    </ContentTemplate>
                </asp:UpdatePanel>

                <asp:UpdatePanel ID="UpdatePanel131" runat="server">
                    <ContentTemplate>







                        <td>
                            <asp:ImageButton ID="tgpw24supplier" runat="server" Height="39px" ImageUrl="~/images/tglogo.png" Width="175px" />
                        </td>
                        <td>
                            <asp:Label ID="lbltgpw24program" runat="server" Text="Total Energy"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txttgpw24sc" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="txttgpw24day" runat="server" Text="0" Width="75px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txttgpw24night" runat="server" Text="0" Width="75px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txttgpw24ew" runat="server" Text="0" Width="75px"></asp:TextBox>
                        </td>
                        <%-- <td>
                                                        <asp:TextBox ID="txttgpw24wd" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                    </td>

                                                    <td>
                                                        <asp:TextBox ID="txttgpw24unit" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                    </td>--%>
                        <td>
                            <asp:TextBox ID="txttgpw24offpeak" runat="server" Text="0" Width="75px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txttgpw24other" runat="server" Text="0" Width="75px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txttgpw24uplift" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="3.0" step="0.1" AutoPostBack="true"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txttgpw24rate" runat="server" Text="0" Width="75px"></asp:TextBox>

                        </td>
                        <td>
                            <asp:CheckBox ID="chktgpw24" runat="server" />
                        </td>
                        </td>
                             <td>
                                 <asp:Button ID="btntgpw24show" runat="server" Text="Show" />
                             </td>
                        <td>
                            <asp:Button ID="Button28" runat="server" Text="Save" /></td>





                        </tr>

                    </ContentTemplate>

                </asp:UpdatePanel>

                <asp:UpdatePanel ID="UpdatePanel102" runat="server">
                    <ContentTemplate>



                        <tr>



                            <td>
                                <asp:ImageButton ID="opus24supplier" runat="server" Height="39px" ImageUrl="~/images/opus.png" Width="175px" />
                            </td>
                            <td>
                                <asp:Label ID="lblopus24program" runat="server" Text="Opus Energy"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtopus24sc" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txtopus24day" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtopus24night" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>

                            <td>
                                <asp:TextBox ID="txtopus24ew" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <%--  <td>
                                <asp:TextBox ID="txtopus24wd" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>

                            <td>
                                <asp:TextBox ID="txtopus24unit" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>--%>
                            <td>
                                <asp:TextBox ID="txtopus24offpeak" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtopus24other" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtopus24uplift" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="1.0" step="0.1" AutoPostBack="true" OnTextChanged="txtopus24uplift_TextChanged"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtopus24rate" runat="server" Text="0" Width="75px"></asp:TextBox>

                            </td>
                            <td>
                                <asp:CheckBox ID="chkopus24" runat="server" />
                            </td>
                            <td>
                                <asp:Button ID="btnopus24Show" runat="server" Text="Show" />
                            </td>
                            <td>
                                <asp:Button ID="btnopus24Save" runat="server" Text="Save" /></td>




                        </tr>

                    </ContentTemplate>
                </asp:UpdatePanel>

                <asp:UpdatePanel ID="UpdatePanel106" runat="server">
                    <ContentTemplate>



                        <tr>



                            <td>
                                <asp:ImageButton ID="eon24supplier" runat="server" Height="39px" ImageUrl="~/images/eon.jpg" Width="175px" />
                            </td>
                            <td>
                                <asp:Label ID="lbleon24program" runat="server" Text="Eon  Energy"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txteon24sc" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txteon24day" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txteon24night" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>

                            <td>
                                <asp:TextBox ID="txteon24ew" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <%-- <td>
                                <asp:TextBox ID="txteon24wd" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>

                            <td>
                                <asp:TextBox ID="txteon24unit" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>--%>
                            <td>
                                <asp:TextBox ID="txteon24offpeak" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txteon24other" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <%--   <asp:TextBox ID="txteon24uplift" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="3.0" step="0.1" AutoPostBack="true"></asp:TextBox>--%>
                                <asp:DropDownList ID="ddeon24uplift" runat="server" Width="75px" AutoPostBack="true" OnSelectedIndexChanged="ddeon24uplift_SelectedIndexChanged">
                                    <asp:ListItem Selected="True">0.0</asp:ListItem>
                                    <asp:ListItem>0.1</asp:ListItem>
                                    <asp:ListItem>0.2</asp:ListItem>
                                    <asp:ListItem>0.3</asp:ListItem>
                                    <asp:ListItem>0.4</asp:ListItem>
                                    <asp:ListItem>0.5</asp:ListItem>
                                    <asp:ListItem>0.6</asp:ListItem>
                                    <asp:ListItem>0.7</asp:ListItem>
                                    <asp:ListItem>0.8</asp:ListItem>
                                    <asp:ListItem>0.9</asp:ListItem>
                                    <asp:ListItem>1.0</asp:ListItem>
                                    <asp:ListItem>1.2</asp:ListItem>
                                    <asp:ListItem>1.5</asp:ListItem>



                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:TextBox ID="txteon24rate" runat="server" Text="0" Width="75px"></asp:TextBox>

                            </td>
                            <td>
                                <asp:CheckBox ID="chkeon24" runat="server" />
                            </td>
                            <td>
                                <asp:Button ID="btneon24Show" runat="server" Text="Show" />
                            </td>
                            <td>
                                <asp:Button ID="btneon24Save" runat="server" Text="Save" /></td>




                        </tr>

                    </ContentTemplate>
                </asp:UpdatePanel>

                <asp:UpdatePanel ID="UpdatePanel118" runat="server">
                    <ContentTemplate>



                        <tr>



                            <td>
                                <asp:ImageButton ID="hev24supplier" runat="server" Height="39px" ImageUrl="~/images/hev.png" Width="175px" />
                            </td>
                            <td>
                                <asp:Label ID="lblhev24program" runat="server" Text="Heven Energy"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txthev24sc" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txthev24day" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txthev24night" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>

                            <td>
                                <asp:TextBox ID="txthev24ew" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <%-- <td>
                                                                <asp:TextBox ID="txthev24wd" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                            </td>

                                                            <td>
                                                                <asp:TextBox ID="txthev24unit" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                            </td>--%>
                            <td>
                                <asp:TextBox ID="txthev24offpeak" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txthev24other" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txthev24uplift" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="1.0" step="0.1" AutoPostBack="true"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txthev24rate" runat="server" Text="0" Width="75px"></asp:TextBox>

                            </td>
                            <td>
                                <asp:CheckBox ID="chkhev24" runat="server" />
                            </td>
                            <td>
                                <asp:Button ID="btnhev24Show" runat="server" Text="Show" />
                            </td>
                            <td>
                                <asp:Button ID="btnhev24Save" runat="server" Text="Save" /></td>




                        </tr>

                    </ContentTemplate>
                </asp:UpdatePanel>

                <asp:UpdatePanel ID="UpdatePanel136" runat="server">
                    <ContentTemplate>



                        <tr>



                            <td>
                                <asp:ImageButton ID="hevc24supplier" runat="server" Height="39px" ImageUrl="~/images/hev.png" Width="175px" />
                            </td>
                            <td>
                                <asp:Label ID="lblhevc24program" runat="server" Text="heven  Energy Complete"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txthevc24sc" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txthevc24day" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txthevc24night" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>

                            <td>
                                <asp:TextBox ID="txthevc24ew" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <%-- <td>
                                                                <asp:TextBox ID="txthevc24wd" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                            </td>

                                                            <td>
                                                                <asp:TextBox ID="txthevc24unit" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                            </td>--%>
                            <td>
                                <asp:TextBox ID="txthevc24offpeak" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txthevc24other" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txthevc24uplift" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="1.0" step="0.1" AutoPostBack="true"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txthevc24rate" runat="server" Text="0" Width="75px"></asp:TextBox>

                            </td>
                            <td>
                                <asp:CheckBox ID="chkhevc24" runat="server" />
                            </td>
                            <td>
                                <asp:Button ID="btnhevc24Show" runat="server" Text="Show" />
                            </td>
                            <td>
                                <asp:Button ID="btnhevc24Save" runat="server" Text="Save" /></td>




                        </tr>

                    </ContentTemplate>
                </asp:UpdatePanel>



                                <asp:UpdatePanel ID="UpdatePanel153" runat="server">
                                    <ContentTemplate>







                                        <td>
                                            <asp:ImageButton ID="utila24supplier" runat="server" Height="39px" ImageUrl="~/images/utilita.png" Width="175px" />
                                        </td>
                                        <td>
                                            <asp:Label ID="lblutila24program" runat="server" Text="Utilita Energy new"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtutila24sc" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="txtutila24day" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtutila24night" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtutila24ew" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <%-- <td>
                                            <asp:TextBox ID="txtutila24wd" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>

                                        <td>
                                            <asp:TextBox ID="txtutila24unit" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>--%>
                                        <td>
                                            <asp:TextBox ID="txtutila24offpeak" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtutila24other" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtutila24uplift" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="1.5" step="0.1" AutoPostBack="true" ></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtutil24Rate" runat="server" Text="0" Width="75px"></asp:TextBox>

                                        </td>

                                        <td>
                                            <asp:CheckBox ID="chkutil24" runat="server" />
                                        </td>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnutil24" runat="server" Text="Show" OnClick="btnutil24Show_Click" />
                                        </td>
                                        <td>
                                            <asp:Button ID="Button48" runat="server" Text="Save" /></td>



                                        </tr>

                                    </ContentTemplate>
                                </asp:UpdatePanel>
								
								
								 <asp:UpdatePanel ID="UpdatePanel154" runat="server">
                                    <ContentTemplate>







                                        <td>
                                            <asp:ImageButton ID="gulfa24supplier" runat="server" Height="39px" ImageUrl="~/images/gulf.png" Width="175px" />
                                        </td>
                                        <td>
                                            <asp:Label ID="lblgulfa24program" runat="server" Text="Gulf  Energy"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtgulfa24sc" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="txtgulfa24day" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtgulfa24night" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtgulfa24ew" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <%-- <td>
                                            <asp:TextBox ID="txtgulfa24wd" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>

                                        <td>
                                            <asp:TextBox ID="txtgulfa24unit" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>--%>
                                        <td>
                                            <asp:TextBox ID="txtgulfa24offpeak" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtgulfa24other" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtgulfa24uplift" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="1.5" step="0.1" AutoPostBack="true"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtgulf24Rate" runat="server" Text="0" Width="75px"></asp:TextBox>

                                        </td>

                                        <td>
                                            <asp:CheckBox ID="chkgulf24" runat="server" />
                                        </td>
                                        </td>
                                        <td>
                                            <asp:Button ID="btngulf24" runat="server" Text="Show" OnClick="btngulf24Show_Click" />
                                        </td>
                                        <td>
                                            <asp:Button ID="Button50" runat="server" Text="Save" /></td>



                                        </tr>

                                    </ContentTemplate>
                                </asp:UpdatePanel>
								
								  <asp:UpdatePanel ID="UpdatePanel155" runat="server">
                                    <ContentTemplate>

                                        <td>
                                            <asp:ImageButton ID="yuea24supplier" runat="server" Height="39px" ImageUrl="~/images/yue.jpg" Width="175px" />
                                        </td>
                                        <td>
                                            <asp:Label ID="lblyuea24program" runat="server" Text="YU Energy"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtyuea24sc" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="txtyuea24day" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtyuea24night" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtyuea24ew" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <%-- <td>
                                            <asp:TextBox ID="txtyuea24wd" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>

                                        <td>
                                            <asp:TextBox ID="txtyuea24unit" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>--%>
                                        <td>
                                            <asp:TextBox ID="txtyuea24offpeak" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtyuea24other" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtyuea24uplift" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="1.5" step="0.1" AutoPostBack="true" ></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtyue24Rate" runat="server" Text="0" Width="75px"></asp:TextBox>

                                        </td>

                                        <td>
                                            <asp:CheckBox ID="chkyue24" runat="server" />
                                        </td>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnyue24" runat="server" Text="Show" OnClick="btnyue24Show_Click" />
                                        </td>
                                        <td>
                                            <asp:Button ID="Button52" runat="server" Text="Save" /></td>



                                        </tr>

                                    </ContentTemplate>
                                </asp:UpdatePanel>





            </table>




        </asp:View>



        <asp:View ID="View36" runat="server">
            <table class="table table-bordered table-dark">
                <tr>
                    <td>Supplier Name</td>
                    <td>Program Name</td>
                    <td>Standing&nbsp; charge</td>
                    <td>Day Unit Charge</td>
                    <td>Night Unit Charge</td>
                    <td>EVENING WEEKEND UNIT CHARGE</td>
                    <%--<td>WEEKDAY DAY UNIT CHARGE</td>

                    <td>UNIT Charge</td>--%>
                    <td>OFF PEAK UNIT CHARGE</td>
                    <td>Other Charges </td>
                    <td>Uplift</td>
                    <td>Yearly Charge</td>





                    <td>Mail</td>
                    <td>Show </td>
                    <td>Save</td>





                </tr>
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>



                        <tr>



                            <td>
                                <asp:ImageButton ID="bga36supplier" runat="server" Height="39px" ImageUrl="~/britishgas.jpg" Width="175px" />
                            </td>
                            <td>
                                <asp:Label ID="lblBga36program" runat="server" Text="British Gas new"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbga36sc" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txtbga36day" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbga36night" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbga36ew" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <%-- <td>
                                <asp:TextBox ID="txtbga36wd" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>

                            <td>
                                <asp:TextBox ID="txtbga36unit" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>--%>
                            <td>
                                <asp:TextBox ID="txtbga36offpeak" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbga36other" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbga36uplift" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="2.0" step="0.1" AutoPostBack="true" OnTextChanged="txtbga36uplift_TextChanged"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbga36rate" runat="server" Text="0" Width="75px"></asp:TextBox>

                            </td>
                            <td>
                                <asp:CheckBox ID="chkbga36" runat="server" />
                            </td>
                            <td>
                                <asp:Button ID="btnbga36" runat="server" Text="Show" OnClick="btnbga36_Click" />
                            </td>
                            <td>
                                <asp:Button ID="Button45" runat="server" Text="Save" /></td>




                        </tr>

                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                    <ContentTemplate>



                        <tr>



                            <td>
                                <asp:ImageButton ID="bge36supplier" runat="server" Height="39px" ImageUrl="~/britishgas.jpg" Width="175px" />
                            </td>
                            <td>
                                <asp:Label ID="lblBge36program" runat="server" Text="British Gas Re new "></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbge36sc" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txtbge36day" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbge36night" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbge36ew" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <%-- <td>
                                <asp:TextBox ID="txtbge36wd" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>

                            <td>
                                <asp:TextBox ID="txtbge36unit" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>--%>
                            <td>
                                <asp:TextBox ID="txtbge36offpeak" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbge36other" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbge36uplift" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="2.0" step="0.1" AutoPostBack="true" OnTextChanged="txtbge36uplift_TextChanged"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbfge36rate" runat="server" Text="0" Width="75px"></asp:TextBox>

                            </td>
                            <td>
                                <asp:CheckBox ID="chkbge36" runat="server" />
                            </td>
                            <td>
                                <asp:Button ID="btnbge36" runat="server" Text="Show" OnClick="btnbge36_Click" />
                            </td>
                            <td>
                                <asp:Button ID="Button47" runat="server" Text="Save" /></td>




                        </tr>

                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                    <ContentTemplate>



                        <tr>



                            <td>
                                <asp:ImageButton ID="bgl36supplier" runat="server" Height="39px" ImageUrl="~/images/bgl.png" Width="175px" />
                            </td>
                            <td>
                                <asp:Label ID="lblbgla36program" runat="server" Text="British Gas Lite new"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbgla36sc" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txtbgla36day" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbgla36night" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbgla36ew" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <%-- <td>
                                <asp:TextBox ID="txtbgla36wd" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>

                            <td>
                                <asp:TextBox ID="txtbgla36unit" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>--%>
                            <td>
                                <asp:TextBox ID="txtbgla36offpeak" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbgla36other" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbgla36uplift" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="1.5" step="0.1" AutoPostBack="true" OnTextChanged="txtbgla36uplift_TextChanged"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbfgla36rate" runat="server" Text="0" Width="75px"></asp:TextBox>

                            </td>


                            <td>
                                <asp:CheckBox ID="chkbgla36" runat="server" />
                            </td>
                            <td>
                                <asp:Button ID="btnbgla36" runat="server" Text="Show" OnClick="btnbgla36_Click" />
                            </td>
                            <td>
                                <asp:Button ID="Button49" runat="server" Text="Save" /></td>


                        </tr>

                    </ContentTemplate>
                </asp:UpdatePanel>

                <asp:UpdatePanel ID="UpdatePanel18" runat="server">
                    <ContentTemplate>



                        <tr>



                            <td>
                                <asp:ImageButton ID="bgle36supplier" runat="server" Height="39px" ImageUrl="~/images/bgl.png" Width="175px" />
                            </td>
                            <td>
                                <asp:Label ID="lblbgle36program" runat="server" Text="British Gas Lite new"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbgle36sc" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txtbgle36day" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbgle36night" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbgle36ew" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <%--  <td>
                                <asp:TextBox ID="txtbgle36wd" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>

                            <td>
                                <asp:TextBox ID="txtbgle36unit" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>--%>
                            <td>
                                <asp:TextBox ID="txtbgle36offpeak" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbgle36other" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbgle36uplift" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="1.5" step="0.1" AutoPostBack="true" OnTextChanged="txtbgle36uplift_TextChanged"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbgle36rate" runat="server" Text="0" Width="75px"></asp:TextBox>

                            </td>


                            <td>
                                <asp:CheckBox ID="chkbgle36" runat="server" />
                            </td>
                            <td>
                                <asp:Button ID="btnbgle36" runat="server" Text="Show" OnClick="btnbgle36_Click" />
                            </td>
                            <td>
                                <asp:Button ID="Button51" runat="server" Text="Save" /></td>


                        </tr>

                    </ContentTemplate>
                </asp:UpdatePanel>

                <asp:UpdatePanel ID="UpdatePanel23" runat="server">
                    <ContentTemplate>



                        <tr>



                            <td>
                                <asp:ImageButton ID="edfa36supplier" runat="server" Height="39px" ImageUrl="~/images/edf.jpg" Width="175px" />
                            </td>
                            <td>
                                <asp:Label ID="lbledfa36program" runat="server" Text="British Gas Lite new"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtedfa36sc" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txtedfa36day" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtedfa36night" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtedfa36ew" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <%-- <td>
                                <asp:TextBox ID="txtedfa36wd" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>

                            <td>
                                <asp:TextBox ID="txtedfa36unit" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>--%>
                            <td>
                                <asp:TextBox ID="txtedfa36offpeak" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtedfa36other" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtedfa36uplift" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="1.5" step="0.1" AutoPostBack="true" OnTextChanged="txtedfa36uplift_TextChanged"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtEdf36Rate" runat="server" Text="0" Width="75px"></asp:TextBox>

                            </td>

                            <td>
                                <asp:CheckBox ID="chkedf36" runat="server" />
                            </td>
                            <td>
                                <asp:Button ID="btnedf36" runat="server" Text="Show" OnClick="btnedf36_Click" />
                            </td>
                            <td>
                                <asp:Button ID="Button53" runat="server" Text="Save" /></td>



                        </tr>

                    </ContentTemplate>
                </asp:UpdatePanel>

                <asp:UpdatePanel ID="UpdatePanel28" runat="server">
                    <ContentTemplate>



                        <tr>



                            <td>
                                <asp:ImageButton ID="dea36supplier" runat="server" Height="39px" ImageUrl="~/images/de.jpg" Width="175px" />
                            </td>
                            <td>
                                <asp:Label ID="lbldea36program" runat="server" Text="British Gas Lite new"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtdea36sc" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txtdea36day" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtdea36night" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtdea36ew" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <%-- <td>
                                <asp:TextBox ID="txtdea36wd" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>

                            <td>
                                <asp:TextBox ID="txtdea36unit" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>--%>
                            <td>
                                <asp:TextBox ID="txtdea36offpeak" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtdea36other" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtdea36uplift" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="2.0" step="0.1" AutoPostBack="true" OnTextChanged="txtdea36uplift_TextChanged"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtde36rate" runat="server" Text="0" Width="75px"></asp:TextBox>

                            </td>


                            <td>
                                <asp:CheckBox ID="chkde36" runat="server" />
                            </td>
                            <td>
                                <asp:Button ID="btnde36" runat="server" Text="Show" OnClick="btnde36_Click" />
                            </td>
                            <td>
                                <asp:Button ID="Button55" runat="server" Text="Save" /></td>


                        </tr>

                    </ContentTemplate>
                </asp:UpdatePanel>


                <asp:UpdatePanel ID="UpdatePanel142" runat="server">
                    <ContentTemplate>







                        <td>
                            <asp:ImageButton ID="deawc36supplier" runat="server" Height="39px" ImageUrl="~/images/de.jpg" Width="175px" />
                        </td>
                        <td>
                            <asp:Label ID="lbldeawc36program" runat="server" Text="Dual Energy WC 36 Months"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtdeawc36sc" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="txtdeawc36day" runat="server" Text="0" Width="75px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtdeawc36night" runat="server" Text="0" Width="75px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtdeawc36ew" runat="server" Text="0" Width="75px"></asp:TextBox>
                        </td>
                        <%-- <td>
                                                <asp:TextBox ID="txtdeawc36wd" runat="server" Text="0" Width="75px"></asp:TextBox>
                                            </td>

                                            <td>
                                                <asp:TextBox ID="txtdeawc36unit" runat="server" Text="0" Width="75px"></asp:TextBox>
                                            </td>--%>
                        <td>
                            <asp:TextBox ID="txtdeawc36offpeak" runat="server" Text="0" Width="75px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtdeawc36other" runat="server" Text="0" Width="75px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtdeawc36uplift" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="2.0" step="0.1" AutoPostBack="true"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtdeawc36rate" runat="server" Text="0" Width="75px"></asp:TextBox>

                        </td>

                        <td>
                            <asp:CheckBox ID="chkdeawc36" runat="server" />
                        </td>
                        </td>
                                            <td>
                                                <asp:Button ID="btndeawc36show" runat="server" Text="Show" />
                                            </td>
                        <td>
                            <asp:Button ID="btndeawc36save" runat="server" Text="Save" /></td>



                        </tr>

                    </ContentTemplate>
                </asp:UpdatePanel>


                <asp:UpdatePanel ID="UpdatePanel33" runat="server">
                    <ContentTemplate>



                        <tr>



                            <td>
                                <asp:ImageButton ID="pe36supplier" runat="server" Height="39px" ImageUrl="~/images/positive.jpg" Width="175px" />
                            </td>
                            <td>
                                <asp:Label ID="lblpe36program" runat="server" Text="British Gas Lite new"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtpe36sc" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txtpe36day" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtpe36night" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtpe36ew" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <%-- <td>
                                <asp:TextBox ID="txtpe36wd" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>

                            <td>
                                <asp:TextBox ID="txtpe36unit" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>--%>
                            <td>
                                <asp:TextBox ID="txtpe36offpeak" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtpe36other" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtpe36uplift" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="3.0" step="0.1" AutoPostBack="true" OnTextChanged="txtpe36uplift_TextChanged"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtpe36rate" runat="server" Text="0" Width="75px"></asp:TextBox>

                            </td>


                            <td>
                                <asp:CheckBox ID="chkpe36" runat="server" />
                            </td>
                            <td>
                                <asp:Button ID="btnpe36" runat="server" Text="Show" OnClick="btnpe36_Click" />
                            </td>
                            <td>
                                <asp:Button ID="Button57" runat="server" Text="Save" /></td>


                        </tr>

                    </ContentTemplate>
                </asp:UpdatePanel>

                <asp:UpdatePanel ID="UpdatePanel36" runat="server">
                    <ContentTemplate>



                        <tr>



                            <td>
                                <asp:ImageButton ID="gaz36supplier" runat="server" Height="39px" ImageUrl="~/images/gaz.png" AlternateText="Gaz Prom " Width="175px" />
                            </td>
                            <td>
                                <asp:Label ID="lblgaz36program" runat="server" Text="Gaz  Energy"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtgaz36sc" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txtgaz36day" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtgaz36night" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtgaz36ew" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <%-- <td>
                                <asp:TextBox ID="txtgaz36wd" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>

                            <td>
                                <asp:TextBox ID="txtgaz36unit" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>--%>
                            <td>
                                <asp:TextBox ID="txtgaz36offpeak" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtgaz36other" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtgaz36uplift" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="2.0" step="0.1" AutoPostBack="true" OnTextChanged="txtgaz36uplift_TextChanged"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtgaz36rate" runat="server" Text="0" Width="75px"></asp:TextBox>

                            </td>

                            <td>
                                <asp:CheckBox ID="chkgaz36" runat="server" />
                            </td>
                            <td>
                                <asp:Button ID="btngaz36" runat="server" Text="Show" OnClick="btngaz36_Click" />
                            </td>
                            <td>
                                <asp:Button ID="Button59" runat="server" Text="Save" /></td>



                        </tr>

                    </ContentTemplate>
                </asp:UpdatePanel>

                <asp:UpdatePanel ID="UpdatePanel70" runat="server">
                    <ContentTemplate>
                        <tr>







                            <td>
                                <asp:ImageButton ID="sse36supplier" runat="server" Height="39px" ImageUrl="~/images/sse.jpg" AlternateText="sse energy" Width="175px" />
                            </td>
                            <td>
                                <asp:Label ID="lblsse36program" runat="server" Text="sse  Energy"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtsse36scamr" runat="server" Width="75px" Text="0"></asp:TextBox>
                                <asp:TextBox ID="txtsse36scnonamr" runat="server" Width="75px" Text="0"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtsse36day" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtsse36night" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtsse36ew" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <%-- <td>
                                                        <asp:TextBox ID="txtsse36wd" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                    </td>

                                                    <td>
                                                        <asp:TextBox ID="txtsse36unit" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                    </td>--%>
                            <td>
                                <asp:TextBox ID="txtsse36offpeak" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtsse36other" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtsse36uplift" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="2.0" step="0.1" AutoPostBack="true" OnTextChanged="txtsse36uplift_TextChanged"></asp:TextBox>
                                <asp:TextBox ID="txtsse36upliftnonamr" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="2.0" step="0.1" AutoPostBack="true" OnTextChanged="txtsse36upliftnonamr_TextChanged"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtsse36rate" runat="server" Text="0" Width="75px"></asp:TextBox>
                                <asp:TextBox ID="txtsse36ratenonamr" runat="server" Text="0" Width="75px"></asp:TextBox>

                            </td>

                            <td>
                                <asp:CheckBox ID="chksse36amr" runat="server" /><br />
                                <asp:CheckBox ID="chksse36nonamr" runat="server" />
                            </td>
                            </td>
                                                    <td>
                                                        <asp:Button ID="btnsse36amr" runat="server" Text="Show" />
                                                        <asp:Button ID="btnsse36nonamr" runat="server" Text="Show" />
                                                    </td>
                            <td>
                                <asp:Button ID="Button6" runat="server" Text="Save" />
                                <asp:Button ID="Button7" runat="server" Text="Save" />
                            </td>



                        </tr>

                    </ContentTemplate>

                </asp:UpdatePanel>




                <asp:UpdatePanel ID="UpdatePanel40" runat="server">
                    <ContentTemplate>



                        <tr>



                            <td>
                                <asp:ImageButton ID="npra36supplier" runat="server" Height="39px" ImageUrl="~/images/npower.jpg" AlternateText="N Power energy" Width="175px" />
                            </td>
                            <td>
                                <asp:Label ID="lblnpra36program" runat="server" Text="npra  Energy"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtnpra36sc" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txtnpra36day" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtnpra36night" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtnpra36ew" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <%--<td>
                                <asp:TextBox ID="txtnpra36wd" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>

                            <td>
                                <asp:TextBox ID="txtnpra36unit" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>--%>
                            <td>
                                <asp:TextBox ID="txtnpra36offpeak" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtnpra36other" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtnpra36uplift" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="3.0" step="0.1" AutoPostBack="true" OnTextChanged="txtnpra36uplift_TextChanged"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtnpra36rate" runat="server" Text="0" Width="75px"></asp:TextBox>

                            </td>

                            <td>
                                <asp:CheckBox ID="chknpr36" runat="server" />
                            </td>
                            <td>
                                <asp:Button ID="btnnpr36" runat="server" Text="Show" OnClick="btnnpr36_Click" />
                            </td>
                            <td>
                                <asp:Button ID="Button61" runat="server" Text="Save" /></td>



                        </tr>

                    </ContentTemplate>
                </asp:UpdatePanel>

                <asp:UpdatePanel ID="UpdatePanel44" runat="server">
                    <ContentTemplate>



                        <tr>



                            <td>
                                <asp:ImageButton ID="spe36supplier" runat="server" Height="39px" ImageUrl="~/images/sp_logo.jpg" AlternateText="N Power energy" Width="175px" />
                            </td>
                            <td>
                                <asp:Label ID="lblspe36program" runat="server" Text="spe  Energy"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtspe36sc" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txtspe36day" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtspe36night" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtspe36ew" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <%--  <td>
                                <asp:TextBox ID="txtspe36wd" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>

                            <td>
                                <asp:TextBox ID="txtspe36unit" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>--%>
                            <td>
                                <asp:TextBox ID="txtspe36offpeak" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtspe36other" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtspe36uplift" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="2.0" step="0.1" AutoPostBack="true" OnTextChanged="txtspe36uplift_TextChanged"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtspe36rate" runat="server" Text="0" Width="75px"></asp:TextBox>

                            </td>


                            <td>
                                <asp:CheckBox ID="chkspe36" runat="server" />
                            </td>
                            <td>
                                <asp:Button ID="btnspe36" runat="server" Text="Show" OnClick="btnspe36_Click" />
                            </td>
                            <td>
                                <asp:Button ID="Button63" runat="server" Text="Save" /></td>


                        </tr>

                    </ContentTemplate>
                </asp:UpdatePanel>

                <asp:UpdatePanel ID="UpdatePanel47" runat="server">
                    <ContentTemplate>



                        <tr>



                            <td>
                                <asp:ImageButton ID="tgp36supplier" runat="server" Height="39px" ImageUrl="~/images/tglogo.png" Width="175px" />
                            </td>
                            <td>
                                <asp:Label ID="lbltgp36program" runat="server" Text="Total Energy"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txttgp36sc" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txttgp36day" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txttgp36night" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txttgp36ew" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <%--<td>
                                <asp:TextBox ID="txttgp36wd" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>

                            <td>
                                <asp:TextBox ID="txttgp36unit" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>--%>
                            <td>
                                <asp:TextBox ID="txttgp36offpeak" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txttgp36other" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txttgp36uplift" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="3.0" step="0.1" AutoPostBack="true" OnTextChanged="txttgp36uplift_TextChanged"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txttgp36rate" runat="server" Text="0" Width="75px"></asp:TextBox>

                            </td>

                            <td>
                                <asp:CheckBox ID="chktgp36" runat="server" />
                            </td>
                            <td>
                                <asp:Button ID="btntgp36" runat="server" Text="Show" OnClick="btntgp36_Click" />
                            </td>
                            <td>
                                <asp:Button ID="Button65" runat="server" Text="Save" /></td>



                        </tr>

                    </ContentTemplate>
                </asp:UpdatePanel>

                <asp:UpdatePanel ID="UpdatePanel132" runat="server">
                    <ContentTemplate>







                        <td>
                            <asp:ImageButton ID="tgpw36supplier" runat="server" Height="39px" ImageUrl="~/images/tglogo.png" Width="175px" />
                        </td>
                        <td>
                            <asp:Label ID="lbltgpw36program" runat="server" Text="Total energy"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txttgpw36sc" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="txttgpw36day" runat="server" Text="0" Width="75px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txttgpw36night" runat="server" Text="0" Width="75px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txttgpw36ew" runat="server" Text="0" Width="75px"></asp:TextBox>
                        </td>
                        <%-- <td>
                                                        <asp:TextBox ID="txttgpw36wd" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                    </td>

                                                    <td>
                                                        <asp:TextBox ID="txttgpw36unit" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                    </td>--%>
                        <td>
                            <asp:TextBox ID="txttgpw36offpeak" runat="server" Text="0" Width="75px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txttgpw36other" runat="server" Text="0" Width="75px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txttgpw36uplift" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="3.0" step="0.1" AutoPostBack="true"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txttgpw36rate" runat="server" Text="0" Width="75px"></asp:TextBox>

                        </td>
                        <td>
                            <asp:CheckBox ID="chktgpw36" runat="server" />
                        </td>
                        </td>
                             <td>
                                 <asp:Button ID="Button30" runat="server" Text="Show" />
                             </td>
                        <td>
                            <asp:Button ID="Button32" runat="server" Text="Save" /></td>





                        </tr>

                    </ContentTemplate>

                </asp:UpdatePanel>

                <asp:UpdatePanel ID="UpdatePanel103" runat="server">
                    <ContentTemplate>



                        <tr>



                            <td>
                                <asp:ImageButton ID="opus36supplier" runat="server" Height="39px" ImageUrl="~/images/opus.png" Width="175px" />
                            </td>
                            <td>
                                <asp:Label ID="lblopus36program" runat="server" Text="Opus Energy"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtopus36sc" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txtopus36day" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtopus36night" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>

                            <td>
                                <asp:TextBox ID="txtopus36ew" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <%-- <td>
                                <asp:TextBox ID="txtopus36wd" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>

                            <td>
                                <asp:TextBox ID="txtopus36unit" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>--%>
                            <td>
                                <asp:TextBox ID="txtopus36offpeak" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtopus36other" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtopus36uplift" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="1.0" step="0.1" AutoPostBack="true" OnTextChanged="txtopus36uplift_TextChanged"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtopus36rate" runat="server" Text="0" Width="75px"></asp:TextBox>

                            </td>
                            <td>
                                <asp:CheckBox ID="chkopus36" runat="server" />
                            </td>
                            <td>
                                <asp:Button ID="btnopus36Show" runat="server" Text="Show" />
                            </td>
                            <td>
                                <asp:Button ID="btnopus36Save" runat="server" Text="Save" /></td>




                        </tr>

                    </ContentTemplate>
                </asp:UpdatePanel>

                <asp:UpdatePanel ID="UpdatePanel107" runat="server">
                    <ContentTemplate>



                        <tr>



                            <td>
                                <asp:ImageButton ID="eon36supplier" runat="server" Height="39px" ImageUrl="~/images/eon.jpg" Width="175px" />
                            </td>
                            <td>
                                <asp:Label ID="lbleon36program" runat="server" Text="EON  energy"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txteon36sc" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txteon36day" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txteon36night" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>

                            <td>
                                <asp:TextBox ID="txteon36ew" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <%-- <td>
                                <asp:TextBox ID="txteon36wd" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>

                            <td>
                                <asp:TextBox ID="txteon36unit" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>--%>
                            <td>
                                <asp:TextBox ID="txteon36offpeak" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txteon36other" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <%-- <asp:TextBox ID="txteon36uplift" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="3.0" step="0.1" AutoPostBack="true"></asp:TextBox>--%>
                                <asp:DropDownList ID="ddeon36uplift" runat="server" Width="75px" AutoPostBack="true" OnSelectedIndexChanged="ddeon36uplift_SelectedIndexChanged">
                                    <asp:ListItem Selected="True">0.0</asp:ListItem>
                                    <asp:ListItem>0.1</asp:ListItem>
                                    <asp:ListItem>0.2</asp:ListItem>
                                    <asp:ListItem>0.3</asp:ListItem>
                                    <asp:ListItem>0.4</asp:ListItem>
                                    <asp:ListItem>0.5</asp:ListItem>
                                    <asp:ListItem>0.6</asp:ListItem>
                                    <asp:ListItem>0.7</asp:ListItem>
                                    <asp:ListItem>0.8</asp:ListItem>
                                    <asp:ListItem>0.9</asp:ListItem>
                                    <asp:ListItem>1.0</asp:ListItem>
                                    <asp:ListItem>1.2</asp:ListItem>
                                    <asp:ListItem>1.5</asp:ListItem>



                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:TextBox ID="txteon36rate" runat="server" Text="0" Width="75px"></asp:TextBox>

                            </td>
                            <td>
                                <asp:CheckBox ID="chkeon36" runat="server" />
                            </td>
                            <td>
                                <asp:Button ID="btneon36Show" runat="server" Text="Show" />
                            </td>
                            <td>
                                <asp:Button ID="btneon36Save" runat="server" Text="Save" /></td>




                        </tr>

                    </ContentTemplate>
                </asp:UpdatePanel>

                <asp:UpdatePanel ID="UpdatePanel119" runat="server">
                    <ContentTemplate>



                        <tr>



                            <td>
                                <asp:ImageButton ID="hev36supplier" runat="server" Height="39px" ImageUrl="~/images/hev.png" Width="175px" />
                            </td>
                            <td>
                                <asp:Label ID="lblhev36program" runat="server" Text="Heven Energy"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txthev36sc" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txthev36day" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txthev36night" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>

                            <td>
                                <asp:TextBox ID="txthev36ew" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <%-- <td>
                                                                <asp:TextBox ID="txthev36wd" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                            </td>

                                                            <td>
                                                                <asp:TextBox ID="txthev36unit" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                            </td>--%>
                            <td>
                                <asp:TextBox ID="txthev36offpeak" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txthev36other" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txthev36uplift" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="1.0" step="0.1" AutoPostBack="true"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txthev36rate" runat="server" Text="0" Width="75px"></asp:TextBox>

                            </td>
                            <td>
                                <asp:CheckBox ID="chkhev36" runat="server" />
                            </td>
                            <td>
                                <asp:Button ID="btnhev36Show" runat="server" Text="Show" />
                            </td>
                            <td>
                                <asp:Button ID="btnhev36Save" runat="server" Text="Save" /></td>




                        </tr>

                    </ContentTemplate>
                </asp:UpdatePanel>

                <asp:UpdatePanel ID="UpdatePanel137" runat="server">
                    <ContentTemplate>



                        <tr>



                            <td>
                                <asp:ImageButton ID="hevc36supplier" runat="server" Height="39px" ImageUrl="~/images/hev.png" Width="175px" />
                            </td>
                            <td>
                                <asp:Label ID="lblhevc36program" runat="server" Text="heven  Energy Complete"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txthevc36sc" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txthevc36day" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txthevc36night" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>

                            <td>
                                <asp:TextBox ID="txthevc36ew" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>

                            <td>
                                <asp:TextBox ID="txthevc36offpeak" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txthevc36other" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txthevc36uplift" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="1.0" step="0.1" AutoPostBack="true"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txthevc36rate" runat="server" Text="0" Width="75px"></asp:TextBox>

                            </td>
                            <td>
                                <asp:CheckBox ID="chkhevc36" runat="server" />
                            </td>
                            <td>
                                <asp:Button ID="btnhevc36Show" runat="server" Text="Show" />
                            </td>
                            <td>
                                <asp:Button ID="btnhevc36Save" runat="server" Text="Save" /></td>




                        </tr>

                    </ContentTemplate>
                </asp:UpdatePanel>



                                <asp:UpdatePanel ID="UpdatePanel156" runat="server">
                                    <ContentTemplate>







                                        <td>
                                            <asp:ImageButton ID="utila36supplier" runat="server" Height="39px" ImageUrl="~/images/utilita.png" Width="175px" />
                                        </td>
                                        <td>
                                            <asp:Label ID="lblutila36program" runat="server" Text="Utilita Energy new"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtutila36sc" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="txtutila36day" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtutila36night" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtutila36ew" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <%-- <td>
                                            <asp:TextBox ID="txtutila36wd" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>

                                        <td>
                                            <asp:TextBox ID="txtutila36unit" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>--%>
                                        <td>
                                            <asp:TextBox ID="txtutila36offpeak" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtutila36other" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtutila36uplift" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="1.5" step="0.1" AutoPostBack="true" ></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtutil36Rate" runat="server" Text="0" Width="75px"></asp:TextBox>

                                        </td>

                                        <td>
                                            <asp:CheckBox ID="chkutil36" runat="server" />
                                        </td>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnutil36" runat="server" Text="Show" OnClick="btnutil36Show_Click" />
                                        </td>
                                        <td>
                                            <asp:Button ID="Button54" runat="server" Text="Save" /></td>



                                        </tr>

                                    </ContentTemplate>
                                </asp:UpdatePanel>
								
								
								 <asp:UpdatePanel ID="UpdatePanel157" runat="server">
                                    <ContentTemplate>







                                        <td>
                                            <asp:ImageButton ID="gulfa36supplier" runat="server" Height="39px" ImageUrl="~/images/gulf.png" Width="175px" />
                                        </td>
                                        <td>
                                            <asp:Label ID="lblgulfa36program" runat="server" Text="Gulf  Energy"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtgulfa36sc" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="txtgulfa36day" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtgulfa36night" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtgulfa36ew" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <%-- <td>
                                            <asp:TextBox ID="txtgulfa36wd" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>

                                        <td>
                                            <asp:TextBox ID="txtgulfa36unit" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>--%>
                                        <td>
                                            <asp:TextBox ID="txtgulfa36offpeak" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtgulfa36other" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtgulfa36uplift" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="1.5" step="0.1" AutoPostBack="true"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtgulf36Rate" runat="server" Text="0" Width="75px"></asp:TextBox>

                                        </td>

                                        <td>
                                            <asp:CheckBox ID="chkgulf36" runat="server" />
                                        </td>
                                        </td>
                                        <td>
                                            <asp:Button ID="btngulf36" runat="server" Text="Show" OnClick="btngulf36Show_Click" />
                                        </td>
                                        <td>
                                            <asp:Button ID="Button56" runat="server" Text="Save" /></td>



                                        </tr>

                                    </ContentTemplate>
                                </asp:UpdatePanel>
								
								  <asp:UpdatePanel ID="UpdatePanel158" runat="server">
                                    <ContentTemplate>







                                        <td>
                                            <asp:ImageButton ID="yuea36supplier" runat="server" Height="39px" ImageUrl="~/images/yue.jpg" Width="175px" />
                                        </td>
                                        <td>
                                            <asp:Label ID="lblyuea36program" runat="server" Text="YU Energy"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtyuea36sc" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="txtyuea36day" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtyuea36night" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtyuea36ew" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <%-- <td>
                                            <asp:TextBox ID="txtyuea36wd" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>

                                        <td>
                                            <asp:TextBox ID="txtyuea36unit" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>--%>
                                        <td>
                                            <asp:TextBox ID="txtyuea36offpeak" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtyuea36other" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtyuea36uplift" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="1.5" step="0.1" AutoPostBack="true" ></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtyue36Rate" runat="server" Text="0" Width="75px"></asp:TextBox>

                                        </td>

                                        <td>
                                            <asp:CheckBox ID="chkyue36" runat="server" />
                                        </td>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnyue36" runat="server" Text="Show" OnClick="btnyue36Show_Click" />
                                        </td>
                                        <td>
                                            <asp:Button ID="Button58" runat="server" Text="Save" /></td>



                                        </tr>

                                    </ContentTemplate>
                                </asp:UpdatePanel>







            </table>

        </asp:View>
        <asp:View ID="View48" runat="server">
            <table class="table table-bordered table-dark">
                <tr>
                    <td>Supplier Name</td>
                    <td>Program Name</td>
                    <td>Standing&nbsp; charge</td>
                    <td>Day Unit Charge</td>
                    <td>Night Unit Charge</td>
                    <td>EVENING WEEKEND UNIT CHARGE</td>
                    <%-- <td>WEEKDAY DAY UNIT CHARGE</td>

                    <td>UNIT Charge</td>--%>
                    <td>OFF PEAK UNIT CHARGE</td>
                    <td>Other Charges </td>
                    <td>Uplift</td>
                    <td>Yearly Charge</td>
                    <td>Mail</td>
                    <td>Show </td>
                    <td>Save</td>










                </tr>
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>



                        <tr>



                            <td>
                                <asp:ImageButton ID="bga48supplier" runat="server" Height="39px" ImageUrl="~/britishgas.jpg" Width="175px" />
                            </td>
                            <td>
                                <asp:Label ID="lblBga48program" runat="server" Text="British Gas new"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbga48sc" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txtbga48day" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbga48night" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbga48ew" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <%-- <td>
                                <asp:TextBox ID="txtbga48wd" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>

                            <td>
                                <asp:TextBox ID="txtbga48unit" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>--%>
                            <td>
                                <asp:TextBox ID="txtbga48offpeak" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbga48other" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbga48uplift" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="2.0" step="0.1" AutoPostBack="true" OnTextChanged="txtbga48uplift_TextChanged"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbga48rate" runat="server" Text="0" Width="75px"></asp:TextBox>

                            </td>


                            <td>
                                <asp:CheckBox ID="chkbga48" runat="server" />
                            </td>
                            <td>
                                <asp:Button ID="btnbga48" runat="server" Text="Show" OnClick="btnbga48_Click" />
                            </td>
                            <td>
                                <asp:Button ID="Button95" runat="server" Text="Save" /></td>


                        </tr>

                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                    <ContentTemplate>



                        <tr>



                            <td>
                                <asp:ImageButton ID="bge48supplier" runat="server" Height="39px" ImageUrl="~/britishgas.jpg" Width="175px" />
                            </td>
                            <td>
                                <asp:Label ID="lblBge48program" runat="server" Text="British Gas Re new "></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbge48sc" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txtbge48day" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbge48night" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbge48ew" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <%-- <td>
                                <asp:TextBox ID="txtbge48wd" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>

                            <td>
                                <asp:TextBox ID="txtbge48unit" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>--%>
                            <td>
                                <asp:TextBox ID="txtbge48offpeak" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbge48other" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbge48uplift" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="2.0" step="0.1" AutoPostBack="true" OnTextChanged="txtbge48uplift_TextChanged"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbfge48rate" runat="server" Text="0" Width="75px"></asp:TextBox>

                            </td>

                            <td>
                                <asp:CheckBox ID="chkbge48" runat="server" />
                            </td>
                            <td>
                                <asp:Button ID="btnbge48" runat="server" Text="Show" OnClick="btnbge48_Click" />
                            </td>
                            <td>
                                <asp:Button ID="Button67" runat="server" Text="Save" /></td>



                        </tr>

                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                    <ContentTemplate>



                        <tr>



                            <td>
                                <asp:ImageButton ID="bgl48supplier" runat="server" Height="39px" ImageUrl="~/images/bgl.png" Width="175px" />
                            </td>
                            <td>
                                <asp:Label ID="lblbgla48program" runat="server" Text="British Gas Lite new"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbgla48sc" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txtbgla48day" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbgla48night" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbgla48ew" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <%-- <td>
                                <asp:TextBox ID="txtbgla48wd" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>

                            <td>
                                <asp:TextBox ID="txtbgla48unit" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>--%>
                            <td>
                                <asp:TextBox ID="txtbgla48offpeak" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbgla48other" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbgla48uplift" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="1.5" step="0.1" AutoPostBack="true" OnTextChanged="txtbgla48uplift_TextChanged"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbfgla48rate" runat="server" Text="0" Width="75px"></asp:TextBox>

                            </td>

                            <td>
                                <asp:CheckBox ID="chkbgla48" runat="server" />
                            </td>
                            <td>
                                <asp:Button ID="btnbgla46" runat="server" Text="Show" OnClick="btnbgla46_Click" />
                            </td>
                            <td>
                                <asp:Button ID="Button69" runat="server" Text="Save" /></td>



                        </tr>

                    </ContentTemplate>
                </asp:UpdatePanel>

                <asp:UpdatePanel ID="UpdatePanel19" runat="server">
                    <ContentTemplate>



                        <tr>



                            <td>
                                <asp:ImageButton ID="bgle48supplier" runat="server" Height="39px" ImageUrl="~/images/bgl.png" Width="175px" />
                            </td>
                            <td>
                                <asp:Label ID="lblbgle48program" runat="server" Text="British Gas Lite new"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbgle48sc" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txtbgle48day" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbgle48night" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbgle48ew" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <%--  <td>
                                <asp:TextBox ID="txtbgle48wd" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>

                            <td>
                                <asp:TextBox ID="txtbgle48unit" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>--%>
                            <td>
                                <asp:TextBox ID="txtbgle48offpeak" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbgle48other" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbgle48uplift" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="1.5" step="0.1" AutoPostBack="true" OnTextChanged="txtbgle48uplift_TextChanged"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbgle48rate" runat="server" Text="0" Width="75px"></asp:TextBox>

                            </td>

                            <td>
                                <asp:CheckBox ID="chkbgle48" runat="server" />
                            </td>
                            <td>
                                <asp:Button ID="btnbgle48" runat="server" Text="Show" OnClick="btnbgle48_Click" />
                            </td>
                            <td>
                                <asp:Button ID="Button71" runat="server" Text="Save" /></td>



                        </tr>

                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:UpdatePanel ID="UpdatePanel24" runat="server">
                    <ContentTemplate>



                        <tr>



                            <td>
                                <asp:ImageButton ID="edfa48supplier" runat="server" Height="39px" ImageUrl="~/images/edf.jpg" Width="175px" />
                            </td>
                            <td>
                                <asp:Label ID="lbledfa48program" runat="server" Text="British Gas Lite new"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtedfa48sc" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txtedfa48day" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtedfa48night" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtedfa48ew" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <%-- <td>
                                <asp:TextBox ID="txtedfa48wd" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>

                            <td>
                                <asp:TextBox ID="txtedfa48unit" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>--%>
                            <td>
                                <asp:TextBox ID="txtedfa48offpeak" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtedfa48other" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtedfa48uplift" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="1.5" step="0.1" AutoPostBack="true" OnTextChanged="txtedfa48uplift_TextChanged"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtEdf48Rate" runat="server" Text="0" Width="75px"></asp:TextBox>

                            </td>


                            <td>
                                <asp:CheckBox ID="chkedf48" runat="server" />
                            </td>
                            <td>
                                <asp:Button ID="Button72" runat="server" Text="Show" />
                            </td>
                            <td>
                                <asp:Button ID="Button73" runat="server" Text="Save" /></td>


                        </tr>

                    </ContentTemplate>
                </asp:UpdatePanel>




                <asp:UpdatePanel ID="UpdatePanel29" runat="server">
                    <ContentTemplate>



                        <tr>



                            <td>
                                <asp:ImageButton ID="dea48supplier" runat="server" Height="39px" ImageUrl="~/images/de.jpg" Width="175px" />
                            </td>
                            <td>
                                <asp:Label ID="lbldea48program" runat="server" Text="British Gas Lite new"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtdea48sc" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txtdea48day" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtdea48night" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtdea48ew" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <%--<td>
                                <asp:TextBox ID="txtdea48wd" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>

                            <td>
                                <asp:TextBox ID="txtdea48unit" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>--%>
                            <td>
                                <asp:TextBox ID="txtdea48offpeak" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtdea48other" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtdea48uplift" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="2.0" step="0.1" AutoPostBack="true"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtdea48" runat="server" Text="0" Width="75px"></asp:TextBox>

                            </td>
                            <td>
                                <asp:CheckBox ID="chkdea48" runat="server" />
                            </td>
                            <td>
                                <asp:Button ID="Button74" runat="server" Text="Show" />
                            </td>
                            <td>
                                <asp:Button ID="Button75" runat="server" Text="Save" /></td>




                        </tr>

                    </ContentTemplate>
                </asp:UpdatePanel>


                <asp:UpdatePanel ID="UpdatePanel143" runat="server">
                    <ContentTemplate>



                        <td>
                            <asp:ImageButton ID="deawc48supplier" runat="server" Height="39px" ImageUrl="~/images/de.jpg" Width="175px" />
                        </td>
                        <td>
                            <asp:Label ID="lbldeawc48program" runat="server" Text="Dual Energy WC 48 Months"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtdeawc48sc" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="txtdeawc48day" runat="server" Text="0" Width="75px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtdeawc48night" runat="server" Text="0" Width="75px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtdeawc48ew" runat="server" Text="0" Width="75px"></asp:TextBox>
                        </td>
                        <%-- <td>
                                                <asp:TextBox ID="txtdeawc48wd" runat="server" Text="0" Width="75px"></asp:TextBox>
                                            </td>

                                            <td>
                                                <asp:TextBox ID="txtdeawc48unit" runat="server" Text="0" Width="75px"></asp:TextBox>
                                            </td>--%>
                        <td>
                            <asp:TextBox ID="txtdeawc48offpeak" runat="server" Text="0" Width="75px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtdeawc48other" runat="server" Text="0" Width="75px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtdeawc48uplift" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="2.0" step="0.1" AutoPostBack="true"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtdeawc48rate" runat="server" Text="0" Width="75px"></asp:TextBox>

                        </td>

                        <td>
                            <asp:CheckBox ID="chkdeawc48" runat="server" />
                        </td>
                        </td>
                                            <td>
                                                <asp:Button ID="btndeawc48show" runat="server" Text="Show" />
                                            </td>
                        <td>
                            <asp:Button ID="btndeawc48save" runat="server" Text="Save" /></td>



                        </tr>

                    </ContentTemplate>
                </asp:UpdatePanel>

                <tr>
                    <asp:UpdatePanel ID="UpdatePanel48" runat="server">
                        <ContentTemplate>







                            <td>
                                <asp:ImageButton ID="tgp48supplier" runat="server" Height="39px" ImageUrl="~/images/tglogo.png" Width="175px" />
                            </td>
                            <td>
                                <asp:Label ID="lbltgp48program" runat="server" Text="Total Energy"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txttgp48sc" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txttgp48day" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txttgp48night" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txttgp48ew" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <%-- <td>
                                <asp:TextBox ID="txttgp48wd" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>

                            <td>
                                <asp:TextBox ID="txttgp48unit" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>--%>
                            <td>
                                <asp:TextBox ID="txttgp48offpeak" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txttgp48other" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txttgp48uplift" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="3.0" step="0.1" AutoPostBack="true" OnTextChanged="txttgp48uplift_TextChanged"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txttgp48rate" runat="server" Text="0" Width="75px"></asp:TextBox>

                            </td>

                            <td>
                                <asp:CheckBox ID="chktgp48" runat="server" />
                            </td>
                            <td>
                                <asp:Button ID="btnTotal48" runat="server" Text="Show" OnClick="btnTotal48_Click" />
                            </td>
                            <td>
                                <asp:Button ID="Button79" runat="server" Text="Save" /></td>



                            </tr>

                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:UpdatePanel ID="UpdatePanel133" runat="server">
                        <ContentTemplate>







                            <td>
                                <asp:ImageButton ID="tgpw48supplier" runat="server" Height="39px" ImageUrl="~/images/tglogo.png" Width="175px" />
                            </td>
                            <td>
                                <asp:Label ID="lbltgpw48program" runat="server" Text="Total Energy"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txttgpw48sc" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txttgpw48day" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txttgpw48night" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txttgpw48ew" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <%-- <td>
                                                        <asp:TextBox ID="txttgpw48wd" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                    </td>

                                                    <td>
                                                        <asp:TextBox ID="txttgpw48unit" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                    </td>--%>
                            <td>
                                <asp:TextBox ID="txttgpw48offpeak" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txttgpw48other" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txttgpw48uplift" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="3.0" step="0.1" AutoPostBack="true"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txttgpw48rate" runat="server" Text="0" Width="75px"></asp:TextBox>

                            </td>
                            <td>
                                <asp:CheckBox ID="chktgpw48" runat="server" />
                            </td>
                            </td>
                             <td>
                                 <asp:Button ID="Button34" runat="server" Text="Show" />
                             </td>
                            <td>
                                <asp:Button ID="Button36" runat="server" Text="Save" /></td>





                            </tr>

                        </ContentTemplate>

                    </asp:UpdatePanel>


                    <asp:UpdatePanel ID="UpdatePanel104" runat="server">
                        <ContentTemplate>



                            <tr>



                                <td>
                                    <asp:ImageButton ID="opus48supplier" runat="server" Height="39px" ImageUrl="~/images/opus.png" Width="175px" />
                                </td>
                                <td>
                                    <asp:Label ID="lblopus48program" runat="server" Text="Opus Energy"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtopus48sc" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txtopus48day" runat="server" Text="0" Width="75px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtopus48night" runat="server" Text="0" Width="75px"></asp:TextBox>
                                </td>

                                <td>
                                    <asp:TextBox ID="txtopus48ew" runat="server" Text="0" Width="75px"></asp:TextBox>
                                </td>
                                <%-- <td>
                                    <asp:TextBox ID="txtopus48wd" runat="server" Text="0" Width="75px"></asp:TextBox>
                                </td>

                                <td>
                                    <asp:TextBox ID="txtopus48unit" runat="server" Text="0" Width="75px"></asp:TextBox>
                                </td>--%>
                                <td>
                                    <asp:TextBox ID="txtopus48offpeak" runat="server" Text="0" Width="75px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtopus48other" runat="server" Text="0" Width="75px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtopus48uplift" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="1.0" step="0.1" AutoPostBack="true" OnTextChanged="txtopus48uplift_TextChanged"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtopus48rate" runat="server" Text="0" Width="75px"></asp:TextBox>

                                </td>
                                <td>
                                    <asp:CheckBox ID="chkopus48" runat="server" />
                                </td>
                                <td>
                                    <asp:Button ID="btnopus48Show" runat="server" Text="Show" />
                                </td>
                                <td>
                                    <asp:Button ID="btnopus48Save" runat="server" Text="Save" /></td>




                            </tr>

                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <tr>
                        <asp:UpdatePanel ID="UpdatePanel108" runat="server">
                            <ContentTemplate>







                                <td>
                                    <asp:ImageButton ID="eon48supplier" runat="server" Height="39px" ImageUrl="~/images/eon.jpg" Width="175px" />
                                </td>
                                <td>
                                    <asp:Label ID="lbleon48program" runat="server" Text="EON Energy"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txteon48sc" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txteon48day" runat="server" Text="0" Width="75px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txteon48night" runat="server" Text="0" Width="75px"></asp:TextBox>
                                </td>

                                <td>
                                    <asp:TextBox ID="txteon48ew" runat="server" Text="0" Width="75px"></asp:TextBox>
                                </td>
                                <%-- <td>
                                    <asp:TextBox ID="txteon48wd" runat="server" Text="0" Width="75px"></asp:TextBox>
                                </td>

                                <td>
                                    <asp:TextBox ID="txteon48unit" runat="server" Text="0" Width="75px"></asp:TextBox>
                                </td>--%>
                                <td>
                                    <asp:TextBox ID="txteon48offpeak" runat="server" Text="0" Width="75px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txteon48other" runat="server" Text="0" Width="75px"></asp:TextBox>
                                </td>
                                <td>
                                    <%--  <asp:TextBox ID="txteon48uplift" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="3.0" step="0.1" AutoPostBack="true"></asp:TextBox>--%>
                                    <asp:DropDownList ID="ddeon48uplift" runat="server" Width="75px" AutoPostBack="true" OnSelectedIndexChanged="ddeon48uplift_SelectedIndexChanged">
                                        <asp:ListItem Selected="True">0.0</asp:ListItem>
                                        <asp:ListItem>0.1</asp:ListItem>
                                        <asp:ListItem>0.2</asp:ListItem>
                                        <asp:ListItem>0.3</asp:ListItem>
                                        <asp:ListItem>0.4</asp:ListItem>
                                        <asp:ListItem>0.5</asp:ListItem>
                                        <asp:ListItem>0.6</asp:ListItem>
                                        <asp:ListItem>0.7</asp:ListItem>
                                        <asp:ListItem>0.8</asp:ListItem>
                                        <asp:ListItem>0.9</asp:ListItem>
                                        <asp:ListItem>1.0</asp:ListItem>
                                        <asp:ListItem>1.2</asp:ListItem>
                                        <asp:ListItem>1.5</asp:ListItem>



                                    </asp:DropDownList>

                                </td>
                                <td>
                                    <asp:TextBox ID="txteon48rate" runat="server" Text="0" Width="75px"></asp:TextBox>

                                </td>
                                <td>
                                    <asp:CheckBox ID="chkeon48" runat="server" />
                                </td>
                                <td>
                                    <asp:Button ID="btneon48Show" runat="server" Text="Show" />
                                </td>
                                <td>
                                    <asp:Button ID="btneon48Save" runat="server" Text="Save" /></td>




                                </tr>

                            </ContentTemplate>
                        </asp:UpdatePanel>

                        <asp:UpdatePanel ID="UpdatePanel120" runat="server">
                            <ContentTemplate>



                                <tr>



                                    <td>
                                        <asp:ImageButton ID="hev48supplier" runat="server" Height="39px" ImageUrl="~/images/hev.png" Width="175px" />
                                    </td>
                                    <td>
                                        <asp:Label ID="lblhev48program" runat="server" Text="Heven Energy"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txthev48sc" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                                    <td>
                                        <asp:TextBox ID="txthev48day" runat="server" Text="0" Width="75px"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txthev48night" runat="server" Text="0" Width="75px"></asp:TextBox>
                                    </td>

                                    <td>
                                        <asp:TextBox ID="txthev48ew" runat="server" Text="0" Width="75px"></asp:TextBox>
                                    </td>
                                    <%-- <td>
                                                                <asp:TextBox ID="txthev48wd" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                            </td>

                                                            <td>
                                                                <asp:TextBox ID="txthev48unit" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                            </td>--%>
                                    <td>
                                        <asp:TextBox ID="txthev48offpeak" runat="server" Text="0" Width="75px"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txthev48other" runat="server" Text="0" Width="75px"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txthev48uplift" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="1.0" step="0.1" AutoPostBack="true"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txthev48rate" runat="server" Text="0" Width="75px"></asp:TextBox>

                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkhev48" runat="server" />
                                    </td>
                                    <td>
                                        <asp:Button ID="btnhev48Show" runat="server" Text="Show" />
                                    </td>
                                    <td>
                                        <asp:Button ID="btnhev48Save" runat="server" Text="Save" /></td>




                                </tr>

                            </ContentTemplate>
                        </asp:UpdatePanel>

                        <asp:UpdatePanel ID="UpdatePanel138" runat="server">
                            <ContentTemplate>



                                <tr>



                                    <td>
                                        <asp:ImageButton ID="hevc48supplier" runat="server" Height="39px" ImageUrl="~/images/hev.png" Width="175px" />
                                    </td>
                                    <td>
                                        <asp:Label ID="lblhevc48program" runat="server" Text="heven  Energy Complete"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txthevc48sc" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                                    <td>
                                        <asp:TextBox ID="txthevc48day" runat="server" Text="0" Width="75px"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txthevc48night" runat="server" Text="0" Width="75px"></asp:TextBox>
                                    </td>

                                    <td>
                                        <asp:TextBox ID="txthevc48ew" runat="server" Text="0" Width="75px"></asp:TextBox>
                                    </td>
                                    <%-- <td>
                                                                <asp:TextBox ID="txthevc48wd" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                            </td>

                                                            <td>
                                                                <asp:TextBox ID="txthevc48unit" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                            </td>--%>
                                    <td>
                                        <asp:TextBox ID="txthevc48offpeak" runat="server" Text="0" Width="75px"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txthevc48other" runat="server" Text="0" Width="75px"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txthevc48uplift" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="1.0" step="0.1" AutoPostBack="true"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txthevc48rate" runat="server" Text="0" Width="75px"></asp:TextBox>

                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkhevc48" runat="server" />
                                    </td>
                                    <td>
                                        <asp:Button ID="btnhevc48Show" runat="server" Text="Show" />
                                    </td>
                                    <td>
                                        <asp:Button ID="btnhevc48Save" runat="server" Text="Save" /></td>




                                </tr>

                            </ContentTemplate>
                        </asp:UpdatePanel>



                                <asp:UpdatePanel ID="UpdatePanel159" runat="server">
                                    <ContentTemplate>







                                        <td>
                                            <asp:ImageButton ID="utila48supplier" runat="server" Height="39px" ImageUrl="~/images/utilita.png" Width="175px" />
                                        </td>
                                        <td>
                                            <asp:Label ID="lblutila48program" runat="server" Text="Utilita Energy new"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtutila48sc" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="txtutila48day" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtutila48night" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtutila48ew" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <%-- <td>
                                            <asp:TextBox ID="txtutila48wd" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>

                                        <td>
                                            <asp:TextBox ID="txtutila48unit" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>--%>
                                        <td>
                                            <asp:TextBox ID="txtutila48offpeak" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtutila48other" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtutila48uplift" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="1.5" step="0.1" AutoPostBack="true" ></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtutil48Rate" runat="server" Text="0" Width="75px"></asp:TextBox>

                                        </td>

                                        <td>
                                            <asp:CheckBox ID="chkutil48" runat="server" />
                                        </td>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnutil48" runat="server" Text="Show" OnClick="btnutil48Show_Click" />
                                        </td>
                                        <td>
                                            <asp:Button ID="Button60" runat="server" Text="Save" /></td>



                                        </tr>

                                    </ContentTemplate>
                                </asp:UpdatePanel>
								
								
								 <asp:UpdatePanel ID="UpdatePanel160" runat="server">
                                    <ContentTemplate>







                                        <td>
                                            <asp:ImageButton ID="gulfa48supplier" runat="server" Height="39px" ImageUrl="~/images/gulf.png" Width="175px" />
                                        </td>
                                        <td>
                                            <asp:Label ID="lblgulfa48program" runat="server" Text="Gulf  Energy"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtgulfa48sc" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="txtgulfa48day" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtgulfa48night" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtgulfa48ew" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <%-- <td>
                                            <asp:TextBox ID="txtgulfa48wd" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>

                                        <td>
                                            <asp:TextBox ID="txtgulfa48unit" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>--%>
                                        <td>
                                            <asp:TextBox ID="txtgulfa48offpeak" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtgulfa48other" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtgulfa48uplift" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="1.5" step="0.1" AutoPostBack="true"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtgulf48Rate" runat="server" Text="0" Width="75px"></asp:TextBox>

                                        </td>

                                        <td>
                                            <asp:CheckBox ID="chkgulf48" runat="server" />
                                        </td>
                                        </td>
                                        <td>
                                            <asp:Button ID="btngulf48" runat="server" Text="Show" OnClick="btngulf48Show_Click" />
                                        </td>
                                        <td>
                                            <asp:Button ID="Button62" runat="server" Text="Save" /></td>



                                        </tr>

                                    </ContentTemplate>
                                </asp:UpdatePanel>
								
								  <asp:UpdatePanel ID="UpdatePanel161" runat="server">
                                    <ContentTemplate>







                                        <td>
                                            <asp:ImageButton ID="yuea48supplier" runat="server" Height="39px" ImageUrl="~/images/yue.jpg" Width="175px" />
                                        </td>
                                        <td>
                                            <asp:Label ID="lblyuea48program" runat="server" Text="YU Energy"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtyuea48sc" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="txtyuea48day" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtyuea48night" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtyuea48ew" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <%-- <td>
                                            <asp:TextBox ID="txtyuea48wd" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>

                                        <td>
                                            <asp:TextBox ID="txtyuea48unit" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>--%>
                                        <td>
                                            <asp:TextBox ID="txtyuea48offpeak" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtyuea48other" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtyuea48uplift" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="1.5" step="0.1" AutoPostBack="true" ></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtyue48Rate" runat="server" Text="0" Width="75px"></asp:TextBox>

                                        </td>

                                        <td>
                                            <asp:CheckBox ID="chkyue48" runat="server" />
                                        </td>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnyue48" runat="server" Text="Show" OnClick="btnyue48Show_Click" />
                                        </td>
                                        <td>
                                            <asp:Button ID="Button64" runat="server" Text="Save" /></td>



                                        </tr>

                                    </ContentTemplate>
                                </asp:UpdatePanel>





            </table>

        </asp:View>
        <asp:View ID="View60" runat="server">

            <table class="table table-bordered table-dark">
                <tr>
                    <td>Supplier Name</td>
                    <td>Program Name</td>
                    <td>Standing&nbsp; charge</td>
                    <td>Day Unit Charge</td>
                    <td>Night Unit Charge</td>
                    <td>EVENING WEEKEND UNIT CHARGE</td>
                    <%-- <td>WEEKDAY DAY UNIT CHARGE</td>

                    <td>UNIT Charge</td>--%>
                    <td>OFF PEAK UNIT CHARGE</td>
                    <td>Other Charges </td>
                    <td>Uplift</td>
                    <td>Yearly Charge</td>





                    <td>Mail</td>
                    <td>Show </td>
                    <td>Save</td>





                </tr>
                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>



                        <tr>



                            <td>
                                <asp:ImageButton ID="bga60supplier" runat="server" Height="39px" ImageUrl="~/britishgas.jpg" Width="175px" />
                            </td>
                            <td>
                                <asp:Label ID="lblBga60program" runat="server" Text="British Gas new"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbga60sc" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txtbga60day" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbga60night" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbga60ew" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <%--<td>
                                <asp:TextBox ID="txtbga60wd" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>

                            <td>
                                <asp:TextBox ID="txtbga60unit" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>--%>
                            <td>
                                <asp:TextBox ID="txtbga60offpeak" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbga60other" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbga60uplift" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="2.0" step="0.1" AutoPostBack="true" OnTextChanged="txtbga60uplift_TextChanged"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbga60rate" runat="server" Text="0" Width="75px"></asp:TextBox>

                            </td>

                            <td>
                                <asp:CheckBox ID="chkbga60" runat="server" />
                            </td>
                            <td>
                                <asp:Button ID="btnbga60" runat="server" Text="Show" />
                            </td>
                            <td>
                                <asp:Button ID="Button81" runat="server" Text="Save" /></td>




                        </tr>

                    </ContentTemplate>
                </asp:UpdatePanel>

                <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                    <ContentTemplate>



                        <tr>



                            <td>
                                <asp:ImageButton ID="bge60supplier" runat="server" Height="39px" ImageUrl="~/britishgas.jpg" Width="175px" />
                            </td>
                            <td>
                                <asp:Label ID="lblBge60program" runat="server" Text="British Gas Re new "></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbge60sc" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txtbge60day" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbge60night" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbge60ew" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <%-- <td>
                                <asp:TextBox ID="txtbge60wd" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>

                            <td>
                                <asp:TextBox ID="txtbge60unit" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>--%>
                            <td>
                                <asp:TextBox ID="txtbge60offpeak" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbge60other" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbge60uplift" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="2.0" step="0.1" AutoPostBack="true"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbfge60rate" runat="server" Text="0" Width="75px"></asp:TextBox>

                            </td>

                            <td>
                                <asp:CheckBox ID="chkbge60" runat="server" />
                            </td>
                            <td>
                                <asp:Button ID="btnbge60" runat="server" Text="Show" />
                            </td>
                            <td>
                                <asp:Button ID="Button83" runat="server" Text="Save" /></td>



                        </tr>

                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:UpdatePanel ID="UpdatePanel15" runat="server">
                    <ContentTemplate>



                        <tr>



                            <td>
                                <asp:ImageButton ID="bgl60supplier" runat="server" Height="39px" ImageUrl="~/images/bgl.png" Width="175px" />
                            </td>
                            <td>
                                <asp:Label ID="lblbgla60program" runat="server" Text="British Gas Lite new"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbgla60sc" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txtbgla60day" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbgla60night" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbgla60ew" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <%-- <td>
                                <asp:TextBox ID="txtbgla60wd" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>

                            <td>
                                <asp:TextBox ID="txtbgla60unit" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>--%>
                            <td>
                                <asp:TextBox ID="txtbgla60offpeak" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbgla60other" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbgla60uplift" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="1.5" step="0.1" AutoPostBack="true"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbfgla60rate" runat="server" Text="0" Width="75px"></asp:TextBox>

                            </td>

                            <td>
                                <asp:CheckBox ID="chkbgla60" runat="server" />
                            </td>
                            <td>
                                <asp:Button ID="btnbgla60" runat="server" Text="Show" />
                            </td>
                            <td>
                                <asp:Button ID="Button85" runat="server" Text="Save" /></td>



                        </tr>

                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:UpdatePanel ID="UpdatePanel20" runat="server">
                    <ContentTemplate>



                        <tr>



                            <td>
                                <asp:ImageButton ID="bgle60supplier" runat="server" Height="39px" ImageUrl="~/images/bgl.png" Width="175px" />
                            </td>
                            <td>
                                <asp:Label ID="lblbgle60program" runat="server" Text="British Gas Lite new"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbgle60sc" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txtbgle60day" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbgle60night" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbgle60ew" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <%--<td>
                                <asp:TextBox ID="txtbgle60wd" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>

                            <td>
                                <asp:TextBox ID="txtbgle60unit" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>--%>
                            <td>
                                <asp:TextBox ID="txtbgle60offpeak" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbgle60other" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbgle60uplift" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="1.5" step="0.1" AutoPostBack="true"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbfgle60rate" runat="server" Text="0" Width="75px"></asp:TextBox>

                            </td>

                            <td>
                                <asp:CheckBox ID="chkbgle60" runat="server" />
                            </td>
                            <td>
                                <asp:Button ID="btnbgle60" runat="server" Text="Show" />
                            </td>
                            <td>
                                <asp:Button ID="Button87" runat="server" Text="Save" /></td>



                        </tr>

                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:UpdatePanel ID="UpdatePanel25" runat="server">
                    <ContentTemplate>



                        <tr>



                            <td>
                                <asp:ImageButton ID="edfa60supplier" runat="server" Height="39px" ImageUrl="~/images/edf.jpg" Width="175px" />
                            </td>
                            <td>
                                <asp:Label ID="lbledfa60program" runat="server" Text="British Gas Lite new"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtedfa60sc" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txtedfa60day" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtedfa60night" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtedfa60ew" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <%-- <td>
                                <asp:TextBox ID="txtedfa60wd" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>

                            <td>
                                <asp:TextBox ID="txtedfa60unit" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>--%>
                            <td>
                                <asp:TextBox ID="txtedfa60offpeak" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtedfa60other" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtedfa60uplift" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="1.5" step="0.1" AutoPostBack="true" OnTextChanged="txtedfa60uplift_TextChanged"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtedf60rate" runat="server" Text="0" Width="75px"></asp:TextBox>

                            </td>

                            <td>
                                <asp:CheckBox ID="chkedf60" runat="server" />
                            </td>
                            <td>
                                <asp:Button ID="btnedf60" runat="server" Text="Show" />
                            </td>
                            <td>
                                <asp:Button ID="Button89" runat="server" Text="Save" /></td>



                        </tr>

                    </ContentTemplate>
                </asp:UpdatePanel>

                <asp:UpdatePanel ID="UpdatePanel30" runat="server">
                    <ContentTemplate>



                        <tr>



                            <td>
                                <asp:ImageButton ID="dea60supplier" runat="server" Height="39px" ImageUrl="~/images/de.jpg" Width="175px" />
                            </td>
                            <td>
                                <asp:Label ID="lbldea60program" runat="server" Text="British Gas Lite new"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtdea60sc" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txtdea60day" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtdea60night" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtdea60ew" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <%--<td>
                                <asp:TextBox ID="txtdea60wd" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>

                            <td>
                                <asp:TextBox ID="txtdea60unit" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>--%>
                            <td>
                                <asp:TextBox ID="txtdea60offpeak" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtdea60other" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtdea60uplift" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="2.0" step="0.1" AutoPostBack="true" OnTextChanged="txtdea60uplift_TextChanged"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtde60rate" runat="server" Text="0" Width="75px"></asp:TextBox>

                            </td>


                            <td>
                                <asp:CheckBox ID="chkde60" runat="server" />
                            </td>
                            <td>
                                <asp:Button ID="btnde60" runat="server" Text="Show" OnClick="btnde60_Click" />
                            </td>
                            <td>
                                <asp:Button ID="Button91" runat="server" Text="Save" /></td>


                        </tr>

                    </ContentTemplate>
                </asp:UpdatePanel>

                <asp:UpdatePanel ID="UpdatePanel144" runat="server">
                    <ContentTemplate>



                        <td>
                            <asp:ImageButton ID="deawc60supplier" runat="server" Height="39px" ImageUrl="~/images/de.jpg" Width="175px" />
                        </td>
                        <td>
                            <asp:Label ID="lbldeawc60program" runat="server" Text="Dual Energy WC 60 Months"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtdeawc60sc" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="txtdeawc60day" runat="server" Text="0" Width="75px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtdeawc60night" runat="server" Text="0" Width="75px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtdeawc60ew" runat="server" Text="0" Width="75px"></asp:TextBox>
                        </td>
                        <%-- <td>
                                                <asp:TextBox ID="txtdeawc60wd" runat="server" Text="0" Width="75px"></asp:TextBox>
                                            </td>

                                            <td>
                                                <asp:TextBox ID="txtdeawc60unit" runat="server" Text="0" Width="75px"></asp:TextBox>
                                            </td>--%>
                        <td>
                            <asp:TextBox ID="txtdeawc60offpeak" runat="server" Text="0" Width="75px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtdeawc60other" runat="server" Text="0" Width="75px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtdeawc60uplift" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="2.0" step="0.1" AutoPostBack="true"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtdeawc60rate" runat="server" Text="0" Width="75px"></asp:TextBox>

                        </td>

                        <td>
                            <asp:CheckBox ID="chkdeawc60" runat="server" />
                        </td>
                        </td>
                                            <td>
                                                <asp:Button ID="btndeawc60show" runat="server" Text="Show" />
                                            </td>
                        <td>
                            <asp:Button ID="btndeawc60save" runat="server" Text="Save" /></td>



                        </tr>

                    </ContentTemplate>
                </asp:UpdatePanel>



                <asp:UpdatePanel ID="UpdatePanel49" runat="server">
                    <ContentTemplate>



                        <tr>



                            <td>
                                <asp:ImageButton ID="tgp60supplier" runat="server" Height="39px" ImageUrl="~/images/tglogo.png" Width="175px" />
                            </td>
                            <td>
                                <asp:Label ID="lbltgp60program" runat="server" Text="Total Energy"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txttgp60sc" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txttgp60day" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txttgp60night" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txttgp60ew" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <%-- <td>
                                <asp:TextBox ID="txttgp60wd" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>

                            <td>
                                <asp:TextBox ID="txttgp60unit" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>--%>
                            <td>
                                <asp:TextBox ID="txttgp60offpeak" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txttgp60other" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txttgp60uplift" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="3.0" step="0.1" AutoPostBack="true" OnTextChanged="txttgp60uplift_TextChanged"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txttgp60rate" runat="server" Text="0" Width="75px"></asp:TextBox>

                            </td>

                            <td>
                                <asp:CheckBox ID="chktgp60" runat="server" />
                            </td>
                            <td>
                                <asp:Button ID="btntgp60" runat="server" Text="Show" OnClick="btntgp60_Click" />
                            </td>
                            <td>
                                <asp:Button ID="Button93" runat="server" Text="Save" /></td>



                        </tr>

                    </ContentTemplate>
                </asp:UpdatePanel>

                <asp:UpdatePanel ID="UpdatePanel134" runat="server">
                    <ContentTemplate>







                        <td>
                            <asp:ImageButton ID="tgpw60supplier" runat="server" Height="39px" ImageUrl="~/images/tglogo.png" Width="175px" />
                        </td>
                        <td>
                            <asp:Label ID="lbltgpw60program" runat="server" Text="Total Energy"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txttgpw60sc" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="txttgpw60day" runat="server" Text="0" Width="75px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txttgpw60night" runat="server" Text="0" Width="75px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txttgpw60ew" runat="server" Text="0" Width="75px"></asp:TextBox>
                        </td>
                        <%-- <td>
                                                        <asp:TextBox ID="txttgpw60wd" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                    </td>

                                                    <td>
                                                        <asp:TextBox ID="txttgpw60unit" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                    </td>--%>
                        <td>
                            <asp:TextBox ID="txttgpw60offpeak" runat="server" Text="0" Width="75px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txttgpw60other" runat="server" Text="0" Width="75px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txttgpw60uplift" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="3.0" step="0.1" AutoPostBack="true"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txttgpw60rate" runat="server" Text="0" Width="75px"></asp:TextBox>

                        </td>
                        <td>
                            <asp:CheckBox ID="chktgpw60" runat="server" />
                        </td>
                        </td>
                             <td>
                                 <asp:Button ID="Button38" runat="server" Text="Show" />
                             </td>
                        <td>
                            <asp:Button ID="Button40" runat="server" Text="Save" /></td>





                        </tr>

                    </ContentTemplate>

                </asp:UpdatePanel>


                                <asp:UpdatePanel ID="UpdatePanel162" runat="server">
                                    <ContentTemplate>







                                        <td>
                                            <asp:ImageButton ID="utila60supplier" runat="server" Height="39px" ImageUrl="~/images/utilita.png" Width="175px" />
                                        </td>
                                        <td>
                                            <asp:Label ID="lblutila60program" runat="server" Text="Utilita Energy new"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtutila60sc" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="txtutila60day" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtutila60night" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtutila60ew" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <%-- <td>
                                            <asp:TextBox ID="txtutila60wd" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>

                                        <td>
                                            <asp:TextBox ID="txtutila60unit" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>--%>
                                        <td>
                                            <asp:TextBox ID="txtutila60offpeak" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtutila60other" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtutila60uplift" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="1.5" step="0.1" AutoPostBack="true" ></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtutil60Rate" runat="server" Text="0" Width="75px"></asp:TextBox>

                                        </td>

                                        <td>
                                            <asp:CheckBox ID="chkutil60" runat="server" />
                                        </td>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnutil60" runat="server" Text="Show" />
                                        </td>
                                        <td>
                                            <asp:Button ID="Button66" runat="server" Text="Save" /></td>



                                        </tr>

                                    </ContentTemplate>
                                </asp:UpdatePanel>
								
								
								 <asp:UpdatePanel ID="UpdatePanel163" runat="server">
                                    <ContentTemplate>







                                        <td>
                                            <asp:ImageButton ID="gulfa60supplier" runat="server" Height="39px" ImageUrl="~/images/gulf.png" Width="175px" />
                                        </td>
                                        <td>
                                            <asp:Label ID="lblgulfa60program" runat="server" Text="Gulf  Energy"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtgulfa60sc" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="txtgulfa60day" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtgulfa60night" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtgulfa60ew" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <%-- <td>
                                            <asp:TextBox ID="txtgulfa60wd" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>

                                        <td>
                                            <asp:TextBox ID="txtgulfa60unit" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>--%>
                                        <td>
                                            <asp:TextBox ID="txtgulfa60offpeak" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtgulfa60other" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtgulfa60uplift" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="1.5" step="0.1" AutoPostBack="true"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtgulf60Rate" runat="server" Text="0" Width="75px"></asp:TextBox>

                                        </td>

                                        <td>
                                            <asp:CheckBox ID="chkgulf60" runat="server" />
                                        </td>
                                        </td>
                                        <td>
                                            <asp:Button ID="btngulf60" runat="server" Text="Show" OnClick="btngulf60Show_Click" />
                                        </td>
                                        <td>
                                            <asp:Button ID="Button68" runat="server" Text="Save" /></td>



                                        </tr>

                                    </ContentTemplate>
                                </asp:UpdatePanel>
								
								  <asp:UpdatePanel ID="UpdatePanel164" runat="server">
                                    <ContentTemplate>







                                        <td>
                                            <asp:ImageButton ID="yuea60supplier" runat="server" Height="39px" ImageUrl="~/images/yue.jpg" Width="175px" />
                                        </td>
                                        <td>
                                            <asp:Label ID="lblyuea60program" runat="server" Text="YU Energy"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtyuea60sc" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="txtyuea60day" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtyuea60night" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtyuea60ew" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <%-- <td>
                                            <asp:TextBox ID="txtyuea60wd" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>

                                        <td>
                                            <asp:TextBox ID="txtyuea60unit" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>--%>
                                        <td>
                                            <asp:TextBox ID="txtyuea60offpeak" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtyuea60other" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtyuea60uplift" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="1.5" step="0.1" AutoPostBack="true" ></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtyue60Rate" runat="server" Text="0" Width="75px"></asp:TextBox>

                                        </td>

                                        <td>
                                            <asp:CheckBox ID="chkyue60" runat="server" />
                                        </td>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnyue60" runat="server" Text="Show" OnClick="btnyue60Show_Click" />
                                        </td>
                                        <td>
                                            <asp:Button ID="Button70" runat="server" Text="Save" /></td>



                                        </tr>

                                    </ContentTemplate>
                                </asp:UpdatePanel>



            </table>
        </asp:View>
        <asp:View ID="Viewall" runat="server">
            <h3>Rate for 1 year</h3>

            <table class="table table-bordered table-dark">
                <tr>
                    <td>Supplier Name</td>
                    <td>Program Name</td>
                    <td>Standing&nbsp; charge</td>
                    <td>Day Unit Charge</td>
                    <td>Night Unit Charge</td>
                    <td>EVENING<br />
                        WEEKEND UNIT CHARGE</td>
                    <%--<td>WEEKDAY
                         <br />
                        DAY UNIT<br />
                        CHARGE</td>

                    <td>UNIT Charge</td>--%>
                    <td>OFF PEAK UNIT CHARGE</td>
                    <td>Other Charges </td>
                    <td>Uplift</td>
                    <td>Yearly Charge</td>





                    <td>Mail</td>
                    <td>Show </td>
                    <td>Save</td>





                </tr>
                <asp:UpdatePanel ID="UpdatePanel50" runat="server">
                    <ContentTemplate>



                        <tr>



                            <td>
                                <asp:ImageButton ID="bga12supplierall" runat="server" Height="39px" ImageUrl="~/britishgas.jpg" Width="175px" />
                            </td>
                            <td>
                                <asp:Label ID="lblBga12programall" runat="server" Text="British Gas new"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbga12scall" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txtbga12dayall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbga12nightall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>

                            <td>
                                <asp:TextBox ID="txtbga12ewall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <%-- <td>
                                <asp:TextBox ID="txtbga12wdall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>

                            <td>
                                <asp:TextBox ID="txtbga12unitall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>--%>
                            <td>
                                <asp:TextBox ID="txtbga12offpeakall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbga12otherall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbga12upliftall" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="2.0" step="0.1" AutoPostBack="true" OnTextChanged="txtbga12upliftall_TextChanged"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbga12rateall" runat="server" Text="0" Width="75px"></asp:TextBox>

                            </td>
                            <td>
                                <asp:CheckBox ID="chkbga12all" runat="server" />
                            </td>
                            <td>
                                <asp:Button ID="btnbga12Showall" runat="server" Text="Show" OnClick="btnbga12Showall_Click" />
                            </td>
                            <td>
                                <asp:Button ID="Button13" runat="server" Text="Save" /></td>




                        </tr>

                    </ContentTemplate>
                </asp:UpdatePanel>


                <tr>
                    <asp:UpdatePanel ID="UpdatePanel51" runat="server">
                        <ContentTemplate>







                            <td>
                                <asp:ImageButton ID="bge12supplierall" runat="server" Height="39px" ImageUrl="~/britishgas.jpg" Width="175px" />
                            </td>
                            <td>
                                <asp:Label ID="lblBge12programall" runat="server" Text="British Gas Re new "></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbge12scall" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txtbge12dayall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbge12nightall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbge12ewall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <%-- <td>
                                <asp:TextBox ID="txtbge12wdall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>

                            <td>
                                <asp:TextBox ID="txtbge12unitall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>--%>
                            <td>
                                <asp:TextBox ID="txtbge12offpeakall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbge12otherall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbge12upliftall" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="2.0" step="0.1" AutoPostBack="true" OnTextChanged="txtbge12upliftall_TextChanged"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbge12rateall" runat="server" Text="0" Width="75px"></asp:TextBox>

                            </td>
                            <td>
                                <asp:CheckBox ID="chkbge12all" runat="server" />
                            </td>
                            </td>
                             <td>
                                 <asp:Button ID="btnbge12showall" runat="server" Text="Show" />
                             </td>
                            <td>
                                <asp:Button ID="btnbgesaveall" runat="server" Text="Save" /></td>



                            </tr>

                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <tr>
                        <asp:UpdatePanel ID="UpdatePanel52" runat="server">
                            <ContentTemplate>







                                <td>
                                    <asp:ImageButton ID="bgl12supplierall" runat="server" Height="39px" ImageUrl="~/images/bgl.png" Width="175px" />
                                </td>
                                <td>
                                    <asp:Label ID="lblbgla12programall" runat="server" Text="British Gas Lite new"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtbgla12scall" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txtbgla12dayall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtbgla12nightall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtbgla12ewall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                </td>
                                <%-- <td>
                                    <asp:TextBox ID="txtbgla12wdall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                </td>

                                <td>
                                    <asp:TextBox ID="txtbgla12unitall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                </td>--%>
                                <td>
                                    <asp:TextBox ID="txtbgla12offpeakall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtbgla12otherall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtbgla12upliftall" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="1.5" step="0.1" AutoPostBack="true" OnTextChanged="txtbgla12upliftall_TextChanged"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtbgla12rateall" runat="server" Text="0" Width="75px"></asp:TextBox>

                                </td>

                                <td>
                                    <asp:CheckBox ID="chkbgl12all" runat="server" />
                                </td>
                                </td>
                             <td>
                                 <asp:Button ID="btnbglashowall" runat="server" Text="Show" />
                             </td>
                                <td>
                                    <asp:Button ID="btnbglasaveall" runat="server" Text="Save" /></td>




                                </tr>

                            </ContentTemplate>
                        </asp:UpdatePanel>

                        <asp:UpdatePanel ID="UpdatePanel53" runat="server">
                            <ContentTemplate>



                                <tr>



                                    <td>
                                        <asp:ImageButton ID="bgle12supplierall" runat="server" Height="39px" ImageUrl="~/images/bgl.png" Width="175px" />
                                    </td>
                                    <td>
                                        <asp:Label ID="lblbgle12programall" runat="server" Text="British Gas Lite new"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtbgle12scall" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                                    <td>
                                        <asp:TextBox ID="txtbgle12dayall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtbgle12nightall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtbgle12ewall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                    </td>
                                    <%-- <td>
                                        <asp:TextBox ID="txtbgle12wdall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                    </td>

                                    <td>
                                        <asp:TextBox ID="txtbgle12unitall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                    </td>--%>
                                    <td>
                                        <asp:TextBox ID="txtbgle12offpeakall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtbgle12otherall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtbgle12upliftall" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="1.5" step="0.1" AutoPostBack="true" OnTextChanged="txtbgle12upliftall_TextChanged"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtbgle12rateall" runat="server" Text="0" Width="75px"></asp:TextBox>

                                    </td>

                                    <td>
                                        <asp:CheckBox ID="chkbgle12all" runat="server" />
                                    </td>
                                    </td>
                             <td>
                                 <asp:Button ID="btnbgleshowall" runat="server" Text="Show" />
                             </td>
                                    <td>
                                        <asp:Button ID="btnbglesaveall" runat="server" Text="Save" /></td>





                                </tr>

                            </ContentTemplate>
                        </asp:UpdatePanel>

                        <tr>
                            <asp:UpdatePanel ID="UpdatePanel54" runat="server">
                                <ContentTemplate>







                                    <td>
                                        <asp:ImageButton ID="edfa12supplierall" runat="server" Height="39px" ImageUrl="~/images/edf.jpg" Width="175px" />
                                    </td>
                                    <td>
                                        <asp:Label ID="lbledfa12programall" runat="server" Text="British Gas Lite new"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtedfa12scall" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                                    <td>
                                        <asp:TextBox ID="txtedfa12dayall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtedfa12nightall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtedfa12ewall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                    </td>
                                    <%--<td>
                                        <asp:TextBox ID="txtedfa12wdall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                    </td>

                                    <td>
                                        <asp:TextBox ID="txtedfa12unitall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                    </td>--%>
                                    <td>
                                        <asp:TextBox ID="txtedfa12offpeakall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtedfa12otherall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtedfa12upliftall" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="1.5" step="0.1" AutoPostBack="true" OnTextChanged="txtedfa12upliftall_TextChanged"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtedf12rateall" runat="server" Text="0" Width="75px"></asp:TextBox>

                                    </td>

                                    <td>
                                        <asp:CheckBox ID="chkedf12all" runat="server" />
                                    </td>
                                    </td>
                             <td>
                                 <asp:Button ID="Button96" runat="server" Text="Show" />
                             </td>
                                    <td>
                                        <asp:Button ID="Button97" runat="server" Text="Save" /></td>



                                    </tr>

                                </ContentTemplate>
                            </asp:UpdatePanel>

                            <asp:UpdatePanel ID="UpdatePanel55" runat="server">
                                <ContentTemplate>



                                    <tr>



                                        <td>
                                            <asp:ImageButton ID="dea12supplier12all" runat="server" Height="39px" ImageUrl="~/images/de.jpg" Width="175px" />
                                        </td>
                                        <td>
                                            <asp:Label ID="lbldea12program12all" runat="server" Text="British Gas Lite new"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtdea12sc12all" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="txtdea12day12all" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtdea12night12all" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtdea12ew12all" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <%-- <td>
                                            <asp:TextBox ID="txtdea12wd12all" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>

                                        <td>
                                            <asp:TextBox ID="txtdea12unit12all" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>--%>
                                        <td>
                                            <asp:TextBox ID="txtdea12offpeak12all" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtdea12other12all" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtdea12uplift12all" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="2.0" step="0.1" AutoPostBack="true" OnTextChanged="txtdea12uplift12all_TextChanged"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtdea12all" runat="server" Text="0" Width="75px"></asp:TextBox>

                                        </td>

                                        <td>
                                            <asp:CheckBox ID="chkdea12all" runat="server" />
                                        </td>

                                        <td>
                                            <asp:Button ID="btndea12showall" runat="server" Text="Show" />
                                        </td>
                                        <td>
                                            <asp:Button ID="btndea12saveall" runat="server" Text="Save" /></td>



                                    </tr>

                                </ContentTemplate>
                            </asp:UpdatePanel>

                            <asp:UpdatePanel ID="UpdatePanel145" runat="server">
                                <ContentTemplate>



                                    <tr>



                                        <td>
                                            <asp:ImageButton ID="deawc12supplier12all" runat="server" Height="39px" ImageUrl="~/images/de.jpg" Width="175px" />
                                        </td>
                                        <td>
                                            <asp:Label ID="lbldeawc12program12all" runat="server" Text="British Gas Lite new"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtdeawc12sc12all" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="txtdeawc12day12all" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtdeawc12night12all" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtdeawc12ew12all" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <%-- <td>
                                            <asp:TextBox ID="txtdeawc12wd12all" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>

                                        <td>
                                            <asp:TextBox ID="txtdeawc12unit12all" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>--%>
                                        <td>
                                            <asp:TextBox ID="txtdeawc12offpeak12all" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtdeawc12other12all" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtdeawc12uplift12all" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="2.0" step="0.1" AutoPostBack="true"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtdeawc12all" runat="server" Text="0" Width="75px"></asp:TextBox>

                                        </td>

                                        <td>
                                            <asp:CheckBox ID="chkdeawc12all" runat="server" />
                                        </td>

                                        <td>
                                            <asp:Button ID="btndeawc12showall" runat="server" Text="Show" />
                                        </td>
                                        <td>
                                            <asp:Button ID="btndeawc12saveall" runat="server" Text="Save" /></td>



                                    </tr>

                                </ContentTemplate>
                            </asp:UpdatePanel>

                            <tr>
                                <asp:UpdatePanel ID="UpdatePanel56" runat="server">
                                    <ContentTemplate>







                                        <td>
                                            <asp:ImageButton ID="pe12supplierall" runat="server" Height="39px" ImageUrl="~/images/positive.jpg" Width="175px" />
                                        </td>
                                        <td>
                                            <asp:Label ID="lblpe12programall" runat="server" Text="Positive Energy"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtpe12scall" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="txtpe12dayall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtpe12nightall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtpe12ewall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <%-- <td>
                                            <asp:TextBox ID="txtpe12wdall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>

                                        <td>
                                            <asp:TextBox ID="txtpe12unitall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>--%>
                                        <td>
                                            <asp:TextBox ID="txtpe12offpeakall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtpe12otherall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtpe12upliftall" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="3.0" step="0.1" AutoPostBack="true" OnTextChanged="txtpe12upliftall_TextChanged"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtpe12rateall" runat="server" Text="0" Width="75px"></asp:TextBox>

                                        </td>

                                        <td>
                                            <asp:CheckBox ID="chkpe12all" runat="server" />
                                        </td>
                                        </td>
                             <td>
                                 <asp:Button ID="Button100" runat="server" Text="Show" />
                             </td>
                                        <td>
                                            <asp:Button ID="Button101" runat="server" Text="Save" /></td>




                                        </tr>

                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <tr>
                                    <asp:UpdatePanel ID="UpdatePanel57" runat="server">
                                        <ContentTemplate>







                                            <td>
                                                <asp:ImageButton ID="gaz12supplierall" runat="server" Height="39px" ImageUrl="~/images/gaz.png" AlternateText="Gaz Prom " Width="175px" />
                                            </td>
                                            <td>
                                                <asp:Label ID="lblgaz12programall" runat="server" Text="Gaz  Energy"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtgaz12scall" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox ID="txtgaz12dayall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtgaz12nightall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtgaz12ewall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                            </td>
                                            <%--<td>
                                                <asp:TextBox ID="txtgaz12wdall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                            </td>

                                            <td>
                                                <asp:TextBox ID="txtgaz12unitall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                            </td>--%>
                                            <td>
                                                <asp:TextBox ID="txtgaz12offpeakall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtgaz12otherall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtgaz12upliftall" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="2.0" step="0.1" AutoPostBack="true" OnTextChanged="txtgaz12upliftall_TextChanged"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtgaz12rateall" runat="server" Text="0" Width="75px"></asp:TextBox>

                                            </td>

                                            <td>
                                                <asp:CheckBox ID="chkgaz12all" runat="server" />
                                            </td>
                                            </td>
                             <td>
                                 <asp:Button ID="Button102" runat="server" Text="Show" />
                             </td>
                                            <td>
                                                <asp:Button ID="Button103" runat="server" Text="Save" /></td>




                                            </tr>

                                        </ContentTemplate>
                                    </asp:UpdatePanel>

                                    <asp:UpdatePanel ID="UpdatePanel58" runat="server">
                                        <ContentTemplate>



                                            <tr>



                                                <td>
                                                    <asp:ImageButton ID="sse12supplierall" runat="server" Height="39px" ImageUrl="~/images/sse.jpg" AlternateText="sse energy" Width="175px" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblsse12programall" runat="server" Text="sse  Energy"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtsse12scamrall" runat="server" Width="75px" Text="0"></asp:TextBox>
                                                    <asp:TextBox ID="txtsse12scnonamrall" runat="server" Width="75px" Text="0"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtsse12dayall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtsse12nightall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtsse12ewall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                </td>
                                                <%--<td>
                                                    <asp:TextBox ID="txtsse12wdall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                </td>

                                                <td>
                                                    <asp:TextBox ID="txtsse12unitall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                </td>--%>
                                                <td>
                                                    <asp:TextBox ID="txtsse12offpeakall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtsse12otherall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtsse12upliftall" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="2.0" step="0.1" AutoPostBack="true" OnTextChanged="txtsse12upliftall_TextChanged"></asp:TextBox>
                                                    <asp:TextBox ID="txtsse12upliftnonamrall" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="2.0" step="0.1" AutoPostBack="true" OnTextChanged="txtsse12upliftnonamrall_TextChanged"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtsse12rateall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                    <asp:TextBox ID="txtsse12ratenonamrall" runat="server" Text="0" Width="75px"></asp:TextBox>

                                                </td>

                                                <td>
                                                    <asp:CheckBox ID="chkss12all" runat="server" />
                                                </td>

                                                <td>
                                                    <asp:Button ID="Button104" runat="server" Text="Show" />
                                                </td>
                                                <td>
                                                    <asp:Button ID="Button105" runat="server" Text="Save" /></td>



                                            </tr>

                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <tr>
                                        <asp:UpdatePanel ID="UpdatePanel59" runat="server">
                                            <ContentTemplate>





                                                <td>
                                                    <asp:ImageButton ID="npra12supplierall" runat="server" Height="39px" ImageUrl="~/images/npower.jpg" AlternateText="N Power energy" Width="175px" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblnpra12programall" runat="server" Text="npra  Energy"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtnpra12scall" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                                                <td>
                                                    <asp:TextBox ID="txtnpra12dayall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtnpra12nightall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtnpra12ewall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                </td>
                                                <%--<td>
                                                    <asp:TextBox ID="txtnpra12wdall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                </td>

                                                <td>
                                                    <asp:TextBox ID="txtnpra12unitall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                </td>--%>
                                                <td>
                                                    <asp:TextBox ID="txtnpra12offpeakall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtnpra12otherall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtnpra12upliftall" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="3.0" step="0.1" AutoPostBack="true" OnTextChanged="txtnpra12upliftall_TextChanged"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtnpra12rateall" runat="server" Text="0" Width="75px"></asp:TextBox>

                                                </td>

                                                <td>
                                                    <asp:CheckBox ID="chknpower12all" runat="server" />
                                                </td>
                                                </td>
                  <td>
                      <asp:Button ID="Button106" runat="server" Text="Show" />
                  </td>
                                                <td>
                                                    <asp:Button ID="Button107" runat="server" Text="Save" /></td>



                                                </tr>

                                            </ContentTemplate>
                                        </asp:UpdatePanel>


                                        <asp:UpdatePanel ID="UpdatePanel60" runat="server">
                                            <ContentTemplate>



                                                <tr>



                                                    <td>
                                                        <asp:ImageButton ID="spe12supplierall" runat="server" Height="39px" ImageUrl="~/images/sp_logo.jpg" AlternateText="N Power energy" Width="175px" />
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblspe12programall" runat="server" Text="spe  Energy"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtspe12scall" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox ID="txtspe12dayall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtspe12nightall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtspe12ewall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                    </td>
                                                    <%-- <td>
                                                        <asp:TextBox ID="txtspe12wdall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                    </td>

                                                    <td>
                                                        <asp:TextBox ID="txtspe12unitall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                    </td>--%>
                                                    <td>
                                                        <asp:TextBox ID="txtspe12offpeakall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtspe12otherall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtspe12upliftall" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="2.0" step="0.1" AutoPostBack="true" OnTextChanged="txtspe12upliftall_TextChanged"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtspe12rateall" runat="server" Text="0" Width="75px"></asp:TextBox>

                                                    </td>
                                                    <td>
                                                        <asp:CheckBox ID="chkspe12all" runat="server" />
                                                    </td>
                                                    </td>
                             <td>
                                 <asp:Button ID="Button108" runat="server" Text="Show" />
                             </td>
                                                    <td>
                                                        <asp:Button ID="Button109" runat="server" Text="Save" /></td>



                                                </tr>

                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <tr>
                                            <asp:UpdatePanel ID="UpdatePanel61" runat="server">
                                                <ContentTemplate>







                                                    <td>
                                                        <asp:ImageButton ID="tgp12supplierall" runat="server" Height="39px" ImageUrl="~/images/tglogo.png" Width="175px" />
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lbltgp12programall" runat="server" Text="Total Energy"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txttgp12scall" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox ID="txttgp12dayall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txttgp12nightall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txttgp12ewall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                    </td>
                                                    <%-- <td>
                                                        <asp:TextBox ID="txttgp12wdall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                    </td>

                                                    <td>
                                                        <asp:TextBox ID="txttgp12unitall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                    </td>--%>
                                                    <td>
                                                        <asp:TextBox ID="txttgp12offpeakall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txttgp12otherall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txttgp12upliftall" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="3.0" step="0.1" AutoPostBack="true" OnTextChanged="txttgp12upliftall_TextChanged"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txttgp12rateall" runat="server" Text="0" Width="75px"></asp:TextBox>

                                                    </td>
                                                    <td>
                                                        <asp:CheckBox ID="chktgp12all" runat="server" />
                                                    </td>
                                                    </td>
                             <td>
                                 <asp:Button ID="Button110" runat="server" Text="Show" />
                             </td>
                                                    <td>
                                                        <asp:Button ID="Button111" runat="server" Text="Save" /></td>





                                                    </tr>

                                                </ContentTemplate>
                                            </asp:UpdatePanel>

                                            <asp:UpdatePanel ID="UpdatePanel125" runat="server">
                                                <ContentTemplate>







                                                    <td>
                                                        <asp:ImageButton ID="tgpw12supplierall" runat="server" Height="39px" ImageUrl="~/images/tglogo.png" Width="175px" />
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lbltgpw12programall" runat="server" Text="total energy"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txttgpw12scall" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox ID="txttgpw12dayall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txttgpw12nightall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txttgpw12ewall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                    </td>
                                                    <%-- <td>
                                                        <asp:TextBox ID="txttgpw12wdall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                    </td>

                                                    <td>
                                                        <asp:TextBox ID="txttgpw12unitall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                    </td>--%>
                                                    <td>
                                                        <asp:TextBox ID="txttgpw12offpeakall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txttgpw12otherall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txttgpw12upliftall" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="3.0" step="0.1" AutoPostBack="true"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txttgpw12rateall" runat="server" Text="0" Width="75px"></asp:TextBox>

                                                    </td>
                                                    <td>
                                                        <asp:CheckBox ID="chktgpw12all" runat="server" />
                                                    </td>
                                                    </td>
                             <td>
                                 <asp:Button ID="Button8" runat="server" Text="Show" />
                             </td>
                                                    <td>
                                                        <asp:Button ID="Button9" runat="server" Text="Save" /></td>





                                                    </tr>

                                                </ContentTemplate>
                                            </asp:UpdatePanel>

                                            <asp:UpdatePanel ID="UpdatePanel109" runat="server">
                                                <ContentTemplate>



                                                    <tr>



                                                        <td>
                                                            <asp:ImageButton ID="opus12supplierall" runat="server" Height="39px" ImageUrl="~/images/opus.png" Width="175px" />
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblopus12programall" runat="server" Text="Opus Energy"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtopus12scall" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                                                        <td>
                                                            <asp:TextBox ID="txtopus12dayall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtopus12nightall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                        </td>

                                                        <td>
                                                            <asp:TextBox ID="txtopus12ewall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                        </td>
                                                        <%-- <td>
                                                            <asp:TextBox ID="txtopus12wdall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                        </td>

                                                        <td>
                                                            <asp:TextBox ID="txtopus12unitall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                        </td>--%>
                                                        <td>
                                                            <asp:TextBox ID="txtopus12offpeakall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtopus12otherall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtopus12upliftall" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="1.0" step="0.1" AutoPostBack="true" OnTextChanged="txtopus12upliftall_TextChanged"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtopus12rateall" runat="server" Text="0" Width="75px"></asp:TextBox>

                                                        </td>
                                                        <td>
                                                            <asp:CheckBox ID="chkopus12all" runat="server" />
                                                        </td>
                                                        <td>
                                                            <asp:Button ID="btnopus12Showall" runat="server" Text="Show" />
                                                        </td>
                                                        <td>
                                                            <asp:Button ID="btnopus12Saveall" runat="server" Text="Save" /></td>




                                                    </tr>

                                                </ContentTemplate>
                                            </asp:UpdatePanel>


                                            <asp:UpdatePanel ID="UpdatePanel110" runat="server">
                                                <ContentTemplate>



                                                    <tr>



                                                        <td>
                                                            <asp:ImageButton ID="eon12supplierall" runat="server" Height="39px" ImageUrl="~/images/eon.jpg" Width="175px" />
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lbleon12programall" runat="server" Text="Opus Energy"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txteon12scall" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                                                        <td>
                                                            <asp:TextBox ID="txteon12dayall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txteon12nightall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                        </td>

                                                        <td>
                                                            <asp:TextBox ID="txteon12ewall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                        </td>
                                                        <%-- <td>
                                                            <asp:TextBox ID="txteon12wdall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                        </td>

                                                        <td>
                                                            <asp:TextBox ID="txteon12unitall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                        </td>--%>
                                                        <td>
                                                            <asp:TextBox ID="txteon12offpeakall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txteon12otherall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <%--  <asp:TextBox ID="txteon12upliftall" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="3.0" step="0.1" AutoPostBack="true"></asp:TextBox>--%>
                                                            <asp:DropDownList ID="ddeon12upliftall" runat="server" Width="75px" AutoPostBack="true" OnSelectedIndexChanged="ddeon12upliftall_SelectedIndexChanged">
                                                                <asp:ListItem Selected="True">0.0</asp:ListItem>
                                                                <asp:ListItem>0.1</asp:ListItem>
                                                                <asp:ListItem>0.2</asp:ListItem>
                                                                <asp:ListItem>0.3</asp:ListItem>
                                                                <asp:ListItem>0.4</asp:ListItem>
                                                                <asp:ListItem>0.5</asp:ListItem>
                                                                <asp:ListItem>0.6</asp:ListItem>
                                                                <asp:ListItem>0.7</asp:ListItem>
                                                                <asp:ListItem>0.8</asp:ListItem>
                                                                <asp:ListItem>0.9</asp:ListItem>
                                                                <asp:ListItem>1.0</asp:ListItem>
                                                                <asp:ListItem>1.2</asp:ListItem>
                                                                <asp:ListItem>1.5</asp:ListItem>



                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txteon12rateall" runat="server" Text="0" Width="75px"></asp:TextBox>

                                                        </td>
                                                        <td>
                                                            <asp:CheckBox ID="chkeon12all" runat="server" />
                                                        </td>
                                                        <td>
                                                            <asp:Button ID="btneon12Showall" runat="server" Text="Show" />
                                                        </td>
                                                        <td>
                                                            <asp:Button ID="btneon12Saveall" runat="server" Text="Save" /></td>




                                                    </tr>

                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                            <asp:UpdatePanel ID="UpdatePanel121" runat="server">
                                                <ContentTemplate>



                                                    <tr>



                                                        <td>
                                                            <asp:ImageButton ID="hev12supplierall" runat="server" Height="39px" ImageUrl="~/images/hev.png" Width="175px" />
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblhev12programall" runat="server" Text="Heven power"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txthev12scall" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                                                        <td>
                                                            <asp:TextBox ID="txthev12dayall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txthev12nightall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                        </td>

                                                        <td>
                                                            <asp:TextBox ID="txthev12ewall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                        </td>

                                                        <td>
                                                            <asp:TextBox ID="txthev12offpeakall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txthev12otherall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txthev12upliftall" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="1.0" step="0.1" AutoPostBack="true"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txthev12rateall" runat="server" Text="0" Width="75px"></asp:TextBox>

                                                        </td>
                                                        <td>
                                                            <asp:CheckBox ID="chkhev12all" runat="server" />
                                                        </td>
                                                        <td>
                                                            <asp:Button ID="btnhev12Showall" runat="server" Text="Show" />
                                                        </td>
                                                        <td>
                                                            <asp:Button ID="btnhev12Saveall" runat="server" Text="Save" /></td>




                                                    </tr>

                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                            <asp:UpdatePanel ID="UpdatePanel139" runat="server">
                                                <ContentTemplate>



                                                    <tr>



                                                        <td>
                                                            <asp:ImageButton ID="hevc12supplierall" runat="server" Height="39px" ImageUrl="~/images/hev.png" Width="175px" />
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblhevc12programall" runat="server" Text="hevcen power"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txthevc12scall" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                                                        <td>
                                                            <asp:TextBox ID="txthevc12dayall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txthevc12nightall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                        </td>

                                                        <td>
                                                            <asp:TextBox ID="txthevc12ewall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                        </td>

                                                        <td>
                                                            <asp:TextBox ID="txthevc12offpeakall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txthevc12otherall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txthevc12upliftall" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="1.0" step="0.1" AutoPostBack="true"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txthevc12rateall" runat="server" Text="0" Width="75px"></asp:TextBox>

                                                        </td>
                                                        <td>
                                                            <asp:CheckBox ID="chkhevc12all" runat="server" />
                                                        </td>
                                                        <td>
                                                            <asp:Button ID="btnhevc12Showall" runat="server" Text="Show" />
                                                        </td>
                                                        <td>
                                                            <asp:Button ID="btnhevc12Saveall" runat="server" Text="Save" /></td>




                                                    </tr>

                                                </ContentTemplate>
                                            </asp:UpdatePanel>



                                <asp:UpdatePanel ID="UpdatePanel165" runat="server">
                                    <ContentTemplate>







                                        <td>
                                            <asp:ImageButton ID="utila12supplierall" runat="server" Height="39px" ImageUrl="~/images/utilita.png" Width="175px" />
                                        </td>
                                        <td>
                                            <asp:Label ID="lblutila12programall" runat="server" Text="Utilita Energy new"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtutila12scall" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="txtutila12dayall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtutila12nightall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtutila12ewall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <%-- <td>
                                            <asp:TextBox ID="txtutila12wdall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>

                                        <td>
                                            <asp:TextBox ID="txtutila12unitall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>--%>
                                        <td>
                                            <asp:TextBox ID="txtutila12offpeakall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtutila12otherall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtutila12upliftall" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="1.5" step="0.1" AutoPostBack="true" ></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtutil12Rateall" runat="server" Text="0" Width="75px"></asp:TextBox>

                                        </td>

                                        <td>
                                            <asp:CheckBox ID="chkutil12all" runat="server" />
                                        </td>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnutil12all" runat="server" Text="Show" OnClick="btnutil12allShow_Click" />
                                        </td>
                                        <td>
                                            <asp:Button ID="Button42all" runat="server" Text="Save" /></td>



                                        </tr>

                                    </ContentTemplate>
                                </asp:UpdatePanel>
								
								
								 <asp:UpdatePanel ID="UpdatePanel166" runat="server">
                                    <ContentTemplate>







                                        <td>
                                            <asp:ImageButton ID="gulfa12supplierall" runat="server" Height="39px" ImageUrl="~/images/gulf.png" Width="175px" />
                                        </td>
                                        <td>
                                            <asp:Label ID="lblgulfa12programall" runat="server" Text="Gulf  Energy"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtgulfa12scall" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="txtgulfa12dayall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtgulfa12nightall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtgulfa12ewall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <%-- <td>
                                            <asp:TextBox ID="txtgulfa12wdall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>

                                        <td>
                                            <asp:TextBox ID="txtgulfa12unitall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>--%>
                                        <td>
                                            <asp:TextBox ID="txtgulfa12offpeakall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtgulfa12otherall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtgulfa12upliftall" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="1.5" step="0.1" AutoPostBack="true"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtgulf12Rateall" runat="server" Text="0" Width="75px"></asp:TextBox>

                                        </td>

                                        <td>
                                            <asp:CheckBox ID="chkgulf12all" runat="server" />
                                        </td>
                                        </td>
                                        <td>
                                            <asp:Button ID="btngulf12all" runat="server" Text="Show" OnClick="btngulf12allShow_Click" />
                                        </td>
                                        <td>
                                            <asp:Button ID="Button44all" runat="server" Text="Save" /></td>



                                        </tr>

                                    </ContentTemplate>
                                </asp:UpdatePanel>
								
								  <asp:UpdatePanel ID="UpdatePanel167" runat="server">
                                    <ContentTemplate>







                                        <td>
                                            <asp:ImageButton ID="yuea12supplierall" runat="server" Height="39px" ImageUrl="~/images/yue.jpg" Width="175px" />
                                        </td>
                                        <td>
                                            <asp:Label ID="lblyuea12programall" runat="server" Text="YU Energy"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtyuea12scall" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="txtyuea12dayall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtyuea12nightall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtyuea12ewall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <%-- <td>
                                            <asp:TextBox ID="txtyuea12wdall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>

                                        <td>
                                            <asp:TextBox ID="txtyuea12unitall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>--%>
                                        <td>
                                            <asp:TextBox ID="txtyuea12offpeakall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtyuea12otherall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtyuea12upliftall" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="1.5" step="0.1" AutoPostBack="true" ></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtyue12Rateall" runat="server" Text="0" Width="75px"></asp:TextBox>

                                        </td>

                                        <td>
                                            <asp:CheckBox ID="chkyue12all" runat="server" />
                                        </td>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnyue12all" runat="server" Text="Show" OnClick="btnyue12allShow_Click" />
                                        </td>
                                        <td>
                                            <asp:Button ID="Button46all" runat="server" Text="Save" /></td>



                                        </tr>

                                    </ContentTemplate>
                                </asp:UpdatePanel>







            </table>
            <h3>Rate for 2 years</h3>


            <table class="table table-bordered table-dark">
                <tr>
                    <td>Supplier Name</td>
                    <td>Program Name</td>
                    <td>Standing&nbsp; charge</td>
                    <td>Day Unit Charge</td>
                    <td>Night Unit
                        <br />
                        Charge</td>
                    <td>EVENING<br />
                        WEEKEND UNIT CHARGE</td>
                    <%-- <td>WEEKDAY
                        <br />
                        DAY UNIT<br />
                        CHARGE</td>

                    <td>UNIT Charge</td>--%>
                    <td>OFF PEAK UNIT CHARGE</td>
                    <td>Other Charges </td>
                    <td>Uplift</td>
                    <td>Yearly Charge</td>





                    <td>Mail</td>
                    <td>Show </td>
                    <td>Save</td>





                </tr>
                <asp:UpdatePanel ID="UpdatePanel62" runat="server">
                    <ContentTemplate>



                        <tr>



                            <td>
                                <asp:ImageButton ID="bga24supplierall" runat="server" Height="39px" ImageUrl="~/britishgas.jpg" Width="175px" />
                            </td>
                            <td>
                                <asp:Label ID="lblBga24programall" runat="server" Text="British Gas new"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbga24scall" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txtbga24dayall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbga24nightall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>

                            <td>
                                <asp:TextBox ID="txtbga24ewall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <%--<td>
                                <asp:TextBox ID="txtbga24wdall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>

                            <td>
                                <asp:TextBox ID="txtbga24unitall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>--%>
                            <td>
                                <asp:TextBox ID="txtbga24offpeakall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbga24otherall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbga24upliftall" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="2.0" step="0.1" AutoPostBack="true" OnTextChanged="txtbga24upliftall_TextChanged"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbga24rateall" runat="server" Text="0" Width="75px"></asp:TextBox>

                            </td>
                            <td>
                                <asp:CheckBox ID="chkbga24all" runat="server" />
                            </td>
                            <td>
                                <asp:Button ID="btnbga24Showall" runat="server" Text="Show" />
                            </td>
                            <td>
                                <asp:Button ID="btnBga24Save" runat="server" Text="Save" /></td>




                        </tr>

                    </ContentTemplate>
                </asp:UpdatePanel>

                <tr>

                    <asp:UpdatePanel ID="UpdatePanel63" runat="server">
                        <ContentTemplate>







                            <td>
                                <asp:ImageButton ID="bge24supplierall" runat="server" Height="39px" ImageUrl="~/britishgas.jpg" Width="175px" />
                            </td>
                            <td>
                                <asp:Label ID="lblBge24programall" runat="server" Text="British Gas Re new "></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbge24scall" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txtbge24dayall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbge24nightall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbge24ewall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <%-- <td>
                                <asp:TextBox ID="txtbge24wdall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>

                            <td>
                                <asp:TextBox ID="txtbge24unitall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>--%>
                            <td>
                                <asp:TextBox ID="txtbge24offpeakall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbge24otherall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbge24upliftall" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="2.0" step="0.1" AutoPostBack="true" OnTextChanged="txtbge24upliftall_TextChanged"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbge24rateall" runat="server" Text="0" Width="75px"></asp:TextBox>

                            </td>
                            <td>
                                <asp:CheckBox ID="chkbge24all" runat="server" />
                            </td>
                            </td>
                            <td>
                                <asp:Button ID="btnbge24showall" runat="server" Text="Show" />
                            </td>
                            <td>
                                <asp:Button ID="Button112" runat="server" Text="Save" /></td>



                            </tr>

                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <asp:UpdatePanel ID="UpdatePanel64" runat="server">
                        <ContentTemplate>



                            <tr>



                                <td>
                                    <asp:ImageButton ID="bgl24supplierall" runat="server" Height="39px" ImageUrl="~/images/bgl.png" Width="175px" />
                                </td>
                                <td>
                                    <asp:Label ID="lblbgla24programall" runat="server" Text="British Gas Lite new"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtbgla24scall" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txtbgla24dayall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtbgla24nightall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtbgla24ewall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                </td>
                                <%-- <td>
                                    <asp:TextBox ID="txtbgla24wdall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                </td>

                                <td>
                                    <asp:TextBox ID="txtbgla24unitall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                </td>--%>
                                <td>
                                    <asp:TextBox ID="txtbgla24offpeakall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtbgla24otherall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtbgla24upliftall" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="1.5" step="0.1" AutoPostBack="true" OnTextChanged="txtbgla24upliftall_TextChanged"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtbgla24rateall" runat="server" Text="0" Width="75px"></asp:TextBox>

                                </td>

                                <td>
                                    <asp:CheckBox ID="chkbgla24all" runat="server" />
                                </td>
                                </td>
                                <td>
                                    <asp:Button ID="Button113" runat="server" Text="Show" />
                                </td>
                                <td>
                                    <asp:Button ID="Button114" runat="server" Text="Save" /></td>




                            </tr>

                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <tr>
                        <asp:UpdatePanel ID="UpdatePanel65" runat="server">
                            <ContentTemplate>







                                <td>
                                    <asp:ImageButton ID="bgle24supplierall" runat="server" Height="39px" ImageUrl="~/images/bgl.png" Width="175px" />
                                </td>
                                <td>
                                    <asp:Label ID="lblbgle24programall" runat="server" Text="British Gas Lite new"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtbgle24scall" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txtbgle24dayall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtbgle24nightall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtbgle24ewall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                </td>
                                <%-- <td>
                                    <asp:TextBox ID="txtbgle24wdall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                </td>

                                <td>
                                    <asp:TextBox ID="txtbgle24unitall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                </td>--%>
                                <td>
                                    <asp:TextBox ID="txtbgle24offpeakall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtbgle24otherall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtbgle24upliftall" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="1.5" step="0.1" AutoPostBack="true" OnTextChanged="txtbgle24upliftall_TextChanged"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtbgle24rateall" runat="server" Text="0" Width="75px"></asp:TextBox>

                                </td>

                                <td>
                                    <asp:CheckBox ID="chkbgle24all" runat="server" />
                                </td>
                                <td>
                                    <asp:Button ID="Button115" runat="server" Text="Show" />
                                </td>
                                <td>
                                    <asp:Button ID="Button116" runat="server" Text="Save" /></td>





                                </tr>

                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <tr>

                            <asp:UpdatePanel ID="UpdatePanel66" runat="server">
                                <ContentTemplate>







                                    <td>
                                        <asp:ImageButton ID="edfa24supplierall" runat="server" Height="39px" ImageUrl="~/images/edf.jpg" Width="175px" />
                                    </td>
                                    <td>
                                        <asp:Label ID="lbledfa24programall" runat="server" Text="British Gas Lite new"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtedfa24scall" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                                    <td>
                                        <asp:TextBox ID="txtedfa24dayall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtedfa24nightall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtedfa24ewall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                    </td>
                                    <%--<td>
                                        <asp:TextBox ID="txtedfa24wdall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                    </td>

                                    <td>
                                        <asp:TextBox ID="txtedfa24unitall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                    </td>--%>
                                    <td>
                                        <asp:TextBox ID="txtedfa24offpeakall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtedfa24otherall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtedfa24upliftall" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="1.5" step="0.1" AutoPostBack="true" OnTextChanged="txtedfa24upliftall_TextChanged"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtedf24rateall" runat="server" Text="0" Width="75px"></asp:TextBox>

                                    </td>

                                    <td>
                                        <asp:CheckBox ID="chkedf24all" runat="server" />
                                    </td>
                                    </td>
                                    <td>
                                        <asp:Button ID="Button117" runat="server" Text="Show" />
                                    </td>
                                    <td>
                                        <asp:Button ID="Button118" runat="server" Text="Save" /></td>



                                    </tr>

                                </ContentTemplate>
                            </asp:UpdatePanel>

                            <asp:UpdatePanel ID="UpdatePanel67" runat="server">
                                <ContentTemplate>



                                    <tr>



                                        <td>
                                            <asp:ImageButton ID="dea24supplier24all" runat="server" Height="39px" ImageUrl="~/images/de.jpg" Width="175px" />
                                        </td>
                                        <td>
                                            <asp:Label ID="lbldea24program24all" runat="server" Text="British Gas Lite new"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtdea24sc24all" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="txtdea24day24all" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtdea24night24all" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtdea24ew24all" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <%-- <td>
                                            <asp:TextBox ID="txtdea24wd24all" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>

                                        <td>
                                            <asp:TextBox ID="txtdea24unit24all" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>--%>
                                        <td>
                                            <asp:TextBox ID="txtdea24offpeak24all" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtdea24other24all" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtdea24uplift24all" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="3.0" step="0.1" AutoPostBack="true" OnTextChanged="txtdea24uplift24all_TextChanged"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtdea24all" runat="server" Text="0" Width="75px"></asp:TextBox>

                                        </td>

                                        <td>
                                            <asp:CheckBox ID="chkdea24all" runat="server" />
                                        </td>
                                        <td>
                                            <asp:Button ID="btndea24showall" runat="server" Text="Show" />
                                        </td>
                                        <td>
                                            <asp:Button ID="btndea24saveall" runat="server" Text="Save" /></td>



                                    </tr>

                                </ContentTemplate>
                            </asp:UpdatePanel>

                            <asp:UpdatePanel ID="UpdatePanel146" runat="server">
                                <ContentTemplate>



                                    <tr>



                                        <td>
                                            <asp:ImageButton ID="deawc24supplier24all" runat="server" Height="39px" ImageUrl="~/images/de.jpg" Width="175px" />
                                        </td>
                                        <td>
                                            <asp:Label ID="lbldeawc24program24all" runat="server" Text="British Gas Lite new"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtdeawc24sc24all" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="txtdeawc24day24all" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtdeawc24night24all" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtdeawc24ew24all" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <%-- <td>
                                            <asp:TextBox ID="txtdeawc24wd24all" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>

                                        <td>
                                            <asp:TextBox ID="txtdeawc24unit24all" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>--%>
                                        <td>
                                            <asp:TextBox ID="txtdeawc24offpeak24all" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtdeawc24other24all" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtdeawc24uplift24all" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="2.0" step="0.1" AutoPostBack="true"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtdeawc24all" runat="server" Text="0" Width="75px"></asp:TextBox>

                                        </td>

                                        <td>
                                            <asp:CheckBox ID="chkdeawc24all" runat="server" />
                                        </td>

                                        <td>
                                            <asp:Button ID="btndeawc24showall" runat="server" Text="Show" />
                                        </td>
                                        <td>
                                            <asp:Button ID="btndeawc24saveall" runat="server" Text="Save" /></td>



                                    </tr>

                                </ContentTemplate>
                            </asp:UpdatePanel>

                            <tr>
                                <asp:UpdatePanel ID="UpdatePanel68" runat="server">
                                    <ContentTemplate>







                                        <td>
                                            <asp:ImageButton ID="pe24supplierall" runat="server" Height="39px" ImageUrl="~/images/positive.jpg" Width="175px" />
                                        </td>
                                        <td>
                                            <asp:Label ID="lblpe24programall" runat="server" Text="Positive Energy"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtpe24scall" runat="server" Width="75px" Text="0"></asp:TextBox>

                                        </td>

                                        <td>
                                            <asp:TextBox ID="txtpe24dayall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>

                                        <td>
                                            <asp:TextBox ID="txtpe24nightall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtpe24ewall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <%-- <td>
                                            <asp:TextBox ID="txtpe24wdall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                      
                                      

                                      
                                        <td>
                                            <asp:TextBox ID="txtpe24unitall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>  --%>
                                        <td>
                                            <asp:TextBox ID="txtpe24offpeakall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtpe24otherall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtpe24upliftall" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="3.0" step="0.1" AutoPostBack="true" OnTextChanged="txtpe24upliftall_TextChanged"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtpe24rateall" runat="server" Text="0" Width="75px"></asp:TextBox>

                                        </td>

                                        <td>
                                            <asp:CheckBox ID="chkpe24all" runat="server" />
                                        </td>
                                        </td>
                                        <td>
                                            <asp:Button ID="Button121" runat="server" Text="Show" />
                                        </td>
                                        <td>
                                            <asp:Button ID="Button122" runat="server" Text="Save" /></td>




                                        </tr>

                                    </ContentTemplate>
                                </asp:UpdatePanel>

                                <asp:UpdatePanel ID="UpdatePanel69" runat="server">
                                    <ContentTemplate>



                                        <tr>



                                            <td>
                                                <asp:ImageButton ID="gaz24supplierall" runat="server" Height="39px" ImageUrl="~/images/gaz.png" AlternateText="Gaz Prom " Width="175px" />
                                            </td>
                                            <td>
                                                <asp:Label ID="lblgaz24programall" runat="server" Text="Gaz  Energy"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtgaz24scall" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox ID="txtgaz24dayall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtgaz24nightall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtgaz24ewall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                            </td>
                                            <%-- <td>
                                            <asp:TextBox ID="txtgaz24wdall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>

                                        <td>
                                            <asp:TextBox ID="txtgaz24unitall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>--%>
                                            <td>
                                                <asp:TextBox ID="txtgaz24offpeakall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtgaz24otherall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtgaz24upliftall" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="2.0" step="0.1" AutoPostBack="true" OnTextChanged="txtgaz24upliftall_TextChanged"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtgaz24rateall" runat="server" Text="0" Width="75px"></asp:TextBox>

                                            </td>

                                            <td>
                                                <asp:CheckBox ID="chkgaz24all" runat="server" />
                                            </td>
                                            </td>
                                        <td>
                                            <asp:Button ID="Button123" runat="server" Text="Show" />
                                        </td>
                                            <td>
                                                <asp:Button ID="Button124" runat="server" Text="Save" /></td>




                                        </tr>

                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <tr>
                                    <asp:UpdatePanel ID="UpdatePanelsseall" runat="server">
                                        <ContentTemplate>







                                            <td>
                                                <asp:ImageButton ID="sse24supplierall" runat="server" Height="39px" ImageUrl="~/images/sse.jpg" AlternateText="sse energy" Width="175px" />
                                            </td>
                                            <td>
                                                <asp:Label ID="lblsse24programall" runat="server" Text="sse  Energy"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtsse24scamrall" runat="server" Width="75px" Text="0"></asp:TextBox>
                                                <asp:TextBox ID="txtsse24scnonamrall" runat="server" Width="75px" Text="0"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtsse24dayall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtsse24nightall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtsse24ewall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                            </td>
                                            <%--  <td>
                                                <asp:TextBox ID="txtsse24wdall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                            </td>

                                            <td>
                                                <asp:TextBox ID="txtsse24unitall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                            </td>--%>
                                            <td>
                                                <asp:TextBox ID="txtsse24offpeakall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtsse24otherall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="chksse24all" runat="server" />
                                                <asp:CheckBox ID="chksse24rtenormal" runat="server" />
                                            </td>

                                            <td>
                                                <asp:TextBox ID="txtsse24upliftall" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="2.0" step="0.1" AutoPostBack="true" OnTextChanged="txtsse24upliftall_TextChanged"></asp:TextBox>
                                                <asp:TextBox ID="txtsse24upliftnonamrall" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="2.0" step="0.1" AutoPostBack="true" OnTextChanged="txtsse24upliftnonamrall_TextChanged"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtsse24rateall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                <asp:TextBox ID="txtsse24ratenonamrall" runat="server" Text="0" Width="75px"></asp:TextBox>

                                            </td>


                                            <td>
                                                <asp:Button ID="Button125" runat="server" Text="Show" />
                                            </td>
                                            <td>
                                                <asp:Button ID="Button126" runat="server" Text="Save" /></td>



                                            </tr>

                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <tr>
                                        <asp:UpdatePanel ID="UpdatePanel71" runat="server">
                                            <ContentTemplate>







                                                <td>
                                                    <asp:ImageButton ID="npra24supplierall" runat="server" Height="39px" ImageUrl="~/images/npower.jpg" AlternateText="N Power energy" Width="175px" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblnpra24programall" runat="server" Text="npra  Energy"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtnpra24scall" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                                                <td>
                                                    <asp:TextBox ID="txtnpra24dayall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtnpra24nightall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtnpra24ewall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                </td>
                                                <%--   <td>
                                                <asp:TextBox ID="txtnpra24wdall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                            </td>

                                            <td>
                                                <asp:TextBox ID="txtnpra24unitall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                            </td>--%>
                                                <td>
                                                    <asp:TextBox ID="txtnpra24offpeakall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtnpra24otherall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtnpra24upliftall" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="3.0" step="0.1" AutoPostBack="true" OnTextChanged="txtnpra24upliftall_TextChanged"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtnpra24rateall" runat="server" Text="0" Width="75px"></asp:TextBox>

                                                </td>

                                                <td>
                                                    <asp:CheckBox ID="chknpower24all" runat="server" />
                                                </td>
                                                </td>
                                            <td>
                                                <asp:Button ID="Button127" runat="server" Text="Show" />
                                            </td>
                                                <td>
                                                    <asp:Button ID="Button128" runat="server" Text="Save" /></td>



                                                </tr>

                                            </ContentTemplate>
                                        </asp:UpdatePanel>

                                        <tr>
                                            <asp:UpdatePanel ID="UpdatePanel72" runat="server">
                                                <ContentTemplate>







                                                    <td>
                                                        <asp:ImageButton ID="spe24supplierall" runat="server" Height="39px" ImageUrl="~/images/sp_logo.jpg" AlternateText="N Power energy" Width="175px" />
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblspe24programall" runat="server" Text="spe  Energy"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtspe24scall" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox ID="txtspe24dayall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtspe24nightall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtspe24ewall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                    </td>
                                                    <%-- <td>
                                                    <asp:TextBox ID="txtspe24wdall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                </td>

                                                <td>
                                                    <asp:TextBox ID="txtspe24unitall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                </td>--%>
                                                    <td>
                                                        <asp:TextBox ID="txtspe24offpeakall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtspe24otherall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtspe24upliftall" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="2.0" step="0.1" AutoPostBack="true" OnTextChanged="txtspe24upliftall_TextChanged"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtspe24rateall" runat="server" Text="0" Width="75px"></asp:TextBox>

                                                    </td>
                                                    <td>
                                                        <asp:CheckBox ID="chkspe24all" runat="server" />
                                                    </td>
                                                    </td>
                                                <td>
                                                    <asp:Button ID="Button129" runat="server" Text="Show" />
                                                </td>
                                                    <td>
                                                        <asp:Button ID="Button130" runat="server" Text="Save" /></td>



                                                    </tr>

                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                            <tr>
                                                <asp:UpdatePanel ID="UpdatePanel73" runat="server">
                                                    <ContentTemplate>







                                                        <td>
                                                            <asp:ImageButton ID="tgp24supplierall" runat="server" Height="39px" ImageUrl="~/images/tglogo.png" Width="175px" />
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lbltgp24programall" runat="server" Text="Total Energy"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txttgp24scall" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                                                        <td>
                                                            <asp:TextBox ID="txttgp24dayall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txttgp24nightall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txttgp24ewall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                        </td>
                                                        <%--<td>
                                                        <asp:TextBox ID="txttgp24wdall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                    </td>

                                                    <td>
                                                        <asp:TextBox ID="txttgp24unitall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                    </td>--%>
                                                        <td>
                                                            <asp:TextBox ID="txttgp24offpeakall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txttgp24otherall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txttgp24upliftall" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="3.0" step="0.1" AutoPostBack="true" OnTextChanged="txttgp24upliftall_TextChanged"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txttgp24rateall" runat="server" Text="0" Width="75px"></asp:TextBox>

                                                        </td>
                                                        <td>
                                                            <asp:CheckBox ID="chktgp24all" runat="server" />
                                                        </td>
                                                        </td>
                                <td>
                                    <asp:Button ID="Button131" runat="server" Text="Show" />
                                </td>
                                                        <td>
                                                            <asp:Button ID="Button132" runat="server" Text="Save" /></td>





                                                        </tr>

                                                    </ContentTemplate>
                                                </asp:UpdatePanel>


                                                <asp:UpdatePanel ID="UpdatePanel126" runat="server">
                                                    <ContentTemplate>







                                                        <td>
                                                            <asp:ImageButton ID="tgpw24supplierall" runat="server" Height="39px" ImageUrl="~/images/tglogo.png" Width="175px" />
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lbltgpw24programall" runat="server" Text="Total Energy"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txttgpw24scall" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                                                        <td>
                                                            <asp:TextBox ID="txttgpw24dayall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txttgpw24nightall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txttgpw24ewall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                        </td>
                                                        <%-- <td>
                                                        <asp:TextBox ID="txttgpw24wdall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                    </td>

                                                    <td>
                                                        <asp:TextBox ID="txttgpw24unitall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                    </td>--%>
                                                        <td>
                                                            <asp:TextBox ID="txttgpw24offpeakall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txttgpw24otherall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txttgpw24upliftall" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="3.0" step="0.1" AutoPostBack="true"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txttgpw24rateall" runat="server" Text="0" Width="75px"></asp:TextBox>

                                                        </td>
                                                        <td>
                                                            <asp:CheckBox ID="chktgpw24all" runat="server" />
                                                        </td>
                                                        </td>
                             <td>
                                 <asp:Button ID="Button10" runat="server" Text="Show" />
                             </td>
                                                        <td>
                                                            <asp:Button ID="Button11" runat="server" Text="Save" /></td>





                                                        </tr>

                                                    </ContentTemplate>
                                                </asp:UpdatePanel>


                                                <asp:UpdatePanel ID="UpdatePanel111" runat="server">
                                                    <ContentTemplate>



                                                        <tr>



                                                            <td>
                                                                <asp:ImageButton ID="opus24supplierall" runat="server" Height="39px" ImageUrl="~/images/opus.png" Width="175px" />
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblopus24programall" runat="server" Text="Opus Energy"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtopus24scall" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                                                            <td>
                                                                <asp:TextBox ID="txtopus24dayall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtopus24nightall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                            </td>

                                                            <td>
                                                                <asp:TextBox ID="txtopus24ewall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                            </td>
                                                            <%-- <td>
                                                            <asp:TextBox ID="txtopus24wdall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                        </td>

                                                        <td>
                                                            <asp:TextBox ID="txtopus24unitall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                        </td>--%>
                                                            <td>
                                                                <asp:TextBox ID="txtopus24offpeakall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtopus24otherall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtopus24upliftall" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="3.0" step="0.1" AutoPostBack="true" OnTextChanged="txtopus24upliftall_TextChanged"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtopus24rateall" runat="server" Text="0" Width="75px"></asp:TextBox>

                                                            </td>
                                                            <td>
                                                                <asp:CheckBox ID="chkopus24all" runat="server" />
                                                            </td>
                                                            <td>
                                                                <asp:Button ID="btnopus24Showall" runat="server" Text="Show" />
                                                            </td>
                                                            <td>
                                                                <asp:Button ID="btnopus24Saveall" runat="server" Text="Save" /></td>




                                                        </tr>

                                                    </ContentTemplate>
                                                </asp:UpdatePanel>


                                                <asp:UpdatePanel ID="UpdatePanel112" runat="server">
                                                    <ContentTemplate>



                                                        <tr>



                                                            <td>
                                                                <asp:ImageButton ID="eon24supplierall" runat="server" Height="39px" ImageUrl="~/images/eon.jpg" Width="175px" />
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lbleon24programall" runat="server" Text="Eone  energy "></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txteon24scall" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                                                            <td>
                                                                <asp:TextBox ID="txteon24dayall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txteon24nightall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                            </td>


                                                            <td>
                                                                <asp:TextBox ID="txteon24ewall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                            </td>
                                                            <%-- <td>
                                                                <asp:TextBox ID="txteon24wdall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                            </td>

                                                            <asp:TextBox ID="txteon24unitall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                        </td>--%>
                                                            <td>
                                                                <asp:TextBox ID="txteon24offpeakall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txteon24otherall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <%--  <asp:TextBox ID="txteon24upliftall" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="3.0" step="0.1" AutoPostBack="true"></asp:TextBox>--%>
                                                                <asp:DropDownList ID="ddeon24upliftall" runat="server" Width="75px" AutoPostBack="true" OnSelectedIndexChanged="ddeon24upliftall_SelectedIndexChanged">
                                                                    <asp:ListItem Selected="True">0.0</asp:ListItem>
                                                                    <asp:ListItem>0.1</asp:ListItem>
                                                                    <asp:ListItem>0.2</asp:ListItem>
                                                                    <asp:ListItem>0.3</asp:ListItem>
                                                                    <asp:ListItem>0.4</asp:ListItem>
                                                                    <asp:ListItem>0.5</asp:ListItem>
                                                                    <asp:ListItem>0.6</asp:ListItem>
                                                                    <asp:ListItem>0.7</asp:ListItem>
                                                                    <asp:ListItem>0.8</asp:ListItem>
                                                                    <asp:ListItem>0.9</asp:ListItem>
                                                                    <asp:ListItem>1.0</asp:ListItem>
                                                                    <asp:ListItem>1.2</asp:ListItem>
                                                                    <asp:ListItem>1.5</asp:ListItem>



                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txteon24rateall" runat="server" Text="0" Width="75px"></asp:TextBox>

                                                            </td>
                                                            <td>
                                                                <asp:CheckBox ID="chkeon24all" runat="server" />
                                                            </td>
                                                            <td>
                                                                <asp:Button ID="btneon24Showall" runat="server" Text="Show" />
                                                            </td>
                                                            <td>
                                                                <asp:Button ID="btneon24Saveall" runat="server" Text="Save" /></td>




                                                        </tr>

                                                    </ContentTemplate>
                                                </asp:UpdatePanel>


                                                <asp:UpdatePanel ID="UpdatePanel122" runat="server">
                                                    <ContentTemplate>



                                                        <tr>



                                                            <td>
                                                                <asp:ImageButton ID="hev24supplierall" runat="server" Height="39px" ImageUrl="~/images/hev.png" Width="175px" />
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblhev24programall" runat="server" Text="Heven power"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txthev24scall" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                                                            <td>
                                                                <asp:TextBox ID="txthev24dayall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txthev24nightall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                            </td>

                                                            <td>
                                                                <asp:TextBox ID="txthev24ewall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                            </td>
                                                            <%-- <td>
                                                                <asp:TextBox ID="txthev24wdall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                            </td>

                                                            <td>
                                                                <asp:TextBox ID="txthev24unitall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                            </td>--%>
                                                            <td>
                                                                <asp:TextBox ID="txthev24offpeakall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txthev24otherall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txthev24upliftall" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="1.0" step="0.1" AutoPostBack="true"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txthev24rateall" runat="server" Text="0" Width="75px"></asp:TextBox>

                                                            </td>
                                                            <td>
                                                                <asp:CheckBox ID="chkhev24all" runat="server" />
                                                            </td>
                                                            <td>
                                                                <asp:Button ID="btnhev24Showall" runat="server" Text="Show" />
                                                            </td>
                                                            <td>
                                                                <asp:Button ID="btnhev24Saveall" runat="server" Text="Save" /></td>




                                                        </tr>

                                                    </ContentTemplate>
                                                </asp:UpdatePanel>

                                                <asp:UpdatePanel ID="UpdatePanel241" runat="server">
                                                    <ContentTemplate>



                                                        <tr>



                                                            <td>
                                                                <asp:ImageButton ID="hevc24supplierall" runat="server" Height="39px" ImageUrl="~/images/hev.png" Width="175px" />
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblhevc24programall" runat="server" Text="hevcen power"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txthevc24scall" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                                                            <td>
                                                                <asp:TextBox ID="txthevc24dayall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txthevc24nightall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                            </td>

                                                            <td>
                                                                <asp:TextBox ID="txthevc24ewall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                            </td>

                                                            <td>
                                                                <asp:TextBox ID="txthevc24offpeakall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txthevc24otherall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txthevc24upliftall" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="1.0" step="0.1" AutoPostBack="true"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txthevc24rateall" runat="server" Text="0" Width="75px"></asp:TextBox>

                                                            </td>
                                                            <td>
                                                                <asp:CheckBox ID="chkhevc24all" runat="server" />
                                                            </td>
                                                            <td>
                                                                <asp:Button ID="btnhevc24Showall" runat="server" Text="Show" />
                                                            </td>
                                                            <td>
                                                                <asp:Button ID="btnhevc24Saveall" runat="server" Text="Save" /></td>




                                                        </tr>

                                                    </ContentTemplate>
                                                </asp:UpdatePanel>


                                <asp:UpdatePanel ID="UpdatePanel168" runat="server">
                                    <ContentTemplate>







                                        <td>
                                            <asp:ImageButton ID="utila24supplierall" runat="server" Height="39px" ImageUrl="~/images/utilita.png" Width="175px" />
                                        </td>
                                        <td>
                                            <asp:Label ID="lblutila24programall" runat="server" Text="Utilita Energy new"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtutila24scall" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="txtutila24dayall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtutila24nightall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtutila24ewall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <%-- <td>
                                            <asp:TextBox ID="txtutila24wdall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>

                                        <td>
                                            <asp:TextBox ID="txtutila24unitall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>--%>
                                        <td>
                                            <asp:TextBox ID="txtutila24offpeakall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtutila24otherall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtutila24upliftall" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="1.5" step="0.1" AutoPostBack="true" ></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtutil24Rateall" runat="server" Text="0" Width="75px"></asp:TextBox>

                                        </td>

                                        <td>
                                            <asp:CheckBox ID="chkutil24all" runat="server" />
                                        </td>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnutil24all" runat="server" Text="Show" OnClick="btnutil24allShow_Click" />
                                        </td>
                                        <td>
                                            <asp:Button ID="Button76" runat="server" Text="Save" /></td>



                                        </tr>

                                    </ContentTemplate>
                                </asp:UpdatePanel>
								
								
								 <asp:UpdatePanel ID="UpdatePanel169" runat="server">
                                    <ContentTemplate>







                                        <td>
                                            <asp:ImageButton ID="gulfa24supplierall" runat="server" Height="39px" ImageUrl="~/images/gulf.png" Width="175px" />
                                        </td>
                                        <td>
                                            <asp:Label ID="lblgulfa24programall" runat="server" Text="Gulf  Energy"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtgulfa24scall" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="txtgulfa24dayall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtgulfa24nightall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtgulfa24ewall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <%-- <td>
                                            <asp:TextBox ID="txtgulfa24wdall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>

                                        <td>
                                            <asp:TextBox ID="txtgulfa24unitall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>--%>
                                        <td>
                                            <asp:TextBox ID="txtgulfa24offpeakall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtgulfa24otherall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtgulfa24upliftall" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="1.5" step="0.1" AutoPostBack="true"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtgulf24Rateall" runat="server" Text="0" Width="75px"></asp:TextBox>

                                        </td>

                                        <td>
                                            <asp:CheckBox ID="chkgulf24all" runat="server" />
                                        </td>
                                        </td>
                                        <td>
                                            <asp:Button ID="btngulf24all" runat="server" Text="Show" OnClick="btngulf24allShow_Click" />
                                        </td>
                                        <td>
                                            <asp:Button ID="Button77" runat="server" Text="Save" /></td>



                                        </tr>

                                    </ContentTemplate>
                                </asp:UpdatePanel>
								
								  <asp:UpdatePanel ID="UpdatePanel170" runat="server">
                                    <ContentTemplate>







                                        <td>
                                            <asp:ImageButton ID="yuea24supplierall" runat="server" Height="39px" ImageUrl="~/images/yue.jpg" Width="175px" />
                                        </td>
                                        <td>
                                            <asp:Label ID="lblyuea24programall" runat="server" Text="YU Energy"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtyuea24scall" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="txtyuea24dayall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtyuea24nightall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtyuea24ewall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <%-- <td>
                                            <asp:TextBox ID="txtyuea24wdall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>

                                        <td>
                                            <asp:TextBox ID="txtyuea24unitall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>--%>
                                        <td>
                                            <asp:TextBox ID="txtyuea24offpeakall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtyuea24otherall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtyuea24upliftall" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="1.5" step="0.1" AutoPostBack="true" ></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtyue24Rateall" runat="server" Text="0" Width="75px"></asp:TextBox>

                                        </td>

                                        <td>
                                            <asp:CheckBox ID="chkyue24all" runat="server" />
                                        </td>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnyue24all" runat="server" Text="Show" OnClick="btnyue24allShow_Click" />
                                        </td>
                                        <td>
                                            <asp:Button ID="Button78" runat="server" Text="Save" /></td>



                                        </tr>

                                    </ContentTemplate>
                                </asp:UpdatePanel>






            </table>

            <h3>Rate for 3 years</h3>



            <table class="table table-bordered table-dark">
                <tr>
                    <td>Supplier Name</td>
                    <td>Program Name</td>
                    <td>Standing&nbsp; charge</td>
                    <td>Day Unit Charge</td>
                    <td>Night Unit
                         <br />
                        Charge</td>
                    <td>EVENING<br />
                        WEEKEND UNIT CHARGE</td>
                    <%-- <td>WEEKDAY
                         <br />
                        DAY UNIT<br />
                        CHARGE</td>

                    <td>UNIT Charge</td>--%>
                    <td>OFF PEAK UNIT CHARGE</td>
                    <td>Other Charges </td>
                    <td>Uplift</td>
                    <td>Yearly Charge</td>





                    <td>Mail</td>
                    <td>Show </td>
                    <td>Save</td>





                </tr>
                <asp:UpdatePanel ID="UpdatePanel74" runat="server">
                    <ContentTemplate>



                        <tr>



                            <td>
                                <asp:ImageButton ID="bga36supplierall" runat="server" Height="39px" ImageUrl="~/britishgas.jpg" Width="175px" />
                            </td>
                            <td>
                                <asp:Label ID="lblBga36programall" runat="server" Text="British Gas new"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbga36scall" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txtbga36dayall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbga36nightall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>

                            <td>
                                <asp:TextBox ID="txtbga36ewall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <%--   <td>
                                <asp:TextBox ID="txtbga36wdall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>

                            <td>
                                <asp:TextBox ID="txtbga36unitall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>--%>
                            <td>
                                <asp:TextBox ID="txtbga36offpeakall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbga36otherall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbga36upliftall" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="2.0" step="0.1" AutoPostBack="true" OnTextChanged="txtbga36upliftall_TextChanged"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbga36rateall" runat="server" Text="0" Width="75px"></asp:TextBox>

                            </td>
                            <td>
                                <asp:CheckBox ID="chkbga36all" runat="server" />
                            </td>
                            <td>
                                <asp:Button ID="btnbga36Showall" runat="server" Text="Show" />
                            </td>
                            <td>
                                <asp:Button ID="btnBga36Save" runat="server" Text="Save" /></td>




                        </tr>

                    </ContentTemplate>

                </asp:UpdatePanel>


                <tr>
                    <asp:UpdatePanel ID="UpdatePanel75" runat="server">
                        <ContentTemplate>







                            <td>
                                <asp:ImageButton ID="bge36supplierall" runat="server" Height="39px" ImageUrl="~/britishgas.jpg" Width="175px" />
                            </td>
                            <td>
                                <asp:Label ID="lblBge36programall" runat="server" Text="British Gas Re new "></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbge36scall" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txtbge36dayall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbge36nightall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbge36ewall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <%-- <td>
                                <asp:TextBox ID="txtbge36wdall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>

                            <td>
                                <asp:TextBox ID="txtbge36unitall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>--%>
                            <td>
                                <asp:TextBox ID="txtbge36offpeakall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbge36otherall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbge36upliftall" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="2.0" step="0.1" AutoPostBack="true" OnTextChanged="txtbge36upliftall_TextChanged"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbge36rateall" runat="server" Text="0" Width="75px"></asp:TextBox>

                            </td>
                            <td>
                                <asp:CheckBox ID="chkbge36all" runat="server" />
                            </td>
                            </td>
                             <td>
                                 <asp:Button ID="btnbge36showall" runat="server" Text="Show" />
                             </td>
                            <td>
                                <asp:Button ID="Button133" runat="server" Text="Save" /></td>



                            </tr>

                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <asp:UpdatePanel ID="UpdatePanel76" runat="server">
                        <ContentTemplate>



                            <tr>



                                <td>
                                    <asp:ImageButton ID="bgl36supplierall" runat="server" Height="39px" ImageUrl="~/images/bgl.png" Width="175px" />
                                </td>
                                <td>
                                    <asp:Label ID="lblbgla36programall" runat="server" Text="British Gas Lite new"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtbgla36scall" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txtbgla36dayall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtbgla36nightall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtbgla36ewall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                </td>
                                <%--   <td>
                                    <asp:TextBox ID="txtbgla36wdall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                </td>

                                <td>
                                    <asp:TextBox ID="txtbgla36unitall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                </td>--%>
                                <td>
                                    <asp:TextBox ID="txtbgla36offpeakall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtbgla36otherall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtbgla36upliftall" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="1.5" step="0.1" AutoPostBack="true" OnTextChanged="txtbgla36upliftall_TextChanged"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtbgla36rateall" runat="server" Text="0" Width="75px"></asp:TextBox>

                                </td>

                                <td>
                                    <asp:CheckBox ID="chkbgla36all" runat="server" />
                                </td>

                                <td>
                                    <asp:Button ID="Button134" runat="server" Text="Show" />
                                </td>
                                <td>
                                    <asp:Button ID="Button135" runat="server" Text="Save" /></td>




                            </tr>

                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <tr>
                        <asp:UpdatePanel ID="UpdatePanel77" runat="server">
                            <ContentTemplate>







                                <td>
                                    <asp:ImageButton ID="bgle36supplierall" runat="server" Height="39px" ImageUrl="~/images/bgl.png" Width="175px" />
                                </td>
                                <td>
                                    <asp:Label ID="lblbgle36programall" runat="server" Text="British Gas Lite new"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtbgle36scall" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txtbgle36dayall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtbgle36nightall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtbgle36ewall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                </td>
                                <%--   <td>
                                    <asp:TextBox ID="txtbgle36wdall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                </td>

                                <td>
                                    <asp:TextBox ID="txtbgle36unitall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                </td>--%>
                                <td>
                                    <asp:TextBox ID="txtbgle36offpeakall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtbgle36otherall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtbgle36upliftall" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="1.5" step="0.1" AutoPostBack="true" OnTextChanged="txtbgle36upliftall_TextChanged"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtbgle36rateall" runat="server" Text="0" Width="75px"></asp:TextBox>

                                </td>

                                <td>
                                    <asp:CheckBox ID="chkbgle36all" runat="server" />
                                </td>
                                </td>
                             <td>
                                 <asp:Button ID="Button136" runat="server" Text="Show" />
                             </td>
                                <td>
                                    <asp:Button ID="Button137" runat="server" Text="Save" /></td>





                                </tr>

                            </ContentTemplate>
                        </asp:UpdatePanel>

                        <tr>
                            <asp:UpdatePanel ID="UpdatePanel78" runat="server">
                                <ContentTemplate>







                                    <td>
                                        <asp:ImageButton ID="edfa36supplierall" runat="server" Height="39px" ImageUrl="~/images/edf.jpg" Width="175px" />
                                    </td>
                                    <td>
                                        <asp:Label ID="lbledfa36programall" runat="server" Text="British Gas Lite new"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtedfa36scall" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                                    <td>
                                        <asp:TextBox ID="txtedfa36dayall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtedfa36nightall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtedfa36ewall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                    </td>
                                    <%--  <td>
                                        <asp:TextBox ID="txtedfa36wdall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                    </td>

                                    <td>
                                        <asp:TextBox ID="txtedfa36unitall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                    </td>--%>
                                    <td>
                                        <asp:TextBox ID="txtedfa36offpeakall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtedfa36otherall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtedfa36upliftall" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="1.5" step="0.1" AutoPostBack="true" OnTextChanged="txtedfa36upliftall_TextChanged"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtedf36rateall" runat="server" Text="0" Width="75px"></asp:TextBox>

                                    </td>

                                    <td>
                                        <asp:CheckBox ID="chkedf36all" runat="server" />
                                    </td>
                                    </td>
                             <td>
                                 <asp:Button ID="Button138" runat="server" Text="Show" />
                             </td>
                                    <td>
                                        <asp:Button ID="Button139" runat="server" Text="Save" /></td>



                                    </tr>

                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <tr>
                                <asp:UpdatePanel ID="UpdatePanel79" runat="server">
                                    <ContentTemplate>







                                        <td>
                                            <asp:ImageButton ID="dea36supplier36" runat="server" Height="39px" ImageUrl="~/images/de.jpg" Width="175px" />
                                        </td>
                                        <td>
                                            <asp:Label ID="lbldea36programall" runat="server" Text="British Gas Lite new"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtdea36scall" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="txtdea36dayall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtdea36nightall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtdea36ewall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <%--   <td>
                                            <asp:TextBox ID="txtdea36wdall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>

                                        <td>
                                            <asp:TextBox ID="txtdea36unitall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>--%>
                                        <td>
                                            <asp:TextBox ID="txtdea36offpeakall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtdea36otherall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtdea36uplift1ll" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="2.0" step="0.1" AutoPostBack="true" OnTextChanged="txtdea36uplift1ll_TextChanged"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtdea36all" runat="server" Text="0" Width="75px"></asp:TextBox>

                                        </td>

                                        <td>
                                            <asp:CheckBox ID="chkdea36all" runat="server" />
                                        </td>
                                        </td>
                             <td>
                                 <asp:Button ID="Button140" runat="server" Text="Show" />
                             </td>
                                        <td>
                                            <asp:Button ID="Button141" runat="server" Text="Save" /></td>



                                        </tr>

                                    </ContentTemplate>
                                </asp:UpdatePanel>


                                <asp:UpdatePanel ID="UpdatePanel147" runat="server">
                                    <ContentTemplate>



                                        <tr>



                                            <td>
                                                <asp:ImageButton ID="deawc36supplier36all" runat="server" Height="39px" ImageUrl="~/images/de.jpg" Width="175px" />
                                            </td>
                                            <td>
                                                <asp:Label ID="lbldeawc36program36all" runat="server" Text="British Gas Lite new"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtdeawc36sc36all" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox ID="txtdeawc36day36all" runat="server" Text="0" Width="75px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtdeawc36night36all" runat="server" Text="0" Width="75px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtdeawc36ew36all" runat="server" Text="0" Width="75px"></asp:TextBox>
                                            </td>
                                            <%-- <td>
                                            <asp:TextBox ID="txtdeawc36wd36all" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>

                                        <td>
                                            <asp:TextBox ID="txtdeawc36unit36all" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>--%>
                                            <td>
                                                <asp:TextBox ID="txtdeawc36offpeak36all" runat="server" Text="0" Width="75px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtdeawc36other36all" runat="server" Text="0" Width="75px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtdeawc36uplift36all" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="2.0" step="0.1" AutoPostBack="true"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtdeawc36all" runat="server" Text="0" Width="75px"></asp:TextBox>

                                            </td>

                                            <td>
                                                <asp:CheckBox ID="chkdeawc36all" runat="server" />
                                            </td>

                                            <td>
                                                <asp:Button ID="btndeawc36showall" runat="server" Text="Show" />
                                            </td>
                                            <td>
                                                <asp:Button ID="btndeawc36saveall" runat="server" Text="Save" /></td>



                                        </tr>

                                    </ContentTemplate>
                                </asp:UpdatePanel>



                                <asp:UpdatePanel ID="UpdatePanel80" runat="server">
                                    <ContentTemplate>



                                        <tr>



                                            <td>
                                                <asp:ImageButton ID="pe36supplierall" runat="server" Height="39px" ImageUrl="~/images/positive.jpg" Width="175px" />
                                            </td>
                                            <td>
                                                <asp:Label ID="lblpe36programall" runat="server" Text="Positive Energy"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtpe36scall" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox ID="txtpe36dayall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtpe36nightall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtpe36ewall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                            </td>
                                            <%--    <td>
                                                <asp:TextBox ID="txtpe36wdall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                            </td>

                                            <td>
                                                <asp:TextBox ID="txtpe36unitall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                            </td>--%>
                                            <td>
                                                <asp:TextBox ID="txtpe36offpeakall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtpe36otherall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtpe36upliftall" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="3.0" step="0.1" AutoPostBack="true" OnTextChanged="txtpe36upliftall_TextChanged"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtpe36rateall" runat="server" Text="0" Width="75px"></asp:TextBox>

                                            </td>

                                            <td>
                                                <asp:CheckBox ID="chkpe36all" runat="server" />
                                            </td>
                                            </td>
                             <td>
                                 <asp:Button ID="Button142" runat="server" Text="Show" />
                             </td>
                                            <td>
                                                <asp:Button ID="Button143" runat="server" Text="Save" /></td>




                                        </tr>

                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <tr>
                                    <asp:UpdatePanel ID="UpdatePanel81" runat="server">
                                        <ContentTemplate>







                                            <td>
                                                <asp:ImageButton ID="gaz36supplierall" runat="server" Height="39px" ImageUrl="~/images/gaz.png" AlternateText="Gaz Prom " Width="175px" />
                                            </td>
                                            <td>
                                                <asp:Label ID="lblgaz36programall" runat="server" Text="Gaz  Energy"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtgaz36scall" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox ID="txtgaz36dayall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtgaz36nightall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtgaz36ewall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                            </td>
                                            <%--  <td>
                                                <asp:TextBox ID="txtgaz36wdall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                            </td>

                                            <td>
                                                <asp:TextBox ID="txtgaz36unitall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                            </td>--%>
                                            <td>
                                                <asp:TextBox ID="txtgaz36offpeakall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtgaz36otherall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtgaz36upliftall" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="2.0" step="0.1" AutoPostBack="true" OnTextChanged="txtgaz36upliftall_TextChanged"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtgaz36rateall" runat="server" Text="0" Width="75px"></asp:TextBox>

                                            </td>

                                            <td>
                                                <asp:CheckBox ID="chkgaz36all" runat="server" />
                                            </td>

                                            <td>
                                                <asp:Button ID="Button144" runat="server" Text="Show" />
                                            </td>
                                            <td>
                                                <asp:Button ID="Button145" runat="server" Text="Save" /></td>




                                            </tr>

                                        </ContentTemplate>
                                    </asp:UpdatePanel>

                                    <asp:UpdatePanel ID="UpdatePanel82" runat="server">
                                        <ContentTemplate>



                                            <tr>



                                                <td>
                                                    <asp:ImageButton ID="sse36supplierall" runat="server" Height="39px" ImageUrl="~/images/sse.jpg" AlternateText="sse energy" Width="175px" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblsse36programall" runat="server" Text="sse  Energy"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtsse36scamrall" runat="server" Width="75px" Text="0"></asp:TextBox>
                                                    <asp:TextBox ID="txtsse36scnonamrall" runat="server" Width="75px" Text="0"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtsse36dayall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtsse36nightall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtsse36ewall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                </td>
                                                <%--  <td>
                                                    <asp:TextBox ID="txtsse36wdall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                </td>

                                                <td>
                                                    <asp:TextBox ID="txtsse36unitall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                </td>--%>
                                                <td>
                                                    <asp:TextBox ID="txtsse36offpeakall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtsse36otherall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtsse36upliftall" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="2.0" step="0.1" AutoPostBack="true" OnTextChanged="txtsse36upliftall_TextChanged"></asp:TextBox>
                                                    <asp:TextBox ID="txtsse36upliftnonamrall" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="2.0" step="0.1" AutoPostBack="true" OnTextChanged="txtsse36upliftnonamrall_TextChanged"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtsse36rateall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                    <asp:TextBox ID="txtsse36ratenonamrall" runat="server" Text="0" Width="75px"></asp:TextBox>

                                                </td>

                                                <td>
                                                    <asp:CheckBox ID="chksse36all" runat="server" />
                                                </td>
                                                </td>
                             <td>
                                 <asp:Button ID="Button146" runat="server" Text="Show" />
                             </td>
                                                <td>
                                                    <asp:Button ID="Button147" runat="server" Text="Save" /></td>



                                            </tr>

                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <tr>
                                        <asp:UpdatePanel ID="UpdatePanel83" runat="server">
                                            <ContentTemplate>







                                                <td>
                                                    <asp:ImageButton ID="npra36supplierall" runat="server" Height="39px" ImageUrl="~/images/npower.jpg" AlternateText="N Power energy" Width="175px" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblnpra36programall" runat="server" Text="npra  Energy"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtnpra36scall" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                                                <td>
                                                    <asp:TextBox ID="txtnpra36dayall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtnpra36nightall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtnpra36ewall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                </td>
                                                <%--    <td>
                                                    <asp:TextBox ID="txtnpra36wdall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                </td>

                                                <td>
                                                    <asp:TextBox ID="txtnpra36unitall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                </td>--%>
                                                <td>
                                                    <asp:TextBox ID="txtnpra36offpeakall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtnpra36otherall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtnpra36upliftall" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="3.0" step="0.1" AutoPostBack="true" OnTextChanged="txtnpra36upliftall_TextChanged"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtnpra36rateall" runat="server" Text="0" Width="75px"></asp:TextBox>

                                                </td>

                                                <td>
                                                    <asp:CheckBox ID="chknpower36all" runat="server" />
                                                </td>
                                                </td>
                             <td>
                                 <asp:Button ID="Button148" runat="server" Text="Show" />
                             </td>
                                                <td>
                                                    <asp:Button ID="Button149" runat="server" Text="Save" /></td>



                                                </tr>

                                            </ContentTemplate>
                                        </asp:UpdatePanel>

                                        <tr>
                                            <asp:UpdatePanel ID="UpdatePanel84" runat="server">
                                                <ContentTemplate>







                                                    <td>
                                                        <asp:ImageButton ID="spe36supplierall" runat="server" Height="39px" ImageUrl="~/images/sp_logo.jpg" AlternateText="N Power energy" Width="175px" />
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblspe36programall" runat="server" Text="spe  Energy"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtspe36scall" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox ID="txtspe36dayall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtspe36nightall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtspe36ewall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                    </td>
                                                    <%--  <td>
                                                        <asp:TextBox ID="txtspe36wdall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                    </td>

                                                    <td>
                                                        <asp:TextBox ID="txtspe36unitall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                    </td>--%>
                                                    <td>
                                                        <asp:TextBox ID="txtspe36offpeakall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtspe36otherall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtspe36upliftall" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="2.0" step="0.1" AutoPostBack="true" OnTextChanged="txtspe36upliftall_TextChanged"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtspe36rateall" runat="server" Text="0" Width="75px"></asp:TextBox>

                                                    </td>
                                                    <td>
                                                        <asp:CheckBox ID="chkspe36all" runat="server" Text="" />
                                                    </td>
                                                    </td>
                             <td>
                                 <asp:Button ID="Button150" runat="server" Text="Show" />
                             </td>
                                                    <td>
                                                        <asp:Button ID="Button151" runat="server" Text="Save" /></td>



                                                    </tr>

                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                            <tr>
                                                <asp:UpdatePanel ID="UpdatePanel85" runat="server">
                                                    <ContentTemplate>







                                                        <td>
                                                            <asp:ImageButton ID="tgp36supplierall" runat="server" Height="39px" ImageUrl="~/images/tglogo.png" Width="175px" />
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lbltgp36programall" runat="server" Text="Total Energy"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txttgp36scall" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                                                        <td>
                                                            <asp:TextBox ID="txttgp36dayall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txttgp36nightall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txttgp36ewall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                        </td>
                                                        <%--  <td>
                                                            <asp:TextBox ID="txttgp36wdall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                        </td>

                                                        <td>
                                                            <asp:TextBox ID="txttgp36unitall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                        </td>--%>
                                                        <td>
                                                            <asp:TextBox ID="txttgp36offpeakall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txttgp36otherall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txttgp36upliftall" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="3.0" step="0.1" AutoPostBack="true" OnTextChanged="txttgp36upliftall_TextChanged"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txttgp36rateall" runat="server" Text="0" Width="75px"></asp:TextBox>

                                                        </td>
                                                        <td>
                                                            <asp:CheckBox ID="chktgp36all" runat="server" Text="" />
                                                        </td>
                                                        </td>
                             <td>
                                 <asp:Button ID="Button152" runat="server" Text="Show" />
                             </td>
                                                        <td>
                                                            <asp:Button ID="Button153" runat="server" Text="Save" /></td>





                                                        </tr>

                                                    </ContentTemplate>
                                                </asp:UpdatePanel>

                                                <asp:UpdatePanel ID="UpdatePanel127" runat="server">
                                                    <ContentTemplate>







                                                        <td>
                                                            <asp:ImageButton ID="tgpw36supplierall" runat="server" Height="39px" ImageUrl="~/images/tglogo.png" Width="175px" />
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lbltgpw36programall" runat="server" Text="Total Energy"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txttgpw36scall" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                                                        <td>
                                                            <asp:TextBox ID="txttgpw36dayall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txttgpw36nightall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txttgpw36ewall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                        </td>
                                                        <%-- <td>
                                                        <asp:TextBox ID="txttgpw36wdall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                    </td>

                                                    <td>
                                                        <asp:TextBox ID="txttgpw36unitall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                    </td>--%>
                                                        <td>
                                                            <asp:TextBox ID="txttgpw36offpeakall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txttgpw36otherall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txttgpw36upliftall" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="3.0" step="0.1" AutoPostBack="true"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txttgpw36rateall" runat="server" Text="0" Width="75px"></asp:TextBox>

                                                        </td>
                                                        <td>
                                                            <asp:CheckBox ID="chktgpw36all" runat="server" />
                                                        </td>
                                                        </td>
                             <td>
                                 <asp:Button ID="btntgpw36show" runat="server" Text="Show" />
                             </td>
                                                        <td>
                                                            <asp:Button ID="Button22" runat="server" Text="Save" /></td>





                                                        </tr>

                                                    </ContentTemplate>
                                                </asp:UpdatePanel>



                                                <asp:UpdatePanel ID="UpdatePanel113" runat="server">
                                                    <ContentTemplate>



                                                        <tr>



                                                            <td>
                                                                <asp:ImageButton ID="opus36supplierall" runat="server" Height="39px" ImageUrl="~/images/opus.png" Width="175px" />
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblopus36programall" runat="server" Text="Opus Energy"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtopus36scall" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                                                            <td>
                                                                <asp:TextBox ID="txtopus36dayall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtopus36nightall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                            </td>

                                                            <td>
                                                                <asp:TextBox ID="txtopus36ewall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                            </td>
                                                            <%--   <td>
                                                                <asp:TextBox ID="txtopus36wdall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                            </td>

                                                            <td>
                                                                <asp:TextBox ID="txtopus36unitall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                            </td>--%>
                                                            <td>
                                                                <asp:TextBox ID="txtopus36offpeakall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtopus36otherall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtopus36upliftall" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="1.0" step="0.1" AutoPostBack="true" OnTextChanged="txtopus36upliftall_TextChanged"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtopus36rateall" runat="server" Text="0" Width="75px"></asp:TextBox>

                                                            </td>
                                                            <td>
                                                                <asp:CheckBox ID="chkopus36all" runat="server" />
                                                            </td>
                                                            <td>
                                                                <asp:Button ID="btnopus36Showall" runat="server" Text="Show" />
                                                            </td>
                                                            <td>
                                                                <asp:Button ID="btnopus36Saveall" runat="server" Text="Save" /></td>




                                                        </tr>

                                                    </ContentTemplate>
                                                </asp:UpdatePanel>


                                                <asp:UpdatePanel ID="UpdatePanel114" runat="server">
                                                    <ContentTemplate>



                                                        <tr>



                                                            <td>
                                                                <asp:ImageButton ID="eon36supplierall" runat="server" Height="39px" ImageUrl="~/images/eon.jpg" Width="175px" />
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lbleon36programall" runat="server" Text="Eon Energy"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txteon36scall" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                                                            <td>
                                                                <asp:TextBox ID="txteon36dayall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txteon36nightall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                            </td>

                                                            <td>
                                                                <asp:TextBox ID="txteon36ewall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                            </td>
                                                            <%--  <td>
                                                                <asp:TextBox ID="txteon36wdall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                            </td>

                                                            <td>
                                                                <asp:TextBox ID="txteon36unitall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                            </td>--%>
                                                            <td>
                                                                <asp:TextBox ID="txteon36offpeakall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txteon36otherall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <%--  <asp:TextBox ID="txteon36upliftall" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="3.0" step="0.1" AutoPostBack="true"></asp:TextBox>--%>
                                                                <asp:DropDownList ID="ddeon36upliftall" runat="server" Width="75px" AutoPostBack="true" OnSelectedIndexChanged="ddeon36upliftall_SelectedIndexChanged">
                                                                    <asp:ListItem Selected="True">0.0</asp:ListItem>
                                                                    <asp:ListItem>0.1</asp:ListItem>
                                                                    <asp:ListItem>0.2</asp:ListItem>
                                                                    <asp:ListItem>0.3</asp:ListItem>
                                                                    <asp:ListItem>0.4</asp:ListItem>
                                                                    <asp:ListItem>0.5</asp:ListItem>
                                                                    <asp:ListItem>0.6</asp:ListItem>
                                                                    <asp:ListItem>0.7</asp:ListItem>
                                                                    <asp:ListItem>0.8</asp:ListItem>
                                                                    <asp:ListItem>0.9</asp:ListItem>
                                                                    <asp:ListItem>1.0</asp:ListItem>
                                                                    <asp:ListItem>1.2</asp:ListItem>
                                                                    <asp:ListItem>1.5</asp:ListItem>



                                                                </asp:DropDownList>


                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txteon36rateall" runat="server" Text="0" Width="75px"></asp:TextBox>

                                                            </td>
                                                            <td>
                                                                <asp:CheckBox ID="chkeon36all" runat="server" />
                                                            </td>
                                                            <td>
                                                                <asp:Button ID="btneon36Showall" runat="server" Text="Show" />
                                                            </td>
                                                            <td>
                                                                <asp:Button ID="btneon36Saveall" runat="server" Text="Save" /></td>




                                                        </tr>

                                                    </ContentTemplate>
                                                </asp:UpdatePanel>

                                                <asp:UpdatePanel ID="UpdatePanel123" runat="server">
                                                    <ContentTemplate>



                                                        <tr>



                                                            <td>
                                                                <asp:ImageButton ID="hev36supplierall" runat="server" Height="39px" ImageUrl="~/images/hev.png" Width="175px" />
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblhev36programall" runat="server" Text="Heven power"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txthev36scall" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                                                            <td>
                                                                <asp:TextBox ID="txthev36dayall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txthev36nightall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                            </td>

                                                            <td>
                                                                <asp:TextBox ID="txthev36ewall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                            </td>
                                                            <%-- <td>
                                                                <asp:TextBox ID="txthev36wdall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                            </td>

                                                            <td>
                                                                <asp:TextBox ID="txthev36unitall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                            </td>--%>
                                                            <td>
                                                                <asp:TextBox ID="txthev36offpeakall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txthev36otherall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txthev36upliftall" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="1.0" step="0.1" AutoPostBack="true"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txthev36rateall" runat="server" Text="0" Width="75px"></asp:TextBox>

                                                            </td>
                                                            <td>
                                                                <asp:CheckBox ID="chkhev36all" runat="server" />
                                                            </td>
                                                            <td>
                                                                <asp:Button ID="btnhev36Showall" runat="server" Text="Show" />
                                                            </td>
                                                            <td>
                                                                <asp:Button ID="btnhev36Saveall" runat="server" Text="Save" /></td>




                                                        </tr>

                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                                <asp:UpdatePanel ID="UpdatePanel361" runat="server">
                                                    <ContentTemplate>



                                                        <tr>



                                                            <td>
                                                                <asp:ImageButton ID="hevc36supplierall" runat="server" Height="39px" ImageUrl="~/images/hev.png" Width="175px" />
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblhevc36programall" runat="server" Text="hevcen power"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txthevc36scall" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                                                            <td>
                                                                <asp:TextBox ID="txthevc36dayall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txthevc36nightall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                            </td>

                                                            <td>
                                                                <asp:TextBox ID="txthevc36ewall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                            </td>

                                                            <td>
                                                                <asp:TextBox ID="txthevc36offpeakall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txthevc36otherall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txthevc36upliftall" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="1.0" step="0.1" AutoPostBack="true"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txthevc36rateall" runat="server" Text="0" Width="75px"></asp:TextBox>

                                                            </td>
                                                            <td>
                                                                <asp:CheckBox ID="chkhevc36all" runat="server" />
                                                            </td>
                                                            <td>
                                                                <asp:Button ID="btnhevc36Showall" runat="server" Text="Show" />
                                                            </td>
                                                            <td>
                                                                <asp:Button ID="btnhevc36Saveall" runat="server" Text="Save" /></td>




                                                        </tr>

                                                    </ContentTemplate>
                                                </asp:UpdatePanel>



                                <asp:UpdatePanel ID="UpdatePanel171" runat="server">
                                    <ContentTemplate>







                                        <td>
                                            <asp:ImageButton ID="utila36supplierall" runat="server" Height="39px" ImageUrl="~/images/utilita.png" Width="175px" />
                                        </td>
                                        <td>
                                            <asp:Label ID="lblutila36programall" runat="server" Text="Utilita Energy new"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtutila36scall" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="txtutila36dayall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtutila36nightall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtutila36ewall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <%-- <td>
                                            <asp:TextBox ID="txtutila36wdall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>

                                        <td>
                                            <asp:TextBox ID="txtutila36unitall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>--%>
                                        <td>
                                            <asp:TextBox ID="txtutila36offpeakall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtutila36otherall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtutila36upliftall" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="1.5" step="0.1" AutoPostBack="true" ></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtutil36Rateall" runat="server" Text="0" Width="75px"></asp:TextBox>

                                        </td>

                                        <td>
                                            <asp:CheckBox ID="chkutil36all" runat="server" />
                                        </td>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnutil36all" runat="server" Text="Show" OnClick="btnutil36allShow_Click" />
                                        </td>
                                        <td>
                                            <asp:Button ID="Button80" runat="server" Text="Save" /></td>



                                        </tr>

                                    </ContentTemplate>
                                </asp:UpdatePanel>
								
								
								 <asp:UpdatePanel ID="UpdatePanel172" runat="server">
                                    <ContentTemplate>







                                        <td>
                                            <asp:ImageButton ID="gulfa36supplierall" runat="server" Height="39px" ImageUrl="~/images/gulf.png" Width="175px" />
                                        </td>
                                        <td>
                                            <asp:Label ID="lblgulfa36programall" runat="server" Text="Gulf  Energy"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtgulfa36scall" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="txtgulfa36dayall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtgulfa36nightall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtgulfa36ewall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <%-- <td>
                                            <asp:TextBox ID="txtgulfa36wdall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>

                                        <td>
                                            <asp:TextBox ID="txtgulfa36unitall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>--%>
                                        <td>
                                            <asp:TextBox ID="txtgulfa36offpeakall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtgulfa36otherall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtgulfa36upliftall" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="1.5" step="0.1" AutoPostBack="true"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtgulf36Rateall" runat="server" Text="0" Width="75px"></asp:TextBox>

                                        </td>

                                        <td>
                                            <asp:CheckBox ID="chkgulf36all" runat="server" />
                                        </td>
                                        </td>
                                        <td>
                                            <asp:Button ID="btngulf36all" runat="server" Text="Show" OnClick="btngulf36allShow_Click" />
                                        </td>
                                        <td>
                                            <asp:Button ID="Button82" runat="server" Text="Save" /></td>



                                        </tr>

                                    </ContentTemplate>
                                </asp:UpdatePanel>
								
								  <asp:UpdatePanel ID="UpdatePanel173" runat="server">
                                    <ContentTemplate>







                                        <td>
                                            <asp:ImageButton ID="yuea36supplierall" runat="server" Height="39px" ImageUrl="~/images/yue.jpg" Width="175px" />
                                        </td>
                                        <td>
                                            <asp:Label ID="lblyuea36programall" runat="server" Text="YU Energy"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtyuea36scall" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="txtyuea36dayall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtyuea36nightall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtyuea36ewall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <%-- <td>
                                            <asp:TextBox ID="txtyuea36wdall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>

                                        <td>
                                            <asp:TextBox ID="txtyuea36unitall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>--%>
                                        <td>
                                            <asp:TextBox ID="txtyuea36offpeakall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtyuea36otherall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtyuea36upliftall" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="1.5" step="0.1" AutoPostBack="true" ></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtyue36Rateall" runat="server" Text="0" Width="75px"></asp:TextBox>

                                        </td>

                                        <td>
                                            <asp:CheckBox ID="chkyue36all" runat="server" />
                                        </td>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnyue36all" runat="server" Text="Show" OnClick="btnyue36allShow_Click" />
                                        </td>
                                        <td>
                                            <asp:Button ID="Button84" runat="server" Text="Save" /></td>



                                        </tr>

                                    </ContentTemplate>
                                </asp:UpdatePanel>



            </table>

            <h3>Rate sheet for 4 years</h3>
            <table class="table table-bordered table-dark">
                <tr>
                    <td>Supplier Name</td>
                    <td>Program Name</td>
                    <td>Standing&nbsp; charge</td>
                    <td>Day Unit Charge</td>
                    <td>Night Unit Charge</td>
                    <td>EVENING WEEKEND UNIT CHARGE</td>
                    <%--  <td>WEEKDAY DAY UNIT CHARGE</td>

                    <td>UNIT Charge</td>--%>
                    <td>OFF PEAK UNIT CHARGE</td>
                    <td>Other Charges </td>
                    <td>Uplift</td>
                    <td>Yearly Charge</td>
                    <td>Mail</td>
                    <td>Show </td>
                    <td>Save</td>










                </tr>
                <asp:UpdatePanel ID="UpdatePanel86" runat="server">
                    <ContentTemplate>



                        <tr>



                            <td>
                                <asp:ImageButton ID="bga48supplierall" runat="server" Height="39px" ImageUrl="~/britishgas.jpg" Width="175px" />
                            </td>
                            <td>
                                <asp:Label ID="lblBga48programall" runat="server" Text="British Gas new"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbga48scall" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txtbga48dayall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbga48nightall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbga48ewall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <%-- <td>
                                <asp:TextBox ID="txtbga48wdall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>

                            <td>
                                <asp:TextBox ID="txtbga48unitall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>--%>
                            <td>
                                <asp:TextBox ID="txtbga48offpeakall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbga48otherall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbga48upliftall" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="2.0" step="0.1" AutoPostBack="true" OnTextChanged="txtbga48upliftall_TextChanged"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbfga48rateall" runat="server" Text="0" Width="75px"></asp:TextBox>

                            </td>


                            <td>
                                <asp:CheckBox ID="chkbga48all" runat="server" Text="" />
                            </td>
                            <td>
                                <asp:Button ID="Button154" runat="server" Text="Show" />
                            </td>
                            <td>
                                <asp:Button ID="Button155" runat="server" Text="Save" /></td>


                        </tr>

                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:UpdatePanel ID="UpdatePanel87" runat="server">
                    <ContentTemplate>



                        <tr>



                            <td>
                                <asp:ImageButton ID="bge48supplierall" runat="server" Height="39px" ImageUrl="~/britishgas.jpg" Width="175px" />
                            </td>
                            <td>
                                <asp:Label ID="lblBge48programall" runat="server" Text="British Gas Re new "></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbge48scall" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txtbge48dayall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbge48nightall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbge48ewall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <%-- <td>
                                <asp:TextBox ID="txtbge48wdall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>

                            <td>
                                <asp:TextBox ID="txtbge48unitall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>--%>
                            <td>
                                <asp:TextBox ID="txtbge48offpeakall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbge48otherall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbge48upliftall" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="2.0" step="0.1" AutoPostBack="true" OnTextChanged="txtbge48upliftall_TextChanged"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbfge48rateall" runat="server" Text="0" Width="75px"></asp:TextBox>

                            </td>

                            <td>
                                <asp:CheckBox ID="chkbge48all" runat="server" Text="" />
                            </td>
                            <td>
                                <asp:Button ID="Button156" runat="server" Text="Show" />
                            </td>
                            <td>
                                <asp:Button ID="Button157" runat="server" Text="Save" /></td>



                        </tr>

                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:UpdatePanel ID="UpdatePanel88" runat="server">
                    <ContentTemplate>



                        <tr>



                            <td>
                                <asp:ImageButton ID="bgl48supplierall" runat="server" Height="39px" ImageUrl="~/images/bgl.png" Width="175px" />
                            </td>
                            <td>
                                <asp:Label ID="lblbgla48programall" runat="server" Text="British Gas Lite new"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbgla48scall" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txtbgla48dayall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbgla48nightall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbgla48ewall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <%-- <td>
                                <asp:TextBox ID="txtbgla48wdall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>

                            <td>
                                <asp:TextBox ID="txtbgla48unitall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>--%>
                            <td>
                                <asp:TextBox ID="txtbgla48offpeakall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbgla48otherall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbgla48upliftall" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="1.0" step="0.1" AutoPostBack="true" OnTextChanged="txtbgla48upliftall_TextChanged"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbfgla48rateall" runat="server" Text="0" Width="75px"></asp:TextBox>

                            </td>

                            <td>
                                <asp:CheckBox ID="chkbgla48all" runat="server" Text="" />
                            </td>
                            <td>
                                <asp:Button ID="Button158" runat="server" Text="Show" />
                            </td>
                            <td>
                                <asp:Button ID="Button159" runat="server" Text="Save" /></td>



                        </tr>

                    </ContentTemplate>
                </asp:UpdatePanel>

                <asp:UpdatePanel ID="UpdatePanel89" runat="server">
                    <ContentTemplate>



                        <tr>



                            <td>
                                <asp:ImageButton ID="bgle48supplierall" runat="server" Height="39px" ImageUrl="~/images/bgl.png" Width="175px" />
                            </td>
                            <td>
                                <asp:Label ID="lblbgle48programall" runat="server" Text="British Gas Lite new"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbgle48scall" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txtbgle48dayall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbgle48nightall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbgle48ewall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <%-- <td>
                                <asp:TextBox ID="txtbgle48wdall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>

                            <td>
                                <asp:TextBox ID="txtbgle48unitall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>--%>
                            <td>
                                <asp:TextBox ID="txtbgle48offpeakall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbgle48otherall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbgle48upliftall" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="1.5" step="0.1" AutoPostBack="true" OnTextChanged="txtbgle48upliftall_TextChanged"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbga48rateall" runat="server" Text="0" Width="75px"></asp:TextBox>

                            </td>

                            <td>
                                <asp:CheckBox ID="chkbgle48all" runat="server" Text="" />
                            </td>
                            <td>
                                <asp:Button ID="Button160" runat="server" Text="Show" />
                            </td>
                            <td>
                                <asp:Button ID="Button161" runat="server" Text="Save" /></td>



                        </tr>

                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:UpdatePanel ID="UpdatePanel90" runat="server">
                    <ContentTemplate>



                        <tr>



                            <td>
                                <asp:ImageButton ID="edfa48supplierall" runat="server" Height="39px" ImageUrl="~/images/edf.jpg" Width="175px" />
                            </td>
                            <td>
                                <asp:Label ID="lbledfa48programall" runat="server" Text="British Gas Lite new"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtedfa48scall" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txtedfa48dayall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtedfa48nightall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtedfa48ewall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <%--  <td>
                                <asp:TextBox ID="txtedfa48wdall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>

                            <td>
                                <asp:TextBox ID="txtedfa48unitall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>--%>
                            <td>
                                <asp:TextBox ID="txtedfa48offpeakall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtedfa48otherall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtedfa48upliftall" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="1.5" step="0.1" AutoPostBack="true" OnTextChanged="txtedfa48upliftall_TextChanged"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtedfa48rateall" runat="server" Text="0" Width="75px"></asp:TextBox>

                            </td>


                            <td>
                                <asp:CheckBox ID="chkedf48all" runat="server" Text="" />
                            </td>
                            <td>
                                <asp:Button ID="Button162" runat="server" Text="Show" />
                            </td>
                            <td>
                                <asp:Button ID="Button163" runat="server" Text="Save" /></td>


                        </tr>

                    </ContentTemplate>
                </asp:UpdatePanel>

                <asp:UpdatePanel ID="UpdatePanel91" runat="server">
                    <ContentTemplate>



                        <tr>



                            <td>
                                <asp:ImageButton ID="dea48supplierall" runat="server" Height="39px" ImageUrl="~/images/de.jpg" Width="175px" />
                            </td>
                            <td>
                                <asp:Label ID="lbldea48programall" runat="server" Text="Dual new"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtdea48scall" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txtdea48dayall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtdea48nightall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtdea48ewall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <%--<td>
                                <asp:TextBox ID="txtdea48wdall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>

                            <td>
                                <asp:TextBox ID="txtdea48unitall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>--%>
                            <td>
                                <asp:TextBox ID="txtdea48offpeakall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtdea48otherall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtdea48upliftall" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="2.0" step="0.1" AutoPostBack="true"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtdea48rateall" runat="server" Text="0" Width="75px"></asp:TextBox>

                            </td>
                            <td>
                                <asp:CheckBox ID="chkdea48all" runat="server" Text="" />
                            </td>
                            <td>
                                <asp:Button ID="Button164" runat="server" Text="Show" />
                            </td>
                            <td>
                                <asp:Button ID="Button165" runat="server" Text="Save" /></td>




                        </tr>

                    </ContentTemplate>
                </asp:UpdatePanel>

                                            <asp:UpdatePanel ID="UpdatePanel148" runat="server">
                                <ContentTemplate>



                                    <tr>



                                        <td>
                                            <asp:ImageButton ID="deawc48supplier48all" runat="server" Height="39px" ImageUrl="~/images/de.jpg" Width="175px" />
                                        </td>
                                        <td>
                                            <asp:Label ID="lbldeawc48program48all" runat="server" Text="British Gas Lite new"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtdeawc48sc48all" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="txtdeawc48day48all" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtdeawc48night48all" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtdeawc48ew48all" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <%-- <td>
                                            <asp:TextBox ID="txtdeawc48wd48all" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>

                                        <td>
                                            <asp:TextBox ID="txtdeawc48unit48all" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>--%>
                                        <td>
                                            <asp:TextBox ID="txtdeawc48offpeak48all" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtdeawc48other48all" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtdeawc48uplift48all" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="2.0" step="0.1" AutoPostBack="true"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtdeawc48all" runat="server" Text="0" Width="75px"></asp:TextBox>

                                        </td>

                                        <td>
                                            <asp:CheckBox ID="chkdeawc48all" runat="server" />
                                        </td>

                                        <td>
                                            <asp:Button ID="btndeawc48showall" runat="server" Text="Show" />
                                        </td>
                                        <td>
                                            <asp:Button ID="btndeawc48saveall" runat="server" Text="Save" /></td>



                                    </tr>

                                </ContentTemplate>
                            </asp:UpdatePanel>


                <asp:UpdatePanel ID="UpdatePanel92" runat="server">
                    <ContentTemplate>



                        <tr>



                            <td>
                                <asp:ImageButton ID="npra48supplierall" runat="server" Height="39px" ImageUrl="~/images/npower.jpg" AlternateText="N Power energy" Width="175px" />
                            </td>
                            <td>
                                <asp:Label ID="lblnpra48programall" runat="server" Text="npra  Energy"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtnpra48scall" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txtnpra48dayall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtnpra48nightall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtnpra48ewall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <%--<td>
                                <asp:TextBox ID="txtnpra48wdall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>

                            <td>
                                <asp:TextBox ID="txtnpra48unitall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>--%>
                            <td>
                                <asp:TextBox ID="txtnpra48offpeakall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtnpra48otherall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtnpra48rateall" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="3.0" step="0.1" AutoPostBack="true"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtnpra48upliftall" runat="server" Text="0" Width="75px"></asp:TextBox>

                            </td>



                            <td>
                                <asp:CheckBox ID="chknpower48all" runat="server" Text="" />
                            </td>
                            <td>
                                <asp:Button ID="Button166" runat="server" Text="Show" />
                            </td>
                            <td>
                                <asp:Button ID="Button167" runat="server" Text="Save" /></td>

                        </tr>

                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:UpdatePanel ID="UpdatePanel93" runat="server">
                    <ContentTemplate>



                        <tr>



                            <td>
                                <asp:ImageButton ID="tgp48supplierall" runat="server" Height="39px" ImageUrl="~/images/tglogo.png" Width="175px" />
                            </td>
                            <td>
                                <asp:Label ID="lbltgp48programall" runat="server" Text="Total  Energy"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txttgp48scall" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txttgp48dayall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txttgp48nightall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txttgp48ewall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <%--   <td>
                                <asp:TextBox ID="txttgp48wdall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>

                            <td>
                                <asp:TextBox ID="txttgp48unitall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>--%>
                            <td>
                                <asp:TextBox ID="txttgp48offpeakall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txttgp48otherall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txttgp48upliftall" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="3.0" step="0.1" AutoPostBack="true" OnTextChanged="txttgp48upliftall_TextChanged"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txttgp48rateall" runat="server" Text="0" Width="75px"></asp:TextBox>

                            </td>

                            <td>
                                <asp:CheckBox ID="chktgp48all" runat="server" Text="" />
                            </td>
                            <td>
                                <asp:Button ID="Button168" runat="server" Text="Show" />
                            </td>
                            <td>
                                <asp:Button ID="Button169" runat="server" Text="Save" /></td>



                        </tr>

                    </ContentTemplate>
                </asp:UpdatePanel>

                <asp:UpdatePanel ID="UpdatePanel128" runat="server">
                    <ContentTemplate>







                        <td>
                            <asp:ImageButton ID="tgpw48supplierall" runat="server" Height="39px" ImageUrl="~/images/tglogo.png" Width="175px" />
                        </td>
                        <td>
                            <asp:Label ID="lbltgpw48programall" runat="server" Text="Total Energy"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txttgpw48scall" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="txttgpw48dayall" runat="server" Text="0" Width="75px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txttgpw48nightall" runat="server" Text="0" Width="75px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txttgpw48ewall" runat="server" Text="0" Width="75px"></asp:TextBox>
                        </td>
                        <%-- <td>
                                                        <asp:TextBox ID="txttgpw48wdall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                    </td>

                                                    <td>
                                                        <asp:TextBox ID="txttgpw48unitall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                    </td>--%>
                        <td>
                            <asp:TextBox ID="txttgpw48offpeakall" runat="server" Text="0" Width="75px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txttgpw48otherall" runat="server" Text="0" Width="75px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txttgpw48upliftall" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="3.0" step="0.1" AutoPostBack="true"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txttgpw48rateall" runat="server" Text="0" Width="75px"></asp:TextBox>

                        </td>
                        <td>
                            <asp:CheckBox ID="chktgpw48all" runat="server" />
                        </td>
                        </td>
                             <td>
                                 <asp:Button ID="btntgpw48show" runat="server" Text="Show" />
                             </td>
                        <td>
                            <asp:Button ID="Button20" runat="server" Text="Save" /></td>





                        </tr>

                    </ContentTemplate>

                </asp:UpdatePanel>


                <asp:UpdatePanel ID="UpdatePanel115" runat="server">
                    <ContentTemplate>



                        <tr>



                            <td>
                                <asp:ImageButton ID="opus48supplierall" runat="server" Height="39px" ImageUrl="~/images/opus.png" Width="175px" />
                            </td>
                            <td>
                                <asp:Label ID="lblopus48programall" runat="server" Text="Opus Energy"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtopus48scall" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txtopus48dayall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtopus48nightall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>

                            <td>
                                <asp:TextBox ID="txtopus48ewall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <%--<td>
                                <asp:TextBox ID="txtopus48wdall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>

                            <td>
                                <asp:TextBox ID="txtopus48unitall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>--%>
                            <td>
                                <asp:TextBox ID="txtopus48offpeakall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtopus48otherall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtopus48upliftall" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="1.0" step="0.1" AutoPostBack="true" OnTextChanged="txtopus48upliftall_TextChanged"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtopus48rateall" runat="server" Text="0" Width="75px"></asp:TextBox>

                            </td>
                            <td>
                                <asp:CheckBox ID="chkopus48all" runat="server" />
                            </td>
                            <td>
                                <asp:Button ID="btnopus48Showall" runat="server" Text="Show" />
                            </td>
                            <td>
                                <asp:Button ID="btnopus48Saveall" runat="server" Text="Save" /></td>




                        </tr>

                    </ContentTemplate>
                </asp:UpdatePanel>


                <asp:UpdatePanel ID="UpdatePanel116" runat="server">
                    <ContentTemplate>



                        <tr>



                            <td>
                                <asp:ImageButton ID="eon48supplierall" runat="server" Height="39px" ImageUrl="~/images/eon.jpg" Width="175px" />
                            </td>
                            <td>
                                <asp:Label ID="lbleon48programall" runat="server" Text="Eon energy"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txteon48scall" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txteon48dayall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txteon48nightall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>

                            <td>
                                <asp:TextBox ID="txteon48ewall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <%--  <td>
                                <asp:TextBox ID="txteon48wdall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>

                            <td>
                                <asp:TextBox ID="txteon48unitall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>--%>
                            <td>
                                <asp:TextBox ID="txteon48offpeakall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txteon48otherall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <%--       <asp:TextBox ID="txteon48upliftall" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="3.0" step="0.1" AutoPostBack="true"></asp:TextBox>--%>
                                <asp:DropDownList ID="ddeon48upliftall" runat="server" Width="75px" AutoPostBack="true" OnSelectedIndexChanged="ddeon48upliftall_SelectedIndexChanged">
                                    <asp:ListItem Selected="True">0.0</asp:ListItem>
                                    <asp:ListItem>0.1</asp:ListItem>
                                    <asp:ListItem>0.2</asp:ListItem>
                                    <asp:ListItem>0.3</asp:ListItem>
                                    <asp:ListItem>0.4</asp:ListItem>
                                    <asp:ListItem>0.5</asp:ListItem>
                                    <asp:ListItem>0.6</asp:ListItem>
                                    <asp:ListItem>0.7</asp:ListItem>
                                    <asp:ListItem>0.8</asp:ListItem>
                                    <asp:ListItem>0.9</asp:ListItem>
                                    <asp:ListItem>1.0</asp:ListItem>
                                    <asp:ListItem>1.2</asp:ListItem>
                                    <asp:ListItem>1.5</asp:ListItem>



                                </asp:DropDownList>

                            </td>
                            <td>
                                <asp:TextBox ID="txteon48rateall" runat="server" Text="0" Width="75px"></asp:TextBox>

                            </td>
                            <td>
                                <asp:CheckBox ID="chkeon48all" runat="server" />
                            </td>
                            <td>
                                <asp:Button ID="btneon48Showall" runat="server" Text="Show" />
                            </td>
                            <td>
                                <asp:Button ID="btneon48Saveall" runat="server" Text="Save" /></td>




                        </tr>

                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:UpdatePanel ID="UpdatePanel124" runat="server">
                    <ContentTemplate>



                        <tr>



                            <td>
                                <asp:ImageButton ID="hev48supplierall" runat="server" Height="39px" ImageUrl="~/images/hev.png" Width="175px" />
                            </td>
                            <td>
                                <asp:Label ID="lblhev48programall" runat="server" Text="Heven power"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txthev48scall" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txthev48dayall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txthev48nightall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>

                            <td>
                                <asp:TextBox ID="txthev48ewall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <%-- <td>
                                                                <asp:TextBox ID="txthev48wdall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                            </td>

                                                            <td>
                                                                <asp:TextBox ID="txthev48unitall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                            </td>--%>
                            <td>
                                <asp:TextBox ID="txthev48offpeakall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txthev48otherall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txthev48upliftall" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="1.0" step="0.1" AutoPostBack="true"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txthev48rateall" runat="server" Text="0" Width="75px"></asp:TextBox>

                            </td>
                            <td>
                                <asp:CheckBox ID="chkhev48all" runat="server" />
                            </td>
                            <td>
                                <asp:Button ID="btnhev48Showall" runat="server" Text="Show" />
                            </td>
                            <td>
                                <asp:Button ID="btnhev48Saveall" runat="server" Text="Save" /></td>




                        </tr>

                    </ContentTemplate>
                </asp:UpdatePanel>


                <asp:UpdatePanel ID="UpdatePanel481" runat="server">
                    <ContentTemplate>



                        <tr>



                            <td>
                                <asp:ImageButton ID="hevc48supplierall" runat="server" Height="39px" ImageUrl="~/images/hev.png" Width="175px" />
                            </td>
                            <td>
                                <asp:Label ID="lblhevc48programall" runat="server" Text="hevcen power"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txthevc48scall" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txthevc48dayall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txthevc48nightall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>

                            <td>
                                <asp:TextBox ID="txthevc48ewall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>

                            <td>
                                <asp:TextBox ID="txthevc48offpeakall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <%--<td>--%>
                            <asp:TextBox ID="txthevc48otherall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                                                        <td>
                                                            <asp:TextBox ID="txthevc48upliftall" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="1.0" step="0.1" AutoPostBack="true"></asp:TextBox>
                                                        </td>
                            <td>
                                <asp:TextBox ID="txthevc48rateall" runat="server" Text="0" Width="75px"></asp:TextBox>

                            </td>
                            <td>
                                <asp:CheckBox ID="chkhevc48all" runat="server" />
                            </td>
                            <td>
                                <asp:Button ID="btnhevc48Showall" runat="server" Text="Show" />
                            </td>
                            <td>
                                <asp:Button ID="btnhevc48Saveall" runat="server" Text="Save" /></td>




                        </tr>

                    </ContentTemplate>
                </asp:UpdatePanel>



                                <asp:UpdatePanel ID="UpdatePanel174" runat="server">
                                    <ContentTemplate>







                                        <td>
                                            <asp:ImageButton ID="utila48supplierall" runat="server" Height="39px" ImageUrl="~/images/utilita.png" Width="175px" />
                                        </td>
                                        <td>
                                            <asp:Label ID="lblutila48programall" runat="server" Text="Utilita Energy new"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtutila48scall" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="txtutila48dayall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtutila48nightall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtutila48ewall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <%-- <td>
                                            <asp:TextBox ID="txtutila48wdall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>

                                        <td>
                                            <asp:TextBox ID="txtutila48unitall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>--%>
                                        <td>
                                            <asp:TextBox ID="txtutila48offpeakall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtutila48otherall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtutila48upliftall" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="1.5" step="0.1" AutoPostBack="true" ></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtutil48Rateall" runat="server" Text="0" Width="75px"></asp:TextBox>

                                        </td>

                                        <td>
                                            <asp:CheckBox ID="chkutil48all" runat="server" />
                                        </td>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnutil48all" runat="server" Text="Show" OnClick="btnutil48allShow_Click" />
                                        </td>
                                        <td>
                                            <asp:Button ID="Button86" runat="server" Text="Save" /></td>



                                        </tr>

                                    </ContentTemplate>
                                </asp:UpdatePanel>
								
								
								 <asp:UpdatePanel ID="UpdatePanel175" runat="server">
                                    <ContentTemplate>







                                        <td>
                                            <asp:ImageButton ID="gulfa48supplierall" runat="server" Height="39px" ImageUrl="~/images/gulf.png" Width="175px" />
                                        </td>
                                        <td>
                                            <asp:Label ID="lblgulfa48programall" runat="server" Text="Gulf  Energy"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtgulfa48scall" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="txtgulfa48dayall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtgulfa48nightall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtgulfa48ewall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <%-- <td>
                                            <asp:TextBox ID="txtgulfa48wdall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>

                                        <td>
                                            <asp:TextBox ID="txtgulfa48unitall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>--%>
                                        <td>
                                            <asp:TextBox ID="txtgulfa48offpeakall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtgulfa48otherall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtgulfa48upliftall" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="1.5" step="0.1" AutoPostBack="true"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtgulf48Rateall" runat="server" Text="0" Width="75px"></asp:TextBox>

                                        </td>

                                        <td>
                                            <asp:CheckBox ID="chkgulf48all" runat="server" />
                                        </td>
                                        </td>
                                        <td>
                                            <asp:Button ID="btngulf48all" runat="server" Text="Show" OnClick="btngulf48allShow_Click" />
                                        </td>
                                        <td>
                                            <asp:Button ID="Button88" runat="server" Text="Save" /></td>



                                        </tr>

                                    </ContentTemplate>
                                </asp:UpdatePanel>
								
								  <asp:UpdatePanel ID="UpdatePanel176" runat="server">
                                    <ContentTemplate>







                                        <td>
                                            <asp:ImageButton ID="yuea48supplierall" runat="server" Height="39px" ImageUrl="~/images/yue.jpg" Width="175px" />
                                        </td>
                                        <td>
                                            <asp:Label ID="lblyuea48programall" runat="server" Text="YU Energy"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtyuea48scall" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="txtyuea48dayall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtyuea48nightall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtyuea48ewall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <%-- <td>
                                            <asp:TextBox ID="txtyuea48wdall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>

                                        <td>
                                            <asp:TextBox ID="txtyuea48unitall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>--%>
                                        <td>
                                            <asp:TextBox ID="txtyuea48offpeakall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtyuea48otherall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtyuea48upliftall" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="1.5" step="0.1" AutoPostBack="true" ></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtyue48Rateall" runat="server" Text="0" Width="75px"></asp:TextBox>

                                        </td>

                                        <td>
                                            <asp:CheckBox ID="chkyue48all" runat="server" />
                                        </td>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnyue48all" runat="server" Text="Show" OnClick="btnyue48allShow_Click" />
                                        </td>
                                        <td>
                                            <asp:Button ID="Button90" runat="server" Text="Save" /></td>



                                        </tr>

                                    </ContentTemplate>
                                </asp:UpdatePanel>




            </table>
            <h3>Rate for 5 years</h3>
            <table class="table table-bordered table-dark">
                <tr>
                    <td>Supplier Name</td>
                    <td>Program Name</td>
                    <td>Standing&nbsp; charge</td>
                    <td>Day Unit Charge</td>
                    <td>Night Unit Charge</td>
                    <td>EVENING WEEKEND UNIT CHARGE</td>
                    <%-- <td>WEEKDAY DAY UNIT CHARGE</td>

                    <td>UNIT Charge</td>--%>
                    <td>OFF PEAK UNIT CHARGE</td>
                    <td>Other Charges </td>
                    <td>Uplift</td>
                    <td>Yearly Charge</td>





                    <td>Mail</td>
                    <td>Show </td>
                    <td>Save</td>





                </tr>
                <asp:UpdatePanel ID="UpdatePanel94" runat="server">
                    <ContentTemplate>



                        <tr>



                            <td>
                                <asp:ImageButton ID="bga60supplierall" runat="server" Height="39px" ImageUrl="~/britishgas.jpg" Width="175px" />
                            </td>
                            <td>
                                <asp:Label ID="lblBga60programall" runat="server" Text="British Gas new"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbga60scall" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txtbga60dayall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbga60nightall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbga60ewall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <%-- <td>
                                <asp:TextBox ID="txtbga60wdall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>

                            <td>
                                <asp:TextBox ID="txtbga60unitall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>--%>
                            <td>
                                <asp:TextBox ID="txtbga60offpeakall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbga60otherall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbga60upliftall" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="2.0" step="0.1" AutoPostBack="true" OnTextChanged="txtbga60upliftall_TextChanged"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbga60rateall" runat="server" Text="0" Width="75px"></asp:TextBox>

                            </td>

                            <td>
                                <asp:CheckBox ID="chkbga60all" runat="server" Text="" />
                            </td>
                            <td>
                                <asp:Button ID="Button170" runat="server" Text="Show" />
                            </td>
                            <td>
                                <asp:Button ID="Button171" runat="server" Text="Save" /></td>




                        </tr>

                    </ContentTemplate>
                </asp:UpdatePanel>

                <asp:UpdatePanel ID="UpdatePanel95" runat="server">
                    <ContentTemplate>



                        <tr>



                            <td>
                                <asp:ImageButton ID="bge60supplierall" runat="server" Height="39px" ImageUrl="~/britishgas.jpg" Width="175px" />
                            </td>
                            <td>
                                <asp:Label ID="lblBge60programall" runat="server" Text="British Gas Re new "></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbge60scall" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txtbge60dayall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbge60nightall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbge60ewall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <%-- <td>
                                <asp:TextBox ID="txtbge60wdall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>

                            <td>
                                <asp:TextBox ID="txtbge60unitall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>--%>
                            <td>
                                <asp:TextBox ID="txtbge60offpeakall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbge60otherall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbge60upliftall" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="2.0" step="0.1" AutoPostBack="true"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbfge60rateall" runat="server" Text="0" Width="75px"></asp:TextBox>

                            </td>

                            <td>
                                <asp:CheckBox ID="chkbge60all" runat="server" Text="" />
                            </td>
                            <td>
                                <asp:Button ID="Button172" runat="server" Text="Show" />
                            </td>
                            <td>
                                <asp:Button ID="Button173" runat="server" Text="Save" /></td>



                        </tr>

                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:UpdatePanel ID="UpdatePanel96" runat="server">
                    <ContentTemplate>



                        <tr>



                            <td>
                                <asp:ImageButton ID="bgl60supplierall" runat="server" Height="39px" ImageUrl="~/images/bgl.png" Width="175px" />
                            </td>
                            <td>
                                <asp:Label ID="lblbgla60programall" runat="server" Text="British Gas Lite new"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbgla60scall" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txtbgla60dayall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbgla60nightall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbgla60ewall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <%--<td>
                                <asp:TextBox ID="txtbgla60wdall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>

                            <td>
                                <asp:TextBox ID="txtbgla60unitall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>--%>
                            <td>
                                <asp:TextBox ID="txtbgla60offpeakall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbgla60otherall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbgla60upliftall" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="1.5" step="0.1" AutoPostBack="true"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbfgla60rateall" runat="server" Text="0" Width="75px"></asp:TextBox>

                            </td>

                            <td>
                                <asp:CheckBox ID="chkbgla60all" runat="server" />
                            </td>
                            <td>
                                <asp:Button ID="Button174" runat="server" Text="Show" />
                            </td>
                            <td>
                                <asp:Button ID="Button175" runat="server" Text="Save" /></td>



                        </tr>

                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:UpdatePanel ID="UpdatePanel97" runat="server">
                    <ContentTemplate>



                        <tr>



                            <td>
                                <asp:ImageButton ID="bgle60supplierall" runat="server" Height="39px" ImageUrl="~/images/bgl.png" Width="175px" />
                            </td>
                            <td>
                                <asp:Label ID="lblbgle60programall" runat="server" Text="British Gas Lite new"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbgle60scall" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txtbgle60dayall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbgle60nightall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbgle60ewall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <%-- <td>
                                <asp:TextBox ID="txtbgle60wdall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>

                            <td>
                                <asp:TextBox ID="txtbgle60unitall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>--%>
                            <td>
                                <asp:TextBox ID="txtbgle60offpeakall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbgle60otherall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbgle60upliftall" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="1.5" step="0.1" AutoPostBack="true"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbfgle60rateall" runat="server" Text="0" Width="75px"></asp:TextBox>

                            </td>

                            <td>
                                <asp:CheckBox ID="chkbgle60all" runat="server" />
                            </td>
                            <td>
                                <asp:Button ID="Button176" runat="server" Text="Show" />
                            </td>
                            <td>
                                <asp:Button ID="Button177" runat="server" Text="Save" /></td>



                        </tr>

                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:UpdatePanel ID="UpdatePanel98" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>



                        <tr>



                            <td>
                                <asp:ImageButton ID="edfa60supplierall" runat="server" Height="39px" ImageUrl="~/images/edf.jpg" Width="175px" />
                            </td>
                            <td>
                                <asp:Label ID="lbledfa60programall" runat="server" Text="British Gas Lite new"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtedfa60scall" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txtedfa60dayall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtedfa60nightall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtedfa60ewall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <%-- <td>
                                <asp:TextBox ID="txtedfa60wdall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>

                            <td>
                                <asp:TextBox ID="txtedfa60unitall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>--%>
                            <td>
                                <asp:TextBox ID="txtedfa60offpeakall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtedfa60otherall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtedfa60upliftall" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="1.5" step="0.1" AutoPostBack="true"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtedf60rateall" runat="server" Text="0" Width="75px"></asp:TextBox>

                            </td>

                            <td>
                                <asp:CheckBox ID="chkedf60all" runat="server" />
                            </td>
                            <td>
                                <asp:Button ID="Button178" runat="server" Text="Show" />
                            </td>
                            <td>
                                <asp:Button ID="Button179" runat="server" Text="Save" /></td>



                        </tr>



                    </ContentTemplate>


                </asp:UpdatePanel>

                <asp:UpdatePanel ID="UpdatePanel99" runat="server">
                    <ContentTemplate>



                        <tr>



                            <td>
                                <asp:ImageButton ID="dea60supplierall" runat="server" Height="39px" ImageUrl="~/images/de.jpg" Width="175px" />
                            </td>
                            <td>
                                <asp:Label ID="lbldea60programall" runat="server" Text="British Gas Lite new"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtdea60scall" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txtdea60dayall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtdea60nightall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtdea60ewall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <%--  <td>
                                <asp:TextBox ID="txtdea60wdall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>

                            <td>
                                <asp:TextBox ID="txtdea60unitall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>--%>
                            <td>
                                <asp:TextBox ID="txtdea60offpeakall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtdea60otherall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtdea60upliftall" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="2.0" step="0.1" AutoPostBack="true" OnTextChanged="txtdea60upliftall_TextChanged"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtde60rateall" runat="server" Text="0" Width="75px"></asp:TextBox>

                            </td>


                            <td>
                                <asp:CheckBox ID="chkdea60all" runat="server" />
                            </td>
                            <td>
                                <asp:Button ID="Button180" runat="server" Text="Show" />
                            </td>
                            <td>
                                <asp:Button ID="Button181" runat="server" Text="Save" /></td>


                        </tr>

                    </ContentTemplate>
                </asp:UpdatePanel>

                                            <asp:UpdatePanel ID="UpdatePanel149" runat="server">
                                <ContentTemplate>



                                    <tr>



                                        <td>
                                            <asp:ImageButton ID="deawc60supplier60all" runat="server" Height="39px" ImageUrl="~/images/de.jpg" Width="175px" />
                                        </td>
                                        <td>
                                            <asp:Label ID="lbldeawc60program60all" runat="server" Text="British Gas Lite new"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtdeawc60sc60all" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="txtdeawc60day60all" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtdeawc60night60all" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtdeawc60ew60all" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <%-- <td>
                                            <asp:TextBox ID="txtdeawc60wd60all" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>

                                        <td>
                                            <asp:TextBox ID="txtdeawc60unit60all" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>--%>
                                        <td>
                                            <asp:TextBox ID="txtdeawc60offpeak60all" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtdeawc60other60all" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtdeawc60uplift60all" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="2.0" step="0.1" AutoPostBack="true"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtdeawc60all" runat="server" Text="0" Width="75px"></asp:TextBox>

                                        </td>

                                        <td>
                                            <asp:CheckBox ID="chkdeawc60all" runat="server" />
                                        </td>

                                        <td>
                                            <asp:Button ID="btndeawc60showall" runat="server" Text="Show" />
                                        </td>
                                        <td>
                                            <asp:Button ID="btndeawc60saveall" runat="server" Text="Save" /></td>



                                    </tr>

                                </ContentTemplate>
                            </asp:UpdatePanel>



                <asp:UpdatePanel ID="UpdatePanel100" runat="server">
                    <ContentTemplate>



                        <tr>



                            <td>
                                <asp:ImageButton ID="tgp60supplierall" runat="server" Height="39px" ImageUrl="~/images/tglogo.png" Width="175px" />
                            </td>
                            <td>
                                <asp:Label ID="lbltgp60programall" runat="server" Text="Total Energy"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txttgp60scall" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txttgp60dayall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txttgp60nightall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txttgp60ewall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <%--  <td>
                                <asp:TextBox ID="txttgp60wdall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>

                            <td>
                                <asp:TextBox ID="txttgp60unitall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>--%>
                            <td>
                                <asp:TextBox ID="txttgp60offpeakall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txttgp60otherall" runat="server" Text="0" Width="75px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txttgp60upliftall" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="3.0" step="0.1" AutoPostBack="true" OnTextChanged="txttgp60upliftall_TextChanged"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txttgp60rateall" runat="server" Text="0" Width="75px"></asp:TextBox>

                            </td>

                            <td>
                                <asp:CheckBox ID="chktgp60all" runat="server" />
                            </td>
                            <td>
                                <asp:Button ID="Button182" runat="server" Text="Show" />
                            </td>
                            <td>
                                <asp:Button ID="Button183" runat="server" Text="Save" /></td>



                        </tr>

                    </ContentTemplate>
                </asp:UpdatePanel>

                <asp:UpdatePanel ID="UpdatePanel129" runat="server">
                    <ContentTemplate>







                        <td>
                            <asp:ImageButton ID="tgpw60supplierall" runat="server" Height="39px" ImageUrl="~/images/tglogo.png" Width="175px" />
                        </td>
                        <td>
                            <asp:Label ID="lbltgpw60programall" runat="server" Text="Total Energy"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txttgpw60scall" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="txttgpw60dayall" runat="server" Text="0" Width="75px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txttgpw60nightall" runat="server" Text="0" Width="75px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txttgpw60ewall" runat="server" Text="0" Width="75px"></asp:TextBox>
                        </td>
                        <%-- <td>
                                                        <asp:TextBox ID="txttgpw60wdall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                    </td>

                                                    <td>
                                                        <asp:TextBox ID="txttgpw60unitall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                                    </td>--%>
                        <td>
                            <asp:TextBox ID="txttgpw60offpeakall" runat="server" Text="0" Width="75px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txttgpw60otherall" runat="server" Text="0" Width="75px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txttgpw60upliftall" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="3.0" step="0.1" AutoPostBack="true"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txttgpw60rateall" runat="server" Text="0" Width="75px"></asp:TextBox>

                        </td>
                        <td>
                            <asp:CheckBox ID="chktgpw60all" runat="server" />
                        </td>
                        </td>
                             <td>
                                 <asp:Button ID="btntgpw60show" runat="server" Text="Show" />
                             </td>
                        <td>
                            <asp:Button ID="Button24" runat="server" Text="Save" /></td>





                        </tr>

                    </ContentTemplate>

                </asp:UpdatePanel>


                                <asp:UpdatePanel ID="UpdatePanel177" runat="server">
                                    <ContentTemplate>







                                        <td>
                                            <asp:ImageButton ID="utila60supplierall" runat="server" Height="39px" ImageUrl="~/images/utilita.png" Width="175px" />
                                        </td>
                                        <td>
                                            <asp:Label ID="lblutila60programall" runat="server" Text="Utilita Energy new"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtutila60scall" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="txtutila60dayall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtutila60nightall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtutila60ewall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <%-- <td>
                                            <asp:TextBox ID="txtutila60wdall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>

                                        <td>
                                            <asp:TextBox ID="txtutila60unitall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>--%>
                                        <td>
                                            <asp:TextBox ID="txtutila60offpeakall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtutila60otherall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtutila60upliftall" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="1.5" step="0.1" AutoPostBack="true" ></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtutil60Rateall" runat="server" Text="0" Width="75px"></asp:TextBox>

                                        </td>

                                        <td>
                                            <asp:CheckBox ID="chkutil60all" runat="server" />
                                        </td>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnutil60all" runat="server" Text="Show" />
                                        </td>
                                        <td>
                                            <asp:Button ID="Button92" runat="server" Text="Save" /></td>



                                        </tr>

                                    </ContentTemplate>
                                </asp:UpdatePanel>
								
								
								 <asp:UpdatePanel ID="UpdatePanel178" runat="server">
                                    <ContentTemplate>







                                        <td>
                                            <asp:ImageButton ID="gulfa60supplierall" runat="server" Height="39px" ImageUrl="~/images/gulf.png" Width="175px" />
                                        </td>
                                        <td>
                                            <asp:Label ID="lblgulfa60programall" runat="server" Text="Gulf  Energy"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtgulfa60scall" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="txtgulfa60dayall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtgulfa60nightall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtgulfa60ewall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <%-- <td>
                                            <asp:TextBox ID="txtgulfa60wdall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>

                                        <td>
                                            <asp:TextBox ID="txtgulfa60unitall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>--%>
                                        <td>
                                            <asp:TextBox ID="txtgulfa60offpeakall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtgulfa60otherall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtgulfa60upliftall" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="1.5" step="0.1" AutoPostBack="true"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtgulf60Rateall" runat="server" Text="0" Width="75px"></asp:TextBox>

                                        </td>

                                        <td>
                                            <asp:CheckBox ID="chkgulf60all" runat="server" />
                                        </td>
                                        </td>
                                        <td>
                                            <asp:Button ID="btngulf60all" runat="server" Text="Show" OnClick="btngulf60allShow_Click" />
                                        </td>
                                        <td>
                                            <asp:Button ID="Button94" runat="server" Text="Save" /></td>



                                        </tr>

                                    </ContentTemplate>
                                </asp:UpdatePanel>
								
								  <asp:UpdatePanel ID="UpdatePanel179" runat="server">
                                    <ContentTemplate>







                                        <td>
                                            <asp:ImageButton ID="yuea60supplierall" runat="server" Height="39px" ImageUrl="~/images/yue.jpg" Width="175px" />
                                        </td>
                                        <td>
                                            <asp:Label ID="lblyuea60programall" runat="server" Text="YU Energy"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtyuea60scall" runat="server" Width="75px" Text="0"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="txtyuea60dayall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtyuea60nightall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtyuea60ewall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <%-- <td>
                                            <asp:TextBox ID="txtyuea60wdall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>

                                        <td>
                                            <asp:TextBox ID="txtyuea60unitall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>--%>
                                        <td>
                                            <asp:TextBox ID="txtyuea60offpeakall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtyuea60otherall" runat="server" Text="0" Width="75px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtyuea60upliftall" runat="server" Text="0" Width="75px" TextMode="Number" min="0.0" max="1.5" step="0.1" AutoPostBack="true" ></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtyue60Rateall" runat="server" Text="0" Width="75px"></asp:TextBox>

                                        </td>

                                        <td>
                                            <asp:CheckBox ID="chkyue60all" runat="server" />
                                        </td>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnyue60all" runat="server" Text="Show" OnClick="btnyue60allShow_Click" />
                                        </td>
                                        <td>
                                            <asp:Button ID="Button98" runat="server" Text="Save" /></td>



                                        </tr>

                                    </ContentTemplate>
                                </asp:UpdatePanel>



            </table>




        </asp:View>

        <asp:View ID="Result" runat="server">
            <div class="container">
                <hr />
                <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0">


                    <ajaxToolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="12 Months">
                        <ContentTemplate>
                            <asp:GridView ID="gvResult12" runat="server" Width="100%"></asp:GridView>
                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>
                    <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="24 Months">
                        <ContentTemplate>
                            <asp:GridView ID="gvResult24" runat="server" Width="100%"></asp:GridView>
                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>
                    <ajaxToolkit:TabPanel ID="TabPanel3" runat="server" HeaderText="36 Months">
                        <ContentTemplate>
                            <asp:GridView ID="gvResult36" runat="server" Width="100%"></asp:GridView>
                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>
                    <ajaxToolkit:TabPanel ID="TabPanel4" runat="server" HeaderText="48 Months">
                        <ContentTemplate>
                            <asp:GridView ID="gvResult48" runat="server" Width="100%"></asp:GridView>
                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>
                    <ajaxToolkit:TabPanel ID="TabPanel5" runat="server" HeaderText="60 Months">
                        <ContentTemplate>
                            <asp:GridView ID="gvResult60" runat="server" Width="95%"></asp:GridView>
                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>


                </ajaxToolkit:TabContainer>

                <hr />
            </div>





        </asp:View>




    </asp:MultiView>
</asp:Content>
