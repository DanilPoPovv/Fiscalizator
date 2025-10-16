using System.IO;
using System.Text;
namespace Fiscalizator.Logger
{
    public class Logger
    {
        public void FileLog(string message)
        {
            string path = Path.Combine(AppContext.BaseDirectory, "log.txt");
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{DateTime.Now}");
            sb.AppendLine(message);
            sb.AppendLine("================================================================");
            File.AppendAllText(path, sb.ToString());
        }

    }
}
