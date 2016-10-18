using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiUnes.Models.Object
{
    public class VIDEOS_PERFIL
    {
        public ICollection<TB_UNIVERSIDADE_VIDEOS_PERFIL> VIDEOSPERFIL { get; set; }
        public TB_UNIVERSIDADE_VIDEOS VIDEOS { get; set; }
    }
}