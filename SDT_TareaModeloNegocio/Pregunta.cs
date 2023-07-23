using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDT_TareaModeloNegocio
{
    internal class Preguntas
    {
        public string Pregunta { get; set; } = string.Empty;
        public string Respuesta { get; set; } = string.Empty;
        public TipoPregunta Tipo { get; set; }
    }
    public enum TipoPregunta
    {
        Cualitativa,
        Cuantitativa
    }
}
