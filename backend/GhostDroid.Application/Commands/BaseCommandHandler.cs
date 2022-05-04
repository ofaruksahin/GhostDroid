using AutoMapper;

namespace GhostDroid.Application.Commands
{
    public abstract class BaseCommandHandler
    {
        protected IMapper _mapper;

        public BaseCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }
    }
}
