using System;

namespace PL
{
    internal class Menu
    {
        private readonly MenuList _options;
        private int _selectedIndex;
        private WriteBuffer _previousBuffer;

        public string Title { get; private set; }
        public WriteBuffer CurrentBuffer { get; }

        public Menu(string title)
        {
            Title = title;
            _options = new MenuList();
            _selectedIndex = 0;
            CurrentBuffer = new WriteBuffer();
        }

        public void SetTile(string title)
        {
            Title = title;
        }

        private void DisplayOptions()
        {
            ConsoleWorker.WriteItem(Title, foregroundColor: ConsoleColor.Green);

            for (var i = 0; i < _options.Length; i++)
            {
                var currentOption = _options[i];
                string prefix;

                if (i == _selectedIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                    prefix = "->";
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                    prefix = "  ";
                }

                Console.WriteLine($"{prefix} {currentOption.Name}");
            }
            Console.ResetColor();
        }

        public int GetNumberOption()
        {
            return _selectedIndex;
        }

        public Menu Add(string name, Action action)
        {
            _options.Add(name, action);
            return this;
        }

        public static void Close() => throw new InvalidOperationException("Цей метод не повинен запускатися напряму. Лише посилайтесь на цей метод.");

        public void Run(WriteBuffer previousBuffer = null)
        {
            _previousBuffer = previousBuffer;

            do
            {
                ConsoleWorker.Clear();
                Console.CursorVisible = false;
                DisplayOptions();

                CurrentBuffer.GetChars(out var bufferData, out var foregroundColors, out var backgroundColors);

                if (CurrentBuffer.HasData)
                {
                    ConsoleWorker.WriteItem("");
                    for (var i = 0; i < bufferData.Length; i++)
                    {
                        ConsoleWorker.WriteItem(bufferData[i], false, foregroundColors[i], backgroundColors[i]);
                    }
                }
                Console.SetCursorPosition(0, 0);

                var keyInfo = ConsoleWorker.ReadKey(true);
                var keyPressed = keyInfo.Key;

                if (keyPressed == ConsoleKey.UpArrow)
                {
                    _selectedIndex = (_selectedIndex + _options.Length - 1) % _options.Length;
                }
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    _selectedIndex = (_selectedIndex + 1) % _options.Length;
                }
                else if (keyPressed == ConsoleKey.Enter)
                {
                    if (_options[_selectedIndex].Action == Close)
                    {
                        _selectedIndex = 0;
                        CurrentBuffer.Clear();
                        _previousBuffer?.Clear();
                        break;
                    }
                    CurrentBuffer.Clear();
                    ConsoleWorker.Clear();
                    DisplayOptions();
                    CurrentBuffer.Open();
                    Console.CursorVisible = true;
                    _options[_selectedIndex].Action.Invoke();
                    CurrentBuffer.Close();
                }
            } while (true);
        }
    }
}
