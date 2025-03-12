using System.ComponentModel.DataAnnotations.Schema;

namespace Solr.Engine.Models
{
    [Table("lk_VoiceCommands")]
    public class SolrSpeechModel
    {
        public int id { get; set; }
        public string key { get; set; }
        public int group { get; set; }
    }
}
