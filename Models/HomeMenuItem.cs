using System;

namespace Resume.Shared
{
	public enum MenuType
	{
		About,
	}

	public class HomeMenuItem : BaseModel
	{
		public HomeMenuItem ()
		{
			MenuType = MenuType.About;
		}
		public string Icon {get;set;}
		public MenuType MenuType { get; set; }
	}
}

