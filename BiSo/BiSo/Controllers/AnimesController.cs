using BiSo.Models;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace BiSo.Controllers
{
    [Authorize]
    public class AnimesController : Controller
    {
        private Bi_Ro_DashboardEntities1 db = new Bi_Ro_DashboardEntities1();

        // GET: Animes
        public ActionResult Index()
        {
            var login = User.Identity.GetUserId();
            var animes = db.Animes.Include(a => a.AspNetUser).Where(a=>a.UserId==login);
            return View(animes.ToList());
        }

        // GET: Animes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Anime anime = db.Animes.Find(id);
            if (anime == null)
            {
                return HttpNotFound();
            }
            return View(anime);
        }

        // GET: Animes/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email");
            return View();
        }

        // POST: Animes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nmae,Episode,Rating,UserId,isWatch,AnimeImg")] Anime anime, HttpPostedFileBase AnimeImg)
        {
            if (ModelState.IsValid)
            {
                string folderPath = Server.MapPath("~/Content/Images");
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                string fileName = Path.GetFileName(AnimeImg.FileName);
                string path = Path.Combine(folderPath, fileName);
                AnimeImg.SaveAs(path);
                anime.AnimeImg = "../Content/Images/" + fileName;
              
            db.Animes.Add(anime);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email", anime.UserId);
            return View(anime);
        }

        // GET: Animes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Anime anime = db.Animes.Find(id);
            if (anime == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email", anime.UserId);
            return View(anime);
        }

        // POST: Animes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nmae,Episode,Rating,UserId,isWatch,AnimeImg")] Anime anime, HttpPostedFileBase AnimeImg)
        {
            if (ModelState.IsValid)
            {
                string folderPath = Server.MapPath("~/Content/Images");
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                string fileName = Path.GetFileName(AnimeImg.FileName);
                string path = Path.Combine(folderPath, fileName);
                AnimeImg.SaveAs(path);
                anime.AnimeImg = "../Content/Images/" + fileName;
                db.Entry(anime).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email", anime.UserId);
            return View(anime);
        }

        // GET: Animes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Anime anime = db.Animes.Find(id);
            if (anime == null)
            {
                return HttpNotFound();
            }
            return View(anime);
        }

        // POST: Animes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Anime anime = db.Animes.Find(id);
            db.Animes.Remove(anime);
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
    }
}
