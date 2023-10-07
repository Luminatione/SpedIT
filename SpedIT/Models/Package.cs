using System.ComponentModel.DataAnnotations;
using SpedIT_Domain.Models.Enums;

namespace SpedIT_Domain.Models
{
    public class Package
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public PackageState State { get; set; }

		[Required]
		public string Address { get; set; }

		public string Comment { get; set; }

		[Required]
		public DateTime SendingTime { get; set; }

		public DateOnly PlannedDeliveryTime { get; set; }

		public Package(PackageState state, string address, string comment, DateTime sendingTime, DateOnly plannedDeliveryTime)
		{
			State = state;
			Address = address;
			Comment = comment;
			SendingTime = sendingTime;
			PlannedDeliveryTime = plannedDeliveryTime;
		}
	}
}
