using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.prov.by.Models
{
    public class DataRequest
    {
        public MimeTypes MimeType { get; set; }

        public string Data { get; set; }

        public DateTime ExpirationDate { get; set; }

        public bool IsFree { get; set; }
    }
}
