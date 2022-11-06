using System;
using System.Collections.Generic;

namespace PL
{
    internal class MenuList
    {
        private readonly List<MenuItem> _menuItems;

        public MenuList()
        {
            _menuItems = new List<MenuItem>();
        }

        public void Add(string name, Action action)
        {
            _menuItems.Add(new MenuItem(name, action, _menuItems.Count));
        }
        public int Length => _menuItems.Count;
        public MenuItem this[int i] => _menuItems[i];
    }
}