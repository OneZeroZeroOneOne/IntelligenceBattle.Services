using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using IntelligenceBattle.Services.GameManager.Services;

namespace IntelligenceBattle.Services.GameManager
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly GameManagerService _gameManagerService;

        public Worker(ILogger<Worker> logger, GameManagerService gameManagerService)
        {
            _logger = logger;
            _gameManagerService = gameManagerService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                try
                {
                    await _gameManagerService.CreateGames();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                await Task.Delay(100, stoppingToken);
            }
        }
    }
}
