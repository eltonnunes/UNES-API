namespace ApiUnes.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TB_PERFIL_USUARIO
    {
        [Key]
        public int PEU_ID_PERFIL_USUARIO { get; set; }

        public int PER_ID_PERFIL { get; set; }

        [Required]
        [StringLength(20)]
        public string PEU_TX_USERNAME { get; set; }

        public virtual TB_PERFIL TB_PERFIL { get; set; }
    }
}
