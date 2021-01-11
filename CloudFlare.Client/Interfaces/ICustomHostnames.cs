using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api.CustomHostname;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Enumerators;
using CloudFlare.Client.Models;

namespace CloudFlare.Client.Interfaces
{
    public interface ICustomHostnames
    {
        /// <summary>
        /// Add a new custom hostname and request that an SSL certificate be issued for it. One of three validation methods—http,
        /// cname, email—should be used, with 'http' recommended if the CNAME is already in place (or will be soon). Specifying 'email'
        /// will send an email to the WHOIS contacts on file for the base domain plus hostmaster, postmaster, webmaster, admin, administrator.
        /// Specifying 'cname' will return a CNAME that needs to be placed. If http is used and the domain is not already pointing to the Managed CNAME host,
        /// the PATCH method must be used once it is (to complete validation).
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="hostname">The custom hostname that will point to your hostname via CNAME</param>
        /// <param name="ssl">SSL properties used when creating the custom hostname</param>
        /// <returns></returns>
        Task<CloudFlareResult<CustomHostname>> AddAsync(string zoneId, string hostname, CustomHostnameSsl ssl);

        /// <summary>
        /// Add a new custom hostname and request that an SSL certificate be issued for it. One of three validation methods—http,
        /// cname, email—should be used, with 'http' recommended if the CNAME is already in place (or will be soon). Specifying 'email'
        /// will send an email to the WHOIS contacts on file for the base domain plus hostmaster, postmaster, webmaster, admin, administrator.
        /// Specifying 'cname' will return a CNAME that needs to be placed. If http is used and the domain is not already pointing to the Managed CNAME host,
        /// the PATCH method must be used once it is (to complete validation).
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="hostname">The custom hostname that will point to your hostname via CNAME</param>
        /// <param name="ssl">SSL properties used when creating the custom hostname</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<CustomHostname>> AddAsync(string zoneId, string hostname, CustomHostnameSsl ssl, CancellationToken cancellationToken);

        /// <summary>
        /// Delete Custom Hostname (and any issued SSL certificates)
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="customHostnameId">Custom hostname identifier</param>
        /// <returns></returns>
        Task<CloudFlareResult<CustomHostname>> DeleteAsync(string zoneId, string customHostnameId);

        /// <summary>
        /// Delete Custom Hostname (and any issued SSL certificates)
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="customHostnameId">Custom hostname identifier</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<CustomHostname>> DeleteAsync(string zoneId, string customHostnameId, CancellationToken cancellationToken);

        /// <summary>
        /// List, search, sort, and filter all of your custom hostnames
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<CustomHostname>>> GetAsync(string zoneId);

        /// <summary>
        /// List, search, sort, and filter all of your custom hostnames
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<CustomHostname>>> GetAsync(string zoneId, CancellationToken cancellationToken);

        /// <summary>
        /// List, search, sort, and filter all of your custom hostnames
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="hostname">Fully qualified domain name to match against. This parameter cannot be used with the 'id' parameter</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<CustomHostname>>> GetAsync(string zoneId, string hostname);

        /// <summary>
        /// List, search, sort, and filter all of your custom hostnames
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="hostname">Fully qualified domain name to match against. This parameter cannot be used with the 'id' parameter</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<CustomHostname>>> GetAsync(string zoneId, string hostname, CancellationToken cancellationToken);

        /// <summary>
        /// List, search, sort, and filter all of your custom hostnames
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="hostname">Fully qualified domain name to match against. This parameter cannot be used with the 'id' parameter</param>
        /// <param name="page">Page number of paginated results</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<CustomHostname>>> GetAsync(string zoneId, string hostname, int? page);

        /// <summary>
        /// List, search, sort, and filter all of your custom hostnames
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="hostname">Fully qualified domain name to match against. This parameter cannot be used with the 'id' parameter</param>
        /// <param name="page">Page number of paginated results</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<CustomHostname>>> GetAsync(string zoneId, string hostname, int? page, CancellationToken cancellationToken);

