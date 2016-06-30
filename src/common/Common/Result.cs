using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Common
{
    public class Result
    {
        private readonly List<ValidationResult> errors = new List<ValidationResult>();

        public virtual IEnumerable<string> Errors
        {
            get { return errors.Select(e => e.ErrorMessage).ToList(); }
        }

        public virtual bool HasErrors
        {
            get { return errors.Any(); }
        }

        public void AddError(string message)
        {
            errors.Add(new ValidationResult(message));
        }

        public void AddError(ValidationResult validationResult)
        {
            errors.Add(validationResult);
        }

        public void AddErrorRange(IEnumerable<ValidationResult> validationResults)
        {
            errors.AddRange(validationResults);
        }

        public void AddErrorRange(IEnumerable<string> errorMessages)
        {
            foreach (var error in errorMessages)
            {
                errors.Add(new ValidationResult(error));
            }
        }
    }

    public sealed class Result<T> : Result
    {
        public T Data { get; set; }

        public Result()
        {
        }

        public Result(T data)
        {
            Data = data;
        }
    }
}