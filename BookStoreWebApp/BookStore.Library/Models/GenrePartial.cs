using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Library.Models
{
    [ModelMetadataType(typeof(GenreMetaData))]
    public partial class Genre
    {

    }

    public class GenreMetaData
    {
        [Display(Name = "Genre Type")]
        public string GenreType { get; set; }

    }

}
