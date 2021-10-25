﻿#region License

/* **************************************************************************************
 * Copyright (c) Librame Pong All rights reserved.
 * 
 * https://github.com/librame
 * 
 * You must not remove this notice, or any other, from this software.
 * **************************************************************************************/

#endregion

using Librame.AspNetCore;
using Librame.AspNetCore.Themepack;
using Librame.Extensions.Core;

namespace Microsoft.Extensions.DependencyInjection;

/// <summary>
/// <see cref="WebExtensionBuilder"/> 静态扩展。
/// </summary>
public static class WebExtensionBuilderExtensions
{

    /// <summary>
    /// 注册 Librame Web 扩展构建器。
    /// </summary>
    /// <param name="parentBuilder">给定的 <see cref="IExtensionBuilder"/>。</param>
    /// <param name="setupOptions">给定用于设置选项的动作（可选；为空则不设置）。</param>
    /// <param name="configOptions">给定使用 <see cref="IConfiguration"/> 的选项配置（可选；为空则不配置）。</param>
    /// <param name="setupBuilder">给定用于设置构建器的动作（可选；为空则不设置）。</param>
    /// <returns>返回 <see cref="WebExtensionBuilder"/>。</returns>
    public static WebExtensionBuilder AddWeb(this IExtensionBuilder parentBuilder,
        Action<WebExtensionOptions>? setupOptions = null, IConfiguration? configOptions = null,
        Action<WebExtensionBuilder>? setupBuilder = null)
    {
        if (configOptions is null)
            configOptions = typeof(WebExtensionOptions).GetConfigOptionsFromJson();

        var builder = new WebExtensionBuilder(parentBuilder, setupOptions, configOptions);
        setupBuilder?.Invoke(builder);

        builder.AddThemepack();

        return builder;
    }


    private static WebExtensionBuilder AddThemepack(this WebExtensionBuilder builder)
    {
        builder.TryAddOrReplaceService<IThemeManager, InternalThemeManager>();
        builder.TryAddOrReplaceService<IThemeResolver, InternalThemeResolver>();

        return builder;
    }


    ///// <summary>
    ///// 启用支持泛型控制器。
    ///// </summary>
    ///// <param name="builder">给定的 <see cref="IWebBuilder"/>。</param>
    ///// <returns>返回 <see cref="IWebBuilder"/>。</returns>
    //public static IWebBuilder EnableSupportedGenericController(this IWebBuilder builder)
    //    => builder.SetProperty(p => p.SupportedGenericController, true);


    ///// <summary>
    ///// 添加 Web 扩展（支持多次添加，从第二次开始，返回适配器模式）。
    ///// </summary>
    ///// <param name="parentBuilder">给定的父级 <see cref="IExtensionBuilder"/>。</param>
    ///// <param name="configureDependency">给定的配置依赖动作方法（可选）。</param>
    ///// <param name="builderFactory">给定创建 Web 构建器的工厂方法（可选）。</param>
    ///// <returns>返回 <see cref="IWebBuilder"/>。</returns>
    //public static IWebBuilder AddWeb(this IExtensionBuilder parentBuilder,
    //    Action<WebBuilderDependency> configureDependency = null,
    //    Func<IExtensionBuilder, WebBuilderDependency, IWebBuilder> builderFactory = null)
    //    => parentBuilder.AddWeb<WebBuilderDependency>(configureDependency, builderFactory);

    ///// <summary>
    ///// 添加 Web 扩展（支持多次添加，从第二次开始，返回适配器模式）。
    ///// </summary>
    ///// <typeparam name="TDependency">指定的依赖类型。</typeparam>
    ///// <param name="parentBuilder">给定的父级 <see cref="IExtensionBuilder"/>。</param>
    ///// <param name="configureDependency">给定的配置依赖动作方法（可选）。</param>
    ///// <param name="builderFactory">给定创建 Web 构建器的工厂方法（可选）。</param>
    ///// <returns>返回 <see cref="IWebBuilder"/>。</returns>
    //public static IWebBuilder AddWeb<TDependency>(this IExtensionBuilder parentBuilder,
    //    Action<TDependency> configureDependency = null,
    //    Func<IExtensionBuilder, TDependency, IWebBuilder> builderFactory = null)
    //    where TDependency : WebBuilderDependency
    //{
    //    // 如果已经添加过 Web 扩展，则直接返回适配器模式
    //    if (parentBuilder.TryGetBuilder(out IWebBuilder webBuilder))
    //        return new WebBuilderAdapter(parentBuilder, webBuilder);

    //    // Clear Options Cache
    //    ConsistencyOptionsCache.TryRemove<WebBuilderOptions>();

    //    // Add Builder Dependency
    //    var dependency = parentBuilder.AddBuilderDependency(out var dependencyType, configureDependency);
    //    parentBuilder.Services.TryAddReferenceBuilderDependency<WebBuilderDependency>(dependency, dependencyType);

    //    // Create Builder
    //    return builderFactory.NotNullOrDefault(()
    //        => (b, d) => new WebBuilder(b, d)).Invoke(parentBuilder, dependency);
    //}

}
