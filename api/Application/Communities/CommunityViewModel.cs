using AutoMapper;
using Sociussion.Application.Common.Mappings;
using Sociussion.Domain.Entities;

namespace Sociussion.Application.Communities;

public class CommunityViewModel : IMapFrom<Community>
{
    public ulong Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string PhotoUrl { get; set; }

    public ulong OwnerId { get; set; }

    public ulong MemberCount { get; set; }

    public DateTime? LastActive { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Community, CommunityViewModel>();
    }
}