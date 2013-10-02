using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// new...
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Security.Principal;
using System.Net;
using oct01securitybasic.ViewModels;

namespace oct01securitybasic.Handlers
{
    // This class handles the HTTP Basic Authentication process
    // There are plenty of refactoring opportunities;
    // we'll do that later, after you learn the process

    public class BasicAuthMessageHandler : DelegatingHandler
    {
        // Authentication header strings
        private const string Header = "WWW-Authenticate";
        private const string HeaderValue = "Basic";

        // SendAsync method is in the System.Net.Http.MessageProcessingHandler class
        // It handles an HTTP request as an async operation
        // It returns a Task<T>, which is an object that represents the async operation

        protected override System.Threading.Tasks.Task<HttpResponseMessage>
            SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            // Fetch the request's authorization header
            AuthenticationHeaderValue authValue = request.Headers.Authorization;

            // If it has useful data, continue
            // authValue.Scheme is "Basic" in our example 
            // authValue.Parameter is a Base64-encoded string with credentials

            if (authValue != null && !String.IsNullOrWhiteSpace(authValue.Parameter))
            {
                // Decode the credentials:
                // HTTP Basic Authentication credentials are in the format...
                // username:password
                // ...and then Base64-encoded

                // We will decode them into a two-element string array
                string[] credentials =
                    System.Text.Encoding.ASCII.GetString
                    (Convert.FromBase64String(authValue.Parameter)).Split(new[] { ':' });

                // Lookup user in the credential store
                Repo_Credential r = new Repo_Credential();
                var credential = r.GetCredentialByValues(credentials[0], credentials[1]);

                if (credential != null)
                {
                    // Successful match...
                    // Now, create a new generic user
                    // An identity object represents the user on whose behalf the code is running
                    var identity = new GenericIdentity(credential.Username);

                    // Next, set this request's current principal
                    // A principal object represents the security context of the user,
                    // on whose behalf the code is running
                    // It includes the user's identity object, and a string array
                    // of roles to which the user belongs

                    IPrincipal principal = 
                        new GenericPrincipal(identity, new[] { credential.Role });
                    Thread.CurrentPrincipal = principal;

                    // Make sure that the HTTP request processing context has the new principal
                    if (HttpContext.Current != null) HttpContext.Current.User = principal;
                }

            }

            // Finally, after the code above has executed, return the result
            return base.SendAsync(request, cancellationToken).ContinueWith(task =>
                {
                    // Create a response object
                    var response = task.Result;
                    // If the user was unable to authenticate, 
                    // and authentication is required, add the appropriate header
                    if (response.StatusCode == HttpStatusCode.Unauthorized
                        && !response.Headers.Contains(Header))
                    {
                        response.Headers.Add(Header, HeaderValue);
                    }

                    return response;
                });

        }

    }

}