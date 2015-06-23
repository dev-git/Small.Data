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
	public class NoteViewModel
	{
		[Display(Name = "Name")]
		public string Name { get; set; }

		[Display(Name = "Detail")]
		public string Detail { get; set; }


		[Display(Name = "Category")]
		public string Category { get; set; }

		public int NoteID { get; set; }
	}
}