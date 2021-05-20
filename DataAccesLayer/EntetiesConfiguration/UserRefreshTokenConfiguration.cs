using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DataAccesLayer.Enteties;
 
namespace DataAccesLayer.EntetiesConfiguration
{
    public class UserRefreshTokenConfiguration : IEntityTypeConfiguration<UsersRefreshToken>
    {
        public void Configure(EntityTypeBuilder<UsersRefreshToken> builder)
        {
            builder.HasKey(k => k.UserId);
        }
    }
}
