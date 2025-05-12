using System.ComponentModel.DataAnnotations;

namespace AnimalClinicAPI.Model;

using System.ComponentModel.DataAnnotations;


public class Animal
{
    public int Id { get; set; }

    [MaxLength(100)]
    public string Name { get; set; } = null!;

    [MaxLength(100)]
    public string Type { get; set; } = null!;

    public DateTime AdmissionDate { get; set; }

    public int OwnerId { get; set; }
}
