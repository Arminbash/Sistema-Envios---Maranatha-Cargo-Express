﻿using _1.MCargoExpress.Domain;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._1.MCargoExpress.Dtos
{
    /// <summary>
    /// Perfiles de mapeo de entidades a Dto
    /// </summary>
    /// Johnny Arcia
    public class MappingProfiles : Profile
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public MappingProfiles()
        {
            CreateMap<Traduccion, TraduccionDto>().ReverseMap();
        }
    }
}