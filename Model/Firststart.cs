using System;
using System.IO;
using System.Data.SQLite;

namespace Model
{
    public class Firststart
    {
        private readonly string way = $@"C:\Users\{Environment.UserName}\AppData\Local\ToDoApp";
        private readonly string commandText1 = "CREATE TABLE Category (ID_CATEGORY INTEGER PRIMARY KEY AUTOINCREMENT, NAME VARCHAR (255), COMPLETE BOOLEAN)";
        private readonly string commandText2 = "CREATE TABLE NOTES (ID_NOTE INTEGER PRIMARY KEY AUTOINCREMENT, ID_CATEGORY INTEGER REFERENCES Category (ID_CATEGORY), \"NAME \" VARCHAR (255), DATE DATETIME, \"COMPLETE \" BOOLEAN)";

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