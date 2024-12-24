using System;
using DataAccessLayer;
using DataAccessLayer.Model;
using DataAccessLayer.Repositories;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            // Створюємо контекст бази даних
            using (var context = new AppDbContext())
            {
                // Ініціалізуємо репозиторії
                var projectRepository = new ProjectRepository(context);
                var participantRepository = new ParticipantRepository(context);

                // Додаємо тестові дані до таблиці Projects
                var project1 = new Project
                {
                    Name = "Project A",
                    StartDate = new DateTime(2023, 10, 1),
                    EndDate = new DateTime(2023, 12, 31)
                };
                projectRepository.Add(project1);

                var project2 = new Project
                {
                    Name = "Project B",
                    StartDate = new DateTime(2023, 11, 1),
                    EndDate = null
                };
                projectRepository.Add(project2);

                // Додаємо тестові дані до таблиці Participants
                var participant1 = new Participant
                {
                    FullName = "John Doe",
                    Login = "johndoe",
                    Password = "password123",
                    Position = "Developer",
                    ProjectId = project1.Id
                };
                participantRepository.Add(participant1);

                var participant2 = new Participant
                {
                    FullName = "Jane Smith",
                    Login = "janesmith",
                    Password = "password456",
                    Position = "Manager",
                    ProjectId = project2.Id
                };
                participantRepository.Add(participant2);

                // Виводимо всі проекти
                Console.WriteLine("Projects:");
                var projects = projectRepository.GetAll();
                foreach (var project in projects)
                {
                    Console.WriteLine($"ID: {project.Id}, Name: {project.Name}, Start Date: {project.StartDate}, End Date: {project.EndDate}");
                }

                // Виводимо всіх учасників
                Console.WriteLine("\nParticipants:");
                var participants = participantRepository.GetAll();
                foreach (var participant in participants)
                {
                    Console.WriteLine($"ID: {participant.Id}, Full Name: {participant.FullName}, Position: {participant.Position}, Project ID: {participant.ProjectId}");
                }

                // Оновлюємо інформацію про учасника
                var participantToUpdate = participantRepository.GetById(1);
                if (participantToUpdate != null)
                {
                    participantToUpdate.Position = "Senior Developer";
                    participantRepository.Update(participantToUpdate);
                    Console.WriteLine("\nParticipant updated successfully.");
                }

                // Видаляємо учасника
                participantRepository.Delete(2);
                Console.WriteLine("\nParticipant with ID 2 deleted successfully.");

                // Виводимо оновлений список учасників
                Console.WriteLine("\nUpdated Participants:");
                participants = participantRepository.GetAll();
                foreach (var participant in participants)
                {
                    Console.WriteLine($"ID: {participant.Id}, Full Name: {participant.FullName}, Position: {participant.Position}, Project ID: {participant.ProjectId}");
                }
            }
        }
    }
}