using SecretaryProblem4.model.interfaces;

namespace SecretaryProblem4.model;

public class Friend : IFriend
{
    private readonly List<IContender> _rejectedContenders = new List<IContender>();
    private int _maxValue = Int32.MinValue;
    private IContender? _bestContender = null;

    public void RememberContender(IContender contender)
    {
        _bestContender ??= contender;
        if (contender.GetValue() > _maxValue)
        {
            _maxValue = contender.GetValue();
            _bestContender = contender;
        }
        _rejectedContenders.Add(contender);
    }

    public int CountBetterContenders(IContender contender)
    {
        var comparedContenderResult = contender.GetValue();
        return _rejectedContenders.Count(rejectedContender => comparedContenderResult < rejectedContender.GetValue());
    }
}