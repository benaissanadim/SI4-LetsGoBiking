using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using GeoCoordinate = System.Device.Location.GeoCoordinate;

namespace ProxyCacheServer
{
    internal class JCDecauxProxyManager
    {
        public string apiKey = "197c22569da3c20597913b5cacffd1c9626b14d4";
        string query, url, response;

        public List<Contract> getAllContracts()
        {
            query = "apiKey=" + apiKey;
            url = "https://api.jcdecaux.com/vls/v3/contracts";
            //  string request = JCDecauxAPICall(url + "?" + query);
            GenericProxyCache<List<Contract>> genericProxyCache = new GenericProxyCache<List<Contract>>();
            List<Contract> allContracts = genericProxyCache.Get(url + "?" + query);
            return (allContracts);
        }
        public List<Station> getStations(string contract)
        {
            url = "https://api.jcdecaux.com/vls/v3/stations";
            query = "contract=" + contract + "&apiKey=" + apiKey;
            GenericProxyCache<List<Station>> genericProxyCache = new GenericProxyCache<List<Station>>();
            List<Station> allStations = genericProxyCache.Get(url + "?" + query);
            if (allStations == null) return null;
            if(allStations.Count > 120)
                return (allStations.GetRange(0, 120));
            return (allStations);
        }

 

    }

    [DataContract]
    public class Contract
    {
        [DataMember]
        public string name { get; set; }
    }

    [DataContract]
    public class Station
    {
        [DataMember]
        public int number { get; set; }

        [DataMember]
        public string contractName { get; set; }

        [DataMember]
        public string name { get; set; }
        [DataMember]
        public Position position { get; set; }
        [DataMember]
        public Stands totalStands { get; set; }


        public override bool Equals(object obj)
        {
            if (!(obj is Station station))
                return false;

            return number == station.number && contractName == station.contractName;
        }
    }

    [DataContract]
    public class Stands
    {
        [DataMember]
        public Availability availabilities { get; set; }
        [DataMember]
        public int capacity { get; set; }
    }

    [DataContract]
    public class Availability
    {
        [DataMember]
        public int bikes { get; set; }
        [DataMember]
        public int stands { get; set; }
        [DataMember]
        public int mechanicalBikes { get; set; }
        [DataMember]
        public int electricalBikes { get; set; }
    }

    [DataContract]
    public class Position
    {
        [DataMember]
        public double latitude { get; set; }
        [DataMember]
        public double longitude { get; set; }


        public GeoCoordinate ToGeoCoordinate()
        {
            return new GeoCoordinate(latitude, longitude);
        }
    }





}


