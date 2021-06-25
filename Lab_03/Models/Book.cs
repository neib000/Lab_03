namespace Lab_03.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Book")]
    public partial class Book
    {
        public int Id { get; set; }
        [Display(Name = "Tác giả")]
        [Required(ErrorMessage = "Tác giả không được trống")]
        [StringLength(30, ErrorMessage = "Tên tác giả không được vượt quá 30 kí tự")]
        public string Author { get; set; }
        [Display(Name = "Tên sách")]
        [Required(ErrorMessage = "Tên sách không được trống")]
        [StringLength(100, ErrorMessage = "Tên sách không được vượt quá 100 kí tự")]
        public string Title { get; set; }
        [Display(Name = "Mô tả")]
        [Required(ErrorMessage = "Mô tả không được trống")]
        [StringLength(100, ErrorMessage = "Mô tả không được vượt quá 100 kí tự")]
        public string Description { get; set; }
        [Display(Name = "Hình ảnh")]
        [Required(ErrorMessage = "Hình ảnh không được trống")]
        [StringLength(100)]
        public string ImageCover { get; set; }
        [Display(Name = "Giá sách")]
        [Required(ErrorMessage = "Giá sách không được trống")]
        [Range(1000, 1000000,
       ErrorMessage = "Giá sách từ 1000 đến 1000000")]
        public int? Price { get; set; }
    }
}
