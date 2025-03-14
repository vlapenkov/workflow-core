using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkflowCore.Persistence.EntityFramework.Models
{
    /// <summary>
    /// Класс описания Workflow
    /// </summary>
    public class PersistedDefinition
    {
        [Key]
        public long Id { get; set; }

        [MaxLength(200)]
        public string WorkflowDefinitionId { get; set; }

        public int Version { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }
        
        public DefinitionMeta MetaData { get; set; }


    }

    
    


}
