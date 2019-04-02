﻿using Xamarin.Forms.CustomAttributes;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Controls;

#if UITEST
using Xamarin.Forms.Core.UITests;
using Xamarin.UITest;
using NUnit.Framework;
#endif

namespace Xamarin.Forms.Controls.Issues
{
#if UITEST
	[Category(UITestCategories.Shell)]
#endif
	[Preserve(AllMembers = true)]
	[Issue(IssueTracker.Github, 5132, "Unable to specify automation properties on the hamburger/flyout icon", PlatformAffected.Default)]
	public class Issue5132 : TestShell
	{
		protected override void Init()
		{
			Title = "Shell";
			FlyoutIcon = new FontImageSource
			{
				Glyph = "\uf2fb",
				FontFamily = DefaultFontFamily(),
				Size = 20,
				AutomationId = "shellIcon"
			};
			FlyoutIcon.SetValue(AutomationProperties.HelpTextProperty, "This as Shell FlyoutIcon");
			FlyoutIcon.SetValue(AutomationProperties.NameProperty, "SHELLMAINFLYOUTICON");
			Items.Add(new ShellItem
			{
				Title = "Connect",
				Items = {
					new ShellSection { Title = "library",
						Items = {
									new ShellContent { Content = new Label  { Text = "Turn accessibility on and make sure the help text is read" } }
								}
						}
				}
			});
		}

		static string DefaultFontFamily()
		{
			var fontFamily = "";
			switch (Device.RuntimePlatform)
			{
				case Device.iOS:
					fontFamily = "Ionicons";
					break;
				case Device.UWP:
					fontFamily = "Assets/Fonts/ionicons.ttf#ionicons";
					break;
				case Device.Android:
				default:
					fontFamily = "fonts/ionicons.ttf#";
					break;
			}

			return fontFamily;
		}

#if UITEST
		[Test]
		public void Issue5132Test()
		{
			RunningApp.WaitForElement(q => q.Marked("shellIcon"));
			TapInFlyout("Connect", "shellIcon");
		}
#endif
	}
}