namespace BookStore.Interfaces
{
    public interface IOrdersProvider
    {
        public void CreateOrder(int phone, string adress);
    }
}
