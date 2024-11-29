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
                OwnerId = Guid.Parse("ea616dc0-e621-474e-a247-b823b9fe6004"),
                Visibility = Visibility.Private,
                IsPublished = true,
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
                OwnerId = Guid.Parse("ea616dc0-e621-474e-a247-b823b9fe6004"),
                Visibility = Visibility.Private,
                IsPublished = true,
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
            }
        };

        context.Quizzes.AddRange(quizzes);
        context.SaveChanges();
        return Task.CompletedTask;
    }
}