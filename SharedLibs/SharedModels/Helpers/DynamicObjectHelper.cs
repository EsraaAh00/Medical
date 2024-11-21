using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SharedModels.Helpers
{
    public static class DynamicObjectHelper
    {
        public static void AddParameter(dynamic model, string propertyName, object value)
        {
            var expandoDict = model as IDictionary<string, object>;
            if (expandoDict != null)
            {
                expandoDict[propertyName] = value;
            }
        }
    }
}

