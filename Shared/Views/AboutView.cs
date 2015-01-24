﻿using System;
using Xamarin.Forms;

namespace Resume.Shared
{
	public class AboutView : BaseView
	{
		public AboutView ()
		{
			var stack = new StackLayout
            {
				Orientation = StackOrientation.Vertical,
				Spacing = 10,
			};

			var image = new Image();
			image.Source = ImageSource.FromFile("pv_batman.jpg");
			image.Aspect = Aspect.AspectFill;

			stack.Children.Add(image);

			var stack2 = new StackLayout
            {
				Orientation = StackOrientation.Vertical,
				VerticalOptions = LayoutOptions.FillAndExpand,
				Spacing = 10,
				Padding = 10,
			};

            var about = new Label
            {
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
				Text = "My name is Paul Peavyhouse...",
				LineBreakMode = LineBreakMode.WordWrap,
			};

			stack2.Children.Add(about);

			stack.Children.Add(new ScrollView
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                Content = stack2,
            });

			Content = stack;
		}
	}
}

