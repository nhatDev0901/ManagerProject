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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SUBMITTION()
        {
            COMMENTS = new HashSet<COMMENT>();
            FILES = new HashSet<FILE>();
        }

        [Key]
        public int Sub_ID { get; set; }

        [StringLength(50)]
        public string Sub_Code { get; set; }

        [StringLength(200)]
        public string Sub_Title { get; set; }

        public string Sub_Description { get; set; }

        public DateTime? Created_Date { get; set; }

        public int? Created_By { get; set; }

        public DateTime? Updated_Date { get; set; }

        public int? Updated_By { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<COMMENT> COMMENTS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FILE> FILES { get; set; }

        public virtual USER USER { get; set; }

        public virtual USER USER1 { get; set; }
    }
}
