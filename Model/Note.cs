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
        public bool Do_Note { get; set; }
        public DateTime Created { get; set; }

        public Note()
        {
            
        }

    }
}
