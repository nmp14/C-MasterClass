namespace SRP_SingleResponsibilityPrinciple.Helpers;

class NamesFormatter
{
    public string Format(List<string> names)
    {
        return string.Join(Environment.NewLine + "-----" + Environment.NewLine, names);
    }
}