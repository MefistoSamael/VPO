using Aspose.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    public class HtmlGradientCreator
    {
        public void CreateHtmlGradient()
        {
            string filePath = MyPath.path;

            // Создаем файл и объект StreamWriter для записи в него
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                // Начинаем запись HTML-кода
                sw.WriteLine("<!DOCTYPE html>");
                sw.WriteLine("<html>");
                sw.WriteLine("<head>");
                sw.WriteLine("<title>Градиентная таблица</title>");
                sw.WriteLine("</head>");
                sw.WriteLine("<body>");
                sw.WriteLine("<table>");

                int rowCount = 255; // Количество строк в таблице
                double step = 255.0 / rowCount; // Рассчитываем шаг изменения цвета

                for (int i = 0; i < rowCount; i++)
                {
                    int red = (int)(255 - i * step);
                    int green = (int)(255 - i * step);
                    int blue = (int)(255 - i * step);

                    string bgColor = string.Format("#{0:X2}{1:X2}{2:X2}", red, green, blue);

                    // Создаем строку таблицы с заданным фоновым цветом
                    sw.WriteLine("<tr style='background-color:" + bgColor + "'>");
                    sw.WriteLine("<td width=\"1000\"> </td>");
                    sw.WriteLine("</tr>");
                }

                // Завершаем запись HTML-кода
                sw.WriteLine("</table>");
                sw.WriteLine("</body>");
                sw.WriteLine("</html>");
            }

            Console.WriteLine("HTML-файл создан: " + filePath);
        }
    }
}
