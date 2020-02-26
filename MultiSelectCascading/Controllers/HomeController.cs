using MultiSelectCascading.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MultiSelectCascading.Controllers
{
    public class HomeController : Controller
    {
        MVCTutorialEntities db = new MVCTutorialEntities();
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetCountryList(string searchTerm)
        {
            var CounrtyList = db.Countries.ToList();

            if (searchTerm != null)
            {
                CounrtyList = db.Countries.Where(x => x.CountryName.Contains(searchTerm)).ToList();
            }

            var modifiedData = CounrtyList.Select(x => new
            {
                id = x.CountryId,
                text = x.CountryName
            });
            return Json(modifiedData, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetStateList(string CountryIDs)
        {

            List<int> CountryIdList = new List<int>();

            CountryIdList = CountryIDs.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            List<State> StateList = new List<State>();
            foreach (int countryID in CountryIdList)
            {
                db.Configuration.ProxyCreationEnabled = false;
                var listDataByCountryID = db.States.Where(x => x.CountryId == countryID).ToList();
                foreach (var item in listDataByCountryID)
                {
                    StateList.Add(item);
                }
            }

            return Json(StateList, JsonRequestBehavior.AllowGet);

        }
    }
}