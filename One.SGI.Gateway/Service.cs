using Firebase.Database;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace One.SGI.Gateway
{
    public class Service
    {
        private static readonly LiteDatabase localDB = new LiteDatabase(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "One", "SGI", "Gateway", "data"));
        private static readonly LiteCollection<Model.Gateway> localDB_gateway_col = localDB.GetCollection<Model.Gateway>();

        private readonly FirebaseClient cliente;
        private readonly Model.Gateway current = localDB_gateway_col.FindAll().FirstOrDefault();


        private Service(string URL)
        {
            cliente = new FirebaseClient(URL);

            if (current == default(Model.Gateway))
            {
                localDB_gateway_col.Insert(new Model.Gateway());
                current = localDB_gateway_col.FindAll().FirstOrDefault();
            }
        }

        public static Service Start()
        {
            return new Service("https://one-sgh.firebaseio.com/");
        }

    }
}
