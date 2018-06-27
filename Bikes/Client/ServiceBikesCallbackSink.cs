using Client.BikesServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class ServiceBikesCallbackSink: BikesServiceReference.IServiceBikesCallback
    {
        public void GetedBikesed(string city, string station_name, string nb_bikes)
        {
            /*int i = 0;
            while(i < 1000000000)
            {
                if(i%5000000 == 0)Console.WriteLine("Ville: "+ city + ", nom de la station: "+station_name +", nb vélos dispos: "+ nb_bikes);
                ++i;
            }*/
            Console.WriteLine("Ville: " + city + ", nom de la station: " + station_name + ", nb vélos dispos: " + nb_bikes);
        }
    }
}
