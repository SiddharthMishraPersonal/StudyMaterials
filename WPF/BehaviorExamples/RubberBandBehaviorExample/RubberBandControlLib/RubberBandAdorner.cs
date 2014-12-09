using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace RubberBandControlLib
{
  public class RubberBandAdorner : Adorner
  {
    private Point _startPoint;
    private Point _currentPoint;
    private Brush _brush;
    private bool _flag;
    private ScrollViewer _scrollViewer;
    private ScrollBar _scrollBar;

    public RubberBandAdorner(UIElement adornerUIElement) : base(adornerUIElement)
    {
      IsHitTestVisible = false;
      adornerUIElement.MouseMove += adornerUIElement_MouseMove;
      adornerUIElement.MouseLeftButtonDown += adornerUIElement_MouseLeftButtonDown;
      adornerUIElement.PreviewMouseLeftButtonUp += adornerUIElement_PreviewMouseLeftButtonUp;
      _brush = new SolidColorBrush(SystemColors.HighlightColor);
      _brush.Opacity = 0.3;
    }

    protected override void OnRender(DrawingContext drawingContext)
    {
      var rect = new Rect(_startPoint, _currentPoint);
      drawingContext.DrawGeometry(_brush, new Pen(SystemColors.HighlightBrush,1),new RectangleGeometry(rect) );
      base.OnRender(drawingContext);
    }

    void adornerUIElement_PreviewMouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
      _currentPoint= new Point(0,0);
      _startPoint=new Point(0,0);
      AdornedElement.ReleaseMouseCapture();
      InvalidateVisual();
      _flag = false;
    }

    void adornerUIElement_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
      var selector = AdornedElement as ListBox;

      if (selector.SelectedItems != null &&
          (selector.SelectionMode == SelectionMode.Extended || selector.SelectionMode == SelectionMode.Multiple))
      {
        selector.SelectedItems.Clear();
      }

      //Take the mouse point from where we have to start selection.
      _startPoint = Mouse.GetPosition(AdornedElement);
      Mouse.Capture(selector);
      _flag = true;
    }

    void adornerUIElement_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
    {
      if (e.LeftButton == MouseButtonState.Pressed && _flag)
      {
        _currentPoint = Mouse.GetPosition(AdornedElement);

        var selector = AdornedElement as Selector;

        if (_scrollViewer == null)
        {
          _scrollViewer = FindVisualChild<ScrollViewer>(selector);
        }

        if (selector.Items.Count > 0)
        {
          if (_currentPoint.Y > ((FrameworkElement) AdornedElement).ActualHeight &&
              _scrollViewer.VerticalOffset < selector.ActualHeight && _scrollBar.Visibility == Visibility.Visible)
          {
            _startPoint.Y -= 50;
          }
          else
          {
            if (_currentPoint.Y < 0 && _scrollViewer.VerticalOffset > 0 && _scrollBar.Visibility == Visibility.Visible)
            {
              _startPoint.Y += 50;
            }
          }
        }

        InvalidateVisual();

        foreach (var obj in selector.Items)
        {
          var item = selector.ItemContainerGenerator.ContainerFromItem(obj) as ListBoxItem;
          if(item==null) continue;

          var point = item.TransformToAncestor(AdornedElement).Transform(new Point(0, 0));
          var bandRect = new Rect(_startPoint, _currentPoint);
          var elementRect = new Rect(point.X, point.Y, item.ActualWidth, item.ActualHeight);

          if (bandRect.IntersectsWith(elementRect))
          {
            item.IsSelected = true;
          }
          else
          {
            item.IsSelected = false;
          }
        }

      }
    }

    private static TChildItem FindVisualChild<TChildItem>(DependencyObject dependencyObject) where TChildItem : DependencyObject
    {
      for (int i = 0; i < VisualTreeHelper.GetChildrenCount(dependencyObject); i++)
      {
        var child = VisualTreeHelper.GetChild(dependencyObject, i);

        if (child != null && child is TChildItem)
        {
          return (TChildItem) child;
        }
        else
        {
          var childOfChild = FindVisualChild<TChildItem>(child);

          if (childOfChild != null)
          {
            return childOfChild;
          }
          }
      }

      return null;
    }
  }
}
