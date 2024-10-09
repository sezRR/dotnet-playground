using BuilderPattern.TaskBuilder.Common.Enums;

namespace BuilderPattern.TaskBuilder.Common.Interfaces;

public interface IDependency : ICommonDetails
{
    public DependencyType DependencyType { get; set; } // Maybe not required because of the generic type parameter
}