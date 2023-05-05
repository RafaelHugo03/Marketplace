using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marketplace.Domain.enums
{
    public enum OrderStatus
    {
        PendingPayment,
        Canceled,
        PaymentConfirmed
    }
}