namespace ModelEF.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("USERS")]
    public partial class USER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public USER()
        {
            COMMENTS = new HashSet<COMMENT>();
            SUBMITTIONS = new HashSet<SUBMITTION>();
            SUBMITTIONS1 = new HashSet<SUBMITTION>();
        }

        [Key]
        public int User_ID { get; set; }

        [StringLength(50)]
        public string Username { get; set; }

        [StringLength(50)]
        public string Password { get; set; }

        public int? Dep_ID { get; set; }

        public int? Role_ID { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<COMMENT> COMMENTS { get; set; }

        public virtual DEPARTMENT DEPARTMENT { get; set; }

        public virtual ROLE ROLE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SUBMITTION> SUBMITTIONS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SUBMITTION> SUBMITTIONS1 { get; set; }
    }
}
