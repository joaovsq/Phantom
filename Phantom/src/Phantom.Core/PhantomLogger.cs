using NLog;
using NLog.Conditions;
using NLog.Config;
using NLog.Targets;

namespace Phantom
{
    public enum LoggerModule
    {
        Core,
        Network
    }

    public class PhantomLogger
    {

        private readonly ILogger logger;

        public PhantomLogger(LoggerModule module)
        {
            var loggerConfig = new LoggingConfiguration();

            var consoleTarget = new ColoredConsoleTarget("PhantomConsoleTarget");

            // Console log layout
            consoleTarget.Layout = @"${date:format=yyyy-MM-dd HH\:mm\:ss} | ${logger} ${level} - ${message}  ${exception}";

            // Replaces the Info log color to Green
            var infoGreenRule = new ConsoleRowHighlightingRule();
            infoGreenRule.Condition = ConditionParser.ParseExpression("level == LogLevel.Info");
            infoGreenRule.ForegroundColor = ConsoleOutputColor.Green;

            consoleTarget.RowHighlightingRules.Add(infoGreenRule);

            // Add targets and rules
            loggerConfig.AddTarget(consoleTarget);
            loggerConfig.AddRuleForAllLevels(consoleTarget);

            LogManager.Configuration = loggerConfig;
            logger = LogManager.GetLogger(module.ToString());
        }

        public void Info(string info)
        {
            logger.Info(info);
        }

        public void Warn(string warn)
        {
            logger.Warn(warn);
        }

        public void Debug(string debug)
        {
            logger.Debug(debug);
        }

        public void Error(string error)
        {
            logger.Error(error);
        }

        public void Fatal(string fatal)
        {
            logger.Fatal(fatal);
        }

    }
}
