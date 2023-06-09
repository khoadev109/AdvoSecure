﻿using AdvoSecure.Domain.Entities.Base;
using AdvoSecure.Domain.Entities.Billings;
using AdvoSecure.Domain.Entities.Tasks;

namespace AdvoSecure.Domain.Entities.Timing
{
    public class Time : BaseGuidEntity
    {
        public DateTime Start { get; set; }

        public DateTime? Stop { get; set; }

        public string Details { get; set; }

        public bool Billable { get; set; }

        public int WorkerContactId { get; set; }

        public Contacts.Contact WorkerContact { get; set; }

        public int? TimeCategoryId { get; set; }

        public TimeCategory TimeCategory { get; set; }

        public IList<InnerTask> Tasks { get; set; } = new List<InnerTask>();

        public IList<InvoiceTime> InvoiceTimes { get; set; } = new List<InvoiceTime>();
    }
}
