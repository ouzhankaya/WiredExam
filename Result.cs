using System;


	public class Result<T> where T : class
	{
    public List<ErrorMessageObj> Errors { get; set; }
    public T Result { get; set; }

    public Result()
    {
        Errors = new List<ErrorMessageObj>();
    }
    public void AddError(ErrorMessageCode code, string message)
    {
        Errors.Add(new ErrorMessageObj() { Code = code, Message = message });
    }
}
}
