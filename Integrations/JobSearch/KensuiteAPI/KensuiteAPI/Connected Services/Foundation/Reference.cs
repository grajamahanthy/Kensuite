﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KensuiteAPI.Foundation {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://trm.brassring.com/HRIS", ConfigurationName="Foundation.DispatchMessageSoap")]
    public interface DispatchMessageSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://trm.brassring.com/HRIS/Dispatch", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string Dispatch(string HRXML);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://trm.brassring.com/HRIS/Dispatch", ReplyAction="*")]
        System.Threading.Tasks.Task<string> DispatchAsync(string HRXML);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface DispatchMessageSoapChannel : KensuiteAPI.Foundation.DispatchMessageSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DispatchMessageSoapClient : System.ServiceModel.ClientBase<KensuiteAPI.Foundation.DispatchMessageSoap>, KensuiteAPI.Foundation.DispatchMessageSoap {
        
        public DispatchMessageSoapClient() {
        }
        
        public DispatchMessageSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public DispatchMessageSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DispatchMessageSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DispatchMessageSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string Dispatch(string HRXML) {
            return base.Channel.Dispatch(HRXML);
        }
        
        public System.Threading.Tasks.Task<string> DispatchAsync(string HRXML) {
            return base.Channel.DispatchAsync(HRXML);
        }
    }
}