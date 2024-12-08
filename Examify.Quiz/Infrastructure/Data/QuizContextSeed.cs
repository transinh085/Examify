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
                Code = "JSBASIC",
                StartTime = DateTime.UtcNow,
                EndTime = DateTime.UtcNow.AddDays(7),
                RandomQuestions = true,
                RandomOptions = true,
                Questions =
                [
                    new Question
                    {
                        Content = "What is JavaScript?",
                        Duration = 30,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
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
                        Type = QuestionType.SingleChoice,
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
                        Type = QuestionType.SingleChoice,
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
                        Type = QuestionType.SingleChoice,
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
                        Type = QuestionType.SingleChoice,
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
                        Type = QuestionType.SingleChoice,
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
                        Type = QuestionType.SingleChoice,
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
                        Type = QuestionType.SingleChoice,
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
                        Type = QuestionType.SingleChoice,
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
                        Type = QuestionType.SingleChoice,
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
                Code = "C#BASIC",
                StartTime = DateTime.UtcNow,
                EndTime = DateTime.UtcNow.AddDays(7),
                RandomQuestions = true,
                RandomOptions = true,
                Questions =
                [
                    new Question
                    {
                        Content = "What is the default web server for ASP.NET Core?",
                        Duration = 30,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
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
                        Type = QuestionType.SingleChoice,
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
                        Type = QuestionType.SingleChoice,
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
                        Type = QuestionType.SingleChoice,
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
                        Type = QuestionType.SingleChoice,
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
                        Type = QuestionType.SingleChoice,
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
                        Type = QuestionType.SingleChoice,
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
                        Type = QuestionType.SingleChoice,
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
                        Type = QuestionType.SingleChoice,
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
                Code = "AABD",
                StartTime = DateTime.UtcNow,
                EndTime = DateTime.UtcNow.AddDays(7),
                RandomQuestions = true,
                RandomOptions = true,
                Questions = new List<Question>
                {
                    new Question
                    {
                        Content = "What is 5 + 3?",
                        Duration = 30,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
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
                        Type = QuestionType.SingleChoice,
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
                        Type = QuestionType.SingleChoice,
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
                        Type = QuestionType.SingleChoice,
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
                        Type = QuestionType.SingleChoice,
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
                        Type = QuestionType.SingleChoice,
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
                        Type = QuestionType.SingleChoice,
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
                        Type = QuestionType.SingleChoice,
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
                        Type = QuestionType.SingleChoice,
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
                        Type = QuestionType.SingleChoice,
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
                Code = "ADBD",
                StartTime = DateTime.UtcNow,
                EndTime = DateTime.UtcNow.AddDays(7),
                RandomQuestions = true,
                RandomOptions = true,
                Questions = new List<Question>
                {
                    new Question
                    {
                        Content = "What is the value of 2³ + 3²?",
                        Duration = 40,
                        Points = 2,
                        Type = QuestionType.SingleChoice,
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
                        Type = QuestionType.SingleChoice,
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
                        Type = QuestionType.SingleChoice,
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
                        Type = QuestionType.SingleChoice,
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
                        Type = QuestionType.SingleChoice,
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
                        Type = QuestionType.SingleChoice,
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
                        Type = QuestionType.SingleChoice,
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
                        Type = QuestionType.SingleChoice,
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
                        Type = QuestionType.SingleChoice,
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
                        Type = QuestionType.SingleChoice,
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
            },
            new Entities.Quiz
            {
                Title = "Basic Physics Quiz",
                Cover = "https://media.quizizz.com/_mdserver/main/media/resource/gs/quizizz-media/quizzes/6bad597e-142c-4b7c-b1e9-76626a8c8ff2-v2?w=200&h=200",
                Description = "Test your fundamental physics knowledge",
                SubjectId = Guid.Parse("462175fb-55b4-40e0-b317-8f4d58ca9615"),
                GradeId = Guid.Parse("56873e58-0c4f-4f33-a7c6-faf1bb3e6b40"),
                LanguageId = Guid.Parse("d9789c96-e0c8-4826-81b3-0eccd22d3508"),
                OwnerId = "ea616dc0-e621-474e-a247-b823b9fe6004",
                Visibility = Visibility.Public,
                IsPublished = true,
                Code = "QWEQWE",
                Questions = new List<Question>
                {
                    new Question
                    {
                        Content = "What is the speed of light in vacuum?",
                        Duration = 30,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 1,
                        Options = new List<Option>
                        {
                            new Option { Content = "3 x 10^6 m/s", IsCorrect = false },
                            new Option { Content = "3 x 10^8 m/s", IsCorrect = true },
                            new Option { Content = "3 x 10^7 m/s", IsCorrect = false },
                            new Option { Content = "3 x 10^5 m/s", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "Which of the following objects is not a source of light?",
                        Duration = 30,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 2,
                        Options = new List<Option>
                        {
                            new Option { Content = "The Sun", IsCorrect = false },
                            new Option { Content = "A volcano erupting", IsCorrect = false },
                            new Option { Content = "A glowing light bulb", IsCorrect = false },
                            new Option { Content = "The Moon", IsCorrect = true }
                        }
                    },
                    new Question
                    {
                        Content = "A luminous object is:",
                        Duration = 30,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 3,
                        Options = new List<Option>
                        {
                            new Option { Content = "An object that emits light.", IsCorrect = false },
                            new Option { Content = "Sources of light and objects that reflect light shining on them.", IsCorrect = true },
                            new Option { Content = "Objects that are illuminated.", IsCorrect = false },
                            new Option { Content = "Objects visible to the eyes.", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "Choose the correct statement:",
                        Duration = 30,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 4,
                        Options = new List<Option>
                        {
                            new Option { Content = "The eye sees an object when light from the object enters the eye.", IsCorrect = true },
                            new Option { Content = "The eye sees an object when light emitted from the eye reaches the object.", IsCorrect = false },
                            new Option { Content = "The condition for seeing an object is that the object must be illuminated.", IsCorrect = false },
                            new Option { Content = "The condition for the eye to see an object is that the object must emit light or reflect light.", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "Under which condition do we observe a lunar eclipse from Earth?",
                        Duration = 30,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 5,
                        Options = new List<Option>
                        {
                            new Option { Content = "At night, when we stand in a place not receiving sunlight.", IsCorrect = false },
                            new Option { Content = "At night, when the Moon does not receive sunlight because it is blocked by the Earth.", IsCorrect = true },
                            new Option { Content = "When the Sun blocks the Moon, preventing its light from reaching Earth.", IsCorrect = false },
                            new Option { Content = "During the day, when the Earth blocks the Moon.", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "Why are multiple light bulbs installed in different positions in a classroom instead of using one large bulb? Which explanation is correct?",
                        Duration = 30,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 6,
                        Options = new List<Option>
                        {
                            new Option { Content = "To make the classroom look nicer.", IsCorrect = false },
                            new Option { Content = "Only to increase the brightness in the classroom.", IsCorrect = false },
                            new Option { Content = "To avoid shadows and partial shadows when students write.", IsCorrect = true },
                            new Option { Content = "To prevent students from being dazzled.", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "During a solar eclipse, what is the relative position of the Earth, Sun, and Moon (assuming their centers lie on the same straight line)? Select the correct answer from the options below:",
                        Duration = 30,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 7,
                        Options = new List<Option>
                        {
                            new Option { Content = "Earth – Sun – Moon", IsCorrect = false },
                            new Option { Content = "Sun – Earth – Moon", IsCorrect = false },
                            new Option { Content = "Earth – Moon – Sun", IsCorrect = true },
                            new Option { Content = "Moon – Earth – Sun", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "Choose the correct statement:",
                        Duration = 30,
                        Points = 1,
                        Type = QuestionType.MultipleChoice,
                        Order = 8,
                        Options = new List<Option>
                        {
                            new Option { Content = "The reflected ray lies in the plane containing the incident ray and the normal to the mirror at the point of incidence.", IsCorrect = true },
                            new Option { Content = "The reflected ray, incident ray, and the normal to the mirror at the point of incidence all lie in the same plane.", IsCorrect = true },
                            new Option { Content = "The plane containing the incident ray and the normal to the mirror at the point of incidence also contains the reflected ray.", IsCorrect = true },
                            new Option { Content = "All false", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "Which of the following cannot be considered a plane mirror?",
                        Duration = 30,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 9,
                        Options = new List<Option>
                        {
                            new Option { Content = "A TV screen.", IsCorrect = false },
                            new Option { Content = "The surface of a white sheet of paper.", IsCorrect = true },
                            new Option { Content = "The surface of a calm lake.", IsCorrect = false },
                            new Option { Content = "A piece of glass without silver nitrate coating.", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                    Content = "Choose the correct statement:",
                    Duration = 30,
                    Points = 1,
                    Type = QuestionType.SingleChoice,
                    Order = 10,
                    Options = new List<Option>
                        {
                            new Option { Content = "The image of an object in a plane mirror is always smaller than the object.", IsCorrect = false },
                            new Option { Content = "The image of an object created by a plane mirror can be larger than the object depending on its position relative to the mirror.", IsCorrect = false },
                            new Option { Content = "If the screen is placed at an appropriate position, we can capture the image of the object created by the plane mirror.", IsCorrect = false },
                            new Option { Content = "The image of an object created by a plane mirror always has the same size as the object.", IsCorrect = true }
                        }
                    }
                }
            },
            new Entities.Quiz
            {
                Title = "Basic Physics Quiz 2",
                Cover = "https://media.quizizz.com/_mdserver/main/media/resource/gs/quizizz-media/quizzes/6bad597e-142c-4b7c-b1e9-76626a8c8ff2-v2?w=200&h=200",
                Description = "Test your fundamental physics knowledge 2",
                SubjectId = Guid.Parse("462175fb-55b4-40e0-b317-8f4d58ca9615"),
                GradeId = Guid.Parse("56873e58-0c4f-4f33-a7c6-faf1bb3e6b40"),
                LanguageId = Guid.Parse("d9789c96-e0c8-4826-81b3-0eccd22d3508"),
                OwnerId = "ea616dc0-e621-474e-a247-b823b9fe6004",
                Visibility = Visibility.Public,
                IsPublished = true,
                Code = "ASDASD",
                Questions = new List<Question>
                {
                    new Question
                    {
                        Content = "A person who is 1.6 meters tall stands in front of a plane mirror, and the image is 1.5 meters away from the mirror. How far is the person from the mirror?",
                        Duration = 30,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 1,
                        Options = new List<Option>
                        {
                            new Option { Content = "3 meters", IsCorrect = false },
                            new Option { Content = "3.2 meters", IsCorrect = false },
                            new Option { Content = "1.5 meters", IsCorrect = true },
                            new Option { Content = "1.6 meters", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "The image of an object formed by a convex mirror has the following characteristic:",
                        Duration = 30,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 2,
                        Options = new List<Option>
                        {
                            new Option { Content = "Larger than the object", IsCorrect = false },
                            new Option { Content = "Equal to the object", IsCorrect = false },
                            new Option { Content = "Smaller than the object", IsCorrect = true },
                            new Option { Content = "Twice the size of the object", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "We can see the filament of a light bulb because:",
                        Duration = 30,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 3,
                        Options = new List<Option>
                        {
                            new Option { Content = "There is no object blocking the light between the eye and the filament.", IsCorrect = true },
                            new Option { Content = "An electric current is passing through the filament.", IsCorrect = false },
                            new Option { Content = "Light from the eye is transmitted to the filament.", IsCorrect = false },
                            new Option { Content = "Light from the filament is transmitted to the eye.", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "A person who is 1.6 meters tall stands in front of a plane mirror. What is the height of their image?",
                        Duration = 30,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 4,
                        Options = new List<Option>
                        {
                            new Option { Content = "3 meters", IsCorrect = false },
                            new Option { Content = "3.2 meters", IsCorrect = false },
                            new Option { Content = "1.5 meters", IsCorrect = false },
                            new Option { Content = "1.6 meters", IsCorrect = true }
                        }
                    },
                    new Question
                    {
                        Content = "A convex mirror is used as a rearview mirror (mirror for looking behind) on cars and motorcycles because:",
                        Duration = 30,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 5,
                        Options = new List<Option>
                        {
                            new Option { Content = "It is easy to manufacture.", IsCorrect = false },
                            new Option { Content = "It provides a large and clear image.", IsCorrect = false },
                            new Option { Content = "It offers a wide field of view behind the mirror.", IsCorrect = true },
                            new Option { Content = "All of the above reasons.", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "We can perceive light when:",
                        Duration = 30,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 6,
                        Options = new List<Option>
                        {
                            new Option { Content = "It is daytime.", IsCorrect = false },
                            new Option { Content = "There is a light source in front of us.", IsCorrect = false },
                            new Option { Content = "We have our eyes open.", IsCorrect = false },
                            new Option { Content = "Light is entering our eyes.", IsCorrect = true }
                        }
                    },
                    new Question
                    {
                        Content = "Which of the following homogeneous environments does not satisfy the condition for the straight-line propagation of light?",
                        Duration = 30,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 7,
                        Options = new List<Option>
                        {
                            new Option { Content = "Air", IsCorrect = false },
                            new Option { Content = "Glass", IsCorrect = false },
                            new Option { Content = "Water", IsCorrect = false },
                            new Option { Content = "Iron", IsCorrect = true }
                        }
                    },
                    new Question
                    {
                        Content = "A parallel beam of light consists of rays that:",
                        Duration = 30,
                        Points = 1,
                        Type = QuestionType.MultipleChoice,
                        Order = 8,
                        Options = new List<Option>
                        {
                            new Option { Content = "Do not intersect.", IsCorrect = true },
                            new Option { Content = "Meet at infinity.", IsCorrect = true },
                            new Option { Content = "Neither converge nor diverge.", IsCorrect = true },
                            new Option { Content = "All false.", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "Which of the following statements is correct according to the law of reflection of light?",
                        Duration = 30,
                        Points = 1,
                        Type = QuestionType.MultipleChoice,
                        Order = 9,
                        Options = new List<Option>
                        {
                            new Option { Content = "The angle of reflection is equal to the angle of incidence.", IsCorrect = true },
                            new Option { Content = "The angle of incidence is equal to the angle of reflection.", IsCorrect = true },
                            new Option { Content = "The angle of reflection is greater than the angle of incidence.", IsCorrect = false },
                            new Option { Content = "The angle of incidence is greater than the angle of reflection.", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "Why do we see an object?",
                        Duration = 30,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 10,
                        Options = new List<Option>
                        {
                            new Option { Content = "Because we open our eyes and face the object.", IsCorrect = false },
                            new Option { Content = "Because our eyes emit rays of light onto the object.", IsCorrect = false },
                            new Option { Content = "Because light from the object enters our eyes.", IsCorrect = true },
                            new Option { Content = "Because the object is illuminated.", IsCorrect = false }
                        }
                    }
                }
            },
            new Entities.Quiz
            {
                Title = "Math grade 2",
                Cover = "https://quizizz.com/media/resource/gs/quizizz-media/quizzes/cacd1311-e0a2-41ba-85bd-309e1d3474a6?w=200&h=200",
                Description = "Learn the basics of Math 2",
                SubjectId = Guid.Parse("59820f61-ada9-44e8-9a45-790981fe05f0"),
                GradeId = Guid.Parse("bac8156d-9e33-4054-8a56-8d8ca6647cfb"),
                LanguageId = Guid.Parse("d9789c96-e0c8-4826-81b3-0eccd22d3508"),
                OwnerId = "ea616dc0-e621-474e-a247-b823b9fe6004",
                Visibility = Visibility.Public,
                IsPublished = true,
                Code = "ZXCZXC",
                Questions = new List<Question>
                {
                    new Question
                    {
                        Content = "7+5=",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 1,
                        Options = new List<Option>
                        {
                            new Option { Content = "12", IsCorrect = true },
                            new Option { Content = "31", IsCorrect = false },
                            new Option { Content = "11", IsCorrect = false },
                            new Option { Content = "13", IsCorrect = false }
                        }
                    },new Question
                    {
                        Content = "9+6+4+2=",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 2,
                        Options = new List<Option>
                        {
                            new Option { Content = "27", IsCorrect = false },
                            new Option { Content = "24", IsCorrect = false },
                            new Option { Content = "21", IsCorrect = true },
                            new Option { Content = "30", IsCorrect = false }
                        }
                    },new Question
                    {
                        Content = "3+4+9+2",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 3,
                        Options = new List<Option>
                        {
                            new Option { Content = "19", IsCorrect = false },
                            new Option { Content = "20", IsCorrect = false },
                            new Option { Content = "21", IsCorrect = false },
                            new Option { Content = "18", IsCorrect = true }
                        }
                    },new Question
                    {
                        Content = "2+5+4+7+6+8",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 4,
                        Options = new List<Option>
                        {
                            new Option { Content = "33", IsCorrect = false },
                            new Option { Content = "32", IsCorrect = true },
                            new Option { Content = "15", IsCorrect = false },
                            new Option { Content = "36", IsCorrect = false }
                        }
                    },new Question
                    {
                        Content = "2-1+3+4-6",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 5,
                        Options = new List<Option>
                        {
                            new Option { Content = "-1", IsCorrect = false },
                            new Option { Content = "2", IsCorrect = true },
                            new Option { Content = "0", IsCorrect = false },
                            new Option { Content = "3", IsCorrect = false }
                        }
                    },new Question
                    {
                        Content = "9-6+5-2+7+9+3-10",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 6,
                        Options = new List<Option>
                        {
                            new Option { Content = "12", IsCorrect = false },
                            new Option { Content = "11", IsCorrect = false },
                            new Option { Content = "15", IsCorrect = true },
                            new Option { Content = "17", IsCorrect = false }
                        }
                    },new Question
                    {
                        Content = "7+5=",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 7,
                        Options = new List<Option>
                        {
                            new Option { Content = "12", IsCorrect = true },
                            new Option { Content = "31", IsCorrect = false },
                            new Option { Content = "11", IsCorrect = false },
                            new Option { Content = "13", IsCorrect = false }
                        }
                    },new Question
                    {
                        Content = "Insert number:13<__<17",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.MultipleChoice,
                        Order = 8,
                        Options = new List<Option>
                        {
                            new Option { Content = "12", IsCorrect = false },
                            new Option { Content = "18", IsCorrect = false },
                            new Option { Content = "15", IsCorrect = true },
                            new Option { Content = "16", IsCorrect = true }
                        }
                    },new Question
                    {
                        Content = "2-1+3= 5",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 9,
                        Options = new List<Option>
                        {
                            new Option { Content = "true", IsCorrect = false },
                            new Option { Content = "false", IsCorrect = true },
                        }
                    },new Question
                    {
                        Content = "Choose (>, <, =).    23__31-7",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 10,
                        Options = new List<Option>
                        {
                            new Option { Content = ">", IsCorrect = false },
                            new Option { Content = "<", IsCorrect = true },
                            new Option { Content = "=", IsCorrect = false },
                        }
                    }
                }
            },
            new Entities.Quiz
            {
                Title = "Math grade 3",
                Cover = "https://quizizz.com/media/resource/gs/quizizz-media/quizzes/cacd1311-e0a2-41ba-85bd-309e1d3474a6?w=200&h=200",
                Description = "Learn the basics of chemistry",
                SubjectId = Guid.Parse("59820f61-ada9-44e8-9a45-790981fe05f0"),
                GradeId = Guid.Parse("fe1ab3da-f5d9-4b63-ba57-3dbc14a9a82b"),
                LanguageId = Guid.Parse("d9789c96-e0c8-4826-81b3-0eccd22d3508"),
                OwnerId = "ea616dc0-e621-474e-a247-b823b9fe6004",
                Visibility = Visibility.Public,
                IsPublished = true,
                Code = "WERWER",
                Questions = new List<Question>
                {
                    new Question
                    {
                        Content = "Calculate the value of the expression: 8635kg - 783kg x 4",
                        Duration = 30,
                        Points = 1,
                        Type = QuestionType.MultipleChoice,
                        Order = 1,
                        Options = new List<Option>
                        {
                            new Option { Content = "3408kg", IsCorrect = false },
                            new Option { Content = "5503kg", IsCorrect = true },
                            new Option { Content = "5503", IsCorrect = true },
                            new Option { Content = "3408", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "When dividing a two-digit number by 8, the quotient is 5 and the remainder is 6. What is the dividend?",
                        Duration = 30,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 2,
                        Options = new List<Option>
                        {
                            new Option { Content = "50", IsCorrect = false },
                            new Option { Content = "240", IsCorrect = false },
                            new Option { Content = "200", IsCorrect = false },
                            new Option { Content = "46", IsCorrect = true }
                        }
                    },
                    new Question
                    {
                        Content = "What is the remainder when 358 is divided by 5?",
                        Duration = 30,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 3,
                        Options = new List<Option>
                        {
                            new Option { Content = "3", IsCorrect = true },
                            new Option { Content = "5", IsCorrect = false },
                            new Option { Content = "8", IsCorrect = false },
                            new Option { Content = "7", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "A rectangle has a length of 124 cm and a width of 86 cm. What is its perimeter?",
                        Duration = 30,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 4,
                        Options = new List<Option>
                        {
                            new Option { Content = "105 cm", IsCorrect = false },
                            new Option { Content = "210 cm", IsCorrect = false },
                            new Option { Content = "420 cm", IsCorrect = true },
                            new Option { Content = "110 cm", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "Fill in the appropriate symbol for the comparison: 1234 x 2 .... 1234 x 3",
                        Duration = 30,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 5,
                        Options = new List<Option>
                        {
                            new Option { Content = ">", IsCorrect = false },
                            new Option { Content = "<", IsCorrect = true },
                            new Option { Content = "=", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "A transport company has 4 teams of vehicles. The first team has 10 cars, and each of the remaining 3 teams has 9 cars. How many cars does the company have?",
                        Duration = 30,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 6,
                        Options = new List<Option>
                        {
                            new Option { Content = "40", IsCorrect = false },
                            new Option { Content = "55", IsCorrect = false },
                            new Option { Content = "37", IsCorrect = true },
                            new Option { Content = "89", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "A container initially holds 36 liters of oil. After usage, the remaining oil is 1/3 of the initial amount. How many liters of oil remain in the container?",
                        Duration = 30,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 7,
                        Options = new List<Option>
                        {
                            new Option { Content = "17", IsCorrect = false },
                            new Option { Content = "20", IsCorrect = false },
                            new Option { Content = "12", IsCorrect = true },
                            new Option { Content = "35", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "Class 3A plants 42 trees, and Class 3B plants 4 times the number of trees Class 3A plants. How many trees do both classes plant together?",
                        Duration = 30,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 8,
                        Options = new List<Option>
                        {
                            new Option { Content = "210", IsCorrect = true },
                            new Option { Content = "265", IsCorrect = false },
                            new Option { Content = "42", IsCorrect = false },
                            new Option { Content = "267", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "What is the value of the expression 840 ÷ (2 + 2)?",
                        Duration = 30,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 9,
                        Options = new List<Option>
                        {
                            new Option { Content = "210", IsCorrect = true },
                            new Option { Content = "201", IsCorrect = false },
                            new Option { Content = "220", IsCorrect = false },
                            new Option { Content = "120", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "Solve the equation x ÷ 5 = 83. What is the value of x?",
                        Duration = 30,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 10,
                        Options = new List<Option>
                        {
                            new Option { Content = "415", IsCorrect = true },
                            new Option { Content = "416", IsCorrect = false },
                            new Option { Content = "16", IsCorrect = false },
                            new Option { Content = "16,6", IsCorrect = false }
                        }
                    }
                }
            },
            new Entities.Quiz
            {
                Title = "Basic English",
                Cover = "https://quizizz.com/media/resource/gs/quizizz-media/quizzes/ed713aa3-7040-4a1d-98b6-833d6f9726e8?w=200&h=200",
                Description = "Learn the basics of english",
                SubjectId = Guid.Parse("f9c0f102-9fab-4f11-a76c-33efd4439af0"),
                GradeId = Guid.Parse("953829bd-5e12-4799-8bd3-3d78d0507097"),
                LanguageId = Guid.Parse("d9789c96-e0c8-4826-81b3-0eccd22d3508"),
                OwnerId = "ea616dc0-e621-474e-a247-b823b9fe6004",
                Visibility = Visibility.Public,
                IsPublished = true,
                Code = "XCVXCV",
                Questions = new List<Question>
                {
                    new Question
                    {
                        Content = "What is the plural form of 'child'?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 1,
                        Options = new List<Option>
                        {
                            new Option { Content = "Children", IsCorrect = true },
                            new Option { Content = "Childs", IsCorrect = false },
                            new Option { Content = "Childes", IsCorrect = false },
                            new Option { Content = "Childer", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "Which of the following is the correct past tense of 'go'?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 2,
                        Options = new List<Option>
                        {
                            new Option { Content = "Went", IsCorrect = true },
                            new Option { Content = "Goned", IsCorrect = false },
                            new Option { Content = "Gone", IsCorrect = false },
                            new Option { Content = "Going", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "Which word is an antonym of 'happy'?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 3,
                        Options = new List<Option>
                        {
                            new Option { Content = "Sad", IsCorrect = true },
                            new Option { Content = "Excited", IsCorrect = false },
                            new Option { Content = "Delighted", IsCorrect = false },
                            new Option { Content = "Glad", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "Which sentence is in the passive voice?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 4,
                        Options = new List<Option>
                        {
                            new Option { Content = "The book was read by Sarah.", IsCorrect = true },
                            new Option { Content = "Sarah reads the book.", IsCorrect = false },
                            new Option { Content = "Sarah is reading the book.", IsCorrect = false },
                            new Option { Content = "Sarah has read the book.", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "What is the comparative form of 'good'?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 5,
                        Options = new List<Option>
                        {
                            new Option { Content = "Better", IsCorrect = true },
                            new Option { Content = "Gooder", IsCorrect = false },
                            new Option { Content = "Best", IsCorrect = false },
                            new Option { Content = "Goodest", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "What does the word 'benevolent' mean?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 6,
                        Options = new List<Option>
                        {
                            new Option { Content = "Kind and generous", IsCorrect = true },
                            new Option { Content = "Evil and harmful", IsCorrect = false },
                            new Option { Content = "Lazy and uninterested", IsCorrect = false },
                            new Option { Content = "Greedy and selfish", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "Which word is a synonym of 'intelligent'?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 7,
                        Options = new List<Option>
                        {
                            new Option { Content = "Smart", IsCorrect = true },
                            new Option { Content = "Dumb", IsCorrect = false },
                            new Option { Content = "Slow", IsCorrect = false },
                            new Option { Content = "Boring", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "What is the correct way to ask for the time?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 8,
                        Options = new List<Option>
                        {
                            new Option { Content = "What time is it?", IsCorrect = true },
                            new Option { Content = "When is the time?", IsCorrect = false },
                            new Option { Content = "How is the time?", IsCorrect = false },
                            new Option { Content = "What the time?", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "Which of the following sentences is grammatically correct?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 9,
                        Options = new List<Option>
                        {
                            new Option { Content = "She has been working all day.", IsCorrect = true },
                            new Option { Content = "She worked all day has been.", IsCorrect = false },
                            new Option { Content = "She working has been all day.", IsCorrect = false },
                            new Option { Content = "She had been working all day.", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "Which of these is an example of a compound sentence?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 10,
                        Options = new List<Option>
                        {
                            new Option { Content = "I wanted to go to the store, but it was closed.", IsCorrect = true },
                            new Option { Content = "I wanted to go to the store.", IsCorrect = false },
                            new Option { Content = "I went to the store.", IsCorrect = false },
                            new Option { Content = "It was closed.", IsCorrect = false }
                        }
                    }
                }
            },
            new Entities.Quiz
            {
                Title = "Basic English 2",
                Cover = "https://quizizz.com/media/resource/gs/quizizz-media/quizzes/ed713aa3-7040-4a1d-98b6-833d6f9726e8?w=200&h=200",
                Description = "Learn the basics of english",
                SubjectId = Guid.Parse("f9c0f102-9fab-4f11-a76c-33efd4439af0"),
                GradeId = Guid.Parse("953829bd-5e12-4799-8bd3-3d78d0507097"),
                LanguageId = Guid.Parse("d9789c96-e0c8-4826-81b3-0eccd22d3508"),
                OwnerId = "ea616dc0-e621-474e-a247-b823b9fe6004",
                Visibility = Visibility.Public,
                IsPublished = true,
                Code = "QAZQAZ",
                Questions = new List<Question>
                {
                    new Question
                    {
                        Content = "Which of the following is the correct spelling?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 1,
                        Options = new List<Option>
                        {
                            new Option { Content = "Necessary", IsCorrect = true },
                            new Option { Content = "Neccessary", IsCorrect = false },
                            new Option { Content = "Nessary", IsCorrect = false },
                            new Option { Content = "Necessery", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "What is the opposite of 'arrive'?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 2,
                        Options = new List<Option>
                        {
                            new Option { Content = "Depart", IsCorrect = true },
                            new Option { Content = "Stay", IsCorrect = false },
                            new Option { Content = "Come", IsCorrect = false },
                            new Option { Content = "Go", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "What does the word 'altruistic' mean?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 3,
                        Options = new List<Option>
                        {
                            new Option { Content = "Selfless", IsCorrect = true },
                            new Option { Content = "Greedy", IsCorrect = false },
                            new Option { Content = "Lazy", IsCorrect = false },
                            new Option { Content = "Honest", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "Which of these is an example of a conjunction?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 4,
                        Options = new List<Option>
                        {
                            new Option { Content = "But", IsCorrect = true },
                            new Option { Content = "Happy", IsCorrect = false },
                            new Option { Content = "Run", IsCorrect = false },
                            new Option { Content = "Book", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "What is the superlative form of 'bad'?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 5,
                        Options = new List<Option>
                        {
                            new Option { Content = "Worst", IsCorrect = true },
                            new Option { Content = "Badder", IsCorrect = false },
                            new Option { Content = "Baddest", IsCorrect = false },
                            new Option { Content = "More bad", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "Which of the following words is a noun?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 6,
                        Options = new List<Option>
                        {
                            new Option { Content = "Book", IsCorrect = true },
                            new Option { Content = "Run", IsCorrect = false },
                            new Option { Content = "Quickly", IsCorrect = false },
                            new Option { Content = "Sing", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "Which sentence is correct?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 7,
                        Options = new List<Option>
                        {
                            new Option { Content = "He has been studying English for five years.", IsCorrect = true },
                            new Option { Content = "He studied English for five years.", IsCorrect = false },
                            new Option { Content = "He study English for five years.", IsCorrect = false },
                            new Option { Content = "He was study English for five years.", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "What is the past tense of 'eat'?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 8,
                        Options = new List<Option>
                        {
                            new Option { Content = "Ate", IsCorrect = true },
                            new Option { Content = "Eated", IsCorrect = false },
                            new Option { Content = "Eaten", IsCorrect = false },
                            new Option { Content = "Eating", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "Which of the following is a synonym of 'brave'?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 9,
                        Options = new List<Option>
                        {
                            new Option { Content = "Courageous", IsCorrect = true },
                            new Option { Content = "Afraid", IsCorrect = false },
                            new Option { Content = "Shy", IsCorrect = false },
                            new Option { Content = "Weak", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "Which of these sentences uses the word 'literally' correctly?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 10,
                        Options = new List<Option>
                        {
                            new Option { Content = "He was literally jumping with joy.", IsCorrect = true },
                            new Option { Content = "He literally jumped the fence.", IsCorrect = false },
                            new Option { Content = "He literally ran faster than the speed of light.", IsCorrect = false },
                            new Option { Content = "The car literally flew into the sky.", IsCorrect = false }
                        }
                    }
                }
            },
            new Entities.Quiz
            {
                Title = "Introduction to Geography",
                Cover = "https://quizizz.com/media/resource/gs/quizizz-media/quizzes/6da8c5e8-8182-430e-b32b-317746c72632?w=200&h=200",
                Description = "Learn the basics of Geography",
                SubjectId = Guid.Parse("deb9e2f7-6c42-43bd-a675-bf5f59b9f821"),
                GradeId = Guid.Parse("45304ba8-da09-46b9-8400-d5b7a7bb718e"),
                LanguageId = Guid.Parse("d9789c96-e0c8-4826-81b3-0eccd22d3508"),
                OwnerId = "ea616dc0-e621-474e-a247-b823b9fe6004",
                Visibility = Visibility.Public,
                IsPublished = true,
                Code = "QAXQAX",
                Questions = new List<Question>
                {
                    new Question
                    {
                        Content = "What is the capital city of France?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 1,
                        Options = new List<Option>
                        {
                            new Option { Content = "Paris", IsCorrect = true },
                            new Option { Content = "Lyon", IsCorrect = false },
                            new Option { Content = "Marseille", IsCorrect = false },
                            new Option { Content = "Nice", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "Which continent is known as the 'Frozen Continent'?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 2,
                        Options = new List<Option>
                        {
                            new Option { Content = "Antarctica", IsCorrect = true },
                            new Option { Content = "Europe", IsCorrect = false },
                            new Option { Content = "North America", IsCorrect = false },
                            new Option { Content = "Asia", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "What is the longest river in the world?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 3,
                        Options = new List<Option>
                        {
                            new Option { Content = "Nile", IsCorrect = true },
                            new Option { Content = "Amazon", IsCorrect = false },
                            new Option { Content = "Yangtze", IsCorrect = false },
                            new Option { Content = "Mississippi", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "Which is the largest ocean on Earth?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 4,
                        Options = new List<Option>
                        {
                            new Option { Content = "Pacific Ocean", IsCorrect = true },
                            new Option { Content = "Atlantic Ocean", IsCorrect = false },
                            new Option { Content = "Indian Ocean", IsCorrect = false },
                            new Option { Content = "Arctic Ocean", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "What is the smallest country in the world?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 5,
                        Options = new List<Option>
                        {
                            new Option { Content = "Vatican City", IsCorrect = true },
                            new Option { Content = "Monaco", IsCorrect = false },
                            new Option { Content = "San Marino", IsCorrect = false },
                            new Option { Content = "Liechtenstein", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "Which desert is the largest in the world?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 6,
                        Options = new List<Option>
                        {
                            new Option { Content = "Sahara", IsCorrect = true },
                            new Option { Content = "Arabian", IsCorrect = false },
                            new Option { Content = "Gobi", IsCorrect = false },
                            new Option { Content = "Kalahari", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "Which country has the largest population?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 7,
                        Options = new List<Option>
                        {
                            new Option { Content = "China", IsCorrect = true },
                            new Option { Content = "India", IsCorrect = false },
                            new Option { Content = "United States", IsCorrect = false },
                            new Option { Content = "Indonesia", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "Which mountain range is home to Mount Everest?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 8,
                        Options = new List<Option>
                        {
                            new Option { Content = "Himalayas", IsCorrect = true },
                            new Option { Content = "Andes", IsCorrect = false },
                            new Option { Content = "Rockies", IsCorrect = false },
                            new Option { Content = "Alps", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "Which country is known as the 'Land of the Rising Sun'?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 9,
                        Options = new List<Option>
                        {
                            new Option { Content = "Japan", IsCorrect = true },
                            new Option { Content = "China", IsCorrect = false },
                            new Option { Content = "South Korea", IsCorrect = false },
                            new Option { Content = "Thailand", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "What is the largest island in the world?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 10,
                        Options = new List<Option>
                        {
                            new Option { Content = "Greenland", IsCorrect = true },
                            new Option { Content = "Australia", IsCorrect = false },
                            new Option { Content = "New Guinea", IsCorrect = false },
                            new Option { Content = "Borneo", IsCorrect = false }
                        }
                    }
                }
            },
            new Entities.Quiz
            {
                Title = "Introduction to Geography 2",
                Cover = "https://media.quizizz.com/_mdserver/main/media/resource/gs/quizizz-media/quizzes/6682d09a-bf50-4ec9-900d-975bc235a631-v2?w=200&h=200",
                Description = "Learn the basics of Geography",
                SubjectId = Guid.Parse("deb9e2f7-6c42-43bd-a675-bf5f59b9f821"),
                GradeId = Guid.Parse("45304ba8-da09-46b9-8400-d5b7a7bb718e"),
                LanguageId = Guid.Parse("d9789c96-e0c8-4826-81b3-0eccd22d3508"),
                OwnerId = "ea616dc0-e621-474e-a247-b823b9fe6004",
                Visibility = Visibility.Public,
                IsPublished = true,
                Code = "QACQAC",
                Questions = new List<Question>
                {
                    new Question
                    {
                        Content = "Which country has the largest land area in the world?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 1,
                        Options = new List<Option>
                        {
                            new Option { Content = "Russia", IsCorrect = true },
                            new Option { Content = "Canada", IsCorrect = false },
                            new Option { Content = "United States", IsCorrect = false },
                            new Option { Content = "China", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "Which U.S. state is known as the 'Sunshine State'?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 2,
                        Options = new List<Option>
                        {
                            new Option { Content = "Florida", IsCorrect = true },
                            new Option { Content = "California", IsCorrect = false },
                            new Option { Content = "Texas", IsCorrect = false },
                            new Option { Content = "Hawaii", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "What is the name of the imaginary line that divides the Earth into Northern and Southern Hemispheres?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 3,
                        Options = new List<Option>
                        {
                            new Option { Content = "Equator", IsCorrect = true },
                            new Option { Content = "Prime Meridian", IsCorrect = false },
                            new Option { Content = "Tropic of Cancer", IsCorrect = false },
                            new Option { Content = "Tropic of Capricorn", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "Which country is famous for its pyramids and the Sphinx?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 4,
                        Options = new List<Option>
                        {
                            new Option { Content = "Egypt", IsCorrect = true },
                            new Option { Content = "Greece", IsCorrect = false },
                            new Option { Content = "Mexico", IsCorrect = false },
                            new Option { Content = "India", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "Which river flows through the city of London?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 5,
                        Options = new List<Option>
                        {
                            new Option { Content = "Thames", IsCorrect = true },
                            new Option { Content = "Seine", IsCorrect = false },
                            new Option { Content = "Danube", IsCorrect = false },
                            new Option { Content = "Rhine", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "Which country is home to the Great Barrier Reef?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 6,
                        Options = new List<Option>
                        {
                            new Option { Content = "Australia", IsCorrect = true },
                            new Option { Content = "New Zealand", IsCorrect = false },
                            new Option { Content = "Indonesia", IsCorrect = false },
                            new Option { Content = "Fiji", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "What is the smallest continent by land area?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 7,
                        Options = new List<Option>
                        {
                            new Option { Content = "Australia", IsCorrect = true },
                            new Option { Content = "Europe", IsCorrect = false },
                            new Option { Content = "Antarctica", IsCorrect = false },
                            new Option { Content = "South America", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "Which African country is known as the 'Rainbow Nation'?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 8,
                        Options = new List<Option>
                        {
                            new Option { Content = "South Africa", IsCorrect = true },
                            new Option { Content = "Kenya", IsCorrect = false },
                            new Option { Content = "Nigeria", IsCorrect = false },
                            new Option { Content = "Egypt", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "What is the capital city of Japan?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 9,
                        Options = new List<Option>
                        {
                            new Option { Content = "Tokyo", IsCorrect = true },
                            new Option { Content = "Osaka", IsCorrect = false },
                            new Option { Content = "Kyoto", IsCorrect = false },
                            new Option { Content = "Nagoya", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "Which country shares the longest border with the United States?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 10,
                        Options = new List<Option>
                        {
                            new Option { Content = "Canada", IsCorrect = true },
                            new Option { Content = "Mexico", IsCorrect = false },
                            new Option { Content = "Russia", IsCorrect = false },
                            new Option { Content = "Cuba", IsCorrect = false }
                        }
                    }
                }

            },
            new Entities.Quiz
            {
                Title = "Introduction to Chemistry",
                Cover = "https://quizizz.com/media/resource/gs/quizizz-media/quizzes/e69c1c65-8fad-4d7a-93c9-999a618f98f2?w=200&h=200",
                Description = "Learn the basics of chemistry",
                SubjectId = Guid.Parse("048d1a67-4ced-4189-85e6-c2803577f040"),
                GradeId = Guid.Parse("f2fe3f16-41f4-43da-b253-14873bb07100"),
                LanguageId = Guid.Parse("d9789c96-e0c8-4826-81b3-0eccd22d3508"),
                OwnerId = "ea616dc0-e621-474e-a247-b823b9fe6004",
                Visibility = Visibility.Public,
                IsPublished = true,
                Code = "QSZQSZ",
                Questions = new List<Question>
                {
                    new Question
                    {
                        Content = "What is the chemical symbol for water?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 1,
                        Options = new List<Option>
                        {
                            new Option { Content = "H2O", IsCorrect = true },
                            new Option { Content = "HO2", IsCorrect = false },
                            new Option { Content = "O2H", IsCorrect = false },
                            new Option { Content = "H2", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "What is the atomic number of hydrogen?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 2,
                        Options = new List<Option>
                        {
                            new Option { Content = "1", IsCorrect = true },
                            new Option { Content = "2", IsCorrect = false },
                            new Option { Content = "3", IsCorrect = false },
                            new Option { Content = "4", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "What is the most abundant gas in Earth’s atmosphere?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 3,
                        Options = new List<Option>
                        {
                            new Option { Content = "Nitrogen", IsCorrect = true },
                            new Option { Content = "Oxygen", IsCorrect = false },
                            new Option { Content = "Carbon Dioxide", IsCorrect = false },
                            new Option { Content = "Hydrogen", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "Which subatomic particle has a positive charge?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 4,
                        Options = new List<Option>
                        {
                            new Option { Content = "Proton", IsCorrect = true },
                            new Option { Content = "Electron", IsCorrect = false },
                            new Option { Content = "Neutron", IsCorrect = false },
                            new Option { Content = "Photon", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "What is the pH value of a neutral substance like pure water?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 5,
                        Options = new List<Option>
                        {
                            new Option { Content = "7", IsCorrect = true },
                            new Option { Content = "0", IsCorrect = false },
                            new Option { Content = "14", IsCorrect = false },
                            new Option { Content = "1", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "Which element is commonly known as the 'King of Chemicals'?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 6,
                        Options = new List<Option>
                        {
                            new Option { Content = "Sulfuric Acid (H2SO4)", IsCorrect = true },
                            new Option { Content = "Hydrochloric Acid (HCl)", IsCorrect = false },
                            new Option { Content = "Nitric Acid (HNO3)", IsCorrect = false },
                            new Option { Content = "Acetic Acid (CH3COOH)", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "What is the chemical formula for table salt?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 7,
                        Options = new List<Option>
                        {
                            new Option { Content = "NaCl", IsCorrect = true },
                            new Option { Content = "KCl", IsCorrect = false },
                            new Option { Content = "CaCl2", IsCorrect = false },
                            new Option { Content = "MgCl2", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "Which element is represented by the symbol 'O'?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 8,
                        Options = new List<Option>
                        {
                            new Option { Content = "Oxygen", IsCorrect = true },
                            new Option { Content = "Osmium", IsCorrect = false },
                            new Option { Content = "Oxide", IsCorrect = false },
                            new Option { Content = "Oganesson", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "What type of bond is formed when two atoms share electrons?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 9,
                        Options = new List<Option>
                        {
                            new Option { Content = "Covalent Bond", IsCorrect = true },
                            new Option { Content = "Ionic Bond", IsCorrect = false },
                            new Option { Content = "Hydrogen Bond", IsCorrect = false },
                            new Option { Content = "Metallic Bond", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "Which element is the main component of diamonds?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 10,
                        Options = new List<Option>
                        {
                            new Option { Content = "Carbon", IsCorrect = true },
                            new Option { Content = "Silicon", IsCorrect = false },
                            new Option { Content = "Graphite", IsCorrect = false },
                            new Option { Content = "Boron", IsCorrect = false }
                        }
                    }
                }

            },
            new Entities.Quiz
            {
                Title = "Introduction to Chemistry 2",
                Cover = "https://quizizz.com/media/resource/gs/quizizz-media/quizzes/6cec8a67-8bf1-474d-addb-625792d74819?w=200&h=200",
                Description = "Learn the basics of chemistry",
                SubjectId = Guid.Parse("048d1a67-4ced-4189-85e6-c2803577f040"),
                GradeId = Guid.Parse("f2fe3f16-41f4-43da-b253-14873bb07100"),
                LanguageId = Guid.Parse("d9789c96-e0c8-4826-81b3-0eccd22d3508"),
                OwnerId = "ea616dc0-e621-474e-a247-b823b9fe6004",
                Visibility = Visibility.Public,
                IsPublished = true, 
                Code = "QSXQSX",
                Questions = new List<Question>
                {
                    new Question
                    {
                        Content = "What is the most abundant element in the universe?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 1,
                        Options = new List<Option>
                        {
                            new Option { Content = "Hydrogen", IsCorrect = true },
                            new Option { Content = "Helium", IsCorrect = false },
                            new Option { Content = "Oxygen", IsCorrect = false },
                            new Option { Content = "Carbon", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "What is the periodic table symbol for gold?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 2,
                        Options = new List<Option>
                        {
                            new Option { Content = "Au", IsCorrect = true },
                            new Option { Content = "Ag", IsCorrect = false },
                            new Option { Content = "Pb", IsCorrect = false },
                            new Option { Content = "Fe", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "Which scientist is credited with creating the periodic table?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 3,
                        Options = new List<Option>
                        {
                            new Option { Content = "Dmitri Mendeleev", IsCorrect = true },
                            new Option { Content = "Marie Curie", IsCorrect = false },
                            new Option { Content = "John Dalton", IsCorrect = false },
                            new Option { Content = "Isaac Newton", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "What is the pH value of a strong acid?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 4,
                        Options = new List<Option>
                        {
                            new Option { Content = "Less than 7", IsCorrect = true },
                            new Option { Content = "7", IsCorrect = false },
                            new Option { Content = "More than 7", IsCorrect = false },
                            new Option { Content = "14", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "What is the chemical formula for carbon dioxide?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 5,
                        Options = new List<Option>
                        {
                            new Option { Content = "CO2", IsCorrect = true },
                            new Option { Content = "CO", IsCorrect = false },
                            new Option { Content = "C2O", IsCorrect = false },
                            new Option { Content = "C3O2", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "Which gas is known as a greenhouse gas?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 6,
                        Options = new List<Option>
                        {
                            new Option { Content = "Carbon Dioxide", IsCorrect = true },
                            new Option { Content = "Oxygen", IsCorrect = false },
                            new Option { Content = "Nitrogen", IsCorrect = false },
                            new Option { Content = "Helium", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "What is the charge of an electron?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 7,
                        Options = new List<Option>
                        {
                            new Option { Content = "Negative", IsCorrect = true },
                            new Option { Content = "Positive", IsCorrect = false },
                            new Option { Content = "Neutral", IsCorrect = false },
                            new Option { Content = "Varies", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "Which element is liquid at room temperature?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 8,
                        Options = new List<Option>
                        {
                            new Option { Content = "Mercury", IsCorrect = true },
                            new Option { Content = "Iron", IsCorrect = false },
                            new Option { Content = "Gold", IsCorrect = false },
                            new Option { Content = "Aluminum", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "What type of reaction involves the combination of two or more substances to form one product?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 9,
                        Options = new List<Option>
                        {
                            new Option { Content = "Synthesis Reaction", IsCorrect = true },
                            new Option { Content = "Decomposition Reaction", IsCorrect = false },
                            new Option { Content = "Combustion Reaction", IsCorrect = false },
                            new Option { Content = "Neutralization Reaction", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "Which element is the lightest and first in the periodic table?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 10,
                        Options = new List<Option>
                        {
                            new Option { Content = "Hydrogen", IsCorrect = true },
                            new Option { Content = "Helium", IsCorrect = false },
                            new Option { Content = "Lithium", IsCorrect = false },
                            new Option { Content = "Beryllium", IsCorrect = false }
                        }
                    }
                }

            },
            new Entities.Quiz
            {
                Title = "Introduction to VietNam history",
                Cover = "https://quizizz.com/media/resource/gs/quizizz-media/quizzes/71cb4af4-3149-4bf3-a7ce-1038b4f732ea?w=200&h=200",
                Description = "Learn the basics of VietNam history",
                SubjectId = Guid.Parse("d34d0164-6d96-4e58-b732-abbc35ce4d28"),
                GradeId = Guid.Parse("ccc9fa86-9ba3-438a-8930-8db470ed6d15"),
                LanguageId = Guid.Parse("d9789c96-e0c8-4826-81b3-0eccd22d3508"),
                OwnerId = "ea616dc0-e621-474e-a247-b823b9fe6004",
                Visibility = Visibility.Public,
                IsPublished = true,
                Code = "QSCQSC",
                Questions = new List<Question>
                {
                    new Question
                    {
                        Content = "When did Vietnam gain independence from French colonial rule?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 1,
                        Options = new List<Option>
                        {
                            new Option { Content = "1954", IsCorrect = true },
                            new Option { Content = "1945", IsCorrect = false },
                            new Option { Content = "1975", IsCorrect = false },
                            new Option { Content = "1968", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "Who was the leader of the Vietnamese independence movement against French colonialism?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 2,
                        Options = new List<Option>
                        {
                            new Option { Content = "Ho Chi Minh", IsCorrect = true },
                            new Option { Content = "Ngo Dinh Diem", IsCorrect = false },
                            new Option { Content = "Pham Van Dong", IsCorrect = false },
                            new Option { Content = "Vo Nguyen Giap", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "What is the name of the ancient kingdom that existed in central Vietnam from the 2nd to the 15th century?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 3,
                        Options = new List<Option>
                        {
                            new Option { Content = "Champa", IsCorrect = true },
                            new Option { Content = "Dai Viet", IsCorrect = false },
                            new Option { Content = "Nam Viet", IsCorrect = false },
                            new Option { Content = "Tonkin", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "Which battle in 1954 marked the decisive victory of Vietnamese forces over the French?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 4,
                        Options = new List<Option>
                        {
                            new Option { Content = "Battle of Dien Bien Phu", IsCorrect = true },
                            new Option { Content = "Tet Offensive", IsCorrect = false },
                            new Option { Content = "Battle of Hue", IsCorrect = false },
                            new Option { Content = "Fall of Saigon", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "What event marked the reunification of North and South Vietnam?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 5,
                        Options = new List<Option>
                        {
                            new Option { Content = "Fall of Saigon in 1975", IsCorrect = true },
                            new Option { Content = "Geneva Accords in 1954", IsCorrect = false },
                            new Option { Content = "Paris Peace Accords in 1973", IsCorrect = false },
                            new Option { Content = "Tet Offensive in 1968", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "Which empire ruled Vietnam during the 19th and early 20th centuries?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 6,
                        Options = new List<Option>
                        {
                            new Option { Content = "French Empire", IsCorrect = true },
                            new Option { Content = "Ming Dynasty", IsCorrect = false },
                            new Option { Content = "Japanese Empire", IsCorrect = false },
                            new Option { Content = "Mongol Empire", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "What dynasty ruled Vietnam during its golden age of Confucian culture?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 7,
                        Options = new List<Option>
                        {
                            new Option { Content = "Nguyen Dynasty", IsCorrect = false },
                            new Option { Content = "Tran Dynasty", IsCorrect = true },
                            new Option { Content = "Le Dynasty", IsCorrect = false },
                            new Option { Content = "Tay Son Dynasty", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "Who was the famous Vietnamese general who led the victory at Dien Bien Phu?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 8,
                        Options = new List<Option>
                        {
                            new Option { Content = "Vo Nguyen Giap", IsCorrect = true },
                            new Option { Content = "Ho Chi Minh", IsCorrect = false },
                            new Option { Content = "Ngo Dinh Diem", IsCorrect = false },
                            new Option { Content = "Pham Van Dong", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "What was the ancient name of Hanoi during the Ly Dynasty?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 9,
                        Options = new List<Option>
                        {
                            new Option { Content = "Thang Long", IsCorrect = true },
                            new Option { Content = "Dai Viet", IsCorrect = false },
                            new Option { Content = "Tonkin", IsCorrect = false },
                            new Option { Content = "Hoa Lu", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "What agreement in 1954 temporarily divided Vietnam along the 17th parallel?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 10,
                        Options = new List<Option>
                        {
                            new Option { Content = "Geneva Accords", IsCorrect = true },
                            new Option { Content = "Paris Peace Accords", IsCorrect = false },
                            new Option { Content = "Treaty of Saigon", IsCorrect = false },
                            new Option { Content = "Bangkok Declaration", IsCorrect = false }
                        }
                    }
                }
            },
            new Entities.Quiz
            {
                Title = "World War I",
                Cover = "https://media.quizizz.com/_mdserver/main/media/resource/gs/quizizz-media/quizzes/b7286c32-f7a1-44ad-a70e-e44730867c8a-v2?w=200&h=200",
                Description = "World War I",
                SubjectId = Guid.Parse("d34d0164-6d96-4e58-b732-abbc35ce4d28"),
                GradeId = Guid.Parse("ccc9fa86-9ba3-438a-8930-8db470ed6d15"),
                LanguageId = Guid.Parse("d9789c96-e0c8-4826-81b3-0eccd22d3508"),
                OwnerId = "ea616dc0-e621-474e-a247-b823b9fe6004",
                Visibility = Visibility.Public,
                IsPublished = true,
                Code = "QDZQDZ",
                Questions = new List<Question>
                {
                    new Question
                    {
                        Content = "Which event directly triggered the start of World War I?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 1,
                        Options = new List<Option>
                        {
                            new Option { Content = "Assassination of Archduke Franz Ferdinand", IsCorrect = true },
                            new Option { Content = "Invasion of Belgium", IsCorrect = false },
                            new Option { Content = "Zimmermann Telegram", IsCorrect = false },
                            new Option { Content = "Russian Revolution", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "Which countries made up the Triple Alliance during World War I?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 2,
                        Options = new List<Option>
                        {
                            new Option { Content = "Germany, Austria-Hungary, Italy", IsCorrect = true },
                            new Option { Content = "France, Russia, Britain", IsCorrect = false },
                            new Option { Content = "Germany, Austria-Hungary, Ottoman Empire", IsCorrect = false },
                            new Option { Content = "France, Italy, United States", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "Which country was the first to declare war in World War I?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 3,
                        Options = new List<Option>
                        {
                            new Option { Content = "Austria-Hungary", IsCorrect = true },
                            new Option { Content = "Germany", IsCorrect = false },
                            new Option { Content = "Russia", IsCorrect = false },
                            new Option { Content = "France", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "Who was the leader of Germany during World War I?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 4,
                        Options = new List<Option>
                        {
                            new Option { Content = "Kaiser Wilhelm II", IsCorrect = true },
                            new Option { Content = "Adolf Hitler", IsCorrect = false },
                            new Option { Content = "Otto von Bismarck", IsCorrect = false },
                            new Option { Content = "Erich Ludendorff", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "Which battle is considered the largest and bloodiest of World War I?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 5,
                        Options = new List<Option>
                        {
                            new Option { Content = "Battle of the Somme", IsCorrect = true },
                            new Option { Content = "Battle of Verdun", IsCorrect = false },
                            new Option { Content = "Battle of Tannenberg", IsCorrect = false },
                            new Option { Content = "Battle of Gallipoli", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "Which country joined the Allies in World War I in 1917, tipping the balance in favor of the Allies?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 6,
                        Options = new List<Option>
                        {
                            new Option { Content = "United States", IsCorrect = true },
                            new Option { Content = "Italy", IsCorrect = false },
                            new Option { Content = "Japan", IsCorrect = false },
                            new Option { Content = "Romania", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "What was the name of the treaty that ended World War I?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 7,
                        Options = new List<Option>
                        {
                            new Option { Content = "Treaty of Versailles", IsCorrect = true },
                            new Option { Content = "Treaty of Paris", IsCorrect = false },
                            new Option { Content = "Treaty of Trianon", IsCorrect = false },
                            new Option { Content = "Treaty of Brest-Litovsk", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "Which empire collapsed after World War I, leading to the creation of new countries in Eastern Europe?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 8,
                        Options = new List<Option>
                        {
                            new Option { Content = "Austro-Hungarian Empire", IsCorrect = true },
                            new Option { Content = "Ottoman Empire", IsCorrect = false },
                            new Option { Content = "Russian Empire", IsCorrect = false },
                            new Option { Content = "British Empire", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "What was the primary cause of the U.S. joining World War I?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 9,
                        Options = new List<Option>
                        {
                            new Option { Content = "Zimmermann Telegram", IsCorrect = true },
                            new Option { Content = "Sinking of the Lusitania", IsCorrect = false },
                            new Option { Content = "Invasion of Belgium", IsCorrect = false },
                            new Option { Content = "Russian Revolution", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "Which new technology was introduced during World War I, contributing to the high casualties?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 10,
                        Options = new List<Option>
                        {
                            new Option { Content = "Machine Guns", IsCorrect = true },
                            new Option { Content = "Tanks", IsCorrect = false },
                            new Option { Content = "Submarines", IsCorrect = false },
                            new Option { Content = "Nuclear Weapons", IsCorrect = false }
                        }
                    }
                }
            },
            new Entities.Quiz
            {
                Title = "World War II",
                Cover = "https://media.quizizz.com/_mdserver/main/media/resource/gs/quizizz-media/quizzes/b7286c32-f7a1-44ad-a70e-e44730867c8a-v2?w=200&h=200",
                Description = "World War II",
                SubjectId = Guid.Parse("d34d0164-6d96-4e58-b732-abbc35ce4d28"),
                GradeId = Guid.Parse("ccc9fa86-9ba3-438a-8930-8db470ed6d15"),
                LanguageId = Guid.Parse("d9789c96-e0c8-4826-81b3-0eccd22d3508"),
                OwnerId = "ea616dc0-e621-474e-a247-b823b9fe6004",
                Visibility = Visibility.Public,
                IsPublished = true,
                Code = "QDCQDC",
                Questions = new List<Question>
                {
                    new Question
                    {
                        Content = "What event directly triggered the start of World War II?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 1,
                        Options = new List<Option>
                        {
                            new Option { Content = "Invasion of Poland by Germany", IsCorrect = true },
                            new Option { Content = "Attack on Pearl Harbor", IsCorrect = false },
                            new Option { Content = "Battle of Britain", IsCorrect = false },
                            new Option { Content = "Signing of the Treaty of Versailles", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "Which countries were part of the Axis Powers during World War II?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 2,
                        Options = new List<Option>
                        {
                            new Option { Content = "Germany, Italy, Japan", IsCorrect = true },
                            new Option { Content = "France, Britain, Soviet Union", IsCorrect = false },
                            new Option { Content = "Germany, France, Japan", IsCorrect = false },
                            new Option { Content = "United States, Britain, USSR", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "Who was the leader of Nazi Germany during World War II?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 3,
                        Options = new List<Option>
                        {
                            new Option { Content = "Adolf Hitler", IsCorrect = true },
                            new Option { Content = "Joseph Stalin", IsCorrect = false },
                            new Option { Content = "Benito Mussolini", IsCorrect = false },
                            new Option { Content = "Emperor Hirohito", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "Which battle is considered the turning point in the Pacific War during World War II?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 4,
                        Options = new List<Option>
                        {
                            new Option { Content = "Battle of Midway", IsCorrect = true },
                            new Option { Content = "Battle of Stalingrad", IsCorrect = false },
                            new Option { Content = "D-Day", IsCorrect = false },
                            new Option { Content = "Battle of the Bulge", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "What was the name of the secret project to develop the atomic bomb in the United States?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 5,
                        Options = new List<Option>
                        {
                            new Option { Content = "Manhattan Project", IsCorrect = true },
                            new Option { Content = "Operation Overlord", IsCorrect = false },
                            new Option { Content = "Project Hydra", IsCorrect = false },
                            new Option { Content = "Operation Barbarossa", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "Which country was invaded by Germany in 1941, leading to its entry into World War II?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 6,
                        Options = new List<Option>
                        {
                            new Option { Content = "Soviet Union", IsCorrect = true },
                            new Option { Content = "France", IsCorrect = false },
                            new Option { Content = "Poland", IsCorrect = false },
                            new Option { Content = "Norway", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "Where did the D-Day landings take place in 1944?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 7,
                        Options = new List<Option>
                        {
                            new Option { Content = "Normandy, France", IsCorrect = true },
                            new Option { Content = "Iwo Jima, Japan", IsCorrect = false },
                            new Option { Content = "Stalingrad, Soviet Union", IsCorrect = false },
                            new Option { Content = "El Alamein, Egypt", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "Which event led to the United States' entry into World War II?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 8,
                        Options = new List<Option>
                        {
                            new Option { Content = "Attack on Pearl Harbor", IsCorrect = true },
                            new Option { Content = "Invasion of France", IsCorrect = false },
                            new Option { Content = "Battle of Britain", IsCorrect = false },
                            new Option { Content = "Sinking of the Lusitania", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "Which major conference in 1945 resulted in agreements about the post-war order and the division of Germany?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 9,
                        Options = new List<Option>
                        {
                            new Option { Content = "Yalta Conference", IsCorrect = true },
                            new Option { Content = "Munich Conference", IsCorrect = false },
                            new Option { Content = "Paris Peace Talks", IsCorrect = false },
                            new Option { Content = "Treaty of Versailles", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "What was the name of the largest and deadliest concentration camp in Nazi Germany?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 10,
                        Options = new List<Option>
                        {
                            new Option { Content = "Auschwitz", IsCorrect = true },
                            new Option { Content = "Dachau", IsCorrect = false },
                            new Option { Content = "Treblinka", IsCorrect = false },
                            new Option { Content = "Buchenwald", IsCorrect = false }
                        }
                    }
                }
            },
            new Entities.Quiz
            {
                Title = "Introduction to programming",
                Cover = "https://quizizz.com/media/resource/gs/quizizz-media/quizzes/a456289c-1456-433d-aac7-46f224d7c1e2",
                Description = "Learn the basics of programming",
                SubjectId = Guid.Parse("2f921f98-5b80-4916-943c-31c6a88ca70e"),
                GradeId = Guid.Parse("e2cee932-4bce-40e5-b3be-16829008bb02"),
                LanguageId = Guid.Parse("d9789c96-e0c8-4826-81b3-0eccd22d3508"),
                OwnerId = "ea616dc0-e621-474e-a247-b823b9fe6004",
                Visibility = Visibility.Public,
                IsPublished = true,
                Code = "WAZWAZ",
                Questions = new List<Question>
                {
                    new Question
                    {
                        Content = "What is the only thing that computers understand?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 1,
                        Options = new List<Option>
                        {
                            new Option { Content = "Machine Code", IsCorrect = true },
                            new Option { Content = "Low Level Language", IsCorrect = false },
                            new Option { Content = "High Level Language", IsCorrect = false },
                            new Option { Content = "Algorithm", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "Before a computer can understand a program it must be...",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 2,
                        Options = new List<Option>
                        {
                            new Option { Content = "Translated into its machine code.", IsCorrect = true },
                            new Option { Content = "Translated into a high level language.", IsCorrect = false },
                            new Option { Content = "Translated into a low level language.", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "Java, Python, PHP, and C++ are examples of",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 3,
                        Options = new List<Option>
                        {
                            new Option { Content = "low level languages", IsCorrect = false },
                            new Option { Content = "Graphic arts languages", IsCorrect = false },
                            new Option { Content = "medium level languages", IsCorrect = false },
                            new Option { Content = "high level languages", IsCorrect = true }
                        }
                    },
                    new Question
                    {
                        Content = "What is machine code?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 4,
                        Options = new List<Option>
                        {
                            new Option { Content = "A programming language that a computer understands", IsCorrect = true },
                            new Option { Content = "The make and model of a computer", IsCorrect = false },
                            new Option { Content = "The serial number of a computer", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "Which language is directly understood by the computer without translation program?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 5,
                        Options = new List<Option>
                        {
                            new Option { Content = "BASIC", IsCorrect = false },
                            new Option { Content = "Assembly Language", IsCorrect = false },
                            new Option { Content = "Machine Language", IsCorrect = true },
                            new Option { Content = "C Language", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "Which of the following is not a high level programming language?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 6,
                        Options = new List<Option>
                        {
                            new Option { Content = "Assembly", IsCorrect = true },
                            new Option { Content = "C++", IsCorrect = false },
                            new Option { Content = "Java", IsCorrect = false },
                            new Option { Content = "Python", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "Which level of a programming language is Assembly Code?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 7,
                        Options = new List<Option>
                        {
                            new Option { Content = "Low", IsCorrect = true },
                            new Option { Content = "High", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "Which level would create the fastest code to execute?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 8,
                        Options = new List<Option>
                        {
                            new Option { Content = "Low", IsCorrect = true },
                            new Option { Content = "Assembly", IsCorrect = false },
                            new Option { Content = "High", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "Which level would create the easiest code for humans to understand?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 9,
                        Options = new List<Option>
                        {
                            new Option { Content = "Low", IsCorrect = false },
                            new Option { Content = "Assembly", IsCorrect = false },
                            new Option { Content = "High", IsCorrect = true }
                        }
                    },
                    new Question
                    {
                        Content = "Machine Code uses mnemonics to represent instructions",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 10,
                        Options = new List<Option>
                        {
                            new Option { Content = "True", IsCorrect = false },
                            new Option { Content = "False", IsCorrect = true }
                        }
                    }
                }
            },
            new Entities.Quiz
            {
                Title = "Software Engineering",
                Cover = "https://quizizz.com/media/resource/gs/quizizz-media/quizzes/4fe44387-e5e5-4d56-bdd8-3b2cd7e3df5b",
                Description = "Learn the basics of software engineering",
                SubjectId = Guid.Parse("2f921f98-5b80-4916-943c-31c6a88ca70e"),
                GradeId = Guid.Parse("45304ba8-da09-46b9-8400-d5b7a7bb718e"),
                LanguageId = Guid.Parse("d9789c96-e0c8-4826-81b3-0eccd22d3508"),
                OwnerId = "ea616dc0-e621-474e-a247-b823b9fe6004",
                Visibility = Visibility.Public,
                IsPublished = true,
                Code = "WAXWAX",
                Questions = new List<Question>
                {
                    new Question
                    {
                        Content = "Dependency models the _________ relationship",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 1,
                        Options = new List<Option>
                        {
                            new Option { Content = "has-a", IsCorrect = true },
                            new Option { Content = "is-a", IsCorrect = false },
                            new Option { Content = "uses-a", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "Interfaces model the _________ relationship",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 2,
                        Options = new List<Option>
                        {
                            new Option { Content = "has-a", IsCorrect = false },
                            new Option { Content = "is-a", IsCorrect = true },
                            new Option { Content = "uses-a", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "Aggregation models the _________ relationship",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 3,
                        Options = new List<Option>
                        {
                            new Option { Content = "has-a", IsCorrect = true },
                            new Option { Content = "is-a", IsCorrect = false },
                            new Option { Content = "uses-a", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "Inheritance models the _________ relationship",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 4,
                        Options = new List<Option>
                        {
                            new Option { Content = "has-a", IsCorrect = false },
                            new Option { Content = "is-a", IsCorrect = true },
                            new Option { Content = "uses-a", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "The analysis phase ____________________",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 5,
                        Options = new List<Option>
                        {
                            new Option { Content = "Determines what the program will do", IsCorrect = true },
                            new Option { Content = "Determines how the program will work", IsCorrect = false },
                            new Option { Content = "Determines whether or not the program works", IsCorrect = false },
                            new Option { Content = "Adds new features to the delivered program", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "The operations and maintenance phase ____________________",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 6,
                        Options = new List<Option>
                        {
                            new Option { Content = "Determines what the program will do", IsCorrect = false },
                            new Option { Content = "Determines how the program will work", IsCorrect = false },
                            new Option { Content = "Determines whether or not the program works", IsCorrect = false },
                            new Option { Content = "Adds new features to the delivered program", IsCorrect = true }
                        }
                    },
                    new Question
                    {
                        Content = "The integration phase ____________________",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 7,
                        Options = new List<Option>
                        {
                            new Option { Content = "Determines what the program will do", IsCorrect = false },
                            new Option { Content = "Determines how the program will work", IsCorrect = false },
                            new Option { Content = "Determines whether or not the program works", IsCorrect = false },
                            new Option { Content = "Adds new features to the delivered program", IsCorrect = true }
                        }
                    },
                    new Question
                    {
                        Content = "The implementation phase ____________________",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 8,
                        Options = new List<Option>
                        {
                            new Option { Content = "Determines whether or not the program is feasible", IsCorrect = false },
                            new Option { Content = "Determines which classes are needed and what they will do", IsCorrect = false },
                            new Option { Content = "Determines whether or not the program works", IsCorrect = false },
                            new Option { Content = "Implements the program code", IsCorrect = true }
                        }
                    },
                    new Question
                    {
                        Content = "The design phase ____________________",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 9,
                        Options = new List<Option>
                        {
                            new Option { Content = "Determines whether or not the program is feasible", IsCorrect = false },
                            new Option { Content = "Determines which classes are needed and what they will do", IsCorrect = true },
                            new Option { Content = "Determines whether or not the program works", IsCorrect = false },
                            new Option { Content = "Implements the program code", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "The analysis phase ____________________",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 10,
                        Options = new List<Option>
                        {
                            new Option { Content = "Creates a diagram of the planned classes and their relationships", IsCorrect = false },
                            new Option { Content = "Creates a requirement specification", IsCorrect = true },
                            new Option { Content = "Verifies whether or not the requirement specification has been met", IsCorrect = false },
                            new Option { Content = "Implements the program code", IsCorrect = false }
                        }
                    }
                }
            },
            new Entities.Quiz
            {
                Title = "Conditional Sentences",
                Cover = "https://quizizz.com/media/resource/gs/quizizz-media/quizzes/ffb618cf-d46f-4a7d-bfae-b27907396e0b?w=200&h=200",
                Description = "Learn the basics of Conditional Sentences",
                SubjectId = Guid.Parse("f9c0f102-9fab-4f11-a76c-33efd4439af0"),
                GradeId = Guid.Parse("6afce851-669f-4ee8-a082-814f3633d2a3"),
                LanguageId = Guid.Parse("d9789c96-e0c8-4826-81b3-0eccd22d3508"),
                OwnerId = "ea616dc0-e621-474e-a247-b823b9fe6004",
                Visibility = Visibility.Public,
                IsPublished = true,
                Code = "BNVBNV",
                Questions = new List<Question>
                {
                    new Question
                    {
                        Content = "I wouldn’t tell her if I ……….. you. She can’t keep a secret.",
                        Duration = 45,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 1,
                        Options = new List<Option>
                        {
                            new Option { Content = "will be", IsCorrect = false },
                            new Option { Content = "were", IsCorrect = true },
                            new Option { Content = "am", IsCorrect = false },
                            new Option { Content = "had been", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "Paul would be a good artist if he …….... more patience.",
                        Duration = 45,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 2,
                        Options = new List<Option>
                        {
                            new Option { Content = "had", IsCorrect = true },
                            new Option { Content = "has", IsCorrect = false },
                            new Option { Content = "will have", IsCorrect = false },
                            new Option { Content = "have", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "If we walk so slowly, we ………………. late.",
                        Duration = 30,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 3,
                        Options = new List<Option>
                        {
                            new Option { Content = "will being", IsCorrect = false },
                            new Option { Content = "will be", IsCorrect = true },
                            new Option { Content = "be", IsCorrect = false },
                            new Option { Content = "would be", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "If I …………. John, I’d ask Mary for a date.",
                        Duration = 30,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 4,
                        Options = new List<Option>
                        {
                            new Option { Content = "will be", IsCorrect = false },
                            new Option { Content = "am", IsCorrect = false },
                            new Option { Content = "were", IsCorrect = true },
                            new Option { Content = "would be", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "If you ……….., you won’t find out the truth.",
                        Duration = 30,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 5,
                        Options = new List<Option>
                        {
                            new Option { Content = "will ask", IsCorrect = false },
                            new Option { Content = "won't ask", IsCorrect = false },
                            new Option { Content = "ask", IsCorrect = true },
                            new Option { Content = "don't ask", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "If Amy does the washing up, her brother __________ the table.",
                        Duration = 30,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 6,
                        Options = new List<Option>
                        {
                            new Option { Content = "will clean", IsCorrect = true },
                            new Option { Content = "would clean", IsCorrect = false },
                            new Option { Content = "have cleaned", IsCorrect = false },
                            new Option { Content = "cleaned", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "You would have slept much better, if you _______ your medicine.",
                        Duration = 30,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 7,
                        Options = new List<Option>
                        {
                            new Option { Content = "will take", IsCorrect = false },
                            new Option { Content = "took", IsCorrect = false },
                            new Option { Content = "had taken", IsCorrect = true },
                            new Option { Content = "would take", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "If you wait a minute, I _______ with you.",
                        Duration = 30,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 8,
                        Options = new List<Option>
                        {
                            new Option { Content = "will go", IsCorrect = true },
                            new Option { Content = "would go", IsCorrect = false },
                            new Option { Content = "would have gone", IsCorrect = false },
                            new Option { Content = "go", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "My uncle would stay longer in N.Y, if he ______ more time.",
                        Duration = 30,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 9,
                        Options = new List<Option>
                        {
                            new Option { Content = "has", IsCorrect = false },
                            new Option { Content = "had", IsCorrect = true },
                            new Option { Content = "would have", IsCorrect = false },
                            new Option { Content = "had had", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "He wouldn't have been sleepy all the day if he _____________ late last night.",
                        Duration = 30,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 10,
                        Options = new List<Option>
                        {
                            new Option { Content = "didn't stay up", IsCorrect = false },
                            new Option { Content = "stayed up", IsCorrect = false },
                            new Option { Content = "hadn't stayed up", IsCorrect = true },
                            new Option { Content = "stays up", IsCorrect = false }
                        }
                    }
                }
            },
            new Entities.Quiz
            {
                Title = "Modern History",
                Cover = "https://quizizz.com/media/resource/gs/quizizz-media/quizzes/e1fa8a41-cead-4bd0-a782-26f99a77b3db?w=200&h=200",
                Description = "Learn the basics of Modern History",
                SubjectId = Guid.Parse("d34d0164-6d96-4e58-b732-abbc35ce4d28"),
                GradeId = Guid.Parse("56873e58-0c4f-4f33-a7c6-faf1bb3e6b40"),
                LanguageId = Guid.Parse("d9789c96-e0c8-4826-81b3-0eccd22d3508"),
                OwnerId = "ea616dc0-e621-474e-a247-b823b9fe6004",
                Visibility = Visibility.Public,
                IsPublished = true,
                Code = "YHNYHN",
                Questions = new List<Question>
                {
                    new Question
                    {
                        Content = "Nobility and clergy lost their privileges and their power and wealth diminished",
                        Duration = 30,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 1,
                        Options = new List<Option>
                        {
                            new Option { Content = "True", IsCorrect = true },
                            new Option { Content = "False", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "Select the names of the periods of the Modern Age",
                        Duration = 30,
                        Points = 1,
                        Type = QuestionType.MultipleChoice,
                        Order = 2,
                        Options = new List<Option>
                        {
                            new Option { Content = "Renaissance period", IsCorrect = true },
                            new Option { Content = "Victorian era", IsCorrect = false },
                            new Option { Content = "Baroque period", IsCorrect = true },
                            new Option { Content = "Age of Enlightment", IsCorrect = true }
                        }
                    },
                    new Question
                    {
                        Content = "What was the interest of people during the Renaissance period?",
                        Duration = 30,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 3,
                        Options = new List<Option>
                        {
                            new Option { Content = "Ancient Greek and Roman culture", IsCorrect = true },
                            new Option { Content = "French culture", IsCorrect = false },
                            new Option { Content = "Authoritarian monarchies", IsCorrect = false },
                            new Option { Content = "Other countries", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "The Baroque period had an impact on art, architecture and literature",
                        Duration = 30,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 4,
                        Options = new List<Option>
                        {
                            new Option { Content = "True", IsCorrect = true },
                            new Option { Content = "False", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "During the Age of Enlightment, there were great advances in technology and healthcare",
                        Duration = 30,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 5,
                        Options = new List<Option>
                        {
                            new Option { Content = "True", IsCorrect = true },
                            new Option { Content = "False", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "What was one of the most important inventions that appeared in the 15th century?",
                        Duration = 30,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 6,
                        Options = new List<Option>
                        {
                            new Option { Content = "Light bulb", IsCorrect = false },
                            new Option { Content = "Gunpowder", IsCorrect = false },
                            new Option { Content = "Printing press", IsCorrect = true },
                            new Option { Content = "Eyeglasses", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "The printing press was invented by Johannes Gutenberg in 1559",
                        Duration = 30,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 7,
                        Options = new List<Option>
                        {
                            new Option { Content = "True", IsCorrect = false },
                            new Option { Content = "False", IsCorrect = true }
                        }
                    },
                    new Question
                    {
                        Content = "What did the kings do to get more fame and money?",
                        Duration = 30,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 8,
                        Options = new List<Option>
                        {
                            new Option { Content = "Be at war with other factions", IsCorrect = false },
                            new Option { Content = "Sell lands to other countries", IsCorrect = false },
                            new Option { Content = "Increase the taxes people had to pay", IsCorrect = false },
                            new Option { Content = "Promote expeditions to discover new trade routes", IsCorrect = true }
                        }
                    },
                    new Question
                    {
                        Content = "What is the name of this invention?",
                        Duration = 30,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 9,
                        Options = new List<Option>
                        {
                            new Option { Content = "Compass", IsCorrect = false },
                            new Option { Content = "Astrolabe", IsCorrect = true },
                            new Option { Content = "Portolan charts", IsCorrect = false },
                            new Option { Content = "Printing press", IsCorrect = false }
                        }
                    }
                }
            },
            new Entities.Quiz
            {
                Title = "Introduction to Modern History 2",
                Cover = "https://quizizz.com/media/resource/gs/quizizz-media/quizzes/e1fa8a41-cead-4bd0-a782-26f99a77b3db?w=200&h=200",
                Description = "Learn the basics of Modern History 2",
                SubjectId = Guid.Parse("d34d0164-6d96-4e58-b732-abbc35ce4d28"),
                GradeId = Guid.Parse("56873e58-0c4f-4f33-a7c6-faf1bb3e6b40"),
                LanguageId = Guid.Parse("d9789c96-e0c8-4826-81b3-0eccd22d3508"),
                OwnerId = "ea616dc0-e621-474e-a247-b823b9fe6004",
                Visibility = Visibility.Public,
                IsPublished = true,
                Code = "POIPOI",
                Questions = new List<Question>
                {
                    new Question
                    {
                        Content = "Which two kingdoms unified at the end of the 15th century?",
                        Duration = 60,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Options = new List<Option>
                        {
                            new Option { Content = "Castilla y Navarra", IsCorrect = false },
                            new Option { Content = "Castilla y Granada", IsCorrect = false },
                            new Option { Content = "Castilla y Aragón", IsCorrect = true },
                            new Option { Content = "Castilla y Portugal", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "The two kingdoms formed an alliance and changed their own laws, parliaments, and currencies to be the same.",
                        Duration = 60,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Options = new List<Option>
                        {
                            new Option { Content = "True", IsCorrect = false },
                            new Option { Content = "False", IsCorrect = true }
                        }
                    },
                    new Question
                    {
                        Content = "The Catholic Monarchs, Isabel and Fernando, were passionate defenders of:",
                        Duration = 60,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Options = new List<Option>
                        {
                            new Option { Content = "Ancient Greek and Roman culture", IsCorrect = false },
                            new Option { Content = "Peace and justice", IsCorrect = false },
                            new Option { Content = "Money and taxes", IsCorrect = false },
                            new Option { Content = "Christian faith", IsCorrect = true }
                        }
                    },
                    new Question
                    {
                        Content = "What else happened in 1492 aside from the discovery of America?",
                        Duration = 60,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Options = new List<Option>
                        {
                            new Option { Content = "Navarra became part of Castilla", IsCorrect = false },
                            new Option { Content = "The printing press was invented", IsCorrect = false },
                            new Option { Content = "Granada was taken from the Muslims", IsCorrect = true },
                            new Option { Content = "Isabel and Fernando got married", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "The Catholic Monarchs expanded the kingdom by marrying their children into other countries. How many children did they have?",
                        Duration = 60,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Options = new List<Option>
                        {
                            new Option { Content = "2", IsCorrect = false },
                            new Option { Content = "3", IsCorrect = false },
                            new Option { Content = "4", IsCorrect = false },
                            new Option { Content = "5", IsCorrect = true }
                        }
                    },
                    new Question
                    {
                        Content = "During this time, Aragon expanded its territory along the:",
                        Duration = 60,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Options = new List<Option>
                        {
                            new Option { Content = "Mediterranean Sea", IsCorrect = true },
                            new Option { Content = "Pacific Ocean", IsCorrect = false },
                            new Option { Content = "Atlantic Ocean", IsCorrect = false },
                            new Option { Content = "North Sea", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "In which year did Castilla conquer the Canary Islands?",
                        Duration = 60,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Options = new List<Option>
                        {
                            new Option { Content = "1512", IsCorrect = false },
                            new Option { Content = "1492", IsCorrect = true },
                            new Option { Content = "1516", IsCorrect = false },
                            new Option { Content = "1469", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "Which of these countries became part of the Catholic Monarchs' kingdom?",
                        Duration = 60,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Options = new List<Option>
                        {
                            new Option { Content = "Austria", IsCorrect = false },
                            new Option { Content = "Burgundy", IsCorrect = true },
                            new Option { Content = "France", IsCorrect = false },
                            new Option { Content = "England", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "When did Navarra become part of the Crown of Castilla?",
                        Duration = 60,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Options = new List<Option>
                        {
                            new Option { Content = "1502", IsCorrect = false },
                            new Option { Content = "1469", IsCorrect = false },
                            new Option { Content = "1512", IsCorrect = true },
                            new Option { Content = "1492", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "Which countries did Castilla conquer in the North of Africa?",
                        Duration = 60,
                        Points = 1,
                        Type = QuestionType.MultipleChoice,
                        Options = new List<Option>
                        {
                            new Option { Content = "Oran", IsCorrect = true },
                            new Option { Content = "Ceuta", IsCorrect = true },
                            new Option { Content = "Melilla", IsCorrect = true },
                            new Option { Content = "Algiers", IsCorrect = false }
                        }
                    }
                }
            },
            new Entities.Quiz
            {
                Title = "Introduction to present perfect",
                Cover = "https://quizizz.com/media/resource/gs/quizizz-media/quizzes/bc6448ec-c623-46ae-b11d-ea6900c43737",
                Description = "Learn the basics of present perfect",
                SubjectId = Guid.Parse("f9c0f102-9fab-4f11-a76c-33efd4439af0"),
                GradeId = Guid.Parse("56873e58-0c4f-4f33-a7c6-faf1bb3e6b40"),
                LanguageId = Guid.Parse("d9789c96-e0c8-4826-81b3-0eccd22d3508"),
                OwnerId = "ea616dc0-e621-474e-a247-b823b9fe6004",
                Visibility = Visibility.Public,
                IsPublished = true,
                Code = "MNBMNB",
                Questions = new List<Question>
                {
                    new Question
                    {
                        Content = "I haven't ______________ your book.",
                        Duration = 60,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 1,
                        Options = new List<Option>
                        {
                            new Option { Content = "taken", IsCorrect = true },
                            new Option { Content = "take", IsCorrect = false },
                            new Option { Content = "took", IsCorrect = false },
                            new Option { Content = "takes", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "She ____________ eaten Asian food.",
                        Duration = 60,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 2,
                        Options = new List<Option>
                        {
                            new Option { Content = "has", IsCorrect = true },
                            new Option { Content = "had", IsCorrect = false },
                            new Option { Content = "hadn't", IsCorrect = false },
                            new Option { Content = "hasn't", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "I _________________ my purse.",
                        Duration = 60,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 3,
                        Options = new List<Option>
                        {
                            new Option { Content = "I have lost my purse.", IsCorrect = true },
                            new Option { Content = "I has lost my purse.", IsCorrect = false },
                            new Option { Content = "I have losted my purse.", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "We _________________ this movie already.",
                        Duration = 60,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 4,
                        Options = new List<Option>
                        {
                            new Option { Content = "We have seen this movie already.", IsCorrect = true },
                            new Option { Content = "We has seen this movie already.", IsCorrect = false },
                            new Option { Content = "We have seed this movie already.", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "There _________________ an accident.",
                        Duration = 60,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 5,
                        Options = new List<Option>
                        {
                            new Option { Content = "There has been an accident.", IsCorrect = true },
                            new Option { Content = "There have been an accident.", IsCorrect = false },
                            new Option { Content = "There has beed an accident.", IsCorrect = false },
                            new Option { Content = "There has beed an accident.", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "It's a great movie. I have ... that movie many times.",
                        Duration = 60,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 6,
                        Options = new List<Option>
                        {
                            new Option { Content = "saw", IsCorrect = false },
                            new Option { Content = "seen", IsCorrect = true },
                            new Option { Content = "see", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "Have you ... really strange or interesting food?",
                        Duration = 60,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 7,
                        Options = new List<Option>
                        {
                            new Option { Content = "ever eaten", IsCorrect = true },
                            new Option { Content = "never eaten", IsCorrect = false },
                            new Option { Content = "ate", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "(A) ... your brother talked to you yet? (B) Yes, he ... .",
                        Duration = 60,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 8,
                        Options = new List<Option>
                        {
                            new Option { Content = "Has / did", IsCorrect = false },
                            new Option { Content = "Have / have", IsCorrect = false },
                            new Option { Content = "Has / has", IsCorrect = true }
                        }
                    },
                    new Question
                    {
                        Content = "She has a car, so she ... there many times.",
                        Duration = 60,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 9,
                        Options = new List<Option>
                        {
                            new Option { Content = "have drive", IsCorrect = false },
                            new Option { Content = "has driven", IsCorrect = true },
                            new Option { Content = "has drove", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "I .............. never .................... a car before.",
                        Duration = 60,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 10,
                        Options = new List<Option>
                        {
                            new Option { Content = "have, had", IsCorrect = false },
                            new Option { Content = "has, had", IsCorrect = false },
                            new Option { Content = "have, have", IsCorrect = true },
                            new Option { Content = "had, had", IsCorrect = false }
                        }
                    }
                }
            },
            new Entities.Quiz
            {
                Title = "Introduction to English 10",
                Cover = "https://quizizz.com/media/resource/gs/quizizz-media/quizzes/82d18683-e87f-45e3-b368-1880c15148dc",
                Description = "Learn the basics of english",
                SubjectId = Guid.Parse("f9c0f102-9fab-4f11-a76c-33efd4439af0"),
                GradeId = Guid.Parse("953829bd-5e12-4799-8bd3-3d78d0507097"),
                LanguageId = Guid.Parse("d9789c96-e0c8-4826-81b3-0eccd22d3508"),
                OwnerId = "ea616dc0-e621-474e-a247-b823b9fe6004",
                Visibility = Visibility.Public,
                IsPublished = true,
                Code = "WFVWFV",
                Questions = new List<Question>
                {
                    new Question
                    {
                        Content = "Which of the following are synonyms for 'happy'?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.MultipleChoice,
                        Order = 1,
                        Options = new List<Option>
                        {
                            new Option { Content = "Sad", IsCorrect = false },
                            new Option { Content = "Joyful", IsCorrect = true },
                            new Option { Content = "Angry", IsCorrect = false },
                            new Option { Content = "Cheerful", IsCorrect = true }
                        }
                    },
                    new Question
                    {
                        Content = "What is the past tense form of 'run'?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 2,
                        Options = new List<Option>
                        {
                            new Option { Content = "Ran", IsCorrect = true },
                            new Option { Content = "Runed", IsCorrect = false },
                            new Option { Content = "Runned", IsCorrect = false },
                            new Option { Content = "Rang", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "Which of the following sentences are grammatically correct?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.MultipleChoice,
                        Order = 3,
                        Options = new List<Option>
                        {
                            new Option { Content = "She don't like pizza.", IsCorrect = false },
                            new Option { Content = "She doesn't like pizza.", IsCorrect = true },
                            new Option { Content = "She don't likes pizza.", IsCorrect = false },
                            new Option { Content = "She doesn't like pizza at all.", IsCorrect = true }
                        }
                    },
                    new Question
                    {
                        Content = "Which words are adjectives?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.MultipleChoice,
                        Order = 4,
                        Options = new List<Option>
                        {
                            new Option { Content = "Quickly", IsCorrect = false },
                            new Option { Content = "Beautiful", IsCorrect = true },
                            new Option { Content = "Running", IsCorrect = false },
                            new Option { Content = "Large", IsCorrect = true }
                        }
                    },
                    new Question
                    {
                        Content = "What is the plural form of 'child'?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 5,
                        Options = new List<Option>
                        {
                            new Option { Content = "Children", IsCorrect = true },
                            new Option { Content = "Childs", IsCorrect = false },
                            new Option { Content = "Childes", IsCorrect = false },
                            new Option { Content = "Childer", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "Which of the following sentences use correct punctuation?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.MultipleChoice,
                        Order = 6,
                        Options = new List<Option>
                        {
                            new Option { Content = "I like ice cream, chocolate and cookies.", IsCorrect = true },
                            new Option { Content = "I like ice cream chocolate, and cookies.", IsCorrect = false },
                            new Option { Content = "I like ice cream, chocolate, and cookies.", IsCorrect = true },
                            new Option { Content = "I like ice cream chocolate and, cookies.", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "Which of the following are prepositions?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.MultipleChoice,
                        Order = 7,
                        Options = new List<Option>
                        {
                            new Option { Content = "Cat", IsCorrect = false },
                            new Option { Content = "Under", IsCorrect = true },
                            new Option { Content = "Dance", IsCorrect = false },
                            new Option { Content = "Through", IsCorrect = true }
                        }
                    },
                    new Question
                    {
                        Content = "Which words are antonyms of 'easy'?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.MultipleChoice,
                        Order = 8,
                        Options = new List<Option>
                        {
                            new Option { Content = "Hard", IsCorrect = true },
                            new Option { Content = "Smooth", IsCorrect = false },
                            new Option { Content = "Simple", IsCorrect = false },
                            new Option { Content = "Difficult", IsCorrect = true }
                        }
                    },
                    new Question
                    {
                        Content = "Which of the following are correct spellings?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.SingleChoice,
                        Order = 9,
                        Options = new List<Option>
                        {
                            new Option { Content = "Accomodation", IsCorrect = false },
                            new Option { Content = "Accomadation", IsCorrect = false },
                            new Option { Content = "Accommodation", IsCorrect = true },
                            new Option { Content = "Accommadation", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "What is the correct form of 'to be' in the sentence: 'I/She ___ a doctor.'",
                        Duration = 10,
                        Points = 1,
                        Type = QuestionType.MultipleChoice,
                        Order = 10,
                        Options = new List<Option>
                        {
                            new Option { Content = "am", IsCorrect = true },
                            new Option { Content = "is", IsCorrect = true },
                            new Option { Content = "are", IsCorrect = false },
                            new Option { Content = "was", IsCorrect = false }
                        }
                    }
                }
            },
        };

        context.Quizzes.AddRange(quizzes);
        context.SaveChanges();
        return Task.CompletedTask;
    }
}