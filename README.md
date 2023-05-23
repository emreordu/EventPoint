# EventPoint

This document is about what programming skills and techniques you would need when you develop the event application project as an adessi for young adessi adaptation and learning program.

The project has 3 steps. First backend programming(.NET Core), second backend programming(NodeJS) and third step is frontend programming(React). According to my experiences i will try to guide you for necessary things before you start the project. 

## Prerequisite Skills

Before you start this project i think it would be better if you already know or get experience below programming languages, frameworks and technologies:

1. ASP.NET Core
2. ASP.NET Core Web API
3. LINQ
4. Entity Framework
5. REST Architecture 
6. NodeJS
7. ExpressJS
8. ReactJS

## Backend Programming (.NET Core)

For .NET Core backend programming first thing you should learn/study software architectures and design patterns. During project development you will need different approaches as far as the architecture is concerned. For this reason i wanted to start with architectures and design patterns. Below are the architectures and design patterns i used during my project and some additional patterns as they are common ones:

### Software Architectures and Design Patterns

In the beginning we started with n-layer architecture. It's one of the most used and classical architecture in programming world. You can find good examples of it on the internet but for short description you can read following article: [N-tier architecture](https://medium.com/design-microservices-architecture-with-patterns/layered-n-layer-architecture-e15ffdb7fa42)

After that i adapted my project to CQRS design patternt. While i'm doing that i used MediatR library for that. CQRS means Command Query Responsibility Segregation. Basically you separate your code as query and command. You can read this article to learn more details: [What is CQRS](https://learn.microsoft.com/en-us/azure/architecture/patterns/cqrs)
Generally people use CQRS together with MediatR library. You can find an article about it here: [MediatR](https://code-maze.com/cqrs-mediatr-in-aspnet-core)

Finally i worked on adapting my project to onion architecture. I didn't complete it and rolled back to CQRS but i worked on another project with applying onion architecture and complete it. If you'd like to take a look here is a short article about onion architecture: [Onion architecture](https://medium.com/expedia-group-tech/onion-architecture-deed8a554423#:~:text=Onion%20architecture%20is%20built%20on,flexible%2C%20sustainable%20and%20portable%20architecture.)

There's also common design patterns which are used a lot in software development. One of them is Dependency Injection(DI). Dependency Injection is a design pattern i also used a lot in my project. Here's an article about DI: [What is Dependency Injection](https://www.tutorialsteacher.com/ioc/dependency-injection)

### Helper Libraries

There are helper libraries i used and probably you will use to write less code and make your project more readable and less complex. Below i wanted to put the libraries i used during my development process:

1. AutoMapper [AutoMapper Documentation](https://docs.automapper.org/en/stable/)

2. FluentValidation [FluentValidation Documentation](https://docs.fluentvalidation.net/en/latest/)

3. EntityFrameworkCore [EntityFrameworkCore Documentation](https://www.entityframeworktutorial.net/efcore/entity-framework-core.aspx)

### Techniques and Approaches

There are some techniques, approaches, types and technical terms that i used and they are used commonly in .NET core. Some of the ones i remember middleware, IoC Container, Global Error Handling, Global Query Filter, Soft Delete, Delegates, Asynchronous programming, Concurrent Dictionary etc. Of course there are other things but so far these are the ones i remember i used.

#### Middleware

Middleware is a concept came with ASP.NET Core. Middleware is a component (class) which is executed on every request in ASP.NET Core application. You can read this article to learn more about [Middlewares](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/middleware/?view=aspnetcore-7.0)

#### IOC Container

It's also called DI Container, don't be confused they both mean same thing. IOC container is a framework for implementing automatic dependency injection very effectively. This is a framework to create dependencies and inject them automatically when required. It automatically creates objects based on the request and injects them when required. If you're interested you can read this article: [IoC Container](https://www.tutorialsteacher.com/ioc/ioc-container)

#### Global Error Handling

This is an approach to manage the errors. A middleware intercepts the program to handle errors globally. You can read this article to learn about [Global Error Handling](https://code-maze.com/global-error-handling-aspnetcore/)

#### Global Query Filter

This approach makes all the queries has an invisible where query in the background. You don't need to make it over and over. There's a Microsoft article here about [Global Query Filter](https://learn.microsoft.com/en-us/ef/core/querying/filters)

#### Soft Delete

Soft delete means hiding a record without actually/physically deleting it. Instead of deleting that record from your database you put an extra column like isDeleted or isActive and this is boolean. If it's true it shows or hides based on your logic. You can find an article here: [Soft Delete](https://medium.com/@uslperera/soft-delete-with-ef-core-c677bff73ef7)

#### Delegates

C# delegates are similar to pointers to functions, in C or C++. A delegate is a reference type variable that holds the reference to a method. The reference can be changed at runtime. Delegates are especially used for implementing events and the call-back methods. All delegates are implicitly derived from the System.Delegate class. It provides a way which tells which method is to be called when an event is triggered. 
For example, if you click on a Button on a form (Windows Form application), the program would call a specific method. In simple words, it is a type that represents references to methods with a particular parameter list and return type and then calls the method in a program for execution when it is needed. This Microsoft article explains how delegates work in C#: [Delegates](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/delegates/)

#### Asynchronous programming

In asynchronous programming, the code gets executed in a thread without having to wait for an I/O-bound or long-running task to finish. Microsoft recommends Task-based Asynchronous Pattern  to implement asynchronous programming in the .NET Framework or .NET Core applications using async , await keywords and Task class. You can read more here [Asynchronous Programming](https://learn.microsoft.com/en-us/dotnet/csharp/asynchronous-programming/async-scenarios)

#### Concurrent Dictionary

Concurrent dictionary represents a thread-safe collection of key/value pairs that can be accessed by multiple threads concurrently. You can read this article [Concurrent Dictionary](https://www.c-sharpcorner.com/article/concurrentdictionary-in-c-sharp/)
