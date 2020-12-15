using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BicycleShop.Data.Models {
    public class Order {

        [BindNever]
        public int id {get; set;}

        [Display(Name = "Введите имя")]
/*        [StringLength(1)]*/
        [Required(ErrorMessage = "Длинна имени должна быть больше 1 символа")]
        public string name { get; set; }

        [Display(Name = "Введите фамилию")]
        [Required(ErrorMessage = "Длинна фамилии должна быть больше 1 символа")]
        public string surname { get; set; }

        [Display(Name = "Введите адрес")]
        [Required(ErrorMessage = "Длинна адреса должна быть больше 1 символа")]
        public string adress { get; set; }

        [Display(Name = "Введите номер телефона")]
        [Required(ErrorMessage = "Длинна номера должна быть больше 1 символа")]
        [DataType(DataType.PhoneNumber)]
        public string phone { get; set; }

        [Display(Name = "Введите адресс электронной почты")]
        [Required(ErrorMessage = "Длинна адресс электронной почты должна быть больше 1 символа")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime orderTime { get; set; }
        public List<OrderDetail> orderDetails { get; set; }

    }
}
