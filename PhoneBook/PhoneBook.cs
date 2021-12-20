namespace PhoneBook
{
    public class PhoneBook
    {
        // Для EF
        public PhoneBook()
        {
        }

        // Для добавления новой записи пользователем
        public PhoneBook(string lastName, string firstName, string middleName, string numberPhone, string address, string desc)
        {
            LastName = lastName;
            FirstName = firstName;
            MiddleName = middleName;
            NumberPhone = numberPhone;
            Address = address;
            Desc = desc;
        }

        // Для инициализации БД начальными данными
        public PhoneBook(int id, string lastName, string firstName, string middleName, string numberPhone, string address, string desc)
        {
            Id = id;
            LastName = lastName;
            FirstName = firstName;
            MiddleName = middleName;
            NumberPhone = numberPhone;
            Address = address;
            Desc = desc;
        }

        /// <summary>
        /// Id записи
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Отчество
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// Номер телефона
        /// </summary>
        public string NumberPhone { get; set; }

        /// <summary>
        /// Адрес
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        public string Desc { get; set; }
    }
}
