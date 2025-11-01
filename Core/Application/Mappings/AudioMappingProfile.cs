using AudioWeb.Core.Application.DTOs.Auths;
using AudioWeb.Core.Application.DTOs.Categories;
using AudioWeb.Core.Application.DTOs.Channels;
using AudioWeb.Core.Application.DTOs.OriginalStories;
using AudioWeb.Core.Application.DTOs.Playlists;
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

            //auth

            CreateMap<User, RegisterDto>();
            // category

            CreateMap<Category, CategoryDto>()
                .ForMember(dest => dest.TrackListDtos, opt => opt.MapFrom(src => src.Tracks));
            CreateMap<CategoryDto, Category>()
                .ForMember(dest => dest.Tracks, opt => opt.MapFrom(src => src.TrackListDtos));

            CreateMap<Category, CategoryListDto>();
            CreateMap<CreateCategoryDto, Category>()
                .ReverseMap();

            // channel
            CreateMap<Channel, ChannelDto>()
                .ForMember(dest => dest.UploadedTrackListDtos, opt => opt.MapFrom(src => src.UploadedTracks))
                .ForMember(dest => dest.PlaylistDtos, opt => opt.MapFrom(src => src.Playlists));
            CreateMap<CreateChannelDto, Channel>();
            CreateMap<Channel, ChannelListDto>();

            //Original story
            CreateMap<OriginalStory, OriginalStoryDto>()
                 .ForMember(dest => dest.WriterName, opt => opt.MapFrom((src, dest) => src.Writer != null ? src.Writer.Name : null))
                 .ForMember(dest => dest.TrackListDtos, opt => opt.MapFrom(src => src.Tracks));
            CreateMap<OriginalStory, OriginalStoryListDto>()
                 .ForMember(dest => dest.WriterName, opt => opt.MapFrom((src, dest) => src.Writer != null ? src.Writer.Name : null));
            CreateMap<CreateOriginalStoryDto, OriginalStory>()
                .ReverseMap();


            //Playlist
            CreateMap<Playlist, PlaylistDto>()
                .ForMember(dest => dest.ItemCount, opt => opt.MapFrom(src => src.PlaylistItems.Count()))
                .ForMember(dest => dest.TrackListDtos, opt => opt.MapFrom(src => src.PlaylistItems.Select(pe => pe.Track)));
            CreateMap<CreatePlaylistDto, Playlist>();

            //Writer
            CreateMap<Writer, WriterDto>()
                .ForMember(dest => dest.OriginalStoryListDtos, opt => opt.MapFrom(src => src.OriginalStories));
            CreateMap<Writer, WriterListDto>();
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
                .ForMember(dest => dest.TrackListDtos, opt => opt.MapFrom(src => src.TrackTags.Select(tt => tt.Track)));
            CreateMap<Tag, TagListDto>();
            CreateMap<CreateTagDto, Tag>();

        }

    }
}
