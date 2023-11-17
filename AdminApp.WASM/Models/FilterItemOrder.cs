using AdminApp.WASM.Models.ViewModels;
using System.Reflection;

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

		public void ResetFields(int endPrice = 10000)
		{
			StartDate = null;
			EndDate = null;
			PhoneNumber = "";
			StartPrice = 0;
			EndPrice = endPrice;
		}

		public List<OrderWithExpandedBool> PerformSearchByPhone(string phoneNumber, ICollection<OrderWithExpandedBool> orders)
		{
			return orders.Where(o => o.OrderVM.Receiver.PhoneNumber.StartsWith(phoneNumber)).ToList();
		}

		// general method with all conditions 
		// calls the required filter method depending on parameters
        public ICollection<OrderWithExpandedBool> PerformSearch(ICollection<OrderWithExpandedBool> orders)
		{
			ICollection<OrderWithExpandedBool> result = new List<OrderWithExpandedBool>();
			if(!string.IsNullOrEmpty(this.PhoneNumber))
			{
				result = PerformSearchByPhone(PhoneNumber, orders);
			}

			else
			{
				result = orders;
			}


			// both StartDate and EndDate are set
			if(this.StartDate != default && this.EndDate != default)
			{
				result = PerformSearchByDateRange(this, result);
			}

			// only StartDate is set
			else if(this.StartDate != default && this.EndDate == default)
			{
				result = PerformSearchByStartDateOnly(this, result);
			}

			// only EndDate is set
			else if(this.StartDate == default && this.EndDate != default)
			{
				result = PerformSearchByEndDateOnly(this, result);
			}

			// search by price
			if (this.StartPrice >= 0 && this.EndPrice is not 0)
			{
				result = PerformSearchByPriceRange(this, result);
			}
			


			return result;
		}

		private static List<OrderWithExpandedBool> PerformSearchByEndDateOnly(FilterItemOrder filter, ICollection<OrderWithExpandedBool> orders)
		{
			return orders.Where(o => DateOnly.FromDateTime(o.OrderVM.OrderDate).CompareTo(DateOnly.FromDateTime((DateTime)filter.EndDate!)) <= 0).ToList();
		}

		private static List<OrderWithExpandedBool> PerformSearchByPriceRange(FilterItemOrder filter, ICollection<OrderWithExpandedBool> orders)
		{
			return orders.Where(o => (o.OrderVM.TotalSum >= filter.StartPrice && o.OrderVM.TotalSum <= filter.EndPrice)).ToList();

		}

		private static List<OrderWithExpandedBool> PerformSearchByStartDateOnly(FilterItemOrder filter, ICollection<OrderWithExpandedBool> orders)
		{
			return orders.Where(o => DateOnly.FromDateTime(o.OrderVM.OrderDate).CompareTo(DateOnly.FromDateTime((DateTime)filter.StartDate!)) >= 0).ToList();

        }

		private static List<OrderWithExpandedBool> PerformSearchByDateRange(FilterItemOrder filter, ICollection<OrderWithExpandedBool> orders)
		{
			return orders.Where(o => DateOnly.FromDateTime(o.OrderVM.OrderDate).CompareTo(DateOnly.FromDateTime((DateTime)filter.StartDate!)) >= 0 
									&& DateOnly.FromDateTime(o.OrderVM.OrderDate).CompareTo(DateOnly.FromDateTime((DateTime)filter.EndDate!)) <= 0).ToList();

		}
	}
}
