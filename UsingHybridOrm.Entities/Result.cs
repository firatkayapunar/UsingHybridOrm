namespace UsingHybridOrm.Entities.DTO.Department
{
    public class Result
    {
        // İşlemin başarılı olup olmadığını belirtir
        public bool Success { get; set; }
        // İşlemle ilgili mesaj
        public string Message { get; set; }
        // Hataların listesi
        public IEnumerable<string> Errors { get; set; }

        public Result(bool success, string message, IEnumerable<string> errors)
        {
            Success = success;
            Message = message;
            Errors = errors ?? new List<string>();
        }

        public static Result SuccessResult(string message = "")
        {
            return new Result(true, message, Enumerable.Empty<string>());
        }

        public static Result FailureResult(string message, IEnumerable<string> errors)
        {
            return new Result(false, message, errors);
        }
    }
}
