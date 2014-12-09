using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObserverPattern.WeatherApp.Observer;

namespace ObserverPattern.WeatherApp.Subject
{
  public class WeatherData : ISubject
  {

    private Dictionary<Guid, IObserver> _observers = new Dictionary<Guid, IObserver>();
    private float _temperature;
    private float _humidity;
    private float _pressure;


    public WeatherData()
    {
      _temperature = 25;
      _pressure = 109;
      _humidity = 78;
    }


    #region ISubject Members

    public void RegisterObserver(IObserver observer)
    {
      if (Observers.ContainsKey(observer.ObserverGuid))
        Observers[observer.ObserverGuid] = observer;
      else
      {
        Observers.Add(observer.ObserverGuid, observer);
      }
    }

    public void RemoveObserver(IObserver observer)
    {
      if (Observers.ContainsKey(observer.ObserverGuid))
      {
        Observers.Remove(observer.ObserverGuid);
      }
      else
      {
        throw new Exception(string.Format("Observer '{0}' not found.", observer.ObserverGuid));
      }
    }

    public void NotifyObserver(IObserver observer)
    {
      Observers[observer.ObserverGuid].Update(_temperature + observer.ObserverName.Length, _pressure + observer.ObserverName.Length, _humidity + observer.ObserverName.Length);
    }

    public Dictionary<Guid, IObserver> Observers
    {
      get { return _observers; }
    }

    public void NotifyAll()
    {
      foreach (KeyValuePair<Guid, IObserver> keyValuePair in Observers)
      {
        keyValuePair.Value.Update(_temperature + keyValuePair.Value.ObserverName.Length, _pressure + keyValuePair.Value.ObserverName.Length, _humidity + keyValuePair.Value.ObserverName.Length);
      }
    }

    #endregion
  }
}
