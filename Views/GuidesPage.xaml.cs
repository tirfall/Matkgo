using Matkgo.Models;
using Matkgo.ViewModels;
using System;
using System.IO;

namespace Matkgo.Views
{
    public partial class GuidesPage : ContentPage
    {
        public const string DATABASE_NAME = "guides.db";
        private static GuideRepository database;

        public static GuideRepository Database
        {
            get
            {
                if (database == null)
                {
                    database = new GuideRepository(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME));
                }
                return database;
            }
        }

        public GuidesPage()
        {
            InitializeComponent();
            BindingContext = new GuideViewModel();
        }
    }
}
