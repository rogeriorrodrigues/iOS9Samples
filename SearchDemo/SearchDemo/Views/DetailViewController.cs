
using System;

using Foundation;
using UIKit;
using SDWebImage;

namespace SearchDemo
{
	public partial class DetailViewController : UIViewController
	{
		public Monkey Monkey { get; set; }

		public DetailViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			this.Title = Monkey.Name;
			MonkeyImage.SetImage(
				url: new NSUrl (Monkey.Image), 
				placeholder: UIImage.FromBundle ("placeholder.png")
			);
			LocationLabel.Text = Monkey.Location;
			DescriptionTextView.Text = Monkey.Details;
		}

		private void CreateActivityForSearch()
		{
			var activity = new NSUserActivity("com.xamarin.searchdemo.monkey");
			activity.EligibleForSearch = true;
			activity.EligibleForPublicIndexing = true;

			activity.Title = Monkey.Name;
			activity.AddUserInfoEntries(NSDictionary.FromObjectAndKey(new NSString(Monkey.Name), new NSString("Name")));

			var keywords = new string[] { Monkey.Name, "Monkey" };
			activity.Keywords = new NSSet(keywords);
			activity.ContentAttributeSet = new CoreSpotlight.CSSearchableItemAttributeSet(Monkey.Details);

			activity.BecomeCurrent ();
		}
	}
}

