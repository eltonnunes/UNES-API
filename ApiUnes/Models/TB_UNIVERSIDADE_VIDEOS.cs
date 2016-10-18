namespace ApiUnes.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TB_UNIVERSIDADE_VIDEOS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TB_UNIVERSIDADE_VIDEOS()
        {
            TB_UNIVERSIDADE_ESTATISTICAS = new HashSet<TB_UNIVERSIDADE_ESTATISTICAS>();
        }

        [Key]
        public long UNV_ID_VIDEOS { get; set; }

        [StringLength(200)]
        public string UNV_TX_TITULO { get; set; }

        public string UNV_TX_DESCRICAO { get; set; }

        public int? UNV_NR_VIEW { get; set; }

        public int? UNV_NR_LIKE { get; set; }

        public DateTime? UNV_DT_DATA { get; set; }

        public long UNT_ID_TAG { get; set; }

        [StringLength(200)]
        public string UNV_TX_HASH { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TB_UNIVERSIDADE_ESTATISTICAS> TB_UNIVERSIDADE_ESTATISTICAS { get; set; }

        public virtual TB_UNIVERSIDADE_TAG TB_UNIVERSIDADE_TAG { get; set; }
    }
}
