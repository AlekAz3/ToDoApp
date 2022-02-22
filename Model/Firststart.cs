using System;
using System.IO;
using System.Data.SQLite;

namespace Model
{
    public class Firststart
    {
        private readonly string way = $@"C:\Users\{Environment.UserName}\AppData\Local\ToDoApp";
        private readonly string commandText1 = "CREATE TABLE category ( id_category INTEGER PRIMARY KEY AUTOINCREMENT, name VARCHAR (255), do_note BOOLEAN );";
        private readonly string commandText2 = "CREATE TABLE Notes ( id_note INTEGER PRIMARY KEY AUTOINCREMENT, id_category INTEGER REFERENCES category (id_category), date_note DATETIME, check_note BOOLEAN );";

        public Firststart()
        {
            if(!Directory.Exists(way)) Directory.CreateDirectory(way);

            SQLiteConnection db = new SQLiteConnection($@"Data Source={way}\todoapp.db;");
            db.Open();
            
            using(SQLiteCommand cmd = new SQLiteCommand("PRAGMA foreign_keys = 1", db))
                cmd.ExecuteNonQuery();

            using(SQLiteCommand cmdCreate = new SQLiteCommand(commandText1, db))
                cmdCreate.ExecuteNonQuery();

            using (SQLiteCommand cmdCreate = new SQLiteCommand(commandText2, db))
                cmdCreate.ExecuteNonQuery();
            
            db.Close();
        }
    }
}