using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using CST.Localization;
using CST.Security;
using CST.Security.Data;

namespace CST.Security
{
    public class SecurityController : Controller
    {

        /// <summary>
        /// Inject this !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        /// </summary>
        private SecurityEntities _securityDbContext = null;

        public SecurityController(SecurityEntities securityDbContext)
        {
            _securityDbContext = securityDbContext;
        }

        protected SecurityEntities SecurityDBContext
        {
            get
            {
                return _securityDbContext;
            }
        }
        
        // User login
        protected bool ValidateUserPassword(string login, string password)
        {
            return Membership.ValidateUser(login, password);
        }

        protected User GetUserByLogin(string login)
        {
            login = login.Trim();
            return (from u in SecurityDBContext.Users
                    where u.Login == login
                    select u).FirstOrDefault();
        }

        protected bool AuthorizeUser(string login, bool remember)
        {
            User user = GetUserByLogin(login);
            if (user != null)
            {
                AuthorizeUser(user, remember);
                return true;
            }
            return false;
        }

        protected void AuthorizeUser(User user, bool remember)
        {
            FormsAuthentication.SetAuthCookie(user.GetLoginUpper(), remember);
        }

        // user settings
        // ? service 

        protected string UserSettingsKey { get { return User.Identity.Name + "_SettingsIdx"; } }

        protected void ClearUserSettings()
        {
            Session.Remove(UserSettingsKey);
        }

        //
        // Routing
        protected ActionResult RedirectReturn(string url, string defaultAction="Index", string defualtController="Home")
        {
            if ((url != null)
                && (url.Length > 1)
                && url.StartsWith("/")
                && !url.StartsWith("//")
                && !url.StartsWith("/\\"))
            {
                return RedirectIfLocal(url, () => RedirectToAction(defaultAction, defualtController));
            }
            else
            {
                return RedirectToAction(defaultAction, defualtController);
            }
        }
        protected ActionResult RedirectIfLocal(string url, Func<ActionResult> redirFunc)
        {
            if (this.IsLocalUrl(url))
            {
                return Redirect(url);
            }
            else if (redirFunc != null)
            {
                return redirFunc();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // Action helper methods

        protected ActionResult GetLogOnAction(string redirectAction)
        {
            if (User.Identity != null && User.Identity.IsAuthenticated)
            {
                return RedirectToAction(redirectAction);
            }
            return View();
        }

        protected ActionResult PostLogOnAction(LogOnModel model, string redirectPasswordAction, string defaultAction="Index", string defualtController="Home")
        {
            if (ModelState.IsValid)
            {
                string returnUrl = model.ReturnUrl;

                if (ValidateUserPassword(model.LoginUpper, model.Password))
                {
                    User user = GetUserByLogin(model.LoginUpper);

                    //SetSaveCurrentCulture(user.Culture);
                    if (user.IfNotNull(u => u.AlterPassword) == true)
                    {
                        return RedirectToAction(redirectPasswordAction, model);
                    }
                    else
                    {
                        AuthorizeUser(user, model.RememberMe);
                        return this.RedirectReturn(returnUrl, defaultAction, defualtController);
                    }
                }
                else
                {
                    ModelState.AddModelError("",
                        SystemExtensions.Sentence(model.GetDisplayName(m => m.LoginUpper), LocalStr.or, model.GetDisplayName(m => m.Password), LocalStr.verbIsNot, LocalStr.valid)
                    );
                }
            }
            // If we got this far, something failed, redisplay form
            return View(model);
        }

    }
}
