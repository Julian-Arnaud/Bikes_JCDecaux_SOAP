using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

using Client.BikesServiceReference;

namespace Client
{
    class Program
    {
        
        static void Main(string[] args)
        {
            /////////
            //Cache//
            /////////

            /*Stores the result of GetCities() so it's called once and for all*/
            string[] citiesList = { "" };

            /*Stores map of <string, string[]> for every GetStationsCity(xxxxx) for the given xxxxx city*/

            Dictionary<string, string[]> citiesStations = new Dictionary<string, string[]>();

            //End cache
            ////////////

            ServiceBikesCallbackSink truc = new ServiceBikesCallbackSink();
            InstanceContext context = new InstanceContext(truc);

            ServiceBikesClient client = new ServiceBikesClient(context);
            client.SubscribeGetedBikesedEvent();

           // ServiceBikesClient iencli = new ServiceBikesClient();
            Console.WriteLine("The available commands are:\n" +
                "1 (GetCities) to retrieve the list of cities which use Velib\n" +
                "2 (GetStationsCity) to retrieve the list of the bikes stations of a given city\n" +
                "3 (GetBikesTown) to get the number of available bikes for a given station and city\n" +
                "4 (Help) to print these commands again\n" + 
                "5 (Exit) to quit the application.");

            bool done = false;
            while(!done)
            {
                Console.WriteLine("Please enter your choice: ");
                string s = Console.ReadLine();

                switch (s)
                {
                    case "1":
                        if(citiesList[0] == "")
                        {
                            Console.WriteLine("Retrieving list of cities from distant server...");
                            citiesList = client.GetCities();
                        }

                        for (int i = 1; i < citiesList.Length; ++i)
                        {
                            Console.WriteLine(citiesList[i]);
                        }
                        break;
                    case "2":
                        Console.WriteLine("Please type the desired town:");
                        s = Console.ReadLine();
                        if(!citiesList.Contains('"'+s+'"') || citiesList[0] == "")
                        {
                            Console.WriteLine("Please enter a valid city name or execute command 1 (GetCities)");
                        }
                        else
                        {
                            if(citiesStations.ContainsKey(s))
                            {
                                Console.WriteLine("I already know the stations for city " + s);
                                string[] tmp = citiesStations[s];
                                for (int i = 0; i < tmp.Length; ++i)
                                {
                                    Console.WriteLine(tmp[i]);
                                }
                            }
                            else
                            {
                                Console.WriteLine("Retrieving list of stations for city " + s+"...");
                                string[] res2 = client.GetStationsCity(s);
                                for (int i = 0; i < res2.Length; ++i)
                                {
                                    Console.WriteLine(res2[i]);
                                }
                                Console.WriteLine("Adding new information to dictionnary to grab info faster next time...");
                                citiesStations.Add(s, res2);
                            }
                        }                        
                        break;
                    case "3":
                        Console.WriteLine("Please type the desired town:");
                        s = Console.ReadLine();
                        Console.WriteLine("Enter the station number:");
                        string nb = Console.ReadLine();
                        if(!citiesList.Contains('"'+s+'"') || citiesList[0] == "")
                        {
                            Console.WriteLine("Please enter a valid city name or execute command 1 (GetCities)");
                        }
                        else
                        {
                            string res3 = client.GetBikesTown(s, nb);
                            if(res3 == "")
                            {
                                Console.WriteLine("Station not found, please try again");
                            }
                            else
                            {
                                Console.WriteLine("There is/are " + res3 + " available bike(s) at this station");
                            }
                        }
                        break;
                    case "4":
                        Console.WriteLine("The available commands are:\n" +
                "1 (GetCities) to retrieve the list of cities which use Velib\n" +
                "2 (GetStationsCity) to retrieve the list of the bikes stations of a given city\n" +
                "3 (GetBikesTown) to get the number of available bikes for a given station and city\n" +
                "4 (Help) to print these commands again\n" +
                "5 (Exit) to quit the application.");
                        break;
                    case "5":
                        done = true;
                        break;
                    default:
                        break;
                }
            }


            Console.WriteLine("Press any key to quit the application");

            Console.ReadLine();
        }
    }
}
