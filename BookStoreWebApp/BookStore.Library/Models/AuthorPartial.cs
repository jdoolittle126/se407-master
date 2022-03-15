using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Library.Models
{
    [ModelMetadataType(typeof(AuthorMetaData))]
    public partial class Author
    {

    }

    public class AuthorMetaData
    {
        [Display(Name = "First Name")]
        public string AuthorFirst { get; set; }

        [Display(Name = "Last Name")]
        public string AuthorLast { get; set; }
    }

}
