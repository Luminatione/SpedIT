using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SpedIT_Domain.Models
{
	public class Invoice
	{
		[Key]
		public int Id { get; set; }

		[Required, DisplayName("Invoice Number")]
		public string InvoiceNumber { get; set; }

		[Required, DisplayName("Issued Date")]
		public DateTime IssuedDate { get; set; }

		[Required, DisplayName("Due Date")]
		public DateTime DueDate { get; set; }

		[Required, DisplayName("Total Amount")]
		public decimal TotalAmount { get; set; }

		[Required]
		public string NIP { get; set; }

		public Invoice(string invoiceNumber, DateTime issuedDate, DateTime dueDate, decimal totalAmount, string NIP)
		{
			InvoiceNumber = invoiceNumber;
			IssuedDate = issuedDate;
			DueDate = dueDate;
			TotalAmount = totalAmount;
			this.NIP = NIP;
		}

        public Invoice()
        {
			Id = 0;
            InvoiceNumber = string.Empty;
            IssuedDate = DateTime.MinValue;
            DueDate = DateTime.MinValue;
            TotalAmount = 0;
            NIP = string.Empty;
        }
    }
}
