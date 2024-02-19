using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace Kredek.Api.Common.Abstraction;

public interface IFeatureEndpoint
{
    void AddRoute(IEndpointRouteBuilder builder, HttpVerbs verb, string route);
    void Configure(RouteHandlerBuilder builder);
}

public abstract class FeatureEndpoint<TResult> 
    : IFeatureEndpoint
{
    public void AddRoute(IEndpointRouteBuilder builder, HttpVerbs verb, string route)
    {
        var routeBuilder = verb switch
        {
            HttpVerbs.Get => builder.MapGet(route, HandleAsync),
            HttpVerbs.Post => builder.MapPost(route, HandleAsync),
            HttpVerbs.Put => builder.MapPut(route, HandleAsync),
            HttpVerbs.Delete => builder.MapDelete(route, HandleAsync),
            _ => throw new NotSupportedException()
        };

        Configure(routeBuilder);
    }

    public abstract void Configure(RouteHandlerBuilder builder);

    public abstract Task<TResult> HandleAsync(
        CancellationToken cancellationToken = default);
}

public abstract class FeatureEndpoint<TResult, TParameter> 
    : IFeatureEndpoint
{
    public void AddRoute(IEndpointRouteBuilder builder, HttpVerbs verb, string route)
    {
        var routeBuilder = verb switch
        {
            HttpVerbs.Get => builder.MapGet(route, HandleAsync),
            HttpVerbs.Post => builder.MapPost(route, HandleAsync),
            HttpVerbs.Put => builder.MapPut(route, HandleAsync),
            HttpVerbs.Delete => builder.MapDelete(route, HandleAsync),
            _ => throw new NotSupportedException()
        };

        Configure(routeBuilder);
    }

    public abstract void Configure(RouteHandlerBuilder builder);

    public abstract Task<TResult> HandleAsync(
        TParameter parameter, 
        CancellationToken cancellationToken = default);
}

public abstract class FeatureEndpoint<TResult, TParameter1, TParameter2> 
    : IFeatureEndpoint
{
    public void AddRoute(IEndpointRouteBuilder builder, HttpVerbs verb, string route)
    {
        var routeBuilder = verb switch
        {
            HttpVerbs.Get => builder.MapGet(route, HandleAsync),
            HttpVerbs.Post => builder.MapPost(route, HandleAsync),
            HttpVerbs.Put => builder.MapPut(route, HandleAsync),
            HttpVerbs.Delete => builder.MapDelete(route, HandleAsync),
            _ => throw new NotSupportedException()
        };

        Configure(routeBuilder);
    }

    public abstract void Configure(RouteHandlerBuilder builder);

    public abstract Task<TResult> HandleAsync(
        TParameter1 parameter1, 
        TParameter2 parameter2, 
        CancellationToken cancellationToken = default);
}

internal abstract class FeatureEndpoint<TResult, TParameter1, TParameter2, TParameter3> 
    : IFeatureEndpoint
{
    public void AddRoute(IEndpointRouteBuilder builder, HttpVerbs verb, string route)
    {
        var routeBuilder = verb switch
        {
            HttpVerbs.Get => builder.MapGet(route, HandleAsync),
            HttpVerbs.Post => builder.MapPost(route, HandleAsync),
            HttpVerbs.Put => builder.MapPut(route, HandleAsync),
            HttpVerbs.Delete => builder.MapDelete(route, HandleAsync),
            _ => throw new NotSupportedException()
        };

        Configure(routeBuilder);
    }

    public abstract void Configure(RouteHandlerBuilder builder);

    public abstract Task<TResult> HandleAsync(
        TParameter1 parameter1, 
        TParameter2 parameter2, 
        TParameter3 parameter3, 
        CancellationToken cancellationToken = default);
}