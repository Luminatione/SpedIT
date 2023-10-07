using SpedIT.Models;
using System.ComponentModel.DataAnnotations;

namespace SpedIT_Domain.Models
{
	public class Complain
	{
		[Key]
		public int Id { get; set; }

		public Employee Complainant { get; set; }

		public Employee Contested {  get; set; }

		[Required]
		public string content { get; set; }

		public Complain(Employee complainant, Employee contested, string content)
		{
			Complainant = complainant;
			Contested = contested;
			this.content = content;
		}
	}
}
