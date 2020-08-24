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
    public class ProcedureStepController : Controller
    {
        // GET: ProcedureSteps
        public ActionResult Index()
        {
            ViewData["Message"] = "List of Procedures.";


            var client = new RestClient(ProcedureLib.Variables.apiUrl);
            var request = new RestRequest("api/ProcedureStepModels/", Method.GET);
            var execute = client.Execute(request);
            string proc = execute.Content;

            var model = JsonConvert.DeserializeObject<List<ProcedureLib.Models.ProcedureStepModel>>(proc);

            return View(model);
        }
        // GET: ProcedureSteps/Details/5
        public ActionResult View(int id)
        {
            return View();
        }

        // GET: ProcedureSteps/Create
        public ActionResult Create()
        {
            return View();
        }





        // POST: ProcedureSteps/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProcedureLib.Models.ProcedureStepModel collection)
        {
            try
            {

                if (ModelState.IsValid)
                {

                    ViewData["ProcedureId"] = collection.ProcedureId;
                    ViewData["StepNumber"] = collection.StepNumber;
                    ViewData["StepDescription"] = collection.StepDescription;
                    ViewData["StepType"] = collection.StepType;

                    string json = JsonConvert.SerializeObject(collection);

                    var client = new RestClient(ProcedureLib.Variables.apiUrl);
                    var request = new RestRequest("api/ProcedureStepModels/", Method.POST);
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

        // GET: ProcedureSteps/Edit/5
        public ActionResult Edit(int id)
        {
            var client = new RestClient(ProcedureLib.Variables.apiUrl);
            var request = new RestRequest("api/ProcedureStepModels/" + id, Method.GET);
            var execute = client.Execute(request);
            string proc = execute.Content;

            var model = JsonConvert.DeserializeObject<ProcedureLib.Models.ProcedureStepModel>(proc);

            return View(model);

        }


        // POST: ProcedureSteps/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProcedureLib.Models.ProcedureStepModel collection)
        {
            try
            {

                if (ModelState.IsValid)
                {


                    ViewData["ProcedureId"] = collection.ProcedureId;
                    ViewData["StepNumber"] = collection.StepNumber;
                    ViewData["StepDescription"] = collection.StepDescription;
                    ViewData["StepType"] = collection.StepType;

                    string json = JsonConvert.SerializeObject(collection);

                    var client = new RestClient(ProcedureLib.Variables.apiUrl);
                    var request = new RestRequest("api/ProcedureStepModels/" + id, Method.PUT);
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


        // GET: ProcedureSteps/Delete/5
        public ActionResult Delete(int id)
        {
            var client = new RestClient(ProcedureLib.Variables.apiUrl);
            var request = new RestRequest("api/ProcedureStepModels/" + id, Method.GET);
            var execute = client.Execute(request);
            string proc = execute.Content;

            var model = JsonConvert.DeserializeObject<ProcedureLib.Models.ProcedureStepModel>(proc);

            return View(model);
        }

        // POST: ProcedureSteps/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ProcedureLib.Models.ProcedureStepModel collection)
        {
            try
            {

                if (ModelState.IsValid)
                {


                    ViewData["ProcedureId"] = collection.ProcedureId;
                    ViewData["StepNumber"] = collection.StepNumber;
                    ViewData["StepDescription"] = collection.StepDescription;
                    ViewData["StepType"] = collection.StepType;

                    string json = JsonConvert.SerializeObject(collection);

                    var client = new RestClient(ProcedureLib.Variables.apiUrl);
                    var request = new RestRequest("api/ProcedureStepModels/" + id, Method.DELETE);
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