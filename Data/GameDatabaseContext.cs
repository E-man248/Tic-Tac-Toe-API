using Microsoft.EntityFrameworkCore;
using TicTacToeAPI.Models;

namespace TicTacToeAPI.Data
{
    /** <summary>
        This class handles the mapping of the database mapping to
        the repository. In this way, it will be able to be refered
        by the repository to allow access to the database.
    </summary> **/
    public class GameDatabaseContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Filename=GameDatabase.db");
        }

        public DbSet<Game> Games { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Move> Moves { get; set; }
    }
}