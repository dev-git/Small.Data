using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Small.Data.Blt
{
	public class Note
	{
		public Note()
		{
			// Can put interals here...
		}

		public Note(string detail)
			: this()
		{
			Detail = detail;
		}

		public int Id { get; set; }
		public string Name { get; set; }
		public string Detail { get; set; }
		public DateTime CreateDate { get; set; }
		public string Category { get; set; }
	}
}
