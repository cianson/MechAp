using System;
using System.Collections.Generic;
using System.Text;

namespace MechAp
{
    public interface INotification
    {
        void CreateNotification(string title, string message);
    }
}
