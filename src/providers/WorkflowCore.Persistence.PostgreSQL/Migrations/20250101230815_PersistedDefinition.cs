using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace WorkflowCore.Persistence.PostgreSQL.Migrations
{
    public partial class PersistedDefinition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Definition",
                schema: "wfc",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    WorkflowDefinitionId = table.Column<string>(maxLength: 200, nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: true),
                    Version = table.Column<int>(nullable: false),
                    MetaData = table.Column<string>(type: "jsonb", nullable: false /*, defaultValue: "{\"History\":[]}" */)

                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Definition", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Definition",
                schema: "wfc");

            
        }
    }
}
