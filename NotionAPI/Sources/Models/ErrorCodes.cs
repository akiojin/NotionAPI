namespace NotionAPI;

public class ErrorCodes
{
    /// <summary>
    /// The request body could not be decoded as JSON.
    /// </summary>
    public const string InvalidJSON = "invalid_json";

    /// <summary>
    /// The request URL is not valid.
    /// </summary>
    public const string InvalidRequestURL = "invalid_request_url";

    /// <summary>
    /// This request is not supported.
    /// </summary>
    public const string InvalidRequest = "invalid_request";

    /// <summary>
    /// The provided authorization grant (e.g., authorization code, resource owner credentials)
    /// or refresh token is invalid, expired, revoked, does not match the redirection URI used in the authorization request,
    /// or was issued to another client. See OAuth 2.0 documentation for more information.
    /// </summary>
    public const string InvalidGrant = "invalid_grant";

    /// <summary>
    /// The request body does not match the schema for the expected parameters.
    /// Check the "message" property for more details.
    /// </summary>
    public const string ValidationError = "validation_error";

    /// <summary>
    /// The bearer token is not valid.
    /// </summary>
    public const string Unauthorized = "unauthorized";

    /// <summary>
    /// Given the bearer token used, the resource does not exist.
    /// This error can also indicate that the resource has not been shared with owner of the bearer token.
    /// </summary>
    public const string ObjectNotFound = "object_not_found";

    /// <summary>
    /// The transaction could not be completed, potentially due to a data collision.
    /// Make sure the parameters are up to date and try again.
    /// </summary>
    public const string ConflictError = "conflict_error";

    /// <summary>
    /// This request exceeds the number of requests allowed. Slow down and try again.
    /// <see href="https://developers.notion.com/reference/request-limits"/>
    /// </summary>
    public const string RateLimited = "rate_limited";

    /// <summary>
    /// An unexpected error occurred.
    /// <see href="https://www.notion.so/help"/>
    /// </summary>
    public const string InternalServerError = "internal_server_error";

    /// <summary>
    /// Notion encountered an issue while attempting to complete this request
    /// (e.g., failed to establish a connection with an upstream server).
    /// Please try again.
    /// </summary>
    public const string BadGateway = "bad_gateway";

    /// <summary>
    /// Notion is unavailable.
    /// This can occur when the time to respond to a request takes longer than 60 seconds, the maximum request timeout.
    /// Please try again later.
    /// </summary>
    public const string ServiceUnavailable = "service_unavailable";

    /// <summary>
    /// Notion's database is unavailable or is not in a state that can be queried. Please try again later.
    /// </summary>
    public const string DatabaseConnectionUnavailable = "database_connection_unavailable";

    /// <summary>
    /// Notion timed out while attempting to complete this request.
    /// Please try again later.
    /// </summary>
    public const string GatewayTimeout = "gateway_timeout";
}
