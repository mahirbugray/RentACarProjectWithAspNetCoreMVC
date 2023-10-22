using AutoMapper;
using BAU_Project_RentACarPortal.App.DataAccess.Identity.Model;
using BAU_Project_RentACarPortal.App.Entity.Entities;
using BAU_Project_RentACarPortal.App.Entity.Services;
using BAU_Project_RentACarPortal.App.Entity.ViewModels;
using BAU_Project_RentACarPortal.App.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAU_Project_RentACarPortal.App.Service.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AppUser, UserViewModel>().ReverseMap();
            CreateMap<AppUser, LoginViewModel>().ReverseMap();
            CreateMap<AppRole, RoleViewModel>().ReverseMap();
            CreateMap<Araba, ArabaViewModel>().ReverseMap();
            CreateMap<ArabaDetay, ArabaDetayViewModel>().ReverseMap();
            CreateMap<ArabaKategori, KategoriViewModel>().ReverseMap();
            CreateMap<Firma, FirmaViewModel>().ReverseMap();
            CreateMap<Sigorta, SigortaViewModel>().ReverseMap();
            CreateMap<Kiralama, KiralamaViewModel>().ReverseMap();
            CreateMap<KiralamaDetay, KiralamaDetayViewModel>().ReverseMap();
            CreateMap<Degerlendirme, DegerlendirmeViewModel>().ReverseMap();
            CreateMap<Devir, DevirViewModel>().ReverseMap();
        }
    }
}
