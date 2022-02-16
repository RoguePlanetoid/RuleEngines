namespace Rules.Demo.Common;

/// <summary>
/// Eligible for Promotion
/// </summary>
public interface IEligibleForPromotion
{
    /// <summary>
    /// Registered Date
    /// </summary>
    public DateTime RegisteredDate { get; }

    /// <summary>
    /// Is Identity Verified
    /// </summary>
    public bool IsIdentityVerified { get; }
}

