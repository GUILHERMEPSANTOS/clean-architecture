using Microsoft.EntityFrameworkCore.Migrations;

namespace CleanArch.Infra.Data.Migrations
{
    public partial class SeedProducts : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql(@"INSERT INTO Products(Name,Description, Price, Stock,Image,CategoryId)
            VALUES('Caderno espiral', 'Caderno espiral 100 folhas', 8.0,50,'caderno1.jpg',1)");
        }

        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("DELETE FROM Products");
        }
    }
}
