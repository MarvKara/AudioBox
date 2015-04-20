using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Crowdsound_Centralized_Server_Application.Modules
{
    public static class UserInputInterpreter
    {
        private static Thread _inputInterpreterThread;
        private static string _userInput;

        public static void Initialize()
        {
            _userInput = string.Empty;
            _inputInterpreterThread = new Thread(MainInterpreterRoutine) {IsBackground = true};
            _inputInterpreterThread.Start();
        }

        public static void Read(string input)
        {
            _userInput = input;
        }

        private static void ClearInput()
        {
            _userInput = string.Empty;
        }

        public static void MainInterpreterRoutine()
        {
            while (true)
            {
                Thread.Sleep(1);

                if (_userInput == "exec _gui")
                {
                    Console.WriteLine("\n");
                    Console.WriteLine("EXEC GUI...");
                    Console.WriteLine("NOT IMPLEMENTED");
                    // OpenGUI();
                    ClearInput();
                    continue;
                }
                if (_userInput == "exec swecho")
                {
                    Console.WriteLine("\n");
                    Console.WriteLine("EXEC SWECHO");
                    Console.WriteLine("NOT IMPLEMENTED");
                    Console.WriteLine(Core.SwitchEchoMode());
                    ClearInput();
                    continue;
                }
                if (_userInput == "cls")
                {
                    Console.Clear();
                    ClearInput();
                    continue;
                }
                if (!string.IsNullOrEmpty(_userInput))
                {
                    if (_userInput != string.Empty)
                    {
                        Console.WriteLine("INVALID COMMAND! : " + _userInput);
                        ClearInput();
                    }
                }
            }
        }
    }
}
