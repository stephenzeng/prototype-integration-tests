using System.ComponentModel.DataAnnotations;

namespace MyProjects.Prototypes.IntegrationTests.Domain
{
    public class Store
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}