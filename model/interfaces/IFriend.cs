namespace SecretaryProblem4.model.interfaces;

public interface IFriend
{
    public void RememberContender(IContender contender);
    public int CountBetterContenders(IContender contender);
}