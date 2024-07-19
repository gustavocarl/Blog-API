//Not in use yet
namespace Blog_API.DTOs;

public class Result<T>
{
    public T? Value { get; }

    public string? Error { get; }

    public bool IsSucess => Error == null;

    public bool IsFailure => Error != null;

    protected Result(T value, string error)
    {
        Value = value;
        Error = error;
    }

    public static Result<T> Sucess(T value) => new(value, null!);

    public static Result<T> Failure(string error) => new(default!, error);
}