using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BlockbusterLibrary.Models;
using Microsoft.AspNetCore.Mvc;

#nullable disable

namespace BlockBusterLibrary.Models
{
    public partial class Transaction
    {
        public int TransactionId { get; set; }
        public int MovieId { get; set; }
        public int CustomerId { get; set; }

        public DateTime CheckedOutDate { get; set; }
        public DateTime DueDate { get; set; }
        public string CheckedIn { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Movie Movie { get; set; }
    }

 


}
