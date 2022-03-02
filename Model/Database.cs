using System;
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
  
        public List<Note> NoteFromDB()
        {
            List<Note> notes = new List<Note>();

            string command = $@"SELECT * FROM NOTES;";

            SQLiteCommand cmd = new SQLiteCommand(command, _connection);
            SQLiteDataReader sql = cmd.ExecuteReader();

            if (sql.HasRows)
            {
                while (sql.Read())
                {
                    notes.Add(
                        new Note(
                            Convert.ToInt32(sql["ID_NOTE"]),
                            sql["NAME "].ToString(),
                            Convert.ToInt32(sql["ID_CATEGORY"]),
                            Convert.ToBoolean(sql["COMPLETE "])));
                }
            }
            return notes;
        }

        public List<Category> CategoryFromDB()
        {
            List<Category> categories = new List<Category>();

            string command = $@"SELECT * FROM Category;";

            SQLiteCommand cmd = new SQLiteCommand(command, _connection);
            SQLiteDataReader sql = cmd.ExecuteReader();

            if (sql.HasRows)
            {
                while (sql.Read())
                {
                    if (!Convert.ToBoolean(sql["COMPLETE"]))
                    {
                        categories.Add(new Category(
                            Convert.ToInt32(sql["ID_CATEGORY"]),
                            sql["NAME"].ToString()));
                    }
                }
            }
            return categories;
        }

        public void SaveStateCheckBoxToDB(Note note)
        {
            string commandText = $"UPDATE NOTES SET \"COMPLETE \" = {note.Complete} WHERE ID_NOTE == {note.Id_note}";

            using (SQLiteCommand cmdCreate = new SQLiteCommand(commandText, _connection))
                cmdCreate.ExecuteNonQuery();

        }

        public void AddCategotyToDB(Category category)
        {
            string commandText = $"INSERT INTO Category (NAME, COMPLETE) VALUES(\"{category.Name}\", FALSE)";

            using (SQLiteCommand cmdCreate = new SQLiteCommand(commandText, _connection))
                cmdCreate.ExecuteNonQuery();
        }
    }
}