namespace Rules.Demo.Console;

/// <summary>
/// Application
/// </summary>
internal class Application
{
    private const string yes = "Y";
    private const string no = "N";

    private readonly IUsers _users;
    private readonly IEligibility _eligibility;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="users">Users</param>
    /// <param name="eligibility">Eligiblity</param>
    public Application(IUsers users, IEligibility eligibility) =>
        (_users, _eligibility) = 
        (users ?? throw new ArgumentNullException(nameof(users)), 
        eligibility ?? throw new ArgumentNullException(nameof(eligibility)));

    /// <summary>
    /// Run
    /// </summary>
    public async Task RunAsync()
    {
        bool loop;
        do
        {
            ClearOutput();
            SetOutput("Rule Engine Console Demo\n");
            var ruleEngineType = GetRuleEngineType();
            var user = await GetUserByUsernameAsync();
            if(user.IsSuccess)
            {
                SetOutput($"Welcome {user.Username}!\n");
                var isEligibleForPromotion = await _eligibility.IsEligibleForPromotionAsync(ruleEngineType, user);
                ViewPromotion(isEligibleForPromotion);
                var isEligibleForBonus = await _eligibility.IsEligibleForBonusAsync(ruleEngineType, user);
                ViewBonus(isEligibleForBonus);
                loop = GetAnswer("Do you want to Continue?");
            }
            else
            {
                loop = GetAnswer("Username does not exist! Do you want to Continue?");
            }       
        } while(loop);
    }

    /// <summary>
    /// View Promotion
    /// </summary>
    /// <param name="isEligibleForPromotion">Is Eligible For Promotion</param>
    private void ViewPromotion(bool isEligibleForPromotion)
    {
        if(isEligibleForPromotion)
        {
            SetOutput("You can see our Promotions:");
            SetOutput("- There is an extra jackpot in Bingo!");
            SetOutput("- There are extra turns in Spin!");
        }
        else
            SetOutput("You can't see our Promotions, sorry!");
    }

    /// <summary>
    /// View Bonus
    /// </summary>
    /// <param name="isEligibleForBonus">Is Eligible for Bonus</param>
    private void ViewBonus(bool isEligibleForBonus)
    {
        if(isEligibleForBonus)
        {
            var isAward = GetAnswer("\nYou can also get our special Bonus! Do you want to claim it?");
            if(isAward)
                SetOutput("You have been awarded our special Bonus!");
        }
    }

    /// <summary>
    /// Get Answer
    /// </summary>
    /// <param name="prompt">Prompt</param>
    /// <returns>True if Loop, False if not</returns>
    private bool GetAnswer(string prompt)
    {
        SetOutput($"{prompt} [{yes}/{no}]");
        return GetInput().Equals(yes, StringComparison.InvariantCultureIgnoreCase);
    }

    /// <summary>
    /// Get User by Username
    /// </summary>
    /// <returns>User Model</returns>
    private async ValueTask<UserModel> GetUserByUsernameAsync()
    {
        var type = typeof(UserModel);
        SetOutput($"Enter Username:");
        var username = GetInput();
        return await _users.GetUserAsync(username);
    }

    /// <summary>
    /// Get Rule Engine Type
    /// </summary>
    /// <returns>Rule Engine Type</returns>
    private RuleEngineType GetRuleEngineType()
    {
        var type = typeof(RuleEngineType);
        SetOutput($"Choose {nameof(RuleEngineType)}");
        foreach(RuleEngineType ruleEngineType in Enum.GetValues(type))
        {
            SetOutput($"{(int)ruleEngineType}. {ruleEngineType.GetDescription()}");
        }
        SetOutput($"Select {nameof(RuleEngineType)}:");
        return int.TryParse(GetInput(), out int result) && Enum.IsDefined(type, result)
            ? (RuleEngineType)result
            : RuleEngineType.ElsaRulesEngine;
    }

    /// <summary>
    /// Clear Output
    /// </summary>
    private void ClearOutput() =>
        System.Console.Clear();

    /// <summary>
    /// Get Input
    /// </summary>
    /// <returns>String</returns>
    private string GetInput() =>
        System.Console.ReadLine() ?? string.Empty;

    /// <summary>
    /// Set Output
    /// </summary>
    /// <param name="value">String</param>
    private void SetOutput(string value) =>
        System.Console.WriteLine(value);
}
