using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Principal;
using System.Web.Mvc;
using AppGoat.Domain.Constants;

namespace AppGoat.Api.Models.Login
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Usuario")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [Display(Name = "Recordar contraseña?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {

        // [Required]
        public int idUser { get; set; }

        [Required(ErrorMessage = "The field {0} is required.")]
        [StringLength(50, ErrorMessage = "Max. {1} characters.")]
        [Display(Name = "Name")]
        public string Name { get; set; }


        [Required(ErrorMessage = "The field {0} is required.")]
        [StringLength(50, ErrorMessage = "Max. {1} characters.")]
        [Display(Name = "LastName")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "The field {0} is required.")]
        [StringLength(50, ErrorMessage = "Max. {1} characters.")]
        [Display(Name = "UserName")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "The field {0} is required.")]
        [EmailAddress(ErrorMessage = "The field {0} is not correct.")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The field {0} is required.")]
        [StringLength(100, ErrorMessage = "The {0} must have at least {2} characters.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Password and password confirmation do not match")]
        public string ConfirmPassword { get; set; }

        public SelectList roleList { get; set; }


        [Display(Name = "Role")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int idRole { get; set; }

        public string roleName { get; set; }

        //public void LoadCollections(IMastersCollection coleccion, IPrincipal user)
        //{
        //    var roles = coleccion.Roles();

        //    if (user.IsInRole(UserRoles.SUPERVISOR))
        //        roles = roles.Where(x => !Equals(x.Name, UserRoles.ADMIN));

        //    roleList = new SelectList(roles, "Name", "Name");
        //}
    }

    public class EditViewModel
    {

        // [Required]
        public int idUser { get; set; }

        [Required(ErrorMessage = "The field {0} is required.")]
        [StringLength(50, ErrorMessage = "Max. {1} characters.")]
        [Display(Name = "Name")]
        public string Name { get; set; }


        [Required(ErrorMessage = "The field {0} is required.")]
        [StringLength(50, ErrorMessage = "Max. {1} characters.")]
        [Display(Name = "LastName")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "The field {0} is required.")]
        [StringLength(50, ErrorMessage = "Max. {1} characters.")]
        [Display(Name = "UserName")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "The field {0} is required.")]
        [EmailAddress(ErrorMessage = "The field {0} is not correct.")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        public SelectList roleList { get; set; }


        [Display(Name = "Role")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int idRole { get; set; }

        public string roleName { get; set; }

        //public void LoadCollections(IMastersCollection coleccion, IPrincipal user)
        //{
        //    var roles = coleccion.Roles();

        //    if (user.IsInRole(UserRoles.SUPERVISOR))
        //        roles = roles.Where(x => !Equals(x.Name, UserRoles.ADMIN));

        //    roleList = new SelectList(roles, "Id", "Name");
        //}
    }



    public class UserEditViewModel
    {
        [Required(ErrorMessage = "The field {0} is required.")]
        public int idUser { get; set; }

        [Required(ErrorMessage = "The field {0} is required.")]
        [StringLength(50, ErrorMessage = "Max. {1} characters")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The field {0} is required.")]
        [StringLength(50, ErrorMessage = "Max. {1} characters")]
        [Display(Name = "LastName")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "The field {0} is required.")]
        [StringLength(50, ErrorMessage = "Max. {1} characters")]
        [Display(Name = "UserName")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "The field {0} is required.")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        public int idRole { get; set; }

        public string roleName { get; set; }

        public string oldRoleName { get; set; }

    }


    public class mDeleteUser
    {

        [Required(ErrorMessage = "Required field")]
        public int idUser { get; set; }

        [Required(ErrorMessage = "Required field")]
        [StringLength(50, ErrorMessage = "Max. {1} characters")]
        [Display(Name = "Name")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Required field")]
        [StringLength(50, ErrorMessage = "Max. {1} characters")]
        [Display(Name = "Surname")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Required field")]
        [StringLength(50, ErrorMessage = "Max. {1} characters")]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Required field")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }


    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class UserRestPasswordModel
    {
        [Required(ErrorMessage = "The field {0} is required.")]
        [Display(Name = "IdUser")]
        public int IdUser { get; set; }

        [Required(ErrorMessage = "The field {0} is required.")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}