using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InputModule
{
    public static class MyInput
    {
        /// <summary>
        /// Перевіряє відповідність типу int.
        /// </summary>
        /// <param name="str">Стрічка що перевіряється.</param>
        /// <returns>Повертає true якщо стрічка успішно може бути конвертована в int.</returns>
        public static bool IsInt(string str)
        {
            int temp;
            return int.TryParse(str, System.Globalization.NumberStyles.Integer, System.Globalization.CultureInfo.InvariantCulture, out temp);
        }

        /// <summary>
        /// Перевіряє відповідність типу float.
        /// </summary>
        /// <param name="str">Стрічка що перевіряється.</param>
        /// <returns>Повертає true якщо стрічка успішно може бути конвертована в float.</returns>
        public static bool IsFloat(string str)
        {
            float temp;
            return (float.TryParse(str, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out temp) ||
                float.TryParse(str, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.CurrentCulture, out temp));
        }

        /// <summary>
        /// Перевіряє відповідність типу double.
        /// </summary>
        /// <param name="str">Стрічка що перевіряється.</param>
        /// <returns>Повертає true якщо стрічка успішно може бути конвертована в double.</returns>
        public static bool IsDouble(string str)
        {
            double temp;
            return (double.TryParse(str, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out temp) ||
                double.TryParse(str, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.CurrentCulture, out temp));
        }

        /// <summary>
        /// Перетворює стрічку в int.
        /// </summary>
        /// <param name="str">Стрічка що повинна бути перетворена.</param>
        /// <returns>Повертає int, що є результатом перетворення стрічки.</returns>
        public static int SouldBeInt(string str)
        {
            int temp;
            int.TryParse(str, System.Globalization.NumberStyles.Integer, System.Globalization.CultureInfo.InvariantCulture, out temp);
            return temp;
        }
        /// <summary>
        /// Перетворює стрічку в int.
        /// </summary>
        /// <param name="str">Стрічка що повинна бути перетворена.</param>
        /// <param name="res">Змінна в яку повинен бути записаний результат.</param>
        /// <returns>Повертає true якщо стрічка була перетворена в int.</returns>
        public static bool SouldBeInt(string str, out int res)
        {
            return int.TryParse(str, System.Globalization.NumberStyles.Integer, System.Globalization.CultureInfo.InvariantCulture, out res);
        }

        /// <summary>
        /// Перетворює стрічку в float.
        /// </summary>
        /// <param name="str">Стрічка що повинна бути перетворена.</param>
        /// <returns>Повертає float, що є результатом перетворення стрічки.</returns>
        public static float SouldBeFloat(string str)
        {
            float temp;
            if (!float.TryParse(str, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out temp))
                float.TryParse(str, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.CurrentCulture, out temp);
            return temp;
        }
        /// <summary>
        /// Перетворює стрічку в float.
        /// </summary>
        /// <param name="str">Стрічка що повинна бути перетворена.</param>
        /// <param name="res">Змінна в яку повинен бути записаний результат.</param>
        /// <returns>Повертає true якщо стрічка була перетворена в float.</returns>
        public static bool SouldBeFloat(string str, out float res)
        {
            if (float.TryParse(str, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out res)) return true;
            if (float.TryParse(str, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.CurrentCulture, out res)) return true;
            return false;
        }

        /// <summary>
        /// Перетворює стрічку в double.
        /// </summary>
        /// <param name="str">Стрічка що повинна бути перетворена.</param>
        /// <returns>Повертає double, що є результатом перетворення стрічки.</returns>
        public static double SouldBeDouble(string str)
        {
            double temp;
            if (!double.TryParse(str, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out temp))
                double.TryParse(str, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.CurrentCulture, out temp);
            return temp;
        }
        /// <summary>
        /// Перетворює стрічку в double.
        /// </summary>
        /// <param name="str">Стрічка що повинна бути перетворена.</param>
        /// <param name="res">Змінна в яку повинен бути записаний результат.</param>
        /// <returns>Повертає true якщо стрічка була перетворена в double.</returns>
        public static bool SouldBeDouble(string str, out double res)
        {
            if (double.TryParse(str, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out res)) return true;
            if (double.TryParse(str, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.CurrentCulture, out res)) return true;
            return false;
        }
    }
}
