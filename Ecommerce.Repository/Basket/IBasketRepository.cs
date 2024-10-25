﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Repository.Basket
{
    public interface IBasketReposatry
    {
        Task<UserBasket> GetBasketAsync(Guid? id);
        Task<UserBasket> UpdateBasketAsync(UserBasket basket);
        Task<bool> DeleteBasketAsync(Guid id);
    }
}