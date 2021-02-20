using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TIcketBook.DataTier.Models;
using TIcketBook.DataTier.Repositories;
using TIcketBook.DTO.Model;
using TIcketBook.Service;

namespace TIcketBook.Helper
{
    public class MapperProfile : Profile
    {
        public MapperProfile() 
        {
            CreateMap<MovieShow, MovieShowDTO>()
                .BeforeMap((x, y) => y.Status = "Running");
        }
    }
}
