using EMS.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Host
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ServiceHost empsh1 = null;
        ServiceHost deptsh1 = null;
        ServiceHost projsh1 = null;
        private void Form1_Load(object sender, EventArgs e)
        {
            Uri empa = new Uri("net.tcp://localhost:8000/empService");
            Uri depta = new Uri("net.tcp://localhost:8000/deptService");
            Uri proja = new Uri("net.tcp://localhost:8000/projService");

            try
            {
                empsh1 = new ServiceHost(typeof(EmployeeService), empa);
                deptsh1 = new ServiceHost(typeof(DepartmentService), depta);
                projsh1 = new ServiceHost(typeof(ProjectService), proja);

                NetTcpBinding empb = new NetTcpBinding();
                NetTcpBinding deptb = new NetTcpBinding();
                NetTcpBinding projb = new NetTcpBinding();

                ServiceMetadataBehavior empMBehave = new ServiceMetadataBehavior();
                empsh1.Description.Behaviors.Add(empMBehave);
                empsh1.AddServiceEndpoint(typeof(IMetadataExchange), MetadataExchangeBindings.CreateMexTcpBinding(), "mex");
                empsh1.AddServiceEndpoint(typeof(IEmployeeService), empb, empa);

                ServiceMetadataBehavior deptMBehave = new ServiceMetadataBehavior();
                deptsh1.Description.Behaviors.Add(deptMBehave);
                deptsh1.Description.Behaviors.Remove(typeof(ServiceDebugBehavior));
                deptsh1.Description.Behaviors.Add(new ServiceDebugBehavior { IncludeExceptionDetailInFaults = true });
                deptsh1.AddServiceEndpoint(typeof(IMetadataExchange), MetadataExchangeBindings.CreateMexTcpBinding(), "mex");
                deptsh1.AddServiceEndpoint(typeof(IDepartmentService), deptb, depta);

                ServiceMetadataBehavior projMBehave = new ServiceMetadataBehavior();
                projsh1.Description.Behaviors.Add(projMBehave);
                projsh1.AddServiceEndpoint(typeof(IMetadataExchange), MetadataExchangeBindings.CreateMexTcpBinding(), "mex");
                projsh1.AddServiceEndpoint(typeof(IProjectService), projb, proja);

                empsh1.Open();
                deptsh1.Open();
                projsh1.Open();

                lblConfirmation.Text = "EMS is hosted...";

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}
