using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

using System.Data.Linq.Mapping;
using System.Collections.ObjectModel;
using System.Data.Linq;

namespace ToDoCheck.ViewModels
{
    [Table]
    public class ItemViewModel : INotifyPropertyChanged
    {
        private int _idid;
        /// <summary>
        /// Propiedad ViewModel de ejemplo; esta propiedad se usa para identificar el objeto.
        /// </summary>
        /// <returns></returns>

        [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT NOT NULL Identity", CanBeNull = false, AutoSync = AutoSync.OnInsert)]
        public int IDid
        {
            get
            {
                return _idid;
            }
            set
            {
                if (value != _idid)
                {
                    _idid = value;
                    NotifyPropertyChanged("IDid");
                }
            }
        }

        private int _id;

        [Column]
        public int ID
        {
            get
            {
                return _id;
            }
            set
            {
                if (value != _id)
                {
                    _id = value;
                    NotifyPropertyChanged("ID");
                }
            }
        }

        //Title
        private string _title;

        [Column]
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                if (value != _title)
                {
                    _title = value;
                    NotifyPropertyChanged("Title");
                }
            }
        }

        //Description
        private string _description;

        [Column]
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                if (value != _description)
                {
                    _description = value;
                    NotifyPropertyChanged("Description");
                }
            }
        }

        //Date
        private String _date;

        [Column]
        public String Date
        {
            get
            {
                return _date;
            }
            set
            {
                if (value != _date)
                {
                    _date = value;
                    NotifyPropertyChanged("Date");
                }
            }
        }

        //Color
        private String _color;

        [Column]
        public String Color
        {
            get
            {
                return _color;
            }
            set
            {
                if (value != _color)
                {
                    _color = value;
                    NotifyPropertyChanged("Color");
                }
            }
        }

        //URL Color
        private String _colorURL;

        [Column]
        public String ColorURL
        {
            get
            {
                return _colorURL;
            }
            set
            {
                if (value != _colorURL)
                {
                    _colorURL = value;
                    NotifyPropertyChanged("ColorURL");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}