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
/// 定义存放布局内容的集合。
/// </summary>
/// <typeparam name="TContent">指定的内容类型。</typeparam>
public class LayoutContentCollection<TContent> : IEnumerable<KeyValuePair<string, LayoutContent<TContent>>>
{
    private readonly ConcurrentDictionary<string, LayoutContent<TContent>> _layouts;


    /// <summary>
    /// 构造一个 <see cref="LayoutContentCollection{TContent}"/>。
    /// </summary>
    /// <param name="layouts">给定的 <see cref="ConcurrentDictionary{TKey, TValue}"/>（可选）。</param>
    public LayoutContentCollection(ConcurrentDictionary<string, LayoutContent<TContent>>? layouts = null)
    {
        _layouts = layouts ?? new ConcurrentDictionary<string, LayoutContent<TContent>>();
    }


    /// <summary>
    /// 获取指定键名的布局内容。
    /// </summary>
    /// <param name="key">给定的键名。</param>
    /// <returns>返回 <see cref="LayoutContent{TContent}"/>。</returns>
    public LayoutContent<TContent> this[string key]
        => _layouts[key];

    /// <summary>
    /// 所有布局内容的键名集合。
    /// </summary>
    public ICollection<string> AllKeys
        => _layouts.Keys;


    /// <summary>
    /// 公共布局内容。
    /// </summary>
    /// <value>返回 <see cref="LayoutContent{TContent}"/>。</value>
    public LayoutContent<TContent> Common
        => _layouts.GetOrAdd(LayoutKeys.Common, key => new LayoutContent<TContent>(key));

    /// <summary>
    /// 登入布局内容。
    /// </summary>
    /// <value>返回 <see cref="LayoutContent{TContent}"/>。</value>
    public LayoutContent<TContent> Login
        => _layouts.GetOrAdd(LayoutKeys.Login, key => new LayoutContent<TContent>(key));

    /// <summary>
    /// 管理布局内容。
    /// </summary>
    /// <value>返回 <see cref="LayoutContent{TContent}"/>。</value>
    public LayoutContent<TContent> Manage
        => _layouts.GetOrAdd(LayoutKeys.Manage, key => new LayoutContent<TContent>(key));


    /// <summary>
    /// 获取枚举器。
    /// </summary>
    /// <returns>返回 <see cref="IEnumerable{T}"/>。</returns>
    public IEnumerator<KeyValuePair<string, LayoutContent<TContent>>> GetEnumerator()
        => _layouts.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator()
        => GetEnumerator();


    /// <summary>
    /// 包含指定键名的布局内容。
    /// </summary>
    /// <param name="key">给定的键名。</param>
    /// <returns>返回布尔值。</returns>
    public bool Contains(string key)
        => _layouts.ContainsKey(key);

    /// <summary>
    /// 添加或更新指定键名的布局内容。
    /// </summary>
    /// <param name="key">给定的键名。</param>
    /// <param name="addValueFunc">用于添加布局内容工厂方法。</param>
    /// <param name="updateValueFunc">用于更新布局内容工厂方法。</param>
    /// <returns>返回 <see cref="LayoutContent{TContent}"/>。</returns>
    public LayoutContent<TContent> AddOrUpdate(string key, Func<string, LayoutContent<TContent>> addValueFunc,
        Func<string, LayoutContent<TContent>, LayoutContent<TContent>> updateValueFunc)
        => _layouts.AddOrUpdate(key, addValueFunc, updateValueFunc);

    /// <summary>
    /// 获取或添加指定键名的布局内容。
    /// </summary>
    /// <param name="key">给定的键名。</param>
    /// <param name="valueFunc">用于添加布局内容工厂方法（可选；默认新建）。</param>
    /// <returns>返回 <see cref="LayoutContent{TContent}"/>。</returns>
    public LayoutContent<TContent> GetOrAdd(string key, Func<string, LayoutContent<TContent>>? valueFunc = null)
        => _layouts.GetOrAdd(key, valueFunc ?? (key => new LayoutContent<TContent>(key)));

    /// <summary>
    /// 尝试获取指定键名的布局内容。
    /// </summary>
    /// <param name="key">给定的键名。</param>
    /// <param name="value">输出布局内容。</param>
    /// <returns>返回布尔值。</returns>
    public bool TryGet(string key, [MaybeNullWhen(false)] out LayoutContent<TContent> value)
        => _layouts.TryGetValue(key, out value);

    /// <summary>
    /// 尝试获取指定键名的布局内容。
    /// </summary>
    /// <param name="key">给定的键名。</param>
    /// <param name="value">输出布局内容。</param>
    /// <returns>返回布尔值。</returns>
    public bool TryRemove(string key, [MaybeNullWhen(false)] out LayoutContent<TContent> value)
        => _layouts.TryRemove(key, out value);

}
