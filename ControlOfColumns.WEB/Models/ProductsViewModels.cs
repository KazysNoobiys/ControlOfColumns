using System.ComponentModel.DataAnnotations;

namespace ControlOfColumns.WEB.Models
{
    public class ProductsViewModels
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Имя обязательно для заполнения!")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Длинна строки должна быть от 4 до 50 символов!")]
        [Display(Name = "Имя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Цена обязательно для заполнения!")]
        [DataType(DataType.Currency)]
        [Display(Name = "Цена единицы товара")]
        public double Price { get; set; }

        [Display(Name = "Описание товара товара")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Display(Name = "Колличество товара на складе")]
        public int Quantity { get; set; }

        [Display(Name = "Комментарии")]
        [DataType(DataType.MultilineText)]
        public string Commnets { get; set; }

    }
}