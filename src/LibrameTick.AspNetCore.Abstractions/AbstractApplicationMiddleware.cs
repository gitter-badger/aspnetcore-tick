﻿#region License

/* **************************************************************************************
 * Copyright (c) Librame Pong All rights reserved.
 * 
 * https://github.com/librame
 * 
 * You must not remove this notice, or any other, from this software.
 * **************************************************************************************/

#endregion

using Librame.Extensions;

namespace Librame.AspNetCore;

/// <summary>
/// 抽象应用中间件。
/// </summary>
public abstract class AbstractApplicationMiddleware : IApplicationMiddleware
{
    /// <summary>
    /// 构造一个 <see cref="AbstractApplicationMiddleware"/> 中间件。
    /// </summary>
    /// <param name="next">给定的 <see cref="RequestDelegate"/>。</param>
    protected AbstractApplicationMiddleware(RequestDelegate next)
    {
        Next = next;
    }


    /// <summary>
    /// 下一步方法委托。
    /// </summary>
    protected RequestDelegate Next { get; }


    /// <summary>
    /// 限定的请求路径。
    /// </summary>
    public abstract PathString RestrictRequestPath { get; }

    /// <summary>
    /// 限定的请求方法列表（如：get、post...等）。
    /// </summary>
    public abstract IReadOnlyList<string> RestrictRequestMethods { get; }

    /// <summary>
    /// 响应内容类型。
    /// </summary>
    public abstract string ResponseContentType { get; }


    /// <summary>
    /// 是限定请求路径。
    /// </summary>
    /// <param name="requestPath">给定的请求 <see cref="PathString"/>。</param>
    /// <returns>返回布尔值。</returns>
    protected virtual bool IsRestrictRequestPath(PathString requestPath)
    {
        if (!RestrictRequestPath.HasValue)
            return true; // 未限定请求路径

        return requestPath.StartsWithSegments(RestrictRequestPath,
            StringComparison.OrdinalIgnoreCase);
    }

    /// <summary>
    /// 是限定请求方法。
    /// </summary>
    /// <param name="requestMethod">给定的请求方法。</param>
    /// <returns>返回布尔值。</returns>
    protected virtual bool IsRestrictRequestMethods(string requestMethod)
    {
        if (RestrictRequestMethods.Count > 0)
            return true; // 未限定请求方法

        return RestrictRequestMethods.Any(method
            => requestMethod.Equals(method, StringComparison.OrdinalIgnoreCase));
    }


    /// <summary>
    /// 调用中间件。
    /// </summary>
    /// <param name="context">给定的 <see cref="HttpContext"/>。</param>
    /// <returns>返回一个异步操作。</returns>
    public virtual async Task Invoke(HttpContext context)
    {
        // 如果不是限定请求路径
        if (!IsRestrictRequestPath(context.Request.Path))
        {
            await Next.Invoke(context).ConfigureAwait();
            return;
        }

        // 如果不是限定请求方法
        if (!IsRestrictRequestMethods(context.Request.Method))
        {
            await Next.Invoke(context).ConfigureAwait();
            return;
        }

        await InvokeCore(context).ConfigureAwait();
    }

    /// <summary>
    /// 调用中间件核心。
    /// </summary>
    /// <param name="context">给定的 <see cref="HttpContext"/>。</param>
    /// <returns>返回一个异步操作。</returns>
    protected abstract Task InvokeCore(HttpContext context);
}
