using System.Diagnostics.CodeAnalysis;

namespace LuniShop.Shared.Abstractions.Results;

public sealed record Result<T>(T? Value, string? ErrorMessage)
{
    [MemberNotNullWhen(true, nameof(Value))]
    public bool IsSuccess => ErrorMessage is null && Value is not null;
}

public static class Result
{
    public static Result<T> Success<T>(T value) => new(value, null);
    public static Result<T> Failure<T>(string errorMessage) => new(default, errorMessage);
}
