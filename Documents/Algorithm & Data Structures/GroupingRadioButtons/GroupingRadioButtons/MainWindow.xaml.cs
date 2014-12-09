using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;
using System.IO;

namespace GroupingRadioButtons
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
    }

    private void radRibbonBtnBrowseArchivedLogFile_Click(object sender, RoutedEventArgs e)
    {
      var dialog = new OpenFileDialog();
      //dialog.DefaultExt = "*.HTS";
      dialog.Filter = "DB3 files (*.DB3)|*.DB3";
      dialog.FilterIndex = 1;
      dialog.Title = "Please select a archived log file.";
      dialog.InitialDirectory = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), "SILAS");

      //DialogResult result = dialog.ShowDialog();

      Properties.Settings.Default.ArchivedPath = "";
    }

    private void RadioButton_Checked(object sender, RoutedEventArgs e)
    {

    }
  }
}
