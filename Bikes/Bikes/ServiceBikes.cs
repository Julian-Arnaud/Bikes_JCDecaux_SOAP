using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Bikes
{
    public class ServiceBikes : IServiceBikes
    {
        static Action<string, string, string> event1 = delegate { };

        public void SubscribeGetedBikesedEvent(String city, String station)
        {
            IServiceBikesEvents subscriber = OperationContext.Current.GetCallbackChannel<IServiceBikesEvents>();
            event1 += subscriber.GetedBikesed;
        }

        public String GetBikesTown(String city, String station_service)
        {
            WebRequest request = WebRequest.Create(
 "https://api.jcdecaux.com/vls/v1/stations?contract="+city+"&apiKey=8080b495679f1f648ee8eecb87396275e53d370c");

            WebResponse response = request.GetResponse();
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();

            Console.WriteLine(responseFromServer);

            string[] tab = responseFromServer.Split('{');
            string[] tab1 = { "" };
            string[] tab2 = { "" };
            string res = "";
            for (int i = 0; i < tab.Length; ++i)
            {
                if (i % 2 == 1 && tab[i].Contains(station_service))
                {
                    tab1 = tab[i + 1].Split(',');
                    tab2 = tab1[tab1.Length - 3].Split(':');
                    Console.WriteLine(tab2[tab2.Length - 1]);
                    res = tab2[tab2.Length - 1];
                }

            }
            event1(city, station_service, res);
            return res;
        }

        public List<string> GetCities()
        {
            WebRequest request = WebRequest.Create(
 "https://api.jcdecaux.com/vls/v1/contracts?apiKey=8080b495679f1f648ee8eecb87396275e53d370c");

            WebResponse response = request.GetResponse();
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();

            string[] tab = responseFromServer.Split('{');
            string[] tab1 = { "" };
            string[] tab2 = { "" };
            List<string> resList = new List<string>();
            for (int i = 0; i < tab.Length; ++i)
            {
                tab1 = tab[i].Split(',');
                tab2 = tab1[0].Split(':');
                Console.WriteLine(tab2[tab2.Length - 1]);
                resList.Add(tab2[tab2.Length - 1]);
            }

            return resList;
        }

        public List<string> GetStationsCity(string city)
        {
            WebRequest request = WebRequest.Create(
 "https://api.jcdecaux.com/vls/v1/stations?contract="+city+"&apiKey=8080b495679f1f648ee8eecb87396275e53d370c");

            WebResponse response = request.GetResponse();
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();

            Console.WriteLine(responseFromServer);

            string[] tab = responseFromServer.Split('{');
            string[] tab1 = { "" };
            string[] tab2 = { "" };
            List<string> resList = new List<string>();
            for (int i = 0; i < tab.Length; ++i)
            {
                if (i % 2 == 1)
                {
                    tab1 = tab[i].Split(',');
                    tab2 = tab1[1].Split(':');
                    Console.WriteLine(tab2[tab2.Length - 1]);
                    resList.Add(tab2[tab2.Length - 1]);
                }

            }
            return resList;
        }
    }
}
