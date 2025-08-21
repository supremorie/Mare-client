using MessagePack;

namespace MareSynchronos.API.Dto;

[MessagePackObject(keyAsPropertyName: true)]
public record SupporterDto(List<string> Supporters);