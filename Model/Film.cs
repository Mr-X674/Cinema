using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Model
{
    internal class Film
    {
        [Key]
        public int id { get; set; }

        [Required]
        public int? Genreid { get; set; }

        [ForeignKey("Genreid")]
        public Genre Genre { get; set; }

        [Required]
        public int? hallid { get; set; }

        [ForeignKey("hallid")]
        public hall hall { get; set; }

        [Required]
        public int? sessionid { get; set; }

        [ForeignKey("sessionid")]
        public session session { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public DateTime Years { get; set; }
        [NotMapped]
        public Genre genre
        {
            get
            {
                return DataWorker.GetStudentById((int)StudentId);
            }
        }
        [NotMapped]
        public Ticket Ticket
        {
            get
            {
                return DataWorker.GetDisciplineById((int)DisciplineId);
            }
        }
    }
}
