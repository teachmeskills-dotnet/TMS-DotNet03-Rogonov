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
        /// Get question by user identifier.
        /// </summary>
        /// <param name="id">User identifier.</param>
        /// <returns>Question.</returns>
        Task<IEnumerable<QuestionDto>> GetQuestionByUserIdAsync(string userId);
    }
}
