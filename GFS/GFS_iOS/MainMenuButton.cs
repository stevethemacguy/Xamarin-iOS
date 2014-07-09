using System;
using MonoTouch.UIKit;

namespace GFS_iOS
{
	//MainMenuButton is used to create a UIBarButtonItem with default settings
	public class MainMenuButton
	{
		UIBarButtonItem button;

		public MainMenuButton()
		{
		}

		public UIBarButtonItem getButton(UIViewController parentView, int startingY)
		{
			//Initialize Flyout Menu
			MenuSubView menuView = MenuSubView.getInstance();

			//Create the Main Menu button, which is used to show/hide the MenuSubView
			button = new UIBarButtonItem(UIImage.FromFile("menuIconShifted.png"), UIBarButtonItemStyle.Plain, 
				//When clicked
				(sender, args) => {
					if (menuView.isVisible()) {
						//Change X image back to the normal menu image
						button.Image = UIImage.FromFile("menuIconShifted.png");
					} else {
						//Make Button show the X image once it's pressed.
						button.Image = UIImage.FromFile("XIcon.png");
					}
					menuView.toggleMenu(parentView, startingY);
				});

			return button;
		}
	}
}

