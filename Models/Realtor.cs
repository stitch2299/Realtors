using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Realtors.Models
{
    [Serializable]
    [Table("realtors")]
    public class Realtor
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("guid")]
        public Guid Guid { get; set; }

        [Column("lastName")]
        public string LastName { get; set; }

        [Column("firstName")]
        public string FirstName { get; set; }

        [Column("subDivision")]
        public int SubDivision { get; set; }

        [Column("registrationDate")]
        public DateTime RegistrationDate { get; set; }
    }
}
