using System.Linq;

namespace LopushokNew.DB
{
    public partial class Product
    {
        public string MaterialsList => string.Join(", ", ProductMaterials.Select(x => x.Material.Name));

        public string Color => "#ffffff";
    }
}
