using Examify.Quiz.Dtos;
using Result;

namespace Examify.Result.Grpc.Client
{
	public class ResultQuizMetaService(Identity.IdentityClient identityClient, QuizGrpcService.QuizGrpcServiceClient quizClient) : IResultQuizMetaService
	{
		public async Task<UserDto> GetOwnerAsync(Guid userId)
		{
			var user = identityClient.GetIdentity(new IdentityRequest { Id = userId.ToString() });
			UserDto result = new UserDto
			{
				Id = user.Id,
				Name = user.Name,
				Avatar = user.Image
			};
			return result;
		}

		public async Task<QuizReply> GetQuizAsync(string Code)
		{
			return quizClient.GetQuiz(new QuizRequest
			{
				Id = "",
				Code = Code
			});
		}
	}
}
