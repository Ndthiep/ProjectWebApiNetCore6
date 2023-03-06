using AutoMapper;
using MyApiNetCore6.Data;
using MyApiNetCore6.Models;
using MyApiNetCore6.ViewModels;

namespace MyApiNetCore6.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper() 
        {
            // ReverseMap: Đảo ngược qua lại, map qua lại
            CreateMap<Book, BookModels>().ReverseMap();
            //CreateMap<???, UserViewModel>().ReverseMap();
        }
    }
}
