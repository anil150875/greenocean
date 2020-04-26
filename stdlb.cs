using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GreenOcean
{
    
    public class stdlb
    {
        string myConnectionString = "Data Source=DESKTOP-19DCAF9;Initial Catalog = greenway; Integrated Security = True";
        public int getnpowerload(int load)
        {
            int maxload = 0;
            if (load <= 39999)
            {
                maxload = 39999;
            }
            else if(load > 39999 && load < 99999)
            {
                maxload = 99999;
            }
            else if (load > 99999 && load < 199999)
            {
                maxload = 199999;
            }
            else 
            {
                maxload = 299999;
            }
            
            return maxload;
        }


        public int Getbg(int load)
        {
            int maxload = 0;
            if (load <= 5000)
            {
                maxload = 4999;
            }
            if (load > 4999  && load < 10000)
            {
                maxload = 9999;
            }
            if (load > 10000 && load < 20000)
            {
                maxload = 19999;
            }
            if (load > 19999 && load < 50000)
            {
                maxload = 49999;
            }
            if(load > 50000)
            {
                maxload = 99999999;
            }

            return maxload;
        }

        public string getbgplan(string mtccode)
        {
            string BGEMetertype = "";
            SqlConnection con = new SqlConnection(myConnectionString);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            SqlCommand cmd = new SqlCommand("select top 1 bg from mtc where  mtccode = @mtccode", con);
            cmd.Parameters.AddWithValue("@mtccode", mtccode);
            BGEMetertype = Convert.ToString(cmd.ExecuteScalar());
            con.Close();
            return BGEMetertype;

        }

        public string getbgliteplan(string mtccode)
        {
            string BGLMetertype = "";
            SqlConnection con = new SqlConnection(myConnectionString);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();


            }


            SqlCommand cmd = new SqlCommand("select top 1 bgl  from mtc where  mtccode = @mtccode", con);
            cmd.Parameters.AddWithValue("@mtccode", mtccode);
            BGLMetertype = Convert.ToString(cmd.ExecuteScalar());
            con.Close();
            return BGLMetertype;
        }

        public string getpeplan(string mtccode)
        {
            string PEMetertype = "";
            SqlConnection con = new SqlConnection(myConnectionString);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();


            }


            SqlCommand cmd = new SqlCommand("select top 1 pe   from mtc where  mtccode = @mtccode", con);
            cmd.Parameters.AddWithValue("@mtccode", mtccode);
            PEMetertype = Convert.ToString(cmd.ExecuteScalar());
            con.Close();

            return PEMetertype = "";
        }

        public string getsseplan(string mtccode)
        {

            string SSEPEMetertype = "";
            SqlConnection con = new SqlConnection(myConnectionString);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();


            }


            SqlCommand cmd = new SqlCommand("select top 1 sse   from mtc where  mtccode = @mtccode", con);
            cmd.Parameters.AddWithValue("@mtccode", mtccode);
            SSEPEMetertype = Convert.ToString(cmd.ExecuteScalar());
            con.Close();
            return SSEPEMetertype;


        }

        public string getspeplan(string mtccode)
        {
            string SPAMetertype = "";
            SqlConnection con = new SqlConnection(myConnectionString);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();


            }


            SqlCommand cmd = new SqlCommand("select top 1 sp   from mtc where  mtccode = @mtccode", con);
            cmd.Parameters.AddWithValue("@mtccode", mtccode);
            SPAMetertype = Convert.ToString(cmd.ExecuteScalar());
            con.Close();
            return SPAMetertype;

        }

        public string  geteonplan(string mtccode)
        {
            string EONEMetertype = "";
            SqlConnection con = new SqlConnection(myConnectionString);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();


            }


            SqlCommand cmd = new SqlCommand("select top 1 SalesProductDesc   from mtc where  mtccode = @mtccode", con);
            cmd.Parameters.AddWithValue("@mtccode", mtccode);
            EONEMetertype = Convert.ToString(cmd.ExecuteScalar());
            con.Close();
            return EONEMetertype;

        }

        public string getdeeplan(string mtccode)
        {
            string DEMetertype = "";
            SqlConnection con = new SqlConnection(myConnectionString);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();


            }


            SqlCommand cmd = new SqlCommand("select top 1 de  from mtc where  mtccode = @mtccode", con);
            cmd.Parameters.AddWithValue("@mtccode", mtccode);
            DEMetertype = Convert.ToString(cmd.ExecuteScalar());
            con.Close();
            return DEMetertype;

        }


       public string getedfplan(string mtccode)
        {
            string EDFMetertype = "";
            SqlConnection con = new SqlConnection(myConnectionString);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();


            }

            SqlCommand cmd = new SqlCommand("select top 1 edfe  from mtc where  mtccode = @mtccode", con);
            cmd.Parameters.AddWithValue("@mtccode", mtccode);
            EDFMetertype = Convert.ToString(cmd.ExecuteScalar());
            con.Close();
            return EDFMetertype;

        }

        public string getgazplan(string mtccode)
        {
            string GZMetertype = "";


            SqlConnection con = new SqlConnection(myConnectionString);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();


            }

            SqlCommand cmd = new SqlCommand("select top 1 gaz  from mtc where  mtccode = @mtccode", con);
            cmd.Parameters.AddWithValue("@mtccode", mtccode);
            GZMetertype = Convert.ToString(cmd.ExecuteScalar());
            con.Close();

            return GZMetertype;

        }

        public double  SingleRatebg(double standing, double daycharge , double consumption)
        {
            double finalvalue = 0.0;
            double sc = (standing * 365) / 100;
            finalvalue = sc + (daycharge * consumption) / 100;
            return finalvalue;


        }

        public double Daynight(double standing, double daycharge, double nightcharge , double  consumption)
        {
            double finalvalue = 0.0;
            double sc = (standing * 365) / 100;
            double dayc = 0.0;
            double nightc = 0.0;
            dayc = (daycharge * (consumption * .7)/ 100) ;
            nightc = (nightcharge * (consumption * .3) / 100);
            finalvalue = sc + nightc + dayc;
            return finalvalue;


        }

        public double EW(double standing, double daycharge, double  weekend , double consumption)
        {
            double finalvalue = 0.0;
            double sc = (standing * 365) / 100;
            double dayc = 0.0;
            double weekc = 0.0;
            dayc = (daycharge * (consumption * .7) / 100);
            weekc = (weekc * (consumption * .3) / 100);
            finalvalue = sc + weekc + dayc;
            return finalvalue;


        }


        public double Ewn(double standing, double daycharge, double nightcharge, double evening, double consumption)
        {
            double finalvalue = 0.0;
            double sc = (standing * 365) / 100;
            double dayc = 0.0;
            double nightc = 0.0;
            double evec = 0.0;
            dayc = (daycharge * (consumption * .4) / 100);
            nightc = (nightcharge * (consumption * .3) / 100);
            evec = (nightcharge * (consumption * .3) / 100);
            finalvalue = sc + nightc + dayc + evec;
            return finalvalue;


        }


        public double Deday(double standing, double daycharge, double consumption)
        {
            double finalvalue = 0.0;
            double sc = (standing * 365) / 100;
            finalvalue = sc + (daycharge * consumption) / 100;
            return finalvalue;
            
        }

        public double Dee7(double standing, double daycharge, double week, double consumption)
        {
            double finalvalue = 0.0;
            double sc = (standing * 365) / 100;
            double dayc = 0.0;
            double weekc = 0.0;
            dayc = (daycharge * (consumption * .7) / 100);
            weekc = (week * (consumption * .3) / 100);
            finalvalue = sc + dayc + weekc;
            return finalvalue;

        }

        public double DeeEWN(double standing, double daycharge,double nightcharge , double week, double consumption)
        {
            double finalvalue = 0.0;
            double sc = (standing * 365) / 100;
            double dayc = 0.0;
            double nightc = 0.0;
            double evec = 0.0;
            dayc = (daycharge * (consumption * .4) / 100);
            nightc = (nightcharge * (consumption * .3) / 100);
            evec = (nightcharge * (consumption * .3) / 100);
            finalvalue = sc + nightc + dayc + evec;
            return finalvalue;

        }

        public double EdfEwn(double standing, double daycharge, double nightcharge, double evening, double consumption)
        {
            double finalvalue = 0.0;
            double sc = (standing * 365) / 100;
            double dayc = 0.0;
            double nightc = 0.0;
            double evec = 0.0;
            dayc = (daycharge * (consumption * .4) / 100);
            nightc = (nightcharge * (consumption * .3) / 100);
            evec = (nightcharge * (consumption * .3) / 100);
            finalvalue = sc + nightc + dayc + evec;
            return finalvalue;


        }

        public double Edfstd(double standing, double daycharge, double consumption)
        {
            double finalvalue = 0.0;
            double sc = (standing * 365) / 100;
            finalvalue = sc + (daycharge * consumption) / 100;
            return finalvalue;


        }

        public double EdfEC7(double standing, double daycharge, double nightcharge, double consumption)
        {
            double finalvalue = 0.0;
            double sc = (standing * 365) / 100;
            double dayc = 0.0;
            double nightc = 0.0;
            dayc = (daycharge * (consumption * .7) / 100);
            nightc = (nightcharge * (consumption * .3) / 100);
            finalvalue = sc + nightc + dayc;
            return finalvalue;


        }

        public double EDFEWE(double standing, double daycharge, double weekend, double consumption)
        {
            double finalvalue = 0.0;
            double sc = (standing * 365) / 100;
            double dayc = 0.0;
            double weekc = 0.0;
            dayc = (daycharge * (consumption * .7) / 100);
            weekc = (weekc * (consumption * .3) / 100);
            finalvalue = sc + weekc + dayc;
            return finalvalue;


        }

        public double NpowerEBF_STD(double standing, double allunit, double consumption)
        {
            double finalvalue = 0.0;
            double sc = (standing * 365) / 100;
            finalvalue = sc + (allunit * consumption) / 100;
            return finalvalue;


        }

        public double NpowerEBF_E07(double standing, double daycharge, double nightcharge, double consumption)
        {
            double finalvalue = 0.0;
            double sc = (standing * 365) / 100;
            double dayc = 0.0;
            double nightc = 0.0;
            dayc = (daycharge * (consumption * .7) / 100);
            nightc = (nightcharge * (consumption * .3) / 100);
            finalvalue = sc + nightc + dayc;
            return finalvalue;


        }

        public double NpowerEBF_H07(double standing, double otherunit, double consumption)
        {
            double finalvalue = 0.0;
            double sc = (standing * 365) / 100;
            finalvalue = sc + (otherunit * consumption) / 100;
            return finalvalue;


        }

        public double NpowerEBF_E_W(double standing, double weekday, double others, double consumption)
        {
            double finalvalue = 0.0;
            double sc = (standing * 365) / 100;
            double weekdadayc = 0.0;
            double othercc = 0.0;
            weekdadayc = (weekday * (consumption * .7) / 100);
            othercc = (others * (consumption * .3) / 100);
            finalvalue = sc + weekdadayc + othercc;
            return finalvalue;


        }

        public double gazUnrestricted(double standing, double unitrate, double consumption)
        {
            double finalvalue = 0.0;
            double sc = (standing * 365) / 100;
            finalvalue = sc + (unitrate * consumption) / 100;
            return finalvalue;


        }

        public double gazeco7(double standing, double daycharge, double nightcharge, double consumption)
        {
            double finalvalue = 0.0;
            double sc = (standing * 365) / 100;
            double dayc = 0.0;
            double nightc = 0.0;
            dayc = (daycharge * (consumption * .7) / 100);
            nightc = (nightcharge * (consumption * .3) / 100);
            finalvalue = sc + nightc + dayc;
            return finalvalue;


        }

        public double gazeanw(double standing, double daycharge, double weekend, double consumption)
        {
            double finalvalue = 0.0;
            double sc = (standing * 365) / 100;
            double dayc = 0.0;
            double nightc = 0.0;
            dayc = (daycharge * (consumption * .7) / 100);
            nightc = (weekend * (consumption * .3) / 100);
            finalvalue = sc + nightc + dayc;
            return finalvalue;


        }

        public double gazdayeveweek(double standing, double daycharge, double nightcharge, double evening, double consumption)
        {
            double finalvalue = 0.0;
            double sc = (standing * 365) / 100;
            double dayc = 0.0;
            double nightc = 0.0;
            double evec = 0.0;
            dayc = (daycharge * (consumption * .4) / 100);
            nightc = (nightcharge * (consumption * .3) / 100);
            evec = (nightcharge * (consumption * .3) / 100);
            finalvalue = sc + nightc + dayc + evec;
            return finalvalue;


        }


        public double PeBusinessUnrestricted(double standing, double dayrate, double consumption)
        {
            double finalvalue = 0.0;
            double sc = (standing * 365) / 100;
            finalvalue = sc + (dayrate * consumption) / 100;
            return finalvalue;


        }

        public double eonbaserate(double standing, double dayrate, double unitrate, double consumption)
        {
            double finalvalue = 0.0;
            double sc = (standing * 365) / 100;
            finalvalue = sc + (dayrate * consumption) / 100;
            return finalvalue;


        }















    }
}