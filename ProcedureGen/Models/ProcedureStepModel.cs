using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProcedureLib.Models
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class ProcedureStepModel
    {

        [JsonProperty("StepId")]
        [Key]
        public int StepId { get; set; }

        [JsonProperty("ProcedureId")]
        [ForeignKey("ProcedureModel")]
        public int ProcedureId { get; set; }

        [JsonProperty("StepNumber")]
        [Required]
        public int StepNumber { get; set; }

        [JsonProperty("StepDescription")]
        public string StepDescription { get; set; }

        [JsonProperty("StepType")]
        public string StepType { get; set; }




        public ProcedureStepModel()
        {

        }
    }

    
}