        /// <summary>
        /// List, search, sort, and filter all of your custom hostnames
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="hostname">Fully qualified domain name to match against. This parameter cannot be used with the 'id' parameter</param>
        /// <param name="page">Page number of paginated results</param>
        /// <param name="perPage">Number of hostnames per page</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<CustomHostname>>> GetAsync(string zoneId, string hostname, int? page, int? perPage);

        /// <summary>
        /// List, search, sort, and filter all of your custom hostnames
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="hostname">Fully qualified domain name to match against. This parameter cannot be used with the 'id' parameter</param>
        /// <param name="page">Page number of paginated results</param>
        /// <param name="perPage">Number of hostnames per page</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<CustomHostname>>> GetAsync(string zoneId, string hostname, int? page, int? perPage, CancellationToken cancellationToken);

        /// <summary>
        /// List, search, sort, and filter all of your custom hostnames
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="hostname">Fully qualified domain name to match against. This parameter cannot be used with the 'id' parameter</param>
        /// <param name="page">Page number of paginated results</param>
        /// <param name="perPage">Number of hostnames per page</param>
        /// <param name="type">Field to order hostnames by</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<CustomHostname>>> GetAsync(string zoneId, string hostname, int? page, int? perPage, CustomHostnameOrderType? type);

        /// <summary>
        /// List, search, sort, and filter all of your custom hostnames
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="hostname">Fully qualified domain name to match against. This parameter cannot be used with the 'id' parameter</param>
        /// <param name="page">Page number of paginated results</param>
        /// <param name="perPage">Number of hostnames per page</param>
        /// <param name="type">Field to order hostnames by</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<CustomHostname>>> GetAsync(string zoneId, string hostname, int? page, int? perPage, CustomHostnameOrderType? type, CancellationToken cancellationToken);

        /// <summary>
        /// List, search, sort, and filter all of your custom hostnames
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="hostname">Fully qualified domain name to match against. This parameter cannot be used with the 'id' parameter</param>
        /// <param name="page">Page number of paginated results</param>
        /// <param name="perPage">Number of hostnames per page</param>
        /// <param name="type">Field to order hostnames by</param>
        /// <param name="order">Direction to order hostnames</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<CustomHostname>>> GetAsync(string zoneId, string hostname, int? page, int? perPage, CustomHostnameOrderType? type, OrderType? order);

        /// <summary>
        /// List, search, sort, and filter all of your custom hostnames
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="hostname">Fully qualified domain name to match against. This parameter cannot be used with the 'id' parameter</param>
        /// <param name="page">Page number of paginated results</param>
        /// <param name="perPage">Number of hostnames per page</param>
        /// <param name="type">Field to order hostnames by</param>
        /// <param name="order">Direction to order hostnames</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<CustomHostname>>> GetAsync(string zoneId, string hostname, int? page, int? perPage, CustomHostnameOrderType? type, OrderType? order, CancellationToken cancellationToken);

        /// <summary>
        /// List, search, sort, and filter all of your custom hostnames
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="hostname">Fully qualified domain name to match against. This parameter cannot be used with the 'id' parameter</param>
        /// <param name="page">Page number of paginated results</param>
        /// <param name="perPage">Number of hostnames per page</param>
        /// <param name="type">Field to order hostnames by</param>
        /// <param name="order">Direction to order hostnames</param>
        /// <param name="ssl">Whether to filter hostnames based on if they have SSL enabled</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<CustomHostname>>> GetAsync(string zoneId, string hostname, int? page, int? perPage, CustomHostnameOrderType? type, OrderType? order, bool? ssl);

        /// <summary>
        /// List, search, sort, and filter all of your custom hostnames
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="hostname">Fully qualified domain name to match against. This parameter cannot be used with the 'id' parameter</param>
        /// <param name="page">Page number of paginated results</param>
        /// <param name="perPage">Number of hostnames per page</param>
        /// <param name="type">Field to order hostnames by</param>
        /// <param name="order">Direction to order hostnames</param>
        /// <param name="ssl">Whether to filter hostnames based on if they have SSL enabled</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<CustomHostname>>> GetAsync(string zoneId, string hostname, int? page, int? perPage, CustomHostnameOrderType? type, OrderType? order, bool? ssl, CancellationToken cancellationToken);

        /// <summary>
        /// List, search, sort, and filter all of your custom hostnames
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<CustomHostname>>> GetByIdAsync(string zoneId);

