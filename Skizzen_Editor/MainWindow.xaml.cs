using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Skizzen_Editor
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //Anbindung UserControl an MainWindow in Canvas
            Controls.DrawingLines ucobject = new Controls.DrawingLines();
            myCanvas.Children.Add(ucobject);

            MainViewModel vm = new MainViewModel();
            vm.myCanvas = this.myCanvas;
            this.DataContext = vm;
        }
    }
}
