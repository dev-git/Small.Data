using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Small.Data.Blt
{
    public class Movie
    {
		public Movie()
		{
			// Can put interals here...
		}

		public Movie(string title)
			: this()
		{
			Title = title;
		}

		public int Id { get; private set; }
		public string Title { get; set; }
		public DateTime ReleaseDate { get; set; }
		public string Genre { get; set; }
    }
}
