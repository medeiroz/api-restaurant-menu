using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantMenu.ApiService.Migrations;

/// <inheritdoc />
public partial class SeedProducts : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder mb)
    {
        mb.Sql("INSERT INTO products (name, description, price, image_url, stoke, category_id, created_at, updated_at) VALUES " +
            "('Coca Cola', 'Coca Cola 500ml', 550, 'coca-cola.jpg', 100, 1, now(), now()), " +
            "('Fanta', 'Fanta 500ml', 550, 'fanta.jpg', 100, 1, now(), now()), " +
            "('Sprite', 'Sprite 500ml', 550, 'sprite.jpg', 100, 1, now(), now()), " +

            "('Cheeseburger', 'Cheeseburger with beef patty', 1500, 'cheeseburger.jpg', 100, 2, now(), now()), " +
            "('Hamburger', 'Hamburger with beef patty', 1200, 'hamburger.jpg', 100, 2, now(), now()), " +
            "('Double Cheeseburger', 'Double Cheeseburger with beef patty', 2000, 'double-cheeseburger.jpg', 100, 2, now(), now()), " +

            "('Caesar Salad', 'Caesar Salad with chicken', 1200, 'caesar-salad.jpg', 100, 3, now(), now()), " +
            "('Greek Salad', 'Greek Salad with feta cheese', 1000, 'greek-salad.jpg', 100, 3, now(), now()), " +
            "('Garden Salad', 'Garden Salad with vegetables', 800, 'garden-salad.jpg', 100, 3, now(), now()) "
         );
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder mb)
    {
        mb.Sql("DELETE FROM products WHERE name IN ('Coca Cola', 'Fanta', 'Sprite', 'Cheeseburger', 'Hamburger', 'Double Cheeseburger', 'Caesar Salad', 'Greek Salad', 'Garden Salad')");
    }
}
