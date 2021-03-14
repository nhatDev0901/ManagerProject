namespace ModelEF.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FILES")]
    public partial class FILE
    {
        [Key]
        public int File_ID { get; set; }

        [StringLength(500)]
        public string File_Name { get; set; }

        [StringLength(500)]
        public string File_Path { get; set; }

        [StringLength(50)]
        public string Sub_Code { get; set; }

        public int? Sub_ID { get; set; }

        public virtual SUBMITTION SUBMITTION { get; set; }
    }
}
