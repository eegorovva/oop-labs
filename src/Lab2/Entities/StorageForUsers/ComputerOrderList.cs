using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.StorageForUsers;
public class ComputerOrderList : IOrderList
{
    private Computer _orderList;
    private int _id;

    public ComputerOrderList(int id, Computer computer)
    {
        if (id < 0)
        {
            throw new ArgumentException("Id cannot be zero or less ", nameof(id));
        }

        _orderList = computer;
        _id = id;
    }

    public Computer Computer => _orderList;
    public int Id => _id;
}
