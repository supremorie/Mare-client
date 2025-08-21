using MareSynchronos.API.Data;
using MessagePack;

namespace MareSynchronos.API.Dto.User;

[MessagePackObject(keyAsPropertyName: true)]
public record MoodlesDto(UserData User, MoodlesAction Action, string Statuses) : UserDto(User);

public enum MoodlesAction
{
    UpLoad, Download, Remove
}