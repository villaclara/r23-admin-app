using AdminApp.WASM.Models.ViewModels;

namespace AdminApp.WASM.Models
{
	public class FilterItemOrder
	{
		public DateTime? StartDate { get; set; } 
		public DateTime? EndDate { get; set; }
		public string PhoneNumber { get; set; } = "";
		public int StartPrice { get; set; }
		public int EndPrice { get; set; }


		public FilterItemOrder(DateTime? startDate = null, DateTime? endDate = null, string phoneNumber = "", int startPrice = 0, int endPrice = 10000)
		{
			StartDate = startDate;
			EndDate = endDate;
			PhoneNumber = phoneNumber;
			StartPrice = startPrice;
			EndPrice = endPrice;
		}

		public void ResetFields()
		{
			StartDate = null;
			EndDate = null;
			PhoneNumber = "";
			StartPrice = 0;
			EndPrice = 0;
		}

		public ICollection<OrderWithExpandedBool> PerformSearch(ICollection<OrderWithExpandedBool> orders)
		{
			if(this.StartDate != default && this.EndDate != default)
			{
				return PerformSearchByDateRange(this, orders);
			}
			else if(this.StartDate != default && this.EndDate == default)
			{
				return PerformSearchByOnlyDate(this, orders);
			}

			if (this.StartPrice >= 0 && this.EndPrice is not 0)
			{
				return PerformSearchByPriceRange(this, orders);
			}
			
			
			else 
				return orders;
		}

		private static ICollection<OrderWithExpandedBool> PerformSearchByPriceRange(FilterItemOrder filter, ICollection<OrderWithExpandedBool> orders)
		{
			return orders.Where(o => (o.OrderVM.TotalSum >= filter.StartPrice && o.OrderVM.TotalSum <= filter.EndPrice)).ToList();

		}

		private static ICollection<OrderWithExpandedBool> PerformSearchByOnlyDate(FilterItemOrder filter, ICollection<OrderWithExpandedBool> orders)
		{
			return orders.Where(o => DateOnly.FromDateTime(o.OrderVM.OrderDate).CompareTo(DateOnly.FromDateTime((DateTime)filter.StartDate!)) >= 0).ToList();

        }

		private static ICollection<OrderWithExpandedBool> PerformSearchByDateRange(FilterItemOrder filter, ICollection<OrderWithExpandedBool> orders)
		{
			return orders.Where(o => DateOnly.FromDateTime(o.OrderVM.OrderDate).CompareTo(DateOnly.FromDateTime((DateTime)filter.StartDate!)) >= 0 
									&& DateOnly.FromDateTime(o.OrderVM.OrderDate).CompareTo(DateOnly.FromDateTime((DateTime)filter.EndDate!)) <= 0).ToList();

		}
	}
}
