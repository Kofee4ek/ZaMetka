using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZaMetka.Model;

namespace ZaMetka.Views
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public partial class NoteAddingPage : ContentPage
    {
        public NoteAddingPage()
        {
            InitializeComponent();
            BindingContext = new Model.Note();
        }

        private async void LoadNote(string value)
        {
            try
            {
                int id = Convert.ToInt32(value);
                Note note = await App.NotesDB.GetNoteAsync(id);
                BindingContext = note;
            }
            catch { }

        }

        public string ItemId
        {
            set {
                LoadNote(value);
            }

        }

        private async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            Note note = (Note)BindingContext;
            note.Date = DateTime.UtcNow;
            if (!string.IsNullOrWhiteSpace(note.Text))
            {
                await App.NotesDB.SaveNoteAsync(note);
            }
            await Shell.Current.GoToAsync("..");
        }

        private async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            Note note = (Note)BindingContext;
            await App.NotesDB.DeleteNoteAsync(note);
            await Shell.Current.GoToAsync("..");    
        }
    }
}