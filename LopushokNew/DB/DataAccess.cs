using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;

namespace LopushokNew.DB
{
    public class DataAccess
    {
        public delegate void AddNewItem();
        public static event AddNewItem AddNewItemEvent;

        private static DbSet<Product> _products => LopushokNewEntities.GetContext().Products;


        public static List<Product> GetProducts() => _products.ToList();
        public static List<Material> GetMaterials() => LopushokNewEntities.GetContext().Materials.ToList();
        public static List<ProductType> GetProductTypes() => LopushokNewEntities.GetContext().ProductTypes.ToList();

        public static void SaveProduct(Product product)
        {
            if (product.Id == 0)
                _products.Add(product);

            LopushokNewEntities.GetContext().SaveChanges();
            AddNewItemEvent?.Invoke();
        }

        public static bool IsExist(Product product)
        {
            return _products.Any(p => p.Article == product.Article && p.Id != product.Id);
        }
    }
}
