using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FacebookApp.Web.Models;
using FacebookApp.Common.Dtos;
using FacebookApp.Business.Services.Interfaces;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

namespace FacebookApp.Web.Controllers
{
	public class HomeController : Controller
	{
		private IUserServices _userServices;

		public HomeController(IUserServices userServices)
		{

			_userServices = userServices;

		}

		public IActionResult Index()
		{
			return View();
		}


		[HttpPost]
		public IActionResult PostNewEmployee(UserDto userDto)
		{
			//ViewBag
			//ViewData

			ViewBag.IsPost = true;

			if (ModelState.IsValid)
			{
				ViewBag.Result = true;
			}
			else
			{
				ViewBag.Result = false;
			}

			//ViewBag.Result = model != null ? true : false;
			//ViewData["Result"] = model != null;

			return View("Index");
		}

		[HttpPost]
		public IActionResult PostNewEmployeeForAjax(UserDto userDto)
		{
			
			
			_userServices.AddUsers(userDto);



			return Json(ModelState.IsValid);
		}

		public IActionResult PostLoginUserForAjax(UserDto userDto)
		{

			ViewBag.IsPost = true;

			var model = _userServices.LoginControl(userDto.Email, userDto.Password);

			if (model)
			{

				var loginUser = JsonConvert.SerializeObject(_userServices.GetByUserEmail(userDto.Email));
				HttpContext.Session.SetString("User", loginUser);
			
				ViewBag.Result = true;

			}
			else
			{
				ViewBag.Result = false;


			}

			return Json(model);
		}






		public IActionResult About()
		{
			ViewData["Message"] = "Your application description page.";

			return View();
		}

		public IActionResult Contact()
		{
			ViewData["Message"] = "Your contact page.";

			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
