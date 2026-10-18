using System.Windows;

namespace Book_Manager_WPF
{
    public partial class BookEditWindow : Window
    {
        // В конструкторе принимаем Book и отдаем в DataContext (по ТЗ)
        public BookEditWindow(Book book)
        {
            InitializeComponent();
            DataContext = book;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            // Закрываем окно и возвращаем true (по ТЗ)
            this.DialogResult = true;
        }
    }
}