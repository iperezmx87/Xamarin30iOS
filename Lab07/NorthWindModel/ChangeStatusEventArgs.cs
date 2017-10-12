using System;
using NorthWind;

namespace NorthWindModel
{
    public class ChangeStatusEventArgs : IChangeStatusEventArgs
    {
        public ChangeStatusEventArgs()
        {
        }

        public StatusOptions Status { get; set; }
    }
}
