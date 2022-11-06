using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PL
{
    internal class WriteBuffer : TextWriter
    {
        private readonly List<TextWriter> _writers;
        private readonly TextWriter _consoleStandartWriter;
        private readonly List<ConsoleColor> _foregroundColors;
        private readonly List<ConsoleColor> _backgroundColors;

        public override Encoding Encoding => Encoding.UTF8;
        public bool HasData { get; private set; }

        public WriteBuffer()
        {
            _writers = new List<TextWriter>();
            _consoleStandartWriter = Console.Out;
            _foregroundColors = new List<ConsoleColor>();
            _backgroundColors = new List<ConsoleColor>();

            _writers.Add(_consoleStandartWriter);
            _writers.Add(new StringWriter());
        }

        public override void Write(char ch)
        {
            foreach (var writer in _writers)
                writer.Write(ch);
            _foregroundColors.Add(Console.ForegroundColor);
            _backgroundColors.Add(Console.BackgroundColor);
        }

        public void GetChars(out char[] chars, out List<ConsoleColor> foregroundColors, out List<ConsoleColor> backgroundColors)
        {
            chars = _writers[1].ToString().ToCharArray();
            //chars = _writers[1].ToString().Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToString()
            //    .ToCharArray();
            foregroundColors = _foregroundColors;
            backgroundColors = _backgroundColors;
        }

        public void Open()
        {
            Console.SetOut(this);
            HasData = true;
        }

        public override void Close()
        {
            Console.SetOut(_consoleStandartWriter);
        }

        public void Clear()
        {
            _writers[1] = new StringWriter();
            HasData = false;
            _foregroundColors.Clear();
            _backgroundColors.Clear();
        }
    }
}