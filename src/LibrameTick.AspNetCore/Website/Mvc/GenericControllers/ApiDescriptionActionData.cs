﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Microsoft.AspNetCore.Mvc.Abstractions;

namespace Librame.AspNetCore.Web.Projects
{
    /// <summary>
    /// Represents data used to build an <c>ApiDescription</c>, stored as part of the
    /// <see cref="ActionDescriptor.Properties"/>.
    /// </summary>
    internal class ApiDescriptionActionData
    {
        /// <summary>
        /// The <c>ApiDescription.GroupName</c> of <c>ApiDescription</c> objects for the associated
        /// action.
        /// </summary>
        public string GroupName { get; set; }
    }
}
