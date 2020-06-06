namespace ResourceManager.Core.Dtos.FilterDtos
{
    public class ResourceFilterDto
    {
        public string SearchText { get; set; }

        public int? MeasuringUnitId { get; set; }

        public int? CategoryId { get; set; }

        public int? SubCategoryId { get; set; }

        public int? SafetyClassId { get; set; }

        public int? EcologyClassId { get; set; }
    }
}
