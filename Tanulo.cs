using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tanulok;

namespace Tanulok
{
    [Table("Tanulok")]
    public class Tanulo
    {
        [Key]
        public int Id { get; set; }

        [StringLength(6)]
        [Required]
        public string NEPTUNKod { get; set; }

        [StringLength(150)]
        [Required]
        public string Nev { get; set; }

        [Required]
        public SzervezetiEgyseg SzervezetiEgyseg { get; set; }

        [StringLength(100)]
        public string AktualFelev { get; set; }

        [Required]
        public Tagozat Tagozat { get; set; }

        public DateTime? FelvetelDatuma { get; set; }
    }
}
/* Ez egy C# osztály, amely a "Tanulok" nevű adattáblát reprezentálja. 
 * Az osztály az Entity Framework Code First funkcióit használja. Az osztály tartalmazza a tábla oszlopait, amelyeket az adattáblában tárolt adatokhoz kapcsolódóan definiáltak. A tábla oszlopai a következők:

Id: Az oszlop azonosítója, ami az adatbázis elsődleges kulcsaként szerepel.
NEPTUNKod: A diák egyedi NEPTUN kódja.
Nev: A diák neve.
SzervezetiEgyseg: A diákhoz tartozó szervezeti egység, amelyhez az osztály a SzervezetiEgyseg osztályt használja.
AktualFelev: Az aktuális félév, amelybe a diák be van iratkozva.
Tagozat: A diákhoz tartozó tagozat, amelyhez az osztály a Tagozat osztályt használja.
FelvetelDatuma: A diák felvételének dátuma. A dátum lehet null értékű, ha a diákot még nem vették fel az iskolába.*/
