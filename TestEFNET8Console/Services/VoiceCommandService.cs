using Microsoft.EntityFrameworkCore;
using Solr.Engine.Data;
using Solr.Engine.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Solr.Engine.Services
{
    public class SolrVoiceCommandService
    {
        private readonly EngineDbContext _context;

        public SolrVoiceCommandService(EngineDbContext context)
        {
            _context = context;
        }

        public async Task<List<SolrSpeechModel>> GetVoiceCommandsAsync()
        {
            return await _context.VoiceCommand.ToListAsync();
        }
    }
}
