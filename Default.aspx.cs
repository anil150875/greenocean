using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Drawing;

namespace GreenOcean
{
    

    public partial class _Default : Page
    {
        //  string myConnectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;

        string myConnectionString = "Data Source=DESKTOP-19DCAF9;Initial Catalog = greenway; Integrated Security = True";
        void getbgplan()
        {
            SqlConnection con = new SqlConnection(myConnectionString);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();


            }
           
            SqlCommand cmd = new SqlCommand("select top 1 bg from mtc where  mtccode = @mtccode", con);
            cmd.Parameters.AddWithValue("@mtccode", lblMTCR.Text);
            lblBGEMetertype.Text = Convert.ToString(cmd.ExecuteScalar());
            con.Close();


        }

        void getbgliteplan()
        {
            SqlConnection con = new SqlConnection(myConnectionString);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();


            }
           

            SqlCommand cmd = new SqlCommand("select top 1 bgl  from mtc where  mtccode = @mtccode", con);
            cmd.Parameters.AddWithValue("@mtccode", lblMTCR.Text);
            lblBGLMetertype.Text = Convert.ToString(cmd.ExecuteScalar());
            con.Close();


        }

        void getdeeplan()
        {
            SqlConnection con = new SqlConnection(myConnectionString);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();


            }


            SqlCommand cmd = new SqlCommand("select top 1 de  from mtc where  mtccode = @mtccode", con);
            cmd.Parameters.AddWithValue("@mtccode", lblMTCR.Text);
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
           
            SqlCommand cmd = new SqlCommand("select top 1 edfe  from mtc where  mtccode = @mtccode", con);
            cmd.Parameters.AddWithValue("@mtccode", lblMTCR.Text);
            lblEDFMetertype.Text = Convert.ToString(cmd.ExecuteScalar());
            con.Close();


        }

       

        /// <summary>
        /// 
        /// </summary>
        private void BindBGE()
        {


            SqlConnection con = new SqlConnection(myConnectionString);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();


            }
            SqlCommand bgcmd = new SqlCommand();

          //  string mycommand = "select PriceLineDescription, unitcharge , unittype ,  (unitcharge * 365) /100 as yearlycharge ,( unitcharge + " + upliftvalue + " ) as uplift from bgea where ConsumptionRange =@ConsumptionRange and  RegionPES = @RegionPES and ProfileClass = @ProfileClass and ContractDuration = @ContractDuration and PaymentMethod = @PaymentMethod AND WindowOpen >= @WindowOpen and windowclose <= @windowclose and MeterType = @MeterType  ";

            SqlDataAdapter SQLAdapter = new SqlDataAdapter(@"select windowopen , windowclose , PriceLineDescription, unitcharge , unittype  , ContractDuration , SalesType , ConsumptionRange from bgea where ConsumptionRange ='" + txtConsumption.Text+ "' and ProfileClass = '" +lblProfile.Text+ "' and RegionPES ='" +lblRegion.Text+ "' and  ContractDuration = '" +txtContract.Text+ "'  and MeterType ='" +lblBGEMetertype.Text+ "'and PaymentMethod ='" +txtPaymentMethod.Text+ "' and windowopen >='"+ cdStartDate.SelectedDate + "' and  windowclose <= ' " + cdEndDate.SelectedDate + "'", con);
            DataTable DT = new DataTable();
            SQLAdapter.Fill(DT);
            gvBGE.DataSource = DT;
            gvBGE.DataBind();
        }


        private void BindBGR()
        {


            SqlConnection con = new SqlConnection(myConnectionString);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();


            }
            SqlCommand bgcmd = new SqlCommand();

            //  string mycommand = "select PriceLineDescription, unitcharge , unittype ,  (unitcharge * 365) /100 as yearlycharge ,( unitcharge + " + upliftvalue + " ) as uplift from bgea where ConsumptionRange =@ConsumptionRange and  RegionPES = @RegionPES and ProfileClass = @ProfileClass and ContractDuration = @ContractDuration and PaymentMethod = @PaymentMethod AND WindowOpen >= @WindowOpen and windowclose <= @windowclose and MeterType = @MeterType  ";

            SqlDataAdapter SQLAdapter = new SqlDataAdapter(@"select windowopen , windowclose , PriceLineDescription, unitcharge , unittype  , ContractDuration , SalesType , ConsumptionRange from bger  where ConsumptionRange ='" + txtConsumption.Text + "' and ProfileClass = '" + lblProfile.Text + "' and RegionPES ='" + lblRegion.Text + "' and  ContractDuration = '" + txtContract.Text + "'  and MeterType ='" + lblBGEMetertype.Text + "'and PaymentMethod ='" + txtPaymentMethod.Text + "'and windowopen >='" + cdStartDate.SelectedDate + "' and  windowclose <= ' " + cdEndDate.SelectedDate + "'", con);
            DataTable DT = new DataTable();
            SQLAdapter.Fill(DT);
            gvBGR.DataSource = DT;
            gvBGR.DataBind();
        }


        private void BindBGL()
        {


            SqlConnection con = new SqlConnection(myConnectionString);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();


            }
            SqlCommand bgcmd = new SqlCommand();

            //  string mycommand = "select PriceLineDescription, unitcharge , unittype ,  (unitcharge * 365) /100 as yearlycharge ,( unitcharge + " + upliftvalue + " ) as uplift from bgea where ConsumptionRange =@ConsumptionRange and  RegionPES = @RegionPES and ProfileClass = @ProfileClass and ContractDuration = @ContractDuration and PaymentMethod = @PaymentMethod AND WindowOpen >= @WindowOpen and windowclose <= @windowclose and MeterType = @MeterType  ";

            SqlDataAdapter SQLAdapter = new SqlDataAdapter(@"select windowopen , windowclose , PriceLineDescription, unitcharge , unittype  , ContractDuration , SalesType , ConsumptionRange  from bgl where ConsumptionRange ='" + txtConsumption.Text + "' and ProfileClass = '" + lblProfile.Text + "' and RegionPES ='" + lblRegion.Text + "' and  ContractDuration = '" + txtContract.Text + "'  and MeterType ='" + lblBGLMetertype.Text + "'and PaymentMethod ='" + txtPaymentMethod.Text + "'and windowopen >='" + cdStartDate.SelectedDate + "' and  windowclose <= ' " + cdEndDate.SelectedDate + "' AND SalesType ='Acquisition'", con);
            DataTable DT = new DataTable();
            SQLAdapter.Fill(DT);
            gvBGL.DataSource = DT;
            gvBGL.DataBind();
        }

        private void BindBGLRENW()
        {


            SqlConnection con = new SqlConnection(myConnectionString);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();


            }
            SqlCommand bgcmd = new SqlCommand();

            //  string mycommand = "select PriceLineDescription, unitcharge , unittype ,  (unitcharge * 365) /100 as yearlycharge ,( unitcharge + " + upliftvalue + " ) as uplift from bgea where ConsumptionRange =@ConsumptionRange and  RegionPES = @RegionPES and ProfileClass = @ProfileClass and ContractDuration = @ContractDuration and PaymentMethod = @PaymentMethod AND WindowOpen >= @WindowOpen and windowclose <= @windowclose and MeterType = @MeterType  ";

            SqlDataAdapter SQLAdapter = new SqlDataAdapter(@"select windowopen , windowclose , PriceLineDescription, unitcharge , unittype  , ContractDuration , SalesType , ConsumptionRange  from bgl where ConsumptionRange ='" + txtConsumption.Text + "' and ProfileClass = '" + lblProfile.Text + "' and RegionPES ='" + lblRegion.Text + "' and  ContractDuration = '" + txtContract.Text + "'  and MeterType ='" + lblBGLMetertype.Text + "'and PaymentMethod ='" + txtPaymentMethod.Text + "'and windowopen >='" + cdStartDate.SelectedDate + "' and  windowclose <= ' " + cdEndDate.SelectedDate + "' and SalesType = 'Renewal' ", con);
            DataTable DT = new DataTable();
            SQLAdapter.Fill(DT);
            gvBGlRenew.DataSource = DT;
            gvBGlRenew.DataBind();
        }


        private void BindDEE()
        {


            SqlConnection con = new SqlConnection(myConnectionString);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();


            }
            SqlCommand bgcmd = new SqlCommand();

            //  string mycommand = "select PriceLineDescription, unitcharge , unittype ,  (unitcharge * 365) /100 as yearlycharge ,( unitcharge + " + upliftvalue + " ) as uplift from bgea where ConsumptionRange =@ConsumptionRange and  RegionPES = @RegionPES and ProfileClass = @ProfileClass and ContractDuration = @ContractDuration and PaymentMethod = @PaymentMethod AND WindowOpen >= @WindowOpen and windowclose <= @windowclose and MeterType = @MeterType  ";

            SqlDataAdapter SQLAdapter = new SqlDataAdapter(@"select Product	,StandingCharge	,DayAllSTODOtherDayUnits as day, nightunitprice as night , EveWkendControlSTODWinterPeak as WeekEnd from dee where distid ='" + lblRegion.Text + "' and profile = '" + lblProfile.Text + "'   and MeterType ='" + lblDEMetertype.Text + "'", con);
            DataTable DT = new DataTable();
            SQLAdapter.Fill(DT);
            gvDE.DataSource = DT;
            gvDE.DataBind();
        }


        private void BindEDF()
        {


            SqlConnection con = new SqlConnection(myConnectionString);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();


            }
            SqlCommand bgcmd = new SqlCommand();

        //    string mycommand = "select * from edfELE where Contractlengthmonths= '"+ txtContract.Text+'" and Meter = '" + lblEDFMetertype.Text + "' and   region like   '%" + lblRegion.Text + "%'";

            SqlDataAdapter SQLAdapter = new SqlDataAdapter("select StandingCharge , Day, night , rank , DDDiscountEffectiveDay,	DDDiscountEffectiveNight,	DDDiscountEffectiveEveningWeekend,	ROUND from edfELE where  Contractlengthmonths ='" + txtContract.Text+ "' and meter ='"+ lblEDFMetertype.Text + "' and region like '%" + lblRegion.Text + "%' and round ='0' order by rank", con);
            DataTable DT = new DataTable();
            SQLAdapter.Fill(DT);
            gvEDF.DataSource = DT;
            gvEDF.DataBind();
        }

        /// <summary>
        /// Page loads and set first active view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                MultiView1.SetActiveView(View4);
               
            }
            else
            {
              
            }

          
            

        }

        protected void btinMpan_Click(object sender, EventArgs e)
        {
            lblRegion.Text = txtMPAN.Text.Substring(8, 2);
            lblMTCR.Text = txtMPAN.Text.Substring(2, 3);
            lblProfile.Text = txtMPAN.Text.Substring(0, 2);
            getbgplan();
            getbgliteplan();
            getedfplan();
            getdeeplan();
           // MultiView1.SetActiveView(View2);


        }

        protected void btnShowProposal_Click(object sender, EventArgs e)
        {

           
            MultiView1.SetActiveView(View3);
           

            BindBGR();
            BindBGL();
            BindBGLRENW();
            BindDEE();
            BindEDF();
            BindBGE();



        }

        protected void cdEndDate_SelectionChanged(object sender, EventArgs e)
        {
          
        }

        protected void cdStartDate_SelectionChanged(object sender, EventArgs e)
        {
           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //if(RadioButtonList1.SelectedItem.Text == "Electricity")
            //{
            //    MultiView1.SetActiveView(View1);
            //}
            //if (RadioButtonList1.SelectedItem.Text == "Gas")
            //{
            //    MultiView1.SetActiveView(View5);
            //}
            Response.Redirect("quote.aspx?businessname=" + txtBusiness.Text);
        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        protected void gvBGE_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Double totalcost = 0.0;
                if (e.Row.Cells[5].Text != "UNIT CHARGE")
                {
                    totalcost = Convert.ToDouble(e.Row.Cells[6].Text);
                    totalcost = (totalcost * 365);
                    e.Row.Cells[0].Text = totalcost.ToString();
                    e.Row.Cells[1].Text = txtUplift.Text.Trim();
                }
                else
                {

                    e.Row.Cells[0].Text = totalcost.ToString();

                }
                

            }
        }

        protected void gvBGR_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Double totalcost = 0.0;
                if (e.Row.Cells[5].Text != "UNIT CHARGE")
                {
                    totalcost = Convert.ToDouble(e.Row.Cells[6].Text);
                    totalcost = (totalcost * 365);
                    e.Row.Cells[0].Text = totalcost.ToString();
                    e.Row.Cells[1].Text = txtUplift.Text.Trim();
                }
                else
                {

                    e.Row.Cells[0].Text = totalcost.ToString();

                }
            }
        }

        protected void gvBGL_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Double totalcost = 0.0;
                if (e.Row.Cells[5].Text != "UNIT CHARGE")
                {
                    totalcost = Convert.ToDouble(e.Row.Cells[6].Text);
                    totalcost = (totalcost * 365);
                    e.Row.Cells[0].Text = totalcost.ToString();
                    e.Row.Cells[1].Text = txtUplift.Text.Trim();
                }
                else
                {

                    e.Row.Cells[0].Text = totalcost.ToString();

                }
            }

        }

        protected void gvBGlRenew_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Double totalcost = 0.0;
                if (e.Row.Cells[5].Text != "UNIT CHARGE")
                {
                    totalcost = Convert.ToDouble(e.Row.Cells[6].Text);
                    totalcost = (totalcost * 365);
                    e.Row.Cells[0].Text = totalcost.ToString();
                    e.Row.Cells[1].Text = txtUplift.Text.Trim();
                }
                else
                {

                    e.Row.Cells[0].Text = totalcost.ToString();

                }
            }
        }

        protected void gvDE_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}