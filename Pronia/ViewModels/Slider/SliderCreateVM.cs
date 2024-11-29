using System.ComponentModel.DataAnnotations;

namespace Pronia.ViewModels.Slider
{
    public class SliderCreateVM
    {
        [MaxLength(32, ErrorMessage = "Title length must e lees than 32"),Required (ErrorMessage ="Basligi qeyd etmemisiniz,Edin!")]                
        public string Title { get; set; }
        [MaxLength (64),Required]
        public string Subtitle { get; set; }
        public string Link { get; set; }
        [Required]
        public IFormFile File { get; set;}
    }
}
