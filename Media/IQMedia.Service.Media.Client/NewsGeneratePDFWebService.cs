﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.269
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------



[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
[System.ServiceModel.ServiceContractAttribute(ConfigurationName="INewsGeneratePDFWebService")]
public interface INewsGeneratePDFWebService
{
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INewsGeneratePDFWebService/WakeupService", ReplyAction="http://tempuri.org/INewsGeneratePDFWebService/WakeupServiceResponse")]
    void WakeupService();
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public interface INewsGeneratePDFWebServiceChannel : INewsGeneratePDFWebService, System.ServiceModel.IClientChannel
{
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public partial class NewsGeneratePDFWebServiceClient : System.ServiceModel.ClientBase<INewsGeneratePDFWebService>, INewsGeneratePDFWebService
{
    
    public NewsGeneratePDFWebServiceClient()
    {
    }
    
    public NewsGeneratePDFWebServiceClient(string endpointConfigurationName) : 
            base(endpointConfigurationName)
    {
    }
    
    public NewsGeneratePDFWebServiceClient(string endpointConfigurationName, string remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public NewsGeneratePDFWebServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public NewsGeneratePDFWebServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(binding, remoteAddress)
    {
    }
    
    public void WakeupService()
    {
        base.Channel.WakeupService();
    }
}
