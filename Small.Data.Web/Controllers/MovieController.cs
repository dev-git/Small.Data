using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Small.Data.Dat;
using Small.Data.Web.Models;

namespace Small.Data.Web.Controllers
{
    public class MovieController : Controller
    {
        //
        // GET: /Movie/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Movie/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Movie/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Movie/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Map this to the DAO
				Blt.Movie movie = new Blt.Movie();
				//movie.Title = collection.GetValue("title");
				movie.Title = Convert.ToString(collection["title"]);
				movie.Genre = Convert.ToString(collection["genre"]);
				movie.ReleaseDate = DateTime.Now;

				MovieDao movieDao = new MovieDao();
				movieDao.Insert(movie);

                return RedirectToAction("List");
            }
            catch
            {
                return View();
            }
        }

		//
		// GET: /Movie/Save

		public ActionResult Save()
		{
			return View();
		} 

		[HttpPost]
		public ActionResult Save(MovieViewModel movie)
		{
			try
			{
				MovieDao movieDao = new MovieDao();
				Blt.Movie mov = new Blt.Movie();

				mov.Title = movie.Title;
				mov.Genre = movie.Genre;
				mov.ReleaseDate = DateTime.Now;
				movieDao.Insert(mov);

				return RedirectToAction("List");
			}
			catch
			{
				return View();
			}
			//return new HttpStatusCodeResult(HttpStatusCode.OK);
		}

        //
        // GET: /Movie/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Movie/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Movie/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Movie/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

		//
		// GET: /Movie/List

		public ActionResult List()
		{
			// Todo: Put this in a mapper
			MovieDao movieDao = new MovieDao();
			IList<Blt.Movie> movieList = movieDao.GetMovies();

			IList<MovieViewModel> movieViewList = new List<MovieViewModel>();

			foreach (Blt.Movie movie in movieList)
			{
				MovieViewModel mov = new MovieViewModel();
				mov.Title = movie.Title;
				mov.Genre = movie.Genre;
				mov.ReleaseDate = movie.ReleaseDate;

				movieViewList.Add(mov);
			}

			return View(movieViewList);
			//return View();
		}
    }
}
