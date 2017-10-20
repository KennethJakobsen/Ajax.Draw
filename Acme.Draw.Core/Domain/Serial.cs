using System;
using System.Collections.Generic;
using System.Text;
using LinqToDB.Mapping;

namespace Acme.Draw.Core.Domain
{
    [Table(Name = "Serials")]
    public class Serial
    {
        [Column("Serial")]
        public string SerialNumber { get; set; }
    }
}
