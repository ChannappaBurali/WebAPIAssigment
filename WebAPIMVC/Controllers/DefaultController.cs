using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebAPIMVC.Models;

namespace WebAPIMVC.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            IEnumerable<MVCModel> Weather;
            HttpResponseMessage httpres = GlobalClass.WebClient.GetAsync("Default").Result;
            Weather = httpres.Content.ReadAsAsync<IEnumerable<MVCModel>>().Result;
            return View(Weather);
        }

       public ActionResult AddorEdit(int id=0)
        {
            if (id == 0) 
            return View(new MVCModel());
            else
            {
                HttpResponseMessage res = GlobalClass.WebClient.GetAsync("tblWeathers/"+id.ToString()).Result;
                return View(res.Content.ReadAsAsync<MVCModel>().Result);
            }
        }
        [HttpPost]
        public ActionResult AddorEdit(MVCModel mv)
        {
            if (mv.Id == 0) { 
            HttpResponseMessage res = GlobalClass.WebClient.PostAsJsonAsync("tblWeathers", mv).Result;            
            }
            else
            {
                HttpResponseMessage res = GlobalClass.WebClient.PutAsJsonAsync("tblWeathers/"+mv.Id, mv).Result;
            }
            return RedirectToAction("Index");
        }
   
        public ActionResult Delete(int id)
        {
            HttpResponseMessage res = GlobalClass.WebClient.DeleteAsync("tblWeathers/"+id.ToString()).Result;
            return RedirectToAction("Index");
        }        
    }
}