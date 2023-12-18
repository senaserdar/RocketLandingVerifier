using RocketLandingVerifier.RocketLandingLibrary.Dto;

namespace RocketLandingVerifier.RocketLandingLibrary;

using System;
using System.Collections.Generic;

public class LandingAreaVerifier
{
    private int[,] _landingArea;
    private int _platformStartX;
    private int _platformStartY;
    private int _platformEndX;
    private int _platformEndY;
    private HashSet<(int, int)> _previousLandings = new();

    public LandingAreaVerifier(LandingAreaVerifierInput input, int[,] landingArea)
    {
        if (input.PlatformStartX + input.PlatformWidth > input.LandingAreaWidth || input.PlatformStartY + input.PlatformLength > input.LandingAreaLength)
        {
            throw new ArgumentException("Landing platform cannot be larger than or exceed the landing area.");
        }

        _landingArea = landingArea;
        InitializeLandingArea(input);
        InitializeLandingAreaStart(input);
    }

    private void InitializeLandingArea(LandingAreaVerifierInput input)
    {
        _landingArea = new int[input.LandingAreaWidth, input.LandingAreaLength];
    }

    private void InitializeLandingAreaStart(LandingAreaVerifierInput input)
    {
        _platformStartX = input.PlatformStartX;
        _platformStartY = input.PlatformStartY;  
        _platformEndX = input.PlatformStartX + input.PlatformWidth;
        _platformEndY = input.PlatformStartY + input.PlatformLength;
    }

    public string VerifyLanding(int x, int y)
    {
        if (IsOutOfPlatform(x, y))
            return "Out of platform"; //Platform dışı 
        if (IsCollision(x, y) || !IsOneUnitDistance(x, y))
            return "Collision"; //Çarpışma
        MarkArea(x, y);
        return "Landing permitted"; // İniş için uygun
    }

    private bool IsOutOfPlatform(int x, int y)
    {
        return _platformStartX > x || x > _platformEndX || _platformStartY > y || y > _platformEndY;
    }

    private bool IsCollision(int x, int y)
    {
        return _landingArea[x, y] == 1 || _previousLandings.Contains((x, y));
    }
    
    private bool IsOneUnitDistance(int x, int y)
    {
        foreach (var (adjX, adjY) in GetAdjacentPositions(x, y))
        {
            if (_previousLandings.Contains((adjX, adjY)))
            {
                return false;
            }
        }

        return true;
    }

    private void MarkArea(int x, int y)
    {
        _landingArea[x, y] = 1;
        _previousLandings.Add((x, y));
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