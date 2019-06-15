using System;
using System.Text.Json;
using System.IO;
using System.Text;

namespace CoreJsonProjesi
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var memoryStream = new MemoryStream())
            {
                using (var jsonWriter = new Utf8JsonWriter(memoryStream))
                {
                    jsonWriter.WriteStartObject();
                    jsonWriter.WriteString("Ad", "Yigit");
                    jsonWriter.WriteString("Soyad", "Nuhuz");
                    jsonWriter.WriteNumber("No", 320);
                    jsonWriter.WriteNumber("Ortalama", 50.5);
                    jsonWriter.WriteEndObject();
                }

                FileStream file = new FileStream("YeniOgrenci.txt", FileMode.Create, FileAccess.Write);
                memoryStream.WriteTo(file);
                file.Close();

                string json = Encoding.UTF8.GetString(memoryStream.ToArray());
                Console.WriteLine(json);
            }
        }
    }
}
