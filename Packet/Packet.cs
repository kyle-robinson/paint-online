using System;
using System.Net;
using System.Drawing;

public enum PacketType
{
    EMPTY,
    SERVER_MESSAGE,
    NICKNAME,
    CLIENT_LIST,
    LOGIN,
    PAINTING,
    PEN
}

[Serializable]
public class Packet
{
    public PacketType packetType { get; set; }
}

[Serializable]
public class EmptyPacket : Packet
{
    public EmptyPacket()
    {
        packetType = PacketType.EMPTY;
    }
}

[Serializable]
public class ServerMessagePacket : Packet
{
    public string message;
    public ServerMessagePacket( string message )
    {
        this.message = message;
        packetType = PacketType.SERVER_MESSAGE;
    }
}

[Serializable]
public class NicknamePacket : Packet
{
    public string name;
    public NicknamePacket( string name )
    {
        this.name = name;
        packetType = PacketType.NICKNAME;
    }
}

[Serializable]
public class ClientListPacket : Packet
{
    public string name;
    public bool removeText;
    public ClientListPacket( string name, bool removeText )
    {
        this.name = name;
        this.removeText = removeText;
        packetType = PacketType.CLIENT_LIST;
    }
}

[Serializable]
public class LoginPacket : Packet
{
    public IPEndPoint EndPoint;
    public LoginPacket( IPEndPoint EndPoint )
    {
        this.EndPoint = EndPoint;
        packetType = PacketType.LOGIN;
    }
}

[Serializable]
public class PaintPacket : Packet
{
    //public Color penColor;
    public int xPos;
    public int yPos;
    public Point mouseLocation;
    public PaintPacket( int xPos, int yPos, Point mouseLocation )
    {
        //this.penColor = penColor;
        this.xPos = xPos;
        this.yPos = yPos;
        this.mouseLocation = mouseLocation;
        packetType = PacketType.PAINTING;
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