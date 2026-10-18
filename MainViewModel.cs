using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Book_Manager_WPF
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Book> Books { get; set; }

        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        private Book _selectedBook;
        public Book SelectedBook
        {
            get { return _selectedBook; }
            set
            {
                _selectedBook = value;
                OnPropertyChanged();
                //проверка состоягния кнопок
                CommandManager.InvalidateRequerySuggested();
            }
        }

        public MainViewModel()
        {
            Books = new ObservableCollection<Book>();

            Books.Add(new Book { Title = "Мастер и Маргарита", Author = "М. Булгаков", Year = 1967 });

            AddCommand = new RelayCommand(OnAdd);
            EditCommand = new RelayCommand(OnEdit, CanEditOrDelete);
            DeleteCommand = new RelayCommand(OnDelete, CanEditOrDelete);
        }

        private bool CanEditOrDelete(object parameter)
        {
            return SelectedBook != null;
        }

        private void OnAdd(object parameter)
        {
            Book newBook = new Book();
            BookEditWindow window = new BookEditWindow(newBook);

            if (window.ShowDialog() == true)
            {
                Books.Add(newBook);
            }
        }

        private void OnEdit(object parameter)
        {
            BookEditWindow window = new BookEditWindow(SelectedBook);
            window.ShowDialog();
        }

        private void OnDelete(object parameter)
        {
            Books.Remove(SelectedBook);
            SelectedBook = null;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}