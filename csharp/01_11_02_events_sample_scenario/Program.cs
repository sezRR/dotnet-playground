string path = @"D:\DProgramming\SelfLearning\CSharp\dotnet-playground";
PathControl pathControl = new();
pathControl.PathControlEvent += (sizeMB) =>
{
    Console.WriteLine($"> 50MB, {sizeMB}");
};

await pathControl.Control(path);

class PathControl
{
    public delegate void PathHandler(float sizeMB);
    public event PathHandler PathControlEvent;

    public async Task Control(string path)
    {
        while (true)
        {
            await Task.Delay(1000);
            
            DirectoryInfo directoryInfo = new(path);
            var files = directoryInfo.GetFiles();
            float size = await Task.Run(() =>
                directoryInfo.EnumerateFiles("*", SearchOption.AllDirectories).Sum(file => file.Length));
            float sizeMB = (size / 1024) / 1024;

            if (sizeMB > 50)
                PathControlEvent(sizeMB);
        }
    }
}