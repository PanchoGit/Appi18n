using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Appi18n.Web.Models
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

    /// <summary>
    ///     Result of a particular operation that also generates an output value.
    /// </summary>
    /// <typeparam name="T">Type of result</typeparam>
    public class Result<T> : Result
    {
        #region Constructors

        public Result()
        {
        }

        public Result(T data)
        {
            Data = data;
        }

        #endregion Constructors

        public virtual T Data { get; set; }
    }
}