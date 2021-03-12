using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelThomasChristian.Interfaces;
using HotelThomasChristian.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HotelThomasChristian.Pages.Hotels
{
    public class GetAllHotelsModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string FilterCriteria { get; set; }
        public List<Hotel> Hotels { get; private set; }

        public int christian = 10; 
        private IHotelService hotelService;

        public GetAllHotelsModel(IHotelService hService)
        {
            this.hotelService = hService;
        }
        public async Task OnGetAsync()
        {
            if (!String.IsNullOrEmpty(FilterCriteria))
            {
                Hotels = await hotelService.GetHotelsByNameAsync(FilterCriteria);
            }
            else
                Hotels = await hotelService.GetAllHotelAsync();
        }
    }
}
