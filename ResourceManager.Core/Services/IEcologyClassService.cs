﻿using ResourceManager.Core.Dtos;
using ResourceManager.Core.Dtos.FilterDtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ResourceManager.Core.Services
{
    public interface IEcologyClassService
    {
        public Task<IEnumerable<EcologyClassDto>> GetAllAsync();
    }
}
