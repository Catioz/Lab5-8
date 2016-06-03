using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        NotepadModel notepadmodel = new NotepadModel();
        public ActionResult Index(string text)
        {
            var fail_1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data", "data.txt");
            System.IO.File.AppendAllText(fail_1, text + Environment.NewLine);

            return View();
        }

        public ActionResult About()
        {
            var fail_2 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data", "data.txt");
            ViewBag.myText = System.IO.File.ReadAllLines(fail_2);
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //==================================================================================
        public ActionResult Notepad()
        {
            ViewBag.Message = "Notepad";

            return View();
        }
        public void Create(Notep notepad)  
        {
            notepadmodel.Create(notepad.Name); 
        }
        public void Record(string Name, string Text)
        {
            notepadmodel.Record(Name, Text);
        }

        public string Load(string Name)
        {
            if (Name != "")
            {
                return notepadmodel.Load(Name);
            }
            return null;
        }
        public void Image(string Name)
        {
            if (Name != "")
            {
                notepadmodel.Image(Name);
            }
        }
        //=================================================================================
        public ActionResult NotepadName(string Name)
        {

            var fail = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data", Name);
            ViewBag.myText = System.IO.File.ReadAllLines(fail);
            @ViewBag.Message = Name;
            return View();         
        }
        //=================================================================================
        public class Notep
        {
            public string Name { get; set; }
        }
        public class NotepadBinder : IModelBinder
        {
            public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
            {
                var request = controllerContext.HttpContext.Request;
                if (request.Form["Name"] != null)
                {
                    return new Notep
                    {
                        Name = request.Form["Name"]
                    };
                }
                return null;
            }
        }

    }
}