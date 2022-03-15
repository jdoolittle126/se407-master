using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Library.Models
{
    [ModelMetadataType(typeof(BookMetaData))]
    public partial class Book
    {

    }

    public class BookMetaData
    {
        [Display(Name = "Title")]
        public string BookTitle { get; set; }

        [Display(Name = "Year of Release")]
        public short YearOfRelease { get; set; }
    }

}
