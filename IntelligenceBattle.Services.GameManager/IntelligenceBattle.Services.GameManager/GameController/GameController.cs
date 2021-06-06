using IntelligenceBattle.Services.GameManager.Context;
using IntelligenceBattle.Services.GameManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace IntelligenceBattle.Services.GameManager.GameController
{
    public class GameController
    {
        public Game _game;

        public PublicContext _context;

        public GameController(Game game, PublicContext context)
        {
            _game = game;
            _context = context;
        }



        public void Start()
        {
            //добавить количество по игро типу
            int gameQuestionCount = 3;

            var random = new Random();
            var questionsCountQuery = _context.Questions.AsQueryable();
            var questionsQuery = _context.Questions.AsQueryable();
            if (_game.CategoryId != 1)
            {
                questionsCountQuery = questionsCountQuery.Where(x => x.CategoryId == _game.CategoryId);
                questionsQuery = questionsQuery.Where(x => x.CategoryId == _game.CategoryId);
            };
            var questionsCount = questionsCountQuery.Count();
            var questions = questionsQuery
                .OrderBy(x => x.Id)
                .Skip(random.Next(0, questionsCount - gameQuestionCount))
                .Take(gameQuestionCount)
                .ToList();
            var gameQuestionList = new List<GameQuestion>();
            foreach (var question in questions)
            {
                gameQuestionList.Add(new GameQuestion
                {
                    GameId = _game.Id,
                    QuestionId = question.Id,
                });
            }
            _context.GameQuestions.AddRange(gameQuestionList);
            _context.SaveChanges();
            var gameUsers = _context.GameUsers.Where(x => x.GameId == _game.Id).ToList();
            var userCount = gameUsers.Count;
            var startList = new List<Notification>();
            foreach (var user in gameUsers)
            {
                startList.Add(new Notification
                {
                    Text = " ",
                    TypeId = 2,
                    UserId = user.UserId,
                    ProviderId = user.ProviderId,
                });
            }

            _context.Notifications.AddRange(startList);
            foreach (var question in questions)
            {
                var gameQuestion = _context.GameQuestions
                    .FirstOrDefault(x => x.QuestionId == question.Id && x.GameId == _game.Id);
                gameQuestion.IsCurrent = true;
                var sendQuestionList = new List<SendQuestion>();
                foreach (var user in gameUsers)
                {
                    sendQuestionList.Add(new SendQuestion
                    {
                        GameId = _game.Id,
                        QuestionId = question.Id,
                        ProviderId = user.ProviderId,
                        UserId = user.UserId,
                    });
                }

                _context.SendQuestions.AddRange(sendQuestionList);
                _context.SaveChanges();
                var startTime = DateTime.Now;
                var endTime = startTime + TimeSpan.FromMinutes(1);
                while (DateTime.Now < endTime)
                {

                    var userAnswerCount = _context.UserAnswers
                        .Count(x => x.GameId == _game.Id && x.QuestionId == question.Id);
                    if (userAnswerCount == userCount)
                    {
                        break;
                    }

                }
                if (DateTime.Now > endTime)
                {
                    var timeoutList = new List<Notification>();
                    foreach (var user in gameUsers)
                    {

                        timeoutList.Add(new Notification
                        {
                            Text = " ",
                            TypeId = 4,
                            UserId = user.UserId,
                            ProviderId = user.ProviderId,
                        });
                    }
                    _context.Notifications.AddRange(timeoutList);
                }
                gameQuestion.IsCurrent = false;
                _context.SaveChanges();
            }
            

            var endGameNotList = new List<Notification>();
            foreach (var user in gameUsers)
            {
                endGameNotList.Add(new Notification
                {
                    Text = $"{_game.Id}",
                    TypeId = 3,
                    UserId = user.UserId,
                    ProviderId = user.ProviderId,
                });
            }

            var game = _context.Games.FirstOrDefault(x => x.Id == _game.Id);
            game.IsEnd = true;
            _context.Notifications.AddRange(endGameNotList);
            _context.SaveChanges();
        }
    }
}
