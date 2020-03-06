using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectCS
{
    // todo : peut être la rendre static
    class OrderFormUIinterface
    {
        private OrderForm _orderForm;
        public OrderForm orderForm
        {
            get => _orderForm;
        }

        public OrderFormUIinterface(OrderForm orderForm)
        {
            
        }


    }
}
