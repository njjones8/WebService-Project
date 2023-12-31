﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TryItPageLocal.ServiceReference1 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/BankWithdraw", ReplyAction="http://tempuri.org/IService1/BankWithdrawResponse")]
        bool BankWithdraw(string encryptedCC, double value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/BankWithdraw", ReplyAction="http://tempuri.org/IService1/BankWithdrawResponse")]
        System.Threading.Tasks.Task<bool> BankWithdrawAsync(string encryptedCC, double value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/BankDeposit", ReplyAction="http://tempuri.org/IService1/BankDepositResponse")]
        bool BankDeposit(string encryptedCC, double value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/BankDeposit", ReplyAction="http://tempuri.org/IService1/BankDepositResponse")]
        System.Threading.Tasks.Task<bool> BankDepositAsync(string encryptedCC, double value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetSubs", ReplyAction="http://tempuri.org/IService1/GetSubsResponse")]
        string[] GetSubs(string username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetSubs", ReplyAction="http://tempuri.org/IService1/GetSubsResponse")]
        System.Threading.Tasks.Task<string[]> GetSubsAsync(string username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/AddSub", ReplyAction="http://tempuri.org/IService1/AddSubResponse")]
        bool AddSub(string username, string subscription);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/AddSub", ReplyAction="http://tempuri.org/IService1/AddSubResponse")]
        System.Threading.Tasks.Task<bool> AddSubAsync(string username, string subscription);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/RemoveSub", ReplyAction="http://tempuri.org/IService1/RemoveSubResponse")]
        bool RemoveSub(string username, string subscription);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/RemoveSub", ReplyAction="http://tempuri.org/IService1/RemoveSubResponse")]
        System.Threading.Tasks.Task<bool> RemoveSubAsync(string username, string subscription);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/AvgWindIntensity", ReplyAction="http://tempuri.org/IService1/AvgWindIntensityResponse")]
        decimal AvgWindIntensity(decimal longitude, decimal latitude);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/AvgWindIntensity", ReplyAction="http://tempuri.org/IService1/AvgWindIntensityResponse")]
        System.Threading.Tasks.Task<decimal> AvgWindIntensityAsync(decimal longitude, decimal latitude);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetNews", ReplyAction="http://tempuri.org/IService1/GetNewsResponse")]
        string[] GetNews(string[] topics);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetNews", ReplyAction="http://tempuri.org/IService1/GetNewsResponse")]
        System.Threading.Tasks.Task<string[]> GetNewsAsync(string[] topics);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : TryItPageLocal.ServiceReference1.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<TryItPageLocal.ServiceReference1.IService1>, TryItPageLocal.ServiceReference1.IService1 {
        
        public Service1Client() {
        }
        
        public Service1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool BankWithdraw(string encryptedCC, double value) {
            return base.Channel.BankWithdraw(encryptedCC, value);
        }
        
        public System.Threading.Tasks.Task<bool> BankWithdrawAsync(string encryptedCC, double value) {
            return base.Channel.BankWithdrawAsync(encryptedCC, value);
        }
        
        public bool BankDeposit(string encryptedCC, double value) {
            return base.Channel.BankDeposit(encryptedCC, value);
        }
        
        public System.Threading.Tasks.Task<bool> BankDepositAsync(string encryptedCC, double value) {
            return base.Channel.BankDepositAsync(encryptedCC, value);
        }
        
        public string[] GetSubs(string username) {
            return base.Channel.GetSubs(username);
        }
        
        public System.Threading.Tasks.Task<string[]> GetSubsAsync(string username) {
            return base.Channel.GetSubsAsync(username);
        }
        
        public bool AddSub(string username, string subscription) {
            return base.Channel.AddSub(username, subscription);
        }
        
        public System.Threading.Tasks.Task<bool> AddSubAsync(string username, string subscription) {
            return base.Channel.AddSubAsync(username, subscription);
        }
        
        public bool RemoveSub(string username, string subscription) {
            return base.Channel.RemoveSub(username, subscription);
        }
        
        public System.Threading.Tasks.Task<bool> RemoveSubAsync(string username, string subscription) {
            return base.Channel.RemoveSubAsync(username, subscription);
        }
        
        public decimal AvgWindIntensity(decimal longitude, decimal latitude) {
            return base.Channel.AvgWindIntensity(longitude, latitude);
        }
        
        public System.Threading.Tasks.Task<decimal> AvgWindIntensityAsync(decimal longitude, decimal latitude) {
            return base.Channel.AvgWindIntensityAsync(longitude, latitude);
        }
        
        public string[] GetNews(string[] topics) {
            return base.Channel.GetNews(topics);
        }
        
        public System.Threading.Tasks.Task<string[]> GetNewsAsync(string[] topics) {
            return base.Channel.GetNewsAsync(topics);
        }
    }
}
