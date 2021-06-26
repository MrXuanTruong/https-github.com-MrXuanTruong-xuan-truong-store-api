using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Entity.Enums
{
    public class OrderStatusEnum
    {
        public const int WAIT = 1;
        public const int CONFIRMED = 2;
        public const int PAID = 3;
        public const int CANCEL = 4;
        public const int EXPORTED = 20002;
        public const int REFUND = 10002;

    }
}
