
using Examify.Quiz.Dtos;
using Examify.Result.Entities;
using Examify.Result.Grpc.Client;
using Examify.Result.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Examify.Result.Repositories
{
	public class JoinQuizRepository(QuizResultContext quizResultContext, IResultQuizMetaService resultQuizMetaService) : IJoinQuizRepository
	{
		public async Task<JoinQuiz> Create(Guid userId, Guid quizId)
		{
			JoinQuiz joinQuiz = new JoinQuiz
			{
				UserId = userId,
				QuizId = quizId
			};
			await quizResultContext.JoinQuizzes.AddAsync(joinQuiz);
			await quizResultContext.SaveChangesAsync();
			return joinQuiz;
		}

		public async Task<List<UserDto>> GetUserJoinQuiz(string code)
		{
			var getQuiz = await resultQuizMetaService.GetQuizAsync(code);
			var playTime = DateTime.SpecifyKind(DateTime.Parse(getQuiz.PlayTime), DateTimeKind.Utc); // Ensure playTime is in UTC
			var listJoinQuiz = await quizResultContext.JoinQuizzes
				.Where(q => q.QuizId == Guid.Parse(getQuiz.Id))
				.Where(q => q.CreatedDate >= playTime)
				.ToListAsync();
			List<UserDto> list
				= new List<UserDto>();
			foreach (var item in listJoinQuiz)
			{
				UserDto userDto = await resultQuizMetaService.GetOwnerAsync(item.UserId);
				list.Add(userDto);
			}
			return list;
		}

		public async Task<bool> CheckUserJoin(Guid userId, string code)
		{
			var getQuiz = await resultQuizMetaService.GetQuizAsync(code);
			var playTime = DateTime.SpecifyKind(DateTime.Parse(getQuiz.PlayTime), DateTimeKind.Utc);
			var check = await quizResultContext.JoinQuizzes
				.Where(q => q.UserId == userId)
				.Where(q => q.CreatedDate >= playTime)
				.FirstOrDefaultAsync();
			if (check == null)
			{
				return false;
			}
			return true;
		}

	}
}
