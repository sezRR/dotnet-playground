namespace BuilderPattern.TaskBuilder.Common.Interfaces;

public interface ICommonDetails
{
    string Name { get; set; }
    string? Description { get; set; }
    string? Details { get; set; }
}
