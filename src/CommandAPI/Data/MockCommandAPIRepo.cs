using System.Collections.Generic;
using CommandAPI.Models;

namespace CommandAPI.Data
{
    public class MockCommandAPIRepo : ICommandAPIRepo
    {
        public void CreateCommand(Command cmd)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteCommand(Command cmd)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Command> GetAllCommands() //Read Method
        {
            var commands = new List<Command>
            {
                new Command{
                    Id = 0,
                    HowTo = "How to generate a migration",
                    CommandLine = "dotnet ef migrations add <Name of Migration>",
                    Platform = ".Net Core EF"},
                new Command{
                    Id = 1,
                    HowTo = "How to run migrations",
                    CommandLine = "dotnet ef database",
                    Platform = ".Net Core EF"},
                new Command{
                    Id = 2,
                    HowTo = "List active migrations",
                    CommandLine = "dotnet ef migrations list",
                    Platform = ".Net Core EF"},
            };

            return commands;
        }

        public Command GetCommandById(int id) //Read Method
        {
            return new Command{
                    Id = 0,
                    HowTo = "How to generate a migration",
                    CommandLine = "dotnet ef migrations add <Name of Migration>",
                    Platform = ".Net Core EF"};
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateCommand(Command cmd)
        {
            throw new System.NotImplementedException();
        }
    }
}