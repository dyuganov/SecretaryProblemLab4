using SecretaryProblem4.model.interfaces;

namespace SecretaryProblem4.model;

public class Contender : IContender
{
    private readonly String _name;

    private readonly String _surname;

    private readonly int _value;

    public Contender(string name, string surname, int value)
    {
        _name = name;
        _surname = surname;
        _value = value;
    }
    
    public String GetName()
    {
        return _name;
    }

    public String GetSurname()
    {
        return _surname;
    }

    public String GetFullName()
    {
        return _name + ' ' + _surname;
    }

    public int GetValue()
    {
        return _value;
    }
}