﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Client.deptServiceRef {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DepartmentDTO", Namespace="http://schemas.datacontract.org/2004/07/EMS.Models")]
    [System.SerializableAttribute()]
    public partial class DepartmentDTO : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int DepartmentIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LocationField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
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
        public int DepartmentId {
            get {
                return this.DepartmentIdField;
            }
            set {
                if ((this.DepartmentIdField.Equals(value) != true)) {
                    this.DepartmentIdField = value;
                    this.RaisePropertyChanged("DepartmentId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Location {
            get {
                return this.LocationField;
            }
            set {
                if ((object.ReferenceEquals(this.LocationField, value) != true)) {
                    this.LocationField = value;
                    this.RaisePropertyChanged("Location");
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
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Department", Namespace="http://schemas.datacontract.org/2004/07/EMS")]
    [System.SerializableAttribute()]
    public partial class Department : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int DepartmentIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Client.deptServiceRef.Employee[] EmployeesField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LocationField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Client.deptServiceRef.Project[] ProjectsField;
        
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
        public int DepartmentId {
            get {
                return this.DepartmentIdField;
            }
            set {
                if ((this.DepartmentIdField.Equals(value) != true)) {
                    this.DepartmentIdField = value;
                    this.RaisePropertyChanged("DepartmentId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Client.deptServiceRef.Employee[] Employees {
            get {
                return this.EmployeesField;
            }
            set {
                if ((object.ReferenceEquals(this.EmployeesField, value) != true)) {
                    this.EmployeesField = value;
                    this.RaisePropertyChanged("Employees");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Location {
            get {
                return this.LocationField;
            }
            set {
                if ((object.ReferenceEquals(this.LocationField, value) != true)) {
                    this.LocationField = value;
                    this.RaisePropertyChanged("Location");
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
        public Client.deptServiceRef.Project[] Projects {
            get {
                return this.ProjectsField;
            }
            set {
                if ((object.ReferenceEquals(this.ProjectsField, value) != true)) {
                    this.ProjectsField = value;
                    this.RaisePropertyChanged("Projects");
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Project", Namespace="http://schemas.datacontract.org/2004/07/EMS")]
    [System.SerializableAttribute()]
    public partial class Project : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ProjectIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StatusField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TitleField;
        
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
        public int ProjectId {
            get {
                return this.ProjectIdField;
            }
            set {
                if ((this.ProjectIdField.Equals(value) != true)) {
                    this.ProjectIdField = value;
                    this.RaisePropertyChanged("ProjectId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Status {
            get {
                return this.StatusField;
            }
            set {
                if ((object.ReferenceEquals(this.StatusField, value) != true)) {
                    this.StatusField = value;
                    this.RaisePropertyChanged("Status");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Title {
            get {
                return this.TitleField;
            }
            set {
                if ((object.ReferenceEquals(this.TitleField, value) != true)) {
                    this.TitleField = value;
                    this.RaisePropertyChanged("Title");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="deptServiceRef.IDepartmentService")]
    public interface IDepartmentService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDepartmentService/getDepartment", ReplyAction="http://tempuri.org/IDepartmentService/getDepartmentResponse")]
        Client.deptServiceRef.DepartmentDTO getDepartment(string dept_name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDepartmentService/getDepartment", ReplyAction="http://tempuri.org/IDepartmentService/getDepartmentResponse")]
        System.Threading.Tasks.Task<Client.deptServiceRef.DepartmentDTO> getDepartmentAsync(string dept_name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDepartmentService/getDepartments", ReplyAction="http://tempuri.org/IDepartmentService/getDepartmentsResponse")]
        Client.deptServiceRef.DepartmentDTO[] getDepartments();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDepartmentService/getDepartments", ReplyAction="http://tempuri.org/IDepartmentService/getDepartmentsResponse")]
        System.Threading.Tasks.Task<Client.deptServiceRef.DepartmentDTO[]> getDepartmentsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDepartmentService/addDepartment", ReplyAction="http://tempuri.org/IDepartmentService/addDepartmentResponse")]
        string addDepartment(Client.deptServiceRef.DepartmentDTO d);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDepartmentService/addDepartment", ReplyAction="http://tempuri.org/IDepartmentService/addDepartmentResponse")]
        System.Threading.Tasks.Task<string> addDepartmentAsync(Client.deptServiceRef.DepartmentDTO d);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDepartmentService/updateDepartment", ReplyAction="http://tempuri.org/IDepartmentService/updateDepartmentResponse")]
        string updateDepartment(string dept_name, Client.deptServiceRef.Department d);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDepartmentService/updateDepartment", ReplyAction="http://tempuri.org/IDepartmentService/updateDepartmentResponse")]
        System.Threading.Tasks.Task<string> updateDepartmentAsync(string dept_name, Client.deptServiceRef.Department d);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDepartmentService/deleteDepartment", ReplyAction="http://tempuri.org/IDepartmentService/deleteDepartmentResponse")]
        string deleteDepartment(string dept_name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDepartmentService/deleteDepartment", ReplyAction="http://tempuri.org/IDepartmentService/deleteDepartmentResponse")]
        System.Threading.Tasks.Task<string> deleteDepartmentAsync(string dept_name);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IDepartmentServiceChannel : Client.deptServiceRef.IDepartmentService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DepartmentServiceClient : System.ServiceModel.ClientBase<Client.deptServiceRef.IDepartmentService>, Client.deptServiceRef.IDepartmentService {
        
        public DepartmentServiceClient() {
        }
        
        public DepartmentServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public DepartmentServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DepartmentServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DepartmentServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Client.deptServiceRef.DepartmentDTO getDepartment(string dept_name) {
            return base.Channel.getDepartment(dept_name);
        }
        
        public System.Threading.Tasks.Task<Client.deptServiceRef.DepartmentDTO> getDepartmentAsync(string dept_name) {
            return base.Channel.getDepartmentAsync(dept_name);
        }
        
        public Client.deptServiceRef.DepartmentDTO[] getDepartments() {
            return base.Channel.getDepartments();
        }
        
        public System.Threading.Tasks.Task<Client.deptServiceRef.DepartmentDTO[]> getDepartmentsAsync() {
            return base.Channel.getDepartmentsAsync();
        }
        
        public string addDepartment(Client.deptServiceRef.DepartmentDTO d) {
            return base.Channel.addDepartment(d);
        }
        
        public System.Threading.Tasks.Task<string> addDepartmentAsync(Client.deptServiceRef.DepartmentDTO d) {
            return base.Channel.addDepartmentAsync(d);
        }
        
        public string updateDepartment(string dept_name, Client.deptServiceRef.Department d) {
            return base.Channel.updateDepartment(dept_name, d);
        }
        
        public System.Threading.Tasks.Task<string> updateDepartmentAsync(string dept_name, Client.deptServiceRef.Department d) {
            return base.Channel.updateDepartmentAsync(dept_name, d);
        }
        
        public string deleteDepartment(string dept_name) {
            return base.Channel.deleteDepartment(dept_name);
        }
        
        public System.Threading.Tasks.Task<string> deleteDepartmentAsync(string dept_name) {
            return base.Channel.deleteDepartmentAsync(dept_name);
        }
    }
}
