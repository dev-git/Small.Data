using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Small.Data.Dat;
using Small.Data.Web.Models;

namespace Small.Data.Web.Controllers
{
    public class NoteController : Controller
    {
        //
        // GET: /Note/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Note/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Note/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Note/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Note/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Note/Edit/5

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
        // GET: /Note/Delete/5
 
        public ActionResult Delete(int id)
        {
			NoteDao noteDao = new NoteDao();
			noteDao.Delete(id);

			return RedirectToAction("List");
        }

        //
        // POST: /Note/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
				NoteDao noteDao = new NoteDao();
				noteDao.Delete(id);
 
                return RedirectToAction("List");
            }
            catch
            {
                return null;
            }
        }

		//
		// GET: /Note/Save

		public ActionResult Save()
		{
			return View();
		} 

		[HttpPost]
		public ActionResult Save(NoteViewModel note)
		{
			try
			{
				if (!String.IsNullOrEmpty(note.Detail))
				{
					NoteDao noteDao = new NoteDao();
					Blt.Note myNote = new Blt.Note();

					myNote.Name = note.Name;
					myNote.Detail = note.Detail;
					myNote.Category = note.Category;

					noteDao.Insert(myNote);

				}
				return RedirectToAction("List");
			}
			catch
			{
				return View();
			}
		}

		public ActionResult List()
		{
			// Todo: Put this in a mapper
			NoteDao noteDao = new NoteDao();
			IList<Blt.Note> noteList = noteDao.GetNotes();

			IList<NoteViewModel> noteViewList = new List<NoteViewModel>();

			foreach (Blt.Note note in noteList)
			{
				NoteViewModel myNote = new NoteViewModel();
				myNote.NoteID = note.Id;
				myNote.Name = note.Name;
				myNote.Detail = note.Detail;
				myNote.Category = note.Category;

				noteViewList.Add(myNote);

			}

			return View(noteViewList);
			//return View();
		}
    }
}
