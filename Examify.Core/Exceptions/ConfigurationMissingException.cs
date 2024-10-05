namespace Examify.Core.Exceptions;

public class ConfigurationMissingException(string sectionName)
    : Exception($"Configuration section {sectionName} is missing.");