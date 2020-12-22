using AllQueez.BLL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AllQueez.BLL.Interfaces
{
    /// <summary>
    /// Question manager interface.
    /// </summary>
    public interface IQuestionManager
    {
        /// <summary>
        /// Create Question by user identifier.
        /// </summary>
        /// <param name="questionDto">Guestion data transfer object.</param>
        Task CreateAsync(QuestionDto questionDto);

        /// <summary>
        /// Get question by user identifier.
        /// </summary>
        /// <param name="id">User identifier.</param>
        /// <returns>Question.</returns>
        Task<IEnumerable<QuestionDto>> GetQuestionByUserIdAsync(string userId);

        /// <summary>
        /// Delete question by user and question identifiers.
        /// </summary>
        /// <param name="id">Question identifier.</param>
        /// <param name="userId">User identifier..</param>
        Task DeleteAsync(int id, string userId);
    }
}