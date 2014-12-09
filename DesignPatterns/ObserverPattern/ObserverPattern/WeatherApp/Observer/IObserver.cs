using System;

namespace ObserverPattern.WeatherApp.Observer
{
  public interface IObserver
  {
    Guid ObserverGuid { get; set; }
    string ObserverName { get; set; }
    void Update(float temperature, float pressure, float humidity);
  }

}
