namespace Rules.Demo.Common;

/// <summary>
/// User Model
/// </summary>
public class UserModel : IEligibleForBonus, IEligibleForPromotion
{
    /// <summary>
    /// Username
    /// </summary>
    public string Username { get; }

    /// <summary>
    /// Registered Date
    /// </summary>
    public DateTime RegisteredDate { get; }

    /// <summary>
    /// Date of Birth
    /// </summary>
    public DateTime DateOfBirth { get; }

    /// <summary>
    /// Is Identity Verified
    /// </summary>
    public bool IsIdentityVerified { get; }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="username">Username</param>
    /// <param name="registeredDate">Registered Date</param>
    /// <param name="dateOfBirth">Date of Birth</param>
    /// <param name="isIdentityVerified">Is Identity Verified</param>
    public UserModel(string username, DateTime registeredDate, DateTime dateOfBirth, bool isIdentityVerified) =>
        (Username, RegisteredDate, DateOfBirth, IsIdentityVerified) = (username, registeredDate, dateOfBirth, isIdentityVerified);

    /// <summary>
    /// Empty
    /// </summary>
    public static UserModel Empty =>
        new(string.Empty, DateTime.MinValue, DateTime.MinValue, false);

    /// <summary>
    /// Is Success
    /// </summary>
    public bool IsSuccess => 
        !string.IsNullOrEmpty(Username);
}
