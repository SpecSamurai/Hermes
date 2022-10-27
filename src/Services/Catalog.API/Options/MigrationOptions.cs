using System.ComponentModel.DataAnnotations;

namespace Hermes.Catalog.API.Options;

public class MigrationOptions
{
    private const string OptionsValidationErrorMessage = "Value for {0} must be greater or equal 0.";

    [Range(0, int.MaxValue, ErrorMessage = OptionsValidationErrorMessage)]
    public int MigrationRetryCount { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = OptionsValidationErrorMessage)]
    public int RetrySleepDurationInSeconds { get; set; }
}