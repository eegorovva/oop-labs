using System;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Сomponents;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;
public class ComputerCase : Component
{
    private Collection<string> _formFactorForMotherBoard;
    private double _heightForCard;
    private double _widthForCard;
    private double _height;
    private double _width;
    private double _lenght;

    public ComputerCase(string name, Collection<string> formFactorForMotherBoard, double heightForCard, double widthForCard, double height, double width, double lenght)
        : base(name)
    {
        if (formFactorForMotherBoard is null)
        {
            throw new ArgumentException("Formfactor cannot be null", nameof(formFactorForMotherBoard));
        }

        if (heightForCard <= 0)
        {
            throw new ArgumentException("height cannot be zero", nameof(heightForCard));
        }

        if (widthForCard <= 0)
        {
            throw new ArgumentException("width cannot be zero", nameof(widthForCard));
        }

        if (height <= 0)
        {
            throw new ArgumentException("height cannot be zero", nameof(height));
        }

        if (width <= 0)
        {
            throw new ArgumentException("width cannot be zero", nameof(width));
        }

        if (lenght <= 0)
        {
            throw new ArgumentException("lenght cannot be zero", nameof(lenght));
        }

        _formFactorForMotherBoard = formFactorForMotherBoard;
        _heightForCard = heightForCard;
        _widthForCard = widthForCard;
        _height = height;
        _width = width;
        _lenght = lenght;
    }

    public Collection<string> Formfactor => _formFactorForMotherBoard;
    public double Height => _height;
    public double Width => _width;
    public double Lenght => _lenght;
    public double HeightForCard => _heightForCard;
    public double WidthForCard => _widthForCard;
}
