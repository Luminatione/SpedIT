using SpedIT.Models;
using SpedIT_Domain.Models;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace SpedIT_Domain.Models
{
	public class Vehicle
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public string RegistrationNumber { get; set; }

		[Required]
		public string Model { get; set; }

		[Required]
		public bool IsActive { get; set; }

		public Department LastDepartment { get; set; }

		public Employee Driver {  get; set; }

		[Required]
		public Vector3 Dimensions { get; set; }

		public float Height { get; set; }

		[Required]
		public float MaxWeight { get; set; }

		ICollection<Package> Packages { get; set; }
	}
}