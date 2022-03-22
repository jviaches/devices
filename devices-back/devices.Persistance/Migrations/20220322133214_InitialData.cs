using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace devices.Persistance.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Devices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    DeviceType = table.Column<int>(type: "integer", nullable: false),
                    DeviceStatus = table.Column<int>(type: "integer", nullable: false),
                    RelatedDevices = table.Column<Guid[]>(type: "uuid[]", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devices", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Devices",
                columns: new[] { "Id", "DeviceStatus", "DeviceType", "Name", "RelatedDevices" },
                values: new object[,]
                {
                    { new Guid("93db428b-aad2-4a0c-bdb7-8d7941c23649"), 2, 0, "Device 1", new[] { new Guid("81c066fb-3b81-40e8-a863-3ccf589b6119"), new Guid("81c066fb-3b81-40e8-a863-3ccf589b6119"), new Guid("bfaeb67a-6d2a-4e9c-b615-07f4052e0966") } },
                    { new Guid("81c066fb-3b81-40e8-a863-3ccf589b6119"), 0, 1, "Device 2", null },
                    { new Guid("bfeefcc2-d1a7-4e48-b221-8ace75a69d8b"), 2, 2, "Device 3", null },
                    { new Guid("bfaeb67a-6d2a-4e9c-b615-07f4052e0966"), 2, 3, "Device 4", null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Devices");
        }
    }
}
