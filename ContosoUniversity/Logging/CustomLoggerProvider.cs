using System;
using System.IO;
using Microsoft.Extensions.Logging;
using System.Threading;

namespace ContosoUniversity.Logging
{
    public class CustomLoggerProvider : ILoggerProvider
    {
        
        public ILogger CreateLogger(string categoryName)
        {
            return new CustomLogger();
        }

        public void Dispose()
        {
            
        }

        private class CustomLogger : ILogger
        {
            private readonly string tempDirPath = Environment.GetEnvironmentVariable("TEMP");
            private static SemaphoreSlim _fileLock = new SemaphoreSlim(1);

            public bool IsEnabled(LogLevel logLevel)
            {
                return true;
            }

            public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
            {
                string logFilePath = Path.Combine(tempDirPath, "log.txt");
                var outputLine = formatter(state, exception);
                WriteTextAsync(outputLine, logFilePath);
                Console.WriteLine(outputLine);
            }

            static async void WriteTextAsync(string text, string path)
            {
                try
                {
                    await _fileLock.WaitAsync();
                    using (StreamWriter outputFile = File.AppendText(path))
                    {
                        await outputFile.WriteLineAsync(text);
                        outputFile.Dispose();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);

                }
                finally
                {
                    _fileLock.Release();
                }
                
            }

            public IDisposable BeginScope<TState>(TState state)
            {
                return null;
            }
        }
    }
}
