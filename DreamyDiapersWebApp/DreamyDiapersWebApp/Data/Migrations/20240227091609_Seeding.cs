using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DreamyDiapersWebApp.Migrations
{
    /// <inheritdoc />
    public partial class Seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItem_Cart_CartId",
                table: "CartItem");

            migrationBuilder.DropForeignKey(
                name: "FK_CartItem_Item_ItemId",
                table: "CartItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CartItem",
                table: "CartItem");

            migrationBuilder.RenameTable(
                name: "CartItem",
                newName: "CartItems");

            migrationBuilder.RenameIndex(
                name: "IX_CartItem_ItemId",
                table: "CartItems",
                newName: "IX_CartItems_ItemId");

            migrationBuilder.RenameIndex(
                name: "IX_CartItem_CartId",
                table: "CartItems",
                newName: "IX_CartItems_CartId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CartItems",
                table: "CartItems",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Item",
                columns: new[] { "Id", "Description", "Name", "OriginalPrice", "Price", "Stock", "Url" },
                values: new object[,]
                {
                    { 1, "Our teddy bear sets the standard for supreme softness and unmatched quality. Made from top-tier materials, its velvety fur invites you into a world of comfort. Experience the pinnacle of plush perfection with this exceptional cuddle companion.", "Supreme Soft Teddy Bear", 15m, 15m, 20, "Pictures/Items/TeddyBear.jpg" },
                    { 2, "Enhance your baby's first steps with our Wooden Walker. Immerse your little one in the charm of nature as they take confident strides with this meticulously crafted wooden stroller. Designed for comfort and security, our eco-conscious Wooden Walker ensures a stylish and enjoyable outdoor experience for both you and your baby. Let every step be a delightful journey with the essence of nature guiding the way.", "Wooden Walker", 45.99m, 42.99m, 340, "Pictures/Items/WoodenWalker.jpg" },
                    { 3, "Dr. Brown's baby Bottle ensures a natural flow for your baby's feeding journey. Designed with a focus on mimicking breastfeeding, these bottles promote a seamless transition and offer a comforting experience, making mealtime a joy for both baby and parent.", "Dr. Brown's Baby Bottle", 9.99m, 8m, 89, "Pictures/Items/Bottle.jpg" },
                    { 4, "Keep it together with our versatile clips. Ideal for securing blankets, toys, or stroller accessories, these clips add convenience to your parenting journey.", "Versatile Baby Clips", 1.29m, 1.29m, 50, "Pictures/Items/Clips.jpg" },
                    { 5, "Soothe your little one with our pacifier set. Designed for comfort and style, these pacifiers offer a calming experience for your baby.", "Pacifier Set", 4.59m, 4.59m, 0, "Pictures/Items/Pacifiers.jpg" },
                    { 6, "Facilitate efficient drying of your baby bottles with our purpose-built drying rack. Its smart design allows for easy arrangement and quick air-drying after washing.", "Baby Bottle Drying Rack", 12m, 9m, 25, "Pictures/Items/BottleDryingRack.jpg" },
                    { 7, "Make on-the-go napping a breeze with our travel crib. Compact and comfortable, this crib provides a cozy space for your baby to rest during your adventures.", "Portable Travel Crib", 69.99m, 69.99m, 16, "Pictures/Items/TravelCrib.jpg" },
                    { 8, "Create a safe and playful environment for your little one with our play yard. Easy to set up and fold, it's the perfect solution for indoor and outdoor playtime.", "Play Yard", 99m, 89m, 25, "Pictures/Items/PlayYard.jpg" },
                    { 9, "Support your baby's first steps with our sturdy walker. Designed for stability and fun, it encourages mobility and exploration in a safe environment.", "Baby's First Walker", 49.99m, 44.99m, 34, "Pictures/Items/Walker.jpg" },
                    { 10, "Navigate the streets with ease using our double stroller. Featuring a sleek red design and spacious seating, it's perfect for parents with two little ones.", "Red Double Stroller", 229m, 229m, 12, "Pictures/Items/Stroller.jpg" },
                    { 11, "Dress your baby in comfort and style with our white onesie. Made from soft, breathable fabric, it's perfect for everyday wear and cuddle time.", "Cozy White Onesie", 89m, 89m, 13, "Pictures/Items/Onesie.jpg" },
                    { 12, "Stay organized on the go with our cute backpack. Let your little one's imagination soar with our adorable butterfly-shaped backpack. This cutie yellow backpack is not only stylish but also designed with comfort and convenience in mind.", "Yellow Butterfly Backpack", 12m, 12m, 14, "Pictures/Items/Backpack.jpg" },
                    { 13, "Ensure your baby's safety with our set of aid bands. Adjustable and comfortable, these bands offer peace of mind during everyday activities.", "Safety Aid Bands Set", 1.99m, 0.99m, 0, "Pictures/Items/AidBands.jpg" },
                    { 14, "Entertain and stimulate your baby's senses with our charming rattle. Crafted for tiny hands, this delightful toy encourages early development.", "Stimulating Baby Rattle", 4.99m, 3.99m, 50, "Pictures/Items/Rattle.jpg" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Cart_CartId",
                table: "CartItems",
                column: "CartId",
                principalTable: "Cart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Item_ItemId",
                table: "CartItems",
                column: "ItemId",
                principalTable: "Item",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Cart_CartId",
                table: "CartItems");

            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Item_ItemId",
                table: "CartItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CartItems",
                table: "CartItems");

            migrationBuilder.DeleteData(
                table: "Item",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Item",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Item",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Item",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Item",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Item",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Item",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Item",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Item",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Item",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Item",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Item",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Item",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Item",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.RenameTable(
                name: "CartItems",
                newName: "CartItem");

            migrationBuilder.RenameIndex(
                name: "IX_CartItems_ItemId",
                table: "CartItem",
                newName: "IX_CartItem_ItemId");

            migrationBuilder.RenameIndex(
                name: "IX_CartItems_CartId",
                table: "CartItem",
                newName: "IX_CartItem_CartId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CartItem",
                table: "CartItem",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItem_Cart_CartId",
                table: "CartItem",
                column: "CartId",
                principalTable: "Cart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CartItem_Item_ItemId",
                table: "CartItem",
                column: "ItemId",
                principalTable: "Item",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
