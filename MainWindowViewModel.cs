using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Media;
using System.ComponentModel;

namespace GTSP_2
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        #region Data Members

        /// <summary>
        /// The list of rectangles that is displayed in the ListBox.
        /// </summary>
        private ObservableCollection<EllipseViewModel> ellipses = new ObservableCollection<EllipseViewModel>();

        /// <summary>
        /// List of connections between rectangles.
        /// </summary>
        private ObservableCollection<ConnectionViewModel> connections = new ObservableCollection<ConnectionViewModel>();

        #endregion Data Members

        public MainWindowViewModel()
        {
            //
            // Populate the view model with some example data.
            //

            var r1 = new EllipseViewModel(10, 10, 50, 50, Colors.Blue);
            ellipses.Add(r1);
            var r2 = new EllipseViewModel(70, 60, 50, 50, Colors.Green);
            ellipses.Add(r2);
            var r3 = new EllipseViewModel(150, 130, 50, 50, Colors.Purple);
            ellipses.Add(r3);

            //
            // Add some connections between rectangles.
            //
            connections.Add(new ConnectionViewModel(r1, r2));
            connections.Add(new ConnectionViewModel(r2, r3));
        }

        /// <summary>
        /// The list of rectangles that is displayed in the ListBox.
        /// </summary>
        public ObservableCollection<EllipseViewModel> Ellipses
        {
            get
            {
                return ellipses;
            }
        }

        /// <summary>
        /// List of connections between rectangles.
        /// </summary>
        public ObservableCollection<ConnectionViewModel> Connections
        {
            get
            {
                return connections;
            }
        }

        #region INotifyPropertyChanged Members

        /// <summary>
        /// Raises the 'PropertyChanged' event when the value of a property of the view model has changed.
        /// </summary>
        private void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        /// <summary>
        /// 'PropertyChanged' event that is raised when the value of a property of the view model has changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}
