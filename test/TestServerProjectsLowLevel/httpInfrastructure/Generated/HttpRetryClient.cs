// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace httpInfrastructure_LowLevel
{
    // Data plane generated client. The HttpRetry service client.
    /// <summary> The HttpRetry service client. </summary>
    public partial class HttpRetryClient
    {
        private const string AuthorizationHeader = "Fake-Subscription-Key";
        private readonly AzureKeyCredential _keyCredential;
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of HttpRetryClient for mocking. </summary>
        protected HttpRetryClient()
        {
        }

        /// <summary> Initializes a new instance of HttpRetryClient. </summary>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="credential"/> is null. </exception>
        public HttpRetryClient(AzureKeyCredential credential) : this(credential, new Uri("http://localhost:3000"), new AutoRestHttpInfrastructureTestServiceClientOptions())
        {
        }

        /// <summary> Initializes a new instance of HttpRetryClient. </summary>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="credential"/> or <paramref name="endpoint"/> is null. </exception>
        public HttpRetryClient(AzureKeyCredential credential, Uri endpoint, AutoRestHttpInfrastructureTestServiceClientOptions options)
        {
            Argument.AssertNotNull(credential, nameof(credential));
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            options ??= new AutoRestHttpInfrastructureTestServiceClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _keyCredential = credential;
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), new HttpPipelinePolicy[] { new AzureKeyCredentialPolicy(_keyCredential, AuthorizationHeader) }, new ResponseClassifier());
            _endpoint = endpoint;
        }

        /// <summary> Return 408 status code, then 200 after retry. </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <example>
        /// This sample shows how to call Head408Async.
        /// <code><![CDATA[
        /// var credential = new AzureKeyCredential("<key>");
        /// var client = new HttpRetryClient(credential);
        /// 
        /// Response response = await client.Head408Async();
        /// Console.WriteLine(response.Status);
        /// ]]></code>
        /// </example>
        public virtual async Task<Response> Head408Async(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("HttpRetryClient.Head408");
            scope.Start();
            try
            {
                using HttpMessage message = CreateHead408Request(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return 408 status code, then 200 after retry. </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <example>
        /// This sample shows how to call Head408.
        /// <code><![CDATA[
        /// var credential = new AzureKeyCredential("<key>");
        /// var client = new HttpRetryClient(credential);
        /// 
        /// Response response = client.Head408();
        /// Console.WriteLine(response.Status);
        /// ]]></code>
        /// </example>
        public virtual Response Head408(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("HttpRetryClient.Head408");
            scope.Start();
            try
            {
                using HttpMessage message = CreateHead408Request(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return 500 status code, then 200 after retry. </summary>
        /// <param name="content"> The content to send as the body of the request. Details of the request body schema are in the Remarks section below. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <example>
        /// This sample shows how to call Put500Async with required request content.
        /// <code><![CDATA[
        /// var credential = new AzureKeyCredential("<key>");
        /// var client = new HttpRetryClient(credential);
        /// 
        /// var data = true;
        /// 
        /// Response response = await client.Put500Async(RequestContent.Create(data));
        /// Console.WriteLine(response.Status);
        /// ]]></code>
        /// </example>
        public virtual async Task<Response> Put500Async(RequestContent content, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("HttpRetryClient.Put500");
            scope.Start();
            try
            {
                using HttpMessage message = CreatePut500Request(content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return 500 status code, then 200 after retry. </summary>
        /// <param name="content"> The content to send as the body of the request. Details of the request body schema are in the Remarks section below. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <example>
        /// This sample shows how to call Put500 with required request content.
        /// <code><![CDATA[
        /// var credential = new AzureKeyCredential("<key>");
        /// var client = new HttpRetryClient(credential);
        /// 
        /// var data = true;
        /// 
        /// Response response = client.Put500(RequestContent.Create(data));
        /// Console.WriteLine(response.Status);
        /// ]]></code>
        /// </example>
        public virtual Response Put500(RequestContent content, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("HttpRetryClient.Put500");
            scope.Start();
            try
            {
                using HttpMessage message = CreatePut500Request(content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return 500 status code, then 200 after retry. </summary>
        /// <param name="content"> The content to send as the body of the request. Details of the request body schema are in the Remarks section below. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <example>
        /// This sample shows how to call Patch500Async with required request content.
        /// <code><![CDATA[
        /// var credential = new AzureKeyCredential("<key>");
        /// var client = new HttpRetryClient(credential);
        /// 
        /// var data = true;
        /// 
        /// Response response = await client.Patch500Async(RequestContent.Create(data));
        /// Console.WriteLine(response.Status);
        /// ]]></code>
        /// </example>
        public virtual async Task<Response> Patch500Async(RequestContent content, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("HttpRetryClient.Patch500");
            scope.Start();
            try
            {
                using HttpMessage message = CreatePatch500Request(content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return 500 status code, then 200 after retry. </summary>
        /// <param name="content"> The content to send as the body of the request. Details of the request body schema are in the Remarks section below. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <example>
        /// This sample shows how to call Patch500 with required request content.
        /// <code><![CDATA[
        /// var credential = new AzureKeyCredential("<key>");
        /// var client = new HttpRetryClient(credential);
        /// 
        /// var data = true;
        /// 
        /// Response response = client.Patch500(RequestContent.Create(data));
        /// Console.WriteLine(response.Status);
        /// ]]></code>
        /// </example>
        public virtual Response Patch500(RequestContent content, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("HttpRetryClient.Patch500");
            scope.Start();
            try
            {
                using HttpMessage message = CreatePatch500Request(content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return 502 status code, then 200 after retry. </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <example>
        /// This sample shows how to call Get502Async.
        /// <code><![CDATA[
        /// var credential = new AzureKeyCredential("<key>");
        /// var client = new HttpRetryClient(credential);
        /// 
        /// Response response = await client.Get502Async();
        /// Console.WriteLine(response.Status);
        /// ]]></code>
        /// </example>
        public virtual async Task<Response> Get502Async(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("HttpRetryClient.Get502");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGet502Request(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return 502 status code, then 200 after retry. </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <example>
        /// This sample shows how to call Get502.
        /// <code><![CDATA[
        /// var credential = new AzureKeyCredential("<key>");
        /// var client = new HttpRetryClient(credential);
        /// 
        /// Response response = client.Get502();
        /// Console.WriteLine(response.Status);
        /// ]]></code>
        /// </example>
        public virtual Response Get502(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("HttpRetryClient.Get502");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGet502Request(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return 502 status code, then 200 after retry. </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <example>
        /// This sample shows how to call Options502Async and parse the result.
        /// <code><![CDATA[
        /// var credential = new AzureKeyCredential("<key>");
        /// var client = new HttpRetryClient(credential);
        /// 
        /// Response response = await client.Options502Async();
        /// 
        /// JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
        /// Console.WriteLine(result.ToString());
        /// ]]></code>
        /// </example>
        public virtual async Task<Response> Options502Async(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("HttpRetryClient.Options502");
            scope.Start();
            try
            {
                using HttpMessage message = CreateOptions502Request(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return 502 status code, then 200 after retry. </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <example>
        /// This sample shows how to call Options502 and parse the result.
        /// <code><![CDATA[
        /// var credential = new AzureKeyCredential("<key>");
        /// var client = new HttpRetryClient(credential);
        /// 
        /// Response response = client.Options502();
        /// 
        /// JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
        /// Console.WriteLine(result.ToString());
        /// ]]></code>
        /// </example>
        public virtual Response Options502(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("HttpRetryClient.Options502");
            scope.Start();
            try
            {
                using HttpMessage message = CreateOptions502Request(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return 503 status code, then 200 after retry. </summary>
        /// <param name="content"> The content to send as the body of the request. Details of the request body schema are in the Remarks section below. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <example>
        /// This sample shows how to call Post503Async with required request content.
        /// <code><![CDATA[
        /// var credential = new AzureKeyCredential("<key>");
        /// var client = new HttpRetryClient(credential);
        /// 
        /// var data = true;
        /// 
        /// Response response = await client.Post503Async(RequestContent.Create(data));
        /// Console.WriteLine(response.Status);
        /// ]]></code>
        /// </example>
        public virtual async Task<Response> Post503Async(RequestContent content, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("HttpRetryClient.Post503");
            scope.Start();
            try
            {
                using HttpMessage message = CreatePost503Request(content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return 503 status code, then 200 after retry. </summary>
        /// <param name="content"> The content to send as the body of the request. Details of the request body schema are in the Remarks section below. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <example>
        /// This sample shows how to call Post503 with required request content.
        /// <code><![CDATA[
        /// var credential = new AzureKeyCredential("<key>");
        /// var client = new HttpRetryClient(credential);
        /// 
        /// var data = true;
        /// 
        /// Response response = client.Post503(RequestContent.Create(data));
        /// Console.WriteLine(response.Status);
        /// ]]></code>
        /// </example>
        public virtual Response Post503(RequestContent content, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("HttpRetryClient.Post503");
            scope.Start();
            try
            {
                using HttpMessage message = CreatePost503Request(content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return 503 status code, then 200 after retry. </summary>
        /// <param name="content"> The content to send as the body of the request. Details of the request body schema are in the Remarks section below. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <example>
        /// This sample shows how to call Delete503Async with required request content.
        /// <code><![CDATA[
        /// var credential = new AzureKeyCredential("<key>");
        /// var client = new HttpRetryClient(credential);
        /// 
        /// var data = true;
        /// 
        /// Response response = await client.Delete503Async(RequestContent.Create(data));
        /// Console.WriteLine(response.Status);
        /// ]]></code>
        /// </example>
        public virtual async Task<Response> Delete503Async(RequestContent content, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("HttpRetryClient.Delete503");
            scope.Start();
            try
            {
                using HttpMessage message = CreateDelete503Request(content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return 503 status code, then 200 after retry. </summary>
        /// <param name="content"> The content to send as the body of the request. Details of the request body schema are in the Remarks section below. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <example>
        /// This sample shows how to call Delete503 with required request content.
        /// <code><![CDATA[
        /// var credential = new AzureKeyCredential("<key>");
        /// var client = new HttpRetryClient(credential);
        /// 
        /// var data = true;
        /// 
        /// Response response = client.Delete503(RequestContent.Create(data));
        /// Console.WriteLine(response.Status);
        /// ]]></code>
        /// </example>
        public virtual Response Delete503(RequestContent content, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("HttpRetryClient.Delete503");
            scope.Start();
            try
            {
                using HttpMessage message = CreateDelete503Request(content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return 504 status code, then 200 after retry. </summary>
        /// <param name="content"> The content to send as the body of the request. Details of the request body schema are in the Remarks section below. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <example>
        /// This sample shows how to call Put504Async with required request content.
        /// <code><![CDATA[
        /// var credential = new AzureKeyCredential("<key>");
        /// var client = new HttpRetryClient(credential);
        /// 
        /// var data = true;
        /// 
        /// Response response = await client.Put504Async(RequestContent.Create(data));
        /// Console.WriteLine(response.Status);
        /// ]]></code>
        /// </example>
        public virtual async Task<Response> Put504Async(RequestContent content, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("HttpRetryClient.Put504");
            scope.Start();
            try
            {
                using HttpMessage message = CreatePut504Request(content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return 504 status code, then 200 after retry. </summary>
        /// <param name="content"> The content to send as the body of the request. Details of the request body schema are in the Remarks section below. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <example>
        /// This sample shows how to call Put504 with required request content.
        /// <code><![CDATA[
        /// var credential = new AzureKeyCredential("<key>");
        /// var client = new HttpRetryClient(credential);
        /// 
        /// var data = true;
        /// 
        /// Response response = client.Put504(RequestContent.Create(data));
        /// Console.WriteLine(response.Status);
        /// ]]></code>
        /// </example>
        public virtual Response Put504(RequestContent content, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("HttpRetryClient.Put504");
            scope.Start();
            try
            {
                using HttpMessage message = CreatePut504Request(content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return 504 status code, then 200 after retry. </summary>
        /// <param name="content"> The content to send as the body of the request. Details of the request body schema are in the Remarks section below. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <example>
        /// This sample shows how to call Patch504Async with required request content.
        /// <code><![CDATA[
        /// var credential = new AzureKeyCredential("<key>");
        /// var client = new HttpRetryClient(credential);
        /// 
        /// var data = true;
        /// 
        /// Response response = await client.Patch504Async(RequestContent.Create(data));
        /// Console.WriteLine(response.Status);
        /// ]]></code>
        /// </example>
        public virtual async Task<Response> Patch504Async(RequestContent content, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("HttpRetryClient.Patch504");
            scope.Start();
            try
            {
                using HttpMessage message = CreatePatch504Request(content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return 504 status code, then 200 after retry. </summary>
        /// <param name="content"> The content to send as the body of the request. Details of the request body schema are in the Remarks section below. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <example>
        /// This sample shows how to call Patch504 with required request content.
        /// <code><![CDATA[
        /// var credential = new AzureKeyCredential("<key>");
        /// var client = new HttpRetryClient(credential);
        /// 
        /// var data = true;
        /// 
        /// Response response = client.Patch504(RequestContent.Create(data));
        /// Console.WriteLine(response.Status);
        /// ]]></code>
        /// </example>
        public virtual Response Patch504(RequestContent content, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("HttpRetryClient.Patch504");
            scope.Start();
            try
            {
                using HttpMessage message = CreatePatch504Request(content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal HttpMessage CreateHead408Request(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Head;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/retry/408", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreatePut500Request(RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/retry/500", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }

        internal HttpMessage CreatePatch500Request(RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Patch;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/retry/500", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }

        internal HttpMessage CreateGet502Request(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/retry/502", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateOptions502Request(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Options;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/retry/502", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreatePost503Request(RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/retry/503", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }

        internal HttpMessage CreateDelete503Request(RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Delete;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/retry/503", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }

        internal HttpMessage CreatePut504Request(RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/retry/504", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }

        internal HttpMessage CreatePatch504Request(RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Patch;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/retry/504", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }

        private static ResponseClassifier _responseClassifier200;
        private static ResponseClassifier ResponseClassifier200 => _responseClassifier200 ??= new StatusCodeClassifier(stackalloc ushort[] { 200 });
    }
}
