using System;

namespace Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            TextDocument textDocument = new HtmlAdapter();
            textDocument.Request();

            Console.ReadLine();
        }
    }
    //Target
    class TextDocument
    {
        public virtual void Request()
        {
            Console.WriteLine("Called Text Document Request");
        }
    }
    //Adapter
    class HtmlAdapter : TextDocument
    {
        private HtmlDocument _htmlDocument = new HtmlDocument();
        public override void Request()
        {
            _htmlDocument.ConvertRequest();
        }
    }

    //Adaptee
    class HtmlDocument
    {
        public void ConvertRequest()
        {
            Console.WriteLine("<html><head></head><body><label>Called Html Convert Request</label></body></html>");
        }
    }
}
