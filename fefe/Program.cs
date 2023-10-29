using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Note> notes = new List<Note>();

        notes.Add(new Note("Название имен или название партии СССР", "Описание: DDDD", "2023-10-06"));
        notes.Add(new Note("Тут уже другое название", "Описание заметки было уничтожено", "2023-10-08"));
        notes.Add(new Note("ЕЩЕ ОДНО НАЗВАНИЕ ыыыфвфывы", "чето типо", "2023-10-13"));
        notes.Add(new Note("название в душе будет ежи", "блаблабла", "2023-10-20"));
        notes.Add(new Note("Финал мост вонтет", "XDXDXD", "2023-10-22"));

        int currentIndex = 0;

        ConsoleKeyInfo keyInfo;
        do
        {
            Console.Clear();
            Console.WriteLine("Добро пожаловать в ежедневник!");
            Console.WriteLine("Для создания заметки нажмите на G");

            DisplayMenu(notes, currentIndex);

            keyInfo = Console.ReadKey();

            switch (keyInfo.Key)
            {
                case ConsoleKey.RightArrow:
                    Console.Clear();
                    currentIndex = (currentIndex + 1 + notes.Count) % notes.Count;
                    break;

                case ConsoleKey.LeftArrow:
                    Console.Clear();
                    currentIndex = (currentIndex - 1 + notes.Count) % notes.Count;
                    break;

                case ConsoleKey.Enter:
                    Console.Clear();
                    notes[currentIndex].DisplayFullInfo();
                    break;

                case ConsoleKey.G:
                    Console.Clear();
                    Note newNote = new Note("", "", "");
                    newNote.CreateDate();
                    notes.Add(newNote);
                    currentIndex = notes.Count - 1;
                    break;
            }
        } while (keyInfo.Key != ConsoleKey.Escape);
    }

    static void DisplayMenu(List<Note> notes, int currentIndex)
    {
        Console.WriteLine("Используйте стрелки влево/вправо для управления");
        Console.WriteLine();

        for (int i = 0; i < notes.Count; i++)
        {
            string arrow = (i == currentIndex) ? "→" : " ";
            Console.WriteLine($"{arrow} {notes[i].Title}");
        }
    }
}

class Note
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Date { get; set; }

    public Note(string title, string description, string date)
    {
        Title = title;
        Description = description;
        Date = date;
    }

    public void DisplayFullInfo()
    {
        Console.WriteLine("Текущая заметка:");
        Console.WriteLine($"Название: {Title}");
        Console.WriteLine($"Описание: {Description}");
        Console.WriteLine($"Дата: {Date}");
        Console.WriteLine("\nНажмите Enter для продолжения...");
        Console.ReadLine();
    }

    public void CreateDate()
    {
        Console.Write("Введите название заметки: ");
        Title = Console.ReadLine();
        Console.Write("Введите описание: ");
        Description = Console.ReadLine();
        Console.Write("Введите дату: ");
        Date = Console.ReadLine();
    }
}
