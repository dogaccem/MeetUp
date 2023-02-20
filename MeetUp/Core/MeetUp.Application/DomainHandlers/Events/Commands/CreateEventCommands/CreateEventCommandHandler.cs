using MediatR;
using MeetUp.Application.Abstractions.Repositories;
using MeetUp.Application.Abstractions.UnitOfWork;
using MeetUp.Domain.Entities;
using MeetUp.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Security.Claims;

namespace MeetUp.Application.DomainHandlers.Events.Commands.CreateEventCommands
{
    internal class CreateEventCommandHandler : IRequestHandler<CreateEventCommandRequest, Unit>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IWriteRepository<Event> _eventWriteRepository;
        private readonly IReadRepository<Tag> _readTagRepository;

        public CreateEventCommandHandler(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _eventWriteRepository = unitOfWork.GetWriteRepository<Event>();
            _readTagRepository = unitOfWork.GetReadRepository<Tag>();
        }
        public async Task<Unit> Handle(CreateEventCommandRequest request, CancellationToken cancellationToken)
        {
            var currentUser = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == request.ApplicationUserId);

            var eventModel = new Event()
            {
                Title = request.Title,
                imageUrl= request.ImageUrl,
                Capacity= request.Capacity,
                ShortContent = request.ShortContent,
                Place = request.Place,
                StartDate = request.StartDate,
                CategoryId = request.CategoryId,
                EndDate = request.EndDate,
                EventDetail = new EventDetail()
                {
                    Content = request.Content,
                    RespondBy = request.RespondBy,
                    IntervalTime = request.EndDate - request.StartDate,
                },
            };

            foreach (var tag in request.Tags.Split(','))
            {
                var result = await _readTagRepository.AnyAsync(t => t.Name == tag);
                if (!result)
                {
                    eventModel.Tags.Add(new Tag()
                    {
                        Name = tag
                    });
                }
            }

            currentUser.Events.Add(eventModel);

            await _eventWriteRepository.AddAsync(eventModel);

            return Unit.Value;
        }
    }
}
