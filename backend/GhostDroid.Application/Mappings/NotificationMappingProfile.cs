using AutoMapper;
using GhostDroid.Application.Commands.Notification;
using GhostDroid.Domain.Models;

namespace GhostDroid.Application.Mappings
{
    public class NotificationMappingProfile : Profile
    {
        public NotificationMappingProfile()
        {
            CreateMap<CreateNotificationCommand, Notification>()
                .ForMember(f => f.PackageName, m => m.MapFrom(f => f.PackageName))
                .ForMember(f => f.Title, m => m.MapFrom(f => f.Title))
                .ForMember(f => f.Content, m => m.MapFrom(f => f.Content));
        }
    }
}
