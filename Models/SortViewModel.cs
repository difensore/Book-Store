namespace BookStore.Models
{
    public class SortViewModel
    {
        public SortState NameSort { get; } 
        public SortState PriceSort { get; }              
        public SortState Current { get; } 

        public SortViewModel(SortState sortOrder)
        {
            NameSort = sortOrder == SortState.NameAsc ? SortState.NameDesc : SortState.NameAsc;
            PriceSort = sortOrder == SortState.PriceAsc ? SortState.PriceDesc : SortState.PriceAsc;           
            Current = sortOrder;
        }
    }
}
