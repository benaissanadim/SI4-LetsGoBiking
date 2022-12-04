﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Description;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ProxyCacheServer
{
    internal class Program
    {
        static void Main(String[] args)
        {

            Uri httpUrl = new Uri("http://localhost:8733/Design_Time_Addresses/ProxyCacheServer/Service1/");

            ServiceHost host = new ServiceHost(typeof(Service1), httpUrl);

            host.AddServiceEndpoint(typeof(IProxyCacheService), new BasicHttpBinding(), "");

            //Enable metadata exchange
            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            host.Description.Behaviors.Add(smb);

            //Start the Service
            host.Open();

            Console.WriteLine("Service is host at " + DateTime.Now.ToString());
            Console.WriteLine("Host is running... Press <Enter> key to stop");

            Service1 service1 = new Service1();
            service1.getStations("Marseille");

            Console.ReadLine();


        }
    }
}

