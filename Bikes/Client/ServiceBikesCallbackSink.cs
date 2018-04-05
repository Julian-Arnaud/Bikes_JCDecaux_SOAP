using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class ServiceBikesCallbackSink: BikesServiceReference.IServiceBikesCallback
    {
        public void GetedBikesed(string city, string station_name)
        {
            Console.WriteLine("Toto");
        }
    }
}
