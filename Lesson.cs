using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LOL.Lesson10
{
    internal class Lesson
    {
        private List<Progrm> programists = new List<Progrm>()
        {
            new Progrm { Name = "Cena", Position = "Junior", Hobby = "Football", Salary = 1000, WorkCompany = "Microsoft" },
            new Progrm { Name = "Jack", Position = "Middle", Hobby = "Basketball", Salary = 2000, WorkCompany = "Google" },
            new Progrm { Name = "Jill", Position = "Senior", Hobby = "Volleyball", Salary = 3000, WorkCompany = "Apple" },
            new Progrm { Name = "John", Position = "Junior", Hobby = "Hockey", Salary = 1000, WorkCompany = "Microsoft" },
            new Progrm { Name = "Rock", Position = "Middle", Hobby = "Baseball", Salary = 2000, WorkCompany = "Google" }
        };

        public void Run()
        {
            while (true)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Hamma programmistlarni anketasini kursatish");
                Console.WriteLine("2. Programmist qo'shish");
                Console.WriteLine("3. Programmist anketasini to'g'irlash");
                Console.WriteLine("4. Anketadan programmist o'chirish");
                Console.WriteLine("5. Chiqish");
                Console.Write("Shulardan bittasini tanlang: ");
                int choose = Convert.ToInt32(Console.ReadLine());

                switch (choose)
                {
                    case 1:
                        ShowAll();
                        break;
                    case 2:
                        AddProgrammer();
                        break;
                    case 3:
                        EditProgrammer();
                        break;
                    case 4:
                        DeleteProgrammer();
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("Noto'gri son krittingiz");
                        break;
                }
            }
        }

        private void ShowAll()
        {
            Console.WriteLine("\nProgrrammistlar anketasi:");
            foreach (var p in programists)
            {
                Console.WriteLine($"ID:{p.Id} | Name:{p.Name} | Position:{p.Position} | Hobby:{p.Hobby} | Salary:{p.Salary}$ | WorkCompany:{p.WorkCompany}");
            }
        }

        private void AddProgrammer()
        {
            var newProgrammer = new Progrm { Id = Guid.NewGuid() };
            Console.Write("Ismi: ");
            newProgrammer.Name = Console.ReadLine();
            Console.Write("Yo'nalishi: ");
            newProgrammer.Position = Console.ReadLine();
            Console.Write("Hobbisi: ");
            newProgrammer.Hobby = Console.ReadLine();
            Console.Write("Oyligi: ");
            newProgrammer.Salary = int.Parse(Console.ReadLine());
            Console.Write("Companiyasi: ");
            newProgrammer.WorkCompany = Console.ReadLine();

            programists.Add(newProgrammer);
            Console.WriteLine("Yangi programmist anketasi qo'shildi!");
        }

        private void EditProgrammer()
        {
            Console.Write("Programmist idsini kriting: ");
            if (Guid.TryParse(Console.ReadLine(), out Guid id))
            {
                var programmer = programists.FirstOrDefault(p => p.Id == id);
                if (programmer != null)
                {
                    Console.Write("Yangii ismni kriting (Bumasam Enterni bosing, oldingo ismni qoldirish uchun): ");
                    string input = Console.ReadLine();
                    if (!string.IsNullOrEmpty(input)) programmer.Name = input;

                    Console.Write("Yangi yunalishi: ");
                    input = Console.ReadLine();
                    if (!string.IsNullOrEmpty(input)) programmer.Position = input;

                    Console.Write("Yangi hobbisi: ");
                    input = Console.ReadLine();
                    if (!string.IsNullOrEmpty(input)) programmer.Hobby = input;

                    Console.Write("Yangi ish oyligi(dollorda): ");
                    input = Console.ReadLine();
                    programmer.Salary = int.Parse(input);

                    Console.Write("Kompaniya nomi: ");
                    input = Console.ReadLine();
                    if (!string.IsNullOrEmpty(input)) programmer.WorkCompany = input;

                    Console.WriteLine("Programmistning anketasi yangilandi!");
                }
                else Console.WriteLine("Bu iddagi Programmist anketasi topilmadi!");
            }
            else Console.WriteLine("Id bunday formata emas!");
        }

        private void DeleteProgrammer()
        {
            Console.Write("Programmist anketasining idsini tering, o'chirish uchun: ");
            if (Guid.TryParse(Console.ReadLine(), out Guid id))
            {
                var programmer = programists.FirstOrDefault(p => p.Id == id);
                if (programmer != null)
                {
                    programists.Remove(programmer);
                    Console.WriteLine("Programmist anketasi o'chirildi!");
                }
                else Console.WriteLine("Bu iddagi Programmist anketasi topilmadi!");
            }
            else Console.WriteLine("Id bunday formata emas!");
        }
    }

    internal class Progrm
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Position { get; set; }
        public string Hobby { get; set; }
        public int Salary { get; set; }
        public string WorkCompany { get; set; }
    }
}
