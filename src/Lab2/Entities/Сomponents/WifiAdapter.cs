using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Сomponents;
public class WifiAdapter : Component
{
    private string _wifiVersion;
    private bool _bluetooth;
    private double _pcieVersion;
    private int power;

    public WifiAdapter(string name, string wifiVersion, bool bluetooth, double pcieVersion, int power)
        : base(name)
    {
        if (wifiVersion is null)
        {
            throw new ArgumentException("Wifi cannot be null: ", nameof(wifiVersion));
        }

        if (pcieVersion <= 0)
        {
            throw new ArgumentException("Version cannot be zero: ", nameof(pcieVersion));
        }

        if (power <= 0)
        {
            throw new ArgumentException("Power cannot be zero: ", nameof(power));
        }

        _wifiVersion = wifiVersion;
        _bluetooth = bluetooth;
        _pcieVersion = pcieVersion;
        this.power = power;
    }
}
