using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace SearchDemo
{
	public class MonkeyListViewModel
	{
		private bool _isBusy;

		public ObservableCollection<Monkey> Monkeys;

		public MonkeyListViewModel ()
		{
			Monkeys = new ObservableCollection<Monkey> ();
		}

		public async Task GetMonkeysAsync()
		{
			if (_isBusy)
			{
				return;
			}

			try
			{
				_isBusy = true;

				var client = new HttpClient();
				var json = await client.GetStringAsync("http://montemagno.com/monkeys.json");
				var monkeyList = JsonConvert.DeserializeObject<List<Monkey>>(json);

				foreach(var monkey in monkeyList)
				{
					Monkeys.Add(monkey);
				}
			}
			finally
			{
				_isBusy = false;
			}
		}
	}
}

