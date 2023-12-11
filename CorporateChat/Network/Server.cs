using CorporateChat.Model;
using CorporateChat.Network.IO;
using CorporateChat.View;
using CorporateServer.Network.IO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CorporateChat.Network
{
    // конструктор сервера
    internal class Server
    {        
        // события доставки пакетов
        public event Action connectedEvent;
        public event Action messageRecievedEvent;
        public event Action userDisconnectedEvent;
        public event Action registrationFailedEvent;
        public event Action registrationCompletedEvent;
        public event Action authCompletedEvent;
        public event Action authFailedEvent;
        public event Action newChatCreatedEvent;
        public event Action chatsRecievedEvent;
        public event Action userListRecievedEvent;
        public event Action secAuthCompletedEvent;
        public event Action secAuthErrorEvent;
        public event Action destMessageRecievedEvent;
        public event Action deleteChatEvent;
        public event Action newChatNameRecieved;
        TcpClient tcpClient;
        X509Certificate2 clientCertificate;
        SslStream sslStream;
        public PacketReader packetReader;
        public Guid sessionId { get; set; }
        public Server()
        {
            tcpClient = new TcpClient();
            clientCertificate = new X509Certificate2("C:\\OpenSSL\\client.pfx", "12345");            
        }
        public void ConnectToServer()
        {
            if(!tcpClient.Connected)
            {
                // подключение к серверу
                tcpClient.Connect("127.0.0.1", 7891);
                // создание tls-соединения
                sslStream = new SslStream(tcpClient.GetStream(), false, new RemoteCertificateValidationCallback(ValidateServerCertificate), null);
                sslStream.AuthenticateAsClient("localhost", new X509CertificateCollection { clientCertificate }, SslProtocols.Tls12, false);
                // отмечаемся на сервере
                packetReader = new PacketReader(sslStream);
                // ждем пакеты
                ReadPackets();                             
            }
        }
        public async void ReadPackets()
        {            
            await Task.Run(() =>
            {
                while (true)
                {
                    try
                    {
                        var opcode = packetReader.ReadByte();
                        switch (opcode)
                        {
                            case 1:
                                connectedEvent?.Invoke();
                                break;
                            case 3:
                                registrationFailedEvent?.Invoke();
                                break;
                            case 4:
                                registrationCompletedEvent?.Invoke();
                                break;
                            case 5:
                                messageRecievedEvent?.Invoke();
                                break;
                            case 7:
                                authCompletedEvent?.Invoke();
                                break;
                            case 8:
                                authFailedEvent?.Invoke();
                                break;
                            case 10:
                                userDisconnectedEvent?.Invoke();
                                break;
                            case 12:
                                newChatCreatedEvent?.Invoke();
                                break;
                            case 14:
                                chatsRecievedEvent?.Invoke();
                                break;
                            case 15:
                                userListRecievedEvent?.Invoke();
                                break;
                            case 21:
                                secAuthCompletedEvent?.Invoke();
                                break;
                            case 22:
                                secAuthErrorEvent?.Invoke();
                                break;
                            case 25:
                                destMessageRecievedEvent?.Invoke();
                                break;
                            case 34:
                                deleteChatEvent?.Invoke();
                                break;
                            case 37:
                                newChatNameRecieved?.Invoke();
                                break;
                            default:
                                Console.WriteLine("что-то не так");
                                break;
                        }
                    }
                    catch(EndOfStreamException ex)
                    {
                        Console.WriteLine($"Чтение после конца потока невозможно: {ex.Message}");
                        continue;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Ошибка: {ex.Message}");
                        break;
                    }


                }
            });
        }
        public void ChangeChatName( string chatName, Guid chatId)
        {
            var packet = new PacketBuilder();
            packet.WriteOpCode(35);
            packet.WriteMessage(sessionId.ToString());
            packet.WriteMessage(chatId.ToString());
            packet.WriteMessage(chatName);
            byte[] request = packet.GetPacketBytes();
            sslStream.Write(request, 0, request.Length);
        }
        public void DeleteChat(Guid chatId)
        {
            var packet = new PacketBuilder();
            packet.WriteOpCode(33);
            packet.WriteMessage(sessionId.ToString());
            packet.WriteMessage(chatId.ToString());            
            byte[] request = packet.GetPacketBytes();
            sslStream.Write(request, 0, request.Length);
        }
        public void AddUsersToChat(Guid chatId, ObservableCollection<User> users)
        {
            var packet = new PacketBuilder();
            packet.WriteOpCode(31);
            packet.WriteMessage(sessionId.ToString());
            packet.WriteMessage(chatId.ToString());
            packet.WriteUserIDList(users);
            byte[] request = packet.GetPacketBytes();
            sslStream.Write(request, 0, request.Length);
        }
        public void DeleteUsersFromChat(Guid chatId, ObservableCollection<User> users)
        {
            var packet = new PacketBuilder();
            packet.WriteOpCode(30);
            packet.WriteMessage(sessionId.ToString());
            packet.WriteMessage(chatId.ToString());
            packet.WriteUserIDList(users);
            byte[] request = packet.GetPacketBytes();
            sslStream.Write(request, 0, request.Length);
        }
        public void SendOtpToServer(string OTP)
        {
            var messagePacket = new PacketBuilder();
            messagePacket.WriteOpCode(20);
            messagePacket.WriteMessage(OTP);
            byte[] request = messagePacket.GetPacketBytes();
            sslStream.Write(request, 0, request.Length);
        }
        public void SendMessageToServer(Message newMessage) 
        {
            //Message newMessage = new Message(username, message);

            var messagePacket = new PacketBuilder();
            messagePacket.WriteOpCode(5);
            messagePacket.WriteMessage(sessionId.ToString());
            messagePacket.WriteMessage(newMessage.Id.ToString());
            messagePacket.WriteMessage(newMessage.UserId.ToString());
            messagePacket.WriteMessage(newMessage.UserName.ToString());
            messagePacket.WriteMessage(newMessage.UserSurname.ToString());
            messagePacket.WriteMessage(newMessage.timeCreated.ToString());
            messagePacket.WriteMessage(newMessage.chatId.ToString());
            messagePacket.WriteMessage(newMessage.MessageText);
            byte[] request = messagePacket.GetPacketBytes();
            sslStream.Write(request, 0, request.Length);
        }
        public void SendDestroynigMessageToServer(Message newMessage)
        {
            //Message newMessage = new Message(username, message);

            var messagePacket = new PacketBuilder();
            messagePacket.WriteOpCode(24);
            messagePacket.WriteMessage(sessionId.ToString());
            messagePacket.WriteMessage(newMessage.Id.ToString());
            messagePacket.WriteMessage(newMessage.UserId.ToString());
            messagePacket.WriteMessage(newMessage.UserName.ToString());
            messagePacket.WriteMessage(newMessage.UserSurname.ToString());
            messagePacket.WriteMessage(newMessage.timeCreated.ToString());
            messagePacket.WriteMessage(newMessage.timeToDestroy.ToString());
            messagePacket.WriteMessage(newMessage.chatId.ToString());
            messagePacket.WriteMessage(newMessage.MessageText);
            byte[] request = messagePacket.GetPacketBytes();
            sslStream.Write(request, 0, request.Length);
        }
        public void SendRegidtrationDataToServer(string username, string password, string mail, string name, string surname, string post)
        {
            var messagePacket = new PacketBuilder();
            messagePacket.WriteOpCode(2);
            messagePacket.WriteMessage(username);
            messagePacket.WriteMessage(password);
            messagePacket.WriteMessage(mail);
            messagePacket.WriteMessage(name);
            messagePacket.WriteMessage(surname);
            messagePacket.WriteMessage(post);
            byte[] request = messagePacket.GetPacketBytes();
            sslStream.Write(request, 0, request.Length);
        }
        public void SendAuthDataToServer(string username, string password)
        {
            var messagePacket = new PacketBuilder();
            messagePacket.WriteOpCode(6);
            messagePacket.WriteMessage(username);
            messagePacket.WriteMessage(password);
            byte[] request = messagePacket.GetPacketBytes();
            sslStream.Write(request, 0, request.Length);
        }
        public void SendNewChatData(string name, ObservableCollection<User> introluctors)
        {
            var messagePacket = new PacketBuilder();
            messagePacket.WriteOpCode(11);
            messagePacket.WriteMessage(sessionId.ToString());
            messagePacket.WriteMessage(name);
            messagePacket.WriteUserList(introluctors);
            byte[] request = messagePacket.GetPacketBytes();
            sslStream.Write(request, 0, request.Length);
        }

        public static bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

    }
}
