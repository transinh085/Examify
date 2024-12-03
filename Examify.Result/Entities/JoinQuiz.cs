using Examify.Core.Entitites;

namespace Examify.Result.Entities
{
	public class JoinQuiz : BaseEntity
	{
		public Guid QuizId { get; set; }

		public Guid UserId { get; set; }
	}
}
