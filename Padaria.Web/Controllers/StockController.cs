using Padaria.Repository.Entities;
using Padaria.Repository.Repository;
using System.Web.Mvc;

namespace Padaria.Web.Controllers
{
    [Authorize]
    public class StockController : Controller
    {
        private const bool Valid = true;
        private const int Success = 1;
        private StockRepository InstantiateStockRepository { get; } = new StockRepository();
        [HttpGet]
        public ActionResult List() => View(InstantiateStockRepository.GetAlls());
        [HttpGet]
        public ActionResult Add(int productID) => View(InstantiateStockRepository.GetByIDs(productID));
        [HttpPost]
        public ActionResult Add(Stock stock)
        {
            if (ModelState.IsValid == Valid)
            {
                switch (InstantiateStockRepository.AddStock(stock))
                {
                    case Success:
                        return RedirectToAction(nameof(this.List));
                    default:
                        return HttpNotFound();
                }
            }
            return View(stock);
        }
        [HttpGet]
        public ActionResult Remove(int productID) => View(InstantiateStockRepository.GetByIDs(productID));
        [HttpPost]
        public ActionResult Remove(Stock stock)
        {
            if (ModelState.IsValid == Valid)
            {
                switch (InstantiateStockRepository.RemoveStock(stock))
                {
                    case Success:
                        return RedirectToAction(nameof(this.List));
                    default:
                        return HttpNotFound();
                }
            }
            return View(stock);
        }
        [HttpGet]
        public ActionResult Edit(int productID) => View(InstantiateStockRepository.GetByIDs(productID));
        [HttpPost]
        public ActionResult Edit(Stock stock)
        {
            if (ModelState.IsValid == Valid)
            {
                switch (InstantiateStockRepository.Update(stock))
                {
                    case Success:
                        return RedirectToAction(nameof(this.List));
                    default:
                        return HttpNotFound();

                }
            }
            return View(stock);
        }

    }
}