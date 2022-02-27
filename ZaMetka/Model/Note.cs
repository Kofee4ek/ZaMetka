using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace ZaMetka.Model
{
    public class Note
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string NoteText { get; set; }
        public DateTime Date { get; set; }
    }
}
