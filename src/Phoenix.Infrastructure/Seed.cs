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
                new Customer { Id = 1, Name = "Devpulse", Phone = "(215) 2302985", Fax = "(859) 7142603", AddressLine1 = "9 Kropf Parkway", City = "Philadelphia", State = "Pennsylvania", ZipCode = "19151" },
                new Customer { Id = 2, Name = "Aimbu", Phone = "(915) 7769445", Fax = "(757) 7922211", AddressLine1 = "6182 Summit Trail", City = "El Paso", State = "Texas", ZipCode = "79984" },
                new Customer { Id = 3, Name = "Blogtag", Phone = "(678) 3925258", Fax = "(202) 1922572", AddressLine1 = "1 Alpine Hill", City = "Marietta", State = "Georgia", ZipCode = "30066" },
                new Customer { Id = 4, Name = "Lajo", Phone = "(281) 9731981", Fax = "(805) 2267375", AddressLine1 = "1 Vera Park", City = "Houston", State = "Texas", ZipCode = "77020" },
                new Customer { Id = 5, Name = "Gigabox", Phone = "(814) 9628069", Fax = "(812) 1499393", AddressLine1 = "14 Clove Crossing", City = "Erie", State = "Pennsylvania", ZipCode = "16550" },
                new Customer { Id = 6, Name = "Realcube", Phone = "(302) 7822379", Fax = "(239) 3817974", AddressLine1 = "47 Service Place", City = "Newark", State = "Delaware", ZipCode = "19714" },
                new Customer { Id = 7, Name = "Talane", Phone = "(804) 4400477", Fax = "(863) 7101039", AddressLine1 = "88440 Prentice Point", City = "Richmond", State = "Virginia", ZipCode = "23242" },
                new Customer { Id = 8, Name = "Kare", Phone = "(803) 9534843", Fax = "(806) 2304931", AddressLine1 = "7773 Colorado Pass", City = "Columbia", State = "South Carolina", ZipCode = "29203" },
                new Customer { Id = 9, Name = "Browsecat", Phone = "(503) 2497784", Fax = "(269) 3327528", AddressLine1 = "65 Oak Center", City = "Portland", State = "Oregon", ZipCode = "97216" },
                new Customer { Id = 10, Name = "Skaboo", Phone = "(563) 4194980", Fax = "(361) 1368237", AddressLine1 = "141 Autumn Leaf Plaza", City = "Davenport", State = "Iowa", ZipCode = "52809" },
                new Customer { Id = 11, Name = "Mydo", Phone = "(404) 5308764", Fax = "(717) 8453279", AddressLine1 = "8917 Mesta Avenue", City = "Atlanta", State = "Georgia", ZipCode = "30356" },
                new Customer { Id = 12, Name = "Lajo", Phone = "(864) 7499941", Fax = "(570) 8136653", AddressLine1 = "485 Tomscot Parkway", City = "Spartanburg", State = "South Carolina", ZipCode = "29319" },
                new Customer { Id = 13, Name = "Gabvine", Phone = "(612) 5701546", Fax = "(415) 3818680", AddressLine1 = "10 Sheridan Street", City = "Minneapolis", State = "Minnesota", ZipCode = "55441" },
                new Customer { Id = 14, Name = "Feednation", Phone = "(314) 1434740", Fax = "(205) 9260007", AddressLine1 = "68327 Cascade Terrace", City = "Saint Louis", State = "Missouri", ZipCode = "63116" },
                new Customer { Id = 15, Name = "Zoonder", Phone = "(510) 1643237", Fax = "(718) 4310775", AddressLine1 = "2 Hanson Plaza", City = "Hayward", State = "California", ZipCode = "94544" },
                new Customer { Id = 16, Name = "Photobean", Phone = "(781) 1605304", Fax = "(410) 4631546", AddressLine1 = "17512 Dunning Trail", City = "Newton", State = "Massachusetts", ZipCode = "02458" },
                new Customer { Id = 17, Name = "Zazio", Phone = "(508) 7188944", Fax = "(205) 2082693", AddressLine1 = "744 Grim Junction", City = "Worcester", State = "Massachusetts", ZipCode = "01610" },
                new Customer { Id = 18, Name = "Feedmix", Phone = "(214) 3432315", Fax = "(304) 6807975", AddressLine1 = "0235 Farragut Center", City = "Dallas", State = "Texas", ZipCode = "75277" },
                new Customer { Id = 19, Name = "Digitube", Phone = "(412) 6348069", Fax = "(304) 7335622", AddressLine1 = "9 Corben Plaza", City = "Pittsburgh", State = "Pennsylvania", ZipCode = "15210" },
                new Customer { Id = 20, Name = "Zava", Phone = "(501) 5514222", Fax = "(260) 7218199", AddressLine1 = "7065 Roth Pass", City = "Little Rock", State = "Arkansas", ZipCode = "72215" },
                new Customer { Id = 21, Name = "Meeveo", Phone = "(862) 6543764", Fax = "(202) 1951747", AddressLine1 = "262 Dovetail Place", City = "Paterson", State = "New Jersey", ZipCode = "07544" },
                new Customer { Id = 22, Name = "LiveZ", Phone = "(714) 7253452", Fax = "(808) 3834253", AddressLine1 = "84834 Eagan Hill", City = "Irvine", State = "California", ZipCode = "92717" },
                new Customer { Id = 23, Name = "Jaxspan", Phone = "(917) 9555270", Fax = "(916) 7052251", AddressLine1 = "3520 Summit Center", City = "Jamaica", State = "New York", ZipCode = "11436" },
                new Customer { Id = 24, Name = "Trunyx", Phone = "(574) 6877521", Fax = "(303) 1940833", AddressLine1 = "508 Packers Alley", City = "South Bend", State = "Indiana", ZipCode = "46634" },
                new Customer { Id = 25, Name = "Quatz", Phone = "(713) 7183613", Fax = "(770) 7320886", AddressLine1 = "7998 Bowman Park", City = "Houston", State = "Texas", ZipCode = "77212" },
                new Customer { Id = 26, Name = "Livefish", Phone = "(305) 8910904", Fax = "(917) 1847313", AddressLine1 = "37 Bartillon Pass", City = "Miami", State = "Florida", ZipCode = "33283" },
                new Customer { Id = 27, Name = "Voolia", Phone = "(408) 5340578", Fax = "(812) 8763090", AddressLine1 = "8511 Cardinal Lane", City = "San Jose", State = "California", ZipCode = "95150" },
                new Customer { Id = 28, Name = "Zava", Phone = "(516) 5533397", Fax = "(636) 6366758", AddressLine1 = "7919 Transport Circle", City = "Great Neck", State = "New York", ZipCode = "11024" },
                new Customer { Id = 29, Name = "Cogibox", Phone = "(480) 5023377", Fax = "(313) 7602058", AddressLine1 = "829 Victoria Circle", City = "Scottsdale", State = "Arizona", ZipCode = "85260" },
                new Customer { Id = 30, Name = "Yambee", Phone = "(614) 9499624", Fax = "(214) 5077468", AddressLine1 = "05 Grim Parkway", City = "Columbus", State = "Ohio", ZipCode = "43210" },
                new Customer { Id = 31, Name = "Jabbersphere", Phone = "(405) 5815210", Fax = "(425) 6898869", AddressLine1 = "652 Springs Court", City = "Oklahoma City", State = "Oklahoma", ZipCode = "73167" },
                new Customer { Id = 32, Name = "Flashset", Phone = "(865) 6793299", Fax = "(218) 4401578", AddressLine1 = "66669 Goodland Junction", City = "Knoxville", State = "Tennessee", ZipCode = "37939" },
                new Customer { Id = 33, Name = "Jabberbean", Phone = "(212) 6473306", Fax = "(269) 6444573", AddressLine1 = "28615 Haas Way", City = "New York City", State = "New York", ZipCode = "10079" },
                new Customer { Id = 34, Name = "Jetwire", Phone = "(954) 2745999", Fax = "(619) 6405742", AddressLine1 = "5602 Twin Pines Place", City = "Miami", State = "Florida", ZipCode = "33142" },
                new Customer { Id = 35, Name = "Trunyx", Phone = "(917) 9912587", Fax = "(334) 8205846", AddressLine1 = "20 Melody Junction", City = "New York City", State = "New York", ZipCode = "10105" },
                new Customer { Id = 36, Name = "Kazio", Phone = "(404) 6613659", Fax = "(706) 9561028", AddressLine1 = "634 Sachs Terrace", City = "Atlanta", State = "Georgia", ZipCode = "30356" },
                new Customer { Id = 37, Name = "Einti", Phone = "(501) 2208933", Fax = "(505) 7995233", AddressLine1 = "14340 Fordem Drive", City = "Little Rock", State = "Arkansas", ZipCode = "72209" },
                new Customer { Id = 38, Name = "Realfire", Phone = "(559) 6484922", Fax = "(518) 3037584", AddressLine1 = "141 5th Trail", City = "Fresno", State = "California", ZipCode = "93750" },
                new Customer { Id = 39, Name = "Chatterbridge", Phone = "(770) 1754005", Fax = "(214) 2854965", AddressLine1 = "08 Miller Trail", City = "Atlanta", State = "Georgia", ZipCode = "30328" },
                new Customer { Id = 40, Name = "Eidel", Phone = "(213) 7643949", Fax = "(304) 2092836", AddressLine1 = "1061 Dovetail Hill", City = "Los Angeles", State = "California", ZipCode = "90055" },
                new Customer { Id = 41, Name = "Riffpath", Phone = "(501) 1767066", Fax = "(801) 7894926", AddressLine1 = "16651 Crescent Oaks Avenue", City = "North Little Rock", State = "Arkansas", ZipCode = "72199" },
                new Customer { Id = 42, Name = "Skyble", Phone = "(585) 1407930", Fax = "(361) 4759811", AddressLine1 = "100 Crescent Oaks Hill", City = "Rochester", State = "New York", ZipCode = "14609" },
                new Customer { Id = 43, Name = "Oyoyo", Phone = "(831) 2065879", Fax = "(619) 9768100", AddressLine1 = "33 Forest Dale Park", City = "Santa Cruz", State = "California", ZipCode = "95064" },
                new Customer { Id = 44, Name = "Feedfish", Phone = "(717) 8217517", Fax = "(763) 9586783", AddressLine1 = "34061 Annamark Court", City = "Lancaster", State = "Pennsylvania", ZipCode = "17622" },
                new Customer { Id = 45, Name = "Janyx", Phone = ",(801) 9141006", Fax = "(903) 2630463", AddressLine1 = "269 Farwell Drive", City = "Salt Lake City", State = "Utah", ZipCode = "84120" },
                new Customer { Id = 46, Name = "Avamm", Phone = "(713) 6062841", Fax = "(626) 3264267", AddressLine1 = "34 1st Terrace", City = "Houston", State = "Texas", ZipCode = "77266" },
                new Customer { Id = 47, Name = "Gigazoom", Phone = "(714) 2375137", Fax = "(502) 4803481", AddressLine1 = "84553 Bonner Trail", City = "Santa Ana", State = "California", ZipCode = "92725" },
                new Customer { Id = 48, Name = "Abatz", Phone = "(814) 8645383", Fax = "(240) 2486299", AddressLine1 = "4182 Del Mar Court", City = "Johnstown", State = "Pennsylvania", ZipCode = "15906" },
                new Customer { Id = 49, Name = "Devbug", Phone = "(212) 6916699", Fax = "(203) 8350971", AddressLine1 = "08 Derek Way", City = "New York City", State = "New York", ZipCode = "10249" },
                new Customer { Id = 50, Name = "Jabbercube", Phone = "(915) 4290363", Fax = "(772) 7683873", AddressLine1 = "42 Susan Street", City = "El Paso", State = "Texas", ZipCode = "88563" },
                new Customer { Id = 51, Name = "Gabvine", Phone = "(915) 8001085", Fax = "(330) 7338951", AddressLine1 = "113 Farragut Trail", City = "El Paso", State = "Texas", ZipCode = "88574" },
                new Customer { Id = 52, Name = "Gigazoom", Phone = "(320) 7547928", Fax = "(770) 4313318", AddressLine1 = "28378 Gulseth Park", City = "Saint Cloud", State = "Minnesota", ZipCode = "56398" },
                new Customer { Id = 53, Name = "Centizu", Phone = "(407) 4369685", Fax = "(317) 4502574", AddressLine1 = "9 Waubesa Court", City = "Winter Haven", State = "Florida", ZipCode = "33884" },
                new Customer { Id = 54, Name = "Zava", Phone = "(713) 7347271", Fax = "(704) 6174572", AddressLine1 = "8645 Mendota Way", City = "Houston", State = "Texas", ZipCode = "77212" },
                new Customer { Id = 55, Name = "Bluezoom", Phone = "(417) 5001942", Fax = "(941) 4978863", AddressLine1 = "5695 Ridgeway Alley", City = "Springfield", State = "Missouri", ZipCode = "65810" },
                new Customer { Id = 56, Name = "Twimm", Phone = "(706) 6697388", Fax = "(205) 7077559", AddressLine1 = "106 Kings Pass", City = "Columbus", State = "Georgia", ZipCode = "31914" }              
            };
            return customers;
        }

        public static Supplier[] Suppliers()
        {
            var suppliers = new Supplier[]
            {
                new Supplier { Id = 1, Name = "Hebie Hurai Pharmaceuticals", AddressLine1 = "", City = "Xianho", State = "Xiangzho", ZipCode = "172818" },
                new Supplier { Id = 2, Name = "Hong Kong Chemicals", AddressLine1 = "", City = "Xianho", State = "Xiangzho", ZipCode = "172818" },
                new Supplier { Id = 3, Name = "North China Industries", AddressLine1 = "", City = "Xianho", State = "Xiangzho", ZipCode = "172818" },
                new Supplier { Id = 4, Name = "Neon Chemicals", AddressLine1 = "", City = "Xianho", State = "Xiangzho", ZipCode = "172818" },
                new Supplier { Id = 5, Name = "Mehran International", AddressLine1 = "", City = "Xianho", State = "Xiangzho", ZipCode = "172818" },
                new Supplier { Id = 6, Name = "Zenith Securities", AddressLine1 = "", City = "Xianho", State = "Xiangzho", ZipCode = "172818" },
                new Supplier { Id = 7, Name = "Mumbai Fashion Accessories", AddressLine1 = "", City = "Xianho", State = "Xiangzho", ZipCode = "172818" },
                new Supplier { Id = 8, Name = "Xainshu Chemicals Shanghai", AddressLine1 = "", City = "Xianho", State = "Xiangzho", ZipCode = "172818" },
                new Supplier { Id = 9, Name = "Foster Pharmaceuticals", AddressLine1 = "", City = "Xianho", State = "Xiangzho", ZipCode = "172818" },
                new Supplier { Id = 10, Name = "Gennie Industrial Pharmaceutical", AddressLine1 = "", City = "Xianho", State = "Xiangzho", ZipCode = "172818" }
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