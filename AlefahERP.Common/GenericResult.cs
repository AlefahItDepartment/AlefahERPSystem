using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlefahERP.Common
{
    public class GenericResult<TEntity> where TEntity : class
    {
        public bool status { get; set; }
        public string? message { get; set; }
        public TEntity? data { get; set; }
        public int? totalRecords { get; set; }
    }
}
