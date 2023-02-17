using System;
using System.Collections.Generic;

namespace TrainingWebService.Models
{
    public partial class Modules
    {
        public Modules()
        {
            SubModules = new HashSet<SubModules>();
        }

        public int Id { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }

        public ICollection<SubModules> SubModules { get; set; }
    }
}
