namespace ApiUnes.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TB_USUARIO_ALIAS
    {
        [Key]
        public long UAL_ID_USUARIO_ALIAS { get; set; }

        public long USU_ID_USUARIO { get; set; }

        [StringLength(50)]
        public string UAL_TX_ALIAS { get; set; }

        [Required]
        public string UAL_TX_SENHA { get; set; }

        public int? UAL_NR_DIAS { get; set; }

        [Column(TypeName = "date")]
        public DateTime? UAL_DT_SENHA { get; set; }

        public bool UAL_BL_MUDAR { get; set; }

        public bool UAL_BL_ATIVO { get; set; }

        public int? UAL_NR_TENTATIVAS { get; set; }

        [Column(TypeName = "date")]
        public DateTime? UAL_DT_TENTATIVAS { get; set; }

        public long? UPA_ID_PERFIL_ALIAS { get; set; }

        public int? PER_ID_PERFIL_GENERICO { get; set; }

        public bool? UAL_BL_GRATUIDADE { get; set; }

        public DateTime? UAL_DT_CRIACAO { get; set; }

        public virtual TB_USUARIO TB_USUARIO { get; set; }
    }
}
