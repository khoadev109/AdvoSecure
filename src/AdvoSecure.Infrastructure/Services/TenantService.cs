using AdvoSecure.Application.Dtos;
using AdvoSecure.Application.Interfaces.Repositories;
using AdvoSecure.Application.Interfaces.Services;
using AdvoSecure.Domain.Entities;
using AdvoSecure.Infrastructure.Persistance;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace AdvoSecure.Infrastructure.Services
{
    public class TenantService : ITenantService
    {
        private readonly ITenantRepository _tenantRepository;
        private readonly IMapper _mapper;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public TenantService(ITenantRepository tenantRepository, IMapper mapper, IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _tenantRepository = tenantRepository;
            _mapper = mapper;
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        public async Task<TenantDto> CreateTenantFromTenantBase(OrgInitializationRequestDto orgRequestDto)
        {
            bool isTenantExisted = await _tenantRepository.CheckTenantExisted(orgRequestDto.AzureTenantId);
            if (isTenantExisted)
            {
                return new TenantDto();
            }

            var tenantBaseDto = await GetTenantFromTenantBase(orgRequestDto.AzureTenantId);

            if (tenantBaseDto == null)
            {
                return new TenantDto();
            }

            Tenant createdTenant = await _tenantRepository.Create(tenantBaseDto, orgRequestDto.AzureIdentityId);

            TenantDto createdTenantDto = _mapper.Map<TenantDto>(createdTenant);

            return createdTenantDto;
        }

        private async Task<TenantDto> GetTenantFromTenantBase(string azureTenantId)
        {
            var httpClient = _httpClientFactory.CreateClient("TenantApi");

            var getByTenantIdApiUrl = $"{_configuration["Tenant:TenantApiUrl"]}/{_configuration["Tenant:ByTenantId"]}/{azureTenantId}";

            HttpResponseMessage response = await httpClient.GetAsync(getByTenantIdApiUrl);

            response.EnsureSuccessStatusCode();

            var contentStream = await response.Content.ReadAsStreamAsync();

            using var streamReader = new StreamReader(contentStream);
            using var jsonReader = new JsonTextReader(streamReader);

            JsonSerializer serializer = new();

            var tenantFromTenantBase = serializer.Deserialize<TenantDto>(jsonReader);

            return tenantFromTenantBase;
        }

        public async Task<TenantDto> GetTenant()
        {
            Tenant tenant = await _tenantRepository.Get();

            TenantDto tenantDto = _mapper.Map<TenantDto>(tenant);

            return tenantDto;
        }
    }
}
