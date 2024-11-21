using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels.Models
{
    public class Pair<T, U>
    {


        public Pair(T first, U second)
        {
            this.First = first;
            this.Second = second;
        }
        public Pair<T, U> SetPair(T first, U second)
        {

            this.First = first;
            this.Second = second;
            return this;

        }

        public T First { get; set; }
        public U Second { get; set; }
    };
}
