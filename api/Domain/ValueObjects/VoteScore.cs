using Sociussion.Domain.Common;

namespace Sociussion.Domain.ValueObjects;

public class VoteScore : ValueObject
{
    public long VotesUp { get; set; } = 0;
    public long VotesDown { get; set; } = 0;
    public long Score => VotesUp - VotesDown;

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Score;
    }
}