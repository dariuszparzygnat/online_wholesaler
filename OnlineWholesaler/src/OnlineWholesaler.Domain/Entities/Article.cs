using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineWholesaler.Domain.Entities
{
    public class Article
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
