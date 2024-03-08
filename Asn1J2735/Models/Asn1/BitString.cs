using System.Collections;
using System.Text;

namespace Econolite.Asn1J2735.Models.Asn1;

public class BitString : IEnumerable
  {
    protected byte[] _buffer;
    protected int _bitLen;

    public int Count => this._bitLen;

    public byte[] Buffer
    {
      get => this._buffer;
      set
      {
        this._buffer = value;
        this._bitLen = value.Length * 8;
      }
    }

    public int Length
    {
      get => this._bitLen;
      set
      {
        this._bitLen = value;
        Array.Resize<byte>(ref this._buffer, (value + 7) / 8);
      }
    }

    public BitString Resize(int bitLength)
    {
      Array.Resize<byte>(ref this._buffer, (bitLength + 7) / 8);
      this._bitLen = bitLength;
      return this;
    }

    public bool this[int index]
    {
      get
      {
        if (index >= this._bitLen)
          throw new IndexOutOfRangeException();
        return ((uint) this._buffer[index / 8] & (uint) (128 >> index % 8)) > 0U;
      }
      set
      {
        if (index >= this._bitLen)
          throw new IndexOutOfRangeException();
        if (value)
          this._buffer[index / 8] |= (byte) (128 >> index % 8);
        else
          this._buffer[index / 8] &= (byte) ~(128 >> index % 8);
      }
    }

    public BitString(int length)
    {
      this._bitLen = length >= 0 ? length : throw new ArgumentException();
      this._buffer = new byte[(length + 7) / 8];
    }

    public BitString(BitString value)
    {
      this._bitLen = value.Length;
      this._buffer = new byte[(this._bitLen + 7) / 8];
      System.Buffer.BlockCopy((Array) value.Buffer, 0, (Array) this._buffer, 0, this._buffer.Length);
    }

    public BitString(BitArray bitArray)
    {
      this._bitLen = bitArray.Length;
      this._buffer = new byte[(this._bitLen + 7) / 8];
      for (int index = 0; index < this._bitLen; ++index)
        this.Set(index, bitArray[index]);
    }

    public BitString(bool[] boolArray)
    {
      this._bitLen = boolArray.Length;
      this._buffer = new byte[(this._bitLen + 7) / 8];
      for (int index = 0; index < this._bitLen; ++index)
        this.Set(index, boolArray[index]);
    }

    public BitString(byte[] byteArray, int nbits)
    {
      int length = (nbits + 7) / 8;
      this._bitLen = nbits;
      this._buffer = new byte[length];
      System.Buffer.BlockCopy((Array) byteArray, 0, (Array) this._buffer, 0, nbits / 8);
      if (nbits % 8 <= 0)
        return;
      this._buffer[length - 1] = (byte) ((uint) byteArray[length - 1] & (uint) ((int) byte.MaxValue << 8 - nbits % 8));
    }

    public BitString(byte[] byteArray)
    {
      this._bitLen = byteArray.Length * 8;
      this._buffer = new byte[byteArray.Length];
      System.Buffer.BlockCopy((Array) byteArray, 0, (Array) this._buffer, 0, this._buffer.Length);
    }

    public bool Get(int index)
    {
      if (index >= this._bitLen)
        throw new IndexOutOfRangeException();
      return ((uint) this._buffer[index / 8] & (uint) (128 >> index % 8)) > 0U;
    }

    public void Set(int index, bool value)
    {
      if (index >= this._bitLen)
        throw new IndexOutOfRangeException();
      if (value)
        this._buffer[index / 8] |= (byte) (128 >> index % 8);
      else
        this._buffer[index / 8] &= (byte) ~(128 >> index % 8);
    }

    public void Set(byte[] byteArray)
    {
      if (byteArray == null)
      {
        this._bitLen = 0;
        this._buffer = new byte[0];
      }
      else
      {
        this._bitLen = byteArray.Length * 8;
        this._buffer = new byte[byteArray.Length];
        System.Buffer.BlockCopy((Array) byteArray, 0, (Array) this._buffer, 0, this._buffer.Length);
      }
    }

    public void Set(byte[] byteArray, int nbits)
    {
      int length = (nbits + 7) / 8;
      this._bitLen = nbits;
      this._buffer = new byte[length];
      System.Buffer.BlockCopy((Array) byteArray, 0, (Array) this._buffer, 0, nbits / 8);
      if (nbits % 8 <= 0)
        return;
      this._buffer[length - 1] = (byte) ((uint) byteArray[length - 1] & (uint) ((int) byte.MaxValue << 8 - nbits % 8));
    }

    public void Set(BitArray bitArray)
    {
      this._bitLen = bitArray.Length;
      this._buffer = new byte[(this._bitLen + 7) / 8];
      for (int index = 0; index < this._bitLen; ++index)
        this[index] = bitArray[index];
    }

    public void Set(BitString value)
    {
      this._bitLen = value.Length;
      this._buffer = new byte[(this._bitLen + 7) / 8];
      System.Buffer.BlockCopy((Array) value.Buffer, 0, (Array) this._buffer, 0, this._buffer.Length);
    }

    public void SetAll(bool value)
    {
      byte num = value ? byte.MaxValue : (byte) 0;
      if (this._bitLen <= 0)
        return;
      for (int index = 0; index < this._bitLen / 8; ++index)
        this._buffer[index] = num;
      if (this._bitLen % 8 <= 0)
        return;
      this._buffer[this._bitLen / 8] = (byte) ((uint) num << 8 - this._bitLen % 8);
    }

    public BitArray ToBitArray()
    {
      BitArray bitArray = new BitArray(this._bitLen);
      for (int index = 0; index < this._bitLen; ++index)
        bitArray[index] = this[index];
      return bitArray;
    }

    public BitString And(BitString value)
    {
      if (this._bitLen != value.Length)
        throw new ArgumentException();
      int num = (this._bitLen + 7) / 8;
      for (int index = 0; index < num; ++index)
        this._buffer[index] &= value.Buffer[index];
      return this;
    }

    public BitString Or(BitString value)
    {
      if (this._bitLen != value.Length)
        throw new ArgumentException();
      int num = (this._bitLen + 7) / 8;
      for (int index = 0; index < num; ++index)
        this._buffer[index] |= value.Buffer[index];
      return this;
    }

    public BitString Xor(BitString value)
    {
      if (this._bitLen != value.Length)
        throw new ArgumentException();
      int num = (this._bitLen + 7) / 8;
      for (int index = 0; index < num; ++index)
        this._buffer[index] ^= value.Buffer[index];
      return this;
    }

    public BitString Not()
    {
      int index1 = this._bitLen / 8;
      for (int index2 = 0; index2 < index1; ++index2)
        this._buffer[index2] = (byte) ~this._buffer[index2];
      if (this._bitLen % 8 > 0)
        this._buffer[index1] = (byte) ((uint) ~this._buffer[index1] & (uint) ((int) byte.MaxValue << 8 - this._bitLen % 8));
      return this;
    }

    public override bool Equals(object obj)
    {
      if (obj == null || obj.GetType() != this.GetType())
        return false;
      BitString bitString = (BitString) obj;
      if (this._bitLen != bitString.Length)
        return false;
      for (int index = 0; index < this._bitLen / 8 + (this._bitLen % 8 > 0 ? 1 : 0); ++index)
      {
        if ((int) this.Buffer[index] != (int) bitString.Buffer[index])
          return false;
      }
      return true;
    }

    public override int GetHashCode() => base.GetHashCode();

    public override string ToString()
    {
      if (this.Count <= 0)
        return string.Empty;
      StringBuilder stringBuilder = new StringBuilder(this.Count);
      for (int index = 0; index < this.Count; ++index)
        stringBuilder.Append(this.Get(index) ? "1" : "0");
      return stringBuilder.ToString();
    }

    public virtual object Copy() => (object) new BitString(this);

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) new BitString.boolEnum(this);

    private class boolEnum : IEnumerator
    {
      private int position = -1;
      public BitString bitStr;

      public boolEnum(BitString bitString) => this.bitStr = bitString;

      public bool MoveNext()
      {
        ++this.position;
        return this.position < this.bitStr.Length;
      }

      public void Reset() => this.position = -1;

      object IEnumerator.Current => (object) this.Current;

      public bool Current
      {
        get
        {
          try
          {
            return this.bitStr[this.position];
          }
          catch (IndexOutOfRangeException ex)
          {
            throw new InvalidOperationException();
          }
        }
      }
    }
  }

public static class BitStringExtensions
{
    public static string ToBitString(this int slice, int length)
    {
        var charArray = Convert.ToString((int) slice, 2).PadLeft(length, '0').Reverse().ToArray();
        return new string(charArray);
    }

    public static int ToIntFromBitString(this string bitString)
    {
        var charArray = bitString.Reverse().ToArray();
        return Convert.ToInt32(new string(charArray), 2);
    }
}