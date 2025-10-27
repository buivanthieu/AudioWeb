using AudioWeb.Core.Application.DTOs.Categories;
using AudioWeb.Core.Application.DTOs.Channels;
using AudioWeb.Core.Application.DTOs.OriginalStories;
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
            CreateMap<CreateCategoryDto, Category>()
                .ReverseMap();

            // channel
            CreateMap<Channel, ChannelDto>()
                .ForMember(dest => dest.UploadedTrackDtos, opt => opt.MapFrom(src => src.UploadedTracks));
            CreateMap<ChannelDto, Channel>()
                .ForMember(dest => dest.UploadedTracks, opt => opt.MapFrom(src => src.UploadedTrackDtos));
            CreateMap<CreateChannelDto, Channel>()
                .ReverseMap();

            //Original story
            CreateMap<OriginalStory, OriginalStoryDto>()
                .ForMember(dest => dest.TrackDtos, opt => opt.MapFrom(src => src.Tracks));
            CreateMap<CreateOriginalStoryDto, OriginalStory>()
                .ReverseMap();


            //Playlist


        }

    }
}
