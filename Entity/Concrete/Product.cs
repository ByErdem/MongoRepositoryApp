using MongoDB.Entities;
using Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Product : IDBEntity
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public decimal Value { get; set; }
        public int Quantity { get; set; }
    }
}
