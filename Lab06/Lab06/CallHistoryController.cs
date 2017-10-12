using Foundation;
using System;
using UIKit;
using System.Collections.Generic;

namespace Lab06
{
    public partial class CallHistoryController : UITableViewController
    {
        public List<string> PhoneNumbers
        {
            get;
            set;
        }

        public NSString CallHistoryCellId = new NSString("CallHistoryCell");

        public CallHistoryController(IntPtr handle) : base(handle)
        {
            TableView.RegisterClassForCellReuse(typeof(UITableViewCell), CallHistoryCellId);
            TableView.Source = new CallHistoryDataSource(this);
		}

		class CallHistoryDataSource : UITableViewSource
		{
			CallHistoryController controller;

			public CallHistoryDataSource(CallHistoryController cont)
			{
				this.controller = cont;
			}

			public override nint RowsInSection(UITableView tableView, nint section)
			{
				return controller.PhoneNumbers.Count;
			}

			public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
			{
				var cell = tableView.DequeueReusableCell(controller.CallHistoryCellId);

				cell.TextLabel.Text = controller.PhoneNumbers[indexPath.Row];

				return cell;
			}
		}
    }
}