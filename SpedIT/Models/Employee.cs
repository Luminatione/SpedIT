using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using SpedIT_Domain.Models.Enums;
using System.ComponentModel;

namespace SpedIT.Models
{
    public class Employee
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[DisplayName("First Name")]
		public string FirstName { get; set; }

		[Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("Date of Birth")]
        public DateTime DateOfBirth { get; set; }

		[Required]
        [DisplayName("Date of Start Work")]
        public DateTime DateOfStartWork { get; set; }

		[ForeignKey(nameof(Department))]
        [DisplayName("Department")]
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }

		[Required]
		[Column(TypeName = "decimal(18, 2)")]
        public decimal Salary { get; set; }

		[Required]
		[ForeignKey(nameof(Position))]
        [DisplayName("Position")]
        public int PositionId { get; set; }
		public Position? Position { get; set; }

		public string PESEL {  get; set; }

		public string? Comment {  get; set; }

        [DisplayName("Emplyment Type")]
        public EmplymentType EmplymentType { get; set; }

        public Employee()
        {
			Id = 0;
			FirstName = string.Empty;
			LastName = string.Empty;
			DateOfBirth = DateTime.MinValue;
			DateOfStartWork = DateTime.MinValue;
			PESEL = string.Empty;
			Comment = string.Empty;
			EmplymentType = EmplymentType.None;
        }
    }
}
