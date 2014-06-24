﻿namespace Castle.Facilities.Zmq.Rpc.Remote
{
	using System;
	using Castle.Facilities.Zmq.Rpc.Internal;
	using Castle.Zmq;
	using Castle.Zmq.Extensions;
	using Castle.Zmq.Rpc.Model;
	using ProtoBuf;


	internal class RemoteRequest : BaseRequest<ResponseMessage>
	{
		private readonly RequestMessage _requestMessage;

		public RemoteRequest(IZmqContext context, string endpoint, RequestMessage requestMessage) : base(context, endpoint)
		{
			_requestMessage = requestMessage;
		}

		protected override void SendRequest(IZmqSocket socket)
		{
			socket.Send(Builder.SerializeRequest(_requestMessage));
		}

		protected override ResponseMessage GetReply(IZmqSocket socket)
		{
			throw new NotImplementedException();
			socket.Recv();
		}
	}
}