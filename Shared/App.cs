using System;
using Xamarin.Forms;

namespace Resume.Shared
{
    public static class App
	{
		private static Page homeView;
		public static Page RootPage
		{
			get { return homeView ?? (homeView = new HomeView()); }
		}
	}
}

