using AllQueez.BLL.Models;
using System.Threading.Tasks;

namespace AllQueez.BLL.Interfaces
{
    /// <summary>
    /// RoundQuestion manager interface.
    /// </summary>
    public interface IRoundQuestionManager
    {
        /// <summary>
        /// Add questions to round.
        /// </summary>
        /// <param name="roundQuestionDto">RoundQuestion data transfer object.</param>
        Task AddQuestionAsync(RoundQuestionDto roundQuestionDto);
    }
}