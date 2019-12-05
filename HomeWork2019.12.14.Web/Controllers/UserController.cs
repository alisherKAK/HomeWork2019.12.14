using HomeWork2019._12._14.AbstractModels;
using HomeWork2019._12._14.Models;
using HomeWork2019._12._14.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeWork2019._12._14.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Post> _postRepository;
        public UserController(IRepository<Post> postRepository, IRepository<User> userRepository)
        {
            _userRepository = userRepository;
            _postRepository = postRepository;
        }
        // GET: User
        public ActionResult Index(User user)
        {
            var posts = _postRepository.GetAll();

            if (posts == null) posts = new List<Post>();

            ViewBag.Id = user.Id;

            return View(posts);
        }

        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(User user)
        {
            user.Password = Hashing.HashPassword(user.Password);
            _userRepository.Add(user);

            return RedirectToAction("SignIn");
        }
        public ActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignIn(User user)
        {
            var repositoryUser = _userRepository.GetAll().Where(i => i.Login == user.Login).FirstOrDefault();
            if(repositoryUser != null && Hashing.ValidatePassword(user.Password, repositoryUser.Password))
            {
                return RedirectToAction("Index", repositoryUser);
            }

            return RedirectToAction("SignIn");
        }
    }
}