using MediatR;

namespace Examify.Quiz.Features.Quizs.Query.GetAllQuiz;

public record GetAllQuizQuery : IRequest<IResult>;