using Application.Features.Frameworks.Dtos;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Frameworks.Models
{
    public class FrameworkListModel :BasePageableModel
    {
        public IList<FrameworkListDto> Items { get; set; }
    }
}
