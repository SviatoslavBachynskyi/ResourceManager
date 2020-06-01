using System;

namespace ResourceManager.Core.Models
{
    public class Resource
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int? ResourceSubCategoryId { get; set; }

        public int MeasuringUnitId { get; set; }

        public string Description { get; set; }

        public int? SafetyClassId { get; set; }

        public int? EcologyClassId { get; set; }

        public DateTime? ShelfLife { get; set; }

        public bool? NeedLicense { get; set; }

        public EcologyClass EcologyClass { get; set; }

        public MeasuringUnit MeasuringUnit { get; set; }

        public ResourceSubCategory ResourceSubCategory { get; set; }

        public SafetyClass SafetyClass { get; set; }
    }
}
