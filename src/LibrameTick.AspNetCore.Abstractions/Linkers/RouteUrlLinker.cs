﻿#region License

/* **************************************************************************************
 * Copyright (c) Librame Pong All rights reserved.
 * 
 * https://github.com/librame
 * 
 * You must not remove this notice, or any other, from this software.
 * **************************************************************************************/

#endregion

namespace Librame.AspNetCore.Linkers;

/// <summary>
/// 定义实现 <see cref="ILinker"/> 的路由 URL 链接器。
/// </summary>
public class RouteUrlLinker : AbstractLinker
{
    /// <summary>
    /// 构造一个 <see cref="RouteUrlLinker"/>。
    /// </summary>
    /// <param name="routeName">给定的路由名称（可选）。</param>
    /// <param name="values">给定的参数值集合对象（可选）。</param>
    /// <param name="protocol">给定的协议（可选）。</param>
    /// <param name="host">给定的主机（可选）。</param>
    /// <param name="fragment">给定的片段（可选）。</param>
    /// <param name="area">给定的区域（可选）。</param>
    /// <param name="lockedArea">锁定区域（默认锁定；表示区域不会在环境正常化中修改）。</param>
    public RouteUrlLinker(string? routeName = null, object? values = null,
        string? protocol = null, string? host = null, string? fragment = null,
        string? area = null, bool lockedArea = true)
        : base(values, protocol, host, fragment, area, lockedArea)
    {
        RouteName = routeName;
    }


    /// <summary>
    /// 路由名称。
    /// </summary>
    public string? RouteName { get; protected set; }


    /// <summary>
    /// 生成链接。
    /// </summary>
    /// <param name="helper">给定的 <see cref="IUrlHelper"/>。</param>
    /// <returns>返回链接字符串。</returns>
    public override string? GenerateLink(IUrlHelper helper)
        => helper.RouteUrl(RouteName, Values, Protocol, Host, Fragment);


    /// <summary>
    /// 转换为字符串。
    /// </summary>
    /// <returns>返回模拟链接字符串。</returns>
    public override string ToString()
        => $"{nameof(RouteName)}={RouteName};{base.ToString()}";

}
