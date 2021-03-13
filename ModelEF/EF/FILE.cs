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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FILE()
        {
            SUBMITTIONS = new HashSet<SUBMITTION>();
        }

        [Key]
        public int File_ID { get; set; }

        [StringLength(500)]
        public string File_Name { get; set; }

        [StringLength(200)]
        public string File_Path { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SUBMITTION> SUBMITTIONS { get; set; }
    }
}
