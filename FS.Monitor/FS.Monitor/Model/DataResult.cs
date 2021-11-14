using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FS.Monitor.Model
{
   public static class DataResult
    {
        public delegate void PropertyChangedEventHandler(string e);
        public static event PropertyChangedEventHandler propertyChangedHandler;

        private static string dataMsg;
        public static string Property_dataMsg 
        {
            get 
            {
                return dataMsg;
            }
            set 
            {
                dataMsg = value;
                propertyChangedHandler(dataMsg);
            }
        }
    }
}
