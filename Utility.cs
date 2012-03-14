using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace Lab1_redo
{
    /// <summary>
    /// For general methods used commonly. Includes methods for formatting, I/O, displaying, basic arithmetic.
    /// </summary>
    static class Utility
    {

        /// <summary>
        /// Display a Press Any Key to ... message at the bottom of the screen
        /// </summary>
        /// <param name="strVerb">the term to include in the Press Any Key to ... message; defaults to "continue . . ."</param>
        public static void PressAnyKey(string strVerb = "continue ...")
        {
            Console.ForegroundColor = ConsoleColor.Red;

            if (Console.CursorTop < Console.WindowHeight - 1)
                Console.SetCursorPosition(0, Console.WindowHeight - 1);
            else
                Console.SetCursorPosition(0, Console.CursorTop + 2);

            Console.Write("Press any key to " + strVerb);
            Console.ReadKey();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
        } // End PressAnyKey

        /// <summary>
        /// Display a specified welcome message.
        /// </summary>
        public static void WelcomeMessage()
        {
            String msg = "Welcome.";
            String caption = "Welcome, again.";
            String author = "Lee John Philip Carr";

            Console.WriteLine("{0}\n\n\t\t\t{1}\n\n\t\t\t{2}\n\n\t\t\t{3}", msg, caption, author, DateTime.Today.ToLongDateString());
            Console.ReadKey();
            Console.Clear();
        }

        /// <summary>
        /// Display a specified closing message.
        /// </summary>
        public static void GoodByeMessage()
        {
            String msg = "Goodbye";

            Console.WriteLine("{0}\n\n\t\t\t{1}\n\n\t\t\t{2}", msg, DateTime.Today.ToLongTimeString());
            Console.ReadKey();
        }

        /// <summary>
        /// Return a string formatted for display between the designated left and right margins
        /// </summary>
        /// <param name="txt">the string to be formatted</param>
        /// <param name="leftMargin">the left margin</param>
        /// <param name="rightMargin">the right margin</param>
        /// <returns>the formatted string</returns>
        public static string FormatText(string txt, int leftMargin = 0, int rightMargin = 80)
        {

            return null;
        }

        /// <summary>
        /// Used to control the settings of the display window.
        /// </summary>
        public static void Settings()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Title = "Text Processor";
        }

        /// <summary>
        /// Receives basic information from the user.
        /// </summary>
        public static void UserInfo()
        {
            Console.WriteLine("\nPlease enter your name.");
            //   = Console.ReadLine();

            Console.WriteLine("\nPlease enter your E-mail address.");
            //    = Console.ReadLine();

            Console.WriteLine("\nPlease enter your phone number in form of either 'XXX-XXXX' or 'XXX-XXX-XXXX'");
            // = Console.ReadLine();
        }

        public static String GetExistingText()
        {
            String txt = "";
            OpenFileDialog dlg = new OpenFileDialog();

            dlg.InitialDirectory = Application.StartupPath;
            dlg.Title = "Select a text file.";
            dlg.Filter = "text files|*.txt|allfiles|*.*";

            if (dlg.ShowDialog() == DialogResult.Cancel)
                return null;

            StreamReader reader = null;

            try
            {
                reader = new StreamReader(dlg.FileName);
                while (reader.Peek() != -1)
                {
                    txt += reader.ReadToEnd();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.GetType() + "\n" + exc.Message + "\n" + exc.StackTrace,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Restart();
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }

            return txt;
        }

        public static IList<T> Clone<T>(this IList<T> listToClone) where T : ICloneable
        {
            return listToClone.Select(item => (T)item.Clone()).ToList();
        }
    }
}