using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantMenu.ApiService.Migrations;

/// <inheritdoc />
public partial class SeedCategories : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder mb)
    {
        mb.Sql("INSERT INTO categories (name, image_url, created_at, updated_at) VALUES " +
            "('Drinks', 'drinks.jpg', now(), now()), " +
            "('Burgers', 'burgers.jpg', now(), now()), " +
            "('Salads', 'salads.jpg', now(), now())"
        );
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder mb)
    {
        mb.Sql("DELETE FROM categories WHERE name IN ('Drinks', 'Burgers', 'Salads')");
    }
}
