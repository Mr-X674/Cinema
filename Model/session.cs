using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Model
{
    internal class session
    {
        [Key]
        public int id { get; set; }

        [Required]
        public int? filmid { get; set; }

        [ForeignKey("filmid")]
        public Film film { get; set; }

        [Required]
        public int? hallid { get; set; }

        [ForeignKey("hallid")]
        public hall hall { get; set; }

        [Required]
        public int? price { get; set; }

        [Required]
        public DateTime Date { get; set; }


    }
}
