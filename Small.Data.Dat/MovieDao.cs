using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Small.Data.Blt;
using System.Data;

namespace Small.Data.Dat
{
	public class MovieDao
	{
		public int Insert(Movie movie)
		{
			/*"create table Movie (movie_pk integer primary key autoincrement, movie_date datetime, " +
					 " movie_title text, movie_desc text, movie_genre test, when_created datetime default (strftime('%Y-%m-%d %H:%M:%f', 'now')), " +
					 " is_deleted bool default (0), user_modified int default (0));";*/

			StringBuilder sql = new StringBuilder();
			sql.Append(" Insert into Movie (movie_date, movie_genre, movie_title) values (");
			sql.Append(" datetime('" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'), '");
			sql.Append( (String.IsNullOrEmpty(movie.Genre) ? String.Empty : movie.Genre.Replace("'", "\"")) + "', '");
			sql.Append(movie.Title.Replace("'", "\"") + "');");

			int newId = Db.Insert(sql.ToString(), true);

			return newId;
		}

		public IList<Movie> GetMovies()
		{
			StringBuilder sql = new StringBuilder();
			sql.Append(" Select movie_date, movie_title, movie_desc, movie_genre from Movie order by when_created desc;");

			DataTable dt = Db.GetDataTable(sql.ToString());

			return MakeMovieList(dt);
		}

		private IList<Movie> MakeMovieList(DataTable dt)
		{
			IList<Movie> list = new List<Movie>();
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(MakeMovie(dr));
			}

			return list;
		}

		private Movie MakeMovie(DataRow dr)
		{
			string movieTitle = dr["movie_title"].ToString();
			Movie mov = new Movie(movieTitle);
			mov.ReleaseDate = DateTime.Parse(dr["movie_date"].ToString());
			mov.Genre = dr["movie_genre"].ToString();

			return mov;
		}
	}
}
