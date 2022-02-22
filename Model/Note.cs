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
        public bool Complete { get; set; }
        public string Created { get; set; }

        public Note(int Id_Note, string Name, int Id_category, bool complete)
        {
            this.Id_note = Id_Note;
            this.Name = Name;
            this.Complete = complete;
            this.Id_Category = Id_category;
        }

        public Note(int Id_Note, string Name, bool complete)
        {
            this.Id_note = Id_Note;
            this.Name = Name;
            this.Complete = complete;
        }

        public Note( string Name, int Id_category, bool complete)
        {

            this.Name = Name;
            this.Complete = complete;
            this.Id_Category = Id_category;
        }


    }

}
