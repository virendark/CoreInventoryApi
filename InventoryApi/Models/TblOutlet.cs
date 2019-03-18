using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryApi.Models
{
    [Table("TblOutlet")]
    public partial class TblOutlet
    {
        public int Id { get; set; }
        public int? LoginId { get; set; }
        public string OutletName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string CityName { get; set; }
        public string DisticName { get; set; }
        public string StateName { get; set; }
        public string CountryName { get; set; }

        public virtual TblLogin Login { get; set; }
    }
}
