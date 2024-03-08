﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Client.empServiceRef {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Employee", Namespace="http://schemas.datacontract.org/2004/07/EMS")]
    [System.SerializableAttribute()]
    public partial class Employee : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int EmployeeIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int SalaryField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int EmployeeId {
            get {
                return this.EmployeeIdField;
            }
            set {
                if ((this.EmployeeIdField.Equals(value) != true)) {
                    this.EmployeeIdField = value;
                    this.RaisePropertyChanged("EmployeeId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Salary {
            get {
                return this.SalaryField;
            }
            set {
                if ((this.SalaryField.Equals(value) != true)) {
                    this.SalaryField = value;
                    this.RaisePropertyChanged("Salary");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="empServiceRef.IEmployeeService")]
    public interface IEmployeeService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmployeeService/addEmployee", ReplyAction="http://tempuri.org/IEmployeeService/addEmployeeResponse")]
        string addEmployee(Client.empServiceRef.Employee e, string deptName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmployeeService/addEmployee", ReplyAction="http://tempuri.org/IEmployeeService/addEmployeeResponse")]
        System.Threading.Tasks.Task<string> addEmployeeAsync(Client.empServiceRef.Employee e, string deptName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmployeeService/getEmployee", ReplyAction="http://tempuri.org/IEmployeeService/getEmployeeResponse")]
        Client.empServiceRef.Employee getEmployee(int emp_id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmployeeService/getEmployee", ReplyAction="http://tempuri.org/IEmployeeService/getEmployeeResponse")]
        System.Threading.Tasks.Task<Client.empServiceRef.Employee> getEmployeeAsync(int emp_id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmployeeService/updateEmployee", ReplyAction="http://tempuri.org/IEmployeeService/updateEmployeeResponse")]
        string updateEmployee(int emp_id, Client.empServiceRef.Employee e);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmployeeService/updateEmployee", ReplyAction="http://tempuri.org/IEmployeeService/updateEmployeeResponse")]
        System.Threading.Tasks.Task<string> updateEmployeeAsync(int emp_id, Client.empServiceRef.Employee e);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmployeeService/deleteEmployee", ReplyAction="http://tempuri.org/IEmployeeService/deleteEmployeeResponse")]
        string deleteEmployee(int emp_id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmployeeService/deleteEmployee", ReplyAction="http://tempuri.org/IEmployeeService/deleteEmployeeResponse")]
        System.Threading.Tasks.Task<string> deleteEmployeeAsync(int emp_id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmployeeService/getEmployees", ReplyAction="http://tempuri.org/IEmployeeService/getEmployeesResponse")]
        Client.empServiceRef.Employee[] getEmployees();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmployeeService/getEmployees", ReplyAction="http://tempuri.org/IEmployeeService/getEmployeesResponse")]
        System.Threading.Tasks.Task<Client.empServiceRef.Employee[]> getEmployeesAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IEmployeeServiceChannel : Client.empServiceRef.IEmployeeService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class EmployeeServiceClient : System.ServiceModel.ClientBase<Client.empServiceRef.IEmployeeService>, Client.empServiceRef.IEmployeeService {
        
        public EmployeeServiceClient() {
        }
        
        public EmployeeServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public EmployeeServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public EmployeeServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public EmployeeServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string addEmployee(Client.empServiceRef.Employee e, string deptName) {
            return base.Channel.addEmployee(e, deptName);
        }
        
        public System.Threading.Tasks.Task<string> addEmployeeAsync(Client.empServiceRef.Employee e, string deptName) {
            return base.Channel.addEmployeeAsync(e, deptName);
        }
        
        public Client.empServiceRef.Employee getEmployee(int emp_id) {
            return base.Channel.getEmployee(emp_id);
        }
        
        public System.Threading.Tasks.Task<Client.empServiceRef.Employee> getEmployeeAsync(int emp_id) {
            return base.Channel.getEmployeeAsync(emp_id);
        }
        
        public string updateEmployee(int emp_id, Client.empServiceRef.Employee e) {
            return base.Channel.updateEmployee(emp_id, e);
        }
        
        public System.Threading.Tasks.Task<string> updateEmployeeAsync(int emp_id, Client.empServiceRef.Employee e) {
            return base.Channel.updateEmployeeAsync(emp_id, e);
        }
        
        public string deleteEmployee(int emp_id) {
            return base.Channel.deleteEmployee(emp_id);
        }
        
        public System.Threading.Tasks.Task<string> deleteEmployeeAsync(int emp_id) {
            return base.Channel.deleteEmployeeAsync(emp_id);
        }
        
        public Client.empServiceRef.Employee[] getEmployees() {
            return base.Channel.getEmployees();
        }
        
        public System.Threading.Tasks.Task<Client.empServiceRef.Employee[]> getEmployeesAsync() {
            return base.Channel.getEmployeesAsync();
        }
    }
}
