using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBook.CB
{
    public class Contact
    {
        public int Id { get; set; }  // Ідентифікатор контакту (первинний ключ)
        public string Name { get; set; }  // Ім’я контакту
        public string PhoneNumber { get; set; }  // Номер телефону
        public string Email { get; set; }  // Email
        public string Address { get; set; }  // Адреса
        public string Description { get; set; }  // Коротка характеристика
    }
}
