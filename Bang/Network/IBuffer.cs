namespace Bang.Networks;
public interface IBuffer
{
    public void WriteByte(byte b);
    public void WriteChar(char c);
    public void WriteShort(short s);
    public void WriteInt(int i);
    public void WriteLong(long l);
    public void WriteFloat(float f);
    public void WriteDouble(double d);
    public void WriteString(string str);
    public void WriteChars(char[] chars);

    public byte ReadByte();
    public char ReadChar();
    public short ReadShort();
    public int ReadInt();
    public long ReadLong();
    public float ReadFloat();
    public double ReadDouble();
    public char[] ReadChars(int length);

    public string ReadString(int length);

    public byte[] ToByteArray();
}
