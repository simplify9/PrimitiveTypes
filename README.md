# SW.PrimitiveTypes
![Build Status](https://dev.azure.com/simplify9/Github%20Pipelines/_apis/build/status/simplify9.PrimitiveTypes?branchName=master)

| **Package**       | **Version** |
| :----------------:|:----------------------:|
| ``SimplyWorks.PrimitiveTypes``|![Nuget](https://img.shields.io/nuget/v/SimplyWorks.PrimitiveTypes?style=for-the-badge)|

[SW.PrimitiveTypes](https://www.nuget.org/packages/SimplyWorks.PrimitiveTypes/) is a library
containing highly reusable types and interfaces that pertain to certain patterns of programming and typical value types. It is a dependency for almost all Simplify9's packages.

## Value Objects
The *Value Objects* segment focuses on typical business logic types like
`StreetAddress`, `Weight`, `Money` or `Blob`. This is to cut down on repetitive types in the most
common business applications.

## Bus
The [`Bus`](https://github.com/simplify9/Bus) segment contains interfaces of a typical bus messaging system, like consumers and publishers. The `SimplyWorks.Bus` package looks for implementations of these interfaces to add to the bus' consumers/publishers.

## CqApi
The [`CqApi`](https://github.com/simplify9/CqApi) segment contains interfaces to define typical API handler types, (*Eg:* `IGetHandler<>`, `ICommandHandler<>`, etc.). The `SimplyWorks.CqApi` library looks for implementations of these interfaces to inject into its dynamic API.

## Searchy
The [`Searchy`](https://github.com/simplify9/Searchy) segment revolves around interfaces that describe typical Searchy handlers, to cut down on API's work when it comes understanding a query message.

## CloudFiles
The [`Cloudfiles`](https://github.com/simplify9/CloudFiles) segment has interfaces to describe services that lift blobs/streams on the cloud.
`SimplyWorks.CloudFiles` is an implementation of this interfaces.


## Getting support 👷
If you encounter any bugs, don't hesitate to submit an [issue](https://github.com/simplify9/HttpExtensions/issues). We'll get back to you promptly!
