﻿using UIKit;

namespace Formation.iOS
{
	public class Application
	{
		// This is the main entry point of the application.
		static void Main (string[] args)
		{
			// if you want to use a different Application Delegate class from "AppDelegate"
			// you can specify it here.
			pwetClass.Main (args, null, "AppDelegate");
		}
	}

	public class pwetClass : UIApplication{

	}

}
