using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BAU_Project_RentACarPortal.App.Entity.ViewModels
{
    public class RegisterViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "İsim alanı boş geçilemez")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Soyisim alanı boş geçilemez")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Kullanıcı adı boş geçilemez")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Telefon alanı boş geçilemez")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "TCKNo alanı boş geçilemez")]
        public string TcNo { get; set; }
        [Required(ErrorMessage = "Cinsiyet alanı boş geçilemez")]
        public bool Cinsiyet { get; set; }
        [Required(ErrorMessage = "Doğum tarihi alanı boş geçilemez")]
        public DateTime DogumYili { get; set; }
        [Required(ErrorMessage = "Adres alanı boş geçilemez")]
        public string? Adres { get; set; }
        [Required(ErrorMessage = "Email alanı boş geçilemez")]
        [EmailAddress(ErrorMessage = "Email formatı uygun değil")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Şifre boş geçilemez")]
        [Display(Name = "Şifre")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Tekrar şifresi boş geçilemez")]
        [Compare("Password", ErrorMessage = "Şifreler uyuşmuyor!")]
        [Display(Name = "Şifre Tekrar")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
