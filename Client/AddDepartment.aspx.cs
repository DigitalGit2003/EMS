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

            Department department = new Department();
            department.Name = name;
            department.Location = location;

            deptServiceRef.DepartmentServiceClient dc = new deptServiceRef.DepartmentServiceClient("NetTcpBinding_IDepartmentService");
            string s = dc.addDepartment(department);

            Label1.Text = s;
        }
    }
}