using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using IntelligenceBattle.Services.GameManager.Context;
using IntelligenceBattle.Services.GameManager.Extentions;
using IntelligenceBattle.Services.GameManager.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace IntelligenceBattle.Services.GameManager.Services
{
    public class GameManagerService
    {
        private readonly PublicContext _context;
        private readonly IServiceProvider _iServiceProvider;
        public GameManagerService(PublicContext context, IServiceProvider iServiceProvider)
        {
            _context = context;
            _iServiceProvider = iServiceProvider;
        }

        public async Task CreateGames()
        {
            var searche1s = await _context.SearchGames.ToListAsync();
            var searches = (await _context.SearchGames
                .Include(x => x.GameType)
                .ToListAsync()).AsEnumerable().GroupBy(x => new
            {
                x.GameTypeId,
                x.CategoryId
            }).ToList();

            foreach (var searchList in searches)
            {
                var b = searchList.ToList().SplitList(nSize: searchList.First().GameType.PlayerCount).ToList();
                var last = b.LastOrDefault();
                if (last != null)
                {
                    if (last.Data.Count < searchList.First().GameType.PlayerCount)
                    {
                        b.RemoveAt(b.Count - 1);
                    }

                }

                foreach (var s in b)
                {
                    _context.SearchGames.RemoveRange(s.Data);
                    await _context.SaveChangesAsync();
                    var newGame = new Game
                    {
                        CategoryId = s.Data.First().CategoryId,
                        GameTypeId = s.Data.First().GameTypeId,
                        CreatedDatetime = DateTime.Now,
                        IsEnd = false,
                    };
                    foreach (var search in s.Data)
                    {
                        newGame.GameUsers.Add(new GameUser
                        {
                            CreatedDateTime = DateTime.Now,
                            ProviderId = search.ProviderId,
                            UserId = search.UserId,
                        });
                    }
                    await _context.Games.AddAsync(newGame);
                    await _context.SaveChangesAsync();
                    var gameController =
                        ActivatorUtilities.CreateInstance<GameController.GameController>(_iServiceProvider, newGame);
                    Thread t = new Thread(new ThreadStart(gameController.Start));
                    t.Start();
                }
            }
        }
    }
    
}
