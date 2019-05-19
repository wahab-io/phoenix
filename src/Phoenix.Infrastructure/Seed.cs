using System;
using Phoenix.Domain.Customers;
using Phoenix.Domain.Suppliers;
using Phoenix.Domain.Products;

namespace Phoenix.Infrastructure
{
    public static class Seed
    {
        public static Customer[] Customers()
        {
            var customers = new[]
            {
                new Customer { Id = 1, StreetLine1 = "Obere Str. 57", City = "Berlin", Name = "Alfreds Futterkiste", Country = "Germany", Fax = "030-0076545", Phone = "030-0074321", ZipCode = "12209" },
                new Customer { Id = 2, StreetLine1 = "Avda. de la Constitución 2222", City = "México D.F.", Name = "Ana Trujillo Emparedados y helados", Country = "Mexico", Fax = "(5) 555-3745", Phone = "(5) 555-4729", ZipCode = "05021" },
                new Customer { Id = 3, StreetLine1 = "Mataderos  2312", City = "México D.F.", Name = "Antonio Moreno Taquería", Country = "Mexico", Fax = "", Phone = "(5) 555-3932", ZipCode = "05023" },
                new Customer { Id = 4, StreetLine1 = "120 Hanover Sq.", City = "London", Name = "Around the Horn", Country = "UK", Fax = "(171) 555-6750", Phone = "(171) 555-7788", ZipCode = "WA1 1DP" },
                new Customer { Id = 5, StreetLine1 = "Berguvsvägen  8", City = "Luleå", Name = "Berglunds snabbköp", Country = "Sweden", Fax = "0921-12 34 67", Phone = "0921-12 34 65", ZipCode = "S-958 22" },                
                new Customer { Id = 6, StreetLine1 = "24, place Kléber", City = "Strasbourg", Name = "Blondesddsl père et fils", Country = "France", Fax = "88.60.15.32", Phone = "88.60.15.31", ZipCode = "67000" },
                new Customer { Id = 7, StreetLine1 = "C/ Araquil, 67", City = "Madrid", Name = "Bólido Comidas preparadas", Country = "Spain", Fax = "(91) 555 91 99", Phone = "(91) 555 22 82", ZipCode = "28023" },
                new Customer { Id = 8, StreetLine1 = "12, rue des Bouchers", City = "Marseille", Name = "Bon app'", Country = "France", Fax = "91.24.45.41", Phone = "91.24.45.40", ZipCode = "13008" },
                new Customer { Id = 9, StreetLine1 = "23 Tsawassen Blvd.", City = "Tsawassen", Name = "Bottom-Dollar Markets", Country = "Canada", Fax = "(604) 555-3745", Phone = "(604) 555-4729", ZipCode = "T2F 8M4" },
                new Customer { Id = 10, StreetLine1 = "Fauntleroy Circus", City = "London", Name = "B's Beverages", Country = "UK", Fax = "", Phone = "(171) 555-1212", ZipCode = "EC2 5NT" },
                new Customer { Id = 11, StreetLine1 = "Cerrito 333", City = "Buenos Aires", Name = "Cactus Comidas para llevar", Country = "Argentina", Fax = "(1) 135-4892", Phone = "(1) 135-5555", ZipCode = "1010" },
                new Customer { Id = 12, StreetLine1 = "Sierras de Granada 9993", City = "México D.F.", Name = "Centro comercial Moctezuma", Country = "Mexico", Fax = "(5) 555-7293", Phone = "(5) 555-3392", ZipCode = "05022" },
                new Customer { Id = 13, StreetLine1 = "Hauptstr. 29", City = "Bern", Name = "Chop-suey Chinese", Country = "Switzerland", Fax = "", Phone = "0452-076545", ZipCode = "3012" },
                new Customer { Id = 14, StreetLine1 = "Av. dos Lusíadas, 23", City = "Sao Paulo", Name = "Comércio Mineiro", Country = "Brazil", Fax = "", Phone = "(11) 555-7647", ZipCode = "05432-043"},
                new Customer { Id = 15, StreetLine1 = "Berkeley Gardens 12  Brewery", City = "London", Name = "Consolidated Holdings", Country = "UK", Fax = "(171) 555-9199", Phone = "(171) 555-2282", ZipCode = "WX1 6LT" },
                new Customer { Id = 16, StreetLine1 = "Walserweg 21", City = "Aachen", Name = "Drachenblut Delikatessen", Country = "Germany", Fax = "0241-059428", Phone = "0241-039123", ZipCode = "52066" },
                new Customer { Id = 17, StreetLine1 = "67, rue des Cinquante Otages", City = "Nantes", Name = "Du monde entier", Country = "France", Fax = "40.67.89.89", Phone = "40.67.88.88", ZipCode = "44000" },
                new Customer { Id = 18, StreetLine1 = "35 King George", City = "London", Name = "Eastern Connection", Country = "UK", Fax = "(171) 555-3373", Phone = "(171) 555-0297", ZipCode = "WX3 6FW" },
                new Customer { Id = 19, StreetLine1 = "Kirchgasse 6", City = "Graz", Name = "Ernst Handel", Country = "Austria", Fax = "7675-3426", Phone = "7675-3425", ZipCode = "8010" },
                new Customer { Id = 20, StreetLine1 = "Rua Orós, 92", City = "Sao Paulo", Name = "Familia Arquibaldo", Country = "Brazil", Fax = "", Phone = "(11) 555-9857", ZipCode = "05442-030" },
                new Customer { Id = 21, StreetLine1 = "C/ Moralzarzal, 86", City = "Madrid", Name = "FISSA Fabrica Inter. Salchichas S.A.", Country = "Spain", Fax = "(91) 555 55 93", Phone = "(91) 555 94 44", ZipCode = "28034" },
                new Customer { Id = 22, StreetLine1 = "184, chaussée de Tournai", City = "Lille", Name = "Folies gourmandes", Country = "France", Fax = "20.16.10.17", Phone = "20.16.10.16", ZipCode = "59000" },
                new Customer { Id = 23, StreetLine1 = "Åkergatan 24", City = "Bräcke", Name = "Folk och fä HB", Country = "Sweden", Fax = "", Phone = "0695-34 67 21", ZipCode = "S-844 67" },
                new Customer { Id = 24, StreetLine1 = "Berliner Platz 43", City = "München", Name = "Frankenversand", Country = "Germany", Fax = "089-0877451", Phone = "089-0877310", ZipCode = "80805" },
                new Customer { Id = 25, StreetLine1 = "54, rue Royale", City = "Nantes", Name = "France restauration", Country = "France", Fax = "40.32.21.20", Phone = "40.32.21.21", ZipCode = "44000" },
                new Customer { Id = 26, StreetLine1 = "Via Monte Bianco 34", City = "Torino", Name = "Franchi S.p.A.", Country = "Italy", Fax = "011-4988261", Phone = "011-4988260", ZipCode = "10100" },
                new Customer { Id = 27, StreetLine1 = "Jardim das rosas n. 32", City = "Lisboa", Name = "Furia Bacalhau e Frutos do Mar", Country = "Portugal", Fax = "(1) 354-2535", Phone = "(1) 354-2534", ZipCode = "1675" },
                new Customer { Id = 28, StreetLine1 = "Rambla de Cataluña, 23", City = "Barcelona", Name = "Galería del gastrónomo", Country = "Spain", Fax = "(93) 203 4561", Phone = "(93) 203 4560", ZipCode = "08022" },
                new Customer { Id = 29, StreetLine1 = "C/ Romero, 33", City = "Sevilla", Name = "Godos Cocina Típica", Country = "Spain", Fax = "", Phone = "(95) 555 82 82", ZipCode = "41101" },
                new Customer { Id = 30, StreetLine1 = "Av. Brasil, 442", City = "Campinas", Name = "Gourmet Lanchonetes", Country = "Brazil", Fax = "", Phone = "(11) 555-9482", ZipCode = "04876-786" },
                new Customer { Id = 31, StreetLine1 = "2732 Baker Blvd.", City = "Eugene", Name = "Great Lakes Food Market", Country = "USA", Fax = "", Phone = "(503) 555-7555", ZipCode = "97403" },
                new Customer { Id = 32, StreetLine1 = "5ª Ave. Los Palos Grandes", City = "Caracas", Name = "GROSELLA-Restaurante", Country = "Venezuela", Fax = "(2) 283-3397", Phone = "(2) 283-2951", ZipCode = "1081" },
                new Customer { Id = 33, StreetLine1 = "Rua do Paço, 67", City = "Rio de Janeiro", Name = "Hanari Carnes", Country = "Brazil", Fax = "(21) 555-8765", Phone = "(21) 555-0091", ZipCode = "05454-876"},
                new Customer { Id = 34, StreetLine1 = "Carrera 22 con Ave. Carlos Soublette #8-35", City = "San Cristóbal", Name = "HILARION-Abastos", Country = "Venezuela", Fax = "(5) 555-1948", Phone = "(5) 555-1340", ZipCode = "5022" },
                new Customer { Id = 35, StreetLine1 = "City Center Plaza 516 Main St.", City = "Elgin", Name = "Hungry Coyote Import Store", Country = "USA", Fax = "(503) 555-2376", Phone = "(503) 555-6874", ZipCode = "97827" },
                new Customer { Id = 36, StreetLine1 = "8 Johnstown Road", City = "Cork", Name = "Hungry Owl All-Night Grocers", Country = "Ireland", Fax = "2967 3333", Phone = "2967 542", ZipCode = "" },
                new Customer { Id = 37, StreetLine1 = "Garden House Crowther Way", City = "Cowes", Name = "Island Trading", Country = "UK", Fax = "", Phone = "(198) 555-8888", ZipCode = "PO31 7PJ" },
                new Customer { Id = 38, StreetLine1 = "Maubelstr. 90", City = "Brandenburg", Name = "Königlich Essen", Country = "Germany", Fax = "", Phone = "0555-09876", ZipCode = "14776" },
                new Customer { Id = 39, StreetLine1 = "67, avenue de l'Europe", City = "Versailles", Name = "La corne d'abondance", Country = "France", Fax = "30.59.85.11", Phone = "30.59.84.10", ZipCode = "78000" },
                new Customer { Id = 40, StreetLine1 = "1 rue Alsace-Lorraine", City = "Toulouse", Name = "La maison d'Asie", Country = "France", Fax = "61.77.61.11", Phone = "61.77.61.10", ZipCode = "31000" },
                new Customer { Id = 41, StreetLine1 = "1900 Oak St.", City = "Vancouver", Name = "Laughing Bacchus Wine Cellars", Country = "Canada", Fax = "(604) 555-7293", Phone = "(604) 555-3392", ZipCode = "V3F 2K1" },
                new Customer { Id = 42, StreetLine1 = "12 Orchestra Terrace", City = "Walla Walla", Name = "Lazy K Kountry Store", Country = "USA", Fax = "(509) 555-6221", Phone = "(509) 555-7969", ZipCode = "99362", },
                new Customer { Id = 43, StreetLine1 = "Magazinweg 7", City = "Frankfurt a.M.", Name = "Lehmanns Marktstand", Country = "Germany", Fax = "069-0245874", Phone = "069-0245984", ZipCode = "60528" },
                new Customer { Id = 44, StreetLine1 = "87 Polk St. Suite 5", City = "San Francisco", Name = "Let's Stop N Shop", Country = "USA", Fax = "", Phone = "(415) 555-5938", ZipCode = "94117" },
                new Customer { Id = 45, StreetLine1 = "Carrera 52 con Ave. Bolívar #65-98 Llano Largo", City = "Barquisimeto", Name = "LILA-Supermercado", Country = "Venezuela", Fax = "(9) 331-7256", Phone = "(9) 331-6954", ZipCode = "3508" }                
            };
            return customers;
        }

