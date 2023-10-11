using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace SpedIT.Models
{
	public class Department
	{
		[Key]
		public int Id { get; set; }

		public string Name { get; set; }

		[Required]
		public string Address { get; set; }

		public Department(string name, string address)
		{
			Name = name;
			Address = address;
		}

        public Department()
        {
			Id = 0;
			Name = string.Empty;
			Address = string.Empty;
        }
    }
}
