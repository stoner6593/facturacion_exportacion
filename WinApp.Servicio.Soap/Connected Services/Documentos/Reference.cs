﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WinApp.Servicio.Soap.Documentos {
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3062.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://service.sunat.gob.pe/")]
    public partial class SOAPException : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string messageField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public string message {
            get {
                return this.messageField;
            }
            set {
                this.messageField = value;
                this.RaisePropertyChanged("message");
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
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3062.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://service.sunat.gob.pe")]
    public partial class StatusCdr : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string numeroComprobanteField;
        
        private string rucComprobanteField;
        
        private string serieComprobanteField;
        
        private string tipoComprobanteField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public string numeroComprobante {
            get {
                return this.numeroComprobanteField;
            }
            set {
                this.numeroComprobanteField = value;
                this.RaisePropertyChanged("numeroComprobante");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public string rucComprobante {
            get {
                return this.rucComprobanteField;
            }
            set {
                this.rucComprobanteField = value;
                this.RaisePropertyChanged("rucComprobante");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=2)]
        public string serieComprobante {
            get {
                return this.serieComprobanteField;
            }
            set {
                this.serieComprobanteField = value;
                this.RaisePropertyChanged("serieComprobante");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=3)]
        public string tipoComprobante {
            get {
                return this.tipoComprobanteField;
            }
            set {
                this.tipoComprobanteField = value;
                this.RaisePropertyChanged("tipoComprobante");
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
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://service.sunat.gob.pe/", ConfigurationName="Documentos.BizlinksOSE")]
    public interface BizlinksOSE {
        
        // CODEGEN: Se está generando un contrato de mensaje, ya que el espacio de nombres de contenedor (http://service.sunat.gob.pe) del mensaje getStatusCdr no coincide con el valor predeterminado (http://service.sunat.gob.pe/)
        [System.ServiceModel.OperationContractAttribute(Action="urn:getStatusCdr", ReplyAction="*")]
        [System.ServiceModel.FaultContractAttribute(typeof(WinApp.Servicio.Soap.Documentos.SOAPException), Action="urn:getStatusCdr", Name="SOAPException")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        WinApp.Servicio.Soap.Documentos.getStatusCdrResponse getStatusCdr(WinApp.Servicio.Soap.Documentos.getStatusCdr request);
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:getStatusCdr", ReplyAction="*")]
        System.Threading.Tasks.Task<WinApp.Servicio.Soap.Documentos.getStatusCdrResponse> getStatusCdrAsync(WinApp.Servicio.Soap.Documentos.getStatusCdr request);
        
        // CODEGEN: Se está generando un contrato de mensaje, ya que el espacio de nombres de contenedor (http://service.sunat.gob.pe) del mensaje sendPack no coincide con el valor predeterminado (http://service.sunat.gob.pe/)
        [System.ServiceModel.OperationContractAttribute(Action="urn:sendPack", ReplyAction="*")]
        [System.ServiceModel.FaultContractAttribute(typeof(WinApp.Servicio.Soap.Documentos.SOAPException), Action="urn:sendPack", Name="SOAPException")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        WinApp.Servicio.Soap.Documentos.sendPackResponse sendPack(WinApp.Servicio.Soap.Documentos.sendPack request);
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:sendPack", ReplyAction="*")]
        System.Threading.Tasks.Task<WinApp.Servicio.Soap.Documentos.sendPackResponse> sendPackAsync(WinApp.Servicio.Soap.Documentos.sendPack request);
        
        // CODEGEN: Se está generando un contrato de mensaje, ya que el espacio de nombres de contenedor (http://service.sunat.gob.pe) del mensaje sendBill no coincide con el valor predeterminado (http://service.sunat.gob.pe/)
        [System.ServiceModel.OperationContractAttribute(Action="urn:sendBill", ReplyAction="*")]
        [System.ServiceModel.FaultContractAttribute(typeof(WinApp.Servicio.Soap.Documentos.SOAPException), Action="urn:sendBill", Name="SOAPException")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        WinApp.Servicio.Soap.Documentos.sendBillResponse sendBill(WinApp.Servicio.Soap.Documentos.sendBill request);
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:sendBill", ReplyAction="*")]
        System.Threading.Tasks.Task<WinApp.Servicio.Soap.Documentos.sendBillResponse> sendBillAsync(WinApp.Servicio.Soap.Documentos.sendBill request);
        
        // CODEGEN: Se está generando un contrato de mensaje, ya que el espacio de nombres de contenedor (http://service.sunat.gob.pe) del mensaje getStatus no coincide con el valor predeterminado (http://service.sunat.gob.pe/)
        [System.ServiceModel.OperationContractAttribute(Action="urn:getStatus", ReplyAction="*")]
        [System.ServiceModel.FaultContractAttribute(typeof(WinApp.Servicio.Soap.Documentos.SOAPException), Action="urn:getStatus", Name="SOAPException")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        WinApp.Servicio.Soap.Documentos.getStatusResponse getStatus(WinApp.Servicio.Soap.Documentos.getStatus request);
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:getStatus", ReplyAction="*")]
        System.Threading.Tasks.Task<WinApp.Servicio.Soap.Documentos.getStatusResponse> getStatusAsync(WinApp.Servicio.Soap.Documentos.getStatus request);
        
        // CODEGEN: Se está generando un contrato de mensaje, ya que el espacio de nombres de contenedor (http://service.sunat.gob.pe) del mensaje sendSummary no coincide con el valor predeterminado (http://service.sunat.gob.pe/)
        [System.ServiceModel.OperationContractAttribute(Action="urn:sendSummary", ReplyAction="*")]
        [System.ServiceModel.FaultContractAttribute(typeof(WinApp.Servicio.Soap.Documentos.SOAPException), Action="urn:sendSummary", Name="SOAPException")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        WinApp.Servicio.Soap.Documentos.sendSummaryResponse sendSummary(WinApp.Servicio.Soap.Documentos.sendSummary request);
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:sendSummary", ReplyAction="*")]
        System.Threading.Tasks.Task<WinApp.Servicio.Soap.Documentos.sendSummaryResponse> sendSummaryAsync(WinApp.Servicio.Soap.Documentos.sendSummary request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="getStatusCdr", WrapperNamespace="http://service.sunat.gob.pe", IsWrapped=true)]
    public partial class getStatusCdr {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://service.sunat.gob.pe", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public WinApp.Servicio.Soap.Documentos.StatusCdr statusCdr;
        
        public getStatusCdr() {
        }
        
        public getStatusCdr(WinApp.Servicio.Soap.Documentos.StatusCdr statusCdr) {
            this.statusCdr = statusCdr;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="getStatusCdrResponse", WrapperNamespace="http://service.sunat.gob.pe", IsWrapped=true)]
    public partial class getStatusCdrResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://service.sunat.gob.pe", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, DataType="base64Binary")]
        public byte[] document;
        
        public getStatusCdrResponse() {
        }
        
        public getStatusCdrResponse(byte[] document) {
            this.document = document;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="sendPack", WrapperNamespace="http://service.sunat.gob.pe", IsWrapped=true)]
    public partial class sendPack {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://service.sunat.gob.pe", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string fileName;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://service.sunat.gob.pe", Order=1)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, DataType="base64Binary")]
        public byte[] contentFile;
        
        public sendPack() {
        }
        
        public sendPack(string fileName, byte[] contentFile) {
            this.fileName = fileName;
            this.contentFile = contentFile;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="sendPackResponse", WrapperNamespace="http://service.sunat.gob.pe", IsWrapped=true)]
    public partial class sendPackResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://service.sunat.gob.pe", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string ticket;
        
        public sendPackResponse() {
        }
        
        public sendPackResponse(string ticket) {
            this.ticket = ticket;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="sendBill", WrapperNamespace="http://service.sunat.gob.pe", IsWrapped=true)]
    public partial class sendBill {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://service.sunat.gob.pe", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string fileName;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://service.sunat.gob.pe", Order=1)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, DataType="base64Binary")]
        public byte[] contentFile;
        
        public sendBill() {
        }
        
        public sendBill(string fileName, byte[] contentFile) {
            this.fileName = fileName;
            this.contentFile = contentFile;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="sendBillResponse", WrapperNamespace="http://service.sunat.gob.pe", IsWrapped=true)]
    public partial class sendBillResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://service.sunat.gob.pe", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, DataType="base64Binary")]
        public byte[] applicationResponse;
        
        public sendBillResponse() {
        }
        
        public sendBillResponse(byte[] applicationResponse) {
            this.applicationResponse = applicationResponse;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3062.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://service.sunat.gob.pe")]
    public partial class statusResponse : object, System.ComponentModel.INotifyPropertyChanged {
        
        private byte[] contentField;
        
        private string statusCodeField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, DataType="base64Binary", Order=0)]
        public byte[] content {
            get {
                return this.contentField;
            }
            set {
                this.contentField = value;
                this.RaisePropertyChanged("content");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public string statusCode {
            get {
                return this.statusCodeField;
            }
            set {
                this.statusCodeField = value;
                this.RaisePropertyChanged("statusCode");
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="getStatus", WrapperNamespace="http://service.sunat.gob.pe", IsWrapped=true)]
    public partial class getStatus {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://service.sunat.gob.pe", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string ticket;
        
        public getStatus() {
        }
        
        public getStatus(string ticket) {
            this.ticket = ticket;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="getStatusResponse", WrapperNamespace="http://service.sunat.gob.pe", IsWrapped=true)]
    public partial class getStatusResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://service.sunat.gob.pe", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public WinApp.Servicio.Soap.Documentos.statusResponse status;
        
        public getStatusResponse() {
        }
        
        public getStatusResponse(WinApp.Servicio.Soap.Documentos.statusResponse status) {
            this.status = status;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="sendSummary", WrapperNamespace="http://service.sunat.gob.pe", IsWrapped=true)]
    public partial class sendSummary {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://service.sunat.gob.pe", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string fileName;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://service.sunat.gob.pe", Order=1)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, DataType="base64Binary")]
        public byte[] contentFile;
        
        public sendSummary() {
        }
        
        public sendSummary(string fileName, byte[] contentFile) {
            this.fileName = fileName;
            this.contentFile = contentFile;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="sendSummaryResponse", WrapperNamespace="http://service.sunat.gob.pe", IsWrapped=true)]
    public partial class sendSummaryResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://service.sunat.gob.pe", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string ticket;
        
        public sendSummaryResponse() {
        }
        
        public sendSummaryResponse(string ticket) {
            this.ticket = ticket;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface BizlinksOSEChannel : WinApp.Servicio.Soap.Documentos.BizlinksOSE, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class BizlinksOSEClient : System.ServiceModel.ClientBase<WinApp.Servicio.Soap.Documentos.BizlinksOSE>, WinApp.Servicio.Soap.Documentos.BizlinksOSE {
        
        public BizlinksOSEClient() {
        }
        
        public BizlinksOSEClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public BizlinksOSEClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public BizlinksOSEClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public BizlinksOSEClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        WinApp.Servicio.Soap.Documentos.getStatusCdrResponse WinApp.Servicio.Soap.Documentos.BizlinksOSE.getStatusCdr(WinApp.Servicio.Soap.Documentos.getStatusCdr request) {
            return base.Channel.getStatusCdr(request);
        }
        
        public byte[] getStatusCdr(WinApp.Servicio.Soap.Documentos.StatusCdr statusCdr) {
            WinApp.Servicio.Soap.Documentos.getStatusCdr inValue = new WinApp.Servicio.Soap.Documentos.getStatusCdr();
            inValue.statusCdr = statusCdr;
            WinApp.Servicio.Soap.Documentos.getStatusCdrResponse retVal = ((WinApp.Servicio.Soap.Documentos.BizlinksOSE)(this)).getStatusCdr(inValue);
            return retVal.document;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<WinApp.Servicio.Soap.Documentos.getStatusCdrResponse> WinApp.Servicio.Soap.Documentos.BizlinksOSE.getStatusCdrAsync(WinApp.Servicio.Soap.Documentos.getStatusCdr request) {
            return base.Channel.getStatusCdrAsync(request);
        }
        
        public System.Threading.Tasks.Task<WinApp.Servicio.Soap.Documentos.getStatusCdrResponse> getStatusCdrAsync(WinApp.Servicio.Soap.Documentos.StatusCdr statusCdr) {
            WinApp.Servicio.Soap.Documentos.getStatusCdr inValue = new WinApp.Servicio.Soap.Documentos.getStatusCdr();
            inValue.statusCdr = statusCdr;
            return ((WinApp.Servicio.Soap.Documentos.BizlinksOSE)(this)).getStatusCdrAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        WinApp.Servicio.Soap.Documentos.sendPackResponse WinApp.Servicio.Soap.Documentos.BizlinksOSE.sendPack(WinApp.Servicio.Soap.Documentos.sendPack request) {
            return base.Channel.sendPack(request);
        }
        
        public string sendPack(string fileName, byte[] contentFile) {
            WinApp.Servicio.Soap.Documentos.sendPack inValue = new WinApp.Servicio.Soap.Documentos.sendPack();
            inValue.fileName = fileName;
            inValue.contentFile = contentFile;
            WinApp.Servicio.Soap.Documentos.sendPackResponse retVal = ((WinApp.Servicio.Soap.Documentos.BizlinksOSE)(this)).sendPack(inValue);
            return retVal.ticket;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<WinApp.Servicio.Soap.Documentos.sendPackResponse> WinApp.Servicio.Soap.Documentos.BizlinksOSE.sendPackAsync(WinApp.Servicio.Soap.Documentos.sendPack request) {
            return base.Channel.sendPackAsync(request);
        }
        
        public System.Threading.Tasks.Task<WinApp.Servicio.Soap.Documentos.sendPackResponse> sendPackAsync(string fileName, byte[] contentFile) {
            WinApp.Servicio.Soap.Documentos.sendPack inValue = new WinApp.Servicio.Soap.Documentos.sendPack();
            inValue.fileName = fileName;
            inValue.contentFile = contentFile;
            return ((WinApp.Servicio.Soap.Documentos.BizlinksOSE)(this)).sendPackAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        WinApp.Servicio.Soap.Documentos.sendBillResponse WinApp.Servicio.Soap.Documentos.BizlinksOSE.sendBill(WinApp.Servicio.Soap.Documentos.sendBill request) {
            return base.Channel.sendBill(request);
        }
        
        public byte[] sendBill(string fileName, byte[] contentFile) {
            WinApp.Servicio.Soap.Documentos.sendBill inValue = new WinApp.Servicio.Soap.Documentos.sendBill();
            inValue.fileName = fileName;
            inValue.contentFile = contentFile;
            WinApp.Servicio.Soap.Documentos.sendBillResponse retVal = ((WinApp.Servicio.Soap.Documentos.BizlinksOSE)(this)).sendBill(inValue);
            return retVal.applicationResponse;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<WinApp.Servicio.Soap.Documentos.sendBillResponse> WinApp.Servicio.Soap.Documentos.BizlinksOSE.sendBillAsync(WinApp.Servicio.Soap.Documentos.sendBill request) {
            return base.Channel.sendBillAsync(request);
        }
        
        public System.Threading.Tasks.Task<WinApp.Servicio.Soap.Documentos.sendBillResponse> sendBillAsync(string fileName, byte[] contentFile) {
            WinApp.Servicio.Soap.Documentos.sendBill inValue = new WinApp.Servicio.Soap.Documentos.sendBill();
            inValue.fileName = fileName;
            inValue.contentFile = contentFile;
            return ((WinApp.Servicio.Soap.Documentos.BizlinksOSE)(this)).sendBillAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        WinApp.Servicio.Soap.Documentos.getStatusResponse WinApp.Servicio.Soap.Documentos.BizlinksOSE.getStatus(WinApp.Servicio.Soap.Documentos.getStatus request) {
            return base.Channel.getStatus(request);
        }
        
        public WinApp.Servicio.Soap.Documentos.statusResponse getStatus(string ticket) {
            WinApp.Servicio.Soap.Documentos.getStatus inValue = new WinApp.Servicio.Soap.Documentos.getStatus();
            inValue.ticket = ticket;
            WinApp.Servicio.Soap.Documentos.getStatusResponse retVal = ((WinApp.Servicio.Soap.Documentos.BizlinksOSE)(this)).getStatus(inValue);
            return retVal.status;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<WinApp.Servicio.Soap.Documentos.getStatusResponse> WinApp.Servicio.Soap.Documentos.BizlinksOSE.getStatusAsync(WinApp.Servicio.Soap.Documentos.getStatus request) {
            return base.Channel.getStatusAsync(request);
        }
        
        public System.Threading.Tasks.Task<WinApp.Servicio.Soap.Documentos.getStatusResponse> getStatusAsync(string ticket) {
            WinApp.Servicio.Soap.Documentos.getStatus inValue = new WinApp.Servicio.Soap.Documentos.getStatus();
            inValue.ticket = ticket;
            return ((WinApp.Servicio.Soap.Documentos.BizlinksOSE)(this)).getStatusAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        WinApp.Servicio.Soap.Documentos.sendSummaryResponse WinApp.Servicio.Soap.Documentos.BizlinksOSE.sendSummary(WinApp.Servicio.Soap.Documentos.sendSummary request) {
            return base.Channel.sendSummary(request);
        }
        
        public string sendSummary(string fileName, byte[] contentFile) {
            WinApp.Servicio.Soap.Documentos.sendSummary inValue = new WinApp.Servicio.Soap.Documentos.sendSummary();
            inValue.fileName = fileName;
            inValue.contentFile = contentFile;
            WinApp.Servicio.Soap.Documentos.sendSummaryResponse retVal = ((WinApp.Servicio.Soap.Documentos.BizlinksOSE)(this)).sendSummary(inValue);
            return retVal.ticket;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<WinApp.Servicio.Soap.Documentos.sendSummaryResponse> WinApp.Servicio.Soap.Documentos.BizlinksOSE.sendSummaryAsync(WinApp.Servicio.Soap.Documentos.sendSummary request) {
            return base.Channel.sendSummaryAsync(request);
        }
        
        public System.Threading.Tasks.Task<WinApp.Servicio.Soap.Documentos.sendSummaryResponse> sendSummaryAsync(string fileName, byte[] contentFile) {
            WinApp.Servicio.Soap.Documentos.sendSummary inValue = new WinApp.Servicio.Soap.Documentos.sendSummary();
            inValue.fileName = fileName;
            inValue.contentFile = contentFile;
            return ((WinApp.Servicio.Soap.Documentos.BizlinksOSE)(this)).sendSummaryAsync(inValue);
        }
    }
}
