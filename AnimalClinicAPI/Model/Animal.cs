using System.ComponentModel.DataAnnotations;

namespace AnimalClinicAPI.Model;

public class Animal
{
    public int  Id { get; set; }
    [MaxLength(100)]
    public string Name { get; set; }
    [MaxLength(100)]
    public string Type { get; set; }
    public DateTime AdmissionDate { get; set; }
    public int ownerID  { get; set; }
}