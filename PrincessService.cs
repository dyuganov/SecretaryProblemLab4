using SecretaryProblem4.model.interfaces;
using Microsoft.Extensions.Hosting;
using SecretaryProblem4.model;

namespace SecretaryProblem4;

public class PrincessService : IHostedService
{
    private readonly IHostApplicationLifetime _appLifetime;
    private readonly IHall _hall;
    private readonly Princess _princess;

    public PrincessService(IFriend friend, IHall hall, IHostApplicationLifetime appLifetime)
    {
        _hall = hall;
        _princess = new Princess(friend);
        _appLifetime = appLifetime;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _appLifetime.ApplicationStarted.Register(OnStarted);
        _appLifetime.ApplicationStopping.Register(OnStopping);
        _appLifetime.ApplicationStopped.Register(OnStopped);
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    private void OnStarted()
    {
        Console.WriteLine(@"started");
        IContender? currentContender = null;
        for (int i = 0; i < Constants.ContendersNum; ++i)
        {
            currentContender = _princess.MakeChoice(_hall.NextContender());
            if (currentContender != null) break;
        }

        Console.WriteLine($@"score: {GetFinalScore(currentContender)}");
        _appLifetime.StopApplication();
    }

    private int GetFinalScore(IContender? contender)
    {
        const int notChosenValue = 10;
        if (contender == null) return notChosenValue;

        const int firstScore = 20;
        const int thirdScore = 50;
        const int fifthScore = 100;
        const int looseValue = 0;
        var contenderValue = contender.GetValue();
        Console.WriteLine($@"got score");
        return contenderValue switch
        {
            100 => firstScore,
            97 => thirdScore,
            95 => fifthScore,
            _ => looseValue
        };
    }

    private void OnStopping()
    {
        Console.WriteLine(@"stopping");
    }

    private void OnStopped()
    {
        Console.WriteLine(@"stopped");
    }
}