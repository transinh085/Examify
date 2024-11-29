using AutoMapper;

namespace Examify.Quiz.Features.Quiz.Dtos;

public class QuizUserDto
{
    public List<QuizDto> quizPulished { get; set; }
    public List<QuizDto> quizUnpublished { get; set; }
    
    private class QuizUserDtoProfile : Profile
    {
        public QuizUserDtoProfile()
        {
            CreateMap<Entities.Quiz, QuizDto>();
        }
    }
}