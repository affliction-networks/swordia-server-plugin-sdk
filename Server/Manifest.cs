using Atheme.Plugins.Interfaces;
using Atheme.Plugins.Manifests.Types;
using Atheme.Utilities;
using Semver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPluginServer
{
    public struct Manifest : IManifestHelper, IEquatable<IManifestHelper>, IEquatable<Manifest>
    {
        // ReSharper disable once AssignNullToNotNullAttribute This will not be null.
        /// <inheritdoc />
        public string Name => typeof(Manifest).Namespace;

        // ReSharper disable once AssignNullToNotNullAttribute This will not be null.
        /// <inheritdoc />
        public string Key => typeof(Manifest).Namespace;

        /// <inheritdoc />
        public SemVersion Version => new SemVersion(1);

        /// <inheritdoc />
        public Authors Authors =>
            "Affliction Networks LLC.";

        /// <inheritdoc />
        public string Homepage => "https://affliction-networks.com";

        public override bool Equals(object obj) => obj is Manifest other && Equals(other) ||
                                                   obj is IManifestHelper otherManifestHelper &&
                                                   Equals(otherManifestHelper);

        public override int GetHashCode() => ValueUtils.ComputeHashCode(Name, Key, Version, Authors, Homepage);

        public static bool operator ==(Manifest left, Manifest right) => left.Equals(right);

        public static bool operator !=(Manifest left, Manifest right) => !(left == right);

        public bool Equals(Manifest other) => Equals(other as IManifestHelper);

        public bool Equals(IManifestHelper other) => other != null &&
                                                     string.Equals(Name, other.Name, StringComparison.Ordinal) &&
                                                     string.Equals(Key, other.Key, StringComparison.Ordinal) &&
                                                     Version.Equals(other.Version) &&
                                                     Authors.Equals(other.Authors as IEnumerable<Author>) &&
                                                     string.Equals(Homepage, other.Homepage,
                                                         StringComparison.OrdinalIgnoreCase);
    }
}
