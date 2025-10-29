using AudioWeb.Core.Application.DTOs.Categories;
using AudioWeb.Core.Application.DTOs.Channels;
using AudioWeb.Core.Application.DTOs.OriginalStories;
using AudioWeb.Core.Application.DTOs.Tags;
using AudioWeb.Core.Application.DTOs.Tracks;
using AudioWeb.Core.Application.DTOs.Writers;
using AudioWeb.Core.Domain.Entities;
using AutoMapper;

namespace AudioWeb.Core.Application.Mappings
{
    public class AudioMappingProfile : Profile
    {

        public AudioMappingProfile()
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

            //Writer
            CreateMap<Writer, WriterDto>()
                .ReverseMap();
            CreateMap<CreateWriterDto, Writer>();

            //Track
            CreateMap<Track, TrackDto>();
            CreateMap<CreateTrackDto, Track>();
            CreateMap<Track, TrackListDto>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
                .ForMember(dest => dest.OriginalStoryName, opt => opt.MapFrom(src => src.OriginalStory.StoryName))
                .ForMember(dest => dest.ChannelName, opt => opt.MapFrom(src => src.Channel.Name))
                .ForMember(dest => dest.TagNames, opt => opt.MapFrom(src => src.TrackTags.Select(tt => tt.Tag.Name)));

            //Tag
            CreateMap<Tag, TagDto>()
                .ReverseMap();
            CreateMap<CreateTagDto, Tag>();

        }

    }
}
