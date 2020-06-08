using System;

namespace ResourceManager.Core.Dtos
{
    public class ResourceDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int MeasuringUnitId { get; set; }

        public string MeasuringUnit { get; set; }

        public string Description { get; set; }

        public int? SafetyClassId { get; set; }

        public string SafetyClass { get; set; }

        public int? EcologyClassId { get; set; }

        public string EcologyClass { get; set; }

        public DateTime? ShelfLife { get; set; }

        public bool NeedLicense { get; set; }

        public int? CategoryId { get; set; }

        public int? SubCategoryId { get; set; }

        public string SubCategory { get; set; }

        public string Category { get; set; }
    }
}