        /// <summary>
        /// List, search, sort, and filter all of your custom hostnames
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<CustomHostname>>> GetByIdAsync(string zoneId, CancellationToken cancellationToken);

        /// <summary>
        /// List, search, sort, and filter all of your custom hostnames
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="customHostnameId">Hostname ID to match against. This ID was generated and returned during the initial custom_hostname creation.
        /// This parameter cannot be used with the 'hostname' parameter</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<CustomHostname>>> GetByIdAsync(string zoneId, string customHostnameId);

        /// <summary>
        /// List, search, sort, and filter all of your custom hostnames
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="customHostnameId">Hostname ID to match against. This ID was generated and returned during the initial custom_hostname creation.
        /// This parameter cannot be used with the 'hostname' parameter</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<CustomHostname>>> GetByIdAsync(string zoneId, string customHostnameId, CancellationToken cancellationToken);

        /// <summary>
        /// List, search, sort, and filter all of your custom hostnames
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="customHostnameId">Hostname ID to match against. This ID was generated and returned during the initial custom_hostname creation.
        /// This parameter cannot be used with the 'hostname' parameter</param>
        /// <param name="page">Page number of paginated results</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<CustomHostname>>> GetByIdAsync(string zoneId, string customHostnameId, int? page);

        /// <summary>
        /// List, search, sort, and filter all of your custom hostnames
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="customHostnameId">Hostname ID to match against. This ID was generated and returned during the initial custom_hostname creation.
        /// This parameter cannot be used with the 'hostname' parameter</param>
        /// <param name="page">Page number of paginated results</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<CustomHostname>>> GetByIdAsync(string zoneId, string customHostnameId, int? page, CancellationToken cancellationToken);

        /// <summary>
        /// List, search, sort, and filter all of your custom hostnames
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="customHostnameId">Hostname ID to match against. This ID was generated and returned during the initial custom_hostname creation.
        /// This parameter cannot be used with the 'hostname' parameter</param>
        /// <param name="page">Page number of paginated results</param>
        /// <param name="perPage">Number of hostnames per page</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<CustomHostname>>> GetByIdAsync(string zoneId, string customHostnameId, int? page,
            int? perPage);

