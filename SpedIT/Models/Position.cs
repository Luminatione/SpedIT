using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SpedIT.Models
{
	public class Position
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public string Name { get; set; }

		[DisplayName("Minimal Salary")]
		public decimal MinimalSalary { get; set; }

		public Position(string name, decimal minimalSalary)
		{
			Name = name;
			this.MinimalSalary = minimalSalary;
		}

		public Position() 
		{ 
			Id = 0;
			Name = string.Empty;
			MinimalSalary = 0;
		}
	}
}
