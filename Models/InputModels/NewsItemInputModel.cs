using System;
using System.ComponentModel.DataAnnotations;

namespace template.Models.InputModels
{
    public class NewsItemInputModel
    {
        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [Url]
        public string ImgSource { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string ShortDescription { get; set; }

        [Required]
        [MinLength(50)]
        [MaxLength(255)]
        public string LongDescription { get; set; }

        [Required]
        public DateTime PublishDate { get; set; }

    }
}