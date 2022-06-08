using MediatR;

namespace UserContactInformation.Application.Features.Report.Commands
{
    public class ProduceReportCommandHandler : IRequestHandler<ProduceReportCommand, int>
    {
        public Task<int> Handle(ProduceReportCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
