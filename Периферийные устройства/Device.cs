using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Периферийные_устройства
{
    class Device : Supplement
    {
        private List<Peripherals> peripherals = new List<Peripherals>();
        public void AddPeripheral()
        {
            do
            {
                Console.Write("Введите название устройства: ");
                string name = Console.ReadLine();
                Console.Write("Введите тип устройства: ");
                string type = Console.ReadLine();
                Console.Write("Введите страну производства: ");
                string country = Console.ReadLine();
                Console.Write("Введите год производства: ");
                int year = Convert.ToInt32(Console.ReadLine());
                // Создаем новый объект периферийного устройства на основе введенных данных
                Peripherals newPeripheral = new Supplement(name, type, country, year);
                peripherals.Add(newPeripheral);
                Console.WriteLine("Периферийное устройство успешно добавлено в список.");
                Console.WriteLine("\nХотите добавить еще устройство? (да/нет)");
            } while (Console.ReadLine().ToLower() == "да");

            Console.WriteLine("\nНажмите Enter для выхода в главное меню...");
            Console.ReadLine(); 
            Console.Clear();
        }
        public void DisplayAllDevices()
        {
            foreach (var device in peripherals)
            {
                device.Show();
            }
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1. Добавить устройство в начало списка");
            Console.WriteLine("2. Добавить устройство в конец списка");
            Console.WriteLine("3. Добавить устройство после определенного устройства");
            Console.WriteLine("4. Добавить устройство перед определенным устройством");
            Console.WriteLine("5. Удалить устройство из списка");
            Console.WriteLine("6. Показать устройства определенного типа");
            Console.WriteLine("7. Показать устройства отсортированные по годам производства");
            Console.WriteLine("8. Вернуться в главное меню");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Clear();
                    AddDeviceToBeginning();
                    break;
                case 2:
                    Console.Clear();
                    AddDeviceToEnd();
                    break;
                case 3:
                    Console.Clear();
                    AddDeviceAfter();
                    break;
                case 4:
                    Console.Clear();
                    AddDeviceBefore();
                    break;
                case 5:
                    Console.Clear();
                    RemoveDevice();
                    break;
                case 6:
                    Console.Clear();
                    ShowDevicesByType();
                    break;
                case 7:
                    Console.Clear();
                    DisplayDevicesSortedByYear();
                    break;
                case 8:
                    Console.Clear();
                    Console.Clear();
                    break;
                default:
                    Console.WriteLine("Некорректный выбор.");
                    break;
            }
        }
        public void AddDeviceToBeginning()
        {
            Console.WriteLine("Введите данные для нового устройства:");
            Console.Write("Введите название устройства: ");
            string name = Console.ReadLine();
            Console.Write("Введите тип устройства: ");
            string type = Console.ReadLine();
            Console.Write("Введите страну производства: ");
            string country = Console.ReadLine();
            Console.Write("Введите год производства: ");
            int year = Convert.ToInt32(Console.ReadLine());
            Peripherals newPeripheral = new Supplement(name, type, country, year);
            peripherals.Add(newPeripheral);
            Console.WriteLine("Устройство успешно добавлено в начало списка.");
            Console.ReadLine();
            Console.Clear();
            DisplayAllDevices();
        }
        public void AddDeviceToEnd()
        {
            Console.WriteLine("Введите данные для нового устройства:");
            Console.Write("Введите название устройства: ");
            string name = Console.ReadLine();
            Console.Write("Введите тип устройства: ");
            string type = Console.ReadLine();
            Console.Write("Введите страну производства: ");
            string country = Console.ReadLine();
            Console.Write("Введите год производства: ");
            int year = Convert.ToInt32(Console.ReadLine());
            Peripherals newPeripheral = new Supplement(name, type, country, year);
            peripherals.Add(newPeripheral);
            Console.WriteLine("Устройство успешно добавлено в конец списка.");
            Console.ReadLine();
            Console.Clear();
            DisplayAllDevices();
        }
        public void AddDeviceAfter()
        {
            Console.Write("Введите название устройства, после которого нужно добавить новое устройство: ");
            string deviceTypeToInsertAfter = Console.ReadLine();
            Console.WriteLine("Введите данные для нового устройства:");
            Console.Write("Введите название устройства: ");
            string name = Console.ReadLine();
            Console.Write("Введите тип устройства: ");
            string type = Console.ReadLine();
            Console.Write("Введите страну производства: ");
            string country = Console.ReadLine();
            Console.Write("Введите год производства: ");
            int year = Convert.ToInt32(Console.ReadLine());
            Peripherals newPeripheral = new Supplement(name, type, country, year);
            peripherals.Add(newPeripheral);
            int index = peripherals.FindIndex(device => device.Type == deviceTypeToInsertAfter);
            if (index != -1)
            {
                peripherals.Insert(index + 1, newPeripheral);
                Console.WriteLine($"Устройство успешно добавлено после устройства с названием '{deviceTypeToInsertAfter}'.");
            }
            else
            {
                Console.WriteLine($"Устройство с названием '{deviceTypeToInsertAfter}' не найдено в списке.");
            }
            Console.ReadLine();
            Console.Clear();
            DisplayAllDevices();
        }
        public void AddDeviceBefore()
        {
            Console.Write("Введите название устройства, перед которым нужно добавить новое устройство: ");
            string deviceTypeToInsertBefore = Console.ReadLine();
            Console.WriteLine("Введите данные для нового устройства:");
            Console.Write("Введите название устройства: ");
            string name = Console.ReadLine();
            Console.Write("Введите тип устройства: ");
            string type = Console.ReadLine();
            Console.Write("Введите страну производства: ");
            string country = Console.ReadLine();
            Console.Write("Введите год производства: ");
            int year = Convert.ToInt32(Console.ReadLine());
            Peripherals newPeripheral = new Supplement(name, type, country, year);
            peripherals.Add(newPeripheral);
            int index = peripherals.FindIndex(device => device.Type == deviceTypeToInsertBefore);
            if (index != -1)
            {
                peripherals.Insert(index, newPeripheral);
                Console.WriteLine($"Устройство успешно добавлено перед устройством с названием '{deviceTypeToInsertBefore}'.");
            }
            else
            {
                Console.WriteLine($"Устройство с названием '{deviceTypeToInsertBefore}' не найдено в списке.");
            }
            Console.ReadLine();
            Console.Clear();
            DisplayAllDevices();
        }
        public void RemoveDevice()
        {
            Console.Write("Введите название устройства, которое нужно удалить: ");
            string deviceNameToRemove = Console.ReadLine();
            int removedCount = peripherals.RemoveAll(device => device.Type == deviceNameToRemove);
            if (removedCount > 0)
            {
                Console.WriteLine($"Устройство с названием '{deviceNameToRemove}' успешно удалено из списка.");
            }
            else
            {
                Console.WriteLine($"Устройство с названием '{deviceNameToRemove}' не найдено в списке.");
            }
            Console.ReadLine();
            Console.Clear();
            DisplayAllDevices();
        }
        public void ShowDevicesByType()
        {
            Console.Write("Введите тип устройства для вывода: ");
            string deviceType = Console.ReadLine();
            List<Peripherals> devicesOfType = peripherals.Where(device => device.Type.Equals(deviceType, StringComparison.OrdinalIgnoreCase)).ToList();
            if (devicesOfType.Count > 0)
            {
                Console.WriteLine($"Устройства типа '{deviceType}':");
                foreach (var device in devicesOfType)
                {
                    device.Show();
                }
            }
            else
            {
                Console.WriteLine($"Устройства типа '{deviceType}' не найдены.");
            }
            Console.ReadLine();
            Console.Clear();
            DisplayAllDevices();

        }
        public void DisplayDevicesSortedByYear()
        {
            if (peripherals.Count > 0)
            {
                var sortedDevices = peripherals.OrderBy(device => device.Year);

                Console.WriteLine("Устройства, отсортированные по годам производства:");
                foreach (var device in sortedDevices)
                {
                    device.Show();
                }
            }
            else
            {
                Console.WriteLine("Список устройств пуст.");
            }
            Console.ReadLine();
            Console.Clear();
            DisplayAllDevices();
           
        }
        public void SaveMonitorsToFile()
        {
            string file = @"D:\Куровая_\Периферийные устройства\monitor.txt";
            try
            {
                List<Peripherals> monitors = peripherals.Where(device => device.Type.Equals("Монитор", StringComparison.OrdinalIgnoreCase)).ToList();
                if (monitors.Count > 0)
                {
                    Console.WriteLine("Список мониторов:");
                    foreach (var monitor in monitors)
                    {
                        Console.WriteLine($"Название: {monitor.Name}, Тип: {monitor.Type}, Страна производства: {monitor.Country}, Год производства: {monitor.Year}");
                    }
                }
                else
                {
                    Console.WriteLine("Мониторы не найдены.");
                }
                using (StreamWriter writer = new StreamWriter(file))
                {
                    foreach (Peripherals peripheral in peripherals)
                    {
                        if (peripheral.Type.Equals("Монитор", StringComparison.OrdinalIgnoreCase))
                        {
                            if (peripheral is Supplement supplement)
                            {
                                writer.WriteLine($"Название: {supplement.Name}, Тип: {supplement.Type}, Страна производства: {supplement.Country}, Год производства: {supplement.Year}");
                            }
                        }
                    }
                }
                Console.WriteLine("Данные о мониторах успешно сохранены в файл.");
            }
            catch (Exception error)
            {
                Console.WriteLine($"Ошибка при сохранении данных в файл: {error.Message}");
            }
        }
        // Метод для загрузки данных из файла
        public void LoadDataFromFile(Device device)
        {
            string file= @"D:\Куровая_\Периферийные устройства\device.txt";
            try
            {
                if (File.Exists(file))
                {
                    string[] lines = File.ReadAllLines(file);

                    foreach (string line in lines)
                    {
                        string[] data = line.Split(';');
                        if (data.Length >= 4)
                        {
                            string name = data[0];
                            string type = data[1];
                            string country = data[2];
                            int year = Convert.ToInt32(data[3]);

                            if (type == "Supplement")
                            {
                                Supplement supplement = new Supplement(name, type, country, year);
                                device.peripherals.Add(supplement);
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Файл с данными не найден. Создан новый файл.");
                    File.Create(file).Close();
                }
            }
            catch (Exception error)
            {
                Console.WriteLine($"Ошибка при загрузке данных из файла: {error.Message}");
            }
        }
        // Метод для сохранения данных в файл
        public void SaveDataToFile(Device device)
        {
            string file = @"D:\Куровая_\Периферийные устройства\device.txt";
            try
            {
                using (StreamWriter writer = new StreamWriter(file))
                {
                    foreach (Peripherals peripheral in device.peripherals)
                    {
                        if (peripheral is Supplement supplement)
                        {
                            writer.WriteLine($"Название: {supplement.Name}, Тип: {supplement.Type}, Страна производства: {supplement.Country}, Год производства: {supplement.Year}");
                        }
                    }
                }
            }
            catch (Exception error)
            {
                Console.WriteLine($"Ошибка при сохранении данных в файл: {error.Message}");
            }
        }
    }
}
