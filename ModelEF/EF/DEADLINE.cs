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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DEADLINE()
        {
            SUBMITTIONS = new HashSet<SUBMITTION>();
        }

        [Key]
        public int DeadLine_ID { get; set; }

        public DateTime? DeadLine_Start { get; set; }

        public DateTime? DeadLine_End { get; set; }

        public DateTime? Created_Date { get; set; }

        [StringLength(200)]
        public string DeadLine_Content { get; set; } 

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SUBMITTION> SUBMITTIONS { get; set; }
    }
}
