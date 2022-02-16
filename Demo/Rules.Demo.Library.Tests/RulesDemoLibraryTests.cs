using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Rules.Demo.Library.Tests;

/// <summary>
/// Rules Demo Library Tests
/// </summary>
public class RulesDemoLibraryTests
{
    [TestCase(RuleEngineType.ElsaRulesEngine, "recent", "01-Jan-2022 12:00:00", 24, 30, false)]
    [TestCase(RuleEngineType.ElsaRulesEngine, "registered", "01-Jan-2022 12:00:00", 24, 30, false)]
    [TestCase(RuleEngineType.ElsaRulesEngine, "verified", "01-Jan-2022 12:00:00", 24, 30, true)]
    [TestCase(RuleEngineType.ElsaRulesEngine, "recentyoung", "01-Jan-2022 12:00:00", 24, 30, false)]
    [TestCase(RuleEngineType.ElsaRulesEngine, "registeredyoung", "01-Jan-2022 12:00:00", 24, 30, false)]
    [TestCase(RuleEngineType.ElsaRulesEngine, "verifiedyoung", "01-Jan-2022 12:00:00", 24, 30, true)]

    [TestCase(RuleEngineType.MicrosoftRulesEngine, "recent", "01-Jan-2022 12:00:00", 24, 30, false)]
    [TestCase(RuleEngineType.MicrosoftRulesEngine, "registered", "01-Jan-2022 12:00:00", 24, 30, false)]
    [TestCase(RuleEngineType.MicrosoftRulesEngine, "verified", "01-Jan-2022 12:00:00", 24, 30, true)]
    [TestCase(RuleEngineType.MicrosoftRulesEngine, "recentyoung", "01-Jan-2022 12:00:00", 24, 30, false)]
    [TestCase(RuleEngineType.MicrosoftRulesEngine, "registeredyoung", "01-Jan-2022 12:00:00", 24, 30, false)]
    [TestCase(RuleEngineType.MicrosoftRulesEngine, "verifiedyoung", "01-Jan-2022 12:00:00", 24, 30, true)]
    public async Task IsEligibleForPromotion_Valid(RuleEngineType rulesEngine, string username, DateTime currentDate, int dateOfBirthMinimumAge, int registeredDateMinimumDaysOld, bool expected)
    {
        // Arrange
        var services = new ServiceCollection()
        .AddDemo(() => currentDate, dateOfBirthMinimumAge, registeredDateMinimumDaysOld)
        .BuildServiceProvider();
        // Act
        var eligiblity = services.GetRequiredService<IEligibility>();
        var users = services.GetRequiredService<IUsers>();
        var model = await users.GetUserAsync(username);
        var actual = await eligiblity.IsEligibleForPromotionAsync(rulesEngine, model);
        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestCase(RuleEngineType.ElsaRulesEngine, "recent", "01-Jan-2022 12:00:00", 24, 30, false)]
    [TestCase(RuleEngineType.ElsaRulesEngine, "registered", "01-Jan-2022 12:00:00", 24, 30, false)]
    [TestCase(RuleEngineType.ElsaRulesEngine, "verified", "01-Jan-2022 12:00:00", 24, 30, true)]
    [TestCase(RuleEngineType.ElsaRulesEngine, "recentyoung", "01-Jan-2022 12:00:00", 24, 30, false)]
    [TestCase(RuleEngineType.ElsaRulesEngine, "registeredyoung", "01-Jan-2022 12:00:00", 24, 30, false)]
    [TestCase(RuleEngineType.ElsaRulesEngine, "verifiedyoung", "01-Jan-2022 12:00:00", 24, 30, false)]

    [TestCase(RuleEngineType.MicrosoftRulesEngine, "recent", "01-Jan-2022 12:00:00", 24, 30, false)]
    [TestCase(RuleEngineType.MicrosoftRulesEngine, "registered", "01-Jan-2022 12:00:00", 24, 30, false)]
    [TestCase(RuleEngineType.MicrosoftRulesEngine, "verified", "01-Jan-2022 12:00:00", 24, 30, true)]
    [TestCase(RuleEngineType.MicrosoftRulesEngine, "recentyoung", "01-Jan-2022 12:00:00", 24, 30, false)]
    [TestCase(RuleEngineType.MicrosoftRulesEngine, "registeredyoung", "01-Jan-2022 12:00:00", 24, 30, false)]
    [TestCase(RuleEngineType.MicrosoftRulesEngine, "verifiedyoung", "01-Jan-2022 12:00:00", 24, 30, false)]

    public async Task IsEligibleForBonus_Valid(RuleEngineType ruleEngineType, string username, DateTime currentDate, int dateOfBirthMinimumAge, int registeredDateMinimumDaysOld, bool expected)
    {
        // Arrange
        var services = new ServiceCollection()
        .AddDemo(() => currentDate, dateOfBirthMinimumAge, registeredDateMinimumDaysOld)
        .BuildServiceProvider();
        // Act
        var eligiblity = services.GetRequiredService<IEligibility>();
        var users = services.GetRequiredService<IUsers>();
        var model = await users.GetUserAsync(username);
        var actual = await eligiblity.IsEligibleForBonusAsync(ruleEngineType, model);
        // Assert
        Assert.AreEqual(expected, actual);
    }
}