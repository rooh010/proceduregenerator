using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProcedureLib.Models
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class ProcedureModel
    {
        [Key]
        [JsonProperty("ProcedureId")]
        public int ProcedureId { get; set; }

        [JsonProperty("Version")]
        public float Version { get; set; }

        [JsonProperty("ProcedureName")]
        public string ProcedureName { get; set; }

        public ProcedureModel()
        {

        }
    }

    
}
