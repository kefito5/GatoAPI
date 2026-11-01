namespace GatoAPI.Modelos
{
    public class HistorialPartidas
    {
        public int idHistorial { get; set; }
        public int idPartida { get; set; }
        public int? posicion { get; set; }
        public DateTime? fecha_movimiento { get; set; }
        public DateTime fecha_creacion { get; set; } = DateTime.Now;
        public string? usuario_creacion { get; set; }
        public DateTime? fecha_modificacion { get; set; }
        public string? usuario_modificacion { get; set; }
    }
}