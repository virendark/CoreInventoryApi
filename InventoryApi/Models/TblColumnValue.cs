using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryApi.Models
{
    [Table("TblColumnValue")]
    public partial class TblColumnValue
    {
        public int Id { get; set; }
        public int? ColumnTypeId { get; set; }
        public string ColumnText { get; set; }

        public virtual TblColumnType ColumnType { get; set; }
    }
}
