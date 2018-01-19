using CustomersReestr.Components.Models;

namespace CustomersReestr.Components.ContentWindows
{
    interface IMainWindowFrameWorker
    {
        void NavigateToEditCustomer(Customer customer);
        void NavigateToCustomersGrid();
    }
}
