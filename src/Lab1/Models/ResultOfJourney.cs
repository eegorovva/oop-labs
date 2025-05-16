using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models;
public abstract class ResultOfJourney
{
    private string _info;
    private Ship _ship;

    protected ResultOfJourney(string info, Ship ship)
    {
        if (string.IsNullOrEmpty(info))
        {
            throw new ArgumentException("Info cannot be empty ", nameof(info));
        }

        if (ship == null)
        {
            throw new ArgumentException("ship cannot be null ", nameof(ship));
        }

        _ship = ship;
        _info = info;
    }

    public Ship Ship => _ship;
    public string Info => _info;
}
