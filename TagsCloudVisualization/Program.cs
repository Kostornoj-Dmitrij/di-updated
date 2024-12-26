using Autofac;
using CommandLine;
using TagsCloudVisualization.DiConfiguration;
using TagsCloudVisualization.Visualization;

namespace TagsCloudVisualization;

public static class Program
{
    public static void Main(string[] args)
    {
        Parser.Default.ParseArguments<CommandLineOptions>(args).WithParsed(commandLineOptions =>
        {
            var container = DiContainer.Configure(commandLineOptions);
            var cloudMaker = container.Resolve<TagsCloudMaker>();
            var image = cloudMaker.MakeImage();
            var imageSaver = container.Resolve<IImageSaver>();

            imageSaver.Save(image);
        }).WithNotParsed(errors =>
        {
            foreach (var error in errors)
            {
                Console.WriteLine(error.ToString());
            }
            Environment.Exit(1);
        });
    }
}