namespace ApiUnes.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TB_UNIVERSIDADE_PERFIL
    {
        [Key]
        public long UNP_ID_PERFIL { get; set; }

        [Required]
        [StringLength(50)]
        public string UNP_TX_NOME { get; set; }
    }
}
