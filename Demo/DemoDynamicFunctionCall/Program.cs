using System;
using System.Reflection;

namespace DemoDynamicFunctionCall
{
    public enum DbActionType
    {
        Add,
        Remove
    }

    public class DbAction
    {
        public DbActionType Type;
        public string Data;
    }

    public class DataBase
    {
        public void InvokeAction(DbAction action)
        {
            // medhodName was constructed with actionType
            string medhodName = "Action_" + action.Type;
            MethodInfo method = GetType().GetMethod(medhodName, 
                BindingFlags.NonPublic | BindingFlags.Instance); // Can Get Private Functions
            if (method is null)
            {
                Console.WriteLine($"Function not found! {medhodName}");
                return;
            }
            
            method.Invoke(this, new object[] { action.Data });
        }

        // Function's name was mapped DbActionType 
        private void Action_Add(string data)
        {
            Console.WriteLine($"Add -> Data: {data}");
        }
        
        // Function's name was mapped DbActionType 
        private void Action_Remove(string data)
        {
            Console.WriteLine($"Remove -> Data: {data}");
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Program was started.\n");
            
            DataBase db = new DataBase();
            
            db.InvokeAction(new DbAction()
            {
                Type = DbActionType.Add,
                Data = "Hello world!"
            });
            
            db.InvokeAction(new DbAction()
            {
                Type = DbActionType.Remove,
                Data = "Bye bye world."
            });
            
            Console.WriteLine("\nProgram was ended.");
        }
    }
}