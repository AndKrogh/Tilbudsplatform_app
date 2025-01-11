using TilbudsPlatform.Model;

namespace TilbudsPlatform.Entities
{
    public class Invoice
    {
        required public int Id { get; set; }
        required public string InvoiceNumber { get; set; }
        required public DateTime IssueDate { get; set; }
        required public decimal TotalAmount { get; set; }
        required public bool IsPaid { get; set; }
        required public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
