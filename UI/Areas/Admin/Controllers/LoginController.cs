using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using DTO;

//namespace UI.Controllers
namespace UI.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        UserBLL userbLL = new UserBLL();
        // GET: Login
        public ActionResult Index()
        {
            UserDTO dto = new UserDTO();
            return View(dto);
        }
        [HttpPost]
        public ActionResult Index(UserDTO model)
        {
            if(model.Username != null && model.Password != null)
            {
                UserDTO user = userbLL.GetUserWithUsernameAndPassword(model);
                if(user.ID != 0)
                {
                    UserStatic.UserID = user.ID;
                    UserStatic.isAdmin = user.isAdmin;
                    UserStatic.Namesurname = user.Name;
                    UserStatic.Imagepath = user.Imagepath;

                    LogBLL.AddLog(General.ProcessType.Login, General.TableName.Login, 12);
                    return RedirectToAction("Index", "Post");
                }
                else
                    return View(model);
            }
            else
                return View(model);
            
        }
    }
}