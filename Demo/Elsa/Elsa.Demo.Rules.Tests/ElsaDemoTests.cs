using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Rules.Demo.Common;
using System;
using System.Threading.Tasks;

namespace Elsa.Demo.Rules.Tests;

public class Tests
{
    [TestCase("01-Jan-2022 12:00:00", "01-Jan-2021 12:00:00", true, 30, true)]
    [TestCase("01-Jan-2022 12:00:00", "01-Jan-2021 12:00:00", false, 30, false)]
    [TestCase("01-Jan-2022 12:00:00", "12-Dec-2021 12:00:00", true, 30, false)]
    public async Task IsEligibleForPromotion_Valid(DateTime currentDate, DateTime registeredDate, bool isIdentityVerified, int registeredDateMinimumDaysOld, bool expected)
    {
        // Arrange
        var services = new ServiceCollection()
        .AddSingleton<IRulesConfig>(s => new RulesConfig(() => currentDate, 0, registeredDateMinimumDaysOld))
        .AddElsaRulesEngine()
        .BuildServiceProvider();
        // Act
        var factory = services.GetRequiredService<IElsaEligibleForPromotionFactory>();
        var model = new UserModel("username", registeredDate, DateTime.MinValue, isIdentityVerified);
        var actual = await factory.EvaluateAsync(model);
        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestCase("01-Jan-2022 12:00:00", "01-Jan-2021 12:00:00", "18-Mar-1980", true, 30, 25, true)]
    [TestCase("01-Jan-2022 12:00:00", "01-Jan-2021 12:00:00", "18-Mar-1980", true, 30, 25, true)]
    [TestCase("01-Jan-2022 12:00:00", "01-Jan-2021 12:00:00", "18-Mar-1980", false, 30, 25, false)]
    [TestCase("01-Jan-2022 12:00:00", "12-Dec-2021 12:00:00", "18-Mar-1980", true, 30, 25, false)]
    [TestCase("01-Jan-2022 12:00:00", "01-Jan-2021 12:00:00", "18-Mar-1980", true, 30, 55, false)]
    public async Task IsEligibleForBonus_Valid(DateTime currentDate, DateTime registeredDate, DateTime dateOfBirth, bool isIdentityVerified, int registeredDateMinimumDaysOld, int dateOfBirthMinimumAge, bool expected)
    {
        // Arrange
        var services = new ServiceCollection()
        .AddSingleton<IRulesConfig>(s => new RulesConfig(() => currentDate, dateOfBirthMinimumAge, registeredDateMinimumDaysOld))
        .AddElsaRulesEngine()
        .BuildServiceProvider();
        // Act
        var factory = services.GetRequiredService<IElsaEligibleForBonusFactory>();
        var model = new UserModel("username", registeredDate, dateOfBirth, isIdentityVerified);
        var actual = await factory.EvaluateAsync(model);
        // Assert
        Assert.AreEqual(expected, actual);
    }
}