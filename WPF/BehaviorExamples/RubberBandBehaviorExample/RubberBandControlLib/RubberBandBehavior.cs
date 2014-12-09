using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Interactivity;

namespace RubberBandControlLib
{
  [DescriptionAttribute("Enable RubberBand selection for WPF listbox objects.")]
  public class RubberBandBehavior : Behavior<ListBox>
  {
    protected override void OnAttached()
    {
      AssociatedObject.Loaded += AssociatedObject_Loaded;
      base.OnAttached();
    }

    void AssociatedObject_Loaded(object sender, System.Windows.RoutedEventArgs e)
    {
      var bandAdorner = new RubberBandAdorner(AssociatedObject);
      var adornerLayer = AdornerLayer.GetAdornerLayer(AssociatedObject);
      adornerLayer.Add(bandAdorner);
    }

    protected override void OnDetaching()
    {
      AssociatedObject.Loaded -= AssociatedObject_Loaded;
      base.OnDetaching();
    }
  }
}
