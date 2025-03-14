using System.Collections.Generic;

namespace WorkflowCore.Persistence.EntityFramework.Models
{
    /// <summary>
    /// Описание workflow
    /// </summary>
    public class DefinitionMeta
    {
        public List<StepData> Steps { get; set; }
    }

    /// <summary>
    /// Данные шага
    /// </summary>    

    public class StepData
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? DimensionId { get; set; }
    }
}