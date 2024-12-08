using Ardalis.GuardClauses;
using AutoMapper;
using Examify.Events;
using Examify.Quiz.Dtos;
using Examify.Quiz.Entities;
using Examify.Quiz.Features.Questions.Command.BulkUpdateQuestion;
using Examify.Quiz.Features.Questions.Command.PatchQuestionAttributes;
using Examify.Quiz.Infrastructure.Data;
using MassTransit;
using Microsoft.EntityFrameworkCore;

namespace Examify.Quiz.Repositories.Questions;

public class QuestionRepository(QuizContext quizContext, IMapper mapper, IPublishEndpoint publishEndpoint) : IQuestionRepository
{
    public async Task BulkUpdateQuestion(BulkUpdateQuestionCommand request, CancellationToken cancellationToken)
    {
        var questions = await quizContext.Questions.Where(x => x.QuizId == request.QuizId)
            .ToListAsync(cancellationToken);

        questions.ForEach(x =>
        {
            x.Duration = request.Duration ?? x.Duration;
            x.Points = request.Points ?? x.Points;
        });

        await quizContext.SaveChangesAsync(cancellationToken);
    }

    public async Task CreateQuestion(Entities.Question question, CancellationToken cancellationToken)
    {
        await quizContext.Questions.AddAsync(question, cancellationToken);
        await quizContext.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteQuestionById(Guid questionId, CancellationToken cancellationToken)
    {
        var question = await quizContext.Questions.FirstOrDefaultAsync(x => x.Id == questionId, cancellationToken);
        quizContext.Questions.Remove(question);
        await quizContext.SaveChangesAsync(cancellationToken);
    }

    public async Task DuplicateQuestion(Guid questionId, CancellationToken cancellationToken)
    {
        var question = await quizContext.Questions.Include(x => x.Options)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == questionId, cancellationToken);

        if (question is null)
        {
            return;
        }

        var newQuestion = new Entities.Question
        {
            QuizId = question.QuizId,
            Content = question.Content,
            Duration = question.Duration,
            Points = question.Points,
            Type = question.Type,
            Options = question.Options.Select(x => new Entities.Option
            {
                Content = x.Content,
                IsCorrect = x.IsCorrect
            }).ToList(),
        };

        await quizContext.Questions.AddAsync(newQuestion, cancellationToken);
        await quizContext.SaveChangesAsync(cancellationToken);
    }

    public async Task PatchQuestionAttributes(PatchQuestionAttributesCommand request,
        CancellationToken cancellationToken)
    {
        var question = await quizContext.Questions
            .FindAsync(request.Id, cancellationToken);

        if (question == null) return;

        if (request.Duration.HasValue)
        {
            question.Duration = request.Duration.Value;
        }

        if (request.Points.HasValue)
        {
            question.Points = request.Points.Value;
        }

        await quizContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<bool> IsQuestionExists(Guid quizId, CancellationToken cancellationToken)
    {
        return await quizContext.Questions
            .AnyAsync(q => q.QuizId == quizId, cancellationToken);
    }

    public async Task UpdateOrder(Guid questionId, int newOrder, CancellationToken cancellationToken)
    {
        var question = await quizContext.Questions
            .FirstOrDefaultAsync(q => q.Id == questionId, cancellationToken);

        Guard.Against.NotFound(questionId, question);

        if (question.Order == newOrder)
        {
            return;
        }

        var quizId = question.QuizId;
        var currentOrder = question.Order;

        var questions = await quizContext.Questions
            .Where(q => q.QuizId == quizId)
            .ToListAsync(cancellationToken);

        if (newOrder < currentOrder)
        {
            foreach (var q in questions.Where(q => q.Order >= newOrder && q.Order < currentOrder))
            {
                q.Order += 1;
            }
        }
        else if (newOrder > currentOrder)
        {
            foreach (var q in questions.Where(q => q.Order > currentOrder && q.Order <= newOrder))
            {
                q.Order -= 1;
            }
        }

        question.Order = newOrder;
        await quizContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<PopulatedQuestionDto?> FindById(Guid id)
    {
        var question = await quizContext.Questions
            .Include(x => x.Options)
            .FirstOrDefaultAsync(x => x.Id == id);

        return mapper.Map<PopulatedQuestionDto>(question);
    }

    public async Task UpdateQuestion(Question question, CancellationToken cancellationToken)
    {
        var existingQuestion = await quizContext.Questions
            .FirstOrDefaultAsync(x => x.Id == question.Id, cancellationToken);

        Guard.Against.NotFound(question.Id, existingQuestion);

        existingQuestion.Content = question.Content;
        existingQuestion.Duration = question.Duration;
        existingQuestion.Points = question.Points;
        existingQuestion.Type = question.Type;
        existingQuestion.Order = question.Order;

        var existingOptions = await quizContext.Options
            .Where(x => x.QuestionId == question.Id)
            .ToListAsync(cancellationToken);

        var existingOptionDict = existingOptions.ToDictionary(x => x.Id);

        var optionsToRemove = new List<Option>();
        var optionsToAdd = new List<Option>();
        var optionsToUpdate = new List<Option>();

        foreach (var option in question.Options)
        {
            if (existingOptionDict.TryGetValue(option.Id, out var existingOption))
            {
                existingOption.Content = option.Content;
                existingOption.IsCorrect = option.IsCorrect;
                optionsToUpdate.Add(existingOption);
            }
            else
            {
                optionsToAdd.Add(new Option
                {
                    Content = option.Content,
                    IsCorrect = option.IsCorrect,
                    QuestionId = question.Id
                });
            }
        }

        optionsToRemove = existingOptions
            .Where(existingOption => !question.Options.Any(option => option.Id == existingOption.Id))
            .ToList();

        if (optionsToRemove.Any())
        {
            quizContext.Options.RemoveRange(optionsToRemove);
            await publishEndpoint.Publish<OptionDeletedEvent>(new
            {
                OptionIds = optionsToRemove.Select(x => x.Id),
                DeletedAt = DateTime.UtcNow
            });
        }

        if (optionsToAdd.Any())
        {
            await quizContext.Options.AddRangeAsync(optionsToAdd, cancellationToken);
        }

        await quizContext.SaveChangesAsync(cancellationToken);
    }

}