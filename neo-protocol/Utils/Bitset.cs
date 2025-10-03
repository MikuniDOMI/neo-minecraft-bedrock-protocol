using System.Numerics;

namespace neo_protocol.Utils;

public class Bitset
{
    /// <summary>
    ///     Creates a new Bitset with a specific size.
    /// </summary>
    /// <param name="size">The amount of bits that the Bitset can store.</param>
    public Bitset(int size)
    {
        Size = size;
        IntValue = BigInteger.Zero;
    }

    /// <summary>
    ///     Creates a new Bitset with a specific size and initial value.
    /// </summary>
    /// <param name="size">The amount of bits that the Bitset can store.</param>
    /// <param name="intValue">The initial value of the bitset.</param>
    public Bitset(int size, BigInteger intValue)
    {
        Size = size;
        IntValue = intValue;
    }

    public int Size { get; }
    public BigInteger IntValue { get; private set; }

    /// <summary>
    ///     Gets the low 64 bits of the bitset.
    /// </summary>
    public ulong Low
    {
        get
        {
            if (IntValue <= ulong.MaxValue)
                return (ulong)IntValue;

            return (ulong)(IntValue & ulong.MaxValue);
        }
    }

    /// <summary>
    ///     Gets the high bits of the bitset (for bitsets larger than 64 bits).
    /// </summary>
    public ulong High
    {
        get
        {
            if (Size <= 64)
                return 0;

            return (ulong)(IntValue >> 64);
        }
    }

    /// <summary>
    ///     Sets a bit at a specific index in the Bitset.
    /// </summary>
    /// <param name="i">The index of the bit to set.</param>
    /// <exception cref="IndexOutOfRangeException">Thrown when index is higher than the size of the Bitset.</exception>
    public void Set(int i)
    {
        if (i >= Size)
            throw new IndexOutOfRangeException("index out of bounds");

        IntValue |= BigInteger.One << i;
    }

    /// <summary>
    ///     Unsets a bit at a specific index in the Bitset.
    /// </summary>
    /// <param name="i">The index of the bit to unset.</param>
    /// <exception cref="IndexOutOfRangeException">Thrown when index is higher than the size of the Bitset.</exception>
    public void Unset(int i)
    {
        if (i >= Size)
            throw new IndexOutOfRangeException("index out of bounds");

        IntValue &= ~(BigInteger.One << i);
    }

    /// <summary>
    ///     Returns if a bit at a specific index in the Bitset is set.
    /// </summary>
    /// <param name="i">The index of the bit to check.</param>
    /// <returns>True if the bit is set, false otherwise.</returns>
    /// <exception cref="IndexOutOfRangeException">Thrown when index is higher than the size of the Bitset.</exception>
    public bool Load(int i)
    {
        if (i >= Size)
            throw new IndexOutOfRangeException("index out of bounds");

        return (IntValue & (BigInteger.One << i)) != BigInteger.Zero;
    }

    /// <summary>
    ///     Returns the size of the Bitset.
    /// </summary>
    public int Len()
    {
        return Size;
    }

    /// <summary>
    ///     Checks if any of the specified flags are set in the bitset.
    /// </summary>
    /// <param name="flags">The flags to check.</param>
    /// <returns>True if any of the flags are set, false otherwise.</returns>
    public bool HasFlag(ulong flags)
    {
        return (IntValue & flags) != 0;
    }
}