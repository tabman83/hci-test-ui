namespace Api;

public class ResultOrError<TResult, TError>
{
    public TResult Result { get; }
    public TError Error { get; }
    public bool IsSuccess { get; }

    // Private constructor ensures that the static methods are used to instantiate the class
    private ResultOrError(TResult result, TError error, bool isSuccess)
    {
        Result = result;
        Error = error;
        IsSuccess = isSuccess;
    }

    // Factory method for success
    public static ResultOrError<TResult, TError> WithSuccess(TResult result)
    {
        return new ResultOrError<TResult, TError>(result, default(TError), true);
    }

    // Factory method for error
    public static ResultOrError<TResult, TError> WithError(TError error)
    {
        return new ResultOrError<TResult, TError>(default(TResult), error, false);
    }
}