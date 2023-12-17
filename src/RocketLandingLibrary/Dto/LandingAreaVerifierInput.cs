using System.ComponentModel.DataAnnotations;

namespace RocketLandingVerifier.RocketLandingLibrary.Dto;

public class LandingAreaVerifierInput
{
    [Required]
    public int LandingAreaWidth { get; set; }
    [Required]
    public int LandingAreaLength { get; set; }
    [Required]
    public int PlatformWidth { get; set; }
    [Required]
    public int PlatformLength { get; set; }
    [Required]
    public int PlatformStartX { get; set; }
    [Required]
    public int PlatformStartY { get; set; }
}
