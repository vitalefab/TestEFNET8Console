using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Solr.Engine.Models;
using System.Collections.Generic;

namespace Solr.Engine.Data
{
    public class EngineDbContext : DbContext
    {

        private readonly IConfiguration _configuration;
        public EngineDbContext(IConfiguration configuration, DbContextOptions<EngineDbContext> options) : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<SolrSpeechModel> VoiceCommand { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetSection("ConnectionStrings")["SqlConnection"]);
        }
    }
}
