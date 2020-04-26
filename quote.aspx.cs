using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GreenOcean
{
    public partial class quote : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblBusiness.Text = Request.QueryString["businessname"];
        }

        protected void btnEleTerrif_Click(object sender, EventArgs e)
        {
            Response.Redirect("elerate.aspx?profile=" + ddProfile.Text + "&mtc=" + txtELEMTC.Text + "&region=" + ddEleRegion.Text + "&eac=" + txtELEEAC.Text + "&supplier=" + DDELESupplier.Text + "&startdate=" + CalEleStartDate.SelectedDate.ToString() + "&bt=" + DDELEBusinesstype.Text + "&duration=" + txtELEDuration.Text + "&pm=" + txtElepaymentMode.Text);
        }
    }
}