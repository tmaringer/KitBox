using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectCS
{
    // todo : peut être la rendre static
    public static class OrderFormUIinterface
    {
        private static OrderForm _orderForm = new OrderForm();
        public static OrderForm orderForm
        {
            get => _orderForm;
        }

        


    }
}
