using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryApi.Models
{
    [Table("TblLogin")]
    public partial class TblLogin
    {
        public TblLogin()
        {
            TblOutlet = new HashSet<TblOutlet>();
        }

        public int Id { get; set; }
        public int? PhoneNumber { get; set; }
        public DateTime? CreateOn { get; set; }
        public DateTime? ModifyOn { get; set; }
        public DateTime? ExpirDate { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public virtual ICollection<TblOutlet> TblOutlet { get; set; }
    }
}
