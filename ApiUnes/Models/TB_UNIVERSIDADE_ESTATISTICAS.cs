namespace ApiUnes.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TB_UNIVERSIDADE_ESTATISTICAS
    {
        [Key]
        public long UNE_ID_ESTATISTICAS { get; set; }

        public long UNV_ID_VIDEOS { get; set; }

        public long USU_ID_USUARIO { get; set; }

        public DateTime UNE_DT_DATAVIEW { get; set; }

        public virtual TB_UNIVERSIDADE_VIDEOS TB_UNIVERSIDADE_VIDEOS { get; set; }

        public virtual TB_USUARIO TB_USUARIO { get; set; }
    }
}
