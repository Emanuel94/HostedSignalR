using HostedSignalR.Models;
using Microsoft.AspNetCore.SignalR;

namespace HostedSignalR
{
    public class PopulationHostedService : IHostedService, IDisposable
    {
        private Timer _timer;
        private readonly IHubContext<PopulationHub> _populationHub;

        public PopulationHostedService(IHubContext<PopulationHub> population)
        { 
            _populationHub = population;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(SendInfo, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));
            return Task.CompletedTask;
        }

        private void SendInfo(object? state)
        {
            IEnumerable<Population> population;
            using (var contextDB = new AccountownerContext() )
            {
                population = contextDB.Populations.ToArray();
            }

            _populationHub.Clients.All.SendAsync("Recive", population);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }
    }
}
