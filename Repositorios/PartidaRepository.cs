using GatoAPI.Modelos;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace GatoAPI.Repositorios
{
    public class PartidaRepository
    {
        private readonly AppDbContext _context;

        public PartidaRepository(AppDbContext context)
        {
            _context = context;
        }

        // Crear partida mediante procedimiento almacenado
        public async Task CrearPartidas(Partidas p)
        {
            var parameters = new[]
            {
                new SqlParameter("@JugadorActual", p.jugadorActual),
                new SqlParameter("@Estado", p.estado),
                new SqlParameter("@Usuario", (object?)p.usuario_creacion ?? DBNull.Value)
            };

            await _context.Database.ExecuteSqlRawAsync("EXEC sp_CrearPartida @JugadorActual, @Estado, @Usuario", parameters);
        }

        // Leer todas las partidas
        public async Task<List<Partidas>> LeerPartidas()
        {
            return await _context.Partidas.ToListAsync();
        }

        // Update / Actualizar partida
        public async Task Actualizar(Partidas p)
        {
            var parameters = new[]
            {
                new SqlParameter("@idPartida", p.idPartida),
                new SqlParameter("@jugadorActual", p.jugadorActual),
                new SqlParameter("@estado", p.estado),
                new SqlParameter("@usuario_modificacion", (object?)p.usuario_modificacion ?? DBNull.Value)
            };

            await _context.Database.ExecuteSqlRawAsync("EXEC sp_ActualizarPartida @idPartida, @jugadorActual, @estado, @usuario_modificacion", parameters);
        }

        // Delete / Eliminar partida
        public async Task Eliminar(int id)
        {
            var parametro = new SqlParameter("@idPartida", id);
            await _context.Database.ExecuteSqlRawAsync("EXEC SP_ELIMINAR_PARTIDA @idPartida", parametro);
        }
    }
}