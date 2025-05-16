using System;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.AttributesForComponents;
public class BIOS
{
    private string _type;
    private string _version;
    private Collection<CPU> _cpu;

    public BIOS(string type, string version, Collection<CPU> cpu)
    {
        if (type is null)
        {
            throw new ArgumentException("Type cannot be null", nameof(type));
        }

        if (version is null)
        {
            throw new ArgumentException("Version cannot be null", nameof(version));
        }

        if (cpu is null)
        {
            throw new ArgumentException("Cpu cannot be null", nameof(cpu));
        }

        _type = type;
        _version = version;
        _cpu = cpu;
    }

    public Collection<CPU> CPUs => _cpu;
}
