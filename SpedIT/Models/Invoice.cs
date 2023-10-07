using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SpedIT_Domain.Models
{
	public class Invoice
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public string InvoiceNumber { get; set; }

		[Required]
		public DateTime IssuedDate { get; set; }

		[Required]
		public DateTime DueDate { get; set; }

		[Required]
		public decimal TotalAmount { get; set; }

		[Required]
		public string NIP { get; set; }

		public Invoice(string invoiceNumber, DateTime issuedDate, DateTime dueDate, decimal totalAmount, string nIP)
		{
			InvoiceNumber = invoiceNumber;
			IssuedDate = issuedDate;
			DueDate = dueDate;
			TotalAmount = totalAmount;
			NIP = nIP;
		}
	}
}
