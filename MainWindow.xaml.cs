using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

using System;
using System.Text;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Controls.Primitives;

namespace GTSP_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainWindowViewModel viewModel;

        /// <summary>
        /// Setup window and Canvas
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            this.viewModel = (MainWindowViewModel)this.DataContext;
            viewModel.Ellipses.Add(new EllipseViewModel(80, 120, 50, 50, Colors.Blue));
            this.MouseLeftButtonDown += Window_OnMouseLeftClick;
        }

        /// <summary>
        /// Handle the user dragging the rectangle.
        /// </summary>
        private void Thumb_DragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
        {
            Thumb thumb = (Thumb)sender;
            EllipseViewModel ellipse = (EllipseViewModel)thumb.DataContext;

            // Update the the position of the rectangle in the view-model.
            ellipse.X += e.HorizontalChange;
            ellipse.Y += e.VerticalChange;
        }

        private void Window_OnMouseLeftClick(object sender, MouseButtonEventArgs e)
        {
            var aa = sender as EllipseViewModel;

            Point p = e.GetPosition(this);
            viewModel.Ellipses.Add(new EllipseViewModel(p.X - 25, p.Y - 25, 50, 50, Colors.Blue));
        }

        private void Ellipse_OnMouseLeftClick(object sender, MouseButtonEventArgs e)
        {
            
        }
    }
}
