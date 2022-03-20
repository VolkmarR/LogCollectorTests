using Serilog;

namespace LogCollectorTests.Helpers
{
    public class LogDataHelper
    {
        record Person(string FirstName, string LastName, DateTime BirthDay);

        private readonly ILogger<LogDataHelper> _logger;

        public LogDataHelper(ILogger<LogDataHelper> logger)
        {
            _logger = logger;
        }

        public LogDataHelper LogSimpleMessages()
        {
            _logger.LogDebug("Simple debug message");
            _logger.LogInformation("Simple information message");
            _logger.LogWarning("Simple warning message");
            _logger.LogError("Simple error message");
            _logger.LogCritical("Simple critical message");

            return this;
        }

        public LogDataHelper LogMessagesWithValues()
        {
            var rnd = new Random();
            _logger.LogInformation("Information message with an random ID {id} (as integer)", rnd.Next(1, 10));
            _logger.LogInformation("Information message with another random ID {id} (as guid)", Guid.NewGuid());
            _logger.LogInformation("Information message with multiple values: Current Date values {year}-{month}-{day}", DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);

            var person = new Person("Firstname " + rnd.Next(1, 10), "Lastname " + rnd.Next(1, 10), new DateTime(1974, rnd.Next(1, 12), rnd.Next(1, 28)));
            _logger.LogInformation("Information message with simple object: {person}", person);

            return this;
        }

        public void LogException()
        {
            try
            {
                throw new InvalidOperationException("Generated Exception with an inner exception", new Exception("Dummy inner exception"));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error message with and exception");
            }
        }

        public LogDataHelper LogMessagesWithSerilog()
        {
            var contextLogger = Log.ForContext("MethodName", nameof(LogMessagesWithSerilog));
            contextLogger.Information("Infomation message using serilog context logger");
            contextLogger.Warning("Warning message using serilog context logger");

            return this;
        }

    }
}
