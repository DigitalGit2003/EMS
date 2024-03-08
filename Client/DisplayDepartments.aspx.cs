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
            deptServiceRef.DepartmentServiceClient dc = new deptServiceRef.DepartmentServiceClient("NetTcpBinding_IDepartmentService");
            List<string> deptNames = dc.getDepartmentNames().ToList();
            List<string> deptLocations = dc.getDepartmentLocations().ToList();

            // Create a DataTable
            DataTable dtDepartments = new DataTable();
            dtDepartments.Columns.Add("Name");
            dtDepartments.Columns.Add("Location");

            // Add rows to the DataTable
            for (int i = 0; i < deptNames.Count; i++)
            {
                DataRow dr = dtDepartments.NewRow();
                dr["Name"] = deptNames[i];
                dr["Location"] = deptLocations[i];
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

            string dept_name = args[0];
            int rowIndex = Convert.ToInt32(args[1]);

            DepartmentServiceClient dc = new DepartmentServiceClient();
            string s = dc.deleteDepartment(dept_name);

            PopulateGridView();
            Label1.Text = s;
        }
    }
}