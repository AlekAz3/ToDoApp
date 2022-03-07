using System;
using System.Text;
using System.Collections.Generic;

namespace Model
{
    public class Note
    {
        public int Id_note { get; set; }
        public string Name { get; set; }
        public int Id_Category { get; set; }  
        public string Name_Category { get; set; }
        public bool Complete { get; set; }
        public string Created { get; set; }

        public Note(int Id_Note, string Name, string Name_Category,int Id_Category, bool complete)
        {
            this.Id_note = Id_Note;
            this.Name = Name;
            this.Complete = complete;
            this.Name_Category = Name_Category;
            this.Id_Category = Id_Category;
        }
    }
}
