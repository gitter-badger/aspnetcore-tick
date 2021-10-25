﻿#region License

/* **************************************************************************************
 * Copyright (c) Librame Pong All rights reserved.
 * 
 * https://github.com/librame
 * 
 * You must not remove this notice, or any other, from this software.
 * **************************************************************************************/

#endregion

namespace Librame.AspNetCore.Themepack;

/// <summary>
/// 定义一个布局提供程序接口。
/// </summary>
public interface ILayoutProvider
{
    /// <summary>
    /// 获取主题包的布局路径集合。
    /// </summary>
    /// <param name="pathPattern">给定布局查找的路径模式（可选）。</param>
    /// <param name="nameSelector">给定符合布局查找路径模式的名称选择器（可选）。</param>
    /// <returns>返回包含布局名称与路径的字典集合。</returns>
    Dictionary<string, string> GetRazorPaths(string? pathPattern = null,
        Func<GroupCollection, string>? nameSelector = null);
}
