﻿using System;
using System.Diagnostics;

namespace Xamarin.Forms
{

	[DebuggerDisplay("Location = {Location}")]
	public class ShellNavigationState
	{
		Uri _fullLocation;

		internal Uri FullLocation
		{
			get => _fullLocation;
			set
			{
				_fullLocation = value;
				Location = Routing.RemoveImplicit(value);
			}
		}

		public Uri Location
		{
			get;
			private set;
		}

		public ShellNavigationState() { }
		public ShellNavigationState(string location)
		{
			FullLocation = ShellUriHandler.CreateUri(location);

		}

		public ShellNavigationState(Uri location) => FullLocation = location;
		public static implicit operator ShellNavigationState(Uri uri) => new ShellNavigationState(uri);
		public static implicit operator ShellNavigationState(string value) => new ShellNavigationState(value);
	}
}
