﻿#region License

/* **************************************************************************************
 * Copyright (c) Librame Pong All rights reserved.
 * 
 * https://github.com/librame
 * 
 * You must not remove this notice, or any other, from this software.
 * **************************************************************************************/

#endregion

using Librame.Extensions.Resources;

namespace Librame.AspNetCore.Resources;

/// <summary>
/// 定义实现 <see cref="IResource"/> 的版权声明资源。
/// </summary>
public class CopyrightResource : AbstractResource<CopyrightResource>
{

#pragma warning disable CS8618 // 在退出构造函数时，不可为 null 的字段必须包含非 null 值。请考虑声明为可以为 null。

    /// <summary>
    /// 版权所有。
    /// </summary>
    public string Copyright { get; set; }

    /// <summary>
    /// 技术支持。
    /// </summary>
    public string PoweredBy { get; set; }

    /// <summary>
    /// 语言。
    /// </summary>
    public string Culture { get; set; }

    /// <summary>
    /// 应用。
    /// </summary>
    public string Application { get; set; }

    /// <summary>
    /// 主题。
    /// </summary>
    public string Themepack { get; set; }

    /// <summary>
    /// 在 NuGet 查找。
    /// </summary>
    public string SearchInNuget { get; set; }

    /// <summary>
    /// 跳转到微软官方站点。
    /// </summary>
    public string GotoMicrosoft { get; set; }

#pragma warning restore CS8618 // 在退出构造函数时，不可为 null 的字段必须包含非 null 值。请考虑声明为可以为 null。

}
