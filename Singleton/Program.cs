using System;
using System.Threading;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            LoginApplication("username", "password");
            Console.WriteLine($"Logged User Id : {LoginManager.Instance.LoginUserId} - Logged Date : {LoginManager.Instance.LoggedDate.ToLongDateString()}");
            Console.ReadLine();
        }

        private static void LoginApplication(string username, string password)
        {
            LoginManager.Instance.LoginUserId = Guid.NewGuid();
            LoginManager.Instance.LoggedDate = DateTime.Now;
        }
    }
    //Singleton
    class LoginManager
    {
        private static readonly Lazy<LoginManager> _lazy = new Lazy<LoginManager>(LazyThreadSafetyMode.ExecutionAndPublication);

        public static LoginManager Instance
        {
            get { return _lazy.Value; }
        }

        public Guid LoginUserId { get; set; }
        public DateTime LoggedDate { get; set; }
    }
}
