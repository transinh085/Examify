using Examify.Quiz.Dtos;
using Result;

namespace Examify.Result.Grpc.Client
{
	public interface IResultQuizMetaService
	{
		Task<UserDto> GetOwnerAsync(Guid Id);

		Task<QuizReply> GetQuizAsync(string Code);
	}
}
