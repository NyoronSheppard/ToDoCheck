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

namespace ToDoCheck
{
    public partial class DetailsPage : PhoneApplicationPage
    {
        //Attributes
        int index;

        //AuxArray for save the rest of the list
        List<ItemViewModel> auxList; 

        //DataBase
        public DataBaseContext DataB { get; set; }

        // Constructor
        public DetailsPage()
        {
            DataB = new DataBaseContext("Data Source=isostore:/DBToDo.sdf");

            auxList = new List<ItemViewModel>();

            InitializeComponent();

            // Código de ejemplo para traducir ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        // Cuando se navega a la página para establecer el contexto de datos en el elemento seleccionado de la lista
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (DataContext == null)
            {
                string selectedIndex = "";
                if (NavigationContext.QueryString.TryGetValue("selectedItem", out selectedIndex))
                {
                    index = int.Parse(selectedIndex);

                    DataContext = App.ViewModel.Items[index];
                }
            }
        }

        //Delete Item
        private void onClickCompletedButton(object sender, EventArgs e)
        {

            var itemV = new ItemViewModel()
            {
                ID = App.ViewModel.Items[index].ID,
                IDid = App.ViewModel.Items[index].IDid,
                Title = App.ViewModel.Items[index].Title,
                Description = App.ViewModel.Items[index].Description,
                Date = App.ViewModel.Items[index].Date,
                ColorURL = App.ViewModel.Items[index].ColorURL,
                Color = App.ViewModel.Items[index].Color
            };

            DataB.Item.Attach(itemV);
            DataB.Item.DeleteOnSubmit(itemV);
            DataB.SubmitChanges();

            App.ViewModel.Items.RemoveAt(index);

            //updateItemsRemove();


            //int itemsCount = App.ViewModel.Items.Count;
            //Remove from ViewModel
            for (int i = index; i < App.ViewModel.Items.Count; )
            {
                //Save the rest of the items in auxiliar list
                var itemVAux = new ItemViewModel()
                {
                    ID = (App.ViewModel.Items[i].ID - 1),
                    IDid = App.ViewModel.Items[i].IDid,
                    Title = App.ViewModel.Items[i].Title,
                    Description = App.ViewModel.Items[i].Description,
                    Date = App.ViewModel.Items[i].Date,
                    Color = App.ViewModel.Items[i].Color,
                    ColorURL = App.ViewModel.Items[i].ColorURL
                };

                auxList.Add(itemVAux);

                //Delete Items
                var itemVV = new ItemViewModel()
                {
                    ID = App.ViewModel.Items[i].ID,
                    IDid = App.ViewModel.Items[i].IDid,
                    Title = App.ViewModel.Items[i].Title,
                    Description = App.ViewModel.Items[i].Description,
                    Date = App.ViewModel.Items[i].Date,
                    ColorURL = App.ViewModel.Items[i].ColorURL,
                    Color = App.ViewModel.Items[i].Color
                };

                DataB.Item.Attach(itemVV);
                DataB.Item.DeleteOnSubmit(itemVV);
                DataB.SubmitChanges();

                App.ViewModel.Items.RemoveAt(i);
            }

            //Add the rest of list
            foreach (var item in auxList)
            {
                App.ViewModel.Items.Add(item);

                DataB.Item.InsertOnSubmit(item);
                DataB.SubmitChanges();
            }

            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }

        //Update Items ID
        //public void updateItemsRemove()
        //{
        //    int i = 0;

        //    foreach (var item in App.ViewModel.Items)
        //    {
        //        item.ID = i;
        //        i++;
        //    }
        //}

        //Add Tile Button
        private void onClickIconButton(object sender, EventArgs e)
        {
            //Statics Values from TileUpdate
            ViewModels.TileUpdate.seeTile = true;

            ViewModels.TileUpdate.titleTile = App.ViewModel.Items[index].Title;
            ViewModels.TileUpdate.descriptionTile = App.ViewModel.Items[index].Description;
            ViewModels.TileUpdate.updateTile = App.ViewModel.Items[index].Date;

            ViewModels.TileUpdate.createOrUpdateTile();

            //Tile Created
            updatedTile.Text = "     The icon has been created successfully";
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