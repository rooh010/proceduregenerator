using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;

namespace ProcedureFrontend.Controllers
{
    public class ProcedureController : Controller
    {
        // GET: Procedure
        public ActionResult Index()
        {
            ViewData["Message"] = "List of Procedures.";


            var client = new RestClient(ProcedureLib.Variables.apiUrl);
            var request = new RestRequest("api/ProcedureModels/", Method.GET);
            var execute = client.Execute(request);
            string proc = execute.Content;

            var model = JsonConvert.DeserializeObject<List<ProcedureLib.Models.ProcedureModel>>(proc);

            return View(model);
        }


        // GET: Procedure/View/5
        public ActionResult View(int id)
        {


            return View();
        }






        

        // GET: Procedure/Create
        public ActionResult Create()
        {
            return View();
        }





        // POST: Procedure/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProcedureLib.Models.ProcedureModel collection)
        {
            try
            {

                if (ModelState.IsValid)
                {


                    ViewData["Version"] = collection.Version;
                    ViewData["ProcedureName"] = collection.ProcedureName;

                    string json = JsonConvert.SerializeObject(collection);

                    var client = new RestClient(ProcedureLib.Variables.apiUrl);
                    var request = new RestRequest("api/ProcedureModels/", Method.POST);
                    request.AddJsonBody(json);
                    var execute = client.Execute(request);


                    return RedirectToAction(nameof(Index));
                }

                else
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Procedure/Edit/5
        public ActionResult Edit(int id)
        {
            var client = new RestClient(ProcedureLib.Variables.apiUrl);
            var request = new RestRequest("api/ProcedureModels/" + id, Method.GET);
            var execute = client.Execute(request);
            string proc = execute.Content;

            var model = JsonConvert.DeserializeObject<ProcedureLib.Models.ProcedureModel>(proc);

            return View(model);

        }


        // POST: Procedure/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProcedureLib.Models.ProcedureModel collection)
        {
            try
            {

                if (ModelState.IsValid)
                {


                    ViewData["Version"] = collection.Version;
                    ViewData["ProcedureName"] = collection.ProcedureName;

                    string json = JsonConvert.SerializeObject(collection);

                    var client = new RestClient(ProcedureLib.Variables.apiUrl);
                    var request = new RestRequest("api/ProcedureModels/" + id, Method.PUT);
                    request.AddJsonBody(json);
                    var execute = client.Execute(request);


                    return RedirectToAction(nameof(Index));
                }

                else
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                return View();
            }
        }


        // GET: Procedure/Delete/5
        public ActionResult Delete(int id)
        {
            var client = new RestClient(ProcedureLib.Variables.apiUrl);
            var request = new RestRequest("api/ProcedureModels/" + id, Method.GET);
            var execute = client.Execute(request);
            string proc = execute.Content;

            var model = JsonConvert.DeserializeObject<ProcedureLib.Models.ProcedureModel>(proc);

            return View(model);
        }

        // POST: Procedure/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ProcedureLib.Models.ProcedureModel collection)
        {
            try
            {

                if (ModelState.IsValid)
                {


                    ViewData["Version"] = collection.Version;
                    ViewData["ProcedureName"] = collection.ProcedureName;

                    string json = JsonConvert.SerializeObject(collection);

                    var client = new RestClient(ProcedureLib.Variables.apiUrl);
                    var request = new RestRequest("api/ProcedureModels/" + id, Method.DELETE);
                    request.AddJsonBody(json);
                    var execute = client.Execute(request);


                    return RedirectToAction(nameof(Index));
                }

                else
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                return View();
            }
        }
    }
}