using System;
using System.IO;
using System.Data.SQLite;

namespace Model
{
    public class Firststart
    {
        private readonly string way = $@"C:\Users\{Environment.UserName}\AppData\Local\ToDoApp";
        private readonly string commandText1 = "CREATE TABLE \"Category\" ( \"ID_CATEGORY\"	INTEGER, \"NAME_CATEGORY\"	VARCHAR(255), \"COMPLETE\"	BOOLEAN, PRIMARY KEY(\"ID_CATEGORY\" AUTOINCREMENT) );";
        private readonly string commandText2 = "CREATE TABLE \"NOTES\" ( \"ID_NOTE\"	INTEGER, \"ID_CATEGORY\"	INTEGER, \"NAME \"	VARCHAR(255), \"DATE\"	DATETIME, \"COMPLETE_NOTE\"	BOOLEAN, FOREIGN KEY(\"ID_CATEGORY\") REFERENCES \"Category\"(\"ID_CATEGORY\"), PRIMARY KEY(\"ID_NOTE\" AUTOINCREMENT) );";

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