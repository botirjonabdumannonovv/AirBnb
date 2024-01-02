using AirBnb.Server.Api.Models.Dtos;
using AirBnb.ServerApp.Domain.Entities;
using AutoMapper;

namespace AirBnb.Server.Api.Mappers;

public class ListingCategoryMapper : Profile
{
    public ListingCategoryMapper()
    {
        CreateMap<ListingCategory, ListingCategoryDto>()
            .ForMember(dest => dest.ImageUrl, opt => opt.ConvertUsing<StorageFilePathToUrlConverter, StorageFile>(src => src.ImageStorageFile));
    }
}

public class StorageFilePathToUrlConverter : IValueConverter<StorageFile, string>
{
    public string Convert(StorageFile sourceMember, ResolutionContext context)
    {
        throw new NotImplementedException();
    }
}