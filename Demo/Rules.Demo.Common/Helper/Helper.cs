namespace Rules.Demo.Common;

/// <summary>
/// Helper
/// </summary>
public static class Helper
{
    /// <summary>
    /// Get Age
    /// </summary>
    /// <param name="birthDate">Date of Birth</param>
    /// <param name="currentDate">Current Date</param>
    /// <returns>Age</returns>
    public static int GetAge(DateTime birthDate, DateTime currentDate)
    {
        var age = currentDate.Year - birthDate.Year;
        if ((birthDate.Month == currentDate.Month && currentDate.Day < birthDate.Day)
            || currentDate.Month < birthDate.Month)
            age--;
        return age;
    }

    /// <summary>
    /// Get Days
    /// </summary>
    /// <param name="sourceDate">Source Date</param>
    /// <param name="currentDate">Current Date</param>
    /// <returns>Days between Dates</returns>
    public static double GetDays(DateTime sourceDate, DateTime currentDate) =>
        (currentDate - sourceDate).TotalDays;
}
