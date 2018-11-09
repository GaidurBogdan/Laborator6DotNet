using System;
using System.ComponentModel.DataAnnotations;

namespace DataLayer
{
    public class POI
    {
        [Key]
        public Guid Id { get; private set; }

        [Required]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "invalid name")]
        public string Name { get; private set; }

        [Required]
        [StringLength(150)]
        public string Description { get; private set; }

        public POI(string description, string name)
        {
            Id = Guid.NewGuid();
            Description = description;
            Name = name;
        }

        public POI()
        {

        }

        public void SetName(String name)
        {
            Name = name;
        }

        public void SetDescription(String description)
        {
            Description = description;
        }
    }
}
