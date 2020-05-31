using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IO.Swagger.Migrations
{
    public partial class PetStoreInitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(maxLength: 64, nullable: false),
                    password = table.Column<string>(maxLength: 64, nullable: false),
                    firstname = table.Column<string>(maxLength: 64, nullable: true),
                    lastname = table.Column<string>(maxLength: 64, nullable: true),
                    email = table.Column<string>(maxLength: 128, nullable: false),
                    phone = table.Column<string>(maxLength: 16, nullable: false),
                    status = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Invoice_Status",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice_Status", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Invoice",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    invoice_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    status_id = table.Column<int>(nullable: false),
                    customer_id = table.Column<int>(nullable: false),
                    ship_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    delivery_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    shipping_address = table.Column<string>(maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.id);
                    table.ForeignKey(
                        name: "FK__Invoice__custome__5FB337D6",
                        column: x => x.customer_id,
                        principalTable: "Customer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Invoice__status___5EBF139D",
                        column: x => x.status_id,
                        principalTable: "Invoice_Status",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pet",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(maxLength: 64, nullable: true),
                    status = table.Column<string>(maxLength: 32, nullable: true),
                    category_id = table.Column<int>(nullable: true),
                    invoice_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pet", x => x.id);
                    table.ForeignKey(
                        name: "FK__Pet__category_id__5070F446",
                        column: x => x.category_id,
                        principalTable: "Category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Pet__invoice_id__68487DD7",
                        column: x => x.invoice_id,
                        principalTable: "Invoice",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pet_Tag_Mapping",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pet_id = table.Column<int>(nullable: false),
                    tag_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pet_Tag_Mapping", x => x.id);
                    table.ForeignKey(
                        name: "FK__Pet_Tag_M__pet_i__66603565",
                        column: x => x.pet_id,
                        principalTable: "Pet",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Pet_Tag_M__tag_i__6754599E",
                        column: x => x.tag_id,
                        principalTable: "Tag",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "UQ__Category__72E12F1BE07B17E6",
                table: "Category",
                column: "name",
                unique: true,
                filter: "[name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UQ__Customer__AB6E6164078B2432",
                table: "Customer",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Customer__6E2DBEDEBDEC29AB",
                table: "Customer",
                column: "password",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Customer__B43B145FE6986663",
                table: "Customer",
                column: "phone",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Customer__F3DBC5721B62B3FF",
                table: "Customer",
                column: "username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_customer_id",
                table: "Invoice",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_status_id",
                table: "Invoice",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "UQ__Invoice___72E12F1BBC8D8952",
                table: "Invoice_Status",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pet_category_id",
                table: "Pet",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_Pet_invoice_id",
                table: "Pet",
                column: "invoice_id");

            migrationBuilder.CreateIndex(
                name: "IX_Pet_Tag_Mapping_pet_id",
                table: "Pet_Tag_Mapping",
                column: "pet_id");

            migrationBuilder.CreateIndex(
                name: "IX_Pet_Tag_Mapping_tag_id",
                table: "Pet_Tag_Mapping",
                column: "tag_id");

            migrationBuilder.CreateIndex(
                name: "UQ__Tag__72E12F1BCA4C4E51",
                table: "Tag",
                column: "name",
                unique: true,
                filter: "[name] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pet_Tag_Mapping");

            migrationBuilder.DropTable(
                name: "Pet");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Invoice");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Invoice_Status");
        }
    }
}
