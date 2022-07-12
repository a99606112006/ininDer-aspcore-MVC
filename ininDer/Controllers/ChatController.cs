using ininDer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Diagnostics;

namespace ininDer.Controllers
{
    public class ChatController : Controller
    {
        private readonly ininDerContext _context;

        public ChatController(ininDerContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddMessage(Message message)
        {
            int id = _context.Message.Count();


            if (id == 0)
            {
                message.Id = 0;
            }
            else
            {
                var lastid = _context.Message.OrderByDescending(d => d.Id).FirstOrDefault();
                message.Id = lastid.Id + 1;
            }
            _context.Message.Add(message);
            _context.SaveChanges();


            return StatusCode(201);
        }
        [HttpPost]
        public  ActionResult GetMessage(int id)
        {


            var messages =   _context.Message
            .Where(x => x.ChatroomId == id)
            .Select(x => new Message()
            {
                Id = x.Id,
                ChatroomId = x.ChatroomId,
                Content = x.Content,
                UserId = x.UserId


            })
         .ToList();

            return Json(messages);



        }

        [HttpPost]

        public ActionResult GetFriends(string id)
        {


            var friends = _context.Chatroom
            .Where(x => x.User_1 == id||x.User_2==id)
            .Select(x => new Chatroom()
            {
                Id = x.Id,
                User_1 = x.User_1,
                User_2 = x.User_2


            }).ToList();


            return Json(friends);



        }


    }
}
