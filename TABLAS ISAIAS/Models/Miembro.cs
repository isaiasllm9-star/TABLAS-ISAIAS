namespace FitLife.Models
{
    public class Miembro
    {
        public string cedula { get; set; } = string.Empty;
        public string nombre_completo { get; set; } = string.Empty;
        public string telefono { get; set; } = string.Empty;

        public override string ToString() => $"[{cedula}] {nombre_completo} - {telefono}";
    }
}
