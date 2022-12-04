using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CacheProxyServer
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" à la fois dans le code et le fichier de configuration.
    public class ProxyCacheService : IProxyCacheService
    {
        JCDecauxProxyManager jcdecauxTool = new JCDecauxProxyManager();

        public List<Contract> getAllContracts()
        {
            return (jcdecauxTool.getAllContracts());
        }

        public List<Station> getStations(string contract)
        {
            return (jcdecauxTool.getStations(contract));
        }
    }
}
