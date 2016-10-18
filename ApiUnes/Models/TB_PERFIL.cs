namespace ApiUnes.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TB_PERFIL
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TB_PERFIL()
        {
            TB_PERFIL_USUARIO = new HashSet<TB_PERFIL_USUARIO>();
            TB_USUARIO_ALIAS = new HashSet<TB_USUARIO_ALIAS>();
        }

        [Key]
        public int PER_ID_PERFIL { get; set; }

        [Required]
        [StringLength(50)]
        public string PER_TX_DESCRICAO { get; set; }

        public bool? PER_BL_STATUS { get; set; }

        public bool? PER_BL_GENERICO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TB_PERFIL_USUARIO> TB_PERFIL_USUARIO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TB_USUARIO_ALIAS> TB_USUARIO_ALIAS { get; set; }
    }
}
