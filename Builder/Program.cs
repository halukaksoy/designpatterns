using System;
using System.Collections.Generic;

namespace Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            ConnectionContext context = new ConnectionContext();

            //DevConnection
            var devConnectionBuilder = new DevelopmentConnectionBuilder();
            context.ConstructConnection(devConnectionBuilder);
            devConnectionBuilder.Connection.ShowConnection();

            //TestConnection 
            var testConnectionBuilder = new TestConnectionBuilder();
            context.ConstructConnection(testConnectionBuilder);
            testConnectionBuilder.Connection.ShowConnection();

            //ProdConnection 
            var prodConnectionBuilder = new ProductionConnectionBuilder();
            context.ConstructConnection(prodConnectionBuilder);
            prodConnectionBuilder.Connection.ShowConnection();

            Console.ReadLine();

        }
    }

    //Director Class
    class ConnectionContext
    {
        public void ConstructConnection(ConnectionBuilder connectionBuilder)
        {
            connectionBuilder.BuildServer();
            connectionBuilder.BuildDatabase();
            connectionBuilder.BuildUserName();
            connectionBuilder.BuildPassword();
        }
    }
    //Abstract Builder
    abstract class ConnectionBuilder
    {
        protected Connection connection;
        public Connection Connection
        {
            get { return connection; }
        }

        public abstract void BuildServer();
        public abstract void BuildDatabase();
        public abstract void BuildUserName();
        public abstract void BuildPassword();

    }
    //Concrete Builder
    class DevelopmentConnectionBuilder : ConnectionBuilder
    {
        public DevelopmentConnectionBuilder()
        {
            connection = new Connection("Development");
        }
        public override void BuildDatabase()
        {
            connection["database"] = "DevelopmentDatabase";
        }

        public override void BuildPassword()
        {
            connection["password"] = "DevelopmentPassword";
        }

        public override void BuildServer()
        {
            connection["server"] = "DevelopmentServer";
        }

        public override void BuildUserName()
        {
            connection["username"] = "DevUser";
        }
    }
    //Concrete Builder
    class TestConnectionBuilder : ConnectionBuilder
    {
        public TestConnectionBuilder()
        {
            connection = new Connection("Test");
        }
        public override void BuildDatabase()
        {
            connection["database"] = "TestDatabase";
        }

        public override void BuildPassword()
        {
            connection["password"] = "TestPassword";
        }

        public override void BuildServer()
        {
            connection["server"] = "TestServer";
        }

        public override void BuildUserName()
        {
            connection["username"] = "TestUser";
        }
    }
    //Concrete Builder
    class ProductionConnectionBuilder : ConnectionBuilder
    {
        public ProductionConnectionBuilder()
        {
            connection = new Connection("Production");
        }
        public override void BuildDatabase()
        {
            connection["database"] = "ProductionDatabase";
        }

        public override void BuildPassword()
        {
            connection["password"] = "ProductionPassword";
        }

        public override void BuildServer()
        {
            connection["server"] = "ProductionServer";
        }

        public override void BuildUserName()
        {
            connection["username"] = "ProdUser";
        }
    }
    //Product
    class Connection
    {
        private string _connectionType;
        private Dictionary<string, string> _properties = new Dictionary<string, string>();

        public Connection(string connectionType)
        {
            _connectionType = connectionType;
        }

        public string this[string key]
        {
            get { return _properties[key]; }
            set { _properties[key] = value; }
        }

        public void ShowConnection()
        {
            Console.WriteLine("\n--------------------------");
            Console.WriteLine($"Connection Type: {_connectionType}");
            Console.WriteLine($"Server: {_properties["server"]}");
            Console.WriteLine($"Database: {_properties["database"]}");
            Console.WriteLine($"Username: {_properties["username"]}");
            Console.WriteLine($"Password: {_properties["password"]}");
        }
    }
}
