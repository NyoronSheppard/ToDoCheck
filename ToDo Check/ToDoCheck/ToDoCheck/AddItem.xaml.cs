using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media.Imaging;
using ToDoCheck.ViewModels;

namespace ToDoCheck
{
    public partial class AddItem : PhoneApplicationPage
    {
        //Attributes
        
        //Id
        private int id;

        //Title
        private string title;

        //Description
        private string description;

        //Color
        private string color;

        //Color URL
        private string colorURL;

        //DataBase
        public DataBaseContext DataB { get; set; }

        public AddItem()
        {
            DataB = new DataBaseContext("Data Source=isostore:/DBToDo.sdf");

            InitializeComponent();

            //Default Values
            id = App.ViewModel.Items.Count;
            title = "Default Title";
            description = "Default Description";
            color = "green";
            colorURL = @"/Assets/Priority/pGreen.png";
        }

        //Title
        private void textBoxTitle_TextChanged(object sender, TextChangedEventArgs e)
        {
            title = textBoxTitle.Text;
        }

        //Description
        private void textBoxDescription_TextChanged(object sender, TextChangedEventArgs e)
        {
            description = textBoxDescription.Text;
        }

        //Tap Green Color
        private void green_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            BitmapImage bmGreen = new BitmapImage(new Uri(@"/Assets/Priority/check.png", UriKind.RelativeOrAbsolute));
            greenCheck.Source = bmGreen;

            yellowCheck.Source = null;
            redCheck.Source = null;

            color = "green";
            colorURL = @"/Assets/Priority/pGreen.png";
        }

        //Tap Yellow Color
        private void yellow_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            BitmapImage bmYellow = new BitmapImage(new Uri(@"/Assets/Priority/check.png", UriKind.RelativeOrAbsolute));
            yellowCheck.Source = bmYellow;

            greenCheck.Source = null;
            redCheck.Source = null;

            color = "yellow";
            colorURL = @"/Assets/Priority/pYellow.png";
        }

        //Tap Red Color
        private void red_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            BitmapImage bmRed = new BitmapImage(new Uri(@"/Assets/Priority/check.png", UriKind.RelativeOrAbsolute));
            redCheck.Source = bmRed;

            greenCheck.Source = null;
            yellowCheck.Source = null;

            color = "red";
            colorURL = @"/Assets/Priority/pRed.png";
        }

        //Add item
        private void onClickCheckButton(object sender, EventArgs e)
        {
            if (description == "")
            {
                description = "Edit Description";
            }
            if (title == "")
            {
                title = "Default";
            }

            //Create Item (Automatic IDid)
            ItemViewModel itemV = new ItemViewModel();
            //itemV.IDid = 150;
            itemV.ID = id;
            itemV.Description = description;
            itemV.Date = DateTime.Now.ToShortDateString();
            itemV.Title = title;
            itemV.Color = color;
            itemV.ColorURL = colorURL;

            //Add Database
            DataB.Item.InsertOnSubmit(itemV);
            DataB.SubmitChanges();

            //Add ViewModel
            App.ViewModel.Items.Add(itemV);

            //Que hay en la base de datos
            //foreach (var item in DataB.Item)
            //{
            //    ItemViewModel pruebaV = new ItemViewModel();
            //    pruebaV.ID = item.ID;
            //    pruebaV.Description = item.Description;
            //    pruebaV.Date = item.Date;
            //    pruebaV.Title = item.Title;
            //    pruebaV.Color = item.Color;
            //    pruebaV.ColorURL = item.ColorURL;
            //}

            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }
    }
}