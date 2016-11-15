// CS/INFO 1182
// Jon Holmes
// 2/1/2016
// Interface for Repeatable Items
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseObjects {
     /// <summary>
     /// Interface for a Object that needs to be copied
     /// </summary>
     /// <typeparam name="T"></typeparam>
     interface IRepeatable<T> {
         /// <summary>
         /// Create a copy of this object
         /// </summary>
         /// <returns>copy of the object</returns>
         T CreateCopy();
    }
}