        /// <summary>
        /// List, search, sort, and filter all of your custom hostnames
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="customHostnameId">Hostname ID to match against. This ID was generated and returned during the initial custom_hostname creation.
        /// This parameter cannot be used with the 'hostname' parameter</param>
        /// <param name="page">Page number of paginated results</param>
        /// <param name="perPage">Number of hostnames per page</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<CustomHostname>>> GetByIdAsync(string zoneId, string customHostnameId, int? page,
            int? perPage, CancellationToken cancellationToken);

        /// <summary>
        /// List, search, sort, and filter all of your custom hostnames
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="customHostnameId">Hostname ID to match against. This ID was generated and returned during the initial custom_hostname creation.
        /// This parameter cannot be used with the 'hostname' parameter</param>
        /// <param name="page">Page number of paginated results</param>
        /// <param name="perPage">Number of hostnames per page</param>
        /// <param name="type">Field to order hostnames by</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<CustomHostname>>> GetByIdAsync(string zoneId, string customHostnameId, int? page,
            int? perPage, CustomHostnameOrderType? type);

        /// <summary>
        /// List, search, sort, and filter all of your custom hostnames
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="customHostnameId">Hostname ID to match against. This ID was generated and returned during the initial custom_hostname creation.
        /// This parameter cannot be used with the 'hostname' parameter</param>
        /// <param name="page">Page number of paginated results</param>
        /// <param name="perPage">Number of hostnames per page</param>
        /// <param name="type">Field to order hostnames by</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<CustomHostname>>> GetByIdAsync(string zoneId, string customHostnameId, int? page,
            int? perPage, CustomHostnameOrderType? type, CancellationToken cancellationToken);

        /// <summary>
        /// List, search, sort, and filter all of your custom hostnames
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="customHostnameId">Hostname ID to match against. This ID was generated and returned during the initial custom_hostname creation.
        /// This parameter cannot be used with the 'hostname' parameter</param>
        /// <param name="page">Page number of paginated results</param>
        /// <param name="perPage">Number of hostnames per page</param>
        /// <param name="type">Field to order hostnames by</param>
        /// <param name="order">Direction to order hostnames</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<CustomHostname>>> GetByIdAsync(string zoneId, string customHostnameId, int? page,
            int? perPage, CustomHostnameOrderType? type, OrderType? order);

        /// <summary>
        /// List, search, sort, and filter all of your custom hostnames
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="customHostnameId">Hostname ID to match against. This ID was generated and returned during the initial custom_hostname creation.
        /// This parameter cannot be used with the 'hostname' parameter</param>
        /// <param name="page">Page number of paginated results</param>
        /// <param name="perPage">Number of hostnames per page</param>
        /// <param name="type">Field to order hostnames by</param>
        /// <param name="order">Direction to order hostnames</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<CustomHostname>>> GetByIdAsync(string zoneId, string customHostnameId, int? page,
            int? perPage, CustomHostnameOrderType? type, OrderType? order, CancellationToken cancellationToken);

        /// <summary>
        /// List, search, sort, and filter all of your custom hostnames
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="customHostnameId">Hostname ID to match against. This ID was generated and returned during the initial custom_hostname creation.
        /// This parameter cannot be used with the 'hostname' parameter</param>
        /// <param name="page">Page number of paginated results</param>
        /// <param name="perPage">Number of hostnames per page</param>
        /// <param name="type">Field to order hostnames by</param>
        /// <param name="order">Direction to order hostnames</param>
        /// <param name="ssl">Whether to filter hostnames based on if they have SSL enabled</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<CustomHostname>>> GetByIdAsync(string zoneId, string customHostnameId, int? page,
            int? perPage, CustomHostnameOrderType? type, OrderType? order, bool? ssl);

        /// <summary>
        /// List, search, sort, and filter all of your custom hostnames
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="customHostnameId">Hostname ID to match against. This ID was generated and returned during the initial custom_hostname creation.
        /// This parameter cannot be used with the 'hostname' parameter</param>
        /// <param name="page">Page number of paginated results</param>
        /// <param name="perPage">Number of hostnames per page</param>
        /// <param name="type">Field to order hostnames by</param>
        /// <param name="order">Direction to order hostnames</param>
        /// <param name="ssl">Whether to filter hostnames based on if they have SSL enabled</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<CustomHostname>>> GetByIdAsync(string zoneId, string customHostnameId, int? page,
            int? perPage, CustomHostnameOrderType? type, OrderType? order, bool? ssl, CancellationToken cancellationToken);

        /// <summary>
        /// Get all details of the specified custom hostname
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="customHostnameId"></param>
        /// <returns></returns>
        Task<CloudFlareResult<CustomHostname>> GetDetailsAsync(string zoneId, string customHostnameId);

        /// <summary>
        /// Get all details of the specified custom hostname
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="customHostnameId"></param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<CustomHostname>> GetDetailsAsync(string zoneId, string customHostnameId, CancellationToken cancellationToken);

        /// <summary>
        /// Modify SSL configuration for a custom hostname. When sent with SSL config that matches existing config,
        /// used to indicate that hostname should pass domain control validation (DCV). Can also be used to change validation type,
        /// e.g., from 'http' to 'email'.
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="customHostnameId">Custom hostname identifier</param>
        /// <param name="patchCustomHostname">SSL properties used when creating the custom hostname</param>
        /// <returns></returns>
        Task<CloudFlareResult<CustomHostname>> UpdateAsync(string zoneId, string customHostnameId, PatchCustomHostname patchCustomHostname);

        /// <summary>
        /// Modify SSL configuration for a custom hostname. When sent with SSL config that matches existing config,
        /// used to indicate that hostname should pass domain control validation (DCV). Can also be used to change validation type,
        /// e.g., from 'http' to 'email'.
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="customHostnameId">Custom hostname identifier</param>
        /// <param name="patchCustomHostname">SSL properties used when creating the custom hostname</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<CustomHostname>> UpdateAsync(string zoneId, string customHostnameId, PatchCustomHostname patchCustomHostname, CancellationToken cancellationToken);
    }
}