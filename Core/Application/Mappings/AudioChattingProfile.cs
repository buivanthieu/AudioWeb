using AudioWeb.Core.Application.DTOs.Categories;
using AudioWeb.Core.Application.DTOs.Channels;
using AudioWeb.Core.Domain.Entities;
using AutoMapper;

namespace AudioWeb.Core.Application.Mappings
{
    public class AudioChattingProfile : Profile
    {

        public AudioChattingProfile()
        {
            // category

            CreateMap<Category, CategoryDto>()
                .ForMember(dest => dest.TrackDtos, opt => opt.MapFrom(src => src.Tracks));
            CreateMap<CategoryDto, Category>()
                .ForMember(dest => dest.Tracks, opt => opt.MapFrom(src => src.TrackDtos));


            // channel
            CreateMap<Channel, ChannelDto>()
                .ForMember(dest => dest.UploadedTrackDtos, opt => opt.MapFrom(src => src.UploadedTracks));
           
        }

    }
}
