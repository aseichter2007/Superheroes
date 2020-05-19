using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Superheroes.Models
{
    public class SuperHero
    {
        [Key]
        int Id { get; set; }
        string name { get; set; }
        string alterEgo { get; set; }
        string primaryAbility { get; set; }
        string secondaryAbility { get; set; }
        string catchPrase { get; set; }
        string weakness { get; set; }
        bool favorite { get; set; }
    }
}
