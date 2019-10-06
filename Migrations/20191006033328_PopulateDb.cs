using Microsoft.EntityFrameworkCore.Migrations;

namespace LanchesWeb.Migrations
{
    public partial class PopulateDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string queryString =
                "INSERT INTO SnackCategories(Name, Description) " +
                "VALUES('Para Todo Dia', 'Lanches saborosos e saudáveis que combinam com qualquer dia e horário para matar a sua fome!')";
            migrationBuilder.Sql(queryString);

            queryString =
                "INSERT INTO SnackCategories(Name, Description) " +
                "VALUES('Gourmet', 'Lanches com sabor inestimável para paladares aguçados. Quando você quer bancar o degustador, esses são a melhor opção')";
            migrationBuilder.Sql(queryString);


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM SnackCategories");
            migrationBuilder.Sql("DELETE FROM Snacks");
        }
    }
}
