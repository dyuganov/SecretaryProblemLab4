using System.Collections;

namespace SecretaryProblem4.model.interfaces;

public interface IHall : IEnumerable
{
    public IContender NextContender();
}