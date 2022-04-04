using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_StudentsAchievement_Project.Resources.Profiles
{
    class DataBaseField
        
    {
        private string _film;
        private DateTime _date;
        private string _hall;
        private string _number_rows;
        private string _number_place;
        

        public string Film { get => _film; set => _film = value; }
        public DateTime Date { get => _date; set => _date = value; }
        public string Hall { get => _hall; set => _hall = value; }
        public string Number_rows { get => _number_rows; set => _number_rows = value; }
        public string Number_place { get => _number_place; set => _number_place = value; }
    }
}