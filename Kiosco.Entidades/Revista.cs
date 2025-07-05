using System.ComponentModel.DataAnnotations;

namespace Kiosco.Entidades
{
    public enum MarcaRevista
    {
        NationalGeographic,
        Time,
        Vogue,
        RollingStone,
        ScientificAmerican
    }
    public class Revista : Producto
    {
        public MarcaRevista Marca { get; set; }
        public string Edicion { get; set; } = "";
        public bool TienePoster { get; set; }

        public override decimal calcularPrecioFinal()
        {
            if (TienePoster)
            {
                return PrecioBase + 300;
            }
            else
            {
                return PrecioBase;
            }
        }

        public override string InformarDatosEspecifico()
        {
            return $" - Edición: {Edicion} - Tiene Poster: {(TienePoster ? "Sí" : "No")} - Marca de revista {Marca} ";
        }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            foreach (var error in ValidarAtributosComunes())
            {
                yield return error;
            }
        }
    }
}
