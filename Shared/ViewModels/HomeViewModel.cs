﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Resume.Shared
{
	public class HomeViewModel : BaseViewModel
	{
		public ObservableCollection<HomeMenuItem> MenuItems { get; set; }
		public HomeViewModel ()
		{
			CanLoadMore = true;
            Title = "Resume";
			MenuItems = new ObservableCollection<HomeMenuItem> ();
			MenuItems.Add (new HomeMenuItem {
				Id = 0, Title = "About", MenuType = MenuType.About,  Icon = "about.png"
			});
		}

	}
}

