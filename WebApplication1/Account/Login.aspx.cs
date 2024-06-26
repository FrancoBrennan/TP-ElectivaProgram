﻿using System;
using System.Web;
using System.Web.UI;
using CapaDeNegocios;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using WebApplication1.Models;

namespace WebApplication1.Account
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register";
            // Habilite esta opción una vez tenga la confirmación de la cuenta habilitada para la funcionalidad de restablecimiento de contraseña
            //ForgotPasswordHyperLink.NavigateUrl = "Forgot";
            OpenAuthLogin.ReturnUrl = Request.QueryString["ReturnUrl"];
            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!String.IsNullOrEmpty(returnUrl))
            {
                RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            }
        }

        protected void LogIn(object sender, EventArgs e)
        {
            if (IsValid)
            {

                /*
                // Validar la contraseña del usuario
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var signinManager = Context.GetOwinContext().GetUserManager<ApplicationSignInManager>();

                // Esto no cuenta los errores de inicio de sesión hacia el bloqueo de cuenta
                // Para habilitar los errores de contraseña para desencadenar el bloqueo, cambie a shouldLockout: true
                var result = signinManager.PasswordSignIn(Email.Text, Password.Text, RememberMe.Checked, shouldLockout: false);

                switch (result)
                {
                    case SignInStatus.Success:
                        IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                        break;
                    case SignInStatus.LockedOut:
                        Response.Redirect("/Account/Lockout");
                        break;
                    case SignInStatus.RequiresVerification:
                        Response.Redirect(String.Format("/Account/TwoFactorAuthenticationSignIn?ReturnUrl={0}&RememberMe={1}", 
                                                        Request.QueryString["ReturnUrl"],
                                                        RememberMe.Checked),
                                          true);
                        break;
                    case SignInStatus.Failure:
                    default:
                        FailureText.Text = "Intento de inicio de sesión no válido";
                        ErrorMessage.Visible = true;
                        break;
                }

                */

                Club club = (Club)Session["Club"];
                Socio soc = club.Socios.Find(socio => socio.Email.ToString() == Email.Text);

                try
                {
                    if (soc == null || soc.Dni.ToString() != Password.Text)
                    {
                        throw new Exception();
                    }


                    FailureText.Text = "";
                    ErrorMessage.Visible = false;

                    Session["Usuario"] = soc;

                    string url = "https://localhost:44366";
                    string script = string.Format("window.open('{0}');", url);

                    Page.ClientScript.RegisterStartupScript(this.GetType(),
                    "newPage" + UniqueID, script, true);

                }
                catch
                {
                    FailureText.Text = "Datos incorrectos";
                    ErrorMessage.Visible = true;
                }


            }
        }
    }
}