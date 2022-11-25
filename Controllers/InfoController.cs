using System.Data;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Tuskla.Models;
using Tuskla.Models.ViewModels;

namespace Tuskla.Controllers
{
    public class InfoController : Controller
    {
  
        public ViewResult DisplayInfo(string document)
        { 
            return View (document);
        }
    }
}


