using Core.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Entity.Concrete
{
    public class Product : IEntity
    {
        [Key]
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int? CategoryID { get; set; }
        public short UnitPrice { get; set; }
        public short UnitsInStock { get; set; }
    }
}
