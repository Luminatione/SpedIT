using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using SpedIT_Domain.Models.Enums;

namespace SpedIT.Models
{
    public class Employee
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public string FirstName { get; set; }

		[Required]
		public string LastName { get; set; }

		public DateTime DateOfBirth { get; set; }

		[Required]
		public DateTime DateOfStartWork { get; set; }

		[ForeignKey(nameof(Department))]
		public int DepartmentId { get; set; }
		public Department Department { get; set; }

		[Column(TypeName = "decimal(18, 2)"), Required]
		public decimal Salary { get; set; }

		[ForeignKey(nameof(Position)), Required]
		public int PositionId { get; set; }
		public Position Position { get; set; }

		public string PESEL {  get; set; }

		public string Comment {  get; set; }

		public EmplymentType EmplymentType { get; set; }
	}
}
