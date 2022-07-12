using ininDer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ininDer.Controllers
{
    public class PostController : Controller
    {
        private readonly ILogger<PostController> _logger;
        private readonly ininDerContext _context;

        public PostController(ILogger<PostController> logger, ininDerContext context)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult Index()
        {
            var data = _context.Profile.ToList();
            return View(data);
        }

        [HttpPost]
        public ActionResult GetPost()
        {


            var post = _context.Profile
            .Select(x => new Profile()
            {
                UserId = x.UserId,
                Q = x.Q,
                A1 = x.A1,
                A2 = x.A2,
                A3 = x.A3,
                Ca = x.Ca,
                ImageName = x.ImageName
            })
            .ToList();

            return Json(post);



        }
        [HttpPost]

        public ActionResult GetAnswer(string id)
        {
            

            var ans = _context.Profile
            .Where(x => x.UserId == id)
            .Select(x => new Profile()
            {
                Ca = x.Ca


            });
        

            return Json(ans);



        }

        [HttpPost]

        public ActionResult Match(Chatroom friend)
        {
            int id = _context.Chatroom.Count();


            if (id == 0)
            {
                friend.Id = 0;
            }
            else
            {
                var lastid = _context.Chatroom.OrderByDescending(d => d.Id).FirstOrDefault();
                friend.Id = lastid.Id + 1;
            }
            _context.Chatroom.Add(friend);
            _context.SaveChanges();


            return Ok();



        }




    }
}
