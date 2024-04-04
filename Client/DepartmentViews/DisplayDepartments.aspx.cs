using Client.deptServiceRef;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Client
{
    public partial class DisplayDepartments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateGridView();
            }
        }

        private void PopulateGridView()
        {
            DepartmentServiceClient dc = new DepartmentServiceClient();
            List<DepartmentDTO> depts = dc.getDepartments().ToList();
            
            // Create a DataTable
            DataTable dtDepartments = new DataTable();
            dtDepartments.Columns.Add("DeptId");
            dtDepartments.Columns.Add("Name");
            dtDepartments.Columns.Add("Location");

            // Add rows to the DataTable
            foreach (var dept in depts)
            {
                DataRow dr = dtDepartments.NewRow();
                dr["DeptId"] = dept.DepartmentId;
                dr["Name"] = dept.Name;
                dr["Location"] = dept.Location;
                dtDepartments.Rows.Add(dr);
            }

            // Bind the DataTable to GridView
            gvDepartments.DataSource = dtDepartments;
            gvDepartments.DataBind();
        }


        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Button btnDelete = (Button)sender;
            GridViewRow row = (GridViewRow)btnDelete.NamingContainer;

            string commandArgument = btnDelete.CommandArgument;
            string[] args = commandArgument.Split(',');

            string dept_id = args[0];
            int rowIndex = Convert.ToInt32(args[1]);

            DepartmentServiceClient dc = new DepartmentServiceClient();
            string s = dc.deleteDepartment(int.Parse(dept_id));

            PopulateGridView();
            DepartmentDTO dept = dc.getDepartment(int.Parse(dept_id));
            Label1.Text = dept.Name + " " + s;
            Label1.ForeColor = System.Drawing.Color.Red;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Button btnUpdate = (Button)sender;
            GridViewRow row = (GridViewRow)btnUpdate.NamingContainer;

            string commandArgument = btnUpdate.CommandArgument;
            string[] args = commandArgument.Split(',');

            string dept_id = args[0];
            int rowIndex = Convert.ToInt32(args[1]);

            Response.Redirect("UpdateDepartment.aspx?deptId=" + Server.UrlEncode(dept_id));
        }

        protected void btnDeptEmployees_Click(object sender, EventArgs e)
        {
            Button btnDelete = (Button)sender;
            GridViewRow row = (GridViewRow)btnDelete.NamingContainer;

            string commandArgument = btnDelete.CommandArgument;
            string[] args = commandArgument.Split(',');

            string dept_id = args[0];
            int rowIndex = Convert.ToInt32(args[1]);

            Response.Redirect("DepartmentEmployees.aspx?deptId=" + Server.UrlEncode(dept_id));
        }

        protected void btnDeptProjects_Click(object sender, EventArgs e)
        {
            Button btnDelete = (Button)sender;
            GridViewRow row = (GridViewRow)btnDelete.NamingContainer;

            string commandArgument = btnDelete.CommandArgument;
            string[] args = commandArgument.Split(',');

            string dept_id = args[0];
            int rowIndex = Convert.ToInt32(args[1]);

            Response.Redirect("DepartmentProjects.aspx?deptId=" + Server.UrlEncode(dept_id));
        }
    }
}