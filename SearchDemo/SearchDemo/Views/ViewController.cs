using System;

using UIKit;
using SDWebImage;
using Foundation;

namespace SearchDemo
{
	public partial class ViewController : UIViewController, IUITableViewDataSource
	{
		public MonkeyListViewModel ViewModel;

		public ViewController (IntPtr handle) : base (handle)
		{
			ViewModel = new MonkeyListViewModel ();
		}
			
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			var activityIndicator = new UIActivityIndicatorView (new CoreGraphics.CGRect (0, 0, 20, 20));
			activityIndicator.ActivityIndicatorViewStyle = UIActivityIndicatorViewStyle.White;
			activityIndicator.HidesWhenStopped = true;
			NavigationItem.LeftBarButtonItem = new UIBarButtonItem (activityIndicator);

			var getMonkeysButton = new UIBarButtonItem ();
			getMonkeysButton.Title = "Get";
			getMonkeysButton.Clicked += async (object sender, EventArgs e) => {
				activityIndicator.StartAnimating();
				getMonkeysButton.Enabled = false;

				await ViewModel.GetMonkeysAsync();
				TableViewMonkeys.ReloadData();

				getMonkeysButton.Enabled = true;
				activityIndicator.StopAnimating();
			};
			NavigationItem.RightBarButtonItem = getMonkeysButton;

			TableViewMonkeys.WeakDataSource = this;
		}

		public override void PrepareForSegue (UIStoryboardSegue segue, NSObject sender)
		{
			base.PrepareForSegue (segue, sender);

			if (String.Equals (segue.Identifier, "monkeyDetailSegue"))
			{
				var cell = (UITableViewCell)sender;
				var indexPath = TableViewMonkeys.IndexPathForCell (cell);

				var detailView = (DetailViewController)segue.DestinationViewController;
				detailView.Monkey = ViewModel.Monkeys [indexPath.Row];

				TableViewMonkeys.DeselectRow (indexPath, true);
			}
		}

		#region TableView DataSource

		public nint RowsInSection (UITableView tableView, nint section)
		{
			return ViewModel.Monkeys.Count;
		}

		public UITableViewCell GetCell (UITableView tableView, Foundation.NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell ("monkeyCell");
			var monkey = ViewModel.Monkeys [indexPath.Row];

			cell.TextLabel.Text = monkey.Name;
			cell.DetailTextLabel.Text = monkey.Location;
			cell.ImageView.SetImage(
				url: new NSUrl (monkey.Image), 
				placeholder: UIImage.FromBundle ("placeholder.png")
			);

			return cell;
		}

		#endregion
	}
}