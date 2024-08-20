using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace URLShortener.Migrations
{
    /// <inheritdoc />
    public partial class initdb2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "URLShorter",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    URLName = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    URLShorterName = table.Column<string>(type: "nvarchar(200)", maxLength: 20, nullable: true),
                    ShortCode = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_URLShorter", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_URLShorter_ShortCode",
                table: "URLShorter",
                column: "ShortCode",
                unique: true,
                filter: "[ShortCode] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "URLShorter");
        }
    }
}
