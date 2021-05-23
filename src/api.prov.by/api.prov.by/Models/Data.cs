using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.prov.by.Models
{
    public class Data
    {
        public Data(DataRequest  dataRequest)
        {            
            Id = Guid.NewGuid();
            Number = Id.GetHashCode().ToString("x");
            Pass = null;
            StringData = dataRequest.Data;
            if (!dataRequest.IsFree)
            {
                Pass = Extensions.GeneratePass(32);
                StringData = Extensions.EncryptString(Pass, dataRequest.Data);
            }            
            MimeType = dataRequest.MimeType;
            ExpirationDate = dataRequest.ExpirationDate;
            IsFree = dataRequest.IsFree;
        }        

        public Guid Id { get; set; }
                
        public string StringData { get; set; }

        public string Pass { get; set; }

        public MimeTypes MimeType { get; set; }

        public string Number { get; set; }

        public DateTime ExpirationDate { get; set; }

        public bool IsFree { get; set; }
    }
}
