namespace ProductModule.Application.Utils;

public record Result<T>
{
    private Result(T value)
    {
        Value = value;
        IsSuccess = true;
    }
    private Result(string message)
    {
        Message = message;
        IsSuccess = false;
    }

    public T? Value { get; private set; }
    public string? Message { get; private set; }
    public bool IsSuccess { get; private set; }
    public bool IsFail => !IsSuccess;

    public static Result<T> Success(T value) => new Result<T>(value);
    public static Result<T> Fail(string message) => new Result<T>(message);
}