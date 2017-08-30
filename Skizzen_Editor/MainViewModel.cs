using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Skizzen_Editor
{
    //von MainProjekt
    public class MainViewModel : INotifyPropertyChanged
    {
        
        List<List<Line>> figuren = new List<List<Line>>();
        //Liste Linie
        List<Line> tmpLineList;

        Boolean mouseIsClicked = false;
        Boolean isDrawingMode = true;

        System.Drawing.Point lineStartPoint;
        SolidColorBrush brush = new SolidColorBrush(Colors.Black);

        internal Canvas myCanvas; // reference to MainView.xaml.cs:myCanvas

        public void myCanvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            tmpLineList = new List<Line>();
            mouseIsClicked = true;
            lineStartPoint = e.GetPosition(myCanvas);
        }

        private void myCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseIsClicked && isDrawingMode)
            {
                System.Drawing.Point lineEnd = e.GetPosition(myCanvas);
                Line ln = new Line();

                ln.X1 = lineStartPoint.X;
                ln.Y1 = lineStartPoint.Y;
                ln.X2 = lineEnd.X;
                ln.Y2 = lineEnd.Y;
                ln.Stroke = brush;
                ln.StrokeThickness = 2;
                myCanvas.Children.Add(ln);
                tmpLineList.Add(ln);
                //myCanvas.Children.Remove(ln);
                lineStartPoint = lineEnd;
                ln = null;
            }
        }

        private void myCanvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            var line = tmpLineList.ToList();
            figuren.Add(line);
            mouseIsClicked = false;
        }
      
      

        private string _farbe;
        public ICommand MyCommand { get; set; }
        

        public ICommand EraseCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand LoadCommand { get; set; }
        public ICommand MarkersCommand { get; set; }
        public ICommand LSCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand NsCommand { get; set; }

        public string Farbe
        {
            get { return _farbe; }
            set
            {
                _farbe = value;
                OnPropertyChange("Schwarz");
            }

        }
        public MainViewModel()
        {

            EraseCommand = new RelayCommand(
                (obj) => {
                    //löscht die letzte, die vorletzte Linie und so weiter
                    foreach (var child in figuren.Last())
                        myCanvas.Children.Remove((Line)child);
                    figuren.Remove(figuren.Last());
                }, 
                (obj) => {
                    return true;
                });
            SaveCommand = new RelayCommand(
                (obj) =>
                {
                    //noch leer
                },
                (obj) =>
                {
                    return true;
                });
            LoadCommand = new RelayCommand(
                (obj) =>
                {
                    //noch leer
                },
                (obj) =>
                {
                    return true;
                });
            MarkersCommand = new RelayCommand(
                (obj) =>
                {
                    //noch leer
                },
                (obj) =>
                {
                    return true;
                });
            LSCommand = new RelayCommand(
                (obj) =>
                {
                    //noch leer
                },
                (obj) =>
                {
                    return true;
                });
            //löscht alle gezeichneten Linien
            DeleteCommand = new RelayCommand(
                (obj) =>
                {
                    foreach (var polygon in figuren)
                    {
                        foreach (var child in polygon)
                        {
                            myCanvas.Children.Remove(child);
                        }
                    }
                    figuren.Clear();
                },
                (obj) =>
                {
                    return true;
                });
            NsCommand = new RelayCommand(
               (obj) =>
               {
                    //noch leer
                },
               (obj) =>
               {
                   return true;
               });

        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChange(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }
        private bool canexecutemethod(object parameter)
        {
            if (parameter != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void executemethod(object parameter)
        {
            Farbe = (string)parameter;
        }
    }  
}
