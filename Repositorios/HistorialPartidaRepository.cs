using GatoAPI.Modelos;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace GatoAPI.Repositorios
{
    public class HistorialPartidaRepository
    {
        private readonly AppDbContext _context;

        public HistorialPartidaRepository(AppDbContext context)
        {
            _context = context;
        }

        // Crear registro en el historial mediante procedimiento almacenado
        public async Task CrearHistorial(HistorialPartidas h)
        {
            var parameters = new[]
            {
                new SqlParameter("@idPartida", h.idPartida),
                new SqlParameter("@posicion", (object?)h.posicion ?? DBNull.Value),
                new SqlParameter("@Usuario", (object?)h.usuario_creacion ?? DBNull.Value)
            };

            await _context.Database.ExecuteSqlRawAsync("EXEC sp_CrearHistorialPartida @idPartida, @posicion, @Usuario", parameters);
        }

        // Leer todo el historial de partidas
        public async Task<List<HistorialPartidas>> LeerHistorial()
        {
            return await _context.HistorialPartidas.ToListAsync();
        }
    }
}