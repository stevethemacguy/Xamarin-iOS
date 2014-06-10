using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;
using System.Collections.Generic;
namespace GFS_iOS
{
	partial class ProductActionsTableController : UITableViewController
	{
		public ProductActionsTableController actionsTable;
		public HashSet<string> actionList;
		public ProductActionsTableController (IntPtr handle) : base (handle)
		{
			actionsTable = this;
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			actionCell1.BackgroundColor = UIColor.Clear;
			actionCell2.BackgroundColor = UIColor.Clear;
			actionCell3.BackgroundColor = UIColor.Clear;
			//actionCell4.BackgroundColor = UIColor.Clear;
			//actionCell5.BackgroundColor = UIColor.Clear;
			actionsView.BackgroundColor = UIColor.FromPatternImage(UIImage.FromFile("main-background-resized.png"));

			DownloadButton.TouchUpInside += (o,s) => {
				UIAlertView alert = new UIAlertView ("Download Complete!", "The PDF file was sucessfully saved.", null, "OK");
					alert.Show();
			};

			AddToListButton.TouchUpInside += (o,s) => {
				UIActionSheet actionSheet = new UIActionSheet ("Your Saved Lists");
				if(SavedProductList.getInstance() != null)
				{ 
					actionList = SavedProductList.getInstance();
					foreach (string item in actionList)
					{
						actionSheet.AddButton(item);
					}
				}
				actionSheet.AddButton ("Create List");
				actionSheet.AddButton ("Cancel");
				actionSheet.Clicked += delegate(object a, UIButtonEventArgs b) {
					Console.WriteLine ("Button " + b.ButtonIndex.ToString () + " clicked");
				};


				actionSheet.ShowInView (View);
			};
		}
	}
}
