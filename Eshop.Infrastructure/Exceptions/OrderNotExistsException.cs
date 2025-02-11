﻿namespace Eshop.Infrastructure.Exceptions
{
    public class OrderNotExistsException : Exception
    {
        public Guid Id { get; }

        public OrderNotExistsException(Guid id)
        {
            Id = id;
        }
    }
}