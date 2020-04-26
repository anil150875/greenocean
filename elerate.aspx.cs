using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GreenOcean
{
    public partial class elerate : System.Web.UI.Page
    {

        stdlb lib = new stdlb();
        Double totalamount = 0.0;
       

        protected void Page_Load(object sender, EventArgs e)
        {

           


          
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["eac"] == null)
                {
                    Response.Redirect("Default.aspx");
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
               
                getbgplan();
              //  lblBGEMetertype.Text = lib.getbgplan(lblMTC.Text);
                getbgliteplan();
               // lblBGLMetertype.Text = lib.getbgliteplan(lblMTC.Text);
                getdeeplan();
               // lblDEMetertype.Text = lib.getdeeplan(lblMTC.Text);
                getedfplan();
               // lblEDFMetertype.Text = lib.getedfplan(lblMTC.Text);
                getnpowerplan();
              //  lblNpwer.Text = lib(lblMTC.Text);
                getgazplan();
              //  lblGZMetertype.Text = lib.getgazplan(lblMTC.Text);


                getpeplan();
              //  lblPEMetertype.Text = lib.getpeplan(lblMTC.Text);
                getspeplan();
              //  lblSPAMetertype.Text = lib.getspeplan(lblMTC.Text);
                getsseplan();
          //    lblSSEPEMetertype.Text = lib.getsseplan(lblMTC.Text);
                geteonplan();
                lblEONEMetertype.Text = lib.geteonplan(lblMTC.Text);
                BindBGE();
                BindBGR();
                BindBGL();
                BindBGLRENW();
                BindDEEnew();
                BindEDF();
                Bindnpowera();
                Bindnpowere();
                Bindnpoweral();

                Bindgazpower();
                BindPE();
               
                Bindspaa();
                Bindspae();
                bindsse();
                bindtgp();
                Bindeondd();
              //  lblBGEMetertype.Text = lib.getbgplan(lblMTC.Text);



            }
            


        }


        string myConnectionString = "Data Source=DESKTOP-19DCAF9;Initial Catalog = greenway; Integrated Security = True";
        void getbgplan()
        {
            SqlConnection con = new SqlConnection(myConnectionString);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();


            }

            SqlCommand cmd = new SqlCommand("select top 1 bg from mtc where  mtccode = @mtccode", con);
            cmd.Parameters.AddWithValue("@mtccode", lblMTC.Text);
            lblBGEMetertype.Text = Convert.ToString(cmd.ExecuteScalar());
            con.Close();


        }


        void getnpowerplan()
        {
            SqlConnection con = new SqlConnection(myConnectionString);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();


            }

            SqlCommand cmd = new SqlCommand("select top 1 npower from mtc where  mtccode = @mtccode", con);
            cmd.Parameters.AddWithValue("@mtccode", lblMTC.Text);
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


            SqlCommand cmd = new SqlCommand("select top 1 bgl  from mtc where  mtccode = @mtccode", con);
            cmd.Parameters.AddWithValue("@mtccode", lblMTC.Text);
            lblBGLMetertype.Text = Convert.ToString(cmd.ExecuteScalar());
            con.Close();


        }

        void getpeplan()
        {
            SqlConnection con = new SqlConnection(myConnectionString);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();


            }


            SqlCommand cmd = new SqlCommand("select top 1 pe   from mtc where  mtccode = @mtccode", con);
            cmd.Parameters.AddWithValue("@mtccode", lblMTC.Text);
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


            SqlCommand cmd = new SqlCommand("select top 1 sse   from mtc where  mtccode = @mtccode", con);
            cmd.Parameters.AddWithValue("@mtccode", lblMTC.Text);
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


            SqlCommand cmd = new SqlCommand("select top 1 sp   from mtc where  mtccode = @mtccode", con);
            cmd.Parameters.AddWithValue("@mtccode", lblMTC.Text);
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


            SqlCommand cmd = new SqlCommand("select top 1 SalesProductDesc   from mtc where  mtccode = @mtccode", con);
            cmd.Parameters.AddWithValue("@mtccode", lblMTC.Text);
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


            SqlCommand cmd = new SqlCommand("select top 1 de  from mtc where  mtccode = @mtccode", con);
            cmd.Parameters.AddWithValue("@mtccode", lblMTC.Text);
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
            cmd.Parameters.AddWithValue("@mtccode", lblMTC.Text);
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

            SqlCommand cmd = new SqlCommand("select top 1 gaz  from mtc where  mtccode = @mtccode", con);
            cmd.Parameters.AddWithValue("@mtccode", lblMTC.Text);
            lblGZMetertype.Text = Convert.ToString(cmd.ExecuteScalar());
            con.Close();



        }

        private void BindBGE()
        {


            SqlConnection con = new SqlConnection(myConnectionString);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();


            }
            int load = int.Parse(lblEac.Text);
            int myload = lib.Getbg(load);

            SqlCommand bgcmd = new SqlCommand();

            //  string mycommand = "select PriceLineDescription, unitcharge , unittype ,  (unitcharge * 365) /100 as yearlycharge ,( unitcharge + " + upliftvalue + " ) as uplift from bgea where ConsumptionRange =@ConsumptionRange and  RegionPES = @RegionPES and ProfileClass = @ProfileClass and ContractDuration = @ContractDuration and PaymentMethod = @PaymentMethod AND WindowOpen >= @WindowOpen and windowclose <= @windowclose and MeterType = @MeterType  ";
            string pm = "DD";
            SqlDataAdapter SQLAdapter = new SqlDataAdapter(@"select standingcharge, windowopen , windowclose , PriceLineDescription,PaymentMethod, unitcharge , unittype  , ContractDuration , SalesType , ConsumptionRange,PaymentMethod from bgea where ConsumptionRange ='" + myload + "' and ProfileClass = '" + lblProfile.Text + "' and RegionPES ='" + lblRegion.Text + "' and  ContractDuration = '" + lblDuration.Text + "'  and MeterType ='" + lblBGEMetertype.Text + "'and PaymentMethod ='" + lblELEPayment.Text + "' and windowopen >='" + lblStartdate.Text + "' ", con);
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
            int load = int.Parse(lblEac.Text);
            int myload = lib.Getbg(load);
            SqlCommand bgcmd = new SqlCommand();

            //  string mycommand = "select PriceLineDescription, unitcharge , unittype ,  (unitcharge * 365) /100 as yearlycharge ,( unitcharge + " + upliftvalue + " ) as uplift from bgea where ConsumptionRange =@ConsumptionRange and  RegionPES = @RegionPES and ProfileClass = @ProfileClass and ContractDuration = @ContractDuration and PaymentMethod = @PaymentMethod AND WindowOpen >= @WindowOpen and windowclose <= @windowclose and MeterType = @MeterType  ";

            SqlDataAdapter SQLAdapter = new SqlDataAdapter(@"select standingcharge, windowopen , windowclose , PriceLineDescription, unitcharge , unittype  , ContractDuration , SalesType , ConsumptionRange,PaymentMethod from bger where ConsumptionRange ='" + myload + "' and ProfileClass = '" + lblProfile.Text + "' and RegionPES ='" + lblRegion.Text + "' and  ContractDuration = '" + lblDuration.Text + "'  and MeterType ='" + lblBGEMetertype.Text + "'and PaymentMethod ='" + lblELEPayment.Text + "' and windowopen >='" + lblStartdate.Text + "' ", con);
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
            int load = int.Parse(lblEac.Text);
            int myload = lib.Getbg(load);

            //  string mycommand = "select PriceLineDescription, unitcharge , unittype ,  (unitcharge * 365) /100 as yearlycharge ,( unitcharge + " + upliftvalue + " ) as uplift from bgea where ConsumptionRange =@ConsumptionRange and  RegionPES = @RegionPES and ProfileClass = @ProfileClass and ContractDuration = @ContractDuration and PaymentMethod = @PaymentMethod AND WindowOpen >= @WindowOpen and windowclose <= @windowclose and MeterType = @MeterType  ";

            SqlDataAdapter SQLAdapter = new SqlDataAdapter(@"select standingcharge ,windowopen , windowclose , PriceLineDescription,PaymentMethod, unitcharge , unittype  , ContractDuration , SalesType , ConsumptionRange ,PaymentMethod  from bgl where ConsumptionRange ='" + myload + "' and ProfileClass = '" + lblProfile.Text + "' and RegionPES ='" + lblRegion.Text + "' and  ContractDuration = '" + lblDuration.Text + "'  and MeterType ='" + lblBGLMetertype.Text + "'and PaymentMethod ='" + lblELEPayment.Text + "'and windowopen >='" + lblStartdate.Text + "'  AND SalesType ='Acquisition'", con);
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
            int load = int.Parse(lblEac.Text);
            int myload = lib.Getbg(load);

            //  string mycommand = "select PriceLineDescription, unitcharge , unittype ,  (unitcharge * 365) /100 as yearlycharge ,( unitcharge + " + upliftvalue + " ) as uplift from bgea where ConsumptionRange =@ConsumptionRange and  RegionPES = @RegionPES and ProfileClass = @ProfileClass and ContractDuration = @ContractDuration and PaymentMethod = @PaymentMethod AND WindowOpen >= @WindowOpen and windowclose <= @windowclose and MeterType = @MeterType  ";

            SqlDataAdapter SQLAdapter = new SqlDataAdapter(@"select standingcharge, windowopen , windowclose , PriceLineDescription, PaymentMethod, unitcharge , unittype  , ContractDuration , SalesType , ConsumptionRange ,PaymentMethod from bgl where ConsumptionRange ='" + myload + "' and ProfileClass = '" + lblProfile.Text + "' and RegionPES ='" + lblRegion.Text + "' and  ContractDuration = '" + lblDuration.Text + "'  and MeterType ='" + lblBGLMetertype.Text + "'and PaymentMethod ='" + lblELEPayment.Text + "'and windowopen >='" + lblStartdate.Text + "'  AND SalesType ='Renewal'", con);
            DataTable DT = new DataTable();
           // DataTable DT = new DataTable();
            SQLAdapter.Fill(DT);
            gvBGlRenew.DataSource = DT;
            gvBGlRenew.DataBind();
        }


        private void Bindgazpower()
        {


            SqlConnection con = new SqlConnection(myConnectionString);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();


            }
            SqlCommand bgcmd = new SqlCommand();
            int duration = int.Parse(lblDuration.Text);
            duration = duration / 12;

            //  string mycommand = "select PriceLineDescription, unitcharge , unittype ,  (unitcharge * 365) /100 as yearlycharge ,( unitcharge + " + upliftvalue + " ) as uplift from bgea where ConsumptionRange =@ConsumptionRange and  RegionPES = @RegionPES and ProfileClass = @ProfileClass and ContractDuration = @ContractDuration and PaymentMethod = @PaymentMethod AND WindowOpen >= @WindowOpen and windowclose <= @windowclose and MeterType = @MeterType  ";

            SqlDataAdapter SQLAdapter = new SqlDataAdapter(@"select * from gazprom  where ContractDuration like '%" +duration + "%' and  ProfileClass = '" + lblProfile.Text + "' and dno ='" + lblRegion.Text + "' and Meter ='" + lblGZMetertype.Text + "' and gdate ='before 30-Jun-2020'", con);
            DataTable DT = new DataTable();
            // DataTable DT = new DataTable();
            SQLAdapter.Fill(DT);
            gvgaz.DataSource = DT;
            gvgaz.DataBind();
        }


        private void Bindnpowera()
        {


            SqlConnection con = new SqlConnection(myConnectionString);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();


            }
            SqlCommand bgcmd = new SqlCommand();
            int duration = int.Parse(lblDuration.Text);
            duration = duration / 12;
            string myduration = duration.ToString();
            DateTime dt = Convert.ToDateTime(lblStartdate.Text);
            string cmonth = dt.ToString("MMM");
            int load = int.Parse(lblEac.Text);
            int myload = lib.getnpowerload(load);





            SqlDataAdapter SQLAdapter = new SqlDataAdapter(@"select *  from npowera  where rate_type ='" + lblNpwer.Text + "' and pc  = '" + lblProfile.Text + "' and pes ='" + lblRegion.Text + "' and duration='" + myduration + "'  and month ='" + cmonth + "' and volume_max = '" + myload + "'" , con);
            DataTable DT = new DataTable();
            // DataTable DT = new DataTable();
            SQLAdapter.Fill(DT);
            gvNpowerA.DataSource = DT;
            gvNpowerA.DataBind();
        }

        private void Bindnpowere()
        {


            SqlConnection con = new SqlConnection(myConnectionString);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();


            }
            SqlCommand bgcmd = new SqlCommand();
            int duration = int.Parse(lblDuration.Text);
            duration = duration / 12;
            string myduration = duration.ToString();
            DateTime dt = Convert.ToDateTime(lblStartdate.Text);
            string cmonth = dt.ToString("MMM");
            int load = int.Parse(lblEac.Text);
            int myload = lib.getnpowerload(load);




            //  string mycommand = "select PriceLineDescription, unitcharge , unittype ,  (unitcharge * 365) /100 as yearlycharge ,( unitcharge + " + upliftvalue + " ) as uplift from bgea where ConsumptionRange =@ConsumptionRange and  RegionPES = @RegionPES and ProfileClass = @ProfileClass and ContractDuration = @ContractDuration and PaymentMethod = @PaymentMethod AND WindowOpen >= @WindowOpen and windowclose <= @windowclose and MeterType = @MeterType  ";


            SqlDataAdapter SQLAdapter = new SqlDataAdapter(@"select *  from npowere  where rate_type ='" + lblNpwer.Text + "' and pc  = '" + lblProfile.Text + "' and pes ='" + lblRegion.Text + "' and duration='" + myduration + "'  and month ='" + cmonth + "' and volume_max = '" + myload + "'" , con);
            DataTable DT = new DataTable();
            // DataTable DT = new DataTable();
            SQLAdapter.Fill(DT);
            gvnpowere.DataSource = DT;
            gvnpowere.DataBind();
        }

        private void Bindnpoweral()
        {


            SqlConnection con = new SqlConnection(myConnectionString);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();


            }
            SqlCommand bgcmd = new SqlCommand();
            int duration = int.Parse(lblDuration.Text);
            duration = duration / 12;
            string myduration = duration.ToString();
            DateTime dt = Convert.ToDateTime(lblStartdate.Text);
            string cmonth = dt.ToString("MMM");
            int load = int.Parse(lblEac.Text);
            int myload = lib.getnpowerload(load);




            //  string mycommand = "select PriceLineDescription, unitcharge , unittype ,  (unitcharge * 365) /100 as yearlycharge ,( unitcharge + " + upliftvalue + " ) as uplift from bgea where ConsumptionRange =@ConsumptionRange and  RegionPES = @RegionPES and ProfileClass = @ProfileClass and ContractDuration = @ContractDuration and PaymentMethod = @PaymentMethod AND WindowOpen >= @WindowOpen and windowclose <= @windowclose and MeterType = @MeterType  ";


            SqlDataAdapter SQLAdapter = new SqlDataAdapter(@"select *  from npoweral  where rate_type ='" + lblNpwer.Text + "' and pc  = '" + lblProfile.Text + "' and pes ='" + lblRegion.Text + "' and duration='" + myduration + "'  and month ='" + cmonth + "' and volume_max = '" + myload + "'", con);
            DataTable DT = new DataTable();
            
            SQLAdapter.Fill(DT);
            gvnpoweral.DataSource = DT;
            gvnpoweral.DataBind();
        }


        private void BindDEEnew()
        {


            SqlConnection con = new SqlConnection(myConnectionString);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();


            }
            SqlCommand bgcmd = new SqlCommand();

            //  string mycommand = "select PriceLineDescription, unitcharge , unittype ,  (unitcharge * 365) /100 as yearlycharge ,( unitcharge + " + upliftvalue + " ) as uplift from bgea where ConsumptionRange =@ConsumptionRange and  RegionPES = @RegionPES and ProfileClass = @ProfileClass and ContractDuration = @ContractDuration and PaymentMethod = @PaymentMethod AND WindowOpen >= @WindowOpen and windowclose <= @windowclose and MeterType = @MeterType  ";
            string product = "";
            if (lblDuration.Text == "12")
            {
                product = "SmartFIX – 1 Year";
            }

            if (lblDuration.Text == "24")
            {
                product = "SmartFIX – 2 Year";
            }
            if (lblDuration.Text == "36")
            {
                product = "SmartFIX – 3 Year";
            }
            if (lblDuration.Text == "60")
            {
                product = "SmartFIX – 5 Year";
            }



            if (lblDuration.Text =="12")
            {
                SqlDataAdapter SQLAdapter = new SqlDataAdapter(@"select Product	,StandingCharge	,DayAllSTODOtherDayUnits , nightunitprice  , EveWkendControlSTODWinterPeak, EffectiveToDate, EffectiveFromDate  from dee where distid ='" + lblRegion.Text + "' and profile = '" + lblProfile.Text + "'   and MeterType ='" + lblDEMetertype.Text + "' and  product = '" + product + "'" , con);
                DataTable DT = new DataTable();
                SQLAdapter.Fill(DT);
                gvDE.DataSource = DT;
                gvDE.DataBind();
            }
            
            
            
           
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

            SqlDataAdapter SQLAdapter = new SqlDataAdapter("select StandingCharge , Meter ,Contract, Day, night , rank , EveningWeekend,DDDiscountEffectiveDay,	DDDiscountEffectiveNight,	DDDiscountEffectiveEveningWeekend,	ROUND from edfELE where  Contractlengthmonths ='" + lblDuration.Text + "' and meter ='" + lblEDFMetertype.Text + "' and region like '%" + lblRegion.Text + "%' and round ='0' order by rank", con);
            DataTable DT = new DataTable();
            SQLAdapter.Fill(DT);
            gvEDF.DataSource = DT;
            gvEDF.DataBind();
        }

        private void BindPE()
        {


            SqlConnection con = new SqlConnection(myConnectionString);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();


            }
            SqlCommand bgcmd = new SqlCommand();

            //    string mycommand = "select * from edfELE where Contractlengthmonths= '"+ txtContract.Text+'" and Meter = '" + lblEDFMetertype.Text + "' and   region like   '%" + lblRegion.Text + "%'";

            SqlDataAdapter SQLAdapter = new SqlDataAdapter("select * from positive  where   Tariffname ='" + lblPEMetertype.Text + "' and DistributerID  like '%" + lblRegion.Text + "%' and pcs = '" +lblProfile.Text+ "'", con);
            DataTable DT = new DataTable();
            SQLAdapter.Fill(DT);          
            gvpe.DataSource = DT;
            if(lblDuration.Text == "12")
            {
                gvpe.DataSource = DT;
                gvpe.DataBind();
            }
            if(lblDuration.Text == "24")
            {
                gvpe24.DataSource = DT;
                gvpe24.DataBind();
            }

            if (lblDuration.Text == "36")
            {
                gvpe36.DataSource = DT;
                gvpe36.DataBind();
            }

        }


        private void Bindspaa()
        {


            SqlConnection con = new SqlConnection(myConnectionString);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();


            }
            SqlCommand bgcmd = new SqlCommand();
            int load = int.Parse(lblEac.Text);
            int myload = lib.Getbg(load);
            int fixedrate = int.Parse(lblDuration.Text);
            fixedrate = fixedrate / 12;


            //  string mycommand = "select PriceLineDescription, unitcharge , unittype ,  (unitcharge * 365) /100 as yearlycharge ,( unitcharge + " + upliftvalue + " ) as uplift from bgea where ConsumptionRange =@ConsumptionRange and  RegionPES = @RegionPES and ProfileClass = @ProfileClass and ContractDuration = @ContractDuration and PaymentMethod = @PaymentMethod AND WindowOpen >= @WindowOpen and windowclose <= @windowclose and MeterType = @MeterType  ";

            SqlDataAdapter SQLAdapter = new SqlDataAdapter(@"select *  from spaa where  ProfileClass = '" + lblProfile.Text + "' and area  ='" + lblRegion.Text + "' and  FixedRatePeriod = '" + fixedrate + "'  and Meterype ='" + lblSPAMetertype.Text + "' and OnSaleFrom >='" + lblStartdate.Text + "' ", con);
            DataTable DT = new DataTable();
            // DataTable DT = new DataTable();
            SQLAdapter.Fill(DT);
            gvspaa.DataSource = DT;
            gvspaa.DataBind();
        }

        private void Bindspae()
        {


            SqlConnection con = new SqlConnection(myConnectionString);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();


            }
            SqlCommand bgcmd = new SqlCommand();
            int load = int.Parse(lblEac.Text);
            int myload = lib.Getbg(load);
            int fixedrate = int.Parse(lblDuration.Text);
            fixedrate = fixedrate / 12;


            //  string mycommand = "select PriceLineDescription, unitcharge , unittype ,  (unitcharge * 365) /100 as yearlycharge ,( unitcharge + " + upliftvalue + " ) as uplift from bgea where ConsumptionRange =@ConsumptionRange and  RegionPES = @RegionPES and ProfileClass = @ProfileClass and ContractDuration = @ContractDuration and PaymentMethod = @PaymentMethod AND WindowOpen >= @WindowOpen and windowclose <= @windowclose and MeterType = @MeterType  ";

            SqlDataAdapter SQLAdapter = new SqlDataAdapter(@"select *  from spae where  ProfileClass = '" + lblProfile.Text + "' and area  ='" + lblRegion.Text + "' and  FixedRatePeriod = '" + fixedrate + "'  and Meterype ='" + lblSPAMetertype.Text + "' and OnSaleFrom >='" + lblStartdate.Text + "' ", con);
            DataTable DT = new DataTable();
            // DataTable DT = new DataTable();
            SQLAdapter.Fill(DT);
            gvspae.DataSource = DT;
            gvspae.DataBind();
        }


        private void bindsse()
        {


            SqlConnection con = new SqlConnection(myConnectionString);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();


            }
            SqlCommand bgcmd = new SqlCommand();
            int load = int.Parse(lblEac.Text);
            int myload = lib.Getbg(load);
            int fixedrate = int.Parse(lblDuration.Text);
            fixedrate = fixedrate / 12;


            //  string mycommand = "select PriceLineDescription, unitcharge , unittype ,  (unitcharge * 365) /100 as yearlycharge ,( unitcharge + " + upliftvalue + " ) as uplift from bgea where ConsumptionRange =@ConsumptionRange and  RegionPES = @RegionPES and ProfileClass = @ProfileClass and ContractDuration = @ContractDuration and PaymentMethod = @PaymentMethod AND WindowOpen >= @WindowOpen and windowclose <= @windowclose and MeterType = @MeterType  ";

            SqlDataAdapter SQLAdapter = new SqlDataAdapter(@"select *  from sse  where  PROFILECODE = '" + lblProfile.Text + "' and Distributor  like '%" + lblRegion.Text + "%' and   SSE_Structure ='" + lblSSEPEMetertype.Text + "' and Contract_Start >='" + lblStartdate.Text + "' ", con);
            DataTable DT = new DataTable();
            // DataTable DT = new DataTable();
            SQLAdapter.Fill(DT);
            gvsse.DataSource = DT;
            gvsse.DataBind();
        }

        private void bindtgp()
        {


            SqlConnection con = new SqlConnection(myConnectionString);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();


            }
            SqlCommand bgcmd = new SqlCommand();
            int load = int.Parse(lblEac.Text);
            int myload = lib.Getbg(load);
            int fixedrate = int.Parse(lblDuration.Text);
            fixedrate = fixedrate / 12;


            //  string mycommand = "select PriceLineDescription, unitcharge , unittype ,  (unitcharge * 365) /100 as yearlycharge ,( unitcharge + " + upliftvalue + " ) as uplift from bgea where ConsumptionRange =@ConsumptionRange and  RegionPES = @RegionPES and ProfileClass = @ProfileClass and ContractDuration = @ContractDuration and PaymentMethod = @PaymentMethod AND WindowOpen >= @WindowOpen and windowclose <= @windowclose and MeterType = @MeterType  ";

            SqlDataAdapter SQLAdapter = new SqlDataAdapter(@"select *  from tgp   where  Profiles = '" + lblProfile.Text + "' and Region  like '%" + lblRegion.Text + "%' and   mtc  like '%" + lblMTC.Text + "%'   and ContractLength ='" + lblDuration.Text + "'", con);
            DataTable DT = new DataTable();
            // DataTable DT = new DataTable();
            SQLAdapter.Fill(DT);
            gvTGP.DataSource = DT;
            gvTGP.DataBind();
        }


        private void Bindeondd()
        {


            SqlConnection con = new SqlConnection(myConnectionString);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();


            }
            int load = int.Parse(lblEac.Text);
            int myload = lib.Getbg(load);
            SqlCommand bgcmd = new SqlCommand();

            //  string mycommand = "select PriceLineDescription, unitcharge , unittype ,  (unitcharge * 365) /100 as yearlycharge ,( unitcharge + " + upliftvalue + " ) as uplift from bgea where ConsumptionRange =@ConsumptionRange and  RegionPES = @RegionPES and ProfileClass = @ProfileClass and ContractDuration = @ContractDuration and PaymentMethod = @PaymentMethod AND WindowOpen >= @WindowOpen and windowclose <= @windowclose and MeterType = @MeterType  ";

            SqlDataAdapter SQLAdapter = new SqlDataAdapter(@"select top 1 *  from eonelec  where MaxAQ  ='" + myload + "' and Profile = '" + lblProfile.Text + "' and region ='" + lblRegion.Text + "' and  ContractLength like  '%" + lblDuration.Text + "%'  and Product  like '%" + lblEONEMetertype.Text + "%'  ", con);
            DataTable DT = new DataTable();
            SQLAdapter.Fill(DT);
            gvEonDD.DataSource = DT;
            gvEonDD.DataBind();
        }






        protected void gvBGE_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
               
                if (e.Row.Cells[2].Text == "Standing Charge")
                {
                    
                    txtbgasccharge.Text = Convert.ToString(e.Row.Cells[7].Text);
                    lblbgasc.Text = Convert.ToString(e.Row.Cells[7].Text);

                }
                if (e.Row.Cells[2].Text == "NIGHT UNIT CHARGE")
                {
                   
                    txtbgaNightPrice.Text = Convert.ToString(e.Row.Cells[7].Text);
                    lblbganight.Text = txtbgaNightPrice.Text;

                }


                if (e.Row.Cells[2].Text == "UNIT CHARGE" || e.Row.Cells[2].Text == "WEEKDAY DAY UNIT CHARGE" || e.Row.Cells[2].Text == "DAY UNIT CHARGE")
                {
                    txtbgaPrice.Text = Convert.ToString( e.Row.Cells[7].Text);
                    lblbgaday.Text = txtbgaPrice.Text;
                }

                if (e.Row.Cells[2].Text == "EVENINGWEEKENDUNITCHARGE")
                {

                    txtbgaWeekend.Text = Convert.ToString(e.Row.Cells[7].Text);
                    lblbgaweekend.Text = txtbgaWeekend.Text;
                }


                txtbgafinalvalue.Text = totalamount.ToString();
               
            }


        }

        protected void gvBGR_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
               
                if (e.Row.Cells[2].Text == "Standing Charge")
                {

                    txtbgrsccharge.Text = Convert.ToString(e.Row.Cells[7].Text);
                    lblbgrsc.Text = Convert.ToString(e.Row.Cells[7].Text);

                }
                if (e.Row.Cells[2].Text == "NIGHT UNIT CHARGE")
                {

                    txtbgrnight.Text = Convert.ToString(e.Row.Cells[7].Text);
                    lblbgrnight.Text = txtbgrnight.Text;

                }


                if (e.Row.Cells[2].Text == "UNIT CHARGE" || e.Row.Cells[2].Text == "WEEKDAY DAY UNIT CHARGE" || e.Row.Cells[2].Text == "DAY UNIT CHARGE")
                {
                    txtbgrprice.Text = Convert.ToString(e.Row.Cells[7].Text);
                    lblbgrday.Text = txtbgrprice.Text;
                }

                if (e.Row.Cells[2].Text == "EVENINGWEEKENDUNITCHARGE")
                {

                    txtbgrweekend.Text = Convert.ToString(e.Row.Cells[7].Text);
                    lblbgrweekend.Text = txtbgrweekend.Text;
                }

                
               
            }

        }

        protected void gvBGL_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[2].Text == "Standing Charge")
                {

                    txtbglasccharge.Text = Convert.ToString(e.Row.Cells[7].Text);
                    lblbglasccharge.Text = Convert.ToString(e.Row.Cells[7].Text);

                }
                if (e.Row.Cells[2].Text == "NIGHT UNIT CHARGE")
                {

                    txtbglanight.Text = Convert.ToString(e.Row.Cells[7].Text);
                    lblbglanight.Text = txtbglanight.Text;

                }


                if (e.Row.Cells[2].Text == "UNIT CHARGE" || e.Row.Cells[2].Text == "WEEKDAY DAY UNIT CHARGE" || e.Row.Cells[2].Text == "DAY UNIT CHARGE")
                {
                    txtbglaprice.Text = Convert.ToString(e.Row.Cells[7].Text);
                    lblbgladay.Text = txtbglaprice.Text;
                }

                if (e.Row.Cells[2].Text == "EVENINGWEEKENDUNITCHARGE")
                {

                    txtbglaweekend.Text = Convert.ToString(e.Row.Cells[7].Text);
                    lblbglaweekend.Text = txtbglaweekend.Text;
                }

            }
        }

        protected void gvBGlRenew_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[2].Text == "Standing Charge")
                {

                    txtbglesccharge.Text = Convert.ToString(e.Row.Cells[7].Text);
                    lblbglesccharge.Text = Convert.ToString(e.Row.Cells[7].Text);

                }
                if (e.Row.Cells[2].Text == "NIGHT UNIT CHARGE")
                {

                    txtbglenight.Text = Convert.ToString(e.Row.Cells[7].Text);
                    lblbglenight.Text = txtbglenight.Text;

                }


                if (e.Row.Cells[2].Text == "UNIT CHARGE" || e.Row.Cells[2].Text == "WEEKDAY DAY UNIT CHARGE" || e.Row.Cells[2].Text == "DAY UNIT CHARGE")
                {
                    txtbgleprice.Text = Convert.ToString(e.Row.Cells[7].Text);
                    lblbgleday.Text = txtbgleprice.Text;
                }

                if (e.Row.Cells[2].Text == "EVENINGWEEKENDUNITCHARGE")
                {

                    txtbgleweekend.Text = Convert.ToString(e.Row.Cells[7].Text);
                    lblbgleweekend.Text = txtbgleweekend.Text;
                }
            }

        }

        protected void gvDE_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

      

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Double totalcost = 0.0;
                if (e.Row.Cells[1].Text != "UNIT CHARGE")
                {
                    totalcost = Convert.ToDouble(e.Row.Cells[6].Text);
                    totalcost = (totalcost * 365)/100;
                    totalcost = Math.Round(totalcost);
                    e.Row.Cells[8].Text = totalcost.ToString();
                   

                }
                else
                {
                    totalcost = 0.0;
                    totalcost = Convert.ToDouble(e.Row.Cells[6].Text) * Convert.ToDouble(e.Row.Cells[5].Text);
                    totalcost = (totalcost * 365)/100;
                    totalcost = Math.Round(totalcost);
                    e.Row.Cells[8].Text = totalcost.ToString();

                }
            }

        }

      
        protected void txtbgauplift_TextChanged(object sender, EventArgs e)
        {
         
            double actualprice = Convert.ToDouble(txtbgaPrice.Text);
            double eac = Convert.ToDouble(lblEac.Text);
            double sc = Convert.ToDouble(lblbgasc.Text);
            
            double finalvalue = Convert.ToDouble(txtbgafinalvalue.Text);
            double upliftvalue = Convert.ToDouble(txtbgauplift.Text);
            txtbgaPrice.Text = actualprice.ToString();
            double  finalprice = actualprice + Convert.ToDouble(txtbgauplift.Text);
            double dayprice = Convert.ToDouble(lblbgaday.Text) + Convert.ToDouble(txtbgauplift.Text);
            double nightprice = Convert.ToDouble(lblbganight.Text) + Convert.ToDouble(txtbgauplift.Text);
            double weekend = Convert.ToDouble(lblbgaweekend.Text) + Convert.ToDouble(txtbgauplift.Text);

            txtbgaPrice.Text = dayprice.ToString();

            if(lblbganight.Text != "0")
            {
                txtbgaNightPrice.Text = nightprice.ToString();
            }
           
            if(lblbgaweekend.Text != "0")
            {
                txtbgaWeekend.Text = weekend.ToString();
            }
            if(lblBGEMetertype.Text == "Single Rate")
            {
                finalvalue = lib.SingleRatebg(sc, dayprice, eac);
                txtbgafinalvalue.Text = finalvalue.ToString();
            }

            if (lblBGEMetertype.Text == "Day & Night")
            {
                finalvalue = lib.Daynight(sc, dayprice, nightprice, eac);
                txtbgafinalvalue.Text = finalvalue.ToString();
            }
            if(lblBGEMetertype.Text == "Eve/Weekend & Night")
            {
                finalvalue = lib.Ewn(sc, dayprice, nightprice, weekend, eac);
                txtbgafinalvalue.Text = finalvalue.ToString();

            }

            if (lblBGEMetertype.Text == "Eve/Weekend")
            {
                finalvalue = lib.EW(sc, dayprice,  weekend, eac);
                txtbgafinalvalue.Text = finalvalue.ToString();

            }


            



        }

        protected void txtbgruplift_TextChanged(object sender, EventArgs e)
        {
            double actualprice = Convert.ToDouble(txtbgrprice.Text);
            double eac = Convert.ToDouble(lblEac.Text);
            double sc = Convert.ToDouble(lblbgasc.Text);

            double finalvalue = Convert.ToDouble(txtbgrfinalvalue.Text);
            double upliftvalue = Convert.ToDouble(txtbgruplift.Text);
            txtbgrprice.Text = actualprice.ToString();
            double finalprice = actualprice + Convert.ToDouble(txtbgruplift.Text);
            double dayprice = Convert.ToDouble(lblbgrday.Text) + Convert.ToDouble(txtbgruplift.Text);
            double nightprice = Convert.ToDouble(lblbgrnight.Text) + Convert.ToDouble(txtbgruplift.Text);
            double weekend = Convert.ToDouble(lblbgrweekend.Text) + Convert.ToDouble(txtbgruplift.Text);

            txtbgrprice.Text = dayprice.ToString();

            if (lblbgrnight.Text != "0")
            {
                txtbgrnight.Text = nightprice.ToString();
            }

            if (lblbgrweekend.Text != "0")
            {
                txtbgrweekend.Text = weekend.ToString();
            }
            if (lblBGEMetertype.Text == "Single Rate")
            {
                finalvalue = lib.SingleRatebg(sc, dayprice, eac);
                txtbgrfinalvalue.Text = finalvalue.ToString();
            }

            if (lblBGEMetertype.Text == "Day & Night")
            {
                finalvalue = lib.Daynight(sc, dayprice, nightprice, eac);
                txtbgrfinalvalue.Text = finalvalue.ToString();
            }
            if (lblBGEMetertype.Text == "Eve/Weekend & Night")
            {
                finalvalue = lib.Ewn(sc, dayprice, nightprice, weekend, eac);
                txtbgrfinalvalue.Text = finalvalue.ToString();

            }

            if (lblBGEMetertype.Text == "Eve/Weekend")
            {
                finalvalue = lib.EW(sc, dayprice, weekend, eac);
                txtbgrfinalvalue.Text = finalvalue.ToString();

            }



        }

        protected void txtbglauplift_TextChanged(object sender, EventArgs e)
        {

            double actualprice = Convert.ToDouble(txtbglaprice.Text);
            double eac = Convert.ToDouble(lblEac.Text);
            double sc = Convert.ToDouble(lblbglasccharge.Text);

            double finalvalue = Convert.ToDouble(txtbglafinalvalue.Text);
            double upliftvalue = Convert.ToDouble(txtbglauplift.Text);
            txtbglaprice.Text = actualprice.ToString();
            double finalprice = actualprice + Convert.ToDouble(txtbgruplift.Text);
            double dayprice = Convert.ToDouble(lblbgladay.Text) + Convert.ToDouble(txtbglauplift.Text);
            double nightprice = Convert.ToDouble(lblbglanight.Text) + Convert.ToDouble(txtbglauplift.Text);
            double weekend = Convert.ToDouble(lblbglaweekend.Text) + Convert.ToDouble(txtbglauplift.Text);

            txtbglaprice.Text = dayprice.ToString();

            if (lblbglanight.Text != "0")
            {
                txtbgrnight.Text = nightprice.ToString();
            }

            if (lblbglaweekend.Text != "0")
            {
                txtbgrweekend.Text = weekend.ToString();
            }
            if (lblBGEMetertype.Text == "Single Rate")
            {
                finalvalue = lib.SingleRatebg(sc, dayprice, eac);
                txtbglafinalvalue.Text = finalvalue.ToString();
            }

            if (lblBGEMetertype.Text == "Day & Night")
            {
                finalvalue = lib.Daynight(sc, dayprice, nightprice, eac);
                txtbglafinalvalue.Text = finalvalue.ToString();
            }
            if (lblBGEMetertype.Text == "Eve/Weekend & Night")
            {
                finalvalue = lib.Ewn(sc, dayprice, nightprice, weekend, eac);
                txtbglafinalvalue.Text = finalvalue.ToString();

            }

            if (lblBGEMetertype.Text == "Eve/Weekend")
            {
                finalvalue = lib.EW(sc, dayprice, weekend, eac);
                txtbglafinalvalue.Text = finalvalue.ToString();

            }


        }

        protected void txtbgleuplift_TextChanged(object sender, EventArgs e)
        {

            double actualprice = Convert.ToDouble(txtbgleprice.Text);
            double eac = Convert.ToDouble(lblEac.Text);
            double sc = Convert.ToDouble(lblbglesccharge.Text);

            double finalvalue = Convert.ToDouble(txtbglefinalvalue.Text);
            double upliftvalue = Convert.ToDouble(txtbgleuplift.Text);
            txtbgrprice.Text = actualprice.ToString();
            double finalprice = actualprice + Convert.ToDouble(txtbgruplift.Text);
            double dayprice = Convert.ToDouble(lblbgleday.Text) + Convert.ToDouble(txtbgleuplift.Text);
            double nightprice = Convert.ToDouble(lblbglenight.Text) + Convert.ToDouble(txtbgleuplift.Text);
            double weekend = Convert.ToDouble(lblbgleweekend.Text) + Convert.ToDouble(txtbgleuplift.Text);

            txtbgrprice.Text = dayprice.ToString();

            if (lblbglenight.Text != "0")
            {
                txtbgrnight.Text = nightprice.ToString();
            }

            if (lblbgleweekend.Text != "0")
            {
                txtbgrweekend.Text = weekend.ToString();
            }
            if (lblBGEMetertype.Text == "Single Rate")
            {
                finalvalue = lib.SingleRatebg(sc, dayprice, eac);
                txtbglefinalvalue.Text = finalvalue.ToString();
            }

            if (lblBGEMetertype.Text == "Day & Night")
            {
                finalvalue = lib.Daynight(sc, dayprice, nightprice, eac);
                txtbglefinalvalue.Text = finalvalue.ToString();
            }
            if (lblBGEMetertype.Text == "Eve/Weekend & Night")
            {
                finalvalue = lib.Ewn(sc, dayprice, nightprice, weekend, eac);
                txtbglefinalvalue.Text = finalvalue.ToString();

            }

            if (lblBGEMetertype.Text == "Eve/Weekend")
            {
                finalvalue = lib.EW(sc, dayprice, weekend, eac);
                txtbglefinalvalue.Text = finalvalue.ToString();

            }


        }

        protected void gvDE_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
               

                txtdesc.Text = Convert.ToString(e.Row.Cells[2].Text);
                lblDeSc.Text = Convert.ToString(e.Row.Cells[2].Text);

                txtdeDay.Text = Convert.ToString(e.Row.Cells[3].Text);
                lblDeDay.Text = txtdeDay.Text;

                txtdeweekend.Text = Convert.ToString(e.Row.Cells[5].Text);
                lblDeWeekend.Text = txtdeweekend.Text;

                txtdenight.Text = Convert.ToString(e.Row.Cells[4].Text);
                lblDeNight.Text = txtdenight.Text;
            }

        }

        protected void txtdeuplift_TextChanged(object sender, EventArgs e)
        {
          
            double eac = Convert.ToDouble(lblEac.Text);
            double sc = Convert.ToDouble(lblDeSc.Text);
            if (lblDeNight.Text == @"&nbsp;")
            {
                lblDeNight.Text = "0";
            }
            if (lblDeWeekend.Text == @"&nbsp;")
            {
                lblDeWeekend.Text = "0";
            }

            double finalvalue = Convert.ToDouble(txtdefinal.Text);
            double upliftvalue = Convert.ToDouble(txtdeuplift.Text);
       
            double dayprice = Convert.ToDouble(lblDeDay.Text) + Convert.ToDouble(txtdeuplift.Text);
            double nightprice = Convert.ToDouble(lblDeNight.Text) + Convert.ToDouble(txtdeuplift.Text);
            double weekend = Convert.ToDouble(lblDeWeekend.Text) + Convert.ToDouble(txtdeuplift.Text);

            txtdeDay.Text = dayprice.ToString();

            if (lblDeNight.Text != "0")
            {
                txtdenight.Text = nightprice.ToString();
            }

            if (lblDeWeekend.Text != "0")
            {
                txtdeweekend.Text = weekend.ToString();
            }
            if (lblDEMetertype.Text == "DAY")
            {
                finalvalue = lib.Deday(sc, dayprice, eac);
                txtdefinal.Text = finalvalue.ToString();
            }
            if (lblDEMetertype.Text == "E7")
            {
                finalvalue = lib.Dee7(sc,dayprice,weekend,eac);
                txtdefinal.Text = finalvalue.ToString();
            }
            if (lblDEMetertype.Text == "EWN")
            {
                finalvalue = lib.DeeEWN(sc, dayprice,nightprice, weekend, eac);
                txtdefinal.Text = finalvalue.ToString();
            }


        }

        protected void gvEDF_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                txtedfsc.Text = Convert.ToString(e.Row.Cells[2].Text);
                lblEdfSC.Text = Convert.ToString(e.Row.Cells[2].Text);

                txtedfday.Text = Convert.ToString(e.Row.Cells[3].Text);
                lblEdfDay.Text = txtedfday.Text;

                txtedfnight.Text = Convert.ToString(e.Row.Cells[4].Text);
                lblEdfNight.Text = txtedfnight.Text;

                txtedfweekend.Text = Convert.ToString(e.Row.Cells[5].Text);
                lblEDFWeekend.Text = txtedfweekend.Text;
            }

        }

        protected void txtedfuplift_TextChanged(object sender, EventArgs e)
        {
            double actualprice = Convert.ToDouble(txtedfday.Text);
            double eac = Convert.ToDouble(lblEac.Text);
            double sc = Convert.ToDouble(lblEdfSC.Text);
            
            double finalvalue = Convert.ToDouble(txtedffinalvalue.Text);
            double upliftvalue = Convert.ToDouble(txtedfuplift.Text);
            txtedfday.Text = actualprice.ToString();
            double finalprice = actualprice + Convert.ToDouble(txtedfuplift.Text);
            double dayprice = Convert.ToDouble(lblEdfDay.Text) + Convert.ToDouble(txtedfuplift.Text);
            double nightprice = Convert.ToDouble(lblEdfNight.Text) + Convert.ToDouble(txtedfuplift.Text);
            double weekend = Convert.ToDouble(lblEDFWeekend.Text) + Convert.ToDouble(txtedfuplift.Text);

            txtedfday.Text = dayprice.ToString();

            if (lblEdfNight.Text != "0")
            {
                txtedfnight.Text = nightprice.ToString();
            }

            if (lblEDFWeekend.Text != "0")
            {
                txtedfweekend.Text = weekend.ToString();
            }
            if (lblEDFMetertype.Text == "EWN")
            {
                finalvalue = lib.EdfEwn(sc, dayprice, nightprice, weekend, eac);
                txtedffinalvalue.Text = finalvalue.ToString();
            }
            if (lblEDFMetertype.Text == "STD")
            {
                finalvalue = lib.Edfstd(sc, dayprice, eac);
                txtedffinalvalue.Text = finalvalue.ToString();
            }
            if (lblEDFMetertype.Text == "EC7")
            {
                finalvalue = lib.EdfEC7(sc, dayprice, nightprice, eac);
                txtedffinalvalue.Text = finalvalue.ToString();
            }
            if (lblEDFMetertype.Text == "EWE")
            {
                finalvalue = lib.EDFEWE(sc, dayprice, weekend, eac);
                txtedffinalvalue.Text = finalvalue.ToString();
            }



        }

       

        protected void gvpe_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                txtpesc.Text = Convert.ToString(e.Row.Cells[2].Text);
                lblpesc.Text = Convert.ToString(e.Row.Cells[2].Text);

                txtpeday.Text = Convert.ToString(e.Row.Cells[3].Text);
                lblpeday.Text = txtpeday.Text;

                txtpenight.Text = Convert.ToString(e.Row.Cells[4].Text);
                lblpenight.Text = txtpenight.Text;

               

                txtpeweekend.Text = Convert.ToString(e.Row.Cells[6].Text);
                lblpeweekend.Text = txtpeweekend.Text;
            }

        }

        protected void gvpe24_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                txtpesc.Text = Convert.ToString(e.Row.Cells[2].Text);
                lblpesc.Text = Convert.ToString(e.Row.Cells[2].Text);

                txtpeday.Text = Convert.ToString(e.Row.Cells[3].Text);
                lblpeday.Text = txtpeday.Text;

                txtpenight.Text = Convert.ToString(e.Row.Cells[4].Text);
                lblpenight.Text = txtpenight.Text;

                

                txtpeweekend.Text = Convert.ToString(e.Row.Cells[6].Text);
                lblpeweekend.Text = txtpeweekend.Text;
            }

        }

        protected void gvpe36_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                txtpesc.Text = Convert.ToString(e.Row.Cells[2].Text);
                lblpesc.Text = Convert.ToString(e.Row.Cells[2].Text);

                txtpeday.Text = Convert.ToString(e.Row.Cells[3].Text);
                lblpeday.Text = txtpeday.Text;

                txtpenight.Text = Convert.ToString(e.Row.Cells[4].Text);
                lblpenight.Text = txtpenight.Text;

               

                txtpeweekend.Text = Convert.ToString(e.Row.Cells[6].Text);
                lblpeweekend.Text = txtpeweekend.Text;
            }

        }

        protected void gvgaz_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                txtgazsc.Text = Convert.ToString(e.Row.Cells[2].Text);
                lblgazsc.Text = Convert.ToString(e.Row.Cells[2].Text);

                txtgazunitrate.Text = Convert.ToString(e.Row.Cells[3].Text);
                lblgazunitrate.Text = txtgazunitrate.Text;

                txtgazday.Text = Convert.ToString(e.Row.Cells[4].Text);
                lblgazday.Text = txtgazday.Text;

                txtgaznight.Text = Convert.ToString(e.Row.Cells[5].Text);
                lblgaznight.Text = txtgaznight.Text;

                txtgazweekend.Text = Convert.ToString(e.Row.Cells[6].Text);
                lblgazweekend.Text = txtgazweekend.Text;
            }


        }

        protected void gvTGP_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                txttgpsc.Text = Convert.ToString(e.Row.Cells[2].Text);
                lbltgpsc.Text = Convert.ToString(e.Row.Cells[2].Text);

                txttgpunitrate.Text = Convert.ToString(e.Row.Cells[3].Text);
                lbltgpunitrate.Text = txttgpunitrate.Text;

                txttgpday.Text = Convert.ToString(e.Row.Cells[4].Text);
                lbltgpday.Text = txtgazday.Text;

                txttgpnight.Text = Convert.ToString(e.Row.Cells[5].Text);
                lbltgpnight.Text = txttgpnight.Text;

                txttgpweekend.Text = Convert.ToString(e.Row.Cells[6].Text);
                lbltgpweekend.Text = txttgpweekend.Text;
            }

        }

        protected void gvsse_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                txtssesc.Text = Convert.ToString(e.Row.Cells[2].Text);
                lblssesc.Text = Convert.ToString(e.Row.Cells[2].Text);

                txtsseallunits.Text = Convert.ToString(e.Row.Cells[4].Text);
                lblsseallunit.Text = txtsseallunits.Text;

                txtsseDay.Text = Convert.ToString(e.Row.Cells[4].Text);
                lblsseday.Text = txtsseDay.Text;

                txtssenight.Text = Convert.ToString(e.Row.Cells[5].Text);
                lblssenight.Text = txtssenight.Text;

                txtsseweekend.Text = Convert.ToString(e.Row.Cells[6].Text);
                lblsseweekend.Text = txtsseweekend.Text;

            }

        }

        protected void gvEonDD_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                txteonsc.Text = Convert.ToString(e.Row.Cells[2].Text);
                lbleonsc.Text = Convert.ToString(e.Row.Cells[2].Text);

                txteonday.Text = Convert.ToString(e.Row.Cells[3].Text);
                lbleonday.Text = txteonday.Text;

                txteonUnitrate.Text = Convert.ToString(e.Row.Cells[4].Text);
                lbleonunitrate.Text = txteonUnitrate.Text;

                txteonnight.Text = Convert.ToString(e.Row.Cells[5].Text);
                lbleonnight.Text = txteonnight.Text;

                txteonweekend.Text = Convert.ToString(e.Row.Cells[6].Text);
                lbleonweekend.Text = txteonweekend.Text;

            }

           

        }

        protected void gvNpowerA_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                txtnprsc.Text = Convert.ToString(e.Row.Cells[4].Text);
                lblnprsc.Text = Convert.ToString(e.Row.Cells[4].Text);

                txtnprday.Text = Convert.ToString(e.Row.Cells[5].Text);
                lblnprday.Text = txtnprday.Text;

                txtnprall.Text = Convert.ToString(e.Row.Cells[6].Text);
                lblnprall.Text = txtnprall.Text;

                txtnprnight.Text = Convert.ToString(e.Row.Cells[7].Text);
                lblnprnight.Text = txtnprnight.Text;

                txtnprweekend.Text = Convert.ToString(e.Row.Cells[8].Text);
                lblnprweekend.Text = txtnprweekend.Text;

                txtnprother.Text = Convert.ToString(e.Row.Cells[9].Text);
                lblnprother.Text = txtnprother.Text;

            }


        }

        protected void gvnpowere_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                txtnprrsc.Text = Convert.ToString(e.Row.Cells[4].Text);
                lblnprrsc.Text = Convert.ToString(e.Row.Cells[4].Text);

                txtnprrday.Text = Convert.ToString(e.Row.Cells[5].Text);
                lblnprrday.Text = txtnprrday.Text;

                txtnprrall.Text = Convert.ToString(e.Row.Cells[6].Text);
                lblnprrall.Text = txtnprrall.Text;

                txtnprrnight.Text = Convert.ToString(e.Row.Cells[7].Text);
                lblnprrnight.Text = txtnprrnight.Text;

                txtnprrweekend.Text = Convert.ToString(e.Row.Cells[8].Text);
                lblnprrweekend.Text = txtnprrweekend.Text;

                txtnprrothrt.Text = Convert.ToString(e.Row.Cells[8].Text);
                lblnprrother.Text = txtnprrweekend.Text;

            }




        }
        protected void gvnpoweral_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                txtnpresc.Text = Convert.ToString(e.Row.Cells[4].Text);
                lblnpresc.Text = Convert.ToString(e.Row.Cells[4].Text);

                txtnpreday.Text = Convert.ToString(e.Row.Cells[5].Text);
                lblnpreda.Text = txtnpreday.Text;

                txtnpreall.Text = Convert.ToString(e.Row.Cells[6].Text);
                lblnpreall.Text = txtnprrall.Text;

                txtnprenight.Text = Convert.ToString(e.Row.Cells[7].Text);
                lblnprenight.Text = txtnprrnight.Text;

                txtnpreweekend.Text = Convert.ToString(e.Row.Cells[8].Text);
                lblnpreweekend.Text = txtnprrweekend.Text;

                txtnpreother.Text = Convert.ToString(e.Row.Cells[8].Text);
                lblnpreother.Text = txtnprrweekend.Text;

            }

        }

        protected void txtnpruplift_TextChanged(object sender, EventArgs e)
        {
            double eac = Convert.ToDouble(lblEac.Text);
            double sc = Convert.ToDouble(txtnprsc.Text);
            
            if (lblnprday.Text == @"&nbsp;")
            {
                lblnprday.Text = "0";
            }

            if (lblnprnight.Text == @"&nbsp;")
            {
                lblnprnight.Text = "0";
            }
                 

            if (lblnprweekend.Text == @"&nbsp;")
            {
                lblnprweekend.Text = "0";
            }

            if (lblnprother.Text == @"&nbsp;")
            {
                lblnprother.Text = "0";
            }

            if(lblnprall.Text == @"&nbsp;")
            {
                lblnprall.Text = "0";
            }



            double finalvalue = Convert.ToDouble(txtnprfinalvalue.Text);
            double upliftvalue = Convert.ToDouble(txtnpruplift.Text);

            double dayprice = Convert.ToDouble(lblnprday.Text) + Convert.ToDouble(txtnpruplift.Text);
            double nightprice = Convert.ToDouble(lblnprnight.Text) + Convert.ToDouble(txtnpruplift.Text);
            double weekend = Convert.ToDouble(lblnprweekend.Text) + Convert.ToDouble(txtnpruplift.Text);
            double allunitc  = Convert.ToDouble(lblnprall.Text) + Convert.ToDouble(txtnpruplift.Text);
            double otherunitc = Convert.ToDouble(lblnprother.Text) + Convert.ToDouble(txtnpruplift.Text);


            if (lblnprday.Text != "0")
            {
                txtnprday.Text = dayprice.ToString();

            }

            if (lblnprall.Text != "0")
            {
                txtnprall.Text = allunitc.ToString();

            }

            if (lblnprnight.Text != "0")
            {
                txtnprnight.Text = nightprice.ToString();

            }

            if (lblnprweekend.Text != "0")
            {
                txtnprweekend.Text = weekend.ToString();

            }

            if (lblnprother.Text != "0")
            {
                txtnpreother.Text = otherunitc.ToString();

            }




            if (lblNpwer.Text == "EBF_STD")
            {
                finalvalue = lib.NpowerEBF_STD(sc, allunitc, eac);
                txtnprfinalvalue.Text = finalvalue.ToString();
            }

            if (lblNpwer.Text == "EBF_E07")
            {
                finalvalue = lib.NpowerEBF_E07(sc, dayprice, nightprice, eac);
                txtnprfinalvalue.Text = finalvalue.ToString();
            }

            if (lblNpwer.Text == "EBF_H07")
            {
                finalvalue = lib.NpowerEBF_H07(sc, otherunitc, eac);
                txtnprfinalvalue.Text = finalvalue.ToString();
            }

            if (lblNpwer.Text == "EBF_H07")
            {
                finalvalue = lib.NpowerEBF_E_W(sc, weekend, otherunitc, eac);
                txtnprfinalvalue.Text = finalvalue.ToString();
            }




        }

        protected void txtnprruplift_TextChanged(object sender, EventArgs e)
        {
            double eac = Convert.ToDouble(lblEac.Text);
            double sc = Convert.ToDouble(txtnprrsc.Text);

            if (lblnprrday.Text == @"&nbsp;")
            {
                lblnprrday.Text = "0";
            }

            if (lblnprrnight.Text == @"&nbsp;")
            {
                lblnprrnight.Text = "0";
            }


            if (lblnprrweekend.Text == @"&nbsp;")
            {
                lblnprrweekend.Text = "0";
            }

            if (lblnprrall.Text == @"&nbsp;")
            {
                lblnprrall.Text = "0";
            }

            if (lblnprrother.Text == @"&nbsp;")
            {
                lblnprrother.Text = "0";
            }



            double finalvalue = Convert.ToDouble(txtnprrfinalprice.Text);
            double upliftvalue = Convert.ToDouble(txtnprruplift.Text);

            double dayprice = Convert.ToDouble(lblnprrday.Text) + Convert.ToDouble(txtnprruplift.Text);
            double nightprice = Convert.ToDouble(lblnprrnight.Text) + Convert.ToDouble(txtnprruplift.Text);
            double weekend = Convert.ToDouble(lblnprrweekend.Text) + Convert.ToDouble(txtnprruplift.Text);
            double allunitc = Convert.ToDouble(lblnprrall.Text) + Convert.ToDouble(txtnprruplift.Text);
            double otherunitc = Convert.ToDouble(lblnprrother.Text) + Convert.ToDouble(txtnprruplift.Text);


            if (lblnprrday.Text != "0")
            {
                txtnprrday.Text = dayprice.ToString();

            }

            if (lblnprrall.Text != "0")
            {
                txtnprrall.Text = allunitc.ToString();

            }

            if (lblnprrnight.Text != "0")
            {
                txtnprrnight.Text = nightprice.ToString();

            }

            if (lblnprrweekend.Text != "0")
            {
                txtnprrweekend.Text = weekend.ToString();

            }

            if (lblnprrother.Text != "0")
            {
                txtnprrothrt.Text = otherunitc.ToString();

            }




            if (lblNpwer.Text == "EBF_STD")
            {
                finalvalue = lib.NpowerEBF_STD(sc, allunitc, eac);
                txtnprrfinalprice.Text = finalvalue.ToString();
            }

            if (lblNpwer.Text == "EBF_E07")
            {
                finalvalue = lib.NpowerEBF_E07(sc, dayprice, nightprice, eac);
                txtnprrfinalprice.Text = finalvalue.ToString();
            }

            if (lblNpwer.Text == "EBF_H07")
            {
                finalvalue = lib.NpowerEBF_H07(sc, otherunitc, eac);
                txtnprrfinalprice.Text = finalvalue.ToString();
            }

            if (lblNpwer.Text == "EBF_H07")
            {
                finalvalue = lib.NpowerEBF_E_W(sc, weekend, otherunitc, eac);
                txtnprrfinalprice.Text = finalvalue.ToString();
            }



        }

        protected void txtnpreuplift_TextChanged(object sender, EventArgs e)
        {
            double eac = Convert.ToDouble(lblEac.Text);
            double sc = Convert.ToDouble(txtnpresc.Text);

            if (lblnpreda.Text == @"&nbsp;")
            {
                lblnpreda.Text = "0";
            }

            if (lblnprenight.Text == @"&nbsp;")
            {
                lblnprenight.Text = "0";
            }


            if (lblnpreweekend.Text == @"&nbsp;")
            {
                lblnpreweekend.Text = "0";
            }

            if (lblnpreall.Text == @"&nbsp;")
            {
                lblnpreall.Text = "0";
            }

            if (lblnpreother.Text == @"&nbsp;")
            {
                lblnpreother.Text = "0";
            }



            double finalvalue = Convert.ToDouble(txtnprefinalvalue.Text);
            double upliftvalue = Convert.ToDouble(txtnpreuplift.Text);

            double dayprice = Convert.ToDouble(lblnpreda.Text) + Convert.ToDouble(txtnpreuplift.Text);
            double nightprice = Convert.ToDouble(lblnprenight.Text) + Convert.ToDouble(txtnpreuplift.Text);
            double weekend = Convert.ToDouble(lblnpreweekend.Text) + Convert.ToDouble(txtnpreuplift.Text);
            double allunitc = Convert.ToDouble(lblnpreall.Text) + Convert.ToDouble(txtnpreuplift.Text);
            double otherunitc = Convert.ToDouble(lblnpreother.Text) + Convert.ToDouble(txtnpreuplift.Text);


            if (lblnpreda.Text != "0")
            {
                txtnpreday.Text = dayprice.ToString();

            }

            if (lblnpreall.Text != "0")
            {
                txtnpreall.Text = allunitc.ToString();

            }

            if (lblnprenight.Text != "0")
            {
                txtnprenight.Text = nightprice.ToString();

            }

            if (lblnpreweekend.Text != "0")
            {
                txtnpreweekend.Text = weekend.ToString();

            }

            if (lblnpreother.Text != "0")
            {
                txtnpreother.Text = otherunitc.ToString();

            }




            if (lblNpwer.Text == "EBF_STD")
            {
                finalvalue = lib.NpowerEBF_STD(sc, allunitc, eac);
                txtnprefinalvalue.Text = finalvalue.ToString();
            }

            if (lblNpwer.Text == "EBF_E07")
            {
                finalvalue = lib.NpowerEBF_E07(sc, dayprice, nightprice, eac);
                txtnprefinalvalue.Text = finalvalue.ToString();
            }

            if (lblNpwer.Text == "EBF_H07")
            {
                finalvalue = lib.NpowerEBF_H07(sc, otherunitc, eac);
                txtnprefinalvalue.Text = finalvalue.ToString();
            }

            if (lblNpwer.Text == "EBF_H07")
            {
                finalvalue = lib.NpowerEBF_E_W(sc, weekend, otherunitc, eac);
                txtnprefinalvalue.Text = finalvalue.ToString();
            }



        }

        protected void txtgazuplift_TextChanged(object sender, EventArgs e)
        {
            double eac = Convert.ToDouble(lblEac.Text);
            double sc = Convert.ToDouble(txtgazsc.Text);

            if (lblgazday.Text == @"&nbsp;")
            {
                lblgazday.Text = "0";
            }

           
            if (lblgazweekend.Text == @"&nbsp;")
            {
                lblgazweekend.Text = "0";
            }

            if (lblgazunitrate.Text == @"&nbsp;")
            {
                lblgazunitrate.Text = "0";
            }

            if (lblgaznight.Text == @"&nbsp;")
            {
                lblgaznight.Text = "0";
            }



            double finalvalue = Convert.ToDouble(txtgazfinal.Text);
            double upliftvalue = Convert.ToDouble(txtgazuplift.Text);

            double dayprice = Convert.ToDouble(lblgazday.Text) + Convert.ToDouble(txtgazuplift.Text);
            double nightprice = Convert.ToDouble(lblgaznight.Text) + Convert.ToDouble(txtgazuplift.Text);
            double weekend = Convert.ToDouble(lblgazweekend.Text) + Convert.ToDouble(txtgazuplift.Text);
            double unitratec = Convert.ToDouble(lblgazunitrate.Text) + Convert.ToDouble(txtgazuplift.Text);
         


            if (lblgazday.Text != "0")
            {
                txtgazday.Text = dayprice.ToString();

            }

            if (lblgaznight.Text != "0")
            {
                txtgaznight.Text = nightprice.ToString();

            }

            if (lblgazweekend.Text != "0")
            {
                txtgazweekend.Text = weekend.ToString();

            }

            if (lblgazunitrate.Text != "0")
            {
                txtgazunitrate.Text = unitratec.ToString();

            }

            if (lblnpreother.Text != "0")
            {
                txtnpreother.Text = lblnprother.ToString();

            }




            if (lblGZMetertype.Text == "Unrestricted")
            {
                finalvalue = lib.gazUnrestricted(sc, unitratec, eac);
                txtgazfinal.Text = finalvalue.ToString();
            }

            if (lblGZMetertype.Text == "Economy 7")
            {
                finalvalue = lib.gazeco7(sc, dayprice,nightprice, eac);
                txtgazfinal.Text = finalvalue.ToString();
            }

            if (lblGZMetertype.Text == "Evening & Weekend")
            {
                finalvalue = lib.gazeanw(sc, dayprice, weekend, eac);
                txtgazfinal.Text = finalvalue.ToString();
            }

            if (lblGZMetertype.Text == "3 Rate (Day, Night & Evening & Weekend)")
            {
                finalvalue = lib.gazdayeveweek(sc, dayprice, nightprice, weekend, eac);
                txtgazfinal.Text = finalvalue.ToString();
            }




        }

        protected void txtpeuplft_TextChanged(object sender, EventArgs e)
        {

            double eac = Convert.ToDouble(lblEac.Text);
            double sc = Convert.ToDouble(lblpesc.Text);

            if (lblpeday.Text == @"&nbsp;")
            {
                lblpeday.Text = "0";
            }


            if (lblpeweekend.Text == @"&nbsp;")
            {
                lblpeweekend.Text = "0";
            }

            if (lblpenight.Text == @"&nbsp;")
            {
                lblpenight.Text = "0";
            }

            if (lblpeweekend.Text == @"&nbsp;")
            {
                lblpeweekend.Text = "0";
            }



            double finalvalue = Convert.ToDouble(txtpefinal.Text);
            double upliftvalue = Convert.ToDouble(txtpeuplft.Text);

            double dayprice = Convert.ToDouble(lblpeday.Text) + Convert.ToDouble(txtpeuplft.Text);
            double nightprice = Convert.ToDouble(lblpenight.Text) + Convert.ToDouble(txtpeuplft.Text);
            double weekend = Convert.ToDouble(lblpeweekend.Text) + Convert.ToDouble(txtpeuplft.Text);
      



            if (lblpeday.Text != "0")
            {
                txtpeday.Text = dayprice.ToString();

            }

            if (lblpenight.Text != "0")
            {
                txtpenight.Text = nightprice.ToString();

            }

            if (lblpeweekend.Text != "0")
            {
                txtpeweekend.Text = weekend.ToString();

            }

            



            if (lblPEMetertype.Text == "Business Unrestricted")
            {
                finalvalue = lib.PeBusinessUnrestricted(sc, dayprice, eac);
                txtpefinal.Text = finalvalue.ToString();
            }

           



        }

        protected void txteonuplift_TextChanged(object sender, EventArgs e)
        {

            double eac = Convert.ToDouble(lblEac.Text);
            double sc = Convert.ToDouble(lbleonsc.Text);

            if (lbleonday.Text == @"&nbsp;")
            {
                lbleonday.Text = "0";
            }


            if (lbleonnight.Text == @"&nbsp;")
            {
                lbleonnight.Text = "0";
            }

            if (lbleonweekend.Text == @"&nbsp;")
            {
                lbleonweekend.Text = "0";
            }

            if (lbleonunitrate.Text == @"&nbsp;")
            {
                lbleonunitrate.Text = "0";
            }



            double finalvalue = Convert.ToDouble(txteonfinalvalue.Text);
            double upliftvalue = Convert.ToDouble(txteonuplift.Text);

            double dayprice = Convert.ToDouble(lbleonday.Text) + Convert.ToDouble(txteonuplift.Text);
            double nightprice = Convert.ToDouble(lbleonnight.Text) + Convert.ToDouble(txteonuplift.Text);
            double weekend = Convert.ToDouble(lbleonweekend.Text) + Convert.ToDouble(txteonuplift.Text);
            double unitc = Convert.ToDouble(lbleonunitrate.Text) + Convert.ToDouble(txteonuplift.Text);




            if (lbleonday.Text != "0")
            {
                txteonday.Text = dayprice.ToString();

            }

            if (lbleonnight.Text != "0")
            {
                txteonnight.Text = nightprice.ToString();

            }

            if (lbleonweekend.Text != "0")
            {
                txteonweekend.Text = weekend.ToString();

            }
            if (lbleonunitrate.Text != "0")
            {
                txteonUnitrate.Text = unitc.ToString();

            }





            if (lblEONEMetertype.Text == "Baserate")
            {
                finalvalue = lib.eonbaserate(sc, dayprice, unitc, eac);
                txteonfinalvalue.Text = finalvalue.ToString();
            }


        }
    }
}