using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Book_Manager_WPF
{
    public class Book : INotifyPropertyChanged
    {
        private string title;
        private string author;
        private int year;

        public string Title
        {
            get { return title; }
            set { title = value; OnPropertyChanged(); }
        }

        public string Author
        {
            get { return author; }
            set { author = value; OnPropertyChanged(); }
        }

        public int Year
        {
            get { return year; }
            set { year = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}