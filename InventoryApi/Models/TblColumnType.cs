using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryApi.Models
{
    [Table("TblColumnType")]
    public partial class TblColumnType
    {
        public TblColumnType()
        {
            TblColumnValue = new HashSet<TblColumnValue>();
        }

        public int Id { get; set; }
        public string ColumnName { get; set; }

        public virtual ICollection<TblColumnValue> TblColumnValue { get; set; }
    }
}
