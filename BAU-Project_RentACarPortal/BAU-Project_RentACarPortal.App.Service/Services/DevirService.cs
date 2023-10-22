using AutoMapper;
using BAU_Project_RentACarPortal.App.Entity.Entities;
using BAU_Project_RentACarPortal.App.Entity.IUnitOfWorks;
using BAU_Project_RentACarPortal.App.Entity.Services;
using BAU_Project_RentACarPortal.App.Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAU_Project_RentACarPortal.App.Service.Services
{
    public class DevirService : IDevirService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWorks _uow;
        private readonly IArabaService _arabaService;
        private readonly IKiralamaService _kiralamaService;

        public DevirService(IMapper mapper, IUnitOfWorks uow, IArabaService arabaService, IKiralamaService kiralamaService)
        {
            _mapper = mapper;
            _uow = uow;
            _arabaService = arabaService;
            _kiralamaService = kiralamaService;
        }

        public async Task Add(DevirViewModel model)
        {
            _kiralamaService.Update(model.FaturaNo);
            await _uow.GetRepository<Devir>().Add(_mapper.Map<Devir>(model));
            await _uow.CommitAsync();
        }

        public void Edit(DevirViewModel model)
        {
            _uow.GetRepository<Devir>().Update(_mapper.Map<Devir>(model));
            _uow.Commit();
        }
    }
}
