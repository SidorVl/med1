using System;
using System.Collections.Generic;

class Program
{
    static List<Patient> patients = new List<Patient>();
    static List<Doctor> doctors = new List<Doctor>();

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("1. Зареєструватися як пацiєнт");
            Console.WriteLine("2. Зареєструватися як лiкар");
            Console.WriteLine("3. Записатися на прийом до лiкаря");
            Console.WriteLine("4. Подивитися всiх пацiєнтiв");
            Console.WriteLine("5. Редагувати медичну картку");
            Console.WriteLine("6. Створити медичну картку");
            Console.WriteLine("7. Вийти");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    RegisterPatient();
                    break;
                case 2:
                    RegisterDoctor();
                    break;
                case 3:
                    ScheduleAppointment();
                    break;
                case 4:
                    DisplayPatients();
                    break;
                case 5:
                    EditMedicalRecord();
                    break;
                case 6:
                    CreateMedicalRecord();
                    break;
                case 7:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Неправильний вибiр");
                    break;
            }
        }
    }

    static void RegisterPatient()
    {
        Console.WriteLine("Введiть iм'я пацiєнта:");
        string name = Console.ReadLine();
        patients.Add(new Patient(name));
        Console.WriteLine("Пацiєнт зареєстрований успiшно!");
    }

    static void RegisterDoctor()
    {
        Console.WriteLine("Введiть iм'я лiкаря:");
        string name = Console.ReadLine();
        doctors.Add(new Doctor(name));
        Console.WriteLine("Лiкар зареєстрований успiшно!");
    }

    static void ScheduleAppointment()
    {
        Console.WriteLine("Виберiть пацiєнта:");
        for (int i = 0; i < patients.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {patients[i].Name}");
        }
        int patientIndex = int.Parse(Console.ReadLine()) - 1;

        Console.WriteLine("Виберiть лiкаря:");
        for (int i = 0; i < doctors.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {doctors[i].Name}");
        }
        int doctorIndex = int.Parse(Console.ReadLine()) - 1;

        patients[patientIndex].ScheduleAppointment(doctors[doctorIndex]);
        Console.WriteLine("Прийом запланований успiшно!");
    }

    static void DisplayPatients()
    {
        foreach (var patient in patients)
        {
            Console.WriteLine($"Пацiєнт: {patient.Name}, Лiкар: {(patient.AssignedDoctor != null ? patient.AssignedDoctor.Name : "Не заплановано")}");
        }
    }

    static void EditMedicalRecord()
    {
        Console.WriteLine("Виберiть пацiєнта, чиї медичнi записи ви хочете редагувати:");
        for (int i = 0; i < patients.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {patients[i].Name}");
        }
        int patientIndex = int.Parse(Console.ReadLine()) - 1;

        Console.WriteLine("Введiть новий запис для медичної картки:");
        string newRecord = Console.ReadLine();

        patients[patientIndex].MedicalRecords.Add(newRecord);
        Console.WriteLine("Медична картка оновлена успiшно!");
    }

    static void CreateMedicalRecord()
    {
        Console.WriteLine("Введiть iм'я пацiєнта для створення медичної картки:");
        string patientName = Console.ReadLine();

        Console.WriteLine("Введіть вiк пацiєнта:");
        int patientAge = int.Parse(Console.ReadLine());

        Console.WriteLine("Введiть стать пацiєнта:");
        string patientGender = Console.ReadLine();

        Console.WriteLine("Введiть iсторiю хвороби пацiєнта:");
        string medicalHistory = Console.ReadLine();

        patients.Add(new Patient(patientName, patientAge, patientGender, medicalHistory));
        Console.WriteLine("Медична картка створена успiшно!");
    }
}

class Patient
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Gender { get; set; }
    public string MedicalHistory { get; set; }
    public Doctor AssignedDoctor { get; set; }
    public List<string> MedicalRecords { get; set; }


    public Patient(string name)
    {
        Name = name;
        MedicalRecords = new List<string>();
    }


    public Patient(string name, int age, string gender, string medicalHistory)
    {
        Name = name;
        Age = age;
        Gender = gender;
        MedicalHistory = medicalHistory;
        MedicalRecords = new List<string>();
    }

    public void ScheduleAppointment(Doctor doctor)
    {
        AssignedDoctor = doctor;
    }
}


class Doctor
{
    public string Name { get; set; }

    public Doctor(string name)
    {
        Name = name;
    }
}
