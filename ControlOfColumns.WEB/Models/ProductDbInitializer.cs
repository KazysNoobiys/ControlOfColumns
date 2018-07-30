using System.Data.Entity;
using ControlOfColumns.DAL.EF;
using ControlOfColumns.DAL.Models;

namespace ControlOfColumns.WEB.Models
{
    public class ProductDbInitializer:DropCreateDatabaseAlways<ProductDbContext>
    {
        protected override void Seed(ProductDbContext context)
        {
            var p1 = new Product()
            {
                Name = "Швабра",
                Price = 700,
                Commnets = "Новый поставщик",
                Description = "Европейская швабра",
                Quantity = 50
            };
            var p2 = new Product()
            {
                Name = "Щётка",
                Price = 150,
                Commnets = "Заказать новую парити.",
                Description = "Жёсткая щётка",
                Quantity = 112
            };
            var p3 = new Product()
            {
                Name = "Чистящее средство Фейри",
                Price = 210,
                Commnets = "",
                Description = "Современное средство для мытья посуды",
                Quantity = 20
            };
            var p4 = new Product()
            {
                Name = "Металлическая щётка",
                Price = 30,
                Commnets = "Плохо разбирают, новую паритию не брать!",
                Description = "Металлическая щётка",
                Quantity = 30
            };
            context.Products.Add(p1);
            context.Products.Add(p2);
            context.Products.Add(p3);
            context.Products.Add(p4);
            context.SaveChanges();
            base.Seed(context);
        }
    }
}