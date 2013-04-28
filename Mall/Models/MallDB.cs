using System.Data.Entity;

namespace Mall.Models
{
    public class MallDB : DbContext
    {
        // 您可以向此文件中添加自定义代码。更改不会被覆盖。
        // 
        // 如果您希望只要更改模型架构，Entity Framework
        // 就会自动删除并重新生成数据库，则将以下
        // 代码添加到 Global.asax 文件中的 Application_Start 方法。
        // 注意: 这将在每次更改模型时销毁并重新创建数据库。
        // 
        //System.Data.Entity.Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<Mall.Models.MallDB>());


        public DbSet<Category> Category { get; set; }

        public DbSet<GoodsType> GoodsType { get; set; }

        public DbSet<Goods> Goods { get; set; }

        public DbSet<Brand> Brand { get; set; }

        public DbSet<Suppliers> Suppliers { get; set; }

        public DbSet<PaintSizes> PaintSizes { get; set; }

        public DbSet<Cart> Carts { get; set; }

        public DbSet<Frames> Frames { get; set; }

        public DbSet<Shipping> Shippings { get; set; }

        public DbSet<Payment> Payments { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<UserAddress> UserAddresses { get; set; }

        public DbSet<Users> Users { get; set; }


    }
}
