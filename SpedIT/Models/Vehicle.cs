using SpedIT.Models;
using SpedIT_Domain.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace SpedIT_Domain.Models
{
    public class Vehicle
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Registration Number")]
        public string RegistrationNumber { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        [DisplayName("Is Active")]
        public bool IsActive { get; set; }

        [DisplayName("Last Department")]
        public Department? LastDepartment { get; set; }

        public Employee? Driver { get; set; }

        [Required]
        [DisplayName("X Dimensions")]
        public double XDimensions { get; set; }

        [Required]
        [DisplayName("Y Dimensions")]
        public double YDimensions { get; set; }

        [Required]
        [DisplayName("Z Dimensions")]
        public double ZDimensions { get; set; }

        public float Height { get; set; }

        [Required]
        [DisplayName("Max Weight")]
        public float MaxWeight { get; set; }

        [DisplayName("Selected Packages")]
        public virtual List<int> PackagesIds { get; set; }
        public virtual List<Package> Packages { get; set; }

        public Vehicle()
        {
            Id = 0;
            RegistrationNumber = string.Empty;
            Model = string.Empty;
            IsActive = false;
            Driver = null;
            XDimensions = 0;
            YDimensions = 0;
            ZDimensions = 0;
            Height = 0;
            MaxWeight = 0;
            Packages = new List<Package>();
            PackagesIds = new List<int>();
        }
    }
}