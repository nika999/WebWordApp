using Microsoft.EntityFrameworkCore.Migrations;

namespace WebWord.Data.Migrations
{
    public partial class a4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Vocabularies_StudentId",
                table: "Vocabularies",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Vocabularies_WordId",
                table: "Vocabularies",
                column: "WordId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vocabularies_Students_StudentId",
                table: "Vocabularies",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vocabularies_Words_WordId",
                table: "Vocabularies",
                column: "WordId",
                principalTable: "Words",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vocabularies_Students_StudentId",
                table: "Vocabularies");

            migrationBuilder.DropForeignKey(
                name: "FK_Vocabularies_Words_WordId",
                table: "Vocabularies");

            migrationBuilder.DropIndex(
                name: "IX_Vocabularies_StudentId",
                table: "Vocabularies");

            migrationBuilder.DropIndex(
                name: "IX_Vocabularies_WordId",
                table: "Vocabularies");
        }
    }
}
