using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern.WeatherApp.Observer
{
  public class ObserverObject : IObserver
  {

    private Guid _observerGuid;
    private string _observerName;

    public ObserverObject(string name)
    {
      ObserverGuid = Guid.NewGuid();
      ObserverName = name;
    }

    #region IObserver Members

    public void Update(float temperature, float pressure, float humidity)
    {
      Console.Write("Observer: {0},\t ", ObserverName);
      Console.WriteLine("Temperature: {0} C,\tPressure: {1} psi,\tHumidity:{2} %", temperature, pressure, humidity);
    }

    public Guid ObserverGuid
    {
      get { return _observerGuid; }
      set { _observerGuid = value; }
    }

    public string ObserverName
    {
      get { return _observerName; }
      set { _observerName = value; }
    }

    #endregion
  }
}
