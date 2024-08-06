using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewPractice_7_ConsoleApp1
{
    internal class Repository
    {
        private string path;

        public Repository(string Path)
        {
            this.path = Path;
        }

        // Получение всех записей
        public Worker[] GetAllWorkers()
        {
            List<Worker> workers = new List<Worker>();

            if (File.Exists(path))
            {
                string[] lines = File.ReadAllLines(path);
                foreach (string line in lines)
                {
                    string[] parts = line.Split('#');
                    workers.Add(new Worker
                    {
                        Id = int.Parse(parts[0]),
                        DateAdded = DateTime.Parse(parts[1]),
                        FIO = parts[2],
                        Age = int.Parse(parts[3]),
                        Height = int.Parse(parts[4]),
                        BirthDate = DateTime.Parse(parts[5]),
                        BirthPlace = parts[6],
                    });
                }
            }

            return workers.ToArray();
        }

        // Получение записи по ID
        public Worker GetWorkerById(int ID)
        {
            Worker[] workers = GetAllWorkers();
            return workers.FirstOrDefault(w => w.Id == ID);
        }

        // Создание новой записи
        public void AddWorker(Worker worker)
        {
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine($"{worker.Id}#{worker.DateAdded}#{worker.FIO}#{worker.Age}#{worker.Height}#{worker.BirthDate}#{worker.BirthPlace}");
            }
        }

        // Удаление записи
        public void DeleteWorker(int DelId)
        {
            Worker[] workers = GetAllWorkers();
            Worker[] updatedWorkers = workers.Where(w => w.Id != DelId).ToArray();
            File.WriteAllLines(path, updatedWorkers.Select(w => $"{w.Id}#{w.DateAdded}#{w.FIO}#{w.Age}#{w.Height}#{w.BirthDate}#{w.BirthPlace}"));
        }

        // Получение записей в заданном диапазоне дат
        public Worker[] GetWorkersBetweenTwoDates(DateTime dateFrom, DateTime dateTo)
        {
            Worker[] workers = GetAllWorkers();
            return workers.Where(w => w.BirthDate >= dateFrom && w.BirthDate <= dateTo).ToArray();
        }

        public Worker[] SortWorkersById()
        {
            Worker[] workers = GetAllWorkers();
            return workers.OrderBy(w => w.Id).ToArray();
        }

        // Сортировка по дате добавления
        public Worker[] SortWorkersByDateAdded()
        {
            Worker[] workers = GetAllWorkers();
            return workers.OrderBy(w => w.DateAdded).ToArray();
        }

        // Сортировка по ФИО
        public Worker[] SortWorkersByFIO()
        {
            Worker[] workers = GetAllWorkers();
            return workers.OrderBy(w => w.FIO).ToArray();
        }

        // Сортировка по возрасту
        public Worker[] SortWorkersByAge()
        {
            Worker[] workers = GetAllWorkers();
            return workers.OrderBy(w => w.Age).ToArray();
        }

        // Сортировка по росту
        public Worker[] SortWorkersByHeight()
        {
            Worker[] workers = GetAllWorkers();
            return workers.OrderBy(w => w.Height).ToArray();
        }

        // Сортировка по дате рождения
        public Worker[] SortWorkersByBirthDate()
        {
            Worker[] workers = GetAllWorkers();
            return workers.OrderBy(w => w.BirthDate).ToArray();
        }

        // Сортировка по месту рождения
        public Worker[] SortWorkersByBirthPlace()
        {
            Worker[] workers = GetAllWorkers();
            return workers.OrderBy(w => w.BirthPlace).ToArray();
        }
    }
}

