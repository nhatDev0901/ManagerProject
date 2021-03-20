namespace ModelEF.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DEADLINE")]
    public partial class DEADLINE
    {
        [Key]
        public int DeadLine_ID { get; set; }

        public DateTime? DeadLine_Start { get; set; }

        public DateTime? DeadLine_End { get; set; }

        public DateTime? Created_Date { get; set; }
    }
}
