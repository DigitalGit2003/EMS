using Client.deptServiceRef;
using Client.empServiceRef;
using Client.projServiceRef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Client.ProjectViews
{
    public partial class AddEmployees : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                string dept_name = Request.QueryString["deptName"];
                string proj_title = Request.QueryString["projTitle"];
                lblAddEmployees.Text = "Add Employees for " + proj_title + " Project.";

                // get all employees of the department
                EmployeeServiceClient ec = new EmployeeServiceClient();
                List<EmployeeDTO> emps = ec.getEmployeesByDepartmentName(dept_name).ToList();

                foreach (EmployeeDTO emp in emps)
                {
                    cblEmployees.Items.Add(new ListItem(emp.Name));
                }
            }
        }


        protected void btnAddEmployees_Click(object sender, EventArgs e)
        {
            string dept_name = Request.QueryString["deptName"];
            string proj_title = Request.QueryString["projTitle"];
            List<string> emps = new List<string>();

            foreach (ListItem item in cblEmployees.Items)
            {
                if (item.Selected)
                {
                    emps.Add(item.Text);
                }
            }

            ProjectServiceClient pc = new ProjectServiceClient();
            string s = pc.addEmployees(proj_title, emps.ToArray());

            Label1.Text = s;
            Label1.ForeColor = System.Drawing.Color.Green;
            //Response.Redirect("/DepartmentViews/DepartmentProjects.aspx?deptName=" + Server.UrlEncode(dept_name));
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            string dept_name = Request.QueryString["deptName"];
            Response.Redirect("/DepartmentViews/DepartmentProjects.aspx?deptName=" + Server.UrlEncode(dept_name));
        }
    }
}