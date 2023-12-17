using RocketLandingVerifier.RocketLandingLibrary.Dto;

namespace RocketLandingVerifier.RocketLandingLibrary;

using System;
using System.Collections.Generic;

public class LandingAreaVerifier
{
    private int[,] landingArea;
    private int platformStartX;
    private int platformStartY;
    private HashSet<(int, int)> previousLandings = new();

    public LandingAreaVerifier(LandingAreaVerifierInput input)
    {
        if (input.PlatformStartX + input.PlatformWidth > input.LandingAreaWidth || input.PlatformStartY + input.PlatformLength > input.LandingAreaLength)
        {
            throw new ArgumentException("Landing platform cannot be larger than or exceed the landing area.");
        }

        InitializeLandingArea(input);
        InitializeLandingAreaStart(input);
    }

    private void InitializeLandingArea(LandingAreaVerifierInput input)
    {
        landingArea = new int[input.LandingAreaWidth, input.LandingAreaLength];
    }

    private void InitializeLandingAreaStart(LandingAreaVerifierInput input)
    {
        platformStartX = input.PlatformStartX;
        platformStartY = input.PlatformStartY;
    }

    public string VerifyLanding(int x, int y)
    {
        if (IsOutOfPlatform(x, y))
            return "Out of platform"; //Platform dışı 
        if (IsCollision(x, y) || !IsLandingPermitted(x, y) || !IsOneUnitDistance(x, y))
            return "Collision"; //Çarpışma
        MarkArea(x, y);
        return "Landing permitted"; // İniş için uygun
    }

    private bool IsOutOfPlatform(int x, int y)
    {
        return x >= landingArea.GetLength(0) || y >= landingArea.GetLength(1) || x < 0 || y < 0;
    }

    private bool IsCollision(int x, int y)
    {
        return landingArea[x, y] == 1 || previousLandings.Contains((x, y));
    }

    private bool IsLandingPermitted(int x, int y)
    {
        return platformStartX <= x && x < platformStartX + landingArea.GetLength(0) &&
               platformStartY <= y && y < platformStartY + landingArea.GetLength(1);
    }

    private bool IsOneUnitDistance(int x, int y)
    {
        foreach (var (adjX, adjY) in GetAdjacentPositions(x, y))
        {
            if (previousLandings.Contains((adjX, adjY)))
            {
                return false;
            }
        }

        return true;
    }

    private void MarkArea(int x, int y)
    {
        landingArea[x, y] = 1;
        previousLandings.Add((x, y));
    }

    private IEnumerable<(int, int)> GetAdjacentPositions(int x, int y)
    {
        return new List<(int, int)>
        {
            (x + 1, y),
            (x - 1, y),
            (x, y + 1),
            (x, y - 1)
        };
    }
}