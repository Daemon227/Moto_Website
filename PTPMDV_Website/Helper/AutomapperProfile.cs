using AutoMapper;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using PTPMDV_Website.Data;
using PTPMDV_Website.ViewModels;

namespace PTPMDV_Website.Helper
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile() 
        {
            // neu khac ten
            /*CreateMap<RegisterVM, User>()
                .ForMember(user => user.Username, option => option.MapFrom(RegisterVM => 
                RegisterVM.Username));*/

            CreateMap<RegisterVM, User>();
        }
    }
}
