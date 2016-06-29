using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;

namespace Appi18n.Web.Models
{
    public class DomainActionResult : IHttpActionResult
    {
        #region pending review

        /// <summary>
        ///     Tentative to replace 400 bad request.
        /// </summary>
        // public const int Http422UnprocessableEntity = 422;

        #endregion pending review

        #region Properties

        internal readonly HttpRequestMessage Request;

        /// <summary>
        ///     The Http status code of the response.
        /// </summary>
        /// <returns>
        ///     A value of success or failure based on the <see cref="Result" />
        /// </returns>
        public HttpStatusCode HttpStatusCode { get; private set; }

        /// <summary>
        ///     The result of a business workflow that will be used to create the response message.
        /// </summary>
        public Result Result { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="T:DomainActionResult" /> class with a request message.
        /// </summary>
        /// <param name="request">The request message which led to this result.</param>
        protected DomainActionResult(HttpRequestMessage request)
        {
            Request = request;

            //CreateResponse = System.Net.Http.HttpRequestMessageExtensions.CreateResponse;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="T:DomainActionResult" /> class based on a particular result.
        /// </summary>
        /// <param name="request">The request message which led to this result.</param>
        /// <param name="result">The result of a business workflow that needs to be communicated to the referrer.</param>
        public DomainActionResult(HttpRequestMessage request, Result result)
            : this(request)
        {
            Result = result;

            SetHttpStatusCode();
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="T:DomainActionResult" /> class based on a collectionn of validation
        ///     errors.
        /// </summary>
        /// <param name="request">The request message which led to this result.</param>
        /// <param name="issues">Validation errors result of a business workflow or some business validations.</param>
        public DomainActionResult(HttpRequestMessage request, IEnumerable<ValidationResult> issues)
            : this(request)
        {
            Result = new Result();

            Result.AddErrorRange(issues);

            SetHttpStatusCode();
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="T:DomainActionResult" /> class based on a model state.
        /// </summary>
        /// <param name="request">The request message which led to this result.</param>
        /// <param name="modelState">Result of a model validation.</param>
        public DomainActionResult(HttpRequestMessage request, ModelStateDictionary modelState)
            : this(request)
        {
            // TODO: completar la transformación del model state en IEnumerable<ValidationIssue>
            var issues =
                modelState.Select(err => new ValidationResult(err.Value.Errors.First().ErrorMessage));

            Result = new Result();

            Result.AddErrorRange(issues);

            SetHttpStatusCode();
        }

        #region Construction helpers

        private void SetHttpStatusCode()
        {
            HttpStatusCode = Result.HasErrors
                ? HttpStatusCode.BadRequest // Http422UnprocessableEntity
                : HttpStatusCode.OK;
        }

        #endregion Construction helpers

        #endregion Constructors

        /// <summary>
        ///     Allows the call to CreateResponse extension method to CreateResponse be mocked for testing purposes.
        ///     Unless redefined the default value is a pointer to <see cref="System.Net.Http.HttpRequestMessageExtensions" />
        /// </summary>
        internal Func<HttpRequestMessage, HttpStatusCode, object, HttpResponseMessage> CreateResponse { get; set; }

        /// <summary>
        ///     Creates an <see cref="T:System.Net.Http.HttpResponseMessage" /> asynchronously.
        /// </summary>
        /// <returns>
        ///     A task that, when completed, contains the <see cref="T:System.Net.Http.HttpResponseMessage" />.
        /// </returns>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var responseData = Result.HasErrors
                ? new { Data = new { Result.Errors, Success = false } }
                : GetContentsFromResult<object>();

            HttpResponseMessage httpResponse = Request.CreateResponse(HttpStatusCode, responseData);

            return Task.FromResult(httpResponse);
        }

        /// <summary>
        ///     This method is for internal use and is exposed only to facilitate the inspection of the class during testing.
        /// </summary>
        /// <typeparam name="TContent">The type of data you expect the result to have.</typeparam>
        /// <returns>
        ///     The content of the Data property of <see cref="Result" /> or null if the result is void or the types does not
        ///     match.
        /// </returns>
        public TContent GetContentsFromResult<TContent>()
        {
            Type t = Result.GetType();

            if (t.IsGenericType && t.GenericTypeArguments[0] is TContent)
            {
                // to be able to get the value as any base type we need to use reflection
                // as we cant cast the property to Result<BaseType> as if we were using covariance.
                const string contentProperty = "Data";

                var content = t.GetProperty(contentProperty).GetValue(Result);

                return (TContent)content;
            }

            return default(TContent);

            //var result = Result as Result<TContent>;

            //return result != null
            //        ? result.Data
            //        : default(TContent);
        }

        // TODO: see if we can solve this problem switching to https://msdn.microsoft.com/en-us/library/hh549175.aspx
    }
}