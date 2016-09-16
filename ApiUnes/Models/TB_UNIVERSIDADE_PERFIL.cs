namespace ApiUnes.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TB_UNIVERSIDADE_PERFIL
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TB_UNIVERSIDADE_PERFIL()
        {
            TB_USUARIO = new HashSet<TB_USUARIO>();
            TB_UNIVERSIDADE_VIDEOS = new HashSet<TB_UNIVERSIDADE_VIDEOS>();
        }

        [Key]
        public long UNP_ID_PERFIL { get; set; }

        [Required]
        [StringLength(50)]
        public string UNP_TX_NOME { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TB_USUARIO> TB_USUARIO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TB_UNIVERSIDADE_VIDEOS> TB_UNIVERSIDADE_VIDEOS { get; set; }
    }
}
