namespace BuilderPattern.TaskBuilder.Common.Interfaces.Builders;

public interface IBuilder<out TOutput> where TOutput : class
{
    TOutput Build();
}
