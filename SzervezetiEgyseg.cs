using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tanulok
{
    [Table("SzervezetiEgysegek")]
    public class SzervezetiEgyseg
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string SZeNev { get; set; }
    }
}
/* Create Table SzervezetiEgységek (
    Id int not null auto_increment primary key,
    Nev varchar(100) not null unique
    );
*/


/*Ez egy C# osztály, amely a Tanulok névtérben található. 
 * Az osztály az adatbázis egy táblájához (SzervezetiEgysegek) tartozó adatokat tárolja. 
 * Az osztály a System.ComponentModel.DataAnnotations és a System.ComponentModel.DataAnnotations.Schema 
 * névtérben található típusokat használja, 
 * amelyek az adatok érvényességének ellenőrzésére és az adatbázis séma leírására szolgálnak.
 * Az osztályban van egy Id nevű int típusú tulajdonság, amely az elsődleges kulcsként szolgál a táblában, 
 * valamint egy Nev nevű string típusú tulajdonság, amely a tábla Nev oszlopához tartozik, 
 * és egy adott szervezeti egység nevét tartalmazza.*/