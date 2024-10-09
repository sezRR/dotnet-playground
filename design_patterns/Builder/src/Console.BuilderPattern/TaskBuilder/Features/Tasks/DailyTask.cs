using BuilderPattern.TaskBuilder.Common;

namespace BuilderPattern.TaskBuilder.Features.Tasks;

public class DailyTask(string name) : BaseTask(name)
{
    public override bool Complete()
    {
        Status = Common.Enums.TaskStatus.Completed;
        Console.WriteLine($"TASK COMPLETED: Daily Task {Name} with the id {TaskId} is completed!");
        return true;
    }
}