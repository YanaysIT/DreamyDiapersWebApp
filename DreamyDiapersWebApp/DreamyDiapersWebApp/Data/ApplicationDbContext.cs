namespace DreamyDiapersWebApp.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<Item> Item => Set<Item>();
   // public DbSet<Cart> Cart => Set<Cart>();
    public DbSet<CartItem> CartItems => Set<CartItem>();
    public DbSet<Order> Order => Set<Order>();
    public DbSet<OrderItem> OrderItem => Set<OrderItem>();
    public DbSet<Address> Address => Set<Address>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Item>().HasData(
            new Item()
            {
                Id = 1,
                Name = "Supreme Soft Teddy Bear",
                Description = "Our teddy bear sets the standard for supreme softness and unmatched quality. Made from top-tier " +
                      "materials, its velvety fur invites you into a world of comfort. Experience the pinnacle of plush perfection with" +
                      " this exceptional cuddle companion.",
                Url = "Pictures/Items/TeddyBear.jpg",
                Price = 15,
                OriginalPrice = 15,
                Stock = 20
            },
            new Item()
            {
                Id = 2,
                Name = "Wooden Walker",
                Description = "Enhance your baby's first steps with our Wooden Walker. Immerse your little one in the charm of" +
                " nature as they take confident strides with this meticulously crafted wooden stroller. Designed for comfort and" +
                " security, our eco-conscious Wooden Walker ensures a stylish and enjoyable outdoor experience for both you and " +
                "your baby. Let every step be a delightful journey with the essence of nature guiding the way.",
                Url = "Pictures/Items/WoodenWalker.jpg",
                Price = 42.99m,
                OriginalPrice = 45.99m,
                Stock = 340
            },
            new Item()
            {
                Id = 3,
                Name = "Dr. Brown's Baby Bottle",
                Description = "Dr. Brown's baby Bottle ensures a natural flow for your baby's feeding journey. Designed with a " +
                      "focus on mimicking breastfeeding, these bottles promote a seamless transition and offer a comforting experience, " +
                      "making mealtime a joy for both baby and parent.",
                Url = "Pictures/Items/Bottle.jpg",
                Price = 8,
                OriginalPrice = 9.99m,
                Stock = 89
            },
            new Item()
            {
                Id = 4,
                Name = "Versatile Baby Clips",
                Description = "Keep it together with our versatile clips. Ideal for securing blankets, toys, or stroller accessories, " +
                "these clips add convenience to your parenting journey.",
                Url = "Pictures/Items/Clips.jpg",
                Price = 1.29m,
                OriginalPrice = 1.29m,
                Stock = 50
            },
            new Item()
            {
                Id = 5,
                Name = "Pacifier Set",
                Description = "Soothe your little one with our pacifier set. Designed for comfort and style, these pacifiers offer a " +
                "calming experience for your baby.",
                Url = "Pictures/Items/Pacifiers.jpg",
                Price = 4.59m,
                OriginalPrice = 4.59m,
                Stock = 0
            },

            new Item()
            {
                Id = 6,
                Name = "Baby Bottle Drying Rack",
                Description = "Facilitate efficient drying of your baby bottles with our purpose-built drying rack. Its smart " +
                 "design allows for easy arrangement and quick air-drying after washing.",
                Url = "Pictures/Items/BottleDryingRack.jpg",
                Price = 9,
                OriginalPrice = 12,
                Stock = 25
            },
            new Item()
            {
                Id = 7,
                Name = "Portable Travel Crib",
                Description = "Make on-the-go napping a breeze with our travel crib. Compact and comfortable, this crib provides a cozy space for your baby to rest during your adventures.",
                Url = "Pictures/Items/TravelCrib.jpg",
                Price = 69.99m,
                OriginalPrice = 69.99m,
                Stock = 16
            },
            new Item()
            {
                Id = 8,
                Name = "Play Yard",
                Description = "Create a safe and playful environment for your little one with our play yard. Easy to set up and fold," +
                " it's the perfect solution for indoor and outdoor playtime.",
                Url = "Pictures/Items/PlayYard.jpg",
                Price = 89,
                OriginalPrice = 99,
                Stock = 25
            },
            new Item()
            {
                Id = 9,
                Name = "Baby's First Walker",
                Description = "Support your baby's first steps with our sturdy walker. Designed for stability and fun, it encourages mobility and exploration in a safe environment.",
                Url = "Pictures/Items/Walker.jpg",
                Price = 44.99m,
                OriginalPrice = 49.99m,
                Stock = 34
            },
            new Item()
            {
                Id = 10,
                Name = "Red Double Stroller",
                Description = "Navigate the streets with ease using our double stroller. Featuring a sleek red design and spacious " +
                "seating, it's perfect for parents with two little ones.",
                Url = "Pictures/Items/Stroller.jpg",
                Price = 229,
                OriginalPrice = 229,
                Stock = 12
            },
             new Item()
             {
                 Id = 11,
                 Name = "Cozy White Onesie",
                 Description = "Dress your baby in comfort and style with our white onesie. Made from soft, breathable fabric, it's" +
                 " perfect for everyday wear and cuddle time.",
                 Url = "Pictures/Items/Onesie.jpg",
                 Price = 89,
                 OriginalPrice = 89,
                 Stock = 13
             },
             new Item()
             {
                 Id = 12,
                 Name = "Yellow Butterfly Backpack",
                 Description = "Stay organized on the go with our cute backpack. Let your little one's imagination soar with our " +
                 "adorable butterfly-shaped backpack. This cutie yellow backpack is not only stylish but also designed with comfort" +
                 " and convenience in mind.",
                 Url = "Pictures/Items/Backpack.jpg",
                 Price = 12,
                 OriginalPrice = 12,
                 Stock = 14
             },
             new Item()
             {
                 Id = 13,
                 Name = "Safety Aid Bands Set",
                 Description = "Ensure your baby's safety with our set of aid bands. Adjustable and comfortable, these bands offer " +
                 "peace of mind during everyday activities.",
                 Url = "Pictures/Items/AidBands.jpg",
                 Price = 0.99m,
                 OriginalPrice = 1.99m,
                 Stock = 0
             },
             new Item()
             {
                 Id = 14,
                 Name = "Stimulating Baby Rattle",
                 Description = "Entertain and stimulate your baby's senses with our charming rattle. Crafted for tiny hands, this delightful toy encourages early development.",
                 Url = "Pictures/Items/Rattle.jpg",
                 Price = 3.99m,
                 OriginalPrice = 4.99m,
                 Stock = 50
             }
             );
        base.OnModelCreating(modelBuilder);
    }
}
