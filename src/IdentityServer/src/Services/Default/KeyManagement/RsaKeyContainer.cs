// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using System;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;

namespace Duende.IdentityServer.Services.KeyManagement
{
    /// <summary>
    /// Container class for RsaSecurityKey.
    /// </summary>
    public class RsaKeyContainer : KeyContainer
    {
        /// <summary>
        /// Constructor for RsaKeyContainer.
        /// </summary>
        public RsaKeyContainer()
        {
        }

        /// <summary>
        /// Constructor for RsaKeyContainer.
        /// </summary>
        public RsaKeyContainer(RsaSecurityKey key, DateTime created)
            : base(key.KeyId, created, Duende.IdentityServer.Models.KeyType.RSA)
        {
            if (key.Rsa != null)
            {
                Parameters = key.Rsa.ExportParameters(includePrivateParameters: true);
            }
            else
            {
                Parameters = key.Parameters;
            }
        }

        /// <summary>
        /// The RSAParameters.
        /// </summary>
        public RSAParameters Parameters { get; set; }

        /// <inheritdoc/>
        public override AsymmetricSecurityKey ToSecurityKey()
        {
            return new RsaSecurityKey(Parameters)
            {
                KeyId = Id
            };
        }
    }
}
