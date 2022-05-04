using AutoMapper;
using FluentValidation;
using GhostDroid.Domain.Services.Interfaces;
using MediatR;

namespace GhostDroid.Application.Commands.Notification
{
    public class CreateNotificationCommand : IRequest
    {
        public string PackageName { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }

    public class CreateNoficitionCommandValidator : AbstractValidator<CreateNotificationCommand>
    {
        public CreateNoficitionCommandValidator()
        {
            RuleFor(f => f.PackageName).NotEmpty().MaximumLength(150);
            RuleFor(f => f.Title).NotEmpty().MaximumLength(500);
            RuleFor(f => f.Content).NotEmpty().MaximumLength(500);
        }
    }

    public class CreateNotificationCommandHandler : BaseNotificationCommandHandler, IRequestHandler<CreateNotificationCommand>
    {
        public CreateNotificationCommandHandler(
            IMapper mapper,
            INotificationService notificationService)
            : base(mapper, notificationService)
        {
        }

        public async Task<Unit> Handle(CreateNotificationCommand request, CancellationToken cancellationToken)
        {
            var notification = _mapper.Map<Domain.Models.Notification>(request);
            await _notificationService.Insert(notification);
            return Unit.Value;
        }
    }
}
