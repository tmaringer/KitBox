using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectCS
{
    // TODO : terminer
    public static class OrderFormViewInterface
    {
        private static OrderForm _orderForm = new OrderForm();
        private static ShoppingCart _shoppingCart = new ShoppingCart();
        
        public static OrderForm orderForm
        {
            get => _orderForm;
        }

        public static ShoppingCart shoppingCart
        {
            get => _shoppingCart;
        }
        
        // todo : faire test
        public static void createCupbaord(int width, int depth, int boxNumber, Color colorAngleBracket)
        {
            _shoppingCart.buildCupboard(width, depth, boxNumber, colorAngleBracket);
        }


    }
}
