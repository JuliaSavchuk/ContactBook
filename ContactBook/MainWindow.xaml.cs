using ContactBook.CB;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ContactBook;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private ContactContext _context;
    public MainWindow()
    {
        InitializeComponent();
        _context = new ContactContext();
    }

    // Завантаження всіх контактів
    private void ViewAllContacts()
    {
        var contacts = _context.Contacts.ToList();
        LabelViewAllContacts.Content = string.Join("\n", contacts.Select(c => $"{c.Name}\n{c.PhoneNumber}\n{c.Email}\n{c.Address}\n{c.Description}\n"));
    }

    private void DeleteContact_Click(object sender, RoutedEventArgs e)
    {
        var contact = _context.Contacts.FirstOrDefault(c => c.PhoneNumber == PhoneTextBox.Text);
        if (contact != null)
        {
            _context.Contacts.Remove(contact);
            _context.SaveChanges();

            // Оновлюємо відображення всіх контактів
            ViewAllContacts();
        }
        else
        {
            MessageBox.Show("Контакт не знайдений.");
        }
    }

    private void UpdateContact_Click(object sender, RoutedEventArgs e)
    {
        var contact = _context.Contacts.FirstOrDefault(c => c.PhoneNumber == PhoneTextBox.Text);
        if (contact != null)
        {
            contact.Name = NameTextBox.Text;
            contact.Email = EmailTextBox.Text;
            contact.Address = AddressTextBox.Text;
            contact.Description = DescriptionTextBox.Text;

            _context.SaveChanges();

            // Оновлюємо відображення всіх контактів
            ViewAllContacts();
        }
        else
        {
            MessageBox.Show("Контакт не знайдений.");
        }
    }


    private void SearchContact_Click(object sender, RoutedEventArgs e)
    {
        var query = _context.Contacts.AsQueryable();

        if (!string.IsNullOrEmpty(NameTextBox.Text))
            query = query.Where(c => c.Name.Contains(NameTextBox.Text));
        if (!string.IsNullOrEmpty(PhoneTextBox.Text))
            query = query.Where(c => c.PhoneNumber.Contains(PhoneTextBox.Text));
        if (!string.IsNullOrEmpty(EmailTextBox.Text))
            query = query.Where(c => c.Email.Contains(EmailTextBox.Text));
        if (!string.IsNullOrEmpty(AddressTextBox.Text))
            query = query.Where(c => c.Address.Contains(AddressTextBox.Text));
        if (!string.IsNullOrEmpty(DescriptionTextBox.Text))
            query = query.Where(c => c.Description.Contains(DescriptionTextBox.Text));

        var contacts = query.ToList();

        // Вивести знайдений контакт у LabelViewContacts
        LabelViewContacts.Content = string.Join("\n", contacts.Select(c => $"{c.Name}\n{c.PhoneNumber}\n{c.Email}\n{c.Address}\n{c.Description}\n"));
    }

    private void AddContact_Click(object sender, RoutedEventArgs e)
    {
        var contact = new Contact
        {
            Name = NameTextBox.Text,
            PhoneNumber = PhoneTextBox.Text,
            Email = EmailTextBox.Text,
            Address = AddressTextBox.Text,
            Description = DescriptionTextBox.Text
        };

        _context.Contacts.Add(contact);
        _context.SaveChanges();

        // Оновлюємо відображення всіх контактів
        ViewAllContacts();
    }
}