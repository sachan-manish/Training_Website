using System;
using System.Collections.Generic;

namespace TrainingWebService.Models
{
    public partial class SubModules
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public string WikiLink { get; set; }
        public string VideoLink { get; set; }
        public int? ModuleId { get; set; }

        public Modules Module { get; set; }
    }
}
