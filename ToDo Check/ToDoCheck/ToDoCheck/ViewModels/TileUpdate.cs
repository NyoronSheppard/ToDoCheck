using Microsoft.Phone.Shell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ToDoCheck.ViewModels
{
    //Static Class for update Tile
    public static class TileUpdate
    {
        //Id
        public static int idTile;

        //Bool to determine whether or not this
        public static bool seeTile;

        //Title
        public static string titleTile;

        //Currency
        public static string descriptionTile;

        //Last Update
        public static string updateTile;

        //Method to create Tile
        public static void createOrUpdateTile()
        {
            IconicTileData oIcontile = new IconicTileData();
            oIcontile.Title = titleTile;
            //oIcontile.Count = indexItem;

            oIcontile.IconImage = new Uri("/Assets/Tiles/FlipCycleTileSmall.png", UriKind.Relative);
            oIcontile.SmallIconImage = new Uri("/Assets/Tiles/FlipCycleTileSmall.png", UriKind.Relative);

            oIcontile.WideContent1 = titleTile;
            oIcontile.WideContent2 = descriptionTile;
            oIcontile.WideContent3 = updateTile;

            oIcontile.BackgroundColor = new Color { A = 255, R = 0, G = 0, B = 0 }; //new Color { A = 255, R = 0, G = 148, B = 255 };

            ShellTile tileToFind = ShellTile.ActiveTiles.FirstOrDefault(x => x.NavigationUri.ToString().Contains("Iconic".ToString()));

            //Update
            if (tileToFind != null && tileToFind.NavigationUri.ToString().Contains("Iconic"))
            {
                //tileToFind.Delete();
                tileToFind.Update(oIcontile);
                //ShellTile.Create(new Uri("/MainPage.xaml?id=Iconic", UriKind.Relative), oIcontile, true);
            }
            //Create new
            else
            {
                ShellTile.Create(new Uri("/MainPage.xaml?id=Iconic", UriKind.Relative), oIcontile, true);
            }
        }
    }
}
