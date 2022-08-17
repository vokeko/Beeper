using System;
using System.Windows.Forms;

namespace Beeper
{
    public static class Extensions
    {
        public static T Next<T>(this T src) where T : struct
        {
            if (!typeof(T).IsEnum) throw new ArgumentException(String.Format("Argument {0} není Enum!", typeof(T).FullName));

            T[] Arr = (T[])Enum.GetValues(src.GetType());
            int j = Array.IndexOf<T>(Arr, src) + 1;
            return (Arr.Length == j) ? Arr[j - 1] : Arr[j];
        }
        public static T Prev<T>(this T src) where T : struct
        {
            if (!typeof(T).IsEnum) throw new ArgumentException(String.Format("Argument {0} není Enum!", typeof(T).FullName));

            T[] Arr = (T[])Enum.GetValues(src.GetType());
            int j = Array.IndexOf<T>(Arr, src) - 1;
            return (j == -1) ? Arr[0] : Arr[j];
        }
        public static string GetFile()
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.FileName = "pisen";
                dialog.DefaultExt = ".bin";
                dialog.Filter = "Binární soubor (*.bin)|*.bin";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    return dialog.FileName;
                }
                else return null;
            }
        }

        public static string SaveFile()
        {
            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.FileName = "pisen";
                dialog.DefaultExt = ".bin";
                dialog.Filter = "Binární soubor (*.bin)|*.bin";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    return dialog.FileName;
                }
                else return null;
            }
        }
    }
}
