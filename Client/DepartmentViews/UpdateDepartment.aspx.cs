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
                    string dept_name = Request.QueryString["deptName"];
                    
                    DepartmentServiceClient dc = new DepartmentServiceClient();
                    DepartmentDTO dept = dc.getDepartment(dept_name);


                    // Populate the textboxes with existing department details
                    tbName.Text = dept.Name;
                    tbLocation.Text = dept.Location;
                }
            }
        }

        protected void btnUpdateDept_Click(object sender, EventArgs e)
        {
            string deptName = Request.QueryString["deptName"];

            string name = tbName.Text;
            string location = tbLocation.Text;

            DepartmentDTO deptDTO = new DepartmentDTO();
            deptDTO.Name = name;
            deptDTO.Location = location;

            DepartmentServiceClient dc = new DepartmentServiceClient();
            string s = dc.updateDepartment(deptName, deptDTO);

            Response.Redirect("DisplayDepartments.aspx");
        }
    }
}