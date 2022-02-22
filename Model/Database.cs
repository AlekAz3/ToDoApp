﻿using System;
using System.Text;
using System.Data.SQLite;
using System.Collections.Generic;

namespace Model
{
    public class Database
    {
        private static string way = $@"C:\Users\{Environment.UserName}\AppData\Local\ToDoApp";
        private SQLiteConnection _connection = new SQLiteConnection($@"Data Source={way}\todoapp.db;");

        public Database() => _connection.Open();
        
        public void CloseDB() => _connection.Close();
        
        public List<string> Category()
        {
            List<string> categories = new List<string>();

            string command = $"SELECT NAME FROM Category;";
            SQLiteCommand cmd = new SQLiteCommand(command, _connection);
            SQLiteDataReader sql = cmd.ExecuteReader();

            if (sql.HasRows)
            {
                while (sql.Read())
                {
                    categories.Add((string)sql["NAME"]);
                }
            }

            return categories;
        }

        public List<bool> Complete_Category()
        {
            List<bool> complete = new List<bool>();
            string command = $"SELECT COMPLETE FROM Category;";
            SQLiteCommand cmd = new SQLiteCommand(command, _connection);
            SQLiteDataReader sql = cmd.ExecuteReader();

            if (sql.HasRows)
            {
                while (sql.Read())
                {
                    complete.Add((bool)sql["COMPLETE"]);
                }
            }

            return complete;
        }

        public List<string> Note_Name(int id_category)
        {
            List<string> Note_Name =  new List<string>();

            string command =  $@"SELECT ""NAME "" FROM NOTES WHERE ID_CATEGORY == {id_category};";
            
            SQLiteCommand cmd = new SQLiteCommand(command, _connection);
            SQLiteDataReader sql = cmd.ExecuteReader();

            if (sql.HasRows)
            {
                while (sql.Read())
                {
                    Note_Name.Add((string)sql["NAME "]);
                }
            }

            return Note_Name;
        }

        public List<bool> Note_Complete(int id_category)
        {
            List<bool > complete = new List<bool>();

            string command = $@"SELECT ""COMPLETE "" FROM NOTES WHERE ID_CATEGORY == {id_category};";
            SQLiteCommand cmd = new SQLiteCommand(command, _connection);
            SQLiteDataReader sql = cmd.ExecuteReader();

            if (sql.HasRows)
            {
                while (sql.Read())
                {
                    complete.Add((bool)sql["COMPLETE "]);
                }
            }

            return complete;
        }

    }
}