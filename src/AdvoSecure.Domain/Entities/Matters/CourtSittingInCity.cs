﻿using AdvoSecure.Domain.Entities.Base;

namespace AdvoSecure.Domain.Entities.Matters
{
    public class CourtSittingInCity : BaseEntity
    {
        public string Title { get; set; }

        public IList<Matter> Matters { get; set; } = new List<Matter>();
    }
}