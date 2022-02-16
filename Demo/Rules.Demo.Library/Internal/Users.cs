namespace Rules.Demo.Library;

/// <summary>
/// Users
/// </summary>
internal class Users : IUsers
{
    private readonly IEnumerable<UserModel> _users;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="rulesConfig">Rules Config</param>
    public Users(IRulesConfig rulesConfig)
    {
        var verified = true;
        var notVerified = false;
        var recentRegistered = GetDaysAgoDateTime(rulesConfig.CurrentDate, rulesConfig.RegisteredDateMinimumDays - 10);
        var alreadyRegistered = GetDaysAgoDateTime(rulesConfig.CurrentDate, rulesConfig.RegisteredDateMinimumDays + 10);
        var dateOfBirth = GetYearsAgoDateTime(rulesConfig.CurrentDate, rulesConfig.DateOfBirthMinimumAge + 10);
        var youngDateOfBirth = GetYearsAgoDateTime(rulesConfig.CurrentDate, rulesConfig.DateOfBirthMinimumAge - 10);

        _users = new List<UserModel>()    
        {
            new UserModel("recent", recentRegistered, dateOfBirth, notVerified),
            new UserModel("registered", alreadyRegistered, dateOfBirth, notVerified),
            new UserModel("verified", alreadyRegistered, dateOfBirth, verified),

            new UserModel("recentyoung", recentRegistered, youngDateOfBirth, notVerified),
            new UserModel("registeredyoung", alreadyRegistered, youngDateOfBirth, notVerified),
            new UserModel("verifiedyoung", alreadyRegistered, youngDateOfBirth, verified),
        };
    }

    /// <summary>
    /// Get Days Ago Date Time
    /// </summary>
    /// <param name="currentDate">Current Date</param>
    /// <param name="days">Number of Days</param>
    /// <returns>Date Time</returns>
    private static DateTime GetDaysAgoDateTime(DateTime currentDate, int days) =>
        currentDate.AddDays(-days);

    /// <summary>
    /// Get Years Ago Date Time
    /// </summary>
    /// <param name="currentDate">Current Date</param>
    /// <param name="years">Number of Years</param>
    /// <returns>Date Time</returns>
    private static DateTime GetYearsAgoDateTime(DateTime currentDate, int years) =>
        currentDate.AddYears(-years);

    /// <summary>
    /// Get User
    /// </summary>
    /// <param name="username">Username</param>
    /// <returns>User Model</returns>
    public ValueTask<UserModel> GetUserAsync(string username) =>
        ValueTask.FromResult(_users.SingleOrDefault(s => s.Username.Equals(username)) ?? UserModel.Empty);

    /// <summary>
    /// List Users
    /// </summary>
    /// <returns>Enumerable of UserModel</returns>
    public ValueTask<IEnumerable<UserModel>> ListUsersAsync() =>
        ValueTask.FromResult(_users);
}
