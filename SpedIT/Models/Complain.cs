using SpedIT.Models;
using System.ComponentModel.DataAnnotations;

namespace SpedIT_Domain.Models
{
	public class Complain
	{
		[Key]
		public int Id { get; set; }

		public int ComplainantId { get; set; }
		public Employee Complainant { get; set; }

		public int ContestedId { get; set; }
		public Employee Contested {  get; set; }

		[Required]
		public string Content { get; set; }
	}
}
