﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

// 
// 此源代码是由 Microsoft.VSDesigner 4.0.30319.42000 版自动生成。
// 
#pragma warning disable 1591

namespace Test.DBWebService {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3062.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="DBWebServiceSoap", Namespace="http://tempuri.org/")]
    public partial class DBWebService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback AddPU_AppVouchOperationCompleted;
        
        private System.Threading.SendOrPostCallback AddMaterialAppVouchOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public DBWebService() {
            this.Url = global::Test.Properties.Settings.Default.Test_localhost_DBWebService;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event AddPU_AppVouchCompletedEventHandler AddPU_AppVouchCompleted;
        
        /// <remarks/>
        public event AddMaterialAppVouchCompletedEventHandler AddMaterialAppVouchCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/AddPU_AppVouch", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string AddPU_AppVouch(string sXML) {
            object[] results = this.Invoke("AddPU_AppVouch", new object[] {
                        sXML});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void AddPU_AppVouchAsync(string sXML) {
            this.AddPU_AppVouchAsync(sXML, null);
        }
        
        /// <remarks/>
        public void AddPU_AppVouchAsync(string sXML, object userState) {
            if ((this.AddPU_AppVouchOperationCompleted == null)) {
                this.AddPU_AppVouchOperationCompleted = new System.Threading.SendOrPostCallback(this.OnAddPU_AppVouchOperationCompleted);
            }
            this.InvokeAsync("AddPU_AppVouch", new object[] {
                        sXML}, this.AddPU_AppVouchOperationCompleted, userState);
        }
        
        private void OnAddPU_AppVouchOperationCompleted(object arg) {
            if ((this.AddPU_AppVouchCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.AddPU_AppVouchCompleted(this, new AddPU_AppVouchCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/AddMaterialAppVouch", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string AddMaterialAppVouch(string sXML) {
            object[] results = this.Invoke("AddMaterialAppVouch", new object[] {
                        sXML});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void AddMaterialAppVouchAsync(string sXML) {
            this.AddMaterialAppVouchAsync(sXML, null);
        }
        
        /// <remarks/>
        public void AddMaterialAppVouchAsync(string sXML, object userState) {
            if ((this.AddMaterialAppVouchOperationCompleted == null)) {
                this.AddMaterialAppVouchOperationCompleted = new System.Threading.SendOrPostCallback(this.OnAddMaterialAppVouchOperationCompleted);
            }
            this.InvokeAsync("AddMaterialAppVouch", new object[] {
                        sXML}, this.AddMaterialAppVouchOperationCompleted, userState);
        }
        
        private void OnAddMaterialAppVouchOperationCompleted(object arg) {
            if ((this.AddMaterialAppVouchCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.AddMaterialAppVouchCompleted(this, new AddMaterialAppVouchCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3062.0")]
    public delegate void AddPU_AppVouchCompletedEventHandler(object sender, AddPU_AppVouchCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3062.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class AddPU_AppVouchCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal AddPU_AppVouchCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3062.0")]
    public delegate void AddMaterialAppVouchCompletedEventHandler(object sender, AddMaterialAppVouchCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3062.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class AddMaterialAppVouchCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal AddMaterialAppVouchCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591