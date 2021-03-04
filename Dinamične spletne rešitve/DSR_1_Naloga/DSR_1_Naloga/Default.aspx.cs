using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DSR_1_Naloga
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string n1 = Request.QueryString["st1"];
            string n2 = Request.QueryString["st2"];
            string op = Request.QueryString["operator"];

            st1.Value = n1;
            st2.Value = n2;
            oper.Value = op;
        }

        protected void GremoDrgam(object sender, EventArgs e)
        {
            Response.Redirect($"Default.aspx?st1={s1.Text}&st2={s2.Text}&operator={ope.Text}");
            //Response.Redirect($"Default.aspx?st1={(s1.Text.Length > 0 ? s1.Text : 0.ToString())}&st2={(s2.Text.Length > 0 ? s2.Text : 0.ToString())}&operator={ope.Text}");
        }
    }


}