        public static Supplier[] Suppliers()
        {
            var suppliers = new Supplier[]
            {
                new Supplier { Id = 1, Name = "Hebie Hurai Pharmaceuticals", StreetAddress1 = "", City = "Xianho", State = "Xiangzho", ZipCode = "172818" },
                new Supplier { Id = 2, Name = "Hong Kong Chemicals", StreetAddress1 = "", City = "Xianho", State = "Xiangzho", ZipCode = "172818" },
                new Supplier { Id = 3, Name = "North China Industries", StreetAddress1 = "", City = "Xianho", State = "Xiangzho", ZipCode = "172818" },
                new Supplier { Id = 4, Name = "Neon Chemicals", StreetAddress1 = "", City = "Xianho", State = "Xiangzho", ZipCode = "172818" },
                new Supplier { Id = 5, Name = "Mehran International", StreetAddress1 = "", City = "Xianho", State = "Xiangzho", ZipCode = "172818" },
                new Supplier { Id = 6, Name = "Zenith Securities", StreetAddress1 = "", City = "Xianho", State = "Xiangzho", ZipCode = "172818" },
                new Supplier { Id = 7, Name = "Mumbai Fashion Accessories", StreetAddress1 = "", City = "Xianho", State = "Xiangzho", ZipCode = "172818" },
                new Supplier { Id = 8, Name = "Xainshu Chemicals Shanghai", StreetAddress1 = "", City = "Xianho", State = "Xiangzho", ZipCode = "172818" },
                new Supplier { Id = 9, Name = "Foster Pharmaceuticals", StreetAddress1 = "", City = "Xianho", State = "Xiangzho", ZipCode = "172818" },
                new Supplier { Id = 10, Name = "Gennie Industrial Pharmaceutical", StreetAddress1 = "", City = "Xianho", State = "Xiangzho", ZipCode = "172818" }
            };            
            return suppliers;
        }

        public static Product[] Products()
        {
            var products = new Product[]
            {
                new Product { Id = 1, Name = "Oxytocin", Description = "Mild drug for pain relief" },
                new Product { Id = 2, Name = "Benzin Floric", Description = "Mild drug for pain relief" },
                new Product { Id = 3, Name = "Paracetamol", Description = "Mild drug for pain relief" },
            };
            return products;
        }
    }
}