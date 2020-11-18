namespace AllQueez.Web.ViewModels
{
    /// <summary>
    /// Questions list view model.
    /// </summary>
    public class QuestionsViewModel
    {
        /// <summary>
        /// Identifier.
        /// </summary>
        public int Id { get; set; }

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
    }
}
