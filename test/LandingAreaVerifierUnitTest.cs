using RocketLandingVerifier.RocketLandingLibrary;
using RocketLandingVerifier.RocketLandingLibrary.Dto;
using Xunit;

namespace RocketLandingVerifier.test;

public class LandingAreaVerifierUnitTest
{
    [Fact]
    public void VerifyLanding_ShouldThrowException_WhenPlatformExceedsLandingArea()
    {
        // Arrange
        var input = new LandingAreaVerifierInput
        {
            LandingAreaWidth = 11,
            LandingAreaLength = 12,
            PlatformWidth = 6,
            PlatformLength = 17,
            PlatformStartX = 5,
            PlatformStartY = 5
        };

        // Act & Assert
        var ex = Assert.Throws<ArgumentException>(() => new LandingAreaVerifier(input,new int[0,0]));
        Assert.Equal("Landing platform cannot be larger than or exceed the landing area.", ex.Message);
    }

    [Fact]
    public void VerifyLanding_ShouldReturnLandingPermitted_WhenLandingWithinPlatform()
    {
        // Arrange
        var input = new LandingAreaVerifierInput
        {
            LandingAreaWidth = 24,
            LandingAreaLength = 32,
            PlatformWidth = 5,
            PlatformLength = 5,
            PlatformStartX = 5,
            PlatformStartY = 5
        };

        var landingAreaVerifier = new LandingAreaVerifier(input,new int[0,0]);

        // Act
        var result = landingAreaVerifier.VerifyLanding(5, 5);

        // Assert
        Assert.Equal("Landing permitted", result);
    }

    public static IEnumerable<object[]> CollisionTestCases()
    {
        yield return new object[] { 7, 8 }; // Birinci roket 7, 7 ye inmişti Çarpışma bekleniyor
        yield return new object[] { 8, 7 }; // Birinci roket 7, 7 ye inmişti Çarpışma bekleniyor
        yield return new object[] { 7, 7 }; // Birinci roket 7, 7 ye inmişti Çarpışma bekleniyor
    }

    [Theory]
    [MemberData(nameof(CollisionTestCases))]
    public void VerifyCollision_ShouldReturnCollision(int x, int y)
    {
        var input = new LandingAreaVerifierInput
        {
            LandingAreaWidth = 20,
            LandingAreaLength = 20,
            PlatformWidth = 5,
            PlatformLength = 5,
            PlatformStartX = 6,
            PlatformStartY = 6
        };
        // Arrange
        var landingVerifier = new LandingAreaVerifier(input,new int[0,0]);
        landingVerifier.VerifyLanding(7, 7); // Birinci roketin iniş yaptığı yer
        // Act
        var result = landingVerifier.VerifyLanding(x, y); // CollisionTestCases'de ki rocketlerin iniş istedikleri yerler buraya tek tek gelir...

        // Assert
        Assert.Equal("Collision", result);
    }

    [Fact]
    public void VerifyLanding_ShouldReturnOutOfPlatform_WhenLandingOutsideArea()
    {
        // Arrange
        var input = new LandingAreaVerifierInput
        {
            LandingAreaWidth = 24,
            LandingAreaLength = 32,
            PlatformWidth = 5,
            PlatformLength = 5,
            PlatformStartX = 5,
            PlatformStartY = 5
        };

        var landingAreaVerifier = new LandingAreaVerifier(input,new int[0,0]);

        // Act
        var result = landingAreaVerifier.VerifyLanding(30, 40);

        // Assert
        Assert.Equal("Out of platform", result);
    }
}