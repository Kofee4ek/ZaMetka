﻿using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZaMetka.Data;

namespace ZaMetka
{
    public partial class App : Application
    {
        static NotesDB notesDB;
        public static NotesDB NotesDB
        {
            get
            {
                if (notesDB == null)
                {
                    notesDB = new NotesDB(
                        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                        "NotesDataBase.db3"));
                }
                return notesDB;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
