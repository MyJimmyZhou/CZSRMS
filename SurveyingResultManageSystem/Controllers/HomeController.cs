﻿using SurveyingResultManageSystem.App_Start;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SurveyingResultManageSystem.Controllers
{
    public class HomeController : Controller
    {
        CZSRMS_DB db = new CZSRMS_DB();
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(tb_UserInfo user)
        {
            try
            {
                var users = from u in db.tb_UserInfo where u.UserName == user.UserName select u; 
                if (users.Count() == 0)
                    ModelState.AddModelError("UserName", "用户名不存在");
                else if (users.First().Password == user.Password)
                {
                    //把登陆用户名存到cookies中
                    HttpCookie cook = new HttpCookie("username", user.UserName);
                    cook.Expires = DateTime.Now.AddDays(1);//一天
                    Response.Cookies.Add(cook);
                    return RedirectToAction("FileManager", "Home");
                }
                else
                    ModelState.AddModelError("Password", "密码错误");

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View();

        }
        [Authentication]
        public ActionResult Logout()
        {
            HttpCookie cookie = new HttpCookie("username", string.Empty);
            cookie.Expires = DateTime.Now.AddMonths(-1);
            Response.Cookies.Add(cookie);
            return RedirectToAction("Login", "Home");
        }
        [Authentication]
        public ActionResult FileManager()
        {
            return View();
        }
        [Authentication]
        public ActionResult MapManager()
        {
            return View();
        }
    }
}