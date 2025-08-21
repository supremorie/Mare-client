﻿namespace MareSynchronos.WebAPI.SignalR;

public record JwtIdentifier(string ApiUrl, string CharaHash, string UID, string SecretKeyOrOAuth, string NameWithWorld)
{
    public override string ToString()
    {
        return "{JwtIdentifier; Url: " + ApiUrl + ", Chara: " + CharaHash + ", UID: " + UID + ", HasSecretKeyOrOAuth: " + !string.IsNullOrEmpty(SecretKeyOrOAuth) + "NameWithWorld:" + NameWithWorld + "}";
    }
}