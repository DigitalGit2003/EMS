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
                if (Request.QueryString["deptId"] != null)
                {
                    string dept_id = Request.QueryString["deptId"];
                    
                    DepartmentServiceClient dc = new DepartmentServiceClient();
                    DepartmentDTO dept = dc.getDepartment(int.Parse(dept_id));


                    // Populate the textboxes with existing department details
                    tbName.Text = dept.Name;
                    tbLocation.Text = dept.Location;
                }
            }
        }

        protected void btnUpdateDept_Click(object sender, EventArgs e)
        {
            string dept_id = Request.QueryString["deptId"];

            string name = tbName.Text;
            string location = tbLocation.Text;

            DepartmentDTO deptDTO = new DepartmentDTO();
            deptDTO.Name = name;
            deptDTO.Location = location;

            DepartmentServiceClient dc = new DepartmentServiceClient();
            string s = dc.updateDepartment(int.Parse(dept_id), deptDTO);

            Response.Redirect("DisplayDepartments.aspx");
        }
    }
}