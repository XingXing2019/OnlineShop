using Shop.Domain.Model;
using Shop.Domain.ViewModel;

namespace Shop.UI.Services
{
    public interface ICartService
    {
        void Post(CartProduct cartProduct);
        CartProductViewModel Get();
    }
}