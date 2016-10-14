using System;
using System.Net;
using System.Linq;
using System.Linq.Dynamic;
using System.Reflection;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;

namespace DynamicLinq
{
	class Message
	{
		public string Sender;
		public string Receiver;
		public string Text;
		public DateTime SentAt;
		public int Id;
        public IPAddress ip4;

		public Message(string sender, string receiver, string text, DateTime sentAt, int id, IPAddress ip4) {
			this.Sender = sender;
			this.Receiver = receiver;
			this.Text = text;
			this.SentAt = sentAt;
			this.Id = id;
            this.ip4 = ip4;
		}
	}

	class MainClass
	{
		public static void Main (string[] args)
		{
			var messages = new Message[] {
				new Message("Alice", "Bob", "Hello Bob!", DateTime.Now, 1, IPAddress.Parse("127.0.0.1")),
				new Message("Bob", "Alice", "Hello Alice!", DateTime.Now, 2, IPAddress.Parse("127.0.0.1")),
				new Message("Alice", "Bob", "Nice chat!", DateTime.Now, 3, IPAddress.Parse("127.0.0.1")),
				new Message("Alice", "Bob", "Foobar", DateTime.Now, 4, IPAddress.Parse("127.0.0.1")),
				new Message("Alice", "Fred", "Hello Fred!", DateTime.Now, 5, IPAddress.Parse("127.0.0.1"))
			};

			var field = args [0];
			var op = args [1];
			var value = args [2];
			// var value = args [0];

			// var expr = DynamicExpression.ParseLambda(typeof(Message), null, value, messages);
			// Console.WriteLine("Expression: {0}", expr);
			// Console.WriteLine("Result: {0}", expr.Compile().DynamicInvoke(messages[0]));

            var filteredMessages = messages.Where (field + op + value);
			Console.WriteLine ("Dynamic Linq version: {0}", typeof(System.Linq.Dynamic.DynamicExpression).Assembly.FullName);



			foreach (var message in filteredMessages) {
				foreach(var prop in message.GetType().GetFields())
				{
					string name = prop.Name;
					object val = prop.GetValue(message);
					Console.WriteLine("{0}={1}", name, val);
				}
				Console.WriteLine();
			}
		}
	}
}
