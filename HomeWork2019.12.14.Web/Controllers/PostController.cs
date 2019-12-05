using HomeWork2019._12._14.AbstractModels;
using HomeWork2019._12._14.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeWork2019._12._14.Web.Controllers
{
    public class PostController : Controller
    {
        public readonly IRepository<Post> _postRepository;
        public readonly IRepository<User> _userRepository;
        public PostController(IRepository<Post> postRepository, IRepository<User> userRepository)
        {
            _postRepository = postRepository;
            _userRepository = userRepository;
        }

        // GET: Post
        public ActionResult Create(int id)
        {
            ViewBag.Id = id;
            return View();
        }
        [HttpPost]
        public ActionResult Create(Post post, int UserId)
        {
            var user = _userRepository.GetAll().Where(u => u.Id == UserId).FirstOrDefault();
            post.User = user;
            _userRepository.Delete(user);
            _postRepository.Add(post);

            return RedirectToRoute("/User/Index", user);
        }
    }
}