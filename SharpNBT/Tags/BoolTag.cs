using System;
using System.Runtime.Serialization;
using JetBrains.Annotations;

namespace SharpNBT
{
    /// <summary>
    /// A tag that contains a single 8-bit integer value.
    /// </summary>
    /// <remarks>
    /// This tag type does not exist in the NBT specification, and is included for convenience to differentiate it from the <see cref="ByteTag"/> that it is
    /// actually serialized as.
    /// </remarks>
    [PublicAPI][Serializable]
    public class BoolTag : Tag<bool>
    {
        private const string TRUE = "true";
        private const string FALSE = "false";
        
        /// <summary>
        /// Creates a new instance of the <see cref="SharpNBT.ByteTag"/> class with the specified <paramref name="value"/>.
        /// </summary>
        /// <param name="name">The name of the tag, or <see langword="null"/> if tag has no name.</param>
        /// <param name="value">The value to assign to this tag.</param>
        public BoolTag([CanBeNull] string name, bool value) : base(TagType.Byte, name, value)
        {
        }

        /// <summary>
        /// Required constructor for ISerializable implementation.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> to describing this instance.</param>
        /// <param name="context">The destination (see <see cref="T:System.Runtime.Serialization.StreamingContext" />) for this serialization.</param>
        protected BoolTag(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
        
        /// <inheritdoc cref="object.ToString"/>
        public override string ToString() => $"TAG_Bool({PrettyName}): {(Value ? TRUE : FALSE)}";
        
        /// <summary>
        /// Implicit conversion of this tag to a <see cref="byte"/>.
        /// </summary>
        /// <param name="tag">The tag to convert.</param>
        /// <returns>The tag represented as a <see cref="byte"/>.</returns>
        public static implicit operator bool(BoolTag tag) => tag.Value;
        
        /// <summary>
        /// Gets the <i>string</i> representation of this NBT tag (SNBT).
        /// </summary>
        /// <returns>This NBT tag in SNBT format.</returns>
        /// <seealso href="https://minecraft.fandom.com/wiki/NBT_format#SNBT_format"/>
        public override string Stringify() => $"{StringifyName}{(Value ? TRUE : FALSE)}";
        
    }
}