using TechChallangeClassLibrary.Enum;

namespace TechChallangeClassLibrary.Interfaces
{
    public interface IOutput
    {
        string Name { get; }
        OutputType Type { get; }

        bool Send();
    }
}