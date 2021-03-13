namespace ModelEF.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SUBMITTIONS")]
    public partial class SUBMITTION
    {
        [Key]
        public int Sub_ID { get; set; }

        [StringLength(200)]
        public string Sub_Title { get; set; }

        public string Sub_Description { get; set; }

        public DateTime? Created_Date { get; set; }

        public int? Created_By { get; set; }

        public DateTime? Update_Date { get; set; }

        public int? Update_By { get; set; }

        public int? File_ID { get; set; }

        public int? Com_ID { get; set; }

        public virtual COMMENT COMMENT { get; set; }

        public virtual FILE FILE { get; set; }

        public virtual USER USER { get; set; }

        public virtual USER USER1 { get; set; }
    }
}
