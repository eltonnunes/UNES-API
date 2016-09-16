namespace ApiUnes.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TB_PESSOA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TB_PESSOA()
        {
            TB_USUARIO = new HashSet<TB_USUARIO>();
        }

        [Key]
        public long PES_ID_PESSOA { get; set; }

        [StringLength(1)]
        public string PES_IN_PESSOA { get; set; }

        [Required]
        [StringLength(100)]
        public string PES_TX_NOME { get; set; }

        public DateTime PES_DT_CADASTRO { get; set; }

        public string PES_TX_OBSERVACAO { get; set; }

        [StringLength(100)]
        public string PES_TX_EMAIL { get; set; }

        [StringLength(100)]
        public string PES_TX_EMAIL_VERIFICAR { get; set; }

        public bool? PES_BL_EMAIL_VERIFICADO { get; set; }

        public long? PES_NR_CPF_CNPJ { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TB_USUARIO> TB_USUARIO { get; set; }
    }
}
