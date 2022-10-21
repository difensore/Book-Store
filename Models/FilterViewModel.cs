using Microsoft.AspNetCore.Mvc.Rendering;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BookStore.Models
{
    public class FilterViewModel
    {
        public FilterViewModel( string name)
        {           
            SelectedName = name;
        }        
        public string SelectedName { get; }
    }
}
