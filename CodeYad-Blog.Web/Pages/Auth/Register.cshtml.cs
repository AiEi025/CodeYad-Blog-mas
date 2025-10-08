using CodeYad_Blog.CoreLayer.Services.Users;
using CodeYad_Blog.CoreLayer.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace CodeYad_Blog.Web.Pages.Auth
{
    [BindProperties]
    [ValidateAntiForgeryToken]
    public class RegisterModel : PageModel
    {
        private readonly IUserService _userService;

        #region Properties

        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string UserName { get; set; }

        [Display(Name = "نام و نام خانوادگی")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string FullName { get; set; }

        [Display(Name = "کلمه عبور")]
        [MinLength(6, ErrorMessage = "{0} باید بیشتر از 6 کاراکتر باشد")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        
        public string Password { get; set; }
        #endregion

        public RegisterModel(IUserService userService)
        {
            _userService = userService;
        }
        public void OnGet()
        {

        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid == false)
            {
                return Page();
            }
            var result = _userService.RegisterUser(new CoreLayer.DTOs.Users.UserRegisterDTO()
            { 
            UserName = UserName,
            FullName = FullName,
            Password = Password
            });
            if (result.Status == OperationResultStatus.Error)
            {
                ModelState.AddModelError("UserName" ,result.Messsage);
                return Page();
            }
            return RedirectToPage("Login");
        }
    }
}
