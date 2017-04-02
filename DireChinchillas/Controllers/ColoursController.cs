using System.Data.Entity;
using System.Net;
using System.Web.Mvc;
using DireChinchillas.Models;
using DireChinchillas.DbAccess;

namespace DireChinchillas.Controllers
{
    public class ColoursController : Controller
    {
        private DbRepository _repository = new DbRepository(new ApplicationDbContext());

        // GET: Colours
        public ActionResult Index()
        {
            return View(_repository.GetAllColours());
        }

        // GET: Colours/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ColourMutation colourMutation = _repository.GetColourById(id.Value);
            if (colourMutation == null)
            {
                return HttpNotFound();
            }
            return View(colourMutation);
        }

        // GET: Colours/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Colours/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ColourId,Name,BeigeGene,WhiteGene,TovGene,EbonyGene,RecessiveGene")] ColourMutation colourMutation)
        {
            if (ModelState.IsValid)
            {
                _repository.AddColour(colourMutation);
                _repository.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(colourMutation);
        }

        // GET: Colours/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ColourMutation colourMutation = _repository.GetColourById(id.Value);
            if (colourMutation == null)
            {
                return HttpNotFound();
            }
            return View(colourMutation);
        }

        // POST: Colours/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ColourId,Name,BeigeGene,WhiteGene,TovGene,EbonyGene,RecessiveGene")] ColourMutation colourMutation)
        {
            if (ModelState.IsValid)
            {
                _repository.Modify(colourMutation);
                _repository.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(colourMutation);
        }

        // GET: Colours/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ColourMutation colourMutation = _repository.GetColourById(id.Value);
            if (colourMutation == null)
            {
                return HttpNotFound();
            }
            return View(colourMutation);
        }

        // POST: Colours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ColourMutation colourMutation = _repository.GetColourById(id);
            _repository.RemoveColour(colourMutation);
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
