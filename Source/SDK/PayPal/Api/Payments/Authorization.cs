using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections;
using System.Collections.Generic;
using PayPal;
using PayPal.Util;
using PayPal.Api.Payments;

namespace PayPal.Api.Payments
{
	public class Authorization
	{
		/// <summary>
		/// Identifier of the authorization transaction.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string id
		{
			get;
			set;
		}
	
		/// <summary>
		/// Time the resource was created.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string create_time
		{
			get;
			set;
		}
	
		/// <summary>
		/// Time the resource was last updated.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string update_time
		{
			get;
			set;
		}
	
		/// <summary>
		/// Amount being authorized for.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public Amount amount
		{
			get;
			set;
		}
	
		/// <summary>
		/// State of the authorization transaction.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string state
		{
			get;
			set;
		}
	
		/// <summary>
		/// ID of the Payment resource that this transaction is based on.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string parent_payment
		{
			get;
			set;
		}
	
		/// <summary>
		/// Date/Time until which funds may be captured against this resource.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string valid_until
		{
			get;
			set;
		}
	
		/// <summary>
		/// 
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public List<Links> links
		{
			get;
			set;
		}
	
		/// <summary>
		/// Obtain the Authorization transaction resource for the given identifier.
		/// </summary>
		/// <param name="accessToken">Access Token used for the API call.</param>
		/// <param name="authorizationId">string</param>
		/// <returns>Authorization</returns>
		public static Authorization Get(string accessToken, string authorizationId)
		{
			APIContext apiContext = new APIContext(accessToken);
			return Get(apiContext, authorizationId);
		}
		
		/// <summary>
		/// Obtain the Authorization transaction resource for the given identifier.
		/// </summary>
		/// <param name="apiContext">APIContext used for the API call.</param>
		/// <param name="authorizationId">string</param>
		/// <returns>Authorization</returns>
		public static Authorization Get(APIContext apiContext, string authorizationId)
		{
			if (apiContext == null)
			{
				throw new ArgumentNullException("APIContext cannot be null");
			}
			if (string.IsNullOrEmpty(apiContext.AccessToken))
			{
				throw new ArgumentNullException("AccessToken cannot be null or empty");
			}
			if (apiContext.HTTPHeaders == null)
			{
				apiContext.HTTPHeaders = new Dictionary<string, string>();
			}
			apiContext.HTTPHeaders.Add(BaseConstants.ContentTypeHeader, BaseConstants.ContentTypeHeaderJson);
			apiContext.SdkVersion = new SDKVersionImpl();
			if (authorizationId == null)
			{
				throw new ArgumentNullException("authorizationId cannot be null");
			}
			object[] parameters = new object[] {authorizationId};
			string pattern = "v1/payments/authorization/{0}";
			string resourcePath = SDKUtil.FormatURIPath(pattern, parameters);
			string payLoad = "";
			return PayPalResource.ConfigureAndExecute<Authorization>(apiContext, HttpMethod.GET, resourcePath, payLoad);
		}
	
		/// <summary>
		/// Creates (and processes) a new Capture Transaction added as a related resource.
		/// </summary>
		/// <param name="accessToken">Access Token used for the API call.</param>
		/// <param name="capture">Capture</param>
		/// <returns>Capture</returns>
		public Capture Capture(string accessToken, Capture capture)
		{
			APIContext apiContext = new APIContext(accessToken);
			return Capture(apiContext, capture);
		}
		
		/// <summary>
		/// Creates (and processes) a new Capture Transaction added as a related resource.
		/// </summary>
		/// <param name="apiContext">APIContext used for the API call.</param>
		/// <param name="capture">Capture</param>
		/// <returns>Capture</returns>
		public Capture Capture(APIContext apiContext, Capture capture)
		{
			if (apiContext == null)
			{
				throw new ArgumentNullException("APIContext cannot be null");
			}
			if (string.IsNullOrEmpty(apiContext.AccessToken))
			{
				throw new ArgumentNullException("AccessToken cannot be null or empty");
			}
			if (apiContext.HTTPHeaders == null)
			{
				apiContext.HTTPHeaders = new Dictionary<string, string>();
			}
			apiContext.HTTPHeaders.Add(BaseConstants.ContentTypeHeader, BaseConstants.ContentTypeHeaderJson);
			apiContext.SdkVersion = new SDKVersionImpl();
			if (this.id == null)
			{
				throw new ArgumentNullException("Id cannot be null");
			}
			if (capture == null)
			{
				throw new ArgumentNullException("capture cannot be null");
			}
			object[] parameters = new object[] {this.id};
			string pattern = "v1/payments/authorization/{0}/capture";
			string resourcePath = SDKUtil.FormatURIPath(pattern, parameters);
			string payLoad = capture.ConvertToJson();
			return PayPalResource.ConfigureAndExecute<Capture>(apiContext, HttpMethod.POST, resourcePath, payLoad);
		}
	
