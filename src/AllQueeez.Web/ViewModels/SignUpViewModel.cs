using System.ComponentModel.DataAnnotations;

namespace AllQueez.Web.ViewModels
{
    /// <summary>
    /// Register view model.
    /// </summary>
    public class SignUpViewModel
    {
        /// <summary>
        /// Email.
        /// </summary>
        [Required]
        [Display(Name = nameof(Email))]
        public string Email { get; set; }

        /// <summary>
        /// Username.
        /// </summary>
        [Required]
        [Display(Name = nameof(Username))]
        public string Username { get; set; }

        /// <summary>
        /// Password.
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = nameof(Password))]
        public string Password { get; set; }

        /// <summary>
        /// Password confirmation.
        /// </summary>
        [Required]
        [Compare(nameof(Password), ErrorMessage = "Passwords don't match.")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        public string PasswordConfirm { get; set; }
    }
}
