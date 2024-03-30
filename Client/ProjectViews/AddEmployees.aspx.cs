using Client.deptServiceRef;
using Client.empServiceRef;
using Client.projServiceRef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EmpEmployeeDTO = Client.empServiceRef.EmployeeDTO;
using ProjEmployeeDTO = Client.projServiceRef.EmployeeDTO;

namespace Client.ProjectViews
{
    public partial class AddEmployees : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                string dept_id = Request.QueryString["deptId"];
                string proj_id = Request.QueryString["projId"];
                lblAddEmployees.Text = "Add Employees for " + proj_id + " Project.";

                // get all employees of the department
                EmployeeServiceClient ec = new EmployeeServiceClient();
                List<EmpEmployeeDTO> emps = ec.getEmployeesByDepartmentId(int.Parse(dept_id)).ToList();

                // disable checkbox for employees already selected for project(proj_id)
                ProjectServiceClient pc = new ProjectServiceClient();
                List<ProjEmployeeDTO> empsExists = pc.viewEmployees(int.Parse(proj_id)).ToList();

                foreach (EmpEmployeeDTO emp in emps)
                {
                    ListItem item = new ListItem(emp.Name);
                    if (empsExists.Any(ee => ee.EmployeeId == emp.EmployeeId))
                    {
                        item.Enabled = false; // Disable the checkbox
                    }
                    cblEmployees.Items.Add(item);
                }
            }
        }


        protected void btnAddEmployees_Click(object sender, EventArgs e)
        {
            string dept_id = Request.QueryString["deptId"];
            string proj_id = Request.QueryString["projId"];
            List<string> emps = new List<string>();

            foreach (ListItem item in cblEmployees.Items)
            {
                if (item.Selected)
                {
                    emps.Add(item.Text);
                }
            }

            ProjectServiceClient pc = new ProjectServiceClient();
            string s = pc.addEmployees(int.Parse(proj_id), emps.ToArray());

            Label1.Text = s;
            Label1.ForeColor = System.Drawing.Color.Green;
            //Response.Redirect("/DepartmentViews/DepartmentProjects.aspx?deptId=" + Server.UrlEncode(dept_id));
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            string dept_id = Request.QueryString["deptId"];
            Response.Redirect("/DepartmentViews/DepartmentProjects.aspx?deptId=" + Server.UrlEncode(dept_id));
        }
    }
}