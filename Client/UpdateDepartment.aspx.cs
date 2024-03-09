using Client.deptServiceRef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Client
{
    public partial class UpdateDepartment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["deptName"] != null)
                {
                    string departmentName = Request.QueryString["deptName"];
                    Label1.Text = departmentName;
                }
            }
        }
    }
}