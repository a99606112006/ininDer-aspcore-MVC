using ininDer.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ininDer.Controllers
{
    public class ProfileController : Controller
    {
        private readonly ILogger<ProfileController> _logger;
        private readonly ininDerContext _context;
        private IHostingEnvironment Environment;

        public static string userId;

        public ProfileController(ILogger<ProfileController> logger, ininDerContext context, IHostingEnvironment _environment )
        {
            _logger = logger;
            _context = context;
            Environment = _environment;

        }

        public IActionResult Index(string id)
        {
            userId = id;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProfile(Profile profile)
        {



            var fileOriginName = Path.GetFileName(profile.File.FileName);


            var fileExt = Path.GetExtension(fileOriginName);


            var fileNewName = Path.GetRandomFileName();


            var filePath = Path.Combine(this.Environment.WebRootPath, "data/" + fileNewName + fileExt);


            await using (var stream = System.IO.File.Create(filePath))
            {

                await profile.File.CopyToAsync(stream);

            }

            var last = _context.Profile.Count();



            var save = new Profile()
            {
                Id = last + 1,
                ImageName = fileNewName + fileExt,
                Q = profile.Q,
                A1 = profile.A1,
                A2 = profile.A2,
                A3 = profile.A3,
                Ca = profile.Ca,
                UserId = userId

            };
            _context.Profile.Add(save);
            _context.SaveChanges();








            return RedirectToAction("Index", "Post");

        }
    }
}
