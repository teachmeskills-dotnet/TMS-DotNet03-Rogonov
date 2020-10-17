namespace AllQueez.Common.Interfaces
{
    /// <summary>
    /// Interface for User identity implementation.
    /// </summary>
    public interface IHasUserIdentity
    {
        /// <summary>
        /// User identifier.
        /// </summary>
        public string UserId { get; set; }
    }
}
