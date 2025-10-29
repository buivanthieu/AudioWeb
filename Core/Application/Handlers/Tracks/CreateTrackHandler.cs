using MediatR;

using AudioWeb.Core.Application.DTOs.Tracks;
using AudioWeb.Core.Application.Commands.Tracks;
using AudioWeb.Core.Domain.Interfaces;
using AutoMapper;
using AudioWeb.Core.Domain.Entities;
using AudioWeb.Core.Application.DTOs.Writers;
using AudioWeb.Core.Application.DTOs.OriginalStories;
using AudioWeb.Core.Application.DTOs.Tags;

namespace AudioWeb.Core.Application.Handlers.Tracks
{
    public class CreateTrackHandler : IRequestHandler<CreateTrackCommand, TrackDto>
    {
        private readonly ITrackRepository _trackRepository;
        private readonly IMapper _mapper;
        private readonly IOriginalStoryRepository _originalStoryRepository;
        private readonly ITagRepository _tagRepository;
        private readonly IWriterRepository _writerRepository;
        private readonly ITrackTagRepository _trackTagRepository;
        public CreateTrackHandler(ITrackRepository trackRepository, IMapper mapper, 
            IOriginalStoryRepository originalStoryRepository, ITagRepository tagRepository, 
            IWriterRepository writerRepository, ITrackTagRepository trackTagRepository)
        {
            _trackRepository = trackRepository;
            _mapper = mapper;
            _originalStoryRepository = originalStoryRepository;
            _tagRepository = tagRepository;
            _writerRepository = writerRepository;
            _trackTagRepository = trackTagRepository;
        }

        public async Task<TrackDto> Handle(CreateTrackCommand request, CancellationToken cancellationToken)
        {
			

            var createTrackDto = request.CreateTrackDto;


            Writer? writer = null;

            if (!string.IsNullOrWhiteSpace(createTrackDto.WriterName))
            {
                writer = await _writerRepository.GetByNameAsync(createTrackDto.WriterName);

                if (writer == null)
                {
                    var createWriterDto = new CreateWriterDto
                    {
                        Name = createTrackDto.WriterName.Trim()
                    };

                    writer = _mapper.Map<Writer>(createWriterDto);
                    await _writerRepository.AddAsync(writer);

                }
            }


            OriginalStory? story = null;
            if (!string.IsNullOrWhiteSpace(createTrackDto.OriginalStoryName))
            {
                story = await _originalStoryRepository.GetByNameAsync(createTrackDto.OriginalStoryName);
                if (story == null)
                {
                    var createStoryDto = new CreateOriginalStoryDto
                    {
                        StoryName = createTrackDto.OriginalStoryName.Trim(),
                        WriterId = writer?.Id
                    };
                    story = _mapper.Map<OriginalStory>(createStoryDto);
                    await _originalStoryRepository.AddAsync(story);
                }
            }

            var tags = new List<Tag>();
            foreach (var tagName in createTrackDto.TagNames.Distinct())
            {
                var tag = await _tagRepository.GetByNameAsync(tagName);
                if (tag == null)
                {
                    var createTagDto = new CreateTagDto
                    {
                        Name = tagName.Trim()
                    };
                    tag = _mapper.Map<Tag>(createTagDto);
                    await _tagRepository.AddAsync(tag);
                }
                tags.Add(tag);
            }

            var track = _mapper.Map<Track>(createTrackDto);
            if (story != null)
            {
                track.OriginalStoryId = story.Id;

            }
            var createdTrack = await _trackRepository.AddAsync(track);


            foreach (var tag in tags)
            {
                var trackTag = new TrackTag
                {
                    TrackId = createdTrack.Id,
                    TagId = tag.Id
                };
                await _trackTagRepository.AddAsync(trackTag);
            }


            return _mapper.Map<TrackDto>(createdTrack);

        }
    }
}
