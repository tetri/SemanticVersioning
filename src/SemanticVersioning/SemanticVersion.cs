using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace SemanticVersioning
{
    [JsonConverter(typeof(SemanticVersionConverter))]
    public readonly struct SemanticVersion : IComparable<SemanticVersion>, IEquatable<SemanticVersion>
    {
        public int Major { get; }
        public int Minor { get; }
        public int Patch { get; }
        public string Prerelease { get; }
        public string Build { get; }

        private static readonly Regex VersionRegex = new Regex(
            @"^(0|[1-9]\d*)\.(0|[1-9]\d*)\.(0|[1-9]\d*)(?:-((?:0|[1-9]\d*|\d*[a-zA-Z-][a-zA-Z0-9-]*)(?:\.(?:0|[1-9]\d*|\d*[a-zA-Z-][a-zA-Z0-9-]*))*))?(?:\+([0-9a-zA-Z-]+(?:\.[0-9a-zA-Z-]+)*))?$",
            RegexOptions.Compiled);

        public SemanticVersion()
        {
            Major = 0;
            Minor = 0;
            Patch = 0;
            Prerelease = string.Empty;
            Build = string.Empty;
        }

        public SemanticVersion(string version)
        {
            var match = VersionRegex.Match(version);
            if (!match.Success)
            {
                throw new ArgumentException("Invalid semantic version format", nameof(version));
            }

            Major = int.Parse(match.Groups[1].Value);
            Minor = int.Parse(match.Groups[2].Value);
            Patch = int.Parse(match.Groups[3].Value);
            Prerelease = match.Groups[4].Success ? match.Groups[4].Value : string.Empty;
            Build = match.Groups[5].Success ? match.Groups[5].Value : string.Empty;
        }

        public SemanticVersion(int major, int minor, int patch, string prerelease = "", string build = "")
        {
            Major = major;
            Minor = minor;
            Patch = patch;
            Prerelease = prerelease ?? string.Empty;
            Build = build ?? string.Empty;
        }

        public override string ToString()
        {
            var version = $"{Major}.{Minor}.{Patch}";
            if (!string.IsNullOrEmpty(Prerelease))
            {
                version += $"-{Prerelease}";
            }
            if (!string.IsNullOrEmpty(Build))
            {
                version += $"+{Build}";
            }
            return version;
        }

        public int CompareTo(SemanticVersion other)
        {
            var majorComparison = Major.CompareTo(other.Major);
            if (majorComparison != 0) return majorComparison;

            var minorComparison = Minor.CompareTo(other.Minor);
            if (minorComparison != 0) return minorComparison;

            var patchComparison = Patch.CompareTo(other.Patch);
            if (patchComparison != 0) return patchComparison;

            return ComparePreRelease(Prerelease, other.Prerelease);
        }

        private static int ComparePreRelease(string left, string right)
        {
            if (string.IsNullOrEmpty(left) && string.IsNullOrEmpty(right)) return 0;
            if (string.IsNullOrEmpty(left)) return 1;
            if (string.IsNullOrEmpty(right)) return -1;

            var leftParts = left.Split('.');
            var rightParts = right.Split('.');

            int minLength = Math.Min(leftParts.Length, rightParts.Length);
            for (int i = 0; i < minLength; i++)
            {
                string leftPart = leftParts[i];
                string rightPart = rightParts[i];

                bool leftIsNumeric = int.TryParse(leftPart, out int leftNum);
                bool rightIsNumeric = int.TryParse(rightPart, out int rightNum);

                if (leftIsNumeric && rightIsNumeric)
                {
                    int comparison = leftNum.CompareTo(rightNum);
                    if (comparison != 0) return comparison;
                }
                else if (leftIsNumeric)
                {
                    return -1;
                }
                else if (rightIsNumeric)
                {
                    return 1;
                }
                else
                {
                    int comparison = string.Compare(leftPart, rightPart, StringComparison.Ordinal);
                    if (comparison != 0)
                        return comparison < 0 ? -1 : 1;
                }
            }

            return leftParts.Length.CompareTo(rightParts.Length);
        }

        public bool Equals(SemanticVersion other) => CompareTo(other) == 0;

        public override bool Equals(object obj) => obj is SemanticVersion other && Equals(other);

        public override int GetHashCode()
        {
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_0_OR_GREATER
    return HashCode.Combine(Major, Minor, Patch, Prerelease);
#else
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + Major.GetHashCode();
                hash = hash * 23 + Minor.GetHashCode();
                hash = hash * 23 + Patch.GetHashCode();
                hash = hash * 23 + (Prerelease?.GetHashCode() ?? 0);
                return hash;
            }
#endif
        }

        public static bool operator ==(SemanticVersion left, SemanticVersion right) => left.Equals(right);
        public static bool operator !=(SemanticVersion left, SemanticVersion right) => !left.Equals(right);
        public static bool operator <(SemanticVersion left, SemanticVersion right) => left.CompareTo(right) < 0;
        public static bool operator >(SemanticVersion left, SemanticVersion right) => left.CompareTo(right) > 0;
        public static bool operator <=(SemanticVersion left, SemanticVersion right) => left.CompareTo(right) <= 0;
        public static bool operator >=(SemanticVersion left, SemanticVersion right) => left.CompareTo(right) >= 0;
    }

    public class SemanticVersionConverter : JsonConverter<SemanticVersion>
    {
        public override SemanticVersion Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var versionString = reader.GetString();
            return new SemanticVersion(versionString);
        }

        public override void Write(Utf8JsonWriter writer, SemanticVersion value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }
}