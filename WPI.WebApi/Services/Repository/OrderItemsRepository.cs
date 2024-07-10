﻿using AutoMapper;
using WPI.WebApi.Data;
using WPI.WebApi.Data.Models.EF;
using WPI.WebApi.Services.Generic;
using WPI.WebApi.Services.IRepository;

namespace WPI.WebApi.Services.Repository
{
    public class OrderItemsRepository : GenericRepository<OrderItems> , IOrderItemsRepository
    {
        public OrderItemsRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
