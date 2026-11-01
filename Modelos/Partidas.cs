namespace GatoAPI.Modelos
{
    public class Partidas
    {
        public int idPartida { get; set; }
        public char jugadorActual { get; set; }
        public char estado { get; set; }
        public char? ganador { get; set; }
        public DateTime? fecha_finalizacion { get; set; }
        public DateTime fecha_creacion { get; set; } = DateTime.Now;
        public string? usuario_creacion { get; set; }
        public DateTime? fecha_modificacion { get; set; }
        public string? usuario_modificacion { get; set; }
    }
}