using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tanulok
{
    [Table("Tagozatok")]
    public class Tagozat
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string TagozatNev { get; set; }
    }
}

/*Ez egy C# osztály, amely a `Tanulok` névtérben található. 
 * Az osztály az adatbázis egy táblájához (`Tagozatok`) tartozó adatokat tárolja. 
 * Az osztály a `System.ComponentModel.DataAnnotations` és a `System.ComponentModel.DataAnnotations.Schema` 
 * névtérben található típusokat használja, amelyek az adatok érvényességének ellenőrzésére és az adatbázis séma leírására szolgálnak. 
 * Az osztályban van egy `Id` nevű `int` típusú tulajdonság, amely az elsődleges kulcsként szolgál a táblában, 
 * valamint egy `Nev` nevű `string` típusú tulajdonság, amely a tábla `Nev` oszlopához tartozik, és egy adott tagozat nevét tartalmazza.*/