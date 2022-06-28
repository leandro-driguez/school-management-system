namespace SchoolManagementSystem.API;

class PeriodicHostedService : BackgroundService
{
    private readonly TimeSpan _period = TimeSpan.FromDays(1);
    private readonly ILogger<PeriodicHostedService> _logger;
    private readonly IServiceScopeFactory _factory;
    private int _executionCount = 0;
    public bool IsEnabled { get; set; }

    public PeriodicHostedService(
        ILogger<PeriodicHostedService> logger, 
        IServiceScopeFactory factory)
    {
        _logger = logger;
        _factory = factory;
        IsEnabled = true;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using PeriodicTimer timer = new PeriodicTimer(_period);

        while (
            !stoppingToken.IsCancellationRequested &&
            await timer.WaitForNextTickAsync(stoppingToken))
        {
            try
            {
                if (IsEnabled)
                {
                    await using AsyncServiceScope asyncScope = _factory.CreateAsyncScope();
                    
                    DebtorNotificationService debtorNotificationService = asyncScope.ServiceProvider.GetRequiredService<DebtorNotificationService>();
                    await debtorNotificationService.CalculateDebtors();

                    _executionCount++;
                    _logger.LogInformation(
                        $"Executed PeriodicHostedService - Count: {_executionCount}");
                }
                else
                {
                    _logger.LogInformation(
                        "Skipped PeriodicHostedService");
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation(
                    $"Failed to execute PeriodicHostedService with exception message {ex.Message}. Good luck next round!");
            }
        }
    }
}
