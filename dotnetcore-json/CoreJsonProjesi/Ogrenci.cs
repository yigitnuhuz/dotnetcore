using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace CoreJsonProjesi
{
    public class Ogrenci
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        [JsonPropertyName("Numara")]
        public int No { get; set; }
        [JsonIgnore]
        public double Ortalama { get; set; }
    }
}
