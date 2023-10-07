using System.ComponentModel.DataAnnotations;

namespace SpedIT.Models
{
	public class Position
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public string Name { get; set; }

		public decimal minimalSalary { get; set; }

		public Position(string name, decimal minimalSalary)
		{
			Name = name;
			this.minimalSalary = minimalSalary;
		}
	}
}
