namespace Rules.Demo.Blazor;

/// <summary>
/// Application
/// </summary>
internal class Application
{
    private const string login = "/";
    private const string index = "/index";

    private readonly IUsers _users;
    private readonly IEligibility _eligibility;
    private readonly NavigationManager _navigation;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="users">Users</param>
    /// <param name="eligibility">Eligiblity</param>
    /// <param name="navigation">Navigation</param>
    public Application(IUsers users, IEligibility eligibility, NavigationManager navigation) =>
        (_users, _eligibility, _navigation) =
        (users ?? throw new ArgumentNullException(nameof(users)),
        eligibility ?? throw new ArgumentNullException(nameof(eligibility)),
        navigation ?? throw new ArgumentNullException(nameof(navigation)));

    /// <summary>
    /// Login Model
    /// </summary>
    public LoginModel LoginModel { get; private set; } = new();

    /// <summary>
    /// User Model
    /// </summary>
    public UserModel UserModel { get; private set; } = UserModel.Empty;

    /// <summary>
    /// User Models
    /// </summary>
    public IEnumerable<UserModel> UserModels { get; private set; } = Enumerable.Empty<UserModel>();

    /// <summary>
    /// Is Eligible For Promotion
    /// </summary>
    public bool IsEligibleForPromotion { get; private set; }

    /// <summary>
    /// Is Eligible For Bonus
    /// </summary>
    public bool IsEligibleForBonus { get; private set; }

    /// <summary>
    /// Is Bonus Claimed
    /// </summary>
    public bool IsBonusClaimed { get; private set; }

    /// <summary>
    /// Is Logged In
    /// </summary>
    public bool IsLoggedIn => UserModel.IsSuccess;

    /// <summary>
    /// Login
    /// </summary>
    public async Task LoginAsync()
    {
        UserModel = await _users.GetUserAsync(LoginModel.Username);
        if(UserModel.IsSuccess)
        {
            IsBonusClaimed = false;
            IsEligibleForPromotion = await _eligibility.IsEligibleForPromotionAsync(LoginModel.RuleEngineType, UserModel);
            IsEligibleForBonus = await _eligibility.IsEligibleForBonusAsync(LoginModel.RuleEngineType, UserModel);
            _navigation.NavigateTo(index);
        }
    }

    /// <summary>
    /// Fetch
    /// </summary>
    public async Task FetchAsync() =>
        UserModels = await _users.ListUsersAsync();

    /// <summary>
    /// Logout
    /// </summary>
    public void Logout()
    { 
        LoginModel = new();
        UserModel = UserModel.Empty;
        _navigation.NavigateTo(login);
    }

    /// <summary>
    /// Claim
    /// </summary>
    public void Claim() =>
        IsBonusClaimed = !IsBonusClaimed;
}
