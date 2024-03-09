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
                    
                    DepartmentServiceClient dc = new DepartmentServiceClient();
                    DepartmentDTO dept = dc.getDepartment(departmentName);


                    // Populate the textboxes with existing department details
                    tbName.Text = dept.Name;
                    tbLocation.Text = dept.Location;
                }
            }
        }

        protected void btnUpdateDept_Click(object sender, EventArgs e)
        {
            string departmentName = Request.QueryString["deptName"];

            string name = tbName.Text;
            string location = tbLocation.Text;

            DepartmentDTO departmentDTO = new DepartmentDTO();
            departmentDTO.Name = name;
            departmentDTO.Location = location;

            DepartmentServiceClient dc = new DepartmentServiceClient();
            string s = dc.updateDepartment(departmentName, departmentDTO);

            Label1.Text = s;
        }
    }
}