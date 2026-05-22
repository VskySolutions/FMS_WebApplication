namespace Vsky.Api.ApiErrors
{
    public enum AuthErrorCodes
    {
        InvalidCredentials = 101,
        RequiresTwoFactor = 102,
        Lockedout = 103,
        NotAllowed = 104,
        Failed = 105
    }
}