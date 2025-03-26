using System;
using System.Collections.Generic;

// Базовый класс Entity
public abstract class Entity
{
    public int Id { get; set; }
}

// Класс Building (Корпус)
public class Building : Entity
{
    public string Name { get; set; }        // Название корпуса
    public string Address { get; set; }     // Адрес корпуса
    public List<Room> Rooms { get; set; } = new List<Room>(); // Список номеров

    // Метод для добавления номера в корпус
    public void AddRoom(Room room)
    {
        room.Building = this;
        Rooms.Add(room);
    }
}

// Класс Room (Номер)
public class Room : Entity
{
    public int RoomNumber { get; set; }     // Номер комнаты
    public int Capacity { get; set; }       // Вместимость
    public Building Building { get; set; }  // Ссылка на корпус
    public List<Visitor> Visitors { get; set; } = new List<Visitor>(); // Список посетителей

    // Метод для заселения посетителя
    public void AddVisitor(Visitor visitor)
    {
        if (Visitors.Count < Capacity)
        {
            visitor.Room = this;
            Visitors.Add(visitor);
        }
        else
        {
            Console.WriteLine("Номер переполнен, невозможно добавить посетителя.");
        }
    }
}

// Класс Visitor (Посетитель)
public class Visitor : Entity
{
    public string FirstName { get; set; }   // Имя
    public string LastName { get; set; }    // Фамилия
    public DateTime CheckInDate { get; set; } // Дата заезда
    public DateTime CheckOutDate { get; set; } // Дата выезда
    public Room Room { get; set; }          // Ссылка на номер

    // Метод для вывода информации о посетителе
    public void DisplayInfo()
    {
        Console.WriteLine($"Посетитель: {FirstName} {LastName}");
        Console.WriteLine($"Дата заезда: {CheckInDate.ToShortDateString()}");
        Console.WriteLine($"Дата выезда: {CheckOutDate.ToShortDateString()}");
        Console.WriteLine($"Номер: {Room?.RoomNumber}, Корпус: {Room?.Building?.Name}");
        Console.WriteLine($"Прикрасный вид у окна");
    }
}

// Пример использования классов
public class Program
{
    public static void Main(string[] args)
    {
        // Создаем корпус
        Building building1 = new Building
        {
            Id = 1,
            Name = "Корпус А",
            Address = "ул. Санаторная, 1"
        };

        // Создаем номера в корпусе
        Room room101 = new Room
        {
            Id = 1,
            RoomNumber = 101,
            Capacity = 2
        };

        Room room102 = new Room
        {
            Id = 2,
            RoomNumber = 102,
            Capacity = 3
        };

        // Добавляем номера в корпус
        building1.AddRoom(room101);
        building1.AddRoom(room102);

        // Создаем посетителей
        Visitor visitor1 = new Visitor
        {
            Id = 1,
            FirstName = "Иван",
            LastName = "Иванов",
            CheckInDate = DateTime.Now,
            CheckOutDate = DateTime.Now.AddDays(7)
        };

        Visitor visitor2 = new Visitor
        {
            Id = 2,
            FirstName = "Петр",
            LastName = "Петров",
            CheckInDate = DateTime.Now,
            CheckOutDate = DateTime.Now.AddDays(5)
        };

        // Заселяем посетителей в номера
        room101.AddVisitor(visitor1);
        room102.AddVisitor(visitor2);

        // Выводим информацию о посетителях
        visitor1.DisplayInfo();
        visitor2.DisplayInfo();

        Console.ReadLine(); // Чтобы консоль не закрывалась сразу
    }
}
