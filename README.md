# HMACSignature
HMAC Signature between WebAPI and Windows Phone 8


This project shows how can you create HMAC secure WebApi and how to fetch the data via Windows Phone client.

The main WebAPI player is HMACAuthenticationAttribute attribute which make sure that the http request is signed by the client.
HMACDelegatingHandler is the main file which does the job to sign client's request.
The AppId and AppKey must be the same in both files.

Most of the code was taken from
http://bitoftech.net/2014/12/15/secure-asp-net-web-api-using-api-key-authentication-hmac-authentication/
website, which shows how to create HMAC WebAPI and how to use console client to fetch the data.
I couldn't use the same code with WP project. The main issue is that you cannot use System.Security.Cryptography namespace in WinRT project,
the Windows.Security.Cryptography needs to be use instead.
There are differences in the way you use both of the namespace, hope this help you in your projects.
