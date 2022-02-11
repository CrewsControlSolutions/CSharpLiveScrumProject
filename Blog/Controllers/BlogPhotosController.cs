using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TheatreCMS3.Areas.Blog.Models;
using TheatreCMS3.Models;

namespace TheatreCMS3.Areas.Blog.Controllers
{
    public class BlogPhotosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Blog/BlogPhotos
        public ActionResult Index()
        {
            return View(db.BlogPhotoes.ToList());
        }

        // GET: Blog/BlogPhotos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogPhoto blogPhoto = db.BlogPhotoes.Find(id);
            if (blogPhoto == null)
            {
                return HttpNotFound();
            }
            return View(blogPhoto);
        }

        // GET: Blog/BlogPhotos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Blog/BlogPhotos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BlogPhotoId,Title,Photo")] BlogPhoto blogPhoto, HttpPostedFileBase PhotoFile)
        {
            if (ModelState.IsValid)
            {
                //only attempt to convert and store photo in database if user selected a photo 
                if (PhotoFile != null)
                {
                    var convertedPhoto = PhotoConvert(PhotoFile);
                    blogPhoto.Photo = convertedPhoto;
                }

                db.BlogPhotoes.Add(blogPhoto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(blogPhoto);
        }

        // GET: Blog/BlogPhotos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogPhoto blogPhoto = db.BlogPhotoes.Find(id);
            if (blogPhoto == null)
            {
                return HttpNotFound();
            }
            return View(blogPhoto);
        }

        // POST: Blog/BlogPhotos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BlogPhotoId,Title,Photo")] BlogPhoto blogPhoto, HttpPostedFileBase PhotoFile)
        {
            if (ModelState.IsValid)
            {
                if (PhotoFile != null)
                {
                    var convertedPhoto = PhotoConvert(PhotoFile);
                    blogPhoto.Photo = convertedPhoto;
                }

                db.Entry(blogPhoto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(blogPhoto);
        }

        // GET: Blog/BlogPhotos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogPhoto blogPhoto = db.BlogPhotoes.Find(id);
            if (blogPhoto == null)
            {
                return HttpNotFound();
            }
            return View(blogPhoto);
        }

        // POST: Blog/BlogPhotos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BlogPhoto blogPhoto = db.BlogPhotoes.Find(id);
            db.BlogPhotoes.Remove(blogPhoto);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        //create method for converting a photo to a byte array
        public byte[] PhotoConvert(HttpPostedFileBase photo)
        {
            byte[] bytes;
            using (BinaryReader br = new BinaryReader(photo.InputStream))
            {
                bytes = br.ReadBytes(photo.ContentLength);
            }

            return bytes;
        }

        //method for retrieving a photo stored as a byte array in the database
        [HttpGet]
        [AllowAnonymous]
        public ActionResult ViewImage(int id)
        {
            BlogPhoto blogPhoto = db.BlogPhotoes.Find(id);

            //check for if a photo exists for the passed id
            if (blogPhoto.Photo != null)
            {
                byte[] buffer = blogPhoto.Photo;
                return File(buffer, "image/jpg", string.Format("{0}.jpg", id));
            }

            //since no photo exists at this stage, simply return the view
            else
            {
                return View(blogPhoto);
            }
        }
    }
}
