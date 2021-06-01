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
            var questionsCount = _context.Questions.Count();
            var questions = _context.Questions.Where(x => x.CategoryId == _game.CategoryId)
                .OrderBy(x => x.Id)
                .Skip(random.Next(1, questionsCount - gameQuestionCount))
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
            var userCount = _context.GameUsers.Count(x => x.GameId == _game.Id);
            var gameUsers = _context.GameUsers.Where(x => x.GameId == _game.Id).ToList();
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
                gameQuestion.IsCurrent = false;
                _context.SaveChanges();
            }

            var endGameNotList = new List<Notification>();
            foreach (var user in gameUsers)
            {
                endGameNotList.Add(new Notification
                {
                    Text = "game was end",
                    TypeId = 1,
                });
            }

            _game.IsEnd = true;
            _context.Notifications.AddRange(endGameNotList);
            _context.SaveChanges();
        }
    }
}
