using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



namespace GreenOcean
{
    [Serializable]
    public partial class electricityview : System.Web.UI.Page
    {
        stdlb lib = new stdlb();
        string myConnectionString = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
       // string myConnectionString = "Data Source=DESKTOP-19DCAF9;Initial Catalog = greenway; Integrated Security = True";
        string winopen = DateTime.Today.ToString();
        string winclose = DateTime.Now.AddYears(1).ToString();
        proposal ps = new proposal();


        protected void Page_Load(object sender, EventArgs e)
        {

            lblEac.Text = txtEac.Text;
            if (!Page.IsPostBack)
            {
                lblDuration.Text = "12";
                Multiview1.SetActiveView(View12);

                if (Request.QueryString["eac"] == null)
                {
                    Response.Redirect("login.aspx");
                }

                lblEac.Text = Request.QueryString["eac"];
                lblMTC.Text = Request.QueryString["mtc"];
                lblProfile.Text = Request.QueryString["profile"];
                lblRegion.Text = Request.QueryString["region"];
                lblBusinessType.Text = Request.QueryString["bt"];
                lblDuration.Text = Request.QueryString["duration"];
                lblCurrentSupplier.Text = Request.QueryString["supplier"];
                lblStartdate.Text = Request.QueryString["startdate"];
                lblELEPayment.Text = Request.QueryString["pm"];
                txtEac.Text = Request.QueryString["eac"];
                txtBusiness.Text = Session["business"].ToString();

                DateTime dtwindowclose = Convert.ToDateTime(lblStartdate.Text);
                dtwindowclose = dtwindowclose.AddYears(1);
                string winclose = Convert.ToString(dtwindowclose);
                getbgplan();


                getbgliteplan();
               

                gethevsplan();
                getdeeplan();

                getedfplan();

                getnpowerplan();

                getgazplan();

                getopusplan();

                getpeplan();

                getspeplan();

                getsseplan();

                getopusplan();
                getopusplan1();
                getopusplan2();
                getopusplan1();

                geteonplan();
                GetUtilita();
                GetGulf();
                Getyu();

                Bindbga();
                Bindbgl();
                Bindedf();
                Bindde();
                Bindpe();
                gazpron();
                SSE();
                Npower();
                Spe();
                Tgp();
                bindeon();
                BindOpus();
                Hevs();
                TgpWithouSc();
                BindGulf();
                Bindyuee();

                Calculation();

            }
        }
        #region Opus Calculation
        void BindOpus()
           // 12 Months
        {

            string dayrate, weekday, unitrate = "0";
            dayrate = "0";
            weekday = "0";
            unitrate = "0";

            if (lblProfile.Text != "00")
            {
                txtopus12sc.Text = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "12", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Standing Charge");

                dayrate = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "12", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Day Rate");

                unitrate = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "12", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Unit Rate");


                txtopus12ew.Text = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "12", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Eve & Weekend Rate");


                txtopus12night.Text = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "12", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Night Rate");


                txtopus12offpeak.Text = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "12", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Off Peak Rate");

                weekday = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "12", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Weekday Rate");
                if (txtopus12ew.Text == "0")
                {
                    txtopus12ew.Text = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "12", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Eve, weekend & Night Rate");

                }

                txtopus12day.Text = lib.DayRate(dayrate, weekday, unitrate);



                txtopus12sc.ToolTip = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "12", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Standing Charge");
                dayrate = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "12", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Day Rate");
                unitrate = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "12", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Unit Rate");
                txtopus12ew.ToolTip = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "12", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Eve & Weekend Rate");
                txtopus12night.ToolTip = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "12", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Night Rate");
                txtopus12offpeak.ToolTip = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "12", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Off Peak Rate");
                weekday = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "12", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Weekday Rate");
                if (txtopus12ew.ToolTip == "0")
                {
                    txtopus12ew.ToolTip = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "12", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Eve, weekend & Night Rate");

                }

                txtopus12day.ToolTip = lib.DayRate(dayrate, weekday, unitrate);


                // 24  Months

                txtopus24sc.Text = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "24", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Standing Charge");

                dayrate = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "24", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Day Rate");


                unitrate = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "24", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Unit Rate");


                txtopus24ew.Text = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "24", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Eve & Weekend Rate");


                txtopus24night.Text = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "24", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Night Rate");


                txtopus24offpeak.Text = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "24", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Off Peak Rate");

                weekday = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "24", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Weekday Rate");
                if (txtopus24ew.Text == "0")
                {
                    txtopus24ew.Text = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "24", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Eve, weekend & Night Rate");

                }


                txtopus24day.Text = lib.DayRate(dayrate, weekday, unitrate);


                txtopus24sc.ToolTip = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "24", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Standing Charge");
                dayrate = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "24", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Day Rate");
                txtopus24ew.ToolTip = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "24", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Eve & Weekend Rate");
                unitrate = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "24", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Unit Rate");
                txtopus24offpeak.ToolTip = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "24", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Off Peak Rate");
                weekday = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "24", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Weekday Rate");
                txtopus24night.ToolTip = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "24", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Night Rate");
                if (txtopus24ew.ToolTip == "0")
                {
                    txtopus24ew.ToolTip = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "24", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Eve, weekend & Night Rate");

                }

                txtopus24day.ToolTip = lib.DayRate(dayrate, weekday, unitrate);

                //    txtopus24day.ToolTip = lib.DayRate(dayrate, weekday, unitrate);


                // 36 Months

                txtopus36sc.Text = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "36", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Standing Charge");


                dayrate = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "36", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Day Rate");


                unitrate = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "36", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Unit Rate");

                txtopus36ew.Text = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "36", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Eve & Weekend Rate");


                txtopus36night.Text = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "36", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Night Rate");


                txtopus36offpeak.Text = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "36", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Off Peak Rate");

                if (txtopus36ew.Text == "0")
                {
                    txtopus36ew.Text = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "36", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Eve, weekend & Night Rate");

                }



                weekday = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "36", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Weekday Rate");

                txtopus36day.Text = lib.DayRate(dayrate, weekday, unitrate);

                txtopus36sc.ToolTip = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "36", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Standing Charge");
                dayrate = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "36", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Day Rate");
                unitrate = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "36", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Unit Rate");
                txtopus36ew.ToolTip = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "36", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Eve & Weekend Rate");
                txtopus36night.ToolTip = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "36", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Night Rate");
                txtopus36offpeak.ToolTip = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "36", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Off Peak Rate");
                if (txtopus36ew.ToolTip == "0")
                {
                    txtopus36ew.ToolTip = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "36", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Eve, weekend & Night Rate");

                }


                weekday = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "36", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Weekday Rate");
                txtopus36day.ToolTip = lib.DayRate(dayrate, weekday, unitrate);



                // 48 Months

                txtopus48sc.Text = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "48", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Standing Charge");

                dayrate = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "48", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Day Rate");
                unitrate = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "48", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Unit Rate");
                txtopus48ew.Text = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "48", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Eve & Weekend Rate");
                txtopus48night.Text = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "48", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Night Rate");

                txtopus48offpeak.Text = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "48", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Off Peak Rate");


                weekday = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "48", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Weekday Rate");
                if (txtopus48ew.Text == "0")
                {
                    txtopus48ew.Text = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "48", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Eve, weekend & Night Rate");

                }


                txtopus48day.Text = lib.DayRate(dayrate, weekday, unitrate);

                // Tooltips

                txtopus48sc.ToolTip = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "48", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Standing Charge");
                weekday = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "48", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Weekday Rate");
                txtopus48night.ToolTip = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "48", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Night Rate");


                dayrate = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "48", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Day Rate");
                unitrate = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "48", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Unit Rate");
                txtopus48ew.ToolTip = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "48", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Eve & Weekend Rate");
                txtopus48offpeak.ToolTip = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "48", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Off Peak Rate");
                if (txtopus48ew.ToolTip == "0")
                {
                    txtopus48ew.ToolTip = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "48", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Eve, weekend & Night Rate");

                }

                txtopus48day.ToolTip = lib.DayRate(dayrate, weekday, unitrate);


                // All months
                txtopus12scall.Text = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "12", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Standing Charge");


                dayrate = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "12", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Day Rate");


                unitrate = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "12", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Unit Rate");

                txtopus12ewall.Text = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "12", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Eve & Weekend Rate");

                txtopus12nightall.Text = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "12", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Night Rate");

                txtopus12offpeakall.Text = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "12", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Off Peak Rate");

                weekday = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "12", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Weekday Rate");


                txtopus12dayall.Text = lib.DayRate(dayrate, weekday, unitrate);


                // Tooltips

                txtopus12scall.ToolTip = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "12", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Standing Charge");
                dayrate = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "12", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Day Rate");
                unitrate = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "12", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Unit Rate");
                txtopus12ewall.ToolTip = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "12", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Eve & Weekend Rate");
                txtopus12nightall.ToolTip = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "12", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Night Rate");
                txtopus12offpeakall.ToolTip = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "12", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Off Peak Rate");
                weekday = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "12", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Weekday Rate");

                txtopus12dayall.ToolTip = lib.DayRate(dayrate, weekday, unitrate);


                // 24  Months

                txtopus24scall.Text = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "24", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Standing Charge");

                dayrate = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "24", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Day Rate");


                unitrate = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "24", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Unit Rate");

                txtopus24ewall.Text = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "24", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Eve & Weekend Rate");


                txtopus24nightall.Text = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "24", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Night Rate");


                txtopus24offpeakall.Text = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "24", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Off Peak Rate");


                weekday = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "24", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Weekday Rate");

                txtopus24dayall.Text = lib.DayRate(dayrate, weekday, unitrate);



                txtopus24scall.ToolTip = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "24", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Standing Charge");
                dayrate = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "24", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Day Rate");
                unitrate = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "24", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Unit Rate");
                txtopus24ewall.ToolTip = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "24", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Eve & Weekend Rate");
                txtopus24nightall.ToolTip = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "24", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Night Rate");
                txtopus24offpeakall.ToolTip = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "24", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Off Peak Rate");
                weekday = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "24", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Weekday Rate");

                txtopus24dayall.ToolTip = lib.DayRate(dayrate, weekday, unitrate);

                // 36 Months

                txtopus36scall.Text = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "36", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Standing Charge");


                dayrate = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "36", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Day Rate");

                unitrate = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "36", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Unit Rate");

                txtopus36ewall.Text = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "36", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Eve & Weekend Rate");


                txtopus36nightall.Text = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "36", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Night Rate");

                txtopus36offpeakall.Text = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "36", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Off Peak Rate");


                weekday = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "36", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Weekday Rate");
                txtopus36dayall.Text = lib.DayRate(dayrate, weekday, unitrate);





                txtopus36scall.ToolTip = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "12", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Standing Charge");
                dayrate = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "12", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Day Rate");
                unitrate = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "12", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Unit Rate");
                txtopus36ewall.ToolTip = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "12", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Eve & Weekend Rate");
                txtopus36nightall.ToolTip = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "12", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Night Rate");
                txtopus36offpeakall.ToolTip = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "12", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Off Peak Rate");
                weekday = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "12", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Weekday Rate");
                txtopus36dayall.ToolTip = lib.DayRate(dayrate, weekday, unitrate);

                // 48 Months

                txtopus48scall.Text = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "48", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Standing Charge");

                dayrate = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "48", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Day Rate");


                unitrate = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "48", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Unit Rate");

                txtopus48ewall.Text = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "48", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Eve & Weekend Rate");

                txtopus48nightall.Text = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "48", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Night Rate");


                txtopus48offpeakall.Text = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "48", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Off Peak Rate");


                weekday = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "48", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Weekday Rate");
                txtopus48dayall.Text = lib.DayRate(dayrate, weekday, unitrate);



                txtopus48scall.ToolTip = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "48", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Standing Charge");
                dayrate = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "48", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Day Rate");
                unitrate = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "48", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Unit Rate");
                txtopus48ewall.ToolTip = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "48", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Eve & Weekend Rate");
                txtopus48nightall.ToolTip = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "48", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Night Rate");
                txtopus48offpeakall.ToolTip = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "48", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Off Peak Rate");
                weekday = lib.Opus("Price", lblProfile.Text, lblRegion.Text, "48", lblOpusMeterType.Text, lblOpusMeterType1.Text, lblOpusMeterType2.Text, lblOpusMeterType3.Text, "Weekday Rate");
                txtopus48dayall.ToolTip = lib.DayRate(dayrate, weekday, unitrate);

            }

            if(lblProfile.Text == "00")
            {
                txtopus12sc.Text = lib.Opus("Price", "05", lblRegion.Text, "12", "HH", "", "", "", "Standing Charge");

                dayrate = lib.Opus("Price", "05", lblRegion.Text, "12", "HH", "", "", "", "Day Rate");

                unitrate = lib.Opus("Price", "05", lblRegion.Text, "12", "HH", "", "", "", "Unit Rate");


                txtopus12ew.Text = lib.Opus("Price", "05", lblRegion.Text, "12", "HH", "", "", "", "Eve & Weekend Rate");


                txtopus12night.Text = lib.Opus("Price", "05", lblRegion.Text, "12", "HH", "", "", "", "Night Rate");


                txtopus12offpeak.Text = lib.Opus("Price", "05", lblRegion.Text, "12", "HH", "", "", "", "Off Peak Rate");

                weekday = lib.Opus("Price", "05", lblRegion.Text, "12", "HH", "", "", "", "Weekday Rate");
                if (txtopus12ew.Text == "0")
                {
                    txtopus12ew.Text = lib.Opus("Price", "05", lblRegion.Text, "12", "HH", "", "", "", "Eve, weekend & Night Rate");

                }

                txtopus12day.Text = lib.DayRate(dayrate, weekday, unitrate);



                txtopus12sc.ToolTip = lib.Opus("Price", "05", lblRegion.Text, "12", "HH", "", "", "", "Standing Charge");
                dayrate = lib.Opus("Price", "05", lblRegion.Text, "12", "HH", "", "", "", "Day Rate");
                unitrate = lib.Opus("Price", "05", lblRegion.Text, "12", "HH", "", "", "", "Unit Rate");
                txtopus12ew.ToolTip = lib.Opus("Price", "05", lblRegion.Text, "12", "HH", "", "", "", "Eve & Weekend Rate");
                txtopus12night.ToolTip = lib.Opus("Price", "05", lblRegion.Text, "12", "HH", "", "", "", "Night Rate");
                txtopus12offpeak.ToolTip = lib.Opus("Price", "05", lblRegion.Text, "12", "HH", "", "", "", "Off Peak Rate");
                weekday = lib.Opus("Price", "05", lblRegion.Text, "12", "HH", "", "", "", "Weekday Rate");
                if (txtopus12ew.ToolTip == "0")
                {
                    txtopus12ew.ToolTip = lib.Opus("Price", "05", lblRegion.Text, "12", "HH", "", "", "", "Eve, weekend & Night Rate");

                }

                txtopus12day.ToolTip = lib.DayRate(dayrate, weekday, unitrate);


                // 24  Months

                txtopus24sc.Text = lib.Opus("Price", "05", lblRegion.Text, "24", "HH", "", "", "", "Standing Charge");

                dayrate = lib.Opus("Price", "05", lblRegion.Text, "24", "HH", "", "", "", "Day Rate");


                unitrate = lib.Opus("Price", "05", lblRegion.Text, "24", "HH", "", "", "", "Unit Rate");


                txtopus24ew.Text = lib.Opus("Price", "05", lblRegion.Text, "24", "HH", "", "", "", "Eve & Weekend Rate");


                txtopus24night.Text = lib.Opus("Price", "05", lblRegion.Text, "24", "HH", "", "", "", "Night Rate");


                txtopus24offpeak.Text = lib.Opus("Price", "05", lblRegion.Text, "24", "HH", "", "", "", "Off Peak Rate");

                weekday = lib.Opus("Price", "05", lblRegion.Text, "24", "HH", "", "", "", "Weekday Rate");
                if (txtopus24ew.Text == "0")
                {
                    txtopus24ew.Text = lib.Opus("Price", "05", lblRegion.Text, "24", "HH", "", "", "", "Eve, weekend & Night Rate");

                }


                txtopus24day.Text = lib.DayRate(dayrate, weekday, unitrate);


                txtopus24sc.ToolTip = lib.Opus("Price", "05", lblRegion.Text, "24", "HH", "", "", "", "Standing Charge");
                dayrate = lib.Opus("Price", "05", lblRegion.Text, "24", "HH", "", "", "", "Day Rate");
                txtopus24ew.ToolTip = lib.Opus("Price", "05", lblRegion.Text, "24", "HH", "", "", "", "Eve & Weekend Rate");
                unitrate = lib.Opus("Price", "05", lblRegion.Text, "24", "HH", "", "", "", "Unit Rate");
                txtopus24offpeak.ToolTip = lib.Opus("Price", "05", lblRegion.Text, "24", "HH", "", "", "", "Off Peak Rate");
                weekday = lib.Opus("Price", "05", lblRegion.Text, "24", "HH", "", "", "", "Weekday Rate");
                txtopus24night.ToolTip = lib.Opus("Price", "05", lblRegion.Text, "24", "HH", "", "", "", "Night Rate");
                if (txtopus24ew.ToolTip == "0")
                {
                    txtopus24ew.ToolTip = lib.Opus("Price", "05", lblRegion.Text, "24", "HH", "", "", "", "Eve, weekend & Night Rate");

                }

                txtopus24day.ToolTip = lib.DayRate(dayrate, weekday, unitrate);

                //    txtopus24day.ToolTip = lib.DayRate(dayrate, weekday, unitrate);


                // 36 Months

                txtopus36sc.Text = lib.Opus("Price", "05", lblRegion.Text, "36", "HH", "", "", "", "Standing Charge");


                dayrate = lib.Opus("Price", "05", lblRegion.Text, "36", "HH", "", "", "", "Day Rate");


                unitrate = lib.Opus("Price", "05", lblRegion.Text, "36", "HH", "", "", "", "Unit Rate");

                txtopus36ew.Text = lib.Opus("Price", "05", lblRegion.Text, "36", "HH", "", "", "", "Eve & Weekend Rate");


                txtopus36night.Text = lib.Opus("Price", "05", lblRegion.Text, "36", "HH", "", "", "", "Night Rate");


                txtopus36offpeak.Text = lib.Opus("Price", "05", lblRegion.Text, "36", "HH", "", "", "", "Off Peak Rate");

                if (txtopus36ew.Text == "0")
                {
                    txtopus36ew.Text = lib.Opus("Price", "05", lblRegion.Text, "36", "HH", "", "", "", "Eve, weekend & Night Rate");

                }



                weekday = lib.Opus("Price", "05", lblRegion.Text, "36", "HH", "", "", "", "Weekday Rate");

                txtopus36day.Text = lib.DayRate(dayrate, weekday, unitrate);

                txtopus36sc.ToolTip = lib.Opus("Price", "05", lblRegion.Text, "36", "HH", "", "", "", "Standing Charge");
                dayrate = lib.Opus("Price", "05", lblRegion.Text, "36", "HH", "", "", "", "Day Rate");
                unitrate = lib.Opus("Price", "05", lblRegion.Text, "36", "HH", "", "", "", "Unit Rate");
                txtopus36ew.ToolTip = lib.Opus("Price", "05", lblRegion.Text, "36", "HH", "", "", "", "Eve & Weekend Rate");
                txtopus36night.ToolTip = lib.Opus("Price", "05", lblRegion.Text, "36", "HH", "", "", "", "Night Rate");
                txtopus36offpeak.ToolTip = lib.Opus("Price", "05", lblRegion.Text, "36", "HH", "", "", "", "Off Peak Rate");
                if (txtopus36ew.ToolTip == "0")
                {
                    txtopus36ew.ToolTip = lib.Opus("Price", "05", lblRegion.Text, "36", "HH", "", "", "", "Eve, weekend & Night Rate");

                }


                weekday = lib.Opus("Price", "05", lblRegion.Text, "36", "HH", "", "", "", "Weekday Rate");
                txtopus36day.ToolTip = lib.DayRate(dayrate, weekday, unitrate);



                // 48 Months

                txtopus48sc.Text = lib.Opus("Price", "05", lblRegion.Text, "48", "HH", "", "", "", "Standing Charge");

                dayrate = lib.Opus("Price", "05", lblRegion.Text, "48", "HH", "", "", "", "Day Rate");
                unitrate = lib.Opus("Price", "05", lblRegion.Text, "48", "HH", "", "", "", "Unit Rate");
                txtopus48ew.Text = lib.Opus("Price", "05", lblRegion.Text, "48", "HH", "", "", "", "Eve & Weekend Rate");
                txtopus48night.Text = lib.Opus("Price", "05", lblRegion.Text, "48", "HH", "", "", "", "Night Rate");

                txtopus48offpeak.Text = lib.Opus("Price", "05", lblRegion.Text, "48", "HH", "", "", "", "Off Peak Rate");


                weekday = lib.Opus("Price", "05", lblRegion.Text, "48", "HH", "", "", "", "Weekday Rate");
                if (txtopus48ew.Text == "0")
                {
                    txtopus48ew.Text = lib.Opus("Price", "05", lblRegion.Text, "48", "HH", "", "", "", "Eve, weekend & Night Rate");

                }


                txtopus48day.Text = lib.DayRate(dayrate, weekday, unitrate);

                // Tooltips

                txtopus48sc.ToolTip = lib.Opus("Price", "05", lblRegion.Text, "48", "HH", "", "", "", "Standing Charge");
                weekday = lib.Opus("Price", "05", lblRegion.Text, "48", "HH", "", "", "", "Weekday Rate");
                txtopus48night.ToolTip = lib.Opus("Price", "05", lblRegion.Text, "48", "HH", "", "", "", "Night Rate");


                dayrate = lib.Opus("Price", "05", lblRegion.Text, "48", "HH", "", "", "", "Day Rate");
                unitrate = lib.Opus("Price", "05", lblRegion.Text, "48", "HH", "", "", "", "Unit Rate");
                txtopus48ew.ToolTip = lib.Opus("Price", "05", lblRegion.Text, "48", "HH", "", "", "", "Eve & Weekend Rate");
                txtopus48offpeak.ToolTip = lib.Opus("Price", "05", lblRegion.Text, "48", "HH", "", "", "", "Off Peak Rate");
                if (txtopus48ew.ToolTip == "0")
                {
                    txtopus48ew.ToolTip = lib.Opus("Price", "05", lblRegion.Text, "48", "HH", "", "", "", "Eve, weekend & Night Rate");

                }

                txtopus48day.ToolTip = lib.DayRate(dayrate, weekday, unitrate);


                // All months
                txtopus12scall.Text = lib.Opus("Price", "05", lblRegion.Text, "12", "HH", "", "", "", "Standing Charge");


                dayrate = lib.Opus("Price", "05", lblRegion.Text, "12", "HH", "", "", "", "Day Rate");


                unitrate = lib.Opus("Price", "05", lblRegion.Text, "12", "HH", "", "", "", "Unit Rate");

                txtopus12ewall.Text = lib.Opus("Price", "05", lblRegion.Text, "12", "HH", "", "", "", "Eve & Weekend Rate");

                txtopus12nightall.Text = lib.Opus("Price", "05", lblRegion.Text, "12", "HH", "", "", "", "Night Rate");

                txtopus12offpeakall.Text = lib.Opus("Price", "05", lblRegion.Text, "12", "HH", "", "", "", "Off Peak Rate");

                weekday = lib.Opus("Price", "05", lblRegion.Text, "12", "HH", "", "", "", "Weekday Rate");


                txtopus12dayall.Text = lib.DayRate(dayrate, weekday, unitrate);


                // Tooltips

                txtopus12scall.ToolTip = lib.Opus("Price", "05", lblRegion.Text, "12", "HH", "", "", "", "Standing Charge");
                dayrate = lib.Opus("Price", "05", lblRegion.Text, "12", "HH", "", "", "", "Day Rate");
                unitrate = lib.Opus("Price", "05", lblRegion.Text, "12", "HH", "", "", "", "Unit Rate");
                txtopus12ewall.ToolTip = lib.Opus("Price", "05", lblRegion.Text, "12", "HH", "", "", "", "Eve & Weekend Rate");
                txtopus12nightall.ToolTip = lib.Opus("Price", "05", lblRegion.Text, "12", "HH", "", "", "", "Night Rate");
                txtopus12offpeakall.ToolTip = lib.Opus("Price", "05", lblRegion.Text, "12", "HH", "", "", "", "Off Peak Rate");
                weekday = lib.Opus("Price", "05", lblRegion.Text, "12", "HH", "", "", "", "Weekday Rate");

                txtopus12dayall.ToolTip = lib.DayRate(dayrate, weekday, unitrate);


                // 24  Months

                txtopus24scall.Text = lib.Opus("Price", "05", lblRegion.Text, "24", "HH", "", "", "", "Standing Charge");

                dayrate = lib.Opus("Price", "05", lblRegion.Text, "24", "HH", "", "", "", "Day Rate");


                unitrate = lib.Opus("Price", "05", lblRegion.Text, "24", "HH", "", "", "", "Unit Rate");

                txtopus24ewall.Text = lib.Opus("Price", "05", lblRegion.Text, "24", "HH", "", "", "", "Eve & Weekend Rate");


                txtopus24nightall.Text = lib.Opus("Price", "05", lblRegion.Text, "24", "HH", "", "", "", "Night Rate");


                txtopus24offpeakall.Text = lib.Opus("Price", "05", lblRegion.Text, "24", "HH", "", "", "", "Off Peak Rate");


                weekday = lib.Opus("Price", "05", lblRegion.Text, "24", "HH", "", "", "", "Weekday Rate");

                txtopus24dayall.Text = lib.DayRate(dayrate, weekday, unitrate);



                txtopus24scall.ToolTip = lib.Opus("Price", "05", lblRegion.Text, "24", "HH", "", "", "", "Standing Charge");
                dayrate = lib.Opus("Price", "05", lblRegion.Text, "24", "HH", "", "", "", "Day Rate");
                unitrate = lib.Opus("Price", "05", lblRegion.Text, "24", "HH", "", "", "", "Unit Rate");
                txtopus24ewall.ToolTip = lib.Opus("Price", "05", lblRegion.Text, "24", "HH", "", "", "", "Eve & Weekend Rate");
                txtopus24nightall.ToolTip = lib.Opus("Price", "05", lblRegion.Text, "24", "HH", "", "", "", "Night Rate");
                txtopus24offpeakall.ToolTip = lib.Opus("Price", "05", lblRegion.Text, "24", "HH", "", "", "", "Off Peak Rate");
                weekday = lib.Opus("Price", "05", lblRegion.Text, "24", "HH", "", "", "", "Weekday Rate");

                txtopus24dayall.ToolTip = lib.DayRate(dayrate, weekday, unitrate);

                // 36 Months

                txtopus36scall.Text = lib.Opus("Price", "05", lblRegion.Text, "36", "HH", "", "", "", "Standing Charge");


                dayrate = lib.Opus("Price", "05", lblRegion.Text, "36", "HH", "", "", "", "Day Rate");

                unitrate = lib.Opus("Price", "05", lblRegion.Text, "36", "HH", "", "", "", "Unit Rate");

                txtopus36ewall.Text = lib.Opus("Price", "05", lblRegion.Text, "36", "HH", "", "", "", "Eve & Weekend Rate");


                txtopus36nightall.Text = lib.Opus("Price", "05", lblRegion.Text, "36", "HH", "", "", "", "Night Rate");

                txtopus36offpeakall.Text = lib.Opus("Price", "05", lblRegion.Text, "36", "HH", "", "", "", "Off Peak Rate");


                weekday = lib.Opus("Price", "05", lblRegion.Text, "36", "HH", "", "", "", "Weekday Rate");
                txtopus36dayall.Text = lib.DayRate(dayrate, weekday, unitrate);





                txtopus36scall.ToolTip = lib.Opus("Price", "05", lblRegion.Text, "12", "HH", "", "", "", "Standing Charge");
                dayrate = lib.Opus("Price", "05", lblRegion.Text, "12", "HH", "", "", "", "Day Rate");
                unitrate = lib.Opus("Price", "05", lblRegion.Text, "12", "HH", "", "", "", "Unit Rate");
                txtopus36ewall.ToolTip = lib.Opus("Price", "05", lblRegion.Text, "12", "HH", "", "", "", "Eve & Weekend Rate");
                txtopus36nightall.ToolTip = lib.Opus("Price", "05", lblRegion.Text, "12", "HH", "", "", "", "Night Rate");
                txtopus36offpeakall.ToolTip = lib.Opus("Price", "05", lblRegion.Text, "12", "HH", "", "", "", "Off Peak Rate");
                weekday = lib.Opus("Price", "05", lblRegion.Text, "12", "HH", "", "", "", "Weekday Rate");
                txtopus36dayall.ToolTip = lib.DayRate(dayrate, weekday, unitrate);

                // 48 Months

                txtopus48scall.Text = lib.Opus("Price", "05", lblRegion.Text, "48", "HH", "", "", "", "Standing Charge");

                dayrate = lib.Opus("Price", "05", lblRegion.Text, "48", "HH", "", "", "", "Day Rate");


                unitrate = lib.Opus("Price", "05", lblRegion.Text, "48", "HH", "", "", "", "Unit Rate");

                txtopus48ewall.Text = lib.Opus("Price", "05", lblRegion.Text, "48", "HH", "", "", "", "Eve & Weekend Rate");

                txtopus48nightall.Text = lib.Opus("Price", "05", lblRegion.Text, "48", "HH", "", "", "", "Night Rate");


                txtopus48offpeakall.Text = lib.Opus("Price", "05", lblRegion.Text, "48", "HH", "", "", "", "Off Peak Rate");


                weekday = lib.Opus("Price", "05", lblRegion.Text, "48", "HH", "", "", "", "Weekday Rate");
                txtopus48dayall.Text = lib.DayRate(dayrate, weekday, unitrate);



                txtopus48scall.ToolTip = lib.Opus("Price", "05", lblRegion.Text, "48", "HH", "", "", "", "Standing Charge");
                dayrate = lib.Opus("Price", "05", lblRegion.Text, "48", "HH", "", "", "", "Day Rate");
                unitrate = lib.Opus("Price", "05", lblRegion.Text, "48", "HH", "", "", "", "Unit Rate");
                txtopus48ewall.ToolTip = lib.Opus("Price", "05", lblRegion.Text, "48", "HH", "", "", "", "Eve & Weekend Rate");
                txtopus48nightall.ToolTip = lib.Opus("Price", "05", lblRegion.Text, "48", "HH", "", "", "", "Night Rate");
                txtopus48offpeakall.ToolTip = lib.Opus("Price", "05", lblRegion.Text, "48", "HH", "", "", "", "Off Peak Rate");
                weekday = lib.Opus("Price", "05", lblRegion.Text, "48", "HH", "", "", "", "Weekday Rate");
                txtopus48dayall.ToolTip = lib.DayRate(dayrate, weekday, unitrate);





            }

        }

        #endregion

        #region Eon Calculation

        void bindeon()
        {
            if(lblELEPayment.Text == "DD")
            {
                txteon12sc.Text = lib.Eon("DDStandingCharge", lblProfile.Text, lblRegion.Text ,lblEONEMetertype.Text, "12",lblEONEMetertype.Text, lblEac.Text);
                txteon12day.Text = lib.Eon("DDDayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "12", lblEONEMetertype.Text, lblEac.Text);
                txteon12night.Text = lib.Eon("DDNightUnitPrice", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "12", lblEONEMetertype.Text, lblEac.Text);
                txteon12ew.Text =lib.Eon("DDEveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "12", lblEONEMetertype.Text, lblEac.Text);

                txteon12sc.ToolTip = lib.Eon("DDStandingCharge", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "12", lblEONEMetertype.Text, lblEac.Text);
                txteon12day.ToolTip = lib.Eon("DDDayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "12", lblEONEMetertype.Text, lblEac.Text);
                txteon12night.ToolTip = lib.Eon("DDNightUnitPrice", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "12", lblEONEMetertype.Text, lblEac.Text);
                txteon12ew.ToolTip = lib.Eon("DDEveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "12", lblEONEMetertype.Text, lblEac.Text);

                txteon12scall.Text = lib.Eon("DDStandingCharge", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "12", lblEONEMetertype.Text, lblEac.Text);
                txteon12dayall.Text = lib.Eon("DDDayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "12", lblEONEMetertype.Text, lblEac.Text);
                txteon12nightall.Text = lib.Eon("DDNightUnitPrice", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "12", lblEONEMetertype.Text, lblEac.Text);
                txteon12ewall.Text = lib.Eon("DDEveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "12", lblEONEMetertype.Text, lblEac.Text);

                txteon12scall.ToolTip = lib.Eon("DDStandingCharge", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "12", lblEONEMetertype.Text, lblEac.Text);
                txteon12dayall.ToolTip = lib.Eon("DDDayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "12", lblEONEMetertype.Text, lblEac.Text);
                txteon12nightall.ToolTip = lib.Eon("DDNightUnitPrice", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "12", lblEONEMetertype.Text, lblEac.Text);
                txteon12ewall.ToolTip = lib.Eon("DDEveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "12", lblEONEMetertype.Text, lblEac.Text);

            }
            else
            {
                txteon12sc.Text = lib.Eon("StandingCharge", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "12", lblEONEMetertype.Text, lblEac.Text);
                txteon12day.Text = lib.Eon("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "12", lblEONEMetertype.Text, lblEac.Text);
                txteon12night.Text = lib.Eon("NightUnitPrice", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "12", lblEONEMetertype.Text, lblEac.Text);
                txteon12ew.Text = lib.Eon("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "12", lblEONEMetertype.Text, lblEac.Text);

                txteon12sc.ToolTip = lib.Eon("StandingCharge", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "12", lblEONEMetertype.Text, lblEac.Text);
                txteon12day.ToolTip = lib.Eon("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "12", lblEONEMetertype.Text, lblEac.Text);
                txteon12night.ToolTip = lib.Eon("NightUnitPrice", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "12", lblEONEMetertype.Text, lblEac.Text);
                txteon12ew.ToolTip = lib.Eon("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "12", lblEONEMetertype.Text, lblEac.Text);

                txteon12scall.Text = lib.Eon("StandingCharge", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "12", lblEONEMetertype.Text, lblEac.Text);
                txteon12dayall.Text = lib.Eon("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "12", lblEONEMetertype.Text, lblEac.Text);
                txteon12nightall.Text = lib.Eon("NightUnitPrice", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "12", lblEONEMetertype.Text, lblEac.Text);
                txteon12ewall.Text = lib.Eon("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "12", lblEONEMetertype.Text, lblEac.Text);

                txteon12scall.ToolTip = lib.Eon("StandingCharge", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "12", lblEONEMetertype.Text, lblEac.Text);
                txteon12dayall.ToolTip = lib.Eon("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "12", lblEONEMetertype.Text, lblEac.Text);
                txteon12nightall.ToolTip = lib.Eon("NightUnitPrice", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "12", lblEONEMetertype.Text, lblEac.Text);
                txteon12ewall.ToolTip = lib.Eon("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "12", lblEONEMetertype.Text, lblEac.Text);

            }

            if (lblELEPayment.Text == "DD")
            {
                txteon24sc.Text = lib.Eon("DDStandingCharge", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "24", lblEONEMetertype.Text, lblEac.Text);
                txteon24day.Text = lib.Eon("DDDayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "24", lblEONEMetertype.Text, lblEac.Text);
                txteon24night.Text = lib.Eon("DDNightUnitPrice", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "24", lblEONEMetertype.Text, lblEac.Text);
                txteon24ew.Text = lib.Eon("DDEveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "24", lblEONEMetertype.Text, lblEac.Text);

                txteon24sc.ToolTip = lib.Eon("DDStandingCharge", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "24", lblEONEMetertype.Text, lblEac.Text);
                txteon24day.ToolTip = lib.Eon("DDDayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "24", lblEONEMetertype.Text, lblEac.Text);
                txteon24night.ToolTip = lib.Eon("DDNightUnitPrice", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "24", lblEONEMetertype.Text, lblEac.Text);
                txteon24ew.ToolTip = lib.Eon("DDEveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "24", lblEONEMetertype.Text, lblEac.Text);

                txteon24scall.Text = lib.Eon("DDStandingCharge", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "24", lblEONEMetertype.Text, lblEac.Text);
                txteon24dayall.Text = lib.Eon("DDDayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "24", lblEONEMetertype.Text, lblEac.Text);
                txteon24nightall.Text = lib.Eon("DDNightUnitPrice", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "24", lblEONEMetertype.Text, lblEac.Text);
                txteon24ewall.Text = lib.Eon("DDEveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "24", lblEONEMetertype.Text, lblEac.Text);

                txteon24scall.ToolTip = lib.Eon("DDStandingCharge", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "24", lblEONEMetertype.Text, lblEac.Text);
                txteon24dayall.ToolTip = lib.Eon("DDDayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "24", lblEONEMetertype.Text, lblEac.Text);
                txteon24nightall.ToolTip = lib.Eon("DDNightUnitPrice", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "24", lblEONEMetertype.Text, lblEac.Text);
                txteon24ewall.ToolTip = lib.Eon("DDEveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "24", lblEONEMetertype.Text, lblEac.Text);


            }
            else
            {
                txteon24sc.Text = lib.Eon("StandingCharge", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "24", lblEONEMetertype.Text, lblEac.Text);
                txteon24day.Text = lib.Eon("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "24", lblEONEMetertype.Text, lblEac.Text);
                txteon24night.Text = lib.Eon("NightUnitPrice", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "24", lblEONEMetertype.Text, lblEac.Text);
                txteon24ew.Text = lib.Eon("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "24", lblEONEMetertype.Text, lblEac.Text);

                txteon24sc.ToolTip = lib.Eon("StandingCharge", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "24", lblEONEMetertype.Text, lblEac.Text);
                txteon24day.ToolTip = lib.Eon("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "24", lblEONEMetertype.Text, lblEac.Text);
                txteon24night.ToolTip = lib.Eon("NightUnitPrice", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "24", lblEONEMetertype.Text, lblEac.Text);
                txteon24ew.ToolTip = lib.Eon("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "24", lblEONEMetertype.Text, lblEac.Text);

                txteon24scall.Text = lib.Eon("StandingCharge", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "24", lblEONEMetertype.Text, lblEac.Text);
                txteon24dayall.Text = lib.Eon("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "24", lblEONEMetertype.Text, lblEac.Text);
                txteon24nightall.Text = lib.Eon("NightUnitPrice", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "24", lblEONEMetertype.Text, lblEac.Text);
                txteon24ewall.Text = lib.Eon("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "24", lblEONEMetertype.Text, lblEac.Text);

                txteon24scall.ToolTip = lib.Eon("StandingCharge", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "24", lblEONEMetertype.Text, lblEac.Text);
                txteon24dayall.ToolTip = lib.Eon("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "24", lblEONEMetertype.Text, lblEac.Text);
                txteon24nightall.ToolTip = lib.Eon("NightUnitPrice", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "24", lblEONEMetertype.Text, lblEac.Text);
                txteon24ewall.ToolTip = lib.Eon("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "24", lblEONEMetertype.Text, lblEac.Text);


            }

            if (lblELEPayment.Text == "DD")
            {
                txteon36sc.Text = lib.Eon("DDStandingCharge", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "36", lblEONEMetertype.Text, lblEac.Text);
                txteon36day.Text = lib.Eon("DDDayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "36", lblEONEMetertype.Text, lblEac.Text);
                txteon36night.Text = lib.Eon("DDNightUnitPrice", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "36", lblEONEMetertype.Text, lblEac.Text);
                txteon36ew.Text = lib.Eon("DDEveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "36", lblEONEMetertype.Text, lblEac.Text);

                txteon36sc.ToolTip = lib.Eon("DDStandingCharge", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "36", lblEONEMetertype.Text, lblEac.Text);
                txteon36day.ToolTip = lib.Eon("DDDayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "36", lblEONEMetertype.Text, lblEac.Text);
                txteon36night.ToolTip = lib.Eon("DDNightUnitPrice", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "36", lblEONEMetertype.Text, lblEac.Text);
                txteon36ew.ToolTip = lib.Eon("DDEveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "36", lblEONEMetertype.Text, lblEac.Text);

                txteon36scall.Text = lib.Eon("DDStandingCharge", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "36", lblEONEMetertype.Text, lblEac.Text);
                txteon36dayall.Text = lib.Eon("DDDayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "36", lblEONEMetertype.Text, lblEac.Text);
                txteon36nightall.Text = lib.Eon("DDNightUnitPrice", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "36", lblEONEMetertype.Text, lblEac.Text);
                txteon36ewall.Text = lib.Eon("DDEveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "36", lblEONEMetertype.Text, lblEac.Text);

                txteon36scall.ToolTip = lib.Eon("DDStandingCharge", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "36", lblEONEMetertype.Text, lblEac.Text);
                txteon36dayall.ToolTip = lib.Eon("DDDayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "36", lblEONEMetertype.Text, lblEac.Text);
                txteon36nightall.ToolTip = lib.Eon("DDNightUnitPrice", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "36", lblEONEMetertype.Text, lblEac.Text);
                txteon36ewall.ToolTip = lib.Eon("DDEveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "36", lblEONEMetertype.Text, lblEac.Text);

            }
            else
            {
                txteon36sc.Text = lib.Eon("StandingCharge", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "48", lblEONEMetertype.Text, lblEac.Text);
                txteon36day.Text = lib.Eon("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "48", lblEONEMetertype.Text, lblEac.Text);
                txteon36night.Text = lib.Eon("NightUnitPrice", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "48", lblEONEMetertype.Text, lblEac.Text);
                txteon36ew.Text = lib.Eon("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "48", lblEONEMetertype.Text, lblEac.Text);

                txteon36sc.ToolTip = lib.Eon("StandingCharge", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "48", lblEONEMetertype.Text, lblEac.Text);
                txteon36day.ToolTip = lib.Eon("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "48", lblEONEMetertype.Text, lblEac.Text);
                txteon36night.ToolTip = lib.Eon("NightUnitPrice", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "48", lblEONEMetertype.Text, lblEac.Text);
                txteon36ew.ToolTip = lib.Eon("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "48", lblEONEMetertype.Text, lblEac.Text);


                txteon36scall.Text = lib.Eon("StandingCharge", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "48", lblEONEMetertype.Text, lblEac.Text);
                txteon36dayall.Text = lib.Eon("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "48", lblEONEMetertype.Text, lblEac.Text);
                txteon36nightall.Text = lib.Eon("NightUnitPrice", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "48", lblEONEMetertype.Text, lblEac.Text);
                txteon36ewall.Text = lib.Eon("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "48", lblEONEMetertype.Text, lblEac.Text);

                txteon36scall.ToolTip = lib.Eon("StandingCharge", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "48", lblEONEMetertype.Text, lblEac.Text);
                txteon36dayall.ToolTip = lib.Eon("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "48", lblEONEMetertype.Text, lblEac.Text);
                txteon36nightall.ToolTip = lib.Eon("NightUnitPrice", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "48", lblEONEMetertype.Text, lblEac.Text);
                txteon36ewall.ToolTip = lib.Eon("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "48", lblEONEMetertype.Text, lblEac.Text);

            }

            if (lblELEPayment.Text == "DD")
            {
                txteon48sc.Text = lib.Eon("DDStandingCharge", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "24", lblEONEMetertype.Text, lblEac.Text);
                txteon48day.Text = lib.Eon("DDDayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "24", lblEONEMetertype.Text, lblEac.Text);
                txteon48night.Text = lib.Eon("DDNightUnitPrice", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "24", lblEONEMetertype.Text, lblEac.Text);
                txteon48ew.Text = lib.Eon("DDEveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "24", lblEONEMetertype.Text, lblEac.Text);

                txteon48sc.ToolTip = lib.Eon("DDStandingCharge", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "24", lblEONEMetertype.Text, lblEac.Text);
                txteon48day.ToolTip = lib.Eon("DDDayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "24", lblEONEMetertype.Text, lblEac.Text);
                txteon48night.ToolTip = lib.Eon("DDNightUnitPrice", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "24", lblEONEMetertype.Text, lblEac.Text);
                txteon48ew.ToolTip = lib.Eon("DDEveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "24", lblEONEMetertype.Text, lblEac.Text);


                txteon48scall.Text = lib.Eon("DDStandingCharge", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "24", lblEONEMetertype.Text, lblEac.Text);
                txteon48dayall.Text = lib.Eon("DDDayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "24", lblEONEMetertype.Text, lblEac.Text);
                txteon48nightall.Text = lib.Eon("DDNightUnitPrice", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "24", lblEONEMetertype.Text, lblEac.Text);
                txteon48ewall.Text = lib.Eon("DDEveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "24", lblEONEMetertype.Text, lblEac.Text);

                txteon48scall.ToolTip = lib.Eon("DDStandingCharge", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "24", lblEONEMetertype.Text, lblEac.Text);
                txteon48dayall.ToolTip = lib.Eon("DDDayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "24", lblEONEMetertype.Text, lblEac.Text);
                txteon48nightall.ToolTip = lib.Eon("DDNightUnitPrice", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "24", lblEONEMetertype.Text, lblEac.Text);
                txteon48ewall.ToolTip = lib.Eon("DDEveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "24", lblEONEMetertype.Text, lblEac.Text);

            }
            else
            {
                txteon48sc.Text = lib.Eon("StandingCharge", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "24", lblEONEMetertype.Text, lblEac.Text);
                txteon48day.Text = lib.Eon("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "24", lblEONEMetertype.Text, lblEac.Text);
                txteon48night.Text = lib.Eon("NightUnitPrice", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "24", lblEONEMetertype.Text, lblEac.Text);
                txteon48ew.Text = lib.Eon("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "24", lblEONEMetertype.Text, lblEac.Text);

                txteon48sc.ToolTip = lib.Eon("StandingCharge", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "24", lblEONEMetertype.Text, lblEac.Text);
                txteon48day.ToolTip = lib.Eon("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "24", lblEONEMetertype.Text, lblEac.Text);
                txteon48night.ToolTip = lib.Eon("NightUnitPrice", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "24", lblEONEMetertype.Text, lblEac.Text);
                txteon48ew.ToolTip = lib.Eon("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "24", lblEONEMetertype.Text, lblEac.Text);

                txteon48scall.Text = lib.Eon("StandingCharge", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "24", lblEONEMetertype.Text, lblEac.Text);
                txteon48dayall.Text = lib.Eon("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "24", lblEONEMetertype.Text, lblEac.Text);
                txteon48nightall.Text = lib.Eon("NightUnitPrice", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "24", lblEONEMetertype.Text, lblEac.Text);
                txteon48ewall.Text = lib.Eon("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "24", lblEONEMetertype.Text, lblEac.Text);

                txteon48scall.ToolTip = lib.Eon("StandingCharge", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "24", lblEONEMetertype.Text, lblEac.Text);
                txteon48dayall.ToolTip = lib.Eon("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "24", lblEONEMetertype.Text, lblEac.Text);
                txteon48nightall.ToolTip = lib.Eon("NightUnitPrice", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "24", lblEONEMetertype.Text, lblEac.Text);
                txteon48ewall.ToolTip = lib.Eon("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, lblEONEMetertype.Text, "24", lblEONEMetertype.Text, lblEac.Text);

            }



        }


        #endregion

        #region BG calculation
        void Bindbga()
        {

            if (lblProfile.Text != "0" || lblProfile.Text != "00")
            {


                string bgmt = "UnitCharge";
                string bgsaletype = "Acquisition";
                DateTime dtwindowclose = Convert.ToDateTime(lblStartdate.Text);
                dtwindowclose = dtwindowclose.AddYears(1);

                string winclose = Convert.ToString(dtwindowclose);
                string dayrate, weekday, unitrate = "0";
                dayrate = "0";
                weekday ="0";
                unitrate = "0";


                txtbga12sc.Text = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "Standing Charge");
                txtbga12ew.Text = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "EVENING & WEEKEND UNIT CHARGE");
                weekday = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "WEEKDAY DAY UNIT CHARGE");

                dayrate = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "DAY UNIT CHARGE");

                txtbga12night.Text = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "NIGHT UNIT CHARGE");
                unitrate = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "UNIT CHARGE");
                txtbga12offpeak.Text = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "OFF PEAK UNIT CHARGE");
                txtbga12day.Text = lib.DayRate(dayrate, weekday, unitrate);

                // Tooltip
                txtbga12sc.ToolTip = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "Standing Charge");
                txtbga12ew.ToolTip = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "EVENING & WEEKEND UNIT CHARGE");
               // txtbga12wd.ToolTip = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "WEEKDAY DAY UNIT CHARGE");

                txtbga12day.ToolTip =  lib.DayRate(dayrate, weekday, unitrate);

                txtbga12night.ToolTip = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "NIGHT UNIT CHARGE");
               // txtbga12unit.ToolTip = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "UNIT CHARGE");
                txtbga12offpeak.ToolTip = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "OFF PEAK UNIT CHARGE");

                dayrate = "0";
                weekday = "0";
                unitrate = "0";



                // All 12 months
                txtbga12scall.Text = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "Standing Charge");
                txtbga12ewall.Text = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "EVENING & WEEKEND UNIT CHARGE");
                weekday = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "WEEKDAY DAY UNIT CHARGE");

                dayrate = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "DAY UNIT CHARGE");

                txtbga12nightall.Text = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "NIGHT UNIT CHARGE");
                unitrate = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "UNIT CHARGE");
                txtbga12offpeakall.Text = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "OFF PEAK UNIT CHARGE");

                txtbga12dayall.Text = lib.DayRate(dayrate, weekday, unitrate);
                dayrate = "0";
                weekday = "0";
                unitrate = "0";

                // Tooltips

                txtbga12scall.ToolTip = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "Standing Charge");
                txtbga12ewall.ToolTip = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "EVENING & WEEKEND UNIT CHARGE");
                weekday = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "WEEKDAY DAY UNIT CHARGE");

                dayrate  = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "DAY UNIT CHARGE");

                txtbga12nightall.ToolTip = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "NIGHT UNIT CHARGE");
                unitrate = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "UNIT CHARGE");
                txtbga12offpeakall.ToolTip = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "OFF PEAK UNIT CHARGE");
                txtbga12dayall.ToolTip = lib.DayRate(dayrate, weekday, unitrate);

                dayrate = "0";
                weekday = "0";
                unitrate = "0";


                // 24 Month


                txtbga24sc.Text = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "Standing Charge");
                txtbga24ew.Text = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "EVENING & WEEKEND UNIT CHARGE");
                weekday = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "WEEKDAY DAY UNIT CHARGE");

                dayrate = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "DAY UNIT CHARGE");

                txtbga24night.Text = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "NIGHT UNIT CHARGE");
                unitrate = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "UNIT CHARGE");
                txtbga24offpeak.Text = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "OFF PEAK UNIT CHARGE");
                txtbga24day.Text = lib.DayRate(dayrate, weekday, unitrate);

                dayrate = "0";
                weekday = "0";
                unitrate = "0";

                // tooltip

                txtbga24sc.ToolTip = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "Standing Charge");
                txtbga24ew.ToolTip = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "EVENING & WEEKEND UNIT CHARGE");
                 weekday  = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "WEEKDAY DAY UNIT CHARGE");

                dayrate = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "DAY UNIT CHARGE");

                txtbga24night.ToolTip = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "NIGHT UNIT CHARGE");
                unitrate = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "UNIT CHARGE");
                txtbga24offpeak.ToolTip = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "OFF PEAK UNIT CHARGE");
                txtbga24day.ToolTip = lib.DayRate(dayrate, weekday, unitrate);

                dayrate = "0";
                weekday = "0";
                unitrate = "0";

                // All 24 months

                txtbga24scall.Text = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "Standing Charge");
                txtbga24ewall.Text = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "EVENING & WEEKEND UNIT CHARGE");
               weekday = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "WEEKDAY DAY UNIT CHARGE");

               dayrate= lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "DAY UNIT CHARGE");

                txtbga24nightall.Text = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "NIGHT UNIT CHARGE");
                unitrate = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "UNIT CHARGE");
                txtbga24offpeakall.Text = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "OFF PEAK UNIT CHARGE");

                txtbga24dayall.Text = lib.DayRate(dayrate, weekday, unitrate);

                dayrate = "0";
                weekday = "0";
                unitrate = "0";



                // Tooltip

                txtbga24scall.ToolTip = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "Standing Charge");
                txtbga24ewall.ToolTip = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "EVENING & WEEKEND UNIT CHARGE");
                weekday = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "WEEKDAY DAY UNIT CHARGE");

                dayrate = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "DAY UNIT CHARGE");

                txtbga24nightall.ToolTip = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "NIGHT UNIT CHARGE");
                unitrate= lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "UNIT CHARGE");
                txtbga24offpeakall.ToolTip = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "OFF PEAK UNIT CHARGE");
                txtbga24dayall.ToolTip = lib.DayRate(dayrate, weekday, unitrate);

                dayrate = "0";
                weekday = "0";
                unitrate = "0";


                // 36 Months

                txtbga36sc.Text = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "Standing Charge");
                txtbga36ew.Text = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "EVENING & WEEKEND UNIT CHARGE");
                weekday = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "WEEKDAY DAY UNIT CHARGE");

                dayrate = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "DAY UNIT CHARGE");

                txtbga36night.Text = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "NIGHT UNIT CHARGE");
               unitrate = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "UNIT CHARGE");
                txtbga36offpeak.Text = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "OFF PEAK UNIT CHARGE");
                txtbga36day.Text = lib.DayRate(dayrate, weekday, unitrate);

                dayrate = "0";
                weekday = "0";
                unitrate = "0";


                // 36 Months tooltips
                txtbga36sc.ToolTip = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "Standing Charge");
                txtbga36ew.ToolTip = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "EVENING & WEEKEND UNIT CHARGE");
            //    weekday = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "WEEKDAY DAY UNIT CHARGE");

              //  dayrate = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "DAY UNIT CHARGE");

                txtbga36night.ToolTip = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "NIGHT UNIT CHARGE");
                unitrate = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "UNIT CHARGE");
                txtbga36offpeak.ToolTip = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "OFF PEAK UNIT CHARGE");
                txtbga36day.ToolTip = lib.DayRate(dayrate, weekday, unitrate);

                // all 36 months
                dayrate = "0";
                weekday = "0";
                unitrate = "0";




                txtbga36scall.Text = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "Standing Charge");
                txtbga36ewall.Text = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "EVENING & WEEKEND UNIT CHARGE");
               weekday = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "WEEKDAY DAY UNIT CHARGE");

                dayrate= lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "DAY UNIT CHARGE");

                txtbga36nightall.Text = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "NIGHT UNIT CHARGE");
               unitrate= lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "UNIT CHARGE");
                txtbga36offpeakall.Text = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "OFF PEAK UNIT CHARGE");
                txtbga36dayall.Text = lib.DayRate(dayrate, weekday, unitrate);

                dayrate = "0";
                weekday = "0";
                unitrate = "0";



                // 36 month all tooltip
                // all 36 months
                txtbga36scall.ToolTip = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "Standing Charge");
                txtbga36ewall.ToolTip = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "EVENING & WEEKEND UNIT CHARGE");
                weekday = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "WEEKDAY DAY UNIT CHARGE");

                dayrate= lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "DAY UNIT CHARGE");

                txtbga36nightall.ToolTip = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "NIGHT UNIT CHARGE");
                 unitrate = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "UNIT CHARGE");
                txtbga36offpeakall.ToolTip = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "OFF PEAK UNIT CHARGE");
                txtbga36dayall.ToolTip = lib.DayRate(dayrate, weekday, unitrate);
                dayrate = "0";
                weekday = "0";
                unitrate = "0";

                //48 months
                txtbga48sc.Text = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "48", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "Standing Charge");
                txtbga48ew.Text = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "48", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "EVENING & WEEKEND UNIT CHARGE");
                  weekday = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "48", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "WEEKDAY DAY UNIT CHARGE");

               dayrate= lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "48", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "DAY UNIT CHARGE");

                txtbga48night.Text = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "48", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "NIGHT UNIT CHARGE");
               unitrate= lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "48", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "UNIT CHARGE");
                txtbga48offpeak.Text = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "48", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "OFF PEAK UNIT CHARGE");

                txtbga48day.Text = lib.DayRate(dayrate, weekday, unitrate);

                dayrate = "0";
                weekday = "0";
                unitrate = "0";
                //48 months tooltip

                //48 months
                txtbga48sc.ToolTip = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "48", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "Standing Charge");
                txtbga48ew.ToolTip = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "48", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "EVENING & WEEKEND UNIT CHARGE");
               weekday = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "48", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "WEEKDAY DAY UNIT CHARGE");

                dayrate = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "48", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "DAY UNIT CHARGE");

                txtbga48night.ToolTip = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "48", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "NIGHT UNIT CHARGE");
                unitrate = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "48", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "UNIT CHARGE");
                txtbga48offpeak.ToolTip = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "48", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "OFF PEAK UNIT CHARGE");
                txtbga48day.ToolTip = lib.DayRate(dayrate, weekday, unitrate);

                dayrate = "0";
                weekday = "0";
                unitrate = "0";

                // all 48 months
                txtbga48scall.Text = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "48", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "Standing Charge");
                txtbga48ewall.Text = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "48", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "EVENING & WEEKEND UNIT CHARGE");
               weekday = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "48", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "WEEKDAY DAY UNIT CHARGE");

                dayrate = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "48", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "DAY UNIT CHARGE");

                txtbga48nightall.Text = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "48", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "NIGHT UNIT CHARGE");
               unitrate = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "48", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "UNIT CHARGE");
                txtbga48offpeakall.Text = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "48", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "OFF PEAK UNIT CHARGE");
                txtbga48dayall.Text = lib.DayRate(dayrate, weekday, unitrate);


                dayrate = "0";
                weekday = "0";
                unitrate = "0";

                // all 48 months tooltip

                txtbga48scall.ToolTip = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "48", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "Standing Charge");
                txtbga48ewall.ToolTip = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "48", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "EVENING & WEEKEND UNIT CHARGE");
                weekday = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "48", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "WEEKDAY DAY UNIT CHARGE");

                dayrate= lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "48", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "DAY UNIT CHARGE");

                txtbga48nightall.ToolTip = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "48", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "NIGHT UNIT CHARGE");
                unitrate= lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "48", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "UNIT CHARGE");
                txtbga48offpeakall.ToolTip = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "48", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "OFF PEAK UNIT CHARGE");
                txtbga48dayall.ToolTip = lib.DayRate(dayrate, weekday, unitrate);

                dayrate = "0";
                weekday = "0";
                unitrate = "0";
                //  60 months

                txtbga60sc.Text = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "60", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "Standing Charge");
                txtbga60ew.Text = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "60", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "EVENING & WEEKEND UNIT CHARGE");
                weekday= lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "60", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "WEEKDAY DAY UNIT CHARGE");

                dayrate = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "60", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "DAY UNIT CHARGE");

                txtbga60night.Text = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "60", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "NIGHT UNIT CHARGE");
               unitrate = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "60", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "UNIT CHARGE");
                txtbga60offpeak.Text = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "60", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "OFF PEAK UNIT CHARGE");
               txtbga60day.Text = lib.DayRate(dayrate, weekday, unitrate);


                dayrate = "0";
                weekday = "0";
                unitrate = "0";



                // all 60months tooltip

                txtbga60sc.ToolTip = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "60", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "Standing Charge");
                txtbga60ew.ToolTip = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "60", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "EVENING & WEEKEND UNIT CHARGE");
               weekday                     = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "60", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "WEEKDAY DAY UNIT CHARGE");

               dayrate = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "60", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "DAY UNIT CHARGE");

                txtbga60night.ToolTip = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "60", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "NIGHT UNIT CHARGE");
               unitrate = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "60", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "UNIT CHARGE");
                txtbga60offpeak.ToolTip = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "60", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "OFF PEAK UNIT CHARGE");
                txtbga60day.ToolTip = lib.DayRate(dayrate, weekday, unitrate);

                dayrate = "0";
                weekday = "0";
                unitrate = "0";

                // all 60 months

                txtbga60scall.Text = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "60", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "Standing Charge");
                txtbga60ewall.Text = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "60", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "EVENING & WEEKEND UNIT CHARGE");
               weekday= lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "60", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "WEEKDAY DAY UNIT CHARGE");

                dayrate = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "60", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "DAY UNIT CHARGE");

                txtbga60nightall.Text = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "60", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "NIGHT UNIT CHARGE");
                unitrate = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "60", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "UNIT CHARGE");
                txtbga60offpeakall.Text = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "60", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "OFF PEAK UNIT CHARGE");
                txtbga60dayall.Text = lib.DayRate(dayrate, weekday, unitrate);


                dayrate = "0";
                weekday = "0";
                unitrate = "0";



                txtbga60scall.ToolTip = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "60", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "Standing Charge");
                txtbga60ewall.ToolTip = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "60", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "EVENING & WEEKEND UNIT CHARGE");
               weekday = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "60", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "WEEKDAY DAY UNIT CHARGE");

               dayrate = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "60", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "DAY UNIT CHARGE");

                txtbga60nightall.ToolTip = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "60", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "NIGHT UNIT CHARGE");
               unitrate= lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "60", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "UNIT CHARGE");
                txtbga60offpeakall.ToolTip = lib.britishgas(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "60", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "OFF PEAK UNIT CHARGE");

                txtbga60dayall.ToolTip = lib.DayRate(dayrate, weekday, unitrate);

                dayrate = "0";
                weekday = "0";
                unitrate = "0";

                //bg renewal code 12 months

                string bgsalestyper = "Renewal";



                txtbge12sc.Text = lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "Standing Charge");
                txtbge12ew.Text = lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "EVENING & WEEKEND UNIT CHARGE");
               weekday= lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "WEEKDAY DAY UNIT CHARGE");

                dayrate = lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "DAY UNIT CHARGE");

                txtbge12night.Text = lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "NIGHT UNIT CHARGE");
                unitrate = lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "UNIT CHARGE");
                txtbge12offpeak.Text = lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "OFF PEAK UNIT CHARGE");
                txtbge12day.Text = lib.DayRate(dayrate, weekday, unitrate);


                dayrate = "0";
                weekday = "0";
                unitrate = "0";



                // 12 months tooltip
                txtbge12sc.ToolTip = lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "Standing Charge");
                txtbge12ew.ToolTip = lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "EVENING & WEEKEND UNIT CHARGE");
                weekday = lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "WEEKDAY DAY UNIT CHARGE");

                dayrate= lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "DAY UNIT CHARGE");

                txtbge12night.ToolTip = lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "NIGHT UNIT CHARGE");
                unitrate = lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "UNIT CHARGE");
                txtbge12offpeak.ToolTip = lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "OFF PEAK UNIT CHARGE");
                txtbge12day.ToolTip = lib.DayRate(dayrate, weekday, unitrate);


                dayrate = "0";
                weekday = "0";
                unitrate = "0";

                //bg renewal all code 12 months
                txtbge12scall.Text = lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "Standing Charge");
                txtbge12ewall.Text = lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "EVENING & WEEKEND UNIT CHARGE");
                weekday = lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "WEEKDAY DAY UNIT CHARGE");

               dayrate = lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "DAY UNIT CHARGE");

                txtbge12nightall.Text = lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "NIGHT UNIT CHARGE");
               unitrate = lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "UNIT CHARGE");
                txtbge12offpeakall.Text = lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "OFF PEAK UNIT CHARGE");
               txtbge12rate.Text = lib.DayRate(dayrate, weekday, unitrate);

                dayrate = "0";
                weekday = "0";
                unitrate = "0";


                // tooltips
                txtbge12scall.ToolTip = lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "Standing Charge");
                txtbge12ewall.ToolTip = lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "EVENING & WEEKEND UNIT CHARGE");
               weekday = lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "WEEKDAY DAY UNIT CHARGE");

                dayrate= lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "DAY UNIT CHARGE");

                txtbge12nightall.ToolTip = lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "NIGHT UNIT CHARGE");
                unitrate = lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "UNIT CHARGE");
                txtbge12offpeakall.ToolTip = lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "OFF PEAK UNIT CHARGE");
                txtbge12dayall.ToolTip = lib.DayRate(dayrate, weekday, unitrate);
                //bg renewal code 24 months

                dayrate = "0";
                weekday = "0";
                unitrate = "0";

                txtbge24sc.Text = lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "Standing Charge");
                txtbge24ew.Text = lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "EVENING & WEEKEND UNIT CHARGE");
                weekday= lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "WEEKDAY DAY UNIT CHARGE");

                dayrate = lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "DAY UNIT CHARGE");

                txtbge24night.Text = lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "NIGHT UNIT CHARGE");
                unitrate = lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "UNIT CHARGE");
                txtbge24offpeak.Text = lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "OFF PEAK UNIT CHARGE");
                txtbge24day.Text = lib.DayRate(dayrate, weekday, unitrate);

                // tooltips

                dayrate = "0";
                weekday = "0";
                unitrate = "0";


                txtbge24sc.ToolTip = lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "Standing Charge");
                txtbge24ew.ToolTip = lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "EVENING & WEEKEND UNIT CHARGE");
               weekday = lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "WEEKDAY DAY UNIT CHARGE");

                dayrate = lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "DAY UNIT CHARGE");

                txtbge24night.ToolTip = lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "NIGHT UNIT CHARGE");
                unitrate= lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "UNIT CHARGE");
                txtbge24offpeak.ToolTip = lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "OFF PEAK UNIT CHARGE");
                txtbge24day.ToolTip = lib.DayRate(dayrate, weekday, unitrate);



                //bg renewal code all 24 months

                dayrate = "0";
                weekday = "0";
                unitrate = "0";

                txtbge24scall.Text = lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "Standing Charge");
                txtbge24ewall.Text = lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "EVENING & WEEKEND UNIT CHARGE");
                weekday = lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "WEEKDAY DAY UNIT CHARGE");

                dayrate = lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "DAY UNIT CHARGE");

                txtbge24nightall.Text = lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "NIGHT UNIT CHARGE");
                unitrate= lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "UNIT CHARGE");
                txtbge24offpeakall.Text = lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "OFF PEAK UNIT CHARGE");
                txtbge24dayall.Text = lib.DayRate(dayrate, weekday, unitrate);
                // tooltips

                dayrate = "0";
                weekday = "0";
                unitrate = "0";

                txtbge24scall.ToolTip = lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "Standing Charge");
                txtbge24ewall.ToolTip = lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "EVENING & WEEKEND UNIT CHARGE");
                weekday = lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "WEEKDAY DAY UNIT CHARGE");

               dayrate = lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "DAY UNIT CHARGE");

                txtbge24nightall.ToolTip = lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "NIGHT UNIT CHARGE");
                unitrate = lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "UNIT CHARGE");
                txtbge24offpeakall.ToolTip = lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "OFF PEAK UNIT CHARGE");
                txtbge24dayall.ToolTip = lib.DayRate(dayrate, weekday, unitrate);
                //bg renewal code 36 months

                dayrate = "0";
                weekday = "0";
                unitrate = "0";

                txtbge36sc.Text = lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "Standing Charge");
                txtbge36ew.Text = lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "EVENING & WEEKEND UNIT CHARGE");
                weekday = lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "WEEKDAY DAY UNIT CHARGE");

                dayrate = lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "DAY UNIT CHARGE");

                txtbge36night.Text = lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "NIGHT UNIT CHARGE");
                unitrate= lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "UNIT CHARGE");
                txtbge36offpeak.Text = lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "OFF PEAK UNIT CHARGE");
                txtbge36day.Text = lib.DayRate(dayrate, weekday, unitrate);
                // Tooltip

                dayrate = "0";
                weekday = "0";
                unitrate = "0";

                txtbge36sc.ToolTip = lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "Standing Charge");
                txtbge36ew.ToolTip = lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "EVENING & WEEKEND UNIT CHARGE");
                weekday= lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "WEEKDAY DAY UNIT CHARGE");

               dayrate= lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "DAY UNIT CHARGE");

                txtbge36night.ToolTip = lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "NIGHT UNIT CHARGE");
               unitrate = lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "UNIT CHARGE");
                txtbge36offpeak.ToolTip = lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "OFF PEAK UNIT CHARGE");
                txtbge36day.ToolTip = lib.DayRate(dayrate, weekday, unitrate);

                // bg renewal code all 36 months

                dayrate = "0";
                weekday = "0";
                unitrate = "0";

                txtbge36scall.Text = lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "Standing Charge");
                txtbge36ewall.Text = lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "EVENING & WEEKEND UNIT CHARGE");
                weekday = lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "WEEKDAY DAY UNIT CHARGE");

                dayrate= lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "DAY UNIT CHARGE");

                txtbge36nightall.Text = lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "NIGHT UNIT CHARGE");
                unitrate = lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "UNIT CHARGE");
                txtbge36offpeakall.Text = lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "OFF PEAK UNIT CHARGE");
                txtbge36dayall.Text = lib.DayRate(dayrate, weekday, unitrate);

                // Tooltips
                dayrate = "0";
                weekday = "0";
                unitrate = "0";
                txtbge36scall.ToolTip = lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "Standing Charge");
                txtbge36ewall.ToolTip = lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "EVENING & WEEKEND UNIT CHARGE");
                weekday = lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "WEEKDAY DAY UNIT CHARGE");

                dayrate = lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "DAY UNIT CHARGE");

                txtbge36nightall.ToolTip = lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "NIGHT UNIT CHARGE");
                unitrate= lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "UNIT CHARGE");
                txtbge36offpeakall.ToolTip = lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "OFF PEAK UNIT CHARGE");
                txtbge36dayall.ToolTip = lib.DayRate(dayrate, weekday, unitrate);

                //bg renewal code 48 months

                dayrate = "0";
                weekday = "0";
                unitrate = "0";

                txtbge48sc.Text = lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "48", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "Standing Charge");
                txtbge48ew.Text = lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "48", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "EVENING & WEEKEND UNIT CHARGE");
               weekday = lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "48", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "WEEKDAY DAY UNIT CHARGE");

                dayrate= lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "48", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "DAY UNIT CHARGE");

                txtbge48night.Text = lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "48", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "NIGHT UNIT CHARGE");
               unitrate = lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "48", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "UNIT CHARGE");
                txtbge48offpeak.Text = lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "48", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "OFF PEAK UNIT CHARGE");
                txtbge48day.Text = lib.DayRate(dayrate, weekday, unitrate);

                dayrate = "0";
                weekday = "0";
                unitrate = "0";
                // tooltips
                txtbge48sc.ToolTip = lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "48", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "Standing Charge");
                txtbge48ew.ToolTip = lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "48", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "EVENING & WEEKEND UNIT CHARGE");
                weekday= lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "48", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "WEEKDAY DAY UNIT CHARGE");

                dayrate = lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "48", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "DAY UNIT CHARGE");

                txtbge48night.ToolTip = lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "48", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "NIGHT UNIT CHARGE");
                unitrate= lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "48", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "UNIT CHARGE");
                txtbge48offpeak.ToolTip = lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "48", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "OFF PEAK UNIT CHARGE");
                txtbge48day.ToolTip = lib.DayRate(dayrate, weekday, unitrate);

                dayrate = "0";
                weekday = "0";
                unitrate = "0";

                //bg renewal code  all 48 months

                txtbge48scall.Text = lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "48", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "Standing Charge");
                txtbge48ewall.Text = lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "48", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "EVENING & WEEKEND UNIT CHARGE");
               weekday= lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "48", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "WEEKDAY DAY UNIT CHARGE");

               dayrate= lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "48", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "DAY UNIT CHARGE");

                txtbge48nightall.Text = lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "48", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "NIGHT UNIT CHARGE");
               unitrate = lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "48", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "UNIT CHARGE");
                txtbge48offpeakall.Text = lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "48", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "OFF PEAK UNIT CHARGE");
                txtbge48dayall.Text = lib.DayRate(dayrate, weekday, unitrate);

                dayrate = "0";
                weekday = "0";
                unitrate = "0";

                // tooltips

                txtbge48scall.ToolTip = lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "48", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "Standing Charge");
                txtbge48ewall.ToolTip = lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "48", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "EVENING & WEEKEND UNIT CHARGE");
               weekday = lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "48", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "WEEKDAY DAY UNIT CHARGE");

               dayrate= lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "48", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "DAY UNIT CHARGE");

                txtbge48nightall.ToolTip = lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "48", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "NIGHT UNIT CHARGE");
                unitrate = lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "48", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "UNIT CHARGE");
                txtbge48offpeakall.ToolTip = lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "48", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "OFF PEAK UNIT CHARGE");
                txtbge48dayall.ToolTip = lib.DayRate(dayrate, weekday, unitrate);

                dayrate = "0";
                weekday = "0";
                unitrate = "0";

                //bg renewal code 60 months

                txtbge60sc.Text = lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "60", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "Standing Charge");
                txtbge60ew.Text = lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "60", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "EVENING & WEEKEND UNIT CHARGE");
                weekday = lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "60", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "WEEKDAY DAY UNIT CHARGE");

               dayrate = lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "60", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "DAY UNIT CHARGE");

                txtbge60night.Text = lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "60", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "NIGHT UNIT CHARGE");
                unitrate = lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "60", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "UNIT CHARGE");
                txtbge60offpeak.Text = lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "60", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "OFF PEAK UNIT CHARGE");
                txtbge60day.Text = lib.DayRate(dayrate, weekday, unitrate);

                //dayrate = "0";
                //weekday = "0";
                //unitrate = "0";
                // Tooltips

                txtbge60sc.ToolTip = lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "60", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "Standing Charge");
                txtbge60ew.ToolTip = lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "60", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "EVENING & WEEKEND UNIT CHARGE");
               weekday = lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "60", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "WEEKDAY DAY UNIT CHARGE");

                dayrate = lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "60", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "DAY UNIT CHARGE");

                txtbge60night.ToolTip = lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "60", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "NIGHT UNIT CHARGE");
                unitrate = lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "60", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "UNIT CHARGE");
                txtbge60offpeak.ToolTip = lib.britishgasr(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "60", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "OFF PEAK UNIT CHARGE");
                txtbge60day.Text = lib.DayRate(dayrate, weekday, unitrate);
            }

            if(lblProfile.Text == "0" || lblProfile.Text == "00")
            {
                string bgmt = "PRICE";
                string bgsaletype = "Acquisition";
                DateTime dtwindowclose = Convert.ToDateTime(lblStartdate.Text);
                dtwindowclose = dtwindowclose.AddYears(1);
                string winclose = Convert.ToString(dtwindowclose);
                // 12 Months

               string dayrate = "0";
               string weekday = "0";
               string unitrate = "0";


                txtbga12sc.Text =  lib.britishgashq(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "Standing Charge");
              
               dayrate= lib.britishgashq(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "Day Unit Charge");
             
                txtbga12night.Text = lib.britishgashq(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "Night Unit Charge");
              
                unitrate = lib.britishgashq(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "Unit Charge");
              
                txtbga12ew.Text = lib.britishgashq(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "Weekend Unit Charge");
              
               weekday = lib.britishgashq(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "Weekday Unit Charge");

                txtbga12day.Text = lib.DayRate(dayrate, weekday, unitrate);


                txtbga12sc.ToolTip = lib.britishgashq(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "Standing Charge");
                dayrate = lib.britishgashq(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "Day Unit Charge");
                txtbga12night.ToolTip = lib.britishgashq(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "Night Unit Charge");
               unitrate= lib.britishgashq(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "Unit Charge");
                txtbga12ew.ToolTip = lib.britishgashq(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "Weekend Unit Charge");
               weekday = lib.britishgashq(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "Weekday Unit Charge");
                txtbga12day.ToolTip = lib.DayRate(dayrate, weekday, unitrate);




                // 24 Months

                txtbga24sc.Text = lib.britishgashq(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "Standing Charge");
              
                dayrate= lib.britishgashq(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "Day Unit Charge");
                
                txtbga24night.Text = lib.britishgashq(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "Night Unit Charge");
                txtbga24night.ToolTip = lib.britishgashq(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "Night Unit Charge");
               unitrate = lib.britishgashq(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "Unit Charge");
               
                txtbga24ew.Text = lib.britishgashq(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "Weekend Unit Charge");
              
               weekday = lib.britishgashq(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "Weekday Unit Charge");
                
                txtbga24day.Text = lib.DayRate(dayrate, weekday, unitrate);


                txtbga24sc.ToolTip = lib.britishgashq(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "Standing Charge");
                dayrate= lib.britishgashq(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "Day Unit Charge");
                txtbga24night.ToolTip = lib.britishgashq(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "Night Unit Charge");
                unitrate = lib.britishgashq(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "Unit Charge");
                txtbga24ew.ToolTip = lib.britishgashq(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "Weekend Unit Charge");
               weekday= lib.britishgashq(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "Weekday Unit Charge");

                txtbga24day.ToolTip = lib.DayRate(dayrate, weekday, unitrate);


                // 36 Months

                txtbga36sc.Text = lib.britishgashq(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "Standing Charge");
               
               dayrate = lib.britishgashq(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "Day Unit Charge");
              
                txtbga36night.Text = lib.britishgashq(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "Night Unit Charge");

                unitrate= lib.britishgashq(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "Unit Charge");
              
                txtbga36ew.Text = lib.britishgashq(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "Weekend Unit Charge");
              
               weekday = lib.britishgashq(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "Weekday Unit Charge");
                txtbga36day.Text = lib.DayRate(dayrate, weekday, unitrate);


                txtbga36sc.ToolTip = lib.britishgashq(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "Standing Charge");
                dayrate= lib.britishgashq(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "Day Unit Charge");
                txtbga36night.ToolTip = lib.britishgashq(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "Night Unit Charge");
                unitrate = lib.britishgashq(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "Unit Charge");
                txtbga36ew.ToolTip = lib.britishgashq(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "Weekend Unit Charge");
                weekday= lib.britishgashq(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "Weekday Unit Charge");
                txtbga36day.ToolTip = lib.DayRate(dayrate, weekday, unitrate);

               // txtbga36day.ToolTip = lib.DayRate(dayrate, weekday, unitrate);



                //Renewl


                bgsaletype = "Renewal";
         
               
                // 12 Months
                txtbge12sc.Text = lib.britishgasrhq(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "Standing Charge");
               
                dayrate= lib.britishgasrhq(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "Day Unit Charge");
              
                txtbge12night.Text = lib.britishgasrhq(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "Night Unit Charge");
               
               unitrate = lib.britishgasrhq(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "Unit Charge");
              
                txtbge12ew.Text = lib.britishgasrhq(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "Weekend Unit Charge");
              
               weekday = lib.britishgasrhq(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "Weekday Unit Charge");
                txtbge12day.Text = lib.DayRate(dayrate, weekday, unitrate);



                txtbge12sc.ToolTip = lib.britishgasrhq(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "Standing Charge");
                dayrate = lib.britishgasrhq(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "Day Unit Charge");
                txtbge12night.ToolTip = lib.britishgasrhq(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "Night Unit Charge");
                unitrate = lib.britishgasrhq(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "Unit Charge");
                txtbge12ew.ToolTip = lib.britishgasrhq(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "Weekend Unit Charge");
                weekday = lib.britishgasrhq(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "Weekday Unit Charge");

                txtbge12day.ToolTip = lib.DayRate(dayrate, weekday, unitrate);



                // 24 Months

                txtbge24sc.Text = lib.britishgasrhq(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "Standing Charge");
               
               dayrate= lib.britishgasrhq(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "Day Unit Charge");
              
                txtbge24night.Text = lib.britishgasrhq(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "Night Unit Charge");
               
                unitrate= lib.britishgasrhq(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "Unit Charge");
              
                txtbge24ew.Text = lib.britishgasrhq(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "Weekend Unit Charge");
               
               weekday = lib.britishgasrhq(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "Weekday Unit Charge");
             


                txtbge24sc.ToolTip = lib.britishgasrhq(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "Standing Charge");
               dayrate= lib.britishgasrhq(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "Day Unit Charge");
                txtbge24night.ToolTip = lib.britishgasrhq(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "Night Unit Charge");
               unitrate = lib.britishgasrhq(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "Unit Charge");
                txtbge24ew.ToolTip = lib.britishgasrhq(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "Weekend Unit Charge");
                weekday = lib.britishgasrhq(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "Weekday Unit Charge");
                txtbge24day.ToolTip = lib.DayRate(dayrate, weekday, unitrate);


                // 36 Months

                txtbge36sc.Text = lib.britishgasrhq(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "Standing Charge");
               
                dayrate= lib.britishgasrhq(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "Day Unit Charge");
               
                txtbge36night.Text = lib.britishgasrhq(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "Night Unit Charge");
               
               unitrate = lib.britishgasrhq(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "Unit Charge");
              
                txtbge36ew.Text = lib.britishgasrhq(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "Weekend Unit Charge");

                weekday = lib.britishgasrhq(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "Weekday Unit Charge");
                txtbge36day.Text = lib.DayRate(dayrate, weekday, unitrate);


                txtbge36sc.ToolTip = lib.britishgasrhq(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "Standing Charge");
                dayrate= lib.britishgasrhq(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "Day Unit Charge");
                txtbge36night.ToolTip = lib.britishgasrhq(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "Night Unit Charge");
               unitrate= lib.britishgasrhq(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "Unit Charge");
                txtbge36ew.ToolTip = lib.britishgasrhq(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "Weekend Unit Charge");
                weekday = lib.britishgasrhq(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "Weekday Unit Charge");
                txtbge36day.ToolTip = lib.DayRate(dayrate, weekday, unitrate);
             //   txtbge36day.ToolTip = lib.DayRate(dayrate, weekday, unitrate);

            }



        }
        #endregion

        #region bgl calculation

        void Bindbgl()
        {
            string bgmt = "UnitCharge";
            string bgsaletype = "Acquisition";
            DateTime dtwindowclose = Convert.ToDateTime(lblStartdate.Text);
            dtwindowclose = dtwindowclose.AddYears(1);
            string winclose = Convert.ToString(dtwindowclose);
            string dayrate, weekday, unitrate = "0";
            // New Sales for bgl 12 Months
            txtbgla12sc.Text = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "Standing Charge");
            txtbgla12ew.Text = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "EVENING & WEEKEND UNIT CHARGE");
             weekday = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "WEEKDAY DAY UNIT CHARGE");

            dayrate = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "DAY UNIT CHARGE");

            txtbgla12night.Text = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "NIGHT UNIT CHARGE");
            unitrate = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "UNIT CHARGE");
            txtbgla12offpeak.Text = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "OFF PEAK UNIT CHARGE");
            txtbgla12day.Text = lib.DayRate(dayrate, weekday, unitrate);

            // New Sales all for bgl 12 Months
            txtbgla12scall.Text = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "Standing Charge");
            txtbgla12ewall.Text = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "EVENING & WEEKEND UNIT CHARGE");
            weekday = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "WEEKDAY DAY UNIT CHARGE");

            dayrate = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "DAY UNIT CHARGE");

            txtbgla12nightall.Text = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "NIGHT UNIT CHARGE");
           unitrate = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "UNIT CHARGE");
            txtbgla12offpeakall.Text = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "OFF PEAK UNIT CHARGE");

            txtbgla12dayall.Text  = lib.DayRate(dayrate, weekday, unitrate);

            // New Sales for bgl 24 Months

            txtbgla24sc.Text = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "Standing Charge");
            txtbgla24ew.Text = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "EVENING & WEEKEND UNIT CHARGE");
            weekday = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "WEEKDAY DAY UNIT CHARGE");

            dayrate= lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "DAY UNIT CHARGE");

            txtbgla24night.Text = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "NIGHT UNIT CHARGE");
           unitrate = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "UNIT CHARGE");
           // txtbgla24offpeak.Text = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "OFF PEAK UNIT CHARGE");
             txtbgla24day.Text = lib.DayRate(dayrate, weekday, unitrate);

            // New Sales  all for bgl 24 Months
            txtbgla24scall.Text = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "Standing Charge");
            txtbgla24ewall.Text = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "EVENING & WEEKEND UNIT CHARGE");
            weekday = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "WEEKDAY DAY UNIT CHARGE");

            dayrate= lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "DAY UNIT CHARGE");

            txtbgla24nightall.Text = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "NIGHT UNIT CHARGE");
           unitrate = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "UNIT CHARGE");
            txtbgla24offpeakall.Text = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "OFF PEAK UNIT CHARGE");
          txtbgla24dayall.Text = lib.DayRate(dayrate, weekday, unitrate);


            // New Sales for bgl 36 Months
            txtbgla36sc.Text = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "Standing Charge");
            txtbgla36ew.Text = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "EVENING & WEEKEND UNIT CHARGE");
           weekday = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "WEEKDAY DAY UNIT CHARGE");

           dayrate = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "DAY UNIT CHARGE");

            txtbgla36night.Text = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "NIGHT UNIT CHARGE");
           unitrate = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "UNIT CHARGE");
            txtbgla36offpeak.Text = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "OFF PEAK UNIT CHARGE");
            txtbgla36day.Text = lib.DayRate(dayrate, weekday, unitrate);

            // New Sales all for bgl 36 Months
            txtbgla36scall.Text = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "Standing Charge");
            txtbgla36ewall.Text = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "EVENING & WEEKEND UNIT CHARGE");
            weekday= lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "WEEKDAY DAY UNIT CHARGE");

            dayrate = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "DAY UNIT CHARGE");

            txtbgla36nightall.Text = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "NIGHT UNIT CHARGE");
            unitrate= lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "UNIT CHARGE");
            txtbgla36offpeakall.Text = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "OFF PEAK UNIT CHARGE");

            txtbgla36dayall.Text = lib.DayRate(dayrate, weekday, unitrate);

            // New Sales for bgl 48 Months
            txtbgla48sc.Text = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "48", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "Standing Charge");
            txtbgla48ew.Text = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "48", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "EVENING & WEEKEND UNIT CHARGE");
            weekday = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "48", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "WEEKDAY DAY UNIT CHARGE");

            dayrate = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "48", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "DAY UNIT CHARGE");

            txtbgla48night.Text = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "48", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "NIGHT UNIT CHARGE");
            unitrate= lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "48", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "UNIT CHARGE");
            txtbgla48offpeak.Text = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "48", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "OFF PEAK UNIT CHARGE");
            txtbgla48day.Text = lib.DayRate(dayrate, weekday, unitrate);

            dayrate = "0";
            weekday = "0";
            unitrate = "0";

            // New Sales all  for bgl 48 Months
            txtbgla48scall.Text = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "48", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "Standing Charge");
            txtbgla48ewall.Text = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "48", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "EVENING & WEEKEND UNIT CHARGE");
            weekday = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "48", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "WEEKDAY DAY UNIT CHARGE");

            dayrate = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "48", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "DAY UNIT CHARGE");

            txtbgla48nightall.Text = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "48", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "NIGHT UNIT CHARGE");
           unitrate= lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "48", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "UNIT CHARGE");
            txtbgla48offpeakall.Text = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "48", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "OFF PEAK UNIT CHARGE");
            txtbgla48dayall.Text = lib.DayRate(dayrate, weekday, unitrate);

            dayrate = "0";
            weekday = "0";
            unitrate = "0";

            // New Sales for bgl 60 Months
            txtbgla60sc.Text = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "60", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "Standing Charge");
            txtbgla60ew.Text = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "60", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "EVENING & WEEKEND UNIT CHARGE");
           weekday = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "60", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "WEEKDAY DAY UNIT CHARGE");

           dayrate = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "60", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "DAY UNIT CHARGE");

            txtbgla60night.Text = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "60", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "NIGHT UNIT CHARGE");
           unitrate = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "60", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "UNIT CHARGE");
            txtbgla60offpeak.Text = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "60", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "OFF PEAK UNIT CHARGE");
            txtbgla60day.Text = lib.DayRate(dayrate, weekday, unitrate);

            // New Sales all for bgl 60 Months
            txtbgla60scall.Text = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "60", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "Standing Charge");
            txtbgla60ewall.Text = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "60", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "EVENING & WEEKEND UNIT CHARGE");
            weekday = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "60", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "WEEKDAY DAY UNIT CHARGE");

            dayrate= lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "60", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "DAY UNIT CHARGE");

            txtbgla60nightall.Text = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "60", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "NIGHT UNIT CHARGE");
            unitrate = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "60", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "UNIT CHARGE");
            txtbgla60offpeakall.Text = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "60", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "OFF PEAK UNIT CHARGE");
           txtbgla60dayall.Text = lib.DayRate(dayrate, weekday, unitrate);

            //  BGL tooltip

            // New Sales for bgl 12 Months
            txtbgla12sc.ToolTip = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "Standing Charge");
            txtbgla12ew.ToolTip = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "EVENING & WEEKEND UNIT CHARGE");
            weekday = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "WEEKDAY DAY UNIT CHARGE");

            dayrate= lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "DAY UNIT CHARGE");

            txtbgla12night.ToolTip = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "NIGHT UNIT CHARGE");
           unitrate = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "UNIT CHARGE");
            txtbgla12offpeak.ToolTip = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "OFF PEAK UNIT CHARGE");

            txtbgla12day.ToolTip = lib.DayRate(dayrate, weekday, unitrate);

            // New Sales all for bgl 12 Months
            txtbgla12scall.ToolTip = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "Standing Charge");
            txtbgla12ewall.ToolTip = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "EVENING & WEEKEND UNIT CHARGE");
            weekday= lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "WEEKDAY DAY UNIT CHARGE");

          dayrate = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "DAY UNIT CHARGE");

            txtbgla12nightall.ToolTip = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "NIGHT UNIT CHARGE");
            unitrate= lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "UNIT CHARGE");
            txtbgla12offpeakall.ToolTip = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "OFF PEAK UNIT CHARGE");
            txtbgla12dayall.ToolTip= lib.DayRate(dayrate, weekday, unitrate);


            // New Sales for bgl 24 Months
            txtbgla24sc.ToolTip = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "Standing Charge");
            txtbgla24ew.ToolTip = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "EVENING & WEEKEND UNIT CHARGE");
            weekday = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "WEEKDAY DAY UNIT CHARGE");

            dayrate= lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "DAY UNIT CHARGE");

            txtbgla24night.ToolTip = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "NIGHT UNIT CHARGE");
           unitrate = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "UNIT CHARGE");
            txtbgla24offpeak.ToolTip = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "OFF PEAK UNIT CHARGE");
            txtbgla24day.ToolTip = lib.DayRate(dayrate, weekday, unitrate);

            // New Sales  all for bgl 24 Months
            txtbgla24scall.ToolTip = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "Standing Charge");
            txtbgla24ewall.ToolTip = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "EVENING & WEEKEND UNIT CHARGE");
            weekday = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "WEEKDAY DAY UNIT CHARGE");

            dayrate= lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "DAY UNIT CHARGE");

            txtbgla24nightall.ToolTip = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "NIGHT UNIT CHARGE");
            unitrate= lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "UNIT CHARGE");
            txtbgla24offpeakall.ToolTip = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "OFF PEAK UNIT CHARGE");
            txtbgla24dayall.ToolTip = lib.DayRate(dayrate, weekday, unitrate);


            // New Sales for bgl 36 Months
            txtbgla36sc.ToolTip = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "Standing Charge");
            txtbgla36ew.ToolTip = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "EVENING & WEEKEND UNIT CHARGE");
           weekday= lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "WEEKDAY DAY UNIT CHARGE");

            dayrate = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "DAY UNIT CHARGE");

            txtbgla36night.ToolTip = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "NIGHT UNIT CHARGE");
            unitrate = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "UNIT CHARGE");
            txtbgla36offpeak.ToolTip = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "OFF PEAK UNIT CHARGE");
            txtbgla36day.ToolTip = lib.DayRate(dayrate, weekday, unitrate);


            // New Sales all for bgl 36 Months
            txtbgla36scall.ToolTip = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "Standing Charge");
            txtbgla36ewall.ToolTip = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "EVENING & WEEKEND UNIT CHARGE");
           weekday = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "WEEKDAY DAY UNIT CHARGE");

            dayrate = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "DAY UNIT CHARGE");

            txtbgla36nightall.ToolTip = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "NIGHT UNIT CHARGE");
            unitrate= lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "UNIT CHARGE");
            txtbgla36offpeakall.ToolTip = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "OFF PEAK UNIT CHARGE");
            txtbgla36dayall.ToolTip = lib.DayRate(dayrate, weekday, unitrate);

            // New Sales for bgl 48 Months
            txtbgla48sc.ToolTip = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "48", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "Standing Charge");
            txtbgla48ew.ToolTip = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "48", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "EVENING & WEEKEND UNIT CHARGE");
           weekday = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "48", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "WEEKDAY DAY UNIT CHARGE");

           dayrate= lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "48", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "DAY UNIT CHARGE");

            txtbgla48night.ToolTip = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "48", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "NIGHT UNIT CHARGE");
          unitrate= lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "48", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "UNIT CHARGE");
            txtbgla48offpeak.ToolTip = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "48", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "OFF PEAK UNIT CHARGE");
            txtbgla48day.ToolTip = lib.DayRate(dayrate, weekday, unitrate);

            // New Sales all  for bgl 48 Months
            txtbgla48scall.ToolTip = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "48", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "Standing Charge");
            txtbgla48ewall.ToolTip = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "48", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "EVENING & WEEKEND UNIT CHARGE");
            weekday = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "48", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "WEEKDAY DAY UNIT CHARGE");

            dayrate = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "48", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "DAY UNIT CHARGE");

            txtbgla48nightall.ToolTip = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "48", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "NIGHT UNIT CHARGE");
            unitrate = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "48", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "UNIT CHARGE");
            txtbgla48offpeakall.ToolTip = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "48", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "OFF PEAK UNIT CHARGE");
            txtbgla48dayall.ToolTip = lib.DayRate(dayrate, weekday, unitrate);

            dayrate = "0";
            weekday = "0";
            unitrate = "0";
            // New Sales for bgl 60 Months
            txtbgla60sc.ToolTip = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "60", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "Standing Charge");
            txtbgla60ew.ToolTip = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "60", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "EVENING & WEEKEND UNIT CHARGE");
           weekday = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "60", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "WEEKDAY DAY UNIT CHARGE");

           dayrate= lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "60", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "DAY UNIT CHARGE");

            txtbgla60night.ToolTip = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "60", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "NIGHT UNIT CHARGE");
           unitrate = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "60", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "UNIT CHARGE");
            txtbgla60offpeak.ToolTip = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "60", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "OFF PEAK UNIT CHARGE");
            txtbgla60day.ToolTip = lib.DayRate(dayrate, weekday, unitrate);

            // New Sales all for bgl 60 Months
            txtbgla60scall.ToolTip = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "60", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "Standing Charge");
            txtbgla60ewall.ToolTip = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "60", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "EVENING & WEEKEND UNIT CHARGE");
            weekday = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "60", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "WEEKDAY DAY UNIT CHARGE");

           dayrate = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "60", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "DAY UNIT CHARGE");

            txtbgla60nightall.ToolTip = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "60", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "NIGHT UNIT CHARGE");
           unitrate= lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "60", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "UNIT CHARGE");
            txtbgla60offpeakall.ToolTip = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "60", lblELEPayment.Text, lblStartdate.Text, winclose, bgsaletype, "OFF PEAK UNIT CHARGE");
            txtbgla60dayall.ToolTip = lib.DayRate(dayrate, weekday, unitrate);





            // Renewal Sales
            string bgsalestyper = "Renewal";

            // reNew Sales for bgl 12 Months
              txtbgle12sc.Text = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "Standing Charge");
             txtbgle12ew.Text = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "EVENING & WEEKEND UNIT CHARGE");
             weekday = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "WEEKDAY DAY UNIT CHARGE");

            dayrate= lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "DAY UNIT CHARGE");

            txtbgle12night.Text = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "NIGHT UNIT CHARGE");
             unitrate= lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "UNIT CHARGE");
            txtbgle12offpeak.Text = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "OFF PEAK UNIT CHARGE");
            txtbgle12day.Text = lib.DayRate(dayrate, weekday, unitrate);

            // reNew Sales all for bgl 12 Months
            txtbgle12scall.Text = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "Standing Charge");
            txtbgle12ewall.Text = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "EVENING & WEEKEND UNIT CHARGE");
            weekday= lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "WEEKDAY DAY UNIT CHARGE");

            dayrate = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "DAY UNIT CHARGE");

            txtbgle12nightall.Text = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "NIGHT UNIT CHARGE");
            unitrate= lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "UNIT CHARGE");
            txtbgle12offpeakall.Text = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "OFF PEAK UNIT CHARGE");
            txtbgle12dayall.Text = lib.DayRate(dayrate, weekday, unitrate);



            // reNew Sales for bgl 24 Months
            txtbgle24sc.Text = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "Standing Charge");
            txtbgle24ew.Text = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "EVENING & WEEKEND UNIT CHARGE");
            weekday = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "WEEKDAY DAY UNIT CHARGE");

            dayrate = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "DAY UNIT CHARGE");

            txtbgle24night.Text = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "NIGHT UNIT CHARGE");
           unitrate= lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "UNIT CHARGE");
            txtbgle24offpeak.Text = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "OFF PEAK UNIT CHARGE");
            txtbgle24day.Text = lib.DayRate(dayrate, weekday, unitrate);

            // reNew Sales all for bgl 24 Months
            txtbgle24scall.Text = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "Standing Charge");
            txtbgle24ewall.Text = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "EVENING & WEEKEND UNIT CHARGE");
           weekday = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "WEEKDAY DAY UNIT CHARGE");

            dayrate = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "DAY UNIT CHARGE");

            txtbgle24nightall.Text = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "NIGHT UNIT CHARGE");
            unitrate= lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "UNIT CHARGE");
            txtbgle24offpeakall.Text = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "OFF PEAK UNIT CHARGE");
            txtbgle24dayall.Text = lib.DayRate(dayrate, weekday, unitrate);

            // reNew Sales for bgl 36 Months
            txtbgle36sc.Text = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "Standing Charge");
            txtbgle36ew.Text = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "EVENING & WEEKEND UNIT CHARGE");
           weekday = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "WEEKDAY DAY UNIT CHARGE");

          dayrate= lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "DAY UNIT CHARGE");

            txtbgle36night.Text = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "NIGHT UNIT CHARGE");
            unitrate = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "UNIT CHARGE");
            txtbgle36offpeak.Text = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "OFF PEAK UNIT CHARGE");
            txtbgle36day.Text = lib.DayRate(dayrate, weekday, unitrate);


            // reNew Sales all for bgl 36 Months
            txtbgle36scall.Text = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "Standing Charge");
            txtbgle36ewall.Text = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "EVENING & WEEKEND UNIT CHARGE");
            weekday = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "WEEKDAY DAY UNIT CHARGE");

            dayrate = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "DAY UNIT CHARGE");

            txtbgle36nightall.Text = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "NIGHT UNIT CHARGE");
           unitrate= lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "UNIT CHARGE");
            txtbgle36offpeakall.Text = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "OFF PEAK UNIT CHARGE");

           txtbgle36dayall.Text = lib.DayRate(dayrate, weekday, unitrate);



            //re New Sales for bgl 48 nths
            txtbgle48sc.Text = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "48", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "Standing Charge");
            txtbgle48ew.Text = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "48", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "EVENING & WEEKEND UNIT CHARGE");
            weekday = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "48", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "WEEKDAY DAY UNIT CHARGE");

           dayrate = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "48", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "DAY UNIT CHARGE");

            txtbgle48night.Text = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "48", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "NIGHT UNIT CHARGE");
          unitrate= lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "48", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "UNIT CHARGE");
            txtbgle48offpeak.Text = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "48", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "OFF PEAK UNIT CHARGE");
            txtbgle48day.Text = lib.DayRate(dayrate, weekday, unitrate);


            //re New Sales all for bgl 48 nths
            txtbgle48scall.Text = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "48", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "Standing Charge");
            txtbgle48ewall.Text = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "48", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "EVENING & WEEKEND UNIT CHARGE");
            weekday = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "48", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "WEEKDAY DAY UNIT CHARGE");

            dayrate = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "48", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "DAY UNIT CHARGE");

            txtbgle48nightall.Text = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "48", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "NIGHT UNIT CHARGE");
            unitrate = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "48", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "UNIT CHARGE");
            txtbgle48offpeakall.Text = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "48", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "OFF PEAK UNIT CHARGE");
            txtbgle48day.Text = lib.DayRate(dayrate, weekday, unitrate);

            dayrate = "0";
            weekday = "0";
            unitrate = "0";

            // reNew Sales for bgl 60 nths
            txtbgle60sc.Text = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "60", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "Standing Charge");
            txtbgle60ew.Text = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "60", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "EVENING & WEEKEND UNIT CHARGE");
            weekday= lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "60", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "WEEKDAY DAY UNIT CHARGE");

            dayrate = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "60", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "DAY UNIT CHARGE");

            txtbgle60night.Text = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "60", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "NIGHT UNIT CHARGE");
            unitrate = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "60", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "UNIT CHARGE");
            txtbgle60offpeak.Text = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "60", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "OFF PEAK UNIT CHARGE");
            txtbgle60day.Text  = lib.DayRate(dayrate, weekday, unitrate);

            // reNew Sales all for bgl 60 nths
            txtbgle60scall.Text = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "60", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "Standing Charge");
            txtbgle60ewall.Text = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "60", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "EVENING & WEEKEND UNIT CHARGE");
           weekday = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "60", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "WEEKDAY DAY UNIT CHARGE");

           dayrate = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "60", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "DAY UNIT CHARGE");

            txtbgle60nightall.Text = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "60", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "NIGHT UNIT CHARGE");
           unitrate= lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "60", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "UNIT CHARGE");
            txtbgle60offpeakall.Text = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "60", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "OFF PEAK UNIT CHARGE");
            txtbgle60dayall.Text = lib.DayRate(dayrate, weekday, unitrate);
            // Tooltip renewal




            // reNew Sales for bgl 12 Months
            txtbgle12sc.ToolTip = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "Standing Charge");
            txtbgle12ew.ToolTip = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "EVENING & WEEKEND UNIT CHARGE");
            weekday = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "WEEKDAY DAY UNIT CHARGE");

            dayrate = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "DAY UNIT CHARGE");

            txtbgle12night.ToolTip = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "NIGHT UNIT CHARGE");
            unitrate = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "UNIT CHARGE");
            txtbgle12offpeak.ToolTip = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "OFF PEAK UNIT CHARGE");
            txtbgle12day.ToolTip = lib.DayRate(dayrate, weekday, unitrate);


            // reNew Sales all for bgl 12 Months
            txtbgle12scall.ToolTip = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "Standing Charge");
            txtbgle12ewall.ToolTip = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "EVENING & WEEKEND UNIT CHARGE");
            weekday = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "WEEKDAY DAY UNIT CHARGE");

            dayrate = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "DAY UNIT CHARGE");

            txtbgle12nightall.ToolTip = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "NIGHT UNIT CHARGE");
           unitrate= lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "UNIT CHARGE");
            txtbgle12offpeakall.ToolTip = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "12", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "OFF PEAK UNIT CHARGE");
            txtbgle12dayall.ToolTip = lib.DayRate(dayrate, weekday, unitrate);



            // reNew Sales for bgl 24 Months
            txtbgle24sc.ToolTip = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "Standing Charge");
            txtbgle24ew.ToolTip = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "EVENING & WEEKEND UNIT CHARGE");
           weekday = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "WEEKDAY DAY UNIT CHARGE");

            dayrate = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "DAY UNIT CHARGE");

            txtbgle24night.ToolTip = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "NIGHT UNIT CHARGE");
            unitrate = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "UNIT CHARGE");
            txtbgle24offpeak.ToolTip = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "OFF PEAK UNIT CHARGE");
            txtbgle24day.ToolTip = lib.DayRate(dayrate, weekday, unitrate);


            // reNew Sales all for bgl 24 Months
            txtbgle24scall.ToolTip = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "Standing Charge");
            txtbgle24ewall.ToolTip = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "EVENING & WEEKEND UNIT CHARGE");
           weekday = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "WEEKDAY DAY UNIT CHARGE");

           dayrate = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "DAY UNIT CHARGE");

            txtbgle24nightall.ToolTip = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "NIGHT UNIT CHARGE");
            unitrate= lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "UNIT CHARGE");
            txtbgle24offpeakall.ToolTip = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "24", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "OFF PEAK UNIT CHARGE");
            txtbgle24dayall.ToolTip = lib.DayRate(dayrate, weekday, unitrate);


            // reNew Sales for bgl 36 Months
            txtbgle36sc.ToolTip = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "Standing Charge");
            txtbgle36ew.ToolTip = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "EVENING & WEEKEND UNIT CHARGE");
            weekday = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "WEEKDAY DAY UNIT CHARGE");

           dayrate = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "DAY UNIT CHARGE");

            txtbgle36night.ToolTip = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "NIGHT UNIT CHARGE");
           unitrate = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "UNIT CHARGE");
            txtbgle36offpeak.ToolTip = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "OFF PEAK UNIT CHARGE");
            txtbgle36day.ToolTip = lib.DayRate(dayrate, weekday, unitrate);


            // reNew Sales all for bgl 36 Months
            txtbgle36scall.ToolTip = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "Standing Charge");
            txtbgle36ewall.ToolTip = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "EVENING & WEEKEND UNIT CHARGE");
           weekday = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "WEEKDAY DAY UNIT CHARGE");

            dayrate= lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "DAY UNIT CHARGE");

            txtbgle36nightall.ToolTip = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "NIGHT UNIT CHARGE");
           unitrate = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "UNIT CHARGE");
            txtbgle36offpeakall.ToolTip = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "36", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "OFF PEAK UNIT CHARGE");
            txtbgle36dayall.ToolTip = lib.DayRate(dayrate, weekday, unitrate);




            //re New Sales for bgl 48 nths
            txtbgle48sc.ToolTip = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "48", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "Standing Charge");
            txtbgle48ew.ToolTip = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "48", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "EVENING & WEEKEND UNIT CHARGE");
           weekday = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "48", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "WEEKDAY DAY UNIT CHARGE");

           dayrate = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "48", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "DAY UNIT CHARGE");

            txtbgle48night.ToolTip = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "48", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "NIGHT UNIT CHARGE");
            unitrate = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "48", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "UNIT CHARGE");
            txtbgle48offpeak.ToolTip = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "48", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "OFF PEAK UNIT CHARGE");
            txtbgle48day.ToolTip = lib.DayRate(dayrate, weekday, unitrate);

            //re New Sales all for bgl 48 nths
            txtbgle48scall.ToolTip = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "48", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "Standing Charge");
            txtbgle48ewall.ToolTip = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "48", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "EVENING & WEEKEND UNIT CHARGE");
            weekday = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "48", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "WEEKDAY DAY UNIT CHARGE");

           dayrate = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "48", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "DAY UNIT CHARGE");

            txtbgle48nightall.ToolTip = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "48", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "NIGHT UNIT CHARGE");
            unitrate = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "48", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "UNIT CHARGE");
            txtbgle48offpeakall.ToolTip = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "48", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "OFF PEAK UNIT CHARGE");
            txtbgle48dayall.ToolTip = lib.DayRate(dayrate, weekday, unitrate);

            dayrate = "0";
            weekday = "0";
            unitrate = "0";
            // reNew Sales for bgl 60 nths
            txtbgle60sc.ToolTip = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "60", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "Standing Charge");
            txtbgle60ew.ToolTip = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "60", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "EVENING & WEEKEND UNIT CHARGE");
           weekday= lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "60", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "WEEKDAY DAY UNIT CHARGE");

         dayrate = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "60", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "DAY UNIT CHARGE");

            txtbgle60night.ToolTip = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "60", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "NIGHT UNIT CHARGE");
           unitrate= lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "60", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "UNIT CHARGE");
            txtbgle60offpeak.ToolTip = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "60", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "OFF PEAK UNIT CHARGE");
            txtbgle60day.Text = lib.DayRate(dayrate, weekday, unitrate);
            // reNew Sales all for bgl 60 nths
            txtbgle60scall.ToolTip = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "60", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "Standing Charge");
            txtbgle60ewall.ToolTip = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "60", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "EVENING & WEEKEND UNIT CHARGE");
           weekday = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "60", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "WEEKDAY DAY UNIT CHARGE");

            dayrate = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "60", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "DAY UNIT CHARGE");

            txtbgle60nightall.ToolTip = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "60", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "NIGHT UNIT CHARGE");
            unitrate = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "60", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "UNIT CHARGE");
            txtbgle60offpeakall.ToolTip = lib.britishgalite(bgmt, lblEac.Text, lblProfile.Text, lblRegion.Text, lblBGEMetertype.Text, "60", lblELEPayment.Text, lblStartdate.Text, winclose, bgsalestyper, "OFF PEAK UNIT CHARGE");
            txtbgle60dayall.Text = lib.DayRate(dayrate, weekday, unitrate);

        }
        #endregion

        #region EDF calculation
        void Bindedf()

        {



            string salestype = lblELEPayment.Text;
            // 12 Months

            txtedfa12sc.Text = (Convert.ToDouble(lib.Edf("StandingCharge", lblRegion.Text, lblEDFMetertype.Text, "12")) * 100).ToString();
            txtedfa12day.Text = lib.Edf("Day", lblRegion.Text, lblEDFMetertype.Text, "12");
            txtedfa12night.Text = lib.Edf("Night", lblRegion.Text, lblEDFMetertype.Text, "12");
            txtedfa12ew.Text = lib.Edf("EveningWeekend", lblRegion.Text, lblEDFMetertype.Text, "12");
            lbledfa12program.Text = lib.Edf("Contract", lblRegion.Text, lblEDFMetertype.Text, "12") + "For 12 months";

            // 12 Months all
            txtedfa12scall.Text = lib.Edf("StandingCharge", lblRegion.Text, lblEDFMetertype.Text, "12");
            txtedfa12dayall.Text = lib.Edf("Day", lblRegion.Text, lblEDFMetertype.Text, "12");
            txtedfa12nightall.Text = lib.Edf("Night", lblRegion.Text, lblEDFMetertype.Text, "12");
            txtedfa12ewall.Text = lib.Edf("EveningWeekend", lblRegion.Text, lblEDFMetertype.Text, "12");
            lbledfa12programall.Text = lib.Edf("Contract", lblRegion.Text, lblEDFMetertype.Text, "12") + "for 12 months";



            // 24 Months

            txtedfa24sc.Text = (Convert.ToDouble(lib.Edf("StandingCharge", lblRegion.Text, lblEDFMetertype.Text, "24")) * 100).ToString();
            txtedfa24day.Text = lib.Edf("Day", lblRegion.Text, lblEDFMetertype.Text, "24");
            txtedfa24night.Text = lib.Edf("Night", lblRegion.Text, lblEDFMetertype.Text, "24");
            txtedfa24ew.Text = lib.Edf("EveningWeekend", lblRegion.Text, lblEDFMetertype.Text, "24");
            lbledfa24program.Text = lib.Edf("Contract", lblRegion.Text, lblEDFMetertype.Text, "24") + "for 247 months";

            // 24 Months all

            txtedfa24scall.Text = (Convert.ToDouble(lib.Edf("StandingCharge", lblRegion.Text, lblEDFMetertype.Text, "24")) * 100).ToString();
            txtedfa24dayall.Text = lib.Edf("Day", lblRegion.Text, lblEDFMetertype.Text, "24");
            txtedfa24nightall.Text = lib.Edf("Night", lblRegion.Text, lblEDFMetertype.Text, "24");
            txtedfa24ewall.Text = lib.Edf("EveningWeekend", lblRegion.Text, lblEDFMetertype.Text, "24");
            lbledfa24programall.Text = lib.Edf("Contract", lblRegion.Text, lblEDFMetertype.Text, "24") + "for 24 months";



            // 36 Months

            txtedfa36sc.Text = (Convert.ToDouble(lib.Edf("StandingCharge", lblRegion.Text, lblEDFMetertype.Text, "36")) * 100).ToString();
            txtedfa36day.Text = lib.Edf("Day", lblRegion.Text, lblEDFMetertype.Text, "36");
            txtedfa36night.Text = lib.Edf("Night", lblRegion.Text, lblEDFMetertype.Text, "36");
            txtedfa36ew.Text = lib.Edf("EveningWeekend", lblRegion.Text, lblEDFMetertype.Text, "36");
            lbledfa36program.Text = lib.Edf("Contract", lblRegion.Text, lblEDFMetertype.Text, "36") + "for 36 months";

            // 36 Months all

            txtedfa36scall.Text = (Convert.ToDouble(lib.Edf("StandingCharge", lblRegion.Text, lblEDFMetertype.Text, "36")) * 100).ToString();
            txtedfa36dayall.Text = lib.Edf("Day", lblRegion.Text, lblEDFMetertype.Text, "36");
            txtedfa36nightall.Text = lib.Edf("Night", lblRegion.Text, lblEDFMetertype.Text, "36");
            txtedfa36ewall.Text = lib.Edf("EveningWeekend", lblRegion.Text, lblEDFMetertype.Text, "36");
            lbledfa36programall.Text = lib.Edf("Contract", lblRegion.Text, lblEDFMetertype.Text, "36") + "for 36 months";

            // 48 Months

            txtedfa48sc.Text = (Convert.ToDouble(lib.Edf("StandingCharge", lblRegion.Text, lblEDFMetertype.Text, "48")) * 100).ToString();
            txtedfa48day.Text = lib.Edf("Day", lblRegion.Text, lblEDFMetertype.Text, "48");
            txtedfa48night.Text = lib.Edf("Night", lblRegion.Text, lblEDFMetertype.Text, "48");
            txtedfa48ew.Text = lib.Edf("EveningWeekend", lblRegion.Text, lblEDFMetertype.Text, "48");
            lbledfa48program.Text = lib.Edf("Contract", lblRegion.Text, lblEDFMetertype.Text, "48") + "for 48 months";

            // 48 Months all

            txtedfa48scall.Text = (Convert.ToDouble(lib.Edf("StandingCharge", lblRegion.Text, lblEDFMetertype.Text, "48")) * 100).ToString();
            txtedfa48dayall.Text = lib.Edf("Day", lblRegion.Text, lblEDFMetertype.Text, "48");
            txtedfa48nightall.Text = lib.Edf("Night", lblRegion.Text, lblEDFMetertype.Text, "48");
            txtedfa48ewall.Text = lib.Edf("EveningWeekend", lblRegion.Text, lblEDFMetertype.Text, "48");
            lbledfa48programall.Text = lib.Edf("Contract", lblRegion.Text, lblEDFMetertype.Text, "48") + "for 48 months";

            // 60 Months

            txtedfa60sc.Text = (Convert.ToDouble(lib.Edf("StandingCharge", lblRegion.Text, lblEDFMetertype.Text, "60")) * 100).ToString();
            txtedfa60day.Text = lib.Edf("Day", lblRegion.Text, lblEDFMetertype.Text, "60");
            txtedfa60night.Text = lib.Edf("Night", lblRegion.Text, lblEDFMetertype.Text, "60");
            txtedfa60ew.Text = lib.Edf("EveningWeekend", lblRegion.Text, lblEDFMetertype.Text, "60");
            lbledfa60program.Text = lib.Edf("Contract", lblRegion.Text, lblEDFMetertype.Text, "60");


            // 60 Months all

            txtedfa60scall.Text = (Convert.ToDouble(lib.Edf("StandingCharge", lblRegion.Text, lblEDFMetertype.Text, "60")) * 100).ToString();
            txtedfa60dayall.Text = lib.Edf("Day", lblRegion.Text, lblEDFMetertype.Text, "60");
            txtedfa60nightall.Text = lib.Edf("Night", lblRegion.Text, lblEDFMetertype.Text, "60");
            txtedfa60ewall.Text = lib.Edf("EveningWeekend", lblRegion.Text, lblEDFMetertype.Text, "60");
            lbledfa60programall.Text = lib.Edf("Contract", lblRegion.Text, lblEDFMetertype.Text, "60");


            // tooltip for edf

            // 12 Months
            txtedfa12sc.ToolTip = lib.Edf("StandingCharge", lblRegion.Text, lblEDFMetertype.Text, "12");
            txtedfa12day.ToolTip = lib.Edf("Day", lblRegion.Text, lblEDFMetertype.Text, "12");
            txtedfa12night.ToolTip = lib.Edf("Night", lblRegion.Text, lblEDFMetertype.Text, "12");
            txtedfa12ew.ToolTip = lib.Edf("EveningWeekend", lblRegion.Text, lblEDFMetertype.Text, "12");
            lbledfa12program.ToolTip = lib.Edf("Contract", lblRegion.Text, lblEDFMetertype.Text, "12") + "For 12 months";

            // 12 Months all
            txtedfa12scall.ToolTip = lib.Edf("StandingCharge", lblRegion.Text, lblEDFMetertype.Text, "12");
            txtedfa12dayall.ToolTip = lib.Edf("Day", lblRegion.Text, lblEDFMetertype.Text, "12");
            txtedfa12nightall.ToolTip = lib.Edf("Night", lblRegion.Text, lblEDFMetertype.Text, "12");
            txtedfa12ewall.ToolTip = lib.Edf("EveningWeekend", lblRegion.Text, lblEDFMetertype.Text, "12");
            lbledfa12programall.ToolTip = lib.Edf("Contract", lblRegion.Text, lblEDFMetertype.Text, "12") + "for 12 months";



            // 24 Months

            txtedfa24sc.ToolTip = lib.Edf("StandingCharge", lblRegion.Text, lblEDFMetertype.Text, "24");
            txtedfa24day.ToolTip = lib.Edf("Day", lblRegion.Text, lblEDFMetertype.Text, "24");
            txtedfa24night.ToolTip = lib.Edf("Night", lblRegion.Text, lblEDFMetertype.Text, "24");
            txtedfa24ew.ToolTip = lib.Edf("EveningWeekend", lblRegion.Text, lblEDFMetertype.Text, "24");
            lbledfa24program.ToolTip = lib.Edf("Contract", lblRegion.Text, lblEDFMetertype.Text, "24") + "for 247 months";

            // 24 Months all

            txtedfa24scall.ToolTip = lib.Edf("StandingCharge", lblRegion.Text, lblEDFMetertype.Text, "24");
            txtedfa24dayall.ToolTip = lib.Edf("Day", lblRegion.Text, lblEDFMetertype.Text, "24");
            txtedfa24nightall.ToolTip = lib.Edf("Night", lblRegion.Text, lblEDFMetertype.Text, "24");
            txtedfa24ewall.ToolTip = lib.Edf("EveningWeekend", lblRegion.Text, lblEDFMetertype.Text, "24");
            lbledfa24programall.ToolTip = lib.Edf("Contract", lblRegion.Text, lblEDFMetertype.Text, "24") + "for 24 months";



            // 36 Months

            txtedfa36sc.ToolTip = lib.Edf("StandingCharge", lblRegion.Text, lblEDFMetertype.Text, "36");
            txtedfa36day.ToolTip = lib.Edf("Day", lblRegion.Text, lblEDFMetertype.Text, "36");
            txtedfa36night.ToolTip = lib.Edf("Night", lblRegion.Text, lblEDFMetertype.Text, "36");
            txtedfa36ew.ToolTip = lib.Edf("EveningWeekend", lblRegion.Text, lblEDFMetertype.Text, "36");
            lbledfa36program.ToolTip = lib.Edf("Contract", lblRegion.Text, lblEDFMetertype.Text, "36") + "for 36 months";

            // 36 Months all

            txtedfa36scall.ToolTip = lib.Edf("StandingCharge", lblRegion.Text, lblEDFMetertype.Text, "36");
            txtedfa36dayall.ToolTip = lib.Edf("Day", lblRegion.Text, lblEDFMetertype.Text, "36");
            txtedfa36nightall.ToolTip = lib.Edf("Night", lblRegion.Text, lblEDFMetertype.Text, "36");
            txtedfa36ewall.ToolTip = lib.Edf("EveningWeekend", lblRegion.Text, lblEDFMetertype.Text, "36");
            lbledfa36programall.ToolTip = lib.Edf("Contract", lblRegion.Text, lblEDFMetertype.Text, "36") + "for 36 months";

            // 48 Months

            txtedfa48sc.ToolTip = lib.Edf("StandingCharge", lblRegion.Text, lblEDFMetertype.Text, "48");
            txtedfa48day.ToolTip = lib.Edf("Day", lblRegion.Text, lblEDFMetertype.Text, "48");
            txtedfa48night.ToolTip = lib.Edf("Night", lblRegion.Text, lblEDFMetertype.Text, "48");
            txtedfa48ew.ToolTip = lib.Edf("EveningWeekend", lblRegion.Text, lblEDFMetertype.Text, "48");
            lbledfa48program.ToolTip = lib.Edf("Contract", lblRegion.Text, lblEDFMetertype.Text, "48") + "for 48 months";

            // 48 Months all

            txtedfa48scall.ToolTip = lib.Edf("StandingCharge", lblRegion.Text, lblEDFMetertype.Text, "48");
            txtedfa48dayall.ToolTip = lib.Edf("Day", lblRegion.Text, lblEDFMetertype.Text, "48");
            txtedfa48nightall.ToolTip = lib.Edf("Night", lblRegion.Text, lblEDFMetertype.Text, "48");
            txtedfa48ewall.ToolTip = lib.Edf("EveningWeekend", lblRegion.Text, lblEDFMetertype.Text, "48");
            lbledfa48programall.ToolTip = lib.Edf("Contract", lblRegion.Text, lblEDFMetertype.Text, "48") + "for 48 months";

            // 60 Months

            txtedfa60sc.ToolTip = lib.Edf("StandingCharge", lblRegion.Text, lblEDFMetertype.Text, "60");
            txtedfa60day.ToolTip = lib.Edf("Day", lblRegion.Text, lblEDFMetertype.Text, "60");
            txtedfa60night.ToolTip = lib.Edf("Night", lblRegion.Text, lblEDFMetertype.Text, "60");
            txtedfa60ew.ToolTip = lib.Edf("EveningWeekend", lblRegion.Text, lblEDFMetertype.Text, "60");
            lbledfa60program.ToolTip = lib.Edf("Contract", lblRegion.Text, lblEDFMetertype.Text, "60");


            // 60 Months all

            txtedfa60scall.ToolTip = lib.Edf("StandingCharge", lblRegion.Text, lblEDFMetertype.Text, "60");
            txtedfa60dayall.ToolTip = lib.Edf("Day", lblRegion.Text, lblEDFMetertype.Text, "60");
            txtedfa60nightall.ToolTip = lib.Edf("Night", lblRegion.Text, lblEDFMetertype.Text, "60");
            txtedfa60ewall.ToolTip = lib.Edf("EveningWeekend", lblRegion.Text, lblEDFMetertype.Text, "60");
            lbledfa60programall.ToolTip = lib.Edf("Contract", lblRegion.Text, lblEDFMetertype.Text, "60");



        }

        #endregion

        #region DUAL calculation

        void Bindde()
        {
            string salestype = lblELEPayment.Text;
            if (lblCurrentSupplier.Text != "DE")
            {

                if (lblProfile.Text != "00")
                {
                   
                    txtdea12sc.Text = (Convert.ToDouble(lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 1 Year")) * 100).ToString();
                    txtdea12day.Text = (Convert.ToDouble(lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 1 Year")) * 100).ToString();
                    txtdea12night.Text = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 1 Year");
                    txtdea12ew.Text = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 1 Year");

                    lbldea12program.Text = lib.DuelEnergy("Product", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 1 Year") + " For 1 Year";
                    // 12 Months all
                    txtdea12sc12all.Text = (Convert.ToDouble(lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 1 Year")) * 100).ToString();
                    txtdea12day12all.Text = (Convert.ToDouble(lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 1 Year")) * 100).ToString();
                    txtdea12night12all.Text = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 1 Year");
                    txtdea12ew12all.Text = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 1 Year");

                    lbldea12program12all.Text = lib.DuelEnergy("Product", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 1 Year") + " For 1 Year";


                    // 24 Months

                    txtdea24sc.Text = (Convert.ToDouble(lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 2 Year")) * 100).ToString();
                    txtdea24day.Text = (Convert.ToDouble(lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 2 Year")) * 100).ToString();
                    txtdea24night.Text = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 2 Year");
                    txtdea24ew.Text = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 2 Year");

                    lbldea24program.Text = lib.DuelEnergy("Product", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 2 Year") + " For 2 Year";

                    // 24 Months

                    txtdea24sc24all.Text = (Convert.ToDouble(lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 2 Year")) * 100).ToString();
                    txtdea24day24all.Text = (Convert.ToDouble(lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 2 Year")) * 100).ToString();
                    txtdea24night24all.Text = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 2 Year");
                    txtdea24ew24all.Text = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 2 Year");

                    lbldea24program24all.Text = lib.DuelEnergy("Product", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 2 Year") + " For 2 Year";

                    // 36 Months

                    txtdea36sc.Text = (Convert.ToDouble(lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 3 Year")) * 100).ToString();
                    txtdea36day.Text = (Convert.ToDouble(lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 3 Year")) * 100).ToString();
                    txtdea36night.Text = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 3 Year");
                    txtdea36ew.Text = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 3 Year");

                    lbldea36program.Text = lib.DuelEnergy("Product", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 3 Year") + " For 3 Year";

                    // 36 Months all

                    txtdea36scall.Text = (Convert.ToDouble(lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 3 Year")) * 100).ToString();
                    txtdea36dayall.Text = (Convert.ToDouble(lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 3 Year")) * 100).ToString();
                    txtdea36nightall.Text = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 3 Year");
                    txtdea36ewall.Text = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 3 Year");

                    lbldea36programall.Text = lib.DuelEnergy("Product", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 3 Year") + " For 3 Year";





                    // 48 Months

                    txtdea48sc.Text = (Convert.ToDouble(lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 4 Year")) * 100).ToString();
                    txtdea48day.Text = (Convert.ToDouble(lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 4 Year")) * 100).ToString();
                    txtdea48night.Text = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 4 Year");
                    txtdea48ew.Text = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 4 Year");

                    lbldea48program.Text = lib.DuelEnergy("Product", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 4 Year") + " For 4 Year";

                    // 48 Months all

                    txtdea48scall.Text = (Convert.ToDouble(lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 4 Year")) * 100).ToString();
                    txtdea48dayall.Text = (Convert.ToDouble(lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 4 Year")) * 100).ToString();
                    txtdea48nightall.Text = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 4 Year");
                    txtdea48ewall.Text = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 4 Year");

                    lbldea48programall.Text = lib.DuelEnergy("Product", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 4 Year") + " For 4 Year";

                    // 60 Months

                    txtdea60sc.Text = (Convert.ToDouble(lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 5 Year")) * 100).ToString();
                    txtdea60day.Text = (Convert.ToDouble(lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 5 Year")) * 100).ToString();
                    txtdea60night.Text = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 5 Year");
                    txtdea60ew.Text = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 5 Year");

                    lbldea60program.Text = lib.DuelEnergy("Product", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 5 Year") + " For 5 Year";

                    // 60 Months
                    txtdea60scall.Text = (Convert.ToDouble(lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 5 Year")) * 100).ToString();
                    txtdea60dayall.Text = (Convert.ToDouble(lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 5 Year")) * 100).ToString();
                    txtdea60nightall.Text = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 5 Year");
                    txtdea60ewall.Text = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 5 Year");

                    lbldea60programall.Text = lib.DuelEnergy("Product", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 5 Year") + " For 5 Year";



                    /// Tooltip
                    /// 

                    txtdea12sc.ToolTip = lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 1 Year");
                    txtdea12day.ToolTip = lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 1 Year");
                    txtdea12night.ToolTip = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 1 Year");
                    txtdea12ew.ToolTip = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 1 Year");

                    lbldea12program.ToolTip = lib.DuelEnergy("Product", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 1 Year") + " For 1 Year";
                    // 12 Months all
                    txtdea12sc12all.ToolTip = lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 1 Year");
                    txtdea12day12all.ToolTip = lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 1 Year");
                    txtdea12night12all.ToolTip = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 1 Year");
                    txtdea12ew12all.ToolTip = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 1 Year");

                    lbldea12program12all.ToolTip = lib.DuelEnergy("Product", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 1 Year") + " For 1 Year";


                    // 24 Months

                    txtdea24sc.ToolTip = lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 2 Year");
                    txtdea24day.ToolTip = lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 2 Year");
                    txtdea24night.ToolTip = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 2 Year");
                    txtdea24ew.ToolTip = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 2 Year");

                    lbldea24program.ToolTip = lib.DuelEnergy("Product", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 2 Year") + " For 2 Year";

                    // 24 Months

                    txtdea24sc24all.ToolTip = lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 2 Year");
                    txtdea24day24all.ToolTip = lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 2 Year");
                    txtdea24night24all.ToolTip = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 2 Year");
                    txtdea24ew24all.ToolTip = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 2 Year");

                    lbldea24program24all.ToolTip = lib.DuelEnergy("Product", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 2 Year") + " For 2 Year";

                    // 36 Months

                    txtdea36sc.ToolTip = lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 3 Year");
                    txtdea36day.ToolTip = lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 3 Year");
                    txtdea36night.ToolTip = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 3 Year");
                    txtdea36ew.ToolTip = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 3 Year");

                    lbldea36program.ToolTip = lib.DuelEnergy("Product", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 3 Year") + " For 3 Year";

                    // 36 Months all

                    txtdea36scall.ToolTip = lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 3 Year");
                    txtdea36dayall.ToolTip = lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 3 Year");
                    txtdea36nightall.ToolTip = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 3 Year");
                    txtdea36ewall.ToolTip = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 3 Year");

                    lbldea36programall.ToolTip = lib.DuelEnergy("Product", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 3 Year") + " For 3 Year";





                    // 48 Months

                    txtdea48sc.ToolTip = lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 4 Year");
                    txtdea48day.ToolTip = lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 4 Year");
                    txtdea48night.ToolTip = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 4 Year");
                    txtdea48ew.ToolTip = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 4 Year");

                    lbldea48program.ToolTip = lib.DuelEnergy("Product", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 4 Year") + " For 4 Year";

                    // 48 Months all

                    txtdea48scall.ToolTip = lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 4 Year");
                    txtdea48dayall.ToolTip = lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 4 Year");
                    txtdea48nightall.ToolTip = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 4 Year");
                    txtdea48ewall.ToolTip = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 4 Year");

                    lbldea48programall.ToolTip = lib.DuelEnergy("Product", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 4 Year") + " For 4 Year";

                    // 60 Months

                    txtdea60sc.ToolTip = lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 5 Year");
                    txtdea60day.ToolTip = lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 5 Year");
                    txtdea60night.ToolTip = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 5 Year");
                    txtdea60ew.ToolTip = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 5 Year");

                    lbldea60program.ToolTip = lib.DuelEnergy("Product", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 5 Year") + " For 5 Year";

                    // 60 Months
                    txtdea60scall.ToolTip = lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 5 Year");
                    txtdea60dayall.ToolTip = lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 5 Year");
                    txtdea60nightall.ToolTip = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 5 Year");
                    txtdea60ewall.ToolTip = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 5 Year");

                    lbldea60programall.ToolTip = lib.DuelEnergy("Product", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 5 Year") + " For 5 Year";
                }

                if(lblProfile.Text == "00")
                {
                    string mtype = "HH 1RATE (CT)";
                    txtdea12sc.Text = (Convert.ToDouble(lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 1 Year (Level 2)")) * 100).ToString();
                    txtdea12day.Text = (Convert.ToDouble(lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 1 Year (Level 2)")) * 100).ToString();
                    txtdea12night.Text = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 1 Year (Level 2)");
                    txtdea12ew.Text = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 1 Year (Level 2)");

                    lbldea12program.Text = lib.DuelEnergy("Product", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 1 Year (Level 2)") + " For 1 Year";
                    // 12 Months all
                    txtdea12sc12all.Text = (Convert.ToDouble(lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 1 Year (Level 2)")) * 100).ToString();
                    txtdea12day12all.Text = (Convert.ToDouble(lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 1 Year (Level 2)")) * 100).ToString();
                    txtdea12night12all.Text = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 1 Year (Level 2)");
                    txtdea12ew12all.Text = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 1 Year (Level 2)");

                    lbldea12program12all.Text = lib.DuelEnergy("Product", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 1 Year (Level 2)") + " For 1 Year";


                    // 24 Months

                    txtdea24sc.Text = (Convert.ToDouble(lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 2 Year (Level 2)")) * 100).ToString();
                    txtdea24day.Text = (Convert.ToDouble(lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 2 Year (Level 2)")) * 100).ToString();
                    txtdea24night.Text = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 2 Year (Level 2)");
                    txtdea24ew.Text = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 2 Year (Level 2)");

                    lbldea24program.Text = lib.DuelEnergy("Product", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 2 Year (Level 2") + " For 2 Year";

                    // 24 Months

                    txtdea24sc24all.Text = (Convert.ToDouble(lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 2 Year (Level 2")) * 100).ToString();
                    txtdea24day24all.Text = (Convert.ToDouble(lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 2 Year (Level 2")) * 100).ToString();
                    txtdea24night24all.Text = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 2 Year (Level 2)");
                    txtdea24ew24all.Text = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 2 Year (Level 2)");

                    lbldea24program24all.Text = lib.DuelEnergy("Product", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 2 Year (Level 2)") + " For 2 Year";

                    // 36 Months

                    txtdea36sc.Text = (Convert.ToDouble(lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 3 Year (Level 2)")) * 100).ToString();
                    txtdea36day.Text = (Convert.ToDouble(lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 3 Year (Level 2)")) * 100).ToString();
                    txtdea36night.Text = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 3 Year (Level 2)");
                    txtdea36ew.Text = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 3 Year (Level 2)");

                    lbldea36program.Text = lib.DuelEnergy("Product", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 3 Year (Level 2)") + " For 3 Year";

                    // 36 Months all

                    txtdea36scall.Text = (Convert.ToDouble(lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 3 Year (Level 2)")) * 100).ToString();
                    txtdea36dayall.Text = (Convert.ToDouble(lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 3 Year (Level 2)")) * 100).ToString();
                    txtdea36nightall.Text = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 3 Year (Level 2)");
                    txtdea36ewall.Text = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 3 Year (Level 2)");

                    lbldea36programall.Text = lib.DuelEnergy("Product", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 3 Year (Level 2)") + " For 3 Year";





                    // 48 Months

                    txtdea48sc.Text = (Convert.ToDouble(lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 4 Year (Level 2)")) * 100).ToString();
                    txtdea48day.Text = (Convert.ToDouble(lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 4 Year (Level 2)")) * 100).ToString();
                    txtdea48night.Text = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 4 Year (Level 2)");
                    txtdea48ew.Text = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 4 Year (Level 2)");

                    lbldea48program.Text = lib.DuelEnergy("Product", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 4 Year (Level 2)") + " For 4 Year";

                    // 48 Months all

                    txtdea48scall.Text = (Convert.ToDouble(lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 4 Year (Level 2)")) * 100).ToString();
                    txtdea48dayall.Text = (Convert.ToDouble(lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 4 Year (Level 2)")) * 100).ToString();
                    txtdea48nightall.Text = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 4 Year (Level 2)");
                    txtdea48ewall.Text = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 4 Year (Level 2)");

                    lbldea48programall.Text = lib.DuelEnergy("Product", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 4 Year (Level 2)") + " For 4 Year";

                    // 60 Months

                    txtdea60sc.Text = (Convert.ToDouble(lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 5 Year (Level 2)")) * 100).ToString();
                    txtdea60day.Text = (Convert.ToDouble(lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 5 Year (Level 2)")) * 100).ToString();
                    txtdea60night.Text = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 5 Year (Level 2)");
                    txtdea60ew.Text = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 5 Year (Level 2)");

                    lbldea60program.Text = lib.DuelEnergy("Product", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 5 Year (Level 2)") + " For 5 Year";

                    // 60 Months
                    txtdea60scall.Text = (Convert.ToDouble(lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 5 Year (Level 2)")) * 100).ToString();
                    txtdea60dayall.Text = (Convert.ToDouble(lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 5 Year (Level 2)")) * 100).ToString();
                    txtdea60nightall.Text = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 5 Year (Level 2)");
                    txtdea60ewall.Text = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 5 Year (Level 2)");

                    lbldea60programall.Text = lib.DuelEnergy("Product", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 5 Year (Level 2)") + " For 5 Year";



                    /// Tooltip
                    /// 

                    txtdea12sc.ToolTip = lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 1 Year (Level 2)");
                    txtdea12day.ToolTip = lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 1 Year (Level 2)");
                    txtdea12night.ToolTip = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 1 Year (Level 2)");
                    txtdea12ew.ToolTip = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 1 Year (Level 2)");

                  
                    // 12 Months all
                    txtdea12sc12all.ToolTip = lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 1 Year (Level 2)");
                    txtdea12day12all.ToolTip = lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 1 Year (Level 2)");
                    txtdea12night12all.ToolTip = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 1 Year (Level 2)");
                    txtdea12ew12all.ToolTip = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 1 Year (Level 2)");

                 


                    // 24 Months

                    txtdea24sc.ToolTip = lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 2 Year (Level 2)");
                    txtdea24day.ToolTip = lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 2 Year (Level 2)");
                    txtdea24night.ToolTip = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 2 Year (Level 2)");
                    txtdea24ew.ToolTip = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 2 Year (Level 2)");

                
                    // 24 Months

                    txtdea24sc24all.ToolTip = lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 2 Year (Level 2)");
                    txtdea24day24all.ToolTip = lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 2 Year (Level 2)");
                    txtdea24night24all.ToolTip = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 2 Year (Level 2)");
                    txtdea24ew24all.ToolTip = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 2 Year (Level 2)");

                   

                    // 36 Months

                    txtdea36sc.ToolTip = lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 3 Year (Level 2)");
                    txtdea36day.ToolTip = lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 3 Year (Level 2)");
                    txtdea36night.ToolTip = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 3 Year (Level 2)");
                    txtdea36ew.ToolTip = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 3 Year (Level 2)");

                   

                    // 36 Months all

                    txtdea36scall.ToolTip = lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 3 Year (Level 2)");
                    txtdea36dayall.ToolTip = lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 3 Year (Level 2)");
                    txtdea36nightall.ToolTip = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 3 Year (Level 2)");
                    txtdea36ewall.ToolTip = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 3 Year (Level 2)");

                  





                    // 48 Months

                    txtdea48sc.ToolTip = lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 4 Year (Level 2)");
                    txtdea48day.ToolTip = lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 4 Year (Level 2)");
                    txtdea48night.ToolTip = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 4 Year (Level 2)");
                    txtdea48ew.ToolTip = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 4 Year (Level 2)");

                  
                    // 48 Months all

                    txtdea48scall.ToolTip = lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 4 Year (Level 2)");
                    txtdea48dayall.ToolTip = lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 4 Year (Level 2)");
                    txtdea48nightall.ToolTip = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 4 Year (Level 2)");
                    txtdea48ewall.ToolTip = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 4 Year (Level 2)");

                 

                    // 60 Months

                    txtdea60sc.ToolTip = lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 5 Year (Level 2)");
                    txtdea60day.ToolTip = lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 5 Year (Level 2)");
                    txtdea60night.ToolTip = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 5 Year (Level 2)");
                    txtdea60ew.ToolTip = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 5 Year (Level 2)");

                  

                    // 60 Months
                    txtdea60scall.ToolTip = lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 5 Year (Level 2)");
                    txtdea60dayall.ToolTip = lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 5 Year (Level 2)");
                    txtdea60nightall.ToolTip = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 5 Year (Level 2)");
                    txtdea60ewall.ToolTip = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 5 Year (Level 2)");


                    // For WC Rate

                    mtype = "HH 1RATE (WC)";

                    txtdeawc12sc.Text = (Convert.ToDouble(lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 1 Year (Level 2)")) * 100).ToString();
                    txtdeawc12day.Text = (Convert.ToDouble(lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 1 Year (Level 2)")) * 100).ToString();
                    txtdeawc12night.Text = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 1 Year (Level 2)");
                    txtdeawc12ew.Text = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 1 Year (Level 2)");

                    lbldeawc12program.Text = lib.DuelEnergy("Product", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 1 Year (Level 2)") + " For 1 Year";
                    // 12 Months all
                    txtdeawc12sc12all.Text = (Convert.ToDouble(lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 1 Year (Level 2)")) * 100).ToString();
                    txtdeawc12day12all.Text = (Convert.ToDouble(lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 1 Year (Level 2)")) * 100).ToString();
                    txtdeawc12night12all.Text = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 1 Year (Level 2)");
                    txtdeawc12ew12all.Text = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 1 Year (Level 2)");

                    lbldeawc12program12all.Text = lib.DuelEnergy("Product", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 1 Year (Level 2)") + " For 1 Year";


                    // 24 Months

                    txtdeawc24sc.Text = (Convert.ToDouble(lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 2 Year (Level 2)")) * 100).ToString();
                    txtdeawc24day.Text = (Convert.ToDouble(lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 2 Year (Level 2)")) * 100).ToString();
                    txtdeawc24night.Text = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 2 Year (Level 2)");
                    txtdeawc24ew.Text = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 2 Year (Level 2)");

                    lbldeawc24program.Text = lib.DuelEnergy("Product", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 2 Year (Level 2") + " For 2 Year";

                    // 24 Months

                    txtdeawc24sc24all.Text = (Convert.ToDouble(lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 2 Year (Level 2")) * 100).ToString();
                    txtdeawc24day24all.Text = (Convert.ToDouble(lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 2 Year (Level 2")) * 100).ToString();
                    txtdeawc24night24all.Text = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 2 Year (Level 2)");
                    txtdeawc24ew24all.Text = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 2 Year (Level 2)");

                    lbldeawc24program24all.Text = lib.DuelEnergy("Product", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 2 Year (Level 2)") + " For 2 Year";

                    // 36 Months

                    txtdeawc36sc.Text = (Convert.ToDouble(lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 3 Year (Level 2)")) * 100).ToString();
                    txtdeawc36day.Text = (Convert.ToDouble(lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 3 Year (Level 2)")) * 100).ToString();
                    txtdeawc36night.Text = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 3 Year (Level 2)");
                    txtdeawc36ew.Text = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 3 Year (Level 2)");

                    lbldeawc36program.Text = lib.DuelEnergy("Product", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 3 Year (Level 2)") + " For 3 Year";

                    // 36 Months all

                    txtdeawc36sc36all.Text = (Convert.ToDouble(lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 3 Year (Level 2)")) * 100).ToString();
                    txtdeawc36day36all.Text = (Convert.ToDouble(lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 3 Year (Level 2)")) * 100).ToString();
                    txtdeawc36night36all.Text = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 3 Year (Level 2)");
                    txtdeawc36ew36all.Text = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 3 Year (Level 2)");

                    lbldeawc36program36all.Text = lib.DuelEnergy("Product", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 3 Year (Level 2)") + " For 3 Year";





                    // 48 Months

                    txtdeawc48sc.Text = (Convert.ToDouble(lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 4 Year (Level 2)")) * 100).ToString();
                    txtdeawc48day.Text = (Convert.ToDouble(lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 4 Year (Level 2)")) * 100).ToString();
                    txtdeawc48night.Text = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 4 Year (Level 2)");
                    txtdeawc48ew.Text = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 4 Year (Level 2)");

                    lbldeawc48program.Text = lib.DuelEnergy("Product", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 4 Year (Level 2)") + " For 4 Year";

                    // 48 Months all

                    txtdeawc48sc48all.Text = (Convert.ToDouble(lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 4 Year (Level 2)")) * 100).ToString();
                    txtdeawc48day48all.Text = (Convert.ToDouble(lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 4 Year (Level 2)")) * 100).ToString();
                    txtdeawc48night48all.Text = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 4 Year (Level 2)");
                    txtdeawc48ew48all.Text = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 4 Year (Level 2)");

                    lbldea48programall.Text = lib.DuelEnergy("Product", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 4 Year (Level 2)") + " For 4 Year";

                    // 60 Months

                    txtdeawc60sc.Text = (Convert.ToDouble(lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 5 Year (Level 2)")) * 100).ToString();
                    txtdeawc60day.Text = (Convert.ToDouble(lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 5 Year (Level 2)")) * 100).ToString();
                    txtdeawc60night.Text = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 5 Year (Level 2)");
                    txtdeawc60ew.Text = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 5 Year (Level 2)");

                    lbldeawc60program.Text = lib.DuelEnergy("Product", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 5 Year (Level 2)") + " For 5 Year";

                    // 60 Months
                    txtdeawc60sc60all.Text = (Convert.ToDouble(lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 5 Year (Level 2)")) * 100).ToString();
                    txtdeawc60day60all.Text = (Convert.ToDouble(lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 5 Year (Level 2)")) * 100).ToString();
                    txtdeawc60night60all.Text = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 5 Year (Level 2)");
                    txtdeawc60ew60all.Text = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 5 Year (Level 2)");

                    lbldea60programall.Text = lib.DuelEnergy("Product", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 5 Year (Level 2)") + " For 5 Year";



                    /// Tooltip
                    /// 

                    txtdeawc12sc.ToolTip = lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 1 Year (Level 2)");
                    txtdeawc12day.ToolTip = lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 1 Year (Level 2)");
                    txtdeawc12night.ToolTip = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 1 Year (Level 2)");
                    txtdeawc12ew.ToolTip = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 1 Year (Level 2)");


                    // 12 Months all
                    txtdeawc12sc12all.ToolTip = lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 1 Year (Level 2)");
                    txtdeawc12day12all.ToolTip = lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 1 Year (Level 2)");
                    txtdeawc12night12all.ToolTip = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 1 Year (Level 2)");
                    txtdeawc12ew12all.ToolTip = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 1 Year (Level 2)");




                    // 24 Months

                    txtdeawc24sc.ToolTip = lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 2 Year (Level 2)");
                    txtdeawc24day.ToolTip = lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 2 Year (Level 2)");
                    txtdeawc24night.ToolTip = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 2 Year (Level 2)");
                    txtdeawc24ew.ToolTip = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 2 Year (Level 2)");


                    // 24 Months

                    txtdeawc24sc24all.ToolTip = lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 2 Year (Level 2)");
                    txtdeawc24day24all.ToolTip = lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 2 Year (Level 2)");
                    txtdeawc24night24all.ToolTip = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 2 Year (Level 2)");
                    txtdeawc24ew24all.ToolTip = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 2 Year (Level 2)");



                    // 36 Months

                    txtdeawc36sc.ToolTip = lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 3 Year (Level 2)");
                    txtdeawc36day.ToolTip = lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 3 Year (Level 2)");
                    txtdeawc36night.ToolTip = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 3 Year (Level 2)");
                    txtdeawc36ew.ToolTip = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 3 Year (Level 2)");



                    // 36 Months all

                    txtdeawc36sc36all.ToolTip = lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 3 Year (Level 2)");
                    txtdeawc36day36all.ToolTip = lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 3 Year (Level 2)");
                    txtdeawc36night36all.ToolTip = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 3 Year (Level 2)");
                    txtdeawc36ew36all.ToolTip = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 3 Year (Level 2)");







                    // 48 Months

                    txtdeawc48sc.ToolTip = lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 4 Year (Level 2)");
                    txtdeawc48day.ToolTip = lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 4 Year (Level 2)");
                    txtdeawc48night.ToolTip = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 4 Year (Level 2)");
                    txtdeawc48ew.ToolTip = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 4 Year (Level 2)");


                    // 48 Months all

                    txtdeawc48sc48all.ToolTip = lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 4 Year (Level 2)");
                    txtdeawc48day48all.ToolTip = lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 4 Year (Level 2)");
                    txtdeawc48night48all.ToolTip = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 4 Year (Level 2)");
                    txtdeawc48ew48all.ToolTip = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 4 Year (Level 2)");



                    // 60 Months

                    txtdeawc60sc.ToolTip = lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 5 Year (Level 2)");
                    txtdeawc60day.ToolTip = lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 5 Year (Level 2)");
                    txtdeawc60night.ToolTip = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 5 Year (Level 2)");
                    txtdeawc60ew.ToolTip = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 5 Year (Level 2)");



                    // 60 Months
                    txtdeawc60sc60all.ToolTip = lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 5 Year (Level 2)");
                    txtdeawc60day60all.ToolTip = lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 5 Year (Level 2)");
                    txtdeawc60night60all.ToolTip = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 5 Year (Level 2)");
                    txtdeawc60ew60all.ToolTip = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 5 Year (Level 2)");



                }
            }
            else
            {
                // 12 Months

                if (lblProfile.Text != "00")
                {

                    txtdea12sc.Text = (Convert.ToDouble(lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 1 Year Renewal")) * 100).ToString();
                    txtdea12day.Text = (Convert.ToDouble(lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 1 Year Renewal")) * 100).ToString();
                    txtdea12night.Text = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 1 Year Renewal");
                    txtdea12ew.Text = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 1 Year Renewal");

                    lbldea12program.Text = lib.DuelEnergy("Product", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 1 Year Renewal") + " For 1 Year";
                    // 12 Months all
                    txtdea12sc12all.Text = (Convert.ToDouble(lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 1 Year Renewal")) * 100).ToString();
                    txtdea12day12all.Text = (Convert.ToDouble(lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 2 Year Renewal")) * 100).ToString();
                    txtdea12night12all.Text = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SSmartFIX – 1 Year Renewal");
                    txtdea12ew12all.Text = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 1 Year Renewal");

                    lbldea12program12all.Text = lib.DuelEnergy("Product", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 1 Year Renewal") + " For 1 Year";


                    // 24 Months

                    txtdea24sc.Text = (Convert.ToDouble(lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 2 Year Renewal")) * 100).ToString();
                    txtdea24day.Text = (Convert.ToDouble(lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 2 Year Renewal")) * 100).ToString();
                    txtdea24night.Text = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 2 Year Renewal");
                    txtdea24ew.Text = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 2 Year Renewal");

                    lbldea24program.Text = lib.DuelEnergy("Product", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 2 Year Renewal") + " For 2 Year";

                    // 24 Months

                    txtdea24sc24all.Text = (Convert.ToDouble(lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 2 Year Renewal")) * 100).ToString();
                    txtdea24day24all.Text = (Convert.ToDouble(lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 2 Year Renewal")) * 100).ToString();
                    txtdea24night24all.Text = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 2 Year Renewal");
                    txtdea24ew24all.Text = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 2 Year Renewal");

                    lbldea24program24all.Text = lib.DuelEnergy("Product", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 2 Year Renewal") + " For 2 Year";

                    // 36 Months

                    txtdea36sc.Text = (Convert.ToDouble(lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 3 Year Renewal")) * 100).ToString();
                    txtdea36day.Text = (Convert.ToDouble(lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 3 Year Renewal")) * 100).ToString();
                    txtdea36night.Text = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 3 Year Renewal");
                    txtdea36ew.Text = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 3 Year Renewal");

                    lbldea36program.Text = lib.DuelEnergy("Product", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 3 Year Renewal") + " For 3 Year";

                    // 36 Months all

                    txtdea36scall.Text = (Convert.ToDouble(lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 3 Year Renewal")) * 100).ToString();
                    txtdea36dayall.Text = (Convert.ToDouble(lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 3 Year Renewal")) * 100).ToString();
                    txtdea36nightall.Text = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 3 Year Renewal");
                    txtdea36ewall.Text = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 3 Year Renewal");

                    lbldea36programall.Text = lib.DuelEnergy("Product", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 3 Year Renewal") + " For 3 Year";





                    // 48 Months

                    txtdea48sc.Text = (Convert.ToDouble(lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 4 Year Renewal")) * 100).ToString();
                    txtdea48day.Text = (Convert.ToDouble(lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 4 Year Renewal")) * 100).ToString();
                    txtdea48night.Text = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 4 Year Renewal");
                    txtdea48ew.Text = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 4 Year Renewal");

                    lbldea48program.Text = lib.DuelEnergy("Product", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 4 Year Renewal") + " For 4 Year";

                    // 48 Months all

                    txtdea48scall.Text = (Convert.ToDouble(lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 4 Year Renewal")) * 100).ToString();
                    txtdea48dayall.Text = (Convert.ToDouble(lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 4 Year Renewal")) * 100).ToString();
                    txtdea48nightall.Text = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 4 Year Renewal");
                    txtdea48ewall.Text = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 4 Year Renewal");

                    lbldea48programall.Text = lib.DuelEnergy("Product", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 4 Year Renewal") + " For 4 Year";

                    // 60 Months

                    txtdea60sc.Text = (Convert.ToDouble(lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 5 Year Renewal")) * 100).ToString();
                    txtdea60day.Text = (Convert.ToDouble(lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 5 Year Renewal")) * 100).ToString();
                    txtdea60night.Text = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 5 Year Renewal");
                    txtdea60ew.Text = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 5 Year Renewal");

                    lbldea60program.Text = lib.DuelEnergy("Product", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 5 Year Renewal") + " For 5 Year";

                    // 60 Months
                    txtdea60scall.Text = (Convert.ToDouble(lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 5 Year Renewal")) * 100).ToString();
                    txtdea60dayall.Text = (Convert.ToDouble(lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 5 Year Renewal")) * 100).ToString();
                    txtdea60nightall.Text = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 5 Year");
                    txtdea60ewall.Text = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 5 Year Renewal");

                    lbldea60programall.Text = lib.DuelEnergy("Product", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 5 Year Renewal") + " For 5 Year";



                    /// Tooltip
                    /// 

                    txtdea12sc.ToolTip = lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 1 Year Renewal");
                    txtdea12day.ToolTip = lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 1 Year Renewal");
                    txtdea12night.ToolTip = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 1 Year Renewal");
                    txtdea12ew.ToolTip = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 1 Year Renewal");

                    lbldea12program.ToolTip = lib.DuelEnergy("Product", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 1 Year Renewal") + " For 1 Year";
                    // 12 Months all
                    txtdea12sc12all.ToolTip = lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 1 Year Renewal");
                    txtdea12day12all.ToolTip = lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 1 Year Renewal");
                    txtdea12night12all.ToolTip = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 1 Year Renewal");
                    txtdea12ew12all.ToolTip = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 1 Year Renewal");

                    lbldea12program12all.ToolTip = lib.DuelEnergy("Product", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 1 Year Renewal") + " For 1 Year";


                    // 24 Months

                    txtdea24sc.ToolTip = lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 2 Year Renewal");
                    txtdea24day.ToolTip = lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 2 Year Renewal");
                    txtdea24night.ToolTip = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 2 Year Renewal");
                    txtdea24ew.ToolTip = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 2 Year Renewal");

                    lbldea24program.ToolTip = lib.DuelEnergy("Product", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 2 Year Renewal") + " For 2 Year";

                    // 24 Months

                    txtdea24sc24all.ToolTip = lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 2 Year Renewal");
                    txtdea24day24all.ToolTip = lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 2 Year Renewal");
                    txtdea24night24all.ToolTip = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 2 Year Renewal");
                    txtdea24ew24all.ToolTip = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 2 Year Renewal");

                    lbldea24program24all.ToolTip = lib.DuelEnergy("Product", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 2 Year Renewal") + " For 2 Year";

                    // 36 Months

                    txtdea36sc.ToolTip = lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 3 Year Renewal");
                    txtdea36day.ToolTip = lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 3 Year Renewal");
                    txtdea36night.ToolTip = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 3 Year Renewal");
                    txtdea36ew.ToolTip = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 3 Year Renewal");

                    lbldea36program.ToolTip = lib.DuelEnergy("Product", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 3 Year Renewal") + " For 3 Year";

                    // 36 Months all

                    txtdea36scall.ToolTip = lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 3 Year Renewal");
                    txtdea36dayall.ToolTip = lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 3 Year Renewal");
                    txtdea36nightall.ToolTip = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 3 Year Renewal");
                    txtdea36ewall.ToolTip = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 3 Year Renewal");

                    lbldea36programall.ToolTip = lib.DuelEnergy("Product", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 3 Year Renewal") + " For 3 Year";





                    // 48 Months

                    txtdea48sc.ToolTip = lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 4 Year Renewal");
                    txtdea48day.ToolTip = lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 4 Year Renewal");
                    txtdea48night.ToolTip = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 4 Year Renewal");
                    txtdea48ew.ToolTip = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 4 Year Renewal");

                    lbldea48program.ToolTip = lib.DuelEnergy("Product", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 4 Year Renewal") + " For 4 Year";

                    // 48 Months all

                    txtdea48scall.ToolTip = lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 4 Year Renewal");
                    txtdea48dayall.ToolTip = lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 4 Year Renewal");
                    txtdea48nightall.ToolTip = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 4 Year Renewal");
                    txtdea48ewall.ToolTip = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 4 Year Renewal");

                    lbldea48programall.ToolTip = lib.DuelEnergy("Product", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 4 Year Renewal") + " For 4 Year";

                    // 60 Months

                    txtdea60sc.ToolTip = lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 5 Year Renewal");
                    txtdea60day.ToolTip = lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 5 Year Renewal");
                    txtdea60night.ToolTip = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 5 Year Renewal");
                    txtdea60ew.ToolTip = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 5 Year Renewal");

                    lbldea60program.ToolTip = lib.DuelEnergy("Product", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 5 Year Renewal") + " For 5 Year";

                    // 60 Months
                    txtdea60scall.ToolTip = lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 5 Year Renewal");
                    txtdea60dayall.ToolTip = lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 5 Year Renewal");
                    txtdea60nightall.ToolTip = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 5 Year Renewal");
                    txtdea60ewall.ToolTip = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 5 Year Renewal");

                    lbldea60programall.ToolTip = lib.DuelEnergy("Product", lblProfile.Text, lblRegion.Text, lblDEMetertype.Text, "SmartFIX – 5 Year Renewal") + " For 5 Year";
                }

                if(lblProfile.Text == "00")
                {

                    string mtype = "HH 1RATE (CT)";
                    txtdea12sc.Text = (Convert.ToDouble(lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 1 Year Renewal (Level 2)")) * 100).ToString();
                    txtdea12day.Text = (Convert.ToDouble(lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 1 Year Renewal (Level 2)")) * 100).ToString();
                    txtdea12night.Text = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 1 Year Renewal (Level 2)");
                    txtdea12ew.Text = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 1 Year Renewal (Level 2)");

                    lbldea12program.Text = lib.DuelEnergy("Product", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 1 Year Renewal (Level 2)") + " For 1 Year";
                    // 12 Months all
                    txtdea12sc12all.Text = (Convert.ToDouble(lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 1 Year Renewal (Level 2)")) * 100).ToString();
                    txtdea12day12all.Text = (Convert.ToDouble(lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 1 Year Renewal (Level 2)")) * 100).ToString();
                    txtdea12night12all.Text = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 1 Year Renewal (Level 2)");
                    txtdea12ew12all.Text = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 1 Year Renewal (Level 2)");

                    lbldea12program12all.Text = lib.DuelEnergy("Product", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 1 Year Renewal (Level 2)") + " For 1 Year";


                    // 24 Months

                    txtdea24sc.Text = (Convert.ToDouble(lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 2 Year Renewal (Level 2)")) * 100).ToString();
                    txtdea24day.Text = (Convert.ToDouble(lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 2 Year Renewal (Level 2)")) * 100).ToString();
                    txtdea24night.Text = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 2 Year Renewal (Level 2)");
                    txtdea24ew.Text = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 2 Year Renewal (Level 2)");

                    lbldea24program.Text = lib.DuelEnergy("Product", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 2 Year Renewal (Level 2)") + " For 2 Year";

                    // 24 Months

                    txtdea24sc24all.Text = (Convert.ToDouble(lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 2 Year Renewal (Level 2)")) * 100).ToString();
                    txtdea24day24all.Text = (Convert.ToDouble(lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 2 Year Renewal (Level 2)")) * 100).ToString();
                    txtdea24night24all.Text = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 2 Year Renewal (Level 2)");
                    txtdea24ew24all.Text = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 2 Year Renewal (Level 2)");

                    lbldea24program24all.Text = lib.DuelEnergy("Product", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 2 Year Renewal (Level 2)") + " For 2 Year";

                    // 36 Months

                    txtdea36sc.Text = (Convert.ToDouble(lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 3 Year Renewal (Level 2)")) * 100).ToString();
                    txtdea36day.Text = (Convert.ToDouble(lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 3 Year Renewal (Level 2)")) * 100).ToString();
                    txtdea36night.Text = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 3 Year Renewal (Level 2)");
                    txtdea36ew.Text = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 3 Year Renewal (Level 2)");

                    lbldea36program.Text = lib.DuelEnergy("Product", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 3 Year (Level 2)") + mtype + " For 3 Year";

                    // 36 Months all

                    txtdea36scall.Text = (Convert.ToDouble(lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 3 Year Renewal (Level 2)")) * 100).ToString();
                    txtdea36dayall.Text = (Convert.ToDouble(lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 3 Year Renewal (Level 2)")) * 100).ToString();
                    txtdea36nightall.Text = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 3 Year Renewal (Level 2)");
                    txtdea36ewall.Text = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 3 Year Renewal (Level 2)");

                    lbldea36programall.Text = lib.DuelEnergy("Product", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 3 Year Renewal (Level 2)") + mtype  +" For 3 Year";





                    // 48 Months

                    txtdea48sc.Text = (Convert.ToDouble(lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 4 Year Renewal (Level 2)")) * 100).ToString();
                    txtdea48day.Text = (Convert.ToDouble(lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 4 Year Renewal (Level 2)")) * 100).ToString();
                    txtdea48night.Text = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 4 Year Renewal (Level 2)");
                    txtdea48ew.Text = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 4 Year Renewal (Level 2)");

                    lbldea48program.Text = lib.DuelEnergy("Product", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 4 Year Renewal (Level 2)") +  mtype + " For 4 Year";

                    // 48 Months all

                    txtdea48scall.Text = (Convert.ToDouble(lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 4 Year Renewal (Level 2)")) * 100).ToString();
                    txtdea48dayall.Text = (Convert.ToDouble(lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 4 Year Renewal (Level 2)")) * 100).ToString();
                    txtdea48nightall.Text = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 4 Year Renewal (Level 2)");
                    txtdea48ewall.Text = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 4 Year Renewal (Level 2)");

                    lbldea48programall.Text = lib.DuelEnergy("Product", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 4 Year Renewal (Level 2)") +  mtype + " For 4 Year";

                    // 60 Months

                    txtdea60sc.Text = (Convert.ToDouble(lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 5 Year Renewal (Level 2)")) * 100).ToString();
                    txtdea60day.Text = (Convert.ToDouble(lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 5 Year Renewal (Level 2)")) * 100).ToString();
                    txtdea60night.Text = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 5 Year Renewal (Level 2)");
                    txtdea60ew.Text = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 5 Year Renewal (Level 2)");

                    lbldea60program.Text = lib.DuelEnergy("Product", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 5 Year Renewal (Level 2)") + mtype + " For 5 Year";

                    // 60 Months
                    txtdea60scall.Text = (Convert.ToDouble(lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 5 Year Renewal (Level 2)")) * 100).ToString();
                    txtdea60dayall.Text = (Convert.ToDouble(lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 5 Year Renewal (Level 2)")) * 100).ToString();
                    txtdea60nightall.Text = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 5 Year Renewal (Level 2)");
                    txtdea60ewall.Text = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 5 Year Renewal (Level 2)");

                    lbldea60programall.Text = lib.DuelEnergy("Product", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 5 Year Renewal (Level 2)") + " For 5 Year";



                    /// Tooltip
                    /// 

                    txtdea12sc.ToolTip = lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 1 Year Renewal (Level 2)");
                    txtdea12day.ToolTip = lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 1 Year Renewal (Level 2)");
                    txtdea12night.ToolTip = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 1 Year Renewal (Level 2)");
                    txtdea12ew.ToolTip = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 1 Year Renewal (Level 2)");


                    // 12 Months all
                    txtdea12sc12all.ToolTip = lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 1 Year Renewal (Level 2)");
                    txtdea12day12all.ToolTip = lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 1 Year Renewal (Level 2)");
                    txtdea12night12all.ToolTip = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 1 Year Renewal (Level 2)");
                    txtdea12ew12all.ToolTip = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 1 Year Renewal (Level 2)");




                    // 24 Months

                    txtdea24sc.ToolTip = lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 2 Year Renewal (Level 2)");
                    txtdea24day.ToolTip = lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 2 Year Renewal (Level 2)");
                    txtdea24night.ToolTip = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 2 Year Renewal (Level 2)");
                    txtdea24ew.ToolTip = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 2 Year Renewal (Level 2)");


                    // 24 Months

                    txtdea24sc24all.ToolTip = lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 2 Year Renewal (Level 2)");
                    txtdea24day24all.ToolTip = lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 2 Year Renewal (Level 2)");
                    txtdea24night24all.ToolTip = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 2 Year Renewal (Level 2)");
                    txtdea24ew24all.ToolTip = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 2 Year Renewal (Level 2)");



                    // 36 Months

                    txtdea36sc.ToolTip = lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 3 Year Renewal (Level 2)");
                    txtdea36day.ToolTip = lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 3 Year Renewal (Level 2)");
                    txtdea36night.ToolTip = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 3 Year Renewal (Level 2)");
                    txtdea36ew.ToolTip = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 3 Year Renewal (Level 2)");



                    // 36 Months all

                    txtdea36scall.ToolTip = lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 3 Year Renewal (Level 2)");
                    txtdea36dayall.ToolTip = lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 3 Year Renewal (Level 2)");
                    txtdea36nightall.ToolTip = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 3 Year Renewal (Level 2)");
                    txtdea36ewall.ToolTip = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 3 Year Renewal (Level 2)");







                    // 48 Months

                    txtdea48sc.ToolTip = lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 4 Year Renewal (Level 2)");
                    txtdea48day.ToolTip = lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 4 Year Renewal (Level 2)");
                    txtdea48night.ToolTip = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 4 Year Renewal (Level 2)");
                    txtdea48ew.ToolTip = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 4 Year Renewal (Level 2)");


                    // 48 Months all

                    txtdea48scall.ToolTip = lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 4 Year Renewal (Level 2)");
                    txtdea48dayall.ToolTip = lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 4 Year Renewal (Level 2)");
                    txtdea48nightall.ToolTip = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 4 Year Renewal (Level 2)");
                    txtdea48ewall.ToolTip = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 4 Year Renewal (Level 2)");



                    // 60 Months

                    txtdea60sc.ToolTip = lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 4 Year Renewal (Level 2))");
                    txtdea60day.ToolTip = lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 4 Year Renewal (Level 2)");
                    txtdea60night.ToolTip = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 4 Year Renewal (Level 2)");
                    txtdea60ew.ToolTip = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 4 Year Renewal (Level 2)");



                    // 60 Months
                    txtdea60scall.ToolTip = lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 5 Year Renewal (Level 2)");
                    txtdea60dayall.ToolTip = lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 5 Year Renewal (Level 2)");
                    txtdea60nightall.ToolTip = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 4 Year Renewal (Level 2)");
                    txtdea60ewall.ToolTip = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 4 Year Renewal (Level 2)");


                    // For WC Rate

                    mtype = "HH 1RATE (WC)";

                    txtdeawc12sc.Text = (Convert.ToDouble(lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 1 Year Renewal (Level 2)")) * 100).ToString();
                    txtdeawc12day.Text = (Convert.ToDouble(lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 1 Year Renewal (Level 2)")) * 100).ToString();
                    txtdeawc12night.Text = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 1 Year Renewal (Level 2)");
                    txtdeawc12ew.Text = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 1 Year Renewal (Level 2)");

                    lbldeawc12program.Text = lib.DuelEnergy("Product", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 1 Year Renewal (Level 2)") + " For 1 Year";
                    // 12 Months all
                    txtdeawc12sc12all.Text = (Convert.ToDouble(lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 1 Year Renewal (Level 2)")) * 100).ToString();
                    txtdeawc12day12all.Text = (Convert.ToDouble(lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 1 Year Renewal (Level 2)")) * 100).ToString();
                    txtdeawc12night12all.Text = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 1 Year Renewal (Level 2)");
                    txtdeawc12ew12all.Text = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 1 Year Renewal (Level 2)");

                    lbldeawc12program12all.Text = lib.DuelEnergy("Product", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 1 Year Renewal (Level 2)") + " For 1 Year";


                    // 24 Months

                    txtdeawc24sc.Text = (Convert.ToDouble(lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 2 Year Renewal (Level 2)")) * 100).ToString();
                    txtdeawc24day.Text = (Convert.ToDouble(lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 2 Year Renewal (Level 2)")) * 100).ToString();
                    txtdeawc24night.Text = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 2 Year Renewal (Level 2)");
                    txtdeawc24ew.Text = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 2 Year Renewal (Level 2)");

                    lbldeawc24program.Text = lib.DuelEnergy("Product", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 2 Year Renewal (Level 2)") + " For 2 Year";

                    // 24 Months

                    txtdeawc24sc24all.Text = (Convert.ToDouble(lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 2 Year Renewal (Level 2)")) * 100).ToString();
                    txtdeawc24day24all.Text = (Convert.ToDouble(lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 2 Year Renewal (Level 2)")) * 100).ToString();
                    txtdeawc24night24all.Text = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 2 Year Renewal (Level 2)");
                    txtdeawc24ew24all.Text = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 2 Year Renewal (Level 2)");

                    lbldeawc24program24all.Text = lib.DuelEnergy("Product", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 2 Year Renewal (Level 2)") + " For 2 Year";

                    // 36 Months

                    txtdeawc36sc.Text = (Convert.ToDouble(lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 3 Year Renewal (Level 2)")) * 100).ToString();
                    txtdeawc36day.Text = (Convert.ToDouble(lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 3 Year Renewal (Level 2)")) * 100).ToString();
                    txtdeawc36night.Text = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 3 Year Renewal (Level 2)");
                    txtdeawc36ew.Text = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 3 Year Renewal (Level 2)");

                    lbldeawc36program.Text = lib.DuelEnergy("Product", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 3 Year Renewal (Level 2)") + " For 3 Year";

                    // 36 Months all

                    txtdeawc36sc36all.Text = (Convert.ToDouble(lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 3 Year Renewal (Level 2)")) * 100).ToString();
                    txtdeawc36day36all.Text = (Convert.ToDouble(lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 3 Year Renewal (Level 2)")) * 100).ToString();
                    txtdeawc36night36all.Text = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 3 Year Renewal (Level 2)");
                    txtdeawc36ew36all.Text = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 3 Year Renewal (Level 2)");

                    lbldeawc36program36all.Text = lib.DuelEnergy("Product", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 3 Year Renewal (Level 2)") + " For 3 Year";





                    // 48 Months

                    txtdeawc48sc.Text = (Convert.ToDouble(lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 4 Year Renewal (Level 2)")) * 100).ToString();
                    txtdeawc48day.Text = (Convert.ToDouble(lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 4 Year Renewal (Level 2)")) * 100).ToString();
                    txtdeawc48night.Text = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 4 Year Renewal (Level 2)");
                    txtdeawc48ew.Text = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 4 Year Renewal (Level 2))");

                    lbldeawc48program.Text = lib.DuelEnergy("Product", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 4 Year Renewal (Level 2)") + " For 4 Year";

                    // 48 Months all

                    txtdeawc48sc48all.Text = (Convert.ToDouble(lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 4 Year Renewal (Level 2)")) * 100).ToString();
                    txtdeawc48day48all.Text = (Convert.ToDouble(lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 4 Year Renewal (Level 2)")) * 100).ToString();
                    txtdeawc48night48all.Text = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 4 Year Renewal (Level 2)");
                    txtdeawc48ew48all.Text = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 4 Year Renewal (Level 2)");

                    lbldea48programall.Text = lib.DuelEnergy("Product", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 4 Year Renewal (Level 2)") + " For 4 Year";

                    // 60 Months

                    txtdeawc60sc.Text = (Convert.ToDouble(lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 5 Year Renewal (Level 2)")) * 100).ToString();
                    txtdeawc60day.Text = (Convert.ToDouble(lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 5 Year Renewal (Level 2)")) * 100).ToString();
                    txtdeawc60night.Text = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 5 Year Renewal (Level 2)");
                    txtdeawc60ew.Text = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 5 Year Renewal (Level 2)");

                    lbldeawc60program.Text = lib.DuelEnergy("Product", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 5 Year Renewal (Level 2)") + " For 5 Year";

                    // 60 Months
                    txtdeawc60sc60all.Text = (Convert.ToDouble(lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 5 Year Renewal (Level 2)")) * 100).ToString();
                    txtdeawc60day60all.Text = (Convert.ToDouble(lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 5 Year Renewal (Level 2)")) * 100).ToString();
                    txtdeawc60night60all.Text = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 5 Year Renewal (Level 2)");
                    txtdeawc60ew60all.Text = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 5 Year Renewal (Level 2)");

                    lbldea60programall.Text = lib.DuelEnergy("Product", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 5 Year Renewal (Level 2)") + " For 5 Year";



                    /// Tooltip
                    /// 

                    txtdeawc12sc.ToolTip = lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 1 Year Renewal (Level 2)");
                    txtdeawc12day.ToolTip = lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 1 Year Renewal (Level 2)");
                    txtdeawc12night.ToolTip = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 1 Year Renewal (Level 2)");
                    txtdeawc12ew.ToolTip = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 5 Year Renewal (Level 2)");


                    // 12 Months all
                    txtdeawc12sc12all.ToolTip = lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 5 Year Renewal (Level 2)");
                    txtdeawc12day12all.ToolTip = lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 5 Year Renewal (Level 2)");
                    txtdeawc12night12all.ToolTip = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 5 Year Renewal (Level 2)");
                    txtdeawc12ew12all.ToolTip = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 5 Year Renewal (Level 2)");




                    // 24 Months

                    txtdeawc24sc.ToolTip = lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 2 Year Renewal (Level 2)");
                    txtdeawc24day.ToolTip = lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 2 Year Renewal (Level 2)");
                    txtdeawc24night.ToolTip = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 2 Year Renewal (Level 2)");
                    txtdeawc24ew.ToolTip = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 2 Year Renewal (Level 2)");


                    // 24 Months

                    txtdeawc24sc24all.ToolTip = lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 2 Year Renewal (Level 2)");
                    txtdeawc24day24all.ToolTip = lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 2 Year Renewal (Level 2)");
                    txtdeawc24night24all.ToolTip = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 2 Year Renewal (Level 2)");
                    txtdeawc24ew24all.ToolTip = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 2 Year Renewal (Level 2)");



                    // 36 Months

                    txtdeawc36sc.ToolTip = lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 3 Year Renewal (Level 2)");
                    txtdeawc36day.ToolTip = lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 3 Year Renewal (Level 2)");
                    txtdeawc36night.ToolTip = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 3 Year Renewal (Level 2)");
                    txtdeawc36ew.ToolTip = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 3 Year Renewal (Level 2)");



                    // 36 Months all

                    txtdeawc36sc36all.ToolTip = lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 3 Year Renewal (Level 2)");
                    txtdeawc36day36all.ToolTip = lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 3 Year Renewal (Level 2)");
                    txtdeawc36night36all.ToolTip = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 3 Year Renewal (Level 2)");
                    txtdeawc36ew36all.ToolTip = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 3 Year Renewal (Level 2)");







                    // 48 Months

                    txtdeawc48sc.ToolTip = lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 4 Year Renewal (Level 2)");
                    txtdeawc48day.ToolTip = lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 4 Year Renewal (Level 2)");
                    txtdeawc48night.ToolTip = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 4 Year Renewal (Level 2)");
                    txtdeawc48ew.ToolTip = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 4 Year Renewal (Level 2)");


                    // 48 Months all

                    txtdeawc48sc48all.ToolTip = lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 4 Year Renewal (Level 2)");
                    txtdeawc48day48all.ToolTip = lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 4 Year Renewal (Level 2)");
                    txtdeawc48night48all.ToolTip = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 4 Year Renewal (Level 2)");
                    txtdeawc48ew48all.ToolTip = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 4 Year Renewal (Level 2)");



                    // 60 Months

                    txtdeawc60sc.ToolTip = lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 5 Year Renewal (Level 2)");
                    txtdeawc60day.ToolTip = lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 5 Year Renewal (Level 2)");
                    txtdeawc60night.ToolTip = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 5 Year Renewal (Level 2)");
                    txtdeawc60ew.ToolTip = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 5 Year Renewal (Level 2)");



                    // 60 Months
                    txtdeawc60sc60all.ToolTip = lib.DuelEnergy("StandingCharge", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 5 Year Renewal (Level 2)");
                    txtdeawc60day60all.ToolTip = lib.DuelEnergy("DayAllSTODOtherDayUnits", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 5 Year Renewal (Level 2)");
                    txtdeawc60night60all.ToolTip = lib.DuelEnergy("NightUnitPrice", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 5 Year Renewal (Level 2)");
                    txtdeawc60ew60all.ToolTip = lib.DuelEnergy("EveWkendControlSTODWinterPeak", lblProfile.Text, lblRegion.Text, mtype, "SmartFIX – 5 Year Renewal (Level 2)");



                }




            }



        }

        #endregion

        #region Pozitive Energy calculation

        void Bindpe()
        {
            // 12 Months

            txtpe12sc.Text = lib.PositiveEbergy("Fixedcharge12", lblProfile.Text, lblRegion.Text, lblPEMetertype.Text);
            txtpe12day.Text = lib.PositiveEbergy("Day12", lblProfile.Text, lblRegion.Text, lblPEMetertype.Text);
            txtpe12night.Text = lib.PositiveEbergy("Night12", lblProfile.Text, lblRegion.Text, lblPEMetertype.Text);
            txtpe12ew.Text = lib.PositiveEbergy("EveWK12", lblProfile.Text, lblRegion.Text, lblPEMetertype.Text);
            txtpe12other.Text = lib.PositiveEbergy("RHT12", lblProfile.Text, lblRegion.Text, lblPEMetertype.Text);

            lblpe12program.Text = lib.PositiveEbergy("Tariffname", lblProfile.Text, lblRegion.Text, lblPEMetertype.Text) + " For 1 Year";

            // 12 Months all

            txtpe12scall.Text = lib.PositiveEbergy("Fixedcharge12", lblProfile.Text, lblRegion.Text, lblPEMetertype.Text);
            txtpe12dayall.Text = lib.PositiveEbergy("Day12", lblProfile.Text, lblRegion.Text, lblPEMetertype.Text);
            txtpe12nightall.Text = lib.PositiveEbergy("Night12", lblProfile.Text, lblRegion.Text, lblPEMetertype.Text);
            txtpe12ewall.Text = lib.PositiveEbergy("EveWK12", lblProfile.Text, lblRegion.Text, lblPEMetertype.Text);
            txtpe12otherall.Text = lib.PositiveEbergy("RHT12", lblProfile.Text, lblRegion.Text, lblPEMetertype.Text);

            lblpe12programall.Text = lib.PositiveEbergy("Tariffname", lblProfile.Text, lblRegion.Text, lblPEMetertype.Text) + " For 1 Year";

            // 24 Months

            txtpe24sc.Text = lib.PositiveEbergy("Fixedcharge24", lblProfile.Text, lblRegion.Text, lblPEMetertype.Text);
            txtpe24day.Text = lib.PositiveEbergy("Day24", lblProfile.Text, lblRegion.Text, lblPEMetertype.Text);
            txtpe24night.Text = lib.PositiveEbergy("Night24", lblProfile.Text, lblRegion.Text, lblPEMetertype.Text);
            txtpe24ew.Text = lib.PositiveEbergy("EveWK24", lblProfile.Text, lblRegion.Text, lblPEMetertype.Text);
            txtpe24other.Text = lib.PositiveEbergy("RHT24", lblProfile.Text, lblRegion.Text, lblPEMetertype.Text);

            lblpe24program.Text = lib.PositiveEbergy("Tariffname", lblProfile.Text, lblRegion.Text, lblPEMetertype.Text) + " For 2 Year";

            // 24 Months all

            txtpe24scall.Text = lib.PositiveEbergy("Fixedcharge24", lblProfile.Text, lblRegion.Text, lblPEMetertype.Text);
            txtpe24dayall.Text = lib.PositiveEbergy("Day24", lblProfile.Text, lblRegion.Text, lblPEMetertype.Text);
            txtpe24nightall.Text = lib.PositiveEbergy("Night24", lblProfile.Text, lblRegion.Text, lblPEMetertype.Text);
            txtpe24ewall.Text = lib.PositiveEbergy("EveWK24", lblProfile.Text, lblRegion.Text, lblPEMetertype.Text);
            txtpe24otherall.Text = lib.PositiveEbergy("RHT24", lblProfile.Text, lblRegion.Text, lblPEMetertype.Text);

            lblpe24programall.Text = lib.PositiveEbergy("Tariffname", lblProfile.Text, lblRegion.Text, lblPEMetertype.Text) + " For 2 Year";

            // 36 Months

            txtpe36sc.Text = lib.PositiveEbergy("Fixedcharge36", lblProfile.Text, lblRegion.Text, lblPEMetertype.Text);
            txtpe36day.Text = lib.PositiveEbergy("Day36", lblProfile.Text, lblRegion.Text, lblPEMetertype.Text);
            txtpe36night.Text = lib.PositiveEbergy("Night36", lblProfile.Text, lblRegion.Text, lblPEMetertype.Text);
            txtpe36ew.Text = lib.PositiveEbergy("EveWK36", lblProfile.Text, lblRegion.Text, lblPEMetertype.Text);
            txtpe36other.Text = lib.PositiveEbergy("RHT36", lblProfile.Text, lblRegion.Text, lblPEMetertype.Text);

            lblpe36program.Text = lib.PositiveEbergy("Tariffname", lblProfile.Text, lblRegion.Text, lblPEMetertype.Text) + " For 3 Year";

            // 36 Months all

            txtpe36scall.Text = lib.PositiveEbergy("Fixedcharge36", lblProfile.Text, lblRegion.Text, lblPEMetertype.Text);
            txtpe36dayall.Text = lib.PositiveEbergy("Day36", lblProfile.Text, lblRegion.Text, lblPEMetertype.Text);
            txtpe36nightall.Text = lib.PositiveEbergy("Night36", lblProfile.Text, lblRegion.Text, lblPEMetertype.Text);
            txtpe36ewall.Text = lib.PositiveEbergy("EveWK36", lblProfile.Text, lblRegion.Text, lblPEMetertype.Text);
            txtpe36otherall.Text = lib.PositiveEbergy("RHT36", lblProfile.Text, lblRegion.Text, lblPEMetertype.Text);

            lblpe36programall.Text = lib.PositiveEbergy("Tariffname", lblProfile.Text, lblRegion.Text, lblPEMetertype.Text) + " For 3 Year";


            // Tooltips

            // 12 Months

            txtpe12sc.ToolTip = lib.PositiveEbergy("Fixedcharge12", lblProfile.Text, lblRegion.Text, lblPEMetertype.Text);
            txtpe12day.ToolTip = lib.PositiveEbergy("Day12", lblProfile.Text, lblRegion.Text, lblPEMetertype.Text);
            txtpe12night.ToolTip = lib.PositiveEbergy("Night12", lblProfile.Text, lblRegion.Text, lblPEMetertype.Text);
            txtpe12ew.ToolTip = lib.PositiveEbergy("EveWK12", lblProfile.Text, lblRegion.Text, lblPEMetertype.Text);
            txtpe12other.ToolTip = lib.PositiveEbergy("RHT12", lblProfile.Text, lblRegion.Text, lblPEMetertype.Text);

            lblpe12program.ToolTip = lib.PositiveEbergy("Tariffname", lblProfile.Text, lblRegion.Text, lblPEMetertype.Text) + " For 1 Year";

            // 12 Months all

            txtpe12scall.ToolTip = lib.PositiveEbergy("Fixedcharge12", lblProfile.Text, lblRegion.Text, lblPEMetertype.Text);
            txtpe12dayall.ToolTip = lib.PositiveEbergy("Day12", lblProfile.Text, lblRegion.Text, lblPEMetertype.Text);
            txtpe12nightall.ToolTip = lib.PositiveEbergy("Night12", lblProfile.Text, lblRegion.Text, lblPEMetertype.Text);
            txtpe12ewall.ToolTip = lib.PositiveEbergy("EveWK12", lblProfile.Text, lblRegion.Text, lblPEMetertype.Text);
            txtpe12otherall.ToolTip = lib.PositiveEbergy("RHT12", lblProfile.Text, lblRegion.Text, lblPEMetertype.Text);

            lblpe12programall.ToolTip = lib.PositiveEbergy("Tariffname", lblProfile.Text, lblRegion.Text, lblPEMetertype.Text) + " For 1 Year";

            // 24 Months

            txtpe24sc.ToolTip = lib.PositiveEbergy("Fixedcharge24", lblProfile.Text, lblRegion.Text, lblPEMetertype.Text);
            txtpe24day.ToolTip = lib.PositiveEbergy("Day24", lblProfile.Text, lblRegion.Text, lblPEMetertype.Text);
            txtpe24night.ToolTip = lib.PositiveEbergy("Night24", lblProfile.Text, lblRegion.Text, lblPEMetertype.Text);
            txtpe24ew.ToolTip = lib.PositiveEbergy("EveWK24", lblProfile.Text, lblRegion.Text, lblPEMetertype.Text);
            txtpe24other.ToolTip = lib.PositiveEbergy("RHT24", lblProfile.Text, lblRegion.Text, lblPEMetertype.Text);

            lblpe24program.ToolTip = lib.PositiveEbergy("Tariffname", lblProfile.Text, lblRegion.Text, lblPEMetertype.Text) + " For 2 Year";

            // 24 Months all

            txtpe24scall.ToolTip = lib.PositiveEbergy("Fixedcharge24", lblProfile.Text, lblRegion.Text, lblPEMetertype.Text);
            txtpe24dayall.ToolTip = lib.PositiveEbergy("Day24", lblProfile.Text, lblRegion.Text, lblPEMetertype.Text);
            txtpe24nightall.ToolTip = lib.PositiveEbergy("Night24", lblProfile.Text, lblRegion.Text, lblPEMetertype.Text);
            txtpe24ewall.ToolTip = lib.PositiveEbergy("EveWK24", lblProfile.Text, lblRegion.Text, lblPEMetertype.Text);
            txtpe24otherall.ToolTip = lib.PositiveEbergy("RHT24", lblProfile.Text, lblRegion.Text, lblPEMetertype.Text);

            lblpe24programall.ToolTip = lib.PositiveEbergy("Tariffname", lblProfile.Text, lblRegion.Text, lblPEMetertype.Text) + " For 2 Year";

            // 36 Months

            txtpe36sc.ToolTip = lib.PositiveEbergy("Fixedcharge36", lblProfile.Text, lblRegion.Text, lblPEMetertype.Text);
            txtpe36day.ToolTip = lib.PositiveEbergy("Day36", lblProfile.Text, lblRegion.Text, lblPEMetertype.Text);
            txtpe36night.ToolTip = lib.PositiveEbergy("Night36", lblProfile.Text, lblRegion.Text, lblPEMetertype.Text);
            txtpe36ew.ToolTip = lib.PositiveEbergy("EveWK36", lblProfile.Text, lblRegion.Text, lblPEMetertype.Text);
            txtpe36other.ToolTip = lib.PositiveEbergy("RHT36", lblProfile.Text, lblRegion.Text, lblPEMetertype.Text);

            lblpe36program.ToolTip = lib.PositiveEbergy("Tariffname", lblProfile.Text, lblRegion.Text, lblPEMetertype.Text) + " For 3 Year";

            // 36 Months all

            txtpe36scall.ToolTip = lib.PositiveEbergy("Fixedcharge36", lblProfile.Text, lblRegion.Text, lblPEMetertype.Text);
            txtpe36dayall.ToolTip = lib.PositiveEbergy("Day36", lblProfile.Text, lblRegion.Text, lblPEMetertype.Text);
            txtpe36nightall.ToolTip = lib.PositiveEbergy("Night36", lblProfile.Text, lblRegion.Text, lblPEMetertype.Text);
            txtpe36ewall.ToolTip = lib.PositiveEbergy("EveWK36", lblProfile.Text, lblRegion.Text, lblPEMetertype.Text);
            txtpe36otherall.ToolTip = lib.PositiveEbergy("RHT36", lblProfile.Text, lblRegion.Text, lblPEMetertype.Text);

            lblpe36programall.ToolTip = lib.PositiveEbergy("Tariffname", lblProfile.Text, lblRegion.Text, lblPEMetertype.Text) + " For 3 Year";


        }

        #endregion

        #region GazPron calculation
        void gazpron()
        {
            // 12 Months

           string  dayrate = "0";
           string weekday = "0";
           string unitrate = "0";
            string startdate = lblStartdate.Text;

            txtgaz12sc.Text = lib.GazPron("StandingCharge", lblProfile.Text, lblRegion.Text, lblGZMetertype.Text, "1 Year");
            dayrate = lib.GazPron("Day", lblProfile.Text, lblRegion.Text, lblGZMetertype.Text, "1 Year");
            txtgaz12night.Text = lib.GazPron("Night", lblProfile.Text, lblRegion.Text, lblGZMetertype.Text, "1 Year");
            txtgaz12ew.Text = lib.GazPron("EveningWeekend", lblProfile.Text, lblRegion.Text, lblGZMetertype.Text, "1 Year");
            unitrate = lib.GazPron("UnitRate", lblProfile.Text, lblRegion.Text, lblGZMetertype.Text, "1 Year");
            txtgaz12day.Text = lib.DayRate(dayrate, weekday, unitrate);

            lblgaz12program.Text = lib.GazPron("Meter", lblProfile.Text, lblRegion.Text, lblGZMetertype.Text, "1 Year") + "for 1 years";

            // 12 Months all

            txtgaz12scall.Text = lib.GazPron("StandingCharge", lblProfile.Text, lblRegion.Text, lblGZMetertype.Text, "1 Year");
           dayrate = lib.GazPron("Day", lblProfile.Text, lblRegion.Text, lblGZMetertype.Text, "1 Year");
            txtgaz12nightall.Text = lib.GazPron("Night", lblProfile.Text, lblRegion.Text, lblGZMetertype.Text, "1 Year");
            txtgaz12ewall.Text = lib.GazPron("EveningWeekend", lblProfile.Text, lblRegion.Text, lblGZMetertype.Text, "1 Year");
           unitrate = lib.GazPron("UnitRate", lblProfile.Text, lblRegion.Text, lblGZMetertype.Text, "1 Year");
            txtgaz12dayall.Text = lib.DayRate(dayrate, weekday, unitrate);

            lblgaz12programall.Text = lib.GazPron("Meter", lblProfile.Text, lblRegion.Text, lblGZMetertype.Text, "1 Year") + "for 1 years";

            // 24 Months

            txtgaz24sc.Text = lib.GazPron("StandingCharge", lblProfile.Text, lblRegion.Text, lblGZMetertype.Text, "2 Year");
           dayrate = lib.GazPron("Day", lblProfile.Text, lblRegion.Text, lblGZMetertype.Text, "2 Year");
            txtgaz24night.Text = lib.GazPron("Night", lblProfile.Text, lblRegion.Text, lblGZMetertype.Text, "2 Year");
            txtgaz24ew.Text = lib.GazPron("EveningWeekend", lblProfile.Text, lblRegion.Text, lblGZMetertype.Text, "2 Year");
            unitrate = lib.GazPron("UnitRate", lblProfile.Text, lblRegion.Text, lblGZMetertype.Text, "2 Year");
            txtgaz24day.Text = lib.DayRate(dayrate, weekday, unitrate);

            lblgaz24program.Text = lib.GazPron("Meter", lblProfile.Text, lblRegion.Text, lblGZMetertype.Text, "2 Year") + "for 2 years";

            // 24 Months all

            txtgaz24scall.Text = lib.GazPron("StandingCharge", lblProfile.Text, lblRegion.Text, lblGZMetertype.Text, "2 Year");
            dayrate = lib.GazPron("Day", lblProfile.Text, lblRegion.Text, lblGZMetertype.Text, "2 Year");
            txtgaz24nightall.Text = lib.GazPron("Night", lblProfile.Text, lblRegion.Text, lblGZMetertype.Text, "2 Year");
            txtgaz24ewall.Text = lib.GazPron("EveningWeekend", lblProfile.Text, lblRegion.Text, lblGZMetertype.Text, "2 Year");
            unitrate = lib.GazPron("UnitRate", lblProfile.Text, lblRegion.Text, lblGZMetertype.Text, "2 Year");

            txtgaz24dayall.Text = lib.DayRate(dayrate, weekday, unitrate);

            lblgaz24programall.Text = lib.GazPron("Meter", lblProfile.Text, lblRegion.Text, lblGZMetertype.Text, "2 Year") + "for 2 years";


            // 36 Months

            txtgaz36sc.Text = lib.GazPron("StandingCharge", lblProfile.Text, lblRegion.Text, lblGZMetertype.Text, "3 Year");
           dayrate = lib.GazPron("Day", lblProfile.Text, lblRegion.Text, lblGZMetertype.Text, "3 Year");
            txtgaz36night.Text = lib.GazPron("Night", lblProfile.Text, lblRegion.Text, lblGZMetertype.Text, "3 Year");
            txtgaz36ew.Text = lib.GazPron("EveningWeekend", lblProfile.Text, lblRegion.Text, lblGZMetertype.Text, "3 Year");
           unitrate = lib.GazPron("UnitRate", lblProfile.Text, lblRegion.Text, lblGZMetertype.Text, "3 Year");

            txtgaz36day.Text = lib.DayRate(dayrate, weekday, unitrate);
            lblgaz36program.Text = lib.GazPron("Meter", lblProfile.Text, lblRegion.Text, lblGZMetertype.Text, "3 Year") + "for 3 years";

            // 36 Months all

            txtgaz36scall.Text = lib.GazPron("StandingCharge", lblProfile.Text, lblRegion.Text, lblGZMetertype.Text, "3 Year");
            dayrate = lib.GazPron("Day", lblProfile.Text, lblRegion.Text, lblGZMetertype.Text, "3 Year");
            txtgaz36nightall.Text = lib.GazPron("Night", lblProfile.Text, lblRegion.Text, lblGZMetertype.Text, "3 Year");
            txtgaz36ewall.Text = lib.GazPron("EveningWeekend", lblProfile.Text, lblRegion.Text, lblGZMetertype.Text, "3 Year");
           unitrate= lib.GazPron("UnitRate", lblProfile.Text, lblRegion.Text, lblGZMetertype.Text, "3 Year");
            txtgaz36dayall.Text = lib.DayRate(dayrate, weekday, unitrate);


            lblgaz36programall.Text = lib.GazPron("Meter", lblProfile.Text, lblRegion.Text, lblGZMetertype.Text, "3 Year") + "for 3 years";

            // tooltp


            txtgaz12sc.ToolTip = lib.GazPron("StandingCharge", lblProfile.Text, lblRegion.Text, lblGZMetertype.Text, "1 Year");
           dayrate = lib.GazPron("Day", lblProfile.Text, lblRegion.Text, lblGZMetertype.Text, "1 Year");
            txtgaz12night.ToolTip = lib.GazPron("Night", lblProfile.Text, lblRegion.Text, lblGZMetertype.Text, "1 Year");
            txtgaz12ew.ToolTip = lib.GazPron("EveningWeekend", lblProfile.Text, lblRegion.Text, lblGZMetertype.Text, "1 Year");
          unitrate= lib.GazPron("UnitRate", lblProfile.Text, lblRegion.Text, lblGZMetertype.Text, "1 Year");
            txtgaz12day.ToolTip = lib.DayRate(dayrate, weekday, unitrate);

            lblgaz12program.ToolTip = lib.GazPron("Meter", lblProfile.Text, lblRegion.Text, lblGZMetertype.Text, "1 Year") + "for 1 years";

            // 12 Months all

            txtgaz12scall.ToolTip = lib.GazPron("StandingCharge", lblProfile.Text, lblRegion.Text, lblGZMetertype.Text, "1 Year");
            dayrate = lib.GazPron("Day", lblProfile.Text, lblRegion.Text, lblGZMetertype.Text, "1 Year");
            txtgaz12nightall.ToolTip = lib.GazPron("Night", lblProfile.Text, lblRegion.Text, lblGZMetertype.Text, "1 Year");
            txtgaz12ewall.ToolTip = lib.GazPron("EveningWeekend", lblProfile.Text, lblRegion.Text, lblGZMetertype.Text, "1 Year");
            unitrate = lib.GazPron("UnitRate", lblProfile.Text, lblRegion.Text, lblGZMetertype.Text, "1 Year");
            txtgaz12dayall.ToolTip = lib.DayRate(dayrate, weekday, unitrate);

            lblgaz12programall.ToolTip = lib.GazPron("Meter", lblProfile.Text, lblRegion.Text, lblGZMetertype.Text, "1 Year") + "for 1 years";

            // 24 Months

            txtgaz24sc.ToolTip = lib.GazPron("StandingCharge", lblProfile.Text, lblRegion.Text, lblGZMetertype.Text, "2 Year");
            dayrate= lib.GazPron("Day", lblProfile.Text, lblRegion.Text, lblGZMetertype.Text, "2 Year");
            txtgaz24night.ToolTip = lib.GazPron("Night", lblProfile.Text, lblRegion.Text, lblGZMetertype.Text, "2 Year");
            txtgaz24ew.ToolTip = lib.GazPron("EveningWeekend", lblProfile.Text, lblRegion.Text, lblGZMetertype.Text, "2 Year");
            unitrate = lib.GazPron("UnitRate", lblProfile.Text, lblRegion.Text, lblGZMetertype.Text, "2 Year");
            txtgaz24day.ToolTip = lib.DayRate(dayrate, weekday, unitrate);

            lblgaz24program.ToolTip = lib.GazPron("Meter", lblProfile.Text, lblRegion.Text, lblGZMetertype.Text, "2 Year") + "for 2 years";

            // 24 Months all

            txtgaz24scall.ToolTip = lib.GazPron("StandingCharge", lblProfile.Text, lblRegion.Text, lblGZMetertype.Text, "2 Year");
            dayrate = lib.GazPron("Day", lblProfile.Text, lblRegion.Text, lblGZMetertype.Text, "2 Year");
            txtgaz24nightall.ToolTip = lib.GazPron("Night", lblProfile.Text, lblRegion.Text, lblGZMetertype.Text, "2 Year");
            txtgaz24ewall.ToolTip = lib.GazPron("EveningWeekend", lblProfile.Text, lblRegion.Text, lblGZMetertype.Text, "2 Year");
            unitrate = lib.GazPron("UnitRate", lblProfile.Text, lblRegion.Text, lblGZMetertype.Text, "2 Year");
            txtgaz24dayall.ToolTip = lib.DayRate(dayrate, weekday, unitrate);

            lblgaz24programall.ToolTip = lib.GazPron("Meter", lblProfile.Text, lblRegion.Text, lblGZMetertype.Text, "2 Year") + "for 2 years";


            // 36 Months

            txtgaz36sc.ToolTip = lib.GazPron("StandingCharge", lblProfile.Text, lblRegion.Text, lblGZMetertype.Text, "3 Year");
            dayrate = lib.GazPron("Day", lblProfile.Text, lblRegion.Text, lblGZMetertype.Text, "3 Year");
            txtgaz36night.ToolTip = lib.GazPron("Night", lblProfile.Text, lblRegion.Text, lblGZMetertype.Text, "3 Year");
            txtgaz36ew.ToolTip = lib.GazPron("EveningWeekend", lblProfile.Text, lblRegion.Text, lblGZMetertype.Text, "3 Year");
            unitrate = lib.GazPron("UnitRate", lblProfile.Text, lblRegion.Text, lblGZMetertype.Text, "3 Year");
            txtgaz36day.ToolTip = lib.DayRate(dayrate, weekday, unitrate);

            lblgaz36program.ToolTip = lib.GazPron("Meter", lblProfile.Text, lblRegion.Text, lblGZMetertype.Text, "3 Year") + "for 3 years";

            // 36 Months all

            txtgaz36scall.ToolTip = lib.GazPron("StandingCharge", lblProfile.Text, lblRegion.Text, lblGZMetertype.Text, "3 Year");
           dayrate = lib.GazPron("Day", lblProfile.Text, lblRegion.Text, lblGZMetertype.Text, "3 Year");
            txtgaz36nightall.ToolTip = lib.GazPron("Night", lblProfile.Text, lblRegion.Text, lblGZMetertype.Text, "3 Year");
            txtgaz36ewall.ToolTip = lib.GazPron("EveningWeekend", lblProfile.Text, lblRegion.Text, lblGZMetertype.Text, "3 Year");
            unitrate= lib.GazPron("UnitRate", lblProfile.Text, lblRegion.Text, lblGZMetertype.Text, "3 Year");
            txtgaz36dayall.ToolTip = lib.DayRate(dayrate, weekday, unitrate);


            lblgaz36programall.ToolTip = lib.GazPron("Meter", lblProfile.Text, lblRegion.Text, lblGZMetertype.Text, "3 Year") + "for 3 years";




        }

        #endregion

        #region Heven Power Calculation

        void Hevs()
        {

            
            string mymonth = DateTime.Today.Month.ToString();
            string myyear = DateTime.Today.Year.ToString();
            string startdate = lblStartdate.Text;
            DateTime dt = new DateTime();
            dt = Convert.ToDateTime(lblStartdate.Text);
            mymonth = dt.Month.ToString();
            myyear = dt.Year.ToString();

            // 1 year
            txthev12sc.Text = lib.HevS("StandingCharge", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "12", lblStartdate.Text, mymonth, myyear, "Standard", lblEac.Text);
            txthev12day.Text = lib.HevS("DayRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "12", lblStartdate.Text, mymonth, myyear, "Standard", lblEac.Text);
            txthev12night.Text = lib.HevS("NightRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "12", lblStartdate.Text, mymonth, myyear, "Standard", lblEac.Text);
            txthev12ew.Text = lib.HevS("EveWeekendRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "12", lblStartdate.Text, mymonth, myyear, "Standard", lblEac.Text);
            txthev12offpeak.Text = lib.HevS("SingleRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "12", lblStartdate.Text, mymonth, myyear, "Standard", lblEac.Text);
           

            lblhev12program.Text = "Heven Energy 1 Year " + lib.HevS("Product", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "12", lblStartdate.Text, mymonth, myyear, "Standard", lblEac.Text);


            txthev12sc.ToolTip = lib.HevS("StandingCharge", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "12", lblStartdate.Text, mymonth, myyear, "Standard", lblEac.Text);
            txthev12day.ToolTip = lib.HevS("DayRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "12", lblStartdate.Text, mymonth, myyear, "Standard", lblEac.Text);
            txthev12night.ToolTip = lib.HevS("NightRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "12", lblStartdate.Text, mymonth, myyear, "Standard", lblEac.Text);
            txthev12ew.ToolTip = lib.HevS("EveWeekendRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "12", lblStartdate.Text, mymonth, myyear, "Standard", lblEac.Text);
            txthev12offpeak.ToolTip = lib.HevS("SingleRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "12", lblStartdate.Text, mymonth, myyear, "Standard", lblEac.Text);


            lblhev12program.ToolTip = "Heven Energy 1 Year " + lib.HevS("Product", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "12", lblStartdate.Text, mymonth, myyear, "Standard", lblEac.Text);

            //2 year

            
            txthev24sc.Text = lib.HevS("StandingCharge", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "24", lblStartdate.Text, mymonth, myyear, "Standard", lblEac.Text);
            txthev24day.Text = lib.HevS("DayRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "24", lblStartdate.Text, mymonth, myyear, "Standard", lblEac.Text);
            txthev24night.Text = lib.HevS("NightRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "24", lblStartdate.Text, mymonth, myyear, "Standard", lblEac.Text);
            txthev24ew.Text = lib.HevS("EveWeekendRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "24", lblStartdate.Text, mymonth, myyear, "Standard", lblEac.Text);
            txthev24offpeak.Text = lib.HevS("SingleRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "24", lblStartdate.Text, mymonth, myyear, "Standard", lblEac.Text);


            lblhev24program.Text = "Heven Energy 1 Year " + lib.HevS("Product", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "24", lblStartdate.Text, mymonth, myyear, "Standard", lblEac.Text);


            txthev24sc.ToolTip = lib.HevS("StandingCharge", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "24", lblStartdate.Text, mymonth, myyear, "Standard", lblEac.Text);
            txthev24day.ToolTip = lib.HevS("DayRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "24", lblStartdate.Text, mymonth, myyear, "Standard", lblEac.Text);
            txthev24night.ToolTip = lib.HevS("NightRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "24", lblStartdate.Text, mymonth, myyear, "Standard", lblEac.Text);
            txthev24ew.ToolTip = lib.HevS("EveWeekendRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "24", lblStartdate.Text, mymonth, myyear, "Standard", lblEac.Text);
            txthev24offpeak.ToolTip = lib.HevS("SingleRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "24", lblStartdate.Text, mymonth, myyear, "Standard", lblEac.Text);


            lblhev24program.ToolTip = "Heven Energy 1 Year " + lib.HevS("Product", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "24", lblStartdate.Text, mymonth, myyear, "Standard", lblEac.Text);


            //3 year


            txthev36sc.Text = lib.HevS("StandingCharge", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "36", lblStartdate.Text, mymonth, myyear, "Standard", lblEac.Text);
            txthev36day.Text = lib.HevS("DayRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "36", lblStartdate.Text, mymonth, myyear, "Standard", lblEac.Text);
            txthev36night.Text = lib.HevS("NightRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "36", lblStartdate.Text, mymonth, myyear, "Standard", lblEac.Text);
            txthev36ew.Text = lib.HevS("EveWeekendRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "36", lblStartdate.Text, mymonth, myyear, "Standard", lblEac.Text);
            txthev36offpeak.Text = lib.HevS("SingleRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "36", lblStartdate.Text, mymonth, myyear, "Standard", lblEac.Text);


            lblhev36program.Text = "Heven Energy 1 Year " + lib.HevS("Product", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "36", lblStartdate.Text, mymonth, myyear, "Standard", lblEac.Text);


            txthev36sc.ToolTip = lib.HevS("StandingCharge", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "36", lblStartdate.Text, mymonth, myyear, "Standard", lblEac.Text);
            txthev36day.ToolTip = lib.HevS("DayRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "36", lblStartdate.Text, mymonth, myyear, "Standard", lblEac.Text);
            txthev36night.ToolTip = lib.HevS("NightRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "36", lblStartdate.Text, mymonth, myyear, "Standard", lblEac.Text);
            txthev36ew.ToolTip = lib.HevS("EveWeekendRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "36", lblStartdate.Text, mymonth, myyear, "Standard", lblEac.Text);
            txthev36offpeak.ToolTip = lib.HevS("SingleRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "36", lblStartdate.Text, mymonth, myyear, "Standard", lblEac.Text);


            lblhev36program.ToolTip = "Heven Energy 1 Year " + lib.HevS("Product", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "36", lblStartdate.Text, mymonth, myyear, "Standard", lblEac.Text);


            // 4 years

            //4 year


            txthev48sc.Text = lib.HevS("StandingCharge", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "48", lblStartdate.Text, mymonth, myyear, "Standard", lblEac.Text);
            txthev48day.Text = lib.HevS("DayRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "48", lblStartdate.Text, mymonth, myyear, "Standard", lblEac.Text);
            txthev48night.Text = lib.HevS("NightRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "48", lblStartdate.Text, mymonth, myyear, "Standard", lblEac.Text);
            txthev48ew.Text = lib.HevS("EveWeekendRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "48", lblStartdate.Text, mymonth, myyear, "Standard", lblEac.Text);
            txthev48offpeak.Text = lib.HevS("SingleRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "48", lblStartdate.Text, mymonth, myyear, "Standard", lblEac.Text);


            lblhev48program.Text = "Heven Energy 1 Year " + lib.HevS("Product", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "48", lblStartdate.Text, mymonth, myyear, "Standard", lblEac.Text);


            txthev48sc.ToolTip = lib.HevS("StandingCharge", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "48", lblStartdate.Text, mymonth, myyear, "Standard", lblEac.Text);
            txthev48day.ToolTip = lib.HevS("DayRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "48", lblStartdate.Text, mymonth, myyear, "Standard", lblEac.Text);
            txthev48night.ToolTip = lib.HevS("NightRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "48", lblStartdate.Text, mymonth, myyear, "Standard", lblEac.Text);
            txthev48ew.ToolTip = lib.HevS("EveWeekendRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "48", lblStartdate.Text, mymonth, myyear, "Standard", lblEac.Text);
            txthev48offpeak.ToolTip = lib.HevS("SingleRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "48", lblStartdate.Text, mymonth, myyear, "Standard", lblEac.Text);


            lblhev48program.ToolTip = "Heven Energy 1 Year " + lib.HevS("Product", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "48", lblStartdate.Text, mymonth, myyear, "Standard", lblEac.Text);



            /// for All
            /// 

            // 1 year
            txthev12scall.Text = lib.HevS("StandingCharge", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "12", lblStartdate.Text, mymonth, myyear, "Standard", lblEac.Text);
            txthev12dayall.Text = lib.HevS("DayRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "12", lblStartdate.Text, mymonth, myyear, "Standard", lblEac.Text);
            txthev12nightall.Text = lib.HevS("NightRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "12", lblStartdate.Text, mymonth, myyear, "Standard", lblEac.Text);
            txthev12ewall.Text = lib.HevS("EveWeekendRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "12", lblStartdate.Text, mymonth, myyear, "Standard", lblEac.Text);
            txthev12offpeakall.Text = lib.HevS("SingleRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "12", lblStartdate.Text, mymonth, myyear, "Standard", lblEac.Text);


            lblhev12programall.Text = "Heven Energy 1 Year " + lib.HevS("Product", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "12", lblStartdate.Text, mymonth, myyear, "Standard", lblEac.Text);


            txthev12scall.ToolTip = lib.HevS("StandingCharge", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "12", lblStartdate.Text, mymonth, myyear, "Standard", lblEac.Text);
            txthev12dayall.ToolTip = lib.HevS("DayRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "12", lblStartdate.Text, mymonth, myyear, "Standard", lblEac.Text);
            txthev12nightall.ToolTip = lib.HevS("NightRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "12", lblStartdate.Text, mymonth, myyear, "Standard", lblEac.Text);
            txthev12ewall.ToolTip = lib.HevS("EveWeekendRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "12", lblStartdate.Text, mymonth, myyear, "Standard", lblEac.Text);
            txthev12offpeakall.ToolTip = lib.HevS("SingleRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "12", lblStartdate.Text, mymonth, myyear, "Standard", lblEac.Text);


            lblhev12programall.ToolTip = "Heven Energy 1 Year " + lib.HevS("Product", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "12", lblStartdate.Text, mymonth, myyear, "Standard", lblEac.Text);

            //2 year


            txthev24scall.Text = lib.HevS("StandingCharge", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "24", lblStartdate.Text, mymonth, myyear, "Standard", lblEac.Text);
            txthev24dayall.Text = lib.HevS("DayRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "24", lblStartdate.Text, mymonth, myyear, "Standard", lblEac.Text);
            txthev24nightall.Text = lib.HevS("NightRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "24", lblStartdate.Text, mymonth, myyear, "Standard", lblEac.Text);
            txthev24ewall.Text = lib.HevS("EveWeekendRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "24", lblStartdate.Text, mymonth, myyear, "Standard", lblEac.Text);
            txthev24offpeakall.Text = lib.HevS("SingleRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "24", lblStartdate.Text, mymonth, myyear, "Standard", lblEac.Text);


            lblhev24programall.Text = "Heven Energy 1 Year " + lib.HevS("Product", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "24", lblStartdate.Text, mymonth, myyear, "Standard", lblEac.Text);


            txthev24scall.ToolTip = lib.HevS("StandingCharge", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "24", lblStartdate.Text, mymonth, myyear, "Standard", lblEac.Text);
            txthev24dayall.ToolTip = lib.HevS("DayRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "24", lblStartdate.Text, mymonth, myyear, "Standard", lblEac.Text);
            txthev24nightall.ToolTip = lib.HevS("NightRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "24", lblStartdate.Text, mymonth, myyear, "Standard", lblEac.Text);
            txthev24ewall.ToolTip = lib.HevS("EveWeekendRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "24", lblStartdate.Text, mymonth, myyear, "Standard", lblEac.Text);
            txthev24offpeakall.ToolTip = lib.HevS("SingleRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "24", lblStartdate.Text, mymonth, myyear, "Standard", lblEac.Text);


            lblhev24programall.ToolTip = "Heven Energy 1 Year " + lib.HevS("Product", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "24", lblStartdate.Text, mymonth, myyear, "Standard", lblEac.Text);


            //3 year


            txthev36scall.Text = lib.HevS("StandingCharge", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "36", lblStartdate.Text, mymonth, myyear, "Standard", lblEac.Text);
            txthev36dayall.Text = lib.HevS("DayRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "36", lblStartdate.Text, mymonth, myyear, "Standard", lblEac.Text);
            txthev36nightall.Text = lib.HevS("NightRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "36", lblStartdate.Text, mymonth, myyear, "Standard", lblEac.Text);
            txthev36ewall.Text = lib.HevS("EveWeekendRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "36", lblStartdate.Text, mymonth, myyear, "Standard", lblEac.Text);
            txthev36offpeakall.Text = lib.HevS("SingleRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "36", lblStartdate.Text, mymonth, myyear, "Standard", lblEac.Text);


            lblhev36programall.Text = "Heven Energy 1 Year " + lib.HevS("Product", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "36", lblStartdate.Text, mymonth, myyear, "Standard", lblEac.Text);


            txthev36scall.ToolTip = lib.HevS("StandingCharge", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "36", lblStartdate.Text, mymonth, myyear, "Standard", lblEac.Text);
            txthev36dayall.ToolTip = lib.HevS("DayRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "36", lblStartdate.Text, mymonth, myyear, "Standard", lblEac.Text);
            txthev36nightall.ToolTip = lib.HevS("NightRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "36", lblStartdate.Text, mymonth, myyear, "Standard", lblEac.Text);
            txthev36ewall.ToolTip = lib.HevS("EveWeekendRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "36", lblStartdate.Text, mymonth, myyear, "Standard", lblEac.Text);
            txthev36offpeakall.ToolTip = lib.HevS("SingleRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "36", lblStartdate.Text, mymonth, myyear, "Standard", lblEac.Text);


            lblhev36programall.ToolTip = "Heven Energy 1 Year " + lib.HevS("Product", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "36", lblStartdate.Text, mymonth, myyear, "Standard", lblEac.Text);


            // 4 years

            //4 year


            txthev48scall.Text = lib.HevS("StandingCharge", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "48", lblStartdate.Text, mymonth, myyear, "Standard", lblEac.Text);
            txthev48dayall.Text = lib.HevS("DayRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "48", lblStartdate.Text, mymonth, myyear, "Standard", lblEac.Text);
            txthev48nightall.Text = lib.HevS("NightRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "48", lblStartdate.Text, mymonth, myyear, "Standard", lblEac.Text);
            txthev48ewall.Text = lib.HevS("EveWeekendRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "48", lblStartdate.Text, mymonth, myyear, "Standard", lblEac.Text);
            txthev48offpeakall.Text = lib.HevS("SingleRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "48", lblStartdate.Text, mymonth, myyear, "Standard", lblEac.Text);


            lblhev48programall.Text = "Heven Energy 1 Year " + lib.HevS("Product", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "48", lblStartdate.Text, mymonth, myyear, "Standard", lblEac.Text);


            txthev48scall.ToolTip = lib.HevS("StandingCharge", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "48", lblStartdate.Text, mymonth, myyear, "Standard", lblEac.Text);
            txthev48dayall.ToolTip = lib.HevS("DayRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "48", lblStartdate.Text, mymonth, myyear, "Standard", lblEac.Text);
            txthev48nightall.ToolTip = lib.HevS("NightRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "48", lblStartdate.Text, mymonth, myyear, "Standard", lblEac.Text);
            txthev48ewall.ToolTip = lib.HevS("EveWeekendRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "48", lblStartdate.Text, mymonth, myyear, "Standard", lblEac.Text);
            txthev48offpeakall.ToolTip = lib.HevS("SingleRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "48", lblStartdate.Text, mymonth, myyear, "Standard", lblEac.Text);


            lblhev48programall.ToolTip = "Heven Energy 1 Year " + lib.HevS("Product", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "48", lblStartdate.Text, mymonth, myyear, "Standard", lblEac.Text);


            //  For  Complete   porduct

            // 1 year
            txthevc12sc.Text = lib.HevS("StandingCharge", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "12", lblStartdate.Text, mymonth, myyear, "Complete", lblEac.Text);
            txthevc12day.Text = lib.HevS("DayRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "12", lblStartdate.Text, mymonth, myyear, "Complete", lblEac.Text);
            txthevc12night.Text = lib.HevS("NightRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "12", lblStartdate.Text, mymonth, myyear, "Complete", lblEac.Text);
            txthevc12ew.Text = lib.HevS("EveWeekendRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "12", lblStartdate.Text, mymonth, myyear, "Complete", lblEac.Text);
            txthevc12offpeak.Text = lib.HevS("SingleRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "12", lblStartdate.Text, mymonth, myyear, "Complete", lblEac.Text);


            lblhevc12program.Text = "Heven Energy 1 Year " + lib.HevS("Product", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "12", lblStartdate.Text, mymonth, myyear, "Complete", lblEac.Text);


            txthevc12sc.ToolTip = lib.HevS("StandingCharge", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "12", lblStartdate.Text, mymonth, myyear, "Complete", lblEac.Text);
            txthevc12day.ToolTip = lib.HevS("DayRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "12", lblStartdate.Text, mymonth, myyear, "Complete", lblEac.Text);
            txthevc12night.ToolTip = lib.HevS("NightRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "12", lblStartdate.Text, mymonth, myyear, "Complete", lblEac.Text);
            txthevc12ew.ToolTip = lib.HevS("EveWeekendRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "12", lblStartdate.Text, mymonth, myyear, "Complete", lblEac.Text);
            txthevc12offpeak.ToolTip = lib.HevS("SingleRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "12", lblStartdate.Text, mymonth, myyear, "Complete", lblEac.Text);


            lblhevc12program.ToolTip = "Heven Energy 1 Year " + lib.HevS("Product", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "12", lblStartdate.Text, mymonth, myyear, "Complete", lblEac.Text);

            //2 year


            txthevc24sc.Text = lib.HevS("StandingCharge", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "24", lblStartdate.Text, mymonth, myyear, "Complete", lblEac.Text);
            txthevc24day.Text = lib.HevS("DayRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "24", lblStartdate.Text, mymonth, myyear, "Complete", lblEac.Text);
            txthevc24night.Text = lib.HevS("NightRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "24", lblStartdate.Text, mymonth, myyear, "Complete", lblEac.Text);
            txthevc24ew.Text = lib.HevS("EveWeekendRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "24", lblStartdate.Text, mymonth, myyear, "Complete", lblEac.Text);
            txthevc24offpeak.Text = lib.HevS("SingleRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "24", lblStartdate.Text, mymonth, myyear, "Complete", lblEac.Text);


            lblhevc24program.Text = "Heven Energy 1 Year " + lib.HevS("Product", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "24", lblStartdate.Text, mymonth, myyear, "Complete", lblEac.Text);


            txthevc24sc.ToolTip = lib.HevS("StandingCharge", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "24", lblStartdate.Text, mymonth, myyear, "Complete", lblEac.Text);
            txthevc24day.ToolTip = lib.HevS("DayRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "24", lblStartdate.Text, mymonth, myyear, "Complete", lblEac.Text);
            txthevc24night.ToolTip = lib.HevS("NightRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "24", lblStartdate.Text, mymonth, myyear, "Complete", lblEac.Text);
            txthevc24ew.ToolTip = lib.HevS("EveWeekendRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "24", lblStartdate.Text, mymonth, myyear, "Complete", lblEac.Text);
            txthevc24offpeak.ToolTip = lib.HevS("SingleRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "24", lblStartdate.Text, mymonth, myyear, "Complete", lblEac.Text);


            lblhevc24program.ToolTip = "Heven Energy 1 Year " + lib.HevS("Product", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "24", lblStartdate.Text, mymonth, myyear, "Complete", lblEac.Text);


            //3 year


            txthevc36sc.Text = lib.HevS("StandingCharge", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "36", lblStartdate.Text, mymonth, myyear, "Complete", lblEac.Text);
            txthevc36day.Text = lib.HevS("DayRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "36", lblStartdate.Text, mymonth, myyear, "Complete", lblEac.Text);
            txthevc36night.Text = lib.HevS("NightRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "36", lblStartdate.Text, mymonth, myyear, "Complete", lblEac.Text);
            txthevc36ew.Text = lib.HevS("EveWeekendRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "36", lblStartdate.Text, mymonth, myyear, "Complete", lblEac.Text);
            txthevc36offpeak.Text = lib.HevS("SingleRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "36", lblStartdate.Text, mymonth, myyear, "Complete", lblEac.Text);


            lblhevc36program.Text = "Heven Energy 1 Year " + lib.HevS("Product", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "36", lblStartdate.Text, mymonth, myyear, "Complete", lblEac.Text);


            txthevc36sc.ToolTip = lib.HevS("StandingCharge", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "36", lblStartdate.Text, mymonth, myyear, "Complete", lblEac.Text);
            txthevc36day.ToolTip = lib.HevS("DayRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "36", lblStartdate.Text, mymonth, myyear, "Complete", lblEac.Text);
            txthevc36night.ToolTip = lib.HevS("NightRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "36", lblStartdate.Text, mymonth, myyear, "Complete", lblEac.Text);
            txthevc36ew.ToolTip = lib.HevS("EveWeekendRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "36", lblStartdate.Text, mymonth, myyear, "Complete", lblEac.Text);
            txthevc36offpeak.ToolTip = lib.HevS("SingleRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "36", lblStartdate.Text, mymonth, myyear, "Complete", lblEac.Text);


            lblhevc36program.ToolTip = "Heven Energy 1 Year " + lib.HevS("Product", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "36", lblStartdate.Text, mymonth, myyear, "Complete", lblEac.Text);


            // 4 years

            //4 year


            txthevc48sc.Text = lib.HevS("StandingCharge", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "48", lblStartdate.Text, mymonth, myyear, "Complete", lblEac.Text);
            txthevc48day.Text = lib.HevS("DayRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "48", lblStartdate.Text, mymonth, myyear, "Complete", lblEac.Text);
            txthevc48night.Text = lib.HevS("NightRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "48", lblStartdate.Text, mymonth, myyear, "Complete", lblEac.Text);
            txthevc48ew.Text = lib.HevS("EveWeekendRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "48", lblStartdate.Text, mymonth, myyear, "Complete", lblEac.Text);
            txthevc48offpeak.Text = lib.HevS("SingleRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "48", lblStartdate.Text, mymonth, myyear, "Complete", lblEac.Text);


            lblhevc48program.Text = "Heven Energy 1 Year " + lib.HevS("Product", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "48", lblStartdate.Text, mymonth, myyear, "Complete", lblEac.Text);


            txthevc48sc.ToolTip = lib.HevS("StandingCharge", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "48", lblStartdate.Text, mymonth, myyear, "Complete", lblEac.Text);
            txthevc48day.ToolTip = lib.HevS("DayRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "48", lblStartdate.Text, mymonth, myyear, "Complete", lblEac.Text);
            txthevc48night.ToolTip = lib.HevS("NightRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "48", lblStartdate.Text, mymonth, myyear, "Complete", lblEac.Text);
            txthevc48ew.ToolTip = lib.HevS("EveWeekendRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "48", lblStartdate.Text, mymonth, myyear, "Complete", lblEac.Text);
            txthevc48offpeak.ToolTip = lib.HevS("SingleRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "48", lblStartdate.Text, mymonth, myyear, "Complete", lblEac.Text);


            lblhevc48program.ToolTip = "Heven Energy 1 Year " + lib.HevS("Product", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "48", lblStartdate.Text, mymonth, myyear, "Complete", lblEac.Text);



            /// for All
            /// 

            // 1 year
            txthevc12scall.Text = lib.HevS("StandingCharge", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "12", lblStartdate.Text, mymonth, myyear, "Complete", lblEac.Text);
            txthevc12dayall.Text = lib.HevS("DayRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "12", lblStartdate.Text, mymonth, myyear, "Complete", lblEac.Text);
            txthevc12nightall.Text = lib.HevS("NightRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "12", lblStartdate.Text, mymonth, myyear, "Complete", lblEac.Text);
            txthevc12ewall.Text = lib.HevS("EveWeekendRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "12", lblStartdate.Text, mymonth, myyear, "Complete", lblEac.Text);
            txthevc12offpeakall.Text = lib.HevS("SingleRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "12", lblStartdate.Text, mymonth, myyear, "Complete", lblEac.Text);


            lblhevc12programall.Text = "Heven Energy 1 Year " + lib.HevS("Product", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "12", lblStartdate.Text, mymonth, myyear, "Complete", lblEac.Text);


            txthevc12scall.ToolTip = lib.HevS("StandingCharge", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "12", lblStartdate.Text, mymonth, myyear, "Complete", lblEac.Text);
            txthevc12dayall.ToolTip = lib.HevS("DayRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "12", lblStartdate.Text, mymonth, myyear, "Complete", lblEac.Text);
            txthevc12nightall.ToolTip = lib.HevS("NightRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "12", lblStartdate.Text, mymonth, myyear, "Complete", lblEac.Text);
            txthevc12ewall.ToolTip = lib.HevS("EveWeekendRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "12", lblStartdate.Text, mymonth, myyear, "Complete", lblEac.Text);
            txthevc12offpeakall.ToolTip = lib.HevS("SingleRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "12", lblStartdate.Text, mymonth, myyear, "Complete", lblEac.Text);


            lblhevc12programall.ToolTip = "Heven Energy 1 Year " + lib.HevS("Product", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "12", lblStartdate.Text, mymonth, myyear, "Complete", lblEac.Text);

            //2 year


            txthevc24scall.Text = lib.HevS("StandingCharge", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "24", lblStartdate.Text, mymonth, myyear, "Complete", lblEac.Text);
            txthevc24dayall.Text = lib.HevS("DayRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "24", lblStartdate.Text, mymonth, myyear, "Complete", lblEac.Text);
            txthevc24nightall.Text = lib.HevS("NightRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "24", lblStartdate.Text, mymonth, myyear, "Complete", lblEac.Text);
            txthevc24ewall.Text = lib.HevS("EveWeekendRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "24", lblStartdate.Text, mymonth, myyear, "Complete", lblEac.Text);
            txthevc24offpeakall.Text = lib.HevS("SingleRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "24", lblStartdate.Text, mymonth, myyear, "Complete", lblEac.Text);


            lblhevc24programall.Text = "Heven Energy 1 Year " + lib.HevS("Product", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "24", lblStartdate.Text, mymonth, myyear, "Complete", lblEac.Text);


            txthevc24scall.ToolTip = lib.HevS("StandingCharge", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "24", lblStartdate.Text, mymonth, myyear, "Complete", lblEac.Text);
            txthevc24dayall.ToolTip = lib.HevS("DayRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "24", lblStartdate.Text, mymonth, myyear, "Complete", lblEac.Text);
            txthevc24nightall.ToolTip = lib.HevS("NightRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "24", lblStartdate.Text, mymonth, myyear, "Complete", lblEac.Text);
            txthevc24ewall.ToolTip = lib.HevS("EveWeekendRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "24", lblStartdate.Text, mymonth, myyear, "Complete", lblEac.Text);
            txthevc24offpeakall.ToolTip = lib.HevS("SingleRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "24", lblStartdate.Text, mymonth, myyear, "Complete", lblEac.Text);


            lblhevc24programall.ToolTip = "Heven Energy 1 Year " + lib.HevS("Product", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "24", lblStartdate.Text, mymonth, myyear, "Complete", lblEac.Text);


            //3 year


            txthevc36scall.Text = lib.HevS("StandingCharge", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "36", lblStartdate.Text, mymonth, myyear, "Complete", lblEac.Text);
            txthevc36dayall.Text = lib.HevS("DayRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "36", lblStartdate.Text, mymonth, myyear, "Complete", lblEac.Text);
            txthevc36nightall.Text = lib.HevS("NightRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "36", lblStartdate.Text, mymonth, myyear, "Complete", lblEac.Text);
            txthevc36ewall.Text = lib.HevS("EveWeekendRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "36", lblStartdate.Text, mymonth, myyear, "Complete", lblEac.Text);
            txthevc36offpeakall.Text = lib.HevS("SingleRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "36", lblStartdate.Text, mymonth, myyear, "Complete", lblEac.Text);


            lblhevc36programall.Text = "Heven Energy 1 Year " + lib.HevS("Product", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "36", lblStartdate.Text, mymonth, myyear, "Complete", lblEac.Text);


            txthevc36scall.ToolTip = lib.HevS("StandingCharge", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "36", lblStartdate.Text, mymonth, myyear, "Complete", lblEac.Text);
            txthevc36dayall.ToolTip = lib.HevS("DayRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "36", lblStartdate.Text, mymonth, myyear, "Complete", lblEac.Text);
            txthevc36nightall.ToolTip = lib.HevS("NightRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "36", lblStartdate.Text, mymonth, myyear, "Complete", lblEac.Text);
            txthevc36ewall.ToolTip = lib.HevS("EveWeekendRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "36", lblStartdate.Text, mymonth, myyear, "Complete", lblEac.Text);
            txthevc36offpeakall.ToolTip = lib.HevS("SingleRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "36", lblStartdate.Text, mymonth, myyear, "Complete", lblEac.Text);


            lblhevc36programall.ToolTip = "Heven Energy 1 Year " + lib.HevS("Product", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "36", lblStartdate.Text, mymonth, myyear, "Complete", lblEac.Text);


            // 4 years

            //4 year


            txthevc48scall.Text = lib.HevS("StandingCharge", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "48", lblStartdate.Text, mymonth, myyear, "Complete", lblEac.Text);
            txthevc48dayall.Text = lib.HevS("DayRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "48", lblStartdate.Text, mymonth, myyear, "Complete", lblEac.Text);
            txthevc48nightall.Text = lib.HevS("NightRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "48", lblStartdate.Text, mymonth, myyear, "Complete", lblEac.Text);
            txthevc48ewall.Text = lib.HevS("EveWeekendRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "48", lblStartdate.Text, mymonth, myyear, "Complete", lblEac.Text);
            txthevc48offpeakall.Text = lib.HevS("SingleRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "48", lblStartdate.Text, mymonth, myyear, "Complete", lblEac.Text);


            lblhevc48programall.Text = "Heven Energy 1 Year " + lib.HevS("Product", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "48", lblStartdate.Text, mymonth, myyear, "Complete", lblEac.Text);


            txthevc48scall.ToolTip = lib.HevS("StandingCharge", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "48", lblStartdate.Text, mymonth, myyear, "Complete", lblEac.Text);
            txthevc48dayall.ToolTip = lib.HevS("DayRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "48", lblStartdate.Text, mymonth, myyear, "Complete", lblEac.Text);
            txthevc48nightall.ToolTip = lib.HevS("NightRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "48", lblStartdate.Text, mymonth, myyear, "Complete", lblEac.Text);
            txthevc48ewall.ToolTip = lib.HevS("EveWeekendRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "48", lblStartdate.Text, mymonth, myyear, "Complete", lblEac.Text);
            txthevc48offpeakall.ToolTip = lib.HevS("SingleRate", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "48", lblStartdate.Text, mymonth, myyear, "Complete", lblEac.Text);


            lblhevc48programall.ToolTip = "Heven Energy 1 Year " + lib.HevS("Product", lblProfile.Text, lblRegion.Text, lblHevsMeterType.Text, "48", lblStartdate.Text, mymonth, myyear, "Complete", lblEac.Text);




        }
        #endregion

        #region SSE calculation

        void SSE()
        {
            string dayrate = "0";
            string weekday = "0";
            string unitrate = "0";
            #region  SSe 12 Months

            txtsse12scamr.Text = lib.SSE("AMRQuarterlyCharge", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "12", lblStartdate.Text);
            txtsse12scnonamr.Text = lib.SSE("NonAMRQuarterlyCharge", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text,"12", lblStartdate.Text);

            txtsse12ew.Text = lib.SSE("EveningandWeekendUnits", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "12", lblStartdate.Text);
            if(txtsse12ew.Text==  "0")
            {
                txtsse12ew.Text = lib.SSE("NonWeekDayUnits", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "12", lblStartdate.Text);

            }
            
            weekday = lib.SSE("WeekDayUnits", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "12", lblStartdate.Text);
            



            dayrate = lib.SSE("DayUnits", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "12", lblStartdate.Text);

            txtsse12night.Text = lib.SSE("NightUnits", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "12", lblStartdate.Text);
            unitrate = lib.SSE("AllUnits", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "12", lblStartdate.Text);
            txtsse12offpeak.Text = lib.SSE("OffPeakUnits", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "12", lblStartdate.Text);
            txtsse12other.Text = lib.SSE("FiTs", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "12", lblStartdate.Text);


            lblsse12program.Text = "SSE ref -" + lib.SSE("SSERef", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "12", lblStartdate.Text) + " Per quarter";
            txtsse12day.Text = lib.DayRate(dayrate, weekday, unitrate);

            // Tooltip

            txtsse12scamr.ToolTip = lib.SSE("AMRQuarterlyCharge", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "12", lblStartdate.Text);
            txtsse12scnonamr.ToolTip = lib.SSE("NonAMRQuarterlyCharge", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "12", lblStartdate.Text);

            txtsse12ew.ToolTip = lib.SSE("EveningandWeekendUnits", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "12", lblStartdate.Text);
            if (txtsse12ew.ToolTip == "0")
            {
                txtsse12ew.ToolTip = lib.SSE("NonWeekDayUnits", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "12", lblStartdate.Text);

            }
            weekday = lib.SSE("WeekDayUnits", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "12", lblStartdate.Text);
           
            dayrate = lib.SSE("DayUnits", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "12", lblStartdate.Text);

            txtsse12night.ToolTip = lib.SSE("NightUnits", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "12", lblStartdate.Text);
            unitrate = lib.SSE("AllUnits", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text,"12", lblStartdate.Text);
            txtsse12offpeak.ToolTip = lib.SSE("OffPeakUnits", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "12", lblStartdate.Text);
            txtsse12other.ToolTip = lib.SSE("FiTs", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "12", lblStartdate.Text);
            lblsse12program.ToolTip = "SSE ref -" + lib.SSE("SSERef", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "12", lblStartdate.Text) + "Per quarter";
            txtsse12day.ToolTip = lib.DayRate(dayrate, weekday, unitrate);






            // For all




            txtsse12scamrall.Text = lib.SSE("AMRQuarterlyCharge", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "12", lblStartdate.Text);
            txtsse12scnonamrall.Text = lib.SSE("NonAMRQuarterlyCharge", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "12", lblStartdate.Text);

            txtsse12ewall.Text = lib.SSE("EveningandWeekendUnits", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "12", lblStartdate.Text);
            if (txtsse12ewall.Text == "0")
            {
                txtsse12ewall.Text = lib.SSE("NonWeekDayUnits", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "12", lblStartdate.Text);

            }

            weekday = lib.SSE("WeekDayUnits", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "12", lblStartdate.Text);
           
            dayrate = lib.SSE("DayUnits", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "12", lblStartdate.Text);

            txtsse12nightall.Text = lib.SSE("NightUnits", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "12", lblStartdate.Text);
             unitrate = lib.SSE("AllUnits", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text,"12", lblStartdate.Text);
            txtsse12offpeakall.Text = lib.SSE("OffPeakUnits", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "12", lblStartdate.Text);
            txtsse12otherall.Text = lib.SSE("FiTs", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "12", lblStartdate.Text);
            lblsse12programall.Text = "SSE ref -" + lib.SSE("SSERef", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "12", lblStartdate.Text) + "Per quarter";

            txtsse12dayall.Text = lib.DayRate(dayrate, weekday, unitrate);

            // Tooltip

            txtsse12scamrall.ToolTip = lib.SSE("AMRQuarterlyCharge", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "12", lblStartdate.Text);
            txtsse12scnonamrall.ToolTip = lib.SSE("NonAMRQuarterlyCharge", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "12", lblStartdate.Text);

            txtsse12ewall.ToolTip = lib.SSE("EveningandWeekendUnits", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text,"12", lblStartdate.Text);
            if (txtsse12ewall.ToolTip == "0")
            {
                txtsse12ewall.ToolTip = lib.SSE("NonWeekDayUnits", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "12", lblStartdate.Text);

            }

            weekday = lib.SSE("WeekDayUnits", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "12", lblStartdate.Text);
           
            dayrate = lib.SSE("DayUnits", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "12", lblStartdate.Text);

            txtsse12nightall.ToolTip = lib.SSE("NightUnits", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "12", lblStartdate.Text);
            unitrate = lib.SSE("AllUnits", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "12", lblStartdate.Text);
            txtsse12offpeakall.ToolTip = lib.SSE("OffPeakUnits", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "12", lblStartdate.Text);
            txtsse12otherall.ToolTip = lib.SSE("FiTs", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "12", lblStartdate.Text);
            lblsse12programall.ToolTip = "SSE ref -" + lib.SSE("SSERef", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "12", lblStartdate.Text) + "Per quarter";

            txtsse12dayall.ToolTip = lib.DayRate(dayrate, weekday, unitrate);

            #endregion

            #region  SSe 24 Months
        
            txtsse24scamr.Text = lib.SSE("AMRQuarterlyCharge", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "24", lblStartdate.Text);
            txtsse24scnonamr.Text = lib.SSE("NonAMRQuarterlyCharge", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "24", lblStartdate.Text);

            txtsse24ew.Text = lib.SSE("EveningandWeekendUnits", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "24", lblStartdate.Text);
            if (txtsse24ew.Text == "0")
            {
                txtsse24ew.Text = lib.SSE("NonWeekDayUnits", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "24", lblStartdate.Text);

            }

            weekday = lib.SSE("WeekDayUnits", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "24", lblStartdate.Text);
           
            dayrate = lib.SSE("DayUnits", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "24", lblStartdate.Text);

            txtsse24night.Text = lib.SSE("NightUnits", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "24", lblStartdate.Text);
            unitrate = lib.SSE("AllUnits", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "24", lblStartdate.Text);
            txtsse24offpeak.Text = lib.SSE("OffPeakUnits", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "24", lblStartdate.Text);
            txtsse24other.Text = lib.SSE("FiTs", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "24", lblStartdate.Text);
            lblsse24program.Text = "SSE ref -" + lib.SSE("SSERef", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "24", lblStartdate.Text) + "Per quarter";
            txtsse24day.Text = lib.DayRate(dayrate, weekday, unitrate);

            // Tooltip

            txtsse24scamr.ToolTip = lib.SSE("AMRQuarterlyCharge", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "24", lblStartdate.Text);
            txtsse24scnonamr.ToolTip = lib.SSE("NonAMRQuarterlyCharge", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "24", lblStartdate.Text);

            txtsse24ew.ToolTip = lib.SSE("EveningandWeekendUnits", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "24", lblStartdate.Text);
            if (txtsse24ew.ToolTip == "0")
            {
                txtsse24ew.ToolTip = lib.SSE("NonWeekDayUnits", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "24", lblStartdate.Text);

            }
            weekday = lib.SSE("WeekDayUnits", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "24", lblStartdate.Text);

            dayrate = lib.SSE("DayUnits", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "24", lblStartdate.Text);

            txtsse24night.ToolTip = lib.SSE("NightUnits", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "24", lblStartdate.Text);
            unitrate = lib.SSE("AllUnits", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "24", lblStartdate.Text);
            txtsse24offpeak.ToolTip = lib.SSE("OffPeakUnits", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "24", lblStartdate.Text);
            txtsse24other.ToolTip = lib.SSE("FiTs", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "24", lblStartdate.Text);
            lblsse24program.ToolTip = "SSE ref -" + lib.SSE("SSERef", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "24", lblStartdate.Text) + "Per quarter";
            txtsse24day.ToolTip = lib.DayRate(dayrate, weekday, unitrate);






            // For all

            


            txtsse24scamrall.Text = lib.SSE("AMRQuarterlyCharge", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "24", lblStartdate.Text);
            txtsse24scnonamrall.Text = lib.SSE("NonAMRQuarterlyCharge", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "24", lblStartdate.Text);

            txtsse24ewall.Text = lib.SSE("EveningandWeekendUnits", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "24", lblStartdate.Text);
            if (txtsse24ewall.Text == "0")
            {
                txtsse24ewall.Text = lib.SSE("NonWeekDayUnits", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "24", lblStartdate.Text);

            }
            weekday = lib.SSE("WeekDayUnits", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "24", lblStartdate.Text);

            dayrate = lib.SSE("DayUnits", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "24", lblStartdate.Text);

            txtsse24nightall.Text = lib.SSE("NightUnits", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "24", lblStartdate.Text);
            unitrate = lib.SSE("AllUnits", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "24", lblStartdate.Text);
            txtsse24offpeakall.Text = lib.SSE("OffPeakUnits", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "24", lblStartdate.Text);
            txtsse24otherall.Text = lib.SSE("FiTs", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "24", lblStartdate.Text);
            lblsse24programall.Text = "SSE ref -" + lib.SSE("SSERef", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "24", lblStartdate.Text) + "Per quarter";

            txtsse24dayall.Text = lib.DayRate(dayrate, weekday, unitrate);

          //  Tooltip

            txtsse24scamrall.ToolTip = lib.SSE("AMRQuarterlyCharge", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "24", lblStartdate.Text);
            txtsse24scnonamrall.ToolTip = lib.SSE("NonAMRQuarterlyCharge", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "24", lblStartdate.Text);

            txtsse24ewall.ToolTip = lib.SSE("EveningandWeekendUnits", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "24", lblStartdate.Text);
            if (txtsse24ewall.ToolTip == "0")
            {
                txtsse24ewall.ToolTip = lib.SSE("NonWeekDayUnits", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "24", lblStartdate.Text);

            }
            weekday = lib.SSE("WeekDayUnits", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "24", lblStartdate.Text);

            dayrate = lib.SSE("DayUnits", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "24", lblStartdate.Text);

            txtsse24nightall.ToolTip = lib.SSE("NightUnits", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "24", lblStartdate.Text);
            unitrate = lib.SSE("AllUnits", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "24", lblStartdate.Text);
            txtsse24offpeakall.ToolTip = lib.SSE("OffPeakUnits", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "24", lblStartdate.Text);
            txtsse24otherall.ToolTip = lib.SSE("FiTs", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "24", lblStartdate.Text);
            lblsse24programall.ToolTip = "SSE ref -" + lib.SSE("SSERef", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "24", lblStartdate.Text) + "Per quarter";

            txtsse24dayall.ToolTip = lib.DayRate(dayrate, weekday, unitrate);

            #endregion

            #region  SSe 36 Months

            txtsse36scamr.Text = lib.SSE("AMRQuarterlyCharge", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "36", lblStartdate.Text);
            txtsse36scnonamr.Text = lib.SSE("NonAMRQuarterlyCharge", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "36", lblStartdate.Text);

            txtsse36ew.Text = lib.SSE("EveningandWeekendUnits", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "36", lblStartdate.Text);
            if (txtsse36ew.Text == "0")
            {
                txtsse36ew.Text = lib.SSE("NonWeekDayUnits", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "36", lblStartdate.Text);

            }
            weekday = lib.SSE("WeekDayUnits", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "36", lblStartdate.Text);

            dayrate = lib.SSE("DayUnits", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "36", lblStartdate.Text);

            txtsse36night.Text = lib.SSE("NightUnits", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "36", lblStartdate.Text);
            unitrate = lib.SSE("AllUnits", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "36", lblStartdate.Text);
            txtsse36offpeak.Text = lib.SSE("OffPeakUnits", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "36", lblStartdate.Text);
            txtsse36other.Text = lib.SSE("FiTs", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "36", lblStartdate.Text);
            lblsse36program.Text = "SSE ref -" + lib.SSE("SSERef", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "36", lblStartdate.Text) + "Per quarter";
            txtsse36day.Text = lib.DayRate(dayrate, weekday, unitrate);

            // Tooltip

            txtsse36scamr.ToolTip = lib.SSE("AMRQuarterlyCharge", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "36", lblStartdate.Text);
            txtsse36scnonamr.ToolTip = lib.SSE("NonAMRQuarterlyCharge", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "36", lblStartdate.Text);

            txtsse36ew.ToolTip = lib.SSE("EveningandWeekendUnits", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "36", lblStartdate.Text);
            if (txtsse36ew.ToolTip == "0")
            {
                txtsse36ew.ToolTip = lib.SSE("NonWeekDayUnits", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "36", lblStartdate.Text);

            }

            weekday = lib.SSE("WeekDayUnits", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "36", lblStartdate.Text);

            dayrate = lib.SSE("DayUnits", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "36", lblStartdate.Text);

            txtsse36night.ToolTip = lib.SSE("NightUnits", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "36", lblStartdate.Text);
            unitrate = lib.SSE("AllUnits", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "36", lblStartdate.Text);
            txtsse36offpeak.ToolTip = lib.SSE("OffPeakUnits", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "36", lblStartdate.Text);
            txtsse36other.ToolTip = lib.SSE("FiTs", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "36", lblStartdate.Text);
            lblsse36program.ToolTip = "SSE ref -" + lib.SSE("SSERef", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "36", lblStartdate.Text) + "Per quarter";
            txtsse36day.ToolTip = lib.DayRate(dayrate, weekday, unitrate);






            // For all




            txtsse36scamrall.Text = lib.SSE("AMRQuarterlyCharge", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "36", lblStartdate.Text);
            txtsse36scnonamrall.Text = lib.SSE("NonAMRQuarterlyCharge", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "36", lblStartdate.Text);

            txtsse36ewall.Text = lib.SSE("EveningandWeekendUnits", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "36", lblStartdate.Text);
            if (txtsse36ewall.Text == "0")
            {
                txtsse36ewall.Text = lib.SSE("NonWeekDayUnits", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "36", lblStartdate.Text);

            }

            weekday = lib.SSE("WeekDayUnits", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "36", lblStartdate.Text);

            dayrate = lib.SSE("DayUnits", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "36", lblStartdate.Text);

            txtsse36nightall.Text = lib.SSE("NightUnits", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "36", lblStartdate.Text);
            unitrate = lib.SSE("AllUnits", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "36", lblStartdate.Text);
            txtsse36offpeakall.Text = lib.SSE("OffPeakUnits", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "36", lblStartdate.Text);
            txtsse36otherall.Text = lib.SSE("FiTs", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "36", lblStartdate.Text);
            lblsse36programall.Text = "SSE ref -" + lib.SSE("SSERef", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "36", lblStartdate.Text) + "Per quarter";

            txtsse36dayall.Text = lib.DayRate(dayrate, weekday, unitrate);

            //  Tooltip

            txtsse36scamrall.ToolTip = lib.SSE("AMRQuarterlyCharge", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "36", lblStartdate.Text);
            txtsse36scnonamrall.ToolTip = lib.SSE("NonAMRQuarterlyCharge", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "36", lblStartdate.Text);

            txtsse36ewall.ToolTip = lib.SSE("EveningandWeekendUnits", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "36", lblStartdate.Text);
            if (txtsse36ewall.ToolTip == "0")
            {
                txtsse36ewall.ToolTip = lib.SSE("NonWeekDayUnits", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "36", lblStartdate.Text);

            }
            weekday = lib.SSE("WeekDayUnits", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "36", lblStartdate.Text);

            dayrate = lib.SSE("DayUnits", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "36", lblStartdate.Text);

            txtsse36nightall.ToolTip = lib.SSE("NightUnits", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "36", lblStartdate.Text);
            unitrate = lib.SSE("AllUnits", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "36", lblStartdate.Text);
            txtsse36offpeakall.ToolTip = lib.SSE("OffPeakUnits", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "36", lblStartdate.Text);
            txtsse36otherall.ToolTip = lib.SSE("FiTs", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "36", lblStartdate.Text);
            lblsse36programall.ToolTip = "SSE ref -" + lib.SSE("SSERef", lblProfile.Text, lblRegion.Text, lblSSEPEMetertype.Text, "36", lblStartdate.Text) + "Per quarter";

            txtsse36dayall.ToolTip = lib.DayRate(dayrate, weekday, unitrate);

            #endregion

        }

        #endregion


        #region Npower calculation
        void Npower()
        {
            DateTime dt = Convert.ToDateTime(lblStartdate.Text);
            string cmonth = dt.ToString("MMM");
            int load = int.Parse(lblEac.Text);
            int myload = lib.getnpowerload(load);
            // string np = lib.Npowera("Standing_Charge", lblProfile.Text, lblRegion.Text, lblNpwer.Text, "1", cmonth, myload);
            //    Response.Write(np);

            // 12 Months

            string dayrate = "0";
            string weekday = "0";
            string unitrate = "0";

            txtnpra12sc.Text = lib.Npowera("Standing_Charge", lblProfile.Text, lblRegion.Text, lblNpwer.Text, "1", cmonth, myload);
            dayrate = lib.Npowera("Day_Units", lblProfile.Text, lblRegion.Text, lblNpwer.Text, "1", cmonth, myload);
            txtnpra12night.Text = lib.Npowera("Night_Units", lblProfile.Text, lblRegion.Text, lblNpwer.Text, "1", cmonth, myload);
            txtnpra12ew.Text = lib.Npowera("Weekday_Units", lblProfile.Text, lblRegion.Text, lblNpwer.Text, "1", cmonth, myload);

            unitrate = lib.Npowera("All_Units", lblProfile.Text, lblRegion.Text, lblNpwer.Text, "1", cmonth, myload);
            txtnpra12other.Text = lib.Npowera("Other_Units", lblProfile.Text, lblRegion.Text, lblNpwer.Text, "1", cmonth, myload);
            lblnpra12program.Text = " Npower " + lib.Npowera("book", lblProfile.Text, lblRegion.Text, lblNpwer.Text, "1", cmonth, myload) + "For one year";
            txtnpra12day.Text = lib.DayRate(dayrate, weekday, unitrate);




            // 12 Months all

            txtnpra12scall.Text = lib.Npowera("Standing_Charge", lblProfile.Text, lblRegion.Text, lblNpwer.Text, "1", cmonth, myload);
           dayrate= lib.Npowera("Day_Units", lblProfile.Text, lblRegion.Text, lblNpwer.Text, "1", cmonth, myload);
            txtnpra12nightall.Text = lib.Npowera("Night_Units", lblProfile.Text, lblRegion.Text, lblNpwer.Text, "1", cmonth, myload);
            txtnpra12ewall.Text = lib.Npowera("Weekday_Units", lblProfile.Text, lblRegion.Text, lblNpwer.Text, "1", cmonth, myload);

           unitrate = lib.Npowera("All_Units", lblProfile.Text, lblRegion.Text, lblNpwer.Text, "1", cmonth, myload);
            txtnpra12otherall.Text = lib.Npowera("Other_Units", lblProfile.Text, lblRegion.Text, lblNpwer.Text, "1", cmonth, myload);
            lblnpra12programall.Text = " Npower " + lib.Npowera("book", lblProfile.Text, lblRegion.Text, lblNpwer.Text, "1", cmonth, myload) + "For one year";


            txtnpra12dayall.Text= lib.DayRate(dayrate, weekday, unitrate);
            // 24 Months

            txtnpra24sc.Text = lib.Npowera("Standing_Charge", lblProfile.Text, lblRegion.Text, lblNpwer.Text, "2", cmonth, myload);
            dayrate = lib.Npowera("Day_Units", lblProfile.Text, lblRegion.Text, lblNpwer.Text, "2", cmonth, myload);
            txtnpra24night.Text = lib.Npowera("Night_Units", lblProfile.Text, lblRegion.Text, lblNpwer.Text, "2", cmonth, myload);
            txtnpra24ew.Text = lib.Npowera("Weekday_Units", lblProfile.Text, lblRegion.Text, lblNpwer.Text, "2", cmonth, myload);

           unitrate = lib.Npowera("All_Units", lblProfile.Text, lblRegion.Text, lblNpwer.Text, "2", cmonth, myload);
            txtnpra24other.Text = lib.Npowera("Other_Units", lblProfile.Text, lblRegion.Text, lblNpwer.Text, "2", cmonth, myload);
            lblnpra24program.Text = " Npower " + lib.Npowera("book", lblProfile.Text, lblRegion.Text, lblNpwer.Text, "2", cmonth, myload) + "For two year";

            txtnpra24day.Text = lib.DayRate(dayrate, weekday, unitrate);


            // 24 Months all

            txtnpra24scall.Text = lib.Npowera("Standing_Charge", lblProfile.Text, lblRegion.Text, lblNpwer.Text, "2", cmonth, myload);
            dayrate = lib.Npowera("Day_Units", lblProfile.Text, lblRegion.Text, lblNpwer.Text, "2", cmonth, myload);
            txtnpra24nightall.Text = lib.Npowera("Night_Units", lblProfile.Text, lblRegion.Text, lblNpwer.Text, "2", cmonth, myload);
            txtnpra24ewall.Text = lib.Npowera("Weekday_Units", lblProfile.Text, lblRegion.Text, lblNpwer.Text, "2", cmonth, myload);

            unitrate = lib.Npowera("All_Units", lblProfile.Text, lblRegion.Text, lblNpwer.Text, "2", cmonth, myload);
            txtnpra24otherall.Text = lib.Npowera("Other_Units", lblProfile.Text, lblRegion.Text, lblNpwer.Text, "2", cmonth, myload);
            lblnpra24programall.Text = " Npower " + lib.Npowera("book", lblProfile.Text, lblRegion.Text, lblNpwer.Text, "2", cmonth, myload) + "For two year";

            txtnpra24dayall.Text = lib.DayRate(dayrate, weekday, unitrate);

            //36 Months

            txtnpra36sc.Text = lib.Npowera("Standing_Charge", lblProfile.Text, lblRegion.Text, lblNpwer.Text, "3", cmonth, myload);
           dayrate= lib.Npowera("Day_Units", lblProfile.Text, lblRegion.Text, lblNpwer.Text, "3", cmonth, myload);
            txtnpra36night.Text = lib.Npowera("Night_Units", lblProfile.Text, lblRegion.Text, lblNpwer.Text, "3", cmonth, myload);
            txtnpra36ew.Text = lib.Npowera("Weekday_Units", lblProfile.Text, lblRegion.Text, lblNpwer.Text, "3", cmonth, myload);

            unitrate = lib.Npowera("All_Units", lblProfile.Text, lblRegion.Text, lblNpwer.Text, "3", cmonth, myload);
            txtnpra36other.Text = lib.Npowera("Other_Units", lblProfile.Text, lblRegion.Text, lblNpwer.Text, "3", cmonth, myload);
            lblnpra36program.Text = " Npower " + lib.Npowera("book", lblProfile.Text, lblRegion.Text, lblNpwer.Text, "3", cmonth, myload) + "For three  year";

            txtnpra36day.Text = lib.DayRate(dayrate, weekday, unitrate);

            //36 Months

            txtnpra36scall.Text = lib.Npowera("Standing_Charge", lblProfile.Text, lblRegion.Text, lblNpwer.Text, "3", cmonth, myload);
           dayrate = lib.Npowera("Day_Units", lblProfile.Text, lblRegion.Text, lblNpwer.Text, "3", cmonth, myload);
            txtnpra36nightall.Text = lib.Npowera("Night_Units", lblProfile.Text, lblRegion.Text, lblNpwer.Text, "3", cmonth, myload);
            txtnpra36ewall.Text = lib.Npowera("Weekday_Units", lblProfile.Text, lblRegion.Text, lblNpwer.Text, "3", cmonth, myload);

          unitrate = lib.Npowera("All_Units", lblProfile.Text, lblRegion.Text, lblNpwer.Text, "3", cmonth, myload);
            txtnpra36otherall.Text = lib.Npowera("Other_Units", lblProfile.Text, lblRegion.Text, lblNpwer.Text, "3", cmonth, myload);
            lblnpra36programall.Text = " Npower " + lib.Npowera("book", lblProfile.Text, lblRegion.Text, lblNpwer.Text, "3", cmonth, myload) + "For three  year";

            txtnpra36dayall.Text = lib.DayRate(dayrate, weekday, unitrate);


            // Tooltip

            txtnpra12sc.ToolTip = lib.Npowera("Standing_Charge", lblProfile.Text, lblRegion.Text, lblNpwer.Text, "1", cmonth, myload);
            dayrate = lib.Npowera("Day_Units", lblProfile.Text, lblRegion.Text, lblNpwer.Text, "1", cmonth, myload);
            txtnpra12night.ToolTip = lib.Npowera("Night_Units", lblProfile.Text, lblRegion.Text, lblNpwer.Text, "1", cmonth, myload);
            txtnpra12ew.ToolTip = lib.Npowera("Weekday_Units", lblProfile.Text, lblRegion.Text, lblNpwer.Text, "1", cmonth, myload);

            unitrate= lib.Npowera("All_Units", lblProfile.Text, lblRegion.Text, lblNpwer.Text, "1", cmonth, myload);
            txtnpra12other.ToolTip = lib.Npowera("Other_Units", lblProfile.Text, lblRegion.Text, lblNpwer.Text, "1", cmonth, myload);
            lblnpra12program.ToolTip = " Npower " + lib.Npowera("book", lblProfile.Text, lblRegion.Text, lblNpwer.Text, "1", cmonth, myload) + "For one year";

            txtnpra12day.ToolTip = lib.DayRate(dayrate, weekday, unitrate);


            // 12 Months all

            txtnpra12scall.ToolTip = lib.Npowera("Standing_Charge", lblProfile.Text, lblRegion.Text, lblNpwer.Text, "1", cmonth, myload);
            dayrate= lib.Npowera("Day_Units", lblProfile.Text, lblRegion.Text, lblNpwer.Text, "1", cmonth, myload);
            txtnpra12nightall.ToolTip = lib.Npowera("Night_Units", lblProfile.Text, lblRegion.Text, lblNpwer.Text, "1", cmonth, myload);
            txtnpra12ewall.ToolTip = lib.Npowera("Weekday_Units", lblProfile.Text, lblRegion.Text, lblNpwer.Text, "1", cmonth, myload);

           unitrate = lib.Npowera("All_Units", lblProfile.Text, lblRegion.Text, lblNpwer.Text, "1", cmonth, myload);
            txtnpra12otherall.ToolTip = lib.Npowera("Other_Units", lblProfile.Text, lblRegion.Text, lblNpwer.Text, "1", cmonth, myload);
            lblnpra12programall.ToolTip = " Npower " + lib.Npowera("book", lblProfile.Text, lblRegion.Text, lblNpwer.Text, "1", cmonth, myload) + "For one year";

            txtnpra12dayall.ToolTip = lib.DayRate(dayrate, weekday, unitrate);
            // 24 Months

            txtnpra24sc.ToolTip = lib.Npowera("Standing_Charge", lblProfile.Text, lblRegion.Text, lblNpwer.Text, "2", cmonth, myload);
           dayrate= lib.Npowera("Day_Units", lblProfile.Text, lblRegion.Text, lblNpwer.Text, "2", cmonth, myload);
            txtnpra24night.ToolTip = lib.Npowera("Night_Units", lblProfile.Text, lblRegion.Text, lblNpwer.Text, "2", cmonth, myload);
            txtnpra24ew.ToolTip = lib.Npowera("Weekday_Units", lblProfile.Text, lblRegion.Text, lblNpwer.Text, "2", cmonth, myload);

             unitrate = lib.Npowera("All_Units", lblProfile.Text, lblRegion.Text, lblNpwer.Text, "2", cmonth, myload);
            txtnpra24other.ToolTip = lib.Npowera("Other_Units", lblProfile.Text, lblRegion.Text, lblNpwer.Text, "2", cmonth, myload);
            lblnpra24program.ToolTip = " Npower " + lib.Npowera("book", lblProfile.Text, lblRegion.Text, lblNpwer.Text, "2", cmonth, myload) + "For two year";
            txtnpra24day.ToolTip = lib.DayRate(dayrate, weekday, unitrate);





            // 24 Months all

            txtnpra24scall.ToolTip = lib.Npowera("Standing_Charge", lblProfile.Text, lblRegion.Text, lblNpwer.Text, "2", cmonth, myload);
           dayrate = lib.Npowera("Day_Units", lblProfile.Text, lblRegion.Text, lblNpwer.Text, "2", cmonth, myload);
            txtnpra24nightall.ToolTip = lib.Npowera("Night_Units", lblProfile.Text, lblRegion.Text, lblNpwer.Text, "2", cmonth, myload);
            txtnpra24ewall.ToolTip = lib.Npowera("Weekday_Units", lblProfile.Text, lblRegion.Text, lblNpwer.Text, "2", cmonth, myload);

            unitrate= lib.Npowera("All_Units", lblProfile.Text, lblRegion.Text, lblNpwer.Text, "2", cmonth, myload);
            txtnpra24otherall.ToolTip = lib.Npowera("Other_Units", lblProfile.Text, lblRegion.Text, lblNpwer.Text, "2", cmonth, myload);
            lblnpra24programall.ToolTip = " Npower " + lib.Npowera("book", lblProfile.Text, lblRegion.Text, lblNpwer.Text, "2", cmonth, myload) + "For two year";
            txtnpra24dayall.ToolTip = lib.DayRate(dayrate, weekday, unitrate);

            //36 Months

            txtnpra36sc.ToolTip = lib.Npowera("Standing_Charge", lblProfile.Text, lblRegion.Text, lblNpwer.Text, "3", cmonth, myload);
           dayrate= lib.Npowera("Day_Units", lblProfile.Text, lblRegion.Text, lblNpwer.Text, "3", cmonth, myload);
            txtnpra36night.ToolTip = lib.Npowera("Night_Units", lblProfile.Text, lblRegion.Text, lblNpwer.Text, "3", cmonth, myload);
            txtnpra36ew.ToolTip = lib.Npowera("Weekday_Units", lblProfile.Text, lblRegion.Text, lblNpwer.Text, "3", cmonth, myload);

            unitrate= lib.Npowera("All_Units", lblProfile.Text, lblRegion.Text, lblNpwer.Text, "3", cmonth, myload);
            txtnpra36other.ToolTip = lib.Npowera("Other_Units", lblProfile.Text, lblRegion.Text, lblNpwer.Text, "3", cmonth, myload);
            lblnpra36program.ToolTip = " Npower " + lib.Npowera("book", lblProfile.Text, lblRegion.Text, lblNpwer.Text, "3", cmonth, myload) + "For three  year";
            txtnpra36day.ToolTip = lib.DayRate(dayrate, weekday, unitrate);
            //36 Months

            txtnpra36scall.ToolTip = lib.Npowera("Standing_Charge", lblProfile.Text, lblRegion.Text, lblNpwer.Text, "3", cmonth, myload);
           dayrate = lib.Npowera("Day_Units", lblProfile.Text, lblRegion.Text, lblNpwer.Text, "3", cmonth, myload);
            txtnpra36nightall.ToolTip = lib.Npowera("Night_Units", lblProfile.Text, lblRegion.Text, lblNpwer.Text, "3", cmonth, myload);
            txtnpra36ewall.ToolTip = lib.Npowera("Weekday_Units", lblProfile.Text, lblRegion.Text, lblNpwer.Text, "3", cmonth, myload);

            unitrate = lib.Npowera("All_Units", lblProfile.Text, lblRegion.Text, lblNpwer.Text, "3", cmonth, myload);
            txtnpra36otherall.ToolTip = lib.Npowera("Other_Units", lblProfile.Text, lblRegion.Text, lblNpwer.Text, "3", cmonth, myload);
            lblnpra36programall.ToolTip = " Npower " + lib.Npowera("book", lblProfile.Text, lblRegion.Text, lblNpwer.Text, "3", cmonth, myload) + "For three  year";
            txtnpra36dayall.ToolTip = lib.DayRate(dayrate, weekday, unitrate);
        }


        #endregion

        #region SPE Calculation
        void Spe()
        {
            // string res = lib.Spe("StandingCharge", lblProfile.Text, lblRegion.Text, lblSPAMetertype.Text, lblDuration.Text, "Monthly Direct Debit", "Acquisition", lblEac.Text, winopen, winclose);
            // 12 Months


            string dayrate = "0";
            string weekday = "0";
            string unitrate = "0";

            int load = int.Parse(lblEac.Text);
            int myload = lib.GetSPELoad(load);
            string salestype = "Acquisition";
            if (lblCurrentSupplier.Text == "SPE")
            {
                salestype = "Renewal";
            }
            else
            {
                salestype = "Acquisition";
            }

            // 12 Months
            lblDuration.Text = "12";
            txtspe12sc.Text = lib.Spe("StandingCharge", lblProfile.Text, lblRegion.Text, lblSPAMetertype.Text, "12", "Monthly Direct Debit", salestype, myload, winopen, winclose);
            dayrate = lib.Spe("DayRate", lblProfile.Text, lblRegion.Text, lblSPAMetertype.Text, lblDuration.Text, "Monthly Direct Debit", salestype, myload, winopen, winclose);
            txtspe12night.Text = lib.Spe("NightRate", lblProfile.Text, lblRegion.Text, lblSPAMetertype.Text, lblDuration.Text, "Monthly Direct Debit", salestype, myload, winopen, winclose);
            txtspe12ew.Text = lib.Spe("EveningWeekendRate", lblProfile.Text, lblRegion.Text, lblSPAMetertype.Text, lblDuration.Text, "Monthly Direct Debit", salestype, myload, winopen, winclose);
         //   txtspe12offpeak.Text = lib.Spe("OffPeak", lblProfile.Text, lblRegion.Text, lblSPAMetertype.Text, lblDuration.Text, "Monthly Direct Debit", salestype, myload, winopen, winclose);
            unitrate = lib.Spe("UnitRate", lblProfile.Text, lblRegion.Text, lblSPAMetertype.Text, lblDuration.Text, "Monthly Direct Debit", salestype, myload, winopen, winclose);

            lblspe12program.Text = "SPE for" + lib.Spe("ContractDuration", lblProfile.Text, lblRegion.Text, lblSPAMetertype.Text, lblDuration.Text, "Monthly Direct Debit", salestype, myload, winopen, winclose) + "Months " + "for" + salestype;

            txtspe12day.Text = lib.DayRate(dayrate, weekday, unitrate);




            // 12 months  all

            txtspe12scall.Text = lib.Spe("StandingCharge", lblProfile.Text, lblRegion.Text, lblSPAMetertype.Text, "12", "Monthly Direct Debit", salestype, myload, winopen, winclose);
            dayrate = lib.Spe("DayRate", lblProfile.Text, lblRegion.Text, lblSPAMetertype.Text, lblDuration.Text, "Monthly Direct Debit", salestype, myload, winopen, winclose);
            txtspe12nightall.Text = lib.Spe("NightRate", lblProfile.Text, lblRegion.Text, lblSPAMetertype.Text, lblDuration.Text, "Monthly Direct Debit", salestype, myload, winopen, winclose);
            txtspe12ewall.Text = lib.Spe("EveningWeekendRate", lblProfile.Text, lblRegion.Text, lblSPAMetertype.Text, lblDuration.Text, "Monthly Direct Debit", salestype, myload, winopen, winclose);
          //  txtspe12offpeakall.Text = lib.Spe("OffPeak", lblProfile.Text, lblRegion.Text, lblSPAMetertype.Text, lblDuration.Text, "Monthly Direct Debit", salestype, myload, winopen, winclose);
            unitrate = lib.Spe("UnitRate", lblProfile.Text, lblRegion.Text, lblSPAMetertype.Text, lblDuration.Text, "Monthly Direct Debit", salestype, myload, winopen, winclose);

            lblspe12programall.Text = "SPE for" + lib.Spe("ContractDuration", lblProfile.Text, lblRegion.Text, lblSPAMetertype.Text, lblDuration.Text, "Monthly Direct Debit", salestype, myload, winopen, winclose) + "Months " + "for" + salestype;
            txtspe12dayall.Text = lib.DayRate(dayrate, weekday, unitrate);

            txtspe12dayall.Text = lib.DayRate(dayrate, weekday, unitrate);

            // 24 Months
          //  lblDuration.Text = "24";
            txtspe24sc.Text = lib.Spe("StandingCharge", lblProfile.Text, lblRegion.Text, lblSPAMetertype.Text, lblDuration.Text, "Monthly Direct Debit", "Acquisition", myload, winopen, winclose);
            dayrate = lib.Spe("DayRate", lblProfile.Text, lblRegion.Text, lblSPAMetertype.Text, lblDuration.Text, "Monthly Direct Debit", "Acquisition", myload, winopen, winclose);
            txtspe24night.Text = lib.Spe("NightRate", lblProfile.Text, lblRegion.Text, lblSPAMetertype.Text, lblDuration.Text, "Monthly Direct Debit", "Acquisition", myload, winopen, winclose);
            txtspe24ew.Text = lib.Spe("EveningWeekendRate", lblProfile.Text, lblRegion.Text, lblSPAMetertype.Text, lblDuration.Text, "Monthly Direct Debit", "Acquisition", myload, winopen, winclose);
          //  txtspe24offpeak.Text = lib.Spe("OffPeak", lblProfile.Text, lblRegion.Text, lblSPAMetertype.Text, lblDuration.Text, "Monthly Direct Debit", salestype, myload, winopen, winclose);
            unitrate = lib.Spe("UnitRate", lblProfile.Text, lblRegion.Text, lblSPAMetertype.Text, lblDuration.Text, "Monthly Direct Debit", "Acquisition", myload, winopen, winclose);

            lblspe24program.Text = "SPE for" + lib.Spe("ContractDuration", lblProfile.Text, lblRegion.Text, lblSPAMetertype.Text, lblDuration.Text, "Monthly Direct Debit", "Acquisition", myload, winopen, winclose) + "Months " + "for" + salestype;

            txtspe24day.Text = lib.DayRate(dayrate, weekday, unitrate);



            // 24 months all
            txtspe24scall.Text = lib.Spe("StandingCharge", lblProfile.Text, lblRegion.Text, lblSPAMetertype.Text, lblDuration.Text, "Monthly Direct Debit", "Acquisition", myload, winopen, winclose);
           dayrate = lib.Spe("DayRate", lblProfile.Text, lblRegion.Text, lblSPAMetertype.Text, lblDuration.Text, "Monthly Direct Debit", "Acquisition", myload, winopen, winclose);
            txtspe24nightall.Text = lib.Spe("NightRate", lblProfile.Text, lblRegion.Text, lblSPAMetertype.Text, lblDuration.Text, "Monthly Direct Debit", "Acquisition", myload, winopen, winclose);
            txtspe24ewall.Text = lib.Spe("EveningWeekendRate", lblProfile.Text, lblRegion.Text, lblSPAMetertype.Text, lblDuration.Text, "Monthly Direct Debit", "Acquisition", myload, winopen, winclose);
        //    txtspe24offpeakall.Text = lib.Spe("OffPeak", lblProfile.Text, lblRegion.Text, lblSPAMetertype.Text, lblDuration.Text, "Monthly Direct Debit", salestype, myload, winopen, winclose);
            unitrate = lib.Spe("UnitRate", lblProfile.Text, lblRegion.Text, lblSPAMetertype.Text, lblDuration.Text, "Monthly Direct Debit", "Acquisition", myload, winopen, winclose);
         //   txtspe24offpeak.Text = lib.Spe("OffPeak", lblProfile.Text, lblRegion.Text, lblSPAMetertype.Text, lblDuration.Text, "Monthly Direct Debit", salestype, myload, winopen, winclose);
            lblspe24programall.Text = "SPE for" + lib.Spe("ContractDuration", lblProfile.Text, lblRegion.Text, lblSPAMetertype.Text, lblDuration.Text, "Monthly Direct Debit", "Acquisition", myload, winopen, winclose) + "Months " + "for" + salestype;

            txtspe24dayall.Text = lib.DayRate(dayrate, weekday, unitrate);

            // 36 Months
            lblDuration.Text = "36";
            txtspe36sc.Text = lib.Spe("StandingCharge", lblProfile.Text, lblRegion.Text, lblSPAMetertype.Text, lblDuration.Text, "Monthly Direct Debit", "Acquisition", myload, winopen, winclose);
            dayrate = lib.Spe("DayRate", lblProfile.Text, lblRegion.Text, lblSPAMetertype.Text, lblDuration.Text, "Monthly Direct Debit", "Acquisition", myload, winopen, winclose);
            txtspe36night.Text = lib.Spe("NightRate", lblProfile.Text, lblRegion.Text, lblSPAMetertype.Text, lblDuration.Text, "Monthly Direct Debit", "Acquisition", myload, winopen, winclose);
            txtspe36ew.Text = lib.Spe("EveningWeekendRate", lblProfile.Text, lblRegion.Text, lblSPAMetertype.Text, lblDuration.Text, "Monthly Direct Debit", "Acquisition", myload, winopen, winclose);
        //    txtspe36offpeak.Text = lib.Spe("OffPeak", lblProfile.Text, lblRegion.Text, lblSPAMetertype.Text, lblDuration.Text, "Monthly Direct Debit", salestype, myload, winopen, winclose);
            unitrate = lib.Spe("UnitRate", lblProfile.Text, lblRegion.Text, lblSPAMetertype.Text, lblDuration.Text, "Monthly Direct Debit", "Acquisition", myload, winopen, winclose);

            lblspe36program.Text = "SPE for" + lib.Spe("ContractDuration", lblProfile.Text, lblRegion.Text, lblSPAMetertype.Text, lblDuration.Text, "Monthly Direct Debit", "Acquisition", myload, winopen, winclose) + "Months " + "for" + salestype;

            txtspe36day.Text = lib.DayRate(dayrate, weekday, unitrate);
            // 36 months all

            txtspe36scall.Text = lib.Spe("StandingCharge", lblProfile.Text, lblRegion.Text, lblSPAMetertype.Text, lblDuration.Text, "Monthly Direct Debit", "Acquisition", myload, winopen, winclose);
            dayrate = lib.Spe("DayRate", lblProfile.Text, lblRegion.Text, lblSPAMetertype.Text, lblDuration.Text, "Monthly Direct Debit", "Acquisition", myload, winopen, winclose);
            txtspe36nightall.Text = lib.Spe("NightRate", lblProfile.Text, lblRegion.Text, lblSPAMetertype.Text, lblDuration.Text, "Monthly Direct Debit", "Acquisition", myload, winopen, winclose);
            txtspe36ewall.Text = lib.Spe("EveningWeekendRate", lblProfile.Text, lblRegion.Text, lblSPAMetertype.Text, lblDuration.Text, "Monthly Direct Debit", "Acquisition", myload, winopen, winclose);
         //   txtspe36offpeakall.Text = lib.Spe("OffPeak", lblProfile.Text, lblRegion.Text, lblSPAMetertype.Text, lblDuration.Text, "Monthly Direct Debit", salestype, myload, winopen, winclose);
            unitrate = lib.Spe("UnitRate", lblProfile.Text, lblRegion.Text, lblSPAMetertype.Text, lblDuration.Text, "Monthly Direct Debit", "Acquisition", myload, winopen, winclose);

            lblspe36programall.Text = "SPE for" + lib.Spe("ContractDuration", lblProfile.Text, lblRegion.Text, lblSPAMetertype.Text, lblDuration.Text, "Monthly Direct Debit", "Acquisition", myload, winopen, winclose) + "Months " + "for" + salestype;

            txtspe36dayall.Text = lib.DayRate(dayrate, weekday, unitrate);

            // Tooltips

            // 12 Months
            lblDuration.Text = "12";
            txtspe12sc.ToolTip = lib.Spe("StandingCharge", lblProfile.Text, lblRegion.Text, lblSPAMetertype.Text, "12", "Monthly Direct Debit", salestype, myload, winopen, winclose);
            dayrate = lib.Spe("DayRate", lblProfile.Text, lblRegion.Text, lblSPAMetertype.Text, lblDuration.Text, "Monthly Direct Debit", salestype, myload, winopen, winclose);
            txtspe12night.ToolTip = lib.Spe("NightRate", lblProfile.Text, lblRegion.Text, lblSPAMetertype.Text, lblDuration.Text, "Monthly Direct Debit", salestype, myload, winopen, winclose);
            txtspe12ew.ToolTip = lib.Spe("EveningWeekendRate", lblProfile.Text, lblRegion.Text, lblSPAMetertype.Text, lblDuration.Text, "Monthly Direct Debit", salestype, myload, winopen, winclose);
        //    txtspe12offpeak.ToolTip = lib.Spe("OffPeak", lblProfile.Text, lblRegion.Text, lblSPAMetertype.Text, lblDuration.Text, "Monthly Direct Debit", salestype, myload, winopen, winclose);
            unitrate = lib.Spe("UnitRate", lblProfile.Text, lblRegion.Text, lblSPAMetertype.Text, lblDuration.Text, "Monthly Direct Debit", salestype, myload, winopen, winclose);

            lblspe12program.ToolTip = "SPE for" + lib.Spe("ContractDuration", lblProfile.Text, lblRegion.Text, lblSPAMetertype.Text, lblDuration.Text, "Monthly Direct Debit", salestype, myload, winopen, winclose) + "Months " + "for" + salestype;

            txtspe12day.ToolTip = lib.DayRate(dayrate, weekday, unitrate);



            // 12 months  all

            txtspe12scall.ToolTip = lib.Spe("StandingCharge", lblProfile.Text, lblRegion.Text, lblSPAMetertype.Text, "12", "Monthly Direct Debit", salestype, myload, winopen, winclose);
           dayrate = lib.Spe("DayRate", lblProfile.Text, lblRegion.Text, lblSPAMetertype.Text, lblDuration.Text, "Monthly Direct Debit", salestype, myload, winopen, winclose);
            txtspe12nightall.ToolTip = lib.Spe("NightRate", lblProfile.Text, lblRegion.Text, lblSPAMetertype.Text, lblDuration.Text, "Monthly Direct Debit", salestype, myload, winopen, winclose);
            txtspe12ewall.ToolTip = lib.Spe("EveningWeekendRate", lblProfile.Text, lblRegion.Text, lblSPAMetertype.Text, lblDuration.Text, "Monthly Direct Debit", salestype, myload, winopen, winclose);

         //   txtspe12offpeakall.ToolTip = lib.Spe("OffPeak", lblProfile.Text, lblRegion.Text, lblSPAMetertype.Text, lblDuration.Text, "Monthly Direct Debit", salestype, myload, winopen, winclose);
            unitrate = lib.Spe("UnitRate", lblProfile.Text, lblRegion.Text, lblSPAMetertype.Text, lblDuration.Text, "Monthly Direct Debit", salestype, myload, winopen, winclose);

            lblspe12programall.ToolTip = "SPE for" + lib.Spe("ContractDuration", lblProfile.Text, lblRegion.Text, lblSPAMetertype.Text, lblDuration.Text, "Monthly Direct Debit", salestype, myload, winopen, winclose) + "Months " + "for" + salestype;

            txtspe12dayall.ToolTip = lib.DayRate(dayrate, weekday, unitrate);
            // 24 Months
            lblDuration.Text = "24";
            txtspe24sc.ToolTip = lib.Spe("StandingCharge", lblProfile.Text, lblRegion.Text, lblSPAMetertype.Text, lblDuration.Text, "Monthly Direct Debit", "Acquisition", myload, winopen, winclose);
            dayrate = lib.Spe("DayRate", lblProfile.Text, lblRegion.Text, lblSPAMetertype.Text, lblDuration.Text, "Monthly Direct Debit", "Acquisition", myload, winopen, winclose);
            txtspe24night.ToolTip = lib.Spe("NightRate", lblProfile.Text, lblRegion.Text, lblSPAMetertype.Text, lblDuration.Text, "Monthly Direct Debit", "Acquisition", myload, winopen, winclose);
            txtspe24ew.ToolTip = lib.Spe("EveningWeekendRate", lblProfile.Text, lblRegion.Text, lblSPAMetertype.Text, lblDuration.Text, "Monthly Direct Debit", "Acquisition", myload, winopen, winclose);
          //  txtspe24offpeak.ToolTip = lib.Spe("OffPeak", lblProfile.Text, lblRegion.Text, lblSPAMetertype.Text, lblDuration.Text, "Monthly Direct Debit", salestype, myload, winopen, winclose);
            unitrate = lib.Spe("UnitRate", lblProfile.Text, lblRegion.Text, lblSPAMetertype.Text, lblDuration.Text, "Monthly Direct Debit", "Acquisition", myload, winopen, winclose);

            lblspe24program.ToolTip = "SPE for" + lib.Spe("ContractDuration", lblProfile.Text, lblRegion.Text, lblSPAMetertype.Text, lblDuration.Text, "Monthly Direct Debit", "Acquisition", myload, winopen, winclose) + "Months " + "for" + salestype;

            txtspe24day.ToolTip = lib.DayRate(dayrate, weekday, unitrate);
            // 24 months all
            txtspe24scall.ToolTip = lib.Spe("StandingCharge", lblProfile.Text, lblRegion.Text, lblSPAMetertype.Text, lblDuration.Text, "Monthly Direct Debit", "Acquisition", myload, winopen, winclose);
           dayrate= lib.Spe("DayRate", lblProfile.Text, lblRegion.Text, lblSPAMetertype.Text, lblDuration.Text, "Monthly Direct Debit", "Acquisition", myload, winopen, winclose);
            txtspe24nightall.ToolTip = lib.Spe("NightRate", lblProfile.Text, lblRegion.Text, lblSPAMetertype.Text, lblDuration.Text, "Monthly Direct Debit", "Acquisition", myload, winopen, winclose);
            txtspe24ewall.ToolTip = lib.Spe("EveningWeekendRate", lblProfile.Text, lblRegion.Text, lblSPAMetertype.Text, lblDuration.Text, "Monthly Direct Debit", "Acquisition", myload, winopen, winclose);
         //   txtspe24offpeakall.ToolTip = lib.Spe("OffPeak", lblProfile.Text, lblRegion.Text, lblSPAMetertype.Text, lblDuration.Text, "Monthly Direct Debit", salestype, myload, winopen, winclose);
            unitrate = lib.Spe("UnitRate", lblProfile.Text, lblRegion.Text, lblSPAMetertype.Text, lblDuration.Text, "Monthly Direct Debit", "Acquisition", myload, winopen, winclose);

            lblspe24programall.Text = "SPE for" + lib.Spe("ContractDuration", lblProfile.Text, lblRegion.Text, lblSPAMetertype.Text, lblDuration.Text, "Monthly Direct Debit", "Acquisition", myload, winopen, winclose) + "Months " + "for" + salestype;

            txtspe24dayall.ToolTip = lib.DayRate(dayrate, weekday, unitrate);
            // 36 Months
            lblDuration.Text = "36";
            txtspe36sc.ToolTip = lib.Spe("StandingCharge", lblProfile.Text, lblRegion.Text, lblSPAMetertype.Text, lblDuration.Text, "Monthly Direct Debit", "Acquisition", myload, winopen, winclose);
            dayrate = lib.Spe("DayRate", lblProfile.Text, lblRegion.Text, lblSPAMetertype.Text, lblDuration.Text, "Monthly Direct Debit", "Acquisition", myload, winopen, winclose);
            txtspe36night.ToolTip = lib.Spe("NightRate", lblProfile.Text, lblRegion.Text, lblSPAMetertype.Text, lblDuration.Text, "Monthly Direct Debit", "Acquisition", myload, winopen, winclose);
            txtspe36ew.ToolTip = lib.Spe("EveningWeekendRate", lblProfile.Text, lblRegion.Text, lblSPAMetertype.Text, lblDuration.Text, "Monthly Direct Debit", "Acquisition", myload, winopen, winclose);
           // txtspe36offpeak.ToolTip = lib.Spe("OffPeak", lblProfile.Text, lblRegion.Text, lblSPAMetertype.Text, lblDuration.Text, "Monthly Direct Debit", salestype, myload, winopen, winclose);
            unitrate = lib.Spe("UnitRate", lblProfile.Text, lblRegion.Text, lblSPAMetertype.Text, lblDuration.Text, "Monthly Direct Debit", "Acquisition", myload, winopen, winclose);

            lblspe36program.ToolTip = "SPE for" + lib.Spe("ContractDuration", lblProfile.Text, lblRegion.Text, lblSPAMetertype.Text, lblDuration.Text, "Monthly Direct Debit", "Acquisition", myload, winopen, winclose) + "Months " + "for" + salestype;
            txtspe36day.ToolTip = lib.DayRate(dayrate, weekday, unitrate);


            // 36 months all

            txtspe36scall.ToolTip = lib.Spe("StandingCharge", lblProfile.Text, lblRegion.Text, lblSPAMetertype.Text, lblDuration.Text, "Monthly Direct Debit", "Acquisition", myload, winopen, winclose);
           dayrate= lib.Spe("DayRate", lblProfile.Text, lblRegion.Text, lblSPAMetertype.Text, lblDuration.Text, "Monthly Direct Debit", "Acquisition", myload, winopen, winclose);
            txtspe36nightall.ToolTip = lib.Spe("NightRate", lblProfile.Text, lblRegion.Text, lblSPAMetertype.Text, lblDuration.Text, "Monthly Direct Debit", "Acquisition", myload, winopen, winclose);
            txtspe36ewall.ToolTip = lib.Spe("EveningWeekendRate", lblProfile.Text, lblRegion.Text, lblSPAMetertype.Text, lblDuration.Text, "Monthly Direct Debit", "Acquisition", myload, winopen, winclose);
          //  txtspe36offpeak.ToolTip = lib.Spe("OffPeak", lblProfile.Text, lblRegion.Text, lblSPAMetertype.Text, lblDuration.Text, "Monthly Direct Debit", salestype, myload, winopen, winclose);
            unitrate = lib.Spe("UnitRate", lblProfile.Text, lblRegion.Text, lblSPAMetertype.Text, lblDuration.Text, "Monthly Direct Debit", "Acquisition", myload, winopen, winclose);

            lblspe36programall.ToolTip = "SPE for" + lib.Spe("ContractDuration", lblProfile.Text, lblRegion.Text, lblSPAMetertype.Text, lblDuration.Text, "Monthly Direct Debit", "Acquisition", myload, winopen, winclose) + "Months " + "for" + salestype;
            txtspe36dayall.ToolTip = lib.DayRate(dayrate, weekday, unitrate);
        }


        #endregion

        #region Gulf calcultion
        void BindGulf()
        {

            string mymonth = DateTime.Today.Month.ToString();
            string myyear = DateTime.Today.Year.ToString();
            string startdate = lblStartdate.Text;
            DateTime dt = new DateTime();
            dt = Convert.ToDateTime(lblStartdate.Text);
            mymonth = dt.Month.ToString();
            myyear = dt.Year.ToString();

            txtgulfa12sc.Text = lib.Gulf("StandingCharge", lblProfile.Text, lblRegion.Text, lblGulfMetertype.Text, "12", lblStartdate.Text, lblEac.Text, lblELEPayment.Text);
            txtgulfa12day.Text = lib.Gulf("UnitDayRate", lblProfile.Text, lblRegion.Text, lblGulfMetertype.Text, "12", lblStartdate.Text, lblEac.Text, lblELEPayment.Text);
            txtgulfa12ew.Text = lib.Gulf("EveningandWeekendRate", lblProfile.Text, lblRegion.Text, lblGulfMetertype.Text, "12", lblStartdate.Text, lblEac.Text, lblELEPayment.Text);
            txtgulfa12night.Text = lib.Gulf("NightUnitRate", lblProfile.Text, lblRegion.Text, lblGulfMetertype.Text, "12", lblStartdate.Text, lblEac.Text, lblELEPayment.Text);
                      
            lblgulfa12program.Text = "Gulf Energy 1 Year " + lib.Gulf("ProductBundleBillDisplay", lblProfile.Text, lblRegion.Text, lblGulfMetertype.Text, "12", lblStartdate.Text, lblEac.Text, lblELEPayment.Text);

            txtgulfa12sc.ToolTip = lib.Gulf("StandingCharge", lblProfile.Text, lblRegion.Text, lblGulfMetertype.Text, "12", lblStartdate.Text, lblEac.Text, lblELEPayment.Text);
            txtgulfa12day.ToolTip = lib.Gulf("UnitDayRate", lblProfile.Text, lblRegion.Text, lblGulfMetertype.Text, "12", lblStartdate.Text, lblEac.Text, lblELEPayment.Text);
            txtgulfa12ew.ToolTip = lib.Gulf("EveningandWeekendRate", lblProfile.Text, lblRegion.Text, lblGulfMetertype.Text, "12", lblStartdate.Text, lblEac.Text, lblELEPayment.Text);
            txtgulfa12night.ToolTip = lib.Gulf("NightUnitRate", lblProfile.Text, lblRegion.Text, lblGulfMetertype.Text, "12", lblStartdate.Text, lblEac.Text, lblELEPayment.Text);

            lblgulfa12program.ToolTip = "Gulf Energy 1 Year " + lib.Gulf("ProductBundleBillDisplay", lblProfile.Text, lblRegion.Text, lblGulfMetertype.Text, "12", lblStartdate.Text, lblEac.Text, lblELEPayment.Text);


            txtgulfa12scall.Text = lib.Gulf("StandingCharge", lblProfile.Text, lblRegion.Text, lblGulfMetertype.Text, "12", lblStartdate.Text, lblEac.Text, lblELEPayment.Text);
            txtgulfa12dayall.Text = lib.Gulf("UnitDayRate", lblProfile.Text, lblRegion.Text, lblGulfMetertype.Text, "12", lblStartdate.Text, lblEac.Text, lblELEPayment.Text);
            txtgulfa12ewall.Text = lib.Gulf("EveningandWeekendRate", lblProfile.Text, lblRegion.Text, lblGulfMetertype.Text, "12", lblStartdate.Text, lblEac.Text, lblELEPayment.Text);
            txtgulfa12nightall.Text = lib.Gulf("NightUnitRate", lblProfile.Text, lblRegion.Text, lblGulfMetertype.Text, "12", lblStartdate.Text, lblEac.Text, lblELEPayment.Text);

            lblgulfa12programall.Text = "Gulf Energy 1 Year " + lib.Gulf("ProductBundleBillDisplay", lblProfile.Text, lblRegion.Text, lblGulfMetertype.Text, "12", lblStartdate.Text, lblEac.Text, lblELEPayment.Text);

            txtgulfa12scall.ToolTip = lib.Gulf("StandingCharge", lblProfile.Text, lblRegion.Text, lblGulfMetertype.Text, "12", lblStartdate.Text, lblEac.Text, lblELEPayment.Text);
            txtgulfa12dayall.ToolTip = lib.Gulf("UnitDayRate", lblProfile.Text, lblRegion.Text, lblGulfMetertype.Text, "12", lblStartdate.Text, lblEac.Text, lblELEPayment.Text);
            txtgulfa12ewall.ToolTip = lib.Gulf("EveningandWeekendRate", lblProfile.Text, lblRegion.Text, lblGulfMetertype.Text, "12", lblStartdate.Text, lblEac.Text, lblELEPayment.Text);
            txtgulfa12nightall.ToolTip = lib.Gulf("NightUnitRate", lblProfile.Text, lblRegion.Text, lblGulfMetertype.Text, "12", lblStartdate.Text, lblEac.Text, lblELEPayment.Text);

            lblgulfa12programall.ToolTip = "Gulf Energy 1 Year " + lib.Gulf("ProductBundleBillDisplay", lblProfile.Text, lblRegion.Text, lblGulfMetertype.Text, "12", lblStartdate.Text, lblEac.Text, lblELEPayment.Text);

            // 24  Months

            txtgulfa24sc.Text = lib.Gulf("StandingCharge", lblProfile.Text, lblRegion.Text, lblGulfMetertype.Text, "24", lblStartdate.Text, lblEac.Text, lblELEPayment.Text);
            txtgulfa24day.Text = lib.Gulf("UnitDayRate", lblProfile.Text, lblRegion.Text, lblGulfMetertype.Text, "24", lblStartdate.Text, lblEac.Text, lblELEPayment.Text);
            txtgulfa24ew.Text = lib.Gulf("EveningandWeekendRate", lblProfile.Text, lblRegion.Text, lblGulfMetertype.Text, "24", lblStartdate.Text, lblEac.Text, lblELEPayment.Text);
            txtgulfa24night.Text = lib.Gulf("NightUnitRate", lblProfile.Text, lblRegion.Text, lblGulfMetertype.Text, "24", lblStartdate.Text, lblEac.Text, lblELEPayment.Text);

            lblgulfa24program.Text = "Gulf Energy 1 Year " + lib.Gulf("ProductBundleBillDisplay", lblProfile.Text, lblRegion.Text, lblGulfMetertype.Text, "24", lblStartdate.Text, lblEac.Text, lblELEPayment.Text);

            txtgulfa24sc.ToolTip = lib.Gulf("StandingCharge", lblProfile.Text, lblRegion.Text, lblGulfMetertype.Text, "24", lblStartdate.Text, lblEac.Text, lblELEPayment.Text);
            txtgulfa24day.ToolTip = lib.Gulf("UnitDayRate", lblProfile.Text, lblRegion.Text, lblGulfMetertype.Text, "24", lblStartdate.Text, lblEac.Text, lblELEPayment.Text);
            txtgulfa24ew.ToolTip = lib.Gulf("EveningandWeekendRate", lblProfile.Text, lblRegion.Text, lblGulfMetertype.Text, "24", lblStartdate.Text, lblEac.Text, lblELEPayment.Text);
            txtgulfa24night.ToolTip = lib.Gulf("NightUnitRate", lblProfile.Text, lblRegion.Text, lblGulfMetertype.Text, "24", lblStartdate.Text, lblEac.Text, lblELEPayment.Text);

            lblgulfa24program.ToolTip = "Gulf Energy 2 Year " + lib.Gulf("ProductBundleBillDisplay", lblProfile.Text, lblRegion.Text, lblGulfMetertype.Text, "24", lblStartdate.Text, lblEac.Text, lblELEPayment.Text);


            txtgulfa24scall.Text = lib.Gulf("StandingCharge", lblProfile.Text, lblRegion.Text, lblGulfMetertype.Text, "24", lblStartdate.Text, lblEac.Text, lblELEPayment.Text);
            txtgulfa24dayall.Text = lib.Gulf("UnitDayRate", lblProfile.Text, lblRegion.Text, lblGulfMetertype.Text, "24", lblStartdate.Text, lblEac.Text, lblELEPayment.Text);
            txtgulfa24ewall.Text = lib.Gulf("EveningandWeekendRate", lblProfile.Text, lblRegion.Text, lblGulfMetertype.Text, "24", lblStartdate.Text, lblEac.Text, lblELEPayment.Text);
            txtgulfa24nightall.Text = lib.Gulf("NightUnitRate", lblProfile.Text, lblRegion.Text, lblGulfMetertype.Text, "24", lblStartdate.Text, lblEac.Text, lblELEPayment.Text);

            lblgulfa24programall.Text = "Gulf Energy 1 Year " + lib.Gulf("ProductBundleBillDisplay", lblProfile.Text, lblRegion.Text, lblGulfMetertype.Text, "24", lblStartdate.Text, lblEac.Text, lblELEPayment.Text);

            txtgulfa24scall.ToolTip = lib.Gulf("StandingCharge", lblProfile.Text, lblRegion.Text, lblGulfMetertype.Text, "24", lblStartdate.Text, lblEac.Text, lblELEPayment.Text);
            txtgulfa24dayall.ToolTip = lib.Gulf("UnitDayRate", lblProfile.Text, lblRegion.Text, lblGulfMetertype.Text, "24", lblStartdate.Text, lblEac.Text, lblELEPayment.Text);
            txtgulfa24ewall.ToolTip = lib.Gulf("EveningandWeekendRate", lblProfile.Text, lblRegion.Text, lblGulfMetertype.Text, "24", lblStartdate.Text, lblEac.Text, lblELEPayment.Text);
            txtgulfa24nightall.ToolTip = lib.Gulf("NightUnitRate", lblProfile.Text, lblRegion.Text, lblGulfMetertype.Text, "24", lblStartdate.Text, lblEac.Text, lblELEPayment.Text);

            lblgulfa24programall.ToolTip = "Gulf Energy 2 Year " + lib.Gulf("ProductBundleBillDisplay", lblProfile.Text, lblRegion.Text, lblGulfMetertype.Text, "24", lblStartdate.Text, lblEac.Text, lblELEPayment.Text);


            // 36 Months
            txtgulfa36sc.Text = lib.Gulf("StandingCharge", lblProfile.Text, lblRegion.Text, lblGulfMetertype.Text, "36", lblStartdate.Text, lblEac.Text, lblELEPayment.Text);
            txtgulfa36day.Text = lib.Gulf("UnitDayRate", lblProfile.Text, lblRegion.Text, lblGulfMetertype.Text, "36", lblStartdate.Text, lblEac.Text, lblELEPayment.Text);
            txtgulfa36ew.Text = lib.Gulf("EveningandWeekendRate", lblProfile.Text, lblRegion.Text, lblGulfMetertype.Text, "36", lblStartdate.Text, lblEac.Text, lblELEPayment.Text);
            txtgulfa36night.Text = lib.Gulf("NightUnitRate", lblProfile.Text, lblRegion.Text, lblGulfMetertype.Text, "36", lblStartdate.Text, lblEac.Text, lblELEPayment.Text);

            lblgulfa36program.Text = "Gulf Energy 3 Year " + lib.Gulf("ProductBundleBillDisplay", lblProfile.Text, lblRegion.Text, lblGulfMetertype.Text, "36", lblStartdate.Text, lblEac.Text, lblELEPayment.Text);

            txtgulfa36sc.ToolTip = lib.Gulf("StandingCharge", lblProfile.Text, lblRegion.Text, lblGulfMetertype.Text, "36", lblStartdate.Text, lblEac.Text, lblELEPayment.Text);
            txtgulfa36day.ToolTip = lib.Gulf("UnitDayRate", lblProfile.Text, lblRegion.Text, lblGulfMetertype.Text, "36", lblStartdate.Text, lblEac.Text, lblELEPayment.Text);
            txtgulfa36ew.ToolTip = lib.Gulf("EveningandWeekendRate", lblProfile.Text, lblRegion.Text, lblGulfMetertype.Text, "36", lblStartdate.Text, lblEac.Text, lblELEPayment.Text);
            txtgulfa36night.ToolTip = lib.Gulf("NightUnitRate", lblProfile.Text, lblRegion.Text, lblGulfMetertype.Text, "36", lblStartdate.Text, lblEac.Text, lblELEPayment.Text);

            lblgulfa36program.ToolTip = "Gulf Energy 3 Year " + lib.Gulf("ProductBundleBillDisplay", lblProfile.Text, lblRegion.Text, lblGulfMetertype.Text, "36", lblStartdate.Text, lblEac.Text, lblELEPayment.Text);


            txtgulfa36scall.Text = lib.Gulf("StandingCharge", lblProfile.Text, lblRegion.Text, lblGulfMetertype.Text, "36", lblStartdate.Text, lblEac.Text, lblELEPayment.Text);
            txtgulfa36dayall.Text = lib.Gulf("UnitDayRate", lblProfile.Text, lblRegion.Text, lblGulfMetertype.Text, "36", lblStartdate.Text, lblEac.Text, lblELEPayment.Text);
            txtgulfa36ewall.Text = lib.Gulf("EveningandWeekendRate", lblProfile.Text, lblRegion.Text, lblGulfMetertype.Text, "36", lblStartdate.Text, lblEac.Text, lblELEPayment.Text);
            txtgulfa36nightall.Text = lib.Gulf("NightUnitRate", lblProfile.Text, lblRegion.Text, lblGulfMetertype.Text, "36", lblStartdate.Text, lblEac.Text, lblELEPayment.Text);

            lblgulfa36programall.Text = "Gulf Energy 3 Year " + lib.Gulf("ProductBundleBillDisplay", lblProfile.Text, lblRegion.Text, lblGulfMetertype.Text, "36", lblStartdate.Text, lblEac.Text, lblELEPayment.Text);

            txtgulfa36scall.ToolTip = lib.Gulf("StandingCharge", lblProfile.Text, lblRegion.Text, lblGulfMetertype.Text, "36", lblStartdate.Text, lblEac.Text, lblELEPayment.Text);
            txtgulfa36dayall.ToolTip = lib.Gulf("UnitDayRate", lblProfile.Text, lblRegion.Text, lblGulfMetertype.Text, "36", lblStartdate.Text, lblEac.Text, lblELEPayment.Text);
            txtgulfa36ewall.ToolTip = lib.Gulf("EveningandWeekendRate", lblProfile.Text, lblRegion.Text, lblGulfMetertype.Text, "36", lblStartdate.Text, lblEac.Text, lblELEPayment.Text);
            txtgulfa36nightall.ToolTip = lib.Gulf("NightUnitRate", lblProfile.Text, lblRegion.Text, lblGulfMetertype.Text, "36", lblStartdate.Text, lblEac.Text, lblELEPayment.Text);

            lblgulfa36programall.ToolTip = "Gulf Energy 3 Year " + lib.Gulf("ProductBundleBillDisplay", lblProfile.Text, lblRegion.Text, lblGulfMetertype.Text, "36", lblStartdate.Text, lblEac.Text, lblELEPayment.Text);


            // 48 Months
            txtgulfa48sc.Text = lib.Gulf("StandingCharge", lblProfile.Text, lblRegion.Text, lblGulfMetertype.Text, "48", lblStartdate.Text, lblEac.Text, lblELEPayment.Text);
            txtgulfa48day.Text = lib.Gulf("UnitDayRate", lblProfile.Text, lblRegion.Text, lblGulfMetertype.Text, "48", lblStartdate.Text, lblEac.Text, lblELEPayment.Text);
            txtgulfa48ew.Text = lib.Gulf("EveningandWeekendRate", lblProfile.Text, lblRegion.Text, lblGulfMetertype.Text, "48", lblStartdate.Text, lblEac.Text, lblELEPayment.Text);
            txtgulfa48night.Text = lib.Gulf("NightUnitRate", lblProfile.Text, lblRegion.Text, lblGulfMetertype.Text, "48", lblStartdate.Text, lblEac.Text, lblELEPayment.Text);

            lblgulfa48program.Text = "Gulf Energy 4 Year " + lib.Gulf("ProductBundleBillDisplay", lblProfile.Text, lblRegion.Text, lblGulfMetertype.Text, "48", lblStartdate.Text, lblEac.Text, lblELEPayment.Text);

            txtgulfa48sc.ToolTip = lib.Gulf("StandingCharge", lblProfile.Text, lblRegion.Text, lblGulfMetertype.Text, "48", lblStartdate.Text, lblEac.Text, lblELEPayment.Text);
            txtgulfa48day.ToolTip = lib.Gulf("UnitDayRate", lblProfile.Text, lblRegion.Text, lblGulfMetertype.Text, "48", lblStartdate.Text, lblEac.Text, lblELEPayment.Text);
            txtgulfa48ew.ToolTip = lib.Gulf("EveningandWeekendRate", lblProfile.Text, lblRegion.Text, lblGulfMetertype.Text, "48", lblStartdate.Text, lblEac.Text, lblELEPayment.Text);
            txtgulfa48night.ToolTip = lib.Gulf("NightUnitRate", lblProfile.Text, lblRegion.Text, lblGulfMetertype.Text, "48", lblStartdate.Text, lblEac.Text, lblELEPayment.Text);

            lblgulfa48program.ToolTip = "Gulf Energy 4 Year " + lib.Gulf("ProductBundleBillDisplay", lblProfile.Text, lblRegion.Text, lblGulfMetertype.Text, "48", lblStartdate.Text, lblEac.Text, lblELEPayment.Text);


            txtgulfa48scall.Text = lib.Gulf("StandingCharge", lblProfile.Text, lblRegion.Text, lblGulfMetertype.Text, "48", lblStartdate.Text, lblEac.Text, lblELEPayment.Text);
            txtgulfa48dayall.Text = lib.Gulf("UnitDayRate", lblProfile.Text, lblRegion.Text, lblGulfMetertype.Text, "48", lblStartdate.Text, lblEac.Text, lblELEPayment.Text);
            txtgulfa48ewall.Text = lib.Gulf("EveningandWeekendRate", lblProfile.Text, lblRegion.Text, lblGulfMetertype.Text, "48", lblStartdate.Text, lblEac.Text, lblELEPayment.Text);
            txtgulfa48nightall.Text = lib.Gulf("NightUnitRate", lblProfile.Text, lblRegion.Text, lblGulfMetertype.Text, "48", lblStartdate.Text, lblEac.Text, lblELEPayment.Text);

            lblgulfa48programall.Text = "Gulf Energy 4 Year " + lib.Gulf("ProductBundleBillDisplay", lblProfile.Text, lblRegion.Text, lblGulfMetertype.Text, "48", lblStartdate.Text, lblEac.Text, lblELEPayment.Text);

            txtgulfa48scall.ToolTip = lib.Gulf("StandingCharge", lblProfile.Text, lblRegion.Text, lblGulfMetertype.Text, "48", lblStartdate.Text, lblEac.Text, lblELEPayment.Text);
            txtgulfa48dayall.ToolTip = lib.Gulf("UnitDayRate", lblProfile.Text, lblRegion.Text, lblGulfMetertype.Text, "48", lblStartdate.Text, lblEac.Text, lblELEPayment.Text);
            txtgulfa48ewall.ToolTip = lib.Gulf("EveningandWeekendRate", lblProfile.Text, lblRegion.Text, lblGulfMetertype.Text, "48", lblStartdate.Text, lblEac.Text, lblELEPayment.Text);
            txtgulfa48nightall.ToolTip = lib.Gulf("NightUnitRate", lblProfile.Text, lblRegion.Text, lblGulfMetertype.Text, "48", lblStartdate.Text, lblEac.Text, lblELEPayment.Text);

            lblgulfa48programall.ToolTip = "Gulf Energy 4 Year " + lib.Gulf("ProductBundleBillDisplay", lblProfile.Text, lblRegion.Text, lblGulfMetertype.Text, "48", lblStartdate.Text, lblEac.Text, lblELEPayment.Text);


            // 60 Months

            txtgulfa60sc.Text = lib.Gulf("StandingCharge", lblProfile.Text, lblRegion.Text, lblGulfMetertype.Text, "60", lblStartdate.Text, lblEac.Text, lblELEPayment.Text);
            txtgulfa60day.Text = lib.Gulf("UnitDayRate", lblProfile.Text, lblRegion.Text, lblGulfMetertype.Text, "60", lblStartdate.Text, lblEac.Text, lblELEPayment.Text);
            txtgulfa60ew.Text = lib.Gulf("EveningandWeekendRate", lblProfile.Text, lblRegion.Text, lblGulfMetertype.Text, "60", lblStartdate.Text, lblEac.Text, lblELEPayment.Text);
            txtgulfa60night.Text = lib.Gulf("NightUnitRate", lblProfile.Text, lblRegion.Text, lblGulfMetertype.Text, "60", lblStartdate.Text, lblEac.Text, lblELEPayment.Text);

            lblgulfa60program.Text = "Gulf Energy 5 Year " + lib.Gulf("ProductBundleBillDisplay", lblProfile.Text, lblRegion.Text, lblGulfMetertype.Text, "60", lblStartdate.Text, lblEac.Text, lblELEPayment.Text);

            txtgulfa60sc.ToolTip = lib.Gulf("StandingCharge", lblProfile.Text, lblRegion.Text, lblGulfMetertype.Text, "60", lblStartdate.Text, lblEac.Text, lblELEPayment.Text);
            txtgulfa60day.ToolTip = lib.Gulf("UnitDayRate", lblProfile.Text, lblRegion.Text, lblGulfMetertype.Text, "60", lblStartdate.Text, lblEac.Text, lblELEPayment.Text);
            txtgulfa60ew.ToolTip = lib.Gulf("EveningandWeekendRate", lblProfile.Text, lblRegion.Text, lblGulfMetertype.Text, "60", lblStartdate.Text, lblEac.Text, lblELEPayment.Text);
            txtgulfa60night.ToolTip = lib.Gulf("NightUnitRate", lblProfile.Text, lblRegion.Text, lblGulfMetertype.Text, "60", lblStartdate.Text, lblEac.Text, lblELEPayment.Text);

            lblgulfa60program.ToolTip = "Gulf Energy 5 Year " + lib.Gulf("ProductBundleBillDisplay", lblProfile.Text, lblRegion.Text, lblGulfMetertype.Text, "60", lblStartdate.Text, lblEac.Text, lblELEPayment.Text);


            txtgulfa60scall.Text = lib.Gulf("StandingCharge", lblProfile.Text, lblRegion.Text, lblGulfMetertype.Text, "60", lblStartdate.Text, lblEac.Text, lblELEPayment.Text);
            txtgulfa60dayall.Text = lib.Gulf("UnitDayRate", lblProfile.Text, lblRegion.Text, lblGulfMetertype.Text, "60", lblStartdate.Text, lblEac.Text, lblELEPayment.Text);
            txtgulfa60ewall.Text = lib.Gulf("EveningandWeekendRate", lblProfile.Text, lblRegion.Text, lblGulfMetertype.Text, "60", lblStartdate.Text, lblEac.Text, lblELEPayment.Text);
            txtgulfa60nightall.Text = lib.Gulf("NightUnitRate", lblProfile.Text, lblRegion.Text, lblGulfMetertype.Text, "60", lblStartdate.Text, lblEac.Text, lblELEPayment.Text);

            lblgulfa60programall.Text = "Gulf Energy 5 Year " + lib.Gulf("ProductBundleBillDisplay", lblProfile.Text, lblRegion.Text, lblGulfMetertype.Text, "60", lblStartdate.Text, lblEac.Text, lblELEPayment.Text);

            txtgulfa60scall.ToolTip = lib.Gulf("StandingCharge", lblProfile.Text, lblRegion.Text, lblGulfMetertype.Text, "60", lblStartdate.Text, lblEac.Text, lblELEPayment.Text);
            txtgulfa60dayall.ToolTip = lib.Gulf("UnitDayRate", lblProfile.Text, lblRegion.Text, lblGulfMetertype.Text, "60", lblStartdate.Text, lblEac.Text, lblELEPayment.Text);
            txtgulfa60ewall.ToolTip = lib.Gulf("EveningandWeekendRate", lblProfile.Text, lblRegion.Text, lblGulfMetertype.Text, "60", lblStartdate.Text, lblEac.Text, lblELEPayment.Text);
            txtgulfa60nightall.ToolTip = lib.Gulf("NightUnitRate", lblProfile.Text, lblRegion.Text, lblGulfMetertype.Text, "60", lblStartdate.Text, lblEac.Text, lblELEPayment.Text);

            lblgulfa60programall.ToolTip = "Gulf Energy 5 Year " + lib.Gulf("ProductBundleBillDisplay", lblProfile.Text, lblRegion.Text, lblGulfMetertype.Text, "60", lblStartdate.Text, lblEac.Text, lblELEPayment.Text);








        }

        #endregion


        #region yu energy calculation 
        void Bindyuee()
        {

            string mymonth = DateTime.Today.Month.ToString();
            string myyear = DateTime.Today.Year.ToString();
            string startdate = lblStartdate.Text;
            DateTime dt = new DateTime();
            dt = Convert.ToDateTime(lblStartdate.Text);
            mymonth = dt.Month.ToString();
            myyear = dt.Year.ToString();
            string salestype = "Acquisition";
            string greenenergy = "True";
            string PaymentMethod = "";
            if (lblCurrentSupplier.Text != "YU")
            {
                salestype = "Acquisition";
            }
            if (lblCurrentSupplier.Text == "YU")
            {
                salestype = "Renewal";
            }

            txtyuea12sc.Text = lib.Yuee("StandingCharge", lblProfile.Text, lblRegion.Text, lblyuMetertype.Text, "12", lblStartdate.Text, lblEac.Text, PaymentMethod, salestype, greenenergy);
            txtyuea12day.Text = lib.Yuee("DayRate", lblProfile.Text, lblRegion.Text, lblyuMetertype.Text, "12", lblStartdate.Text, lblEac.Text, PaymentMethod, salestype, greenenergy);
            txtyuea12ew.Text = lib.Yuee("EveningWeekendRate", lblProfile.Text, lblRegion.Text, lblyuMetertype.Text, "12", lblStartdate.Text, lblEac.Text, PaymentMethod, salestype, greenenergy);
            txtyuea12night.Text = lib.Yuee("NightRate", lblProfile.Text, lblRegion.Text, lblyuMetertype.Text, "12", lblStartdate.Text, lblEac.Text, PaymentMethod, salestype, greenenergy);

            lblyuea12program.Text = "Yu Energy 1 Year " + lib.Yuee("ProductName", lblProfile.Text, lblRegion.Text, lblyuMetertype.Text, "12", lblStartdate.Text, lblEac.Text, PaymentMethod, salestype, greenenergy);

            txtyuea12sc.ToolTip = lib.Yuee("StandingCharge", lblProfile.Text, lblRegion.Text, lblyuMetertype.Text, "12", lblStartdate.Text, lblEac.Text, PaymentMethod, salestype, greenenergy);
            txtyuea12day.ToolTip = lib.Yuee("DayRate", lblProfile.Text, lblRegion.Text, lblyuMetertype.Text, "12", lblStartdate.Text, lblEac.Text, PaymentMethod, salestype, greenenergy);
            txtyuea12ew.ToolTip = lib.Yuee("EveningWeekendRate", lblProfile.Text, lblRegion.Text, lblyuMetertype.Text, "12", lblStartdate.Text, lblEac.Text, PaymentMethod, salestype, greenenergy);
            txtyuea12night.ToolTip = lib.Yuee("NightRate", lblProfile.Text, lblRegion.Text, lblyuMetertype.Text, "12", lblStartdate.Text, lblEac.Text, PaymentMethod, salestype, greenenergy);

            lblyuea12program.ToolTip = "Yu Energy 1 Year " + lib.Yuee("ProductName", lblProfile.Text, lblRegion.Text, lblyuMetertype.Text, "12", lblStartdate.Text, lblEac.Text, PaymentMethod, salestype, greenenergy);

            //24 months
            txtyuea24sc.Text = lib.Yuee("StandingCharge", lblProfile.Text, lblRegion.Text, lblyuMetertype.Text, "24", lblStartdate.Text, lblEac.Text, PaymentMethod, salestype, greenenergy);
            txtyuea24day.Text = lib.Yuee("DayRate", lblProfile.Text, lblRegion.Text, lblyuMetertype.Text, "24", lblStartdate.Text, lblEac.Text, PaymentMethod, salestype, greenenergy);
            txtyuea24ew.Text = lib.Yuee("EveningWeekendRate", lblProfile.Text, lblRegion.Text, lblyuMetertype.Text, "24", lblStartdate.Text, lblEac.Text, PaymentMethod, salestype, greenenergy);
            txtyuea24night.Text = lib.Yuee("NightRate", lblProfile.Text, lblRegion.Text, lblyuMetertype.Text, "24", lblStartdate.Text, lblEac.Text, PaymentMethod, salestype, greenenergy);

            lblyuea24program.Text = "Yu Energy 2 Year " + lib.Yuee("ProductName", lblProfile.Text, lblRegion.Text, lblyuMetertype.Text, "24", lblStartdate.Text, lblEac.Text, PaymentMethod, salestype, greenenergy);

            txtyuea24sc.ToolTip = lib.Yuee("StandingCharge", lblProfile.Text, lblRegion.Text, lblyuMetertype.Text, "24", lblStartdate.Text, lblEac.Text, PaymentMethod, salestype, greenenergy);
            txtyuea24day.ToolTip = lib.Yuee("DayRate", lblProfile.Text, lblRegion.Text, lblyuMetertype.Text, "24", lblStartdate.Text, lblEac.Text, PaymentMethod, salestype, greenenergy);
            txtyuea24ew.ToolTip = lib.Yuee("EveningWeekendRate", lblProfile.Text, lblRegion.Text, lblyuMetertype.Text, "24", lblStartdate.Text, lblEac.Text, PaymentMethod, salestype, greenenergy);
            txtyuea24night.ToolTip = lib.Yuee("NightRate", lblProfile.Text, lblRegion.Text, lblyuMetertype.Text, "24", lblStartdate.Text, lblEac.Text, PaymentMethod, salestype, greenenergy);

            lblyuea24program.ToolTip = "Yu Energy 2 Year " + lib.Yuee("ProductName", lblProfile.Text, lblRegion.Text, lblyuMetertype.Text, "24", lblStartdate.Text, lblEac.Text, PaymentMethod, salestype, greenenergy);
            // 36 months

            txtyuea36sc.Text = lib.Yuee("StandingCharge", lblProfile.Text, lblRegion.Text, lblyuMetertype.Text, "36", lblStartdate.Text, lblEac.Text, PaymentMethod, salestype, greenenergy);
            txtyuea36day.Text = lib.Yuee("DayRate", lblProfile.Text, lblRegion.Text, lblyuMetertype.Text, "36", lblStartdate.Text, lblEac.Text, PaymentMethod, salestype, greenenergy);
            txtyuea36ew.Text = lib.Yuee("EveningWeekendRate", lblProfile.Text, lblRegion.Text, lblyuMetertype.Text, "36", lblStartdate.Text, lblEac.Text, PaymentMethod, salestype, greenenergy);
            txtyuea36night.Text = lib.Yuee("NightRate", lblProfile.Text, lblRegion.Text, lblyuMetertype.Text, "36", lblStartdate.Text, lblEac.Text, PaymentMethod, salestype, greenenergy);

            lblyuea36program.Text = "Yu Energy 3 Year " + lib.Yuee("ProductName", lblProfile.Text, lblRegion.Text, lblyuMetertype.Text, "36", lblStartdate.Text, lblEac.Text, PaymentMethod, salestype, greenenergy);

            txtyuea36sc.ToolTip = lib.Yuee("StandingCharge", lblProfile.Text, lblRegion.Text, lblyuMetertype.Text, "36", lblStartdate.Text, lblEac.Text, PaymentMethod, salestype, greenenergy);
            txtyuea36day.ToolTip = lib.Yuee("DayRate", lblProfile.Text, lblRegion.Text, lblyuMetertype.Text, "36", lblStartdate.Text, lblEac.Text, PaymentMethod, salestype, greenenergy);
            txtyuea36ew.ToolTip = lib.Yuee("EveningWeekendRate", lblProfile.Text, lblRegion.Text, lblyuMetertype.Text, "36", lblStartdate.Text, lblEac.Text, PaymentMethod, salestype, greenenergy);
            txtyuea36night.ToolTip = lib.Yuee("NightRate", lblProfile.Text, lblRegion.Text, lblyuMetertype.Text, "36", lblStartdate.Text, lblEac.Text, PaymentMethod, salestype, greenenergy);

            lblyuea36program.ToolTip = "Yu Energy 3 Year " + lib.Yuee("ProductName", lblProfile.Text, lblRegion.Text, lblyuMetertype.Text, "36", lblStartdate.Text, lblEac.Text, PaymentMethod, salestype, greenenergy);

            // 48 months

            txtyuea36sc.Text = lib.Yuee("StandingCharge", lblProfile.Text, lblRegion.Text, lblyuMetertype.Text, "36", lblStartdate.Text, lblEac.Text, PaymentMethod, salestype, greenenergy);
            txtyuea36day.Text = lib.Yuee("DayRate", lblProfile.Text, lblRegion.Text, lblyuMetertype.Text, "36", lblStartdate.Text, lblEac.Text, PaymentMethod, salestype, greenenergy);
            txtyuea36ew.Text = lib.Yuee("EveningWeekendRate", lblProfile.Text, lblRegion.Text, lblyuMetertype.Text, "36", lblStartdate.Text, lblEac.Text, PaymentMethod, salestype, greenenergy);
            txtyuea36night.Text = lib.Yuee("NightRate", lblProfile.Text, lblRegion.Text, lblyuMetertype.Text, "36", lblStartdate.Text, lblEac.Text, PaymentMethod, salestype, greenenergy);

            lblyuea36program.Text = "Yu Energy 4 Year " + lib.Yuee("ProductName", lblProfile.Text, lblRegion.Text, lblyuMetertype.Text, "36", lblStartdate.Text, lblEac.Text, PaymentMethod, salestype, greenenergy);

            txtyuea36sc.ToolTip = lib.Yuee("StandingCharge", lblProfile.Text, lblRegion.Text, lblyuMetertype.Text, "36", lblStartdate.Text, lblEac.Text, PaymentMethod, salestype, greenenergy);
            txtyuea36day.ToolTip = lib.Yuee("DayRate", lblProfile.Text, lblRegion.Text, lblyuMetertype.Text, "36", lblStartdate.Text, lblEac.Text, PaymentMethod, salestype, greenenergy);
            txtyuea36ew.ToolTip = lib.Yuee("EveningWeekendRate", lblProfile.Text, lblRegion.Text, lblyuMetertype.Text, "36", lblStartdate.Text, lblEac.Text, PaymentMethod, salestype, greenenergy);
            txtyuea36night.ToolTip = lib.Yuee("NightRate", lblProfile.Text, lblRegion.Text, lblyuMetertype.Text, "36", lblStartdate.Text, lblEac.Text, PaymentMethod, salestype, greenenergy);

            lblyuea36program.ToolTip = "Yu Energy 4 Year " + lib.Yuee("ProductName", lblProfile.Text, lblRegion.Text, lblyuMetertype.Text, "36", lblStartdate.Text, lblEac.Text, PaymentMethod, salestype, greenenergy);

            // 60 months

            txtyuea60sc.Text = lib.Yuee("StandingCharge", lblProfile.Text, lblRegion.Text, lblyuMetertype.Text, "60", lblStartdate.Text, lblEac.Text, PaymentMethod, salestype, greenenergy);
            txtyuea60day.Text = lib.Yuee("DayRate", lblProfile.Text, lblRegion.Text, lblyuMetertype.Text, "60", lblStartdate.Text, lblEac.Text, PaymentMethod, salestype, greenenergy);
            txtyuea60ew.Text = lib.Yuee("EveningWeekendRate", lblProfile.Text, lblRegion.Text, lblyuMetertype.Text, "60", lblStartdate.Text, lblEac.Text, PaymentMethod, salestype, greenenergy);
            txtyuea60night.Text = lib.Yuee("NightRate", lblProfile.Text, lblRegion.Text, lblyuMetertype.Text, "60", lblStartdate.Text, lblEac.Text, PaymentMethod, salestype, greenenergy);

            lblyuea60program.Text = "Yu Energy 5 Year " + lib.Yuee("ProductName", lblProfile.Text, lblRegion.Text, lblyuMetertype.Text, "60", lblStartdate.Text, lblEac.Text, PaymentMethod, salestype, greenenergy);

            txtyuea60sc.ToolTip = lib.Yuee("StandingCharge", lblProfile.Text, lblRegion.Text, lblyuMetertype.Text, "60", lblStartdate.Text, lblEac.Text, PaymentMethod, salestype, greenenergy);
            txtyuea60day.ToolTip = lib.Yuee("DayRate", lblProfile.Text, lblRegion.Text, lblyuMetertype.Text, "60", lblStartdate.Text, lblEac.Text, PaymentMethod, salestype, greenenergy);
            txtyuea60ew.ToolTip = lib.Yuee("EveningWeekendRate", lblProfile.Text, lblRegion.Text, lblyuMetertype.Text, "60", lblStartdate.Text, lblEac.Text, PaymentMethod, salestype, greenenergy);
            txtyuea60night.ToolTip = lib.Yuee("NightRate", lblProfile.Text, lblRegion.Text, lblyuMetertype.Text, "60", lblStartdate.Text, lblEac.Text, PaymentMethod, salestype, greenenergy);

            lblyuea60program.ToolTip = "Yu Energy 5 Year " + lib.Yuee("ProductName", lblProfile.Text, lblRegion.Text, lblyuMetertype.Text, "60", lblStartdate.Text, lblEac.Text, PaymentMethod, salestype, greenenergy);

        }
        #endregion

        #region TGP Calculation with Standing charge

        void Tgp()
        {

            string dayrate = "0";
            string weekday = "0";
            string unitrate = "0";
            lblDuration.Text = "12";
            string eac = lblEac.Text;
            string res = lib.Tgp("FixedChargepday", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            // 12 Months
            winopen = lblStartdate.Text;
            

            txttgp12sc.Text = lib.Tgp("FixedChargepday", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            dayrate = lib.Tgp("DayUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgp12night.Text = lib.Tgp("NightUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgp12ew.Text = lib.Tgp("EveWeUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            weekday = lib.Tgp("WeekdayUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            unitrate = lib.Tgp("UnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgp12other.Text = lib.Tgp("WinterEveUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);


            txttgp12day.Text = lib.DayRate(dayrate, weekday, unitrate);

            lbltgp12program.Text = lib.Tgp("ProductName", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac) + "for 12 months ";

            // 12 months all

            lblDuration.Text = "12";

            txttgp12scall.Text = lib.Tgp("FixedChargepday", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            dayrate = lib.Tgp("DayUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgp12nightall.Text = lib.Tgp("NightUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgp12ewall.Text = lib.Tgp("EveWeUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            weekday = lib.Tgp("WeekdayUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
           unitrate = lib.Tgp("UnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgp12otherall.Text = lib.Tgp("WinterEveUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);

            txttgp12dayall.Text = lib.DayRate(dayrate, weekday, unitrate);

            lbltgp12programall.Text = lib.Tgp("ProductName", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac) + "for 12 months ";

            //24 months 

            lblDuration.Text = "24";

            txttgp24sc.Text = lib.Tgp("FixedChargepday", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            dayrate = lib.Tgp("DayUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgp24night.Text = lib.Tgp("NightUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgp24ew.Text = lib.Tgp("EveWeUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
           weekday= lib.Tgp("WeekdayUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            unitrate = lib.Tgp("UnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgp24other.Text = lib.Tgp("WinterEveUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);

            txttgp24day.Text = lib.DayRate(dayrate, weekday, unitrate);
            lbltgp24program.Text = lib.Tgp("ProductName", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac) + "for 24 months ";

            // 24 months all

            lblDuration.Text = "24";

            txttgp24scall.Text = lib.Tgp("FixedChargepday", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            dayrate = lib.Tgp("DayUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgp24nightall.Text = lib.Tgp("NightUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgp24ewall.Text = lib.Tgp("EveWeUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
              weekday= lib.Tgp("WeekdayUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            unitrate = lib.Tgp("UnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgp24otherall.Text = lib.Tgp("WinterEveUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);


            txttgp24dayall.Text = lib.DayRate(dayrate, weekday, unitrate);

            lbltgp24programall.Text = lib.Tgp("ProductName", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac) + "for 24 months ";

            //36 months

            lblDuration.Text = "36";

            txttgp36sc.Text = lib.Tgp("FixedChargepday", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            dayrate = lib.Tgp("DayUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgp36night.Text = lib.Tgp("NightUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgp36ew.Text = lib.Tgp("EveWeUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            weekday= lib.Tgp("WeekdayUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
             unitrate = lib.Tgp("UnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgp36other.Text = lib.Tgp("WinterEveUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);

            txttgp36day.Text = lib.DayRate(dayrate, weekday, unitrate);

            lbltgp36program.Text = lib.Tgp("ProductName", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac) + "for 36 months ";

            //36 months all

            lblDuration.Text = "36";

            txttgp36scall.Text = lib.Tgp("FixedChargepday", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
           dayrate = lib.Tgp("DayUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgp36nightall.Text = lib.Tgp("NightUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgp36ewall.Text = lib.Tgp("EveWeUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
           weekday = lib.Tgp("WeekdayUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            unitrate= lib.Tgp("UnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgp36otherall.Text = lib.Tgp("WinterEveUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgp36dayall.Text = lib.DayRate(dayrate, weekday, unitrate);

            lbltgp36programall.Text = lib.Tgp("ProductName", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac) + "for 36 months ";


            //48 months
            lblDuration.Text = "48";

            txttgp48sc.Text = lib.Tgp("FixedChargepday", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
           dayrate= lib.Tgp("DayUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgp48night.Text = lib.Tgp("NightUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgp48ew.Text = lib.Tgp("EveWeUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
           weekday= lib.Tgp("WeekdayUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
           unitrate= lib.Tgp("UnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgp48other.Text = lib.Tgp("WinterEveUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);

            txttgp48day.Text = lib.DayRate(dayrate, weekday, unitrate);
            lbltgp48program.Text = lib.Tgp("ProductName", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac) + "for 48 months ";

            //48 months all
            lblDuration.Text = "48";

            txttgp48scall.Text = lib.Tgp("FixedChargepday", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            dayrate = lib.Tgp("DayUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgp48nightall.Text = lib.Tgp("NightUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgp48ewall.Text = lib.Tgp("EveWeUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            weekday = lib.Tgp("WeekdayUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
               unitrate= lib.Tgp("UnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgp48otherall.Text = lib.Tgp("WinterEveUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);

            txttgp48dayall.Text = lib.DayRate(dayrate, weekday, unitrate);

            lbltgp48programall.Text = lib.Tgp("ProductName", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac) + "for 48 months ";

            //60 months

            lblDuration.Text = "60";

            txttgp60sc.Text = lib.Tgp("FixedChargepday", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
           dayrate = lib.Tgp("DayUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgp60night.Text = lib.Tgp("NightUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgp60ew.Text = lib.Tgp("EveWeUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            weekday= lib.Tgp("WeekdayUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            unitrate = lib.Tgp("UnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgp60other.Text = lib.Tgp("WinterEveUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);

            txttgp60day.Text = lib.DayRate(dayrate, weekday, unitrate);


            lbltgp60program.Text = lib.Tgp("ProductName", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac) + "for 48 months ";
            //  60 months all
            txttgp60scall.Text = lib.Tgp("FixedChargepday", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
           dayrate = lib.Tgp("DayUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgp60nightall.Text = lib.Tgp("NightUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgp60ewall.Text = lib.Tgp("EveWeUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
           weekday = lib.Tgp("WeekdayUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
           unitrate = lib.Tgp("UnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgp60otherall.Text = lib.Tgp("WinterEveUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);

            txttgp60dayall.Text = lib.DayRate(dayrate, weekday, unitrate);
            lbltgp60programall.Text = lib.Tgp("ProductName", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac) + "for 48 months ";

            // tooltips




            lblDuration.Text = "12";

            txttgp12sc.ToolTip = lib.Tgp("FixedChargepday", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            dayrate = lib.Tgp("DayUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgp12night.ToolTip = lib.Tgp("NightUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgp12ew.ToolTip = lib.Tgp("EveWeUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            weekday= lib.Tgp("WeekdayUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            unitrate = lib.Tgp("UnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgp12other.ToolTip = lib.Tgp("WinterEveUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);

            txttgp12day.ToolTip = lib.DayRate(dayrate, weekday, unitrate);
            lbltgp12program.ToolTip = lib.Tgp("ProductName", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac) + "for 12 months ";

            // 12 months all

            lblDuration.Text = "12";

            txttgp12scall.ToolTip = lib.Tgp("FixedChargepday", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            dayrate = lib.Tgp("DayUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgp12nightall.ToolTip = lib.Tgp("NightUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgp12ewall.ToolTip = lib.Tgp("EveWeUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            weekday = lib.Tgp("WeekdayUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            unitrate = lib.Tgp("UnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgp12otherall.ToolTip = lib.Tgp("WinterEveUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);

            txttgp12dayall.ToolTip = lib.DayRate(dayrate, weekday, unitrate);

            lbltgp12programall.ToolTip = lib.Tgp("ProductName", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac) + "for 12 months ";

            //24 months 

            lblDuration.Text = "24";

            txttgp24sc.ToolTip = lib.Tgp("FixedChargepday", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            dayrate= lib.Tgp("DayUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgp24night.ToolTip = lib.Tgp("NightUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgp24ew.ToolTip = lib.Tgp("EveWeUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
           weekday = lib.Tgp("WeekdayUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
           unitrate= lib.Tgp("UnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgp24other.ToolTip = lib.Tgp("WinterEveUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);

            txttgp24day.ToolTip = lib.DayRate(dayrate, weekday, unitrate);
            lbltgp24program.ToolTip = lib.Tgp("ProductName", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac) + "for 24 months ";

            // 24 months all

            lblDuration.Text = "24";

            txttgp24scall.ToolTip = lib.Tgp("FixedChargepday", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            dayrate = lib.Tgp("DayUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgp24nightall.ToolTip = lib.Tgp("NightUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgp24ewall.ToolTip = lib.Tgp("EveWeUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            weekday = lib.Tgp("WeekdayUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            unitrate = lib.Tgp("UnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgp24otherall.ToolTip = lib.Tgp("WinterEveUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);

            txttgp24dayall.ToolTip = lib.DayRate(dayrate, weekday, unitrate);
            lbltgp24programall.Text = lib.Tgp("ProductName", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac) + "for 24 months ";

            //36 months

            lblDuration.Text = "36";

            txttgp36sc.ToolTip = lib.Tgp("FixedChargepday", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
           dayrate  = lib.Tgp("DayUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgp36night.ToolTip = lib.Tgp("NightUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgp36ew.ToolTip = lib.Tgp("EveWeUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
           weekday= lib.Tgp("WeekdayUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
           unitrate= lib.Tgp("UnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgp36other.ToolTip = lib.Tgp("WinterEveUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);

            txttgp36day.ToolTip = lib.DayRate(dayrate, weekday, unitrate);
            lbltgp36program.ToolTip = lib.Tgp("ProductName", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac) + "for 36 months ";

            //36 months all

            lblDuration.Text = "36";

            txttgp36scall.ToolTip = lib.Tgp("FixedChargepday", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            dayrate= lib.Tgp("DayUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgp36nightall.ToolTip = lib.Tgp("NightUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgp36ewall.ToolTip = lib.Tgp("EveWeUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
             weekday= lib.Tgp("WeekdayUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            unitrate = lib.Tgp("UnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgp36otherall.ToolTip = lib.Tgp("WinterEveUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);

            txttgp36dayall.ToolTip = lib.DayRate(dayrate, weekday, unitrate);
            lbltgp36programall.ToolTip = lib.Tgp("ProductName", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac) + "for 36 months ";


            //48 months
            lblDuration.Text = "48";

            txttgp48sc.ToolTip = lib.Tgp("FixedChargepday", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
               dayrate = lib.Tgp("DayUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgp48night.ToolTip = lib.Tgp("NightUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgp48ew.ToolTip = lib.Tgp("EveWeUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
           weekday = lib.Tgp("WeekdayUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            unitrate= lib.Tgp("UnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgp48other.ToolTip = lib.Tgp("WinterEveUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);

            txttgp48day.ToolTip = lib.DayRate(dayrate, weekday, unitrate);

            lbltgp48program.ToolTip = lib.Tgp("ProductName", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac) + "for 48 months ";

            //48 months all
            lblDuration.Text = "48";

            txttgp48scall.ToolTip = lib.Tgp("FixedChargepday", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            dayrate = lib.Tgp("DayUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgp48nightall.ToolTip = lib.Tgp("NightUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgp48ewall.ToolTip = lib.Tgp("EveWeUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
           weekday = lib.Tgp("WeekdayUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
           unitrate =lib.Tgp("UnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgp48otherall.ToolTip = lib.Tgp("WinterEveUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);

            txttgp48dayall.ToolTip = lib.DayRate(dayrate, weekday, unitrate);
            lbltgp48programall.ToolTip = lib.Tgp("ProductName", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac) + "for 48 months ";

            //60 months

            lblDuration.Text = "60";

            txttgp60sc.ToolTip = lib.Tgp("FixedChargepday", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            dayrate = lib.Tgp("DayUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgp60night.ToolTip = lib.Tgp("NightUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgp60ew.ToolTip = lib.Tgp("EveWeUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
           weekday= lib.Tgp("WeekdayUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            unitrate = lib.Tgp("UnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgp60other.ToolTip = lib.Tgp("WinterEveUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);

            txttgp60day.ToolTip = lib.DayRate(dayrate, weekday, unitrate);


            lbltgp60program.ToolTip = lib.Tgp("ProductName", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac) + "for 48 months ";
            //  60 months all
            txttgp60scall.ToolTip = lib.Tgp("FixedChargepday", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
           dayrate = lib.Tgp("DayUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgp60nightall.ToolTip = lib.Tgp("NightUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgp60ewall.ToolTip = lib.Tgp("EveWeUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            weekday = lib.Tgp("WeekdayUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
           unitrate= lib.Tgp("UnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgp60otherall.ToolTip = lib.Tgp("WinterEveUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);


            txttgp60dayall.ToolTip = lib.DayRate(dayrate, weekday, unitrate);
            lbltgp60programall.ToolTip = lib.Tgp("ProductName", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose,eac) + "for 48 months ";

        }

        #endregion


        #region TGP Calculation Without Standing charge
        void TgpWithouSc()
        {

            string dayrate = "0";
            string weekday = "0";
            string unitrate = "0";
            lblDuration.Text = "12";
            string eac = lblEac.Text;
           // string res = lib.TgpWsc("FixedChargepday", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            // 12 Months
            winopen = lblStartdate.Text;
            lblDuration.Text = "12";

            //    txttgp12sc.Text = lib.TgpWsc("FixedChargepday", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            dayrate = lib.TgpWsc("DayUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgpw12night.Text = lib.TgpWsc("NightUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgpw12ew.Text = lib.TgpWsc("EveWeUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            weekday = lib.TgpWsc("WeekdayUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            unitrate = lib.TgpWsc("UnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgpw12other.Text = lib.TgpWsc("WinterEveUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);


            txttgpw12day.Text = lib.DayRate(dayrate, weekday, unitrate);

            lbltgpw12program.Text = lib.TgpWsc("ProductName", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac) + "for 12 months ";

            // 12 months all

            lblDuration.Text = "12";

         //   txttgp12scall.Text = lib.TgpWsc("FixedChargepday", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            dayrate = lib.TgpWsc("DayUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgpw12nightall.Text = lib.TgpWsc("NightUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgpw12ewall.Text = lib.TgpWsc("EveWeUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            weekday = lib.TgpWsc("WeekdayUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            unitrate = lib.TgpWsc("UnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgpw12otherall.Text = lib.TgpWsc("WinterEveUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);

            txttgpw12dayall.Text = lib.DayRate(dayrate, weekday, unitrate);

            lbltgpw12programall.Text = lib.TgpWsc("ProductName", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac) + "for 12 months ";

            //24 months 

            lblDuration.Text = "24";

         //   txttgp24sc.Text = lib.TgpWsc("FixedChargepday", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            dayrate = lib.TgpWsc("DayUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgpw24night.Text = lib.TgpWsc("NightUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgpw24ew.Text = lib.TgpWsc("EveWeUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            weekday = lib.TgpWsc("WeekdayUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            unitrate = lib.TgpWsc("UnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgpw24other.Text = lib.TgpWsc("WinterEveUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);

            txttgpw24day.Text = lib.DayRate(dayrate, weekday, unitrate);
            lbltgpw24program.Text = lib.TgpWsc("ProductName", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac) + "for 24 months ";

            // 24 months all

            lblDuration.Text = "24";

        //    txttgp24scall.Text = lib.TgpWsc("FixedChargepday", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            dayrate = lib.TgpWsc("DayUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgpw24nightall.Text = lib.TgpWsc("NightUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgpw24ewall.Text = lib.TgpWsc("EveWeUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            weekday = lib.TgpWsc("WeekdayUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            unitrate = lib.TgpWsc("UnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgpw24otherall.Text = lib.TgpWsc("WinterEveUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);


            txttgpw24dayall.Text = lib.DayRate(dayrate, weekday, unitrate);

            lbltgpw24programall.Text = lib.TgpWsc("ProductName", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac) + "for 24 months ";

            //36 months

            lblDuration.Text = "36";

        //    txttgp36sc.Text = lib.TgpWsc("FixedChargepday", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            dayrate = lib.TgpWsc("DayUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgpw36night.Text = lib.TgpWsc("NightUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgpw36ew.Text = lib.TgpWsc("EveWeUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            weekday = lib.TgpWsc("WeekdayUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            unitrate = lib.TgpWsc("UnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgpw36other.Text = lib.TgpWsc("WinterEveUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);

            txttgpw36day.Text = lib.DayRate(dayrate, weekday, unitrate);

            lbltgpw36program.Text = lib.TgpWsc("ProductName", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac) + "for 36 months ";

            //36 months all

            lblDuration.Text = "36";

      //      txttgp36scall.Text = lib.TgpWsc("FixedChargepday", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            dayrate = lib.TgpWsc("DayUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgpw36nightall.Text = lib.TgpWsc("NightUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgpw36ewall.Text = lib.TgpWsc("EveWeUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            weekday = lib.TgpWsc("WeekdayUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            unitrate = lib.TgpWsc("UnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgpw36otherall.Text = lib.TgpWsc("WinterEveUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgpw36dayall.Text = lib.DayRate(dayrate, weekday, unitrate);

            lbltgpw36programall.Text = lib.TgpWsc("ProductName", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac) + "for 36 months ";


            //48 months
            lblDuration.Text = "48";

        //    txttgp48sc.Text = lib.TgpWsc("FixedChargepday", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            dayrate = lib.TgpWsc("DayUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgpw48night.Text = lib.TgpWsc("NightUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgpw48ew.Text = lib.TgpWsc("EveWeUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            weekday = lib.TgpWsc("WeekdayUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            unitrate = lib.TgpWsc("UnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgpw48other.Text = lib.TgpWsc("WinterEveUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);

            txttgpw48day.Text = lib.DayRate(dayrate, weekday, unitrate);
            lbltgpw48program.Text = lib.TgpWsc("ProductName", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac) + "for 48 months ";

            //48 months all
            lblDuration.Text = "48";

      //      txttgp48scall.Text = lib.TgpWsc("FixedChargepday", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            dayrate = lib.TgpWsc("DayUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgpw48nightall.Text = lib.TgpWsc("NightUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgpw48ewall.Text = lib.TgpWsc("EveWeUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            weekday = lib.TgpWsc("WeekdayUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            unitrate = lib.TgpWsc("UnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgpw48otherall.Text = lib.TgpWsc("WinterEveUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);

            txttgpw48dayall.Text = lib.DayRate(dayrate, weekday, unitrate);

            lbltgpw48programall.Text = lib.TgpWsc("ProductName", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac) + "for 48 months ";

            //60 months

            lblDuration.Text = "60";

      //      txttgp60sc.Text = lib.TgpWsc("FixedChargepday", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            dayrate = lib.TgpWsc("DayUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgpw60night.Text = lib.TgpWsc("NightUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgpw60ew.Text = lib.TgpWsc("EveWeUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            weekday = lib.TgpWsc("WeekdayUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            unitrate = lib.TgpWsc("UnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgpw60other.Text = lib.TgpWsc("WinterEveUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);

            txttgpw60day.Text = lib.DayRate(dayrate, weekday, unitrate);


            lbltgpw60program.Text = lib.TgpWsc("ProductName", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac) + "for 48 months withot SC ";
            //  60 months all
       //     txttgp60scall.Text = lib.TgpWsc("FixedChargepday", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            dayrate = lib.TgpWsc("DayUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgpw60nightall.Text = lib.TgpWsc("NightUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgpw60ewall.Text = lib.TgpWsc("EveWeUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            weekday = lib.TgpWsc("WeekdayUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            unitrate = lib.TgpWsc("UnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgpw60otherall.Text = lib.TgpWsc("WinterEveUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);

            txttgpw60dayall.Text = lib.DayRate(dayrate, weekday, unitrate);
            lbltgpw60programall.Text = lib.TgpWsc("ProductName", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac) + "for 48 months ";

            // tooltips




            lblDuration.Text = "12";

        //    txttgp12sc.ToolTip = lib.TgpWsc("FixedChargepday", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            dayrate = lib.TgpWsc("DayUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgpw12night.ToolTip = lib.TgpWsc("NightUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgpw12ew.ToolTip = lib.TgpWsc("EveWeUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            weekday = lib.TgpWsc("WeekdayUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            unitrate = lib.TgpWsc("UnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgpw12other.ToolTip = lib.TgpWsc("WinterEveUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);

            txttgpw12day.ToolTip = lib.DayRate(dayrate, weekday, unitrate);
            lbltgpw12program.ToolTip = lib.TgpWsc("ProductName", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac) + "for 12 months ";

            // 12 months all

            lblDuration.Text = "12";

        //    txttgp12scall.ToolTip = lib.TgpWsc("FixedChargepday", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            dayrate = lib.TgpWsc("DayUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgpw12nightall.ToolTip = lib.TgpWsc("NightUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgpw12ewall.ToolTip = lib.TgpWsc("EveWeUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            weekday = lib.TgpWsc("WeekdayUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            unitrate = lib.TgpWsc("UnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgpw12otherall.ToolTip = lib.TgpWsc("WinterEveUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);

            txttgpw12dayall.ToolTip = lib.DayRate(dayrate, weekday, unitrate);

            lbltgpw12programall.ToolTip = lib.TgpWsc("ProductName", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac) + "for 12 months ";

            //24 months 

            lblDuration.Text = "24";

         //   txttgp24sc.ToolTip = lib.TgpWsc("FixedChargepday", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            dayrate = lib.TgpWsc("DayUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgpw24night.ToolTip = lib.TgpWsc("NightUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgpw24ew.ToolTip = lib.TgpWsc("EveWeUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            weekday = lib.TgpWsc("WeekdayUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            unitrate = lib.TgpWsc("UnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgpw24other.ToolTip = lib.TgpWsc("WinterEveUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);

            txttgpw24day.ToolTip = lib.DayRate(dayrate, weekday, unitrate);
            lbltgpw24program.ToolTip = lib.TgpWsc("ProductName", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac) + "for 24 months ";

            // 24 months all

            lblDuration.Text = "24";

       //     txttgp24scall.ToolTip = lib.TgpWsc("FixedChargepday", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            dayrate = lib.TgpWsc("DayUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgpw24nightall.ToolTip = lib.TgpWsc("NightUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgpw24ewall.ToolTip = lib.TgpWsc("EveWeUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            weekday = lib.TgpWsc("WeekdayUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            unitrate = lib.TgpWsc("UnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgpw24otherall.ToolTip = lib.TgpWsc("WinterEveUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);

            txttgpw24dayall.ToolTip = lib.DayRate(dayrate, weekday, unitrate);
            lbltgpw24programall.Text = lib.TgpWsc("ProductName", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac) + "for 24 months ";

            //36 months

            lblDuration.Text = "36";

        //    txttgp36sc.ToolTip = lib.TgpWsc("FixedChargepday", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            dayrate = lib.TgpWsc("DayUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgpw36night.ToolTip = lib.TgpWsc("NightUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgpw36ew.ToolTip = lib.TgpWsc("EveWeUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            weekday = lib.TgpWsc("WeekdayUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            unitrate = lib.TgpWsc("UnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgpw36other.ToolTip = lib.TgpWsc("WinterEveUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);

            txttgpw36day.ToolTip = lib.DayRate(dayrate, weekday, unitrate);
            lbltgpw36program.ToolTip = lib.TgpWsc("ProductName", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac) + "for 36 months ";

            //36 months all

            lblDuration.Text = "36";

        //    txttgp36scall.ToolTip = lib.TgpWsc("FixedChargepday", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            dayrate = lib.TgpWsc("DayUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgpw36nightall.ToolTip = lib.TgpWsc("NightUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgpw36ewall.ToolTip = lib.TgpWsc("EveWeUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            weekday = lib.TgpWsc("WeekdayUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            unitrate = lib.TgpWsc("UnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgpw36otherall.ToolTip = lib.TgpWsc("WinterEveUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);

            txttgpw36dayall.ToolTip = lib.DayRate(dayrate, weekday, unitrate);
            lbltgpw36programall.ToolTip = lib.TgpWsc("ProductName", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac) + "for 36 months ";


            //48 months
            lblDuration.Text = "48";

       //     txttgp48sc.ToolTip = lib.TgpWsc("FixedChargepday", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            dayrate = lib.TgpWsc("DayUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgpw48night.ToolTip = lib.TgpWsc("NightUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgpw48ew.ToolTip = lib.TgpWsc("EveWeUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            weekday = lib.TgpWsc("WeekdayUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            unitrate = lib.TgpWsc("UnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgpw48other.ToolTip = lib.TgpWsc("WinterEveUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);

            txttgpw48day.ToolTip = lib.DayRate(dayrate, weekday, unitrate);

            lbltgpw48program.ToolTip = lib.TgpWsc("ProductName", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac) + "for 48 months ";

            //48 months all
            lblDuration.Text = "48";

     //       txttgp48scall.ToolTip = lib.TgpWsc("FixedChargepday", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            dayrate = lib.TgpWsc("DayUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgpw48nightall.ToolTip = lib.TgpWsc("NightUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgpw48ewall.ToolTip = lib.TgpWsc("EveWeUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            weekday = lib.TgpWsc("WeekdayUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            unitrate = lib.TgpWsc("UnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgpw48otherall.ToolTip = lib.TgpWsc("WinterEveUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);

            txttgpw48dayall.ToolTip = lib.DayRate(dayrate, weekday, unitrate);
            lbltgpw48programall.ToolTip = lib.TgpWsc("ProductName", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac) + "for 48 months ";

            //60 months

            lblDuration.Text = "60";

      //      txttgp60sc.ToolTip = lib.TgpWsc("FixedChargepday", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            dayrate = lib.TgpWsc("DayUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgpw60night.ToolTip = lib.TgpWsc("NightUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgpw60ew.ToolTip = lib.TgpWsc("EveWeUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            weekday = lib.TgpWsc("WeekdayUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            unitrate = lib.TgpWsc("UnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgpw60other.ToolTip = lib.TgpWsc("WinterEveUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);

            txttgpw60day.ToolTip = lib.DayRate(dayrate, weekday, unitrate);


            lbltgpw60program.ToolTip = lib.TgpWsc("ProductName", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac) + "for 48 months ";
            //  60 months all
       //     txttgp60scall.ToolTip = lib.TgpWsc("FixedChargepday", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            dayrate = lib.TgpWsc("DayUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgpw60nightall.ToolTip = lib.TgpWsc("NightUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgpw60ewall.ToolTip = lib.TgpWsc("EveWeUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            weekday = lib.TgpWsc("WeekdayUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            unitrate = lib.TgpWsc("UnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);
            txttgpw60otherall.ToolTip = lib.TgpWsc("WinterEveUnitspkWh", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac);


            txttgpw60dayall.ToolTip = lib.DayRate(dayrate, weekday, unitrate);
            lbltgpw60programall.ToolTip = lib.TgpWsc("ProductName", lblProfile.Text, lblRegion.Text, lblMTC.Text, lblDuration.Text, winopen, winclose, eac) + "for 48 months ";

        }

        #endregion


        #region Get Plan Details of all provider

        void getbgplan()
        {
            SqlConnection con = new SqlConnection(myConnectionString);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();


            }

            SqlCommand cmd = new SqlCommand("select top 1 bg from mtc where  mtccode = @mtccode and region = @region ", con);
            cmd.Parameters.AddWithValue("@mtccode", lblMTC.Text);
            cmd.Parameters.AddWithValue("@region", lblRegion.Text);


            lblBGEMetertype.Text = Convert.ToString(cmd.ExecuteScalar());
            con.Close();


        }


        void gethevsplan()
        {
            SqlConnection con = new SqlConnection(myConnectionString);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();


            }

            SqlCommand cmd = new SqlCommand("select top 1 hev from mtc where  mtccode = @mtccode and region = @region ", con);
            cmd.Parameters.AddWithValue("@mtccode", lblMTC.Text);
            cmd.Parameters.AddWithValue("@region", lblRegion.Text);


            lblHevsMeterType.Text = Convert.ToString(cmd.ExecuteScalar());
            con.Close();


        }




        void getnpowerplan()
        {
            SqlConnection con = new SqlConnection(myConnectionString);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();


            }

            SqlCommand cmd = new SqlCommand("select top 1 npower from mtc where  mtccode = @mtccode and region = @region ", con);
            cmd.Parameters.AddWithValue("@mtccode", lblMTC.Text);
            cmd.Parameters.AddWithValue("@region", lblRegion.Text);
            lblNpwer.Text = Convert.ToString(cmd.ExecuteScalar());
            con.Close();


        }


        void getbgliteplan()
        {
            SqlConnection con = new SqlConnection(myConnectionString);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();


            }


            SqlCommand cmd = new SqlCommand("select top 1 bgl  from mtc where  mtccode = @mtccode and region=@region", con);
            cmd.Parameters.AddWithValue("@mtccode", lblMTC.Text);
            cmd.Parameters.AddWithValue("@region", lblRegion.Text);
            lblBGLMetertype.Text = Convert.ToString(cmd.ExecuteScalar());
            con.Close();


        }

        void getopusplan()
        {
            SqlConnection con = new SqlConnection(myConnectionString);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();


            }


            SqlCommand cmd = new SqlCommand("select  top 1 opus1  from mtc where  mtccode = @mtccode and region=@region", con);
            cmd.Parameters.AddWithValue("@mtccode", lblMTC.Text);
            cmd.Parameters.AddWithValue("@region", lblRegion.Text);
            lblOpusMeterType.Text = Convert.ToString(cmd.ExecuteScalar());
            con.Close();


        }

        void getopusplan1()
        {
            SqlConnection con = new SqlConnection(myConnectionString);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();


            }


            SqlCommand cmd = new SqlCommand("select  top 1 opus2  from mtc where  mtccode = @mtccode and region=@region", con);
            cmd.Parameters.AddWithValue("@mtccode", lblMTC.Text);
            cmd.Parameters.AddWithValue("@region", lblRegion.Text);
            lblOpusMeterType1.Text = Convert.ToString(cmd.ExecuteScalar());
            con.Close();


        }

        void getopusplan2()
        {
            SqlConnection con = new SqlConnection(myConnectionString);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();


            }


            SqlCommand cmd = new SqlCommand("select  top 1 opus3  from mtc where  mtccode = @mtccode and region= @region", con);
            cmd.Parameters.AddWithValue("@mtccode", lblMTC.Text);
            cmd.Parameters.AddWithValue("@region", lblRegion.Text);
            lblOpusMeterType2.Text = Convert.ToString(cmd.ExecuteScalar());
            con.Close();



        }

        void getopusplan3()
        {
            SqlConnection con = new SqlConnection(myConnectionString);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();


            }


            SqlCommand cmd = new SqlCommand("select  top 1 opus3  from mtc where  mtccode = @mtccode and region = @region", con);
            cmd.Parameters.AddWithValue("@mtccode", lblMTC.Text);
            cmd.Parameters.AddWithValue("@region", lblRegion.Text);
            lblOpusMeterType3.Text = Convert.ToString(cmd.ExecuteScalar());
            con.Close();



        }

        void getpeplan()
        {
            SqlConnection con = new SqlConnection(myConnectionString);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();


            }


            SqlCommand cmd = new SqlCommand("select top 1 pe   from mtc where  mtccode = @mtccode and region = @region", con);
            cmd.Parameters.AddWithValue("@mtccode", lblMTC.Text);
            cmd.Parameters.AddWithValue("@region", lblRegion.Text);
            lblPEMetertype.Text = Convert.ToString(cmd.ExecuteScalar());
            con.Close();


        }

        void getsseplan()
        {
            SqlConnection con = new SqlConnection(myConnectionString);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();


            }


            SqlCommand cmd = new SqlCommand("select top 1 sse   from mtc where  mtccode = @mtccode and region = @region", con);
            cmd.Parameters.AddWithValue("@mtccode", lblMTC.Text);
            cmd.Parameters.AddWithValue("@region", lblRegion.Text);
            lblSSEPEMetertype.Text = Convert.ToString(cmd.ExecuteScalar());
            con.Close();


        }

        void getspeplan()
        {
            SqlConnection con = new SqlConnection(myConnectionString);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();


            }


            SqlCommand cmd = new SqlCommand("select top 1 sp   from mtc where  mtccode = @mtccode and region =@region", con);
            cmd.Parameters.AddWithValue("@mtccode", lblMTC.Text);
            cmd.Parameters.AddWithValue("@region", lblRegion.Text);
            lblSPAMetertype.Text = Convert.ToString(cmd.ExecuteScalar());
            con.Close();


        }

        void geteonplan()
        {
            SqlConnection con = new SqlConnection(myConnectionString);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();


            }


            SqlCommand cmd = new SqlCommand("select top 1 SalesProductDesc   from mtc where  mtccode = @mtccode and region = @region", con);
            cmd.Parameters.AddWithValue("@mtccode", lblMTC.Text);
            cmd.Parameters.AddWithValue("@region", lblRegion.Text);
            lblEONEMetertype.Text = Convert.ToString(cmd.ExecuteScalar());
            con.Close();


        }


      

        void getdeeplan()
        {
            SqlConnection con = new SqlConnection(myConnectionString);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();


            }


            SqlCommand cmd = new SqlCommand("select top 1 de  from mtc where  mtccode = @mtccode and region = @region", con);
            cmd.Parameters.AddWithValue("@mtccode", lblMTC.Text);
            cmd.Parameters.AddWithValue("@region", lblRegion.Text);
            lblDEMetertype.Text = Convert.ToString(cmd.ExecuteScalar());
            con.Close();


        }


        void getedfplan()
        {
            SqlConnection con = new SqlConnection(myConnectionString);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();


            }

            SqlCommand cmd = new SqlCommand("select top 1 edfe  from mtc where  mtccode = @mtccode and region = @region", con);
            cmd.Parameters.AddWithValue("@mtccode", lblMTC.Text);
            cmd.Parameters.AddWithValue("@region", lblRegion.Text);
            lblEDFMetertype.Text = Convert.ToString(cmd.ExecuteScalar());
            con.Close();


        }

        void getgazplan()
        {



            SqlConnection con = new SqlConnection(myConnectionString);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();


            }

            SqlCommand cmd = new SqlCommand("select top 1 gaz  from mtc where  mtccode = @mtccode and region = @region", con);
            cmd.Parameters.AddWithValue("@mtccode", lblMTC.Text);
            cmd.Parameters.AddWithValue("@region", lblRegion.Text);
            lblGZMetertype.Text = Convert.ToString(cmd.ExecuteScalar());
            con.Close();



        }

        void Getyu()
        {



            SqlConnection con = new SqlConnection(myConnectionString);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();


            }

            SqlCommand cmd = new SqlCommand("select top 1 yu  from mtc where  mtccode = @mtccode and region = @region", con);
            cmd.Parameters.AddWithValue("@mtccode", lblMTC.Text);
            cmd.Parameters.AddWithValue("@region", lblRegion.Text);
            lblyuMetertype.Text = Convert.ToString(cmd.ExecuteScalar());
            con.Close();



        }

        void GetGulf()
        {



            SqlConnection con = new SqlConnection(myConnectionString);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();


            }

            SqlCommand cmd = new SqlCommand("select top 1 gulf  from mtc where  mtccode = @mtccode and region = @region", con);
            cmd.Parameters.AddWithValue("@mtccode", lblMTC.Text);
            cmd.Parameters.AddWithValue("@region", lblRegion.Text);
            lblGulfMetertype.Text = Convert.ToString(cmd.ExecuteScalar());
            con.Close();



        }

        void GetUtilita()
        {



            SqlConnection con = new SqlConnection(myConnectionString);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();


            }

            SqlCommand cmd = new SqlCommand("select top 1 utilita  from mtc where  mtccode = @mtccode and region = @region", con);
            cmd.Parameters.AddWithValue("@mtccode", lblMTC.Text);
            cmd.Parameters.AddWithValue("@region", lblRegion.Text);
            lblUtilitaMetertype.Text = Convert.ToString(cmd.ExecuteScalar());
            con.Close();



        }

        #endregion



        protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        {
            int index = Int32.Parse(e.Item.Value);
            Multiview1.ActiveViewIndex = index;
            
            if(index == 0)
            {
                lblDuration.Text = "12";

            }
            if (index == 1)
            {
                lblDuration.Text = "24";

            }
            if (index == 2)
            {
                lblDuration.Text = "36";

            }
            if (index == 3)
            {
                lblDuration.Text = "48";

            }
            if (index == 4)
            {
                lblDuration.Text = "60";

            }
            if (index == 5)
            {
                lblDuration.Text = "All";

            }


        }

        protected void btnEac_Command(object sender, CommandEventArgs e)
        {
            getbgliteplan();

            getdeeplan();

            getedfplan();

            getnpowerplan();

            getgazplan();

            getopusplan();

            getpeplan();

            getspeplan();

            getsseplan();

            geteonplan();

            Bindbga();
            Bindbgl();
            Bindedf();
            Bindde();
            Bindpe();
            gazpron();
            SSE();
            Npower();
            Spe();
            Tgp();
            


        }















        #region BG Uplift calculation for new customer


        void bga12()
        {
            double finalvalue = 0;

            double sc = Convert.ToDouble(txtbga12sc.Text);
            double dayc = Convert.ToDouble(txtbga12day.ToolTip);
            double nightprice = Convert.ToDouble(txtbga12night.ToolTip);
            double weekend = Convert.ToDouble(txtbga12ew.ToolTip);
        //    double unitc = Convert.ToDouble(txtbga12unit.ToolTip);
       //     double wd = Convert.ToDouble(txtbga12wd.ToolTip);
            double offpeak = Convert.ToDouble(txtbga12offpeak.ToolTip);
        //    double otherc = Convert.ToDouble(txtbga12other.ToolTip.ToString());
            double upliftc = Convert.ToDouble(txtbga12uplift.Text);

            double eac = Convert.ToDouble(lblEac.Text);

            if (txtbga12day.Text != "0")
            {
                dayc = dayc + upliftc;
                txtbga12day.Text = dayc.ToString();
            }

            if (txtbga12night.Text != "0")
            {
                nightprice = nightprice + upliftc;
                txtbga12night.Text = nightprice.ToString();
            }

            if (txtbga12ew.Text != "0")
            {
                weekend = weekend + upliftc;
                txtbga12ew.Text = weekend.ToString();
            }

            //if (txtbga12unit.Text != "0")
            //{
            //    unitc = unitc + upliftc;
            //    txtbga12unit.Text = unitc.ToString();
            //}

            //if (txtbga12wd.Text != "0")
            //{
            //    wd = wd + upliftc;
            //    txtbga12wd.Text = wd.ToString();
            //}

            if (txtbga12offpeak.Text != "0")
            {
                offpeak = offpeak + upliftc;
                txtbga12offpeak.Text = offpeak.ToString();
            }

           










            if (lblBGEMetertype.Text == "Single Rate")
            {
                finalvalue = lib.SingleRatebg(sc, dayc, eac);
                txtbga12rate.Text = finalvalue.ToString();
            }

            if (lblBGEMetertype.Text == "Day & Night")
            {
                finalvalue = lib.Daynight(sc, dayc, nightprice, eac);
                txtbga12rate.Text = finalvalue.ToString();
            }
            if (lblBGEMetertype.Text == "Eve/Weekend & Night")
            {
                finalvalue = lib.Ewn(sc, dayc, nightprice, weekend, eac);
                txtbga12rate.Text = finalvalue.ToString();

            }

            if (lblBGEMetertype.Text == "Eve/Weekend")
            {
                finalvalue = lib.EW(sc, dayc, weekend, eac);
                txtbga12rate.Text = finalvalue.ToString();

            }

            if (lblBGEMetertype.Text == "Off Peak")
            {
                finalvalue = lib.OffPeak(sc, offpeak, eac);
                txtbga12rate.Text = finalvalue.ToString();

            }


        }
        void bga12all()
        {
            double finalvalue = 0;

            double sc = Convert.ToDouble(txtbga12scall.Text);
            double dayc = Convert.ToDouble(txtbga12dayall.ToolTip);
            double nightprice = Convert.ToDouble(txtbga12nightall.ToolTip);
            double weekend = Convert.ToDouble(txtbga12ewall.ToolTip);
          //  double unitc = Convert.ToDouble(txtbga12unitall.ToolTip);
       //     double wd = Convert.ToDouble(txtbga12wdall.ToolTip);
            double offpeak = Convert.ToDouble(txtbga12offpeakall.ToolTip);
            //   double otherc = Convert.ToDouble(txtbga12other.ToolTip.ToString());
            double upliftc = Convert.ToDouble(txtbga12upliftall.Text);

            double eac = Convert.ToDouble(lblEac.Text);

            if (txtbga12dayall.Text != "0")
            {
                dayc = dayc + upliftc;
                txtbga12dayall.Text = dayc.ToString();
            }

            if (txtbga12nightall.Text != "0")
            {
                nightprice = nightprice + upliftc;
                txtbga12nightall.Text = nightprice.ToString();
            }

            if (txtbga12ewall.Text != "0")
            {
                weekend = weekend + upliftc;
                txtbga12ewall.Text = weekend.ToString();
            }

            //if (txtbga12unitall.Text != "0")
            //{
            //    unitc = unitc + upliftc;
            //    txtbga12unitall.Text = unitc.ToString();
            //}

            //if (txtbga12wd.Text != "0")
            //{
            //    wd = wd + upliftc;
            //    txtbga12wdall.Text = wd.ToString();
            //}

            if (txtbga12offpeak.Text != "0")
            {
                offpeak = offpeak + upliftc;
                txtbga12offpeakall.Text = offpeak.ToString();
            }

         










            if (lblBGEMetertype.Text == "Single Rate")
            {
                finalvalue = lib.SingleRatebg(sc, dayc, eac);
                txtbga12rateall.Text = finalvalue.ToString();
            }

            if (lblBGEMetertype.Text == "Day & Night")
            {
                finalvalue = lib.Daynight(sc, dayc, nightprice, eac);
                txtbga12rateall.Text = finalvalue.ToString();
            }
            if (lblBGEMetertype.Text == "Eve/Weekend & Night")
            {
                finalvalue = lib.Ewn(sc, dayc, nightprice, weekend, eac);
                txtbga12rateall.Text = finalvalue.ToString();

            }

            if (lblBGEMetertype.Text == "Eve/Weekend")
            {
                finalvalue = lib.EW(sc, dayc, weekend, eac);
                txtbga12rateall.Text = finalvalue.ToString();

            }

            if (lblBGEMetertype.Text == "Off Peak")
            {
                finalvalue = lib.OffPeak(sc, offpeak, eac);
                txtbga12rateall.Text = finalvalue.ToString();

            }


        }
        void bga24()
        {

            double finalvalue = 0;

            double sc = Convert.ToDouble(txtbga24sc.Text);
            double dayc = Convert.ToDouble(txtbga24day.ToolTip);
            double nightprice = Convert.ToDouble(txtbga24night.ToolTip);
            double weekend = Convert.ToDouble(txtbga24ew.ToolTip);
     //       double unitc = Convert.ToDouble(txtbga24unit.ToolTip);
       //     double wd = Convert.ToDouble(txtbga24wd.ToolTip);
            double offpeak = Convert.ToDouble(txtbga24offpeak.ToolTip);
            //   double otherc = Convert.ToDouble(txtbga12other.ToolTip.ToString());
            double upliftc = Convert.ToDouble(txtbga24uplift.Text);

            double eac = Convert.ToDouble(lblEac.Text);

            if (txtbga24day.Text != "0")
            {
                dayc = dayc + upliftc;
                txtbga24day.Text = dayc.ToString();
            }

            if (txtbga24night.Text != "0")
            {
                nightprice = nightprice + upliftc;
                txtbga24night.Text = nightprice.ToString();
            }

            if (txtbga24ew.Text != "0")
            {
                weekend = weekend + upliftc;
                txtbga24ew.Text = weekend.ToString();
            }

            //if (txtbga24unit.Text != "0")
            //{
            //    unitc = unitc + upliftc;
            //    txtbga24unit.Text = unitc.ToString();
            //}

            //if (txtbga24wd.Text != "0")
            //{
            //    wd = wd + upliftc;
            //    txtbga24wd.Text = wd.ToString();
            //}

            if (txtbga24offpeak.Text != "0")
            {
                offpeak = offpeak + upliftc;
                txtbga24offpeak.Text = offpeak.ToString();
            }

            //if (txtbga12other.Text != "0")
            //{
            //    otherc = otherc + upliftc;
            //    txtbga12other.Text = otherc.ToString();
            //}


            if (lblBGEMetertype.Text == "Single Rate")
            {
                finalvalue = lib.SingleRatebg(sc, dayc, eac);
                txtbga24rate.Text = finalvalue.ToString();
            }

            if (lblBGEMetertype.Text == "Day & Night")
            {
                finalvalue = lib.Daynight(sc, dayc, nightprice, eac);
                txtbga24rate.Text = finalvalue.ToString();
            }
            if (lblBGEMetertype.Text == "Eve/Weekend & Night")
            {
                finalvalue = lib.Ewn(sc, dayc, nightprice, weekend, eac);
                txtbga24rate.Text = finalvalue.ToString();

            }

            if (lblBGEMetertype.Text == "Eve/Weekend")
            {
                finalvalue = lib.EW(sc, dayc, weekend, eac);
                txtbga24rate.Text = finalvalue.ToString();

            }

            if (lblBGEMetertype.Text == "Off Peak")
            {
                finalvalue = lib.OffPeak(sc, offpeak, eac);
                txtbga24rate.Text = finalvalue.ToString();

            }


        }
        void bga24all()
        {
            double finalvalue = 0;

            double sc = Convert.ToDouble(txtbga24scall.Text);
            double dayc = Convert.ToDouble(txtbga24dayall.ToolTip);
            double nightprice = Convert.ToDouble(txtbga24nightall.ToolTip);
            double weekend = Convert.ToDouble(txtbga24ewall.ToolTip);
           // double unitc = Convert.ToDouble(txtbga24unitall.ToolTip);
           // double wd = Convert.ToDouble(txtbga24wdall.ToolTip);
            double offpeak = Convert.ToDouble(txtbga24offpeakall.ToolTip);
            //   double otherc = Convert.ToDouble(txtbga12other.ToolTip.ToString());
            double upliftc = Convert.ToDouble(txtbga24upliftall.Text);

            double eac = Convert.ToDouble(lblEac.Text);

            if (txtbga24dayall.Text != "0")
            {
                dayc = dayc + upliftc;
                txtbga24dayall.Text = dayc.ToString();
            }

            if (txtbga24nightall.Text != "0")
            {
                nightprice = nightprice + upliftc;
                txtbga24nightall.Text = nightprice.ToString();
            }

            if (txtbga24ewall.Text != "0")
            {
                weekend = weekend + upliftc;
                txtbga24ewall.Text = weekend.ToString();
            }

            //if (txtbga24unitall.Text != "0")
            //{
            //    unitc = unitc + upliftc;
            //    txtbga24unitall.Text = unitc.ToString();
            //}

            //if (txtbga24wd.Text != "0")
            //{
            //    wd = wd + upliftc;
            //    txtbga24wdall.Text = wd.ToString();
            //}

            if (txtbga24offpeak.Text != "0")
            {
                offpeak = offpeak + upliftc;
                txtbga24offpeakall.Text = offpeak.ToString();
            }

            //if (txtbga24other.Text != "0")
            //{
            //    otherc = otherc + upliftc;
            //    txtbga24other.Text = otherc.ToString();
            //}











            if (lblBGEMetertype.Text == "Single Rate")
            {
                finalvalue = lib.SingleRatebg(sc, dayc, eac);
                txtbga24rateall.Text = finalvalue.ToString();
            }

            if (lblBGEMetertype.Text == "Day & Night")
            {
                finalvalue = lib.Daynight(sc, dayc, nightprice, eac);
                txtbga24rateall.Text = finalvalue.ToString();
            }
            if (lblBGEMetertype.Text == "Eve/Weekend & Night")
            {
                finalvalue = lib.Ewn(sc, dayc, nightprice, weekend, eac);
                txtbga24rateall.Text = finalvalue.ToString();

            }

            if (lblBGEMetertype.Text == "Eve/Weekend")
            {
                finalvalue = lib.EW(sc, dayc, weekend, eac);
                txtbga24rateall.Text = finalvalue.ToString();

            }

            if (lblBGEMetertype.Text == "Off Peak")
            {
                finalvalue = lib.OffPeak(sc, offpeak, eac);
                txtbga24rateall.Text = finalvalue.ToString();

            }


        }

        void bga36()
        {

            double finalvalue = 0;

            double sc = Convert.ToDouble(txtbga36sc.Text);
            double dayc = Convert.ToDouble(txtbga36day.ToolTip);
            double nightprice = Convert.ToDouble(txtbga36night.ToolTip);
            double weekend = Convert.ToDouble(txtbga36ew.ToolTip);
       //     double unitc = Convert.ToDouble(txtbga36unit.ToolTip);
       //     double wd = Convert.ToDouble(txtbga36wd.ToolTip);
            double offpeak = Convert.ToDouble(txtbga36offpeak.ToolTip);
            //   double otherc = Convert.ToDouble(txtbga12other.ToolTip.ToString());
            double upliftc = Convert.ToDouble(txtbga36uplift.Text);

            double eac = Convert.ToDouble(lblEac.Text);

            if (txtbga36day.Text != "0")
            {
                dayc = dayc + upliftc;
                txtbga36day.Text = dayc.ToString();
            }

            if (txtbga36night.Text != "0")
            {
                nightprice = nightprice + upliftc;
                txtbga36night.Text = nightprice.ToString();
            }

            if (txtbga36ew.Text != "0")
            {
                weekend = weekend + upliftc;
                txtbga36ew.Text = weekend.ToString();
            }

            //if (txtbga36unit.Text != "0")
            //{
            //    unitc = unitc + upliftc;
            //    txtbga36unit.Text = unitc.ToString();
            //}

            //if (txtbga36wd.Text != "0")
            //{
            //    wd = wd + upliftc;
            //    txtbga36wd.Text = wd.ToString();
            //}

            if (txtbga36offpeak.Text != "0")
            {
                offpeak = offpeak + upliftc;
                txtbga36offpeak.Text = offpeak.ToString();
            }

            //if (txtbga12other.Text != "0")
            //{
            //    otherc = otherc + upliftc;
            //    txtbga12other.Text = otherc.ToString();
            //}


            if (lblBGEMetertype.Text == "Single Rate")
            {
                finalvalue = lib.SingleRatebg(sc, dayc, eac);
                txtbga36rate.Text = finalvalue.ToString();
            }

            if (lblBGEMetertype.Text == "Day & Night")
            {
                finalvalue = lib.Daynight(sc, dayc, nightprice, eac);
                txtbga36rate.Text = finalvalue.ToString();
            }
            if (lblBGEMetertype.Text == "Eve/Weekend & Night")
            {
                finalvalue = lib.Ewn(sc, dayc, nightprice, weekend, eac);
                txtbga36rate.Text = finalvalue.ToString();

            }

            if (lblBGEMetertype.Text == "Eve/Weekend")
            {
                finalvalue = lib.EW(sc, dayc, weekend, eac);
                txtbga36rate.Text = finalvalue.ToString();

            }

            if (lblBGEMetertype.Text == "Off Peak")
            {
                finalvalue = lib.OffPeak(sc, offpeak, eac);
                txtbga36rate.Text = finalvalue.ToString();

            }


        }

        void bga36all()
        {

            double finalvalue = 0;

            double sc = Convert.ToDouble(txtbga36scall.Text);
            double dayc = Convert.ToDouble(txtbga36dayall.ToolTip);
            double nightprice = Convert.ToDouble(txtbga36nightall.ToolTip);
            double weekend = Convert.ToDouble(txtbga36ewall.ToolTip);
           // double unitc = Convert.ToDouble(txtbga36unitall.ToolTip);
           // double wd = Convert.ToDouble(txtbga36wdall.ToolTip);
            double offpeak = Convert.ToDouble(txtbga36offpeakall.ToolTip);
            //   double otherc = Convert.ToDouble(txtbga12other.ToolTip.ToString());
            double upliftc = Convert.ToDouble(txtbga36upliftall.Text);

            double eac = Convert.ToDouble(lblEac.Text);

            if (txtbga36day.Text != "0")
            {
                dayc = dayc + upliftc;
                txtbga36dayall.Text = dayc.ToString();
            }

            if (txtbga36night.Text != "0")
            {
                nightprice = nightprice + upliftc;
                txtbga36nightall.Text = nightprice.ToString();
            }

            if (txtbga24ew.Text != "0")
            {
                weekend = weekend + upliftc;
                txtbga36ewall.Text = weekend.ToString();
            }

            //if (txtbga36unit.Text != "0")
            //{
            //    unitc = unitc + upliftc;
            //    txtbga36unitall.Text = unitc.ToString();
            //}

            //if (txtbga36wd.Text != "0")
            //{
            //    wd = wd + upliftc;
            //    txtbga36wdall.Text = wd.ToString();
            //}

            if (txtbga36offpeak.Text != "0")
            {
                offpeak = offpeak + upliftc;
                txtbga36offpeakall.Text = offpeak.ToString();
            }

            //if (txtbga12other.Text != "0")
            //{
            //    otherc = otherc + upliftc;
            //    txtbga12other.Text = otherc.ToString();
            //}


            if (lblBGEMetertype.Text == "Single Rate")
            {
                finalvalue = lib.SingleRatebg(sc, dayc, eac);
                txtbga36rateall.Text = finalvalue.ToString();
            }

            if (lblBGEMetertype.Text == "Day & Night")
            {
                finalvalue = lib.Daynight(sc, dayc, nightprice, eac);
                txtbga36rateall.Text = finalvalue.ToString();
            }
            if (lblBGEMetertype.Text == "Eve/Weekend & Night")
            {
                finalvalue = lib.Ewn(sc, dayc, nightprice, weekend, eac);
                txtbga36rate.Text = finalvalue.ToString();

            }

            if (lblBGEMetertype.Text == "Eve/Weekend")
            {
                finalvalue = lib.EW(sc, dayc, weekend, eac);
                txtbga36rateall.Text = finalvalue.ToString();

            }

            if (lblBGEMetertype.Text == "Off Peak")
            {
                finalvalue = lib.OffPeak(sc, offpeak, eac);
                txtbga36rateall.Text = finalvalue.ToString();

            }


        }
        void bga48()
        {

            double finalvalue = 0;

            double sc = Convert.ToDouble(txtbga48sc.Text);
            double dayc = Convert.ToDouble(txtbga48day.ToolTip);
            double nightprice = Convert.ToDouble(txtbga48night.ToolTip);
            double weekend = Convert.ToDouble(txtbga48ew.ToolTip);
            //double unitc = Convert.ToDouble(txtbga48unit.ToolTip);
            //double wd = Convert.ToDouble(txtbga48wd.ToolTip);
            double offpeak = Convert.ToDouble(txtbga48offpeak.ToolTip);
            //   double otherc = Convert.ToDouble(txtbga12other.ToolTip.ToString());
            double upliftc = Convert.ToDouble(txtbga48uplift.Text);

            double eac = Convert.ToDouble(lblEac.Text);

            if (txtbga48day.Text != "0")
            {
                dayc = dayc + upliftc;
                txtbga24day.Text = dayc.ToString();
            }

            if (txtbga48night.Text != "0")
            {
                nightprice = nightprice + upliftc;
                txtbga48night.Text = nightprice.ToString();
            }

            if (txtbga24ew.Text != "0")
            {
                weekend = weekend + upliftc;
                txtbga48ew.Text = weekend.ToString();
            }

            //if (txtbga48unit.Text != "0")
            //{
            //    unitc = unitc + upliftc;
            //    txtbga48unit.Text = unitc.ToString();
            //}

            //if (txtbga48wd.Text != "0")
            //{
            //    wd = wd + upliftc;
            //    txtbga48wd.Text = wd.ToString();
            //}

            if (txtbga48offpeak.Text != "0")
            {
                offpeak = offpeak + upliftc;
                txtbga48offpeak.Text = offpeak.ToString();
            }

            //if (txtbga12other.Text != "0")
            //{
            //    otherc = otherc + upliftc;
            //    txtbga12other.Text = otherc.ToString();
            //}


            if (lblBGEMetertype.Text == "Single Rate")
            {
                finalvalue = lib.SingleRatebg(sc, dayc, eac);
                txtbga48rate.Text = finalvalue.ToString();
            }

            if (lblBGEMetertype.Text == "Day & Night")
            {
                finalvalue = lib.Daynight(sc, dayc, nightprice, eac);
                txtbga48rate.Text = finalvalue.ToString();
            }
            if (lblBGEMetertype.Text == "Eve/Weekend & Night")
            {
                finalvalue = lib.Ewn(sc, dayc, nightprice, weekend, eac);
                txtbga48rate.Text = finalvalue.ToString();

            }

            if (lblBGEMetertype.Text == "Eve/Weekend")
            {
                finalvalue = lib.EW(sc, dayc, weekend, eac);
                txtbga48rate.Text = finalvalue.ToString();

            }

            if (lblBGEMetertype.Text == "Off Peak")
            {
                finalvalue = lib.OffPeak(sc, offpeak, eac);
                txtbga48rate.Text = finalvalue.ToString();

            }


        }

        void bga48all()
        {

            double finalvalue = 0;

            double sc = Convert.ToDouble(txtbga48scall.Text);
            double dayc = Convert.ToDouble(txtbga48dayall.ToolTip);
            double nightprice = Convert.ToDouble(txtbga48nightall.ToolTip);
            double weekend = Convert.ToDouble(txtbga48ewall.ToolTip);
            //double unitc = Convert.ToDouble(txtbga48unitall.ToolTip);
            //double wd = Convert.ToDouble(txtbga48wdall.ToolTip);
            double offpeak = Convert.ToDouble(txtbga48offpeakall.ToolTip);
            //   double otherc = Convert.ToDouble(txtbga12other.ToolTip.ToString());
            double upliftc = Convert.ToDouble(txtbga48upliftall.Text);

            double eac = Convert.ToDouble(lblEac.Text);

            if (txtbga48day.Text != "0")
            {
                dayc = dayc + upliftc;
                txtbga48dayall.Text = dayc.ToString();
            }

            if (txtbga48night.Text != "0")
            {
                nightprice = nightprice + upliftc;
                txtbga48nightall.Text = nightprice.ToString();
            }

            if (txtbga24ew.Text != "0")
            {
                weekend = weekend + upliftc;
                txtbga48ewall.Text = weekend.ToString();
            }

            //if (txtbga48unit.Text != "0")
            //{
            //    unitc = unitc + upliftc;
            //    txtbga48unitall.Text = unitc.ToString();
            //}

            //if (txtbga48wd.Text != "0")
            //{
            //    wd = wd + upliftc;
            //    txtbga48wdall.Text = wd.ToString();
            //}

            if (txtbga48offpeak.Text != "0")
            {
                offpeak = offpeak + upliftc;
                txtbga48offpeakall.Text = offpeak.ToString();
            }

            //if (txtbga12other.Text != "0")
            //{
            //    otherc = otherc + upliftc;
            //    txtbga12other.Text = otherc.ToString();
            //}


            if (lblBGEMetertype.Text == "Single Rate")
            {
                finalvalue = lib.SingleRatebg(sc, dayc, eac);
                txtbfga48rateall.Text = finalvalue.ToString();
            }

            if (lblBGEMetertype.Text == "Day & Night")
            {
                finalvalue = lib.Daynight(sc, dayc, nightprice, eac);
                txtbfga48rateall.Text = finalvalue.ToString();
            }
            if (lblBGEMetertype.Text == "Eve/Weekend & Night")
            {
                finalvalue = lib.Ewn(sc, dayc, nightprice, weekend, eac);
                txtbfga48rateall.Text = finalvalue.ToString();

            }

            if (lblBGEMetertype.Text == "Eve/Weekend")
            {
                finalvalue = lib.EW(sc, dayc, weekend, eac);
                txtbfga48rateall.Text = finalvalue.ToString();

            }

            if (lblBGEMetertype.Text == "Off Peak")
            {
                finalvalue = lib.OffPeak(sc, offpeak, eac);
                txtbfga48rateall.Text = finalvalue.ToString();

            }


        }


        void bga60()
        {

            double finalvalue = 0;

            double sc = Convert.ToDouble(txtbga60sc.Text);
            double dayc = Convert.ToDouble(txtbga60day.ToolTip);
            double nightprice = Convert.ToDouble(txtbga60night.ToolTip);
            double weekend = Convert.ToDouble(txtbga60ew.ToolTip);
            //double unitc = Convert.ToDouble(txtbga60unit.ToolTip);
            //double wd = Convert.ToDouble(txtbga60wd.ToolTip);
            double offpeak = Convert.ToDouble(txtbga60offpeak.ToolTip);
            //   double otherc = Convert.ToDouble(txtbga12other.ToolTip.ToString());
            double upliftc = Convert.ToDouble(txtbga60uplift.Text);

            double eac = Convert.ToDouble(lblEac.Text);

            if (txtbga60day.Text != "0")
            {
                dayc = dayc + upliftc;
                txtbga24day.Text = dayc.ToString();
            }

            if (txtbga60night.Text != "0")
            {
                nightprice = nightprice + upliftc;
                txtbga60night.Text = nightprice.ToString();
            }

            if (txtbga24ew.Text != "0")
            {
                weekend = weekend + upliftc;
                txtbga60ew.Text = weekend.ToString();
            }

            //if (txtbga60unit.Text != "0")
            //{
            //    unitc = unitc + upliftc;
            //    txtbga60unit.Text = unitc.ToString();
            //}

            //if (txtbga60wd.Text != "0")
            //{
            //    wd = wd + upliftc;
            //    txtbga60wd.Text = wd.ToString();
            //}

            if (txtbga60offpeak.Text != "0")
            {
                offpeak = offpeak + upliftc;
                txtbga60offpeak.Text = offpeak.ToString();
            }

            //if (txtbga12other.Text != "0")
            //{
            //    otherc = otherc + upliftc;
            //    txtbga12other.Text = otherc.ToString();
            //}


            if (lblBGEMetertype.Text == "Single Rate")
            {
                finalvalue = lib.SingleRatebg(sc, dayc, eac);
                txtbga60rate.Text = finalvalue.ToString();
            }

            if (lblBGEMetertype.Text == "Day & Night")
            {
                finalvalue = lib.Daynight(sc, dayc, nightprice, eac);
                txtbga60rate.Text = finalvalue.ToString();
            }
            if (lblBGEMetertype.Text == "Eve/Weekend & Night")
            {
                finalvalue = lib.Ewn(sc, dayc, nightprice, weekend, eac);
                txtbga60rate.Text = finalvalue.ToString();

            }

            if (lblBGEMetertype.Text == "Eve/Weekend")
            {
                finalvalue = lib.EW(sc, dayc, weekend, eac);
                txtbga60rate.Text = finalvalue.ToString();

            }

            if (lblBGEMetertype.Text == "Off Peak")
            {
                finalvalue = lib.OffPeak(sc, offpeak, eac);
                txtbga60rate.Text = finalvalue.ToString();

            }


        }

        void bga60all()
        {

            double finalvalue = 0;

            double sc = Convert.ToDouble(txtbga60scall.Text);
            double dayc = Convert.ToDouble(txtbga60dayall.ToolTip);
            double nightprice = Convert.ToDouble(txtbga60nightall.ToolTip);
            double weekend = Convert.ToDouble(txtbga60ewall.ToolTip);
            //double unitc = Convert.ToDouble(txtbga60unitall.ToolTip);
            //double wd = Convert.ToDouble(txtbga60wdall.ToolTip);
            double offpeak = Convert.ToDouble(txtbga60offpeakall.ToolTip);
            //   double otherc = Convert.ToDouble(txtbga12other.ToolTip.ToString());
            double upliftc = Convert.ToDouble(txtbga60upliftall.Text);

            double eac = Convert.ToDouble(lblEac.Text);

            if (txtbga60day.Text != "0")
            {
                dayc = dayc + upliftc;
                txtbga60dayall.Text = dayc.ToString();
            }

            if (txtbga60night.Text != "0")
            {
                nightprice = nightprice + upliftc;
                txtbga60nightall.Text = nightprice.ToString();
            }

            if (txtbga24ew.Text != "0")
            {
                weekend = weekend + upliftc;
                txtbga60ewall.Text = weekend.ToString();
            }

            //if (txtbga60unit.Text != "0")
            //{
            //    unitc = unitc + upliftc;
            //    txtbga60unitall.Text = unitc.ToString();
            //}

            //if (txtbga60wd.Text != "0")
            //{
            //    wd = wd + upliftc;
            //    txtbga60wdall.Text = wd.ToString();
            //}

            if (txtbga60offpeak.Text != "0")
            {
                offpeak = offpeak + upliftc;
                txtbga60offpeakall.Text = offpeak.ToString();
            }

           


            if (lblBGEMetertype.Text == "Single Rate")
            {
                finalvalue = lib.SingleRatebg(sc, dayc, eac);
                txtbga60rateall.Text = finalvalue.ToString();
            }

            if (lblBGEMetertype.Text == "Day & Night")
            {
                finalvalue = lib.Daynight(sc, dayc, nightprice, eac);
                txtbga60rateall.Text = finalvalue.ToString();
            }
            if (lblBGEMetertype.Text == "Eve/Weekend & Night")
            {
                finalvalue = lib.Ewn(sc, dayc, nightprice, weekend, eac);
                txtbga60rate.Text = finalvalue.ToString();

            }

            if (lblBGEMetertype.Text == "Eve/Weekend")
            {
                finalvalue = lib.EW(sc, dayc, weekend, eac);
                txtbga60rateall.Text = finalvalue.ToString();

            }

            if (lblBGEMetertype.Text == "Off Peak")
            {
                finalvalue = lib.OffPeak(sc, offpeak, eac);
                txtbga60rateall.Text = finalvalue.ToString();

            }


        }


        #endregion

        #region BG Uplift calculation for Existing custome

        void bge12()
        {
            double finalvalue = 0;

            double sc = Convert.ToDouble(txtbge12sc.Text);
            double dayc = Convert.ToDouble(txtbge12day.ToolTip);
            double nightprice = Convert.ToDouble(txtbge12night.ToolTip);
            double weekend = Convert.ToDouble(txtbge12ew.ToolTip);
            //double unitc = Convert.ToDouble(txtbge12unit.ToolTip);
            //double wd = Convert.ToDouble(txtbge12wd.ToolTip);
            double offpeak = Convert.ToDouble(txtbge12offpeak.ToolTip);
            //   double otherc = Convert.ToDouble(txtbge12other.ToolTip.ToString());
            double upliftc = Convert.ToDouble(txtbge12uplift.Text);

            double eac = Convert.ToDouble(lblEac.Text);

            if (txtbge12day.Text != "0")
            {
                dayc = dayc + upliftc;
                txtbge12day.Text = dayc.ToString();
            }

            if (txtbge12night.Text != "0")
            {
                nightprice = nightprice + upliftc;
                txtbge12night.Text = nightprice.ToString();
            }

            if (txtbge12ew.Text != "0")
            {
                weekend = weekend + upliftc;
                txtbge12ew.Text = weekend.ToString();
            }

            //if (txtbge12unit.Text != "0")
            //{
            //    unitc = unitc + upliftc;
            //    txtbge12unit.Text = unitc.ToString();
            //}

            //if (txtbge12wd.Text != "0")
            //{
            //    wd = wd + upliftc;
            //    txtbge12wd.Text = wd.ToString();
            //}

            if (txtbge12offpeak.Text != "0")
            {
                offpeak = offpeak + upliftc;
                txtbge12offpeak.Text = offpeak.ToString();
            }

            //if (txtbge12other.Text != "0")
            //{
            //    otherc = otherc + upliftc;
            //    txtbge12other.Text = otherc.ToString();
            //}











            if (lblBGEMetertype.Text == "Single Rate")
            {
                finalvalue = lib.SingleRatebg(sc, dayc, eac);
                txtbge12rate.Text = finalvalue.ToString();
            }

            if (lblBGEMetertype.Text == "Day & Night")
            {
                finalvalue = lib.Daynight(sc, dayc, nightprice, eac);
                txtbge12rate.Text = finalvalue.ToString();
            }
            if (lblBGEMetertype.Text == "Eve/Weekend & Night")
            {
                finalvalue = lib.Ewn(sc, dayc, nightprice, weekend, eac);
                txtbge12rate.Text = finalvalue.ToString();

            }

            if (lblBGEMetertype.Text == "Eve/Weekend")
            {
                finalvalue = lib.EW(sc, dayc, weekend, eac);
                txtbge12rate.Text = finalvalue.ToString();

            }

            if (lblBGEMetertype.Text == "Off Peak")
            {
                finalvalue = lib.OffPeak(sc, offpeak, eac);
                txtbge12rate.Text = finalvalue.ToString();

            }


        }

        void Bge12all()
        {
            double finalvalue = 0;

            double sc = Convert.ToDouble(txtbge12scall.Text);
            double dayc = Convert.ToDouble(txtbge12dayall.ToolTip);
            double nightprice = Convert.ToDouble(txtbge12nightall.ToolTip);
            double weekend = Convert.ToDouble(txtbge12ewall.ToolTip);
            //double unitc = Convert.ToDouble(txtbge12unitall.ToolTip);
            //double wd = Convert.ToDouble(txtbge12wdall.ToolTip);
            double offpeak = Convert.ToDouble(txtbge12offpeak.ToolTip);
            //   double otherc = Convert.ToDouble(txtbge12other.ToolTip.ToString());
            double upliftc = Convert.ToDouble(txtbge12upliftall.Text);

            double eac = Convert.ToDouble(lblEac.Text);

            if (txtbge12dayall.Text != "0")
            {
                dayc = dayc + upliftc;
                txtbge12dayall.Text = dayc.ToString();
            }

            if (txtbge12nightall.Text != "0")
            {
                nightprice = nightprice + upliftc;
                txtbge12nightall.Text = nightprice.ToString();
            }

            if (txtbge12ewall.Text != "0")
            {
                weekend = weekend + upliftc;
                txtbge12ewall.Text = weekend.ToString();
            }

            //if (txtbge12unitall.Text != "0")
            //{
            //    unitc = unitc + upliftc;
            //    txtbge12unitall.Text = unitc.ToString();
            //}

            //if (txtbge12wdall.Text != "0")
            //{
            //    wd = wd + upliftc;
            //    txtbge12wdall.Text = wd.ToString();
            //}

            if (txtbge12offpeak.Text != "0")
            {
                offpeak = offpeak + upliftc;
                txtbge12offpeakall.Text = offpeak.ToString();
            }

            //if (txtbge12other.Text != "0")
            //{
            //    otherc = otherc + upliftc;
            //    txtbge12other.Text = otherc.ToString();
            //}



            if (lblBGEMetertype.Text == "Single Rate")
            {
                finalvalue = lib.SingleRatebg(sc, dayc, eac);
                txtbge12rateall.Text = finalvalue.ToString();
            }

            if (lblBGEMetertype.Text == "Day & Night")
            {
                finalvalue = lib.Daynight(sc, dayc, nightprice, eac);
                txtbge12rateall.Text = finalvalue.ToString();
            }
            if (lblBGEMetertype.Text == "Eve/Weekend & Night")
            {
                finalvalue = lib.Ewn(sc, dayc, nightprice, weekend, eac);
                txtbge12rateall.Text = finalvalue.ToString();

            }

            if (lblBGEMetertype.Text == "Eve/Weekend")
            {
                finalvalue = lib.EW(sc, dayc, weekend, eac);
                txtbge12rateall.Text = finalvalue.ToString();

            }

            if (lblBGEMetertype.Text == "Off Peak")
            {
                finalvalue = lib.OffPeak(sc, offpeak, eac);
                txtbge12rateall.Text = finalvalue.ToString();

            }


        }

        void Bge24()
        {
            double finalvalue = 0;

            double sc = Convert.ToDouble(txtbge24sc.Text);
            double dayc = Convert.ToDouble(txtbge24day.ToolTip);
            double nightprice = Convert.ToDouble(txtbge24night.ToolTip);
            double weekend = Convert.ToDouble(txtbge24ew.ToolTip);
            //double unitc = Convert.ToDouble(txtbge24unit.ToolTip);
            //double wd = Convert.ToDouble(txtbge24wd.ToolTip);
            double offpeak = Convert.ToDouble(txtbge24offpeak.ToolTip);
            //   double otherc = Convert.ToDouble(txtbge24other.ToolTip.ToString());
            double upliftc = Convert.ToDouble(txtbge24uplift.Text);

            double eac = Convert.ToDouble(lblEac.Text);

            if (txtbge24day.Text != "0")
            {
                dayc = dayc + upliftc;
                txtbge24day.Text = dayc.ToString();
            }

            if (txtbge24night.Text != "0")
            {
                nightprice = nightprice + upliftc;
                txtbge24night.Text = nightprice.ToString();
            }

            if (txtbge24ew.Text != "0")
            {
                weekend = weekend + upliftc;
                txtbge24ew.Text = weekend.ToString();
            }

            //if (txtbge24unit.Text != "0")
            //{
            //    unitc = unitc + upliftc;
            //    txtbge24unit.Text = unitc.ToString();
            //}

            //if (txtbge24wd.Text != "0")
            //{
            //    wd = wd + upliftc;
            //    txtbge24wd.Text = wd.ToString();
            //}

            if (txtbge24offpeak.Text != "0")
            {
                offpeak = offpeak + upliftc;
                txtbge24offpeak.Text = offpeak.ToString();
            }

            //if (txtbge24other.Text != "0")
            //{
            //    otherc = otherc + upliftc;
            //    txtbge24other.Text = otherc.ToString();
            //}




            if (lblBGEMetertype.Text == "Single Rate")
            {
                finalvalue = lib.SingleRatebg(sc, dayc, eac);
                txtbfge24rate.Text = finalvalue.ToString();
            }

            if (lblBGEMetertype.Text == "Day & Night")
            {
                finalvalue = lib.Daynight(sc, dayc, nightprice, eac);
                txtbfge24rate.Text = finalvalue.ToString();
            }
            if (lblBGEMetertype.Text == "Eve/Weekend & Night")
            {
                finalvalue = lib.Ewn(sc, dayc, nightprice, weekend, eac);
                txtbfge24rate.Text = finalvalue.ToString();

            }

            if (lblBGEMetertype.Text == "Eve/Weekend")
            {
                finalvalue = lib.EW(sc, dayc, weekend, eac);
                txtbfge24rate.Text = finalvalue.ToString();

            }

            if (lblBGEMetertype.Text == "Off Peak")
            {
                finalvalue = lib.OffPeak(sc, offpeak, eac);
                txtbfge24rate.Text = finalvalue.ToString();

            }


        }

        void Bge24all()
        {
            double finalvalue = 0;

            double sc = Convert.ToDouble(txtbge24scall.Text);
            double dayc = Convert.ToDouble(txtbge24dayall.ToolTip);
            double nightprice = Convert.ToDouble(txtbge24nightall.ToolTip);
            double weekend = Convert.ToDouble(txtbge24ewall.ToolTip);
            //double unitc = Convert.ToDouble(txtbge24unitall.ToolTip);
            //double wd = Convert.ToDouble(txtbge24wdall.ToolTip);
            double offpeak = Convert.ToDouble(txtbge24offpeak.ToolTip);
            //   double otherc = Convert.ToDouble(txtbge24other.ToolTip.ToString());
            double upliftc = Convert.ToDouble(txtbge24upliftall.Text);

            double eac = Convert.ToDouble(lblEac.Text);

            if (txtbge24dayall.Text != "0")
            {
                dayc = dayc + upliftc;
                txtbge24dayall.Text = dayc.ToString();
            }

            if (txtbge24nightall.Text != "0")
            {
                nightprice = nightprice + upliftc;
                txtbge24nightall.Text = nightprice.ToString();
            }

            if (txtbge24ewall.Text != "0")
            {
                weekend = weekend + upliftc;
                txtbge24ewall.Text = weekend.ToString();
            }

            //if (txtbge24unitall.Text != "0")
            //{
            //    unitc = unitc + upliftc;
            //    txtbge24unitall.Text = unitc.ToString();
            //}

            //if (txtbge24wdall.Text != "0")
            //{
            //    wd = wd + upliftc;
            //    txtbge24wdall.Text = wd.ToString();
            //}

            if (txtbge24offpeak.Text != "0")
            {
                offpeak = offpeak + upliftc;
                txtbge24offpeakall.Text = offpeak.ToString();
            }

            //if (txtbge24other.Text != "0")
            //{
            //    otherc = otherc + upliftc;
            //    txtbge24other.Text = otherc.ToString();
            //}



            if (lblBGEMetertype.Text == "Single Rate")
            {
                finalvalue = lib.SingleRatebg(sc, dayc, eac);
                txtbge24rateall.Text = finalvalue.ToString();
            }

            if (lblBGEMetertype.Text == "Day & Night")
            {
                finalvalue = lib.Daynight(sc, dayc, nightprice, eac);
                txtbge24rateall.Text = finalvalue.ToString();
            }
            if (lblBGEMetertype.Text == "Eve/Weekend & Night")
            {
                finalvalue = lib.Ewn(sc, dayc, nightprice, weekend, eac);
                txtbge24rateall.Text = finalvalue.ToString();

            }

            if (lblBGEMetertype.Text == "Eve/Weekend")
            {
                finalvalue = lib.EW(sc, dayc, weekend, eac);
                txtbge24rateall.Text = finalvalue.ToString();

            }

            if (lblBGEMetertype.Text == "Off Peak")
            {
                finalvalue = lib.OffPeak(sc, offpeak, eac);
                txtbge24rateall.Text = finalvalue.ToString();

            }


        }

        void Bge36()
        {
            double finalvalue = 0;

            double sc = Convert.ToDouble(txtbge36sc.Text);
            double dayc = Convert.ToDouble(txtbge36day.ToolTip);
            double nightprice = Convert.ToDouble(txtbge36night.ToolTip);
            double weekend = Convert.ToDouble(txtbge36ew.ToolTip);
            //double unitc = Convert.ToDouble(txtbge36unit.ToolTip);
            //double wd = Convert.ToDouble(txtbge36wd.ToolTip);
            double offpeak = Convert.ToDouble(txtbge36offpeak.ToolTip);
            //   double otherc = Convert.ToDouble(txtbge36other.ToolTip.ToString());
            double upliftc = Convert.ToDouble(txtbge36uplift.Text);

            double eac = Convert.ToDouble(lblEac.Text);

            if (txtbge36day.Text != "0")
            {
                dayc = dayc + upliftc;
                txtbge36day.Text = dayc.ToString();
            }

            if (txtbge36night.Text != "0")
            {
                nightprice = nightprice + upliftc;
                txtbge36night.Text = nightprice.ToString();
            }

            if (txtbge36ew.Text != "0")
            {
                weekend = weekend + upliftc;
                txtbge36ew.Text = weekend.ToString();
            }

            //if (txtbge36unit.Text != "0")
            //{
            //    unitc = unitc + upliftc;
            //    txtbge36unit.Text = unitc.ToString();
            //}

            //if (txtbge36wd.Text != "0")
            //{
            //    wd = wd + upliftc;
            //    txtbge36wd.Text = wd.ToString();
            //}

            if (txtbge36offpeak.Text != "0")
            {
                offpeak = offpeak + upliftc;
                txtbge36offpeak.Text = offpeak.ToString();
            }

            //if (txtbge36other.Text != "0")
            //{
            //    otherc = otherc + upliftc;
            //    txtbge36other.Text = otherc.ToString();
            //}




            if (lblBGEMetertype.Text == "Single Rate")
            {
                finalvalue = lib.SingleRatebg(sc, dayc, eac);
                txtbfge36rate.Text = finalvalue.ToString();
            }

            if (lblBGEMetertype.Text == "Day & Night")
            {
                finalvalue = lib.Daynight(sc, dayc, nightprice, eac);
                txtbfge36rate.Text = finalvalue.ToString();
            }
            if (lblBGEMetertype.Text == "Eve/Weekend & Night")
            {
                finalvalue = lib.Ewn(sc, dayc, nightprice, weekend, eac);
                txtbfge36rate.Text = finalvalue.ToString();

            }

            if (lblBGEMetertype.Text == "Eve/Weekend")
            {
                finalvalue = lib.EW(sc, dayc, weekend, eac);
                txtbfge36rate.Text = finalvalue.ToString();

            }

            if (lblBGEMetertype.Text == "Off Peak")
            {
                finalvalue = lib.OffPeak(sc, offpeak, eac);
                txtbfge36rate.Text = finalvalue.ToString();

            }


        }

        void Bge36all()
        {
            double finalvalue = 0;

            double sc = Convert.ToDouble(txtbge36scall.Text);
            double dayc = Convert.ToDouble(txtbge36dayall.ToolTip);
            double nightprice = Convert.ToDouble(txtbge36nightall.ToolTip);
            double weekend = Convert.ToDouble(txtbge36ewall.ToolTip);
            //double unitc = Convert.ToDouble(txtbge36unitall.ToolTip);
            //double wd = Convert.ToDouble(txtbge36wdall.ToolTip);
            double offpeak = Convert.ToDouble(txtbge36offpeak.ToolTip);
            //   double otherc = Convert.ToDouble(txtbge36other.ToolTip.ToString());
            double upliftc = Convert.ToDouble(txtbge36upliftall.Text);

            double eac = Convert.ToDouble(lblEac.Text);

            if (txtbge36dayall.Text != "0")
            {
                dayc = dayc + upliftc;
                txtbge36dayall.Text = dayc.ToString();
            }

            if (txtbge36nightall.Text != "0")
            {
                nightprice = nightprice + upliftc;
                txtbge36nightall.Text = nightprice.ToString();
            }

            if (txtbge36ewall.Text != "0")
            {
                weekend = weekend + upliftc;
                txtbge36ewall.Text = weekend.ToString();
            }

            //if (txtbge36unitall.Text != "0")
            //{
            //    unitc = unitc + upliftc;
            //    txtbge36unitall.Text = unitc.ToString();
            //}

            //if (txtbge36wdall.Text != "0")
            //{
            //    wd = wd + upliftc;
            //    txtbge36wdall.Text = wd.ToString();
            //}

            if (txtbge36offpeak.Text != "0")
            {
                offpeak = offpeak + upliftc;
                txtbge36offpeakall.Text = offpeak.ToString();
            }

            //if (txtbge36other.Text != "0")
            //{
            //    otherc = otherc + upliftc;
            //    txtbge36other.Text = otherc.ToString();
            //}



            if (lblBGEMetertype.Text == "Single Rate")
            {
                finalvalue = lib.SingleRatebg(sc, dayc, eac);
                txtbge36rateall.Text = finalvalue.ToString();
            }

            if (lblBGEMetertype.Text == "Day & Night")
            {
                finalvalue = lib.Daynight(sc, dayc, nightprice, eac);
                txtbge36rateall.Text = finalvalue.ToString();
            }
            if (lblBGEMetertype.Text == "Eve/Weekend & Night")
            {
                finalvalue = lib.Ewn(sc, dayc, nightprice, weekend, eac);
                txtbge36rateall.Text = finalvalue.ToString();

            }

            if (lblBGEMetertype.Text == "Eve/Weekend")
            {
                finalvalue = lib.EW(sc, dayc, weekend, eac);
                txtbge36rateall.Text = finalvalue.ToString();

            }

            if (lblBGEMetertype.Text == "Off Peak")
            {
                finalvalue = lib.OffPeak(sc, offpeak, eac);
                txtbge36rateall.Text = finalvalue.ToString();

            }


        }

        void Bge48()
        {
            double finalvalue = 0;

            double sc = Convert.ToDouble(txtbge48sc.Text);
            double dayc = Convert.ToDouble(txtbge48day.ToolTip);
            double nightprice = Convert.ToDouble(txtbge48night.ToolTip);
            double weekend = Convert.ToDouble(txtbge48ew.ToolTip);
            //double unitc = Convert.ToDouble(txtbge48unit.ToolTip);
            //double wd = Convert.ToDouble(txtbge48wd.ToolTip);
            double offpeak = Convert.ToDouble(txtbge48offpeak.ToolTip);
            //   double otherc = Convert.ToDouble(txtbge48other.ToolTip.ToString());
            double upliftc = Convert.ToDouble(txtbge48uplift.Text);

            double eac = Convert.ToDouble(lblEac.Text);

            if (txtbge48day.Text != "0")
            {
                dayc = dayc + upliftc;
                txtbge48day.Text = dayc.ToString();
            }

            if (txtbge48night.Text != "0")
            {
                nightprice = nightprice + upliftc;
                txtbge48night.Text = nightprice.ToString();
            }

            if (txtbge48ew.Text != "0")
            {
                weekend = weekend + upliftc;
                txtbge48ew.Text = weekend.ToString();
            }

            //if (txtbge48unit.Text != "0")
            //{
            //    unitc = unitc + upliftc;
            //    txtbge48unit.Text = unitc.ToString();
            //}

            //if (txtbge48wd.Text != "0")
            //{
            //    wd = wd + upliftc;
            //    txtbge48wd.Text = wd.ToString();
            //}

            if (txtbge48offpeak.Text != "0")
            {
                offpeak = offpeak + upliftc;
                txtbge48offpeak.Text = offpeak.ToString();
            }

            //if (txtbge48other.Text != "0")
            //{
            //    otherc = otherc + upliftc;
            //    txtbge48other.Text = otherc.ToString();
            //}




            if (lblBGEMetertype.Text == "Single Rate")
            {
                finalvalue = lib.SingleRatebg(sc, dayc, eac);
                txtbfge48rate.Text = finalvalue.ToString();
            }

            if (lblBGEMetertype.Text == "Day & Night")
            {
                finalvalue = lib.Daynight(sc, dayc, nightprice, eac);
                txtbfge48rate.Text = finalvalue.ToString();
            }
            if (lblBGEMetertype.Text == "Eve/Weekend & Night")
            {
                finalvalue = lib.Ewn(sc, dayc, nightprice, weekend, eac);
                txtbfge48rate.Text = finalvalue.ToString();

            }

            if (lblBGEMetertype.Text == "Eve/Weekend")
            {
                finalvalue = lib.EW(sc, dayc, weekend, eac);
                txtbfge48rate.Text = finalvalue.ToString();

            }

            if (lblBGEMetertype.Text == "Off Peak")
            {
                finalvalue = lib.OffPeak(sc, offpeak, eac);
                txtbfge48rate.Text = finalvalue.ToString();

            }


        }

        void Bge48all()
        {
            double finalvalue = 0;

            double sc = Convert.ToDouble(txtbge48scall.Text);
            double dayc = Convert.ToDouble(txtbge48dayall.ToolTip);
            double nightprice = Convert.ToDouble(txtbge48nightall.ToolTip);
            double weekend = Convert.ToDouble(txtbge48ewall.ToolTip);
            //double unitc = Convert.ToDouble(txtbge48unitall.ToolTip);
            //double wd = Convert.ToDouble(txtbge48wdall.ToolTip);
            double offpeak = Convert.ToDouble(txtbge48offpeak.ToolTip);
            //   double otherc = Convert.ToDouble(txtbge48other.ToolTip.ToString());
            double upliftc = Convert.ToDouble(txtbge48upliftall.Text);

            double eac = Convert.ToDouble(lblEac.Text);

            if (txtbge48dayall.Text != "0")
            {
                dayc = dayc + upliftc;
                txtbge48dayall.Text = dayc.ToString();
            }

            if (txtbge48nightall.Text != "0")
            {
                nightprice = nightprice + upliftc;
                txtbge48nightall.Text = nightprice.ToString();
            }

            if (txtbge48ewall.Text != "0")
            {
                weekend = weekend + upliftc;
                txtbge48ewall.Text = weekend.ToString();
            }

            //if (txtbge48unitall.Text != "0")
            //{
            //    unitc = unitc + upliftc;
            //    txtbge48unitall.Text = unitc.ToString();
            //}

            //if (txtbge48wdall.Text != "0")
            //{
            //    wd = wd + upliftc;
            //    txtbge48wdall.Text = wd.ToString();
            //}

            if (txtbge48offpeak.Text != "0")
            {
                offpeak = offpeak + upliftc;
                txtbge48offpeakall.Text = offpeak.ToString();
            }

            //if (txtbge48other.Text != "0")
            //{
            //    otherc = otherc + upliftc;
            //    txtbge48other.Text = otherc.ToString();
            //}



            if (lblBGEMetertype.Text == "Single Rate")
            {
                finalvalue = lib.SingleRatebg(sc, dayc, eac);
                txtbfge48rateall.Text = finalvalue.ToString();
            }

            if (lblBGEMetertype.Text == "Day & Night")
            {
                finalvalue = lib.Daynight(sc, dayc, nightprice, eac);
                txtbfge48rateall.Text = finalvalue.ToString();
            }
            if (lblBGEMetertype.Text == "Eve/Weekend & Night")
            {
                finalvalue = lib.Ewn(sc, dayc, nightprice, weekend, eac);
                txtbfge48rateall.Text = finalvalue.ToString();

            }

            if (lblBGEMetertype.Text == "Eve/Weekend")
            {
                finalvalue = lib.EW(sc, dayc, weekend, eac);
                txtbfge48rateall.Text = finalvalue.ToString();

            }

            if (lblBGEMetertype.Text == "Off Peak")
            {
                finalvalue = lib.OffPeak(sc, offpeak, eac);
                txtbfge48rateall.Text = finalvalue.ToString();

            }


        }

        #endregion



        #region BGL Uplift calculation for new customer
        // bgl new

        void Bgl12()
        {
            double finalvalue = 0;

            double sc = Convert.ToDouble(txtbgla12sc.Text);
            double dayc = Convert.ToDouble(txtbgla12day.ToolTip);
            double nightprice = Convert.ToDouble(txtbgla12night.ToolTip);
            double weekend = Convert.ToDouble(txtbgla12ew.ToolTip);
            //double unitc = Convert.ToDouble(txtbgla12unit.ToolTip);
            //double wd = Convert.ToDouble(txtbgla12wd.ToolTip);
            double offpeak = Convert.ToDouble(txtbgla12offpeak.ToolTip);
            //   double otherc = Convert.ToDouble(txtbga12other.ToolTip.ToString());
            double upliftc = Convert.ToDouble(txtbgla12uplift.Text);

            double eac = Convert.ToDouble(lblEac.Text);

            if (txtbgla12day.Text != "0")
            {
                dayc = dayc + upliftc;
                txtbgla12day.Text = dayc.ToString();
            }

            if (txtbgla12night.Text != "0")
            {
                nightprice = nightprice + upliftc;
                txtbgla12night.Text = nightprice.ToString();
            }

            if (txtbgla12ew.Text != "0")
            {
                weekend = weekend + upliftc;
                txtbgla12ew.Text = weekend.ToString();
            }

            //if (txtbgla12unit.Text != "0")
            //{
            //    unitc = unitc + upliftc;
            //    txtbgla12unit.Text = unitc.ToString();
            //}

            //if (txtbgla12wd.Text != "0")
            //{
            //    wd = wd + upliftc;
            //    txtbgla12wd.Text = wd.ToString();
            //}

            if (txtbgla12offpeak.Text != "0")
            {
                offpeak = offpeak + upliftc;
                txtbgla12offpeak.Text = offpeak.ToString();
            }

          

            if (lblBGEMetertype.Text == "Single Rate")
            {
                finalvalue = lib.SingleRatebg(sc, dayc, eac);
                txtbgla12rate.Text = finalvalue.ToString();
            }

            if (lblBGEMetertype.Text == "Day & Night")
            {
                finalvalue = lib.Daynight(sc, dayc, nightprice, eac);
                txtbgla12rate.Text = finalvalue.ToString();
            }
            if (lblBGEMetertype.Text == "Eve/Weekend & Night")
            {
                finalvalue = lib.Ewn(sc, dayc, nightprice, weekend, eac);
                txtbgla12rate.Text = finalvalue.ToString();

            }

            if (lblBGEMetertype.Text == "Eve/Weekend")
            {
                finalvalue = lib.EW(sc, dayc, weekend, eac);
                txtbgla12rate.Text = finalvalue.ToString();

            }

            if (lblBGEMetertype.Text == "Off Peak")
            {
                finalvalue = lib.OffPeak(sc, offpeak, eac);
                txtbgla12rate.Text = finalvalue.ToString();

            }


        }

        void Bgl12all()
        {
            double finalvalue = 0;

            double sc = Convert.ToDouble(txtbgla12scall.Text);
            double dayc = Convert.ToDouble(txtbgla12dayall.ToolTip);
            double nightprice = Convert.ToDouble(txtbgla12nightall.ToolTip);
            double weekend = Convert.ToDouble(txtbgla12ewall.ToolTip);
            //double unitc = Convert.ToDouble(txtbgla12unitall.ToolTip);
            //double wd = Convert.ToDouble(txtbgla12wdall.ToolTip);
            double offpeak = Convert.ToDouble(txtbgla12offpeakall.ToolTip);
            //   double otherc = Convert.ToDouble(txtbga12other.ToolTip.ToString());
            double upliftc = Convert.ToDouble(txtbgla12upliftall.Text);

            double eac = Convert.ToDouble(lblEac.Text);

            if (txtbgla12dayall.Text != "0")
            {
                dayc = dayc + upliftc;
                txtbgla12dayall.Text = dayc.ToString();
            }

            if (txtbgla12nightall.Text != "0")
            {
                nightprice = nightprice + upliftc;
                txtbgla12nightall.Text = nightprice.ToString();
            }

            if (txtbgla12ewall.Text != "0")
            {
                weekend = weekend + upliftc;
                txtbgla12ewall.Text = weekend.ToString();
            }

           // if (txtbgla12unitall.Text != "0")
            //{
            //    unitc = unitc + upliftc;
            //    txtbgla12unitall.Text = unitc.ToString();
            //}

            //if (txtbgla12wdall.Text != "0")
            //{
            //    wd = wd + upliftc;
            //    txtbgla12wdall.Text = wd.ToString();
            //}

            if (txtbgla12offpeakall.Text != "0")
            {
                offpeak = offpeak + upliftc;
                txtbgla12offpeakall.Text = offpeak.ToString();
            }



            if (lblBGEMetertype.Text == "Single Rate")
            {
                finalvalue = lib.SingleRatebg(sc, dayc, eac);
                txtbgla12rateall.Text = finalvalue.ToString();
            }

            if (lblBGEMetertype.Text == "Day & Night")
            {
                finalvalue = lib.Daynight(sc, dayc, nightprice, eac);
                txtbgla12rateall.Text = finalvalue.ToString();
            }
            if (lblBGEMetertype.Text == "Eve/Weekend & Night")
            {
                finalvalue = lib.Ewn(sc, dayc, nightprice, weekend, eac);
                txtbgla12rateall.Text = finalvalue.ToString();

            }

            if (lblBGEMetertype.Text == "Eve/Weekend")
            {
                finalvalue = lib.EW(sc, dayc, weekend, eac);
                txtbgla12rateall.Text = finalvalue.ToString();

            }

            if (lblBGEMetertype.Text == "Off Peak")
            {
                finalvalue = lib.OffPeak(sc, offpeak, eac);
                txtbgla12rateall.Text = finalvalue.ToString();

            }


        }

        void Bgl24()
        {
            double finalvalue = 0;

            double sc = Convert.ToDouble(txtbgla24sc.Text);
            double dayc = Convert.ToDouble(txtbgla24day.ToolTip);
            double nightprice = Convert.ToDouble(txtbgla24night.ToolTip);
            double weekend = Convert.ToDouble(txtbgla24ew.ToolTip);
            //double unitc = Convert.ToDouble(txtbgla24unit.ToolTip);
            //double wd = Convert.ToDouble(txtbgla24wd.ToolTip);
            double offpeak = Convert.ToDouble(txtbgla24offpeak.ToolTip);
            //   double otherc = Convert.ToDouble(txtbga24other.ToolTip.ToString());
            double upliftc = Convert.ToDouble(txtbgla24uplift.Text);

            double eac = Convert.ToDouble(lblEac.Text);

            if (txtbgla24day.Text != "0")
            {
                dayc = dayc + upliftc;
                txtbgla24day.Text = dayc.ToString();
            }

            if (txtbgla24night.Text != "0")
            {
                nightprice = nightprice + upliftc;
                txtbgla24night.Text = nightprice.ToString();
            }

            if (txtbgla24ew.Text != "0")
            {
                weekend = weekend + upliftc;
                txtbgla24ew.Text = weekend.ToString();
            }

            //if (txtbgla24unit.Text != "0")
            //{
            //    unitc = unitc + upliftc;
            //    txtbgla24unit.Text = unitc.ToString();
            //}

            //if (txtbgla24wd.Text != "0")
            //{
            //    wd = wd + upliftc;
            //    txtbgla24wd.Text = wd.ToString();
            //}

            if (txtbgla24offpeak.Text != "0")
            {
                offpeak = offpeak + upliftc;
                txtbgla24offpeak.Text = offpeak.ToString();
            }



            if (lblBGEMetertype.Text == "Single Rate")
            {
                finalvalue = lib.SingleRatebg(sc, dayc, eac);
                txtbfgla24rate.Text = finalvalue.ToString();
            }

            if (lblBGEMetertype.Text == "Day & Night")
            {
                finalvalue = lib.Daynight(sc, dayc, nightprice, eac);
                txtbfgla24rate.Text = finalvalue.ToString();
            }
            if (lblBGEMetertype.Text == "Eve/Weekend & Night")
            {
                finalvalue = lib.Ewn(sc, dayc, nightprice, weekend, eac);
                txtbfgla24rate.Text = finalvalue.ToString();

            }

            if (lblBGEMetertype.Text == "Eve/Weekend")
            {
                finalvalue = lib.EW(sc, dayc, weekend, eac);
                txtbfgla24rate.Text = finalvalue.ToString();

            }

            if (lblBGEMetertype.Text == "Off Peak")
            {
                finalvalue = lib.OffPeak(sc, offpeak, eac);
                txtbfgla24rate.Text = finalvalue.ToString();

            }


        }

        void Bgl24all()
        {
            double finalvalue = 0;

            double sc = Convert.ToDouble(txtbgla24scall.Text);
            double dayc = Convert.ToDouble(txtbgla24dayall.ToolTip);
            double nightprice = Convert.ToDouble(txtbgla24nightall.ToolTip);
            double weekend = Convert.ToDouble(txtbgla24ewall.ToolTip);
            //double unitc = Convert.ToDouble(txtbgla24unitall.ToolTip);
            //double wd = Convert.ToDouble(txtbgla24wdall.ToolTip);
            double offpeak = Convert.ToDouble(txtbgla24offpeakall.ToolTip);
            //   double otherc = Convert.ToDouble(txtbga24other.ToolTip.ToString());
            double upliftc = Convert.ToDouble(txtbgla24upliftall.Text);

            double eac = Convert.ToDouble(lblEac.Text);

            if (txtbgla24dayall.Text != "0")
            {
                dayc = dayc + upliftc;
                txtbgla24dayall.Text = dayc.ToString();
            }

            if (txtbgla24nightall.Text != "0")
            {
                nightprice = nightprice + upliftc;
                txtbgla24nightall.Text = nightprice.ToString();
            }

            if (txtbgla24ewall.Text != "0")
            {
                weekend = weekend + upliftc;
                txtbgla24ewall.Text = weekend.ToString();
            }

            //if (txtbgla24unitall.Text != "0")
            //{
            //    unitc = unitc + upliftc;
            //    txtbgla24unitall.Text = unitc.ToString();
            //}

            //if (txtbgla24wdall.Text != "0")
            //{
            //    wd = wd + upliftc;
            //    txtbgla24wdall.Text = wd.ToString();
            //}

            if (txtbgla24offpeakall.Text != "0")
            {
                offpeak = offpeak + upliftc;
                txtbgla24offpeakall.Text = offpeak.ToString();
            }



            if (lblBGEMetertype.Text == "Single Rate")
            {
                finalvalue = lib.SingleRatebg(sc, dayc, eac);
                txtbgla24rateall.Text = finalvalue.ToString();
            }

            if (lblBGEMetertype.Text == "Day & Night")
            {
                finalvalue = lib.Daynight(sc, dayc, nightprice, eac);
                txtbgla24rateall.Text = finalvalue.ToString();
            }
            if (lblBGEMetertype.Text == "Eve/Weekend & Night")
            {
                finalvalue = lib.Ewn(sc, dayc, nightprice, weekend, eac);
                txtbgla24rateall.Text = finalvalue.ToString();

            }

            if (lblBGEMetertype.Text == "Eve/Weekend")
            {
                finalvalue = lib.EW(sc, dayc, weekend, eac);
                txtbgla24rateall.Text = finalvalue.ToString();

            }

            if (lblBGEMetertype.Text == "Off Peak")
            {
                finalvalue = lib.OffPeak(sc, offpeak, eac);
                txtbgla24rateall.Text = finalvalue.ToString();

            }


        }

        void Bgl36()
        {
            double finalvalue = 0;

            double sc = Convert.ToDouble(txtbgla36sc.Text);
            double dayc = Convert.ToDouble(txtbgla36day.ToolTip);
            double nightprice = Convert.ToDouble(txtbgla36night.ToolTip);
            double weekend = Convert.ToDouble(txtbgla36ew.ToolTip);
           // double unitc = Convert.ToDouble(txtbgla36unit.ToolTip);
            //double wd = Convert.ToDouble(txtbgla36wd.ToolTip);
            double offpeak = Convert.ToDouble(txtbgla36offpeak.ToolTip);
            //   double otherc = Convert.ToDouble(txtbga36other.ToolTip.ToString());
            double upliftc = Convert.ToDouble(txtbgla36uplift.Text);

            double eac = Convert.ToDouble(lblEac.Text);

            if (txtbgla36day.Text != "0")
            {
                dayc = dayc + upliftc;
                txtbgla36day.Text = dayc.ToString();
            }

            if (txtbgla36night.Text != "0")
            {
                nightprice = nightprice + upliftc;
                txtbgla36night.Text = nightprice.ToString();
            }

            if (txtbgla36ew.Text != "0")
            {
                weekend = weekend + upliftc;
                txtbgla36ew.Text = weekend.ToString();
            }

            //if (txtbgla36unit.Text != "0")
            //{
            //    unitc = unitc + upliftc;
            //    txtbgla36unit.Text = unitc.ToString();
            //}

            //if (txtbgla36wd.Text != "0")
            //{
            //    wd = wd + upliftc;
            //    txtbgla36wd.Text = wd.ToString();
            //}

            if (txtbgla36offpeak.Text != "0")
            {
                offpeak = offpeak + upliftc;
                txtbgla36offpeak.Text = offpeak.ToString();
            }



            if (lblBGEMetertype.Text == "Single Rate")
            {
                finalvalue = lib.SingleRatebg(sc, dayc, eac);
                txtbfgla36rate.Text = finalvalue.ToString();
            }

            if (lblBGEMetertype.Text == "Day & Night")
            {
                finalvalue = lib.Daynight(sc, dayc, nightprice, eac);
                txtbfgla36rate.Text = finalvalue.ToString();
            }
            if (lblBGEMetertype.Text == "Eve/Weekend & Night")
            {
                finalvalue = lib.Ewn(sc, dayc, nightprice, weekend, eac);
                txtbfgla36rate.Text = finalvalue.ToString();

            }

            if (lblBGEMetertype.Text == "Eve/Weekend")
            {
                finalvalue = lib.EW(sc, dayc, weekend, eac);
                txtbfgla36rate.Text = finalvalue.ToString();

            }

            if (lblBGEMetertype.Text == "Off Peak")
            {
                finalvalue = lib.OffPeak(sc, offpeak, eac);
                txtbfgla36rate.Text = finalvalue.ToString();

            }


        }
        void Bgl36all()
        {
            double finalvalue = 0;

            double sc = Convert.ToDouble(txtbgla36scall.Text);
            double dayc = Convert.ToDouble(txtbgla36dayall.ToolTip);
            double nightprice = Convert.ToDouble(txtbgla36nightall.ToolTip);
            double weekend = Convert.ToDouble(txtbgla36ewall.ToolTip);
            //double unitc = Convert.ToDouble(txtbgla36unitall.ToolTip);
            //double wd = Convert.ToDouble(txtbgla36wdall.ToolTip);
            double offpeak = Convert.ToDouble(txtbgla36offpeakall.ToolTip);
            //   double otherc = Convert.ToDouble(txtbga36other.ToolTip.ToString());
            double upliftc = Convert.ToDouble(txtbgla36upliftall.Text);

            double eac = Convert.ToDouble(lblEac.Text);

            if (txtbgla36dayall.Text != "0")
            {
                dayc = dayc + upliftc;
                txtbgla36dayall.Text = dayc.ToString();
            }

            if (txtbgla36nightall.Text != "0")
            {
                nightprice = nightprice + upliftc;
                txtbgla36nightall.Text = nightprice.ToString();
            }

            if (txtbgla36ewall.Text != "0")
            {
                weekend = weekend + upliftc;
                txtbgla36ewall.Text = weekend.ToString();
            }

            //if (txtbgla36unitall.Text != "0")
            //{
            //    unitc = unitc + upliftc;
            //    txtbgla36unitall.Text = unitc.ToString();
            //}

            //if (txtbgla36wdall.Text != "0")
            //{
            //    wd = wd + upliftc;
            //    txtbgla36wdall.Text = wd.ToString();
            //}

            if (txtbgla36offpeakall.Text != "0")
            {
                offpeak = offpeak + upliftc;
                txtbgla36offpeakall.Text = offpeak.ToString();
            }



            if (lblBGEMetertype.Text == "Single Rate")
            {
                finalvalue = lib.SingleRatebg(sc, dayc, eac);
                txtbgla36rateall.Text = finalvalue.ToString();
            }

            if (lblBGEMetertype.Text == "Day & Night")
            {
                finalvalue = lib.Daynight(sc, dayc, nightprice, eac);
                txtbgla36rateall.Text = finalvalue.ToString();
            }
            if (lblBGEMetertype.Text == "Eve/Weekend & Night")
            {
                finalvalue = lib.Ewn(sc, dayc, nightprice, weekend, eac);
                txtbgla36rateall.Text = finalvalue.ToString();

            }

            if (lblBGEMetertype.Text == "Eve/Weekend")
            {
                finalvalue = lib.EW(sc, dayc, weekend, eac);
                txtbgla36rateall.Text = finalvalue.ToString();

            }

            if (lblBGEMetertype.Text == "Off Peak")
            {
                finalvalue = lib.OffPeak(sc, offpeak, eac);
                txtbgla36rateall.Text = finalvalue.ToString();

            }


        }

        void Bgl48()
        {
            double finalvalue = 0;

            double sc = Convert.ToDouble(txtbgla48sc.Text);
            double dayc = Convert.ToDouble(txtbgla48day.ToolTip);
            double nightprice = Convert.ToDouble(txtbgla48night.ToolTip);
            double weekend = Convert.ToDouble(txtbgla48ew.ToolTip);
            //double unitc = Convert.ToDouble(txtbgla48unit.ToolTip);
            //double wd = Convert.ToDouble(txtbgla48wd.ToolTip);
            double offpeak = Convert.ToDouble(txtbgla48offpeak.ToolTip);
            //   double otherc = Convert.ToDouble(txtbga48other.ToolTip.ToString());
            double upliftc = Convert.ToDouble(txtbgla48uplift.Text);

            double eac = Convert.ToDouble(lblEac.Text);

            if (txtbgla48day.Text != "0")
            {
                dayc = dayc + upliftc;
                txtbgla48day.Text = dayc.ToString();
            }

            if (txtbgla48night.Text != "0")
            {
                nightprice = nightprice + upliftc;
                txtbgla48night.Text = nightprice.ToString();
            }

            if (txtbgla48ew.Text != "0")
            {
                weekend = weekend + upliftc;
                txtbgla48ew.Text = weekend.ToString();
            }

            //if (txtbgla48unit.Text != "0")
            //{
            //    unitc = unitc + upliftc;
            //    txtbgla48unit.Text = unitc.ToString();
            //}

            //if (txtbgla48wd.Text != "0")
            //{
            //    wd = wd + upliftc;
            //    txtbgla48wd.Text = wd.ToString();
            //}

            if (txtbgla48offpeak.Text != "0")
            {
                offpeak = offpeak + upliftc;
                txtbgla48offpeak.Text = offpeak.ToString();
            }



            if (lblBGEMetertype.Text == "Single Rate")
            {
                finalvalue = lib.SingleRatebg(sc, dayc, eac);
                txtbfgla48rate.Text = finalvalue.ToString();
            }

            if (lblBGEMetertype.Text == "Day & Night")
            {
                finalvalue = lib.Daynight(sc, dayc, nightprice, eac);
                txtbfgla48rate.Text = finalvalue.ToString();
            }
            if (lblBGEMetertype.Text == "Eve/Weekend & Night")
            {
                finalvalue = lib.Ewn(sc, dayc, nightprice, weekend, eac);
                txtbfgla48rate.Text = finalvalue.ToString();

            }

            if (lblBGEMetertype.Text == "Eve/Weekend")
            {
                finalvalue = lib.EW(sc, dayc, weekend, eac);
                txtbfgla48rate.Text = finalvalue.ToString();

            }

            if (lblBGEMetertype.Text == "Off Peak")
            {
                finalvalue = lib.OffPeak(sc, offpeak, eac);
                txtbfgla48rate.Text = finalvalue.ToString();

            }


        }

        void Bgl48all()
        {
            double finalvalue = 0;

            double sc = Convert.ToDouble(txtbgla48scall.Text);
            double dayc = Convert.ToDouble(txtbgla48dayall.ToolTip);
            double nightprice = Convert.ToDouble(txtbgla48nightall.ToolTip);
            double weekend = Convert.ToDouble(txtbgla48ewall.ToolTip);
            //double unitc = Convert.ToDouble(txtbgla48unitall.ToolTip);
            //double wd = Convert.ToDouble(txtbgla48wdall.ToolTip);
            double offpeak = Convert.ToDouble(txtbgla48offpeakall.ToolTip);
            //   double otherc = Convert.ToDouble(txtbga48other.ToolTip.ToString());
            double upliftc = Convert.ToDouble(txtbgla48upliftall.Text);

            double eac = Convert.ToDouble(lblEac.Text);

            if (txtbgla48dayall.Text != "0")
            {
                dayc = dayc + upliftc;
                txtbgla48dayall.Text = dayc.ToString();
            }

            if (txtbgla48nightall.Text != "0")
            {
                nightprice = nightprice + upliftc;
                txtbgla48nightall.Text = nightprice.ToString();
            }

            if (txtbgla48ewall.Text != "0")
            {
                weekend = weekend + upliftc;
                txtbgla48ewall.Text = weekend.ToString();
            }

            //if (txtbgla48unitall.Text != "0")
            //{
            //    unitc = unitc + upliftc;
            //    txtbgla48unitall.Text = unitc.ToString();
            //}

            //if (txtbgla48wdall.Text != "0")
            //{
            //    wd = wd + upliftc;
            //    txtbgla48wdall.Text = wd.ToString();
            //}

            if (txtbgla48offpeakall.Text != "0")
            {
                offpeak = offpeak + upliftc;
                txtbgla48offpeakall.Text = offpeak.ToString();
            }



            if (lblBGEMetertype.Text == "Single Rate")
            {
                finalvalue = lib.SingleRatebg(sc, dayc, eac);
                txtbfgla48rateall.Text = finalvalue.ToString();
            }

            if (lblBGEMetertype.Text == "Day & Night")
            {
                finalvalue = lib.Daynight(sc, dayc, nightprice, eac);
                txtbfgla48rateall.Text = finalvalue.ToString();
            }
            if (lblBGEMetertype.Text == "Eve/Weekend & Night")
            {
                finalvalue = lib.Ewn(sc, dayc, nightprice, weekend, eac);
                txtbfgla48rateall.Text = finalvalue.ToString();

            }

            if (lblBGEMetertype.Text == "Eve/Weekend")
            {
                finalvalue = lib.EW(sc, dayc, weekend, eac);
                txtbfgla48rateall.Text = finalvalue.ToString();

            }

            if (lblBGEMetertype.Text == "Off Peak")
            {
                finalvalue = lib.OffPeak(sc, offpeak, eac);
                txtbfgla48rateall.Text = finalvalue.ToString();

            }


        }

        #endregion


        #region BGL uplift calculation foe existing customer

        // BGL Renewal
        void Bgle12()
        {
            double finalvalue = 0;

            double sc = Convert.ToDouble(txtbgle12sc.Text);
            double dayc = Convert.ToDouble(txtbgle12day.ToolTip);
            double nightprice = Convert.ToDouble(txtbgle12night.ToolTip);
            double weekend = Convert.ToDouble(txtbgle12ew.ToolTip);
            //double unitc = Convert.ToDouble(txtbgle12unit.ToolTip);
            //double wd = Convert.ToDouble(txtbgle12wd.ToolTip);
            double offpeak = Convert.ToDouble(txtbgle12offpeak.ToolTip);
            //   double otherc = Convert.ToDouble(txtbga12other.ToolTip.ToString());
            double upliftc = Convert.ToDouble(txtbgle12uplift.Text);

            double eac = Convert.ToDouble(lblEac.Text);

            if (txtbgle12day.Text != "0")
            {
                dayc = dayc + upliftc;
                txtbgle12day.Text = dayc.ToString();
            }

            if (txtbgle12night.Text != "0")
            {
                nightprice = nightprice + upliftc;
                txtbgle12night.Text = nightprice.ToString();
            }

            if (txtbgle12ew.Text != "0")
            {
                weekend = weekend + upliftc;
                txtbgle12ew.Text = weekend.ToString();
            }

            //if (txtbgle12unit.Text != "0")
            //{
            //    unitc = unitc + upliftc;
            //    txtbgle12unit.Text = unitc.ToString();
            //}

            //if (txtbgle12wd.Text != "0")
            //{
            //    wd = wd + upliftc;
            //    txtbgle12wd.Text = wd.ToString();
            //}

            if (txtbgle12offpeak.Text != "0")
            {
                offpeak = offpeak + upliftc;
                txtbgle12offpeak.Text = offpeak.ToString();
            }



            if (lblBGEMetertype.Text == "Single Rate")
            {
                finalvalue = lib.SingleRatebg(sc, dayc, eac);
                txtbgle12rate.Text = finalvalue.ToString();
            }

            if (lblBGEMetertype.Text == "Day & Night")
            {
                finalvalue = lib.Daynight(sc, dayc, nightprice, eac);
                txtbgle12rate.Text = finalvalue.ToString();
            }
            if (lblBGEMetertype.Text == "Eve/Weekend & Night")
            {
                finalvalue = lib.Ewn(sc, dayc, nightprice, weekend, eac);
                txtbgle12rate.Text = finalvalue.ToString();

            }

            if (lblBGEMetertype.Text == "Eve/Weekend")
            {
                finalvalue = lib.EW(sc, dayc, weekend, eac);
                txtbgle12rate.Text = finalvalue.ToString();

            }

            if (lblBGEMetertype.Text == "Off Peak")
            {
                finalvalue = lib.OffPeak(sc, offpeak, eac);
                txtbgle12rate.Text = finalvalue.ToString();

            }


        }
        void Bgle12all()
        {
            double finalvalue = 0;

            double sc = Convert.ToDouble(txtbgle12scall.Text);
            double dayc = Convert.ToDouble(txtbgle12dayall.ToolTip);
            double nightprice = Convert.ToDouble(txtbgle12nightall.ToolTip);
            double weekend = Convert.ToDouble(txtbgle12ewall.ToolTip);
            //double unitc = Convert.ToDouble(txtbgle12unitall.ToolTip);
            //double wd = Convert.ToDouble(txtbgle12wdall.ToolTip);
            double offpeak = Convert.ToDouble(txtbgle12offpeakall.ToolTip);
            //   double otherc = Convert.ToDouble(txtbga12other.ToolTip.ToString());
            double upliftc = Convert.ToDouble(txtbgle12upliftall.Text);

            double eac = Convert.ToDouble(lblEac.Text);

            if (txtbgle12dayall.Text != "0")
            {
                dayc = dayc + upliftc;
                txtbgle12dayall.Text = dayc.ToString();
            }

            if (txtbgle12nightall.Text != "0")
            {
                nightprice = nightprice + upliftc;
                txtbgle12nightall.Text = nightprice.ToString();
            }

            if (txtbgle12ewall.Text != "0")
            {
                weekend = weekend + upliftc;
                txtbgle12ewall.Text = weekend.ToString();
            }

            //if (txtbgle12unitall.Text != "0")
            //{
            //    unitc = unitc + upliftc;
            //    txtbgle12unitall.Text = unitc.ToString();
            //}

            //if (txtbgle12wdall.Text != "0")
            //{
            //    wd = wd + upliftc;
            //    txtbgle12wdall.Text = wd.ToString();
            //}

            if (txtbgle12offpeakall.Text != "0")
            {
                offpeak = offpeak + upliftc;
                txtbgle12offpeakall.Text = offpeak.ToString();
            }



            if (lblBGEMetertype.Text == "Single Rate")
            {
                finalvalue = lib.SingleRatebg(sc, dayc, eac);
                txtbgle12rateall.Text = finalvalue.ToString();
            }

            if (lblBGEMetertype.Text == "Day & Night")
            {
                finalvalue = lib.Daynight(sc, dayc, nightprice, eac);
                txtbgle12rateall.Text = finalvalue.ToString();
            }
            if (lblBGEMetertype.Text == "Eve/Weekend & Night")
            {
                finalvalue = lib.Ewn(sc, dayc, nightprice, weekend, eac);
                txtbgle12rateall.Text = finalvalue.ToString();

            }

            if (lblBGEMetertype.Text == "Eve/Weekend")
            {
                finalvalue = lib.EW(sc, dayc, weekend, eac);
                txtbgle12rateall.Text = finalvalue.ToString();

            }

            if (lblBGEMetertype.Text == "Off Peak")
            {
                finalvalue = lib.OffPeak(sc, offpeak, eac);
                txtbgle12rateall.Text = finalvalue.ToString();

            }


        }


        void Bgle24()
        {
            double finalvalue = 0;

            double sc = Convert.ToDouble(txtbgle24sc.Text);
            double dayc = Convert.ToDouble(txtbgle24day.ToolTip);
            double nightprice = Convert.ToDouble(txtbgle24night.ToolTip);
            double weekend = Convert.ToDouble(txtbgle24ew.ToolTip);
            //double unitc = Convert.ToDouble(txtbgle24unit.ToolTip);
            //double wd = Convert.ToDouble(txtbgle24wd.ToolTip);
            double offpeak = Convert.ToDouble(txtbgle24offpeak.ToolTip);
            //   double otherc = Convert.ToDouble(txtbga24other.ToolTip.ToString());
            double upliftc = Convert.ToDouble(txtbgle24uplift.Text);

            double eac = Convert.ToDouble(lblEac.Text);

            if (txtbgle24day.Text != "0")
            {
                dayc = dayc + upliftc;
                txtbgle24day.Text = dayc.ToString();
            }

            if (txtbgle24night.Text != "0")
            {
                nightprice = nightprice + upliftc;
                txtbgle24night.Text = nightprice.ToString();
            }

            if (txtbgle24ew.Text != "0")
            {
                weekend = weekend + upliftc;
                txtbgle24ew.Text = weekend.ToString();
            }

            //if (txtbgle24unit.Text != "0")
            //{
            //    unitc = unitc + upliftc;
            //    txtbgle24unit.Text = unitc.ToString();
            //}

            //if (txtbgle24wd.Text != "0")
            //{
            //    wd = wd + upliftc;
            //    txtbgle24wd.Text = wd.ToString();
            //}

            if (txtbgle24offpeak.Text != "0")
            {
                offpeak = offpeak + upliftc;
                txtbgle24offpeak.Text = offpeak.ToString();
            }



            if (lblBGEMetertype.Text == "Single Rate")
            {
                finalvalue = lib.SingleRatebg(sc, dayc, eac);
                txtbgle24rate.Text = finalvalue.ToString();
            }

            if (lblBGEMetertype.Text == "Day & Night")
            {
                finalvalue = lib.Daynight(sc, dayc, nightprice, eac);
                txtbgle24rate.Text = finalvalue.ToString();
            }
            if (lblBGEMetertype.Text == "Eve/Weekend & Night")
            {
                finalvalue = lib.Ewn(sc, dayc, nightprice, weekend, eac);
                txtbgle24rate.Text = finalvalue.ToString();

            }

            if (lblBGEMetertype.Text == "Eve/Weekend")
            {
                finalvalue = lib.EW(sc, dayc, weekend, eac);
                txtbgle24rate.Text = finalvalue.ToString();

            }

            if (lblBGEMetertype.Text == "Off Peak")
            {
                finalvalue = lib.OffPeak(sc, offpeak, eac);
                txtbgle24rate.Text = finalvalue.ToString();

            }


        }
        void Bgle24all()
        {
            double finalvalue = 0;

            double sc = Convert.ToDouble(txtbgle24scall.Text);
            double dayc = Convert.ToDouble(txtbgle24dayall.ToolTip);
            double nightprice = Convert.ToDouble(txtbgle24nightall.ToolTip);
            double weekend = Convert.ToDouble(txtbgle24ewall.ToolTip);
            //double unitc = Convert.ToDouble(txtbgle24unitall.ToolTip);
            //double wd = Convert.ToDouble(txtbgle24wdall.ToolTip);
            double offpeak = Convert.ToDouble(txtbgle24offpeakall.ToolTip);
            //   double otherc = Convert.ToDouble(txtbga24other.ToolTip.ToString());
            double upliftc = Convert.ToDouble(txtbgle24upliftall.Text);

            double eac = Convert.ToDouble(lblEac.Text);

            if (txtbgle24dayall.Text != "0")
            {
                dayc = dayc + upliftc;
                txtbgle24dayall.Text = dayc.ToString();
            }

            if (txtbgle24nightall.Text != "0")
            {
                nightprice = nightprice + upliftc;
                txtbgle24nightall.Text = nightprice.ToString();
            }

            if (txtbgle24ewall.Text != "0")
            {
                weekend = weekend + upliftc;
                txtbgle24ewall.Text = weekend.ToString();
            }

            //if (txtbgle24unitall.Text != "0")
            //{
            //    unitc = unitc + upliftc;
            //    txtbgle24unitall.Text = unitc.ToString();
            //}

            //if (txtbgle24wdall.Text != "0")
            //{
            //    wd = wd + upliftc;
            //    txtbgle24wdall.Text = wd.ToString();
            //}

            if (txtbgle24offpeakall.Text != "0")
            {
                offpeak = offpeak + upliftc;
                txtbgle24offpeakall.Text = offpeak.ToString();
            }



            if (lblBGEMetertype.Text == "Single Rate")
            {
                finalvalue = lib.SingleRatebg(sc, dayc, eac);
                txtbgle24rateall.Text = finalvalue.ToString();
            }

            if (lblBGEMetertype.Text == "Day & Night")
            {
                finalvalue = lib.Daynight(sc, dayc, nightprice, eac);
                txtbgle24rateall.Text = finalvalue.ToString();
            }
            if (lblBGEMetertype.Text == "Eve/Weekend & Night")
            {
                finalvalue = lib.Ewn(sc, dayc, nightprice, weekend, eac);
                txtbgle24rateall.Text = finalvalue.ToString();

            }

            if (lblBGEMetertype.Text == "Eve/Weekend")
            {
                finalvalue = lib.EW(sc, dayc, weekend, eac);
                txtbgle24rateall.Text = finalvalue.ToString();

            }

            if (lblBGEMetertype.Text == "Off Peak")
            {
                finalvalue = lib.OffPeak(sc, offpeak, eac);
                txtbgle24rateall.Text = finalvalue.ToString();

            }


        }
        void Bgle36()
        {
            double finalvalue = 0;

            double sc = Convert.ToDouble(txtbgle36sc.Text);
            double dayc = Convert.ToDouble(txtbgle36day.ToolTip);
            double nightprice = Convert.ToDouble(txtbgle36night.ToolTip);
            double weekend = Convert.ToDouble(txtbgle36ew.ToolTip);
            //double unitc = Convert.ToDouble(txtbgle36unit.ToolTip);
            //double wd = Convert.ToDouble(txtbgle36wd.ToolTip);
            double offpeak = Convert.ToDouble(txtbgle36offpeak.ToolTip);
            //   double otherc = Convert.ToDouble(txtbga36other.ToolTip.ToString());
            double upliftc = Convert.ToDouble(txtbgle36uplift.Text);

            double eac = Convert.ToDouble(lblEac.Text);

            if (txtbgle36day.Text != "0")
            {
                dayc = dayc + upliftc;
                txtbgle36day.Text = dayc.ToString();
            }

            if (txtbgle36night.Text != "0")
            {
                nightprice = nightprice + upliftc;
                txtbgle36night.Text = nightprice.ToString();
            }

            if (txtbgle36ew.Text != "0")
            {
                weekend = weekend + upliftc;
                txtbgle36ew.Text = weekend.ToString();
            }

            //if (txtbgle36unit.Text != "0")
            //{
            //    unitc = unitc + upliftc;
            //    txtbgle36unit.Text = unitc.ToString();
            //}

            //if (txtbgle36wd.Text != "0")
            //{
            //    wd = wd + upliftc;
            //    txtbgle36wd.Text = wd.ToString();
            //}

            if (txtbgle36offpeak.Text != "0")
            {
                offpeak = offpeak + upliftc;
                txtbgle36offpeak.Text = offpeak.ToString();
            }



            if (lblBGEMetertype.Text == "Single Rate")
            {
                finalvalue = lib.SingleRatebg(sc, dayc, eac);
                txtbgle36rate.Text = finalvalue.ToString();
            }

            if (lblBGEMetertype.Text == "Day & Night")
            {
                finalvalue = lib.Daynight(sc, dayc, nightprice, eac);
                txtbgle36rate.Text = finalvalue.ToString();
            }
            if (lblBGEMetertype.Text == "Eve/Weekend & Night")
            {
                finalvalue = lib.Ewn(sc, dayc, nightprice, weekend, eac);
                txtbgle36rate.Text = finalvalue.ToString();

            }

            if (lblBGEMetertype.Text == "Eve/Weekend")
            {
                finalvalue = lib.EW(sc, dayc, weekend, eac);
                txtbgle36rate.Text = finalvalue.ToString();

            }

            if (lblBGEMetertype.Text == "Off Peak")
            {
                finalvalue = lib.OffPeak(sc, offpeak, eac);
                txtbgle36rate.Text = finalvalue.ToString();

            }


        }

        void Bgle36all()
        {
            double finalvalue = 0;

            double sc = Convert.ToDouble(txtbgle36scall.Text);
            double dayc = Convert.ToDouble(txtbgle36dayall.ToolTip);
            double nightprice = Convert.ToDouble(txtbgle36nightall.ToolTip);
            double weekend = Convert.ToDouble(txtbgle36ewall.ToolTip);
            //double unitc = Convert.ToDouble(txtbgle36unitall.ToolTip);
            //double wd = Convert.ToDouble(txtbgle36wdall.ToolTip);
            double offpeak = Convert.ToDouble(txtbgle36offpeakall.ToolTip);
            //   double otherc = Convert.ToDouble(txtbga36other.ToolTip.ToString());
            double upliftc = Convert.ToDouble(txtbgle36upliftall.Text);

            double eac = Convert.ToDouble(lblEac.Text);

            if (txtbgle36dayall.Text != "0")
            {
                dayc = dayc + upliftc;
                txtbgle36dayall.Text = dayc.ToString();
            }

            if (txtbgle36nightall.Text != "0")
            {
                nightprice = nightprice + upliftc;
                txtbgle36nightall.Text = nightprice.ToString();
            }

            if (txtbgle36ewall.Text != "0")
            {
                weekend = weekend + upliftc;
                txtbgle36ewall.Text = weekend.ToString();
            }

            //if (txtbgle36unitall.Text != "0")
            //{
            //    unitc = unitc + upliftc;
            //    txtbgle36unitall.Text = unitc.ToString();
            //}

            //if (txtbgle36wdall.Text != "0")
            //{
            //    wd = wd + upliftc;
            //    txtbgle36wdall.Text = wd.ToString();
            //}

            if (txtbgle36offpeakall.Text != "0")
            {
                offpeak = offpeak + upliftc;
                txtbgle36offpeakall.Text = offpeak.ToString();
            }



            if (lblBGEMetertype.Text == "Single Rate")
            {
                finalvalue = lib.SingleRatebg(sc, dayc, eac);
                txtbgle36rateall.Text = finalvalue.ToString();
            }

            if (lblBGEMetertype.Text == "Day & Night")
            {
                finalvalue = lib.Daynight(sc, dayc, nightprice, eac);
                txtbgle36rateall.Text = finalvalue.ToString();
            }
            if (lblBGEMetertype.Text == "Eve/Weekend & Night")
            {
                finalvalue = lib.Ewn(sc, dayc, nightprice, weekend, eac);
                txtbgle36rateall.Text = finalvalue.ToString();

            }

            if (lblBGEMetertype.Text == "Eve/Weekend")
            {
                finalvalue = lib.EW(sc, dayc, weekend, eac);
                txtbgle36rateall.Text = finalvalue.ToString();

            }

            if (lblBGEMetertype.Text == "Off Peak")
            {
                finalvalue = lib.OffPeak(sc, offpeak, eac);
                txtbga48rateall.Text = finalvalue.ToString();

            }


        }

        void Bgle48()
        {
            double finalvalue = 0;

            double sc = Convert.ToDouble(txtbgle48sc.Text);
            double dayc = Convert.ToDouble(txtbgle48day.ToolTip);
            double nightprice = Convert.ToDouble(txtbgle48night.ToolTip);
            double weekend = Convert.ToDouble(txtbgle48ew.ToolTip);
            //double unitc = Convert.ToDouble(txtbgle48unit.ToolTip);
            //double wd = Convert.ToDouble(txtbgle48wd.ToolTip);
            double offpeak = Convert.ToDouble(txtbgle48offpeak.ToolTip);
            //   double otherc = Convert.ToDouble(txtbga48other.ToolTip.ToString());
            double upliftc = Convert.ToDouble(txtbgle48uplift.Text);

            double eac = Convert.ToDouble(lblEac.Text);

            if (txtbgle48day.Text != "0")
            {
                dayc = dayc + upliftc;
                txtbgle48day.Text = dayc.ToString();
            }

            if (txtbgle48night.Text != "0")
            {
                nightprice = nightprice + upliftc;
                txtbgle48night.Text = nightprice.ToString();
            }

            if (txtbgle48ew.Text != "0")
            {
                weekend = weekend + upliftc;
                txtbgle48ew.Text = weekend.ToString();
            }

            //if (txtbgle48unit.Text != "0")
            //{
            //    unitc = unitc + upliftc;
            //    txtbgle48unit.Text = unitc.ToString();
            //}

            //if (txtbgle48wd.Text != "0")
            //{
            //    wd = wd + upliftc;
            //    txtbgle48wd.Text = wd.ToString();
            //}

            if (txtbgle48offpeak.Text != "0")
            {
                offpeak = offpeak + upliftc;
                txtbgle48offpeak.Text = offpeak.ToString();
            }



            if (lblBGEMetertype.Text == "Single Rate")
            {
                finalvalue = lib.SingleRatebg(sc, dayc, eac);
                txtbgle48rate.Text = finalvalue.ToString();
            }

            if (lblBGEMetertype.Text == "Day & Night")
            {
                finalvalue = lib.Daynight(sc, dayc, nightprice, eac);
                txtbgle48rate.Text = finalvalue.ToString();
            }
            if (lblBGEMetertype.Text == "Eve/Weekend & Night")
            {
                finalvalue = lib.Ewn(sc, dayc, nightprice, weekend, eac);
                txtbgle48rate.Text = finalvalue.ToString();

            }

            if (lblBGEMetertype.Text == "Eve/Weekend")
            {
                finalvalue = lib.EW(sc, dayc, weekend, eac);
                txtbgle48rate.Text = finalvalue.ToString();

            }

            if (lblBGEMetertype.Text == "Off Peak")
            {
                finalvalue = lib.OffPeak(sc, offpeak, eac);
                txtbgle48rate.Text = finalvalue.ToString();

            }


        }

       

        void Bgle48all()
        {
            double finalvalue = 0;

            double sc = Convert.ToDouble(txtbgle48scall.Text);
            double dayc = Convert.ToDouble(txtbgle48dayall.ToolTip);
            double nightprice = Convert.ToDouble(txtbgle48nightall.ToolTip);
            double weekend = Convert.ToDouble(txtbgle48ewall.ToolTip);
            //double unitc = Convert.ToDouble(txtbgle48unitall.ToolTip);
            //double wd = Convert.ToDouble(txtbgle48wdall.ToolTip);
            double offpeak = Convert.ToDouble(txtbgle48offpeakall.ToolTip);
            //   double otherc = Convert.ToDouble(txtbga48other.ToolTip.ToString());
            double upliftc = Convert.ToDouble(txtbgle48upliftall.Text);

            double eac = Convert.ToDouble(lblEac.Text);

            if (txtbgle48dayall.Text != "0")
            {
                dayc = dayc + upliftc;
                txtbgle48dayall.Text = dayc.ToString();
            }

            if (txtbgle48nightall.Text != "0")
            {
                nightprice = nightprice + upliftc;
                txtbgle48nightall.Text = nightprice.ToString();
            }

            if (txtbgle48ewall.Text != "0")
            {
                weekend = weekend + upliftc;
                txtbgle48ewall.Text = weekend.ToString();
            }

            //if (txtbgle48unitall.Text != "0")
            //{
            //    unitc = unitc + upliftc;
            //    txtbgle48unitall.Text = unitc.ToString();
            //}

            //if (txtbgle48wdall.Text != "0")
            //{
            //    wd = wd + upliftc;
            //    txtbgle48wdall.Text = wd.ToString();
            //}

            if (txtbgle48offpeakall.Text != "0")
            {
                offpeak = offpeak + upliftc;
                txtbgle48offpeakall.Text = offpeak.ToString();
            }



            if (lblBGEMetertype.Text == "Single Rate")
            {
                finalvalue = lib.SingleRatebg(sc, dayc, eac);
                txtbga48rateall.Text = finalvalue.ToString();
            }

            if (lblBGEMetertype.Text == "Day & Night")
            {
                finalvalue = lib.Daynight(sc, dayc, nightprice, eac);
                txtbga48rateall.Text = finalvalue.ToString();
            }
            if (lblBGEMetertype.Text == "Eve/Weekend & Night")
            {
                finalvalue = lib.Ewn(sc, dayc, nightprice, weekend, eac);
                txtbga48rateall.Text = finalvalue.ToString();

            }

            if (lblBGEMetertype.Text == "Eve/Weekend")
            {
                finalvalue = lib.EW(sc, dayc, weekend, eac);
                txtbga48rateall.Text = finalvalue.ToString();

            }

            if (lblBGEMetertype.Text == "Off Peak")
            {
                finalvalue = lib.OffPeak(sc, offpeak, eac);
                txtbga48rateall.Text = finalvalue.ToString();

            }


        }


        //Edf Calculation

        #endregion


        #region EDF Uplift calclation 
        void Edf12()
        {

            double finalvalue = 0;

            double sc = Convert.ToDouble(txtedfa12sc.Text);
            double dayc = Convert.ToDouble(txtedfa12day.ToolTip);
            double nightprice = Convert.ToDouble(txtedfa12night.ToolTip);
            double weekend = Convert.ToDouble(txtedfa12ew.ToolTip);
        
            double upliftc = Convert.ToDouble(txtedfa12uplift.Text);

            double eac = Convert.ToDouble(lblEac.Text);

            if (txtedfa12day.Text != "0")
            {
                dayc = dayc + upliftc;
                txtedfa12day.Text = dayc.ToString();
            }

            if (txtedfa12night.Text != "0")
            {
                nightprice = nightprice + upliftc;
                txtedfa12night.Text = nightprice.ToString();
            }

            if (txtedfa12ew.Text != "0")
            {
                weekend = weekend + upliftc;
                txtedfa12ew.Text = weekend.ToString();
            }

           

            if (lblEDFMetertype.Text == "EWN")
            {
                finalvalue = lib.EdfEwn(sc, dayc, nightprice, weekend, eac);
                txtEdf12Rate.Text = finalvalue.ToString();
            }
            if (lblEDFMetertype.Text == "STD")
            {
                finalvalue = lib.Edfstd(sc, dayc, eac);
                txtEdf12Rate.Text = finalvalue.ToString();
            }
            if (lblEDFMetertype.Text == "EC7")
            {
                finalvalue = lib.EdfEC7(sc, dayc, nightprice, eac);
                txtEdf12Rate.Text = finalvalue.ToString();
            }
            if (lblEDFMetertype.Text == "EWE")
            {
                finalvalue = lib.EDFEWE(sc, dayc, weekend, eac);
                txtEdf12Rate.Text = finalvalue.ToString();
            }

        }

        void Edf12all()
        {

            double finalvalue = 0;

            double sc = Convert.ToDouble(txtedfa12scall.Text);
            double dayc = Convert.ToDouble(txtedfa12dayall.ToolTip);
            double nightprice = Convert.ToDouble(txtedfa12nightall.ToolTip);
            double weekend = Convert.ToDouble(txtedfa12ewall.ToolTip);

            double upliftc = Convert.ToDouble(txtedfa12upliftall.Text);

            double eac = Convert.ToDouble(lblEac.Text);

            if (txtedfa12dayall.Text != "0")
            {
                dayc = dayc + upliftc;
                txtedfa12dayall.Text = dayc.ToString();
            }

            if (txtedfa12nightall.Text != "0")
            {
                nightprice = nightprice + upliftc;
                txtedfa12nightall.Text = nightprice.ToString();
            }

            if (txtedfa12ewall.Text != "0")
            {
                weekend = weekend + upliftc;
                txtedfa12ewall.Text = weekend.ToString();
            }



            if (lblEDFMetertype.Text == "EWN")
            {
                finalvalue = lib.EdfEwn(sc, dayc, nightprice, weekend, eac);
                txtedf12rateall.Text = finalvalue.ToString();
            }
            if (lblEDFMetertype.Text == "STD")
            {
                finalvalue = lib.Edfstd(sc, dayc, eac);
                txtedf12rateall.Text = finalvalue.ToString();
            }
            if (lblEDFMetertype.Text == "EC7")
            {
                finalvalue = lib.EdfEC7(sc, dayc, nightprice, eac);
                txtedf12rateall.Text = finalvalue.ToString();
            }
            if (lblEDFMetertype.Text == "EWE")
            {
                finalvalue = lib.EDFEWE(sc, dayc, weekend, eac);
                txtedf12rateall.Text = finalvalue.ToString();
            }

        }

        void Edf24()
        {

            double finalvalue = 0;

            double sc = Convert.ToDouble(txtedfa24sc.Text);
            double dayc = Convert.ToDouble(txtedfa24day.ToolTip);
            double nightprice = Convert.ToDouble(txtedfa24night.ToolTip);
            double weekend = Convert.ToDouble(txtedfa24ew.ToolTip);

            double upliftc = Convert.ToDouble(txtedfa24uplift.Text);

            double eac = Convert.ToDouble(lblEac.Text);

            if (txtedfa24day.Text != "0")
            {
                dayc = dayc + upliftc;
                txtedfa24day.Text = dayc.ToString();
            }

            if (txtedfa24night.Text != "0")
            {
                nightprice = nightprice + upliftc;
                txtedfa24night.Text = nightprice.ToString();
            }

            if (txtedfa24ew.Text != "0")
            {
                weekend = weekend + upliftc;
                txtedfa24ew.Text = weekend.ToString();
            }



            if (lblEDFMetertype.Text == "EWN")
            {
                finalvalue = lib.EdfEwn(sc, dayc, nightprice, weekend, eac);
                txtEdf24Rate.Text = finalvalue.ToString();
            }
            if (lblEDFMetertype.Text == "STD")
            {
                finalvalue = lib.Edfstd(sc, dayc, eac);
                txtEdf24Rate.Text = finalvalue.ToString();
            }
            if (lblEDFMetertype.Text == "EC7")
            {
                finalvalue = lib.EdfEC7(sc, dayc, nightprice, eac);
                txtEdf24Rate.Text = finalvalue.ToString();
            }
            if (lblEDFMetertype.Text == "EWE")
            {
                finalvalue = lib.EDFEWE(sc, dayc, weekend, eac);
                txtEdf24Rate.Text = finalvalue.ToString();
            }

        }

        void Edf24all()
        {

            double finalvalue = 0;

            double sc = Convert.ToDouble(txtedfa24scall.Text);
            double dayc = Convert.ToDouble(txtedfa24dayall.ToolTip);
            double nightprice = Convert.ToDouble(txtedfa24nightall.ToolTip);
            double weekend = Convert.ToDouble(txtedfa24ewall.ToolTip);

            double upliftc = Convert.ToDouble(txtedfa24upliftall.Text);

            double eac = Convert.ToDouble(lblEac.Text);

            if (txtedfa24dayall.Text != "0")
            {
                dayc = dayc + upliftc;
                txtedfa24dayall.Text = dayc.ToString();
            }

            if (txtedfa24nightall.Text != "0")
            {
                nightprice = nightprice + upliftc;
                txtedfa24nightall.Text = nightprice.ToString();
            }

            if (txtedfa24ewall.Text != "0")
            {
                weekend = weekend + upliftc;
                txtedfa24ewall.Text = weekend.ToString();
            }



            if (lblEDFMetertype.Text == "EWN")
            {
                finalvalue = lib.EdfEwn(sc, dayc, nightprice, weekend, eac);
                txtedf24rateall.Text = finalvalue.ToString();
            }
            if (lblEDFMetertype.Text == "STD")
            {
                finalvalue = lib.Edfstd(sc, dayc, eac);
                txtedf24rateall.Text = finalvalue.ToString();
            }
            if (lblEDFMetertype.Text == "EC7")
            {
                finalvalue = lib.EdfEC7(sc, dayc, nightprice, eac);
                txtedf24rateall.Text = finalvalue.ToString();
            }
            if (lblEDFMetertype.Text == "EWE")
            {
                finalvalue = lib.EDFEWE(sc, dayc, weekend, eac);
                txtedf24rateall.Text = finalvalue.ToString();
            }

        }

        void Edf36()
        {

            double finalvalue = 0;

            double sc = Convert.ToDouble(txtedfa36sc.Text);
            double dayc = Convert.ToDouble(txtedfa36day.ToolTip);
            double nightprice = Convert.ToDouble(txtedfa36night.ToolTip);
            double weekend = Convert.ToDouble(txtedfa36ew.ToolTip);

            double upliftc = Convert.ToDouble(txtedfa36uplift.Text);

            double eac = Convert.ToDouble(lblEac.Text);

            if (txtedfa36day.Text != "0")
            {
                dayc = dayc + upliftc;
                txtedfa36day.Text = dayc.ToString();
            }

            if (txtedfa36night.Text != "0")
            {
                nightprice = nightprice + upliftc;
                txtedfa36night.Text = nightprice.ToString();
            }

            if (txtedfa36ew.Text != "0")
            {
                weekend = weekend + upliftc;
                txtedfa36ew.Text = weekend.ToString();
            }



            if (lblEDFMetertype.Text == "EWN")
            {
                finalvalue = lib.EdfEwn(sc, dayc, nightprice, weekend, eac);
                txtEdf36Rate.Text = finalvalue.ToString();
            }
            if (lblEDFMetertype.Text == "STD")
            {
                finalvalue = lib.Edfstd(sc, dayc, eac);
                txtEdf36Rate.Text = finalvalue.ToString();
            }
            if (lblEDFMetertype.Text == "EC7")
            {
                finalvalue = lib.EdfEC7(sc, dayc, nightprice, eac);
                txtEdf36Rate.Text = finalvalue.ToString();
            }
            if (lblEDFMetertype.Text == "EWE")
            {
                finalvalue = lib.EDFEWE(sc, dayc, weekend, eac);
                txtEdf36Rate.Text = finalvalue.ToString();
            }

        }

        void Edf36all()
        {

            double finalvalue = 0;

            double sc = Convert.ToDouble(txtedfa36scall.Text);
            double dayc = Convert.ToDouble(txtedfa36dayall.ToolTip);
            double nightprice = Convert.ToDouble(txtedfa36nightall.ToolTip);
            double weekend = Convert.ToDouble(txtedfa36ewall.ToolTip);

            double upliftc = Convert.ToDouble(txtedfa36upliftall.Text);

            double eac = Convert.ToDouble(lblEac.Text);

            if (txtedfa36dayall.Text != "0")
            {
                dayc = dayc + upliftc;
                txtedfa36dayall.Text = dayc.ToString();
            }

            if (txtedfa36nightall.Text != "0")
            {
                nightprice = nightprice + upliftc;
                txtedfa36nightall.Text = nightprice.ToString();
            }

            if (txtedfa36ewall.Text != "0")
            {
                weekend = weekend + upliftc;
                txtedfa36ewall.Text = weekend.ToString();
            }



            if (lblEDFMetertype.Text == "EWN")
            {
                finalvalue = lib.EdfEwn(sc, dayc, nightprice, weekend, eac);
                txtedf36rateall.Text = finalvalue.ToString();
            }
            if (lblEDFMetertype.Text == "STD")
            {
                finalvalue = lib.Edfstd(sc, dayc, eac);
                txtedf36rateall.Text = finalvalue.ToString();
            }
            if (lblEDFMetertype.Text == "EC7")
            {
                finalvalue = lib.EdfEC7(sc, dayc, nightprice, eac);
                txtedf36rateall.Text = finalvalue.ToString();
            }
            if (lblEDFMetertype.Text == "EWE")
            {
                finalvalue = lib.EDFEWE(sc, dayc, weekend, eac);
                txtedf36rateall.Text = finalvalue.ToString();
            }

        }

        void Edf48()
        {

            double finalvalue = 0;

            double sc = Convert.ToDouble(txtedfa48sc.Text);
            double dayc = Convert.ToDouble(txtedfa48day.ToolTip);
            double nightprice = Convert.ToDouble(txtedfa48night.ToolTip);
            double weekend = Convert.ToDouble(txtedfa48ew.ToolTip);

            double upliftc = Convert.ToDouble(txtedfa48uplift.Text);

            double eac = Convert.ToDouble(lblEac.Text);

            if (txtedfa48day.Text != "0")
            {
                dayc = dayc + upliftc;
                txtedfa48day.Text = dayc.ToString();
            }

            if (txtedfa48night.Text != "0")
            {
                nightprice = nightprice + upliftc;
                txtedfa48night.Text = nightprice.ToString();
            }

            if (txtedfa48ew.Text != "0")
            {
                weekend = weekend + upliftc;
                txtedfa48ew.Text = weekend.ToString();
            }



            if (lblEDFMetertype.Text == "EWN")
            {
                finalvalue = lib.EdfEwn(sc, dayc, nightprice, weekend, eac);
                txtEdf48Rate.Text = finalvalue.ToString();
            }
            if (lblEDFMetertype.Text == "STD")
            {
                finalvalue = lib.Edfstd(sc, dayc, eac);
                txtEdf48Rate.Text = finalvalue.ToString();
            }
            if (lblEDFMetertype.Text == "EC7")
            {
                finalvalue = lib.EdfEC7(sc, dayc, nightprice, eac);
                txtEdf48Rate.Text = finalvalue.ToString();
            }
            if (lblEDFMetertype.Text == "EWE")
            {
                finalvalue = lib.EDFEWE(sc, dayc, weekend, eac);
                txtEdf48Rate.Text = finalvalue.ToString();
            }

        }

        void Edf48all()
        {

            double finalvalue = 0;

            double sc = Convert.ToDouble(txtedfa48scall.Text);
            double dayc = Convert.ToDouble(txtedfa48dayall.ToolTip);
            double nightprice = Convert.ToDouble(txtedfa48nightall.ToolTip);
            double weekend = Convert.ToDouble(txtedfa48ewall.ToolTip);

            double upliftc = Convert.ToDouble(txtedfa48upliftall.Text);

            double eac = Convert.ToDouble(lblEac.Text);

            if (txtedfa48dayall.Text != "0")
            {
                dayc = dayc + upliftc;
                txtedfa48dayall.Text = dayc.ToString();
            }

            if (txtedfa48nightall.Text != "0")
            {
                nightprice = nightprice + upliftc;
                txtedfa48nightall.Text = nightprice.ToString();
            }

            if (txtedfa48ewall.Text != "0")
            {
                weekend = weekend + upliftc;
                txtedfa48ewall.Text = weekend.ToString();
            }



            if (lblEDFMetertype.Text == "EWN")
            {
                finalvalue = lib.EdfEwn(sc, dayc, nightprice, weekend, eac);
                txtedfa48rateall.Text = finalvalue.ToString();
            }
            if (lblEDFMetertype.Text == "STD")
            {
                finalvalue = lib.Edfstd(sc, dayc, eac);
                txtedfa48rateall.Text = finalvalue.ToString();
            }
            if (lblEDFMetertype.Text == "EC7")
            {
                finalvalue = lib.EdfEC7(sc, dayc, nightprice, eac);
                txtedfa48rateall.Text = finalvalue.ToString();
            }
            if (lblEDFMetertype.Text == "EWE")
            {
                finalvalue = lib.EDFEWE(sc, dayc, weekend, eac);
                txtedfa48rateall.Text = finalvalue.ToString();
            }

        }

        #endregion


        #region DE uplift calculation
        void De12()
        {

            double finalvalue = 0;

            double sc = Convert.ToDouble(txtdea12sc.Text);
            double dayc = Convert.ToDouble(txtdea12day.ToolTip);
            double nightprice = Convert.ToDouble(txtdea12night.ToolTip);
            double weekend = Convert.ToDouble(txtdea12ew.ToolTip);

            double upliftc = Convert.ToDouble(txtdea12uplift.Text);

            double eac = Convert.ToDouble(lblEac.Text);

            if (txtdea12day.Text != "0")
            {
                dayc = dayc + upliftc;
                txtdea12day.Text = dayc.ToString();
            }

            if (txtdea12night.Text != "0")
            {
                nightprice = nightprice + upliftc;
                txtdea12night.Text = nightprice.ToString();
            }

            if (txtdea12ew.Text != "0")
            {
                weekend = weekend + upliftc;
                txtdea12ew.Text = weekend.ToString();
            }
            if (lblDEMetertype.Text == "DAY")
            {
                finalvalue = lib.Deday(sc, dayc, eac);
                txtde12rate.Text = finalvalue.ToString();
            }
            if (lblDEMetertype.Text == "E7")
            {
                finalvalue = lib.Dee7(sc, dayc, weekend, eac);
                txtde12rate.Text = finalvalue.ToString();
            }
            if (lblDEMetertype.Text == "EWN")
            {
                finalvalue = lib.DeeEWN(sc, dayc, nightprice, weekend, eac);
                txtde12rate.Text = finalvalue.ToString();
            }

            if (lblDEMetertype.Text == "EW")
            {
                finalvalue = lib.DeeEW(sc, dayc,  weekend, eac);
                txtde12rate.Text = finalvalue.ToString();
            }


        }
        void De12all()
        {

            double finalvalue = 0;

            double sc = Convert.ToDouble(txtdea12sc12all.Text);
            double dayc = Convert.ToDouble(txtdea12day12all.ToolTip);
            double nightprice = Convert.ToDouble(txtdea12night12all.ToolTip);
            double weekend = Convert.ToDouble(txtdea12ew12all.ToolTip);

            double upliftc = Convert.ToDouble(txtdea12uplift12all.Text);

            double eac = Convert.ToDouble(lblEac.Text);

            if (txtdea12day12all.Text != "0")
            {
                dayc = dayc + upliftc;
                txtdea12day12all.Text = dayc.ToString();
            }

            if (txtdea12night12all.Text != "0")
            {
                nightprice = nightprice + upliftc;
                txtdea12night12all.Text = nightprice.ToString();
            }

            if (txtdea12ew12all.Text != "0")
            {
                weekend = weekend + upliftc;
                txtdea12ew12all.Text = weekend.ToString();
            }
            if (lblDEMetertype.Text == "DAY")
            {
                finalvalue = lib.Deday(sc, dayc, eac);
                txtdea12all.Text = finalvalue.ToString();
            }
            if (lblDEMetertype.Text == "E7")
            {
                finalvalue = lib.Dee7(sc, dayc, weekend, eac);
                txtdea12all.Text = finalvalue.ToString();
            }
            if (lblDEMetertype.Text == "EWN")
            {
                finalvalue = lib.DeeEWN(sc, dayc, nightprice, weekend, eac);
                txtdea12all.Text = finalvalue.ToString();
            }

            if (lblDEMetertype.Text == "EW")
            {
                finalvalue = lib.DeeEW(sc, dayc, weekend, eac);
                txtdea12all.Text = finalvalue.ToString();
            }


        }

        void De24()
        {

            double finalvalue = 0;

            double sc = Convert.ToDouble(txtdea24sc.Text);
            double dayc = Convert.ToDouble(txtdea24day.ToolTip);
            double nightprice = Convert.ToDouble(txtdea24night.ToolTip);
            double weekend = Convert.ToDouble(txtdea24ew.ToolTip);

            double upliftc = Convert.ToDouble(txtdea24uplift.Text);

            double eac = Convert.ToDouble(lblEac.Text);

            if (txtdea24day.Text != "0")
            {
                dayc = dayc + upliftc;
                txtdea24day.Text = dayc.ToString();
            }

            if (txtdea24night.Text != "0")
            {
                nightprice = nightprice + upliftc;
                txtdea24night.Text = nightprice.ToString();
            }

            if (txtdea24ew.Text != "0")
            {
                weekend = weekend + upliftc;
                txtdea24ew.Text = weekend.ToString();
            }
            if (lblDEMetertype.Text == "DAY")
            {
                finalvalue = lib.Deday(sc, dayc, eac);
                txtde24rate.Text = finalvalue.ToString();
            }
            if (lblDEMetertype.Text == "E7")
            {
                finalvalue = lib.Dee7(sc, dayc, weekend, eac);
                txtde24rate.Text = finalvalue.ToString();
            }
            if (lblDEMetertype.Text == "EWN")
            {
                finalvalue = lib.DeeEWN(sc, dayc, nightprice, weekend, eac);
                txtde24rate.Text = finalvalue.ToString();
            }

            if (lblDEMetertype.Text == "EW")
            {
                finalvalue = lib.DeeEW(sc, dayc, weekend, eac);
                txtde24rate.Text = finalvalue.ToString();
            }


        }

        void De24all()
        {

            double finalvalue = 0;

            double sc = Convert.ToDouble(txtdea24sc24all.Text);
            double dayc = Convert.ToDouble(txtdea24day24all.ToolTip);
            double nightprice = Convert.ToDouble(txtdea24night24all.ToolTip);
            double weekend = Convert.ToDouble(txtdea24ew24all.ToolTip);

            double upliftc = Convert.ToDouble(txtdea24uplift24all.Text);

            double eac = Convert.ToDouble(lblEac.Text);

            if (txtdea24day24all.Text != "0")
            {
                dayc = dayc + upliftc;
                txtdea24day24all.Text = dayc.ToString();
            }

            if (txtdea24night24all.Text != "0")
            {
                nightprice = nightprice + upliftc;
                txtdea24night24all.Text = nightprice.ToString();
            }

            if (txtdea24ew24all.Text != "0")
            {
                weekend = weekend + upliftc;
                txtdea24ew24all.Text = weekend.ToString();
            }
            if (lblDEMetertype.Text == "DAY")
            {
                finalvalue = lib.Deday(sc, dayc, eac);
                txtdea24all.Text = finalvalue.ToString();
            }
            if (lblDEMetertype.Text == "E7")
            {
                finalvalue = lib.Dee7(sc, dayc, weekend, eac);
                txtdea24all.Text = finalvalue.ToString();
            }
            if (lblDEMetertype.Text == "EWN")
            {
                finalvalue = lib.DeeEWN(sc, dayc, nightprice, weekend, eac);
                txtdea24all.Text = finalvalue.ToString();
            }

            if (lblDEMetertype.Text == "EW")
            {
                finalvalue = lib.DeeEW(sc, dayc, weekend, eac);
                txtdea24all.Text = finalvalue.ToString();
            }


        }
        void De36()
        {

            double finalvalue = 0;

            double sc = Convert.ToDouble(txtdea36sc.Text);
            double dayc = Convert.ToDouble(txtdea36day.ToolTip);
            double nightprice = Convert.ToDouble(txtdea36night.ToolTip);
            double weekend = Convert.ToDouble(txtdea36ew.ToolTip);

            double upliftc = Convert.ToDouble(txtdea36uplift.Text);

            double eac = Convert.ToDouble(lblEac.Text);

            if (txtdea36day.Text != "0")
            {
                dayc = dayc + upliftc;
                txtdea36day.Text = dayc.ToString();
            }

            if (txtdea36night.Text != "0")
            {
                nightprice = nightprice + upliftc;
                txtdea36night.Text = nightprice.ToString();
            }

            if (txtdea36ew.Text != "0")
            {
                weekend = weekend + upliftc;
                txtdea36ew.Text = weekend.ToString();
            }
            if (lblDEMetertype.Text == "DAY")
            {
                finalvalue = lib.Deday(sc, dayc, eac);
                txtde36rate.Text = finalvalue.ToString();
            }
            if (lblDEMetertype.Text == "E7")
            {
                finalvalue = lib.Dee7(sc, dayc, weekend, eac);
                txtde36rate.Text = finalvalue.ToString();
            }
            if (lblDEMetertype.Text == "EWN")
            {
                finalvalue = lib.DeeEWN(sc, dayc, nightprice, weekend, eac);
                txtde36rate.Text = finalvalue.ToString();
            }

            if (lblDEMetertype.Text == "EW")
            {
                finalvalue = lib.DeeEW(sc, dayc, weekend, eac);
                txtde36rate.Text = finalvalue.ToString();
            }


        }
        void De36all()
        {

            double finalvalue = 0;

            double sc = Convert.ToDouble(txtdea36scall.Text);
            double dayc = Convert.ToDouble(txtdea36dayall.ToolTip);
            double nightprice = Convert.ToDouble(txtdea36nightall.ToolTip);
            double weekend = Convert.ToDouble(txtdea36ewall.ToolTip);

            double upliftc = Convert.ToDouble(txtdea36uplift1ll.Text);

            double eac = Convert.ToDouble(lblEac.Text);

            if (txtdea36dayall.Text != "0")
            {
                dayc = dayc + upliftc;
                txtdea36dayall.Text = dayc.ToString();
            }

            if (txtdea36nightall.Text != "0")
            {
                nightprice = nightprice + upliftc;
                txtdea36nightall.Text = nightprice.ToString();
            }

            if (txtdea36ewall.Text != "0")
            {
                weekend = weekend + upliftc;
                txtdea36ewall.Text = weekend.ToString();
            }
            if (lblDEMetertype.Text == "DAY")
            {
                finalvalue = lib.Deday(sc, dayc, eac);
                txtdea36all.Text = finalvalue.ToString();
            }
            if (lblDEMetertype.Text == "E7")
            {
                finalvalue = lib.Dee7(sc, dayc, weekend, eac);
                txtdea36all.Text = finalvalue.ToString();
            }
            if (lblDEMetertype.Text == "EWN")
            {
                finalvalue = lib.DeeEWN(sc, dayc, nightprice, weekend, eac);
                txtdea36all.Text = finalvalue.ToString();
            }

            if (lblDEMetertype.Text == "EW")
            {
                finalvalue = lib.DeeEW(sc, dayc, weekend, eac);
                txtdea36all.Text = finalvalue.ToString();
            }


        }
        void De60()
        {

            double finalvalue = 0;

            double sc = Convert.ToDouble(txtdea60sc.Text);
            double dayc = Convert.ToDouble(txtdea60day.ToolTip);
            double nightprice = Convert.ToDouble(txtdea60night.ToolTip);
            double weekend = Convert.ToDouble(txtdea60ew.ToolTip);

            double upliftc = Convert.ToDouble(txtdea60uplift.Text);

            double eac = Convert.ToDouble(lblEac.Text);

            if (txtdea60day.Text != "0")
            {
                dayc = dayc + upliftc;
                txtdea60day.Text = dayc.ToString();
            }

            if (txtdea60night.Text != "0")
            {
                nightprice = nightprice + upliftc;
                txtdea60night.Text = nightprice.ToString();
            }

            if (txtdea60ew.Text != "0")
            {
                weekend = weekend + upliftc;
                txtdea60ew.Text = weekend.ToString();
            }
            if (lblDEMetertype.Text == "DAY")
            {
                finalvalue = lib.Deday(sc, dayc, eac);
                txtde60rate.Text = finalvalue.ToString();
            }
            if (lblDEMetertype.Text == "E7")
            {
                finalvalue = lib.Dee7(sc, dayc, weekend, eac);
                txtde60rate.Text = finalvalue.ToString();
            }
            if (lblDEMetertype.Text == "EWN")
            {
                finalvalue = lib.DeeEWN(sc, dayc, nightprice, weekend, eac);
                txtde60rate.Text = finalvalue.ToString();
            }

            if (lblDEMetertype.Text == "EW")
            {
                finalvalue = lib.DeeEW(sc, dayc, weekend, eac);
                txtde60rate.Text = finalvalue.ToString();
            }


        }

        void De60all()
        {

            double finalvalue = 0;

            double sc = Convert.ToDouble(txtdea60scall.Text);
            double dayc = Convert.ToDouble(txtdea60dayall.ToolTip);
            double nightprice = Convert.ToDouble(txtdea60nightall.ToolTip);
            double weekend = Convert.ToDouble(txtdea60ewall.ToolTip);

            double upliftc = Convert.ToDouble(txtdea60upliftall.Text);

            double eac = Convert.ToDouble(lblEac.Text);

            if (txtdea60dayall.Text != "0")
            {
                dayc = dayc + upliftc;
                txtdea60dayall.Text = dayc.ToString();
            }

            if (txtdea60nightall.Text != "0")
            {
                nightprice = nightprice + upliftc;
                txtdea60nightall.Text = nightprice.ToString();
            }

            if (txtdea60ewall.Text != "0")
            {
                weekend = weekend + upliftc;
                txtdea60ewall.Text = weekend.ToString();
            }
            if (lblDEMetertype.Text == "DAY")
            {
                finalvalue = lib.Deday(sc, dayc, eac);
                txtde60rateall.Text = finalvalue.ToString();
            }
            if (lblDEMetertype.Text == "E7")
            {
                finalvalue = lib.Dee7(sc, dayc, weekend, eac);
                txtde60rateall.Text = finalvalue.ToString();
            }
            if (lblDEMetertype.Text == "EWN")
            {
                finalvalue = lib.DeeEWN(sc, dayc, nightprice, weekend, eac);
                txtde60rateall.Text = finalvalue.ToString();
            }

            if (lblDEMetertype.Text == "EW")
            {
                finalvalue = lib.DeeEW(sc, dayc, weekend, eac);
                txtde60rateall.Text = finalvalue.ToString();
            }


        }

        #endregion

        #region PE UPlift calculation

        void Pe12()
        {

            double finalvalue = 0;

            double sc = Convert.ToDouble(txtpe12sc.Text);
            double dayc = Convert.ToDouble(txtpe12day.ToolTip);
            double nightprice = Convert.ToDouble(txtpe12night.ToolTip);
            double weekend = Convert.ToDouble(txtpe12ew.ToolTip);
            double other = Convert.ToDouble(txtpe12other.ToolTip);

            double upliftc = Convert.ToDouble(txtpe12uplift.Text);

            double eac = Convert.ToDouble(lblEac.Text);

            if (txtpe12day.Text != "0")
            {
                dayc = dayc + upliftc;
                txtpe12day.Text = dayc.ToString();
            }

            if (txtpe12night.Text != "0")
            {
                nightprice = nightprice + upliftc;
                txtpe12night.Text = nightprice.ToString();
            }

            if (txtpe12ew.Text != "0")
            {
                weekend = weekend + upliftc;
                txtpe12ew.Text = weekend.ToString();
            }

            if (txtpe12other.Text != "0")
            {
                weekend = weekend + upliftc;
                txtpe12other.Text = weekend.ToString();
            }


            if (lblPEMetertype.Text == "Business Unrestricted")
            {
                finalvalue = lib.PeBusinessUnrestricted(sc, dayc, eac);
                txtpe12rate.Text = finalvalue.ToString();
            }
            if (lblPEMetertype.Text == "Business Day Eve/WK")
            {
                finalvalue = lib.PeEW(sc, dayc, weekend, eac);
                txtpe12rate.Text = finalvalue.ToString();
            }
            if (lblPEMetertype.Text == "Business Day Night Eve/WK")
            {
                finalvalue = lib.PeBDEW(sc, dayc, nightprice, weekend, eac);
                txtpe12rate.Text = finalvalue.ToString();
            }

            if (lblPEMetertype.Text == "Business Nightsaver")
            {
                finalvalue = lib.PeDN(sc, dayc, nightprice, eac);
                txtpe12rate.Text = finalvalue.ToString();
            }


        }
        void Pe12all()
        {

            double finalvalue = 0;

            double sc = Convert.ToDouble(txtpe12scall.Text);
            double dayc = Convert.ToDouble(txtpe12dayall.ToolTip);
            double nightprice = Convert.ToDouble(txtpe12nightall.ToolTip);
            double weekend = Convert.ToDouble(txtpe12ewall.ToolTip);
            double other = Convert.ToDouble(txtpe12otherall.ToolTip);

            double upliftc = Convert.ToDouble(txtpe12upliftall.Text);

            double eac = Convert.ToDouble(lblEac.Text);

            if (txtpe12dayall.Text != "0")
            {
                dayc = dayc + upliftc;
                txtpe12dayall.Text = dayc.ToString();
            }

            if (txtpe12nightall.Text != "0")
            {
                nightprice = nightprice + upliftc;
                txtpe12nightall.Text = nightprice.ToString();
            }

            if (txtpe12ewall.Text != "0")
            {
                weekend = weekend + upliftc;
                txtpe12ewall.Text = weekend.ToString();
            }

            if (txtpe12otherall.Text != "0")
            {
                weekend = weekend + upliftc;
                txtpe12otherall.Text = weekend.ToString();
            }


            if (lblPEMetertype.Text == "Business Unrestricted")
            {
                finalvalue = lib.PeBusinessUnrestricted(sc, dayc, eac);
                txtpe12rateall.Text = finalvalue.ToString();
            }
            if (lblPEMetertype.Text == "Business Day Eve/WK")
            {
                finalvalue = lib.PeEW(sc, dayc, weekend, eac);
                txtpe12rateall.Text = finalvalue.ToString();
            }
            if (lblPEMetertype.Text == "Business Day Night Eve/WK")
            {
                finalvalue = lib.PeBDEW(sc, dayc, nightprice, weekend, eac);
                txtpe12rateall.Text = finalvalue.ToString();
            }

            if (lblPEMetertype.Text == "Business Nightsaver")
            {
                finalvalue = lib.PeDN(sc, dayc, nightprice, eac);
                txtpe12rateall.Text = finalvalue.ToString();
            }


        }

        void Pe24()
        {

            double finalvalue = 0;

            double sc = Convert.ToDouble(txtpe24sc.Text);
            double dayc = Convert.ToDouble(txtpe24day.ToolTip);
            double nightprice = Convert.ToDouble(txtpe24night.ToolTip);
            double weekend = Convert.ToDouble(txtpe24ew.ToolTip);
            double other = Convert.ToDouble(txtpe24other.ToolTip);

            double upliftc = Convert.ToDouble(txtpe24uplift.Text);

            double eac = Convert.ToDouble(lblEac.Text);

            if (txtpe24day.Text != "0")
            {
                dayc = dayc + upliftc;
                txtpe24day.Text = dayc.ToString();
            }

            if (txtpe24night.Text != "0")
            {
                nightprice = nightprice + upliftc;
                txtpe24night.Text = nightprice.ToString();
            }

            if (txtpe24ew.Text != "0")
            {
                weekend = weekend + upliftc;
                txtpe24ew.Text = weekend.ToString();
            }

            if (txtpe24other.Text != "0")
            {
                weekend = weekend + upliftc;
                txtpe24other.Text = weekend.ToString();
            }


            if (lblPEMetertype.Text == "Business Unrestricted")
            {
                finalvalue = lib.PeBusinessUnrestricted(sc, dayc, eac);
                txtpe24rate.Text = finalvalue.ToString();
            }
            if (lblPEMetertype.Text == "Business Day Eve/WK")
            {
                finalvalue = lib.PeEW(sc, dayc, weekend, eac);
                txtde24rate.Text = finalvalue.ToString();
            }
            if (lblPEMetertype.Text == "Business Day Night Eve/WK")
            {
                finalvalue = lib.PeBDEW(sc, dayc, nightprice, weekend, eac);
                txtde24rate.Text = finalvalue.ToString();
            }

            if (lblPEMetertype.Text == "Business Nightsaver")
            {
                finalvalue = lib.PeDN(sc, dayc, nightprice, eac);
                txtde24rate.Text = finalvalue.ToString();
            }


        }

        void Pe24all()
        {

            double finalvalue = 0;

            double sc = Convert.ToDouble(txtpe24scall.Text);
            double dayc = Convert.ToDouble(txtpe24dayall.ToolTip);
            double nightprice = Convert.ToDouble(txtpe24nightall.ToolTip);
            double weekend = Convert.ToDouble(txtpe24ewall.ToolTip);
            double other = Convert.ToDouble(txtpe24otherall.ToolTip);

            double upliftc = Convert.ToDouble(txtpe24upliftall.Text);

            double eac = Convert.ToDouble(lblEac.Text);

            if (txtpe24dayall.Text != "0")
            {
                dayc = dayc + upliftc;
                txtpe24dayall.Text = dayc.ToString();
            }

            if (txtpe24nightall.Text != "0")
            {
                nightprice = nightprice + upliftc;
                txtpe24nightall.Text = nightprice.ToString();
            }

            if (txtpe24ewall.Text != "0")
            {
                weekend = weekend + upliftc;
                txtpe24ewall.Text = weekend.ToString();
            }

            if (txtpe24otherall.Text != "0")
            {
                weekend = weekend + upliftc;
                txtpe24otherall.Text = weekend.ToString();
            }


            if (lblPEMetertype.Text == "Business Unrestricted")
            {
                finalvalue = lib.PeBusinessUnrestricted(sc, dayc, eac);
                txtpe24rateall.Text = finalvalue.ToString();
            }
            if (lblPEMetertype.Text == "Business Day Eve/WK")
            {
                finalvalue = lib.PeEW(sc, dayc, weekend, eac);
                txtpe24rateall.Text = finalvalue.ToString();
            }
            if (lblPEMetertype.Text == "Business Day Night Eve/WK")
            {
                finalvalue = lib.PeBDEW(sc, dayc, nightprice, weekend, eac);
                txtpe24rateall.Text = finalvalue.ToString();
            }

            if (lblPEMetertype.Text == "Business Nightsaver")
            {
                finalvalue = lib.PeDN(sc, dayc, nightprice, eac);
                txtpe24rateall.Text = finalvalue.ToString();
            }


        }
        void Pe36()
        {

            double finalvalue = 0;

            double sc = Convert.ToDouble(txtpe36sc.Text);
            double dayc = Convert.ToDouble(txtpe36day.ToolTip);
            double nightprice = Convert.ToDouble(txtpe36night.ToolTip);
            double weekend = Convert.ToDouble(txtpe36ew.ToolTip);
            double other = Convert.ToDouble(txtpe36other.ToolTip);

            double upliftc = Convert.ToDouble(txtpe36uplift.Text);

            double eac = Convert.ToDouble(lblEac.Text);

            if (txtpe36day.Text != "0")
            {
                dayc = dayc + upliftc;
                txtpe36day.Text = dayc.ToString();
            }

            if (txtpe36night.Text != "0")
            {
                nightprice = nightprice + upliftc;
                txtpe36night.Text = nightprice.ToString();
            }

            if (txtpe36ew.Text != "0")
            {
                weekend = weekend + upliftc;
                txtpe36ew.Text = weekend.ToString();
            }

            if (txtpe36other.Text != "0")
            {
                weekend = weekend + upliftc;
                txtpe36other.Text = weekend.ToString();
            }


            if (lblPEMetertype.Text == "Business Unrestricted")
            {
                finalvalue = lib.PeBusinessUnrestricted(sc, dayc, eac);
                txtpe36rate.Text = finalvalue.ToString();
            }
            if (lblPEMetertype.Text == "Business Day Eve/WK")
            {
                finalvalue = lib.PeEW(sc, dayc, weekend, eac);
                txtpe36rate.Text = finalvalue.ToString();
            }
            if (lblPEMetertype.Text == "Business Day Night Eve/WK")
            {
                finalvalue = lib.PeBDEW(sc, dayc, nightprice, weekend, eac);
                txtpe36rate.Text = finalvalue.ToString();
            }

            if (lblPEMetertype.Text == "Business Nightsaver")
            {
                finalvalue = lib.PeDN(sc, dayc, nightprice, eac);
                txtpe36rate.Text = finalvalue.ToString();
            }


        }
        void Pe36all()
        {

            double finalvalue = 0;

            double sc = Convert.ToDouble(txtpe36scall.Text);
            double dayc = Convert.ToDouble(txtpe36dayall.ToolTip);
            double nightprice = Convert.ToDouble(txtpe36nightall.ToolTip);
            double weekend = Convert.ToDouble(txtpe36ewall.ToolTip);
            double other = Convert.ToDouble(txtpe36otherall.ToolTip);

            double upliftc = Convert.ToDouble(txtpe36upliftall.Text);

            double eac = Convert.ToDouble(lblEac.Text);

            if (txtpe36dayall.Text != "0")
            {
                dayc = dayc + upliftc;
                txtpe36dayall.Text = dayc.ToString();
            }

            if (txtpe36nightall.Text != "0")
            {
                nightprice = nightprice + upliftc;
                txtpe36nightall.Text = nightprice.ToString();
            }

            if (txtpe36ewall.Text != "0")
            {
                weekend = weekend + upliftc;
                txtpe36ewall.Text = weekend.ToString();
            }

            if (txtpe36otherall.Text != "0")
            {
                weekend = weekend + upliftc;
                txtpe36otherall.Text = weekend.ToString();
            }


            if (lblPEMetertype.Text == "Business Unrestricted")
            {
                finalvalue = lib.PeBusinessUnrestricted(sc, dayc, eac);
                txtpe36rateall.Text = finalvalue.ToString();
            }
            if (lblPEMetertype.Text == "Business Day Eve/WK")
            {
                finalvalue = lib.PeEW(sc, dayc, weekend, eac);
                txtpe36rateall.Text = finalvalue.ToString();
            }
            if (lblPEMetertype.Text == "Business Day Night Eve/WK")
            {
                finalvalue = lib.PeBDEW(sc, dayc, nightprice, weekend, eac);
                txtpe36rateall.Text = finalvalue.ToString();
            }

            if (lblPEMetertype.Text == "Business Nightsaver")
            {
                finalvalue = lib.PeDN(sc, dayc, nightprice, eac);
                txtpe36rateall.Text = finalvalue.ToString();
            }


        }

        #endregion


        #region GAZ Uplift calculation
        void Gaz12()
        {

            double finalvalue = 0;

            double sc = Convert.ToDouble(txtgaz12sc.Text);
            double dayc = Convert.ToDouble(txtgaz12day.ToolTip);
            double nightprice = Convert.ToDouble(txtgaz12night.ToolTip);
            double weekend = Convert.ToDouble(txtgaz12ew.ToolTip);
            //double unitc = Convert.ToDouble(txtgaz12unit.ToolTip);

            double upliftc = Convert.ToDouble(txtgaz12uplift.Text);

            double eac = Convert.ToDouble(lblEac.Text);

            if (txtgaz12day.Text != "0")
            {
                dayc = dayc + upliftc;
                txtgaz12day.Text = dayc.ToString();
            }

            //if (txtgaz12unit.Text != "0")
            //{
            //    unitc = unitc + upliftc;
            //    txtgaz12unit.Text = unitc.ToString();
            //}

            if (txtgaz12night.Text != "0")
            {
                nightprice = nightprice + upliftc;
                txtgaz12night.Text = nightprice.ToString();
            }

            if (txtgaz12ew.Text != "0")
            {
                weekend = weekend + upliftc;
                txtgaz12ew.Text = weekend.ToString();
            }


            if (lblGZMetertype.Text == "Unrestricted")
            {
                finalvalue = lib.gazUnrestricted(sc, dayc, eac);
                txtgaz12rate.Text = finalvalue.ToString();
            }

            if (lblGZMetertype.Text == "Economy 7")
            {
                finalvalue = lib.gazeco7(sc, dayc, nightprice, eac);
                txtgaz12rate.Text = finalvalue.ToString();
            }

            if (lblGZMetertype.Text == "Evening & Weekend")
            {
                finalvalue = lib.gazeanw(sc, dayc, weekend, eac);
                txtgaz12rate.Text = finalvalue.ToString();
            }

            if (lblGZMetertype.Text == "3 Rate (Day, Night & Evening & Weekend)")
            {
                finalvalue = lib.gazdayeveweek(sc, dayc, nightprice, weekend, eac);
                txtgaz12rate.Text = finalvalue.ToString();
            }

        }
        void Gaz12all()
        {

            double finalvalue = 0;

            double sc = Convert.ToDouble(txtgaz12scall.Text);
            double dayc = Convert.ToDouble(txtgaz12dayall.ToolTip);
            double nightprice = Convert.ToDouble(txtgaz12nightall.ToolTip);
            double weekend = Convert.ToDouble(txtgaz12ewall.ToolTip);
            //double unitc = Convert.ToDouble(txtgaz12unitall.ToolTip);

            double upliftc = Convert.ToDouble(txtgaz12upliftall.Text);

            double eac = Convert.ToDouble(lblEac.Text);

            if (txtgaz12dayall.Text != "0")
            {
                dayc = dayc + upliftc;
                txtgaz12dayall.Text = dayc.ToString();
            }

            //if (txtgaz12unitall.Text != "0")
            //{
            //    unitc = unitc + upliftc;
            //    txtgaz12unitall.Text = unitc.ToString();
            //}

            if (txtgaz12night.Text != "0")
            {
                nightprice = nightprice + upliftc;
                txtgaz12nightall.Text = nightprice.ToString();
            }

            if (txtgaz12ewall.Text != "0")
            {
                weekend = weekend + upliftc;
                txtgaz12ewall.Text = weekend.ToString();
            }


            if (lblGZMetertype.Text == "Unrestricted")
            {
                finalvalue = lib.gazUnrestricted(sc, dayc, eac);
                txtgaz12rateall.Text = finalvalue.ToString();
            }

            if (lblGZMetertype.Text == "Economy 7")
            {
                finalvalue = lib.gazeco7(sc, dayc, nightprice, eac);
                txtgaz12rateall.Text = finalvalue.ToString();
            }

            if (lblGZMetertype.Text == "Evening & Weekend")
            {
                finalvalue = lib.gazeanw(sc, dayc, weekend, eac);
                txtgaz12rateall.Text = finalvalue.ToString();
            }

            if (lblGZMetertype.Text == "3 Rate (Day, Night & Evening & Weekend)")
            {
                finalvalue = lib.gazdayeveweek(sc, dayc, nightprice, weekend, eac);
                txtgaz12rateall.Text = finalvalue.ToString();
            }

        } 

        void Gaz24()
        {

            double finalvalue = 0;

            double sc = Convert.ToDouble(txtgaz24sc.Text);
            double dayc = Convert.ToDouble(txtgaz24day.ToolTip);
            double nightprice = Convert.ToDouble(txtgaz24night.ToolTip);
            double weekend = Convert.ToDouble(txtgaz24ew.ToolTip);
            //double unitc = Convert.ToDouble(txtgaz24unit.ToolTip);

            double upliftc = Convert.ToDouble(txtgaz24uplift.Text);

            double eac = Convert.ToDouble(lblEac.Text);

            if (txtgaz24day.Text != "0")
            {
                dayc = dayc + upliftc;
                txtgaz24day.Text = dayc.ToString();
            }

            //if (txtgaz24unit.Text != "0")
            //{
            //    unitc = unitc + upliftc;
            //    txtgaz24unit.Text = unitc.ToString();
            //}

            if (txtgaz24night.Text != "0")
            {
                nightprice = nightprice + upliftc;
                txtgaz24night.Text = nightprice.ToString();
            }

            if (txtgaz24ew.Text != "0")
            {
                weekend = weekend + upliftc;
                txtgaz24ew.Text = weekend.ToString();
            }


            if (lblGZMetertype.Text == "Unrestricted")
            {
                finalvalue = lib.gazUnrestricted(sc, dayc, eac);
                txtgaz24rate.Text = finalvalue.ToString();
            }

            if (lblGZMetertype.Text == "Economy 7")
            {
                finalvalue = lib.gazeco7(sc, dayc, nightprice, eac);
                txtgaz24rate.Text = finalvalue.ToString();
            }

            if (lblGZMetertype.Text == "Evening & Weekend")
            {
                finalvalue = lib.gazeanw(sc, dayc, weekend, eac);
                txtgaz24rate.Text = finalvalue.ToString();
            }

            if (lblGZMetertype.Text == "3 Rate (Day, Night & Evening & Weekend)")
            {
                finalvalue = lib.gazdayeveweek(sc, dayc, nightprice, weekend, eac);
                txtgaz24rate.Text = finalvalue.ToString();
            }

        }
        void Gaz24all()
        {

            double finalvalue = 0;

            double sc = Convert.ToDouble(txtgaz24scall.Text);
            double dayc = Convert.ToDouble(txtgaz24dayall.ToolTip);
            double nightprice = Convert.ToDouble(txtgaz24nightall.ToolTip);
            double weekend = Convert.ToDouble(txtgaz24ewall.ToolTip);
            //double unitc = Convert.ToDouble(txtgaz24unitall.ToolTip);

            double upliftc = Convert.ToDouble(txtgaz24upliftall.Text);

            double eac = Convert.ToDouble(lblEac.Text);

            if (txtgaz24dayall.Text != "0")
            {
                dayc = dayc + upliftc;
                txtgaz24dayall.Text = dayc.ToString();
            }

            //if (txtgaz24unitall.Text != "0")
            //{
            //    unitc = unitc + upliftc;
            //    txtgaz24unitall.Text = unitc.ToString();
            //}

            if (txtgaz24night.Text != "0")
            {
                nightprice = nightprice + upliftc;
                txtgaz24nightall.Text = nightprice.ToString();
            }

            if (txtgaz24ewall.Text != "0")
            {
                weekend = weekend + upliftc;
                txtgaz24ewall.Text = weekend.ToString();
            }


            if (lblGZMetertype.Text == "Unrestricted")
            {
                finalvalue = lib.gazUnrestricted(sc, dayc, eac);
                txtgaz24rateall.Text = finalvalue.ToString();
            }

            if (lblGZMetertype.Text == "Economy 7")
            {
                finalvalue = lib.gazeco7(sc, dayc, nightprice, eac);
                txtgaz24rateall.Text = finalvalue.ToString();
            }

            if (lblGZMetertype.Text == "Evening & Weekend")
            {
                finalvalue = lib.gazeanw(sc, dayc, weekend, eac);
                txtgaz24rateall.Text = finalvalue.ToString();
            }

            if (lblGZMetertype.Text == "3 Rate (Day, Night & Evening & Weekend)")
            {
                finalvalue = lib.gazdayeveweek(sc, dayc, nightprice, weekend, eac);
                txtgaz24rateall.Text = finalvalue.ToString();
            }

        }
        void Gaz36()
        {

            double finalvalue = 0;

            double sc = Convert.ToDouble(txtgaz36sc.Text);
            double dayc = Convert.ToDouble(txtgaz36day.ToolTip);
            double nightprice = Convert.ToDouble(txtgaz36night.ToolTip);
            double weekend = Convert.ToDouble(txtgaz36ew.ToolTip);
            //double unitc = Convert.ToDouble(txtgaz36unit.ToolTip);

            double upliftc = Convert.ToDouble(txtgaz36uplift.Text);

            double eac = Convert.ToDouble(lblEac.Text);

            if (txtgaz36day.Text != "0")
            {
                dayc = dayc + upliftc;
                txtgaz36day.Text = dayc.ToString();
            }

            //if (txtgaz36unit.Text != "0")
            //{
            //    unitc = unitc + upliftc;
            //    txtgaz36unit.Text = unitc.ToString();
            //}

            if (txtgaz36night.Text != "0")
            {
                nightprice = nightprice + upliftc;
                txtgaz36night.Text = nightprice.ToString();
            }

            if (txtgaz36ew.Text != "0")
            {
                weekend = weekend + upliftc;
                txtgaz36ew.Text = weekend.ToString();
            }


            if (lblGZMetertype.Text == "Unrestricted")
            {
                finalvalue = lib.gazUnrestricted(sc, dayc, eac);
                txtgaz36rate.Text = finalvalue.ToString();
            }

            if (lblGZMetertype.Text == "Economy 7")
            {
                finalvalue = lib.gazeco7(sc, dayc, nightprice, eac);
                txtgaz36rate.Text = finalvalue.ToString();
            }

            if (lblGZMetertype.Text == "Evening & Weekend")
            {
                finalvalue = lib.gazeanw(sc, dayc, weekend, eac);
                txtgaz36rate.Text = finalvalue.ToString();
            }

            if (lblGZMetertype.Text == "3 Rate (Day, Night & Evening & Weekend)")
            {
                finalvalue = lib.gazdayeveweek(sc, dayc, nightprice, weekend, eac);
                txtgaz36rate.Text = finalvalue.ToString();
            }

        }
        void Gaz36all()
        {

            double finalvalue = 0;

            double sc = Convert.ToDouble(txtgaz36scall.Text);
            double dayc = Convert.ToDouble(txtgaz36dayall.ToolTip);
            double nightprice = Convert.ToDouble(txtgaz36nightall.ToolTip);
            double weekend = Convert.ToDouble(txtgaz36ewall.ToolTip);
            //double unitc = Convert.ToDouble(txtgaz36unitall.ToolTip);

            double upliftc = Convert.ToDouble(txtgaz36upliftall.Text);

            double eac = Convert.ToDouble(lblEac.Text);

            if (txtgaz36dayall.Text != "0")
            {
                dayc = dayc + upliftc;
                txtgaz36dayall.Text = dayc.ToString();
            }

            //if (txtgaz36unitall.Text != "0")
            //{
            //    unitc = unitc + upliftc;
            //    txtgaz36unitall.Text = unitc.ToString();
            //}

            if (txtgaz36night.Text != "0")
            {
                nightprice = nightprice + upliftc;
                txtgaz36nightall.Text = nightprice.ToString();
            }

            if (txtgaz36ewall.Text != "0")
            {
                weekend = weekend + upliftc;
                txtgaz36ewall.Text = weekend.ToString();
            }


            if (lblGZMetertype.Text == "Unrestricted")
            {
                finalvalue = lib.gazUnrestricted(sc, dayc, eac);
                txtgaz36rateall.Text = finalvalue.ToString();
            }

            if (lblGZMetertype.Text == "Economy 7")
            {
                finalvalue = lib.gazeco7(sc, dayc, nightprice, eac);
                txtgaz36rateall.Text = finalvalue.ToString();
            }

            if (lblGZMetertype.Text == "Evening & Weekend")
            {
                finalvalue = lib.gazeanw(sc, dayc, weekend, eac);
                txtgaz36rateall.Text = finalvalue.ToString();
            }

            if (lblGZMetertype.Text == "3 Rate (Day, Night & Evening & Weekend)")
            {
                finalvalue = lib.gazdayeveweek(sc, dayc, nightprice, weekend, eac);
                txtgaz36rateall.Text = finalvalue.ToString();
            }

        }

        #endregion

        #region NPower Uplift calculation

        void npower12()
        {
            double finalvalue = 0;

            double sc = Convert.ToDouble(txtnpra12sc.Text);
            double dayc = Convert.ToDouble(txtnpra12day.ToolTip);
            double nightprice = Convert.ToDouble(txtnpra12night.ToolTip);
            double weekend = Convert.ToDouble(txtnpra12ew.ToolTip);
            //double unitc = Convert.ToDouble(txtnpra12unit.ToolTip);
            double otherc = Convert.ToDouble(txtnpra12other.ToolTip);

            double upliftc = Convert.ToDouble(txtnpra12uplift.Text);

            double eac = Convert.ToDouble(lblEac.Text);

            if (txtnpra12day.Text != "0")
            {
                dayc = dayc + upliftc;
                txtnpra12day.Text = dayc.ToString();
            }

            //if (txtnpra12unit.Text != "0")
            //{
            //    unitc = unitc + upliftc;
            //    txtnpra12unit.Text = unitc.ToString();
            //}

            if (txtnpra12night.Text != "0")
            {
                nightprice = nightprice + upliftc;
                txtnpra12night.Text = nightprice.ToString();
            }

            if (txtnpra12ew.Text != "0")
            {
                weekend = weekend + upliftc;
                txtnpra12ew.Text = weekend.ToString();
            }

            if (txtnpra12other.Text != "0")
            {
                weekend = weekend + upliftc;
                txtnpra12other.Text = weekend.ToString();
            }






            if (lblNpwer.Text == "EBF_STD")
            {
                finalvalue = lib.NpowerEBF_STD(sc, dayc, eac);
                txtnpra12rate.Text = finalvalue.ToString();
            }

            if (lblNpwer.Text == "EBF_E07")
            {
                finalvalue = lib.NpowerEBF_E07(sc, dayc, nightprice, eac);
                txtnpra12rate.Text = finalvalue.ToString();
            }

            if (lblNpwer.Text == "EBF_H07")
            {
                finalvalue = lib.NpowerEBF_H07(sc, otherc, eac);
                txtnpra12rate.Text = finalvalue.ToString();
            }

            if (lblNpwer.Text == "EBF_H07")
            {
                finalvalue = lib.NpowerEBF_E_W(sc, weekend, otherc, eac);
                txtnpra12rate.Text = finalvalue.ToString();
            }



        }

        void npower12all()
        {
            double finalvalue = 0;

            double sc = Convert.ToDouble(txtnpra12scall.Text);
            double dayc = Convert.ToDouble(txtnpra12dayall.ToolTip);
            double nightprice = Convert.ToDouble(txtnpra12nightall.ToolTip);
            double weekend = Convert.ToDouble(txtnpra12ewall.ToolTip);
            //double unitc = Convert.ToDouble(txtnpra12unitall.ToolTip);
            double otherc = Convert.ToDouble(txtnpra12otherall.ToolTip);

            double upliftc = Convert.ToDouble(txtnpra12upliftall.Text);

            double eac = Convert.ToDouble(lblEac.Text);

            if (txtnpra12dayall.Text != "0")
            {
                dayc = dayc + upliftc;
                txtnpra12dayall.Text = dayc.ToString();
            }

            //if (txtnpra12unitall.Text != "0")
            //{
            //    unitc = unitc + upliftc;
            //    txtnpra12unitall.Text = unitc.ToString();
            //}

            if (txtnpra12nightall.Text != "0")
            {
                nightprice = nightprice + upliftc;
                txtnpra12nightall.Text = nightprice.ToString();
            }

            if (txtnpra12ewall.Text != "0")
            {
                weekend = weekend + upliftc;
                txtnpra12ewall.Text = weekend.ToString();
            }

            if (txtnpra12otherall.Text != "0")
            {
                weekend = weekend + upliftc;
                txtnpra12otherall.Text = weekend.ToString();
            }






            if (lblNpwer.Text == "EBF_STD")
            {
                finalvalue = lib.NpowerEBF_STD(sc, dayc, eac);
                txtnpra12rateall.Text = finalvalue.ToString();
            }

            if (lblNpwer.Text == "EBF_E07")
            {
                finalvalue = lib.NpowerEBF_E07(sc, dayc, nightprice, eac);
                txtnpra12rateall.Text = finalvalue.ToString();
            }

            if (lblNpwer.Text == "EBF_H07")
            {
                finalvalue = lib.NpowerEBF_H07(sc, otherc, eac);
                txtnpra12rateall.Text = finalvalue.ToString();
            }

            if (lblNpwer.Text == "EBF_H07")
            {
                finalvalue = lib.NpowerEBF_E_W(sc, weekend, otherc, eac);
                txtnpra12rateall.Text = finalvalue.ToString();
            }



        }
        void npower24()
        {
            double finalvalue = 0;

            double sc = Convert.ToDouble(txtnpra24sc.Text);
            double dayc = Convert.ToDouble(txtnpra24day.ToolTip);
            double nightprice = Convert.ToDouble(txtnpra24night.ToolTip);
            double weekend = Convert.ToDouble(txtnpra24ew.ToolTip);
            //double unitc = Convert.ToDouble(txtnpra24unit.ToolTip);
            double otherc = Convert.ToDouble(txtnpra24other.ToolTip);

            double upliftc = Convert.ToDouble(txtnpra24uplift.Text);

            double eac = Convert.ToDouble(lblEac.Text);

            if (txtnpra24day.Text != "0")
            {
                dayc = dayc + upliftc;
                txtnpra24day.Text = dayc.ToString();
            }

            //if (txtnpra24unit.Text != "0")
            //{
            //    unitc = unitc + upliftc;
            //    txtnpra24unit.Text = unitc.ToString();
            //}

            if (txtnpra24night.Text != "0")
            {
                nightprice = nightprice + upliftc;
                txtnpra24night.Text = nightprice.ToString();
            }

            if (txtnpra24ew.Text != "0")
            {
                weekend = weekend + upliftc;
                txtnpra24ew.Text = weekend.ToString();
            }

            if (txtnpra24other.Text != "0")
            {
                weekend = weekend + upliftc;
                txtnpra24other.Text = weekend.ToString();
            }






            if (lblNpwer.Text == "EBF_STD")
            {
                finalvalue = lib.NpowerEBF_STD(sc, dayc, eac);
                txtnpra24rate.Text = finalvalue.ToString();
            }

            if (lblNpwer.Text == "EBF_E07")
            {
                finalvalue = lib.NpowerEBF_E07(sc, dayc, nightprice, eac);
                txtnpra24rate.Text = finalvalue.ToString();
            }

            if (lblNpwer.Text == "EBF_H07")
            {
                finalvalue = lib.NpowerEBF_H07(sc, otherc, eac);
                txtnpra24rate.Text = finalvalue.ToString();
            }

            if (lblNpwer.Text == "EBF_H07")
            {
                finalvalue = lib.NpowerEBF_E_W(sc, weekend, otherc, eac);
                txtnpra24rate.Text = finalvalue.ToString();
            }



        }
        void npower24all()
        {
            double finalvalue = 0;

            double sc = Convert.ToDouble(txtnpra24scall.Text);
            double dayc = Convert.ToDouble(txtnpra24dayall.ToolTip);
            double nightprice = Convert.ToDouble(txtnpra24nightall.ToolTip);
            double weekend = Convert.ToDouble(txtnpra24ewall.ToolTip);
            //double unitc = Convert.ToDouble(txtnpra24unitall.ToolTip);
            double otherc = Convert.ToDouble(txtnpra24otherall.ToolTip);

            double upliftc = Convert.ToDouble(txtnpra24upliftall.Text);

            double eac = Convert.ToDouble(lblEac.Text);

            if (txtnpra24dayall.Text != "0")
            {
                dayc = dayc + upliftc;
                txtnpra24dayall.Text = dayc.ToString();
            }

            //if (txtnpra24unitall.Text != "0")
            //{
            //    unitc = unitc + upliftc;
            //    txtnpra24unitall.Text = unitc.ToString();
            //}

            if (txtnpra24nightall.Text != "0")
            {
                nightprice = nightprice + upliftc;
                txtnpra24nightall.Text = nightprice.ToString();
            }

            if (txtnpra24ewall.Text != "0")
            {
                weekend = weekend + upliftc;
                txtnpra24ewall.Text = weekend.ToString();
            }

            if (txtnpra24otherall.Text != "0")
            {
                weekend = weekend + upliftc;
                txtnpra24otherall.Text = weekend.ToString();
            }






            if (lblNpwer.Text == "EBF_STD")
            {
                finalvalue = lib.NpowerEBF_STD(sc, dayc, eac);
                txtnpra24rateall.Text = finalvalue.ToString();
            }

            if (lblNpwer.Text == "EBF_E07")
            {
                finalvalue = lib.NpowerEBF_E07(sc, dayc, nightprice, eac);
                txtnpra24rateall.Text = finalvalue.ToString();
            }

            if (lblNpwer.Text == "EBF_H07")
            {
                finalvalue = lib.NpowerEBF_H07(sc, otherc, eac);
                txtnpra24rateall.Text = finalvalue.ToString();
            }

            if (lblNpwer.Text == "EBF_H07")
            {
                finalvalue = lib.NpowerEBF_E_W(sc, weekend, otherc, eac);
                txtnpra24rateall.Text = finalvalue.ToString();
            }



        }
        void npower36()
        {
            double finalvalue = 0;

            double sc = Convert.ToDouble(txtnpra36sc.Text);
            double dayc = Convert.ToDouble(txtnpra36day.ToolTip);
            double nightprice = Convert.ToDouble(txtnpra36night.ToolTip);
            double weekend = Convert.ToDouble(txtnpra36ew.ToolTip);
            //double unitc = Convert.ToDouble(txtnpra36unit.ToolTip);
            double otherc = Convert.ToDouble(txtnpra36other.ToolTip);

            double upliftc = Convert.ToDouble(txtnpra36uplift.Text);

            double eac = Convert.ToDouble(lblEac.Text);

            if (txtnpra36day.Text != "0")
            {
                dayc = dayc + upliftc;
                txtnpra36day.Text = dayc.ToString();
            }

            //if (txtnpra36unit.Text != "0")
            //{
            //    unitc = unitc + upliftc;
            //    txtnpra36unit.Text = unitc.ToString();
            //}

            if (txtnpra36night.Text != "0")
            {
                nightprice = nightprice + upliftc;
                txtnpra36night.Text = nightprice.ToString();
            }

            if (txtnpra36ew.Text != "0")
            {
                weekend = weekend + upliftc;
                txtnpra36ew.Text = weekend.ToString();
            }

            if (txtnpra36other.Text != "0")
            {
                weekend = weekend + upliftc;
                txtnpra36other.Text = weekend.ToString();
            }






            if (lblNpwer.Text == "EBF_STD")
            {
                finalvalue = lib.NpowerEBF_STD(sc, dayc, eac);
                txtnpra36rate.Text = finalvalue.ToString();
            }

            if (lblNpwer.Text == "EBF_E07")
            {
                finalvalue = lib.NpowerEBF_E07(sc, dayc, nightprice, eac);
                txtnpra36rate.Text = finalvalue.ToString();
            }

            if (lblNpwer.Text == "EBF_H07")
            {
                finalvalue = lib.NpowerEBF_H07(sc, otherc, eac);
                txtnpra36rate.Text = finalvalue.ToString();
            }

            if (lblNpwer.Text == "EBF_H07")
            {
                finalvalue = lib.NpowerEBF_E_W(sc, weekend, otherc, eac);
                txtnpra36rate.Text = finalvalue.ToString();
            }



        }
        void npower36all()
        {
            double finalvalue = 0;

            double sc = Convert.ToDouble(txtnpra36scall.Text);
            double dayc = Convert.ToDouble(txtnpra36dayall.ToolTip);
            double nightprice = Convert.ToDouble(txtnpra36nightall.ToolTip);
            double weekend = Convert.ToDouble(txtnpra36ewall.ToolTip);
            //double unitc = Convert.ToDouble(txtnpra36unitall.ToolTip);
            double otherc = Convert.ToDouble(txtnpra36otherall.ToolTip);

            double upliftc = Convert.ToDouble(txtnpra36upliftall.Text);

            double eac = Convert.ToDouble(lblEac.Text);

            if (txtnpra36dayall.Text != "0")
            {
                dayc = dayc + upliftc;
                txtnpra36dayall.Text = dayc.ToString();
            }

            //if (txtnpra36unitall.Text != "0")
            //{
            //    unitc = unitc + upliftc;
            //    txtnpra36unitall.Text = unitc.ToString();
            //}

            if (txtnpra36nightall.Text != "0")
            {
                nightprice = nightprice + upliftc;
                txtnpra36nightall.Text = nightprice.ToString();
            }

            if (txtnpra36ewall.Text != "0")
            {
                weekend = weekend + upliftc;
                txtnpra36ewall.Text = weekend.ToString();
            }

            if (txtnpra36otherall.Text != "0")
            {
                weekend = weekend + upliftc;
                txtnpra36otherall.Text = weekend.ToString();
            }






            if (lblNpwer.Text == "EBF_STD")
            {
                finalvalue = lib.NpowerEBF_STD(sc, dayc, eac);
                txtnpra36rateall.Text = finalvalue.ToString();
            }

            if (lblNpwer.Text == "EBF_E07")
            {
                finalvalue = lib.NpowerEBF_E07(sc, dayc, nightprice, eac);
                txtnpra36rateall.Text = finalvalue.ToString();
            }

            if (lblNpwer.Text == "EBF_H07")
            {
                finalvalue = lib.NpowerEBF_H07(sc, otherc, eac);
                txtnpra36rateall.Text = finalvalue.ToString();
            }

            if (lblNpwer.Text == "EBF_H07")
            {
                finalvalue = lib.NpowerEBF_E_W(sc, weekend, otherc, eac);
                txtnpra36rateall.Text = finalvalue.ToString();
            }



        }

        #endregion

        #region TGP Uplift calculation

        void tgp12()
        {

         //   double finalvalue = 0;
            double sc = Convert.ToDouble(txttgp12sc.Text);
            double dayc = Convert.ToDouble(txttgp12day.ToolTip);
            double nightprice = Convert.ToDouble(txttgp12night.ToolTip);
            double weekend = Convert.ToDouble(txttgp12ew.ToolTip);
            //double unitc = Convert.ToDouble(txttgp12unit.ToolTip);
            double otherc = Convert.ToDouble(txttgp12other.ToolTip);

            double upliftc = Convert.ToDouble(txttgp12uplift.Text);

            double eac = Convert.ToDouble(lblEac.Text);
            //if ( txttgp12night.Text == "0" && txttgp12ew.Text == "0" && txttgp12day.Text != "0")
            //{
            //    finalvalue = lib.TgtDay(sc, dayc, eac);
            //    txttgp12rate.Text = finalvalue.ToString();
            //}

            //if (  txttgp12day.Text != "0" && txttgp12night.Text != "0" && txttgp12ew.Text == "0")
            //{
            //    finalvalue = lib.TgtDayNight(sc, dayc, nightprice, eac);
            //    txttgp12rate.Text = finalvalue.ToString();
            //}

            //if (txttgp12day.Text != "0" && txttgp12night.Text == "0" && txttgp12ew.Text != "0")
            //{
            //    finalvalue = lib.TgtDayWeekend(sc, dayc, dayc, eac);
            //    txttgp12rate.Text = finalvalue.ToString();
            //}

            //if (txttgp12day.Text != "0" && txttgp12night.Text != "0" && txttgp12ew.Text != "0")
            //{
            //    finalvalue = lib.TgtDayNightWeekend(sc, dayc, nightprice, dayc, eac);
            //    txttgp12rate.Text = finalvalue.ToString();
            //}

            txttgp12rate.Text = lib.allrates(sc, dayc, nightprice, weekend, 0, eac).ToString();

        }
        void tgp12all()
        {

            double finalvalue = 0;
            double sc = Convert.ToDouble(txttgp12scall.Text);
            double dayc = Convert.ToDouble(txttgp12dayall.ToolTip);
            double nightprice = Convert.ToDouble(txttgp12nightall.ToolTip);
            double weekend = Convert.ToDouble(txttgp12ewall.ToolTip);
            //double unitc = Convert.ToDouble(txttgp12unitall.ToolTip);
            double otherc = Convert.ToDouble(txttgp12otherall.ToolTip);

            double upliftc = Convert.ToDouble(txttgp12upliftall.Text);

            double eac = Convert.ToDouble(lblEac.Text);
            //if (  txttgp12nightall.Text == "0" && txttgp12ewall.Text == "0" && txttgp12dayall.Text == "0")
            //{
            //    finalvalue = lib.TgtDay(sc, dayc, eac);
            //    txttgp12rateall.Text = finalvalue.ToString();
            //}

            //if (txttgp12dayall.Text == "0" && txttgp12nightall.Text == "0" && txttgp12ewall.Text == "0")
            //{
            //    finalvalue = lib.TgtDayNight(sc, dayc, nightprice, eac);
            //    txttgp12rateall.Text = finalvalue.ToString();
            //}

            //if (txttgp12dayall.Text != "0" && txttgp12nightall.Text == "0" && txttgp12ewall.Text != "0")
            //{
            //    finalvalue = lib.TgtDayWeekend(sc, dayc, dayc, eac);
            //    txttgp12rateall.Text = finalvalue.ToString();
            //}

            //if (txttgp12dayall.Text != "0" && txttgp12nightall.Text != "0" && txttgp12ewall.Text != "0")
            //{
            //    finalvalue = lib.TgtDayNightWeekend(sc, dayc, nightprice, dayc, eac);
            //    txttgp12rateall.Text = finalvalue.ToString();
            //}

            txttgp12rateall.Text = lib.allrates(sc, dayc, nightprice, weekend, 0, eac).ToString();

        }

        void tgp24()
        {

            double finalvalue = 0;
            double sc = Convert.ToDouble(txttgp24sc.Text);
            double dayc = Convert.ToDouble(txttgp24day.ToolTip);
            double nightprice = Convert.ToDouble(txttgp24night.ToolTip);
            double weekend = Convert.ToDouble(txttgp24ew.ToolTip);
            //double unitc = Convert.ToDouble(txttgp24unit.ToolTip);
            double otherc = Convert.ToDouble(txttgp24other.ToolTip);

            double upliftc = Convert.ToDouble(txttgp24uplift.Text);

            double eac = Convert.ToDouble(lblEac.Text);
            if ( txttgp24night.Text == "0" && txttgp24ew.Text == "0" && txttgp24day.Text == "0")
            {
                finalvalue = lib.TgtDay(sc, dayc, eac);
                txttgp24rate.Text = finalvalue.ToString();
            }

            if ( txttgp24day.Text == "0" && txttgp24night.Text == "0" && txttgp24ew.Text == "0")
            {
                finalvalue = lib.TgtDayNight(sc, dayc, nightprice, eac);
                txttgp24rate.Text = finalvalue.ToString();
            }

            if (txttgp24day.Text != "0" && txttgp24night.Text == "0" && txttgp24ew.Text != "0")
            {
                finalvalue = lib.TgtDayWeekend(sc, dayc, dayc, eac);
                txttgp24rate.Text = finalvalue.ToString();
            }

            if (txttgp24day.Text != "0" && txttgp24night.Text != "0" && txttgp24ew.Text != "0")
            {
                finalvalue = lib.TgtDayNightWeekend(sc, dayc, nightprice, dayc, eac);
                txttgp24rate.Text = finalvalue.ToString();
            }

            txttgp24rate.Text = lib.allrates(sc, dayc, nightprice, weekend, 0, eac).ToString();

        }
        void tgp24all()
        {

            double finalvalue = 0;
            double sc = Convert.ToDouble(txttgp24scall.Text);
            double dayc = Convert.ToDouble(txttgp24dayall.ToolTip);
            double nightprice = Convert.ToDouble(txttgp24nightall.ToolTip);
           double weekend = Convert.ToDouble(txttgp24ewall.ToolTip);
            //double unitc = Convert.ToDouble(txttgp24unitall.ToolTip);
            double otherc = Convert.ToDouble(txttgp24otherall.ToolTip);

            double upliftc = Convert.ToDouble(txttgp24upliftall.Text);

            double eac = Convert.ToDouble(lblEac.Text);
            //if ( txttgp24nightall.Text == "0" && txttgp24ewall.Text == "0" && txttgp24dayall.Text == "0")
            //{
            //    finalvalue = lib.TgtDay(sc, dayc, eac);
            //    txttgp24rateall.Text = finalvalue.ToString();
            //}

            //if (txttgp24dayall.Text == "0" && txttgp24nightall.Text == "0" && txttgp24ewall.Text == "0")
            //{
            //    finalvalue = lib.TgtDayNight(sc, dayc, nightprice, eac);
            //    txttgp24rateall.Text = finalvalue.ToString();
            //}

            //if (txttgp24dayall.Text != "0" && txttgp24nightall.Text == "0" && txttgp24ewall.Text != "0")
            //{
            //    finalvalue = lib.TgtDayWeekend(sc, dayc, dayc, eac);
            //    txttgp24rateall.Text = finalvalue.ToString();
            //}

            //if (txttgp24dayall.Text != "0" && txttgp24nightall.Text != "0" && txttgp24ewall.Text != "0")
            //{
            //    finalvalue = lib.TgtDayNightWeekend(sc, dayc, nightprice, dayc, eac);
            //    txttgp24rateall.Text = finalvalue.ToString();
            //}

            txttgp24rateall.Text = lib.allrates(sc, dayc, nightprice, weekend, 0, eac).ToString();

        }
        void tgp36()
        {

            double finalvalue = 0;
            double sc = Convert.ToDouble(txttgp36sc.Text);
            double dayc = Convert.ToDouble(txttgp36day.ToolTip);
            double nightprice = Convert.ToDouble(txttgp36night.ToolTip);
            double weekend = Convert.ToDouble(txttgp36ew.ToolTip);
          //  double unitc = Convert.ToDouble(txttgp36unit.ToolTip);
            double otherc = Convert.ToDouble(txttgp36other.ToolTip);

            double upliftc = Convert.ToDouble(txttgp36uplift.Text);

            double eac = Convert.ToDouble(lblEac.Text);
            //if ( txttgp36night.Text == "0" && txttgp36ew.Text == "0" && txttgp36day.Text == "0")
            //{
            //    finalvalue = lib.TgtDay(sc, dayc, eac);
            //    txttgp36rate.Text = finalvalue.ToString();
            //}

            //if ( txttgp36day.Text == "0" && txttgp36night.Text == "0" && txttgp36ew.Text == "0")
            //{
            //    finalvalue = lib.TgtDayNight(sc, dayc, nightprice, eac);
            //    txttgp36rate.Text = finalvalue.ToString();
            //}

            //if (txttgp36day.Text != "0" && txttgp36night.Text == "0" && txttgp36ew.Text != "0")
            //{
            //    finalvalue = lib.TgtDayWeekend(sc, dayc, weekend, eac);
            //    txttgp36rate.Text = finalvalue.ToString();
            //}

            //if (txttgp36day.Text != "0" && txttgp36night.Text != "0" && txttgp36ew.Text != "0")
            //{
            //    finalvalue = lib.TgtDayNightWeekend(sc, dayc, nightprice, weekend, eac);
            //    txttgp36rate.Text = finalvalue.ToString();
            //}

            txttgp36rate.Text = lib.allrates(sc, dayc, nightprice, weekend, 0, eac).ToString();

        }
        void tgp36all()
        {

            double finalvalue = 0;
            double sc = Convert.ToDouble(txttgp36scall.Text);
            double dayc = Convert.ToDouble(txttgp36dayall.ToolTip);
            double nightprice = Convert.ToDouble(txttgp36nightall.ToolTip);
            double weekend = Convert.ToDouble(txttgp36ewall.ToolTip);
         //   double unitc = Convert.ToDouble(txttgp36unitall.ToolTip);
            double otherc = Convert.ToDouble(txttgp36otherall.ToolTip);

            double upliftc = Convert.ToDouble(txttgp36upliftall.Text);

            double eac = Convert.ToDouble(lblEac.Text);
            //if ( txttgp36nightall.Text == "0" && txttgp36ewall.Text == "0" && txttgp36dayall.Text == "0")
            //{
            //    finalvalue = lib.TgtDay(sc, dayc, eac);
            //    txttgp36rateall.Text = finalvalue.ToString();
            //}

            //if ( txttgp36dayall.Text == "0" && txttgp36nightall.Text == "0" && txttgp36ewall.Text == "0")
            //{
            //    finalvalue = lib.TgtDayNight(sc, dayc, nightprice, eac);
            //    txttgp36rateall.Text = finalvalue.ToString();
            //}

            //if (txttgp36dayall.Text != "0" && txttgp36nightall.Text == "0" && txttgp36ewall.Text != "0")
            //{
            //    finalvalue = lib.TgtDayWeekend(sc, dayc, weekend, eac);
            //    txttgp36rateall.Text = finalvalue.ToString();
            //}

            //if (txttgp36dayall.Text != "0" && txttgp36nightall.Text != "0" && txttgp36ewall.Text != "0")
            //{
            //    finalvalue = lib.TgtDayNightWeekend(sc, dayc, nightprice, weekend, eac);
            //    txttgp36rateall.Text = finalvalue.ToString();
            //}

            txttgp36rateall.Text = lib.allrates(sc, dayc, nightprice, weekend, 0, eac).ToString();

        }
        void tgp48()
        {

            double finalvalue = 0;
            double sc = Convert.ToDouble(txttgp48sc.Text);
            double dayc = Convert.ToDouble(txttgp48day.ToolTip);
            double nightprice = Convert.ToDouble(txttgp48night.ToolTip);
            double weekend = Convert.ToDouble(txttgp48ew.ToolTip);
         //   double unitc = Convert.ToDouble(txttgp48unit.ToolTip);
            double otherc = Convert.ToDouble(txttgp48other.ToolTip);

            double upliftc = Convert.ToDouble(txttgp48uplift.Text);

            double eac = Convert.ToDouble(lblEac.Text);
            //if ( txttgp48night.Text == "0" && txttgp48ew.Text == "0" && txttgp48day.Text == "0")
            //{
            //    finalvalue = lib.TgtDay(sc, dayc, eac);
            //    txttgp48rate.Text = finalvalue.ToString();
            //}

            //if ( txttgp48day.Text == "0" && txttgp48night.Text == "0" && txttgp48ew.Text == "0")
            //{
            //    finalvalue = lib.TgtDayNight(sc, dayc, nightprice, eac);
            //    txttgp48rate.Text = finalvalue.ToString();
            //}

            //if (txttgp48day.Text != "0" && txttgp48night.Text == "0" && txttgp48ew.Text != "0")
            //{
            //    finalvalue = lib.TgtDayWeekend(sc, dayc, weekend, eac);
            //    txttgp48rate.Text = finalvalue.ToString();
            //}

            //if (txttgp48day.Text != "0" && txttgp48night.Text != "0" && txttgp48ew.Text != "0")
            //{
            //    finalvalue = lib.TgtDayNightWeekend(sc, dayc, nightprice, weekend, eac);
            //    txttgp48rate.Text = finalvalue.ToString();
            //}

            txttgp48rate.Text = lib.allrates(sc, dayc, nightprice, weekend, 0, eac).ToString();

        }
        void tgp48all()
        {

            double finalvalue = 0;
            double sc = Convert.ToDouble(txttgp48scall.Text);
            double dayc = Convert.ToDouble(txttgp48dayall.ToolTip);
            double nightprice = Convert.ToDouble(txttgp48nightall.ToolTip);
            double weekend = Convert.ToDouble(txttgp48ewall.ToolTip);
        //    double unitc = Convert.ToDouble(txttgp48unitall.ToolTip);
            double otherc = Convert.ToDouble(txttgp48otherall.ToolTip);

            double upliftc = Convert.ToDouble(txttgp48upliftall.Text);

            double eac = Convert.ToDouble(lblEac.Text);
            if ( txttgp48nightall.Text == "0" && txttgp48ewall.Text == "0" && txttgp48dayall.Text == "0")
            {
                finalvalue = lib.TgtDay(sc, dayc, eac);
                txttgp48rateall.Text = finalvalue.ToString();
            }

            if (txttgp48dayall.Text == "0" && txttgp48nightall.Text == "0" && txttgp48ewall.Text == "0")
            {
                finalvalue = lib.TgtDayNight(sc, dayc, nightprice, eac);
                txttgp48rateall.Text = finalvalue.ToString();
            }

            if (txttgp48dayall.Text != "0" && txttgp48nightall.Text == "0" && txttgp48ewall.Text != "0")
            {
                finalvalue = lib.TgtDayWeekend(sc, dayc, weekend, eac);
                txttgp48rateall.Text = finalvalue.ToString();
            }

            if (txttgp48dayall.Text != "0" && txttgp48nightall.Text != "0" && txttgp48ewall.Text != "0")
            {
                finalvalue = lib.TgtDayNightWeekend(sc, dayc, nightprice, weekend, eac);
                txttgp48rateall.Text = finalvalue.ToString();
            }

            txttgp48rateall.Text = lib.allrates(sc, dayc, nightprice, weekend, 0, eac).ToString();

        }
        void tgp60()
        {

            double finalvalue = 0;
            double sc = Convert.ToDouble(txttgp60sc.Text);
            double dayc = Convert.ToDouble(txttgp60day.ToolTip);
            double nightprice = Convert.ToDouble(txttgp60night.ToolTip);
            double weekend = Convert.ToDouble(txttgp60ew.ToolTip);
          //  double unitc = Convert.ToDouble(txttgp60unit.ToolTip);
            double otherc = Convert.ToDouble(txttgp60other.ToolTip);

            double upliftc = Convert.ToDouble(txttgp60uplift.Text);

            double eac = Convert.ToDouble(lblEac.Text);
            //if ( txttgp60night.Text == "0" && txttgp60ew.Text == "0" && txttgp60day.Text == "0")
            //{
            //    finalvalue = lib.TgtDay(sc, dayc, eac);
            //    txttgp60rate.Text = finalvalue.ToString();
            //}

            //if ( txttgp60day.Text == "0" && txttgp60night.Text == "0" && txttgp60ew.Text == "0")
            //{
            //    finalvalue = lib.TgtDayNight(sc, dayc, nightprice, eac);
            //    txttgp60rate.Text = finalvalue.ToString();
            //}

            //if (txttgp60day.Text != "0" && txttgp60night.Text == "0" && txttgp60ew.Text != "0")
            //{
            //    finalvalue = lib.TgtDayWeekend(sc, dayc, weekend, eac);
            //    txttgp60rate.Text = finalvalue.ToString();
            //}

            //if (txttgp60day.Text != "0" && txttgp60night.Text != "0" && txttgp60ew.Text != "0")
            //{
            //    finalvalue = lib.TgtDayNightWeekend(sc, dayc, nightprice, weekend, eac);
            //    txttgp60rate.Text = finalvalue.ToString();
            //}

            txttgp60rate.Text = lib.allrates(sc, dayc, nightprice, weekend, 0, eac).ToString();

        }
        void tgp60all()
        {

            double finalvalue = 0;
            double sc = Convert.ToDouble(txttgp60scall.Text);
            double dayc = Convert.ToDouble(txttgp60dayall.ToolTip);
            double nightprice = Convert.ToDouble(txttgp60nightall.ToolTip);
            double weekend = Convert.ToDouble(txttgp60ewall.ToolTip);
     //       double unitc = Convert.ToDouble(txttgp60unitall.ToolTip);
            double otherc = Convert.ToDouble(txttgp60otherall.ToolTip);

            double upliftc = Convert.ToDouble(txttgp60upliftall.Text);

            double eac = Convert.ToDouble(lblEac.Text);
            //if (txttgp60nightall.Text == "0" && txttgp60ewall.Text == "0" && txttgp60dayall.Text == "0")
            //{
            //    finalvalue = lib.TgtDay(sc, dayc, eac);
            //    txttgp60rateall.Text = finalvalue.ToString();
            //}

            //if (  txttgp48dayall.Text == "0" && txttgp48nightall.Text == "0" && txttgp48ewall.Text == "0")
            //{
            //    finalvalue = lib.TgtDayNight(sc, dayc, nightprice, eac);
            //    txttgp48rateall.Text = finalvalue.ToString();
            //}

            //if (txttgp48dayall.Text != "0" && txttgp48nightall.Text == "0" && txttgp48ewall.Text != "0")
            //{
            //    finalvalue = lib.TgtDayWeekend(sc, dayc, weekend, eac);
            //    txttgp48rateall.Text = finalvalue.ToString();
            //}

            //if (txttgp48dayall.Text != "0" && txttgp48nightall.Text != "0" && txttgp48ewall.Text != "0")
            //{
            //    finalvalue = lib.TgtDayNightWeekend(sc, dayc, nightprice, weekend, eac);
            //    txttgp48rateall.Text = finalvalue.ToString();
            //}

            txttgp48rateall.Text = lib.allrates(sc, dayc, nightprice, weekend, 0, eac).ToString();

        }

        #endregion

        #region SSE Uplift calculation

        public void SSE12()
        {

           
            double sc = Convert.ToDouble(txtsse12scamr.Text);
            double dayc = Convert.ToDouble(txtsse12day.ToolTip);
            double nightprice = Convert.ToDouble(txtsse12night.ToolTip);
            double weekend = Convert.ToDouble(txtsse12ew.ToolTip);
             double offpick = Convert.ToDouble(txtsse12offpeak.ToolTip);
            double otherc = Convert.ToDouble(txtsse12other.ToolTip);

            double upliftc = Convert.ToDouble(txtsse12uplift.Text);

            double eac = Convert.ToDouble(lblEac.Text);



            if (txtsse12day.Text != "0")
            {
                dayc = dayc + upliftc;
                txtsse12day.Text = dayc.ToString();
            }

            if (txtsse12night.Text != "0")
            {
                nightprice = nightprice + upliftc;
                txtsse12night.Text = nightprice.ToString();
            }

            if (txtsse12ew.Text != "0")
            {
                weekend = weekend + upliftc;
                txtsse12ew.Text = weekend.ToString();

            }

            if (txtsse12offpeak.Text != "0")
            {
                offpick = offpick + upliftc;
                txtsse12offpeak.Text = weekend.ToString();

            }


            if (lblSSEPEMetertype.Text == "Q1")
            {
                txtsse12rate.Text = lib.SseQ1(sc, dayc, eac,otherc).ToString();

            }

            if (lblSSEPEMetertype.Text == "Q2")
            {
                txtsse12rate.Text = lib.SseQ2(sc, dayc, nightprice, eac, otherc).ToString();

            }
            if (lblSSEPEMetertype.Text == "Q3")
            {
                txtsse12rate.Text = lib.SseQ3(sc, dayc, weekend, eac, otherc).ToString();

            }

            if (lblSSEPEMetertype.Text == "Q4")
            {
                txtsse12rate.Text = lib.SseQ4(sc, dayc, nightprice, weekend, eac, otherc).ToString();

            }
            if (lblSSEPEMetertype.Text == "Quarterly Commercial Off Peak")
            {
                txtsse12rate.Text = lib.SseOffpick(sc, offpick, eac, otherc).ToString();

            }





        }


        public void SSE12all()
        {


            double sc = Convert.ToDouble(txtsse12scamrall.Text);
            double dayc = Convert.ToDouble(txtsse12dayall.ToolTip);
            double nightprice = Convert.ToDouble(txtsse12nightall.ToolTip);
            double weekend = Convert.ToDouble(txtsse12ewall.ToolTip);
            double offpick = Convert.ToDouble(txtsse12offpeakall.ToolTip);
            double otherc = Convert.ToDouble(txtsse12otherall.ToolTip);

            double upliftc = Convert.ToDouble(txtsse12upliftall.Text);

            double eac = Convert.ToDouble(lblEac.Text);



            if (txtsse12dayall.Text != "0")
            {
                dayc = dayc + upliftc;
                txtsse12dayall.Text = dayc.ToString();
            }

            if (txtsse12night.Text != "0")
            {
                nightprice = nightprice + upliftc;
                txtsse12nightall.Text = nightprice.ToString();
            }

            if (txtsse12ew.Text != "0")
            {
                weekend = weekend + upliftc;
                txtsse12ewall.Text = weekend.ToString();

            }

            if (txtsse12offpeak.Text != "0")
            {
                offpick = offpick + upliftc;
                txtsse12offpeakall.Text = weekend.ToString();

            }


            if (lblSSEPEMetertype.Text == "Q1")
            {
                txtsse12rateall.Text = lib.SseQ1(sc, dayc, eac, otherc).ToString();

            }

            if (lblSSEPEMetertype.Text == "Q2")
            {
                txtsse12rateall.Text = lib.SseQ2(sc, dayc, nightprice, eac, otherc).ToString();

            }
            if (lblSSEPEMetertype.Text == "Q3")
            {
                txtsse12rateall.Text = lib.SseQ3(sc, dayc, weekend, eac, otherc).ToString();

            }

            if (lblSSEPEMetertype.Text == "Q4")
            {
                txtsse12rateall.Text = lib.SseQ4(sc, dayc, nightprice, weekend, eac, otherc).ToString();

            }
            if (lblSSEPEMetertype.Text == "Quarterly Commercial Off Peak")
            {
                txtsse12rateall.Text = lib.SseOffpick(sc, offpick, eac, otherc).ToString();

            }





        }

        public void SSE12NONAMR()
        {


            double sc = Convert.ToDouble(txtsse12scnonamr.Text);
            double dayc = Convert.ToDouble(txtsse12day.ToolTip);
            double nightprice = Convert.ToDouble(txtsse12night.ToolTip);
            double weekend = Convert.ToDouble(txtsse12ew.ToolTip);
            double offpick = Convert.ToDouble(txtsse12offpeak.ToolTip);
            double otherc = Convert.ToDouble(txtsse12other.ToolTip);

            double upliftc = Convert.ToDouble(txtsse12upliftnonamr.Text);

            double eac = Convert.ToDouble(lblEac.Text);



            if (txtsse12day.Text != "0")
            {
                dayc = dayc + upliftc;
                txtsse12day.Text = dayc.ToString();
            }

            if (txtsse12night.Text != "0")
            {
                nightprice = nightprice + upliftc;
                txtsse12night.Text = nightprice.ToString();
            }

            if (txtsse12ew.Text != "0")
            {
                weekend = weekend + upliftc;
                txtsse12ew.Text = weekend.ToString();

            }

            if (txtsse12offpeak.Text != "0")
            {
                offpick = offpick + upliftc;
                txtsse12offpeak.Text = weekend.ToString();

            }


            if (lblSSEPEMetertype.Text == "Q1")
            {
                txtsse12ratenonamr.Text = lib.SseQ1(sc, dayc, eac, otherc).ToString();

            }

            if (lblSSEPEMetertype.Text == "Q2")
            {
                txtsse12ratenonamr.Text = lib.SseQ2(sc, dayc, nightprice, eac, otherc).ToString();

            }
            if (lblSSEPEMetertype.Text == "Q3")
            {
                txtsse12ratenonamr.Text = lib.SseQ3(sc, dayc, weekend, eac, otherc).ToString();

            }

            if (lblSSEPEMetertype.Text == "Q4")
            {
                txtsse12ratenonamr.Text = lib.SseQ4(sc, dayc, nightprice, weekend, eac, otherc).ToString();

            }
            if (lblSSEPEMetertype.Text == "Quarterly Commercial Off Peak")
            {
                txtsse12ratenonamr.Text = lib.SseOffpick(sc, offpick, eac, otherc).ToString();

            }





        }

        public void SSE12NONAMRAll()
        {


            double sc = Convert.ToDouble(txtsse12scnonamrall.Text);
            double dayc = Convert.ToDouble(txtsse12dayall.ToolTip);
            double nightprice = Convert.ToDouble(txtsse12nightall.ToolTip);
            double weekend = Convert.ToDouble(txtsse12ewall.ToolTip);
            double offpick = Convert.ToDouble(txtsse12offpeakall.ToolTip);
            double otherc = Convert.ToDouble(txtsse12otherall.ToolTip);

            double upliftc = Convert.ToDouble(txtsse12upliftnonamrall.Text);

            double eac = Convert.ToDouble(lblEac.Text);



            if (txtsse12dayall.Text != "0")
            {
                dayc = dayc + upliftc;
                txtsse12dayall.Text = dayc.ToString();
            }

            if (txtsse12nightall.Text != "0")
            {
                nightprice = nightprice + upliftc;
                txtsse12nightall.Text = nightprice.ToString();
            }

            if (txtsse12ewall.Text != "0")
            {
                weekend = weekend + upliftc;
                txtsse12ewall.Text = weekend.ToString();

            }

            if (txtsse12offpeak.Text != "0")
            {
                offpick = offpick + upliftc;
                txtsse12offpeakall.Text = weekend.ToString();

            }


            if (lblSSEPEMetertype.Text == "Q1")
            {
                txtsse12ratenonamrall.Text = lib.SseQ1(sc, dayc, eac, otherc).ToString();

            }

            if (lblSSEPEMetertype.Text == "Q2")
            {
                txtsse12ratenonamrall.Text = lib.SseQ2(sc, dayc, nightprice, eac, otherc).ToString();

            }
            if (lblSSEPEMetertype.Text == "Q3")
            {
                txtsse12ratenonamrall.Text = lib.SseQ3(sc, dayc, weekend, eac, otherc).ToString();

            }

            if (lblSSEPEMetertype.Text == "Q4")
            {
                txtsse12ratenonamrall.Text = lib.SseQ4(sc, dayc, nightprice, weekend, eac, otherc).ToString();

            }
            if (lblSSEPEMetertype.Text == "Quarterly Commercial Off Peak")
            {
                txtsse12ratenonamrall.Text = lib.SseOffpick(sc, offpick, eac, otherc).ToString();

            }





        }


        // 24 Months

        public void SSE24()
        {


            double sc = Convert.ToDouble(txtsse24scamr.Text);
            double dayc = Convert.ToDouble(txtsse24day.ToolTip);
            double nightprice = Convert.ToDouble(txtsse24night.ToolTip);
            double weekend = Convert.ToDouble(txtsse24ew.ToolTip);
            double offpick = Convert.ToDouble(txtsse24offpeak.ToolTip);
            double otherc = Convert.ToDouble(txtsse24other.ToolTip);

            double upliftc = Convert.ToDouble(txtsse24uplift.Text);

            double eac = Convert.ToDouble(lblEac.Text);



            if (txtsse24day.Text != "0")
            {
                dayc = dayc + upliftc;
                txtsse24day.Text = dayc.ToString();
            }

            if (txtsse24night.Text != "0")
            {
                nightprice = nightprice + upliftc;
                txtsse24night.Text = nightprice.ToString();
            }

            if (txtsse24ew.Text != "0")
            {
                weekend = weekend + upliftc;
                txtsse24ew.Text = weekend.ToString();

            }

            if (txtsse24offpeak.Text != "0")
            {
                offpick = offpick + upliftc;
                txtsse24offpeak.Text = weekend.ToString();

            }


            if (lblSSEPEMetertype.Text == "Q1")
            {
                txtsse24rate.Text = lib.SseQ1(sc, dayc, eac, otherc).ToString();

            }

            if (lblSSEPEMetertype.Text == "Q2")
            {
                txtsse24rate.Text = lib.SseQ2(sc, dayc, nightprice, eac, otherc).ToString();

            }
            if (lblSSEPEMetertype.Text == "Q3")
            {
                txtsse24rate.Text = lib.SseQ3(sc, dayc, weekend, eac, otherc).ToString();

            }

            if (lblSSEPEMetertype.Text == "Q4")
            {
                txtsse24rate.Text = lib.SseQ4(sc, dayc, nightprice, weekend, eac, otherc).ToString();

            }
            if (lblSSEPEMetertype.Text == "Quarterly Commercial Off Peak")
            {
                txtsse24rate.Text = lib.SseOffpick(sc, offpick, eac, otherc).ToString();

            }





        }

        public void SSE24all()
        {


            double sc = Convert.ToDouble(txtsse24scamrall.Text);
            double dayc = Convert.ToDouble(txtsse24dayall.ToolTip);
            double nightprice = Convert.ToDouble(txtsse24nightall.ToolTip);
            double weekend = Convert.ToDouble(txtsse24ewall.ToolTip);
            double offpick = Convert.ToDouble(txtsse24offpeakall.ToolTip);
            double otherc = Convert.ToDouble(txtsse24otherall.ToolTip);

            double upliftc = Convert.ToDouble(txtsse24upliftall.Text);

            double eac = Convert.ToDouble(lblEac.Text);



            if (txtsse24dayall.Text != "0")
            {
                dayc = dayc + upliftc;
                txtsse24dayall.Text = dayc.ToString();
            }

            if (txtsse24nightall.Text != "0")
            {
                nightprice = nightprice + upliftc;
                txtsse24nightall.Text = nightprice.ToString();
            }

            if (txtsse24ewall.Text != "0")
            {
                weekend = weekend + upliftc;
                txtsse24ewall.Text = weekend.ToString();

            }

            if (txtsse24offpeakall.Text != "0")
            {
                offpick = offpick + upliftc;
                txtsse24offpeakall.Text = weekend.ToString();

            }


            if (lblSSEPEMetertype.Text == "Q1")
            {
                txtsse24rateall.Text = lib.SseQ1(sc, dayc, eac, otherc).ToString();

            }

            if (lblSSEPEMetertype.Text == "Q2")
            {
                txtsse24rateall.Text = lib.SseQ2(sc, dayc, nightprice, eac, otherc).ToString();

            }
            if (lblSSEPEMetertype.Text == "Q3")
            {
                txtsse24rateall.Text = lib.SseQ3(sc, dayc, weekend, eac, otherc).ToString();

            }

            if (lblSSEPEMetertype.Text == "Q4")
            {
                txtsse24rateall.Text = lib.SseQ4(sc, dayc, nightprice, weekend, eac, otherc).ToString();

            }
            if (lblSSEPEMetertype.Text == "Quarterly Commercial Off Peak")
            {
                txtsse24rateall.Text = lib.SseOffpick(sc, offpick, eac, otherc).ToString();

            }





        }

      

        public void SSE24NONAMR()
        {


            double sc = Convert.ToDouble(txtsse24scnonamr.Text);
            double dayc = Convert.ToDouble(txtsse24day.ToolTip);
            double nightprice = Convert.ToDouble(txtsse24night.ToolTip);
            double weekend = Convert.ToDouble(txtsse24ew.ToolTip);
            double offpick = Convert.ToDouble(txtsse24offpeak.ToolTip);
            double otherc = Convert.ToDouble(txtsse24other.ToolTip);

            double upliftc = Convert.ToDouble(txtsse24upliftnonamr.Text);

            double eac = Convert.ToDouble(lblEac.Text);



            if (txtsse24day.Text != "0")
            {
                dayc = dayc + upliftc;
                txtsse24day.Text = dayc.ToString();
            }

            if (txtsse24night.Text != "0")
            {
                nightprice = nightprice + upliftc;
                txtsse24night.Text = nightprice.ToString();
            }

            if (txtsse24ew.Text != "0")
            {
                weekend = weekend + upliftc;
                txtsse24ew.Text = weekend.ToString();

            }

            if (txtsse24offpeak.Text != "0")
            {
                offpick = offpick + upliftc;
                txtsse24offpeak.Text = weekend.ToString();

            }


            if (lblSSEPEMetertype.Text == "Q1")
            {
                txtsse24ratenonamr.Text = lib.SseQ1(sc, dayc, eac, otherc).ToString();

            }

            if (lblSSEPEMetertype.Text == "Q2")
            {
                txtsse24ratenonamr.Text = lib.SseQ2(sc, dayc, nightprice, eac, otherc).ToString();

            }
            if (lblSSEPEMetertype.Text == "Q3")
            {
                txtsse24ratenonamr.Text = lib.SseQ3(sc, dayc, weekend, eac, otherc).ToString();

            }

            if (lblSSEPEMetertype.Text == "Q4")
            {
                txtsse24ratenonamr.Text = lib.SseQ4(sc, dayc, nightprice, weekend, eac, otherc).ToString();

            }
            if (lblSSEPEMetertype.Text == "Quarterly Commercial Off Peak")
            {
                txtsse24ratenonamr.Text = lib.SseOffpick(sc, offpick, eac, otherc).ToString();

            }





        }

        public void SSE24NONAMRAll()
        {


            double sc = Convert.ToDouble(txtsse24scnonamrall.Text);
            double dayc = Convert.ToDouble(txtsse24dayall.ToolTip);
            double nightprice = Convert.ToDouble(txtsse24nightall.ToolTip);
            double weekend = Convert.ToDouble(txtsse24ewall.ToolTip);
            double offpick = Convert.ToDouble(txtsse24offpeakall.ToolTip);
            double otherc = Convert.ToDouble(txtsse24otherall.ToolTip);

            double upliftc = Convert.ToDouble(txtsse24upliftnonamrall.Text);

            double eac = Convert.ToDouble(lblEac.Text);



            if (txtsse24dayall.Text != "0")
            {
                dayc = dayc + upliftc;
                txtsse24dayall.Text = dayc.ToString();
            }

            if (txtsse24nightall.Text != "0")
            {
                nightprice = nightprice + upliftc;
                txtsse24nightall.Text = nightprice.ToString();
            }

            if (txtsse24ewall.Text != "0")
            {
                weekend = weekend + upliftc;
                txtsse24ewall.Text = weekend.ToString();

            }

            if (txtsse24offpeak.Text != "0")
            {
                offpick = offpick + upliftc;
                txtsse24offpeakall.Text = weekend.ToString();

            }


            if (lblSSEPEMetertype.Text == "Q1")
            {
                txtsse24ratenonamrall.Text = lib.SseQ1(sc, dayc, eac, otherc).ToString();

            }

            if (lblSSEPEMetertype.Text == "Q2")
            {
                txtsse24ratenonamrall.Text = lib.SseQ2(sc, dayc, nightprice, eac, otherc).ToString();

            }
            if (lblSSEPEMetertype.Text == "Q3")
            {
                txtsse24ratenonamrall.Text = lib.SseQ3(sc, dayc, weekend, eac, otherc).ToString();

            }

            if (lblSSEPEMetertype.Text == "Q4")
            {
                txtsse24ratenonamrall.Text = lib.SseQ4(sc, dayc, nightprice, weekend, eac, otherc).ToString();

            }
            if (lblSSEPEMetertype.Text == "Quarterly Commercial Off Peak")
            {
                txtsse24ratenonamrall.Text = lib.SseOffpick(sc, offpick, eac, otherc).ToString();

            }





        }

        // 36 Momnths


        public void SSE36()
        {


            double sc = Convert.ToDouble(txtsse36scamr.Text);
            double dayc = Convert.ToDouble(txtsse36day.ToolTip);
            double nightprice = Convert.ToDouble(txtsse36night.ToolTip);
            double weekend = Convert.ToDouble(txtsse36ew.ToolTip);
            double offpick = Convert.ToDouble(txtsse36offpeak.ToolTip);
            double otherc = Convert.ToDouble(txtsse36other.ToolTip);

            double upliftc = Convert.ToDouble(txtsse36uplift.Text);

            double eac = Convert.ToDouble(lblEac.Text);



            if (txtsse36day.Text != "0")
            {
                dayc = dayc + upliftc;
                txtsse36day.Text = dayc.ToString();
            }

            if (txtsse36night.Text != "0")
            {
                nightprice = nightprice + upliftc;
                txtsse36night.Text = nightprice.ToString();
            }

            if (txtsse36ew.Text != "0")
            {
                weekend = weekend + upliftc;
                txtsse36ew.Text = weekend.ToString();

            }

            if (txtsse36offpeak.Text != "0")
            {
                offpick = offpick + upliftc;
                txtsse36offpeak.Text = weekend.ToString();

            }


            if (lblSSEPEMetertype.Text == "Q1")
            {
                txtsse36rate.Text = lib.SseQ1(sc, dayc, eac, otherc).ToString();

            }

            if (lblSSEPEMetertype.Text == "Q2")
            {
                txtsse36rate.Text = lib.SseQ2(sc, dayc, nightprice, eac, otherc).ToString();

            }
            if (lblSSEPEMetertype.Text == "Q3")
            {
                txtsse36rate.Text = lib.SseQ3(sc, dayc, weekend, eac, otherc).ToString();

            }

            if (lblSSEPEMetertype.Text == "Q4")
            {
                txtsse36rate.Text = lib.SseQ4(sc, dayc, nightprice, weekend, eac, otherc).ToString();

            }
            if (lblSSEPEMetertype.Text == "Quarterly Commercial Off Peak")
            {
                txtsse36rate.Text = lib.SseOffpick(sc, offpick, eac, otherc).ToString();

            }





        }

        public void SSE36all()
        {


            double sc = Convert.ToDouble(txtsse36scamrall.Text);
            double dayc = Convert.ToDouble(txtsse36dayall.ToolTip);
            double nightprice = Convert.ToDouble(txtsse36nightall.ToolTip);
            double weekend = Convert.ToDouble(txtsse36ewall.ToolTip);
            double offpick = Convert.ToDouble(txtsse36offpeakall.ToolTip);
            double otherc = Convert.ToDouble(txtsse36otherall.ToolTip);

            double upliftc = Convert.ToDouble(txtsse36upliftall.Text);

            double eac = Convert.ToDouble(lblEac.Text);



            if (txtsse36dayall.Text != "0")
            {
                dayc = dayc + upliftc;
                txtsse36dayall.Text = dayc.ToString();
            }

            if (txtsse36nightall.Text != "0")
            {
                nightprice = nightprice + upliftc;
                txtsse36nightall.Text = nightprice.ToString();
            }

            if (txtsse36ewall.Text != "0")
            {
                weekend = weekend + upliftc;
                txtsse36ewall.Text = weekend.ToString();

            }

            if (txtsse36offpeakall.Text != "0")
            {
                offpick = offpick + upliftc;
                txtsse36offpeakall.Text = weekend.ToString();

            }


            if (lblSSEPEMetertype.Text == "Q1")
            {
                txtsse36rateall.Text = lib.SseQ1(sc, dayc, eac, otherc).ToString();

            }

            if (lblSSEPEMetertype.Text == "Q2")
            {
                txtsse36rateall.Text = lib.SseQ2(sc, dayc, nightprice, eac, otherc).ToString();

            }
            if (lblSSEPEMetertype.Text == "Q3")
            {
                txtsse36rateall.Text = lib.SseQ3(sc, dayc, weekend, eac, otherc).ToString();

            }

            if (lblSSEPEMetertype.Text == "Q4")
            {
                txtsse36rateall.Text = lib.SseQ4(sc, dayc, nightprice, weekend, eac, otherc).ToString();

            }
            if (lblSSEPEMetertype.Text == "Quarterly Commercial Off Peak")
            {
                txtsse36rateall.Text = lib.SseOffpick(sc, offpick, eac, otherc).ToString();

            }





        }


        public void SSE36NONAMR()
        {


            double sc = Convert.ToDouble(txtsse36scnonamr.Text);
            double dayc = Convert.ToDouble(txtsse36day.ToolTip);
            double nightprice = Convert.ToDouble(txtsse36night.ToolTip);
            double weekend = Convert.ToDouble(txtsse36ew.ToolTip);
            double offpick = Convert.ToDouble(txtsse36offpeak.ToolTip);
            double otherc = Convert.ToDouble(txtsse36other.ToolTip);

            double upliftc = Convert.ToDouble(txtsse36upliftnonamr.Text);

            double eac = Convert.ToDouble(lblEac.Text);



            if (txtsse36day.Text != "0")
            {
                dayc = dayc + upliftc;
                txtsse36day.Text = dayc.ToString();
            }

            if (txtsse36night.Text != "0")
            {
                nightprice = nightprice + upliftc;
                txtsse36night.Text = nightprice.ToString();
            }

            if (txtsse36ew.Text != "0")
            {
                weekend = weekend + upliftc;
                txtsse36ew.Text = weekend.ToString();

            }

            if (txtsse36offpeak.Text != "0")
            {
                offpick = offpick + upliftc;
                txtsse36offpeak.Text = weekend.ToString();

            }


            if (lblSSEPEMetertype.Text == "Q1")
            {
                txtsse36ratenonamr.Text = lib.SseQ1(sc, dayc, eac, otherc).ToString();

            }

            if (lblSSEPEMetertype.Text == "Q2")
            {
                txtsse36ratenonamr.Text = lib.SseQ2(sc, dayc, nightprice, eac, otherc).ToString();

            }
            if (lblSSEPEMetertype.Text == "Q3")
            {
                txtsse36ratenonamr.Text = lib.SseQ3(sc, dayc, weekend, eac, otherc).ToString();

            }

            if (lblSSEPEMetertype.Text == "Q4")
            {
                txtsse36ratenonamr.Text = lib.SseQ4(sc, dayc, nightprice, weekend, eac, otherc).ToString();

            }
            if (lblSSEPEMetertype.Text == "Quarterly Commercial Off Peak")
            {
                txtsse36ratenonamr.Text = lib.SseOffpick(sc, offpick, eac, otherc).ToString();

            }





        }


        public void SSE36NONAMRAll()
        {


            double sc = Convert.ToDouble(txtsse36scnonamrall.Text);
            double dayc = Convert.ToDouble(txtsse36dayall.ToolTip);
            double nightprice = Convert.ToDouble(txtsse36nightall.ToolTip);
            double weekend = Convert.ToDouble(txtsse36ewall.ToolTip);
            double offpick = Convert.ToDouble(txtsse36offpeakall.ToolTip);
            double otherc = Convert.ToDouble(txtsse36otherall.ToolTip);

            double upliftc = Convert.ToDouble(txtsse36upliftnonamrall.Text);

            double eac = Convert.ToDouble(lblEac.Text);



            if (txtsse36dayall.Text != "0")
            {
                dayc = dayc + upliftc;
                txtsse36dayall.Text = dayc.ToString();
            }

            if (txtsse36nightall.Text != "0")
            {
                nightprice = nightprice + upliftc;
                txtsse36nightall.Text = nightprice.ToString();
            }

            if (txtsse36ewall.Text != "0")
            {
                weekend = weekend + upliftc;
                txtsse36ewall.Text = weekend.ToString();

            }

            if (txtsse36offpeak.Text != "0")
            {
                offpick = offpick + upliftc;
                txtsse36offpeakall.Text = weekend.ToString();

            }


            if (lblSSEPEMetertype.Text == "Q1")
            {
                txtsse36ratenonamrall.Text = lib.SseQ1(sc, dayc, eac, otherc).ToString();

            }

            if (lblSSEPEMetertype.Text == "Q2")
            {
                txtsse36ratenonamrall.Text = lib.SseQ2(sc, dayc, nightprice, eac, otherc).ToString();

            }
            if (lblSSEPEMetertype.Text == "Q3")
            {
                txtsse36ratenonamrall.Text = lib.SseQ3(sc, dayc, weekend, eac, otherc).ToString();

            }

            if (lblSSEPEMetertype.Text == "Q4")
            {
                txtsse36ratenonamrall.Text = lib.SseQ4(sc, dayc, nightprice, weekend, eac, otherc).ToString();

            }
            if (lblSSEPEMetertype.Text == "Quarterly Commercial Off Peak")
            {
                txtsse36ratenonamrall.Text = lib.SseOffpick(sc, offpick, eac, otherc).ToString();

            }





        }

        #endregion


        #region SPE Uplift calculation

        void Spe12()
        {
            
            double sc = Convert.ToDouble(txtspe12sc.Text);
            double dayc = Convert.ToDouble(txtpe12day.ToolTip);
            double nightprice = Convert.ToDouble(txtspe12night.ToolTip);
            double weekend = Convert.ToDouble(txtspe12ew.ToolTip);
         //   double offpick = Convert.ToDouble(txtspe12offpeak.ToolTip);
           // double otherc = Convert.ToDouble(txtspe12other.ToolTip);

            double upliftc = Convert.ToDouble(txtspe12uplift.Text);

            double eac = Convert.ToDouble(lblEac.Text);



            if (txtpe12day.Text != "0")
            {
                dayc = dayc + upliftc;
                txtpe12day.Text = dayc.ToString();
            }

            if (txtspe12night.Text != "0")
            {
                nightprice = nightprice + upliftc;
                txtspe12night.Text = nightprice.ToString();
            }

            if (txtspe12ew.Text != "0")
            {
                weekend = weekend + upliftc;
                txtspe12ew.Text = weekend.ToString();

            }

            //if (txtspe12offpeak.Text != "0")
            //{
            //    offpick = offpick + upliftc;
            //    txtspe12offpeak.Text = weekend.ToString();

            //}

            if(lblSPAMetertype.Text != "OffPeak")
            {
                txtspe12rate.Text = lib.allrates(sc, dayc, nightprice, weekend,0 , eac).ToString();
            }
            else
            {

            }

        }
        void Spe24()
        {

            double sc = Convert.ToDouble(txtspe24sc.Text);
            double dayc = Convert.ToDouble(txtpe24day.ToolTip);
            double nightprice = Convert.ToDouble(txtspe24night.ToolTip);
            double weekend = Convert.ToDouble(txtspe24ew.ToolTip);
            //   double offpick = Convert.ToDouble(txtspe24offpeak.ToolTip);
            // double otherc = Convert.ToDouble(txtspe24other.ToolTip);

            double upliftc = Convert.ToDouble(txtspe24uplift.Text);

            double eac = Convert.ToDouble(lblEac.Text);



            if (txtpe24day.Text != "0")
            {
                dayc = dayc + upliftc;
                txtpe24day.Text = dayc.ToString();
            }

            if (txtspe24night.Text != "0")
            {
                nightprice = nightprice + upliftc;
                txtspe24night.Text = nightprice.ToString();
            }

            if (txtspe24ew.Text != "0")
            {
                weekend = weekend + upliftc;
                txtspe24ew.Text = weekend.ToString();

            }

            //if (txtspe24offpeak.Text != "0")
            //{
            //    offpick = offpick + upliftc;
            //    txtspe24offpeak.Text = weekend.ToString();

            //}

            if (lblSPAMetertype.Text != "OffPeak")
            {
                txtspe24rate.Text = lib.allrates(sc, dayc, nightprice, weekend, 0, eac).ToString();
            }

        }
        void Spe36()
        {

            double sc = Convert.ToDouble(txtspe36sc.Text);
            double dayc = Convert.ToDouble(txtpe36day.ToolTip);
            double nightprice = Convert.ToDouble(txtspe36night.ToolTip);
            double weekend = Convert.ToDouble(txtspe36ew.ToolTip);
            //   double offpick = Convert.ToDouble(txtspe36offpeak.ToolTip);
            // double otherc = Convert.ToDouble(txtspe36other.ToolTip);

            double upliftc = Convert.ToDouble(txtspe36uplift.Text);

            double eac = Convert.ToDouble(lblEac.Text);



            if (txtpe36day.Text != "0")
            {
                dayc = dayc + upliftc;
                txtpe36day.Text = dayc.ToString();
            }

            if (txtspe36night.Text != "0")
            {
                nightprice = nightprice + upliftc;
                txtspe36night.Text = nightprice.ToString();
            }

            if (txtspe36ew.Text != "0")
            {
                weekend = weekend + upliftc;
                txtspe36ew.Text = weekend.ToString();

            }

            //if (txtspe36offpeak.Text != "0")
            //{
            //    offpick = offpick + upliftc;
            //    txtspe36offpeak.Text = weekend.ToString();

            //}

            if (lblSPAMetertype.Text != "OffPeak")
            {
                txtspe36rate.Text = lib.allrates(sc, dayc, nightprice, weekend, 0, eac).ToString();
            }

        }

        void Spe12all()
        {

            double sc = Convert.ToDouble(txtspe12scall.Text);
            double dayc = Convert.ToDouble(txtpe12dayall.ToolTip);
            double nightprice = Convert.ToDouble(txtspe12nightall.ToolTip);
            double weekend = Convert.ToDouble(txtspe12ewall.ToolTip);
            //   double offpick = Convert.ToDouble(txtspe12offpeak.ToolTip);
            // double otherc = Convert.ToDouble(txtspe12other.ToolTip);

            double upliftc = Convert.ToDouble(txtspe12upliftall.Text);

            double eac = Convert.ToDouble(lblEac.Text);



            if (txtpe12dayall.Text != "0")
            {
                dayc = dayc + upliftc;
                txtpe12dayall.Text = dayc.ToString();
            }

            if (txtspe12nightall.Text != "0")
            {
                nightprice = nightprice + upliftc;
                txtspe12nightall.Text = nightprice.ToString();
            }

            if (txtspe12ewall.Text != "0")
            {
                weekend = weekend + upliftc;
                txtspe12ewall.Text = weekend.ToString();

            }

            //if (txtspe12offpeak.Text != "0")
            //{
            //    offpick = offpick + upliftc;
            //    txtspe12offpeak.Text = weekend.ToString();

            //}

            if (lblSPAMetertype.Text != "OffPeak")
            {
                txtspe12rateall.Text = lib.allrates(sc, dayc, nightprice, weekend, 0, eac).ToString();
            }

        }

        void Spe24all()
        {

            double sc = Convert.ToDouble(txtspe24scall.Text);
            double dayc = Convert.ToDouble(txtpe24dayall.ToolTip);
            double nightprice = Convert.ToDouble(txtspe24nightall.ToolTip);
            double weekend = Convert.ToDouble(txtspe24ewall.ToolTip);
            //   double offpick = Convert.ToDouble(txtspe24offpeak.ToolTip);
            // double otherc = Convert.ToDouble(txtspe24other.ToolTip);

            double upliftc = Convert.ToDouble(txtspe24upliftall.Text);

            double eac = Convert.ToDouble(lblEac.Text);



            if (txtpe24dayall.Text != "0")
            {
                dayc = dayc + upliftc;
                txtpe24dayall.Text = dayc.ToString();
            }

            if (txtspe24nightall.Text != "0")
            {
                nightprice = nightprice + upliftc;
                txtspe24nightall.Text = nightprice.ToString();
            }

            if (txtspe24ewall.Text != "0")
            {
                weekend = weekend + upliftc;
                txtspe24ewall.Text = weekend.ToString();

            }

            //if (txtspe24offpeak.Text != "0")
            //{
            //    offpick = offpick + upliftc;
            //    txtspe24offpeak.Text = weekend.ToString();

            //}

            if (lblSPAMetertype.Text != "OffPeak")
            {
                txtspe24rateall.Text = lib.allrates(sc, dayc, nightprice, weekend, 0, eac).ToString();
            }

        }

        void Spe36all()
        {

            double sc = Convert.ToDouble(txtspe36scall.Text);
            double dayc = Convert.ToDouble(txtpe36dayall.ToolTip);
            double nightprice = Convert.ToDouble(txtspe36nightall.ToolTip);
            double weekend = Convert.ToDouble(txtspe36ewall.ToolTip);
            //   double offpick = Convert.ToDouble(txtspe36offpeak.ToolTip);
            // double otherc = Convert.ToDouble(txtspe36other.ToolTip);

            double upliftc = Convert.ToDouble(txtspe36upliftall.Text);

            double eac = Convert.ToDouble(lblEac.Text);



            if (txtpe36dayall.Text != "0")
            {
                dayc = dayc + upliftc;
                txtpe36dayall.Text = dayc.ToString();
            }

            if (txtspe36nightall.Text != "0")
            {
                nightprice = nightprice + upliftc;
                txtspe36nightall.Text = nightprice.ToString();
            }

            if (txtspe36ewall.Text != "0")
            {
                weekend = weekend + upliftc;
                txtspe36ewall.Text = weekend.ToString();

            }

            //if (txtspe36offpeak.Text != "0")
            //{
            //    offpick = offpick + upliftc;
            //    txtspe36offpeak.Text = weekend.ToString();

            //}

            if (lblSPAMetertype.Text != "OffPeak")
            {
                txtspe36rateall.Text = lib.allrates(sc, dayc, nightprice, weekend, 0, eac).ToString();
            }

        }

        #endregion

        #region OPUS uplift calculation

        void Opus12()
        {

            double sc = Convert.ToDouble(txtopus12sc.Text);
            double dayc = Convert.ToDouble(txtopus12day.ToolTip);
            double nightprice = Convert.ToDouble(txtopus12night.ToolTip);
            double weekend = Convert.ToDouble(txtopus12ew.ToolTip);
            //   double offpick = Convert.ToDouble(txtspe12offpeak.ToolTip);
            // double otherc = Convert.ToDouble(txtspe12other.ToolTip);

            double upliftc = Convert.ToDouble(txtopus12uplift.Text);

            double eac = Convert.ToDouble(lblEac.Text);



            if (txtopus12day.Text != "0")
            {
                dayc = dayc + upliftc;
                txtopus12day.Text = dayc.ToString();
            }

            if (txtopus12night.Text != "0")
            {
                nightprice = nightprice + upliftc;
                txtopus12night.Text = nightprice.ToString();
            }

            if (txtopus12ew.Text != "0")
            {
                weekend = weekend + upliftc;
                txtopus12ew.Text = weekend.ToString();

            }

            //if (txtspe12offpeak.Text != "0")
            //{
            //    offpick = offpick + upliftc;
            //    txtspe12offpeak.Text = weekend.ToString();

            //}

           
                txtopus12rate.Text = lib.allrates(sc, dayc, nightprice, weekend, 0, eac).ToString();
           

        }

        void Opus24()
        {

            double sc = Convert.ToDouble(txtopus24sc.Text);
            double dayc = Convert.ToDouble(txtopus24day.ToolTip);
            double nightprice = Convert.ToDouble(txtopus24night.ToolTip);
            double weekend = Convert.ToDouble(txtopus24ew.ToolTip);
            //   double offpick = Convert.ToDouble(txtspe24offpeak.ToolTip);
            // double otherc = Convert.ToDouble(txtspe24other.ToolTip);

            double upliftc = Convert.ToDouble(txtopus24uplift.Text);

            double eac = Convert.ToDouble(lblEac.Text);



            if (txtopus24day.Text != "0")
            {
                dayc = dayc + upliftc;
                txtopus24day.Text = dayc.ToString();
            }

            if (txtopus24night.Text != "0")
            {
                nightprice = nightprice + upliftc;
                txtopus24night.Text = nightprice.ToString();
            }

            if (txtopus24ew.Text != "0")
            {
                weekend = weekend + upliftc;
                txtopus24ew.Text = weekend.ToString();

            }

            //if (txtspe24offpeak.Text != "0")
            //{
            //    offpick = offpick + upliftc;
            //    txtspe24offpeak.Text = weekend.ToString();

            //}


            txtopus24rate.Text = lib.allrates(sc, dayc, nightprice, weekend, 0, eac).ToString();


        }

        void Opus36()
        {

            double sc = Convert.ToDouble(txtopus36sc.Text);
            double dayc = Convert.ToDouble(txtopus36day.ToolTip);
            double nightprice = Convert.ToDouble(txtopus36night.ToolTip);
            double weekend = Convert.ToDouble(txtopus36ew.ToolTip);
            //   double offpick = Convert.ToDouble(txtspe36offpeak.ToolTip);
            // double otherc = Convert.ToDouble(txtspe36other.ToolTip);

            double upliftc = Convert.ToDouble(txtopus36uplift.Text);

            double eac = Convert.ToDouble(lblEac.Text);



            if (txtopus36day.Text != "0")
            {
                dayc = dayc + upliftc;
                txtopus36day.Text = dayc.ToString();
            }

            if (txtopus36night.Text != "0")
            {
                nightprice = nightprice + upliftc;
                txtopus36night.Text = nightprice.ToString();
            }

            if (txtopus36ew.Text != "0")
            {
                weekend = weekend + upliftc;
                txtopus36ew.Text = weekend.ToString();

            }

            //if (txtspe36offpeak.Text != "0")
            //{
            //    offpick = offpick + upliftc;
            //    txtspe36offpeak.Text = weekend.ToString();

            //}


            txtopus36rate.Text = lib.allrates(sc, dayc, nightprice, weekend, 0, eac).ToString();


        }

        void Opus48()
        {

            double sc = Convert.ToDouble(txtopus48sc.Text);
            double dayc = Convert.ToDouble(txtopus48day.ToolTip);
            double nightprice = Convert.ToDouble(txtopus48night.ToolTip);
            double weekend = Convert.ToDouble(txtopus48ew.ToolTip);
            //   double offpick = Convert.ToDouble(txtspe48offpeak.ToolTip);
            // double otherc = Convert.ToDouble(txtspe48other.ToolTip);

            double upliftc = Convert.ToDouble(txtopus48uplift.Text);

            double eac = Convert.ToDouble(lblEac.Text);



            if (txtopus48day.Text != "0")
            {
                dayc = dayc + upliftc;
                txtopus48day.Text = dayc.ToString();
            }

            if (txtopus48night.Text != "0")
            {
                nightprice = nightprice + upliftc;
                txtopus48night.Text = nightprice.ToString();
            }

            if (txtopus48ew.Text != "0")
            {
                weekend = weekend + upliftc;
                txtopus48ew.Text = weekend.ToString();

            }

            //if (txtspe48offpeak.Text != "0")
            //{
            //    offpick = offpick + upliftc;
            //    txtspe48offpeak.Text = weekend.ToString();

            //}


            txtopus48rate.Text = lib.allrates(sc, dayc, nightprice, weekend, 0, eac).ToString();


        }


        void Opus12all()
        {

            double sc = Convert.ToDouble(txtopus12scall.Text);
            double dayc = Convert.ToDouble(txtopus12dayall.ToolTip);
            double nightprice = Convert.ToDouble(txtopus12nightall.ToolTip);
            double weekend = Convert.ToDouble(txtopus12ewall.ToolTip);
            //   double offpick = Convert.ToDouble(txtspe12offpeak.ToolTip);
            // double otherc = Convert.ToDouble(txtspe12other.ToolTip);

            double upliftc = Convert.ToDouble(txtopus12upliftall.Text);

            double eac = Convert.ToDouble(lblEac.Text);



            if (txtopus12dayall.Text != "0")
            {
                dayc = dayc + upliftc;
                txtopus12dayall.Text = dayc.ToString();
            }

            if (txtopus12nightall.Text != "0")
            {
                nightprice = nightprice + upliftc;
                txtopus12nightall.Text = nightprice.ToString();
            }

            if (txtopus12ewall.Text != "0")
            {
                weekend = weekend + upliftc;
                txtopus12ewall.Text = weekend.ToString();

            }

            //if (txtspe12offpeak.Text != "0")
            //{
            //    offpick = offpick + upliftc;
            //    txtspe12offpeak.Text = weekend.ToString();

            //}


            txtopus12rateall.Text = lib.allrates(sc, dayc, nightprice, weekend, 0, eac).ToString();


        }

        void Opus24all()
        {

            double sc = Convert.ToDouble(txtopus24scall.Text);
            double dayc = Convert.ToDouble(txtopus24dayall.ToolTip);
            double nightprice = Convert.ToDouble(txtopus24nightall.ToolTip);
            double weekend = Convert.ToDouble(txtopus24ewall.ToolTip);
            //   double offpick = Convert.ToDouble(txtspe24offpeak.ToolTip);
            // double otherc = Convert.ToDouble(txtspe24other.ToolTip);

            double upliftc = Convert.ToDouble(txtopus24upliftall.Text);

            double eac = Convert.ToDouble(lblEac.Text);



            if (txtopus24dayall.Text != "0")
            {
                dayc = dayc + upliftc;
                txtopus24dayall.Text = dayc.ToString();
            }

            if (txtopus24nightall.Text != "0")
            {
                nightprice = nightprice + upliftc;
                txtopus24nightall.Text = nightprice.ToString();
            }

            if (txtopus24ewall.Text != "0")
            {
                weekend = weekend + upliftc;
                txtopus24ewall.Text = weekend.ToString();

            }

            //if (txtspe24offpeak.Text != "0")
            //{
            //    offpick = offpick + upliftc;
            //    txtspe24offpeak.Text = weekend.ToString();

            //}


            txtopus24rateall.Text = lib.allrates(sc, dayc, nightprice, weekend, 0, eac).ToString();


        }

        void Opus36all()
        {

            double sc = Convert.ToDouble(txtopus36scall.Text);
            double dayc = Convert.ToDouble(txtopus36dayall.ToolTip);
            double nightprice = Convert.ToDouble(txtopus36nightall.ToolTip);
            double weekend = Convert.ToDouble(txtopus36ewall.ToolTip);
            //   double offpick = Convert.ToDouble(txtspe36offpeak.ToolTip);
            // double otherc = Convert.ToDouble(txtspe36other.ToolTip);

            double upliftc = Convert.ToDouble(txtopus36upliftall.Text);

            double eac = Convert.ToDouble(lblEac.Text);



            if (txtopus36dayall.Text != "0")
            {
                dayc = dayc + upliftc;
                txtopus36dayall.Text = dayc.ToString();
            }

            if (txtopus36nightall.Text != "0")
            {
                nightprice = nightprice + upliftc;
                txtopus36nightall.Text = nightprice.ToString();
            }

            if (txtopus36ewall.Text != "0")
            {
                weekend = weekend + upliftc;
                txtopus36ewall.Text = weekend.ToString();

            }

            //if (txtspe36offpeak.Text != "0")
            //{
            //    offpick = offpick + upliftc;
            //    txtspe36offpeak.Text = weekend.ToString();

            //}


            txtopus36rateall.Text = lib.allrates(sc, dayc, nightprice, weekend, 0, eac).ToString();


        }

        void Opus48all()
        {

            double sc = Convert.ToDouble(txtopus48scall.Text);
            double dayc = Convert.ToDouble(txtopus48dayall.ToolTip);
            double nightprice = Convert.ToDouble(txtopus48nightall.ToolTip);
            double weekend = Convert.ToDouble(txtopus48ewall.ToolTip);
            //   double offpick = Convert.ToDouble(txtspe48offpeak.ToolTip);
            // double otherc = Convert.ToDouble(txtspe48other.ToolTip);

            double upliftc = Convert.ToDouble(txtopus48upliftall.Text);

            double eac = Convert.ToDouble(lblEac.Text);



            if (txtopus48dayall.Text != "0")
            {
                dayc = dayc + upliftc;
                txtopus48dayall.Text = dayc.ToString();
            }

            if (txtopus48nightall.Text != "0")
            {
                nightprice = nightprice + upliftc;
                txtopus48nightall.Text = nightprice.ToString();
            }

            if (txtopus48ewall.Text != "0")
            {
                weekend = weekend + upliftc;
                txtopus48ewall.Text = weekend.ToString();

            }

            //if (txtspe48offpeak.Text != "0")
            //{
            //    offpick = offpick + upliftc;
            //    txtspe48offpeak.Text = weekend.ToString();

            //}


            txtopus48rateall.Text = lib.allrates(sc, dayc, nightprice, weekend, 0, eac).ToString();


        }

        #endregion


        #region EON uplift calculation


        void Eon12()
        {
            // double finalvalue = 0;
            double sc = Convert.ToDouble(txteon12sc.Text);
            double dayc = Convert.ToDouble(txteon12day.ToolTip);
            double nightprice = Convert.ToDouble(txteon12night.ToolTip);
            double weekend = Convert.ToDouble(txteon12ew.ToolTip);
            //       double unitc = Convert.ToDouble(txttgp60unitall.ToolTip);
            //  double otherc = Convert.ToDouble(txteon12other.ToolTip);

            double upliftc = Convert.ToDouble(ddEon12Uplift.Text);

            double eac = Convert.ToDouble(lblEac.Text);



            if (txteon12day.Text != "0")
            {
                dayc = dayc + upliftc;
                txteon12day.Text = dayc.ToString();
            }

            if (txteon12night.Text != "0")
            {
                nightprice = nightprice + upliftc;
                txteon12night.Text = nightprice.ToString();
            }

            if (txteon12ew.Text != "0")
            {
                weekend = weekend + upliftc;
                txteon12ew.Text = weekend.ToString();
            }

            txteon12rate.Text = lib.allrates(sc, dayc, nightprice, weekend, 0, eac).ToString();


        }

        void Eon24()
        {
            // double finalvalue = 0;
            double sc = Convert.ToDouble(txteon24sc.Text);
            double dayc = Convert.ToDouble(txteon24day.ToolTip);
            double nightprice = Convert.ToDouble(txteon24night.ToolTip);
            double weekend = Convert.ToDouble(txteon24ew.ToolTip);
            //       double unitc = Convert.ToDouble(txttgp60unitall.ToolTip);
            //  double otherc = Convert.ToDouble(txteon24other.ToolTip);

            double upliftc = Convert.ToDouble(ddeon24uplift.Text);

            double eac = Convert.ToDouble(lblEac.Text);



            if (txteon24day.Text != "0")
            {
                dayc = dayc + upliftc;
                txteon24day.Text = dayc.ToString();
            }

            if (txteon24night.Text != "0")
            {
                nightprice = nightprice + upliftc;
                txteon24night.Text = nightprice.ToString();
            }

            if (txteon24ew.Text != "0")
            {
                weekend = weekend + upliftc;
                txteon24ew.Text = weekend.ToString();
            }

            txteon24rate.Text = lib.allrates(sc, dayc, nightprice, weekend, 0, eac).ToString();


        }

        void Eon36()
        {
            // double finalvalue = 0;
            double sc = Convert.ToDouble(txteon36sc.Text);
            double dayc = Convert.ToDouble(txteon36day.ToolTip);
            double nightprice = Convert.ToDouble(txteon36night.ToolTip);
            double weekend = Convert.ToDouble(txteon36ew.ToolTip);
            //       double unitc = Convert.ToDouble(txttgp60unitall.ToolTip);
            //  double otherc = Convert.ToDouble(txteon36other.ToolTip);

            double upliftc = Convert.ToDouble(ddeon36uplift.Text);

            double eac = Convert.ToDouble(lblEac.Text);



            if (txteon36day.Text != "0")
            {
                dayc = dayc + upliftc;
                txteon36day.Text = dayc.ToString();
            }

            if (txteon36night.Text != "0")
            {
                nightprice = nightprice + upliftc;
                txteon36night.Text = nightprice.ToString();
            }

            if (txteon36ew.Text != "0")
            {
                weekend = weekend + upliftc;
                txteon36ew.Text = weekend.ToString();
            }

            txteon36rate.Text = lib.allrates(sc, dayc, nightprice, weekend, 0, eac).ToString();


        }

        void Eon48()
        {
            // double finalvalue = 0;
            double sc = Convert.ToDouble(txteon48sc.Text);
            double dayc = Convert.ToDouble(txteon48day.ToolTip);
            double nightprice = Convert.ToDouble(txteon48night.ToolTip);
            double weekend = Convert.ToDouble(txteon48ew.ToolTip);
            //       double unitc = Convert.ToDouble(txttgp60unitall.ToolTip);
            //  double otherc = Convert.ToDouble(txteon48other.ToolTip);

            double upliftc = Convert.ToDouble(ddeon48uplift.Text);

            double eac = Convert.ToDouble(lblEac.Text);



            if (txteon48day.Text != "0")
            {
                dayc = dayc + upliftc;
                txteon48day.Text = dayc.ToString();
            }

            if (txteon48night.Text != "0")
            {
                nightprice = nightprice + upliftc;
                txteon48night.Text = nightprice.ToString();
            }

            if (txteon48ew.Text != "0")
            {
                weekend = weekend + upliftc;
                txteon48ew.Text = weekend.ToString();
            }

            txteon48rate.Text = lib.allrates(sc, dayc, nightprice, weekend, 0, eac).ToString();


        }

        void Eon12all()
        {
            // double finalvalue = 0;
            double sc = Convert.ToDouble(txteon12scall.Text);
            double dayc = Convert.ToDouble(txteon12dayall.ToolTip);
            double nightprice = Convert.ToDouble(txteon12nightall.ToolTip);
            double weekend = Convert.ToDouble(txteon12ewall.ToolTip);
            //       double unitc = Convert.ToDouble(txttgp60unitall.ToolTip);
            //  double otherc = Convert.ToDouble(txteon12other.ToolTip);

            double upliftc = Convert.ToDouble(ddeon12upliftall.Text);

            double eac = Convert.ToDouble(lblEac.Text);



            if (txteon12dayall.Text != "0")
            {
                dayc = dayc + upliftc;
                txteon12dayall.Text = dayc.ToString();
            }

            if (txteon12nightall.Text != "0")
            {
                nightprice = nightprice + upliftc;
                txteon12nightall.Text = nightprice.ToString();
            }

            if (txteon12ewall.Text != "0")
            {
                weekend = weekend + upliftc;
                txteon12ewall.Text = weekend.ToString();
            }

            txteon12rateall.Text = lib.allrates(sc, dayc, nightprice, weekend, 0, eac).ToString();


        }

        void Eon24all()
        {
            // double finalvalue = 0;
            double sc = Convert.ToDouble(txteon24scall.Text);
            double dayc = Convert.ToDouble(txteon24dayall.ToolTip);
            double nightprice = Convert.ToDouble(txteon24nightall.ToolTip);
            double weekend = Convert.ToDouble(txteon24ewall.ToolTip);
            //       double unitc = Convert.ToDouble(txttgp60unitall.ToolTip);
            //  double otherc = Convert.ToDouble(txteon24other.ToolTip);

            double upliftc = Convert.ToDouble(ddeon24upliftall.Text);

            double eac = Convert.ToDouble(lblEac.Text);



            if (txteon24dayall.Text != "0")
            {
                dayc = dayc + upliftc;
                txteon24dayall.Text = dayc.ToString();
            }

            if (txteon24nightall.Text != "0")
            {
                nightprice = nightprice + upliftc;
                txteon24nightall.Text = nightprice.ToString();
            }

            if (txteon24ewall.Text != "0")
            {
                weekend = weekend + upliftc;
                txteon24ewall.Text = weekend.ToString();
            }

            txteon24rateall.Text = lib.allrates(sc, dayc, nightprice, weekend, 0, eac).ToString();


        }

        void Eon36all()
        {
            // double finalvalue = 0;
            double sc = Convert.ToDouble(txteon36scall.Text);
            double dayc = Convert.ToDouble(txteon36dayall.ToolTip);
            double nightprice = Convert.ToDouble(txteon36nightall.ToolTip);
            double weekend = Convert.ToDouble(txteon36ewall.ToolTip);
            //       double unitc = Convert.ToDouble(txttgp60unitall.ToolTip);
            //  double otherc = Convert.ToDouble(txteon36other.ToolTip);

            double upliftc = Convert.ToDouble(ddeon36upliftall.Text);

            double eac = Convert.ToDouble(lblEac.Text);



            if (txteon36dayall.Text != "0")
            {
                dayc = dayc + upliftc;
                txteon36dayall.Text = dayc.ToString();
            }

            if (txteon36nightall.Text != "0")
            {
                nightprice = nightprice + upliftc;
                txteon36nightall.Text = nightprice.ToString();
            }

            if (txteon36ewall.Text != "0")
            {
                weekend = weekend + upliftc;
                txteon36ewall.Text = weekend.ToString();
            }

            txteon36rateall.Text = lib.allrates(sc, dayc, nightprice, weekend, 0, eac).ToString();


        }

        void Eon48all()
        {
            // double finalvalue = 0;
            double sc = Convert.ToDouble(txteon48scall.Text);
            double dayc = Convert.ToDouble(txteon48dayall.ToolTip);
            double nightprice = Convert.ToDouble(txteon48nightall.ToolTip);
            double weekend = Convert.ToDouble(txteon48ewall.ToolTip);
            //       double unitc = Convert.ToDouble(txttgp60unitall.ToolTip);
            //  double otherc = Convert.ToDouble(txteon48other.ToolTip);

            double upliftc = Convert.ToDouble(ddeon48upliftall.Text);

            double eac = Convert.ToDouble(lblEac.Text);



            if (txteon48dayall.Text != "0")
            {
                dayc = dayc + upliftc;
                txteon48dayall.Text = dayc.ToString();
            }

            if (txteon48nightall.Text != "0")
            {
                nightprice = nightprice + upliftc;
                txteon48nightall.Text = nightprice.ToString();
            }

            if (txteon48ewall.Text != "0")
            {
                weekend = weekend + upliftc;
                txteon48ewall.Text = weekend.ToString();
            }

            txteon48rateall.Text = lib.allrates(sc, dayc, nightprice, weekend, 0, eac).ToString();


        }




        #endregion







        protected void txtbga12uplift_TextChanged(object sender, EventArgs e)
        {
            bga12();
        }

      

        protected void txtbga24uplift_TextChanged(object sender, EventArgs e)
        {
            bga24();
        }

        protected void txtbga36uplift_TextChanged(object sender, EventArgs e)
        {
            bga36();
        }

        protected void txtbga60uplift_TextChanged(object sender, EventArgs e)
        {
            bga60();
        }

        protected void txtbga48uplift_TextChanged(object sender, EventArgs e)
        {
            bga48();
        }

        protected void txtbga12upliftall_TextChanged(object sender, EventArgs e)
        {
            bga12all();
        }

        protected void txtbga24upliftall_TextChanged(object sender, EventArgs e)
        {
            bga24all();
        }

        protected void txtbga36upliftall_TextChanged(object sender, EventArgs e)
        {
            bga36all();
        }

        protected void txtbga60upliftall_TextChanged(object sender, EventArgs e)
        {
            bga60all();
        }

        protected void txtbga48upliftall_TextChanged(object sender, EventArgs e)
        {
            bga48all();
        }

        protected void txtbge12uplift_TextChanged(object sender, EventArgs e)
        {
            bge12();
        }

        protected void txtbge24uplift_TextChanged(object sender, EventArgs e)
        {
            Bge24();
        }

        protected void txtbge36uplift_TextChanged(object sender, EventArgs e)
        {
            Bge36();
        }

        protected void txtbge48uplift_TextChanged(object sender, EventArgs e)
        {
            Bge48();
        }

        protected void txtbge12upliftall_TextChanged(object sender, EventArgs e)
        {
            Bge12all();
        }

        protected void txtbge24upliftall_TextChanged(object sender, EventArgs e)
        {
            Bge24all();
        }

        protected void txtbge36upliftall_TextChanged(object sender, EventArgs e)
        {
            Bge36all();
        }

        protected void txtbge48upliftall_TextChanged(object sender, EventArgs e)
        {
            Bge48all();
        }

        protected void txtbgla12uplift_TextChanged(object sender, EventArgs e)
        {
            Bgl12();
        }

        protected void txtbgla24uplift_TextChanged(object sender, EventArgs e)
        {
            Bgl24();
        }

        protected void txtbgla36uplift_TextChanged(object sender, EventArgs e)
        {
            Bgl36();
        }

        protected void txtbgla48uplift_TextChanged(object sender, EventArgs e)
        {
            Bgl48();
        }

        protected void txtbgla12upliftall_TextChanged(object sender, EventArgs e)
        {
            Bgl12all();
        }

        protected void txtbgla24upliftall_TextChanged(object sender, EventArgs e)
        {
            Bgl24all();
        }

        protected void txtbgla36upliftall_TextChanged(object sender, EventArgs e)
        {
            Bgl36all();
        }

        protected void txtbgla48upliftall_TextChanged(object sender, EventArgs e)
        {
            Bgl48all();
        }

        protected void txtbgle12uplift_TextChanged(object sender, EventArgs e)
        {
            Bgle12();
        }

        protected void txtbgle24uplift_TextChanged(object sender, EventArgs e)
        {
            Bgle24();
        }

        protected void txtbgle36uplift_TextChanged(object sender, EventArgs e)
        {
            Bgle36();
        }

        protected void txtbgle48uplift_TextChanged(object sender, EventArgs e)
        {
            Bgle48();
        }

        protected void txtbgle12upliftall_TextChanged(object sender, EventArgs e)
        {
            Bgle12all();
        }

        protected void txtbgle24upliftall_TextChanged(object sender, EventArgs e)
        {
            Bgle24all();
        }

        protected void txtbgle36upliftall_TextChanged(object sender, EventArgs e)
        {
            Bgle36all();
        }

        protected void txtbgle48upliftall_TextChanged(object sender, EventArgs e)
        {
            Bgle48all();
        }

        protected void txtedfa12uplift_TextChanged(object sender, EventArgs e)
        {
            Edf12();
        }

        protected void txtedfa24uplift_TextChanged(object sender, EventArgs e)
        {
            Edf24();
        }

        protected void txtedfa36uplift_TextChanged(object sender, EventArgs e)
        {
            Edf36();
        }

        protected void txtedfa48uplift_TextChanged(object sender, EventArgs e)
        {
            Edf48();
        }

        protected void txtedfa12upliftall_TextChanged(object sender, EventArgs e)
        {
            Edf12all();
        }

        protected void txtedfa24upliftall_TextChanged(object sender, EventArgs e)
        {
            Edf24all();
        }

        protected void txtedfa36upliftall_TextChanged(object sender, EventArgs e)
        {
            Edf36all();
        }

        protected void txtedfa48upliftall_TextChanged(object sender, EventArgs e)
        {
            Edf48all();
        }

        protected void txtdea12uplift_TextChanged(object sender, EventArgs e)
        {
            De12();
        }

        protected void txtdea24uplift_TextChanged(object sender, EventArgs e)
        {
            De24();
        }

        protected void txtdea36uplift_TextChanged(object sender, EventArgs e)
        {
            De36();
        }

        protected void txtedfa60uplift_TextChanged(object sender, EventArgs e)
        {
           // De60();
        }

        protected void txtdea60uplift_TextChanged(object sender, EventArgs e)
        {
            De60();
        }

        protected void txtdea12uplift12all_TextChanged(object sender, EventArgs e)
        {
            De12all();
        }

        protected void txtdea24uplift24all_TextChanged(object sender, EventArgs e)
        {
            De24all();
        }

        protected void txtdea36uplift1ll_TextChanged(object sender, EventArgs e)
        {
            De36all();

        }

        protected void txtdea60upliftall_TextChanged(object sender, EventArgs e)
        {
            De60all();
        }

        protected void txtpe12uplift_TextChanged(object sender, EventArgs e)
        {
            Pe12();
        }

        protected void txtpe24uplift_TextChanged(object sender, EventArgs e)
        {
            Pe24();
        }

        protected void txtpe36uplift_TextChanged(object sender, EventArgs e)
        {
            Pe36();
        }

        protected void txtpe12upliftall_TextChanged(object sender, EventArgs e)
        {
            Pe12all();
        }

        protected void txtpe24upliftall_TextChanged(object sender, EventArgs e)
        {
            Pe24all();
        }

        protected void txtpe36upliftall_TextChanged(object sender, EventArgs e)
        {
            Pe36all();
        }

        protected void txtgaz12uplift_TextChanged(object sender, EventArgs e)
        {
            Gaz12();
        }

        protected void txtgaz24uplift_TextChanged(object sender, EventArgs e)
        {
            Gaz24();
        }

        protected void txtgaz36uplift_TextChanged(object sender, EventArgs e)
        {
            Gaz36();
        }

        protected void txtgaz12upliftall_TextChanged(object sender, EventArgs e)
        {
            Gaz12all();
        }

        protected void txtgaz24upliftall_TextChanged(object sender, EventArgs e)
        {
            Gaz24all();
        }

        protected void txtgaz36upliftall_TextChanged(object sender, EventArgs e)
        {
            Gaz36all();
        }

        protected void txtnpra12uplift_TextChanged(object sender, EventArgs e)
        {
            npower12();
        }

        protected void txtnpra24uplift_TextChanged(object sender, EventArgs e)
        {
            npower24();
        }

        protected void txtnpra36uplift_TextChanged(object sender, EventArgs e)
        {
            npower36();
        }

        protected void txtnpra12upliftall_TextChanged(object sender, EventArgs e)
        {
            npower12all();
        }

        protected void txtnpra24upliftall_TextChanged(object sender, EventArgs e)
        {
            npower24all();
        }

        protected void txtnpra36upliftall_TextChanged(object sender, EventArgs e)
        {
            npower36all();
        }

        protected void txttgp12uplift_TextChanged(object sender, EventArgs e)
        {
            tgp12();
        }

        protected void txttgp24uplift_TextChanged(object sender, EventArgs e)
        {
            tgp24();
        }

        protected void txttgp36uplift_TextChanged(object sender, EventArgs e)
        {
            tgp36();
        }

        protected void txttgp48uplift_TextChanged(object sender, EventArgs e)
        {
            tgp48();
        }

        protected void txttgp60uplift_TextChanged(object sender, EventArgs e)
        {
            tgp60();
        }

        protected void txttgp12upliftall_TextChanged(object sender, EventArgs e)
        {
            tgp12all();
        }

        protected void txttgp24upliftall_TextChanged(object sender, EventArgs e)
        {
            tgp24all();
        }

        protected void txttgp36upliftall_TextChanged(object sender, EventArgs e)
        {
            tgp36all();
        }

        protected void txttgp48upliftall_TextChanged(object sender, EventArgs e)
        {
            tgp48all();
        }

        protected void txttgp60upliftall_TextChanged(object sender, EventArgs e)
        {
            tgp60all();
        }


        protected void ddEon12Uplift_SelectedIndexChanged(object sender, EventArgs e)
        {
             Eon12();

        }

        public void Sendemailwithimg(string msg)
        {
            SmtpClient smtpClient = GetSmtpClient("smtp.gmail.com", 587, "greenoceansoftware@gmail.com", "green!123", true);
            MailMessage mail = new MailMessage();
           

         //   mail.Sender = new MailAddress(mail);

            mail.From = new MailAddress("anil.pecon@gmail.com" ,ddProvider.Text);
            mail.To.Add("anil150875@gmail.com");
            mail.To.Add("greenoceansoftware@gmail.com");
            mail.To.Add(txtEmail.Text.Trim());
            mail.Subject = "Quotation";
            string htmlBody = "Welcome to " + ddProvider.Text + "<hr>";

            string email = lib.GetEmail(ddProvider.Text);
            string phone = lib.GetPhone(ddProvider.Text);
            string website = lib.GetWebsite(ddProvider.Text);

            mail.IsBodyHtml = true;
            mail.Body = htmlBody;
    
            string header = " Dear <b>" + txtName.Text + " ,<b><br> <hr>This mail is in reference to the discussion which we had regarding the renewal of commercial Electricity supply for your business.For the following site <br>- " + txtBusinessAddress.Text + "  <br/> As we have discussed, we are mailing you the prices for your Account <br>";
            string footer = " <br> Again, thank you for considering us for your Business Electricity.<br> <br> Regards  The services of " + ddProvider.Text + " comes for free with no direct cost to our customer base. <br> Having an experience of over four years in the energy markets, We help getting you the best energy deals available in the market <br> Yours sincerely, Customer Services " + ddProvider.Text + "  \n Telephone: " + phone + " \n Email us at: " + email + " <br><hr> Website :" + website+ " <br> What to expect from Us.  <br> We can definitely beat the standard renewal rates which Energy Suppliers offer. -<br> We will obtain discounted pricing from your existing supplier as well as compare the market for you and give you the best independent advice for your energy contracts";
            //  string body = Messagebody(lblDuration.Text, txtbga12scall.Text, "British Gas", txtbga12unitall.Text, txtbga12rate.Text, "bg");
            string body = msg;
            htmlBody = htmlBody + "" + Environment.NewLine + header + body + footer;
            AlternateView htmlview = default(AlternateView);
            htmlview = AlternateView.CreateAlternateViewFromString(htmlBody, null, "text/html");
            LinkedResource imageResourceEs = new LinkedResource("C:\\Users\\anil1\\source\\repos\\GreenOcean\\GreenOcean\\images\\britishgas.jpg")
            {
                ContentId = "bg"
            };

            LinkedResource imageResourceDE = new LinkedResource("C:\\Users\\anil1\\source\\repos\\GreenOcean\\GreenOcean\\images\\de.jpg")
            {
                ContentId = "de"
            };

            LinkedResource imageResourceBGL = new LinkedResource("C:\\Users\\anil1\\source\\repos\\GreenOcean\\GreenOcean\\images\\bgl.png")
            {
                ContentId = "bgl"
            };

            LinkedResource imageResourceEDF = new LinkedResource("C:\\Users\\anil1\\source\\repos\\GreenOcean\\GreenOcean\\images\\edf.jpg")
            {
                ContentId = "edf"
            };

            LinkedResource imageResourceEON = new LinkedResource("C:\\Users\\anil1\\source\\repos\\GreenOcean\\GreenOcean\\images\\eon.jpg")
            {
                ContentId = "eon"
            };
            LinkedResource imageResourceGAZ = new LinkedResource("C:\\Users\\anil1\\source\\repos\\GreenOcean\\GreenOcean\\images\\gaz.png")
            {
                ContentId = "gaz"
            };

            LinkedResource imageResourcespower = new LinkedResource("C:\\Users\\anil1\\source\\repos\\GreenOcean\\GreenOcean\\images\\spower.jpg")
            {
                ContentId = "spower"
            };

            LinkedResource imageResourcenpower = new LinkedResource("C:\\Users\\anil1\\source\\repos\\GreenOcean\\GreenOcean\\images\\npower.jpg")
            {
                ContentId = "npower"
            };

            LinkedResource imageResourceTGP = new LinkedResource("C:\\Users\\anil1\\source\\repos\\GreenOcean\\GreenOcean\\images\\tglogo.png")
            {
                ContentId = "tgp"
            };


            imageResourceEs.TransferEncoding = System.Net.Mime.TransferEncoding.Base64;
            imageResourceDE.TransferEncoding = System.Net.Mime.TransferEncoding.Base64;
            imageResourceBGL.TransferEncoding = System.Net.Mime.TransferEncoding.Base64;
            imageResourceEDF.TransferEncoding = System.Net.Mime.TransferEncoding.Base64;
            imageResourceEON.TransferEncoding = System.Net.Mime.TransferEncoding.Base64;
            imageResourceGAZ.TransferEncoding = System.Net.Mime.TransferEncoding.Base64;
            imageResourcespower.TransferEncoding = System.Net.Mime.TransferEncoding.Base64;
            imageResourcenpower.TransferEncoding = System.Net.Mime.TransferEncoding.Base64;
            imageResourceTGP.TransferEncoding = System.Net.Mime.TransferEncoding.Base64;


            htmlview.LinkedResources.Add(imageResourceEs);
            htmlview.LinkedResources.Add(imageResourceDE);
            htmlview.LinkedResources.Add(imageResourceBGL);
            htmlview.LinkedResources.Add(imageResourceEDF);
            htmlview.LinkedResources.Add(imageResourceEON);
            htmlview.LinkedResources.Add(imageResourceGAZ);
            htmlview.LinkedResources.Add(imageResourcespower);
            htmlview.LinkedResources.Add(imageResourcenpower);
            htmlview.LinkedResources.Add(imageResourceTGP);



            mail.AlternateViews.Add(htmlview);
            try
            {
                smtpClient.Send(mail);
                btnSendEmail.Text = "Email Sent...";
                String leadid = lib.LeadDetailInsert(Session["leadid"].ToString(), Session["UserName"].ToString(), "Email Sent via"  + ddProvider.Text + "", "Y", "", "", "", "", "", Session["UserName"].ToString(), "");
                 leadid = lib.LeadMasterUpdate(Session["leadid"].ToString(), "Email Sent", "A", "");
             }
            catch (Exception t)
            {
                btnSendEmail.Text = t.Message;
            }


        }

        string Messagebody(string duration , string standingcharge,  string provider , string rate , string dayrate , string projectedcost , string images)
        {
            string mybody = "";
            string email = lib.GetEmail(ddProvider.Text);
            string phone = lib.GetPhone(ddProvider.Text);
            string website  = lib.GetWebsite(ddProvider.Text);

            mybody = "<table border = 1px> <tr><td><img src=\"cid:"+ images+"\"></td> <td> <td> Duration</td><td> " + duration + " Months</td> <td> </tr> <tr>Electricity Fixed  Prices from  " + provider + "=:-  Standing Charge  </td> <td> " + standingcharge + " pence/day  </td>  <td>  Unit Rate 	  :" + rate + "pence / kwh </td> <td>     </td><td>Dayrate : "+ dayrate + "pence / kwh </td><td> Early Projected cost </td> " + projectedcost + " </tr></table><br/>  ";
            mybody = mybody + Environment.NewLine + "We would further like to inform you that the above rates / tariff are the best which we can offer you at the moment for " + duration + " Months contract. ";
            return mybody;
        }

        string Finalmessage()
        {
            string mymessage = "";
            if(chkbga12all.Checked== true || chkbga12.Checked == true)

            {
                if(chkbga12.Checked == true)
                {
                   // txtbga12unitall.Text = txtbga12day.Text;
                    txtbga12rateall.Text = txtbga12rate.Text;
                    txtbga12dayall.Text = txtbga12day.Text;

                }

                
                mymessage = mymessage + Messagebody("12", txtbga12scall.Text, "Britsh Gas", txtbga12dayall.Text, txtbga12dayall.Text, txtbga12rateall.Text, "bg");


            }
            if (chkbga24all.Checked == true || chkbga24.Checked == true)
            {
                if(chkbga24.Checked == true)
                {

                
              //  txtbga24unitall.Text = txtbga24day.Text;
                txtbga24rateall.Text = txtbga24rate.Text;
                txtbga24dayall.Text = txtbga24day.Text;
                }

                mymessage = mymessage + Messagebody("24", txtbga24scall.Text, "Britsh Gas", txtbga24dayall.Text, txtbga24dayall.Text, txtbga12rateall.Text, "bg");


            }
            if (chkbga36all.Checked == true || chkbga36.Checked == true)
            {
                if (chkbga36.Checked == true)
                {
                  //  txtbga36unitall.Text = txtbga36day.Text;
                    txtbga36rateall.Text = txtbga36rate.Text;
                    txtbga36dayall.Text = txtbga36day.Text;
                }
                mymessage = mymessage + Messagebody("36", txtbga36scall.Text, "Britsh Gas", txtbga36dayall.Text, txtbga36dayall.Text, txtbga36rateall.Text, "bg");


            }

            if (chkbga48all.Checked == true || chkbga48.Checked ==true)
            {
                if (chkbga48.Checked == true)
                {
                   // txtbga48unitall.Text = txtbga48day.Text;
                    txtbga48rateall.Text = txtbga48rate.Text;
                    txtbga48dayall.Text = txtbga48day.Text;
                }
                mymessage = mymessage + Messagebody("48", txtbga48scall.Text, "Britsh Gas", txtbga48dayall.Text, txtbga48dayall.Text, txtbga48rateall.Text, "bg");


            }

            if (chkbga60all.Checked == true || chkbga60.Checked == true)
            {
                if (chkbga60.Checked == true)
                {
                  //  txtbga60unitall.Text = txtbga60day.Text;
                    txtbga60rateall.Text = txtbga60rate.Text;
                    txtbga60dayall.Text = txtbga60day.Text;
                }
                mymessage = mymessage + Messagebody("60", txtbga48scall.Text, "Britsh Gas", txtbga60dayall.Text, txtbga60dayall.Text, txtbga60rateall.Text, "bg");


            }

            if (chkbge12all.Checked == true || chkbge12.Checked == true)
            {
                if(chkbge12.Checked == true)
                {
               // txtbge12unitall.Text = txtbge12unit.Text;
                txtbge12dayall.Text = txtbge12day.Text;
                txtbge12rateall.Text = txtbge12rate.Text;
                }
              

                mymessage = mymessage + Messagebody("12", txtbge12scall.Text, "Britsh Gas", txtbge12dayall.Text, txtbge12dayall.Text, txtbge12rateall.Text, "bg");


            }

            if (chkbge24all.Checked == true || chkbge24.Checked == true)
            {
                if (chkbge24.Checked == true)
                {
                  //  txtbge24unitall.Text = txtbge24unit.Text;
                    txtbge24dayall.Text = txtbge24day.Text;
                    txtbge24rateall.Text = txtbfge24rate.Text;
                }
                mymessage = mymessage + Messagebody("24", txtbge24scall.Text, "Britsh Gas", txtbge24dayall.Text, txtbge24dayall.Text, txtbge24rateall.Text, "bg");


            }

            if (chkbge36all.Checked == true || chkbge36.Checked == true)
            {
                if (chkbge36.Checked == true)
                {
               //     txtbge36unitall.Text = txtbge36unit.Text;
                    txtbge36dayall.Text = txtbge36day.Text;
                    txtbge36rateall.Text = txtbfge36rate.Text;
                }
                mymessage = mymessage + Messagebody("36", txtbge36scall.Text, "Britsh Gas", txtbge36dayall.Text, txtbge36dayall.Text, txtbge36rateall.Text, "bg");


            }

            if (chkbge48all.Checked == true ||  chkbge48.Checked ==   true )
            {
                if (chkbge48.Checked == true)
                {
                 //   txtbge48unitall.Text = txtbge48unit.Text;
                    txtbge48dayall.Text = txtbge48day.Text;
                    txtbfge48rateall.Text = txtbfge48rate.Text;
                }
                mymessage = mymessage + Messagebody("48", txtbge48scall.Text, "Britsh Gas", txtbge48dayall.Text, txtbge48dayall.Text, txtbfga48rateall.Text, "bg");


            }



            if (chkbgl12all.Checked == true || chkbgla12.Checked == true)
            {
                if (chkbgla12.Checked == true)
                {

                //    txtbgla12unitall.Text = txtbgla12unit.Text;
                    txtbgla12dayall.Text = txtbgla12day.Text;
                    txtbgla12rateall.Text = txtbgla12rate.Text;
                }

                mymessage = mymessage + Messagebody("12", txtbgla12scall.Text, "Britsh Gas Lite", txtbgla12dayall.Text, txtbgla12dayall.Text, txtbgla12rateall.Text, "bgl");


            }

            if (chkbgla24all.Checked == true || chkbgla24.Checked == true)
            {
                if (chkbgla24.Checked == true)
                {
                  //  txtbgla24unitall.Text = txtbgla24unit.Text;
                    txtbgla24dayall.Text = txtbgla24day.Text;
                    txtbgla24rateall.Text = txtbfgla24rate.Text;
                }
                mymessage = mymessage + Messagebody("24", txtbgla24scall.Text, "Britsh Gas Lite", txtbgla24dayall.Text, txtbgla24dayall.Text, txtbgla24rateall.Text, "bgl");


            }

            if (chkbgla36all.Checked == true || chkbgla36.Checked == true)
            {
                if (chkbgla36.Checked == true)
                {
               //     txtbgla36unitall.Text = txtbgla36unit.Text;
                    txtbgla36dayall.Text = txtbgla36day.Text;
                    txtbgla36rateall.Text = txtbfgla36rate.Text;
                }
                mymessage = mymessage + Messagebody("36", txtbgla36scall.Text, "Britsh Gas Lite", txtbgla36dayall.Text, txtbgla36dayall.Text, txtbgla36rateall.Text, "bgl");

            }
            if (chkbgla48all.Checked == true || chkbgla48.Checked == true)
            {
                if (chkbgla48.Checked == true)
                {
                 //   txtbgla48unitall.Text = txtbgla48unit.Text;
                    txtbgla48dayall.Text = txtbgla48day.Text;
                    txtbfgla48rateall.Text = txtbfgla48rate.Text;
                }
                mymessage = mymessage + Messagebody("48", txtbgla48scall.Text, "Britsh Gas Lite", txtbgla48dayall.Text, txtbgla48dayall.Text, txtbfgla48rateall.Text, "bgl");

            }

            if (chkedf12all.Checked == true || chkedf12.Checked == true)
            {

                if (chkedf12.Checked == true)
                {
                //    txtedfa12unitall.Text = txtedfa12unit.Text;
                    txtedfa12dayall.Text = txtedfa12day.Text;
                    txtedf12rateall.Text = txtEdf12Rate.Text;
                }
                mymessage = mymessage + Messagebody("12", txtedfa12scall.Text, "EDF", txtedfa12dayall.Text, txtedfa12dayall.Text, txtedf12rateall.Text, "edf");

            }

            if (chkedf24all.Checked == true || chkedf24.Checked == true)
            {
                if (chkedf24.Checked == true)
                {
                //    txtedfa24unitall.Text = txtedfa24unit.Text;
                    txtedfa24dayall.Text = txtedfa24day.Text;
                    txtedf24rateall.Text = txtEdf24Rate.Text;
                }
                mymessage = mymessage + Messagebody("24", txtedfa24scall.Text, "EDF", txtedfa24dayall.Text, txtedfa24dayall.Text, txtedf24rateall.Text, "edf");

            }
            if (chkedf36all.Checked == true || chkedf36.Checked == true)
            {
                if (chkedf36.Checked == true)
                {
                 //   txtedfa36unitall.Text = txtedfa36unit.Text;
                    txtedfa36dayall.Text = txtedfa36day.Text;
                    txtedf36rateall.Text = txtEdf36Rate.Text;
                }
                mymessage = mymessage + Messagebody("36", txtedfa36scall.Text, "EDF", txtedfa36dayall.Text, txtedfa36dayall.Text, txtedf36rateall.Text, "edf");

            }

            if (chkedf48all.Checked == true || chkedf48.Checked == true)
            {
                if (chkedf48.Checked == true)
                {
                //    txtedfa48unitall.Text = txtedfa36unit.Text;
                    txtedfa48dayall.Text = txtedfa36day.Text;
                    txtedfa48rateall.Text = txtEdf48Rate.Text;
                }
                mymessage = mymessage + Messagebody("48", txtedfa48scall.Text, "EDF", txtedfa48dayall.Text, txtedfa48dayall.Text, txtedfa48rateall.Text, "edf");

            }

            if (chkdea12all.Checked == true || chkde12.Checked == true)
            {
                if (chkde12.Checked == true)
                {
                  //  txtdea12unit12all.Text = txtdea12unit.Text;
                    txtdea12day12all.Text = txtdea12day.Text;
                    txtdea12all.Text = txtde12rate.Text;
                }

                mymessage = mymessage + Messagebody("12", txtdea12sc12all.Text, "Duel Energy ", txtdea12day12all.Text, txtdea12day12all.Text, txtdea12all.Text, "de");

            }
            if (chkdea24all.Checked == true || chkde24.Checked == true)
            {
                if (chkde24.Checked == true)
                {
                //    txtdea24unit24all.Text = txtdea24unit.Text;
                    txtdea24day24all.Text = txtdea24day.Text;
                    txtdea24all.Text = txtde24rate.Text;
                }
                mymessage = mymessage + Messagebody("24", txtdea24sc24all.Text, "Duel Energy ", txtdea24day24all.Text, txtdea24day24all.Text, txtdea24all.Text, "de");

            }

            if (chkdea36all.Checked == true || chkde36.Checked== true)
            {
                if (chkde36.Checked == true)
                {
                //    txtdea36unitall.Text = txtdea36unit.Text;
                    txtdea36dayall.Text = txtdea36day.Text;
                    txtdea36all.Text = txtde36rate.Text;
                }
                mymessage = mymessage + Messagebody("36", txtdea36scall.Text, "Duel Energy ", txtdea36dayall.Text, txtdea36dayall.Text, txtdea36all.Text, "de");

            }

            if (chkdea48all.Checked == true || chkdea48.Checked == true)
            {
                if (chkdea48.Checked == true)
                {
                  //  txtdea48unitall.Text = txtdea48unit.Text;
                    txtdea48dayall.Text = txtdea48day.Text;
                    txtdea48rateall.Text = txtdea48.Text;
                }
                mymessage = mymessage + Messagebody("48", txtdea48scall.Text, "Duel Energy ", txtdea48dayall.Text, txtdea48dayall.Text, txtdea48rateall.Text, "de");

            }

            if (chkdea60all.Checked == true || chkde60.Checked == true)
            {
                if (chkde60.Checked == true)
                {
                //    txtdea60unitall.Text = txtdea60unit.Text;
                    txtdea60dayall.Text = txtdea60day.Text;
                    txtedf60rateall.Text = txtedf60rate.Text;
                }

                mymessage = mymessage + Messagebody("60", txtdea36scall.Text, "Duel Energy ", txtdea60dayall.Text, txtdea60dayall.Text, txtedf60rateall.Text, "de");

            }

            if (chkpe12all.Checked == true || chkpe12.Checked == true)
            {
                if (chkpe12.Checked == true)
                {
                //    txtpe12unitall.Text = txtpe12unit.Text;
                    txtpe12dayall.Text = txtpe12day.Text;
                    txtpe12rateall.Text = txtpe12rate.Text;



                }



                mymessage = mymessage + Messagebody("12", txtpe12scall.Text, "Positve Energy ", txtpe12dayall.Text, txtpe12dayall.Text, txtpe12rateall.Text, "pe");

            }
            if (chkpe24all.Checked == true || chkpe24.Checked == true)
            {
                if (chkpe24.Checked == true)
                {
                    //txtpe24unitall.Text = txtpe24unit.Text;
                    txtpe24dayall.Text = txtpe24day.Text;
                    txtpe24rateall.Text = txtpe24rate.Text;



                }
                mymessage = mymessage + Messagebody("24", txtpe24scall.Text, "Positve Energy ", txtpe24dayall.Text, txtpe24dayall.Text, txtpe24rateall.Text, "pe");

            }
            if (chkpe36all.Checked == true || chkpe36.Checked == true)
            {
                if (chkpe36.Checked == true)
                {
                 //   txtpe36unitall.Text = txtpe36unit.Text;
                    txtpe36dayall.Text = txtpe36day.Text;
                    txtpe36rateall.Text = txtpe36rate.Text;



                }

                mymessage = mymessage + Messagebody("36", txtpe36scall.Text, "Positve Energy ", txtpe36dayall.Text, txtpe36dayall.Text, txtpe36rateall.Text, "pe");

            }

            if (chkgaz12all.Checked == true || chkgaz12.Checked == true)
            {

                if (chkgaz12.Checked == true)
                {
                 //   txtgaz12unitall.Text = txtgaz12unit.Text;
                    txtgaz12dayall.Text = txtgaz12day.Text;
                    txtgaz12rateall.Text = txtgaz12rate.Text;



                }
                mymessage = mymessage + Messagebody("12", txtgaz12scall.Text, "gazprom Energy ", txtgaz12dayall.Text, txtgaz12dayall.Text, txtgaz12rateall.Text, "gaz");

            }
            if (chkgaz24all.Checked == true || chkgaz24.Checked == true)
            {
                if (chkgaz24.Checked == true)
                {
                    //txtgaz24unitall.Text = txtgaz24unit.Text;
                    txtgaz24dayall.Text = txtgaz24day.Text;
                    txtgaz24rateall.Text = txtgaz24rate.Text;



                }
                mymessage = mymessage + Messagebody("24", txtgaz24scall.Text, "gazprom Energy ", txtgaz24dayall.Text, txtgaz24rateall.Text, txtgaz24rateall.Text, "gaz");

            }
            if (chkgaz24all.Checked == true || chkgaz36 .Checked == true)
            {

                if (chkgaz36.Checked == true)
                {
                //    txtgaz36unitall.Text = txtgaz36unit.Text;
                    txtgaz36dayall.Text = txtgaz36day.Text;
                    txtgaz36rateall.Text = txtgaz36rate.Text;



                }
                mymessage = mymessage + Messagebody("36", txtgaz36scall.Text, "gazprom Energy ", txtgaz36dayall.Text, txtgaz36rateall.Text, txtgaz36rateall.Text, "gaz");

            }

            if (chknpower12all.Checked == true || chknpr12.Checked == true)
            {
                if(chknpr12.Checked == true)
                {
                 //   txtnpra12unitall.Text = txtnpra12unit.Text;
                    txtnpra12dayall.Text = txtnpra12day.Text;
                    txtnpra12rateall.Text = txtnpra12rate.Text;




                }

                mymessage = mymessage + Messagebody("12", txtnpra12scall.Text, "Npower Energy ", txtnpra12dayall.Text, txtnpra12dayall.Text, txtnpra12rateall.Text, "npower");

            }

            if (chknpower24all.Checked == true || chknpr24.Checked == true)
            {
                if (chknpr24.Checked == true)
                {
                //    txtnpra24unitall.Text = txtnpra24unit.Text;
                    txtnpra24dayall.Text = txtnpra24day.Text;
                    txtnpra24rateall.Text = txtnpra24rate.Text;

                }
                mymessage = mymessage + Messagebody("24", txtnpra24scall.Text, "Npower Energy ", txtnpra24dayall.Text, txtnpra24dayall.Text, txtnpra24rateall.Text, "npower");

            }
            if (chknpower36all.Checked == true || chknpr36 .Checked == true)
            {
                if (chknpr36.Checked == true)
                {
                 //   txtnpra36unitall.Text = txtnpra36unit.Text;
                    txtnpra36dayall.Text = txtnpra36day.Text;
                    txtnpra36rateall.Text = txtnpra36rate.Text;

                }
                mymessage = mymessage + Messagebody("36", txtnpra36scall.Text, "Npower Energy ", txtnpra36dayall.Text, txtnpra36dayall.Text, txtnpra36rateall.Text, "npower");

            }
            if (chknpower48all.Checked == true || chknpower48all.Checked == true)
            {
              
                mymessage = mymessage + Messagebody("48", txtnpra48scall.Text, "Npower Energy ", txtnpra48dayall.Text, txtnpra48dayall.Text, txtnpra48rateall.Text, "npower");

            }
            if (chktgp12all.Checked == true || chktgp12.Checked == true)
            {
                if(chktgp12.Checked ==true)
                {
                 //   txttgp12unitall.Text = txttgp12unit.Text;
                    txttgp12dayall.Text = txttgp12day.Text;
                    txttgp12rateall.Text = txttgp12rate.Text;
                }

                mymessage = mymessage + Messagebody("12", txttgp12scall.Text, "Total Gas Power Energy ", txttgp12dayall.Text, txttgp12dayall.Text, txttgp12rateall.Text, "tgp");

            }
            if (chktgp24all.Checked == true || chktgp24.Checked == true)
            {
                if (chktgp24.Checked == true)
                {
                //    txttgp24unitall.Text = txttgp24unit.Text;
                    txttgp24dayall.Text = txttgp24day.Text;
                    txttgp24rateall.Text = txttgp24rate.Text;
                }
                mymessage = mymessage + Messagebody("24", txttgp24scall.Text, "Total Gas Power Energy ", txttgp24dayall.Text, txttgp24dayall.Text, txttgp24rateall.Text, "tgp");

            }

            if (chktgp36all.Checked == true || chktgp36.Checked == true)
            {
                if (chktgp36.Checked == true)
                {
                  //  txttgp36unitall.Text = txttgp36unit.Text;
                    txttgp36dayall.Text = txttgp36day.Text;
                    txttgp36rateall.Text = txttgp36rate.Text;
                }
                mymessage = mymessage + Messagebody("36", txttgp36scall.Text, "Total Gas Power Energy ", txttgp36dayall.Text, txttgp36dayall.Text, txttgp36rateall.Text, "tgp");

            }
            if (chktgp48all.Checked == true || chktgp48.Checked == true)
            {
                if (chktgp48.Checked == true)
                {
                    //txttgp48unitall.Text = txttgp48unit.Text;
                    txttgp48dayall.Text = txttgp48day.Text;
                    txttgp48rateall.Text = txttgp48rate.Text;
                }
                mymessage = mymessage + Messagebody("48", txttgp48scall.Text, "Total Gas Power Energy ", txttgp48dayall.Text, txttgp48dayall.Text, txttgp48rateall.Text, "tgp");

            }

            if (chktgp60all.Checked == true || chktgp60.Checked == true)
            {
                if (chktgp60.Checked == true)
                {
                    //txttgp60unitall.Text = txttgp60unit.Text;
                    txttgp60dayall.Text = txttgp60day.Text;
                    txttgp60rateall.Text = txttgp60rate.Text;
                }
                mymessage = mymessage + Messagebody("60", txttgp60scall.Text, "Total Gas Power Energy ", txttgp60dayall.Text, txttgp60dayall.Text, txttgp60rateall.Text, "tgp");

            }

            // opus

            if (chkopus12all.Checked == true || chkopus12.Checked == true)
            {
                if (chkopus12.Checked == true)
                {
                  //  txtopus12unitall.Text = txtopus12unit.Text;
                    txtopus12dayall.Text = txtopus12day.Text;
                    txtopus12rateall.Text = txtopus12rate.Text;
                }


                mymessage = mymessage + Messagebody("12", txtopus12scall.Text, "OPUS Energy ", txtopus12dayall.Text, txtopus12dayall.Text, txtopus12rateall.Text, "OPUS");

            }

            if (chkopus24all.Checked == true || chkopus24.Checked == true)
            {
                if (chkopus24.Checked == true)
                {
                 //   txtopus24unitall.Text = txtopus24unit.Text;
                    txtopus24dayall.Text = txtopus24day.Text;
                    txtopus24rateall.Text = txtopus24rate.Text;
                }
                mymessage = mymessage + Messagebody("24", txtopus24scall.Text, "OPUS Energy ", txtopus24dayall.Text, txtopus24dayall.Text, txtopus24rateall.Text, "OPUS");

            }

            if (chkopus36all.Checked == true || chkopus36.Checked == true)
            {
                if (chkopus36.Checked == true)
                {
                  //  txtopus36unitall.Text = txtopus36unit.Text;
                    txtopus36dayall.Text = txtopus36day.Text;
                    txtopus36rateall.Text = txtopus36rate.Text;
                }
                mymessage = mymessage + Messagebody("36", txtopus24scall.Text, "OPUS Energy ", txtopus36dayall.Text, txtopus36dayall.Text, txtopus36rateall.Text, "OPUS");

            }

            if (chkopus48all.Checked == true || chkopus48.Checked == true)
            {
                if (chkopus48.Checked == true)
                {
                  //  txtopus48unitall.Text = txtopus48unit.Text;
                    txtopus48dayall.Text = txtopus48day.Text;
                    txtopus48rateall.Text = txtopus48rate.Text;
                }
                mymessage = mymessage + Messagebody("48", txtopus24scall.Text, "OPUS Energy ", txtopus48dayall.Text, txtopus48dayall.Text, txtopus48rateall.Text, "OPUS");

            }

            //

            if (chkeon12all.Checked == true || chkeon12.Checked == true)
            {
                if (chkeon12.Checked == true)
                {
                  //  txteon12unitall.Text = txteon12unit.Text;
                    txteon12dayall.Text = txteon12day.Text;
                    txteon12rateall.Text = txteon12rate.Text;
                }

                mymessage = mymessage + Messagebody("12", txteon12scall.Text, "EON ", txteon12dayall.Text, txteon12dayall.Text, txteon12rateall.Text, "EON");

            }

            if (chkeon24all.Checked == true || chkeon24.Checked == true)
            {
                if (chkeon24.Checked == true)
                {
                //    txteon24unitall.Text = txteon24unit.Text;
                    txteon24dayall.Text = txteon24day.Text;
                    txteon24rateall.Text = txteon24rate.Text;
                }
                mymessage = mymessage + Messagebody("24", txteon12scall.Text, "EON ", txteon24dayall.Text, txteon24dayall.Text, txteon24rateall.Text, "EON");

            }

            if (chkeon36all.Checked == true || chkeon36.Checked == true)
            {
                if (chkeon36.Checked == true)
                {
                 //   txteon36unitall.Text = txteon24unit.Text;
                    txteon36dayall.Text = txteon24day.Text;
                    txteon36rateall.Text = txteon24rate.Text;
                }
                mymessage = mymessage + Messagebody("36", txteon36scall.Text, "EON ", txteon36dayall.Text, txteon36dayall.Text, txteon36rateall.Text, "EON");

            }



            return mymessage;
        }
       


        
        static SmtpClient GetSmtpClient(string host, int port, string user, string password, bool enableSsl)
        {
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Host = host;
            smtpClient.Port = port;
            NetworkCredential cred = new NetworkCredential(user, password);
            smtpClient.EnableSsl = enableSsl;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Timeout = 35000;
            smtpClient.Credentials = cred;
            return smtpClient;
        }




        protected void SendEmail_Click(object sender, EventArgs e)
        {

            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Ok  Email has been sent!')", true);
                if (ddProvider.Text == "Select")
                {
                    lblMessage.Text = "Please Select Sender";

                }
                else
                {
                    string mymessagebody = Finalmessage();
                    Sendemailwithimg(mymessagebody);

                }

            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You clicked NO! So Email is not being sent')", true);
            }







          
           
        }
      


        void Calculation()
        {
            bga12();
            bga24();
            bga36();
            bga60();
            bga48();
            bga12all();
            bga24all();
            bga36all();
            bga60all();
            bga48all();
            bge12();
            Bge24();
            Bge36();
            Bge48();
            Bge12all();
            Bge24all();
            Bge36all();
            Bge48all();
            Bgl12();
            Bgl24();
            Bgl36();
            Bgl48();
            Bgl12all();
            Bgl24all();
            Bgl36all();
            Bgl48all();
            Bgle12();
            Bgle24();
            Bgle36();
            Bgle48();
            Bgle12all();
            Bgle24all();
            Bgle36all();
            Bgle48all();
            Edf12();
            Edf24();
            Edf36();
            Edf48();
            Edf12all();
            Edf24all();
            Edf36all();
            Edf48all();
            De12();
            De24();
            De36();
            De60();
            De12all();
            De24all();
            De36all();
            De60all();
            Pe12();
            Pe24();
            Pe36();
            Pe12all();
            Pe24all();
            Gaz12();
            Gaz24();
            Gaz36();
            Gaz12all();
            Gaz24all();
            Gaz36all();
            npower12();
            npower24();
            npower36();
            npower12all();
            npower24all();
            npower36all();
            tgp12();
            tgp24();
            tgp36();
            tgp48();
            tgp60();
            tgp12all();
            tgp24all();
            tgp36all();
            tgp48all();
            tgp60all();
            SSE12();
            SSE12NONAMR();
            SSE12all();
            SSE12NONAMRAll();


            SSE24();
            SSE24NONAMR();
            SSE24all();
            SSE24NONAMRAll();

            SSE36();
            SSE36NONAMR();
            SSE36all();
            SSE36NONAMRAll();

            Spe12();
            Spe24();
            Spe36();

            Spe12all();
            Spe24all();
            Spe36all();

            Opus12();
            Opus24();
            Opus36();
            Opus48();

            Opus12all();
            Opus24all();
            Opus36all();
            Opus48all();

            Eon12();
            Eon24();
            Eon36();
            Eon48();

            Eon12all();
            Eon24all();
            Eon36all();
            Eon48all();




        }

        void Arrange12()
        {
            DataTable dataTable = new DataTable();
           
            dataTable.Columns.Add("Provider");
            dataTable.Columns.Add("Duration");
            dataTable.Columns.Add("Standing Charge");
            dataTable.Columns.Add("Day Rates");
            dataTable.Columns.Add("Night Rates");
            dataTable.Columns.Add("Evening Rates ");
         
            dataTable.Columns.Add("Offpeak  Rates");
            dataTable.Columns.Add("Amount", typeof(double));

            dataTable.Rows.Add("British Gas", "12", txtbga12sc.Text, txtbga12day.Text, txtbga12night.Text, txtbga12ew.Text, txtbga12offpeak.Text , txtbga12rate.Text);
            dataTable.Rows.Add("British Gas Renewal", "12", txtbge12sc.Text, txtbge12day.Text, txtbge12night.Text, txtbge12ew.Text,  txtbge12offpeak.Text, txtbge12rate.Text);

            dataTable.Rows.Add("British Gas Lite", "12", txtbgla12sc.Text, txtbgla12day.Text, txtbgla12night.Text, txtbgla12ew.Text, txtbgla12offpeak.Text, txtbgla12rate.Text);
            dataTable.Rows.Add("British Gas Lite Renewal", "12", txtbgle12sc.Text, txtbgle12day.Text, txtbgle12night.Text, txtbgle12ew.Text, txtbgle12offpeak.Text, txtbgle12rate.Text);

            dataTable.Rows.Add("EDF", "12", txtedfa12sc.Text, txtedfa12day.Text, txtedfa12night.Text, txtedfa12ew.Text, txtedfa12offpeak.Text, txtEdf12Rate.Text);
            dataTable.Rows.Add("Duel", "12", txtdea12sc.Text, txtdea12sc.Text, txtdea12night.Text, txtdea12ew.Text, txtdea12offpeak.Text, txtde12rate.Text);

            dataTable.Rows.Add("Gaz Pron", "12", txtgaz12sc.Text, txtgaz12day.Text, txtgaz12night.Text, txtgaz12ew.Text, txtgaz12offpeak.Text, txtgaz12rate.Text);
            dataTable.Rows.Add("NPower", "12", txtnpra12sc.Text, txtnpra12day.Text, txtnpra12night.Text, txtnpra12ew.Text, txtnpra12offpeak.Text, txtnpra12rate.Text);

            dataTable.Rows.Add("SSE AMR", "12", txtsse12scamr.Text, txtsse12day.Text, txtsse12night.Text, txtsse12ew.Text, txtsse12offpeak.Text, txtsse12rate.Text);
            dataTable.Rows.Add("SSE NON AMR", "12", txtsse12scnonamr.Text, txtsse12day.Text, txtsse12night.Text, txtsse12ew.Text, txtsse12offpeak.Text, txtsse12ratenonamr.Text);

            dataTable.Rows.Add("Scottish Power", "12", txtspe12sc.Text, txtspe12day.Text, txtspe12night.Text, txtspe12ew.Text, txtspe12offpeak.Text, txtspe12rate.Text);
            dataTable.Rows.Add("TGP", "12", txttgp12sc.Text, txttgp12day.Text, txttgp12night.Text, txttgp12ew.Text,txttgp12offpeak.Text,txttgp12rate.Text);

            dataTable.Rows.Add("EON", "12", txteon12sc.Text, txteon12day.Text, txteon12night.Text, txteon12ew.Text, txteon12offpeak.Text, txteon12rate.Text);
            dataTable.Rows.Add("OPUS", "12", txtopus12sc.Text, txtopus12day.Text, txtopus12night.Text, txtopus12ew.Text,  txtopus12offpeak.Text, txtopus12rate.Text);

            dataTable.Rows.Add("HEven", "12", txthev12sc.Text, txthev12day.Text, txthev12night.Text, txthev12ew.Text, txthev12offpeak.Text, txthev12rate.Text);
            dataTable.Rows.Add("Heven without Standing", "12", txthevc12sc.Text, txthevc12day.Text, txthevc12night.Text, txthevc12ew.Text, txthevc12offpeak.Text, txthevc12rate.Text);





            DataView _dv = new DataView(dataTable);
            _dv.Sort = "Amount ASC";

          
            gvResult12.DataSource = _dv;
            gvResult12.AllowSorting = true;

            gvResult12.DataBind();
           

        }

        void Arrange24()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Provider");
            dataTable.Columns.Add("Duration");
            dataTable.Columns.Add("Standing Charge");
            dataTable.Columns.Add("Day Rates");
            dataTable.Columns.Add("Night Rates");
            dataTable.Columns.Add("Evening Rates ");
            
            dataTable.Columns.Add("Offpeak  Rates");
            dataTable.Columns.Add("Amount", typeof(double));

            dataTable.Rows.Add("British Gas", "24", txtbga24sc.Text, txtbga24day.Text, txtbga24night.Text, txtbga24ew.Text,  txtbga24offpeak.Text, txtbga24rate.Text);
            dataTable.Rows.Add("British Gas Renewal", "24", txtbge24sc.Text, txtbge24day.Text, txtbge24night.Text, txtbge24ew.Text, txtbge24offpeak.Text, txtbfge24rate.Text);

            dataTable.Rows.Add("British Gas Lite", "24", txtbgla24sc.Text, txtbgla24day.Text, txtbgla24night.Text, txtbgla24ew.Text,  txtbgla24offpeak.Text, txtbfgla24rate.Text);
            dataTable.Rows.Add("British Gas Lite Renewal", "24", txtbgle24sc.Text, txtbgle24day.Text, txtbgle24night.Text, txtbgle24ew.Text, txtbgle24offpeak.Text, txtbgle24rate.Text);

            dataTable.Rows.Add("EDF", "24", txtedfa24sc.Text, txtedfa24day.Text, txtedfa24night.Text, txtedfa24ew.Text,  txtedfa24offpeak.Text, txtEdf24Rate.Text);
            dataTable.Rows.Add("Duel", "24", txtdea24sc.Text, txtdea24sc.Text, txtdea24night.Text, txtdea24ew.Text,  txtdea24offpeak.Text, txtde24rate.Text);

            dataTable.Rows.Add("Gaz Pron", "24", txtgaz24sc.Text, txtgaz24day.Text, txtgaz24night.Text, txtgaz24ew.Text, txtgaz24offpeak.Text, txtgaz24rate.Text);
            dataTable.Rows.Add("NPower", "24", txtnpra24sc.Text, txtnpra24day.Text, txtnpra24night.Text, txtnpra24ew.Text,  txtnpra24offpeak.Text, txtnpra24rate.Text);

            dataTable.Rows.Add("Scottish Power", "24", txtspe24sc.Text, txtspe24day.Text, txtspe24night.Text, txtspe24ew.Text,  txtspe24offpeak.Text, txtspe24rate.Text);
            dataTable.Rows.Add("TGP", "24", txttgp24sc.Text, txttgp24day.Text, txttgp24night.Text, txttgp24ew.Text, txttgp24offpeak.Text, txttgp24rate.Text);

            dataTable.Rows.Add("EON", "24", txteon24sc.Text, txteon24day.Text, txteon24night.Text, txteon24ew.Text, txteon24offpeak.Text, txteon24rate.Text);
            dataTable.Rows.Add("OPUS", "24", txtopus24sc.Text, txtopus24day.Text, txtopus24night.Text, txtopus24ew.Text, txtopus24offpeak.Text, txtopus24rate.Text);

            dataTable.Rows.Add("HEven", "24", txthev24sc.Text, txthev24day.Text, txthev24night.Text, txthev24ew.Text, txthev24offpeak.Text, txthev24rate.Text);
            dataTable.Rows.Add("Heven without Standing", "24", txthevc24sc.Text, txthevc24day.Text, txthevc24night.Text, txthevc24ew.Text, txthevc24offpeak.Text, txthevc24rate.Text);

            DataView _dv = new DataView(dataTable);
            _dv.Sort = "Amount ASC";

           
            gvResult24.DataSource = _dv;
            gvResult24.AllowSorting = true;

            gvResult24.DataBind();

        }

        void Arrange36()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Provider");
            dataTable.Columns.Add("Duration");
            dataTable.Columns.Add("Standing Charge");
            dataTable.Columns.Add("Day Rates");
            dataTable.Columns.Add("Night Rates");
            dataTable.Columns.Add("Evening Rates ");
           
            dataTable.Columns.Add("Offpeak  Rates");
            dataTable.Columns.Add("Amount", typeof(double));

            dataTable.Rows.Add("British Gas", "36", txtbga36sc.Text, txtbga36day.Text, txtbga36night.Text, txtbga36ew.Text,  txtbga36offpeak.Text, txtbga36rate.Text);
            dataTable.Rows.Add("British Gas Renewal", "36", txtbge36sc.Text, txtbge36day.Text, txtbge36night.Text, txtbge36ew.Text,  txtbge36offpeak.Text, txtbfge36rate.Text);

            dataTable.Rows.Add("British Gas Lite", "36", txtbgla36sc.Text, txtbgla36day.Text, txtbgla36night.Text, txtbgla36ew.Text, txtbgla36offpeak.Text, txtbfgla36rate.Text);
            dataTable.Rows.Add("British Gas Lite Renewal", "36", txtbgle36sc.Text, txtbgle36day.Text, txtbgle36night.Text, txtbgle36ew.Text, txtbgle36offpeak.Text, txtbgle36rate.Text);

            dataTable.Rows.Add("EDF", "36", txtedfa36sc.Text, txtedfa36day.Text, txtedfa36night.Text, txtedfa36ew.Text,  txtedfa36offpeak.Text, txtEdf36Rate.Text);
            dataTable.Rows.Add("Duel", "36", txtdea36sc.Text, txtdea36sc.Text, txtdea36night.Text, txtdea36ew.Text, txtdea36offpeak.Text, txtde36rate.Text);

            dataTable.Rows.Add("Gaz Pron", "36", txtgaz36sc.Text, txtgaz36day.Text, txtgaz36night.Text, txtgaz36ew.Text,  txtgaz36offpeak.Text, txtgaz36rate.Text);
            dataTable.Rows.Add("NPower", "36", txtnpra36sc.Text, txtnpra36day.Text, txtnpra36night.Text, txtnpra36ew.Text, txtnpra36offpeak.Text, txtnpra36rate.Text);

            
            dataTable.Rows.Add("Scottish Power", "36", txtspe36sc.Text, txtspe36day.Text, txtspe36night.Text, txtspe36ew.Text,  txtspe36offpeak.Text, txtspe36rate.Text);
            dataTable.Rows.Add("TGP", "36", txttgp36sc.Text, txttgp36day.Text, txttgp36night.Text, txttgp36ew.Text, txttgp36offpeak.Text, txttgp36rate.Text);

            dataTable.Rows.Add("EON", "36", txteon36sc.Text, txteon36day.Text, txteon36night.Text, txteon36ew.Text, txteon36offpeak.Text, txteon36rate.Text);
            dataTable.Rows.Add("OPUS", "36", txtopus36sc.Text, txtopus36day.Text, txtopus36night.Text, txtopus36ew.Text,  txtopus36offpeak.Text, txtopus36rate.Text);

            dataTable.Rows.Add("HEven", "36", txthev36sc.Text, txthev36day.Text, txthev36night.Text, txthev36ew.Text, txthev36offpeak.Text, txthev36rate.Text);
            dataTable.Rows.Add("Heven without Standing", "36", txthevc36sc.Text, txthevc36day.Text, txthevc36night.Text, txthevc36ew.Text, txthevc36offpeak.Text, txthevc36rate.Text);



            DataView _dv = new DataView(dataTable);
            _dv.Sort = "Amount ASC";

            Multiview1.SetActiveView(Result);
            gvResult36.DataSource = _dv;
            gvResult36.AllowSorting = true;

            gvResult36.DataBind();

        }

        void Arrange48()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Provider");
            dataTable.Columns.Add("Duration");
            dataTable.Columns.Add("Standing Charge");
            dataTable.Columns.Add("Day Rates");
            dataTable.Columns.Add("Night Rates");
            dataTable.Columns.Add("Evening Rates ");
          
            dataTable.Columns.Add("Offpeak  Rates");
            dataTable.Columns.Add("Amount", typeof(double));

            dataTable.Rows.Add("British Gas", "48", txtbga48sc.Text, txtbga48day.Text, txtbga48night.Text, txtbga48ew.Text, txtbga48offpeak.Text, txtbga48rate.Text);
            dataTable.Rows.Add("British Gas Renewal", "48", txtbge48sc.Text, txtbge48day.Text, txtbge48night.Text, txtbge48ew.Text, txtbge48offpeak.Text, txtbfge48rate.Text);

            dataTable.Rows.Add("British Gas Lite", "48", txtbgla48sc.Text, txtbgla48day.Text, txtbgla48night.Text, txtbgla48ew.Text, txtbgla48offpeak.Text, txtbfgla48rate.Text);
            dataTable.Rows.Add("British Gas Lite Renewal", "48", txtbgle48sc.Text, txtbgle48day.Text, txtbgle48night.Text, txtbgle48ew.Text,  txtbgle48offpeak.Text, txtbgle48rate.Text);

            dataTable.Rows.Add("EDF", "48", txtedfa48sc.Text, txtedfa48day.Text, txtedfa48night.Text, txtedfa48ew.Text,  txtedfa48offpeak.Text, txtEdf48Rate.Text);
            dataTable.Rows.Add("Duel", "48", txtdea48sc.Text, txtdea48sc.Text, txtdea48night.Text, txtdea48ew.Text, txtdea48offpeak.Text, txtdea48rateall.Text);

            dataTable.Rows.Add("TGP", "48", txttgp48sc.Text, txttgp48day.Text, txttgp48night.Text, txttgp48ew.Text, txttgp48offpeak.Text, txttgp48rate.Text);

            dataTable.Rows.Add("EON", "48", txteon48sc.Text, txteon48day.Text, txteon48night.Text, txteon48ew.Text, txteon48offpeak.Text, txteon48rate.Text);
            // dataTable.Rows.Add("OPUS", "48", txtopus48sc.Text, txtopus48day.Text, txtopus48night.Text, txtopus48unit.Text, txtopus48offpeak.Text, txtopus48rate.Text);


            dataTable.Rows.Add("Heven", "48", txthev48sc.Text, txthev48day.Text, txthev48night.Text, txthev48ew.Text, txthev48offpeak.Text, txthev48rate.Text);
            dataTable.Rows.Add("Heven without Standing", "48", txthevc48sc.Text, txthevc48day.Text, txthevc48night.Text, txthevc48ew.Text, txthevc48offpeak.Text, txthevc48rate.Text);
            DataView _dv = new DataView(dataTable);
            _dv.Sort = "Amount ASC";

          
            gvResult48.DataSource = _dv;
            gvResult48.AllowSorting = true;

            gvResult48.DataBind();

        }

        void Arrange60()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Provider");
            dataTable.Columns.Add("Duration");
            dataTable.Columns.Add("Standing Charge");
            dataTable.Columns.Add("Day Rates");
            dataTable.Columns.Add("Night Rates");
            dataTable.Columns.Add("Evening Rates ");
           
            dataTable.Columns.Add("Offpeak  Rates");
            dataTable.Columns.Add("Amount", typeof(double));

            dataTable.Rows.Add("British Gas", "60", txtbga60sc.Text, txtbga60day.Text, txtbga60night.Text, txtbga60ew.Text, txtbga60offpeak.Text, txtbga60rate.Text);
            dataTable.Rows.Add("British Gas Renewal", "60", txtbge60sc.Text, txtbge60day.Text, txtbge60night.Text, txtbge60ew.Text, txtbge60offpeak.Text, txtbfge60rate.Text);

            dataTable.Rows.Add("British Gas Lite", "60", txtbgla60sc.Text, txtbgla60day.Text, txtbgla60night.Text, txtbgla60ew.Text, txtbgla60offpeak.Text, txtbfgla60rate.Text);
            dataTable.Rows.Add("British Gas Lite Renewal", "60", txtbgle60sc.Text, txtbgle60day.Text, txtbgle60night.Text, txtbgle60ew.Text, txtbgle60offpeak.Text, txtbfgle60rate.Text);

            dataTable.Rows.Add("EDF", "60", txtedfa60sc.Text, txtedfa60day.Text, txtedfa60night.Text, txtedfa60ew.Text, txtedfa60offpeak.Text, txtedf60rate.Text);
            dataTable.Rows.Add("Duel", "60", txtdea60sc.Text, txtdea60sc.Text, txtdea60night.Text, txtdea60ew.Text,txtdea60offpeak.Text, txtde60rate.Text);
            dataTable.Rows.Add("TGP", "60", txttgp60sc.Text, txttgp60day.Text, txttgp60night.Text, txttgp60ew.Text, txttgp60offpeak.Text, txttgp60rate.Text);



            DataView _dv = new DataView(dataTable);
            _dv.Sort = "Amount ASC";

            
            gvResult60.DataSource = _dv;
            gvResult60.AllowSorting = true;

            gvResult60.DataBind();

        }

        protected void btnResult_Click(object sender, EventArgs e)
        {
            Multiview1.SetActiveView(Result);
            Arrange12();
            Arrange24();
            Arrange36();
            Arrange48();
            Arrange60();

        }


        #region  Proposal generatopm code with show button

        protected void btnbga12Showall_Click(object sender, EventArgs e)
        {
            string un = Session["UserName"].ToString();
            string salestype = "renewal";
            if (lblCurrentSupplier.Text == "bg" || lblCurrentSupplier.Text == "BG")
            {
                salestype = "Acquisition";
            }

            string allunit = "0";

            allunit = txtbga12dayall.Text;


            string TL = Session["mytl"].ToString();
            string MPR = "";
            string SupplyNumber = Session["mpan"].ToString();
            string quot = ps.Storebasicdetas(txtBusiness.Text, un, lblCurrentSupplier.Text, "electricity", lblProfile.Text + lblMTC.Text + lblRegion.Text, lblStartdate.Text, "12", winclose, txtBusiness.Text, lblCurrentSupplier.Text, "BG", lblELEPayment.Text, "NO", lblEac.Text, salestype, txtBusiness.Text, allunit, txtbga12upliftall.Text, txtbga12rateall.Text, txtbga12scall.Text, txtbga12rateall.Text, TL, SupplyNumber, MPR, txtbga12nightall.Text, txtbga12ewall.Text, allunit, txtbga12offpeakall.Text);
            Response.Redirect("quotstion.aspx?prop=" + quot);



        }

        protected void btnbga12Show_Click(object sender, EventArgs e)
        {
            string un = Session["UserName"].ToString();
            string salestype = "renewal";
            if (lblCurrentSupplier.Text == "bg" || lblCurrentSupplier.Text == "BG")
            {
                salestype = "Acquisition";
            }

            string allunit = "0";
            
                allunit = txtbga12day.Text;
           

            string TL = Session["mytl"].ToString();
            string MPR = "";
            string SupplyNumber = Session["mpan"].ToString();
            string quot = ps.Storebasicdetas(txtBusiness.Text, un, lblCurrentSupplier.Text, "electricity", lblProfile.Text + lblMTC.Text + lblRegion.Text, lblStartdate.Text, "12", winclose, txtBusiness.Text, lblCurrentSupplier.Text, "BG", lblELEPayment.Text, "NO", lblEac.Text, salestype, txtBusiness.Text, allunit, txtbga12uplift.Text, txtbga12rate.Text, txtbga12sc.Text, txtbga12rate.Text, TL, SupplyNumber, MPR, txtbga12night.Text, txtbga12ew.Text, allunit, txtbga12offpeak.Text);
            Response.Redirect("quotstion.aspx?prop=" + quot);

        }

        protected void btnbge12show_Click(object sender, EventArgs e)
        {
            string un = Session["UserName"].ToString();
            string salestype = "renewal";
            if (lblCurrentSupplier.Text == "bg")
            {
                salestype = "Acquisition";
            }

          
           string     allunit = txtbga12day.Text;
          

            string TL = Session["mytl"].ToString();
            string MPR = "";
            string SupplyNumber = Session["mpan"].ToString();
            string quot = ps.Storebasicdetas(txtBusiness.Text, un, lblCurrentSupplier.Text, "electricity", lblProfile.Text + lblMTC.Text + lblRegion.Text, lblStartdate.Text, "12", winclose, txtBusiness.Text, lblCurrentSupplier.Text, "BG", lblELEPayment.Text, "NO", lblEac.Text, salestype, txtBusiness.Text, allunit , txtbge12uplift.Text, txtbge12rate.Text, txtbge12sc.Text, txtbge12rate.Text, TL, SupplyNumber, MPR, txtbge12night.Text, txtbge12ew.Text, allunit, txtbge12offpeak.Text);
            Response.Redirect("quotstion.aspx?prop=" + quot);

        }

        protected void btnbgla12_Click(object sender, EventArgs e)
        {
            string un = Session["UserName"].ToString();
            string salestype = "Acquisition";

            string allunit = txtbga12day.Text;


            string TL = Session["mytl"].ToString();
            string MPR = "";
            string SupplyNumber = Session["mpan"].ToString();
            string quot = ps.Storebasicdetas(txtBusiness.Text, un, lblCurrentSupplier.Text, "electricity", lblProfile.Text + lblMTC.Text + lblRegion.Text, lblStartdate.Text, "12", winclose, txtBusiness.Text, lblCurrentSupplier.Text, "BGL", lblELEPayment.Text, "NO", lblEac.Text, salestype, txtBusiness.Text, allunit, txtbgla12uplift.Text, txtbgla12rate.Text, txtbgla12sc.Text, txtbgla12rate.Text, TL, SupplyNumber, MPR, txtbgla12night.Text, txtbgla12ew.Text, allunit, txtbgla12offpeak.Text);
            Response.Redirect("quotstion.aspx?prop=" + quot);

        }

        protected void btnBgle_Click(object sender, EventArgs e)
        {
            string un = Session["UserName"].ToString();
            string salestype = "renewal";
            if (lblCurrentSupplier.Text == "bgl")
            {
                salestype = "Acquisition";
            }

            string allunit = "0";
        
          
                allunit = txtbgle12day.Text;
           



            string TL = Session["mytl"].ToString();
            string MPR = "1234567";
            string SupplyNumber = Session["mpan"].ToString();
            string quot = ps.Storebasicdetas(txtBusiness.Text, un, lblCurrentSupplier.Text, "electricity", lblProfile.Text + lblMTC.Text + lblRegion.Text, lblStartdate.Text, "12", winclose, txtBusiness.Text, lblCurrentSupplier.Text, "BGL", lblELEPayment.Text, "NO", lblEac.Text, salestype, txtBusiness.Text, allunit, txtbgle12uplift.Text, txtbgle12rate.Text, txtbgle12sc.Text, txtbgle12rate.Text, TL, SupplyNumber, MPR, txtbgle12night.Text, txtedfa12ew.Text, allunit, txtedfa12offpeak.Text);
            Response.Redirect("quotstion.aspx?prop=" + quot);

        }

        protected void btnedf12_Click(object sender, EventArgs e)
        {
            string un = Session["UserName"].ToString();
            string salestype = "renewal";
            if (lblCurrentSupplier.Text == "EDF" || lblCurrentSupplier.Text =="edf")
            {
                salestype = "Acquisition";
            }
           
            
           string     allunit = txtedfa12day.Text;
           

            string TL = Session["mytl"].ToString();
            string MPR = "";
            string SupplyNumber = Session["mpan"].ToString();
            string quot = ps.Storebasicdetas(txtBusiness.Text, un, lblCurrentSupplier.Text, "electricity", lblProfile.Text + lblMTC.Text + lblRegion.Text, lblStartdate.Text, "12", winclose, txtBusiness.Text, lblCurrentSupplier.Text, "EDF", lblELEPayment.Text, "NO", lblEac.Text, salestype, txtBusiness.Text, allunit, txtedfa12uplift.Text, txtbgle12rate.Text, txtedfa12sc.Text, txtedf12rateall.Text, TL, SupplyNumber, MPR, txtbgle12night.Text, txtbgle12ew.Text,allunit, txtbgle12offpeak.Text);
            Response.Redirect("quotstion.aspx?prop=" + quot);

        }

        protected void btnde12_Click(object sender, EventArgs e)
        {
            string un = Session["UserName"].ToString();
            string salestype = "renewal";
            if (lblCurrentSupplier.Text == "DE" || lblCurrentSupplier.Text == "duel")
            {
                salestype = "Acquisition";
            }
            string allunit = "0";
          
                allunit = txtdea12day.Text;
          

            string TL = Session["mytl"].ToString();
            string MPR = "";
            string SupplyNumber = Session["mpan"].ToString();
            string quot = ps.Storebasicdetas(txtBusiness.Text, un, lblCurrentSupplier.Text, "electricity", lblProfile.Text + lblMTC.Text + lblRegion.Text, lblStartdate.Text, "12", winclose, txtBusiness.Text, lblCurrentSupplier.Text, "DE", lblELEPayment.Text, "NO", lblEac.Text, salestype, txtBusiness.Text, allunit, txtdea12uplift.Text, txtde12rate.Text, txtdea12sc.Text, txtde12rate.Text, TL, SupplyNumber, MPR, txtdea12night.Text, txtdea12ew.Text,allunit, txtdea12offpeak.Text);
            Response.Redirect("quotstion.aspx?prop=" + quot);

        }

        protected void btnPE12_Click(object sender, EventArgs e)
        {
            string un = Session["UserName"].ToString();
            string salestype = "renewal";
            if (lblCurrentSupplier.Text == "PE" || lblCurrentSupplier.Text == "pozitive")
            {
                salestype = "Acquisition";
            }
            string allunit = "0";
           
                allunit = txtpe12day.Text;
            

            string TL = Session["mytl"].ToString();
            string MPR = "";
            string SupplyNumber = Session["mpan"].ToString();
            string quot = ps.Storebasicdetas(txtBusiness.Text, un, lblCurrentSupplier.Text, "electricity", lblProfile.Text + lblMTC.Text + lblRegion.Text, lblStartdate.Text, "12", winclose, txtBusiness.Text, lblCurrentSupplier.Text, "PE", lblELEPayment.Text, "NO", lblEac.Text, salestype, txtBusiness.Text, allunit, txtpe12uplift.Text, txtpe12rate.Text, txtpe12sc.Text, txtpe12rate.Text, TL, SupplyNumber, MPR, txtpe12night.Text, txtpe12ew.Text, allunit, txtpe12offpeak.Text);
            Response.Redirect("quotstion.aspx?prop=" + quot);
        }

        protected void btnGaz12_Click(object sender, EventArgs e)
        {
            string un = Session["UserName"].ToString();
            string salestype = "renewal";
            if (lblCurrentSupplier.Text == "gaz" || lblCurrentSupplier.Text == "GAZ")
            {
                salestype = "Acquisition";
            }
            string allunit = "0";
           
            
                allunit = txtgaz12day.Text;
            

            string TL = Session["mytl"].ToString();
            string MPR = "";
            string SupplyNumber = Session["mpan"].ToString();
            string quot = ps.Storebasicdetas(txtBusiness.Text, un, lblCurrentSupplier.Text, "electricity", lblProfile.Text + lblMTC.Text + lblRegion.Text, lblStartdate.Text, "12", winclose, txtBusiness.Text, lblCurrentSupplier.Text, "GAZ", lblELEPayment.Text, "NO", lblEac.Text, salestype, txtBusiness.Text, allunit, txtgaz12uplift.Text, txtgaz12rate.Text, txtgaz12sc.Text, txtgaz12rate.Text, TL, SupplyNumber, MPR, txtgaz12night.Text, txtgaz12ew.Text, allunit, txtgaz12offpeak.Text);
            Response.Redirect("quotstion.aspx?prop=" + quot);
        }

        protected void btnsse12amr_Click(object sender, EventArgs e)
        {
            string un = Session["UserName"].ToString();
            string salestype = "renewal";
            if (lblCurrentSupplier.Text == "SSE" || lblCurrentSupplier.Text == "sse")
            {
                salestype = "Acquisition";
            }
            string allunit = txtsse12day.Text;
            string TL = Session["mytl"].ToString();
            string MPR = "";
            string SupplyNumber = Session["mpan"].ToString();
            string quot = ps.Storebasicdetas(txtBusiness.Text, un, lblCurrentSupplier.Text, "electricity", lblProfile.Text + lblMTC.Text + lblRegion.Text, lblStartdate.Text, "12", winclose, txtBusiness.Text, lblCurrentSupplier.Text, "SSE AMR", lblELEPayment.Text, "NO", lblEac.Text, salestype, txtBusiness.Text, txtedfa12day.Text, txtedfa12uplift.Text, txtbgle12rate.Text, txtedfa12sc.Text, txtedf12rateall.Text, TL, SupplyNumber, MPR, txtbgle12night.Text, txtbgle12ew.Text, allunit, txtbgle12offpeak.Text);
            Response.Redirect("quotstion.aspx?prop=" + quot);

        }

        protected void btnsse12nonamr_Click(object sender, EventArgs e)
        {
            string un = Session["UserName"].ToString();
            string salestype = "renewal";
            if (lblCurrentSupplier.Text == "SSE" || lblCurrentSupplier.Text == "sse")
            {
                salestype = "Acquisition";
            }
            string allunit = txtsse12day.Text;
            string TL = Session["mytl"].ToString();
            string MPR = "";
            string SupplyNumber = Session["mpan"].ToString();
            string quot = ps.Storebasicdetas(txtBusiness.Text, un, lblCurrentSupplier.Text, "electricity", lblProfile.Text + lblMTC.Text + lblRegion.Text, lblStartdate.Text, "12", winclose, txtBusiness.Text, lblCurrentSupplier.Text, "SSE AMR", lblELEPayment.Text, "NO", lblEac.Text, salestype, txtBusiness.Text, txtsse12day.Text, txtsse12uplift.Text, txtsse12rate.Text, txtsse12scamr.Text, txtsse12rate.Text, TL, SupplyNumber, MPR, txtsse12night.Text, txtsse12ew.Text, allunit, txtsse12offpeak.Text);
            Response.Redirect("quotstion.aspx?prop=" + quot);

        }

        protected void btnNpr12_Click(object sender, EventArgs e)
        {
            string un = Session["UserName"].ToString();
            string salestype = "renewal";
            if (lblCurrentSupplier.Text == "Npower" || lblCurrentSupplier.Text == "NPOWER" || lblCurrentSupplier.Text == "NPR")
            {
                salestype = "Acquisition";
            }
            string allunit = "0";
            
                allunit = txtnpra12day.Text;
            

            string TL = Session["mytl"].ToString();
            string MPR = "";
            string SupplyNumber = Session["mpan"].ToString();
            string quot = ps.Storebasicdetas(txtBusiness.Text, un, lblCurrentSupplier.Text, "electricity", lblProfile.Text + lblMTC.Text + lblRegion.Text, lblStartdate.Text, "12", winclose, txtBusiness.Text, lblCurrentSupplier.Text, "NPOWER", lblELEPayment.Text, "NO", lblEac.Text, salestype, txtBusiness.Text, txtnpra12day.Text, allunit, txtnpra12rate.Text, txtnpra12sc.Text, txtnpra12rate.Text, TL, SupplyNumber, MPR, txtnpra12night.Text, txtnpra12ew.Text,allunit, txtnpra12offpeak.Text);
            Response.Redirect("quotstion.aspx?prop=" + quot);

        }

        protected void btnSpe12_Click(object sender, EventArgs e)
        {
            string un = Session["UserName"].ToString();
            string salestype = "renewal";
            if (lblCurrentSupplier.Text == "SPE" || lblCurrentSupplier.Text == "SCO" || lblCurrentSupplier.Text == "Spe")
            {
                salestype = "Acquisition";
            }

            string allunit = "0";
           
                allunit = txtspe12day.Text;
           

            string TL = Session["mytl"].ToString();
            string MPR = "";
            string SupplyNumber = Session["mpan"].ToString();
            string quot = ps.Storebasicdetas(txtBusiness.Text, un, lblCurrentSupplier.Text, "electricity", lblProfile.Text + lblMTC.Text + lblRegion.Text, lblStartdate.Text, "12", winclose, txtBusiness.Text, lblCurrentSupplier.Text, "SPE", lblELEPayment.Text, "NO", lblEac.Text, salestype, txtBusiness.Text, allunit , txtspe12uplift.Text, txtspe12rate.Text, txtspe12sc.Text, txtspe12rate.Text, TL, SupplyNumber, MPR, txtspe12night.Text, txtspe12ew.Text, allunit, txtspe12offpeak.Text);
            Response.Redirect("quotstion.aspx?prop=" + quot);

        }

        protected void btnTgp12_Click(object sender, EventArgs e)
        {
            string un = Session["UserName"].ToString();
            string salestype = "renewal";
            if (lblCurrentSupplier.Text == "tgp" || lblCurrentSupplier.Text == "TGP" || lblCurrentSupplier.Text == "Tgp")
            {
                salestype = "Acquisition";
            }
            string allunit = "0";
            
            
                allunit = txttgp12day.Text;
           

            string TL = Session["mytl"].ToString();
            string MPR = "";
            string SupplyNumber = Session["mpan"].ToString();
            string quot = ps.Storebasicdetas(txtBusiness.Text, un, lblCurrentSupplier.Text, "electricity", lblProfile.Text + lblMTC.Text + lblRegion.Text, lblStartdate.Text, "12", winclose, txtBusiness.Text, lblCurrentSupplier.Text, "TGP", lblELEPayment.Text, "NO", lblEac.Text, salestype, txtBusiness.Text,allunit, txttgp12uplift.Text, txttgp12rate.Text, txttgp12sc.Text, txttgp12rate.Text, TL, SupplyNumber, MPR, txtspe12night.Text, txtspe12ew.Text,allunit, txtspe12offpeak.Text);
            Response.Redirect("quotstion.aspx?prop=" + quot + "&allunit=" + allunit + "&sc="+txttgp12sc.Text);

        }

        protected void btnBga24_Click(object sender, EventArgs e)
        {
            string un = Session["UserName"].ToString();
            string salestype = "Acquisition";
          

            string allunit = "0";
            
            
               allunit = txtbga24day.Text;
           

            string TL = Session["mytl"].ToString();
            string MPR = "";
            string SupplyNumber = Session["mpan"].ToString();
            string quot = ps.Storebasicdetas(txtBusiness.Text, un, lblCurrentSupplier.Text, "electricity", lblProfile.Text + lblMTC.Text + lblRegion.Text, lblStartdate.Text, "24", winclose, txtBusiness.Text, lblCurrentSupplier.Text, "BG", lblELEPayment.Text, "NO", lblEac.Text, salestype, txtBusiness.Text, allunit, txtbge24uplift.Text, txtbfgla24rate.Text, txtbge24sc.Text, txtbga12rate.Text, TL, SupplyNumber, MPR, txtbge24night.Text, txtbge24ew.Text, allunit, txtbge24offpeak.Text);
            Response.Redirect("quotstion.aspx?prop=" + quot);



        }

        protected void btnBge24_Click(object sender, EventArgs e)
        {

            string un = Session["UserName"].ToString();
            string salestype = "renewal";
           

            string allunit = "0";
           
                allunit = txtbge24day.Text;
           

            string TL = Session["mytl"].ToString();
            string MPR = "";
            string SupplyNumber = Session["mpan"].ToString();
            string quot = ps.Storebasicdetas(txtBusiness.Text, un, lblCurrentSupplier.Text, "electricity", lblProfile.Text + lblMTC.Text + lblRegion.Text, lblStartdate.Text, "24", winclose, txtBusiness.Text, lblCurrentSupplier.Text, "BG", lblELEPayment.Text, "NO", lblEac.Text, salestype, txtBusiness.Text, allunit, txtbge24uplift.Text, txtbfge24rate.Text, txtbge24sc.Text, txtbfge24rate.Text, TL, SupplyNumber, MPR, txtbge24night.Text, txtbge24ew.Text, allunit, txtbge24offpeak.Text);
            Response.Redirect("quotstion.aspx?prop=" + quot);

        }

        protected void btnbgla24_Click(object sender, EventArgs e)
        {
            string un = Session["UserName"].ToString();
            string salestype = "Acquisition";
           

            string allunit = "0";
           
                allunit = txtbgla24day.Text;
            
            string TL = Session["mytl"].ToString();
            string MPR = "";
            string SupplyNumber = Session["mpan"].ToString();
            string quot = ps.Storebasicdetas(txtBusiness.Text, un, lblCurrentSupplier.Text, "electricity", lblProfile.Text + lblMTC.Text + lblRegion.Text, lblStartdate.Text, "24", winclose, txtBusiness.Text, lblCurrentSupplier.Text, "BGL", lblELEPayment.Text, "NO", lblEac.Text, salestype, txtBusiness.Text, allunit, txtbgla24uplift.Text, txtbfgla24rate.Text, txtbgla24sc.Text, txtbfgla24rate.Text, TL, SupplyNumber, MPR, txtbgla24night.Text, txtbgla24ew.Text, allunit, txtbgla24offpeak.Text);
            Response.Redirect("quotstion.aspx?prop=" + quot);
            
        }

       

        protected void btnbgle24_Click(object sender, EventArgs e)
        {
            string un = Session["UserName"].ToString();
            string salestype = "renewal";
          

            string allunit = "0";
           
                allunit = txtbgle24day.Text;
           



            string TL = Session["mytl"].ToString();
            string MPR = "";
            string SupplyNumber = Session["mpan"].ToString();
            string quot = ps.Storebasicdetas(txtBusiness.Text, un, lblCurrentSupplier.Text, "electricity", lblProfile.Text + lblMTC.Text + lblRegion.Text, lblStartdate.Text, "24", winclose, txtBusiness.Text, lblCurrentSupplier.Text, "BGL", lblELEPayment.Text, "NO", lblEac.Text, salestype, txtBusiness.Text, txtbgle24day.Text, txtbgle24uplift.Text, txtbgle24rate.Text, txtbgle24sc.Text, txtbgle24rate.Text, TL, SupplyNumber, MPR, txtbgle24night.Text, txtedfa24ew.Text, allunit, txtedfa24offpeak.Text);
            Response.Redirect("quotstion.aspx?prop=" + quot);


        }

        protected void btnEDF24_Click(object sender, EventArgs e)
        {
            string un = Session["UserName"].ToString();
            string salestype = "renewal";
            if (lblCurrentSupplier.Text == "EDF" || lblCurrentSupplier.Text == "edf")
            {
                salestype = "Acquisition";
            }
            string allunit = "0";
           
                allunit = txtedfa24day.Text;
            

            string TL = Session["mytl"].ToString();
            string MPR = "";
            string SupplyNumber = Session["mpan"].ToString();
            string quot = ps.Storebasicdetas(txtBusiness.Text, un, lblCurrentSupplier.Text, "electricity", lblProfile.Text + lblMTC.Text + lblRegion.Text, lblStartdate.Text, "24", winclose, txtBusiness.Text, lblCurrentSupplier.Text, "EDF", lblELEPayment.Text, "NO", lblEac.Text, salestype, txtBusiness.Text, allunit, txtedfa24uplift.Text, txtbgle24rate.Text, txtedfa24sc.Text, txtedf24rateall.Text, TL, SupplyNumber, MPR, txtbgle24night.Text, txtbgle24ew.Text, allunit, txtbgle24offpeak.Text);
            Response.Redirect("quotstion.aspx?prop=" + quot);

        }

        protected void btnDe24_Click(object sender, EventArgs e)
        {
            string un = Session["UserName"].ToString();
            string salestype = "renewal";
            if (lblCurrentSupplier.Text == "DE" || lblCurrentSupplier.Text == "duel")
            {
                salestype = "Acquisition";
            }
            string allunit = "0";
            
                allunit = txtdea24day.Text;
           

            string TL = Session["mytl"].ToString();
            string MPR = "";
            string SupplyNumber = Session["mpan"].ToString();
            string quot = ps.Storebasicdetas(txtBusiness.Text, un, lblCurrentSupplier.Text, "electricity", lblProfile.Text + lblMTC.Text + lblRegion.Text, lblStartdate.Text, "24", winclose, txtBusiness.Text, lblCurrentSupplier.Text, "DE", lblELEPayment.Text, "NO", lblEac.Text, salestype, txtBusiness.Text, allunit, txtdea24uplift.Text, txtde24rate.Text, txtdea24sc.Text, txtde24rate.Text, TL, SupplyNumber, MPR, txtdea24night.Text, txtdea24ew.Text, allunit, txtdea24offpeak.Text);
            Response.Redirect("quotstion.aspx?prop=" + quot);

        }

        protected void btnPE24_Click(object sender, EventArgs e)
        {
            string un = Session["UserName"].ToString();
            string salestype = "renewal";
            if (lblCurrentSupplier.Text == "PE" || lblCurrentSupplier.Text == "pozitive")
            {
                salestype = "Acquisition";
            }
            string allunit = "0";
           
                allunit = txtpe24day.Text;
           

            string TL = Session["mytl"].ToString();
            string MPR = "";
            string SupplyNumber = Session["mpan"].ToString();
            string quot = ps.Storebasicdetas(txtBusiness.Text, un, lblCurrentSupplier.Text, "electricity", lblProfile.Text + lblMTC.Text + lblRegion.Text, lblStartdate.Text, "24", winclose, txtBusiness.Text, lblCurrentSupplier.Text, "PE", lblELEPayment.Text, "NO", lblEac.Text, salestype, txtBusiness.Text, allunit, txtpe24uplift.Text, txtpe24rate.Text, txtpe24sc.Text, txtpe24rate.Text, TL, SupplyNumber, MPR, txtpe24night.Text, txtpe24ew.Text,allunit, txtpe24offpeak.Text);
            Response.Redirect("quotstion.aspx?prop=" + quot);

        }

        protected void btnGaz24_Click(object sender, EventArgs e)
        {
            string un = Session["UserName"].ToString();
            string salestype = "renewal";
            if (lblCurrentSupplier.Text == "gaz" || lblCurrentSupplier.Text == "GAZ")
            {
                salestype = "Acquisition";
            }
            string allunit = "0";
            
            
                allunit = txtgaz24day.Text;
            

            string TL = Session["mytl"].ToString();
            string MPR = "";
            string SupplyNumber = Session["mpan"].ToString();
            string quot = ps.Storebasicdetas(txtBusiness.Text, un, lblCurrentSupplier.Text, "electricity", lblProfile.Text + lblMTC.Text + lblRegion.Text, lblStartdate.Text, "24", winclose, txtBusiness.Text, lblCurrentSupplier.Text, "GAZ", lblELEPayment.Text, "NO", lblEac.Text, salestype, txtBusiness.Text, allunit, txtgaz24uplift.Text, txtgaz24rate.Text, txtgaz24sc.Text, txtgaz24rate.Text, TL, SupplyNumber, MPR, txtgaz24night.Text, txtgaz24ew.Text, allunit, txtgaz24offpeak.Text);
            Response.Redirect("quotstion.aspx?prop=" + quot);

        }

        protected void btnnpr24_Click(object sender, EventArgs e)
        {
            string un = Session["UserName"].ToString();
            string salestype = "renewal";
            if (lblCurrentSupplier.Text == "Npower" || lblCurrentSupplier.Text == "NPOWER" || lblCurrentSupplier.Text == "NPR")
            {
                salestype = "Acquisition";
            }
            string allunit = "0";
           
                allunit = txtnpra24day.Text;
           

            string TL = Session["mytl"].ToString();
            string MPR = "2434567";
            string SupplyNumber = Session["mpan"].ToString();
            string quot = ps.Storebasicdetas(txtBusiness.Text, un, lblCurrentSupplier.Text, "electricity", lblProfile.Text + lblMTC.Text + lblRegion.Text, lblStartdate.Text, "24", winclose, txtBusiness.Text, lblCurrentSupplier.Text, "NPOWER", lblELEPayment.Text, "NO", lblEac.Text, salestype, txtBusiness.Text, txtnpra24day.Text, allunit, txtnpra24rate.Text, txtnpra24sc.Text, txtnpra24rate.Text, TL, SupplyNumber, MPR, txtnpra24night.Text, txtnpra24ew.Text, allunit, txtnpra24offpeak.Text);
            Response.Redirect("quotstion.aspx?prop=" + quot);


        }

        protected void btnSpe24_Click(object sender, EventArgs e)
        {
            string un = Session["UserName"].ToString();
            string salestype = "renewal";
            if (lblCurrentSupplier.Text == "SPE" || lblCurrentSupplier.Text == "SCO" || lblCurrentSupplier.Text == "Spe")
            {
                salestype = "Acquisition";
            }

            string allunit = "0";
           
                allunit = txtspe24day.Text;
            

            string TL = Session["mytl"].ToString();
            string MPR = "2434567";
            string SupplyNumber = Session["mpan"].ToString();
            string quot = ps.Storebasicdetas(txtBusiness.Text, un, lblCurrentSupplier.Text, "electricity", lblProfile.Text + lblMTC.Text + lblRegion.Text, lblStartdate.Text, "24", winclose, txtBusiness.Text, lblCurrentSupplier.Text, "SPE", lblELEPayment.Text, "NO", lblEac.Text, salestype, txtBusiness.Text, allunit, txtspe24uplift.Text, txtspe24rate.Text, txtspe24sc.Text, txtspe24rate.Text, TL, SupplyNumber, MPR, txtspe24night.Text, txtspe24ew.Text, allunit, txtspe24offpeak.Text);
            Response.Redirect("quotstion.aspx?prop=" + quot);

        }

        protected void btntgp24_Click(object sender, EventArgs e)
        {
            string un = Session["UserName"].ToString();
            string salestype = "renewal";
            if (lblCurrentSupplier.Text == "tgp" || lblCurrentSupplier.Text == "TGP" || lblCurrentSupplier.Text == "Tgp")
            {
                salestype = "Acquisition";
            }
            string allunit = "0";
           
                allunit = txttgp24day.Text;
           

            string TL = Session["mytl"].ToString();
            string MPR = "";
            string SupplyNumber = Session["mpan"].ToString();
            string quot = ps.Storebasicdetas(txtBusiness.Text, un, lblCurrentSupplier.Text, "electricity", lblProfile.Text + lblMTC.Text + lblRegion.Text, lblStartdate.Text, "24", winclose, txtBusiness.Text, lblCurrentSupplier.Text, "TGP", lblELEPayment.Text, "NO", lblEac.Text, salestype, txtBusiness.Text, allunit, txttgp24uplift.Text, txttgp24rate.Text, txttgp24sc.Text, txttgp24rate.Text, TL, SupplyNumber, MPR, txtspe24night.Text, txtspe24ew.Text, allunit, txtspe24offpeak.Text);
            Response.Redirect("quotstion.aspx?prop=" + quot + "&allunit=" + allunit + "&sc=" + txttgp24sc.Text);

        }

       

        protected void btnbga36_Click(object sender, EventArgs e)
        {
            string un = Session["UserName"].ToString();
            string salestype = "Acquisition";
            
            string allunit = "0";
            
                allunit = txtbga36day.Text;
           

            string TL = Session["mytl"].ToString();
            string MPR = "3634567";
            string SupplyNumber = Session["mpan"].ToString();
            string quot = ps.Storebasicdetas(txtBusiness.Text, un, lblCurrentSupplier.Text, "electricity", lblProfile.Text + lblMTC.Text + lblRegion.Text, lblStartdate.Text, "36", winclose, txtBusiness.Text, lblCurrentSupplier.Text, "BG", lblELEPayment.Text, "NO", lblEac.Text, salestype, txtBusiness.Text, allunit, txtbge36uplift.Text, txtbfgla36rate.Text, txtbge36sc.Text, txtbga12rate.Text, TL, SupplyNumber, MPR, txtbge36night.Text, txtbge36ew.Text, allunit, txtbge36offpeak.Text);
            Response.Redirect("quotstion.aspx?prop=" + quot);


        }

        protected void btnbge36_Click(object sender, EventArgs e)
        {
            string un = Session["UserName"].ToString();
            string salestype = "renewal";


            string allunit = "0";
         
                allunit = txtbge36day.Text;
           

            string TL = Session["mytl"].ToString();
            string MPR = "";
            string SupplyNumber = Session["mpan"].ToString();
            string quot = ps.Storebasicdetas(txtBusiness.Text, un, lblCurrentSupplier.Text, "electricity", lblProfile.Text + lblMTC.Text + lblRegion.Text, lblStartdate.Text, "36", winclose, txtBusiness.Text, lblCurrentSupplier.Text, "BG", lblELEPayment.Text, "NO", lblEac.Text, salestype, txtBusiness.Text, allunit, txtbge36uplift.Text, txtbfge36rate.Text, txtbge36sc.Text, txtbfge36rate.Text, TL, SupplyNumber, MPR, txtbge36night.Text, txtbge36ew.Text, allunit, txtbge36offpeak.Text);
            Response.Redirect("quotstion.aspx?prop=" + quot);
        }

        protected void btnbgla36_Click(object sender, EventArgs e)
        {
            string un = Session["UserName"].ToString();
            string salestype = "Acquisition";


            string allunit = "0";
           
                allunit = txtbgla36day.Text;
           
            string TL = Session["mytl"].ToString();
            string MPR = "";
            string SupplyNumber = Session["mpan"].ToString();
            string quot = ps.Storebasicdetas(txtBusiness.Text, un, lblCurrentSupplier.Text, "electricity", lblProfile.Text + lblMTC.Text + lblRegion.Text, lblStartdate.Text, "36", winclose, txtBusiness.Text, lblCurrentSupplier.Text, "BGL", lblELEPayment.Text, "NO", lblEac.Text, salestype, txtBusiness.Text, allunit, txtbgla36uplift.Text, txtbfgla36rate.Text, txtbgla36sc.Text, txtbfgla36rate.Text, TL, SupplyNumber, MPR, txtbgla36night.Text, txtbgla36ew.Text, allunit, txtbgla36offpeak.Text);
            Response.Redirect("quotstion.aspx?prop=" + quot);

        }

        protected void btnbgle36_Click(object sender, EventArgs e)
        {
            string un = Session["UserName"].ToString();
            string salestype = "renewal";


            string allunit = "0";
           
                allunit = txtbgle36day.Text;
           



            string TL = Session["mytl"].ToString();
            string MPR = "";
            string SupplyNumber = Session["mpan"].ToString();
            string quot = ps.Storebasicdetas(txtBusiness.Text, un, lblCurrentSupplier.Text, "electricity", lblProfile.Text + lblMTC.Text + lblRegion.Text, lblStartdate.Text, "36", winclose, txtBusiness.Text, lblCurrentSupplier.Text, "BGL", lblELEPayment.Text, "NO", lblEac.Text, salestype, txtBusiness.Text, txtbgle36day.Text, txtbgle36uplift.Text, txtbgle36rate.Text, txtbgle36sc.Text, txtbgle36rate.Text, TL, SupplyNumber, MPR, txtbgle36night.Text, txtedfa36ew.Text,allunit, txtedfa36offpeak.Text);
            Response.Redirect("quotstion.aspx?prop=" + quot);

        }

        protected void btnedf36_Click(object sender, EventArgs e)
        {
            string un = Session["UserName"].ToString();
            string salestype = "renewal";
            if (lblCurrentSupplier.Text == "EDF" || lblCurrentSupplier.Text == "edf")
            {
                salestype = "Acquisition";
            }
            string allunit = "0";
            
                allunit = txtedfa36day.Text;
           

            string TL = Session["mytl"].ToString();
            string MPR = "";
            string SupplyNumber = Session["mpan"].ToString();
            string quot = ps.Storebasicdetas(txtBusiness.Text, un, lblCurrentSupplier.Text, "electricity", lblProfile.Text + lblMTC.Text + lblRegion.Text, lblStartdate.Text, "36", winclose, txtBusiness.Text, lblCurrentSupplier.Text, "EDF", lblELEPayment.Text, "NO", lblEac.Text, salestype, txtBusiness.Text, allunit, txtedfa36uplift.Text, txtbgle36rate.Text, txtedfa36sc.Text, txtedf36rateall.Text, TL, SupplyNumber, MPR, txtbgle36night.Text, txtbgle36ew.Text, allunit, txtbgle36offpeak.Text);
            Response.Redirect("quotstion.aspx?prop=" + quot);

        }

        protected void btnde36_Click(object sender, EventArgs e)
        {
            string un = Session["UserName"].ToString();
            string salestype = "renewal";
            if (lblCurrentSupplier.Text == "DE" || lblCurrentSupplier.Text == "duel")
            {
                salestype = "Acquisition";
            }
            string allunit = "0";
            
                allunit = txtdea36day.Text;
            

            string TL = Session["mytl"].ToString();
            string MPR = "";
            string SupplyNumber = Session["mpan"].ToString();
            string quot = ps.Storebasicdetas(txtBusiness.Text, un, lblCurrentSupplier.Text, "electricity", lblProfile.Text + lblMTC.Text + lblRegion.Text, lblStartdate.Text, "36", winclose, txtBusiness.Text, lblCurrentSupplier.Text, "DE", lblELEPayment.Text, "NO", lblEac.Text, salestype, txtBusiness.Text, allunit, txtdea36uplift.Text, txtde36rate.Text, txtdea36sc.Text, txtde36rate.Text, TL, SupplyNumber, MPR, txtdea36night.Text, txtdea36ew.Text, allunit, txtdea36offpeak.Text);
            Response.Redirect("quotstion.aspx?prop=" + quot);

        }

        protected void btnpe36_Click(object sender, EventArgs e)
        {
            string un = Session["UserName"].ToString();
            string salestype = "renewal";
            if (lblCurrentSupplier.Text == "PE" || lblCurrentSupplier.Text == "pozitive")
            {
                salestype = "Acquisition";
            }
            string allunit = "0";
           
                allunit = txtpe36day.Text;
            

            string TL = Session["mytl"].ToString();
            string MPR = "";
            string SupplyNumber = Session["mpan"].ToString();
            string quot = ps.Storebasicdetas(txtBusiness.Text, un, lblCurrentSupplier.Text, "electricity", lblProfile.Text + lblMTC.Text + lblRegion.Text, lblStartdate.Text, "36", winclose, txtBusiness.Text, lblCurrentSupplier.Text, "PE", lblELEPayment.Text, "NO", lblEac.Text, salestype, txtBusiness.Text, allunit, txtpe36uplift.Text, txtpe36rate.Text, txtpe36sc.Text, txtpe36rate.Text, TL, SupplyNumber, MPR, txtpe36night.Text, txtpe36ew.Text, allunit, txtpe36offpeak.Text);
            Response.Redirect("quotstion.aspx?prop=" + quot);


        }

        protected void btngaz36_Click(object sender, EventArgs e)
        {
            string un = Session["UserName"].ToString();
            string salestype = "renewal";
            if (lblCurrentSupplier.Text == "gaz" || lblCurrentSupplier.Text == "GAZ")
            {
                salestype = "Acquisition";
            }
            string allunit = "0";
           
                allunit = txtgaz36day.Text;
           

            string TL = Session["mytl"].ToString();
            string MPR = "";
            string SupplyNumber = Session["mpan"].ToString();
            string quot = ps.Storebasicdetas(txtBusiness.Text, un, lblCurrentSupplier.Text, "electricity", lblProfile.Text + lblMTC.Text + lblRegion.Text, lblStartdate.Text, "36", winclose, txtBusiness.Text, lblCurrentSupplier.Text, "GAZ", lblELEPayment.Text, "NO", lblEac.Text, salestype, txtBusiness.Text, allunit, txtgaz36uplift.Text, txtgaz36rate.Text, txtgaz36sc.Text, txtgaz36rate.Text, TL, SupplyNumber, MPR, txtgaz36night.Text, txtgaz36ew.Text,allunit, txtgaz36offpeak.Text);
            Response.Redirect("quotstion.aspx?prop=" + quot);

        }

        protected void btnnpr36_Click(object sender, EventArgs e)
        {
            string un = Session["UserName"].ToString();
            string salestype = "renewal";
            if (lblCurrentSupplier.Text == "Npower" || lblCurrentSupplier.Text == "NPOWER" || lblCurrentSupplier.Text == "NPR")
            {
                salestype = "Acquisition";
            }
            string allunit = "0";
           
                allunit = txtnpra36day.Text;
            

            string TL = Session["mytl"].ToString();
            string MPR = "3634567";
            string SupplyNumber = Session["mpan"].ToString();
            string quot = ps.Storebasicdetas(txtBusiness.Text, un, lblCurrentSupplier.Text, "electricity", lblProfile.Text + lblMTC.Text + lblRegion.Text, lblStartdate.Text, "36", winclose, txtBusiness.Text, lblCurrentSupplier.Text, "NPOWER", lblELEPayment.Text, "NO", lblEac.Text, salestype, txtBusiness.Text, txtnpra36day.Text, allunit, txtnpra36rate.Text, txtnpra36sc.Text, txtnpra36rate.Text, TL, SupplyNumber, MPR, txtnpra36night.Text, txtnpra36ew.Text,allunit, txtnpra36offpeak.Text);
            Response.Redirect("quotstion.aspx?prop=" + quot);

        }

        protected void btnspe36_Click(object sender, EventArgs e)
        {
            string un = Session["UserName"].ToString();
            string salestype = "renewal";
            if (lblCurrentSupplier.Text == "SPE" || lblCurrentSupplier.Text == "SCO" || lblCurrentSupplier.Text == "Spe")
            {
                salestype = "Acquisition";
            }

            string allunit = "0";
           
                allunit = txtspe36day.Text;
            

            string TL = Session["mytl"].ToString();
            string MPR = "";
            string SupplyNumber = Session["mpan"].ToString();
            string quot = ps.Storebasicdetas(txtBusiness.Text, un, lblCurrentSupplier.Text, "electricity", lblProfile.Text + lblMTC.Text + lblRegion.Text, lblStartdate.Text, "36", winclose, txtBusiness.Text, lblCurrentSupplier.Text, "SPE", lblELEPayment.Text, "NO", lblEac.Text, salestype, txtBusiness.Text, allunit, txtspe36uplift.Text, txtspe36rate.Text, txtspe36sc.Text, txtspe36rate.Text, TL, SupplyNumber, MPR, txtspe36night.Text, txtspe36ew.Text, allunit, txtspe36offpeak.Text);
            Response.Redirect("quotstion.aspx?prop=" + quot);
        }

        protected void btntgp36_Click(object sender, EventArgs e)
        {
            string un = Session["UserName"].ToString();
            string salestype = "renewal";
            if (lblCurrentSupplier.Text == "tgp" || lblCurrentSupplier.Text == "TGP" || lblCurrentSupplier.Text == "Tgp")
            {
                salestype = "Acquisition";
            }
            string allunit = "0";
            
                allunit = txttgp36day.Text;
           

            string TL = Session["mytl"].ToString();
            string MPR = "";
            string SupplyNumber = Session["mpan"].ToString();
            string quot = ps.Storebasicdetas(txtBusiness.Text, un, lblCurrentSupplier.Text, "electricity", lblProfile.Text + lblMTC.Text + lblRegion.Text, lblStartdate.Text, "36", winclose, txtBusiness.Text, lblCurrentSupplier.Text, "TGP", lblELEPayment.Text, "NO", lblEac.Text, salestype, txtBusiness.Text, allunit, txttgp36uplift.Text, txttgp36rate.Text, txttgp36sc.Text, txttgp36rate.Text, TL, SupplyNumber, MPR, txtspe36night.Text, txtspe36ew.Text,allunit, txtspe36offpeak.Text);
            Response.Redirect("quotstion.aspx?prop=" + quot + "&allunit=" + allunit + "&sc=" + txttgp36sc.Text);
        }

        protected void btnbga48_Click(object sender, EventArgs e)
        {
            string un = Session["UserName"].ToString();
            string salestype = "Acquisition";

            string allunit = "0";
          
                allunit = txtbga48day.Text;
           

            string TL = Session["mytl"].ToString();
            string MPR = "4834567";
            string SupplyNumber = Session["mpan"].ToString();
            string quot = ps.Storebasicdetas(txtBusiness.Text, un, lblCurrentSupplier.Text, "electricity", lblProfile.Text + lblMTC.Text + lblRegion.Text, lblStartdate.Text, "48", winclose, txtBusiness.Text, lblCurrentSupplier.Text, "BG", lblELEPayment.Text, "NO", lblEac.Text, salestype, txtBusiness.Text, allunit, txtbge48uplift.Text, txtbfgla48rate.Text, txtbge48sc.Text, txtbga12rate.Text, TL, SupplyNumber, MPR, txtbge48night.Text, txtbge48ew.Text,allunit, txtbge48offpeak.Text);
            Response.Redirect("quotstion.aspx?prop=" + quot);


        }

        protected void btnbge48_Click(object sender, EventArgs e)
        {
            string un = Session["UserName"].ToString();
            string salestype = "renewal";


            string allunit = "0";
           
                allunit = txtbge48day.Text;
          
            string TL = Session["mytl"].ToString();
            string MPR = "4834567";
            string SupplyNumber = Session["mpan"].ToString();
            string quot = ps.Storebasicdetas(txtBusiness.Text, un, lblCurrentSupplier.Text, "electricity", lblProfile.Text + lblMTC.Text + lblRegion.Text, lblStartdate.Text, "48", winclose, txtBusiness.Text, lblCurrentSupplier.Text, "BG", lblELEPayment.Text, "NO", lblEac.Text, salestype, txtBusiness.Text, allunit, txtbge48uplift.Text, txtbfge48rate.Text, txtbge48sc.Text, txtbfge48rate.Text, TL, SupplyNumber, MPR, txtbge48night.Text, txtbge48ew.Text, allunit, txtbge48offpeak.Text);
            Response.Redirect("quotstion.aspx?prop=" + quot);
        }

        protected void btnbgla46_Click(object sender, EventArgs e)
        {
            string un = Session["UserName"].ToString();
            string salestype = "Acquisition";


            string allunit = "0";
           
                allunit = txtbgla48day.Text;
           
            string TL = Session["mytl"].ToString();
            string MPR = "";
            string SupplyNumber = Session["mpan"].ToString();
            string quot = ps.Storebasicdetas(txtBusiness.Text, un, lblCurrentSupplier.Text, "electricity", lblProfile.Text + lblMTC.Text + lblRegion.Text, lblStartdate.Text, "48", winclose, txtBusiness.Text, lblCurrentSupplier.Text, "BGL", lblELEPayment.Text, "NO", lblEac.Text, salestype, txtBusiness.Text, allunit, txtbgla48uplift.Text, txtbfgla48rate.Text, txtbgla48sc.Text, txtbfgla48rate.Text, TL, SupplyNumber, MPR, txtbgla48night.Text, txtbgla48ew.Text, allunit, txtbgla48offpeak.Text);
            Response.Redirect("quotstion.aspx?prop=" + quot);

        }

        protected void btnbgle48_Click(object sender, EventArgs e)
        {
            string un = Session["UserName"].ToString();
            string salestype = "renewal";


            string allunit = "0";
            
          
                allunit = txtbgle48day.Text;
           



            string TL = Session["mytl"].ToString();
            string MPR = "";
            string SupplyNumber = Session["mpan"].ToString();
            string quot = ps.Storebasicdetas(txtBusiness.Text, un, lblCurrentSupplier.Text, "electricity", lblProfile.Text + lblMTC.Text + lblRegion.Text, lblStartdate.Text, "48", winclose, txtBusiness.Text, lblCurrentSupplier.Text, "BGL", lblELEPayment.Text, "NO", lblEac.Text, salestype, txtBusiness.Text, txtbgle48day.Text, txtbgle48uplift.Text, txtbgle48rate.Text, txtbgle48sc.Text, txtbgle48rate.Text, TL, SupplyNumber, MPR, txtbgle48night.Text, txtedfa48ew.Text, allunit, txtedfa48offpeak.Text);
            Response.Redirect("quotstion.aspx?prop=" + quot);

        }

        protected void btnTotal48_Click(object sender, EventArgs e)
        {
            //string un = Session["UserName"].ToString();
            //string salestype = "renewal";
            //if (lblCurrentSupplier.Text == "tgp" || lblCurrentSupplier.Text == "TGP" || lblCurrentSupplier.Text == "Tgp")
            //{
            //    salestype = "Acquisition";
            //}
            //string allunit = "0";
            //if (txttgp48day.Text != "0")
            //{
            //    allunit = txttgp48day.Text;
            //}
            //else
            //{
            //    allunit = txttgp48unit.Text;
            //}

            //string TL = Session["mytl"].ToString();
            //string MPR = "4834567";
            //string SupplyNumber = Session["mpan"].ToString();
            //string quot = ps.Storebasicdetas(txtBusiness.Text, un, lblCurrentSupplier.Text, "electricity", lblProfile.Text + lblMTC.Text + lblRegion.Text, lblStartdate.Text, "48", winclose, txtBusiness.Text, lblCurrentSupplier.Text, "TGP", lblELEPayment.Text, "NO", lblEac.Text, salestype, txtBusiness.Text, allunit, txttgp48uplift.Text, txttgp48rate.Text, txttgp48sc.Text, txttgp48rate.Text, TL, SupplyNumber, MPR, txtspe48night.Text, txtspe48ew.Text, txtspe48wd.Text, txtspe48offpeak.Text);
            //Response.Redirect("quotstion.aspx?prop=" + quot + "&allunit=" + allunit + "&sc=" + txttgp48sc.Text);

        }

        protected void btnde60_Click(object sender, EventArgs e)
        {
            string un = Session["UserName"].ToString();
            string salestype = "renewal";
            if (lblCurrentSupplier.Text == "DE" || lblCurrentSupplier.Text == "duel")
            {
                salestype = "Acquisition";
            }
            string allunit = "0";
         
                allunit = txtdea36day.Text;
           

            string TL = Session["mytl"].ToString();
            string MPR = "";
            string SupplyNumber = Session["mpan"].ToString();
            string quot = ps.Storebasicdetas(txtBusiness.Text, un, lblCurrentSupplier.Text, "electricity", lblProfile.Text + lblMTC.Text + lblRegion.Text, lblStartdate.Text, "36", winclose, txtBusiness.Text, lblCurrentSupplier.Text, "DE", lblELEPayment.Text, "NO", lblEac.Text, salestype, txtBusiness.Text, allunit, txtdea36uplift.Text, txtde36rate.Text, txtdea36sc.Text, txtde36rate.Text, TL, SupplyNumber, MPR, txtdea36night.Text, txtdea36ew.Text, allunit, txtdea36offpeak.Text);
            Response.Redirect("quotstion.aspx?prop=" + quot);

        }

        protected void btntgp60_Click(object sender, EventArgs e)
        {
          

        }

        #endregion



        protected void txtsse12uplift_TextChanged(object sender, EventArgs e)
        {
            SSE12();
        }

        protected void txtsse12upliftnonamr_TextChanged(object sender, EventArgs e)
        {
            SSE12NONAMR();
        }

        protected void txtsse12upliftall_TextChanged(object sender, EventArgs e)
        {
            SSE12all();
        }

        protected void txtsse12upliftnonamrall_TextChanged(object sender, EventArgs e)
        {
            SSE12NONAMRAll();
        }

        protected void txtsse24uplift_TextChanged(object sender, EventArgs e)
        {
            SSE24();
        }

        protected void txtsse24upliftnonamr_TextChanged(object sender, EventArgs e)
        {
            SSE24NONAMR();
        }

        protected void txtsse36uplift_TextChanged(object sender, EventArgs e)
        {
            SSE36();
        }

        protected void txtsse36upliftnonamr_TextChanged(object sender, EventArgs e)
        {
            SSE36NONAMR();
        }

        protected void txtsse24upliftall_TextChanged(object sender, EventArgs e)
        {
            SSE24all();
        }

        protected void txtsse24upliftnonamrall_TextChanged(object sender, EventArgs e)
        {
            SSE24NONAMRAll();
        }

        protected void txtsse36upliftall_TextChanged(object sender, EventArgs e)
        {
            SSE36all();
        }

        protected void txtsse36upliftnonamrall_TextChanged(object sender, EventArgs e)
        {
            SSE36all();

        }

        protected void txtspe12uplift_TextChanged(object sender, EventArgs e)
        {
            Spe12();
        }

        protected void txtspe24uplift_TextChanged(object sender, EventArgs e)
        {
            Spe24();
        }

        protected void txtspe36uplift_TextChanged(object sender, EventArgs e)
        {
            Spe36();
        }

        protected void txtspe12upliftall_TextChanged(object sender, EventArgs e)
        {
            Spe12all();
        }

        protected void txtspe24upliftall_TextChanged(object sender, EventArgs e)
        {
            Spe24all();
        }

        protected void txtspe36upliftall_TextChanged(object sender, EventArgs e)
        {
            Spe36all();
        }

        protected void txtopus12uplift_TextChanged(object sender, EventArgs e)
        {
            Opus12();
        }

        protected void txtopus24uplift_TextChanged(object sender, EventArgs e)
        {
            Opus24();
        }

        protected void txtopus36uplift_TextChanged(object sender, EventArgs e)
        {
            Opus36();
        }

        protected void txtopus48uplift_TextChanged(object sender, EventArgs e)
        {
            Opus48();
        }

        protected void txtopus12upliftall_TextChanged(object sender, EventArgs e)
        {
            Opus12all();
        }

        protected void txtopus24upliftall_TextChanged(object sender, EventArgs e)
        {
            Opus24all();
        }

        protected void txtopus36upliftall_TextChanged(object sender, EventArgs e)
        {
            Opus36all();
        }

        protected void txtopus48upliftall_TextChanged(object sender, EventArgs e)
        {
            Opus48all();
        }

        protected void ddeon24uplift_SelectedIndexChanged(object sender, EventArgs e)
        {
            Eon24();
        }

        protected void ddeon36uplift_SelectedIndexChanged(object sender, EventArgs e)
        {
            Eon36();
        }

        protected void ddeon48uplift_SelectedIndexChanged(object sender, EventArgs e)
        {
            Eon48();
        }

        protected void ddeon12upliftall_SelectedIndexChanged(object sender, EventArgs e)
        {
            Eon12all();
        }

        protected void ddeon24upliftall_SelectedIndexChanged(object sender, EventArgs e)
        {
            Eon24all();
        }

        protected void ddeon36upliftall_SelectedIndexChanged(object sender, EventArgs e)
        {
            Eon36all();
        }

        protected void ddeon48upliftall_SelectedIndexChanged(object sender, EventArgs e)
        {
            Eon48all();

        }

        #region YU
        protected void btnyue12Show_Click(object sender, EventArgs e) 
        {
            string un = Session["UserName"].ToString();
            string salestype = "renewal";
            if (lblCurrentSupplier.Text == "yu" || lblCurrentSupplier.Text == "YU")
            {
                salestype = "Acquisition";
            }

            string allunit = "0";

            allunit = txtyuea12day.Text;


            string TL = Session["mytl"].ToString();
            string MPR = "";
            string SupplyNumber = Session["mpan"].ToString();
            string quot = ps.Storebasicdetas(txtBusiness.Text, un, lblCurrentSupplier.Text, "electricity", lblProfile.Text + lblMTC.Text + lblRegion.Text, lblStartdate.Text, "12", winclose, txtBusiness.Text, lblCurrentSupplier.Text, "YU", lblELEPayment.Text, "NO", lblEac.Text, salestype, txtBusiness.Text, allunit, txtyuea12uplift.Text, txtyue12Rate.Text, txtyuea12sc.Text, txtyue12Rate.Text, TL, SupplyNumber, MPR, txtyuea12night.Text, txtyuea12ew.Text, allunit, txtyuea12offpeak.Text);
            Response.Redirect("quotstion.aspx?prop=" + quot);

        } 

        protected void btnyue24Show_Click(object sender, EventArgs e) 
        {
            string un = Session["UserName"].ToString();
            string salestype = "renewal";
            if (lblCurrentSupplier.Text == "yu" || lblCurrentSupplier.Text == "YU")
            {
                salestype = "Acquisition";
            }

            string allunit = "0";

            allunit = txtyuea24day.Text;


            string TL = Session["mytl"].ToString();
            string MPR = "";
            string SupplyNumber = Session["mpan"].ToString();
            string quot = ps.Storebasicdetas(txtBusiness.Text, un, lblCurrentSupplier.Text, "electricity", lblProfile.Text + lblMTC.Text + lblRegion.Text, lblStartdate.Text, "24", winclose, txtBusiness.Text, lblCurrentSupplier.Text, "YU", lblELEPayment.Text, "NO", lblEac.Text, salestype, txtBusiness.Text, allunit, txtyuea24uplift.Text, txtyue24Rate.Text, txtyuea24sc.Text, txtyue24Rate.Text, TL, SupplyNumber, MPR, txtyuea24night.Text, txtyuea24ew.Text, allunit, txtyuea24offpeak.Text);
            Response.Redirect("quotstion.aspx?prop=" + quot);
        }

        protected void btnyue36Show_Click(object sender, EventArgs e) 
        {
            string un = Session["UserName"].ToString();
            string salestype = "renewal";
            if (lblCurrentSupplier.Text == "yu" || lblCurrentSupplier.Text == "YU")
            {
                salestype = "Acquisition";
            }

            string allunit = "0";

            allunit = txtyuea36day.Text;


            string TL = Session["mytl"].ToString();
            string MPR = "";
            string SupplyNumber = Session["mpan"].ToString();
            string quot = ps.Storebasicdetas(txtBusiness.Text, un, lblCurrentSupplier.Text, "electricity", lblProfile.Text + lblMTC.Text + lblRegion.Text, lblStartdate.Text, "36", winclose, txtBusiness.Text, lblCurrentSupplier.Text, "YU", lblELEPayment.Text, "NO", lblEac.Text, salestype, txtBusiness.Text, allunit, txtyuea36uplift.Text, txtyue24Rate.Text, txtyuea36sc.Text, txtyue24Rate.Text, TL, SupplyNumber, MPR, txtyuea36night.Text, txtyuea36ew.Text, allunit, txtyuea36offpeak.Text);
            Response.Redirect("quotstion.aspx?prop=" + quot);
        }

        protected void btnyue48Show_Click(object sender, EventArgs e) 
        {
            string un = Session["UserName"].ToString();
            string salestype = "renewal";
            if (lblCurrentSupplier.Text == "yu" || lblCurrentSupplier.Text == "YU")
            {
                salestype = "Acquisition";
            }

            string allunit = "0";

            allunit = txtyuea48day.Text;


            string TL = Session["mytl"].ToString();
            string MPR = "";
            string SupplyNumber = Session["mpan"].ToString();
            string quot = ps.Storebasicdetas(txtBusiness.Text, un, lblCurrentSupplier.Text, "electricity", lblProfile.Text + lblMTC.Text + lblRegion.Text, lblStartdate.Text, "48", winclose, txtBusiness.Text, lblCurrentSupplier.Text, "YU", lblELEPayment.Text, "NO", lblEac.Text, salestype, txtBusiness.Text, allunit, txtyuea36uplift.Text, txtyue24Rate.Text, txtyuea36sc.Text, txtyue48Rate.Text, TL, SupplyNumber, MPR, txtyuea48night.Text, txtyuea36ew.Text, allunit, txtyuea48offpeak.Text);
            Response.Redirect("quotstion.aspx?prop=" + quot);
        }

        protected void btnyue60Show_Click(object sender, EventArgs e)
        {
            string un = Session["UserName"].ToString();
            string salestype = "renewal";
            if (lblCurrentSupplier.Text == "yu" || lblCurrentSupplier.Text == "YU")
            {
                salestype = "Acquisition";
            }

            string allunit = "0";

            allunit = txtyuea60day.Text;


            string TL = Session["mytl"].ToString();
            string MPR = "";
            string SupplyNumber = Session["mpan"].ToString();
            string quot = ps.Storebasicdetas(txtBusiness.Text, un, lblCurrentSupplier.Text, "electricity", lblProfile.Text + lblMTC.Text + lblRegion.Text, lblStartdate.Text, "60", winclose, txtBusiness.Text, lblCurrentSupplier.Text, "YU", lblELEPayment.Text, "NO", lblEac.Text, salestype, txtBusiness.Text, allunit, txtyuea36uplift.Text, txtyue24Rate.Text, txtyuea60sc.Text, txtyue60Rate.Text, TL, SupplyNumber, MPR, txtyuea60night.Text, txtyuea60ew.Text, allunit, txtyuea60offpeak.Text);
            Response.Redirect("quotstion.aspx?prop=" + quot);
        }

       
        protected void btnyue12allShow_Click(object sender, EventArgs e) 
        {
            string un = Session["UserName"].ToString();
            string salestype = "renewal";
            if (lblCurrentSupplier.Text == "yu" || lblCurrentSupplier.Text == "YU")
            {
                salestype = "Acquisition";
            }

            string allunit = "0";

            allunit = txtyuea12dayall.Text;


            string TL = Session["mytl"].ToString();
            string MPR = "";
            string SupplyNumber = Session["mpan"].ToString();
            string quot = ps.Storebasicdetas(txtBusiness.Text, un, lblCurrentSupplier.Text, "electricity", lblProfile.Text + lblMTC.Text + lblRegion.Text, lblStartdate.Text, "12", winclose, txtBusiness.Text, lblCurrentSupplier.Text, "YU", lblELEPayment.Text, "NO", lblEac.Text, salestype, txtBusiness.Text, allunit, txtyuea12upliftall.Text, txtyue12Rateall.Text, txtyuea12scall.Text, txtyue12Rate.Text, TL, SupplyNumber, MPR, txtyuea60nightall.Text, txtyuea12ewall.Text, allunit, txtyuea12offpeakall.Text);
            Response.Redirect("quotstion.aspx?prop=" + quot);
        }

        protected void btnyue24allShow_Click(object sender, EventArgs e)
        {
            string un = Session["UserName"].ToString();
            string salestype = "renewal";
            if (lblCurrentSupplier.Text == "yu" || lblCurrentSupplier.Text == "YU")
            {
                salestype = "Acquisition";
            }

            string allunit = "0";

            allunit = txtyuea24dayall.Text;


            string TL = Session["mytl"].ToString();
            string MPR = "";
            string SupplyNumber = Session["mpan"].ToString();
            string quot = ps.Storebasicdetas(txtBusiness.Text, un, lblCurrentSupplier.Text, "electricity", lblProfile.Text + lblMTC.Text + lblRegion.Text, lblStartdate.Text, "24", winclose, txtBusiness.Text, lblCurrentSupplier.Text, "YU", lblELEPayment.Text, "NO", lblEac.Text, salestype, txtBusiness.Text, allunit, txtyuea24upliftall.Text, txtyue24Rateall.Text, txtyuea24scall.Text, txtyue24Rate.Text, TL, SupplyNumber, MPR, txtyuea24nightall.Text, txtyuea24ewall.Text, allunit, txtyuea24offpeakall.Text);
            Response.Redirect("quotstion.aspx?prop=" + quot);
        }

        protected void btnyue36allShow_Click(object sender, EventArgs e) 
        {
            string un = Session["UserName"].ToString();
            string salestype = "renewal";
            if (lblCurrentSupplier.Text == "yu" || lblCurrentSupplier.Text == "YU")
            {
                salestype = "Acquisition";
            }

            string allunit = "0";

            allunit = txtyuea36dayall.Text;


            string TL = Session["mytl"].ToString();
            string MPR = "";
            string SupplyNumber = Session["mpan"].ToString();
            string quot = ps.Storebasicdetas(txtBusiness.Text, un, lblCurrentSupplier.Text, "electricity", lblProfile.Text + lblMTC.Text + lblRegion.Text, lblStartdate.Text, "36", winclose, txtBusiness.Text, lblCurrentSupplier.Text, "YU", lblELEPayment.Text, "NO", lblEac.Text, salestype, txtBusiness.Text, allunit, txtyuea36upliftall.Text, txtyue36Rateall.Text, txtyuea36scall.Text, txtyue36Rate.Text, TL, SupplyNumber, MPR, txtyuea36nightall.Text, txtyuea36ewall.Text, allunit, txtyuea36offpeakall.Text);
            Response.Redirect("quotstion.aspx?prop=" + quot);
        }

        protected void btnyue48allShow_Click(object sender, EventArgs e)
        {
            string un = Session["UserName"].ToString();
            string salestype = "renewal";
            if (lblCurrentSupplier.Text == "yu" || lblCurrentSupplier.Text == "YU")
            {
                salestype = "Acquisition";
            }

            string allunit = "0";

            allunit = txtyuea36dayall.Text;


            string TL = Session["mytl"].ToString();
            string MPR = "";
            string SupplyNumber = Session["mpan"].ToString();
            string quot = ps.Storebasicdetas(txtBusiness.Text, un, lblCurrentSupplier.Text, "electricity", lblProfile.Text + lblMTC.Text + lblRegion.Text, lblStartdate.Text, "48", winclose, txtBusiness.Text, lblCurrentSupplier.Text, "YU", lblELEPayment.Text, "NO", lblEac.Text, salestype, txtBusiness.Text, allunit, txtyuea48upliftall.Text, txtyue48Rateall.Text, txtyuea48scall.Text, txtyue48Rate.Text, TL, SupplyNumber, MPR, txtyuea48nightall.Text, txtyuea48ewall.Text, allunit, txtyuea48offpeakall.Text); 
            Response.Redirect("quotstion.aspx?prop=" + quot);
        }

        protected void btnyue60allShow_Click(object sender, EventArgs e)
        {
            {
                string un = Session["UserName"].ToString();
                string salestype = "renewal";
                if (lblCurrentSupplier.Text == "yu" || lblCurrentSupplier.Text == "YU")
                {
                    salestype = "Acquisition";
                }

                string allunit = "0";

                allunit = txtyuea60dayall.Text;


                string TL = Session["mytl"].ToString();
                string MPR = "";
                string SupplyNumber = Session["mpan"].ToString();
                string quot = ps.Storebasicdetas(txtBusiness.Text, un, lblCurrentSupplier.Text, "electricity", lblProfile.Text + lblMTC.Text + lblRegion.Text, lblStartdate.Text, "60", winclose, txtBusiness.Text, lblCurrentSupplier.Text, "YU", lblELEPayment.Text, "NO", lblEac.Text, salestype, txtBusiness.Text, allunit, txtyuea60upliftall.Text, txtyue60Rateall.Text, txtyuea60scall.Text, txtyue60Rate.Text, TL, SupplyNumber, MPR, txtyuea60nightall.Text, txtyuea60ewall.Text, allunit, txtyuea60offpeakall.Text);
                Response.Redirect("quotstion.aspx?prop=" + quot);

            }
        }

        #endregion YU

        #region Gulf

        protected void btngulf12Show_Click(object sender, EventArgs e)
        {
            string un = Session["UserName"].ToString();
            string salestype = "renewal";
            if (lblCurrentSupplier.Text == "gulf" || lblCurrentSupplier.Text == "GULF")
            {
                salestype = "Acquisition";
            }

            string allunit = "0";

            allunit = txtgulfa12day.Text;


            string TL = Session["mytl"].ToString();
            string MPR = "";
            string SupplyNumber = Session["mpan"].ToString();
            string quot = ps.Storebasicdetas(txtBusiness.Text, un, lblCurrentSupplier.Text, "electricity", lblProfile.Text + lblMTC.Text + lblRegion.Text, lblStartdate.Text, "12", winclose, txtBusiness.Text, lblCurrentSupplier.Text, "GULF", lblELEPayment.Text, "NO", lblEac.Text, salestype, txtBusiness.Text, allunit, txtgulfa12upliftall.Text, txtgulf12Rate.Text, txtgulfa12sc.Text, txtgulf12Rate.Text, TL, SupplyNumber, MPR, txtgulfa12night.Text, txtgulfa12ew.Text, allunit, txtgulfa12offpeak.Text);
            Response.Redirect("quotstion.aspx?prop=" + quot);
        }

        protected void btngulf24Show_Click(object sender, EventArgs e)
        {
            string un = Session["UserName"].ToString();
            string salestype = "renewal";
            if (lblCurrentSupplier.Text == "gulf" || lblCurrentSupplier.Text == "GULF")
            {
                salestype = "Acquisition";
            }

            string allunit = "0";

            allunit = txtgulfa24day.Text;


            string TL = Session["mytl"].ToString();
            string MPR = "";
            string SupplyNumber = Session["mpan"].ToString();
            string quot = ps.Storebasicdetas(txtBusiness.Text, un, lblCurrentSupplier.Text, "electricity", lblProfile.Text + lblMTC.Text + lblRegion.Text, lblStartdate.Text, "24", winclose, txtBusiness.Text, lblCurrentSupplier.Text, "GULF", lblELEPayment.Text, "NO", lblEac.Text, salestype, txtBusiness.Text, allunit, txtgulfa24upliftall.Text, txtgulf24Rate.Text, txtgulfa24sc.Text, txtgulf24Rate.Text, TL, SupplyNumber, MPR, txtgulfa24night.Text, txtgulfa24ew.Text, allunit, txtgulfa24offpeak.Text);
            Response.Redirect("quotstion.aspx?prop=" + quot);
        }

        protected void btngulf36Show_Click(object sender, EventArgs e)
        {
            string un = Session["UserName"].ToString();
            string salestype = "renewal";
            if (lblCurrentSupplier.Text == "gulf" || lblCurrentSupplier.Text == "GULF")
            {
                salestype = "Acquisition";
            }

            string allunit = "0";

            allunit = txtgulfa36day.Text;


            string TL = Session["mytl"].ToString();
            string MPR = "";
            string SupplyNumber = Session["mpan"].ToString();
            string quot = ps.Storebasicdetas(txtBusiness.Text, un, lblCurrentSupplier.Text, "electricity", lblProfile.Text + lblMTC.Text + lblRegion.Text, lblStartdate.Text, "36", winclose, txtBusiness.Text, lblCurrentSupplier.Text, "GULF", lblELEPayment.Text, "NO", lblEac.Text, salestype, txtBusiness.Text, allunit, txtgulfa36upliftall.Text, txtgulf36Rate.Text, txtgulfa36sc.Text, txtgulf36Rate.Text, TL, SupplyNumber, MPR, txtgulfa36night.Text, txtgulfa36ew.Text, allunit, txtgulfa36offpeak.Text);
            Response.Redirect("quotstion.aspx?prop=" + quot);
        }

        protected void btngulf48Show_Click(object sender, EventArgs e)
        { 
            string un = Session["UserName"].ToString();
            string salestype = "renewal";
            if (lblCurrentSupplier.Text == "gulf" || lblCurrentSupplier.Text == "GULF")
            {
                salestype = "Acquisition";
            }

            string allunit = "0";

            allunit = txtgulfa48day.Text;


            string TL = Session["mytl"].ToString();
            string MPR = "";
            string SupplyNumber = Session["mpan"].ToString();
            string quot = ps.Storebasicdetas(txtBusiness.Text, un, lblCurrentSupplier.Text, "electricity", lblProfile.Text + lblMTC.Text + lblRegion.Text, lblStartdate.Text, "48", winclose, txtBusiness.Text, lblCurrentSupplier.Text, "GULF", lblELEPayment.Text, "NO", lblEac.Text, salestype, txtBusiness.Text, allunit, txtgulfa48upliftall.Text, txtgulf48Rate.Text, txtgulfa48sc.Text, txtgulf48Rate.Text, TL, SupplyNumber, MPR, txtgulfa48night.Text, txtgulfa48ew.Text, allunit, txtgulfa48offpeak.Text);
            Response.Redirect("quotstion.aspx?prop=" + quot);
        }

        protected void btngulf60Show_Click(object sender, EventArgs e)
        {
            string un = Session["UserName"].ToString();
            string salestype = "renewal";
            if (lblCurrentSupplier.Text == "gulf" || lblCurrentSupplier.Text == "GULF")
            {
                salestype = "Acquisition";
            }

            string allunit = "0";

            allunit = txtgulfa60day.Text;


            string TL = Session["mytl"].ToString();
            string MPR = "";
            string SupplyNumber = Session["mpan"].ToString();
            string quot = ps.Storebasicdetas(txtBusiness.Text, un, lblCurrentSupplier.Text, "electricity", lblProfile.Text + lblMTC.Text + lblRegion.Text, lblStartdate.Text, "60", winclose, txtBusiness.Text, lblCurrentSupplier.Text, "GULF", lblELEPayment.Text, "NO", lblEac.Text, salestype, txtBusiness.Text, allunit, txtgulfa60upliftall.Text, txtgulf60Rate.Text, txtgulfa60sc.Text, txtgulf48Rate.Text, TL, SupplyNumber, MPR, txtgulfa48night.Text, txtgulfa60ew.Text, allunit, txtgulfa60offpeak.Text);
            Response.Redirect("quotstion.aspx?prop=" + quot);
        }

        protected void btngulf12allShow_Click(object sender, EventArgs e)
        {
            string un = Session["UserName"].ToString();
            string salestype = "renewal";
            if (lblCurrentSupplier.Text == "gulf" || lblCurrentSupplier.Text == "GULF")
            {
                salestype = "Acquisition";
            }

            string allunit = "0";

            allunit = txtgulfa24dayall.Text;


            string TL = Session["mytl"].ToString();
            string MPR = "";
            string SupplyNumber = Session["mpan"].ToString();
            string quot = ps.Storebasicdetas(txtBusiness.Text, un, lblCurrentSupplier.Text, "electricity", lblProfile.Text + lblMTC.Text + lblRegion.Text, lblStartdate.Text, "12", winclose, txtBusiness.Text, lblCurrentSupplier.Text, "GULF", lblELEPayment.Text, "NO", lblEac.Text, salestype, txtBusiness.Text, allunit, txtgulfa12upliftall.Text, txtgulf12Rateall.Text, txtgulfa12scall.Text, txtgulf12Rateall.Text, TL, SupplyNumber, MPR, txtgulfa12nightall.Text, txtgulfa12ewall.Text, allunit, txtgulfa12offpeakall.Text);
            Response.Redirect("quotstion.aspx?prop=" + quot);
        }

        protected void btngulf24allShow_Click(object sender, EventArgs e) 
        {
            string un = Session["UserName"].ToString();
            string salestype = "renewal";
            if (lblCurrentSupplier.Text == "gulf" || lblCurrentSupplier.Text == "GULF")
            {
                salestype = "Acquisition";
            }

            string allunit = "0";

            allunit = txtgulfa24dayall.Text;


            string TL = Session["mytl"].ToString();
            string MPR = "";
            string SupplyNumber = Session["mpan"].ToString();
            string quot = ps.Storebasicdetas(txtBusiness.Text, un, lblCurrentSupplier.Text, "electricity", lblProfile.Text + lblMTC.Text + lblRegion.Text, lblStartdate.Text, "24", winclose, txtBusiness.Text, lblCurrentSupplier.Text, "GULF", lblELEPayment.Text, "NO", lblEac.Text, salestype, txtBusiness.Text, allunit, txtgulfa24upliftall.Text, txtgulf24Rateall.Text, txtgulfa24scall.Text, txtgulf24Rateall.Text, TL, SupplyNumber, MPR, txtgulfa24nightall.Text, txtgulfa24ewall.Text, allunit, txtgulfa24offpeakall.Text);
            Response.Redirect("quotstion.aspx?prop=" + quot);
        }

        protected void btngulf36allShow_Click(object sender, EventArgs e) 
        {
            string un = Session["UserName"].ToString();
            string salestype = "renewal";
            if (lblCurrentSupplier.Text == "gulf" || lblCurrentSupplier.Text == "GULF")
            {
                salestype = "Acquisition";
            }

            string allunit = "0";

            allunit = txtgulfa36dayall.Text;


            string TL = Session["mytl"].ToString();
            string MPR = "";
            string SupplyNumber = Session["mpan"].ToString();
            string quot = ps.Storebasicdetas(txtBusiness.Text, un, lblCurrentSupplier.Text, "electricity", lblProfile.Text + lblMTC.Text + lblRegion.Text, lblStartdate.Text, "36", winclose, txtBusiness.Text, lblCurrentSupplier.Text, "GULF", lblELEPayment.Text, "NO", lblEac.Text, salestype, txtBusiness.Text, allunit, txtgulfa36upliftall.Text, txtgulf36Rateall.Text, txtgulfa36scall.Text, txtgulf36Rateall.Text, TL, SupplyNumber, MPR, txtgulfa36nightall.Text, txtgulfa36ewall.Text, allunit, txtgulfa36offpeakall.Text);
            Response.Redirect("quotstion.aspx?prop=" + quot);
        }

        protected void btngulf48allShow_Click(object sender, EventArgs e)
        {
            string un = Session["UserName"].ToString();
            string salestype = "renewal";
            if (lblCurrentSupplier.Text == "gulf" || lblCurrentSupplier.Text == "GULF")
            {
                salestype = "Acquisition";
            }

            string allunit = "0";

            allunit = txtgulfa48dayall.Text;


            string TL = Session["mytl"].ToString();
            string MPR = "";
            string SupplyNumber = Session["mpan"].ToString();
            string quot = ps.Storebasicdetas(txtBusiness.Text, un, lblCurrentSupplier.Text, "electricity", lblProfile.Text + lblMTC.Text + lblRegion.Text, lblStartdate.Text, "48", winclose, txtBusiness.Text, lblCurrentSupplier.Text, "GULF", lblELEPayment.Text, "NO", lblEac.Text, salestype, txtBusiness.Text, allunit, txtgulfa48upliftall.Text, txtgulf48Rateall.Text, txtgulfa48scall.Text, txtgulf48Rateall.Text, TL, SupplyNumber, MPR, txtyuea48nightall.Text, txtyuea48ewall.Text, allunit, txtyuea48offpeakall.Text);
            Response.Redirect("quotstion.aspx?prop=" + quot);
        }
         
        protected void btngulf60allShow_Click(object sender, EventArgs e)
        {
            string un = Session["UserName"].ToString();
            string salestype = "renewal";
            if (lblCurrentSupplier.Text == "gulf" || lblCurrentSupplier.Text == "GULF")
            {
                salestype = "Acquisition";
            }

            string allunit = "0";

            allunit = txtgulfa60dayall.Text;


            string TL = Session["mytl"].ToString();
            string MPR = "";
            string SupplyNumber = Session["mpan"].ToString();
            string quot = ps.Storebasicdetas(txtBusiness.Text, un, lblCurrentSupplier.Text, "electricity", lblProfile.Text + lblMTC.Text + lblRegion.Text, lblStartdate.Text, "60", winclose, txtBusiness.Text, lblCurrentSupplier.Text, "GULF", lblELEPayment.Text, "NO", lblEac.Text, salestype, txtBusiness.Text, allunit, txtgulfa60upliftall.Text, txtgulf60Rateall.Text, txtgulfa60scall.Text, txtgulf60Rateall.Text, TL, SupplyNumber, MPR, txtyuea60nightall.Text, txtyuea60ewall.Text, allunit, txtyuea60offpeakall.Text);
            Response.Redirect("quotstion.aspx?prop=" + quot);
        }


        #endregion

        #region Utilita

        protected void btnutil12Show_Click(object sender, EventArgs e)
        {
            string un = Session["UserName"].ToString();
            string salestype = "renewal";
            if (lblCurrentSupplier.Text == "utilita" || lblCurrentSupplier.Text == "UTILITA")
            {
                salestype = "Acquisition";
            }

            string allunit = "0";

            allunit = txtutila12day.Text;


            string TL = Session["mytl"].ToString();
            string MPR = "";
            string SupplyNumber = Session["mpan"].ToString();
            string quot = ps.Storebasicdetas(txtBusiness.Text, un, lblCurrentSupplier.Text, "electricity", lblProfile.Text + lblMTC.Text + lblRegion.Text, lblStartdate.Text, "12", winclose, txtBusiness.Text, lblCurrentSupplier.Text, "UTILITA", lblELEPayment.Text, "NO", lblEac.Text, salestype, txtBusiness.Text, allunit, txtutila12uplift.Text, txtutil12Rate.Text, txtutila12sc.Text, txtutil12Rate.Text, TL, SupplyNumber, MPR, txtutila12night.Text, txtutila12ew.Text, allunit, txtutila12offpeak.Text);
            Response.Redirect("quotstion.aspx?prop=" + quot);
        }

        protected void btnutil24Show_Click(object sender, EventArgs e)
        {
            string un = Session["UserName"].ToString();
            string salestype = "renewal";
            if (lblCurrentSupplier.Text == "utilita" || lblCurrentSupplier.Text == "UTILITA")
            {
                salestype = "Acquisition";
            }

            string allunit = "0";

            allunit = txtutila24day.Text;


            string TL = Session["mytl"].ToString();
            string MPR = "";
            string SupplyNumber = Session["mpan"].ToString();
            string quot = ps.Storebasicdetas(txtBusiness.Text, un, lblCurrentSupplier.Text, "electricity", lblProfile.Text + lblMTC.Text + lblRegion.Text, lblStartdate.Text, "24", winclose, txtBusiness.Text, lblCurrentSupplier.Text, "UTILITA", lblELEPayment.Text, "NO", lblEac.Text, salestype, txtBusiness.Text, allunit, txtutila24uplift.Text, txtutil24Rate.Text, txtutila24sc.Text, txtutil24Rate.Text, TL, SupplyNumber, MPR, txtutila24night.Text, txtutila24ew.Text, allunit, txtutila24offpeak.Text);
            Response.Redirect("quotstion.aspx?prop=" + quot);
        }

        protected void btnutil36Show_Click(object sender, EventArgs e)
        {
            string un = Session["UserName"].ToString();
            string salestype = "renewal";
            if (lblCurrentSupplier.Text == "utilita" || lblCurrentSupplier.Text == "UTILITA")
            {
                salestype = "Acquisition";
            }

            string allunit = "0";

            allunit = txtutila36day.Text;


            string TL = Session["mytl"].ToString();
            string MPR = "";
            string SupplyNumber = Session["mpan"].ToString();
            string quot = ps.Storebasicdetas(txtBusiness.Text, un, lblCurrentSupplier.Text, "electricity", lblProfile.Text + lblMTC.Text + lblRegion.Text, lblStartdate.Text, "36", winclose, txtBusiness.Text, lblCurrentSupplier.Text, "UTILITA", lblELEPayment.Text, "NO", lblEac.Text, salestype, txtBusiness.Text, allunit, txtutila36uplift.Text, txtutil36Rate.Text, txtutila36sc.Text, txtutil36Rate.Text, TL, SupplyNumber, MPR, txtutila36night.Text, txtutila36ew.Text, allunit, txtutila36offpeak.Text);
            Response.Redirect("quotstion.aspx?prop=" + quot);
        }

        protected void btnutil48Show_Click(object sender, EventArgs e)
        {
            string un = Session["UserName"].ToString();
            string salestype = "renewal";
            if (lblCurrentSupplier.Text == "utilita" || lblCurrentSupplier.Text == "UTILITA")
            {
                salestype = "Acquisition";
            }

            string allunit = "0";

            allunit = txtutila48day.Text;


            string TL = Session["mytl"].ToString();
            string MPR = "";
            string SupplyNumber = Session["mpan"].ToString();
            string quot = ps.Storebasicdetas(txtBusiness.Text, un, lblCurrentSupplier.Text, "electricity", lblProfile.Text + lblMTC.Text + lblRegion.Text, lblStartdate.Text, "48", winclose, txtBusiness.Text, lblCurrentSupplier.Text, "UTILITA", lblELEPayment.Text, "NO", lblEac.Text, salestype, txtBusiness.Text, allunit, txtutila48uplift.Text, txtutil48Rate.Text, txtutila48sc.Text, txtutil48Rate.Text, TL, SupplyNumber, MPR, txtutila36night.Text, txtutila48ew.Text, allunit, txtutila48offpeak.Text);
            Response.Redirect("quotstion.aspx?prop=" + quot);
        }

        protected void btnutil12allShow_Click(object sender, EventArgs e)
        {
            string un = Session["UserName"].ToString();
            string salestype = "renewal";
            if (lblCurrentSupplier.Text == "utilita" || lblCurrentSupplier.Text == "UTILITA")
            {
                salestype = "Acquisition";
            }

            string allunit = "0";

            allunit = txtutila12dayall.Text;


            string TL = Session["mytl"].ToString();
            string MPR = "";
            string SupplyNumber = Session["mpan"].ToString();
            string quot = ps.Storebasicdetas(txtBusiness.Text, un, lblCurrentSupplier.Text, "electricity", lblProfile.Text + lblMTC.Text + lblRegion.Text, lblStartdate.Text, "12", winclose, txtBusiness.Text, lblCurrentSupplier.Text, "UTILITA", lblELEPayment.Text, "NO", lblEac.Text, salestype, txtBusiness.Text, allunit, txtutila12upliftall.Text, txtutil12Rate.Text, txtutila12sc.Text, txtutil12Rateall.Text, TL, SupplyNumber, MPR, txtutila12nightall.Text, txtutila12ewall.Text, allunit, txtutila12offpeakall.Text);
            Response.Redirect("quotstion.aspx?prop=" + quot);
        }

        protected void btnutil24allShow_Click(object sender, EventArgs e)
        {
            string un = Session["UserName"].ToString();
            string salestype = "renewal";
            if (lblCurrentSupplier.Text == "utilita" || lblCurrentSupplier.Text == "UTILITA")
            {
                salestype = "Acquisition";
            }

            string allunit = "0";

            allunit = txtutila24dayall.Text;


            string TL = Session["mytl"].ToString();
            string MPR = "";
            string SupplyNumber = Session["mpan"].ToString();
            string quot = ps.Storebasicdetas(txtBusiness.Text, un, lblCurrentSupplier.Text, "electricity", lblProfile.Text + lblMTC.Text + lblRegion.Text, lblStartdate.Text, "24", winclose, txtBusiness.Text, lblCurrentSupplier.Text, "UTILITA", lblELEPayment.Text, "NO", lblEac.Text, salestype, txtBusiness.Text, allunit, txtutila24upliftall.Text, txtutil24Rateall.Text, txtutila24scall.Text, txtutil24Rateall.Text, TL, SupplyNumber, MPR, txtutila24nightall.Text, txtutila24ewall.Text, allunit, txtutila24offpeakall.Text);
            Response.Redirect("quotstion.aspx?prop=" + quot);
        }

        protected void btnutil36allShow_Click(object sender, EventArgs e)
        {
            string un = Session["UserName"].ToString();
            string salestype = "renewal";
            if (lblCurrentSupplier.Text == "utilita" || lblCurrentSupplier.Text == "UTILITA")
            {
                salestype = "Acquisition";
            }

            string allunit = "0";

            allunit = txtutila36dayall.Text;


            string TL = Session["mytl"].ToString();
            string MPR = "";
            string SupplyNumber = Session["mpan"].ToString();
            string quot = ps.Storebasicdetas(txtBusiness.Text, un, lblCurrentSupplier.Text, "electricity", lblProfile.Text + lblMTC.Text + lblRegion.Text, lblStartdate.Text, "36", winclose, txtBusiness.Text, lblCurrentSupplier.Text, "UTILITA", lblELEPayment.Text, "NO", lblEac.Text, salestype, txtBusiness.Text, allunit, txtutila36upliftall.Text, txtutil36Rateall.Text, txtutila36scall.Text, txtutil36Rate.Text, TL, SupplyNumber, MPR, txtutila36nightall.Text, txtutila36ewall.Text, allunit, txtutila36offpeakall.Text);
            Response.Redirect("quotstion.aspx?prop=" + quot);
        }

        protected void btnutil48allShow_Click(object sender, EventArgs e)
        {
            string un = Session["UserName"].ToString();
            string salestype = "renewal";
            if (lblCurrentSupplier.Text == "utilita" || lblCurrentSupplier.Text == "UTILITA")
            {
                salestype = "Acquisition";
            }

            string allunit = "0";

            allunit = txtutila48dayall.Text;


            string TL = Session["mytl"].ToString();
            string MPR = "";
            string SupplyNumber = Session["mpan"].ToString();
            string quot = ps.Storebasicdetas(txtBusiness.Text, un, lblCurrentSupplier.Text, "electricity", lblProfile.Text + lblMTC.Text + lblRegion.Text, lblStartdate.Text, "48", winclose, txtBusiness.Text, lblCurrentSupplier.Text, "UTILITA", lblELEPayment.Text, "NO", lblEac.Text, salestype, txtBusiness.Text, allunit, txtutila48uplift.Text, txtutil48Rateall.Text, txtutila48scall.Text, txtutil48Rateall.Text, TL, SupplyNumber, MPR, txtutila36nightall.Text, txtutila48ewall.Text, allunit, txtutila48offpeakall.Text);
            Response.Redirect("quotstion.aspx?prop=" + quot);
        }
         
        #endregion
        //protected void btn12_Click(object sender, EventArgs e)
        //{
        //    Multiview1.SetActiveView(View12);
        //    lblDuration.Text = "12";
        //}

        //protected void btn24_Click(object sender, EventArgs e)
        //{
        //    Multiview1.SetActiveView(View24);
        //    lblDuration.Text = "24";
        //}

        //protected void btn36_Click(object sender, EventArgs e)
        //{
        //    Multiview1.SetActiveView(View36);
        //    lblDuration.Text = "36";
        //}



        //protected void btn48_Click(object sender, EventArgs e)
        //{
        //    Multiview1.SetActiveView(View48);
        //    lblDuration.Text = "48";
        //}

        //protected void btn60_Click(object sender, EventArgs e)
        //{
        //    Multiview1.SetActiveView(View60);
        //    lblDuration.Text = "60";
        //}

        //protected void btnAll_Click(object sender, EventArgs e)
        //{
        //    Multiview1.SetActiveView(Viewall);
        //    lblDuration.Text = "All";

        //}
    }
}