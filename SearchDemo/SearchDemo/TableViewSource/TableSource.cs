using System;
using UIKit;
using System.Collections.Generic;

namespace SearchDemo
{
	public class TableSource : UITableViewSource
	{
		protected List<Monkey> Items;
		protected string cellItendifiet = "monkeyList";
		ViewController owner;

		public TableSource (List<Monkey> items, ViewController owner)
		{
			Items = items;
			this.owner = owner;
		}

		#region implemented abstract members of UITableViewSource

		public override UITableViewCell GetCell (UITableView tableView, Foundation.NSIndexPath indexPath)
		{
			throw new NotImplementedException ();
		}

		public override nint RowsInSection (UITableView tableview, nint section)
		{
			throw new NotImplementedException ();
		}

		public override void RowSelected (UITableView tableView, Foundation.NSIndexPath indexPath)
		{
			throw new System.NotImplementedException ();
		}

		#endregion
	}
}

