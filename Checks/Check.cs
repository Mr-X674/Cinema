using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using Cinema;

namespace Cinema.Checks
{
    public class Check
    {
        DataBase dataBase = new DataBase();
        public Boolean User(string login, string password)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string queryString = $"SELECT * FROM Register WHERE LOGIN = '{login}' AND PASSWORD = '{password}'";

            SqlCommand command = new SqlCommand(queryString, dataBase.GetConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Аккаунт уже существует:", "Аккаунт существует", MessageBoxButton.OK, MessageBoxImage.Information);
                return true;
            }
            else
            {
                return false;
            }
        }
        public Boolean Discipline(string name)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string queryString = $"SELECT * FROM Disciplines WHERE DisciplineName = '{name}'";

            SqlCommand command = new SqlCommand(queryString, dataBase.GetConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Дисциплина уже существует:", "Дисциплина существует", MessageBoxButton.OK, MessageBoxImage.Information);
                return true;
            }
            else
            {
                return false;
            }
        }
        public Boolean Group(string name)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string queryString = $"SELECT * FROM Groups WHERE GroupName = '{name}'";

            SqlCommand command = new SqlCommand(queryString, dataBase.GetConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Группа уже существует:", "Группа существует", MessageBoxButton.OK, MessageBoxImage.Information);
                return true;
            }
            else
            {
                return false;
            }
        }
        public Boolean Student(string firstName, string lastName, string middleName)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string queryString = $"SELECT * FROM Students WHERE StudentFirstName = '{firstName}' AND StudentLastName = '{lastName}' AND StudentMiddleName = '{middleName}'";

            SqlCommand command = new SqlCommand(queryString, dataBase.GetConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Студент уже существует:", "Студент существует", MessageBoxButton.OK, MessageBoxImage.Information);
                return true;
            }
            else
            {
                return false;
            }
        }
        public string SearchElementID(string SearchRow)
        {
            string SearchElementId = null;
            for (int i = 0; i < SearchRow.Length; i++)
            {
                if (SearchRow[i] == ':')
                {
                    break;
                }
                else
                {
                    SearchElementId += SearchRow[i];
                }
            }
            return SearchElementId;
        }

        public string WhatAction(int ActionId)
        {
            string ActionName="НЕсработало";
            switch (ActionId)
            {
                case 0:
                    ActionName="Добавление";
                    break;
                case 1:
                    ActionName = "Редактирование";
                    break;
                case 2:
                    ActionName = "Удаление";
                    break;
            }
            return ActionName;
        }
    }
}
