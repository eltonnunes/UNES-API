using System;
using System.Collections.Generic;

namespace ApiUnes.Models.Object
{
    public class Estatisticas
    {
        private Int64 idvideo;
        public Int64 Idvideo
        {
            get { return idvideo; }
            set { idvideo = value; }
        }

        private Int64 idusuario;
        public Int64 Idusuario
        {
            get { return idusuario; }
            set { idusuario = value; }
        }
    }
}