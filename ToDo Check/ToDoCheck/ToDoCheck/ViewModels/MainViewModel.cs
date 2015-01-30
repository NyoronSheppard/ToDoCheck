using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using ToDoCheck.Resources;

namespace ToDoCheck.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {

        //DataBase
        public DataBaseContext DataB { get; set; }

        public MainViewModel()
        {
            //First call to DataBase
            DataB = new DataBaseContext("Data Source=isostore:/DB.sdf");

            this.Items = new ObservableCollection<ItemViewModel>();
        }

        /// <summary>
        /// Colección para objetos ItemViewModel.
        /// </summary>
        public ObservableCollection<ItemViewModel> Items { get; private set; }

        private string _sampleProperty = "Sample Runtime Property Value";
        /// <summary>
        /// Propiedad Sample ViewModel; esta propiedad se usa en la vista para mostrar su valor mediante un enlace
        /// </summary>
        /// <returns></returns>
        public string SampleProperty
        {
            get
            {
                return _sampleProperty;
            }
            set
            {
                if (value != _sampleProperty)
                {
                    _sampleProperty = value;
                    NotifyPropertyChanged("SampleProperty");
                }
            }
        }

        /// <summary>
        /// Propiedad de ejemplo que devuelve una cadena traducida
        /// </summary>
        public string LocalizedSampleProperty
        {
            get
            {
                return AppResources.SampleProperty;
            }
        }

        public bool IsDataLoaded
        {
            get;
            private set;
        }

        /// <summary>
        /// Crear y agregar unos pocos objetos ItemViewModel a la colección Items.
        /// </summary>
        public void LoadData()
        {

            //Create DataBase
            DataB = new DataBaseContext("Data Source=isostore:/DBToDo.sdf");

            if (!DataB.DatabaseExists())
            {
                DataB.CreateDatabase();
                DataB.SubmitChanges();
            }
            else
            {
                //foreach (var item in DataB.Item)
                //{
                //    App.ViewModel.Items.Add(item);
                //}
                //DataB.SubmitChanges();

                ////Array start in 0
                //foreach (var item in App.ViewModel.Items)
                //{
                //    item.ID = (item.ID - 1);
                //}
            }

            // Datos de ejemplo; reemplazar por los datos reales
            //this.Items.Add(new ItemViewModel() { ID = 1, Title = "runtime one", Description = "Maecenas praesent accumsan bibendum aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", Date = DateTime.Now.ToShortDateString()});
            //this.Items.Add(new ItemViewModel() { ID = 1, Title = "runtime two", Description = "Dictumst eleifend facilisi faucibus", Date = DateTime.Now.ToShortDateString() });
            //this.Items.Add(new ItemViewModel() { ID = this.Items.Count, Title = "runtime three", Description = "Habitant inceptos interdum lobortis", Date = DateTime.Now.ToShortDateString() });
            //this.Items.Add(new ItemViewModel() { ID = this.Items.Count, Title = "runtime four", Description = "Nascetur pharetra placerat pulvinar", Date = DateTime.Now.ToShortDateString() });
            //this.Items.Add(new ItemViewModel() { ID = this.Items.Count, Title = "runtime five", Description = "Maecenas praesent accumsan bibendum", Date = DateTime.Now.ToShortDateString() });
            //this.Items.Add(new ItemViewModel() { ID = this.Items.Count, Title = "runtime six", Description = "Dictumst eleifend facilisi faucibus", Date = DateTime.Now.ToShortDateString() });
            //this.Items.Add(new ItemViewModel() { ID = this.Items.Count, Title = "runtime seven", Description = "Habitant inceptos interdum lobortis", Date = DateTime.Now.ToShortDateString() });
            //this.Items.Add(new ItemViewModel() { ID = this.Items.Count, Title = "runtime eight", Description = "Nascetur pharetra placerat pulvinar", Date = DateTime.Now.ToShortDateString() });         

            this.IsDataLoaded = true;
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