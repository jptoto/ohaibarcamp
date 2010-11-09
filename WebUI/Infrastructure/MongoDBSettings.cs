using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebUI.Infrastructure {
    
    public class MongoDBSettings {

        public string Server { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Database { get; set; }
        public string Query { get; set; }

        public string ConnectionString {

            get {

                string authentication = string.Empty;
                if (! string.IsNullOrEmpty(Username)) {
                    authentication = string.Concat(Username, ':', Password, '@');
                }
                if (!string.IsNullOrEmpty(Query) && !Query.StartsWith("?")) {
                    Query = string.Concat('?', Query);
                }

                return string.Format("mongodb://{0}{1}:{2}/{3}{4}", authentication, Server, Port, Database, Query);

            }
        }
    }
}
