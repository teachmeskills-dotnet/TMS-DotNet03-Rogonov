namespace AllQueez.BLL.Models
{
    /// <summary>
    /// User data tansfer object.
    /// </summary>
    public class UserDto
    {
        /// <summary>
        /// Username.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Password.
        /// </summary>
        public string Password { get; set; }
    }
}