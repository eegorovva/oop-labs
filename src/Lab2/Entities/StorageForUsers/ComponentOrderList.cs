using System;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Repoz;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Сomponents;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.StorageForUsers;
public class ComponentOrderList : IOrderList
{
    private Collection<Component> _orderList;
    private int _id;

    public ComponentOrderList(int id)
    {
        if (id < 0)
        {
            throw new ArgumentException("Id cannot be zero or less ", nameof(id));
        }

        _orderList = new Collection<Component>();
        _id = id;
    }

    public Collection<Component> ListWithComponents => _orderList;
    public int Id => _id;

    public void Add(string name, Storage storage)
    {
        if (name is null)
        {
            throw new ArgumentException("Name cannot be null ", nameof(name));
        }

        if (storage is null)
        {
            throw new ArgumentException("Storage cannot be null ", nameof(storage));
        }

        if (storage.FindComponent(name) != null)
        {
            _orderList.Add(storage.GetComponent(name));
        }
    }
}
