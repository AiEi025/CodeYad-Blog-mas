using CodeYad_Blog.CoreLayer.DTOs.Users;
using CodeYad_Blog.CoreLayer.Services.Users;
using CodeYad_Blog.CoreLayer.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace CodeYad_Blog.Web.Pages.Auth
{
    [ValidateAntiForgeryToken]
    [BindProperties]
    public class LoginModel : PageModel
    {
        private readonly IUserService _userService;
        public LoginModel(IUserService userService)
        {
            _userService = userService;
        }
        #region
        [Required(ErrorMessage = "نام کاربری را وارد کنید")]
        public string Username { get; set; }
        [Required(ErrorMessage = "رمز عبور را وارد کنید")]
        public string Password { get; set; }
        #endregion
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid == false)
            {
                return Page();
            }
            var result = _userService.LoginUser(new LoginUserDTO()
            {
                UserName = Username,
                Passsword = Password
            });
            if (result.Status == OperationResultStatus.NotFound)
            {
                ModelState.AddModelError("UserName", result.Messsage);
                return Page();
            }
            return RedirectToPage("../Index");
        }
    }
}