		/// <summary>
		/// Voids (cancels) an Authorization.
		/// </summary>
		/// <param name="accessToken">Access Token used for the API call.</param>
		/// <returns>Authorization</returns>
		public Authorization Void(string accessToken)
		{
			APIContext apiContext = new APIContext(accessToken);
			return Void(apiContext);
		}
		
		/// <summary>
		/// Voids (cancels) an Authorization.
		/// </summary>
		/// <param name="apiContext">APIContext used for the API call.</param>
		/// <returns>Authorization</returns>
		public Authorization Void(APIContext apiContext)
		{
			if (apiContext == null)
			{
				throw new ArgumentNullException("APIContext cannot be null");
			}
			if (string.IsNullOrEmpty(apiContext.AccessToken))
			{
				throw new ArgumentNullException("AccessToken cannot be null or empty");
			}
			if (apiContext.HTTPHeaders == null)
			{
				apiContext.HTTPHeaders = new Dictionary<string, string>();
			}
			apiContext.HTTPHeaders.Add(BaseConstants.ContentTypeHeader, BaseConstants.ContentTypeHeaderJson);
			apiContext.SdkVersion = new SDKVersionImpl();
			if (this.id == null)
			{
				throw new ArgumentNullException("Id cannot be null");
			}
			object[] parameters = new object[] {this.id};
			string pattern = "v1/payments/authorization/{0}/void";
			string resourcePath = SDKUtil.FormatURIPath(pattern, parameters);
			string payLoad = "";
			return PayPalResource.ConfigureAndExecute<Authorization>(apiContext, HttpMethod.POST, resourcePath, payLoad);
		}
	
		/// <summary>
		/// Reauthorizes an expired Authorization.
		/// </summary>
		/// <param name="accessToken">Access Token used for the API call.</param>
		/// <returns>Authorization</returns>
		public Authorization Reauthorize(string accessToken)
		{
			APIContext apiContext = new APIContext(accessToken);
			return Reauthorize(apiContext);
		}
		
		/// <summary>
		/// Reauthorizes an expired Authorization.
		/// </summary>
		/// <param name="apiContext">APIContext used for the API call.</param>
		/// <returns>Authorization</returns>
		public Authorization Reauthorize(APIContext apiContext)
		{
			if (apiContext == null)
			{
				throw new ArgumentNullException("APIContext cannot be null");
			}
			if (string.IsNullOrEmpty(apiContext.AccessToken))
			{
				throw new ArgumentNullException("AccessToken cannot be null or empty");
			}
			if (apiContext.HTTPHeaders == null)
			{
				apiContext.HTTPHeaders = new Dictionary<string, string>();
			}
			apiContext.HTTPHeaders.Add(BaseConstants.ContentTypeHeader, BaseConstants.ContentTypeHeaderJson);
			apiContext.SdkVersion = new SDKVersionImpl();
			if (this.id == null)
			{
				throw new ArgumentNullException("Id cannot be null");
			}
			object[] parameters = new object[] {this.id};
			string pattern = "v1/payments/authorization/{0}/reauthorize";
			string resourcePath = SDKUtil.FormatURIPath(pattern, parameters);
			string payLoad = this.ConvertToJson();
			return PayPalResource.ConfigureAndExecute<Authorization>(apiContext, HttpMethod.POST, resourcePath, payLoad);
		}
	
		/// <summary>
		/// Converts the object to JSON string
		/// </summary>
		public string ConvertToJson() 
    	{ 
    		return JsonFormatter.ConvertToJson(this);
    	}
	}
}

