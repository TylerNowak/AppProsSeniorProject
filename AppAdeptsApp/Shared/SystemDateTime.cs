using System;
using AppAdeptsApp.Shared.Interfaces;

/// <summary>
/// SystemDateTime retrieve the current system time
/// </summary>
namespace AppAdeptsApp.Shared
{
    public class SystemDateTime: IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}