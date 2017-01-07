
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using MongoDB.Driver;

namespace ProductsLearning.Data
{
    public partial class Repository<T> where T : IEntity
    {
        public string MyMan()
        {
            return "Heej";
        }
    }
}
