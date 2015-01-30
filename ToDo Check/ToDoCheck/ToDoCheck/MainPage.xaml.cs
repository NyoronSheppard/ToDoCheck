using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using ToDoCheck.Resources;
using ToDoCheck.ViewModels;
using System.Windows.Media.Imaging;

namespace ToDoCheck
{
    public partial class MainPage : PhoneApplicationPage
    {

        //DataBase
        public DataBaseContext DataB { get; set; }

        // Constructor
        public MainPage()
        {
            DataB = new DataBaseContext("Data Source=isostore:/DBToDo.sdf");

            InitializeComponent();

            // Determine the visibility of the dark background.
            Visibility darkBackgroundVisibility =
                (Visibility)Application.Current.Resources["PhoneDarkThemeVisibility"];

            // Icon dark or light
            if (darkBackgroundVisibility == Visibility.Visible)
            {
                BitmapImage bm = new BitmapImage(new Uri(@"/Assets/Tiles/tileapplication.png", UriKind.RelativeOrAbsolute));
                iconApp.Source = bm;
            }
            else
            {
                BitmapImage bm = new BitmapImage(new Uri(@"/Assets/Tiles/tileapplicationblack.png", UriKind.RelativeOrAbsolute));
                iconApp.Source = bm;
            }

            // Establecer el contexto de datos del control LongListSelector en los datos de ejemplo
            DataContext = App.ViewModel;

            updateID();

            // Código de ejemplo para traducir ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        // Cargar datos para los elementos ViewModel
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (!App.ViewModel.IsDataLoaded)
            {
                App.ViewModel.LoadData();
            }
        }

        // Selección de controlador cambiada en LongListSelector
        private void MainLongListSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Si el elemento seleccionado es NULL (no hay ninguna selección) no hacer nada
            if (MainLongListSelector.SelectedItem == null)
                return;

            //if (deleteItem == true)
            //{
            //    App.ViewModel.Items.Remove(MainLongListSelector.SelectedItem as ItemViewModel);

            //    updateID();

            //    deleteItem = false;
            //}
            else
            {
                // Navegar a la página siguiente
                NavigationService.Navigate(new Uri("/DetailsPage.xaml?selectedItem=" + (MainLongListSelector.SelectedItem as ItemViewModel).ID, UriKind.Relative));

                // Restablecer elemento seleccionado a null (sin selección)
                MainLongListSelector.SelectedItem = null;
            }
            
        }

        //Update itemID
        public void updateID()
        {
            if (DataB.DatabaseExists())
            {
                App.ViewModel.Items.Clear();

                int i = 0;

                foreach (var item1 in DataB.Item)
                {              
                    App.ViewModel.Items.Add(new ItemViewModel {
                        ID = item1.ID,
                        IDid = item1.IDid,
                        Title = item1.Title,
                        Description = item1.Description,
                        Date = item1.Date,
                        Color = item1.Color,
                        ColorURL = item1.ColorURL
                    });

                    //App.ViewModel.Items[i].ID = (item1.ID - 1);
                    i++;
                }
            }
        }

        //Go to AddPage
        private void onClickAddButton(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/AddItem.xaml", UriKind.Relative));
        }

        private void onClickAbout(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/About.xaml", UriKind.Relative));
        }


        // Código de ejemplo para compilar una ApplicationBar traducida
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Establecer ApplicationBar de la página en una nueva instancia de ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Crear un nuevo botón y establecer el valor de texto en la cadena traducida de AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Crear un nuevo elemento de menú con la cadena traducida de AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}