// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Duende.IdentityServer.Services.KeyManagement
{
    /// <summary>
    /// Interface to model loading teh current singing key, as well as all keys used in OIDC discovery.
    /// </summary>
    public interface IKeyManager
    {
        /// <summary>
        /// Returns the current signing key.
        /// </summary>
        /// <returns></returns>
        Task<RsaKeyContainer> GetCurrentKeyAsync();

        /// <summary>
        /// Returns all the validation keys.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<RsaKeyContainer>> GetAllKeysAsync();
    }
}
