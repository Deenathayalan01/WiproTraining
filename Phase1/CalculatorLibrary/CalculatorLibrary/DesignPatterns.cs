using System;

namespace DesignPatterns
{
    /// <summary>
    /// Singleton Logger class for logging messages.
    /// </summary>
    public class Logger
    {
        private static Logger _instance;
        private static readonly object _lock = new object();

        private Logger() { }

        /// <summary>
        /// Gets the single instance of Logger.
        /// </summary>
        /// <returns>Logger instance.</returns>
        public static Logger GetInstance()
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new Logger();
                }
            }
            return _instance;
        }

        /// <summary>
        /// Logs a message to the console.
        /// </summary>
        /// <param name="message">Message to be logged.</param>
        public void Log(string message)
        {
            Console.WriteLine($"Log: {message}");
        }
    }

    /// <summary>
    /// Factory pattern for creating documents.
    /// </summary>
    public interface IDocument
    {
        void Display();
    }

    /// <summary>
    /// PDF document implementation.
    /// </summary>
    public class PdfDocument : IDocument
    {
        public void Display()
        {
            Console.WriteLine("Displaying PDF Document");
        }
    }

    /// <summary>
    /// Word document implementation.
    /// </summary>
    public class WordDocument : IDocument
    {
        public void Display()
        {
            Console.WriteLine("Displaying Word Document");
        }
    }

    /// <summary>
    /// Factory class for document creation.
    /// </summary>
    public class DocumentFactory
    {
        public static IDocument CreateDocument(string type)
        {
            return type switch
            {
                "PDF" => new PdfDocument(),
                "Word" => new WordDocument(),
                _ => throw new ArgumentException("Invalid document type")
            };
        }
    }

    /// <summary>
    /// Interface for observers in the Observer pattern.
    /// </summary>
    public interface IObserver
    {
        void Update(string weatherData);
    }

    /// <summary>
    /// Weather station that notifies observers of weather changes.
    /// </summary>
    public class WeatherStation
    {
        private readonly List<IObserver> _observers = new();
        private string _weatherData;

        public void AddObserver(IObserver observer) => _observers.Add(observer);
        public void RemoveObserver(IObserver observer) => _observers.Remove(observer);

        public void SetWeatherData(string data)
        {
            _weatherData = data;
            NotifyObservers();
        }

        private void NotifyObservers()
        {
            foreach (var observer in _observers)
            {
                observer.Update(_weatherData);
            }
        }
    }

    /// <summary>
    /// Observer implementation for displaying weather updates.
    /// </summary>
    public class WeatherDisplay : IObserver
    {
        public void Update(string weatherData)
        {
            Console.WriteLine($"Weather updated: {weatherData}");
        }
    }

}
