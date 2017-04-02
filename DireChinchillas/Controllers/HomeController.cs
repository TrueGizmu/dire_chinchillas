using System.Linq;
using System.Net;
using System.Web.Mvc;
using DireChinchillas.Models;
using DireChinchillas.DbAccess;

namespace DireChinchillas.Controllers
{
    public class HomeController : Controller
    {
        private DbRepository _repository = new DbRepository(new ApplicationDbContext());

        // GET: Home
        public ActionResult Index()
        {
            var chinchillas = _repository.GetAllChinchillas();
            return View(chinchillas.ToList());
        }

        // GET: Home/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Chinchilla chinchilla = _repository.GetChinchillaById(id.Value);
            if (chinchilla == null)
            {
                return HttpNotFound();
            }
            return View(chinchilla);
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            ViewBag.ColourId = new SelectList(_repository.GetAllColours(), "ColourId", "Name");
            ViewBag.FatherId = new SelectList(_repository.GetChinchillaBySex(Enums.SexTypes.Male), "ChinchillaId", "Name");
            ViewBag.MotherId = new SelectList(_repository.GetChinchillaBySex(Enums.SexTypes.Female), "ChinchillaId", "Name");
            return View();
        }

        // POST: Home/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ChinchillaId,Name,Sex,Birthday,DeathDate,Description,ColourId,MotherId,FatherId")] Chinchilla chinchilla)
        {
            if (ModelState.IsValid)
            {
                _repository.AddChinchilla(chinchilla);
                _repository.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ColourId = new SelectList(_repository.GetAllColours(), "ColourId", "Name", chinchilla.ColourId);
            ViewBag.FatherId = new SelectList(_repository.GetChinchillaBySex(Enums.SexTypes.Male), "ChinchillaId", "Name", chinchilla.FatherId);
            ViewBag.MotherId = new SelectList(_repository.GetChinchillaBySex(Enums.SexTypes.Female), "ChinchillaId", "Name", chinchilla.MotherId);
            return View(chinchilla);
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Chinchilla chinchilla = _repository.GetChinchillaById(id.Value);
            if (chinchilla == null)
            {
                return HttpNotFound();
            }
            ViewBag.ColourId = new SelectList(_repository.GetAllColours(), "ColourId", "Name", chinchilla.ColourId);
            ViewBag.FatherId = new SelectList(_repository.GetChinchillaBySex(Enums.SexTypes.Male), "ChinchillaId", "Name", chinchilla.FatherId);
            ViewBag.MotherId = new SelectList(_repository.GetChinchillaBySex(Enums.SexTypes.Female), "ChinchillaId", "Name", chinchilla.MotherId);
            return View(chinchilla);
        }

        // POST: Home/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ChinchillaId,Name,Sex,Birthday,DeathDate,Description,ColourId,MotherId,FatherId")] Chinchilla chinchilla)
        {
            if (ModelState.IsValid)
            {
                _repository.Modify(chinchilla);
                _repository.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ColourId = new SelectList(_repository.GetAllColours(), "ColourId", "Name", chinchilla.ColourId);
            ViewBag.FatherId = new SelectList(_repository.GetChinchillaBySex(Enums.SexTypes.Male), "ChinchillaId", "Name", chinchilla.FatherId);
            ViewBag.MotherId = new SelectList(_repository.GetChinchillaBySex(Enums.SexTypes.Female), "ChinchillaId", "Name", chinchilla.MotherId);
            return View(chinchilla);
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Chinchilla chinchilla = _repository.GetChinchillaById(id.Value);
            if (chinchilla == null)
            {
                return HttpNotFound();
            }
            return View(chinchilla);
        }

        // POST: Home/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Chinchilla chinchilla = _repository.GetChinchillaById(id);
            _repository.RemoveChinchilla(chinchilla);
            _repository.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _repository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
