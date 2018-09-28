using System;
using System.Collections.Generic;
using System.Text;

namespace QFXamApp.Models
{
    public static class SearchSettings
    {
        public static int? LevelId { get; set; }
        public static int? BodyId { get; set; }
        public static int? SectorId { get; set; }
        public static int? TypeId { get; set; }
        public static string Text { get; set; }
    }
}
