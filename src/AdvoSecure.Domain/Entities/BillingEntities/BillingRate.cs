﻿using AdvoSecure.Domain.Entities.Base;
using AdvoSecure.Domain.Entities.ContactEntities;

namespace AdvoSecure.Domain.Entities.BillingEntities
{
    public class BillingRate : BaseEntity
    {
        public string Title { get; set; }

        public decimal PricePerUnit { get; set; }

        public IList<Contact> Contacts { get; set; } = new List<Contact>();
    }
}
