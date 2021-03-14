namespace ModelEF.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("COMMENTS")]
    public partial class COMMENT
    {
        [Key]
        public int Com_ID { get; set; }

        public string Com_Name { get; set; }

        public int? User_ID { get; set; }

        public int? Sub_ID { get; set; }

        public virtual SUBMITTION SUBMITTION { get; set; }

        public virtual USER USER { get; set; }
    }
}
