using System;
using System.Collections.Generic;
using System.Text;

namespace Find_All_Here.Models
{
    public class ListaProducts : Response
    {
        #pragma warning disable CS0108 // El miembro oculta el miembro heredado. Falta una contraseña nueva
        public List<ProductDetail> Data { get; set; }
        #pragma warning restore CS0108 // El miembro oculta el miembro heredado. Falta una contraseña nueva
    }
}
