using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace NewPractice_7_ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Имя файла с данными
            string path = "newFile.txt";
            Repository repo = new Repository(path);

            while (true)
            {
                Console.WriteLine("Меню:");
                Console.WriteLine("1. Просмотреть всех работников");
                Console.WriteLine("2. Просмотреть работника по ID");
                Console.WriteLine("3. Добавить нового работника");
                Console.WriteLine("4. Удалить работника");
                Console.WriteLine("5. Просмотреть работников за период");
                Console.WriteLine("6. Сортировать");
                Console.WriteLine("0. Выход");
                Console.WriteLine("Введите номер пункта меню:");

                int userInput = int.Parse(Console.ReadLine());

                switch (userInput)
                {
                    case 0:
                        return;
                    case 1:
                        Worker[] allWorkers = repo.GetAllWorkers();
                        if (allWorkers.Length == 0)
                        {
                            Console.WriteLine("Список работников пуст.");
                        }
                        else
                        {
                            Console.WriteLine("Список всех работников:");
                            foreach (Worker workers in allWorkers)
                            {
                                Console.WriteLine($"ID: {workers.Id}, Дата добавления: {workers.DateAdded} ФИО: {workers.FIO}, Возраст: {workers.Age}, Рост {workers.Height}, Дата рождения {workers.BirthDate}, Место рождения {workers.BirthPlace}");
                            }
                        }
                        break;
                    case 2:
                        Console.WriteLine("Введите ID работника:");
                        int ID = int.Parse(Console.ReadLine());

                        Worker worker = repo.GetWorkerById(ID);

                        // Вывод данных работника (без проверки на null)
                        Console.WriteLine($"ID: {worker.Id}");
                        Console.WriteLine($"Дата добавления: {worker.DateAdded}");
                        Console.WriteLine($"ФИО: {worker.FIO}");
                        Console.WriteLine($"Возраст: {worker.Age}");
                        Console.WriteLine($"Рост: {worker.Height}");
                        Console.WriteLine($"Дата рождения: {worker.BirthDate}");
                        Console.WriteLine($"Место рождения: {worker.BirthPlace}");

                        Console.ReadKey();
                        break;
                    case 3:
                        Console.WriteLine("Введите ID: ");
                        int id = int.Parse(Console.ReadLine());

                        Console.WriteLine("Введите ФИО работника: ");
                        string fio = Console.ReadLine();

                        Console.WriteLine("Введите возраст работника: ");
                        int age = int.Parse(Console.ReadLine());

                        Console.WriteLine("Введите рост работника: ");
                        int height = int.Parse(Console.ReadLine());

                        DateTime DateAdded = DateTime.Now;
                        Console.WriteLine($"время записи: {DateAdded}");

                        Console.WriteLine("Введите дату рождения: ");
                        DateTime birthDate = DateTime.Parse(Console.ReadLine()); //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

                        Console.WriteLine("Введите место рождения работника: ");
                        string birthPlace = Console.ReadLine();

                        Worker newWorker = new Worker
                        {
                            Id = id,
                            DateAdded = DateAdded,
                            FIO = fio,
                            Age = age,
                            Height = height,
                            BirthDate = birthDate,
                            BirthPlace = birthPlace
                        };

                        repo.AddWorker(newWorker);
                        break;
                    case 4:
                        Console.Write("Введите ID работника: ");
                        int DelId = int.Parse(Console.ReadLine());
                        repo.DeleteWorker(DelId);
                        Console.WriteLine("Работник удален.");
                        break;
                    case 5:
                        Console.WriteLine("Введите начальную дату (гггг-мм-дд):");
                        DateTime dateFrom = DateTime.Parse(Console.ReadLine());

                        Console.WriteLine("Введите конечную дату (гггг-мм-дд):");
                        DateTime dateTo = DateTime.Parse(Console.ReadLine());

                        Worker[] GetWorkersDates = repo.GetWorkersBetweenTwoDates(dateFrom, dateTo);
                        if (GetWorkersDates.Length == 0)
                        {
                            Console.WriteLine("Работников в указанном периоде не найдено.");
                        }
                        else
                        {
                            Console.WriteLine("Список работников:");
                            foreach (Worker workers in GetWorkersDates)
                            {
                                Console.WriteLine($"ID: {workers.Id}, Дата добавления: {workers.DateAdded} ФИО: {workers.FIO}, Возраст: {workers.Age}, Рост {workers.Height}, Дата рождения {workers.BirthDate}, Место рождения {workers.BirthPlace} ");
                            }
                        }
                        break;
                    case 6:
                        bool exitMenu = true;
                        while (exitMenu)
                        {
                            Console.WriteLine("Нажмите 0, чтобы выйти");
                            Console.WriteLine("Нажмите 1, чтобы отсортировать по ID");
                            Console.WriteLine("Нажмите 2, чтобы отсортировать по времени захода");
                            Console.WriteLine("Нажмите 3, чтобы отсортировать по возрасту");
                            Console.WriteLine("Нажмите 4, чтобы отсортировать по росту");
                            Console.WriteLine("Нажмите 5, чтобы отсортировать по дате рождения");
                            Console.WriteLine("Нажмите 6, чтобы отсортировать по месту рождения");
                            int userInput2 = int.Parse(Console.ReadLine());

                            switch (userInput2)
                            {
                                case 0:
                                    exitMenu = false;
                                    break;
                                case 1:
                                    Worker[] sortedId = repo.SortWorkersById();
                                    // Вывод отсортированных данных (реализуйте вывод)
                                    foreach (var workers in sortedId)
                                    {
                                        Console.WriteLine(workers.Id);
                                    }
                                    break;
                                case 2:
                                    Worker[] sortedDateAdded = repo.SortWorkersByDateAdded();
                                    foreach (var workers in sortedDateAdded)
                                    {
                                        Console.WriteLine($"{workers.DateAdded}");
                                    }
                                    break;
                                case 3:
                                    Worker[] sortedAge = repo.SortWorkersByAge();
                                    foreach (var workers in sortedAge)
                                    {
                                        Console.WriteLine($"{workers.Age}");
                                    }
                                    break;
                                case 4:
                                    Worker[] sortedHeight = repo.SortWorkersByHeight();
                                    foreach (var workers in sortedHeight)
                                    {
                                        Console.WriteLine($"{workers.Height}");
                                    }
                                    break;
                                case 5:
                                    Worker[] sortedBirthDate = repo.SortWorkersByBirthDate();
                                    foreach (var workers in sortedBirthDate)
                                    {
                                        Console.WriteLine(workers.BirthDate);
                                    }
                                    break;
                                case 6:
                                    Worker[] sortedBirthPlace = repo.SortWorkersByBirthPlace();
                                    foreach (var workers in sortedBirthPlace)
                                    {
                                        Console.WriteLine($"{workers.BirthPlace}");
                                    }
                                    break;
                            }
                        }
                        break;                                 
                }
            }
        }
    }
}
