﻿namespace ResourceManager.ViewModels.FilterViewModels
{
    public class ResourceFilterViewModel
    {
        public string SearchText { get; set; }

        public int? MeasuringUnitId { get; set; }

        public int? CategoryId { get; set; }

        public int? SubCategoryId { get; set; }

        public int? SafetyClassId { get; set; }

        public int? EcologyClassId { get; set; }
    }
}
