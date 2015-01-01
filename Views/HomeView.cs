using System;
using Xamarin.Forms;
using System.Collections.Generic;

namespace Resume.Shared
{
    public class HomeView : MasterDetailPage
    {
        private HomeViewModel ViewModel
        {
            get { return BindingContext as HomeViewModel; }
        }

        HomeMasterView master;

        private Dictionary<MenuType, NavigationPage> pages;

        public HomeView()
        {
            pages = new Dictionary<MenuType, NavigationPage>();
            BindingContext = new HomeViewModel();

            Master = master = new HomeMasterView(ViewModel);

            var homeNav = new NavigationPage(master.PageSelection) {
                BarBackgroundColor = Helpers.Color.DarkBlue.ToFormsColor(),
                BarTextColor = Color.White
            };
            Detail = homeNav;

            pages.Add (MenuType.About, homeNav);

            master.PageSelectionChanged = (menuType) => {

                NavigationPage newPage;
                if (pages.ContainsKey(menuType))
                {
                    newPage = pages[menuType];
                }
                else
                {
                    newPage = new NavigationPage(master.PageSelection)
                    {
                        BarBackgroundColor = Helpers.Color.DarkBlue.ToFormsColor(),
                        BarTextColor = Color.White
                    };
                    pages.Add (menuType, newPage);
                }
                Detail = newPage;
                Detail.Title = master.PageSelection.Title;
                IsPresented = false;
            };

            this.Icon = "slideout.png";
        }
    }

    public class HomeMasterView : BaseView
    {
        public Action<MenuType> PageSelectionChanged;
        private Page pageSelection;
        public Page PageSelection {
            get{ return pageSelection; }
            set {
                pageSelection = value; 
                if (PageSelectionChanged != null)
                    PageSelectionChanged (menuType);
            }
        }

        private MenuType menuType = MenuType.About;

        private AboutView about;

        public HomeMasterView(HomeViewModel viewModel)
        {
            this.Icon = "slideout.png";

            BindingContext = viewModel;

            var layout = new StackLayout { Spacing = 0 };

            var label = new ContentView {
                Padding = new Thickness(10, 36, 0, 5),
                BackgroundColor = Color.Transparent,
                Content = new Label {
                    Text = "MENU",
                    Font = Font.SystemFontOfSize(NamedSize.Medium)
                }
            };

            layout.Children.Add(label);

            var listView = new ListView();

            var cell = new DataTemplate(typeof(ListImageCell));

            cell.SetBinding(TextCell.TextProperty, HomeViewModel.TitlePropertyName);
            cell.SetBinding(ImageCell.ImageSourceProperty, "Icon");

            listView.ItemTemplate = cell;

            listView.ItemsSource = viewModel.MenuItems;

            if (about == null)
                about = new AboutView ();
            PageSelection = about;

            // Change to the correct page
            listView.ItemSelected += (sender, args) =>
            {
                var menuItem = listView.SelectedItem as HomeMenuItem;
                menuType = menuItem.MenuType;
                switch(menuItem.MenuType){
                case MenuType.About:
                    if (about == null)
                        about = new AboutView();
                    PageSelection = about;
                    break;
                }
            };

            listView.SelectedItem = viewModel.MenuItems[0];
            layout.Children.Add(listView);

            Content = layout;
        }
    }
}

