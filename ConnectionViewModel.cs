using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTSP_2
{
    class ConnectionViewModel
    {
        /// <summary>
        /// References to the two rectangles that are connected.
        /// </summary>
        private EllipseViewModel rect1 = null;
        private EllipseViewModel rect2 = null;

        public ConnectionViewModel()
        {
        }

        public ConnectionViewModel(EllipseViewModel rect1, EllipseViewModel rect2)
        {
            this.rect1 = rect1;
            this.rect2 = rect2;
        }

        /// <summary>
        /// References to the first connected rectangle.
        /// </summary>
        public EllipseViewModel Rect1
        {
            get => rect1;
            set
            {
                rect1 = value;
                OnPropertyChanged("Rect1");
            }
        }

        /// <summary>
        /// References to the second connected rectangle.
        /// </summary>
        public EllipseViewModel Rect2
        {
            get => rect2;
            set
            {
                rect2 = value;
                OnPropertyChanged("Rect2");
            }
        }

        #region INotifyPropertyChanged Members

        /// <summary>
        /// Raises the 'PropertyChanged' event when the value of a property of the data model has changed.
        /// </summary>
        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        /// <summary>
        /// 'PropertyChanged' event that is raised when the value of a property of the data model has changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}
