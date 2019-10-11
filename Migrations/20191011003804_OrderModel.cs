using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LanchesWeb.Migrations
{
    public partial class OrderModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeliveredTime",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DepartureTime",
                table: "Orders",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeliveredTime",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DepartureTime",
                table: "Orders");
        }
    }
}
