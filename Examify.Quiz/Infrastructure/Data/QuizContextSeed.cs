using Examify.Quiz.Entities;
using Examify.Quiz.Enums;

namespace Examify.Quiz.Infrastructure.Data;

public class QuizContextSeed : IDbSeeder<QuizContext>
{
    public Task SeedAsync(QuizContext context)
    {
        if (context.Quizzes.Any()) return Task.CompletedTask;
        var quizzes = new List<Entities.Quiz>
        {
            new Entities.Quiz
            {
                Title = "Javascript Quiz Basic",
                Cover = "https://cloud.z.com/vn/wp-content/uploads/2024/01/Screenshot_1-6.png",
                Description = "Test your JavaScript knowledge",
                SubjectId = Guid.Parse("2f921f98-5b80-4916-943c-31c6a88ca70e"),
                GradeId = Guid.Parse("45304ba8-da09-46b9-8400-d5b7a7bb718e"),
                LanguageId = Guid.Parse("d9789c96-e0c8-4826-81b3-0eccd22d3508"),
                OwnerId = "ea616dc0-e621-474e-a247-b823b9fe6004",
                Visibility = Visibility.Public,
                IsPublished = true,
                Settings = new QuizSetting
                {
                    Code = "JSBASIC",
                    StartTime = DateTime.UtcNow,
                    EndTime = DateTime.UtcNow.AddDays(7),
                    RandomQuestions = true,
                    RandomOptions = true
                },
                Questions =
                [
                    new Question
                    {
                        Content = "What is JavaScript?",
                        Duration = 30,
                        Points = 1,
                        Type = QuestionType.MultipleChoice,
                        Order = 1,
                        Options = new List<Option>
                        {
                            new Option { Content = "A programming language", IsCorrect = true },
                            new Option { Content = "A markup language", IsCorrect = false },
                            new Option { Content = "A styling language", IsCorrect = false },
                            new Option { Content = "A scripting language", IsCorrect = false }
                        },
                    },
                    new Question
                    {
                        Content = "Which company developed JavaScript?",
                        Duration = 30,
                        Points = 1,
                        Type = QuestionType.MultipleChoice,
                        Order = 2,
                        Options =
                        [
                            new Option { Content = "Microsoft", IsCorrect = false },
                            new Option { Content = "Google", IsCorrect = false },
                            new Option { Content = "Netscape", IsCorrect = true },
                            new Option { Content = "Apple", IsCorrect = false }
                        ],
                    },
                    new Question
                    {
                        Content = "What does 'var' do in JavaScript?",
                        Duration = 30,
                        Points = 1,
                        Type = QuestionType.MultipleChoice,
                        Order = 3,
                        Options =
                        [
                            new Option { Content = "Declares a constant", IsCorrect = false },
                            new Option { Content = "Declares a variable", IsCorrect = true },
                            new Option { Content = "Defines a function", IsCorrect = false },
                            new Option { Content = "Declares a class", IsCorrect = false }
                        ],
                    },
                    new Question
                    {
                        Content = "Which operator is used for comparison in JavaScript?",
                        Duration = 30,
                        Points = 1,
                        Type = QuestionType.MultipleChoice,
                        Order = 4,
                        Options =
                        [
                            new Option { Content = "=", IsCorrect = false },
                            new Option { Content = "==", IsCorrect = true },
                            new Option { Content = "&&", IsCorrect = false },
                            new Option { Content = "!", IsCorrect = false }
                        ],
                    },
                    new Question
                    {
                        Content = "Which of the following is a correct way to create an array in JavaScript?",
                        Duration = 30,
                        Points = 1,
                        Type = QuestionType.MultipleChoice,
                        Order = 5,
                        Options =
                        [
                            new Option { Content = "var arr = new Array()", IsCorrect = true },
                            new Option { Content = "var arr = []", IsCorrect = true },
                            new Option { Content = "var arr = {}", IsCorrect = false },
                            new Option { Content = "var arr = Array[]", IsCorrect = false }
                        ],
                    },
                    new Question
                    {
                        Content = "What does 'this' refer to in JavaScript?",
                        Duration = 30,
                        Points = 1,
                        Type = QuestionType.MultipleChoice,
                        Order = 6,
                        Options =
                        [
                            new Option { Content = "The current function", IsCorrect = false },
                            new Option { Content = "The global object", IsCorrect = false },
                            new Option { Content = "The current object", IsCorrect = true },
                            new Option { Content = "The parent object", IsCorrect = false }
                        ],
                    },
                    new Question
                    {
                        Content = "How do you create a function in JavaScript?",
                        Duration = 30,
                        Points = 1,
                        Type = QuestionType.MultipleChoice,
                        Order = 7,
                        Options =
                        [
                            new Option { Content = "function myFunc()", IsCorrect = true },
                            new Option { Content = "function = myFunc()", IsCorrect = false },
                            new Option { Content = "func myFunc()", IsCorrect = false },
                            new Option { Content = "create function myFunc()", IsCorrect = false }
                        ],
                    },
                    new Question
                    {
                        Content = "Which of the following is not a JavaScript data type?",
                        Duration = 30,
                        Points = 1,
                        Type = QuestionType.MultipleChoice,
                        Order = 8,
                        Options =
                        [
                            new Option { Content = "String", IsCorrect = false },
                            new Option { Content = "Object", IsCorrect = false },
                            new Option { Content = "Number", IsCorrect = false },
                            new Option { Content = "Class", IsCorrect = true }
                        ],
                    },
                    new Question
                    {
                        Content = "What is the purpose of the 'debugger' keyword in JavaScript?",
                        Duration = 30,
                        Points = 1,
                        Type = QuestionType.MultipleChoice,
                        Order = 9,
                        Options =
                        [
                            new Option
                                { Content = "Stop the execution of the code and start debugging", IsCorrect = true },

                            new Option { Content = "Define a debug level", IsCorrect = false },
                            new Option { Content = "Set a breakpoint", IsCorrect = false },
                            new Option { Content = "Display debugging information", IsCorrect = false }
                        ],
                    },
                    new Question
                    {
                        Content = "Which method is used to parse a JSON string in JavaScript?",
                        Duration = 30,
                        Points = 1,
                        Type = QuestionType.MultipleChoice,
                        Order = 10,
                        Options =
                        [
                            new Option { Content = "JSON.parse()", IsCorrect = true },
                            new Option { Content = "JSON.stringify()", IsCorrect = false },
                            new Option { Content = "parseJSON()", IsCorrect = false },
                            new Option { Content = "toJSON()", IsCorrect = false }
                        ],
                    }
                ]
            },
            new Entities.Quiz
            {
                Title = "ASP.NET Core Quiz Basic",
                Cover = "https://ntsc.com.vn/wp-content/uploads/2019/07/1_XwSwno9LFOxt_Ae3tGtRIg.jpeg",
                Description = "Test your ASP.NET Core knowledge",
                SubjectId = Guid.Parse("2f921f98-5b80-4916-943c-31c6a88ca70e"),
                GradeId = Guid.Parse("45304ba8-da09-46b9-8400-d5b7a7bb718e"),
                LanguageId = Guid.Parse("d9789c96-e0c8-4826-81b3-0eccd22d3508"),
                OwnerId = "ea616dc0-e621-474e-a247-b823b9fe6004",
                Visibility = Visibility.Public,
                IsPublished = true,
                Settings = new QuizSetting
                {
                    Code = "CSHARPBASIC",
                    StartTime = DateTime.UtcNow,
                    EndTime = DateTime.UtcNow.AddDays(7),
                    RandomQuestions = true,
                    RandomOptions = true
                },
                Questions =
                [
                    new Question
                    {
                        Content = "What is the default web server for ASP.NET Core?",
                        Duration = 30,
                        Points = 1,
                        Type = QuestionType.MultipleChoice,
                        Order = 1,
                        Options =
                        [
                            new Option { Content = "IIS", IsCorrect = false },
                            new Option { Content = "Kestrel", IsCorrect = true },
                            new Option { Content = "Apache", IsCorrect = false },
                            new Option { Content = "Nginx", IsCorrect = false }
                        ],
                    },

                    new Question
                    {
                        Content = "Which of the following is used for dependency injection in ASP.NET Core?",
                        Duration = 30,
                        Points = 1,
                        Type = QuestionType.MultipleChoice,
                        Order = 2,
                        Options =
                        [
                            new Option { Content = "Unity", IsCorrect = false },
                            new Option { Content = "Autofac", IsCorrect = false },
                            new Option
                                { Content = "Microsoft.Extensions.DependencyInjection", IsCorrect = true },

                            new Option { Content = "Ninject", IsCorrect = false }
                        ],
                    },

                    new Question
                    {
                        Content = "In ASP.NET Core, which method is used to configure services?",
                        Duration = 30,
                        Points = 1,
                        Type = QuestionType.MultipleChoice,
                        Order = 3,
                        Options =
                        [
                            new Option { Content = "ConfigureServices", IsCorrect = true },
                            new Option { Content = "Configure", IsCorrect = false },
                            new Option { Content = "Startup", IsCorrect = false },
                            new Option { Content = "ConfigureApp", IsCorrect = false }
                        ],
                    },

                    new Question
                    {
                        Content = "Which file contains the configuration for the ASP.NET Core application?",
                        Duration = 30,
                        Points = 1,
                        Type = QuestionType.MultipleChoice,
                        Order = 4,
                        Options =
                        [
                            new Option { Content = "appsettings.json", IsCorrect = true },
                            new Option { Content = "config.json", IsCorrect = false },
                            new Option { Content = "startup.json", IsCorrect = false },
                            new Option { Content = "settings.json", IsCorrect = false }
                        ],
                    },

                    new Question
                    {
                        Content = "What does the 'UseRouting' method do in ASP.NET Core?",
                        Duration = 30,
                        Points = 1,
                        Type = QuestionType.MultipleChoice,
                        Order = 5,
                        Options =
                        [
                            new Option { Content = "It configures routing middleware", IsCorrect = true },
                            new Option
                                { Content = "It defines the routes for controllers", IsCorrect = false },

                            new Option { Content = "It sets up authentication", IsCorrect = false },
                            new Option { Content = "It starts the server", IsCorrect = false }
                        ],
                    },

                    new Question
                    {
                        Content = "What is the purpose of the 'app.UseEndpoints()' method in ASP.NET Core?",
                        Duration = 30,
                        Points = 1,
                        Type = QuestionType.MultipleChoice,
                        Order = 6,
                        Options =
                        [
                            new Option { Content = "It sets up HTTP request pipelines", IsCorrect = false },
                            new Option { Content = "It configures authorization rules", IsCorrect = false },
                            new Option { Content = "It maps controllers to endpoints", IsCorrect = true },
                            new Option { Content = "It starts the application", IsCorrect = false }
                        ],
                    },

                    new Question
                    {
                        Content =
                            "Which of the following middleware is responsible for handling static files in ASP.NET Core?",
                        Duration = 30,
                        Points = 1,
                        Type = QuestionType.MultipleChoice,
                        Order = 7,
                        Options =
                        [
                            new Option { Content = "UseStaticFiles", IsCorrect = true },
                            new Option { Content = "UseStaticContent", IsCorrect = false },
                            new Option { Content = "ServeFiles", IsCorrect = false },
                            new Option { Content = "EnableStaticFiles", IsCorrect = false }
                        ],
                    },

                    new Question
                    {
                        Content =
                            "In ASP.NET Core, which attribute is used to map HTTP request methods to controller actions?",
                        Duration = 30,
                        Points = 1,
                        Type = QuestionType.MultipleChoice,
                        Order = 8,
                        Options =
                        [
                            new Option { Content = "[HttpRequest]", IsCorrect = false },
                            new Option { Content = "[Route]", IsCorrect = false },
                            new Option { Content = "[HttpGet]", IsCorrect = true },
                            new Option { Content = "[HttpPost]", IsCorrect = true }
                        ],
                    },

                    new Question
                    {
                        Content = "How do you enable CORS in ASP.NET Core?",
                        Duration = 30,
                        Points = 1,
                        Type = QuestionType.MultipleChoice,
                        Order = 9,
                        Options =
                        [
                            new Option { Content = "app.UseCors()", IsCorrect = true },
                            new Option { Content = "app.UseCrossOrigin()", IsCorrect = false },
                            new Option { Content = "app.EnableCors()", IsCorrect = false },
                            new Option { Content = "app.AddCors()", IsCorrect = false }
                        ],
                    },

                    new Question
                    {
                        Content = "What is the default port for ASP.NET Core development server?",
                        Duration = 30,
                        Points = 1,
                        Type = QuestionType.MultipleChoice,
                        Order = 10,
                        Options =
                        [
                            new Option { Content = "8080", IsCorrect = false },
                            new Option { Content = "5000", IsCorrect = true },
                            new Option { Content = "443", IsCorrect = false },
                            new Option { Content = "80", IsCorrect = false }
                        ],
                    }
                ]
            },
            new Entities.Quiz
            {
                Title = "Basic Math Quiz",
                Cover = "https://t4.ftcdn.net/jpg/04/61/65/03/360_F_461650383_vOTkFxYQ2T2kvuymieHDHbIWjghyL3DY.jpg",
                Description = "Test your basic math skills",
                SubjectId = Guid.Parse("59820f61-ada9-44e8-9a45-790981fe05f0"),
                GradeId = Guid.Parse("45304ba8-da09-46b9-8400-d5b7a7bb718e"),
                LanguageId = Guid.Parse("d9789c96-e0c8-4826-81b3-0eccd22d3508"),
                OwnerId = "ea616dc0-e621-474e-a247-b823b9fe6004",
                Visibility = Visibility.Public,
                IsPublished = true,
                Settings = new QuizSetting
                {
                    Code = "AABD",
                    StartTime = DateTime.UtcNow,
                    EndTime = DateTime.UtcNow.AddDays(7),
                    RandomQuestions = true,
                    RandomOptions = true
                },
                Questions = new List<Question>
                {
                    new Question
                    {
                        Content = "What is 5 + 3?",
                        Duration = 30,
                        Points = 1,
                        Type = QuestionType.MultipleChoice,
                        Order = 1,
                        Options = new List<Option>
                        {
                            new Option { Content = "7", IsCorrect = false },
                            new Option { Content = "8", IsCorrect = true },
                            new Option { Content = "9", IsCorrect = false },
                            new Option { Content = "10", IsCorrect = false }
                        },
                    },
                    new Question
                    {
                        Content = "What is the square root of 16?",
                        Duration = 30,
                        Points = 1,
                        Type = QuestionType.MultipleChoice,
                        Order = 2,
                        Options = new List<Option>
                        {
                            new Option { Content = "3", IsCorrect = false },
                            new Option { Content = "4", IsCorrect = true },
                            new Option { Content = "5", IsCorrect = false },
                            new Option { Content = "6", IsCorrect = false }
                        },
                    },
                    new Question
                    {
                        Content = "What is 9 x 9?",
                        Duration = 30,
                        Points = 1,
                        Type = QuestionType.MultipleChoice,
                        Order = 3,
                        Options = new List<Option>
                        {
                            new Option { Content = "81", IsCorrect = true },
                            new Option { Content = "72", IsCorrect = false },
                            new Option { Content = "90", IsCorrect = false },
                            new Option { Content = "99", IsCorrect = false }
                        },
                    },
                    new Question
                    {
                        Content = "What is 15 - 7?",
                        Duration = 30,
                        Points = 1,
                        Type = QuestionType.MultipleChoice,
                        Order = 4,
                        Options = new List<Option>
                        {
                            new Option { Content = "7", IsCorrect = false },
                            new Option { Content = "8", IsCorrect = true },
                            new Option { Content = "9", IsCorrect = false },
                            new Option { Content = "6", IsCorrect = false }
                        },
                    },
                    new Question
                    {
                        Content = "What is the value of π (pi) approximately?",
                        Duration = 30,
                        Points = 1,
                        Type = QuestionType.MultipleChoice,
                        Order = 5,
                        Options = new List<Option>
                        {
                            new Option { Content = "3.14", IsCorrect = true },
                            new Option { Content = "3.15", IsCorrect = false },
                            new Option { Content = "3.13", IsCorrect = false },
                            new Option { Content = "3.16", IsCorrect = false }
                        },
                    },
                    new Question
                    {
                        Content = "What is 12 ÷ 4?",
                        Duration = 30,
                        Points = 1,
                        Type = QuestionType.MultipleChoice,
                        Order = 6,
                        Options = new List<Option>
                        {
                            new Option { Content = "2", IsCorrect = false },
                            new Option { Content = "3", IsCorrect = true },
                            new Option { Content = "4", IsCorrect = false },
                            new Option { Content = "5", IsCorrect = false }
                        },
                    },
                    new Question
                    {
                        Content = "What is 7 x 6?",
                        Duration = 30,
                        Points = 1,
                        Type = QuestionType.MultipleChoice,
                        Order = 7,
                        Options = new List<Option>
                        {
                            new Option { Content = "42", IsCorrect = true },
                            new Option { Content = "36", IsCorrect = false },
                            new Option { Content = "48", IsCorrect = false },
                            new Option { Content = "40", IsCorrect = false }
                        },
                    },
                    new Question
                    {
                        Content = "What is the next prime number after 7?",
                        Duration = 30,
                        Points = 1,
                        Type = QuestionType.MultipleChoice,
                        Order = 8,
                        Options = new List<Option>
                        {
                            new Option { Content = "9", IsCorrect = false },
                            new Option { Content = "11", IsCorrect = false },
                            new Option { Content = "13", IsCorrect = true },
                            new Option { Content = "10", IsCorrect = false }
                        },
                    },
                    new Question
                    {
                        Content = "What is 100 ÷ 10?",
                        Duration = 30,
                        Points = 1,
                        Type = QuestionType.MultipleChoice,
                        Order = 9,
                        Options = new List<Option>
                        {
                            new Option { Content = "5", IsCorrect = false },
                            new Option { Content = "10", IsCorrect = true },
                            new Option { Content = "20", IsCorrect = false },
                            new Option { Content = "15", IsCorrect = false }
                        },
                    },
                    new Question
                    {
                        Content = "What is 3²?",
                        Duration = 30,
                        Points = 1,
                        Type = QuestionType.MultipleChoice,
                        Order = 10,
                        Options = new List<Option>
                        {
                            new Option { Content = "6", IsCorrect = false },
                            new Option { Content = "9", IsCorrect = true },
                            new Option { Content = "12", IsCorrect = false },
                            new Option { Content = "8", IsCorrect = false }
                        },
                    }
                }
            },
            new Entities.Quiz
            {
                Title = "Intermediate Math Quiz",
                Cover =
                    "https://media.istockphoto.com/id/1219382595/vector/math-equations-written-on-a-blackboard.jpg?s=612x612&w=0&k=20&c=ShVWsMm2SNCNcIjuWGtpft0kYh5iokCzu0aHPC2fV4A=",
                Description = "Challenge your intermediate math skills",
                SubjectId = Guid.Parse("59820f61-ada9-44e8-9a45-790981fe05f0"),
                GradeId = Guid.Parse("45304ba8-da09-46b9-8400-d5b7a7bb718e"),
                LanguageId = Guid.Parse("d9789c96-e0c8-4826-81b3-0eccd22d3508"),
                OwnerId = "ea616dc0-e621-474e-a247-b823b9fe6004",
                Visibility = Visibility.Private,
                IsPublished = true,
                Settings = new QuizSetting
                {
                    Code = "ADBD",
                    StartTime = DateTime.UtcNow,
                    EndTime = DateTime.UtcNow.AddDays(7),
                    RandomQuestions = true,
                    RandomOptions = true
                },
                Questions = new List<Question>
                {
                    new Question
                    {
                        Content = "What is the value of 2³ + 3²?",
                        Duration = 40,
                        Points = 2,
                        Type = QuestionType.MultipleChoice,
                        Order = 1,
                        Options = new List<Option>
                        {
                            new Option { Content = "17", IsCorrect = false },
                            new Option { Content = "13", IsCorrect = true },
                            new Option { Content = "15", IsCorrect = false },
                            new Option { Content = "19", IsCorrect = false }
                        },
                    },
                    new Question
                    {
                        Content = "What is the greatest common divisor (GCD) of 48 and 180?",
                        Duration = 40,
                        Points = 2,
                        Type = QuestionType.MultipleChoice,
                        Order = 2,
                        Options = new List<Option>
                        {
                            new Option { Content = "6", IsCorrect = false },
                            new Option { Content = "12", IsCorrect = true },
                            new Option { Content = "18", IsCorrect = false },
                            new Option { Content = "24", IsCorrect = false }
                        },
                    },
                    new Question
                    {
                        Content = "Solve for x: 5x - 7 = 18",
                        Duration = 45,
                        Points = 2,
                        Type = QuestionType.MultipleChoice,
                        Order = 3,
                        Options = new List<Option>
                        {
                            new Option { Content = "5", IsCorrect = true },
                            new Option { Content = "6", IsCorrect = false },
                            new Option { Content = "4", IsCorrect = false },
                            new Option { Content = "7", IsCorrect = false }
                        },
                    },
                    new Question
                    {
                        Content = "What is the next number in the sequence: 2, 6, 12, 20, 30, ?",
                        Duration = 45,
                        Points = 2,
                        Type = QuestionType.MultipleChoice,
                        Order = 4,
                        Options = new List<Option>
                        {
                            new Option { Content = "40", IsCorrect = true },
                            new Option { Content = "42", IsCorrect = false },
                            new Option { Content = "38", IsCorrect = false },
                            new Option { Content = "44", IsCorrect = false }
                        },
                    },
                    new Question
                    {
                        Content = "What is the value of 7! (7 factorial)?",
                        Duration = 60,
                        Points = 2,
                        Type = QuestionType.MultipleChoice,
                        Order = 5,
                        Options = new List<Option>
                        {
                            new Option { Content = "5040", IsCorrect = true },
                            new Option { Content = "720", IsCorrect = false },
                            new Option { Content = "4032", IsCorrect = false },
                            new Option { Content = "362880", IsCorrect = false }
                        },
                    },
                    new Question
                    {
                        Content = "What is the sum of the interior angles of a hexagon?",
                        Duration = 40,
                        Points = 2,
                        Type = QuestionType.MultipleChoice,
                        Order = 6,
                        Options = new List<Option>
                        {
                            new Option { Content = "720°", IsCorrect = true },
                            new Option { Content = "540°", IsCorrect = false },
                            new Option { Content = "600°", IsCorrect = false },
                            new Option { Content = "480°", IsCorrect = false }
                        },
                    },
                    new Question
                    {
                        Content = "Solve for y: 3y + 4 = 25",
                        Duration = 40,
                        Points = 2,
                        Type = QuestionType.MultipleChoice,
                        Order = 7,
                        Options = new List<Option>
                        {
                            new Option { Content = "7", IsCorrect = true },
                            new Option { Content = "6", IsCorrect = false },
                            new Option { Content = "8", IsCorrect = false },
                            new Option { Content = "5", IsCorrect = false }
                        },
                    },
                    new Question
                    {
                        Content = "Which is the largest prime number less than 50?",
                        Duration = 40,
                        Points = 2,
                        Type = QuestionType.MultipleChoice,
                        Order = 8,
                        Options = new List<Option>
                        {
                            new Option { Content = "43", IsCorrect = false },
                            new Option { Content = "47", IsCorrect = true },
                            new Option { Content = "41", IsCorrect = false },
                            new Option { Content = "37", IsCorrect = false }
                        },
                    },
                    new Question
                    {
                        Content = "What is the equation of a line with slope 3 and y-intercept 5?",
                        Duration = 50,
                        Points = 2,
                        Type = QuestionType.MultipleChoice,
                        Order = 9,
                        Options = new List<Option>
                        {
                            new Option { Content = "y = 3x + 5", IsCorrect = true },
                            new Option { Content = "y = 5x + 3", IsCorrect = false },
                            new Option { Content = "y = 3x - 5", IsCorrect = false },
                            new Option { Content = "y = 5x - 3", IsCorrect = false }
                        },
                    },
                    new Question
                    {
                        Content = "What is the discriminant of the quadratic equation x² - 4x + 4 = 0?",
                        Duration = 40,
                        Points = 2,
                        Type = QuestionType.MultipleChoice,
                        Order = 10,
                        Options = new List<Option>
                        {
                            new Option { Content = "0", IsCorrect = true },
                            new Option { Content = "4", IsCorrect = false },
                            new Option { Content = "16", IsCorrect = false },
                            new Option { Content = "8", IsCorrect = false }
                        },
                    }
                }
            }
        };

        context.Quizzes.AddRange(quizzes);
        context.SaveChanges();
        return Task.CompletedTask;
    }
}