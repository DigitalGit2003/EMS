using Client.deptServiceRef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Client
{
    public partial class AddDepartment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
     
        }

        protected void btnAddDept_Click(object sender, EventArgs e)
        {
            string name = tbName.Text;
            string location = tbLocation.Text;
            
            DepartmentDTO departmentDTO = new DepartmentDTO();
            departmentDTO.Name = name;
            departmentDTO.Location = location;

            DepartmentServiceClient dc = new DepartmentServiceClient();
            string s = dc.addDepartment(departmentDTO);

            Label1.Text = s;
            Label1.ForeColor = System.Drawing.Color.Green;
        }
    }
}