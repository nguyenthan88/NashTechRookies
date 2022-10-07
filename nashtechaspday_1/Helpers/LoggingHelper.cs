namespace Middleware.Example
{
    public static class LoggingHelper
    {
        public static void WriteToFile(string directoryPath, string fileName, string textContent)
        {
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            string filePath = directoryPath + "\\" + fileName;

            if (!File.Exists(filePath))
            {
                File.WriteAllText(filePath, textContent);
            }
            else
            {
                textContent = $"{Environment.NewLine}{textContent}";
                File.AppendAllText(filePath, textContent);
            }
        }
    }
}