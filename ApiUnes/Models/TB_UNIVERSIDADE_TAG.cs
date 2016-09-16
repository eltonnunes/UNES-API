namespace ApiUnes.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TB_UNIVERSIDADE_TAG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TB_UNIVERSIDADE_TAG()
        {
            TB_UNIVERSIDADE_VIDEOS = new HashSet<TB_UNIVERSIDADE_VIDEOS>();
        }

        [Key]
        public long UNT_ID_TAG { get; set; }

        [Required]
        [StringLength(50)]
        public string UNT_TX_NOME { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TB_UNIVERSIDADE_VIDEOS> TB_UNIVERSIDADE_VIDEOS { get; set; }
    }
}
