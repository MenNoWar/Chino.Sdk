[![Logo](https://www.chino.io/img/chino.io-chino-header-logo.png "Chino.IO Logo")](https://chino.io)
# Chino.SDK

The Chino.SDK is a ToolSet containing wrapper classes for handling communication with a Chino API Server and some additional Utilities.

 - compatible with Dot Net 4.5.2 and above
 - completely written in C#
 - lightweight and easy to use library

Currently the SDK supports the following repository children:
- Applications
- Authentication
- Blobs
- Collections
- Documents
- (User-) Groups
- Permissions
- Repositories
- Schemas
- Search
- Users

# Getting fast started
- have your Chino.IO account ready
- add a new Application with Grant Type = password
- add a user schema
- add a user
- create a new Project of your desired type in Visual Studio
- add a reference to the Chino.Sdk

after you have completed the above steps successful add the Sdk to the using clause of your Source.

```c#
using Chino.Sdk;
```

now we create a new instance of our Api;
```c#
var api = new Api("{insert your server url here}");
```
this is the starting point for any operation we are going to perform.

Next is to get some setting values from Chino.
We need:
- AppSecret
- AppId,
- CustomerId
- CustomerKey

Best way is to store them in an encrypted settings file for your application. There are many tutorials and ways aviable on how to do that.

After reading the values we should have something like this:
```c#
var appSecret = "{your AppSecret}";
var appId = "{your AppId}";
var customerId = "{your Customer Id}";
var customerKey = "{your Customer Key}";
var serverUrl = "{your Server Uri}";
var api = new Api(serverUrl);
```

Well the first thing that happens on most Applications at this point is, that a user logs in.
As mentioned above you have created a userschema and a user in that scheme, including password. 
Now we will log that user in and retrieve the complete user information.

```c#
var userName = "{the created username}";
var userPass = "{the given password}";
var user = api.Authentication.Login(userName, userPass, appId, appSecret);
```

you may decorate the Login-Method with a try/catch, because when the authentication fails an exception of the type ChinoApiException is thrown. This may look something like:
```c#
try
{
    var user = api.Authentication.Login(userName, userPass, appId, appSecret);
}
catch (ChinoApiException ex)
{
    MessageBox.Show(
                    string.Format("Login failed ({0})", ex.Message),
                    "Fail", MessageBoxButtons.OK
    );
}
```

The magic thing is, that from now on, the complete communication with the Api-Server uses the credentials we used to login. That way the Permissions and Rules you set up for your users are taking place.

More "Getting started" about to come, but i guess you got the point.


# Changes:
2017-10-10: 
 added new Methods to Schema:
 - GetSchemaForType: generates a Schema for a class
 - CreateSchemaForType: generates and creates the schema for a class
 - CreateSchemaForAssembly: generates and creates the schema for all classes in an Assembly
 
 Setters of the BasicListResult class are now public (internal before)
