using MareSynchronos.API.Data;
using MessagePack;

namespace MareSynchronos.API.Dto.Group;

[MessagePackObject(keyAsPropertyName: true)]
public record PFinderDto
{
    public Guid Guid { get; set; }
    public DateTimeOffset StartTime { get; set; }
    public DateTimeOffset EndTime { get; set; }
    public DateTimeOffset LastUpdate { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Tags { get; set; }
    public bool IsNSFW { get; set; }
    public bool HasTempGroup { get; set; } = false;
    public string? TempGroupPW { get; set; }
    public bool Open { get; set; }
    public GroupData Group { get; set; }
    public UserData User { get; set; }

    public PFinderDto(Guid guid, DateTimeOffset startTime, DateTimeOffset endTime, DateTimeOffset lastUpdate, string title, string description, string tags,
        bool isNSFW, bool open, GroupData group, UserData user, bool hasTempGroup, string? tempGroupPW)
    {
        Guid = guid;
        StartTime = startTime;
        EndTime = endTime;
        LastUpdate = lastUpdate;
        Title = title;
        Description = description;
        Tags = tags;
        IsNSFW = isNSFW;
        Open = open;
        Group = group;
        User = user;
        HasTempGroup = hasTempGroup;
        TempGroupPW = tempGroupPW;
    }

    public PFinderDto()
    {
        Guid = Guid.NewGuid();
        StartTime = DateTimeOffset.UtcNow;
        EndTime = DateTimeOffset.UtcNow;
        LastUpdate = DateTimeOffset.UtcNow;
        Title = string.Empty;
        Description = string.Empty;
        Tags = string.Empty;
        IsNSFW = false;
        Open = false;
        Group = new GroupData(string.Empty);
        User = new UserData(string.Empty);
        HasTempGroup = false;
        TempGroupPW = null;
    }

    public bool IsVaild()
    {
        if (Guid == Guid.Empty) return false;
        if (StartTime > DateTimeOffset.UtcNow.AddDays(3)) return false;
        if (EndTime < DateTimeOffset.UtcNow) return false;
        if (StartTime + TimeSpan.FromDays(1) < EndTime || StartTime > EndTime) return false;
        if (string.IsNullOrEmpty(Title)) return false;
        if (string.IsNullOrEmpty(Description)) return false;
        if (string.IsNullOrEmpty(Group.GID)) return false;
        if (string.IsNullOrEmpty(User.UID)) return false;
        if (HasTempGroup && string.IsNullOrEmpty(TempGroupPW)) return false;
        return true;
    }
}