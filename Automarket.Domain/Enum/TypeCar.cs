using System.ComponentModel.DataAnnotations;

namespace Automarket.Domain.Enum;

public enum TypeCar
{
    [Display(Name = "Легковой автомобиль")]
    PassengerCar=0,
    [Display(Name = "Седан")]
    Sedan=1,
    [Display(Name = "Хэтчбэк")]
    HatchBack=2,
    [Display(Name = "Минивэн")]
    Minivan=3,
    [Display(Name = "Спортивная автомобиль")]
    SportCar=4,
    [Display(Name = "Внедорожник")]
    Suv=5,

}