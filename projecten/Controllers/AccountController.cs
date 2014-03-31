using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DotNetOpenAuth.AspNet;
using Microsoft.Web.WebPages.OAuth;
using projecten.Models.DAL;
using projecten.Models.Domain;
using WebMatrix.WebData;
using projecten.Filters;
using projecten.Models;
using System.Net.Mail;
using WebMatrix.Data;
using System.Data.SqlClient;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace projecten.Controllers
{
    [Authorize]
    //[InitializeSimpleMembership]
    public class AccountController : Controller
    {
        //
        // GET: /Account/Login
        private BedrijfContext context;

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
           
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid && model.Email == "depauwniels@hotmail.com" && model.Wachtwoord =="testen")
            {
                string rol = "bedrijf";
                FormsAuthenticationTicket authTicket =
                    new FormsAuthenticationTicket(1,model.Email,DateTime.Now,DateTime.Now.AddMinutes(20),false,rol,"/");
               HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName,
                   FormsAuthentication.Encrypt(authTicket));
                Response.Cookies.Add(cookie);
                HttpContext.User = new GenericPrincipal(new GenericIdentity(model.Email), new string[] {rol});
                return RedirectToLocal(returnUrl);
            }
            ModelState.AddModelError("", "The user name or password provided is incorrect.");
            return View(model);
        }

        //
        // POST: /Account/LogOff

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {

            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /Account/Register

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model,Bedrijf bedrijf)
        {

            if (ModelState.IsValid)
            {
                BedrijfRepository bedrijfsRepository = new BedrijfRepository(context);
                bedrijfsRepository.Add(bedrijf);
                bedrijfsRepository.SaveChanges();
                
                // Attempt to register the user
                try
                {
                    String RandomWachtwoord;
                    RandomWachtwoord = CreateRandomPassword(6);
                    MailMessage message = new MailMessage();
                    message.From = new MailAddress(model.email);                   
                    message.To.Add(model.email);
                    message.Subject = "Wachtwoord";
                    message.Body = "jouw wachtwoord: " + RandomWachtwoord;
                    model.Wachtwoord = RandomWachtwoord;

                    /*string rol = "bedrijf";
                    FormsAuthenticationTicket authTicket =
                        new FormsAuthenticationTicket(1, model.email, DateTime.Now, DateTime.Now.AddMinutes(20), false, rol, "/");
                    HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName,
                        FormsAuthentication.Encrypt(authTicket));
                    Response.Cookies.Add(cookie);
                    HttpContext.User = new GenericPrincipal(new GenericIdentity(model.email), new string[] { rol });
                   // return RedirectToLocal(returnUrl);     */    
                    
                    var client = new SmtpClient("smtp.gmail.com", 587)
                    {
                        Credentials = new NetworkCredential("nielsdepauw94@gmail.com", "Yankee12"),
                        EnableSsl = true
                        
                    };
                    
                    client.Send(message.From.ToString(), message.To.ToString(), message.Subject, message.Body);
                   
                    System.Diagnostics.Debug.WriteLine(RandomWachtwoord);
                    
                    return RedirectToAction("Index", "Home");
                }
                    
                catch (MembershipCreateUserException e)
                {
                    ModelState.AddModelError("", ErrorCodeToString(e.StatusCode));
                }
              
                
            
            ModelState.AddModelError("", "The user name or password provided is incorrect.");
            return View(model);
            }
            
            // If we got this far, something failed, redisplay form
            return View(model);
        }
        public static string CreateRandomPassword(int PasswordLength)
        {

            string _allowedChars = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789-";
            Random randNum = new Random();
            char[] chars = new char[PasswordLength];
            int allowedCharCount = _allowedChars.Length;

            for (int i = 0; i < PasswordLength; i++)
            {
                chars[i] = _allowedChars[(int)((_allowedChars.Length) * randNum.NextDouble())];
            }

            return new string(chars);
        }
        //
        // POST: /Account/Disassociate

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Disassociate(string provider, string providerUserId)
        {
            string ownerAccount = OAuthWebSecurity.GetUserName(provider, providerUserId);
            ManageMessageId? message = null;

            // Only disassociate the account if the currently logged in user is the owner
            if (ownerAccount == User.Identity.Name)
            {
                // Use a transaction to prevent the user from deleting their last login credential
                using (var scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.Serializable }))
                {
                    bool hasLocalAccount = OAuthWebSecurity.HasLocalAccount(WebSecurity.GetUserId(User.Identity.Name));
                    if (hasLocalAccount || OAuthWebSecurity.GetAccountsFromUserName(User.Identity.Name).Count > 1)
                    {
                        OAuthWebSecurity.DeleteAccount(provider, providerUserId);
                        scope.Complete();
                        message = ManageMessageId.RemoveLoginSuccess;
                    }
                }
            }

            return RedirectToAction("Manage", new { Message = message });
        }

        //
        // GET: /Account/Manage

        public ActionResult Manage(ManageMessageId? message)
        {
            ViewBag.StatusMessage =
                message == ManageMessageId.ChangePasswordSuccess ? "Your password has been changed."
                : message == ManageMessageId.SetPasswordSuccess ? "Your password has been set."
                : message == ManageMessageId.RemoveLoginSuccess ? "The external login was removed."
                : "";
            ViewBag.HasLocalPassword = OAuthWebSecurity.HasLocalAccount(WebSecurity.GetUserId(User.Identity.Name));
            ViewBag.ReturnUrl = Url.Action("Manage");
            return View();
        }

        //
        // POST: /Account/Manage

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Manage(LocalPasswordModel model)
        {
            bool hasLocalAccount = OAuthWebSecurity.HasLocalAccount(WebSecurity.GetUserId(User.Identity.Name));
            ViewBag.HasLocalPassword = hasLocalAccount;
            ViewBag.ReturnUrl = Url.Action("Manage");
            if (hasLocalAccount)
            {
                if (ModelState.IsValid)
                {
                    // ChangePassword will throw an exception rather than return false in certain failure scenarios.
                    bool changePasswordSucceeded;
                    try
                    {
                        changePasswordSucceeded = WebSecurity.ChangePassword(User.Identity.Name, "iTtjfd", model.NewPassword);
                    }
                    catch (Exception)
                    {
                        changePasswordSucceeded = false;
                    }

                    if (changePasswordSucceeded)
                    {
                        return RedirectToAction("Manage", new { Message = ManageMessageId.ChangePasswordSuccess });
                    }
                    else
                    {
                        ModelState.AddModelError("", "The current password is incorrect or the new password is invalid.");
                    }
                }
            }
            else
            {
                // User does not have a local password so remove any validation errors caused by a missing
                // OldPassword field
                ModelState state = ModelState["OldPassword"];
                if (state != null)
                {
                    state.Errors.Clear();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        WebSecurity.CreateAccount(User.Identity.Name, model.NewPassword);
                        return RedirectToAction("Manage", new { Message = ManageMessageId.SetPasswordSuccess });
                    }
                    catch (Exception)
                    {
                        ModelState.AddModelError("", String.Format("Unable to create local account. An account with the name \"{0}\" may already exist.", User.Identity.Name));
                    }
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // POST: /Account/ExternalLogin

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLogin(string provider, string returnUrl)
        {
            return new ExternalLoginResult(provider, Url.Action("ExternalLoginCallback", new { ReturnUrl = returnUrl }));
        }

        //
        // GET: /Account/ExternalLoginCallback

       
        //
        // POST: /Account/ExternalLoginConfirmation

       
        //
        // GET: /Account/ExternalLoginFailure

        [AllowAnonymous]
        public ActionResult ExternalLoginFailure()
        {
            return View();
        }

        [AllowAnonymous]
        [ChildActionOnly]
        public ActionResult ExternalLoginsList(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return PartialView("_ExternalLoginsListPartial", OAuthWebSecurity.RegisteredClientData);
        }

        [ChildActionOnly]
        public ActionResult RemoveExternalLogins()
        {
            ICollection<OAuthAccount> accounts = OAuthWebSecurity.GetAccountsFromUserName(User.Identity.Name);
            List<ExternalLogin> externalLogins = new List<ExternalLogin>();
            foreach (OAuthAccount account in accounts)
            {
                AuthenticationClientData clientData = OAuthWebSecurity.GetOAuthClientData(account.Provider);

                externalLogins.Add(new ExternalLogin
                {
                    Provider = account.Provider,
                    ProviderDisplayName = clientData.DisplayName,
                    ProviderUserId = account.ProviderUserId,
                });
            }

            ViewBag.ShowRemoveButton = externalLogins.Count > 1 || OAuthWebSecurity.HasLocalAccount(WebSecurity.GetUserId(User.Identity.Name));
            return PartialView("_RemoveExternalLoginsPartial", externalLogins);
        }

        public ActionResult StageOpdrachten()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult SelectAccount(string returnUrl)
        {
            ViewBag.Message = "SelectAccount";
            return View();
        }
        [AllowAnonymous]
        public ActionResult RegistreerSelectAccount(string returnUrl)
        {
            ViewBag.Message = "SelectAccount";
            return View();
        }
        [AllowAnonymous]
        public ActionResult RegistreerStudent()
        {
            ViewBag.Message = "RegistreerStudent";
            return View();

        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult RegistreerStudent(RegistreerStudentModel model, string returnUrl)
        {

            MySqlConnection Conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["localhost"].ConnectionString);
            MySqlCommand Comm1 = new MySqlCommand("SELECT email from student", Conn);
            Conn.Open();
            MySqlDataReader DR1 = Comm1.ExecuteReader();
            var email = "";
            
            if (DR1.Read())
            {
                email = DR1.GetValue(0).ToString();
                System.Diagnostics.Debug.WriteLine(model.Email);
            }
            Conn.Close();

            // WebSecurity.InitializeDatabaseConnection("DefaultConnection", "Student", "Id", "Email","Wachtwoord", autoCreateTables: true);
            if (model.Email == email)
            {
               
                FormsAuthentication.SetAuthCookie(model.Email, false);
                return RedirectToAction("WachtwoordVeranderen", "Account");

            }
            else
            {

                return RedirectToAction("Indexfout", "Home");

            }
            

        }
        
       
        [AllowAnonymous]
        public ActionResult LoginStudent()
        {
        
            ViewBag.Message = "LoginStudent";
            return View();

        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult LoginStudent(LoginStudentModel model, string returnUrl)
        {
            
            MySqlConnection Conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["localhost"].ConnectionString);
            MySqlCommand Comm1 = new MySqlCommand("SELECT email,wachtwoord from student", Conn);
            Conn.Open();
            MySqlDataReader DR1 = Comm1.ExecuteReader();
            var email = "";
            var wachtwoord ="";
            if (DR1.Read())
            {
                email = DR1.GetValue(0).ToString();
                wachtwoord = DR1.GetValue(1).ToString();
                System.Diagnostics.Debug.WriteLine(email);
            }
            Conn.Close();
            if (ModelState.IsValid && model.Email == email && model.Wachtwoord == wachtwoord)
            {
                FormsAuthentication.SetAuthCookie(model.Email, false);
                return RedirectToLocal(returnUrl);
            }

            // If we got this far, something failed, redisplay form
            ModelState.AddModelError("", "The user name or password provided is incorrect.");
            return View(model);
        }
        [AllowAnonymous]
        public ActionResult WachtwoordVeranderen()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult WachtwoordVeranderen(WachtwoordVeranderenModel model)
        {
          
                var db = Database.Open("localhost");
               
                var insertCommand1 = "UPDATE student SET wachtwoord ='" + model.ConfirmPassword + "'WHERE email ='" +User.Identity.Name+ "'";
                    db.Execute(insertCommand1);

                    FormsAuthentication.SetAuthCookie(User.Identity.Name, false);
                   
                    return RedirectToAction("Profiel", "Student");

            
        }
      
        #region Helpers
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public enum ManageMessageId
        {
            ChangePasswordSuccess,
            SetPasswordSuccess,
            RemoveLoginSuccess,
        }

        internal class ExternalLoginResult : ActionResult
        {
            public ExternalLoginResult(string provider, string returnUrl)
            {
                Provider = provider;
                ReturnUrl = returnUrl;
            }

            public string Provider { get; private set; }
            public string ReturnUrl { get; private set; }

            public override void ExecuteResult(ControllerContext context)
            {
                OAuthWebSecurity.RequestAuthentication(Provider, ReturnUrl);
            }
        }

        private static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            // See http://go.microsoft.com/fwlink/?LinkID=177550 for
            // a full list of status codes.
            switch (createStatus)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "Deze gebruikersnaam bestaat al.Gelieve een nieuwe gebruikersnaam te kiezen.";

                case MembershipCreateStatus.DuplicateEmail:
                    return "Er is al iemand geregistreerd met dit Email adres.Gebruik een ander Email adres";

                case MembershipCreateStatus.InvalidPassword:
                    return "Dit wachtwoord is niet correct.";

                case MembershipCreateStatus.InvalidEmail:
                    return "Dit Email adres is niet correct";

                case MembershipCreateStatus.InvalidAnswer:
                    return "The password retrieval answer provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidQuestion:
                    return "The password retrieval question provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidUserName:
                    return "The user name provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.ProviderError:
                    return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                case MembershipCreateStatus.UserRejected:
                    return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                default:
                    return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
            }
        }
        #endregion
    }
}
