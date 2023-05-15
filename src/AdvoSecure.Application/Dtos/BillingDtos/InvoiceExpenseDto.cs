namespace AdvoSecure.Application.Dtos.BillingDtos
{
    public class InvoiceExpenseDto
    {
        public Guid Id { get; set; }

        public Guid InvoiceId { get; set; }

        public InvoiceDto Invoice { get; set; }

        public Guid ExpenseId { get; set; }

        public ExpenseDto Expense { get; set; }

        public string Details { get; set; }
    }
}
