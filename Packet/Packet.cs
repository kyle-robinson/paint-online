using System;
using System.Net;
using System.Drawing;
using System.Security.Cryptography;

public enum PacketType
{
    LOGIN,
    ENCRYPTED_ADMIN,
    ENCRYPTED_CLIENT_LIST,
    PEN,
    PAINT,
    ENCRYPTED_ENABLE_PAINTING,
    ENCRYPTED_CLEAR_SINGLE,
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
public class EncryptedEnablePaintingPacket : Packet
{
    public byte[] playerName;
    public byte[] enablePainting;
    public EncryptedEnablePaintingPacket( byte[] playerName, byte[] enablePainting )
    {
        this.playerName = playerName;
        this.enablePainting = enablePainting;
        packetType = PacketType.ENCRYPTED_ENABLE_PAINTING;
    }
}

/*   CLEAR CANVAS   */
[Serializable]
public class EncryptedClearSinglePacket : Packet
{
    public byte[] playerName;
    public EncryptedClearSinglePacket( byte[] playerName )
    {
        this.playerName = playerName;
        packetType = PacketType.ENCRYPTED_CLEAR_SINGLE;
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