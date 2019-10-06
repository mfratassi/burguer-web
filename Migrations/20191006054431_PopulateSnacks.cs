using Microsoft.EntityFrameworkCore.Migrations;

namespace LanchesWeb.Migrations
{
    public partial class PopulateSnacks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string[] lanchesImages =
            {
                 "https://sanpagourmet.com/wp-content/uploads/2018/04/burguer-mexicano-820x570.png",
                 "https://u.tfstatic.com/restaurant_photos/169/523169/169/612/burguer-place-2-e68dc.jpg",
                 "https://cdn.neemo.com.br/uploads/item/photo/187511/FRANGO-BURGUER.jpg",
                 "https://live.staticflickr.com/4554/37832964885_75ea155695_b.jpg",
                 "https://www.comerciosnobairro.com.br/anunciante/img/img_produtos/20170914011451_9414a8f5b810972c3c9a0e2860c07532_1375995380_img_ofertas_premium.jpg"
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
