using System.ComponentModel.DataAnnotations;

namespace Smarest.ViewModel
{
    public class TableViewModel
    {
        public string Id {get;set;}
        [Required]
        public string Name {get;set;}
        

    }
}
