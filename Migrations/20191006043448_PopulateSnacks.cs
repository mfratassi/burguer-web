using Microsoft.EntityFrameworkCore.Migrations;

namespace LanchesWeb.Migrations
{
    public partial class PopulateSnacks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string[] lanchesImages =
            {
                 "C:\\Users\\mfrat\\Documents\\CURSOS\\DOT NET\\LanchesWeb\\LanchesWeb\\wwwroot\\img\\lanches\\lanche-01.jpg",
                 "C:\\Users\\mfrat\\Documents\\CURSOS\\DOT NET\\LanchesWeb\\LanchesWeb\\wwwroot\\img\\lanches\\lanche-02.jpg",
                 "C:\\Users\\mfrat\\Documents\\CURSOS\\DOT NET\\LanchesWeb\\LanchesWeb\\wwwroot\\img\\lanches\\gourmet-01.jpg",
                 "C:\\Users\\mfrat\\Documents\\CURSOS\\DOT NET\\LanchesWeb\\LanchesWeb\\wwwroot\\img\\lanches\\gourmet-02.jpg",
                 "C:\\Users\\mfrat\\Documents\\CURSOS\\DOT NET\\LanchesWeb\\LanchesWeb\\wwwroot\\img\\lanches\\gourmet-03.jpg"
            };

            string[] lanches = {
                "('X-Tudo', 15.90, 'X-tudo: Lanche completo','Pão de hamburguer, hambúrguer bovino, queijo mussarela, presunto, ovo, salsicha, alface e tomate', '" + lanchesImages[0] + "', null, 1, 1, 19)",
                "('X-Salada', 13.90, 'X-Salada: Saboroso e leve','Pão de hambúrguer, hamburguer bovino, queijo mussarela, alface e tomate', '" + lanchesImages[1] + "', null, 0, 1, 19)",
                "('X-Salada Bacon', 16.90, 'Bacooon: Sempre','Pão de hambúrguer, hamburguer bovino, queijo mussarela, bacon, alface e tomate', '" + lanchesImages[2] + "', null, 0, 1, 19)",
                "('Costelinha Barbecue', 23.90, 'O sabor mais marcante','Pão de hambúrguer, queijo mussarela, costelinha desfiada, molho barbecue e tomate', '" + lanchesImages[3] + "', null, 1, 1, 20)",
                "('Birhl Burguer', 26.90, 'Bihrl, Monstro!','Pão francês gratinado, mussarela de búfala, hamburguer de contra-filé 200g, bacon, ovo, cebola, pepino', '" + lanchesImages[4] + "', null, 1, 1, 20)"
            };

            string queryString = "INSERT INTO Snacks(Name, Price, ShorDescription, LongDescription,MainImage, MainThumbnail, IsStarred, IsAvailable, SnackCategoryId) " +
                "VALUES ";

            for (int i = 0; i < lanches.Length - 1; i++)
            {
                queryString += lanches[i] + ", ";
            }
            queryString += lanches[lanches.Length - 1] + ";";


            migrationBuilder.Sql(queryString);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM SnackCategories");
            migrationBuilder.Sql("DELETE FROM Snacks");
        }
    }
}
