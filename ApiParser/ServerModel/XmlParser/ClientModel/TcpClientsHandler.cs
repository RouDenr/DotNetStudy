﻿using System.Net;
using System.Net.Sockets;
using ServerModel.XmlParser.Server;

namespace ServerModel.XmlParser.ClientModel;

public class TcpClientsHandler
	: IClientHandler
{
	public int Port { get; }
	public IPAddress Ip { get; }
	public IEnumerable<IDisposable> Clients { get; set; }
	public IResponseHandler ResponseHandler { get; }
	public bool IsRunning => Listener.Server.IsBound;
	
	private List<ClientHandler> ClientsList { get; }
	private TcpListener Listener { get; }
	public TcpClientsHandler()
	{
		Port = ConnectionData.Port;
		Ip = ConnectionData.Ip; 
			
		Listener = new TcpListener(Ip, Port);
		if (Listener == null)
			throw new Exception("Failed to create TcpListener");
		
		Clients = new List<ClientHandler>();
		ClientsList = Clients as List<ClientHandler> ?? throw new Exception("Failed to cast Clients to List<IClient>");
		ResponseHandler = new TcpResponseHandler();
	}

	public async Task HandleClients()
	{
		// start listening for client connection
		Listener.Start();

		if (!Listener.Server.IsBound)
			throw new Exception("Failed to start listening for client connection");
		Console.WriteLine($"Listening for client connection on {Ip}:{Port}");

		try
		{
			while (true)
			{
				// wait for client to connect
				var client = await Listener.AcceptTcpClientAsync() ?? throw new Exception("Failed to accept client");
				ClientHandler socketHandler = new(client);
				ClientsList.Add(socketHandler);
				Console.WriteLine($"Client connected: {client.Client.RemoteEndPoint}");
				socketHandler.DisconnectedEvent += DisconnectClient;
				_ = socketHandler.ReadHandle();
			}
		}
		finally
		{
			StopHandle();
		}
	}

	private void DisconnectClient(object? sender, SocketHandler socket)
	{
		if (socket is not ClientHandler client)
			return;
		ClientsList.Remove(client);
		client.DisconnectedEvent -= DisconnectClient;
	}

	public void StopHandle()
	{
		foreach (IDisposable client in Clients)
		{
			client.Dispose();
		}
		
		Listener.Stop();
		ClientsList.Clear();
	}
}