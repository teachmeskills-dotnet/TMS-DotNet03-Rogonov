using System.ComponentModel.DataAnnotations;

namespace AllQueez.Web.ViewModels
{
    /// <summary>
    /// Sign in model.
    /// </summary>
    public class SignInViewModel
    {
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

        // TODO: move to constants
        /// <summary>
        /// Remember me.
        /// </summary>
        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }

        /// <summary>
        /// Return url.
        /// </summary>
        public string ReturnUrl { get; set; }
    }
}
