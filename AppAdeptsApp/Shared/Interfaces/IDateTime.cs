using System;

/// <summary>
/// IDateTime stores the time in order to display the appropriate message
/// </summary>
namespace AppAdeptsApp.Shared.Interfaces
{
    public interface IDateTime
    {
       DateTime Now { get; }
    }
}