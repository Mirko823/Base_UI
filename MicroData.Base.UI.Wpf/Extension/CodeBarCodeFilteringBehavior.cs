using MicroData.Base.Domain.Lookup;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Telerik.Windows.Controls;

namespace MicroData.Base.UI.Wpf.Extension
{
	public class CodeBarCodeFilteringBehavior : FilteringBehavior
	{
		public override IEnumerable<object> FindMatchingItems(string searchText, IList items, IEnumerable<object> escapedItems, string textSearchPath, TextSearchMode textSearchMode)
		{
			var codeBarCode = searchText.Trim();

			if (codeBarCode.Length == 0)
				return base.FindMatchingItems(searchText, items, escapedItems, textSearchPath, textSearchMode);


			IEnumerable<CatalogLookup> results = new List<CatalogLookup>();
			codeBarCode = codeBarCode.ToLower();

			if (textSearchMode == TextSearchMode.Contains)
			{
				results = items.OfType<CatalogLookup>()
						 .Where(x => x.Code.Contains(codeBarCode)
								 || (x.BarCode != null && x.BarCode.Contains(codeBarCode)));
			}
			else
			{
				results = items.OfType<CatalogLookup>()
						  .Where(x => x.Code.ToLower().StartsWith(codeBarCode)
								 || (x.BarCode != null && x.BarCode.ToLower().StartsWith(codeBarCode)));
			}

			return results.Where(x => !escapedItems.Contains(x));
		}
	}
}
