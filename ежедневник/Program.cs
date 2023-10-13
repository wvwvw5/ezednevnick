using System;
using System.Collections.Generic;
using System.Linq;

class DailyPlanner
{
    private List<Note> notes;
    private int currentDateIndex;

    public DailyPlanner()
    {
        notes = new List<Note>
        {
            new Note("Заметка 1", "Описание заметки 1", new DateTime(2023, 10, 6)),
            new Note("Заметка 2", "Описание заметки 2", new DateTime(2023, 10, 8)),
            new Note("Заметка 3", "Описание заметки 3", new DateTime(2023, 10, 28)),
            new Note("Заметка 4", "Описание заметки 4", new DateTime(2023, 10, 26)),
            new Note("Заметка 5", "Описание заметки 5", new DateTime(2023, 11, 01)),
            // Добавьте остальные заметки сюда
        };
        currentDateIndex = 0;
    }

    public void Run()
    {
        ConsoleKeyInfo key;
        do
        {
            Console.Clear();
            DisplayMenu();
            key = Console.ReadKey();
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    MoveToPreviousDate();
                    break;
                case ConsoleKey.DownArrow:
                    MoveToNextDate();
                    break;
                case ConsoleKey.Enter:
                    DisplayNoteDetails();
                    break;
            }
        } while (key.Key != ConsoleKey.Escape);
    }

    private void DisplayMenu()
    {
        Console.WriteLine($"Ежедневник - {notes[currentDateIndex].Date.ToShortDateString()}\n");
        for (int i = 0; i < notes.Count; i++)
        {
            Console.WriteLine($"{(i == currentDateIndex ? "> " : "  ")}{notes[i].Title}");
        }
        Console.WriteLine("\nИспользуйте стрелки вверх/вниз для переключения, Enter для подробной информации, и Esc для выхода.");
    }

    private void MoveToPreviousDate()
    {
        if (currentDateIndex > 0)
        {
            currentDateIndex--;
        }
    }

    private void MoveToNextDate()
    {
        if (currentDateIndex < notes.Count - 1)
        {
            currentDateIndex++;
        }
    }

    private void DisplayNoteDetails()
    {
        Console.Clear();
        var note = notes[currentDateIndex];
        Console.WriteLine($"Заголовок: {note.Title}");
        Console.WriteLine($"Дата: {note.Date.ToShortDateString()}");
        Console.WriteLine($"Описание: {Console.ReadLine()}");
        // Добавьте вывод дополнительных данных о заметке по желанию
        Console.WriteLine("\nНажмите любую клавишу, чтобы вернуться к меню.");
        Console.ReadKey();
    }

    class Note
    {
        public string Title { get; }
        public string Description { get; }
        public DateTime Date { get; }

        public Note(string title, string description, DateTime date)
        {
            Title = title;
            Description = description;
            Date = date;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        DailyPlanner dailyPlanner = new DailyPlanner();
        dailyPlanner.Run();
    }
}
