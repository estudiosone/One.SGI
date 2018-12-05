using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Firebase.Database;
using System.Reactive.Linq;
using Firebase.Database.Query;


namespace One.SGI.Gateway.Printer
{
    class Service
    {
        public static Service Start(string URL)
        {
            return new Service(URL);
        }

        private Service(string URL)
        {
            var client = new FirebaseClient("https://one-sgh.firebaseio.com/");
            var subs = client
                .Child("gateway")
                .AsObservable<GatewayType>()
                .Where(f => !string.IsNullOrEmpty(f.Key))


        }
    }

    class GatewayType
    {
        public string Name { get; set; }
    }
}
