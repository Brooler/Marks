using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Marks.Database.Migrations
{
    public partial class AddedIndexOnPeopleFullName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Peoples_FirstName_LastName",
                table: "Peoples",
                columns: new[] { "FirstName", "LastName" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Peoples_FirstName_LastName",
                table: "Peoples");
        }
    }
}
