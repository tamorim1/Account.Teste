using Account.Data;
using Microsoft.EntityFrameworkCore;

namespace Account.WebAPI
{
    public class AccountMigrationDbContext : AccountDbContext
    {
        public AccountMigrationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected AccountMigrationDbContext()
        {
        }
    }
}
