using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Kiosco.Entidades
{
    public abstract class Producto : IValidatableObject
    {
        public string codigo { get; set; } = "";
        public string Nombre { get; set; } = "";
        public decimal PrecioBase { get; set; }
        public int Stock { get; set; }
        public DateTime fechaDeingreso { get; set; }
        public DateTime fechaDeVencimiento { get; set; }

        public virtual decimal calcularPrecioFinal()
        {
            return PrecioBase;
        }
        
        public string InformarDatos()
        {
            return $"Código: {codigo}, Nombre: {Nombre}, Precio Base: {PrecioBase:C}, Stock: {Stock}, Fecha de Ingreso: {fechaDeingreso.ToShortDateString()}, Fecha de Vencimiento: {fechaDeVencimiento.ToShortDateString()}";
        }

        public abstract string InformarDatosEspecifico();


        public abstract IEnumerable<ValidationResult> Validate(ValidationContext validationContext);

        protected IEnumerable<ValidationResult> ValidarAtributosComunes()
        {
            if (string.IsNullOrWhiteSpace(Nombre))
                yield return new ValidationResult("Nombre obligatorio");

            if (string.IsNullOrWhiteSpace(codigo) || codigo.Length != 5 ||
                    !Regex.IsMatch(codigo, @"^[A-Za-z0-9]{5}$"))
                yield return new ValidationResult("Código debe tener 5 caracteres alfanuméricos");

            if (PrecioBase <= 0)
                yield return new ValidationResult("Precio base debe ser mayor que 0");

            if (Stock < 0)
                yield return new ValidationResult("El stock no puede ser negativo");
            if (fechaDeingreso == default)
                yield return new ValidationResult("Fecha de ingreso es obligatoria");
            if (fechaDeVencimiento < DateTime.Now.Date || fechaDeVencimiento > DateTime.Now.AddDays(180).Date)
            {
                throw new ArgumentOutOfRangeException(nameof(fechaDeVencimiento), "La fecha de vencimiento debe estar entre hoy y 180 días a partir de hoy.");
            }
        }
    }
}
