namespace ApiUnes.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TB_USUARIO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TB_USUARIO()
        {
            TB_UNIVERSIDADE_ESTATISTICAS = new HashSet<TB_UNIVERSIDADE_ESTATISTICAS>();
            TB_UNIVERSIDADE_TOKEN_API = new HashSet<TB_UNIVERSIDADE_TOKEN_API>();
            TB_USUARIO_ALIAS = new HashSet<TB_USUARIO_ALIAS>();
            TB_UNIVERSIDADE_PERFIL = new HashSet<TB_UNIVERSIDADE_PERFIL>();
        }

        [Key]
        public long USU_ID_USUARIO { get; set; }

        [StringLength(50)]
        public string USU_TX_USUARIO { get; set; }

        public bool USU_BL_ATIVO { get; set; }

        public DateTime USU_DT_CRIACAO { get; set; }

        public bool USU_BL_CARGA { get; set; }

        public long? USU_ID_PES_CARGA { get; set; }

        public long? PES_ID_PESSOA { get; set; }

        public bool USU_BL_CONFERIDO { get; set; }

        public bool USU_BL_SENHA_TEMPORARIA { get; set; }

        public int? COB_ID_CONTA_BANCARIA { get; set; }

        public DateTime? USU_DT_CONFERENCIA { get; set; }

        [StringLength(20)]
        public string USU_TX_CONFERENCIA { get; set; }

        public long? USU_ID_USUARIO_LOCK { get; set; }

        public bool? USU_BL_AVISO_PENDENCIA { get; set; }

        public DateTime? USU_DT_AVISO_PENDENCIA { get; set; }

        public bool? USU_BL_AVISO_CALLCENTER { get; set; }

        public bool? USU_BL_AVISO_CONFIRMADO { get; set; }

        public DateTime? USU_DT_AVISO_PRAZOLIMITE { get; set; }

        public bool? USU_BL_VISUALIZOU_AVISO_FRAUDE_BOLETO { get; set; }

        public DateTime? USU_DT_VALIDADE { get; set; }

        public virtual TB_PESSOA TB_PESSOA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TB_UNIVERSIDADE_ESTATISTICAS> TB_UNIVERSIDADE_ESTATISTICAS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TB_UNIVERSIDADE_TOKEN_API> TB_UNIVERSIDADE_TOKEN_API { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TB_USUARIO_ALIAS> TB_USUARIO_ALIAS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TB_UNIVERSIDADE_PERFIL> TB_UNIVERSIDADE_PERFIL { get; set; }
    }
}
