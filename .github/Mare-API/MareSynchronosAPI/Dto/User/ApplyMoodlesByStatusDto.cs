using MareSynchronos.API.Data;
using MessagePack;

namespace MareSynchronos.API.Dto.User;

[MessagePackObject(keyAsPropertyName: true)]
public record ApplyMoodlesByStatusDto(UserData User, string Statuses) : UserDto(User);