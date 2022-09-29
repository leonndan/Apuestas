using Microsoft.AspNetCore.Mvc;
using FireSharp.Config;
using FireSharp.Interfaces;
using FinalFour.Models;
using FireSharp.Response;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FinalFour.Controllers
{
    public class ApuestaController : Controller
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "qwSpFATqsxDFSIY39QSqvmCIMdf2VyktLmI7rVH2",
            BasePath = "https://pickscontroller-default-rtdb.firebaseio.com"
        };
        IFirebaseClient client;
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Pick pick)
        {
            try
            {
                client = new FireSharp.FirebaseClient(config);
                var data = pick;
                PushResponse response = client.Push("Apuesta/", data);
                data.Id = response.Result.name;
                SetResponse setResponse = client.Set("Apuesta/" + data.Id,data);

                if (setResponse.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    ModelState.AddModelError(string.Empty, "Added Succesfully");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Something went wrong!!");
                }
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return View();
        }
        public IActionResult Consuta()
        {
            client = new FireSharp.FirebaseClient(config);
            FirebaseResponse response = client.Get("Apuesta");
            dynamic data = JsonConvert.DeserializeObject<dynamic>(response.Body);
            var list = new List<Pick>();
            if (data != null)
            {
                foreach (var item in data)
                {
                    list.Add(JsonConvert.DeserializeObject<Pick>(((JProperty)item).Value.ToString()));
                }
            }
            return View(list);
        }
    }
}
