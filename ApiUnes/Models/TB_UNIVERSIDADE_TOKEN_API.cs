namespace ApiUnes.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TB_UNIVERSIDADE_TOKEN_API
    {
        [Key]
        public long UTA_ID_TOKEN_API { get; set; }

        public long USU_ID_USUARIO { get; set; }

        public DateTime UTA_DT_VALIDADE { get; set; }

        public DateTime UTA_DT_GERACAO { get; set; }

        [Required]
        [StringLength(255)]
        public string UTA_TX_TOKEN { get; set; }

        public virtual TB_USUARIO TB_USUARIO { get; set; }
    }
}
