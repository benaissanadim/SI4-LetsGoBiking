﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RoutingServer.ServiceProxyCacheReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Contract", Namespace="http://schemas.datacontract.org/2004/07/ProxyCacheServer")]
    [System.SerializableAttribute()]
    public partial class Contract : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string nameField;
        
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
        public string name {
            get {
                return this.nameField;
            }
            set {
                if ((object.ReferenceEquals(this.nameField, value) != true)) {
                    this.nameField = value;
                    this.RaisePropertyChanged("name");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="Station", Namespace="http://schemas.datacontract.org/2004/07/ProxyCacheServer")]
    [System.SerializableAttribute()]
    public partial class Station : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string contractNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string nameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int numberField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private RoutingServer.ServiceProxyCacheReference.Position positionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private RoutingServer.ServiceProxyCacheReference.Stands totalStandsField;
        
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
        public string contractName {
            get {
                return this.contractNameField;
            }
            set {
                if ((object.ReferenceEquals(this.contractNameField, value) != true)) {
                    this.contractNameField = value;
                    this.RaisePropertyChanged("contractName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string name {
            get {
                return this.nameField;
            }
            set {
                if ((object.ReferenceEquals(this.nameField, value) != true)) {
                    this.nameField = value;
                    this.RaisePropertyChanged("name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int number {
            get {
                return this.numberField;
            }
            set {
                if ((this.numberField.Equals(value) != true)) {
                    this.numberField = value;
                    this.RaisePropertyChanged("number");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public RoutingServer.ServiceProxyCacheReference.Position position {
            get {
                return this.positionField;
            }
            set {
                if ((object.ReferenceEquals(this.positionField, value) != true)) {
                    this.positionField = value;
                    this.RaisePropertyChanged("position");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public RoutingServer.ServiceProxyCacheReference.Stands totalStands {
            get {
                return this.totalStandsField;
            }
            set {
                if ((object.ReferenceEquals(this.totalStandsField, value) != true)) {
                    this.totalStandsField = value;
                    this.RaisePropertyChanged("totalStands");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="Position", Namespace="http://schemas.datacontract.org/2004/07/ProxyCacheServer")]
    [System.SerializableAttribute()]
    public partial class Position : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double latitudeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double longitudeField;
        
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
        public double latitude {
            get {
                return this.latitudeField;
            }
            set {
                if ((this.latitudeField.Equals(value) != true)) {
                    this.latitudeField = value;
                    this.RaisePropertyChanged("latitude");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double longitude {
            get {
                return this.longitudeField;
            }
            set {
                if ((this.longitudeField.Equals(value) != true)) {
                    this.longitudeField = value;
                    this.RaisePropertyChanged("longitude");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="Stands", Namespace="http://schemas.datacontract.org/2004/07/ProxyCacheServer")]
    [System.SerializableAttribute()]
    public partial class Stands : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private RoutingServer.ServiceProxyCacheReference.Availability availabilitiesField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int capacityField;
        
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
        public RoutingServer.ServiceProxyCacheReference.Availability availabilities {
            get {
                return this.availabilitiesField;
            }
            set {
                if ((object.ReferenceEquals(this.availabilitiesField, value) != true)) {
                    this.availabilitiesField = value;
                    this.RaisePropertyChanged("availabilities");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int capacity {
            get {
                return this.capacityField;
            }
            set {
                if ((this.capacityField.Equals(value) != true)) {
                    this.capacityField = value;
                    this.RaisePropertyChanged("capacity");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="Availability", Namespace="http://schemas.datacontract.org/2004/07/ProxyCacheServer")]
    [System.SerializableAttribute()]
    public partial class Availability : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int bikesField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int electricalBikesField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int mechanicalBikesField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int standsField;
        
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
        public int bikes {
            get {
                return this.bikesField;
            }
            set {
                if ((this.bikesField.Equals(value) != true)) {
                    this.bikesField = value;
                    this.RaisePropertyChanged("bikes");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int electricalBikes {
            get {
                return this.electricalBikesField;
            }
            set {
                if ((this.electricalBikesField.Equals(value) != true)) {
                    this.electricalBikesField = value;
                    this.RaisePropertyChanged("electricalBikes");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int mechanicalBikes {
            get {
                return this.mechanicalBikesField;
            }
            set {
                if ((this.mechanicalBikesField.Equals(value) != true)) {
                    this.mechanicalBikesField = value;
                    this.RaisePropertyChanged("mechanicalBikes");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int stands {
            get {
                return this.standsField;
            }
            set {
                if ((this.standsField.Equals(value) != true)) {
                    this.standsField = value;
                    this.RaisePropertyChanged("stands");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceProxyCacheReference.IProxyCacheService")]
    public interface IProxyCacheService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProxyCacheService/getAllContracts", ReplyAction="http://tempuri.org/IProxyCacheService/getAllContractsResponse")]
        RoutingServer.ServiceProxyCacheReference.Contract[] getAllContracts();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProxyCacheService/getAllContracts", ReplyAction="http://tempuri.org/IProxyCacheService/getAllContractsResponse")]
        System.Threading.Tasks.Task<RoutingServer.ServiceProxyCacheReference.Contract[]> getAllContractsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProxyCacheService/getStations", ReplyAction="http://tempuri.org/IProxyCacheService/getStationsResponse")]
        RoutingServer.ServiceProxyCacheReference.Station[] getStations(string contract);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProxyCacheService/getStations", ReplyAction="http://tempuri.org/IProxyCacheService/getStationsResponse")]
        System.Threading.Tasks.Task<RoutingServer.ServiceProxyCacheReference.Station[]> getStationsAsync(string contract);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IProxyCacheServiceChannel : RoutingServer.ServiceProxyCacheReference.IProxyCacheService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ProxyCacheServiceClient : System.ServiceModel.ClientBase<RoutingServer.ServiceProxyCacheReference.IProxyCacheService>, RoutingServer.ServiceProxyCacheReference.IProxyCacheService {
        
        public ProxyCacheServiceClient() {
        }
        
        public ProxyCacheServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ProxyCacheServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ProxyCacheServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ProxyCacheServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public RoutingServer.ServiceProxyCacheReference.Contract[] getAllContracts() {
            return base.Channel.getAllContracts();
        }
        
        public System.Threading.Tasks.Task<RoutingServer.ServiceProxyCacheReference.Contract[]> getAllContractsAsync() {
            return base.Channel.getAllContractsAsync();
        }
        
        public RoutingServer.ServiceProxyCacheReference.Station[] getStations(string contract) {
            return base.Channel.getStations(contract);
        }
        
        public System.Threading.Tasks.Task<RoutingServer.ServiceProxyCacheReference.Station[]> getStationsAsync(string contract) {
            return base.Channel.getStationsAsync(contract);
        }
    }
}
