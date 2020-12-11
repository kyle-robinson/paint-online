using System;
using System.Net;
using System.Drawing;
using System.Security.Cryptography;

public enum PacketType
{
    LOGIN,
    ENCRYPTED_ADMIN,
    ENCRYPTED_CLIENT_LIST,
    ENABLE_PAINTING,
    PEN,
    PAINT,
    CLEAR_SINGLE,
    CLEAR_GLOBAL
}

[Serializable]
public class Packet
{
    public PacketType packetType { get; set; }
}

/*   ADMINISTRATION   */
[Serializable]
public class LoginPacket : Packet
{
    public IPEndPoint EndPoint;
    public RSAParameters PublicKey;
    public LoginPacket( IPEndPoint EndPoint, RSAParameters PublicKey )
    {
        this.EndPoint = EndPoint;
        this.PublicKey = PublicKey;
        packetType = PacketType.LOGIN;
    }
}

[Serializable]
public class EncryptedAdminPacket : Packet
{
    public byte[] adminConnected;
    public EncryptedAdminPacket( byte[] adminConnected )
    {
        this.adminConnected = adminConnected;
        packetType = PacketType.ENCRYPTED_ADMIN;
    }
}

[Serializable]
public class EncryptedClientListPacket : Packet
{
    public byte[] name;
    public byte[] removeText;
    public EncryptedClientListPacket( byte[] name, byte[] removeText )
    {
        this.name = name;
        this.removeText = removeText;
        packetType = PacketType.ENCRYPTED_CLIENT_LIST;
    }
}

/*   PAINTING   */
[Serializable]
public class PaintPacket : Packet
{
    public int xPos;
    public int yPos;
    public Point mouseLocation;
    public PaintPacket( int xPos, int yPos, Point mouseLocation )
    {
        this.xPos = xPos;
        this.yPos = yPos;
        this.mouseLocation = mouseLocation;
        packetType = PacketType.PAINT;
    }
}

[Serializable]
public class PenPacket : Packet
{
    public Color penColor;
    public PenPacket( Color penColor )
    {
        this.penColor = penColor;
        packetType = PacketType.PEN;
    }
}

[Serializable]
public class EnablePaintingPacket : Packet
{
    public string playerName;
    public bool enablePainting;
    public EnablePaintingPacket( string playerName, bool enablePainting )
    {
        this.playerName = playerName;
        this.enablePainting = enablePainting;
        packetType = PacketType.ENABLE_PAINTING;
    }
}

[Serializable]
public class ClearSinglePacket : Packet
{
    public string playerName;
    public ClearSinglePacket( string playerName )
    {
        this.playerName = playerName;
        packetType = PacketType.CLEAR_SINGLE;
    }
}

[Serializable]
public class ClearGlobalPacket : Packet
{
    public ClearGlobalPacket()
    {
        packetType = PacketType.CLEAR_GLOBAL;
    }
}