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

            string command = $@"SELECT * FROM NOTES, Category WHERE NOTES.ID_CATEGORY == Category.ID_CATEGORY";

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
                            (sql["NAME_CATEGORY"].ToString()),
                            Convert.ToInt32(sql["ID_CATEGORY"]),
                            Convert.ToBoolean(sql["COMPLETE "]))) ;
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
                            sql["NAME_CATEGORY"].ToString()));
                    }
                }
            }
            return categories;
        }

        public List<Category> ArchiveCategoryFromDB()
        {
            List<Category> Acategories = new List<Category>();

            string command = $@"SELECT * FROM Category;";

            SQLiteCommand cmd = new SQLiteCommand(command, _connection);
            SQLiteDataReader sql = cmd.ExecuteReader();

            if (sql.HasRows)
            {
                while (sql.Read())
                {
                    if (Convert.ToBoolean(sql["COMPLETE"]))
                    {
                        Acategories.Add(new Category(
                            Convert.ToInt32(sql["ID_CATEGORY"]),
                            sql["NAME_CATEGORY"].ToString()));
                    }
                }
            }
            return Acategories;
        }

        public void SaveStateCheckBoxToDB(Note note)
        {
            if (_connection.State == System.Data.ConnectionState.Open)
            {
                string commandText = $"UPDATE NOTES SET \"COMPLETE \" = {note.Complete} WHERE ID_NOTE == {note.Id_note}";

                using (SQLiteCommand cmdCreate = new SQLiteCommand(commandText, _connection))
                    cmdCreate.ExecuteNonQuery();
            }
        }

        public void AddCategotyToDB(Category category)
        {
            string commandText = $"INSERT INTO Category (NAME_CATEGORY, COMPLETE) VALUES(\"{category.Name}\", FALSE)";

            using (SQLiteCommand cmdCreate = new SQLiteCommand(commandText, _connection))
                cmdCreate.ExecuteNonQuery();
        }

        public void AddNoteToDB(Note note)
        {
            string commandText = $"INSERT INTO Notes (ID_CATEGORY, \"NAME \", \"DATE\" , \"COMPLETE \") VALUES(\"{note.Id_Category}\", \"{note.Name}\", \"{DateTime.Now}\", false)";

            using (SQLiteCommand cmdCreate = new SQLiteCommand(commandText, _connection))
                cmdCreate.ExecuteNonQuery();
        }

        public void DellCategory(string name)
        {
            string commandText2 = $"DELETE FROM Category WHERE NAME_CATEGORY = \"{name}\"";

            using (SQLiteCommand cmdCreate = new SQLiteCommand(commandText2, _connection))
                cmdCreate.ExecuteNonQuery();
        }

        public int GetIDCategoryFromName(string Name)
        {
            int id = 0;
            string command = $"SELECT ID_CATEGORY FROM Category WHERE NAME_CATEGORY == \"{Name}\"";

            SQLiteCommand cmd = new SQLiteCommand(command, _connection);
            SQLiteDataReader sql = cmd.ExecuteReader();

            if (sql.HasRows)
            {
                while(sql.Read())
                {
                    id = Convert.ToInt32(sql["ID_CATEGORY"]);
                }
            }
            return id;
            
        }

        public void ArchiveCategory(string name)
        {
            string commandText = $"UPDATE Category SET COMPLETE = TRUE WHERE NAME_CATEGORY == \"{name}\"";
            
            using (SQLiteCommand cmdCreate = new SQLiteCommand(commandText, _connection))
                cmdCreate.ExecuteNonQuery();
        }

        public bool CheckCategoryName(string Name)
        {
            
            string command = $"SELECT NAME_CATEGORY FROM Category WHERE NAME_CATEGORY == \"{Name}\"";

            SQLiteCommand cmd = new SQLiteCommand(command, _connection);
            SQLiteDataReader sql = cmd.ExecuteReader();

            if (sql.HasRows)
                return false;
            else
                return true;
        }

    }
}