using AllQueez.DAL.Interfaces;
using System.Collections.Generic;

namespace AllQueez.DAL.Entities
{
    /// <summary>
    /// Questions.
    /// </summary>
    public class Question : IHasDbIdentity, IHasUserIdentity
    {
        /// <inheritdoc/>
        public int Id { get; set; }

        /// <inheritdoc/>
        public string UserId { get; set; }

        /// <summary>
        /// Navigation to User.
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Comment.
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// File.
        /// </summary>
        public string File { get; set; }

        /// <summary>
        /// Path.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Answer.
        /// </summary>
        public string Answer { get; set; }

        /// <summary>
        /// Navigation to Round questions.
        /// </summary>
        public ICollection<RoundQuestion> RoundQuestions { get; set; }
    }
}
