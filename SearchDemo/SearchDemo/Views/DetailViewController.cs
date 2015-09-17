
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
	}
}

