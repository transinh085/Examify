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
                Code = "CSHARPBASIC",
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
                        Type = QuestionType.SingleChoice,
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
                Cover = "https://example.com/physics_quiz.jpg",
                Description = "Test your fundamental physics knowledge",
                SubjectId = Guid.Parse("462175fb-55b4-40e0-b317-8f4d58ca9615"),
                GradeId = Guid.Parse("56873e58-0c4f-4f33-a7c6-faf1bb3e6b40"),
                LanguageId = Guid.Parse("d9789c96-e0c8-4826-81b3-0eccd22d3508"),
                OwnerId = "ea616dc0-e621-474e-a247-b823b9fe6004",
                Visibility = Visibility.Public,
                IsPublished = true,
                Questions = new List<Question>
                {
                    new Question
                    {
                        Content = "What is the speed of light in vacuum?",
                        Duration = 30,
                        Points = 1,
                        Type = QuestionType.MultipleChoice,
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
                        Type = QuestionType.MultipleChoice,
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
                        Type = QuestionType.MultipleChoice,
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
                        Type = QuestionType.MultipleChoice,
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
                        Type = QuestionType.MultipleChoice,
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
                        Type = QuestionType.MultipleChoice,
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
                        Type = QuestionType.MultipleChoice,
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
                            new Option { Content = "All of the above.", IsCorrect = true }
                        }
                    },
                    new Question
                    {
                        Content = "Which of the following cannot be considered a plane mirror?",
                        Duration = 30,
                        Points = 1,
                        Type = QuestionType.MultipleChoice,
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
                    Type = QuestionType.MultipleChoice,
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
                Cover = "https://example.com/physics_quiz.jpg",
                Description = "Test your fundamental physics knowledge 2",
                SubjectId = Guid.Parse("462175fb-55b4-40e0-b317-8f4d58ca9615"),
                GradeId = Guid.Parse("56873e58-0c4f-4f33-a7c6-faf1bb3e6b40"),
                LanguageId = Guid.Parse("d9789c96-e0c8-4826-81b3-0eccd22d3508"),
                OwnerId = "ea616dc0-e621-474e-a247-b823b9fe6004",
                Visibility = Visibility.Public,
                IsPublished = true,
                Questions = new List<Question>
                {
                    new Question
                    {
                        Content = "A person who is 1.6 meters tall stands in front of a plane mirror, and the image is 1.5 meters away from the mirror. How far is the person from the mirror?",
                        Duration = 30,
                        Points = 1,
                        Type = QuestionType.MultipleChoice,
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
                        Type = QuestionType.MultipleChoice,
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
                        Type = QuestionType.MultipleChoice,
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
                        Type = QuestionType.MultipleChoice,
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
                        Type = QuestionType.MultipleChoice,
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
                        Type = QuestionType.MultipleChoice,
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
                        Type = QuestionType.MultipleChoice,
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
                            new Option { Content = "All of the above.", IsCorrect = true }
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
                        Type = QuestionType.MultipleChoice,
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
                Cover = "https://example.com/chemistry_intro.jpg",
                Description = "Learn the basics of Math 2",
                SubjectId = Guid.Parse("59820f61-ada9-44e8-9a45-790981fe05f0"),
                GradeId = Guid.Parse("bac8156d-9e33-4054-8a56-8d8ca6647cfb"),
                LanguageId = Guid.Parse("92458564-28b3-449c-b2c5-645740600368"),
                OwnerId = "ea616dc0-e621-474e-a247-b823b9fe6004",
                Visibility = Visibility.Public,
                IsPublished = true,
                Questions = new List<Question>
                {
                    new Question
                    {
                        Content = "7+5=",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.MultipleChoice,
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
                        Type = QuestionType.MultipleChoice,
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
                        Type = QuestionType.MultipleChoice,
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
                        Type = QuestionType.MultipleChoice,
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
                        Type = QuestionType.MultipleChoice,
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
                        Type = QuestionType.MultipleChoice,
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
                        Type = QuestionType.MultipleChoice,
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
                        Type = QuestionType.MultipleChoice,
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
                        Type = QuestionType.MultipleChoice,
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
                Cover = "https://example.com/chemistry_intro.jpg",
                Description = "Learn the basics of chemistry",
                SubjectId = Guid.Parse("59820f61-ada9-44e8-9a45-790981fe05f0"),
                GradeId = Guid.Parse("fe1ab3da-f5d9-4b63-ba57-3dbc14a9a82b"),
                LanguageId = Guid.Parse("92458564-28b3-449c-b2c5-645740600368"),
                OwnerId = "ea616dc0-e621-474e-a247-b823b9fe6004",
                Visibility = Visibility.Public,
                IsPublished = true,
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
                            new Option { Content = "5503", IsCorrect = false },
                            new Option { Content = "3408", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "When dividing a two-digit number by 8, the quotient is 5 and the remainder is 6. What is the dividend?",
                        Duration = 30,
                        Points = 1,
                        Type = QuestionType.MultipleChoice,
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
                        Type = QuestionType.MultipleChoice,
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
                        Type = QuestionType.MultipleChoice,
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
                        Type = QuestionType.MultipleChoice,
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
                        Type = QuestionType.MultipleChoice,
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
                        Type = QuestionType.MultipleChoice,
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
                        Type = QuestionType.MultipleChoice,
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
                        Type = QuestionType.MultipleChoice,
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
                        Type = QuestionType.MultipleChoice,
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
                Cover = "https://example.com/chemistry_intro.jpg",
                Description = "Learn the basics of english",
                SubjectId = Guid.Parse("f9c0f102-9fab-4f11-a76c-33efd4439af0"),
                GradeId = Guid.Parse("953829bd-5e12-4799-8bd3-3d78d0507097"),
                LanguageId = Guid.Parse("92458564-28b3-449c-b2c5-645740600368"),
                OwnerId = "ea616dc0-e621-474e-a247-b823b9fe6004",
                Visibility = Visibility.Public,
                IsPublished = true,
                Questions = new List<Question>
                {
                    new Question
                    {
                        Content = "What is the plural form of 'child'?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.MultipleChoice,
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
                        Type = QuestionType.MultipleChoice,
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
                        Type = QuestionType.MultipleChoice,
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
                        Type = QuestionType.MultipleChoice,
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
                        Type = QuestionType.MultipleChoice,
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
                        Type = QuestionType.MultipleChoice,
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
                        Type = QuestionType.MultipleChoice,
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
                        Type = QuestionType.MultipleChoice,
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
                        Type = QuestionType.MultipleChoice,
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
                        Type = QuestionType.MultipleChoice,
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
                Cover = "https://example.com/chemistry_intro.jpg",
                Description = "Learn the basics of english",
                SubjectId = Guid.Parse("f9c0f102-9fab-4f11-a76c-33efd4439af0"),
                GradeId = Guid.Parse("953829bd-5e12-4799-8bd3-3d78d0507097"),
                LanguageId = Guid.Parse("92458564-28b3-449c-b2c5-645740600368"),
                OwnerId = "ea616dc0-e621-474e-a247-b823b9fe6004",
                Visibility = Visibility.Public,
                IsPublished = true,
                Questions = new List<Question>
                {
                    new Question
                    {
                        Content = "Which of the following is the correct spelling?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.MultipleChoice,
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
                        Type = QuestionType.MultipleChoice,
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
                        Type = QuestionType.MultipleChoice,
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
                        Type = QuestionType.MultipleChoice,
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
                        Type = QuestionType.MultipleChoice,
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
                        Type = QuestionType.MultipleChoice,
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
                        Type = QuestionType.MultipleChoice,
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
                        Type = QuestionType.MultipleChoice,
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
                        Type = QuestionType.MultipleChoice,
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
                        Type = QuestionType.MultipleChoice,
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
                Cover = "https://example.com/chemistry_intro.jpg",
                Description = "Learn the basics of Geography",
                SubjectId = Guid.Parse("deb9e2f7-6c42-43bd-a675-bf5f59b9f821"),
                GradeId = Guid.Parse("45304ba8-da09-46b9-8400-d5b7a7bb718e"),
                LanguageId = Guid.Parse("92458564-28b3-449c-b2c5-645740600368"),
                OwnerId = "ea616dc0-e621-474e-a247-b823b9fe6004",
                Visibility = Visibility.Public,
                IsPublished = true,
                Questions = new List<Question>
                {
                    new Question
                    {
                        Content = "What is the capital city of France?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.MultipleChoice,
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
                        Type = QuestionType.MultipleChoice,
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
                        Type = QuestionType.MultipleChoice,
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
                        Type = QuestionType.MultipleChoice,
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
                        Type = QuestionType.MultipleChoice,
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
                        Type = QuestionType.MultipleChoice,
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
                        Type = QuestionType.MultipleChoice,
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
                        Type = QuestionType.MultipleChoice,
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
                        Type = QuestionType.MultipleChoice,
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
                        Type = QuestionType.MultipleChoice,
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
                Cover = "https://example.com/chemistry_intro.jpg",
                Description = "Learn the basics of Geography",
                SubjectId = Guid.Parse("deb9e2f7-6c42-43bd-a675-bf5f59b9f821"),
                GradeId = Guid.Parse("45304ba8-da09-46b9-8400-d5b7a7bb718e"),
                LanguageId = Guid.Parse("92458564-28b3-449c-b2c5-645740600368"),
                OwnerId = "ea616dc0-e621-474e-a247-b823b9fe6004",
                Visibility = Visibility.Public,
                IsPublished = true,
                Questions = new List<Question>
                {
                    new Question
                    {
                        Content = "Which country has the largest land area in the world?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.MultipleChoice,
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
                        Type = QuestionType.MultipleChoice,
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
                        Type = QuestionType.MultipleChoice,
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
                        Type = QuestionType.MultipleChoice,
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
                        Type = QuestionType.MultipleChoice,
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
                        Type = QuestionType.MultipleChoice,
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
                        Type = QuestionType.MultipleChoice,
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
                        Type = QuestionType.MultipleChoice,
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
                        Type = QuestionType.MultipleChoice,
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
                        Type = QuestionType.MultipleChoice,
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
                Cover = "https://example.com/chemistry_intro.jpg",
                Description = "Learn the basics of chemistry",
                SubjectId = Guid.Parse("048d1a67-4ced-4189-85e6-c2803577f040"),
                GradeId = Guid.Parse("f2fe3f16-41f4-43da-b253-14873bb07100"),
                LanguageId = Guid.Parse("92458564-28b3-449c-b2c5-645740600368"),
                OwnerId = "ea616dc0-e621-474e-a247-b823b9fe6004",
                Visibility = Visibility.Public,
                IsPublished = true,
                Questions = new List<Question>
                {
                    new Question
                    {
                        Content = "What is the chemical symbol for water?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.MultipleChoice,
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
                        Type = QuestionType.MultipleChoice,
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
                        Type = QuestionType.MultipleChoice,
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
                        Type = QuestionType.MultipleChoice,
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
                        Type = QuestionType.MultipleChoice,
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
                        Type = QuestionType.MultipleChoice,
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
                        Type = QuestionType.MultipleChoice,
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
                        Type = QuestionType.MultipleChoice,
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
                        Type = QuestionType.MultipleChoice,
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
                        Type = QuestionType.MultipleChoice,
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
                Cover = "https://example.com/chemistry_intro.jpg",
                Description = "Learn the basics of chemistry",
                SubjectId = Guid.Parse("048d1a67-4ced-4189-85e6-c2803577f040"),
                GradeId = Guid.Parse("f2fe3f16-41f4-43da-b253-14873bb07100"),
                LanguageId = Guid.Parse("92458564-28b3-449c-b2c5-645740600368"),
                OwnerId = "ea616dc0-e621-474e-a247-b823b9fe6004",
                Visibility = Visibility.Public,
                IsPublished = true, 
                Questions = new List<Question>
                {
                    new Question
                    {
                        Content = "What is the most abundant element in the universe?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.MultipleChoice,
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
                        Type = QuestionType.MultipleChoice,
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
                        Type = QuestionType.MultipleChoice,
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
                        Type = QuestionType.MultipleChoice,
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
                        Type = QuestionType.MultipleChoice,
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
                        Type = QuestionType.MultipleChoice,
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
                        Type = QuestionType.MultipleChoice,
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
                        Type = QuestionType.MultipleChoice,
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
                        Type = QuestionType.MultipleChoice,
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
                        Type = QuestionType.MultipleChoice,
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
                Title = "Introduction to Chemistry",
                Cover = "https://example.com/chemistry_intro.jpg",
                Description = "Learn the basics of chemistry",
                SubjectId = Guid.Parse("048d1a67-4ced-4189-85e6-c2803577f040"),
                GradeId = Guid.Parse("eaae3de7-126e-4a1c-b301-236049605952"),
                LanguageId = Guid.Parse("92458564-28b3-449c-b2c5-645740600368"),
                OwnerId = "ea616dc0-e621-474e-a247-b823b9fe6004",
                Visibility = Visibility.Public,
                IsPublished = true,
                Questions = new List<Question>
                {
                    new Question
                    {
                        Content = "What is the chemical symbol for water?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.MultipleChoice,
                        Order = 1,
                        Options = new List<Option>
                        {
                            new Option { Content = "H2O", IsCorrect = true },
                            new Option { Content = "O2H", IsCorrect = false },
                            new Option { Content = "HO2", IsCorrect = false },
                            new Option { Content = "H2", IsCorrect = false }
                        }
                    }
                }
            },
            new Entities.Quiz
            {
                Title = "Introduction to Chemistry",
                Cover = "https://example.com/chemistry_intro.jpg",
                Description = "Learn the basics of chemistry",
                SubjectId = Guid.Parse("048d1a67-4ced-4189-85e6-c2803577f040"),
                GradeId = Guid.Parse("eaae3de7-126e-4a1c-b301-236049605952"),
                LanguageId = Guid.Parse("92458564-28b3-449c-b2c5-645740600368"),
                OwnerId = "ea616dc0-e621-474e-a247-b823b9fe6004",
                Visibility = Visibility.Public,
                IsPublished = true,
                Questions = new List<Question>
                {
                    new Question
                    {
                        Content = "What is the chemical symbol for water?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.MultipleChoice,
                        Order = 1,
                        Options = new List<Option>
                        {
                            new Option { Content = "H2O", IsCorrect = true },
                            new Option { Content = "O2H", IsCorrect = false },
                            new Option { Content = "HO2", IsCorrect = false },
                            new Option { Content = "H2", IsCorrect = false }
                        }
                    }
                }
            },
            new Entities.Quiz
            {
                Title = "Introduction to Chemistry",
                Cover = "https://example.com/chemistry_intro.jpg",
                Description = "Learn the basics of chemistry",
                SubjectId = Guid.Parse("048d1a67-4ced-4189-85e6-c2803577f040"),
                GradeId = Guid.Parse("eaae3de7-126e-4a1c-b301-236049605952"),
                LanguageId = Guid.Parse("92458564-28b3-449c-b2c5-645740600368"),
                OwnerId = "ea616dc0-e621-474e-a247-b823b9fe6004",
                Visibility = Visibility.Public,
                IsPublished = true,
                Questions = new List<Question>
                {
                    new Question
                    {
                        Content = "What is the chemical symbol for water?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.MultipleChoice,
                        Order = 1,
                        Options = new List<Option>
                        {
                            new Option { Content = "H2O", IsCorrect = true },
                            new Option { Content = "O2H", IsCorrect = false },
                            new Option { Content = "HO2", IsCorrect = false },
                            new Option { Content = "H2", IsCorrect = false }
                        }
                    }
                }
            },
            new Entities.Quiz
            {
                Title = "Introduction to Chemistry",
                Cover = "https://example.com/chemistry_intro.jpg",
                Description = "Learn the basics of chemistry",
                SubjectId = Guid.Parse("048d1a67-4ced-4189-85e6-c2803577f040"),
                GradeId = Guid.Parse("eaae3de7-126e-4a1c-b301-236049605952"),
                LanguageId = Guid.Parse("92458564-28b3-449c-b2c5-645740600368"),
                OwnerId = "ea616dc0-e621-474e-a247-b823b9fe6004",
                Visibility = Visibility.Public,
                IsPublished = true,
                Questions = new List<Question>
                {
                    new Question
                    {
                        Content = "What is the chemical symbol for water?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.MultipleChoice,
                        Order = 1,
                        Options = new List<Option>
                        {
                            new Option { Content = "H2O", IsCorrect = true },
                            new Option { Content = "O2H", IsCorrect = false },
                            new Option { Content = "HO2", IsCorrect = false },
                            new Option { Content = "H2", IsCorrect = false }
                        }
                    }
                }
            },
            new Entities.Quiz
            {
                Title = "Introduction to Chemistry",
                Cover = "https://example.com/chemistry_intro.jpg",
                Description = "Learn the basics of chemistry",
                SubjectId = Guid.Parse("048d1a67-4ced-4189-85e6-c2803577f040"),
                GradeId = Guid.Parse("eaae3de7-126e-4a1c-b301-236049605952"),
                LanguageId = Guid.Parse("92458564-28b3-449c-b2c5-645740600368"),
                OwnerId = "ea616dc0-e621-474e-a247-b823b9fe6004",
                Visibility = Visibility.Public,
                IsPublished = true,
                Questions = new List<Question>
                {
                    new Question
                    {
                        Content = "What is the chemical symbol for water?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.MultipleChoice,
                        Order = 1,
                        Options = new List<Option>
                        {
                            new Option { Content = "H2O", IsCorrect = true },
                            new Option { Content = "O2H", IsCorrect = false },
                            new Option { Content = "HO2", IsCorrect = false },
                            new Option { Content = "H2", IsCorrect = false }
                        }
                    }
                }
            },
            new Entities.Quiz
            {
                Title = "Introduction to Chemistry",
                Cover = "https://example.com/chemistry_intro.jpg",
                Description = "Learn the basics of chemistry",
                SubjectId = Guid.Parse("048d1a67-4ced-4189-85e6-c2803577f040"),
                GradeId = Guid.Parse("eaae3de7-126e-4a1c-b301-236049605952"),
                LanguageId = Guid.Parse("92458564-28b3-449c-b2c5-645740600368"),
                OwnerId = "ea616dc0-e621-474e-a247-b823b9fe6004",
                Visibility = Visibility.Public,
                IsPublished = true,
                Questions = new List<Question>
                {
                    new Question
                    {
                        Content = "What is the chemical symbol for water?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.MultipleChoice,
                        Order = 1,
                        Options = new List<Option>
                        {
                            new Option { Content = "H2O", IsCorrect = true },
                            new Option { Content = "O2H", IsCorrect = false },
                            new Option { Content = "HO2", IsCorrect = false },
                            new Option { Content = "H2", IsCorrect = false }
                        }
                    }
                }
            },
            new Entities.Quiz
            {
                Title = "Introduction to Chemistry",
                Cover = "https://example.com/chemistry_intro.jpg",
                Description = "Learn the basics of chemistry",
                SubjectId = Guid.Parse("048d1a67-4ced-4189-85e6-c2803577f040"),
                GradeId = Guid.Parse("eaae3de7-126e-4a1c-b301-236049605952"),
                LanguageId = Guid.Parse("92458564-28b3-449c-b2c5-645740600368"),
                OwnerId = "ea616dc0-e621-474e-a247-b823b9fe6004",
                Visibility = Visibility.Public,
                IsPublished = true,
                Questions = new List<Question>
                {
                    new Question
                    {
                        Content = "What is the chemical symbol for water?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.MultipleChoice,
                        Order = 1,
                        Options = new List<Option>
                        {
                            new Option { Content = "H2O", IsCorrect = true },
                            new Option { Content = "O2H", IsCorrect = false },
                            new Option { Content = "HO2", IsCorrect = false },
                            new Option { Content = "H2", IsCorrect = false }
                        }
                    }
                }
            },
            new Entities.Quiz
            {
                Title = "Introduction to Chemistry",
                Cover = "https://example.com/chemistry_intro.jpg",
                Description = "Learn the basics of chemistry",
                SubjectId = Guid.Parse("048d1a67-4ced-4189-85e6-c2803577f040"),
                GradeId = Guid.Parse("eaae3de7-126e-4a1c-b301-236049605952"),
                LanguageId = Guid.Parse("92458564-28b3-449c-b2c5-645740600368"),
                OwnerId = "ea616dc0-e621-474e-a247-b823b9fe6004",
                Visibility = Visibility.Public,
                IsPublished = true,
                Questions = new List<Question>
                {
                    new Question
                    {
                        Content = "What is the chemical symbol for water?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.MultipleChoice,
                        Order = 1,
                        Options = new List<Option>
                        {
                            new Option { Content = "H2O", IsCorrect = true },
                            new Option { Content = "O2H", IsCorrect = false },
                            new Option { Content = "HO2", IsCorrect = false },
                            new Option { Content = "H2", IsCorrect = false }
                        }
                    }
                }
            },
            new Entities.Quiz
            {
                Title = "Introduction to Chemistry",
                Cover = "https://example.com/chemistry_intro.jpg",
                Description = "Learn the basics of chemistry",
                SubjectId = Guid.Parse("048d1a67-4ced-4189-85e6-c2803577f040"),
                GradeId = Guid.Parse("eaae3de7-126e-4a1c-b301-236049605952"),
                LanguageId = Guid.Parse("92458564-28b3-449c-b2c5-645740600368"),
                OwnerId = "ea616dc0-e621-474e-a247-b823b9fe6004",
                Visibility = Visibility.Public,
                IsPublished = true,
                Questions = new List<Question>
                {
                    new Question
                    {
                        Content = "What is the chemical symbol for water?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.MultipleChoice,
                        Order = 1,
                        Options = new List<Option>
                        {
                            new Option { Content = "H2O", IsCorrect = true },
                            new Option { Content = "O2H", IsCorrect = false },
                            new Option { Content = "HO2", IsCorrect = false },
                            new Option { Content = "H2", IsCorrect = false }
                        }
                    }
                }
            },
            new Entities.Quiz
            {
                Title = "Introduction to Chemistry",
                Cover = "https://example.com/chemistry_intro.jpg",
                Description = "Learn the basics of chemistry",
                SubjectId = Guid.Parse("048d1a67-4ced-4189-85e6-c2803577f040"),
                GradeId = Guid.Parse("eaae3de7-126e-4a1c-b301-236049605952"),
                LanguageId = Guid.Parse("92458564-28b3-449c-b2c5-645740600368"),
                OwnerId = "ea616dc0-e621-474e-a247-b823b9fe6004",
                Visibility = Visibility.Public,
                IsPublished = true,
                Questions = new List<Question>
                {
                    new Question
                    {
                        Content = "What is the chemical symbol for water?",
                        Duration = 20,
                        Points = 1,
                        Type = QuestionType.MultipleChoice,
                        Order = 1,
                        Options = new List<Option>
                        {
                            new Option { Content = "H2O", IsCorrect = true },
                            new Option { Content = "O2H", IsCorrect = false },
                            new Option { Content = "HO2", IsCorrect = false },
                            new Option { Content = "H2", IsCorrect = false }
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