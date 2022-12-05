
using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace RoutingServer
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IService1" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        Result GetItinary(string location, string destination);

        [OperationContract]
        bool updateSteps();
       
    }

    // Utilisez un contrat de données comme indiqué dans l'exemple ci-après pour ajouter les types composites aux opérations de service.
    // Vous pouvez ajouter des fichiers XSD au projet. Une fois le projet généré, vous pouvez utiliser directement les types de données qui y sont définis, avec l'espace de noms "NewBikeProject.ContractType".
    [DataContract]
    public class Result
    {
        [DataMember]
        public List<FeatureItinary> routes { get; set; }
        [DataMember]
        public string message { get; set; }

        public Result()
        {
            routes = new List<FeatureItinary>();
            this.message = "";
        }


        public Result(string message)
        {
            this.message = message;
        }

        public void AddRoute(FeatureItinary route)
        {
            routes.Add(route);
        }
    }

    [DataContract]
    public class Coordinate
    {
        [DataMember]
        public List<double> coordinates { get; }

        public Coordinate(List<double> values)
        {
            coordinates = values;
        }
    }

    [DataContract]
    public class Path
    {
        [DataMember]
        public Properties properties { get; set; }
        [DataMember]
        public GeometryItinary geometry { get; set; }

        public Path()
        {
            this.properties = null;
            this.geometry = null;

        }

        public Path(Properties properties, GeometryItinary geometryItinary)
        {
            this.properties = properties;
            this.geometry = geometryItinary;
        }
    }

    [DataContract]
    public class Properties
    {
        [DataMember]
        public string country { get; set; }
        [DataMember]
        public string locality { get; set; }
        [DataMember]
        public Summary summary { get; set; }
        [DataMember]
        public List<Segment> segments { get; set; }
    }

    [DataContract]
    public class Summary
    {
        [DataMember]
        public double distance { get; set; }
        [DataMember]
        public double duration { get; set; }
    }

    [DataContract]
    public class Segment
    {
        [DataMember]
        public List<Step> steps { get; set; }
    }

    [DataContract]
    public class Step
    {
        [DataMember]
        public double distance { get; set; }
        [DataMember]
        public double duration { get; set; }
        [DataMember]
        public string instruction { get; set; }
        [DataMember]
        public string name { get; set; }


    }

    [DataContract]
    public class Response
    {
        [DataMember]
        public List<Feature> features { get; set; }

        internal GeoCoordinate getGeoCoord()
        {
            double x = features[0].geometry.coordinates[1];
            double y = features[0].geometry.coordinates[0];
            return new GeoCoordinate(x, y);
        }

        internal string getCity()
        {
            return features[0].properties.locality;
        }
    }

    [DataContract]
    public class ResponseItinary
    {
        [DataMember]
        public List<FeatureItinary> features { get; set; }

    }

    [DataContract]
    public class GeometryItinary
    {
        [DataMember]
        public List<List<double>> coordinates { get; set; }
    }

    [DataContract]
    public class Geometry
    {
        [DataMember]
        public List<double> coordinates { get; set; }
    }

    [DataContract]
    public class Feature
    {
        [DataMember]
        public Geometry geometry { get; set; }
        [DataMember]
        public Properties properties { set; get; }
    }

    [DataContract]
    public class FeatureItinary
    {
        [DataMember]
        public GeometryItinary geometry { get; set; }
        [DataMember]
        public Properties properties { set; get; }
    }
}