﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Entities.Models
{
    public partial class SourceOfIncome
    {
        public SourceOfIncome()
        {
            Incomes = new HashSet<Income>();
        }

        public int Id { get; set; }
        public int CategoryIncome { get; set; }
        public string Detail { get; set; }

        public virtual CategoryIncome CategoryIncomeNavigation { get; set; }
        public virtual ICollection<Income> Incomes { get; set; }
    }
}
