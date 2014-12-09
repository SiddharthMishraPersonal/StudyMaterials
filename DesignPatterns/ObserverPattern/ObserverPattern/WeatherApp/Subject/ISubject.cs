using System;
using System.Collections.Generic;
using ObserverPattern.WeatherApp.Observer;

namespace ObserverPattern.WeatherApp.Subject
{
  public interface ISubject
  {
    void RegisterObserver(IObserver observer);
    void RemoveObserver(IObserver observer);
    void NotifyObserver(IObserver observer);
    void NotifyAll();

    Dictionary<Guid, IObserver> Observers { get; }
  }
}
