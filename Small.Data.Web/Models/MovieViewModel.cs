using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;

namespace Small.Data.Web.Models
{
	public class MovieViewModel
	{
		[Display(Name = "Title")]
		public string Title { get; set; }

		[Display(Name = "Release Date")]
		[DataType(DataType.DateTime)]
		[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
		public DateTime ReleaseDate { get; set; }

		[Display(Name = "Genre")]
		public string Genre { get; set; }
	}
}